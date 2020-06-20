Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO

Public Class frmChangeLogoutDate
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function

    Private Sub frmChangeLogoutDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtLogoutDate.Value = CDate(Now.AddDays(-1))
    End Sub

    Private Sub cmdset_Click(sender As Object, e As EventArgs) Handles cmdset.Click
        frmMainMenu.txtServerdate.Text = ConvertDate(txtLogoutDate.Text)
        frmMainMenu.txtDate.Text = txtLogoutDate.Value.ToString("dddd MMMM dd, yyyy")
        Me.Close()
    End Sub
End Class