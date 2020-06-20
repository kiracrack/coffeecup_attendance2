Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO
Imports System.Data.OleDb

Public Class frmAttendanceLog
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function

    Private Sub frmAttendanceLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If txtOffice.Text <> "" Then
            SaveDefaultComboItem(txtOffice, txtOffice.Text, DirectCast(txtOffice.SelectedItem, ComboBoxItem).HiddenValue(), Me)
        End If
        Me.Dispose()
    End Sub

    Private Sub frmAttendanceLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If OfflineMode = True Then
            CheckBox1.Enabled = False
        Else
            CheckBox1.Enabled = True
        End If
        LoadOffice()
        txtOffice.Text = defaultCombobox(txtOffice, Me, False)
        officeid.Text = defaultCombobox(txtOffice, Me, True)
        LoadYear()
        LoadAttendance()
        If ActiveCamera = False Then
            ckViewPicture.Checked = False
        End If
    End Sub
    Public Sub LoadOffice()
        LoadToComboBox("select officeid,ucase(officename) as office from tblcompoffice order by officename asc", "office", "officeid", txtOffice)
    End Sub

    Private Sub txtOffice_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtOffice.SelectedValueChanged
        officeid.Text = DirectCast(txtOffice.SelectedItem, ComboBoxItem).HiddenValue()
        LoadMonth()
        LoadAttendance()
    End Sub

    Public Sub LoadYear()
        If CheckBox1.Checked = False Then
            LoadToComboBoxQuery("str", "distinct date_format(logindate,'%Y') as str", "tblpayrollattendancelog where officeid='" & officeid.Text & "' order by date_format(logindate,'%Y') asc", txtYear)
        End If
    End Sub

    Private Sub txtYear_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtYear.SelectedValueChanged
        LoadMonth()
        LoadAttendance()
    End Sub

    Public Sub LoadMonth()
        If CheckBox1.Checked = False Then
            LoadToComboBoxQuery("str", "distinct date_format(logindate,'%M') as str", "tblpayrollattendancelog where officeid='" & officeid.Text & "' and date_format(logindate,'%Y')='" & txtYear.Text & "' order by  date_format(logindate,'%m') asc", txtMonth)
        End If
    End Sub

    Private Sub txtMonth_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtMonth.SelectedValueChanged
        LoadDay()
        LoadAttendance()
    End Sub

    Public Sub LoadDay()
        If CheckBox1.Checked = False Then
            LoadToComboBoxQuery("str", "distinct  date_format(logindate,'%d') as str", "tblpayrollattendancelog where officeid='" & officeid.Text & "' and date_format(logindate,'%M')='" & txtMonth.Text & "' order by  date_format(logindate,'%d') asc", txtDay)
        End If
    End Sub

    Private Sub txtDay_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtDay.SelectedValueChanged
        LoadAttendance()
    End Sub

    Public Sub LoadAttendance()
        If txtOffice.Text = "" Then Exit Sub
        If CheckBox1.Checked = False Then
            If txtYear.Text = "" Or txtMonth.Text = "" Or txtDay.Text = "" Then Exit Sub
        End If

        If OfflineMode = True Then
            MyDataGridView_Trace.DataSource = Nothing : dst = New DataSet
            local_msda = New OleDbDataAdapter("select employeeid, logindate as logdate, (select fullname from tblemployees where employeeid =tblpayrollattendancelog.employeeid) as [Employee Name], " _
                                        + " Format([1st_timein], 'hh:mm:ss AMPM') as [Morning IN], Format([1st_timeout], 'hh:mm:ss AMPM') as [Morning Out], " _
                                        + " Format([2nd_timein], 'hh:mm:ss AMPM') as [Afternoon IN], Format([2nd_timeout], 'hh:mm:ss AMPM') as [Afternoon Out], " _
                                        + " Format([3rd_timein], 'hh:mm:ss AMPM') as [Overtime IN], Format([3rd_timeout], 'hh:mm:ss AMPM') as [Overtime OUT] " _
                                        + " from tblpayrollattendancelog where officeid='" & officeid.Text & "' and " & If(CheckBox1.Checked = True, " logindate='" & txtServerdate.Text & "'", "logindate = '" & txtYear.Text & "-" & CDate(txtDay.Text & "/" & txtMonth.Text & "/" & txtYear.Text).ToString("MM") & "-" & txtDay.Text & "'") & " order by [1st_timein] asc;", local_conn)

            local_msda.SelectCommand.CommandTimeout = 9999999
            local_msda.Fill(dst, 0)
            MyDataGridView_Trace.DataSource = dst.Tables(0)
        Else
            MyDataGridView_Trace.DataSource = Nothing : dst = New DataSet
            msda = New MySqlDataAdapter("select tblpayrollattendancelog.employeeid, date_format(logindate,'%Y-%m-%d') as 'logdate', (select fullname from tblemployees where employeeid =tblpayrollattendancelog.employeeid) as 'Employee Name', " _
                                        + " date_format(1st_timein,'%r') as 'Morning IN', date_format(1st_timeout,'%r') as 'Morning Out', " _
                                        + " date_format(2nd_timein,'%r') as 'Afternoon IN', date_format(2nd_timeout,'%r') as 'Afternoon Out', " _
                                        + " date_format(3rd_timein,'%r') as 'Overtime IN', date_format(3rd_timeout,'%r') as 'Overtime OUT' " _
                                        + " from tblpayrollattendancelog inner join tblemployees on tblpayrollattendancelog.employeeid = tblemployees.employeeid  where tblemployees.officeid='" & DirectCast(txtOffice.SelectedItem, ComboBoxItem).HiddenValue() & "' and " & If(CheckBox1.Checked = True, " logindate='" & txtServerdate.Text & "'", "date_format(logindate,'%Y-%m-%d') = '" & txtYear.Text & "-" & CDate(txtDay.Text & "/" & txtMonth.Text & "/" & txtYear.Text).ToString("MM") & "-" & txtDay.Text & "'") & " order by 1st_timein asc;", conn)

            msda.SelectCommand.CommandTimeout = 9999999
            msda.Fill(dst, 0)
            MyDataGridView_Trace.DataSource = dst.Tables(0)
        End If

        MyDataGridView_Trace.Columns("employeeid").Visible = False : MyDataGridView_Trace.Columns("logdate").Visible = False
        GridColumnAlignment(MyDataGridView_Trace, {"Morning IN", "Morning Out", "Afternoon IN", "Afternoon Out", "Overtime IN", "Overtime OUT"}, DataGridViewContentAlignment.MiddleCenter)
    End Sub

    Public Sub ShowPicture(ByVal empid As String, ByVal logindate As String)
        If OfflineMode = True Then
            local_com.CommandText = "select * from tblattendanceimage where employeeid='" & empid & "' and logindate='" & logindate & "'" : local_rst = local_com.ExecuteReader
            While local_rst.Read
                pic_morning_1.Image = If(local_rst("1st_timein").ToString = "", Nothing, Image.FromFile(Application.StartupPath.ToString & "\Image\" & local_rst("1st_timein").ToString & ".jpg"))
                pic_morning_2.Image = If(local_rst("1st_timeout").ToString = "", Nothing, Image.FromFile(Application.StartupPath.ToString & "\Image\" & local_rst("1st_timeout").ToString & ".jpg"))
                pic_afternoon_1.Image = If(local_rst("2nd_timein").ToString = "", Nothing, Image.FromFile(Application.StartupPath.ToString & "\Image\" & local_rst("2nd_timein").ToString & ".jpg"))
                pic_afternoon_2.Image = If(local_rst("2nd_timeout").ToString = "", Nothing, Image.FromFile(Application.StartupPath.ToString & "\Image\" & local_rst("2nd_timeout").ToString & ".jpg"))
                pic_overtime_1.Image = If(local_rst("3rd_timein").ToString = "", Nothing, Image.FromFile(Application.StartupPath.ToString & "\Image\" & local_rst("3rd_timein").ToString & ".jpg"))
                pic_overtime_2.Image = If(local_rst("3rd_timeout").ToString = "", Nothing, Image.FromFile(Application.StartupPath.ToString & "\Image\" & local_rst("3rd_timeout").ToString & ".jpg"))
            End While
            local_rst.Close()
        Else
            com.CommandText = "select * from filedir.tblattendanceimage where employeeid='" & empid & "' and logindate='" & logindate & "'" : rst = com.ExecuteReader
            While rst.Read
                pic_morning_1.Image = convertSQlImage("1st_timein")
                pic_morning_2.Image = convertSQlImage("1st_timeout")
                pic_afternoon_1.Image = convertSQlImage("2nd_timein")
                pic_afternoon_2.Image = convertSQlImage("2nd_timeout")
                pic_overtime_1.Image = convertSQlImage("3rd_timein")
                pic_overtime_2.Image = convertSQlImage("3rd_timeout")
            End While
            rst.Close()
        End If
    End Sub
    Public Function convertSQlImage(ByVal fld As String) As Image
        If rst(fld).ToString <> "" Then
            imgBytes = CType(rst(fld), Byte())
            stream = New MemoryStream(imgBytes, 0, imgBytes.Length)
            img = Image.FromStream(stream)
            convertSQlImage = img
        End If
    End Function

    Private Sub MyDataGridView_Trace_SelectionChanged(sender As Object, e As EventArgs) Handles MyDataGridView_Trace.SelectionChanged
        If MyDataGridView_Trace.RowCount = 0 Then Exit Sub
        ShowPicture(MyDataGridView_Trace.Item("employeeid", MyDataGridView_Trace.CurrentRow.Index).Value().ToString(), MyDataGridView_Trace.Item("logdate", MyDataGridView_Trace.CurrentRow.Index).Value().ToString())
    End Sub

    Private Sub ckViewPicture_CheckedChanged(sender As Object, e As EventArgs) Handles ckViewPicture.CheckedChanged
        If ckViewPicture.Checked = True Then
            SplitContainer1.Panel2Collapsed = False
        Else
            SplitContainer1.Panel2Collapsed = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtYear.Enabled = False
            txtMonth.Enabled = False
            txtDay.Enabled = False
            txtYear.SelectedIndex = -1 : txtMonth.SelectedIndex = -1 : txtDay.SelectedIndex = -1
        Else
            txtYear.Enabled = True
            txtMonth.Enabled = True
            txtDay.Enabled = True
            txtYear.DroppedDown = True
            LoadYear()
        End If

    End Sub
 
     
End Class