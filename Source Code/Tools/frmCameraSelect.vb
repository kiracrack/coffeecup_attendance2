Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO

Public Class frmCameraSelect
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmCameraSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        frmMainMenu.CheckAvailableCamera()
        If ActiveCamera = True Then
            If capDevices.Count <> 0 Then
                For Each d As DShowNET.Device.DsDevice In capDevices
                    ComboBox1.Items.Add(d.Name)
                    ComboBox1.SelectedIndex = 0
                Next
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        frmMainMenu.CloseInterfaces(False)
        Dim dev As DShowNET.Device.DsDevice = Nothing
        frmMainMenu.CheckAvailableCamera()
        If capDevices.Count <> 0 Then
            dev = TryCast(capDevices(ComboBox1.SelectedIndex), DShowNET.Device.DsDevice)
        End If

        If dev Is Nothing Then
            Me.Close()
            Exit Sub
        End If

        If Not frmMainMenu.StartupVideo(dev.Mon) Then
            Me.Close()
        End If
    End Sub

   
End Class