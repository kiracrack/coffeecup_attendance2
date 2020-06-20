<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangePassword))
        Me.cmdset = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVerifypassword = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtNewPasssword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOldPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdset
        '
        Me.cmdset.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmdset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdset.Location = New System.Drawing.Point(226, 131)
        Me.cmdset.Name = "cmdset"
        Me.cmdset.Size = New System.Drawing.Size(109, 30)
        Me.cmdset.TabIndex = 4
        Me.cmdset.Text = "Confirm Save"
        Me.cmdset.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(71, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 366
        Me.Label4.Text = "Verify Password"
        '
        'txtVerifypassword
        '
        Me.txtVerifypassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtVerifypassword.Font = New System.Drawing.Font("Wingdings", 9.25!)
        Me.txtVerifypassword.ForeColor = System.Drawing.Color.Gray
        Me.txtVerifypassword.Location = New System.Drawing.Point(166, 107)
        Me.txtVerifypassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtVerifypassword.Name = "txtVerifypassword"
        Me.txtVerifypassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtVerifypassword.Size = New System.Drawing.Size(169, 21)
        Me.txtVerifypassword.TabIndex = 3
        Me.txtVerifypassword.Text = "Password"
        '
        'txtNewPasssword
        '
        Me.txtNewPasssword.BackColor = System.Drawing.SystemColors.Window
        Me.txtNewPasssword.Font = New System.Drawing.Font("Wingdings", 9.25!)
        Me.txtNewPasssword.ForeColor = System.Drawing.Color.Gray
        Me.txtNewPasssword.Location = New System.Drawing.Point(166, 83)
        Me.txtNewPasssword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNewPasssword.Name = "txtNewPasssword"
        Me.txtNewPasssword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtNewPasssword.Size = New System.Drawing.Size(169, 21)
        Me.txtNewPasssword.TabIndex = 2
        Me.txtNewPasssword.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(77, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 368
        Me.Label1.Text = "New Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(56, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(212, 15)
        Me.Label2.TabIndex = 377
        Me.Label2.Text = "Change attendance console password.."
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.AcceptsReturn = True
        Me.txtEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeID.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtEmployeeID.Location = New System.Drawing.Point(166, 34)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(103, 22)
        Me.txtEmployeeID.TabIndex = 0
        Me.txtEmployeeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(87, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 379
        Me.Label3.Text = "Employee ID"
        '
        'txtOldPassword
        '
        Me.txtOldPassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtOldPassword.Font = New System.Drawing.Font("Wingdings", 9.25!)
        Me.txtOldPassword.ForeColor = System.Drawing.Color.Gray
        Me.txtOldPassword.Location = New System.Drawing.Point(166, 59)
        Me.txtOldPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOldPassword.Name = "txtOldPassword"
        Me.txtOldPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtOldPassword.Size = New System.Drawing.Size(169, 21)
        Me.txtOldPassword.TabIndex = 1
        Me.txtOldPassword.Text = "Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(82, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 15)
        Me.Label5.TabIndex = 381
        Me.Label5.Text = "Old Password"
        '
        'frmChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(436, 177)
        Me.Controls.Add(Me.txtOldPassword)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNewPasssword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtVerifypassword)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdset)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Attendance Password"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdset As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVerifypassword As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtNewPasssword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOldPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
