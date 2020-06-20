Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO

Public Class frmChangePassword
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    
    Private Sub cmdset_Click(sender As Object, e As EventArgs) Handles cmdset.Click
        If txtEmployeeID.Text = "" Then
            MessageBox.Show("Please enter employee id!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmployeeID.Focus()
            Exit Sub
        ElseIf countqry("tblemployees", "employeeid='" & txtEmployeeID.Text & "'") = 0 Then
            MessageBox.Show("Employee id not found on database!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmployeeID.Focus()
            txtEmployeeID.SelectAll()
            Exit Sub
        ElseIf txtOldPassword.Text = "" Or txtOldPassword.Text = "Password" Then
            MessageBox.Show("Please enter employee id!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOldPassword.Focus()
            txtOldPassword.SelectAll()
            Exit Sub
        ElseIf txtNewPasssword.Text = "" Or txtNewPasssword.Text = "Password" Then
            MessageBox.Show("Please enter new password!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNewPasssword.Focus()
            txtNewPasssword.SelectAll()
            Exit Sub

        ElseIf txtVerifypassword.Text = "" Or txtVerifypassword.Text = "Password" Then
            MessageBox.Show("Please verify password!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtVerifypassword.Focus()
            txtVerifypassword.SelectAll()
            Exit Sub

        ElseIf txtVerifypassword.Text <> txtNewPasssword.Text Then
            MessageBox.Show("Password did not match!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtVerifypassword.Focus()
            Exit Sub

        End If
        Dim getPassword As String = EncryptTripleDES(UCase(txtEmployeeID.Text) + txtOldPassword.Text)
        If countqry("tblemployees", "employeeid='" & txtEmployeeID.Text & "' and attendancepassword='" & getPassword & "'") = 0 Then
            MessageBox.Show("Invalid old password!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOldPassword.Focus()
            txtOldPassword.SelectAll()
            Exit Sub
        End If
        Try
            com.CommandText = "update tblemployees set attendancepassword='" & EncryptTripleDES(UCase(txtEmployeeID.Text) + txtVerifypassword.Text) & "' where employeeid='" & txtEmployeeID.Text & "'" : com.ExecuteNonQuery()
            MsgBox("Your Password Successfuly changed!", vbInformation)
            Me.Close()
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message, vbCrLf _
                            & "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub txtNewPasssword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNewPasssword.KeyPress
        If e.KeyChar() = Chr(13) Then
            txtVerifypassword.Focus()
        End If
    End Sub

    Private Sub txtVerifypassword_GotFocus(sender As Object, e As EventArgs) Handles txtVerifypassword.GotFocus
        Me.AcceptButton = cmdset
    End Sub

    Private Sub txtVerifypassword_LostFocus(sender As Object, e As EventArgs) Handles txtVerifypassword.LostFocus
        Me.AcceptButton = Nothing
    End Sub

    Private Sub txtEmployeeID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmployeeID.KeyPress
        If e.KeyChar() = Chr(13) Then
            txtOldPassword.Focus()
            txtOldPassword.SelectAll()
        End If
    End Sub

    Private Sub txtOldPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOldPassword.KeyPress
        If e.KeyChar() = Chr(13) Then
            txtNewPasssword.Focus()
            txtNewPasssword.SelectAll()
        End If
    End Sub
End Class