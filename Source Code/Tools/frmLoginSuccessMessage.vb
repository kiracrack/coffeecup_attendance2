Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO

Public Class frmLoginSuccessMessage
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function

    Private Sub frmRequestType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowAttendanceLog()
    End Sub

    Public Sub ShowAttendanceLog()
        com.CommandText = "select tblpayrollattendancelog.employeeid, date_format(logindate,'%Y-%m-%d') as 'logdate', " _
                                        + " (select fullname from tblemployees where employeeid =tblpayrollattendancelog.employeeid) as 'empname', " _
                                        + " date_format(1st_timein,'%r') as 'amIN', date_format(1st_timeout,'%r') as 'amOut', " _
                                        + " date_format(2nd_timein,'%r') as 'pmIN', date_format(2nd_timeout,'%r') as 'pmOut', " _
                                        + " date_format(3rd_timein,'%r') as 'overtimeIN', date_format(3rd_timeout,'%r') as 'overtimeOUT' " _
                                        + " from tblpayrollattendancelog inner join tblemployees on tblpayrollattendancelog.employeeid = tblemployees.employeeid  where logindate='" & txtServerdate.Text & "' and tblemployees.employeeid='" & txtEmployeeID.Text & "';" : rst = com.ExecuteReader
        While rst.Read
            txtName.Text = rst("empname").ToString
            txtAmIn.Text = rst("amIN").ToString
            txtAmOut.Text = rst("amOut").ToString
            txtPmIn.Text = rst("pmIN").ToString
            txtPmOut.Text = rst("pmOut").ToString
            'txtOvertimeIn.Text = rst("overtimeIN").ToString
            'txtOvertimeOut.Text = rst("overtimeOUT").ToString
        End While
        rst.Close()
        ShowPicture(txtEmployeeID.Text, txtServerdate.Text, txtSession.Text)
    End Sub
    Public Sub ShowPicture(ByVal empid As String, ByVal logindate As String, ByVal session As String)
        com.CommandText = "select * from filedir.tblattendanceimage where employeeid='" & empid & "' and logindate='" & txtServerdate.Text & "'" : rst = com.ExecuteReader
        While rst.Read
            pic_morning_1.Image = convertSQlImage(session)
        End While
        rst.Close()
        If pic_morning_1.Image Is Nothing Then
            lblNoimage.Visible = True
        Else
            lblNoimage.Visible = False
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
    Private Sub cmdset_Click(sender As Object, e As EventArgs) Handles cmdset.Click
        Me.Close()
    End Sub
End Class