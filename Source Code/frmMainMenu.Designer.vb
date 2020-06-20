<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainMenu))
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ExitConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdViewAttendance = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdCameraSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdSelectCamera = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtDate = New System.Windows.Forms.Label()
        Me.txtTime = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.radMorning = New System.Windows.Forms.RadioButton()
        Me.radAfterNoon = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblOfflinemode = New System.Windows.Forms.Label()
        Me.txtCameraDevice = New System.Windows.Forms.ComboBox()
        Me.PicturePanel = New System.Windows.Forms.Panel()
        Me.lblcamera = New System.Windows.Forms.Label()
        Me.radovertime = New System.Windows.Forms.RadioButton()
        Me.txtServerdate = New System.Windows.Forms.TextBox()
        Me.CheckOnlineServer = New System.Windows.Forms.Timer(Me.components)
        Me.ExportAttendanceLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PicturePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtPassword.Font = New System.Drawing.Font("Wingdings", 14.25!)
        Me.txtPassword.ForeColor = System.Drawing.Color.Gray
        Me.txtPassword.Location = New System.Drawing.Point(368, 204)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtPassword.Size = New System.Drawing.Size(248, 29)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.Text = "Password"
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(354, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(276, 17)
        Me.Label4.TabIndex = 371
        Me.Label4.Text = "Please enter username and password to login"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.AcceptsReturn = True
        Me.txtEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeID.Font = New System.Drawing.Font("Segoe UI", 14.75!)
        Me.txtEmployeeID.Location = New System.Drawing.Point(368, 166)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(248, 34)
        Me.txtEmployeeID.TabIndex = 0
        Me.txtEmployeeID.Text = "EMPLOYEE ID"
        Me.txtEmployeeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitConsoleToolStripMenuItem, Me.cmdChangePassword, Me.ExportAttendanceLogToolStripMenuItem, Me.cmdViewAttendance, Me.cmdCameraSettings, Me.cmdSelectCamera})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(762, 24)
        Me.MenuStrip1.TabIndex = 372
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExitConsoleToolStripMenuItem
        '
        Me.ExitConsoleToolStripMenuItem.Name = "ExitConsoleToolStripMenuItem"
        Me.ExitConsoleToolStripMenuItem.Size = New System.Drawing.Size(83, 20)
        Me.ExitConsoleToolStripMenuItem.Text = "Exit Console"
        '
        'cmdChangePassword
        '
        Me.cmdChangePassword.Name = "cmdChangePassword"
        Me.cmdChangePassword.Size = New System.Drawing.Size(113, 20)
        Me.cmdChangePassword.Text = "Change Password"
        '
        'cmdViewAttendance
        '
        Me.cmdViewAttendance.Name = "cmdViewAttendance"
        Me.cmdViewAttendance.Size = New System.Drawing.Size(131, 20)
        Me.cmdViewAttendance.Text = "View Attendance Log"
        '
        'cmdCameraSettings
        '
        Me.cmdCameraSettings.Name = "cmdCameraSettings"
        Me.cmdCameraSettings.Size = New System.Drawing.Size(105, 20)
        Me.cmdCameraSettings.Text = "Camera Settings"
        '
        'cmdSelectCamera
        '
        Me.cmdSelectCamera.Name = "cmdSelectCamera"
        Me.cmdSelectCamera.Size = New System.Drawing.Size(94, 20)
        Me.cmdSelectCamera.Text = "Select Camera"
        '
        'txtDate
        '
        Me.txtDate.Font = New System.Drawing.Font("Segoe UI Semibold", 10.75!, System.Drawing.FontStyle.Bold)
        Me.txtDate.ForeColor = System.Drawing.Color.Black
        Me.txtDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtDate.Location = New System.Drawing.Point(353, 86)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(276, 23)
        Me.txtDate.TabIndex = 375
        Me.txtDate.Text = "December 13, 1987 MONDAY"
        Me.txtDate.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTime
        '
        Me.txtTime.Font = New System.Drawing.Font("Segoe UI", 25.75!)
        Me.txtTime.ForeColor = System.Drawing.Color.Black
        Me.txtTime.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtTime.Location = New System.Drawing.Point(353, 39)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(276, 51)
        Me.txtTime.TabIndex = 376
        Me.txtTime.Text = "10:50 PM"
        Me.txtTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'radMorning
        '
        Me.radMorning.Appearance = System.Windows.Forms.Appearance.Button
        Me.radMorning.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radMorning.Location = New System.Drawing.Point(368, 117)
        Me.radMorning.Name = "radMorning"
        Me.radMorning.Size = New System.Drawing.Size(121, 26)
        Me.radMorning.TabIndex = 377
        Me.radMorning.TabStop = True
        Me.radMorning.Text = "AM SHIFT"
        Me.radMorning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radMorning.UseVisualStyleBackColor = True
        '
        'radAfterNoon
        '
        Me.radAfterNoon.Appearance = System.Windows.Forms.Appearance.Button
        Me.radAfterNoon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radAfterNoon.Location = New System.Drawing.Point(490, 117)
        Me.radAfterNoon.Name = "radAfterNoon"
        Me.radAfterNoon.Size = New System.Drawing.Size(126, 26)
        Me.radAfterNoon.TabIndex = 380
        Me.radAfterNoon.TabStop = True
        Me.radAfterNoon.Text = "PM SHIFT"
        Me.radAfterNoon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radAfterNoon.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel1.Controls.Add(Me.lblOfflinemode)
        Me.Panel1.Controls.Add(Me.txtCameraDevice)
        Me.Panel1.Controls.Add(Me.PicturePanel)
        Me.Panel1.Controls.Add(Me.radovertime)
        Me.Panel1.Controls.Add(Me.txtServerdate)
        Me.Panel1.Controls.Add(Me.radAfterNoon)
        Me.Panel1.Controls.Add(Me.radMorning)
        Me.Panel1.Controls.Add(Me.txtTime)
        Me.Panel1.Controls.Add(Me.txtDate)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtPassword)
        Me.Panel1.Controls.Add(Me.txtEmployeeID)
        Me.Panel1.Location = New System.Drawing.Point(14, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(735, 300)
        Me.Panel1.TabIndex = 0
        '
        'lblOfflinemode
        '
        Me.lblOfflinemode.Font = New System.Drawing.Font("Segoe UI Semibold", 10.75!, System.Drawing.FontStyle.Bold)
        Me.lblOfflinemode.ForeColor = System.Drawing.Color.Red
        Me.lblOfflinemode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblOfflinemode.Location = New System.Drawing.Point(368, 237)
        Me.lblOfflinemode.Name = "lblOfflinemode"
        Me.lblOfflinemode.Size = New System.Drawing.Size(248, 23)
        Me.lblOfflinemode.TabIndex = 386
        Me.lblOfflinemode.Text = "OFFLINE SERVER MODE"
        Me.lblOfflinemode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCameraDevice
        '
        Me.txtCameraDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtCameraDevice.FormattingEnabled = True
        Me.txtCameraDevice.Location = New System.Drawing.Point(71, 259)
        Me.txtCameraDevice.Name = "txtCameraDevice"
        Me.txtCameraDevice.Size = New System.Drawing.Size(266, 23)
        Me.txtCameraDevice.TabIndex = 385
        Me.txtCameraDevice.Visible = False
        '
        'PicturePanel
        '
        Me.PicturePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicturePanel.Controls.Add(Me.lblcamera)
        Me.PicturePanel.Location = New System.Drawing.Point(71, 22)
        Me.PicturePanel.Name = "PicturePanel"
        Me.PicturePanel.Size = New System.Drawing.Size(266, 231)
        Me.PicturePanel.TabIndex = 384
        '
        'lblcamera
        '
        Me.lblcamera.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.lblcamera.ForeColor = System.Drawing.Color.Black
        Me.lblcamera.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblcamera.Location = New System.Drawing.Point(3, 106)
        Me.lblcamera.Name = "lblcamera"
        Me.lblcamera.Size = New System.Drawing.Size(246, 17)
        Me.lblcamera.TabIndex = 372
        Me.lblcamera.Text = "Camera not available.."
        Me.lblcamera.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblcamera.Visible = False
        '
        'radovertime
        '
        Me.radovertime.Appearance = System.Windows.Forms.Appearance.Button
        Me.radovertime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radovertime.Location = New System.Drawing.Point(635, 256)
        Me.radovertime.Name = "radovertime"
        Me.radovertime.Size = New System.Drawing.Size(87, 26)
        Me.radovertime.TabIndex = 382
        Me.radovertime.TabStop = True
        Me.radovertime.Text = "OVERTIME"
        Me.radovertime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radovertime.UseVisualStyleBackColor = True
        Me.radovertime.Visible = False
        '
        'txtServerdate
        '
        Me.txtServerdate.AcceptsReturn = True
        Me.txtServerdate.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtServerdate.Location = New System.Drawing.Point(613, 14)
        Me.txtServerdate.Name = "txtServerdate"
        Me.txtServerdate.Size = New System.Drawing.Size(94, 22)
        Me.txtServerdate.TabIndex = 381
        Me.txtServerdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtServerdate.Visible = False
        '
        'CheckOnlineServer
        '
        Me.CheckOnlineServer.Interval = 5000
        '
        'ExportAttendanceLogToolStripMenuItem
        '
        Me.ExportAttendanceLogToolStripMenuItem.Name = "ExportAttendanceLogToolStripMenuItem"
        Me.ExportAttendanceLogToolStripMenuItem.Size = New System.Drawing.Size(139, 20)
        Me.ExportAttendanceLogToolStripMenuItem.Text = "Export Attendance Log"
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 349)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attendance Console"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PicturePanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitConsoleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdChangePassword As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdViewAttendance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtDate As System.Windows.Forms.Label
    Friend WithEvents txtTime As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents radMorning As System.Windows.Forms.RadioButton
    Friend WithEvents radAfterNoon As System.Windows.Forms.RadioButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtServerdate As System.Windows.Forms.TextBox
    Friend WithEvents radovertime As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCameraSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicturePanel As System.Windows.Forms.Panel
    Friend WithEvents lblcamera As System.Windows.Forms.Label
    Friend WithEvents cmdSelectCamera As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCameraDevice As System.Windows.Forms.ComboBox
    Friend WithEvents lblOfflinemode As System.Windows.Forms.Label
    Friend WithEvents CheckOnlineServer As System.Windows.Forms.Timer
    Friend WithEvents ExportAttendanceLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
