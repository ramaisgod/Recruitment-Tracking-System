<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCandidate
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCandidate))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_search = New System.Windows.Forms.Button()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.JobIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobPositionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Company1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecruiterDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PositionLevelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApplicationIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CandidateNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JoiningDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HiringManagerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Company2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobLocationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExperienceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalApplicationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ElapsedTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PositionModifiedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifyByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifyDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemarksDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ResumeSourceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobTableBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_SQL_JobTable_FormCandidate = New InnerHeads.DS_SQL_JobTable_FormCandidate()
        Me.Label_jobFound = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txt_jobSearch = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.JobTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.ButtonAddCandidate = New System.Windows.Forms.Button()
        Me.ButtonClearAll = New System.Windows.Forms.Button()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBoxExperience = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBoxLocation = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBoxMobile = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBoxCandidateName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxApplicationID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxResumeSource = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePickerScreeningDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxApplicationStatus = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DateTimePickerOpenDate = New System.Windows.Forms.DateTimePicker()
        Me.TextBoxJobCategory = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ComboBoxRecruiter2 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxJobPosition = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBoxCompanyName = New System.Windows.Forms.TextBox()
        Me.TextBoxJobStatus = New System.Windows.Forms.TextBox()
        Me.ComboBoxJobID = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ButtonDownloadFormat = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ButtonClose_Import = New System.Windows.Forms.Button()
        Me.ButtonAdd_Import = New System.Windows.Forms.Button()
        Me.ButtonClear_Import = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ButtonFileBrowse = New System.Windows.Forms.Button()
        Me.ComboBoxRecruiter2_import = New System.Windows.Forms.ComboBox()
        Me.TextBoxApplicationID_import = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.DateTimePickerScreeningDate_import = New System.Windows.Forms.DateTimePicker()
        Me.ComboBoxResumeSource_import = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBoxApplicationStatus_import = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.JobTableTableAdapter1 = New InnerHeads.DS_SQL_JobTable_FormCandidateTableAdapters.JobTableTableAdapter()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JobTableBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_SQL_JobTable_FormCandidate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JobTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Location = New System.Drawing.Point(766, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(402, 550)
        Me.Panel1.TabIndex = 15
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
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JobIDDataGridViewTextBoxColumn, Me.JobPositionDataGridViewTextBoxColumn, Me.Company1DataGridViewTextBoxColumn, Me.JobStatusDataGridViewTextBoxColumn, Me.RecruiterDataGridViewTextBoxColumn, Me.PositionLevelDataGridViewTextBoxColumn, Me.OpenDateDataGridViewTextBoxColumn, Me.TargetDateDataGridViewTextBoxColumn, Me.ApplicationIDDataGridViewTextBoxColumn, Me.CandidateNameDataGridViewTextBoxColumn, Me.JoiningDateDataGridViewTextBoxColumn, Me.CategoryDataGridViewTextBoxColumn, Me.JobTypeDataGridViewTextBoxColumn, Me.HiringManagerDataGridViewTextBoxColumn, Me.Company2DataGridViewTextBoxColumn, Me.JobLocationDataGridViewTextBoxColumn, Me.ExperienceDataGridViewTextBoxColumn, Me.JobDescriptionDataGridViewTextBoxColumn, Me.TotalApplicationDataGridViewTextBoxColumn, Me.ElapsedTimeDataGridViewTextBoxColumn, Me.PositionModifiedDataGridViewTextBoxColumn, Me.ModifyByDataGridViewTextBoxColumn, Me.ModifyDateDataGridViewTextBoxColumn, Me.RemarksDataGridViewTextBoxColumn, Me.ResumeSourceDataGridViewTextBoxColumn})
        Me.DataGridView3.DataSource = Me.JobTableBindingSource1
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
        Me.JobIDDataGridViewTextBoxColumn.Width = 60
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
        Me.Company1DataGridViewTextBoxColumn.Width = 80
        '
        'JobStatusDataGridViewTextBoxColumn
        '
        Me.JobStatusDataGridViewTextBoxColumn.DataPropertyName = "Job_Status"
        Me.JobStatusDataGridViewTextBoxColumn.HeaderText = "Job_Status"
        Me.JobStatusDataGridViewTextBoxColumn.Name = "JobStatusDataGridViewTextBoxColumn"
        Me.JobStatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.JobStatusDataGridViewTextBoxColumn.Width = 70
        '
        'RecruiterDataGridViewTextBoxColumn
        '
        Me.RecruiterDataGridViewTextBoxColumn.DataPropertyName = "Recruiter"
        Me.RecruiterDataGridViewTextBoxColumn.HeaderText = "Recruiter"
        Me.RecruiterDataGridViewTextBoxColumn.Name = "RecruiterDataGridViewTextBoxColumn"
        Me.RecruiterDataGridViewTextBoxColumn.ReadOnly = True
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
        'TargetDateDataGridViewTextBoxColumn
        '
        Me.TargetDateDataGridViewTextBoxColumn.DataPropertyName = "Target_Date"
        DataGridViewCellStyle2.Format = "dd-MMM-yyyy"
        Me.TargetDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.TargetDateDataGridViewTextBoxColumn.HeaderText = "Target_Date"
        Me.TargetDateDataGridViewTextBoxColumn.Name = "TargetDateDataGridViewTextBoxColumn"
        Me.TargetDateDataGridViewTextBoxColumn.ReadOnly = True
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
        Me.CandidateNameDataGridViewTextBoxColumn.Width = 120
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
        'JobTableBindingSource1
        '
        Me.JobTableBindingSource1.DataMember = "JobTable"
        Me.JobTableBindingSource1.DataSource = Me.DS_SQL_JobTable_FormCandidate
        '
        'DS_SQL_JobTable_FormCandidate
        '
        Me.DS_SQL_JobTable_FormCandidate.DataSetName = "DS_SQL_JobTable_FormCandidate"
        Me.DS_SQL_JobTable_FormCandidate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.Label36.Size = New System.Drawing.Size(146, 17)
        Me.Label36.TabIndex = 4
        Me.Label36.Text = "Search Job Positions"
        '
        'JobTableBindingSource
        '
        Me.JobTableBindingSource.DataMember = "JobTable"
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.ItemSize = New System.Drawing.Size(70, 20)
        Me.TabControl1.Location = New System.Drawing.Point(22, 61)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(736, 494)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(728, 466)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Manual"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ButtonClose)
        Me.GroupBox3.Controls.Add(Me.ButtonAddCandidate)
        Me.GroupBox3.Controls.Add(Me.ButtonClearAll)
        Me.GroupBox3.Controls.Add(Me.ButtonClear)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 337)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(716, 60)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'ButtonClose
        '
        Me.ButtonClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClose.Image = Global.InnerHeads.My.Resources.Resources.close
        Me.ButtonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonClose.Location = New System.Drawing.Point(524, 17)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(97, 35)
        Me.ButtonClose.TabIndex = 20
        Me.ButtonClose.Text = "CL&OSE"
        Me.ButtonClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ButtonAddCandidate
        '
        Me.ButtonAddCandidate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAddCandidate.Image = Global.InnerHeads.My.Resources.Resources.addnew
        Me.ButtonAddCandidate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAddCandidate.Location = New System.Drawing.Point(96, 17)
        Me.ButtonAddCandidate.Name = "ButtonAddCandidate"
        Me.ButtonAddCandidate.Size = New System.Drawing.Size(90, 35)
        Me.ButtonAddCandidate.TabIndex = 17
        Me.ButtonAddCandidate.Text = "&ADD"
        Me.ButtonAddCandidate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAddCandidate.UseVisualStyleBackColor = True
        '
        'ButtonClearAll
        '
        Me.ButtonClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClearAll.Image = CType(resources.GetObject("ButtonClearAll.Image"), System.Drawing.Image)
        Me.ButtonClearAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonClearAll.Location = New System.Drawing.Point(357, 17)
        Me.ButtonClearAll.Name = "ButtonClearAll"
        Me.ButtonClearAll.Size = New System.Drawing.Size(130, 35)
        Me.ButtonClearAll.TabIndex = 19
        Me.ButtonClearAll.Text = "C&LEAR ALL"
        Me.ButtonClearAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClearAll.UseVisualStyleBackColor = True
        '
        'ButtonClear
        '
        Me.ButtonClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClear.Image = CType(resources.GetObject("ButtonClear.Image"), System.Drawing.Image)
        Me.ButtonClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonClear.Location = New System.Drawing.Point(223, 17)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(97, 35)
        Me.ButtonClear.TabIndex = 18
        Me.ButtonClear.Text = "&CLEAR"
        Me.ButtonClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxExperience)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.ComboBoxLocation)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TextBoxMobile)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TextBoxEmail)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TextBoxCandidateName)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TextBoxApplicationID)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ComboBoxResumeSource)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.DateTimePickerScreeningDate)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TextBoxApplicationStatus)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 177)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(716, 142)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "New Candidate Details"
        '
        'TextBoxExperience
        '
        Me.TextBoxExperience.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExperience.Location = New System.Drawing.Point(587, 102)
        Me.TextBoxExperience.Name = "TextBoxExperience"
        Me.TextBoxExperience.Size = New System.Drawing.Size(110, 22)
        Me.TextBoxExperience.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(516, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 16)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Exp. (Yrs) :"
        '
        'ComboBoxLocation
        '
        Me.ComboBoxLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxLocation.FormattingEnabled = True
        Me.ComboBoxLocation.Location = New System.Drawing.Point(338, 100)
        Me.ComboBoxLocation.Name = "ComboBoxLocation"
        Me.ComboBoxLocation.Size = New System.Drawing.Size(167, 24)
        Me.ComboBoxLocation.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(272, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 16)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Location :"
        '
        'TextBoxMobile
        '
        Me.TextBoxMobile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxMobile.Location = New System.Drawing.Point(114, 100)
        Me.TextBoxMobile.Name = "TextBoxMobile"
        Me.TextBoxMobile.Size = New System.Drawing.Size(145, 22)
        Me.TextBoxMobile.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(17, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 16)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Mobile :"
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxEmail.Location = New System.Drawing.Point(412, 68)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(285, 22)
        Me.TextBoxEmail.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(358, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 16)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "E-mail :"
        '
        'TextBoxCandidateName
        '
        Me.TextBoxCandidateName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCandidateName.Location = New System.Drawing.Point(114, 68)
        Me.TextBoxCandidateName.Name = "TextBoxCandidateName"
        Me.TextBoxCandidateName.Size = New System.Drawing.Size(231, 22)
        Me.TextBoxCandidateName.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 16)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Name :"
        '
        'TextBoxApplicationID
        '
        Me.TextBoxApplicationID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxApplicationID.Location = New System.Drawing.Point(114, 33)
        Me.TextBoxApplicationID.Name = "TextBoxApplicationID"
        Me.TextBoxApplicationID.ReadOnly = True
        Me.TextBoxApplicationID.Size = New System.Drawing.Size(84, 22)
        Me.TextBoxApplicationID.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 16)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Application ID :"
        '
        'ComboBoxResumeSource
        '
        Me.ComboBoxResumeSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxResumeSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxResumeSource.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxResumeSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxResumeSource.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBoxResumeSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxResumeSource.FormattingEnabled = True
        Me.ComboBoxResumeSource.Location = New System.Drawing.Point(565, 32)
        Me.ComboBoxResumeSource.Name = "ComboBoxResumeSource"
        Me.ComboBoxResumeSource.Size = New System.Drawing.Size(132, 24)
        Me.ComboBoxResumeSource.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(508, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Source :"
        '
        'DateTimePickerScreeningDate
        '
        Me.DateTimePickerScreeningDate.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerScreeningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerScreeningDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerScreeningDate.Location = New System.Drawing.Point(382, 33)
        Me.DateTimePickerScreeningDate.Name = "DateTimePickerScreeningDate"
        Me.DateTimePickerScreeningDate.Size = New System.Drawing.Size(123, 22)
        Me.DateTimePickerScreeningDate.TabIndex = 10
        Me.DateTimePickerScreeningDate.Value = New Date(2017, 9, 30, 9, 32, 42, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(340, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Date :"
        '
        'TextBoxApplicationStatus
        '
        Me.TextBoxApplicationStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxApplicationStatus.Location = New System.Drawing.Point(251, 33)
        Me.TextBoxApplicationStatus.Name = "TextBoxApplicationStatus"
        Me.TextBoxApplicationStatus.ReadOnly = True
        Me.TextBoxApplicationStatus.Size = New System.Drawing.Size(86, 22)
        Me.TextBoxApplicationStatus.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(200, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Status :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DateTimePickerOpenDate)
        Me.GroupBox1.Controls.Add(Me.TextBoxJobCategory)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.ComboBoxRecruiter2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TextBoxJobPosition)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.TextBoxCompanyName)
        Me.GroupBox1.Controls.Add(Me.TextBoxJobStatus)
        Me.GroupBox1.Controls.Add(Me.ComboBoxJobID)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(716, 133)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Job Details"
        '
        'DateTimePickerOpenDate
        '
        Me.DateTimePickerOpenDate.Enabled = False
        Me.DateTimePickerOpenDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerOpenDate.Location = New System.Drawing.Point(97, 65)
        Me.DateTimePickerOpenDate.Name = "DateTimePickerOpenDate"
        Me.DateTimePickerOpenDate.Size = New System.Drawing.Size(274, 22)
        Me.DateTimePickerOpenDate.TabIndex = 4
        '
        'TextBoxJobCategory
        '
        Me.TextBoxJobCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxJobCategory.Location = New System.Drawing.Point(490, 103)
        Me.TextBoxJobCategory.Name = "TextBoxJobCategory"
        Me.TextBoxJobCategory.ReadOnly = True
        Me.TextBoxJobCategory.Size = New System.Drawing.Size(212, 22)
        Me.TextBoxJobCategory.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(379, 105)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 16)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Category :"
        '
        'ComboBoxRecruiter2
        '
        Me.ComboBoxRecruiter2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxRecruiter2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxRecruiter2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ComboBoxRecruiter2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRecruiter2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxRecruiter2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxRecruiter2.FormattingEnabled = True
        Me.ComboBoxRecruiter2.Location = New System.Drawing.Point(97, 102)
        Me.ComboBoxRecruiter2.Name = "ComboBoxRecruiter2"
        Me.ComboBoxRecruiter2.Size = New System.Drawing.Size(274, 24)
        Me.ComboBoxRecruiter2.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 16)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Open Date :"
        '
        'TextBoxJobPosition
        '
        Me.TextBoxJobPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxJobPosition.Location = New System.Drawing.Point(490, 27)
        Me.TextBoxJobPosition.Name = "TextBoxJobPosition"
        Me.TextBoxJobPosition.ReadOnly = True
        Me.TextBoxJobPosition.Size = New System.Drawing.Size(212, 22)
        Me.TextBoxJobPosition.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(17, 105)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 16)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Recruiter :"
        '
        'TextBoxCompanyName
        '
        Me.TextBoxCompanyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCompanyName.Location = New System.Drawing.Point(490, 65)
        Me.TextBoxCompanyName.Name = "TextBoxCompanyName"
        Me.TextBoxCompanyName.ReadOnly = True
        Me.TextBoxCompanyName.Size = New System.Drawing.Size(212, 22)
        Me.TextBoxCompanyName.TabIndex = 5
        '
        'TextBoxJobStatus
        '
        Me.TextBoxJobStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxJobStatus.Location = New System.Drawing.Point(266, 27)
        Me.TextBoxJobStatus.Name = "TextBoxJobStatus"
        Me.TextBoxJobStatus.ReadOnly = True
        Me.TextBoxJobStatus.Size = New System.Drawing.Size(105, 22)
        Me.TextBoxJobStatus.TabIndex = 2
        '
        'ComboBoxJobID
        '
        Me.ComboBoxJobID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxJobID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJobID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxJobID.FormattingEnabled = True
        Me.ComboBoxJobID.Location = New System.Drawing.Point(97, 26)
        Me.ComboBoxJobID.Name = "ComboBoxJobID"
        Me.ComboBoxJobID.Size = New System.Drawing.Size(89, 24)
        Me.ComboBoxJobID.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(189, 29)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 16)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Job Status :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(379, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Company Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(379, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Job Position :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Job ID :"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage2.Controls.Add(Me.ButtonDownloadFormat)
        Me.TabPage2.Controls.Add(Me.ProgressBar1)
        Me.TabPage2.Controls.Add(Me.txtFilePath)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.ButtonFileBrowse)
        Me.TabPage2.Controls.Add(Me.ComboBoxRecruiter2_import)
        Me.TabPage2.Controls.Add(Me.TextBoxApplicationID_import)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.Label28)
        Me.TabPage2.Controls.Add(Me.DateTimePickerScreeningDate_import)
        Me.TabPage2.Controls.Add(Me.ComboBoxResumeSource_import)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.TextBoxApplicationStatus_import)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(728, 466)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Import"
        '
        'ButtonDownloadFormat
        '
        Me.ButtonDownloadFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDownloadFormat.Image = Global.InnerHeads.My.Resources.Resources.download
        Me.ButtonDownloadFormat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonDownloadFormat.Location = New System.Drawing.Point(552, 198)
        Me.ButtonDownloadFormat.Name = "ButtonDownloadFormat"
        Me.ButtonDownloadFormat.Size = New System.Drawing.Size(156, 36)
        Me.ButtonDownloadFormat.TabIndex = 11
        Me.ButtonDownloadFormat.Text = "Download Format"
        Me.ButtonDownloadFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonDownloadFormat.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 254)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(716, 29)
        Me.ProgressBar1.TabIndex = 21
        '
        'txtFilePath
        '
        Me.txtFilePath.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilePath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFilePath.Location = New System.Drawing.Point(192, 155)
        Me.txtFilePath.Multiline = True
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.ReadOnly = True
        Me.txtFilePath.Size = New System.Drawing.Size(516, 36)
        Me.txtFilePath.TabIndex = 10
        Me.txtFilePath.Text = "Not Selected"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ButtonClose_Import)
        Me.GroupBox4.Controls.Add(Me.ButtonAdd_Import)
        Me.GroupBox4.Controls.Add(Me.ButtonClear_Import)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 283)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(716, 60)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        '
        'ButtonClose_Import
        '
        Me.ButtonClose_Import.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClose_Import.Image = Global.InnerHeads.My.Resources.Resources.close
        Me.ButtonClose_Import.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonClose_Import.Location = New System.Drawing.Point(446, 17)
        Me.ButtonClose_Import.Name = "ButtonClose_Import"
        Me.ButtonClose_Import.Size = New System.Drawing.Size(99, 35)
        Me.ButtonClose_Import.TabIndex = 9
        Me.ButtonClose_Import.Text = "CL&OSE"
        Me.ButtonClose_Import.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClose_Import.UseVisualStyleBackColor = True
        '
        'ButtonAdd_Import
        '
        Me.ButtonAdd_Import.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdd_Import.Image = Global.InnerHeads.My.Resources.Resources.import
        Me.ButtonAdd_Import.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdd_Import.Location = New System.Drawing.Point(171, 17)
        Me.ButtonAdd_Import.Name = "ButtonAdd_Import"
        Me.ButtonAdd_Import.Size = New System.Drawing.Size(111, 35)
        Me.ButtonAdd_Import.TabIndex = 7
        Me.ButtonAdd_Import.Text = "IMPOR&T"
        Me.ButtonAdd_Import.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdd_Import.UseVisualStyleBackColor = True
        '
        'ButtonClear_Import
        '
        Me.ButtonClear_Import.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClear_Import.Image = Global.InnerHeads.My.Resources.Resources.clear
        Me.ButtonClear_Import.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonClear_Import.Location = New System.Drawing.Point(315, 17)
        Me.ButtonClear_Import.Name = "ButtonClear_Import"
        Me.ButtonClear_Import.Size = New System.Drawing.Size(98, 35)
        Me.ButtonClear_Import.TabIndex = 8
        Me.ButtonClear_Import.Text = "&CLEAR"
        Me.ButtonClear_Import.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClear_Import.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(123, 155)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 16)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "File Path:"
        '
        'ButtonFileBrowse
        '
        Me.ButtonFileBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFileBrowse.Image = Global.InnerHeads.My.Resources.Resources.excel_icon
        Me.ButtonFileBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonFileBrowse.Location = New System.Drawing.Point(20, 145)
        Me.ButtonFileBrowse.Name = "ButtonFileBrowse"
        Me.ButtonFileBrowse.Size = New System.Drawing.Size(97, 35)
        Me.ButtonFileBrowse.TabIndex = 6
        Me.ButtonFileBrowse.Text = "&Browse"
        Me.ButtonFileBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonFileBrowse.UseVisualStyleBackColor = True
        '
        'ComboBoxRecruiter2_import
        '
        Me.ComboBoxRecruiter2_import.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxRecruiter2_import.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxRecruiter2_import.BackColor = System.Drawing.Color.White
        Me.ComboBoxRecruiter2_import.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRecruiter2_import.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBoxRecruiter2_import.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxRecruiter2_import.FormattingEnabled = True
        Me.ComboBoxRecruiter2_import.Location = New System.Drawing.Point(20, 52)
        Me.ComboBoxRecruiter2_import.Name = "ComboBoxRecruiter2_import"
        Me.ComboBoxRecruiter2_import.Size = New System.Drawing.Size(166, 24)
        Me.ComboBoxRecruiter2_import.TabIndex = 1
        '
        'TextBoxApplicationID_import
        '
        Me.TextBoxApplicationID_import.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxApplicationID_import.Location = New System.Drawing.Point(119, 92)
        Me.TextBoxApplicationID_import.Name = "TextBoxApplicationID_import"
        Me.TextBoxApplicationID_import.ReadOnly = True
        Me.TextBoxApplicationID_import.Size = New System.Drawing.Size(67, 22)
        Me.TextBoxApplicationID_import.TabIndex = 5
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(17, 95)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(97, 16)
        Me.Label23.TabIndex = 17
        Me.Label23.Text = "Application ID :"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(17, 29)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(68, 16)
        Me.Label28.TabIndex = 10
        Me.Label28.Text = "Recruiter :"
        '
        'DateTimePickerScreeningDate_import
        '
        Me.DateTimePickerScreeningDate_import.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerScreeningDate_import.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerScreeningDate_import.Location = New System.Drawing.Point(366, 52)
        Me.DateTimePickerScreeningDate_import.Name = "DateTimePickerScreeningDate_import"
        Me.DateTimePickerScreeningDate_import.Size = New System.Drawing.Size(250, 22)
        Me.DateTimePickerScreeningDate_import.TabIndex = 3
        Me.DateTimePickerScreeningDate_import.Value = New Date(2017, 9, 30, 9, 32, 42, 0)
        '
        'ComboBoxResumeSource_import
        '
        Me.ComboBoxResumeSource_import.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxResumeSource_import.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxResumeSource_import.BackColor = System.Drawing.Color.White
        Me.ComboBoxResumeSource_import.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxResumeSource_import.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBoxResumeSource_import.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxResumeSource_import.FormattingEnabled = True
        Me.ComboBoxResumeSource_import.Location = New System.Drawing.Point(192, 52)
        Me.ComboBoxResumeSource_import.Name = "ComboBoxResumeSource_import"
        Me.ComboBoxResumeSource_import.Size = New System.Drawing.Size(168, 24)
        Me.ComboBoxResumeSource_import.TabIndex = 2
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(363, 28)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(107, 16)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "Screening Date :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(189, 29)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(57, 16)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "Source :"
        '
        'TextBoxApplicationStatus_import
        '
        Me.TextBoxApplicationStatus_import.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxApplicationStatus_import.Location = New System.Drawing.Point(622, 53)
        Me.TextBoxApplicationStatus_import.Name = "TextBoxApplicationStatus_import"
        Me.TextBoxApplicationStatus_import.ReadOnly = True
        Me.TextBoxApplicationStatus_import.Size = New System.Drawing.Size(86, 22)
        Me.TextBoxApplicationStatus_import.TabIndex = 4
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(619, 29)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(51, 16)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Status :"
        '
        'JobTableTableAdapter1
        '
        Me.JobTableTableAdapter1.ClearBeforeFill = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.Location = New System.Drawing.Point(233, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(315, 31)
        Me.Label19.TabIndex = 50
        Me.Label19.Text = "ADD NEW CANDIDATE"
        '
        'FormCandidate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1177, 560)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(100, 50)
        Me.Name = "FormCandidate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Candidate Details"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JobTableBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_SQL_JobTable_FormCandidate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JobTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents Label_jobFound As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents txt_jobSearch As TextBox
    Friend WithEvents Label36 As Label
    '   Friend WithEvents IHDatabaseDataSet2 As IHDatabaseDataSet2
    Friend WithEvents JobTableBindingSource As BindingSource
    '  Friend WithEvents JobTableTableAdapter As IHDatabaseDataSet2TableAdapters.JobTableTableAdapter
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ButtonClose As Button
    Friend WithEvents ButtonAddCandidate As Button
    Friend WithEvents ButtonClearAll As Button
    Friend WithEvents ButtonClear As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBoxExperience As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents ComboBoxLocation As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBoxMobile As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBoxCandidateName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBoxApplicationID As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBoxResumeSource As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents DateTimePickerScreeningDate As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxApplicationStatus As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DateTimePickerOpenDate As DateTimePicker
    Friend WithEvents TextBoxJobCategory As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents ComboBoxRecruiter2 As ComboBox
    Friend WithEvents TextBoxJobPosition As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TextBoxCompanyName As TextBox
    Friend WithEvents TextBoxJobStatus As TextBox
    Friend WithEvents ComboBoxJobID As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ButtonFileBrowse As Button
    Friend WithEvents ButtonClose_Import As Button
    Friend WithEvents ButtonAdd_Import As Button
    Friend WithEvents ButtonClear_Import As Button
    Friend WithEvents TextBoxApplicationID_import As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents ComboBoxResumeSource_import As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents DateTimePickerScreeningDate_import As DateTimePicker
    Friend WithEvents Label25 As Label
    Friend WithEvents TextBoxApplicationStatus_import As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents ComboBoxRecruiter2_import As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtFilePath As TextBox
    Friend WithEvents ButtonDownloadFormat As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents DS_SQL_JobTable_FormCandidate As DS_SQL_JobTable_FormCandidate
    Friend WithEvents JobTableBindingSource1 As BindingSource
    Friend WithEvents JobTableTableAdapter1 As DS_SQL_JobTable_FormCandidateTableAdapters.JobTableTableAdapter
    Friend WithEvents JobIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobPositionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Company1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobStatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RecruiterDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PositionLevelDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OpenDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TargetDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ApplicationIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CandidateNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JoiningDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CategoryDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HiringManagerDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Company2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobLocationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExperienceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobDescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalApplicationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ElapsedTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PositionModifiedDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModifyByDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModifyDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RemarksDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ResumeSourceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Btn_search As Button
    Friend WithEvents Label19 As Label
End Class
