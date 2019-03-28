<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCreateJob
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxJobID = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBoxJobDescription = New System.Windows.Forms.RichTextBox()
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
        Me.DateTimePickerTargetDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DateTimePickerOpenDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBoxHiringManager = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxRecruiter = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxJobType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxCategory = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxJobPosition = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.ButtonCreateClear = New System.Windows.Forms.Button()
        Me.ButtonCreate = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_search = New System.Windows.Forms.Button()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.JobIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobPositionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Company1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecruiterDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PositionLevelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HiringManagerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Company2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.ResumeSourceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_SQL_JobTable_FormSearchJob = New InnerHeads.DS_SQL_JobTable_FormSearchJob()
        Me.Label_jobFound = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txt_jobSearch = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.JobTableTableAdapter = New InnerHeads.DS_SQL_JobTable_FormSearchJobTableAdapters.JobTableTableAdapter()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JobTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_SQL_JobTable_FormSearchJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Job ID :"
        '
        'TextBoxJobID
        '
        Me.TextBoxJobID.Enabled = False
        Me.TextBoxJobID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxJobID.ForeColor = System.Drawing.Color.Blue
        Me.TextBoxJobID.Location = New System.Drawing.Point(156, 31)
        Me.TextBoxJobID.Name = "TextBoxJobID"
        Me.TextBoxJobID.ReadOnly = True
        Me.TextBoxJobID.Size = New System.Drawing.Size(161, 22)
        Me.TextBoxJobID.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxJobDescription)
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
        Me.GroupBox1.Controls.Add(Me.ComboBoxJobType)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ComboBoxCategory)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ComboBoxJobPosition)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBoxJobID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(32, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(715, 406)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Job Details"
        '
        'TextBoxJobDescription
        '
        Me.TextBoxJobDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxJobDescription.Location = New System.Drawing.Point(156, 334)
        Me.TextBoxJobDescription.Name = "TextBoxJobDescription"
        Me.TextBoxJobDescription.Size = New System.Drawing.Size(521, 59)
        Me.TextBoxJobDescription.TabIndex = 29
        Me.TextBoxJobDescription.Text = ""
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(43, 334)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 16)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Job Description :"
        '
        'ComboBoxExperience
        '
        Me.ComboBoxExperience.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxExperience.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxExperience.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxExperience.FormattingEnabled = True
        Me.ComboBoxExperience.Items.AddRange(New Object() {"Fresher", "0-1 year", "1-3 years", "4-5 years", "5+ years"})
        Me.ComboBoxExperience.Location = New System.Drawing.Point(458, 288)
        Me.ComboBoxExperience.Name = "ComboBoxExperience"
        Me.ComboBoxExperience.Size = New System.Drawing.Size(219, 24)
        Me.ComboBoxExperience.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(342, 291)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 16)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Experience :"
        '
        'ComboBoxJobStatus
        '
        Me.ComboBoxJobStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxJobStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJobStatus.Enabled = False
        Me.ComboBoxJobStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxJobStatus.FormattingEnabled = True
        Me.ComboBoxJobStatus.Items.AddRange(New Object() {"OPEN", "OFFERED", "JOINED", "CANCELLED", "ON-HOLD"})
        Me.ComboBoxJobStatus.Location = New System.Drawing.Point(156, 288)
        Me.ComboBoxJobStatus.Name = "ComboBoxJobStatus"
        Me.ComboBoxJobStatus.Size = New System.Drawing.Size(161, 24)
        Me.ComboBoxJobStatus.TabIndex = 13
        Me.ComboBoxJobStatus.Text = "OPEN"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(43, 291)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 16)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Job Status :"
        '
        'ComboBoxJobLocation
        '
        Me.ComboBoxJobLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxJobLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJobLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxJobLocation.FormattingEnabled = True
        Me.ComboBoxJobLocation.Items.AddRange(New Object() {"Goa", "Mumbai", "Delhi"})
        Me.ComboBoxJobLocation.Location = New System.Drawing.Point(458, 245)
        Me.ComboBoxJobLocation.Name = "ComboBoxJobLocation"
        Me.ComboBoxJobLocation.Size = New System.Drawing.Size(219, 24)
        Me.ComboBoxJobLocation.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(342, 248)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 16)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Job Location :"
        '
        'ComboBoxPositionLevel
        '
        Me.ComboBoxPositionLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxPositionLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxPositionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPositionLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxPositionLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPositionLevel.FormattingEnabled = True
        Me.ComboBoxPositionLevel.Items.AddRange(New Object() {"Entry", "Mid", "Head/CXO"})
        Me.ComboBoxPositionLevel.Location = New System.Drawing.Point(157, 245)
        Me.ComboBoxPositionLevel.Name = "ComboBoxPositionLevel"
        Me.ComboBoxPositionLevel.Size = New System.Drawing.Size(160, 24)
        Me.ComboBoxPositionLevel.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(41, 248)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 16)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Position Level :"
        '
        'ComboBoxCompany2
        '
        Me.ComboBoxCompany2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxCompany2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxCompany2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCompany2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxCompany2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxCompany2.FormattingEnabled = True
        Me.ComboBoxCompany2.Location = New System.Drawing.Point(458, 204)
        Me.ComboBoxCompany2.Name = "ComboBoxCompany2"
        Me.ComboBoxCompany2.Size = New System.Drawing.Size(219, 24)
        Me.ComboBoxCompany2.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(342, 207)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 16)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Group Company :"
        '
        'ComboBoxCompany1
        '
        Me.ComboBoxCompany1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxCompany1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxCompany1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCompany1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxCompany1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxCompany1.FormattingEnabled = True
        Me.ComboBoxCompany1.Location = New System.Drawing.Point(157, 204)
        Me.ComboBoxCompany1.Name = "ComboBoxCompany1"
        Me.ComboBoxCompany1.Size = New System.Drawing.Size(160, 24)
        Me.ComboBoxCompany1.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(41, 207)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Company Name :"
        '
        'DateTimePickerTargetDate
        '
        Me.DateTimePickerTargetDate.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTargetDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerTargetDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTargetDate.Location = New System.Drawing.Point(458, 160)
        Me.DateTimePickerTargetDate.Name = "DateTimePickerTargetDate"
        Me.DateTimePickerTargetDate.Size = New System.Drawing.Size(219, 22)
        Me.DateTimePickerTargetDate.TabIndex = 8
        Me.DateTimePickerTargetDate.Value = New Date(2017, 9, 30, 9, 33, 47, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(342, 164)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Target Date :"
        '
        'DateTimePickerOpenDate
        '
        Me.DateTimePickerOpenDate.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerOpenDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerOpenDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerOpenDate.Location = New System.Drawing.Point(156, 160)
        Me.DateTimePickerOpenDate.Name = "DateTimePickerOpenDate"
        Me.DateTimePickerOpenDate.Size = New System.Drawing.Size(161, 22)
        Me.DateTimePickerOpenDate.TabIndex = 7
        Me.DateTimePickerOpenDate.Value = New Date(2017, 9, 30, 9, 33, 26, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(41, 164)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Open Date :"
        '
        'ComboBoxHiringManager
        '
        Me.ComboBoxHiringManager.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxHiringManager.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxHiringManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxHiringManager.FormattingEnabled = True
        Me.ComboBoxHiringManager.Location = New System.Drawing.Point(458, 118)
        Me.ComboBoxHiringManager.Name = "ComboBoxHiringManager"
        Me.ComboBoxHiringManager.Size = New System.Drawing.Size(219, 24)
        Me.ComboBoxHiringManager.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(342, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Hiring Manager :"
        '
        'ComboBoxRecruiter
        '
        Me.ComboBoxRecruiter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxRecruiter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxRecruiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRecruiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxRecruiter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxRecruiter.FormattingEnabled = True
        Me.ComboBoxRecruiter.Location = New System.Drawing.Point(156, 118)
        Me.ComboBoxRecruiter.Name = "ComboBoxRecruiter"
        Me.ComboBoxRecruiter.Size = New System.Drawing.Size(161, 24)
        Me.ComboBoxRecruiter.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(41, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Recruiter :"
        '
        'ComboBoxJobType
        '
        Me.ComboBoxJobType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxJobType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJobType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxJobType.FormattingEnabled = True
        Me.ComboBoxJobType.Items.AddRange(New Object() {"Employee", "Professional", "Contract"})
        Me.ComboBoxJobType.Location = New System.Drawing.Point(458, 73)
        Me.ComboBoxJobType.Name = "ComboBoxJobType"
        Me.ComboBoxJobType.Size = New System.Drawing.Size(219, 24)
        Me.ComboBoxJobType.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(342, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Job Type :"
        '
        'ComboBoxCategory
        '
        Me.ComboBoxCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxCategory.FormattingEnabled = True
        Me.ComboBoxCategory.Location = New System.Drawing.Point(156, 73)
        Me.ComboBoxCategory.Name = "ComboBoxCategory"
        Me.ComboBoxCategory.Size = New System.Drawing.Size(161, 24)
        Me.ComboBoxCategory.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(41, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Category :"
        '
        'ComboBoxJobPosition
        '
        Me.ComboBoxJobPosition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxJobPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJobPosition.DisplayMember = "PositionName"
        Me.ComboBoxJobPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxJobPosition.FormattingEnabled = True
        Me.ComboBoxJobPosition.Location = New System.Drawing.Point(458, 31)
        Me.ComboBoxJobPosition.Name = "ComboBoxJobPosition"
        Me.ComboBoxJobPosition.Size = New System.Drawing.Size(219, 24)
        Me.ComboBoxJobPosition.TabIndex = 2
        Me.ComboBoxJobPosition.ValueMember = "PositionName"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(342, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Job Position :"
        '
        'ButtonClose
        '
        Me.ButtonClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClose.Image = Global.InnerHeads.My.Resources.Resources.close
        Me.ButtonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonClose.Location = New System.Drawing.Point(470, 18)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(100, 37)
        Me.ButtonClose.TabIndex = 18
        Me.ButtonClose.Text = "CL&OSE"
        Me.ButtonClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ButtonCreateClear
        '
        Me.ButtonCreateClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCreateClear.Image = Global.InnerHeads.My.Resources.Resources.clear
        Me.ButtonCreateClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCreateClear.Location = New System.Drawing.Point(314, 18)
        Me.ButtonCreateClear.Name = "ButtonCreateClear"
        Me.ButtonCreateClear.Size = New System.Drawing.Size(101, 37)
        Me.ButtonCreateClear.TabIndex = 17
        Me.ButtonCreateClear.Text = "C&LEAR"
        Me.ButtonCreateClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCreateClear.UseVisualStyleBackColor = True
        '
        'ButtonCreate
        '
        Me.ButtonCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCreate.Image = Global.InnerHeads.My.Resources.Resources.addnew
        Me.ButtonCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCreate.Location = New System.Drawing.Point(144, 18)
        Me.ButtonCreate.Name = "ButtonCreate"
        Me.ButtonCreate.Size = New System.Drawing.Size(115, 37)
        Me.ButtonCreate.TabIndex = 16
        Me.ButtonCreate.Text = "&CREATE"
        Me.ButtonCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCreate.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonCreate)
        Me.GroupBox2.Controls.Add(Me.ButtonClose)
        Me.GroupBox2.Controls.Add(Me.ButtonCreateClear)
        Me.GroupBox2.Location = New System.Drawing.Point(32, 481)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(715, 67)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.Controls.Add(Me.Btn_search)
        Me.Panel1.Controls.Add(Me.DataGridView3)
        Me.Panel1.Controls.Add(Me.Label_jobFound)
        Me.Panel1.Controls.Add(Me.Label37)
        Me.Panel1.Controls.Add(Me.txt_jobSearch)
        Me.Panel1.Controls.Add(Me.Label36)
        Me.Panel1.Location = New System.Drawing.Point(762, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(402, 550)
        Me.Panel1.TabIndex = 16
        '
        'Btn_search
        '
        Me.Btn_search.BackgroundImage = Global.InnerHeads.My.Resources.Resources.search2
        Me.Btn_search.FlatAppearance.BorderSize = 0
        Me.Btn_search.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Btn_search.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_search.Location = New System.Drawing.Point(365, 24)
        Me.Btn_search.Margin = New System.Windows.Forms.Padding(0)
        Me.Btn_search.Name = "Btn_search"
        Me.Btn_search.Size = New System.Drawing.Size(28, 24)
        Me.Btn_search.TabIndex = 81
        Me.Btn_search.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.Btn_search.UseVisualStyleBackColor = True
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.AllowUserToOrderColumns = True
        Me.DataGridView3.AutoGenerateColumns = False
        Me.DataGridView3.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JobIDDataGridViewTextBoxColumn, Me.JobPositionDataGridViewTextBoxColumn, Me.Company1DataGridViewTextBoxColumn, Me.RecruiterDataGridViewTextBoxColumn, Me.JobStatusDataGridViewTextBoxColumn, Me.PositionLevelDataGridViewTextBoxColumn, Me.OpenDateDataGridViewTextBoxColumn, Me.JobTypeDataGridViewTextBoxColumn, Me.CategoryDataGridViewTextBoxColumn, Me.HiringManagerDataGridViewTextBoxColumn, Me.TargetDateDataGridViewTextBoxColumn, Me.Company2DataGridViewTextBoxColumn, Me.JobLocationDataGridViewTextBoxColumn, Me.ExperienceDataGridViewTextBoxColumn, Me.JobDescriptionDataGridViewTextBoxColumn, Me.TotalApplicationDataGridViewTextBoxColumn, Me.ApplicationIDDataGridViewTextBoxColumn, Me.CandidateNameDataGridViewTextBoxColumn, Me.JoiningDateDataGridViewTextBoxColumn, Me.ElapsedTimeDataGridViewTextBoxColumn, Me.PositionModifiedDataGridViewTextBoxColumn, Me.ModifyByDataGridViewTextBoxColumn, Me.ModifyDateDataGridViewTextBoxColumn, Me.RemarksDataGridViewTextBoxColumn, Me.ResumeSourceDataGridViewTextBoxColumn})
        Me.DataGridView3.DataSource = Me.JobTableBindingSource
        Me.DataGridView3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView3.Location = New System.Drawing.Point(5, 54)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.RowHeadersWidth = 20
        Me.DataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView3.Size = New System.Drawing.Size(388, 488)
        Me.DataGridView3.TabIndex = 22
        '
        'JobIDDataGridViewTextBoxColumn
        '
        Me.JobIDDataGridViewTextBoxColumn.DataPropertyName = "Job_ID"
        Me.JobIDDataGridViewTextBoxColumn.HeaderText = "Job_ID"
        Me.JobIDDataGridViewTextBoxColumn.Name = "JobIDDataGridViewTextBoxColumn"
        Me.JobIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.JobIDDataGridViewTextBoxColumn.Width = 50
        '
        'JobPositionDataGridViewTextBoxColumn
        '
        Me.JobPositionDataGridViewTextBoxColumn.DataPropertyName = "Job_Position"
        Me.JobPositionDataGridViewTextBoxColumn.HeaderText = "Job_Position"
        Me.JobPositionDataGridViewTextBoxColumn.Name = "JobPositionDataGridViewTextBoxColumn"
        Me.JobPositionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Company1DataGridViewTextBoxColumn
        '
        Me.Company1DataGridViewTextBoxColumn.DataPropertyName = "Company1"
        Me.Company1DataGridViewTextBoxColumn.HeaderText = "Company1"
        Me.Company1DataGridViewTextBoxColumn.Name = "Company1DataGridViewTextBoxColumn"
        Me.Company1DataGridViewTextBoxColumn.ReadOnly = True
        Me.Company1DataGridViewTextBoxColumn.Width = 70
        '
        'RecruiterDataGridViewTextBoxColumn
        '
        Me.RecruiterDataGridViewTextBoxColumn.DataPropertyName = "Recruiter"
        Me.RecruiterDataGridViewTextBoxColumn.HeaderText = "Recruiter"
        Me.RecruiterDataGridViewTextBoxColumn.Name = "RecruiterDataGridViewTextBoxColumn"
        Me.RecruiterDataGridViewTextBoxColumn.ReadOnly = True
        Me.RecruiterDataGridViewTextBoxColumn.Width = 70
        '
        'JobStatusDataGridViewTextBoxColumn
        '
        Me.JobStatusDataGridViewTextBoxColumn.DataPropertyName = "Job_Status"
        Me.JobStatusDataGridViewTextBoxColumn.HeaderText = "Job_Status"
        Me.JobStatusDataGridViewTextBoxColumn.Name = "JobStatusDataGridViewTextBoxColumn"
        Me.JobStatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.JobStatusDataGridViewTextBoxColumn.Width = 80
        '
        'PositionLevelDataGridViewTextBoxColumn
        '
        Me.PositionLevelDataGridViewTextBoxColumn.DataPropertyName = "Position_Level"
        Me.PositionLevelDataGridViewTextBoxColumn.HeaderText = "Position_Level"
        Me.PositionLevelDataGridViewTextBoxColumn.Name = "PositionLevelDataGridViewTextBoxColumn"
        Me.PositionLevelDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OpenDateDataGridViewTextBoxColumn
        '
        Me.OpenDateDataGridViewTextBoxColumn.DataPropertyName = "Open_Date"
        DataGridViewCellStyle1.Format = "dd-MMM-yyyy"
        Me.OpenDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.OpenDateDataGridViewTextBoxColumn.HeaderText = "Open_Date"
        Me.OpenDateDataGridViewTextBoxColumn.Name = "OpenDateDataGridViewTextBoxColumn"
        Me.OpenDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'JobTypeDataGridViewTextBoxColumn
        '
        Me.JobTypeDataGridViewTextBoxColumn.DataPropertyName = "Job_Type"
        Me.JobTypeDataGridViewTextBoxColumn.HeaderText = "Job_Type"
        Me.JobTypeDataGridViewTextBoxColumn.Name = "JobTypeDataGridViewTextBoxColumn"
        Me.JobTypeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CategoryDataGridViewTextBoxColumn
        '
        Me.CategoryDataGridViewTextBoxColumn.DataPropertyName = "Category"
        Me.CategoryDataGridViewTextBoxColumn.HeaderText = "Category"
        Me.CategoryDataGridViewTextBoxColumn.Name = "CategoryDataGridViewTextBoxColumn"
        Me.CategoryDataGridViewTextBoxColumn.ReadOnly = True
        '
        'HiringManagerDataGridViewTextBoxColumn
        '
        Me.HiringManagerDataGridViewTextBoxColumn.DataPropertyName = "Hiring_Manager"
        Me.HiringManagerDataGridViewTextBoxColumn.HeaderText = "Hiring_Manager"
        Me.HiringManagerDataGridViewTextBoxColumn.Name = "HiringManagerDataGridViewTextBoxColumn"
        Me.HiringManagerDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TargetDateDataGridViewTextBoxColumn
        '
        Me.TargetDateDataGridViewTextBoxColumn.DataPropertyName = "Target_Date"
        DataGridViewCellStyle2.Format = "dd-MMM-yyyy"
        Me.TargetDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
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
        DataGridViewCellStyle3.Format = "dd-MMM-yyyy"
        Me.JoiningDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
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
        DataGridViewCellStyle4.Format = "dd-MMM-yyyy"
        Me.ModifyDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
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
        'ResumeSourceDataGridViewTextBoxColumn
        '
        Me.ResumeSourceDataGridViewTextBoxColumn.DataPropertyName = "Resume_Source"
        Me.ResumeSourceDataGridViewTextBoxColumn.HeaderText = "Resume_Source"
        Me.ResumeSourceDataGridViewTextBoxColumn.Name = "ResumeSourceDataGridViewTextBoxColumn"
        Me.ResumeSourceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'JobTableBindingSource
        '
        Me.JobTableBindingSource.DataMember = "JobTable"
        Me.JobTableBindingSource.DataSource = Me.DS_SQL_JobTable_FormSearchJob
        '
        'DS_SQL_JobTable_FormSearchJob
        '
        Me.DS_SQL_JobTable_FormSearchJob.DataSetName = "DS_SQL_JobTable_FormSearchJob"
        Me.DS_SQL_JobTable_FormSearchJob.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label_jobFound
        '
        Me.Label_jobFound.AutoSize = True
        Me.Label_jobFound.Location = New System.Drawing.Point(321, 11)
        Me.Label_jobFound.Name = "Label_jobFound"
        Me.Label_jobFound.Size = New System.Drawing.Size(13, 13)
        Me.Label_jobFound.TabIndex = 15
        Me.Label_jobFound.Text = "0"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(279, 11)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(43, 13)
        Me.Label37.TabIndex = 14
        Me.Label37.Text = "Result :"
        '
        'txt_jobSearch
        '
        Me.txt_jobSearch.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txt_jobSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jobSearch.Location = New System.Drawing.Point(5, 24)
        Me.txt_jobSearch.Name = "txt_jobSearch"
        Me.txt_jobSearch.Size = New System.Drawing.Size(357, 24)
        Me.txt_jobSearch.TabIndex = 21
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(4, 4)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(174, 17)
        Me.Label36.TabIndex = 4
        Me.Label36.Text = "Search Existing Positions"
        '
        'JobTableTableAdapter
        '
        Me.JobTableTableAdapter.ClearBeforeFill = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.Location = New System.Drawing.Point(221, 23)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(337, 31)
        Me.Label17.TabIndex = 52
        Me.Label17.Text = "CREATE NEW POSITION"
        '
        'FormCreateJob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1177, 560)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(100, 50)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCreateJob"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Create Job"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JobTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_SQL_JobTable_FormSearchJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxJobID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxJobType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxJobPosition As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxRecruiter As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxHiringManager As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerOpenDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTargetDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxJobLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPositionLevel As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCompany2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCompany1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxExperience As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxJobStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ButtonCreate As System.Windows.Forms.Button
    Friend WithEvents ButtonCreateClear As System.Windows.Forms.Button
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents TextBoxJobDescription As RichTextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Btn_search As Button
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents Label_jobFound As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents txt_jobSearch As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents DS_SQL_JobTable_FormSearchJob As DS_SQL_JobTable_FormSearchJob
    Friend WithEvents JobTableBindingSource As BindingSource
    Friend WithEvents JobTableTableAdapter As DS_SQL_JobTable_FormSearchJobTableAdapters.JobTableTableAdapter
    Friend WithEvents JobIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobPositionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Company1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RecruiterDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobStatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PositionLevelDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OpenDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CategoryDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HiringManagerDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TargetDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Company2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
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
    Friend WithEvents ResumeSourceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Label17 As Label
End Class
