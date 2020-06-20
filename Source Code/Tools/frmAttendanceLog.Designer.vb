<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendanceLog
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAttendanceLog))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MyDataGridView_Trace = New System.Windows.Forms.DataGridView()
        Me.txtServerdate = New System.Windows.Forms.TextBox()
        Me.pic_morning_1 = New System.Windows.Forms.PictureBox()
        Me.pic_morning_2 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pic_afternoon_2 = New System.Windows.Forms.PictureBox()
        Me.pic_afternoon_1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pic_overtime_2 = New System.Windows.Forms.PictureBox()
        Me.pic_overtime_1 = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtYear = New System.Windows.Forms.ComboBox()
        Me.txtMonth = New System.Windows.Forms.ComboBox()
        Me.txtDay = New System.Windows.Forms.ComboBox()
        Me.ckViewPicture = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtOffice = New System.Windows.Forms.ComboBox()
        Me.officeid = New System.Windows.Forms.TextBox()
        CType(Me.MyDataGridView_Trace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_morning_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_morning_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_afternoon_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_afternoon_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_overtime_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_overtime_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MyDataGridView_Trace
        '
        Me.MyDataGridView_Trace.AllowUserToAddRows = False
        Me.MyDataGridView_Trace.AllowUserToDeleteRows = False
        Me.MyDataGridView_Trace.AllowUserToResizeColumns = False
        Me.MyDataGridView_Trace.AllowUserToResizeRows = False
        Me.MyDataGridView_Trace.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.MyDataGridView_Trace.BackgroundColor = System.Drawing.Color.White
        Me.MyDataGridView_Trace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MyDataGridView_Trace.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MyDataGridView_Trace.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MyDataGridView_Trace.DefaultCellStyle = DataGridViewCellStyle2
        Me.MyDataGridView_Trace.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyDataGridView_Trace.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MyDataGridView_Trace.Location = New System.Drawing.Point(0, 0)
        Me.MyDataGridView_Trace.Margin = New System.Windows.Forms.Padding(2)
        Me.MyDataGridView_Trace.MultiSelect = False
        Me.MyDataGridView_Trace.Name = "MyDataGridView_Trace"
        Me.MyDataGridView_Trace.ReadOnly = True
        Me.MyDataGridView_Trace.RowHeadersVisible = False
        Me.MyDataGridView_Trace.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.MyDataGridView_Trace.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.MyDataGridView_Trace.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MyDataGridView_Trace.Size = New System.Drawing.Size(652, 450)
        Me.MyDataGridView_Trace.TabIndex = 395
        '
        'txtServerdate
        '
        Me.txtServerdate.AcceptsReturn = True
        Me.txtServerdate.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtServerdate.Location = New System.Drawing.Point(754, 12)
        Me.txtServerdate.Name = "txtServerdate"
        Me.txtServerdate.Size = New System.Drawing.Size(43, 22)
        Me.txtServerdate.TabIndex = 396
        Me.txtServerdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtServerdate.Visible = False
        '
        'pic_morning_1
        '
        Me.pic_morning_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_morning_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_morning_1.Location = New System.Drawing.Point(7, 24)
        Me.pic_morning_1.Name = "pic_morning_1"
        Me.pic_morning_1.Size = New System.Drawing.Size(93, 81)
        Me.pic_morning_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_morning_1.TabIndex = 397
        Me.pic_morning_1.TabStop = False
        '
        'pic_morning_2
        '
        Me.pic_morning_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_morning_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_morning_2.Location = New System.Drawing.Point(106, 24)
        Me.pic_morning_2.Name = "pic_morning_2"
        Me.pic_morning_2.Size = New System.Drawing.Size(93, 81)
        Me.pic_morning_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_morning_2.TabIndex = 398
        Me.pic_morning_2.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(4, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(195, 17)
        Me.Label4.TabIndex = 399
        Me.Label4.Text = "Morning Session"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(4, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 17)
        Me.Label1.TabIndex = 402
        Me.Label1.Text = "Afternoon Session"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pic_afternoon_2
        '
        Me.pic_afternoon_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_afternoon_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_afternoon_2.Location = New System.Drawing.Point(106, 135)
        Me.pic_afternoon_2.Name = "pic_afternoon_2"
        Me.pic_afternoon_2.Size = New System.Drawing.Size(93, 81)
        Me.pic_afternoon_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_afternoon_2.TabIndex = 401
        Me.pic_afternoon_2.TabStop = False
        '
        'pic_afternoon_1
        '
        Me.pic_afternoon_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_afternoon_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_afternoon_1.Location = New System.Drawing.Point(7, 135)
        Me.pic_afternoon_1.Name = "pic_afternoon_1"
        Me.pic_afternoon_1.Size = New System.Drawing.Size(93, 81)
        Me.pic_afternoon_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_afternoon_1.TabIndex = 400
        Me.pic_afternoon_1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(4, 230)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 17)
        Me.Label2.TabIndex = 405
        Me.Label2.Text = "Overtime Session"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pic_overtime_2
        '
        Me.pic_overtime_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_overtime_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_overtime_2.Location = New System.Drawing.Point(106, 248)
        Me.pic_overtime_2.Name = "pic_overtime_2"
        Me.pic_overtime_2.Size = New System.Drawing.Size(93, 81)
        Me.pic_overtime_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_overtime_2.TabIndex = 404
        Me.pic_overtime_2.TabStop = False
        '
        'pic_overtime_1
        '
        Me.pic_overtime_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_overtime_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_overtime_1.Location = New System.Drawing.Point(7, 248)
        Me.pic_overtime_1.Name = "pic_overtime_1"
        Me.pic_overtime_1.Size = New System.Drawing.Size(93, 81)
        Me.pic_overtime_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_overtime_1.TabIndex = 403
        Me.pic_overtime_1.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 58)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.MyDataGridView_Trace)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pic_morning_1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pic_overtime_2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pic_morning_2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pic_overtime_1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pic_afternoon_1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pic_afternoon_2)
        Me.SplitContainer1.Size = New System.Drawing.Size(865, 450)
        Me.SplitContainer1.SplitterDistance = 652
        Me.SplitContainer1.TabIndex = 406
        '
        'txtYear
        '
        Me.txtYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtYear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.txtYear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYear.FormattingEnabled = True
        Me.txtYear.Location = New System.Drawing.Point(191, 29)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(87, 23)
        Me.txtYear.TabIndex = 407
        '
        'txtMonth
        '
        Me.txtMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtMonth.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.txtMonth.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.FormattingEnabled = True
        Me.txtMonth.Location = New System.Drawing.Point(281, 29)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(183, 23)
        Me.txtMonth.TabIndex = 408
        '
        'txtDay
        '
        Me.txtDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtDay.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.txtDay.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDay.FormattingEnabled = True
        Me.txtDay.Location = New System.Drawing.Point(467, 29)
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(71, 23)
        Me.txtDay.TabIndex = 409
        '
        'ckViewPicture
        '
        Me.ckViewPicture.AutoSize = True
        Me.ckViewPicture.Checked = True
        Me.ckViewPicture.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckViewPicture.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckViewPicture.Location = New System.Drawing.Point(544, 33)
        Me.ckViewPicture.Name = "ckViewPicture"
        Me.ckViewPicture.Size = New System.Drawing.Size(89, 17)
        Me.ckViewPicture.TabIndex = 411
        Me.ckViewPicture.Text = "View Picture"
        Me.ckViewPicture.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(4, 8)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(581, 17)
        Me.CheckBox1.TabIndex = 412
        Me.CheckBox1.Text = "Current date is selected as default list or you can select date to view full atte" & _
    "ndance log by unchecking this.."
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtOffice
        '
        Me.txtOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtOffice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.txtOffice.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOffice.FormattingEnabled = True
        Me.txtOffice.Location = New System.Drawing.Point(4, 29)
        Me.txtOffice.Name = "txtOffice"
        Me.txtOffice.Size = New System.Drawing.Size(183, 23)
        Me.txtOffice.TabIndex = 413
        '
        'officeid
        '
        Me.officeid.AcceptsReturn = True
        Me.officeid.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.officeid.Location = New System.Drawing.Point(803, 12)
        Me.officeid.Name = "officeid"
        Me.officeid.Size = New System.Drawing.Size(41, 22)
        Me.officeid.TabIndex = 397
        Me.officeid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.officeid.Visible = False
        '
        'frmAttendanceLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(869, 510)
        Me.Controls.Add(Me.officeid)
        Me.Controls.Add(Me.txtServerdate)
        Me.Controls.Add(Me.txtOffice)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ckViewPicture)
        Me.Controls.Add(Me.txtDay)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.SplitContainer1)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAttendanceLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attendance Log"
        Me.TopMost = True
        CType(Me.MyDataGridView_Trace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_morning_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_morning_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_afternoon_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_afternoon_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_overtime_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_overtime_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents MyDataGridView_Trace As System.Windows.Forms.DataGridView
    Friend WithEvents txtServerdate As System.Windows.Forms.TextBox
    Friend WithEvents pic_morning_1 As System.Windows.Forms.PictureBox
    Friend WithEvents pic_morning_2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pic_afternoon_2 As System.Windows.Forms.PictureBox
    Friend WithEvents pic_afternoon_1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pic_overtime_2 As System.Windows.Forms.PictureBox
    Friend WithEvents pic_overtime_1 As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtYear As System.Windows.Forms.ComboBox
    Friend WithEvents txtMonth As System.Windows.Forms.ComboBox
    Friend WithEvents txtDay As System.Windows.Forms.ComboBox
    Friend WithEvents ckViewPicture As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtOffice As System.Windows.Forms.ComboBox
    Friend WithEvents officeid As System.Windows.Forms.TextBox
End Class
