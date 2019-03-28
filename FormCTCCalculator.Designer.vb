<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCTCCalculator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCTCCalculator))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Current_FixedAnnual = New System.Windows.Forms.TextBox()
        Me.txt_Current_FixedMonthly = New System.Windows.Forms.TextBox()
        Me.txt_Current_TB = New System.Windows.Forms.TextBox()
        Me.txt_Current_PB = New System.Windows.Forms.TextBox()
        Me.txt_Current_TotalCTC = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_offer_TotalCTC = New System.Windows.Forms.TextBox()
        Me.txt_offer_TB = New System.Windows.Forms.TextBox()
        Me.txt_offer_PB = New System.Windows.Forms.TextBox()
        Me.txt_offer_FixedMonthly = New System.Windows.Forms.TextBox()
        Me.txt_offer_FixedAnnual = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_total_increment = New System.Windows.Forms.TextBox()
        Me.Btn_Calc = New System.Windows.Forms.Button()
        Me.txt_radiobutton_newofferfixedannual = New System.Windows.Forms.TextBox()
        Me.RadioButton_Increment = New System.Windows.Forms.RadioButton()
        Me.RadioButton_NewOfferFixedAnnual = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.increment = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_Multiple = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(61, 123)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fixed Annual :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 151)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fixed Monthly :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(61, 179)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Performance Bonus :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(61, 207)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Tenure Bonus :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(61, 235)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 19)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Total CTC :"
        '
        'txt_Current_FixedAnnual
        '
        Me.txt_Current_FixedAnnual.Location = New System.Drawing.Point(206, 120)
        Me.txt_Current_FixedAnnual.Name = "txt_Current_FixedAnnual"
        Me.txt_Current_FixedAnnual.Size = New System.Drawing.Size(123, 27)
        Me.txt_Current_FixedAnnual.TabIndex = 6
        '
        'txt_Current_FixedMonthly
        '
        Me.txt_Current_FixedMonthly.Location = New System.Drawing.Point(206, 148)
        Me.txt_Current_FixedMonthly.Name = "txt_Current_FixedMonthly"
        Me.txt_Current_FixedMonthly.ReadOnly = True
        Me.txt_Current_FixedMonthly.Size = New System.Drawing.Size(123, 27)
        Me.txt_Current_FixedMonthly.TabIndex = 7
        Me.txt_Current_FixedMonthly.Text = "0"
        Me.ToolTip1.SetToolTip(Me.txt_Current_FixedMonthly, "Fixed Annual / 12")
        '
        'txt_Current_TB
        '
        Me.txt_Current_TB.Location = New System.Drawing.Point(206, 204)
        Me.txt_Current_TB.Name = "txt_Current_TB"
        Me.txt_Current_TB.Size = New System.Drawing.Size(123, 27)
        Me.txt_Current_TB.TabIndex = 9
        Me.txt_Current_TB.Text = "0"
        '
        'txt_Current_PB
        '
        Me.txt_Current_PB.Location = New System.Drawing.Point(206, 176)
        Me.txt_Current_PB.Name = "txt_Current_PB"
        Me.txt_Current_PB.Size = New System.Drawing.Size(123, 27)
        Me.txt_Current_PB.TabIndex = 8
        '
        'txt_Current_TotalCTC
        '
        Me.txt_Current_TotalCTC.Location = New System.Drawing.Point(206, 232)
        Me.txt_Current_TotalCTC.Name = "txt_Current_TotalCTC"
        Me.txt_Current_TotalCTC.ReadOnly = True
        Me.txt_Current_TotalCTC.Size = New System.Drawing.Size(123, 27)
        Me.txt_Current_TotalCTC.TabIndex = 10
        Me.txt_Current_TotalCTC.Text = "0"
        Me.ToolTip1.SetToolTip(Me.txt_Current_TotalCTC, "Fixed Annual + Performance Bonus + Tenure Bonus")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(202, 98)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 19)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Current"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(358, 98)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 19)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "New Offer"
        '
        'txt_offer_TotalCTC
        '
        Me.txt_offer_TotalCTC.Location = New System.Drawing.Point(362, 232)
        Me.txt_offer_TotalCTC.Name = "txt_offer_TotalCTC"
        Me.txt_offer_TotalCTC.ReadOnly = True
        Me.txt_offer_TotalCTC.Size = New System.Drawing.Size(123, 27)
        Me.txt_offer_TotalCTC.TabIndex = 17
        Me.txt_offer_TotalCTC.TabStop = False
        Me.txt_offer_TotalCTC.Text = "0"
        Me.ToolTip1.SetToolTip(Me.txt_offer_TotalCTC, "Fixed Annual + Performance Bonus + Tenure Bonus")
        '
        'txt_offer_TB
        '
        Me.txt_offer_TB.Location = New System.Drawing.Point(362, 204)
        Me.txt_offer_TB.Name = "txt_offer_TB"
        Me.txt_offer_TB.ReadOnly = True
        Me.txt_offer_TB.Size = New System.Drawing.Size(123, 27)
        Me.txt_offer_TB.TabIndex = 16
        Me.txt_offer_TB.TabStop = False
        Me.txt_offer_TB.Text = "0"
        '
        'txt_offer_PB
        '
        Me.txt_offer_PB.Location = New System.Drawing.Point(362, 176)
        Me.txt_offer_PB.Name = "txt_offer_PB"
        Me.txt_offer_PB.ReadOnly = True
        Me.txt_offer_PB.Size = New System.Drawing.Size(123, 27)
        Me.txt_offer_PB.TabIndex = 15
        Me.txt_offer_PB.TabStop = False
        Me.txt_offer_PB.Text = "0"
        Me.ToolTip1.SetToolTip(Me.txt_offer_PB, "Fixed Monthly X 3")
        '
        'txt_offer_FixedMonthly
        '
        Me.txt_offer_FixedMonthly.Location = New System.Drawing.Point(362, 148)
        Me.txt_offer_FixedMonthly.Name = "txt_offer_FixedMonthly"
        Me.txt_offer_FixedMonthly.ReadOnly = True
        Me.txt_offer_FixedMonthly.Size = New System.Drawing.Size(123, 27)
        Me.txt_offer_FixedMonthly.TabIndex = 14
        Me.txt_offer_FixedMonthly.TabStop = False
        Me.txt_offer_FixedMonthly.Text = "0"
        Me.ToolTip1.SetToolTip(Me.txt_offer_FixedMonthly, "Fixed Annual / 12")
        '
        'txt_offer_FixedAnnual
        '
        Me.txt_offer_FixedAnnual.Location = New System.Drawing.Point(362, 120)
        Me.txt_offer_FixedAnnual.Name = "txt_offer_FixedAnnual"
        Me.txt_offer_FixedAnnual.ReadOnly = True
        Me.txt_offer_FixedAnnual.Size = New System.Drawing.Size(123, 27)
        Me.txt_offer_FixedAnnual.TabIndex = 13
        Me.txt_offer_FixedAnnual.TabStop = False
        Me.txt_offer_FixedAnnual.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(65, 370)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(143, 19)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Total Increment (%) :"
        '
        'txt_total_increment
        '
        Me.txt_total_increment.BackColor = System.Drawing.Color.Cyan
        Me.txt_total_increment.Location = New System.Drawing.Point(206, 367)
        Me.txt_total_increment.Name = "txt_total_increment"
        Me.txt_total_increment.Size = New System.Drawing.Size(123, 27)
        Me.txt_total_increment.TabIndex = 21
        Me.ToolTip1.SetToolTip(Me.txt_total_increment, "Including PB and TB")
        '
        'Btn_Calc
        '
        Me.Btn_Calc.Location = New System.Drawing.Point(389, 355)
        Me.Btn_Calc.Name = "Btn_Calc"
        Me.Btn_Calc.Size = New System.Drawing.Size(96, 49)
        Me.Btn_Calc.TabIndex = 15
        Me.Btn_Calc.Text = "&Calculate"
        Me.Btn_Calc.UseVisualStyleBackColor = True
        '
        'txt_radiobutton_newofferfixedannual
        '
        Me.txt_radiobutton_newofferfixedannual.Enabled = False
        Me.txt_radiobutton_newofferfixedannual.Location = New System.Drawing.Point(278, 320)
        Me.txt_radiobutton_newofferfixedannual.Name = "txt_radiobutton_newofferfixedannual"
        Me.txt_radiobutton_newofferfixedannual.Size = New System.Drawing.Size(123, 27)
        Me.txt_radiobutton_newofferfixedannual.TabIndex = 14
        Me.txt_radiobutton_newofferfixedannual.Text = "0"
        '
        'RadioButton_Increment
        '
        Me.RadioButton_Increment.AutoSize = True
        Me.RadioButton_Increment.Checked = True
        Me.RadioButton_Increment.Location = New System.Drawing.Point(65, 288)
        Me.RadioButton_Increment.Name = "RadioButton_Increment"
        Me.RadioButton_Increment.Size = New System.Drawing.Size(212, 23)
        Me.RadioButton_Increment.TabIndex = 11
        Me.RadioButton_Increment.TabStop = True
        Me.RadioButton_Increment.Text = "Increment Fixed Annual (%) :"
        Me.RadioButton_Increment.UseVisualStyleBackColor = True
        '
        'RadioButton_NewOfferFixedAnnual
        '
        Me.RadioButton_NewOfferFixedAnnual.AutoSize = True
        Me.RadioButton_NewOfferFixedAnnual.Location = New System.Drawing.Point(65, 320)
        Me.RadioButton_NewOfferFixedAnnual.Name = "RadioButton_NewOfferFixedAnnual"
        Me.RadioButton_NewOfferFixedAnnual.Size = New System.Drawing.Size(188, 23)
        Me.RadioButton_NewOfferFixedAnnual.TabIndex = 13
        Me.RadioButton_NewOfferFixedAnnual.TabStop = True
        Me.RadioButton_NewOfferFixedAnnual.Text = "New Offer Fixed Annual :"
        Me.RadioButton_NewOfferFixedAnnual.UseVisualStyleBackColor = True
        '
        'increment
        '
        Me.increment.BackColor = System.Drawing.Color.Cyan
        Me.increment.Location = New System.Drawing.Point(278, 288)
        Me.increment.Name = "increment"
        Me.increment.Size = New System.Drawing.Size(123, 27)
        Me.increment.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.increment, "Excluding PB and TB")
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(469, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 30)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Open C&alc"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt_Multiple
        '
        Me.txt_Multiple.Location = New System.Drawing.Point(499, 288)
        Me.txt_Multiple.Name = "txt_Multiple"
        Me.txt_Multiple.Size = New System.Drawing.Size(37, 27)
        Me.txt_Multiple.TabIndex = 23
        Me.txt_Multiple.Text = "3"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(406, 292)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 19)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "PB Multiple :"
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(491, 355)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(69, 49)
        Me.btn_Clear.TabIndex = 25
        Me.btn_Clear.Text = "Clea&r"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.Location = New System.Drawing.Point(151, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(270, 31)
        Me.Label17.TabIndex = 53
        Me.Label17.Text = "CTC CALCULATOR"
        '
        'FormCTCCalculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(572, 463)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btn_Clear)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_Multiple)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.increment)
        Me.Controls.Add(Me.RadioButton_NewOfferFixedAnnual)
        Me.Controls.Add(Me.RadioButton_Increment)
        Me.Controls.Add(Me.txt_radiobutton_newofferfixedannual)
        Me.Controls.Add(Me.Btn_Calc)
        Me.Controls.Add(Me.txt_total_increment)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_offer_TotalCTC)
        Me.Controls.Add(Me.txt_offer_TB)
        Me.Controls.Add(Me.txt_offer_PB)
        Me.Controls.Add(Me.txt_offer_FixedMonthly)
        Me.Controls.Add(Me.txt_offer_FixedAnnual)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_Current_TotalCTC)
        Me.Controls.Add(Me.txt_Current_TB)
        Me.Controls.Add(Me.txt_Current_PB)
        Me.Controls.Add(Me.txt_Current_FixedMonthly)
        Me.Controls.Add(Me.txt_Current_FixedAnnual)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(100, 50)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "FormCTCCalculator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CTC Calculator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_Current_FixedAnnual As TextBox
    Friend WithEvents txt_Current_FixedMonthly As TextBox
    Friend WithEvents txt_Current_TB As TextBox
    Friend WithEvents txt_Current_PB As TextBox
    Friend WithEvents txt_Current_TotalCTC As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_offer_TotalCTC As TextBox
    Friend WithEvents txt_offer_TB As TextBox
    Friend WithEvents txt_offer_PB As TextBox
    Friend WithEvents txt_offer_FixedMonthly As TextBox
    Friend WithEvents txt_offer_FixedAnnual As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_total_increment As TextBox
    Friend WithEvents Btn_Calc As Button
    Friend WithEvents txt_radiobutton_newofferfixedannual As TextBox
    Friend WithEvents RadioButton_Increment As RadioButton
    Friend WithEvents RadioButton_NewOfferFixedAnnual As RadioButton
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents increment As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txt_Multiple As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btn_Clear As Button
    Friend WithEvents Label17 As Label
End Class
