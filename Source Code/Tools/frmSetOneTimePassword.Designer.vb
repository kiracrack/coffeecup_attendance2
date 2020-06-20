<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetOneTimePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetOneTimePassword))
        Me.cmdset = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVerifypassword = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtNewPasssword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdset
        '
        Me.cmdset.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmdset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdset.Location = New System.Drawing.Point(200, 106)
        Me.cmdset.Name = "cmdset"
        Me.cmdset.Size = New System.Drawing.Size(109, 30)
        Me.cmdset.TabIndex = 2
        Me.cmdset.Text = "Confirm Save"
        Me.cmdset.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(45, 85)
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
        Me.txtVerifypassword.Location = New System.Drawing.Point(140, 82)
        Me.txtVerifypassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtVerifypassword.Name = "txtVerifypassword"
        Me.txtVerifypassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtVerifypassword.Size = New System.Drawing.Size(169, 21)
        Me.txtVerifypassword.TabIndex = 1
        Me.txtVerifypassword.Text = "Password"
        '
        'txtNewPasssword
        '
        Me.txtNewPasssword.BackColor = System.Drawing.SystemColors.Window
        Me.txtNewPasssword.Font = New System.Drawing.Font("Wingdings", 9.25!)
        Me.txtNewPasssword.ForeColor = System.Drawing.Color.Gray
        Me.txtNewPasssword.Location = New System.Drawing.Point(140, 58)
        Me.txtNewPasssword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNewPasssword.Name = "txtNewPasssword"
        Me.txtNewPasssword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtNewPasssword.Size = New System.Drawing.Size(169, 21)
        Me.txtNewPasssword.TabIndex = 0
        Me.txtNewPasssword.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(51, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 368
        Me.Label1.Text = "New Password"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Segoe UI Semibold", 10.75!, System.Drawing.FontStyle.Bold)
        Me.txtName.ForeColor = System.Drawing.Color.Black
        Me.txtName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtName.Location = New System.Drawing.Point(20, 12)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(269, 23)
        Me.txtName.TabIndex = 376
        Me.txtName.Text = "BUGAHOD, WINTER S."
        Me.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(21, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(286, 15)
        Me.Label2.TabIndex = 377
        Me.Label2.Text = "Please set your attendance password (One time only)"
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.AcceptsReturn = True
        Me.txtEmployeeID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtEmployeeID.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtEmployeeID.Location = New System.Drawing.Point(35, 112)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(103, 22)
        Me.txtEmployeeID.TabIndex = 378
        Me.txtEmployeeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEmployeeID.Visible = False
        '
        'frmSetOneTimePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(343, 144)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtNewPasssword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtVerifypassword)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdset)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSetOneTimePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "One Time Password"
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
    Friend WithEvents txtName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
End Class
