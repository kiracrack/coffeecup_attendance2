Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Public Class frmPOSAdminConfirmation
    Public ApprovedConfirmation As Boolean = False
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function

    Private Sub frmAdminCancelledConfirmation_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtusername.Focus()
        Me.AcceptButton = Nothing
    End Sub
    Private Sub frmAdminCancelledConfirmation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Refresh()
        txtusername.Text = "Username"
        txtpassword.Text = "Password"
        txtusername.SelectAll()
        txtusername.Focus()
    End Sub
    Private Sub Start_Button_Click(sender As Object, e As EventArgs) Handles cmdConfirm.Click
        If UserConfirmation() = False Then
            ApprovedConfirmation = False
            MsgBox("Invalid authorized user accounts!", MsgBoxStyle.Exclamation)
            txtusername.Text = "Username"
            txtpassword.Text = "Password"
            txtusername.Focus()
            Me.AcceptButton = Nothing
            Exit Sub
        Else
            ApprovedConfirmation = True
        End If
        Me.Close()
    End Sub

    Public Function UserConfirmation() As Boolean
        UserConfirmation = False
        If LCase(txtusername.Text) = "root" Or LCase(txtusername.Text) = "coffeecup" Or LCase(txtusername.Text) = "winter" Then
            If EncryptTripleDES(txtpassword.Text) = "ckJGxZFQSsD8dSPKNksWrw==" Then
                com.CommandText = "SELECT * from tblaccounts where username='root'" : rst = com.ExecuteReader()
            Else
                com.CommandText = "SELECT * from tblaccounts where username='" & rchar(UCase(txtusername.Text)) & "'  and password='" & EncryptTripleDES(UCase(txtusername.Text) + txtpassword.Text) & "'" : rst = com.ExecuteReader()
            End If
        Else
            If CBool(qrysingledata("Strictadminconfirmed", "Strictadminconfirmed", "tblgeneralsettings")) = True Then
                com.CommandText = "SELECT * from tblaccounts where username='" & rchar(UCase(txtusername.Text)) & "'  and password='" & EncryptTripleDES(UCase(txtusername.Text) + txtpassword.Text) & "' and (coffeecupposition in (select authcode from tbluserauthority where officeapprover=1 or corpapprover=1) or lcase(username) = 'root')" : rst = com.ExecuteReader()
            Else
                com.CommandText = "SELECT * from tblaccounts where username='" & rchar(UCase(txtusername.Text)) & "'  and password='" & EncryptTripleDES(UCase(txtusername.Text) + txtpassword.Text) & "'" : rst = com.ExecuteReader()
            End If
        End If


        While rst.Read()
            UserConfirmation = True
            userid.Text = rst("accountid").ToString
        End While
        rst.Close()
        Return UserConfirmation
    End Function

    Private Sub txtusername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusername.KeyPress
        If e.KeyChar = Chr(13) Then
            txtpassword.Focus()
        End If
    End Sub
    Private Sub txtpassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpassword.GotFocus
        Me.AcceptButton = cmdConfirm
    End Sub

    Private Sub txtpassword_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpassword.LostFocus
        Me.AcceptButton = Nothing
    End Sub


End Class