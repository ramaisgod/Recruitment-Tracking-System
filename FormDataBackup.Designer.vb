<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDataBackup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ExportDataRecruiter = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label_filepath = New System.Windows.Forms.Label()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label_exportresult = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.InnerHeads.My.Resources.Resources.ExportToXL
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(482, 130)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(156, 41)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "E&xport To Excel"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ExportDataRecruiter
        '
        Me.ExportDataRecruiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ExportDataRecruiter.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExportDataRecruiter.FormattingEnabled = True
        Me.ExportDataRecruiter.Location = New System.Drawing.Point(196, 137)
        Me.ExportDataRecruiter.Name = "ExportDataRecruiter"
        Me.ExportDataRecruiter.Size = New System.Drawing.Size(219, 32)
        Me.ExportDataRecruiter.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(94, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 24)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Recruiter :"
        '
        'Label_filepath
        '
        Me.Label_filepath.AutoSize = True
        Me.Label_filepath.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_filepath.Location = New System.Drawing.Point(95, 191)
        Me.Label_filepath.Name = "Label_filepath"
        Me.Label_filepath.Size = New System.Drawing.Size(73, 18)
        Me.Label_filepath.TabIndex = 20
        Me.Label_filepath.Text = "File Path :"
        Me.Label_filepath.Visible = False
        '
        'txtFilePath
        '
        Me.txtFilePath.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilePath.Location = New System.Drawing.Point(174, 191)
        Me.txtFilePath.Multiline = True
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.ReadOnly = True
        Me.txtFilePath.Size = New System.Drawing.Size(480, 58)
        Me.txtFilePath.TabIndex = 21
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(103, 279)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(535, 23)
        Me.ProgressBar1.TabIndex = 22
        Me.ProgressBar1.Visible = False
        '
        'Label_exportresult
        '
        Me.Label_exportresult.AutoSize = True
        Me.Label_exportresult.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_exportresult.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label_exportresult.Location = New System.Drawing.Point(98, 289)
        Me.Label_exportresult.Name = "Label_exportresult"
        Me.Label_exportresult.Size = New System.Drawing.Size(0, 20)
        Me.Label_exportresult.TabIndex = 23
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.InnerHeads.My.Resources.Resources.close
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(295, 330)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 33)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "&CLOSE"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.Location = New System.Drawing.Point(239, 29)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(205, 31)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "EXPORT DATA"
        '
        'FormDataBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(683, 376)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label_exportresult)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.txtFilePath)
        Me.Controls.Add(Me.Label_filepath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ExportDataRecruiter)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(100, 50)
        Me.Name = "FormDataBackup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Data Backup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents ExportDataRecruiter As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label_filepath As Label
    Friend WithEvents txtFilePath As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label_exportresult As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label17 As Label
End Class
