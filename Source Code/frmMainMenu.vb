Imports System.Runtime.InteropServices, System.IO, DShowNET, DShowNET.Device, System.Drawing, System.Drawing.Imaging, System.Collections, System.ComponentModel, System.Diagnostics
Imports System.Data, DirectShowLib

Public Class frmMainMenu
    Implements DShowNET.ISampleGrabberCB
    <DllImport("oleaut32.dll")> _
    Public Shared Function OleCreatePropertyFrame(ByVal hwndOwner As IntPtr, ByVal x As Integer, ByVal y As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszCaption As String, ByVal cObjects As Integer, <MarshalAs(UnmanagedType.[Interface], ArraySubType:=UnmanagedType.IUnknown)> ByRef ppUnk As Object, _
      ByVal cPages As Integer, ByVal lpPageClsID As IntPtr, ByVal lcid As Integer, ByVal dwReserved As Integer, ByVal lpvReserved As IntPtr) As Integer
    End Function

    Dim CurrPnl As String
    Friend Enum PlayState
        Init
        Stopped
        Paused
        Running
    End Enum

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.F11) Then
            cmdChangePassword.PerformClick()

        ElseIf keyData = (Keys.F12) Then
            cmdViewAttendance.PerformClick()

        ElseIf keyData = (Keys.F1) Then
            radMorning.Checked = True

        ElseIf keyData = (Keys.F2) Then
            radAfterNoon.Checked = True

        ElseIf keyData = (Keys.F3) Then
            radovertime.Checked = True

        End If
        Return ProcessCmdKey
    End Function

    Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTime.Text = Now.ToString("h:mm:ss tt")
        If System.IO.Directory.Exists(Application.StartupPath.ToString & "\Image") = False Then
            System.IO.Directory.CreateDirectory(Application.StartupPath.ToString & "\Image")
        End If

        If System.IO.File.Exists(file_conn) = False Then
            frmConnectionSetup.ShowDialog()
            Me.Close()
        End If

        If OpenMysqlConnection() = False Then
            'ActivateOfflineMode()
        Else
            OfflineMode = False
            lblOfflinemode.Visible = False
            txtDate.Text = GetServerDate()
            txtServerdate.Text = ConvertDate(GetServerDate)
            'CaptureTempOnlineData()
        End If

        CheckTime()
        'check if directX installed or not and is there any capture devices
        CheckAvailableCamera()
        If ActiveCamera = True Then
            cmdCameraSettings.Visible = True
            If capDevices.Count <> 0 Then
                For Each d As DShowNET.Device.DsDevice In capDevices
                    txtCameraDevice.Items.Add(d.Name)
                    txtCameraDevice.SelectedIndex = 0
                Next
            End If

            If capDevices.Count > 1 Then
                cmdSelectCamera.Visible = True
            Else
                cmdSelectCamera.Visible = False
            End If
        Else
            cmdCameraSettings.Visible = False
            cmdSelectCamera.Visible = False
        End If
    End Sub
    Public Sub RefreshDate()
        OfflineMode = False
        lblOfflinemode.Visible = False
        txtDate.Text = GetServerDate()
        txtServerdate.Text = ConvertDate(GetServerDate)
    End Sub

    'Public Sub ActivateOfflineMode()
    '    local_com.CommandText = "UPDATE tblsystemmode set offlinemode=1" : local_com.ExecuteNonQuery()
    '    OfflineMode = True
    '    CheckOnlineServer.Enabled = True
    '    lblOfflinemode.Visible = True
    '    txtDate.Text = Now.ToString("dddd MMMM dd, yyyy")
    '    txtServerdate.Text = ConvertDate(Now.ToShortDateString)
    'End Sub
    'Public Sub CaptureTempOnlineData()
    '    local_com.CommandText = "delete from tblemployees" : local_com.ExecuteNonQuery()
    '    com.CommandText = "SELECT employeeid,officeid,fullname,attendancepassword,resigned,(select onetimeinout from tblpayrollshiftsettings where shiftcode=tblemployees.shiftcode) as shift FROM `tblemployees`;" : rst = com.ExecuteReader
    '    While rst.Read
    '        local_com.CommandText = "insert into tblemployees (employeeid,officeid,fullname,attendancepassword,resigned,onetimeinout) values('" & rst("employeeid").ToString & "','" & rst("officeid").ToString & "','" & rst("fullname").ToString & "','" & rst("attendancepassword").ToString & "'," & rst("resigned") & "," & rst("shift") & ")" : local_com.ExecuteNonQuery()
    '    End While
    '    rst.Close()

    '    local_com.CommandText = "delete from tblpayrollattendancelog" : local_com.ExecuteNonQuery()
    '    local_com.CommandText = "delete from tblattendanceimage" : local_com.ExecuteNonQuery()
    '    com.CommandText = "SELECT * FROM `tblpayrollattendancelog` where logindate='" & txtServerdate.Text & "';" : rst = com.ExecuteReader
    '    While rst.Read
    '        local_com.CommandText = "insert into tblpayrollattendancelog (employeeid,officeid,logindate,1st_timein,1st_timeout,2nd_timein,2nd_timeout,3rd_timein,3rd_timeout) " _
    '                + " values ('" & rst("employeeid").ToString & "','" & rst("officeid").ToString & "','" & ConvertDate(rst("logindate").ToString) & "', " _
    '                                                            + " " & If(rst("1st_timein").ToString = "", "''", "'" & ConvertServerTime(rst("1st_timein").ToString) & "'") & ", " _
    '                                                            + " " & If(rst("1st_timeout").ToString = "", "''", "'" & ConvertServerTime(rst("1st_timeout").ToString) & "'") & ", " _
    '                                                            + " " & If(rst("2nd_timein").ToString = "", "''", "'" & ConvertServerTime(rst("2nd_timein").ToString) & "'") & ", " _
    '                                                            + " " & If(rst("2nd_timeout").ToString = "", "''", "'" & ConvertServerTime(rst("2nd_timeout").ToString) & "'") & ", " _
    '                                                            + " " & If(rst("3rd_timein").ToString = "", "''", "'" & ConvertServerTime(rst("3rd_timein").ToString) & "'") & ", " _
    '                                                            + " " & If(rst("3rd_timeout").ToString = "", "''", "'" & ConvertServerTime(rst("3rd_timeout").ToString) & "'") & ")" : local_com.ExecuteNonQuery()

    '        local_com.CommandText = "insert into tblattendanceimage (employeeid,logindate) " _
    '               + " values ('" & rst("employeeid").ToString & "','" & ConvertDate(rst("logindate").ToString) & "')" : local_com.ExecuteNonQuery()
    '    End While
    '    rst.Close()
    'End Sub

    Private Sub radAfterNoon_CheckedChanged(sender As Object, e As EventArgs) Handles radAfterNoon.CheckedChanged
        ChangeShift()
    End Sub

    Private Sub radMorning_CheckedChanged(sender As Object, e As EventArgs) Handles radMorning.CheckedChanged
        ChangeShift()
    End Sub

    Public Sub CheckTime()
        If Now.ToShortTimeString > CDate("00:00:00") And Now.ToShortTimeString < CDate("08:00:00") Then
            ' txtServerdate.Text = ConvertDate(CDate(GetServerDate()).AddDays(-1))
            radAfterNoon.Checked = True
        Else
            If Now.ToShortTimeString > CDate("14:30:00") And Now.ToShortTimeString < CDate("23:59:59") Then
                txtServerdate.Text = ConvertDate(GetServerDate())
                radAfterNoon.Checked = True
            Else
                txtServerdate.Text = ConvertDate(GetServerDate())
                radMorning.Checked = True
            End If
          
        End If
    End Sub
    Public Sub ChangeShift()
        If radMorning.Checked = True Then
            txtServerdate.Text = ConvertDate(GetServerDate())
            radMorning.BackColor = Color.Green
            radMorning.ForeColor = Color.White
            radAfterNoon.BackColor = DefaultBackColor
            radAfterNoon.ForeColor = DefaultForeColor
        Else
            'If Now.ToShortTimeString > CDate("12:00:00") And Now.ToShortTimeString < CDate("23:59:59") Then
            '    txtServerdate.Text = ConvertDate(GetServerDate())
            'Else
            '    txtServerdate.Text = ConvertDate(CDate(GetServerDate()).AddDays(-1))
            'End If
            radAfterNoon.BackColor = Color.Green
            radAfterNoon.ForeColor = Color.White
            radMorning.BackColor = DefaultBackColor
            radMorning.ForeColor = DefaultForeColor
        End If
    End Sub
    Private Sub txtEmployeeID_GotFocus(sender As Object, e As EventArgs) Handles txtEmployeeID.GotFocus
        If txtEmployeeID.Text = "EMPLOYEE ID" Then
            txtEmployeeID.Text = ""
        End If
    End Sub

    Private Sub txtEmployeeID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmployeeID.KeyPress
        If e.KeyChar() = Chr(13) Then
            txtPassword.Focus()
            txtPassword.SelectAll()
        End If
        'If e.KeyChar() = Chr(13) Then
        '    If OfflineMode = True Then
        '        OfflineModeLogin()
        '    Else
        '        OnlineModeLogin()
        '    End If
        'End If
    End Sub

    Private Sub txtEmployeeID_LostFocus(sender As Object, e As EventArgs) Handles txtEmployeeID.LostFocus
        If txtEmployeeID.Text = "" Then
            txtEmployeeID.Text = "EMPLOYEE ID"
        End If
    End Sub

    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text = "Password" Then
            txtPassword.Text = ""
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar() = Chr(13) Then
            If OfflineMode = True Then
                ' OfflineModeLogin()
            Else
                OnlineModeLogin()
            End If
        End If
    End Sub

 
    Public Sub OnlineModeLogin()
        If countqry("tblemployees", "employeeid='" & txtEmployeeID.Text & "' and resigned=0") = 0 Then
            MessageBox.Show("Employee record not found!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmployeeID.Focus()
            txtEmployeeID.SelectAll()
            Exit Sub
        End If
        If qrysingledata("attendancepassword", "attendancepassword", "tblemployees where employeeid='" & txtEmployeeID.Text & "' and resigned=0") = "" Then
            frmSetOneTimePassword.txtEmployeeID.Text = txtEmployeeID.Text
            frmSetOneTimePassword.ShowDialog(Me)
        Else
            Dim officeid As String = qrysingledata("officeid", "officeid", "tblemployees where employeeid='" & txtEmployeeID.Text & "'")
            Dim shiftcode As String = qrysingledata("shiftcode", "shiftcode", "tblemployees where employeeid='" & txtEmployeeID.Text & "'")
            Dim onetimeinout As Boolean = False
            If countqry("tblpayrollshiftsettings", "shiftcode in (select shiftcode from tblemployees where employeeid='" & txtEmployeeID.Text & "')") > 0 Then
                onetimeinout = CBool(qrysingledata("onetime", "ifnull(onetimeinout,0) as onetime", "tblemployees inner join tblpayrollshiftsettings on tblemployees.shiftcode=tblpayrollshiftsettings.shiftcode where employeeid='" & txtEmployeeID.Text & "'"))
            End If
            Dim getPassword As String = EncryptTripleDES(UCase(txtEmployeeID.Text) + txtPassword.Text)
            If countqry("tblemployees", "employeeid='" & txtEmployeeID.Text & "' and attendancepassword='" & EncryptTripleDES(UCase(txtEmployeeID.Text) + txtPassword.Text) & "'") > 0 Then
                Dim messagestatus As String = "" : Dim session As String = "" : Dim attDate As String = ""
                If radMorning.Checked = True Then
                    If countqry("tblpayrollattendancelog", "logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = 0 Then
                        com.CommandText = "insert into tblpayrollattendancelog set employeeid='" & txtEmployeeID.Text & "', shiftcode='" & shiftcode & "', officeid='" & officeid & "', logindate='" & txtServerdate.Text & "', 1st_timein=current_time" : com.ExecuteNonQuery()
                        messagestatus = "login in your AM Shift"
                        session = "1st_timein"
                        attDate = txtServerdate.Text
                        com.CommandText = "insert into filedir.tblattendanceimage set employeeid='" & txtEmployeeID.Text & "',officeid='" & officeid & "', logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
                        If ActiveCamera = True Then
                            UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "1st_timein", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
                        End If
                    Else
                        If qrysingledata("1st_timein", "1st_timein", "tblpayrollattendancelog where logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = "" Then
                            com.CommandText = "update tblpayrollattendancelog set 1st_timein=current_time where employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
                            If ActiveCamera = True Then
                                UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "1st_timein", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
                            End If
                            session = "1st_timein"
                            attDate = txtServerdate.Text
                            messagestatus = "login in your AM Shift"
                        Else
                            If qrysingledata("1st_timeout", "1st_timeout", "tblpayrollattendancelog where logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = "" Then
                                com.CommandText = "update tblpayrollattendancelog set 1st_timeout=current_time where employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
                                If ActiveCamera = True Then
                                    UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "1st_timeout", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
                                End If
                                session = "1st_timeout"
                                attDate = txtServerdate.Text
                                messagestatus = "logout in your AM Shift"
                            Else
                                MessageBox.Show("You have already logout AM Shift!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf radAfterNoon.Checked = True Then
                    If countqry("tblpayrollattendancelog", "1st_timein is not null and 1st_timeout is null and logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") > 0 And onetimeinout = False Then
                        MessageBox.Show("You have not yet logout your AM Shift!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If countqry("tblpayrollattendancelog", "logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = 0 Then
                        If countqry("tblpayrollattendancelog", " logindate='" & ConvertDate(CDate(txtServerdate.Text).AddDays(-1)) & "' and employeeid='" & txtEmployeeID.Text & "' and 2nd_timein is not null and 2nd_timeout is null") > 0 Then
                            com.CommandText = "update tblpayrollattendancelog set 2nd_timeout=current_time where employeeid='" & txtEmployeeID.Text & "' and logindate='" & ConvertDate(CDate(txtServerdate.Text).AddDays(-1)) & "'" : com.ExecuteNonQuery()
                            If ActiveCamera = True Then
                                UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & ConvertDate(CDate(txtServerdate.Text).AddDays(-1)) & "'", "2nd_timeout", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
                            End If
                            session = "2nd_timeout"
                            attDate = ConvertDate(CDate(txtServerdate.Text).AddDays(-1))
                            messagestatus = "logout in your PM Shift"
                        Else
                            com.CommandText = "insert into tblpayrollattendancelog set employeeid='" & txtEmployeeID.Text & "',shiftcode='" & shiftcode & "',officeid='" & officeid & "', logindate='" & txtServerdate.Text & "', 2nd_timein=current_time" : com.ExecuteNonQuery()
                            com.CommandText = "insert into filedir.tblattendanceimage set employeeid='" & txtEmployeeID.Text & "',officeid='" & officeid & "', logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
                            If ActiveCamera = True Then
                                UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "2nd_timein", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
                            End If
                            session = "2nd_timein"
                            attDate = txtServerdate.Text
                            messagestatus = "login in your PM Shift"
                        End If
                    Else
                        If qrysingledata("2nd_timein", "2nd_timein", "tblpayrollattendancelog where logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = "" And onetimeinout = False Then
                            com.CommandText = "update tblpayrollattendancelog set 2nd_timein=current_time where employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
                            If ActiveCamera = True Then
                                UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "2nd_timein", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
                            End If
                            session = "2nd_timein"
                            attDate = txtServerdate.Text
                            messagestatus = "login in your PM Shift"
                        Else
                            If qrysingledata("2nd_timeout", "2nd_timeout", "tblpayrollattendancelog where logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = "" Then
                                com.CommandText = "update tblpayrollattendancelog set 2nd_timeout=current_time where employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
                                If ActiveCamera = True Then
                                    UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "2nd_timeout", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
                                End If
                                session = "2nd_timeout"
                                attDate = txtServerdate.Text
                                messagestatus = "logout in your PM Shift"
                            Else
                                MessageBox.Show("You have already logout your PM Shift!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                    End If
               
                End If
                frmLoginSuccessMessage.txtMessage.Text = "You're successfully " & messagestatus & "!"
                frmLoginSuccessMessage.txtSession.Text = session
                frmLoginSuccessMessage.txtServerdate.Text = attDate
                frmLoginSuccessMessage.txtEmployeeID.Text = txtEmployeeID.Text
                frmLoginSuccessMessage.ShowDialog(Me)
                ' CaptureTempOnlineData()
                txtEmployeeID.Text = "EMPLOYEE ID" : txtPassword.Text = "Password" : txtEmployeeID.Focus() : txtEmployeeID.SelectAll() : RefreshDate()
                ChangeShift()
            Else
                MessageBox.Show("Invalid username and password!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtPassword.Focus()
                txtPassword.SelectAll()
            End If
        End If
    End Sub


    'Public Sub OnlineModeLogin()
    '    If countqry("tblemployees", "employeeid='" & txtEmployeeID.Text & "' and resigned=0") = 0 Then
    '        MessageBox.Show("Employee record not found!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        txtEmployeeID.Focus()
    '        txtEmployeeID.SelectAll()
    '        Exit Sub
    '    End If
    '    If qrysingledata("attendancepassword", "attendancepassword", "tblemployees where employeeid='" & txtEmployeeID.Text & "' and resigned=0") = "" Then
    '        frmSetOneTimePassword.txtEmployeeID.Text = txtEmployeeID.Text
    '        frmSetOneTimePassword.ShowDialog(Me)
    '    Else
    '        Dim officeid As String = qrysingledata("officeid", "officeid", "tblemployees where employeeid='" & txtEmployeeID.Text & "'")
    '        Dim shiftcode As String = qrysingledata("shiftcode", "shiftcode", "tblemployees where employeeid='" & txtEmployeeID.Text & "'")
    '        'If officeid = "" Then
    '        '    MessageBox.Show("You are currently not assign on department/office! Please contact your system administrator", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        '    txtEmployeeID.Focus()
    '        '    txtEmployeeID.SelectAll()
    '        '    Exit Sub
    '        'End If
    '        Dim onetimeinout As Boolean = False
    '        If countqry("tblpayrollshiftsettings", "shiftcode in (select shiftcode from tblemployees where employeeid='" & txtEmployeeID.Text & "')") > 0 Then
    '            onetimeinout = CBool(qrysingledata("onetime", "ifnull(onetimeinout,0) as onetime", "tblemployees inner join tblpayrollshiftsettings on tblemployees.shiftcode=tblpayrollshiftsettings.shiftcode where employeeid='" & txtEmployeeID.Text & "'"))
    '        End If
    '        Dim getPassword As String = EncryptTripleDES(UCase(txtEmployeeID.Text) + txtPassword.Text)
    '        'If Now.ToShortTimeString > CDate("00:00:00") And Now.ToShortTimeString < CDate("04:00:00") Then
    '        '    If countqry("tblpayrollattendancelog", "logindate='" & ConvertDate(GetServerDate()) & "' and employeeid='" & txtEmployeeID.Text & "'") = 0 Then
    '        '        txtServerdate.Text = ConvertDate(GetServerDate())
    '        '        radMorning.Checked = True
    '        '    End If
    '        'End If
    '        If countqry("tblemployees", "employeeid='" & txtEmployeeID.Text & "' and attendancepassword='" & EncryptTripleDES(UCase(txtEmployeeID.Text) + txtPassword.Text) & "'") > 0 Then
    '            Dim messagestatus As String = "" : Dim session As String = ""
    '            If radMorning.Checked = True Then
    '                If countqry("tblpayrollattendancelog", "logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = 0 Then
    '                    com.CommandText = "insert into tblpayrollattendancelog set employeeid='" & txtEmployeeID.Text & "', shiftcode='" & shiftcode & "', officeid='" & officeid & "', logindate='" & txtServerdate.Text & "', 1st_timein=current_time" : com.ExecuteNonQuery()
    '                    messagestatus = "login in your AM Shift"
    '                    session = "1st_timein"
    '                    com.CommandText = "insert into filedir.tblattendanceimage set employeeid='" & txtEmployeeID.Text & "',officeid='" & officeid & "', logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
    '                    If ActiveCamera = True Then
    '                        UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "1st_timein", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
    '                    End If
    '                Else
    '                    If qrysingledata("1st_timein", "1st_timein", "tblpayrollattendancelog where logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = "" Then
    '                        com.CommandText = "update tblpayrollattendancelog set 1st_timein=current_time where employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
    '                        If ActiveCamera = True Then
    '                            UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "1st_timein", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
    '                        End If
    '                        session = "1st_timein"
    '                        messagestatus = "login in your AM Shift"
    '                    Else
    '                        If qrysingledata("1st_timeout", "1st_timeout", "tblpayrollattendancelog where logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = "" Then
    '                            com.CommandText = "update tblpayrollattendancelog set 1st_timeout=current_time where employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
    '                            If ActiveCamera = True Then
    '                                UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "1st_timeout", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
    '                            End If
    '                            session = "1st_timeout"
    '                            messagestatus = "logout in your AM Shift"
    '                        Else
    '                            MessageBox.Show("You have already logout AM Shift!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                            Exit Sub
    '                        End If
    '                    End If
    '                End If
    '            ElseIf radAfterNoon.Checked = True Then
    '                If countqry("tblpayrollattendancelog", "1st_timein is not null and 1st_timeout is null and logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") > 0 And onetimeinout = False Then
    '                    MessageBox.Show("You have not yet logout your AM Shift!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Exit Sub
    '                End If
    '                If countqry("tblpayrollattendancelog", "logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = 0 Then
    '                    com.CommandText = "insert into tblpayrollattendancelog set employeeid='" & txtEmployeeID.Text & "',shiftcode='" & shiftcode & "',officeid='" & officeid & "', logindate='" & txtServerdate.Text & "', 2nd_timein=current_time" : com.ExecuteNonQuery()
    '                    com.CommandText = "insert into filedir.tblattendanceimage set employeeid='" & txtEmployeeID.Text & "',officeid='" & officeid & "', logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
    '                    If ActiveCamera = True Then
    '                        UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "2nd_timein", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
    '                    End If
    '                    session = "2nd_timein"
    '                    messagestatus = "login in your PM Shift"
    '                Else
    '                    If qrysingledata("2nd_timein", "2nd_timein", "tblpayrollattendancelog where logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = "" And onetimeinout = False Then
    '                        com.CommandText = "update tblpayrollattendancelog set 2nd_timein=current_time where employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
    '                        If ActiveCamera = True Then
    '                            UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "2nd_timein", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
    '                        End If
    '                        session = "2nd_timein"
    '                        messagestatus = "login in your PM Shift"
    '                    Else
    '                        If qrysingledata("2nd_timeout", "2nd_timeout", "tblpayrollattendancelog where logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = "" Then
    '                            com.CommandText = "update tblpayrollattendancelog set 2nd_timeout=current_time where employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
    '                            If ActiveCamera = True Then
    '                                UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "2nd_timeout", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
    '                            End If
    '                            session = "2nd_timeout"
    '                            messagestatus = "logout in your PM Shift"
    '                        Else
    '                            MessageBox.Show("You have already logout your PM Shift!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                            Exit Sub
    '                        End If
    '                    End If
    '                End If
    '            ElseIf radovertime.Checked = True Then
    '                If countqry("tblpayrollattendancelog", "2nd_timein is not null and 2nd_timeout is null and logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") > 0 Then
    '                    MessageBox.Show("You have not yet logout your PM Shift!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Exit Sub
    '                End If
    '                If countqry("tblpayrollattendancelog", "logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = 0 Then
    '                    com.CommandText = "insert into tblpayrollattendancelog set employeeid='" & txtEmployeeID.Text & "',shiftcode='" & shiftcode & "',officeid='" & officeid & "', logindate='" & txtServerdate.Text & "', 3rd_timein=current_time" : com.ExecuteNonQuery()
    '                    com.CommandText = "insert into filedir.tblattendanceimage set employeeid='" & txtEmployeeID.Text & "',officeid='" & officeid & "', logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
    '                    If ActiveCamera = True Then
    '                        UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "3rd_timein", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
    '                    End If
    '                    session = "3rd_timein"
    '                    messagestatus = "login your overtime session"
    '                Else
    '                    If qrysingledata("3rd_timein", "3rd_timein", "tblpayrollattendancelog where logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = "" Then
    '                        com.CommandText = "update tblpayrollattendancelog set 3rd_timein=current_time where employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
    '                        If ActiveCamera = True Then
    '                            UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "3rd_timein", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
    '                        End If
    '                        session = "3rd_timein"
    '                        messagestatus = "login in your overtime session"
    '                    Else
    '                        If qrysingledata("3rd_timeout", "3rd_timeout", "tblpayrollattendancelog where logindate='" & txtServerdate.Text & "' and employeeid='" & txtEmployeeID.Text & "'") = "" Then
    '                            com.CommandText = "update tblpayrollattendancelog set 3rd_timeout=current_time where employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'" : com.ExecuteNonQuery()
    '                            If ActiveCamera = True Then
    '                                UpdateImage("employeeid='" & txtEmployeeID.Text & "' and logindate='" & txtServerdate.Text & "'", "3rd_timeout", "filedir.tblattendanceimage", TakeScreenShot(PicturePanel), Me)
    '                            End If
    '                            session = "3rd_timeout"
    '                            messagestatus = "logout in your overtime session"
    '                        Else

    '                            MessageBox.Show("You have already logout your overtime session!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                            Exit Sub
    '                        End If
    '                    End If
    '                End If
    '            End If
    '            frmLoginSuccessMessage.txtMessage.Text = "You're successfully " & messagestatus & "!"
    '            frmLoginSuccessMessage.txtSession.Text = session
    '            frmLoginSuccessMessage.txtServerdate.Text = txtServerdate.Text
    '            frmLoginSuccessMessage.txtEmployeeID.Text = txtEmployeeID.Text
    '            frmLoginSuccessMessage.ShowDialog(Me)
    '            ' CaptureTempOnlineData()
    '            txtEmployeeID.Text = "EMPLOYEE ID" : txtPassword.Text = "Password" : txtEmployeeID.Focus() : txtEmployeeID.SelectAll() : RefreshDate()
    '            ChangeShift()
    '        Else
    '            MessageBox.Show("Invalid username and password!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            txtPassword.Focus()
    '            txtPassword.SelectAll()
    '        End If
    '    End If
    'End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        If txtPassword.Text = "" Then
            txtPassword.Text = "Password"
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtTime.Text = Now.ToString("h:mm:ss tt")

    End Sub


    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cmdChangePassword.Click
        If OfflineMode = True Then
            MessageBox.Show("Change password not allowed when offline mode!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        frmChangePassword.Show(Me)
    End Sub

    Private Sub ViewAttendanceLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cmdViewAttendance.Click
        If MessageBox.Show("Viewing attendance record is required an administive user permission! ", "Coffeecup System", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            frmPOSAdminConfirmation.ShowDialog(Me)
            If frmPOSAdminConfirmation.ApprovedConfirmation = True Then
                frmAttendanceLog.txtServerdate.Text = txtServerdate.Text
                frmAttendanceLog.Show(Me)
                frmPOSAdminConfirmation.ApprovedConfirmation = False
                frmPOSAdminConfirmation.Dispose()
            End If
        End If
    End Sub

    Private Sub ExitConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitConsoleToolStripMenuItem.Click
        End
    End Sub

#Region "CAMERA FEATURES"
    Public Sub CheckAvailableCamera()
        If firstActive Then
            Exit Sub
        End If
        firstActive = True
        ActiveCamera = True
        If Not DShowNET.DsUtils.IsCorrectDirectXVersion() Then
            lblcamera.Visible = True
            ActiveCamera = False
            MessageBox.Show(Me, "DirectX 8.1 NOT installed!", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
        End If

        If Not DsDev.GetDevicesOfCat(DShowNET.FilterCategory.VideoInputDevice, capDevices) Then
            lblcamera.Visible = True
            ActiveCamera = False
        End If
    End Sub

    Public Function CaptureImage() As Image
        Try
            TakeScreenShot(PicturePanel)
        Catch ee As Exception
            MessageBox.Show(Me, "Could not grab picture" & vbCr & vbLf & ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
        End Try
    End Function

    Private Function TakeScreenShot(ByVal Control As Control) As Bitmap
        Dim tmpImg As New Bitmap(Control.Width, Control.Height)
        Using g As Graphics = Graphics.FromImage(tmpImg)
            g.CopyFromScreen(PicturePanel.PointToScreen(New Point(0, 0)), New Point(0, 0), New Size(PicturePanel.Width, PicturePanel.Height))
        End Using
        Return tmpImg
    End Function

    Private Sub OnCaptureDone()
        Trace.WriteLine("!!DLG: OnCaptureDone")
        Try
            Dim hr As Integer
            If sampGrabber Is Nothing Then
                Exit Sub
            End If
            hr = sampGrabber.SetCallback(Nothing, 0)

            Dim w As Integer = videoInfoHeader.BmiHeader.Width
            Dim h As Integer = videoInfoHeader.BmiHeader.Height
            If ((w And &H3) <> 0) OrElse (w < 32) OrElse (w > 4096) OrElse (h < 32) OrElse (h > 4096) Then
                Exit Sub
            End If
            Dim stride As Integer = w * 3

            Dim handle As GCHandle = GCHandle.Alloc(savedArray, GCHandleType.Pinned)
            Dim scan0 As Integer = CInt(handle.AddrOfPinnedObject())
            scan0 += (h - 1) * stride
            Dim b As New Bitmap(w, h, -stride, PixelFormat.Format24bppRgb, DirectCast(CType(scan0, IntPtr), IntPtr))
            handle.Free()
            savedArray = Nothing

        Catch ee As Exception
            MessageBox.Show(Me, "Could not grab picture" & vbCr & vbLf & ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
        End Try
    End Sub



    Public Function StartupVideo(ByVal mon As UCOMIMoniker) As Boolean
        Dim hr As Integer
        Try
            If Not CreateCaptureDevice(mon) Then
                Return False
            End If

            If Not GetInterfaces() Then
                Return False
            End If

            If Not SetupGraph() Then
                Return False
            End If

            If Not SetupVideoWindow() Then
                Return False
            End If

            DsROT.AddGraphToRot(graphBuilder, rotCookie)
            ' graphBuilder capGraph
            hr = mediaCtrl.Run()
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If

            Return True
        Catch ee As Exception
            MessageBox.Show(Me, "Could not start video stream" & vbCr & vbLf & ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
            Return False
        End Try
    End Function


    Private Function SetupVideoWindow() As Boolean
        Dim hr As Integer
        Try
            ' Set the video window to be a child of the main window
            hr = videoWin.put_Owner(PicturePanel.Handle)
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If

            ' Set video window style
            hr = videoWin.put_WindowStyle(WS_CHILD Or WS_CLIPCHILDREN)
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If

            ' Use helper function to position video window in client rect of owner window
            ResizeVideoWindow()

            ' Make the video window visible, now that it is properly positioned
            hr = videoWin.put_Visible(DsHlp.OATRUE)
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If

            hr = mediaEvt.SetNotifyWindow(Me.Handle, WM_GRAPHNOTIFY, IntPtr.Zero)
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If
            Return True
        Catch ee As Exception
            MessageBox.Show(Me, "Could not setup video window" & vbCr & vbLf & ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
            Return False
        End Try
    End Function

    Private Sub ResizeVideoWindow()
        If videoWin IsNot Nothing Then
            Dim rc As Rectangle = PicturePanel.ClientRectangle
            videoWin.SetWindowPosition(0, 0, rc.Right, rc.Bottom)
        End If
    End Sub

    Private Function SetupGraph() As Boolean
        Dim hr As Integer
        Try
            hr = capGraph.SetFiltergraph(graphBuilder)
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If

            hr = graphBuilder.AddFilter(capFilter, "Ds.NET Video Capture Device")
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If

            'DShowNET.DsUtils.ShowCapPinDialog(capGraph, capFilter, Me.Handle)

            Dim media As New DShowNET.AMMediaType()
            media.majorType = DShowNET.MediaType.Video
            media.subType = DShowNET.MediaSubType.RGB24
            media.formatType = DShowNET.FormatType.VideoInfo
            ' ???
            hr = sampGrabber.SetMediaType(media)
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If

            hr = graphBuilder.AddFilter(baseGrabFlt, "Ds.NET Grabber")
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If

            Dim cat As Guid = DShowNET.PinCategory.Preview
            Dim med As Guid = DShowNET.MediaType.Video
            hr = capGraph.RenderStream(cat, med, capFilter, Nothing, Nothing)
            ' baseGrabFlt
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If

            cat = DShowNET.PinCategory.Capture
            med = DShowNET.MediaType.Video
            hr = capGraph.RenderStream(cat, med, capFilter, Nothing, baseGrabFlt)
            ' baseGrabFlt
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If

            media = New DShowNET.AMMediaType()
            hr = sampGrabber.GetConnectedMediaType(media)
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If
            If (media.formatType <> DShowNET.FormatType.VideoInfo) OrElse (media.formatPtr = IntPtr.Zero) Then
                Throw New NotSupportedException("Unknown Grabber Media Format")
            End If

            videoInfoHeader = DirectCast(Marshal.PtrToStructure(media.formatPtr, GetType(DShowNET.VideoInfoHeader)), DShowNET.VideoInfoHeader)
            Marshal.FreeCoTaskMem(media.formatPtr)
            media.formatPtr = IntPtr.Zero

            hr = sampGrabber.SetBufferSamples(False)
            If hr = 0 Then
                hr = sampGrabber.SetOneShot(False)
            End If
            If hr = 0 Then
                hr = sampGrabber.SetCallback(Nothing, 0)
            End If
            If hr < 0 Then
                Marshal.ThrowExceptionForHR(hr)
            End If

            Return True
        Catch ee As Exception
            MessageBox.Show(Me, "Could not setup graph" & vbCr & vbLf & ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
            Return False
        End Try
    End Function

    Private Function GetInterfaces() As Boolean
        Dim comType As Type = Nothing
        Dim comObj As Object = Nothing
        Try
            comType = Type.GetTypeFromCLSID(Clsid.FilterGraph)
            If comType Is Nothing Then
                Throw New NotImplementedException("DirectShow FilterGraph not installed/registered!")
            End If
            comObj = Activator.CreateInstance(comType)
            graphBuilder = DirectCast(comObj, DShowNET.IGraphBuilder)
            comObj = Nothing

            Dim clsid__1 As Guid = Clsid.CaptureGraphBuilder2
            Dim riid As Guid = GetType(DShowNET.ICaptureGraphBuilder2).GUID
            comObj = DsBugWO.CreateDsInstance(clsid__1, riid)
            capGraph = DirectCast(comObj, DShowNET.ICaptureGraphBuilder2)
            comObj = Nothing

            comType = Type.GetTypeFromCLSID(Clsid.SampleGrabber)
            If comType Is Nothing Then
                Throw New NotImplementedException("DirectShow SampleGrabber not installed/registered!")
            End If
            comObj = Activator.CreateInstance(comType)
            sampGrabber = DirectCast(comObj, DShowNET.ISampleGrabber)
            comObj = Nothing

            mediaCtrl = DirectCast(graphBuilder, DShowNET.IMediaControl)
            videoWin = DirectCast(graphBuilder, DShowNET.IVideoWindow)
            mediaEvt = DirectCast(graphBuilder, DShowNET.IMediaEventEx)
            baseGrabFlt = DirectCast(sampGrabber, DShowNET.IBaseFilter)
            Return True
        Catch ee As Exception
            MessageBox.Show(Me, "Could not get interfaces" & vbCr & vbLf & ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
            Return False
        Finally
            If comObj IsNot Nothing Then
                Marshal.ReleaseComObject(comObj)
            End If
            comObj = Nothing
        End Try
    End Function

    Private Function CreateCaptureDevice(ByVal mon As UCOMIMoniker) As Boolean
        Dim capObj As Object = Nothing
        Try
            Dim gbf As Guid = GetType(DShowNET.IBaseFilter).GUID
            mon.BindToObject(Nothing, Nothing, gbf, capObj)
            capFilter = DirectCast(capObj, DShowNET.IBaseFilter)
            capObj = Nothing
            Return True
        Catch ee As Exception
            MessageBox.Show(Me, "Could not create capture device" & vbCr & vbLf & ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
            Return False
        Finally
            If capObj IsNot Nothing Then
                Marshal.ReleaseComObject(capObj)
            End If
            capObj = Nothing

        End Try
    End Function

    Public Sub CloseInterfaces(ByVal endnow As Boolean)
        Dim hr As Integer
        Try

            If rotCookie <> 0 Then
                DsROT.RemoveGraphFromRot(rotCookie)
            End If


            If mediaCtrl IsNot Nothing Then
                hr = mediaCtrl.[Stop]()
                mediaCtrl = Nothing
            End If

            If mediaEvt IsNot Nothing Then
                hr = mediaEvt.SetNotifyWindow(IntPtr.Zero, WM_GRAPHNOTIFY, IntPtr.Zero)
                mediaEvt = Nothing
            End If

            If videoWin IsNot Nothing Then
                hr = videoWin.put_Visible(DsHlp.OAFALSE)
                hr = videoWin.put_Owner(IntPtr.Zero)
                videoWin = Nothing
            End If

            baseGrabFlt = Nothing
            If sampGrabber IsNot Nothing Then
                Marshal.ReleaseComObject(sampGrabber)
            End If
            sampGrabber = Nothing

            If capGraph IsNot Nothing Then
                Marshal.ReleaseComObject(capGraph)
            End If
            capGraph = Nothing

            If graphBuilder IsNot Nothing Then
                Marshal.ReleaseComObject(graphBuilder)
            End If
            graphBuilder = Nothing

            If capFilter IsNot Nothing Then
                Marshal.ReleaseComObject(capFilter)
            End If
            capFilter = Nothing
            If endnow = True Then
                If capDevices IsNot Nothing Then
                    For Each d As DShowNET.Device.DsDevice In capDevices
                        d.Dispose()
                    Next
                    capDevices = Nothing
                End If
            End If

        Catch generatedExceptionName As Exception
        End Try
    End Sub

    'Private Sub ResizeVideoWindow()
    '    If videoWin IsNot Nothing Then
    '        Dim rc As Rectangle = VideoPanel.ClientRectangle
    '        videoWin.SetWindowPosition(0, 0, rc.Right, rc.Bottom)
    '    End If
    'End Sub

    Protected Overloads Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_GRAPHNOTIFY Then
            If mediaEvt IsNot Nothing Then
                OnGraphNotify()
            End If
            Exit Sub
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub OnGraphNotify()
        Dim code As DsEvCode
        Dim p1 As Integer, p2 As Integer, hr As Integer = 0
        Do
            hr = mediaEvt.GetEvent(code, p1, p2, 0)
            If hr < 0 Then
                Exit Do
            End If
            hr = mediaEvt.FreeEventParams(code, p1, p2)
        Loop While hr = 0
    End Sub

    ''' <summary> sample callback, NOT USED. </summary>
    Private Function SampleCB(ByVal SampleTime As Double, ByVal pSample As DShowNET.IMediaSample) As Integer Implements DShowNET.ISampleGrabberCB.SampleCB
        Return 0
    End Function

    Private Function BufferCB(ByVal SampleTime As Double, ByVal pBuffer As IntPtr, ByVal BufferLen As Integer) As Integer Implements DShowNET.ISampleGrabberCB.BufferCB
        If captured OrElse (savedArray Is Nothing) Then
            Trace.WriteLine("!!CB: ISampleGrabberCB.BufferCB")
            Return 0
        End If

        captured = True
        bufferedSize = BufferLen
        Trace.WriteLine("!!CB: ISampleGrabberCB.BufferCB !GRAB! size = " & BufferLen.ToString())
        If (pBuffer <> IntPtr.Zero) AndAlso (BufferLen > 1000) AndAlso (BufferLen <= savedArray.Length) Then
            Marshal.Copy(pBuffer, savedArray, 0, BufferLen)
        Else
            Trace.WriteLine(" !!!GRAB! failed ")
        End If
        Me.BeginInvoke(New CaptureDone(AddressOf OnCaptureDone))
        Return 0
    End Function


    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCameraDevice.SelectedValueChanged
        Me.CloseInterfaces(False)
        Dim dev As DShowNET.Device.DsDevice = Nothing
        CheckAvailableCamera()
        If capDevices.Count <> 0 Then
            dev = TryCast(capDevices(txtCameraDevice.SelectedIndex), DShowNET.Device.DsDevice)
        End If

        If dev Is Nothing Then
            Me.Close()
            Exit Sub
        End If

        If Not StartupVideo(dev.Mon) Then
            Me.Close()
        End If
    End Sub


    Private Sub DisplayPropertyPage(ByVal dev As DirectShowLib.IBaseFilter)
        'Get the ISpecifyPropertyPages for the filter
        Dim pProp As DirectShowLib.ISpecifyPropertyPages = TryCast(dev, DirectShowLib.ISpecifyPropertyPages)
        Dim hr As Integer = 0

        If pProp Is Nothing Then
            'If the filter doesn't implement ISpecifyPropertyPages, try displaying IAMVfwCompressDialogs instead!
            Dim compressDialog As DirectShowLib.IAMVfwCompressDialogs = TryCast(dev, DirectShowLib.IAMVfwCompressDialogs)
            If compressDialog IsNot Nothing Then

                hr = compressDialog.ShowDialog(VfwCompressDialogs.Config, IntPtr.Zero)
                DsError.ThrowExceptionForHR(hr)
            End If
            Exit Sub
        End If

        'Get the name of the filter from the FilterInfo struct
        Dim filterInfo As DirectShowLib.FilterInfo
        hr = dev.QueryFilterInfo(filterInfo)
        DsError.ThrowExceptionForHR(hr)

        ' Get the propertypages from the property bag
        Dim caGUID As DirectShowLib.DsCAUUID
        hr = pProp.GetPages(caGUID)
        DsError.ThrowExceptionForHR(hr)

        ' Check for property pages on the output pin
        Dim pPin As DirectShowLib.IPin = DsFindPin.ByDirection(dev, DirectShowLib.PinDirection.Output, 0)
        Dim pProp2 As DirectShowLib.ISpecifyPropertyPages = TryCast(pPin, DirectShowLib.ISpecifyPropertyPages)
        If pProp2 IsNot Nothing Then
            Dim caGUID2 As DirectShowLib.DsCAUUID
            hr = pProp2.GetPages(caGUID2)
            DsError.ThrowExceptionForHR(hr)

            If caGUID2.cElems > 0 Then
                Dim soGuid As Integer = Marshal.SizeOf(GetType(Guid))

                ' Create a new buffer to hold all the GUIDs
                Dim p1 As IntPtr = Marshal.AllocCoTaskMem((caGUID.cElems + caGUID2.cElems) * soGuid)

                ' Copy over the pages from the Filter
                For x As Integer = 0 To caGUID.cElems * soGuid - 1
                    Marshal.WriteByte(p1, x, Marshal.ReadByte(caGUID.pElems, x))
                Next

                ' Add the pages from the pin
                For x As Integer = 0 To caGUID2.cElems * soGuid - 1
                    Marshal.WriteByte(p1, x + (caGUID.cElems * soGuid), Marshal.ReadByte(caGUID2.pElems, x))
                Next

                ' Release the old memory
                Marshal.FreeCoTaskMem(caGUID.pElems)
                Marshal.FreeCoTaskMem(caGUID2.pElems)

                ' Reset caGUID to include both
                caGUID.pElems = p1
                caGUID.cElems += caGUID2.cElems
            End If
        End If

        ' Create and display the OlePropertyFrame
        Dim oDevice As Object = DirectCast(dev, Object)
        hr = OleCreatePropertyFrame(Me.Handle, 0, 0, filterInfo.achName, 1, oDevice, _
        caGUID.cElems, caGUID.pElems, 0, 0, IntPtr.Zero)
        DsError.ThrowExceptionForHR(hr)

        ' Release COM objects
        Marshal.FreeCoTaskMem(caGUID.pElems)
        Marshal.ReleaseComObject(pProp)
        If filterInfo.pGraph IsNot Nothing Then
            Marshal.ReleaseComObject(filterInfo.pGraph)
        End If
    End Sub

    Private Function CreateFilter(ByVal category As Guid, ByVal friendlyname As String) As DirectShowLib.IBaseFilter
        Dim source As Object = Nothing
        Dim iid As Guid = GetType(DirectShowLib.IBaseFilter).GUID
        For Each device As DirectShowLib.DsDevice In DirectShowLib.DsDevice.GetDevicesOfCat(category)
            If device.Name.CompareTo(friendlyname) = 0 Then
                device.Mon.BindToObject(Nothing, Nothing, iid, source)
                Exit For
            End If
        Next

        Return DirectCast(source, DirectShowLib.IBaseFilter)
    End Function


    Private Sub cmdCameraSettings_Click(sender As Object, e As EventArgs) Handles cmdCameraSettings.Click
        Dim devicepath As String = txtCameraDevice.SelectedItem.ToString()
        theDevice = CreateFilter(DirectShowLib.FilterCategory.VideoInputDevice, devicepath)
        DisplayPropertyPage(theDevice)
    End Sub

#End Region

    Private Sub SelectCameraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cmdSelectCamera.Click
        frmCameraSelect.ShowDialog()
    End Sub

    'Private Sub CheckOnlineTimer_Tick(sender As Object, e As EventArgs) Handles CheckOnlineServer.Tick
    '    ActivateCheckingOnlineServer()
    'End Sub

    'Public Sub ActivateCheckingOnlineServer()
    '    If OpenMysqlConnection() = True Then

    '        'upload local data
    '        local_com.CommandText = "select * from tblpayrollattendancelog" : local_rst = local_com.ExecuteReader
    '        While local_rst.Read
    '            If countqry("tblpayrollattendancelog", "employeeid='" & local_rst("employeeid").ToString & "' and logindate='" & local_rst("logindate").ToString & "'") > 0 Then
    '                com.CommandText = "UPDATE tblpayrollattendancelog set employeeid='" & local_rst("employeeid").ToString & "', officeid='" & local_rst("officeid").ToString & "', " _
    '                              + " logindate='" & local_rst("logindate").ToString & "' " _
    '                              + If(local_rst("1st_timein").ToString = "", "", ",1st_timein='" & local_rst("1st_timein").ToString & "' ") _
    '                              + If(local_rst("1st_timeout").ToString = "", "", ",1st_timeout='" & local_rst("1st_timeout").ToString & "' ") _
    '                              + If(local_rst("2nd_timein").ToString = "", "", ",2nd_timein='" & local_rst("2nd_timein").ToString & "' ") _
    '                              + If(local_rst("2nd_timeout").ToString = "", "", ",2nd_timeout='" & local_rst("2nd_timeout").ToString & "' ") _
    '                              + If(local_rst("3rd_timein").ToString = "", "", ",3rd_timein='" & local_rst("3rd_timein").ToString & "' ") _
    '                              + If(local_rst("3rd_timeout").ToString = "", "", ",3rd_timeout='" & local_rst("3rd_timeout").ToString & "' ") _
    '                              + " where employeeid='" & local_rst("employeeid").ToString & "' and logindate='" & local_rst("logindate").ToString & "'" : com.ExecuteNonQuery()
    '            Else
    '                com.CommandText = "insert into tblpayrollattendancelog set employeeid='" & local_rst("employeeid").ToString & "', officeid='" & local_rst("officeid").ToString & "', " _
    '                              + " logindate='" & local_rst("logindate").ToString & "', " _
    '                              + " 1st_timein=" & If(local_rst("1st_timein").ToString = "", "null", "'" & local_rst("1st_timein").ToString & "'") & ", " _
    '                              + " 1st_timeout=" & If(local_rst("1st_timeout").ToString = "", "null", "'" & local_rst("1st_timeout").ToString & "'") & ",  " _
    '                              + " 2nd_timein=" & If(local_rst("2nd_timein").ToString = "", "null", "'" & local_rst("2nd_timein").ToString & "'") & ", " _
    '                              + " 2nd_timeout=" & If(local_rst("2nd_timeout").ToString = "", "null", "'" & local_rst("2nd_timeout").ToString & "'") & ", " _
    '                              + " 3rd_timein=" & If(local_rst("3rd_timein").ToString = "", "null", "'" & local_rst("3rd_timein").ToString & "'") & ", " _
    '                              + " 3rd_timeout=" & If(local_rst("3rd_timeout").ToString = "", "null", "'" & local_rst("3rd_timeout").ToString & "'") & "" : com.ExecuteNonQuery()
    '            End If
    '        End While
    '        local_rst.Close()
    '        local_com.CommandText = "DELETE from tblpayrollattendancelog" : local_com.ExecuteNonQuery()

    '        local_com.CommandText = "select * from tblattendanceimage" : local_rst = local_com.ExecuteReader
    '        While local_rst.Read
    '            Dim arrImage1 As Byte() = Nothing
    '            If local_rst("1st_timein").ToString <> "" Then
    '                Dim Ximg = ResizedImage(Image.FromFile(Application.StartupPath.ToString & "\Image\" & local_rst("1st_timein").ToString & ".jpg"))
    '                Dim mstrefirst As New System.IO.MemoryStream()
    '                Ximg.Save(stream, System.Drawing.Imaging.ImageFormat.Png)
    '                arrImage1 = stream.GetBuffer()
    '                stream.Close()
    '                Ximg.Dispose()
    '            End If
    '            Dim arrImage2 As Byte() = Nothing
    '            If local_rst("1st_timeout").ToString <> "" Then
    '                Dim Ximg = ResizedImage(Image.FromFile(Application.StartupPath.ToString & "\Image\" & local_rst("1st_timeout").ToString & ".jpg"))
    '                Dim mstrefirst As New System.IO.MemoryStream()
    '                Ximg.Save(stream, System.Drawing.Imaging.ImageFormat.Png)
    '                arrImage2 = stream.GetBuffer()
    '                stream.Close()
    '                Ximg.Dispose()
    '            End If

    '            Dim arrImage3 As Byte() = Nothing
    '            If local_rst("2nd_timein").ToString <> "" Then
    '                Dim Ximg = ResizedImage(Image.FromFile(Application.StartupPath.ToString & "\Image\" & local_rst("2nd_timein").ToString & ".jpg"))
    '                Dim mstrefirst As New System.IO.MemoryStream()
    '                Ximg.Save(stream, System.Drawing.Imaging.ImageFormat.Png)
    '                arrImage3 = stream.GetBuffer()
    '                stream.Close()
    '                Ximg.Dispose()
    '            End If
    '            Dim arrImage4 As Byte() = Nothing
    '            If local_rst("2nd_timeout").ToString <> "" Then
    '                Dim Ximg = ResizedImage(Image.FromFile(Application.StartupPath.ToString & "\Image\" & local_rst("2nd_timeout").ToString & ".jpg"))
    '                Dim mstrefirst As New System.IO.MemoryStream()
    '                Ximg.Save(stream, System.Drawing.Imaging.ImageFormat.Png)
    '                arrImage4 = stream.GetBuffer()
    '                stream.Close()
    '                Ximg.Dispose()
    '            End If
    '            Dim arrImage5 As Byte() = Nothing
    '            If local_rst("3rd_timein").ToString <> "" Then
    '                Dim Ximg = ResizedImage(Image.FromFile(Application.StartupPath.ToString & "\Image\" & local_rst("3rd_timein").ToString & ".jpg"))
    '                Dim mstrefirst As New System.IO.MemoryStream()
    '                Ximg.Save(stream, System.Drawing.Imaging.ImageFormat.Png)
    '                arrImage5 = stream.GetBuffer()
    '                stream.Close()
    '                Ximg.Dispose()
    '            End If
    '            Dim arrImage6 As Byte() = Nothing
    '            If local_rst("3rd_timeout").ToString <> "" Then
    '                Dim Ximg = ResizedImage(Image.FromFile(Application.StartupPath.ToString & "\Image\" & local_rst("3rd_timeout").ToString & ".jpg"))
    '                Dim mstrefirst As New System.IO.MemoryStream()
    '                Ximg.Save(stream, System.Drawing.Imaging.ImageFormat.Png)
    '                arrImage6 = stream.GetBuffer()
    '                stream.Close()
    '                Ximg.Dispose()
    '            End If
    '            If countqry("filedir.tblattendanceimage", "employeeid='" & local_rst("employeeid").ToString & "' and logindate='" & local_rst("logindate").ToString & "'") > 0 Then
    '                With com
    '                    .CommandText = "UPDATE filedir.tblattendanceimage set employeeid='" & local_rst("employeeid").ToString & "', " _
    '                              + " officeid='" & local_rst("officeid").ToString & "', logindate='" & local_rst("logindate").ToString & "' " _
    '                              + If(local_rst("1st_timein").ToString = "", "", ",1st_timein=@file1 ") _
    '                              + If(local_rst("1st_timeout").ToString = "", "", ",1st_timeout=@file2 ") _
    '                              + If(local_rst("2nd_timein").ToString = "", "", ",2nd_timein=@file3 ") _
    '                              + If(local_rst("2nd_timeout").ToString = "", "", ",2nd_timeout=@file4 ") _
    '                              + If(local_rst("3rd_timein").ToString = "", "", ",3rd_timein=@file5 ") _
    '                              + If(local_rst("3rd_timeout").ToString = "", "", ",3rd_timeout=@file6 ") _
    '                              + " where employeeid='" & local_rst("employeeid").ToString & "' and logindate='" & local_rst("logindate").ToString & "'"
    '                    .Connection = conn
    '                    If local_rst("1st_timein").ToString <> "" Then
    '                        .Parameters.AddWithValue("@file1", arrImage1)
    '                    End If
    '                    If local_rst("1st_timeout").ToString <> "" Then
    '                        .Parameters.AddWithValue("@file2", arrImage2)
    '                    End If
    '                    If local_rst("2nd_timein").ToString <> "" Then
    '                        .Parameters.AddWithValue("@file3", arrImage3)
    '                    End If
    '                    If local_rst("2nd_timeout").ToString <> "" Then
    '                        .Parameters.AddWithValue("@file4", arrImage4)
    '                    End If
    '                    If local_rst("3rd_timein").ToString <> "" Then
    '                        .Parameters.AddWithValue("@file5", arrImage5)
    '                    End If
    '                    If local_rst("3rd_timeout").ToString <> "" Then
    '                        .Parameters.AddWithValue("@file6", arrImage6)
    '                    End If
    '                    .ExecuteNonQuery()
    '                End With
    '                com.Parameters.Clear()
    '            Else
    '                With com
    '                    .CommandText = "insert into filedir.tblattendanceimage set employeeid='" & local_rst("employeeid").ToString & "', officeid='" & local_rst("officeid").ToString & "',  logindate='" & local_rst("logindate").ToString & "', " _
    '                                        + " 1st_timein=@file1, 1st_timeout=@file2, 2nd_timein=@file3, 2nd_timeout=@file4, 3rd_timein=@file5, 3rd_timeout=@file6"
    '                    .Connection = conn
    '                    .Parameters.AddWithValue("@file1", arrImage1)
    '                    .Parameters.AddWithValue("@file2", arrImage2)
    '                    .Parameters.AddWithValue("@file3", arrImage3)
    '                    .Parameters.AddWithValue("@file4", arrImage4)
    '                    .Parameters.AddWithValue("@file5", arrImage5)
    '                    .Parameters.AddWithValue("@file6", arrImage6)
    '                    .ExecuteNonQuery()
    '                End With
    '                com.Parameters.Clear()
    '            End If
    '        End While
    '        local_rst.Close()

    '        local_com.CommandText = "DELETE from tblattendanceimage" : local_com.ExecuteNonQuery()
    '        local_com.CommandText = "UPDATE tblsystemmode set offlinemode=0" : local_com.ExecuteNonQuery()
    '        'If System.IO.Directory.Exists(Application.StartupPath.ToString & "\Image") = True Then
    '        '    System.IO.Directory.Delete(Application.StartupPath.ToString & "\Image", True)
    '        'End If

    '        OfflineMode = False
    '        CheckOnlineServer.Enabled = False
    '        lblOfflinemode.Visible = False
    '        'CaptureTempOnlineData()
    '    End If
    'End Sub
 
  
    Private Sub ExportAttendanceLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportAttendanceLogToolStripMenuItem.Click
        If MessageBox.Show("Viewing attendance record is required an administive user permission! ", "Coffeecup System", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            frmPOSAdminConfirmation.ShowDialog(Me)
            If frmPOSAdminConfirmation.ApprovedConfirmation = True Then
                frmSelectDateExport.ShowDialog(Me)
                frmPOSAdminConfirmation.ApprovedConfirmation = False
                frmPOSAdminConfirmation.Dispose()
            End If
        End If

    End Sub
End Class
