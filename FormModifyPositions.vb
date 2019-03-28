Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class FormModifyPositions
    Dim SQLConn As New SqlConnection
    Dim SQLComm As New SqlCommand
    Dim ConnStr As String
    Private Sub FormModifyPositions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DS_SQL_JobTable_FormSearchJob.JobTable' table. You can move, or remove it, as needed.
        Me.JobTableTableAdapter1.Fill(Me.DS_SQL_JobTable_FormSearchJob.JobTable)
        'TODO: This line of code loads data into the 'IHDatabaseDataSet5.JobTable' table. You can move, or remove it, as needed.
        'Me.JobTableTableAdapter.Fill(Me.IHDatabaseDataSet5.JobTable)
        CheckBoxAllowModification.Enabled = False
        SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
        SQLComm.Connection = SQLConn
        SQLConn.Open()
        '------- Add List Item in Recruiter 
        SQLComm = New SqlCommand("SELECT RecruiterName FROM Recruiter", SQLConn)
        SQLComm.CommandTimeout = 30
        Dim DR As SqlDataReader
        DR = SQLComm.ExecuteReader()
        If DR.HasRows = True Then
            While DR.Read()
                Me.ComboBoxRecruiter.Items.Add(DR("RecruiterName"))
                Me.ComboBoxModifiedBy.Items.Add(DR("RecruiterName"))
            End While
            DR.Close()
        End If


        '------- Add List Item in Job ID
        SQLComm = New SqlCommand("SELECT Job_ID FROM JobTable WHERE Job_Status <> 'JOINED'", SQLConn)
        SQLComm.CommandTimeout = 30
        DR = SQLComm.ExecuteReader()
        If DR.HasRows = True Then
            While DR.Read()
                Me.ComboBoxModifyJobID.Items.Add(DR("Job_ID"))
            End While
            DR.Close()
        End If
        SQLComm.ResetCommandTimeout()
        '----------------------------------------

        '------- Add List Item in Job Position 
        SQLComm = New SqlCommand("SELECT Job_Position FROM JobPosition", SQLConn)
        SQLComm.CommandTimeout = 30
        DR = SQLComm.ExecuteReader()
        If DR.HasRows = True Then
            While DR.Read()
                Me.ComboBoxJobPosition.Items.Add(DR("Job_Position"))
            End While
            DR.Close()
        End If
        SQLComm.ResetCommandTimeout()
        '----------------------------------------

        '------- Add List Item in Category 
        SQLComm = New SqlCommand("SELECT Category_Name FROM Category", SQLConn)
        SQLComm.CommandTimeout = 30
        DR = SQLComm.ExecuteReader()
        If DR.HasRows = True Then
            While DR.Read()
                Me.ComboBoxCategory.Items.Add(DR("Category_Name"))
            End While
            DR.Close()
        End If
        SQLComm.ResetCommandTimeout()
        '----------------------------------------


        '------- Add List Item in Hiring Manager
        SQLComm = New SqlCommand("SELECT Name FROM EmployeeName", SQLConn)
        SQLComm.CommandTimeout = 30
        DR = SQLComm.ExecuteReader()
        If DR.HasRows = True Then
            While DR.Read()
                Me.ComboBoxHiringManager.Items.Add(DR("Name"))
            End While
            DR.Close()
        End If
        SQLComm.ResetCommandTimeout()
        '----------------------------------------

        '------- Add List Item in Company Name
        SQLComm = New SqlCommand("SELECT CompanyName FROM CompanyList", SQLConn)
        SQLComm.CommandTimeout = 30
        DR = SQLComm.ExecuteReader()
        If DR.HasRows = True Then
            While DR.Read()
                Me.ComboBoxCompany1.Items.Add(DR("CompanyName"))
            End While
            DR.Close()
        End If
        SQLComm.ResetCommandTimeout()
        '----------------------------------------
        SQLConn.Close()

        DateTimePickerOpenDate.Value = Date.Today
        DateTimePickerTargetDate.Value = Date.Today
        DateTimePickerModifyDate.Value = Date.Today

        DataGridView5.Sort(DataGridView5.Columns(8), direction:=ListSortDirection.Descending)


    End Sub

    Private Sub ComboBoxModifyJobID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxModifyJobID.SelectedIndexChanged

        '------------------ Clear Fields ----------------------------------------
        CheckBoxAllowModification.Checked = False
        ComboBoxJobPosition.Text = ""
        LabelCurrentStatus.Text = ""
        ComboBoxCategory.Text = ""
        ComboBoxJobType.Text = ""
        ComboBoxRecruiter.Text = ""
        ComboBoxHiringManager.Text = ""
        DateTimePickerOpenDate.Value = Date.Today
        DateTimePickerTargetDate.Value = Date.Today
        ComboBoxCompany1.Text = ""
        ComboBoxCompany2.Text = ""
        ComboBoxPositionLevel.Text = ""
        ComboBoxJobLocation.Text = ""
        ComboBoxJobStatus.Text = ""
        ComboBoxExperience.Text = ""
        TextBoxRemarks.Text = ""
        DateTimePickerModifyDate.Value = Date.Today
        ComboBoxModifiedBy.Text = ""
        TextBoxRemarks.Text = ""
        DateTimePickerModifyDate.Value = Date.Today
        ComboBoxModifiedBy.Text = ""
        ComboBoxJobStatus.Items.Clear()
        '------------------------------------------------------------------------
        SQLConn.Close()

        Try


            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DT As New DataTable
            'SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE JOB_ID= '" & ComboBoxModifyJobID.Text & "'", SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DT)
            LabelCurrentStatus.DataBindings.Add("Text", DT, "Job_Status")
            ComboBoxJobStatus.DataBindings.Add("Text", DT, "Job_Status")
            ComboBoxJobPosition.DataBindings.Add("Text", DT, "Job_Position")
            ComboBoxCategory.DataBindings.Add("Text", DT, "Category")
            ComboBoxJobType.DataBindings.Add("Text", DT, "Job_Type")
            ComboBoxRecruiter.DataBindings.Add("Text", DT, "Recruiter")
            ComboBoxHiringManager.DataBindings.Add("Text", DT, "Hiring_Manager")
            DateTimePickerOpenDate.DataBindings.Add("Value", DT, "Open_Date")
            DateTimePickerTargetDate.DataBindings.Add("Value", DT, "Target_Date")
            ComboBoxCompany1.DataBindings.Add("Text", DT, "Company1")
            ComboBoxCompany2.DataBindings.Add("Text", DT, "Company2")
            ComboBoxPositionLevel.DataBindings.Add("Text", DT, "Position_Level")
            ComboBoxJobLocation.DataBindings.Add("Text", DT, "Job_Location")
            ComboBoxExperience.DataBindings.Add("Text", DT, "Experience")
            TextBoxRemarks.DataBindings.Add("Text", DT, "Remarks")
            TextBoxJobDescription.DataBindings.Add("Text", DT, "Job_Description")
            'DateTimePickerModifyDate.DataBindings.Add("Value", DT, "Modify_Date")
            'ComboBoxModifiedBy.DataBindings.Add("Text", DT, "Modify_By")


            LabelCurrentStatus.DataBindings.Clear()
            ComboBoxJobStatus.DataBindings.Clear()
            ComboBoxJobPosition.DataBindings.Clear()
            ComboBoxCategory.DataBindings.Clear()
            ComboBoxJobType.DataBindings.Clear()
            ComboBoxRecruiter.DataBindings.Clear()
            ComboBoxHiringManager.DataBindings.Clear()
            DateTimePickerOpenDate.DataBindings.Clear()
            DateTimePickerTargetDate.DataBindings.Clear()
            ComboBoxCompany1.DataBindings.Clear()
            ComboBoxCompany2.DataBindings.Clear()
            ComboBoxPositionLevel.DataBindings.Clear()
            ComboBoxJobLocation.DataBindings.Clear()
            ComboBoxExperience.DataBindings.Clear()
            TextBoxRemarks.DataBindings.Clear()
            DateTimePickerModifyDate.DataBindings.Clear()
            ComboBoxModifiedBy.DataBindings.Clear()
            TextBoxJobDescription.DataBindings.Clear()

            '----------------------------------------- Change Item in Job Status Drop Down ---------------------

            If LabelCurrentStatus.Text <> "OFFERED" Then
                ComboBoxJobStatus.Items.Add("OPEN")
                ComboBoxJobStatus.Items.Add("CANCELLED")
                ComboBoxJobStatus.Items.Add("ON-HOLD")

                ComboBoxJobStatus.Text = LabelCurrentStatus.Text
            Else

                ComboBoxJobStatus.Items.Add("OFFERED")
                ComboBoxJobStatus.Items.Add("OPEN")
                ComboBoxJobStatus.Items.Add("CANCELLED")
                ComboBoxJobStatus.Items.Add("ON-HOLD")

                ComboBoxJobStatus.Text = LabelCurrentStatus.Text

            End If

            If IsNothing(ComboBoxModifyJobID.Text) Then
                CheckBoxAllowModification.Enabled = False
            Else
                CheckBoxAllowModification.Enabled = True
            End If

            '---------------------------------------------------------------------------------------------------
            SQLConn.Close()
            SQLComm.Parameters.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
            SQLConn.Dispose()
        End Try

    End Sub

    Private Sub CheckBoxAllowModification_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAllowModification.CheckedChanged

        If CheckBoxAllowModification.Checked = True Then
            ComboBoxJobPosition.Enabled = True
            ComboBoxCategory.Enabled = True
            ComboBoxJobType.Enabled = True
            ComboBoxRecruiter.Enabled = True
            ComboBoxHiringManager.Enabled = True
            ComboBoxCompany1.Enabled = True
            ComboBoxCompany2.Enabled = True
            If LabelCurrentStatus.Text = "OFFERED" Then
                DateTimePickerOpenDate.Enabled = False
            Else
                DateTimePickerOpenDate.Enabled = True
            End If
            DateTimePickerTargetDate.Enabled = True
            ComboBoxPositionLevel.Enabled = True
            ComboBoxJobLocation.Enabled = True
            ComboBoxJobStatus.Enabled = True
            ComboBoxExperience.Enabled = True
            TextBoxRemarks.Enabled = True
            ComboBoxModifiedBy.Enabled = True
            TextBoxRemarks.Enabled = True
            ComboBoxModifiedBy.Enabled = True
            ButtonModificationSave.Enabled = True
            TextBoxJobDescription.Enabled = True
        Else
            ComboBoxJobPosition.Enabled = False
            ComboBoxCategory.Enabled = False
            ComboBoxJobType.Enabled = False
            ComboBoxRecruiter.Enabled = False
            ComboBoxHiringManager.Enabled = False
            ComboBoxCompany1.Enabled = False
            ComboBoxCompany2.Enabled = False
            DateTimePickerOpenDate.Enabled = False
            DateTimePickerTargetDate.Enabled = False
            ComboBoxPositionLevel.Enabled = False
            ComboBoxJobLocation.Enabled = False
            ComboBoxJobStatus.Enabled = False
            ComboBoxExperience.Enabled = False
            TextBoxRemarks.Enabled = False
            ComboBoxModifiedBy.Enabled = False
            TextBoxRemarks.Enabled = False
            ComboBoxModifiedBy.Enabled = False
            ButtonModificationSave.Enabled = False
            TextBoxJobDescription.Enabled = False
        End If

    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
        FormMain.btn_ModifyJobPosition.BackColor = Color.Honeydew

    End Sub



    Private Sub txt_jobSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_jobSearch.KeyPress
        Try
            Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
            If tmp.KeyChar = ChrW(Keys.Enter) Then
                SQLConn.Close()
                ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                Dim ds2 As New DataSet
                SQLConn.Open()
                'SQLComm = New SQLCommand("Select * FROM JobTable WHERE Job_Position Like '%" & txt_jobSearch.Text & "%'", SQLConn)
                SQLComm = New SqlCommand(("Select * from JOBTABLE where Lower(Job_Position) LIKE '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Job_Status) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Recruiter) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Hiring_Manager) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Company2) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Position_Level) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Application_ID) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Candidate_Name) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Company1) LIKE '%" & LCase(Trim(txt_jobSearch.Text)) & "%'"), SQLConn)
                SQLComm.CommandTimeout = 30
                Dim DA2 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA2.Fill(ds2)
                DataGridView5.DataSource = ds2.Tables(0)
                SQLConn.Close()
                DataGridView5.DataBindings.Clear()
                SQLComm.Parameters.Clear()
                ConnStr = Nothing
                Label_jobFound.Text = DataGridView5.RowCount
                DataGridView5.Sort(DataGridView5.Columns(8), direction:=ListSortDirection.Descending)
            Else
                SQLConn.Dispose()
            End If
        Catch ex As Exception
            SQLConn.Close()
        End Try
    End Sub



    Private Sub DataGridView5_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellDoubleClick
        Try
            If DataGridView5.SelectedCells.Item(3).Value = "JOINED" Then
                MessageBox.Show("Job Status is JOINED !!!. Kindly select another Job ID.")
            Else
                ComboBoxModifyJobID.Text = ""
                ComboBoxModifyJobID.DataBindings.Clear()
                ComboBoxModifyJobID.Text = DataGridView5.SelectedCells.Item(0).Value
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BButtonModificationSave_Click(sender As Object, e As EventArgs) Handles ButtonModificationSave.Click
        Try
            If ComboBoxModifyJobID.Text = "111" Then
                MessageBox.Show("You can't modify Job ID 111. !!!")
                ComboBoxModifyJobID.Focus()
            ElseIf ComboBoxJobPosition.Text = "" Then
                MessageBox.Show("Please Enter Job Position")
                ComboBoxJobPosition.Focus()
            ElseIf ComboBoxCategory.Text = "" Then
                MessageBox.Show("Please Enter Department")
                ComboBoxCategory.Focus()
            ElseIf ComboBoxJobType.Text = "" Then
                MessageBox.Show("Please Enter Job Type")
                ComboBoxJobType.Focus()
            ElseIf ComboBoxRecruiter.Text = "" Then
                MessageBox.Show("Please Select Recruiter")
                ComboBoxRecruiter.Focus()
            ElseIf ComboBoxHiringManager.Text = "" Then
                MessageBox.Show("Please Enter Hiring Manager")
                ComboBoxHiringManager.Focus()
            ElseIf DateTimePickerTargetDate.Value < DateTimePickerOpenDate.Value Then
                MessageBox.Show("Target Date must be greater than Open Date")
                DateTimePickerTargetDate.Focus()
            ElseIf ComboBoxCompany1.Text = "" Then
                MessageBox.Show("Please Select Company Name")
                ComboBoxCompany1.Focus()
            ElseIf ComboBoxCompany2.Text = "" Then
                MessageBox.Show("Please Enter Company")
                ComboBoxCompany2.Focus()
            ElseIf ComboBoxPositionLevel.Text = "" Then
                MessageBox.Show("Please Select Position Level")
                ComboBoxPositionLevel.Focus()
            ElseIf ComboBoxJobLocation.Text = "" Then
                MessageBox.Show("Please Enter Location")
                ComboBoxJobLocation.Focus()
            ElseIf ComboBoxJobStatus.Text = "" Then
                MessageBox.Show("Please Select Job Status")
                ComboBoxJobStatus.Focus()
            ElseIf ComboBoxModifiedBy.Text = "" Then
                MessageBox.Show("Plesae Select Modify By")
                ComboBoxModifiedBy.Focus()
            ElseIf TextBoxRemarks.Text = "" Or TextBoxRemarks.Text = " " Then
                MessageBox.Show("Plesae Enter Reasons and Details of Modification in Remarks. !!!")
                TextBoxRemarks.Focus()
            Else

                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLComm.Connection = SQLConn
                SQLConn.Open()
                SQLComm.CommandText = ""
                SQLComm.CommandText = ("UPDATE JobTable SET Job_Position = @Job_Position,Category=@Category,Job_Type=@Job_Type,Job_Status=@Job_Status,Recruiter=@Recruiter,Hiring_Manager=@Hiring_Manager,Open_Date=@Open_Date,Target_Date=@Target_Date,Company1=@Company1,Company2=@Company2,Position_Level=@Position_Level,Job_Location=@Job_Location,Experience=@Experience,Position_Modified=@Position_Modified,Modify_By=@Modify_By,Modify_Date=@Modify_Date,Remarks=@Remarks,Application_ID = @Application_ID, Candidate_Name = @Candidate_Name,Elapsed_Time = @Elapsed_Time,Joining_Date=@Joining_Date,Resume_Source=@Resume_Source,Job_Description=@Job_Description  Where Job_ID = '" & ComboBoxModifyJobID.Text & "'")

                SQLComm.Parameters.Add("@Job_Position", SqlDbType.Char).Value = ComboBoxJobPosition.Text.Trim()
                SQLComm.Parameters.Add("@Category", SqlDbType.Char).Value = ComboBoxCategory.Text
                SQLComm.Parameters.Add("@Job_Type", SqlDbType.Char).Value = ComboBoxJobType.Text
                SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = ComboBoxJobStatus.Text
                SQLComm.Parameters.Add("@Recruiter", SqlDbType.Char).Value = ComboBoxRecruiter.Text
                SQLComm.Parameters.Add("@Hiring_Manager", SqlDbType.Char).Value = ComboBoxHiringManager.Text.Trim()
                SQLComm.Parameters.Add("@Open_Date", SqlDbType.Date).Value = DateTimePickerOpenDate.Value
                SQLComm.Parameters.Add("@Target_Date", SqlDbType.Date).Value = DateTimePickerTargetDate.Value
                SQLComm.Parameters.Add("@Company1", SqlDbType.Char).Value = ComboBoxCompany1.Text
                SQLComm.Parameters.Add("@Company2", SqlDbType.Char).Value = ComboBoxCompany2.Text
                SQLComm.Parameters.Add("@Position_Level", SqlDbType.Char).Value = ComboBoxPositionLevel.Text
                SQLComm.Parameters.Add("@Job_Location", SqlDbType.Char).Value = ComboBoxJobLocation.Text.Trim()
                SQLComm.Parameters.Add("@Experience", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(ComboBoxExperience.Text.Trim()), DBNull.Value, ComboBoxExperience.Text.Trim())
                SQLComm.Parameters.Add("@Position_Modified", SqlDbType.Char).Value = "Yes"
                SQLComm.Parameters.Add("@Modify_By", SqlDbType.Char).Value = ComboBoxModifiedBy.Text
                SQLComm.Parameters.Add("@Modify_Date", SqlDbType.Date).Value = DateTimePickerModifyDate.Value
                SQLComm.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = If(String.IsNullOrWhiteSpace(TextBoxRemarks.Text.Trim()), DBNull.Value, TextBoxRemarks.Text.Trim())
                SQLComm.Parameters.Add("@Application_ID", SqlDbType.Char).Value = DBNull.Value
                SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = DBNull.Value
                SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTime.Now).Subtract(DateTimePickerOpenDate.Value).Days + 1
                SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = #1/1/1900#
                SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = DBNull.Value
                SQLComm.Parameters.Add("@Job_Description", SqlDbType.NVarChar).Value = If(String.IsNullOrWhiteSpace(TextBoxJobDescription.Text.Trim()), DBNull.Value, Trim(TextBoxJobDescription.Text))

                SQLComm.ExecuteNonQuery()
                SQLConn.Close()

                '---------------------Update Modification in Application Table -----------------------------------------------------------
                SQLConn.Open()
                SQLComm.CommandText = ""
                SQLComm.Parameters.Clear()
                SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status=@Job_Status,Job_OpenDate=@Job_OpenDate,Job_Position = @Job_Position,Company1=@Company1,Job_Category=@Job_Category Where Job_ID = '" & ComboBoxModifyJobID.Text & "'")

                SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = ComboBoxJobStatus.Text
                SQLComm.Parameters.Add("@Job_OpenDate", SqlDbType.Date).Value = DateTimePickerOpenDate.Value
                SQLComm.Parameters.Add("@Job_Position", SqlDbType.Char).Value = ComboBoxJobPosition.Text
                SQLComm.Parameters.Add("@Company1", SqlDbType.Char).Value = ComboBoxCompany1.Text
                SQLComm.Parameters.Add("@Job_Category", SqlDbType.Char).Value = ComboBoxCategory.Text
                SQLComm.ExecuteNonQuery()

                SQLConn.Close()
                CheckBoxAllowModification.Checked = False
                MessageBox.Show("Saved !!!")
                SQLComm.Parameters.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub

    Private Sub ComboBoxCompany1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCompany1.SelectedIndexChanged
        Try
            Dim DR As SqlDataReader
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLComm.Connection = SQLConn
            SQLConn.Open()
            '------- Add List Item in Company Name
            SQLComm = New SqlCommand("SELECT DISTINCT CompanyGroup FROM CompanyList Where CompanyName = '" & ComboBoxCompany1.Text & "'", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            Me.ComboBoxCompany2.Items.Clear()
            If DR.HasRows = True Then
                While DR.Read()
                    Me.ComboBoxCompany2.Items.Add(DR("CompanyGroup"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()
            SQLConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
        End Try

    End Sub

    Private Sub txt_jobSearch_TextChanged(sender As Object, e As EventArgs) Handles txt_jobSearch.TextChanged

    End Sub

    Private Sub Btn_searchApp_Click(sender As Object, e As EventArgs) Handles Btn_searchApp.Click
        Try
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim ds2 As New DataSet
            SQLConn.Open()
            'SQLComm = New SQLCommand("SELECT * FROM JobTable WHERE Job_Position LIKE '%" & txt_jobSearch.Text & "%'", SQLConn)
            SQLComm = New SqlCommand(("Select * from JOBTABLE where Lower(Job_Position) LIKE '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Job_Status) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Recruiter) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Hiring_Manager) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Company2) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Position_Level) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Application_ID) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Candidate_Name) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Company1) LIKE '%" & LCase(Trim(txt_jobSearch.Text)) & "%'"), SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA2 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA2.Fill(ds2)
            DataGridView5.DataSource = ds2.Tables(0)
            SQLConn.Close()
            DataGridView5.DataBindings.Clear()
            SQLComm.Parameters.Clear()
            ConnStr = Nothing
            Label_jobFound.Text = DataGridView5.RowCount
            DataGridView5.Sort(DataGridView5.Columns(8), direction:=ListSortDirection.Descending)
            SQLConn.Dispose()
            txt_jobSearch.Focus()
        Catch ex As Exception
            SQLConn.Close()
        End Try

    End Sub
End Class