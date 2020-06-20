Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO

Public Class frmSetOneTimePassword
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmRequestType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtName.Text = qrysingledata("fullname", "fullname", "tblemployees where employeeid='" & txtEmployeeID.Text & "'")
    End Sub

    Private Sub cmdset_Click(sender As Object, e As EventArgs) Handles cmdset.Click
        If txtNewPasssword.Text = "" Then
            MessageBox.Show("Please enter new password!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNewPasssword.Focus()
            Exit Sub

        ElseIf txtVerifypassword.Text = "" Then
            MessageBox.Show("Please verify password!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtVerifypassword.Focus()
            Exit Sub

        ElseIf txtVerifypassword.Text <> txtNewPasssword.Text Then
            MessageBox.Show("Password did not match!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtVerifypassword.Focus()
            Exit Sub
        End If

        Try
            com.CommandText = "update tblemployees set attendancepassword='" & EncryptTripleDES(UCase(txtEmployeeID.Text) + txtVerifypassword.Text) & "' where employeeid='" & txtEmployeeID.Text & "'" : com.ExecuteNonQuery()
            MsgBox("Your Password Successfuly saved! Please login again..", vbInformation)
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
 
End Class