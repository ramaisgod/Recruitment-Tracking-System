<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSearchJob
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RecruiterDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobPositionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Company1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PositionLevelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApplicationIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CandidateNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JoiningDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Company2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobLocationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalApplicationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ResumeSourceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ElapsedTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HiringManagerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExperienceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PositionModifiedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifyByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifyDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemarksDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobTableBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSSQLJobTableFormSearchJobBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_SQL_JobTable_FormSearchJob = New InnerHeads.DS_SQL_JobTable_FormSearchJob()
        Me.JobTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SearchByPositionLevel = New System.Windows.Forms.ComboBox()
        Me.RadioButtonPositionLevel = New System.Windows.Forms.RadioButton()
        Me.SearchByJobPosition = New System.Windows.Forms.ComboBox()
        Me.RadioButtonJobPosition = New System.Windows.Forms.RadioButton()
        Me.SearchByCompany = New System.Windows.Forms.ComboBox()
        Me.RadioButtonCompany = New System.Windows.Forms.RadioButton()
        Me.SearchByCategory = New System.Windows.Forms.ComboBox()
        Me.RadioButtonCategory = New System.Windows.Forms.RadioButton()
        Me.SearchByJobID = New System.Windows.Forms.ComboBox()
        Me.SearchByRecruiter = New System.Windows.Forms.ComboBox()
        Me.RadioButtonRecruiter = New System.Windows.Forms.RadioButton()
        Me.RadioButtonJobID = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Search = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.RowsCount = New System.Windows.Forms.Label()
        Me.ButtonShowAll = New System.Windows.Forms.Button()
        Me.ButtonFilterOpen = New System.Windows.Forms.Button()
        Me.ButtonFilterOffered = New System.Windows.Forms.Button()
        Me.ButtonFilterJoined = New System.Windows.Forms.Button()
        Me.ButtonFilterCancelled = New System.Windows.Forms.Button()
        Me.ButtonFilterOnHold = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ButtonToJoin = New System.Windows.Forms.Button()
        Me.JobTableTableAdapter1 = New InnerHeads.DS_SQL_JobTable_FormSearchJobTableAdapters.JobTableTableAdapter()
        Me.Label_selectedrows = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.Btn_search = New System.Windows.Forms.Button()
        Me.Btn_ExportToExcel = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Btn_ExportSelection = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JobTableBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSSQLJobTableFormSearchJobBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_SQL_JobTable_FormSearchJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JobTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RecruiterDataGridViewTextBoxColumn, Me.JobIDDataGridViewTextBoxColumn, Me.OpenDateDataGridViewTextBoxColumn, Me.JobPositionDataGridViewTextBoxColumn, Me.Company1DataGridViewTextBoxColumn, Me.PositionLevelDataGridViewTextBoxColumn, Me.JobStatusDataGridViewTextBoxColumn, Me.ApplicationIDDataGridViewTextBoxColumn, Me.CandidateNameDataGridViewTextBoxColumn, Me.JoiningDateDataGridViewTextBoxColumn, Me.Company2DataGridViewTextBoxColumn, Me.JobLocationDataGridViewTextBoxColumn, Me.CategoryDataGridViewTextBoxColumn, Me.TargetDateDataGridViewTextBoxColumn, Me.TotalApplicationDataGridViewTextBoxColumn, Me.ResumeSourceDataGridViewTextBoxColumn, Me.ElapsedTimeDataGridViewTextBoxColumn, Me.JobTypeDataGridViewTextBoxColumn, Me.HiringManagerDataGridViewTextBoxColumn, Me.ExperienceDataGridViewTextBoxColumn, Me.JobDescriptionDataGridViewTextBoxColumn, Me.PositionModifiedDataGridViewTextBoxColumn, Me.ModifyByDataGridViewTextBoxColumn, Me.ModifyDateDataGridViewTextBoxColumn, Me.RemarksDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.JobTableBindingSource1
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(12, 209)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1170, 394)
        Me.DataGridView1.TabIndex = 1
        '
        'RecruiterDataGridViewTextBoxColumn
        '
        Me.RecruiterDataGridViewTextBoxColumn.DataPropertyName = "Recruiter"
        Me.RecruiterDataGridViewTextBoxColumn.HeaderText = "Recruiter"
        Me.RecruiterDataGridViewTextBoxColumn.Name = "RecruiterDataGridViewTextBoxColumn"
        Me.RecruiterDataGridViewTextBoxColumn.ReadOnly = True
        '
        'JobIDDataGridViewTextBoxColumn
        '
        Me.JobIDDataGridViewTextBoxColumn.DataPropertyName = "Job_ID"
        Me.JobIDDataGridViewTextBoxColumn.HeaderText = "Job_ID"
        Me.JobIDDataGridViewTextBoxColumn.Name = "JobIDDataGridViewTextBoxColumn"
        Me.JobIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.JobIDDataGridViewTextBoxColumn.Width = 60
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
        'JobPositionDataGridViewTextBoxColumn
        '
        Me.JobPositionDataGridViewTextBoxColumn.DataPropertyName = "Job_Position"
        Me.JobPositionDataGridViewTextBoxColumn.HeaderText = "Job_Position"
        Me.JobPositionDataGridViewTextBoxColumn.Name = "JobPositionDataGridViewTextBoxColumn"
        Me.JobPositionDataGridViewTextBoxColumn.ReadOnly = True
        Me.JobPositionDataGridViewTextBoxColumn.Width = 130
        '
        'Company1DataGridViewTextBoxColumn
        '
        Me.Company1DataGridViewTextBoxColumn.DataPropertyName = "Company1"
        Me.Company1DataGridViewTextBoxColumn.HeaderText = "Company1"
        Me.Company1DataGridViewTextBoxColumn.Name = "Company1DataGridViewTextBoxColumn"
        Me.Company1DataGridViewTextBoxColumn.ReadOnly = True
        Me.Company1DataGridViewTextBoxColumn.Width = 80
        '
        'PositionLevelDataGridViewTextBoxColumn
        '
        Me.PositionLevelDataGridViewTextBoxColumn.DataPropertyName = "Position_Level"
        Me.PositionLevelDataGridViewTextBoxColumn.HeaderText = "Position_Level"
        Me.PositionLevelDataGridViewTextBoxColumn.Name = "PositionLevelDataGridViewTextBoxColumn"
        Me.PositionLevelDataGridViewTextBoxColumn.ReadOnly = True
        '
        'JobStatusDataGridViewTextBoxColumn
        '
        Me.JobStatusDataGridViewTextBoxColumn.DataPropertyName = "Job_Status"
        Me.JobStatusDataGridViewTextBoxColumn.HeaderText = "Job_Status"
        Me.JobStatusDataGridViewTextBoxColumn.Name = "JobStatusDataGridViewTextBoxColumn"
        Me.JobStatusDataGridViewTextBoxColumn.ReadOnly = True
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
        DataGridViewCellStyle2.Format = "dd-MMM-yyyy"
        Me.JoiningDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.JoiningDateDataGridViewTextBoxColumn.HeaderText = "Joining_Date"
        Me.JoiningDateDataGridViewTextBoxColumn.Name = "JoiningDateDataGridViewTextBoxColumn"
        Me.JoiningDateDataGridViewTextBoxColumn.ReadOnly = True
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
        'CategoryDataGridViewTextBoxColumn
        '
        Me.CategoryDataGridViewTextBoxColumn.DataPropertyName = "Category"
        Me.CategoryDataGridViewTextBoxColumn.HeaderText = "Category"
        Me.CategoryDataGridViewTextBoxColumn.Name = "CategoryDataGridViewTextBoxColumn"
        Me.CategoryDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TargetDateDataGridViewTextBoxColumn
        '
        Me.TargetDateDataGridViewTextBoxColumn.DataPropertyName = "Target_Date"
        DataGridViewCellStyle3.Format = "dd-MMM-yyyy"
        Me.TargetDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.TargetDateDataGridViewTextBoxColumn.HeaderText = "Target_Date"
        Me.TargetDateDataGridViewTextBoxColumn.Name = "TargetDateDataGridViewTextBoxColumn"
        Me.TargetDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TotalApplicationDataGridViewTextBoxColumn
        '
        Me.TotalApplicationDataGridViewTextBoxColumn.DataPropertyName = "Total_Application"
        Me.TotalApplicationDataGridViewTextBoxColumn.HeaderText = "Total_Application"
        Me.TotalApplicationDataGridViewTextBoxColumn.Name = "TotalApplicationDataGridViewTextBoxColumn"
        Me.TotalApplicationDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ResumeSourceDataGridViewTextBoxColumn
        '
        Me.ResumeSourceDataGridViewTextBoxColumn.DataPropertyName = "Resume_Source"
        Me.ResumeSourceDataGridViewTextBoxColumn.HeaderText = "Resume_Source"
        Me.ResumeSourceDataGridViewTextBoxColumn.Name = "ResumeSourceDataGridViewTextBoxColumn"
        Me.ResumeSourceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ElapsedTimeDataGridViewTextBoxColumn
        '
        Me.ElapsedTimeDataGridViewTextBoxColumn.DataPropertyName = "Elapsed_Time"
        Me.ElapsedTimeDataGridViewTextBoxColumn.HeaderText = "Elapsed_Time"
        Me.ElapsedTimeDataGridViewTextBoxColumn.Name = "ElapsedTimeDataGridViewTextBoxColumn"
        Me.ElapsedTimeDataGridViewTextBoxColumn.ReadOnly = True
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
        'JobTableBindingSource1
        '
        Me.JobTableBindingSource1.DataMember = "JobTable"
        Me.JobTableBindingSource1.DataSource = Me.DSSQLJobTableFormSearchJobBindingSource
        '
        'DSSQLJobTableFormSearchJobBindingSource
        '
        Me.DSSQLJobTableFormSearchJobBindingSource.DataSource = Me.DS_SQL_JobTable_FormSearchJob
        Me.DSSQLJobTableFormSearchJobBindingSource.Position = 0
        '
        'DS_SQL_JobTable_FormSearchJob
        '
        Me.DS_SQL_JobTable_FormSearchJob.DataSetName = "DS_SQL_JobTable_FormSearchJob"
        Me.DS_SQL_JobTable_FormSearchJob.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'JobTableBindingSource
        '
        Me.JobTableBindingSource.DataMember = "JobTable"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SearchByPositionLevel)
        Me.GroupBox1.Controls.Add(Me.RadioButtonPositionLevel)
        Me.GroupBox1.Controls.Add(Me.SearchByJobPosition)
        Me.GroupBox1.Controls.Add(Me.RadioButtonJobPosition)
        Me.GroupBox1.Controls.Add(Me.SearchByCompany)
        Me.GroupBox1.Controls.Add(Me.RadioButtonCompany)
        Me.GroupBox1.Controls.Add(Me.SearchByCategory)
        Me.GroupBox1.Controls.Add(Me.RadioButtonCategory)
        Me.GroupBox1.Controls.Add(Me.SearchByJobID)
        Me.GroupBox1.Controls.Add(Me.SearchByRecruiter)
        Me.GroupBox1.Controls.Add(Me.RadioButtonRecruiter)
        Me.GroupBox1.Controls.Add(Me.RadioButtonJobID)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1169, 71)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search By"
        '
        'SearchByPositionLevel
        '
        Me.SearchByPositionLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.SearchByPositionLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SearchByPositionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SearchByPositionLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SearchByPositionLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchByPositionLevel.FormattingEnabled = True
        Me.SearchByPositionLevel.Items.AddRange(New Object() {"Entry", "Mid", "Head/CXO"})
        Me.SearchByPositionLevel.Location = New System.Drawing.Point(962, 41)
        Me.SearchByPositionLevel.Name = "SearchByPositionLevel"
        Me.SearchByPositionLevel.Size = New System.Drawing.Size(121, 24)
        Me.SearchByPositionLevel.TabIndex = 13
        '
        'RadioButtonPositionLevel
        '
        Me.RadioButtonPositionLevel.AutoSize = True
        Me.RadioButtonPositionLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonPositionLevel.Location = New System.Drawing.Point(962, 19)
        Me.RadioButtonPositionLevel.Name = "RadioButtonPositionLevel"
        Me.RadioButtonPositionLevel.Size = New System.Drawing.Size(110, 20)
        Me.RadioButtonPositionLevel.TabIndex = 12
        Me.RadioButtonPositionLevel.TabStop = True
        Me.RadioButtonPositionLevel.Text = "Position Level"
        Me.RadioButtonPositionLevel.UseVisualStyleBackColor = True
        '
        'SearchByJobPosition
        '
        Me.SearchByJobPosition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.SearchByJobPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SearchByJobPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SearchByJobPosition.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SearchByJobPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchByJobPosition.FormattingEnabled = True
        Me.SearchByJobPosition.Location = New System.Drawing.Point(712, 41)
        Me.SearchByJobPosition.Name = "SearchByJobPosition"
        Me.SearchByJobPosition.Size = New System.Drawing.Size(231, 24)
        Me.SearchByJobPosition.TabIndex = 11
        '
        'RadioButtonJobPosition
        '
        Me.RadioButtonJobPosition.AutoSize = True
        Me.RadioButtonJobPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonJobPosition.Location = New System.Drawing.Point(714, 18)
        Me.RadioButtonJobPosition.Name = "RadioButtonJobPosition"
        Me.RadioButtonJobPosition.Size = New System.Drawing.Size(100, 20)
        Me.RadioButtonJobPosition.TabIndex = 10
        Me.RadioButtonJobPosition.TabStop = True
        Me.RadioButtonJobPosition.Text = "Job Position"
        Me.RadioButtonJobPosition.UseVisualStyleBackColor = True
        '
        'SearchByCompany
        '
        Me.SearchByCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.SearchByCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SearchByCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SearchByCompany.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SearchByCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchByCompany.FormattingEnabled = True
        Me.SearchByCompany.Location = New System.Drawing.Point(557, 41)
        Me.SearchByCompany.Name = "SearchByCompany"
        Me.SearchByCompany.Size = New System.Drawing.Size(136, 24)
        Me.SearchByCompany.TabIndex = 9
        '
        'RadioButtonCompany
        '
        Me.RadioButtonCompany.AutoSize = True
        Me.RadioButtonCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonCompany.Location = New System.Drawing.Point(558, 18)
        Me.RadioButtonCompany.Name = "RadioButtonCompany"
        Me.RadioButtonCompany.Size = New System.Drawing.Size(84, 20)
        Me.RadioButtonCompany.TabIndex = 8
        Me.RadioButtonCompany.TabStop = True
        Me.RadioButtonCompany.Text = "Company"
        Me.RadioButtonCompany.UseVisualStyleBackColor = True
        '
        'SearchByCategory
        '
        Me.SearchByCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.SearchByCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SearchByCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SearchByCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SearchByCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchByCategory.FormattingEnabled = True
        Me.SearchByCategory.Location = New System.Drawing.Point(402, 41)
        Me.SearchByCategory.Name = "SearchByCategory"
        Me.SearchByCategory.Size = New System.Drawing.Size(136, 24)
        Me.SearchByCategory.TabIndex = 7
        '
        'RadioButtonCategory
        '
        Me.RadioButtonCategory.AutoSize = True
        Me.RadioButtonCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonCategory.Location = New System.Drawing.Point(402, 18)
        Me.RadioButtonCategory.Name = "RadioButtonCategory"
        Me.RadioButtonCategory.Size = New System.Drawing.Size(81, 20)
        Me.RadioButtonCategory.TabIndex = 6
        Me.RadioButtonCategory.TabStop = True
        Me.RadioButtonCategory.Text = "Category"
        Me.RadioButtonCategory.UseVisualStyleBackColor = True
        '
        'SearchByJobID
        '
        Me.SearchByJobID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.SearchByJobID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SearchByJobID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SearchByJobID.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SearchByJobID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchByJobID.FormattingEnabled = True
        Me.SearchByJobID.Location = New System.Drawing.Point(59, 42)
        Me.SearchByJobID.Name = "SearchByJobID"
        Me.SearchByJobID.Size = New System.Drawing.Size(134, 24)
        Me.SearchByJobID.TabIndex = 3
        '
        'SearchByRecruiter
        '
        Me.SearchByRecruiter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.SearchByRecruiter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SearchByRecruiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SearchByRecruiter.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SearchByRecruiter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchByRecruiter.FormattingEnabled = True
        Me.SearchByRecruiter.Location = New System.Drawing.Point(212, 42)
        Me.SearchByRecruiter.Name = "SearchByRecruiter"
        Me.SearchByRecruiter.Size = New System.Drawing.Size(171, 24)
        Me.SearchByRecruiter.TabIndex = 2
        '
        'RadioButtonRecruiter
        '
        Me.RadioButtonRecruiter.AutoSize = True
        Me.RadioButtonRecruiter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonRecruiter.Location = New System.Drawing.Point(212, 19)
        Me.RadioButtonRecruiter.Name = "RadioButtonRecruiter"
        Me.RadioButtonRecruiter.Size = New System.Drawing.Size(80, 20)
        Me.RadioButtonRecruiter.TabIndex = 1
        Me.RadioButtonRecruiter.TabStop = True
        Me.RadioButtonRecruiter.Text = "Recruiter"
        Me.RadioButtonRecruiter.UseVisualStyleBackColor = True
        '
        'RadioButtonJobID
        '
        Me.RadioButtonJobID.AutoSize = True
        Me.RadioButtonJobID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonJobID.Location = New System.Drawing.Point(59, 19)
        Me.RadioButtonJobID.Name = "RadioButtonJobID"
        Me.RadioButtonJobID.Size = New System.Drawing.Size(65, 20)
        Me.RadioButtonJobID.TabIndex = 0
        Me.RadioButtonJobID.TabStop = True
        Me.RadioButtonJobID.Text = "Job ID"
        Me.RadioButtonJobID.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(10, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 22)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Count :"
        '
        'txt_Search
        '
        Me.txt_Search.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txt_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Search.Location = New System.Drawing.Point(71, 21)
        Me.txt_Search.Name = "txt_Search"
        Me.txt_Search.Size = New System.Drawing.Size(253, 24)
        Me.txt_Search.TabIndex = 14
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(6, 24)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(63, 17)
        Me.Label36.TabIndex = 13
        Me.Label36.Text = "Search :"
        '
        'RowsCount
        '
        Me.RowsCount.AutoSize = True
        Me.RowsCount.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RowsCount.ForeColor = System.Drawing.Color.Green
        Me.RowsCount.Location = New System.Drawing.Point(90, 16)
        Me.RowsCount.Name = "RowsCount"
        Me.RowsCount.Size = New System.Drawing.Size(21, 22)
        Me.RowsCount.TabIndex = 8
        Me.RowsCount.Text = "0"
        '
        'ButtonShowAll
        '
        Me.ButtonShowAll.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.ButtonShowAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.ButtonShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonShowAll.Location = New System.Drawing.Point(6, 19)
        Me.ButtonShowAll.Name = "ButtonShowAll"
        Me.ButtonShowAll.Size = New System.Drawing.Size(113, 23)
        Me.ButtonShowAll.TabIndex = 12
        Me.ButtonShowAll.Text = "Show &All Records"
        Me.ButtonShowAll.UseVisualStyleBackColor = True
        '
        'ButtonFilterOpen
        '
        Me.ButtonFilterOpen.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.ButtonFilterOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua
        Me.ButtonFilterOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.ButtonFilterOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFilterOpen.Location = New System.Drawing.Point(125, 19)
        Me.ButtonFilterOpen.Name = "ButtonFilterOpen"
        Me.ButtonFilterOpen.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFilterOpen.TabIndex = 15
        Me.ButtonFilterOpen.Text = "OPEN"
        Me.ButtonFilterOpen.UseVisualStyleBackColor = True
        '
        'ButtonFilterOffered
        '
        Me.ButtonFilterOffered.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.ButtonFilterOffered.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.ButtonFilterOffered.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFilterOffered.Location = New System.Drawing.Point(206, 19)
        Me.ButtonFilterOffered.Name = "ButtonFilterOffered"
        Me.ButtonFilterOffered.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFilterOffered.TabIndex = 16
        Me.ButtonFilterOffered.Text = "OFFERED"
        Me.ButtonFilterOffered.UseVisualStyleBackColor = True
        '
        'ButtonFilterJoined
        '
        Me.ButtonFilterJoined.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.ButtonFilterJoined.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.ButtonFilterJoined.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFilterJoined.Location = New System.Drawing.Point(287, 19)
        Me.ButtonFilterJoined.Name = "ButtonFilterJoined"
        Me.ButtonFilterJoined.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFilterJoined.TabIndex = 17
        Me.ButtonFilterJoined.Text = "JOINED"
        Me.ButtonFilterJoined.UseVisualStyleBackColor = True
        '
        'ButtonFilterCancelled
        '
        Me.ButtonFilterCancelled.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.ButtonFilterCancelled.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.ButtonFilterCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFilterCancelled.Location = New System.Drawing.Point(449, 19)
        Me.ButtonFilterCancelled.Name = "ButtonFilterCancelled"
        Me.ButtonFilterCancelled.Size = New System.Drawing.Size(83, 23)
        Me.ButtonFilterCancelled.TabIndex = 18
        Me.ButtonFilterCancelled.Text = "CANCELLED"
        Me.ButtonFilterCancelled.UseVisualStyleBackColor = True
        '
        'ButtonFilterOnHold
        '
        Me.ButtonFilterOnHold.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.ButtonFilterOnHold.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.ButtonFilterOnHold.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFilterOnHold.Location = New System.Drawing.Point(538, 19)
        Me.ButtonFilterOnHold.Name = "ButtonFilterOnHold"
        Me.ButtonFilterOnHold.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFilterOnHold.TabIndex = 19
        Me.ButtonFilterOnHold.Text = "ON-HOLD"
        Me.ButtonFilterOnHold.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(796, 175)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(124, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 31
        Me.ProgressBar1.Tag = ""
        Me.ProgressBar1.Visible = False
        '
        'ButtonToJoin
        '
        Me.ButtonToJoin.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.ButtonToJoin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.ButtonToJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonToJoin.Location = New System.Drawing.Point(368, 19)
        Me.ButtonToJoin.Name = "ButtonToJoin"
        Me.ButtonToJoin.Size = New System.Drawing.Size(75, 23)
        Me.ButtonToJoin.TabIndex = 32
        Me.ButtonToJoin.Text = "TO JOIN"
        Me.ButtonToJoin.UseVisualStyleBackColor = True
        '
        'JobTableTableAdapter1
        '
        Me.JobTableTableAdapter1.ClearBeforeFill = True
        '
        'Label_selectedrows
        '
        Me.Label_selectedrows.AutoSize = True
        Me.Label_selectedrows.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_selectedrows.ForeColor = System.Drawing.Color.Blue
        Me.Label_selectedrows.Location = New System.Drawing.Point(996, 613)
        Me.Label_selectedrows.Name = "Label_selectedrows"
        Me.Label_selectedrows.Size = New System.Drawing.Size(122, 18)
        Me.Label_selectedrows.TabIndex = 33
        Me.Label_selectedrows.Text = "Selected Rows :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonShowAll)
        Me.GroupBox2.Controls.Add(Me.ButtonFilterOpen)
        Me.GroupBox2.Controls.Add(Me.ButtonToJoin)
        Me.GroupBox2.Controls.Add(Me.ButtonFilterOffered)
        Me.GroupBox2.Controls.Add(Me.ButtonFilterJoined)
        Me.GroupBox2.Controls.Add(Me.ButtonFilterCancelled)
        Me.GroupBox2.Controls.Add(Me.ButtonFilterOnHold)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 156)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(620, 47)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filter"
        '
        'ButtonClose
        '
        Me.ButtonClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ButtonClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClose.ForeColor = System.Drawing.Color.Black
        Me.ButtonClose.Image = Global.InnerHeads.My.Resources.Resources.close
        Me.ButtonClose.Location = New System.Drawing.Point(15, 604)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(39, 37)
        Me.ButtonClose.TabIndex = 45
        Me.ButtonClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClose.UseVisualStyleBackColor = False
        '
        'Btn_search
        '
        Me.Btn_search.BackgroundImage = Global.InnerHeads.My.Resources.Resources.search_icon
        Me.Btn_search.FlatAppearance.BorderSize = 0
        Me.Btn_search.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Btn_search.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_search.Location = New System.Drawing.Point(311, 15)
        Me.Btn_search.Name = "Btn_search"
        Me.Btn_search.Size = New System.Drawing.Size(52, 38)
        Me.Btn_search.TabIndex = 44
        Me.Btn_search.UseVisualStyleBackColor = True
        '
        'Btn_ExportToExcel
        '
        Me.Btn_ExportToExcel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Btn_ExportToExcel.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.Btn_ExportToExcel.FlatAppearance.BorderSize = 0
        Me.Btn_ExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_ExportToExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ExportToExcel.Image = Global.InnerHeads.My.Resources.Resources.ExportToXL
        Me.Btn_ExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_ExportToExcel.Location = New System.Drawing.Point(642, 167)
        Me.Btn_ExportToExcel.Name = "Btn_ExportToExcel"
        Me.Btn_ExportToExcel.Size = New System.Drawing.Size(151, 36)
        Me.Btn_ExportToExcel.TabIndex = 14
        Me.Btn_ExportToExcel.Text = "Export To Excel"
        Me.Btn_ExportToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_ExportToExcel.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_Search)
        Me.GroupBox3.Controls.Add(Me.Label36)
        Me.GroupBox3.Controls.Add(Me.Btn_search)
        Me.GroupBox3.Location = New System.Drawing.Point(807, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(375, 59)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.RowsCount)
        Me.GroupBox4.Location = New System.Drawing.Point(1001, 158)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(181, 45)
        Me.GroupBox4.TabIndex = 47
        Me.GroupBox4.TabStop = False
        '
        'Btn_ExportSelection
        '
        Me.Btn_ExportSelection.FlatAppearance.BorderSize = 0
        Me.Btn_ExportSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_ExportSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ExportSelection.Image = Global.InnerHeads.My.Resources.Resources.ExportToXL
        Me.Btn_ExportSelection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_ExportSelection.Location = New System.Drawing.Point(836, 608)
        Me.Btn_ExportSelection.Name = "Btn_ExportSelection"
        Me.Btn_ExportSelection.Size = New System.Drawing.Size(154, 28)
        Me.Btn_ExportSelection.TabIndex = 48
        Me.Btn_ExportSelection.Text = "Export Selection"
        Me.Btn_ExportSelection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_ExportSelection.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.Location = New System.Drawing.Point(428, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(344, 31)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "JOB POSITIONS DETAILS"
        '
        'FormSearchJob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1200, 642)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Btn_ExportSelection)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label_selectedrows)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Btn_ExportToExcel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(100, 50)
        Me.Name = "FormSearchJob"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FormSearchJob"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JobTableBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSSQLJobTableFormSearchJobBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_SQL_JobTable_FormSearchJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JobTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    'Friend WithEvents DSJobTable As InnerHeads.DSJobTable
    Friend WithEvents JobTableBindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents JobTableTableAdapter As InnerHeads.DSJobTableTableAdapters.JobTableTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonJobID As System.Windows.Forms.RadioButton
    Friend WithEvents SearchByJobID As System.Windows.Forms.ComboBox
    Friend WithEvents SearchByRecruiter As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButtonRecruiter As System.Windows.Forms.RadioButton
    Friend WithEvents SearchByCompany As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButtonCompany As System.Windows.Forms.RadioButton
    Friend WithEvents SearchByCategory As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButtonCategory As System.Windows.Forms.RadioButton
    Friend WithEvents SearchByJobPosition As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButtonJobPosition As System.Windows.Forms.RadioButton
    Friend WithEvents SearchByPositionLevel As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButtonPositionLevel As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RowsCount As System.Windows.Forms.Label
    Friend WithEvents ButtonShowAll As System.Windows.Forms.Button
    Friend WithEvents Btn_ExportToExcel As Button
    Friend WithEvents txt_Search As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents ButtonFilterOpen As Button
    Friend WithEvents ButtonFilterOffered As Button
    Friend WithEvents ButtonFilterJoined As Button
    Friend WithEvents ButtonFilterCancelled As Button
    Friend WithEvents ButtonFilterOnHold As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ButtonToJoin As Button
    Friend WithEvents DS_SQL_JobTable_FormSearchJob As DS_SQL_JobTable_FormSearchJob
    Friend WithEvents DSSQLJobTableFormSearchJobBindingSource As BindingSource
    Friend WithEvents JobTableBindingSource1 As BindingSource
    Friend WithEvents JobTableTableAdapter1 As DS_SQL_JobTable_FormSearchJobTableAdapters.JobTableTableAdapter
    Friend WithEvents Label_selectedrows As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Btn_search As Button
    Friend WithEvents ButtonClose As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Btn_ExportSelection As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents RecruiterDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OpenDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobPositionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Company1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PositionLevelDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobStatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ApplicationIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CandidateNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JoiningDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Company2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobLocationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CategoryDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TargetDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalApplicationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ResumeSourceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ElapsedTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HiringManagerDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExperienceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobDescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PositionModifiedDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModifyByDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModifyDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RemarksDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
