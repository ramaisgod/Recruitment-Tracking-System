<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormModifyPositions
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboBoxExperience = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBoxJobStatus = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ComboBoxJobLocation = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboBoxPositionLevel = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboBoxCompany2 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBoxCompany1 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ButtonModificationSave = New System.Windows.Forms.Button()
        Me.DateTimePickerTargetDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DateTimePickerOpenDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBoxHiringManager = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxRecruiter = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxJobType = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBoxJobDescription = New System.Windows.Forms.RichTextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.LabelCurrentStatus = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CheckBoxAllowModification = New System.Windows.Forms.CheckBox()
        Me.DateTimePickerModifyDate = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ComboBoxModifiedBy = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ComboBoxModifyJobID = New System.Windows.Forms.ComboBox()
        Me.TextBoxRemarks = New System.Windows.Forms.TextBox()
        Me.ComboBoxCategory = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxJobPosition = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_searchApp = New System.Windows.Forms.Button()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.JobIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobPositionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Company1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecruiterDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HiringManagerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Company2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PositionLevelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobLocationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExperienceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalApplicationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApplicationIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CandidateNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JoiningDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ElapsedTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PositionModifiedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifyByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifyDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemarksDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resume_Source = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobTableBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_SQL_JobTable_FormSearchJob = New InnerHeads.DS_SQL_JobTable_FormSearchJob()
        Me.Label_jobFound = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txt_jobSearch = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.JobTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.JobTableTableAdapter1 = New InnerHeads.DS_SQL_JobTable_FormSearchJobTableAdapters.JobTableTableAdapter()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JobTableBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_SQL_JobTable_FormSearchJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JobTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(65, 345)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Remarks :"
        '
        'ComboBoxExperience
        '
        Me.ComboBoxExperience.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxExperience.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxExperience.Enabled = False
        Me.ComboBoxExperience.FormattingEnabled = True
        Me.ComboBoxExperience.Items.AddRange(New Object() {"Fresher", "0-1 year", "1-3 years", "4-5 years", "5+ years"})
        Me.ComboBoxExperience.Location = New System.Drawing.Point(433, 252)
        Me.ComboBoxExperience.Name = "ComboBoxExperience"
        Me.ComboBoxExperience.Size = New System.Drawing.Size(219, 21)
        Me.ComboBoxExperience.TabIndex = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(342, 255)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Experience :"
        '
        'ComboBoxJobStatus
        '
        Me.ComboBoxJobStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxJobStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJobStatus.Enabled = False
        Me.ComboBoxJobStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxJobStatus.FormattingEnabled = True
        Me.ComboBoxJobStatus.Items.AddRange(New Object() {"OPEN", "CANCELLED", "ON-HOLD"})
        Me.ComboBoxJobStatus.Location = New System.Drawing.Point(433, 49)
        Me.ComboBoxJobStatus.Name = "ComboBoxJobStatus"
        Me.ComboBoxJobStatus.Size = New System.Drawing.Size(219, 21)
        Me.ComboBoxJobStatus.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(342, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Job Status :"
        '
        'ComboBoxJobLocation
        '
        Me.ComboBoxJobLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxJobLocation.Enabled = False
        Me.ComboBoxJobLocation.FormattingEnabled = True
        Me.ComboBoxJobLocation.Items.AddRange(New Object() {"Goa", "Mumbai", "Delhi"})
        Me.ComboBoxJobLocation.Location = New System.Drawing.Point(433, 217)
        Me.ComboBoxJobLocation.Name = "ComboBoxJobLocation"
        Me.ComboBoxJobLocation.Size = New System.Drawing.Size(219, 21)
        Me.ComboBoxJobLocation.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(342, 220)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Job Location :"
        '
        'ComboBoxPositionLevel
        '
        Me.ComboBoxPositionLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxPositionLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxPositionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPositionLevel.Enabled = False
        Me.ComboBoxPositionLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxPositionLevel.FormattingEnabled = True
        Me.ComboBoxPositionLevel.Items.AddRange(New Object() {"Entry", "Mid", "Head/CXO"})
        Me.ComboBoxPositionLevel.Location = New System.Drawing.Point(157, 217)
        Me.ComboBoxPositionLevel.Name = "ComboBoxPositionLevel"
        Me.ComboBoxPositionLevel.Size = New System.Drawing.Size(160, 21)
        Me.ComboBoxPositionLevel.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(63, 220)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Position Level :"
        '
        'ComboBoxCompany2
        '
        Me.ComboBoxCompany2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxCompany2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxCompany2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCompany2.Enabled = False
        Me.ComboBoxCompany2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxCompany2.FormattingEnabled = True
        Me.ComboBoxCompany2.Items.AddRange(New Object() {"Prototyze", "Private Unlimited", "InnerHeads"})
        Me.ComboBoxCompany2.Location = New System.Drawing.Point(433, 182)
        Me.ComboBoxCompany2.Name = "ComboBoxCompany2"
        Me.ComboBoxCompany2.Size = New System.Drawing.Size(219, 21)
        Me.ComboBoxCompany2.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(342, 185)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Company :"
        '
        'ComboBoxCompany1
        '
        Me.ComboBoxCompany1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxCompany1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxCompany1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCompany1.Enabled = False
        Me.ComboBoxCompany1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxCompany1.FormattingEnabled = True
        Me.ComboBoxCompany1.Location = New System.Drawing.Point(157, 182)
        Me.ComboBoxCompany1.Name = "ComboBoxCompany1"
        Me.ComboBoxCompany1.Size = New System.Drawing.Size(160, 21)
        Me.ComboBoxCompany1.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(63, 185)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Company Name :"
        '
        'ButtonModificationSave
        '
        Me.ButtonModificationSave.Enabled = False
        Me.ButtonModificationSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonModificationSave.Image = Global.InnerHeads.My.Resources.Resources.save
        Me.ButtonModificationSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonModificationSave.Location = New System.Drawing.Point(220, 15)
        Me.ButtonModificationSave.Name = "ButtonModificationSave"
        Me.ButtonModificationSave.Size = New System.Drawing.Size(93, 35)
        Me.ButtonModificationSave.TabIndex = 19
        Me.ButtonModificationSave.Text = "&Save"
        Me.ButtonModificationSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonModificationSave.UseVisualStyleBackColor = True
        '
        'DateTimePickerTargetDate
        '
        Me.DateTimePickerTargetDate.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTargetDate.Enabled = False
        Me.DateTimePickerTargetDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTargetDate.Location = New System.Drawing.Point(433, 149)
        Me.DateTimePickerTargetDate.Name = "DateTimePickerTargetDate"
        Me.DateTimePickerTargetDate.Size = New System.Drawing.Size(219, 20)
        Me.DateTimePickerTargetDate.TabIndex = 9
        Me.DateTimePickerTargetDate.Value = New Date(2017, 9, 17, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(342, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Target Date :"
        '
        'DateTimePickerOpenDate
        '
        Me.DateTimePickerOpenDate.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerOpenDate.Enabled = False
        Me.DateTimePickerOpenDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerOpenDate.Location = New System.Drawing.Point(156, 149)
        Me.DateTimePickerOpenDate.Name = "DateTimePickerOpenDate"
        Me.DateTimePickerOpenDate.Size = New System.Drawing.Size(161, 20)
        Me.DateTimePickerOpenDate.TabIndex = 8
        Me.DateTimePickerOpenDate.Value = New Date(2017, 9, 17, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(63, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Open Date :"
        '
        'ComboBoxHiringManager
        '
        Me.ComboBoxHiringManager.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxHiringManager.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxHiringManager.Enabled = False
        Me.ComboBoxHiringManager.FormattingEnabled = True
        Me.ComboBoxHiringManager.Location = New System.Drawing.Point(433, 115)
        Me.ComboBoxHiringManager.Name = "ComboBoxHiringManager"
        Me.ComboBoxHiringManager.Size = New System.Drawing.Size(219, 21)
        Me.ComboBoxHiringManager.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(342, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Hiring Manager :"
        '
        'ComboBoxRecruiter
        '
        Me.ComboBoxRecruiter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxRecruiter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxRecruiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRecruiter.Enabled = False
        Me.ComboBoxRecruiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxRecruiter.FormattingEnabled = True
        Me.ComboBoxRecruiter.Location = New System.Drawing.Point(156, 115)
        Me.ComboBoxRecruiter.Name = "ComboBoxRecruiter"
        Me.ComboBoxRecruiter.Size = New System.Drawing.Size(161, 21)
        Me.ComboBoxRecruiter.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(63, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Recruiter :"
        '
        'ComboBoxJobType
        '
        Me.ComboBoxJobType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxJobType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJobType.Enabled = False
        Me.ComboBoxJobType.FormattingEnabled = True
        Me.ComboBoxJobType.Items.AddRange(New Object() {"Employee", "Professional", "Contract"})
        Me.ComboBoxJobType.Location = New System.Drawing.Point(154, 252)
        Me.ComboBoxJobType.Name = "ComboBoxJobType"
        Me.ComboBoxJobType.Size = New System.Drawing.Size(163, 21)
        Me.ComboBoxJobType.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxJobDescription)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.LabelCurrentStatus)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.CheckBoxAllowModification)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerModifyDate)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.ComboBoxModifiedBy)
        Me.GroupBox1.Controls.Add(Me.ComboBoxJobType)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.ComboBoxModifyJobID)
        Me.GroupBox1.Controls.Add(Me.TextBoxRemarks)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.ComboBoxExperience)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.ComboBoxJobStatus)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.ComboBoxJobLocation)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.ComboBoxPositionLevel)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.ComboBoxCompany2)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.ComboBoxCompany1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerTargetDate)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerOpenDate)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.ComboBoxHiringManager)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ComboBoxRecruiter)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ComboBoxCategory)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ComboBoxJobPosition)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(695, 423)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Job Details"
        '
        'TextBoxJobDescription
        '
        Me.TextBoxJobDescription.Enabled = False
        Me.TextBoxJobDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxJobDescription.Location = New System.Drawing.Point(156, 288)
        Me.TextBoxJobDescription.Name = "TextBoxJobDescription"
        Me.TextBoxJobDescription.Size = New System.Drawing.Size(494, 46)
        Me.TextBoxJobDescription.TabIndex = 38
        Me.TextBoxJobDescription.Text = ""
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(63, 288)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(86, 13)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "Job Description :"
        '
        'LabelCurrentStatus
        '
        Me.LabelCurrentStatus.AutoSize = True
        Me.LabelCurrentStatus.Location = New System.Drawing.Point(430, 23)
        Me.LabelCurrentStatus.Name = "LabelCurrentStatus"
        Me.LabelCurrentStatus.Size = New System.Drawing.Size(0, 13)
        Me.LabelCurrentStatus.TabIndex = 35
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(342, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 13)
        Me.Label19.TabIndex = 34
        Me.Label19.Text = "Current Status :"
        '
        'CheckBoxAllowModification
        '
        Me.CheckBoxAllowModification.AutoSize = True
        Me.CheckBoxAllowModification.Enabled = False
        Me.CheckBoxAllowModification.Location = New System.Drawing.Point(157, 19)
        Me.CheckBoxAllowModification.Name = "CheckBoxAllowModification"
        Me.CheckBoxAllowModification.Size = New System.Drawing.Size(111, 17)
        Me.CheckBoxAllowModification.TabIndex = 2
        Me.CheckBoxAllowModification.Text = "Allow Modification"
        Me.CheckBoxAllowModification.UseVisualStyleBackColor = True
        '
        'DateTimePickerModifyDate
        '
        Me.DateTimePickerModifyDate.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerModifyDate.Enabled = False
        Me.DateTimePickerModifyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerModifyDate.Location = New System.Drawing.Point(154, 390)
        Me.DateTimePickerModifyDate.Name = "DateTimePickerModifyDate"
        Me.DateTimePickerModifyDate.Size = New System.Drawing.Size(163, 20)
        Me.DateTimePickerModifyDate.TabIndex = 16
        Me.DateTimePickerModifyDate.Value = New Date(2017, 9, 17, 0, 0, 0, 0)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(65, 392)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 13)
        Me.Label18.TabIndex = 32
        Me.Label18.Text = "Modify Date :"
        '
        'ComboBoxModifiedBy
        '
        Me.ComboBoxModifiedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxModifiedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxModifiedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxModifiedBy.Enabled = False
        Me.ComboBoxModifiedBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxModifiedBy.FormattingEnabled = True
        Me.ComboBoxModifiedBy.Location = New System.Drawing.Point(433, 389)
        Me.ComboBoxModifiedBy.Name = "ComboBoxModifiedBy"
        Me.ComboBoxModifiedBy.Size = New System.Drawing.Size(219, 21)
        Me.ComboBoxModifiedBy.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(63, 255)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Job Type :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(342, 392)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 13)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Modified by :"
        '
        'ComboBoxModifyJobID
        '
        Me.ComboBoxModifyJobID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxModifyJobID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxModifyJobID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxModifyJobID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxModifyJobID.FormattingEnabled = True
        Me.ComboBoxModifyJobID.Location = New System.Drawing.Point(156, 48)
        Me.ComboBoxModifyJobID.Name = "ComboBoxModifyJobID"
        Me.ComboBoxModifyJobID.Size = New System.Drawing.Size(161, 21)
        Me.ComboBoxModifyJobID.TabIndex = 1
        '
        'TextBoxRemarks
        '
        Me.TextBoxRemarks.Enabled = False
        Me.TextBoxRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxRemarks.Location = New System.Drawing.Point(156, 342)
        Me.TextBoxRemarks.Multiline = True
        Me.TextBoxRemarks.Name = "TextBoxRemarks"
        Me.TextBoxRemarks.Size = New System.Drawing.Size(494, 38)
        Me.TextBoxRemarks.TabIndex = 18
        '
        'ComboBoxCategory
        '
        Me.ComboBoxCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCategory.Enabled = False
        Me.ComboBoxCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxCategory.FormattingEnabled = True
        Me.ComboBoxCategory.Location = New System.Drawing.Point(433, 81)
        Me.ComboBoxCategory.Name = "ComboBoxCategory"
        Me.ComboBoxCategory.Size = New System.Drawing.Size(219, 21)
        Me.ComboBoxCategory.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(340, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Category :"
        '
        'ComboBoxJobPosition
        '
        Me.ComboBoxJobPosition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxJobPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJobPosition.DisplayMember = "PositionName"
        Me.ComboBoxJobPosition.Enabled = False
        Me.ComboBoxJobPosition.FormattingEnabled = True
        Me.ComboBoxJobPosition.Location = New System.Drawing.Point(154, 81)
        Me.ComboBoxJobPosition.Name = "ComboBoxJobPosition"
        Me.ComboBoxJobPosition.Size = New System.Drawing.Size(163, 21)
        Me.ComboBoxJobPosition.TabIndex = 4
        Me.ComboBoxJobPosition.ValueMember = "PositionName"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Job Position :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(63, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Job ID :"
        '
        'ButtonClose
        '
        Me.ButtonClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClose.Image = Global.InnerHeads.My.Resources.Resources.close
        Me.ButtonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonClose.Location = New System.Drawing.Point(381, 15)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(88, 35)
        Me.ButtonClose.TabIndex = 20
        Me.ButtonClose.Text = "Cl&ose"
        Me.ButtonClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.Controls.Add(Me.Btn_searchApp)
        Me.Panel1.Controls.Add(Me.DataGridView5)
        Me.Panel1.Controls.Add(Me.Label_jobFound)
        Me.Panel1.Controls.Add(Me.Label37)
        Me.Panel1.Controls.Add(Me.txt_jobSearch)
        Me.Panel1.Controls.Add(Me.Label36)
        Me.Panel1.Location = New System.Drawing.Point(733, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(402, 516)
        Me.Panel1.TabIndex = 16
        '
        'Btn_searchApp
        '
        Me.Btn_searchApp.BackgroundImage = Global.InnerHeads.My.Resources.Resources.search2
        Me.Btn_searchApp.FlatAppearance.BorderSize = 0
        Me.Btn_searchApp.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Btn_searchApp.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Btn_searchApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_searchApp.Location = New System.Drawing.Point(365, 24)
        Me.Btn_searchApp.Margin = New System.Windows.Forms.Padding(0)
        Me.Btn_searchApp.Name = "Btn_searchApp"
        Me.Btn_searchApp.Size = New System.Drawing.Size(28, 24)
        Me.Btn_searchApp.TabIndex = 83
        Me.Btn_searchApp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.Btn_searchApp.UseVisualStyleBackColor = True
        '
        'DataGridView5
        '
        Me.DataGridView5.AllowUserToAddRows = False
        Me.DataGridView5.AllowUserToDeleteRows = False
        Me.DataGridView5.AllowUserToOrderColumns = True
        Me.DataGridView5.AutoGenerateColumns = False
        Me.DataGridView5.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DataGridView5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JobIDDataGridViewTextBoxColumn, Me.JobPositionDataGridViewTextBoxColumn, Me.Company1DataGridViewTextBoxColumn, Me.JobStatusDataGridViewTextBoxColumn, Me.RecruiterDataGridViewTextBoxColumn, Me.CategoryDataGridViewTextBoxColumn, Me.JobTypeDataGridViewTextBoxColumn, Me.HiringManagerDataGridViewTextBoxColumn, Me.OpenDateDataGridViewTextBoxColumn, Me.TargetDateDataGridViewTextBoxColumn, Me.Company2DataGridViewTextBoxColumn, Me.PositionLevelDataGridViewTextBoxColumn, Me.JobLocationDataGridViewTextBoxColumn, Me.ExperienceDataGridViewTextBoxColumn, Me.JobDescriptionDataGridViewTextBoxColumn, Me.TotalApplicationDataGridViewTextBoxColumn, Me.ApplicationIDDataGridViewTextBoxColumn, Me.CandidateNameDataGridViewTextBoxColumn, Me.JoiningDateDataGridViewTextBoxColumn, Me.ElapsedTimeDataGridViewTextBoxColumn, Me.PositionModifiedDataGridViewTextBoxColumn, Me.ModifyByDataGridViewTextBoxColumn, Me.ModifyDateDataGridViewTextBoxColumn, Me.RemarksDataGridViewTextBoxColumn, Me.Resume_Source})
        Me.DataGridView5.DataSource = Me.JobTableBindingSource1
        Me.DataGridView5.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView5.Location = New System.Drawing.Point(5, 54)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.ReadOnly = True
        Me.DataGridView5.RowHeadersWidth = 20
        Me.DataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView5.Size = New System.Drawing.Size(388, 459)
        Me.DataGridView5.TabIndex = 22
        '
        'JobIDDataGridViewTextBoxColumn
        '
        Me.JobIDDataGridViewTextBoxColumn.DataPropertyName = "Job_ID"
        Me.JobIDDataGridViewTextBoxColumn.HeaderText = "Job_ID"
        Me.JobIDDataGridViewTextBoxColumn.Name = "JobIDDataGridViewTextBoxColumn"
        Me.JobIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.JobIDDataGridViewTextBoxColumn.Width = 70
        '
        'JobPositionDataGridViewTextBoxColumn
        '
        Me.JobPositionDataGridViewTextBoxColumn.DataPropertyName = "Job_Position"
        Me.JobPositionDataGridViewTextBoxColumn.HeaderText = "Job_Position"
        Me.JobPositionDataGridViewTextBoxColumn.Name = "JobPositionDataGridViewTextBoxColumn"
        Me.JobPositionDataGridViewTextBoxColumn.ReadOnly = True
        Me.JobPositionDataGridViewTextBoxColumn.Width = 80
        '
        'Company1DataGridViewTextBoxColumn
        '
        Me.Company1DataGridViewTextBoxColumn.DataPropertyName = "Company1"
        Me.Company1DataGridViewTextBoxColumn.HeaderText = "Company1"
        Me.Company1DataGridViewTextBoxColumn.Name = "Company1DataGridViewTextBoxColumn"
        Me.Company1DataGridViewTextBoxColumn.ReadOnly = True
        Me.Company1DataGridViewTextBoxColumn.Width = 80
        '
        'JobStatusDataGridViewTextBoxColumn
        '
        Me.JobStatusDataGridViewTextBoxColumn.DataPropertyName = "Job_Status"
        Me.JobStatusDataGridViewTextBoxColumn.HeaderText = "Job_Status"
        Me.JobStatusDataGridViewTextBoxColumn.Name = "JobStatusDataGridViewTextBoxColumn"
        Me.JobStatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.JobStatusDataGridViewTextBoxColumn.Width = 80
        '
        'RecruiterDataGridViewTextBoxColumn
        '
        Me.RecruiterDataGridViewTextBoxColumn.DataPropertyName = "Recruiter"
        Me.RecruiterDataGridViewTextBoxColumn.HeaderText = "Recruiter"
        Me.RecruiterDataGridViewTextBoxColumn.Name = "RecruiterDataGridViewTextBoxColumn"
        Me.RecruiterDataGridViewTextBoxColumn.ReadOnly = True
        Me.RecruiterDataGridViewTextBoxColumn.Width = 80
        '
        'CategoryDataGridViewTextBoxColumn
        '
        Me.CategoryDataGridViewTextBoxColumn.DataPropertyName = "Category"
        Me.CategoryDataGridViewTextBoxColumn.HeaderText = "Category"
        Me.CategoryDataGridViewTextBoxColumn.Name = "CategoryDataGridViewTextBoxColumn"
        Me.CategoryDataGridViewTextBoxColumn.ReadOnly = True
        '
        'JobTypeDataGridViewTextBoxColumn
        '
        Me.JobTypeDataGridViewTextBoxColumn.DataPropertyName = "Job_Type"
        Me.JobTypeDataGridViewTextBoxColumn.HeaderText = "Job_Type"
        Me.JobTypeDataGridViewTextBoxColumn.Name = "JobTypeDataGridViewTextBoxColumn"
        Me.JobTypeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'HiringManagerDataGridViewTextBoxColumn
        '
        Me.HiringManagerDataGridViewTextBoxColumn.DataPropertyName = "Hiring_Manager"
        Me.HiringManagerDataGridViewTextBoxColumn.HeaderText = "Hiring_Manager"
        Me.HiringManagerDataGridViewTextBoxColumn.Name = "HiringManagerDataGridViewTextBoxColumn"
        Me.HiringManagerDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OpenDateDataGridViewTextBoxColumn
        '
        Me.OpenDateDataGridViewTextBoxColumn.DataPropertyName = "Open_Date"
        DataGridViewCellStyle5.Format = "dd-MMM-yyyy"
        Me.OpenDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.OpenDateDataGridViewTextBoxColumn.HeaderText = "Open_Date"
        Me.OpenDateDataGridViewTextBoxColumn.Name = "OpenDateDataGridViewTextBoxColumn"
        Me.OpenDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TargetDateDataGridViewTextBoxColumn
        '
        Me.TargetDateDataGridViewTextBoxColumn.DataPropertyName = "Target_Date"
        DataGridViewCellStyle6.Format = "dd-MMM-yyyy"
        Me.TargetDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.TargetDateDataGridViewTextBoxColumn.HeaderText = "Target_Date"
        Me.TargetDateDataGridViewTextBoxColumn.Name = "TargetDateDataGridViewTextBoxColumn"
        Me.TargetDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Company2DataGridViewTextBoxColumn
        '
        Me.Company2DataGridViewTextBoxColumn.DataPropertyName = "Company2"
        Me.Company2DataGridViewTextBoxColumn.HeaderText = "Company2"
        Me.Company2DataGridViewTextBoxColumn.Name = "Company2DataGridViewTextBoxColumn"
        Me.Company2DataGridViewTextBoxColumn.ReadOnly = True
        '
        'PositionLevelDataGridViewTextBoxColumn
        '
        Me.PositionLevelDataGridViewTextBoxColumn.DataPropertyName = "Position_Level"
        Me.PositionLevelDataGridViewTextBoxColumn.HeaderText = "Position_Level"
        Me.PositionLevelDataGridViewTextBoxColumn.Name = "PositionLevelDataGridViewTextBoxColumn"
        Me.PositionLevelDataGridViewTextBoxColumn.ReadOnly = True
        '
        'JobLocationDataGridViewTextBoxColumn
        '
        Me.JobLocationDataGridViewTextBoxColumn.DataPropertyName = "Job_Location"
        Me.JobLocationDataGridViewTextBoxColumn.HeaderText = "Job_Location"
        Me.JobLocationDataGridViewTextBoxColumn.Name = "JobLocationDataGridViewTextBoxColumn"
        Me.JobLocationDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ExperienceDataGridViewTextBoxColumn
        '
        Me.ExperienceDataGridViewTextBoxColumn.DataPropertyName = "Experience"
        Me.ExperienceDataGridViewTextBoxColumn.HeaderText = "Experience"
        Me.ExperienceDataGridViewTextBoxColumn.Name = "ExperienceDataGridViewTextBoxColumn"
        Me.ExperienceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'JobDescriptionDataGridViewTextBoxColumn
        '
        Me.JobDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Job_Description"
        Me.JobDescriptionDataGridViewTextBoxColumn.HeaderText = "Job_Description"
        Me.JobDescriptionDataGridViewTextBoxColumn.Name = "JobDescriptionDataGridViewTextBoxColumn"
        Me.JobDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TotalApplicationDataGridViewTextBoxColumn
        '
        Me.TotalApplicationDataGridViewTextBoxColumn.DataPropertyName = "Total_Application"
        Me.TotalApplicationDataGridViewTextBoxColumn.HeaderText = "Total_Application"
        Me.TotalApplicationDataGridViewTextBoxColumn.Name = "TotalApplicationDataGridViewTextBoxColumn"
        Me.TotalApplicationDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ApplicationIDDataGridViewTextBoxColumn
        '
        Me.ApplicationIDDataGridViewTextBoxColumn.DataPropertyName = "Application_ID"
        Me.ApplicationIDDataGridViewTextBoxColumn.HeaderText = "Application_ID"
        Me.ApplicationIDDataGridViewTextBoxColumn.Name = "ApplicationIDDataGridViewTextBoxColumn"
        Me.ApplicationIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CandidateNameDataGridViewTextBoxColumn
        '
        Me.CandidateNameDataGridViewTextBoxColumn.DataPropertyName = "Candidate_Name"
        Me.CandidateNameDataGridViewTextBoxColumn.HeaderText = "Candidate_Name"
        Me.CandidateNameDataGridViewTextBoxColumn.Name = "CandidateNameDataGridViewTextBoxColumn"
        Me.CandidateNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'JoiningDateDataGridViewTextBoxColumn
        '
        Me.JoiningDateDataGridViewTextBoxColumn.DataPropertyName = "Joining_Date"
        DataGridViewCellStyle7.Format = "dd-MMM-yyyy"
        Me.JoiningDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.JoiningDateDataGridViewTextBoxColumn.HeaderText = "Joining_Date"
        Me.JoiningDateDataGridViewTextBoxColumn.Name = "JoiningDateDataGridViewTextBoxColumn"
        Me.JoiningDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ElapsedTimeDataGridViewTextBoxColumn
        '
        Me.ElapsedTimeDataGridViewTextBoxColumn.DataPropertyName = "Elapsed_Time"
        Me.ElapsedTimeDataGridViewTextBoxColumn.HeaderText = "Elapsed_Time"
        Me.ElapsedTimeDataGridViewTextBoxColumn.Name = "ElapsedTimeDataGridViewTextBoxColumn"
        Me.ElapsedTimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PositionModifiedDataGridViewTextBoxColumn
        '
        Me.PositionModifiedDataGridViewTextBoxColumn.DataPropertyName = "Position_Modified"
        Me.PositionModifiedDataGridViewTextBoxColumn.HeaderText = "Position_Modified"
        Me.PositionModifiedDataGridViewTextBoxColumn.Name = "PositionModifiedDataGridViewTextBoxColumn"
        Me.PositionModifiedDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ModifyByDataGridViewTextBoxColumn
        '
        Me.ModifyByDataGridViewTextBoxColumn.DataPropertyName = "Modify_By"
        Me.ModifyByDataGridViewTextBoxColumn.HeaderText = "Modify_By"
        Me.ModifyByDataGridViewTextBoxColumn.Name = "ModifyByDataGridViewTextBoxColumn"
        Me.ModifyByDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ModifyDateDataGridViewTextBoxColumn
        '
        Me.ModifyDateDataGridViewTextBoxColumn.DataPropertyName = "Modify_Date"
        DataGridViewCellStyle8.Format = "dd-MMM-yyyy"
        Me.ModifyDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.ModifyDateDataGridViewTextBoxColumn.HeaderText = "Modify_Date"
        Me.ModifyDateDataGridViewTextBoxColumn.Name = "ModifyDateDataGridViewTextBoxColumn"
        Me.ModifyDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RemarksDataGridViewTextBoxColumn
        '
        Me.RemarksDataGridViewTextBoxColumn.DataPropertyName = "Remarks"
        Me.RemarksDataGridViewTextBoxColumn.HeaderText = "Remarks"
        Me.RemarksDataGridViewTextBoxColumn.Name = "RemarksDataGridViewTextBoxColumn"
        Me.RemarksDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Resume_Source
        '
        Me.Resume_Source.DataPropertyName = "Resume_Source"
        Me.Resume_Source.HeaderText = "Resume_Source"
        Me.Resume_Source.Name = "Resume_Source"
        Me.Resume_Source.ReadOnly = True
        '
        'JobTableBindingSource1
        '
        Me.JobTableBindingSource1.DataMember = "JobTable"
        Me.JobTableBindingSource1.DataSource = Me.DS_SQL_JobTable_FormSearchJob
        '
        'DS_SQL_JobTable_FormSearchJob
        '
        Me.DS_SQL_JobTable_FormSearchJob.DataSetName = "DS_SQL_JobTable_FormSearchJob"
        Me.DS_SQL_JobTable_FormSearchJob.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label_jobFound
        '
        Me.Label_jobFound.AutoSize = True
        Me.Label_jobFound.Location = New System.Drawing.Point(324, 11)
        Me.Label_jobFound.Name = "Label_jobFound"
        Me.Label_jobFound.Size = New System.Drawing.Size(13, 13)
        Me.Label_jobFound.TabIndex = 15
        Me.Label_jobFound.Text = "0"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(282, 11)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(43, 13)
        Me.Label37.TabIndex = 14
        Me.Label37.Text = "Result :"
        '
        'txt_jobSearch
        '
        Me.txt_jobSearch.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txt_jobSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jobSearch.Location = New System.Drawing.Point(7, 24)
        Me.txt_jobSearch.Name = "txt_jobSearch"
        Me.txt_jobSearch.Size = New System.Drawing.Size(355, 24)
        Me.txt_jobSearch.TabIndex = 21
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(4, 4)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(146, 17)
        Me.Label36.TabIndex = 0
        Me.Label36.Text = "Search Job Positions"
        '
        'JobTableBindingSource
        '
        Me.JobTableBindingSource.DataMember = "JobTable"
        '
        'JobTableTableAdapter1
        '
        Me.JobTableTableAdapter1.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonClose)
        Me.GroupBox2.Controls.Add(Me.ButtonModificationSave)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 483)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(695, 57)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.Location = New System.Drawing.Point(197, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(325, 31)
        Me.Label21.TabIndex = 54
        Me.Label21.Text = "MODIFY JOB POSITION"
        '
        'FormModifyPositions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1136, 550)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(100, 50)
        Me.Name = "FormModifyPositions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Modify Positions"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JobTableBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_SQL_JobTable_FormSearchJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JobTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label15 As Label
    Friend WithEvents ComboBoxExperience As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents ComboBoxJobStatus As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents ComboBoxJobLocation As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents ComboBoxPositionLevel As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBoxCompany2 As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBoxCompany1 As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ButtonModificationSave As Button
    Friend WithEvents DateTimePickerTargetDate As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents DateTimePickerOpenDate As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBoxHiringManager As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBoxRecruiter As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBoxJobType As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBoxCategory As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxJobPosition As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonClose As Button
    Friend WithEvents ComboBoxModifyJobID As ComboBox
    Friend WithEvents TextBoxRemarks As TextBox
    Friend WithEvents DateTimePickerModifyDate As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents ComboBoxModifiedBy As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents CheckBoxAllowModification As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView5 As DataGridView
    Friend WithEvents Label_jobFound As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents txt_jobSearch As TextBox
    Friend WithEvents Label36 As Label
    ' Friend WithEvents IHDatabaseDataSet5 As IHDatabaseDataSet5
    Friend WithEvents JobTableBindingSource As BindingSource
    'Friend WithEvents JobTableTableAdapter As IHDatabaseDataSet5TableAdapters.JobTableTableAdapter
    Friend WithEvents LabelCurrentStatus As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents DS_SQL_JobTable_FormSearchJob As DS_SQL_JobTable_FormSearchJob
    Friend WithEvents JobTableBindingSource1 As BindingSource
    Friend WithEvents JobTableTableAdapter1 As DS_SQL_JobTable_FormSearchJobTableAdapters.JobTableTableAdapter
    Friend WithEvents JobIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobPositionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Company1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobStatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RecruiterDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CategoryDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HiringManagerDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OpenDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TargetDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Company2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PositionLevelDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobLocationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExperienceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobDescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalApplicationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ApplicationIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CandidateNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JoiningDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ElapsedTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PositionModifiedDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModifyByDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModifyDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RemarksDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Resume_Source As DataGridViewTextBoxColumn
    Friend WithEvents Label20 As Label
    Friend WithEvents Btn_searchApp As Button
    Friend WithEvents TextBoxJobDescription As RichTextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label21 As Label
End Class
