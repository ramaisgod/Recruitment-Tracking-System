Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class FormCreateJob
    Dim SQLConn As New SqlConnection
    Dim SQLComm As New SqlCommand

    Private Sub ButtonCreate_Click(sender As Object, e As EventArgs) Handles ButtonCreate.Click
        Try
            '-------- Check If Job ID exist in database with same Application ID -------------------------
            SQLConn.Dispose()
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLComm.Connection = SQLConn
            SQLConn.Open()
            Dim cmd As String
            cmd = "SELECT Count(*) FROM JobTable Where Job_ID = '" & TextBoxJobID.Text & "'"
            SQLComm.CommandText = cmd

            If ComboBoxJobPosition.Text = "" Then
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
            ElseIf SQLComm.ExecuteScalar > 0 Then
                MessageBox.Show("You already created Job ID for the Position '" & ComboBoxJobPosition.Text & "' awhile ago. !!!. Job ID is " & TextBoxJobID.Text & ".", "Information !!!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                SQLComm.CommandText = ""
                SQLConn.Dispose()
                Exit Sub

            Else

                '-------------------------------------------------------------------------------
                SQLConn.Close()
                Dim ConnStr As String = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                Dim cmd1 As String
                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                SQLConn.Open()
                cmd1 = "SELECT Count(*) FROM JobTable Where Job_Position = '" & Trim(ComboBoxJobPosition.Text) & "' AND Company1 = '" & Trim(ComboBoxCompany1.Text) & "' AND Job_Status = 'OPEN'"
                SQLComm.CommandText = cmd1
                If SQLComm.ExecuteScalar > 0 Then
                    If MessageBox.Show("Total  " & SQLComm.ExecuteScalar & " 'OPEN' Position  for '" & ComboBoxJobPosition.Text.Trim() & "' under the venture '" & ComboBoxCompany1.Text.Trim() & "' already exist in database  !!!. Do you want to Create One More ?", "Recruitment Tracking System !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    Else
                        SQLConn.Dispose()
                        SQLComm.Dispose()
                        Exit Sub
                    End If

                End If
                    '-------------------------------------------------------------------------------

                    ' ------ Get Maximum Number from JobTable for New Job ID -------
                    SQLConn.Close()
                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLComm.Connection = SQLConn
                SQLConn.Open()
                Dim MaxEmpID As String
                Dim DR As SqlDataReader
                Dim newNumber As Integer
                MaxEmpID = "SELECT MAX(Sr_No) AS MAXIMUM FROM JobTable"
                'Dim cmd As OleDbCommand = New OleDbCommand(str, Conn)
                SQLComm.CommandText = MaxEmpID
                DR = SQLComm.ExecuteReader
                If DR.HasRows Then
                    While DR.Read()
                        TextBoxJobID.Text = DR("MAXIMUM").ToString
                        newNumber = CInt(Val(TextBoxJobID.Text))
                        If newNumber = 0 Then
                            newNumber = 100001
                            TextBoxJobID.Text = CStr(newNumber)
                        Else
                            newNumber = newNumber + 1
                            TextBoxJobID.Text = CStr(newNumber)
                        End If
                    End While
                    DR.Close()
                End If
                SQLConn.Close()

                ' ----------------------------------------------------------------



                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLComm.Connection = SQLConn

                SQLConn.Open()
                SQLComm.CommandText = ""
                SQLComm.CommandText = "Insert into JobTable(Sr_No,Job_ID,Job_Position,Category,Job_Type,Recruiter,Hiring_Manager,Open_Date,Target_Date,Company1,Company2,Position_Level,Job_Location,Job_Status,Experience,Job_Description) Values(@Sr_No,@Job_ID,@Job_Position,@Category,@Job_Type,@Recruiter,@Hiring_Manager,@Open_Date,@Target_Date,@Company1,@Company2,@Position_Level,@Job_Location,@Job_Status,@Experience,@Job_Description)"

                '([Job_Position],[Department],[Recruiter],[Hiring_Manager],[Date_Opened],[Target_Date],[Company_Name],[Position_Level],[Job_Location],[Job_Status],[Job_Description])
                'SQLComm.CommandText = "Insert into JobTable(Job ID,Job Position,Department,Recruiter,Hiring Manager,Date Opened,Target Date,Company Name,Position Level,Job Location,Job Status,Job Description) Values(@Job ID,@Job Position,@Department,@Recruiter,@Hiring Manager,@Date Opened,@Target Date,@Company Name,@Position Level,@Job Location,@Job Status,@Job Description)"
                'SQLComm.CommandText = "Insert into JobTable Values(@Job ID,@Job Position,@Department,@Recruiter,@Hiring Manager,@Date Opened,@Target Date,@Company Name,@Position Level,@Job Location,@Job Status,@Job Description)"
                SQLComm.Parameters.AddWithValue("Sr_No", newNumber + 1)
                SQLComm.Parameters.AddWithValue("Job_ID", TextBoxJobID.Text)
                SQLComm.Parameters.AddWithValue("Job_Position", Trim(ComboBoxJobPosition.Text))
                SQLComm.Parameters.AddWithValue("Category", ComboBoxCategory.Text)
                SQLComm.Parameters.AddWithValue("Job_Type", ComboBoxJobType.Text)
                SQLComm.Parameters.AddWithValue("Recruiter", ComboBoxRecruiter.Text)
                SQLComm.Parameters.AddWithValue("Hiring_Manager", Trim(ComboBoxHiringManager.Text))
                SQLComm.Parameters.AddWithValue("Open_Date", DateTimePickerOpenDate.Value)
                SQLComm.Parameters.AddWithValue("Target_Date", DateTimePickerTargetDate.Value)
                SQLComm.Parameters.AddWithValue("Company1", ComboBoxCompany1.Text)
                SQLComm.Parameters.AddWithValue("Company2", ComboBoxCompany2.Text)
                SQLComm.Parameters.AddWithValue("Position_Level", ComboBoxPositionLevel.Text)
                SQLComm.Parameters.AddWithValue("Job_Location", Trim(ComboBoxJobLocation.Text))
                SQLComm.Parameters.AddWithValue("Job_Status", ComboBoxJobStatus.Text)
                SQLComm.Parameters.AddWithValue("Experience", If(String.IsNullOrWhiteSpace(ComboBoxExperience.Text.Trim()), DBNull.Value, Trim(ComboBoxExperience.Text)))
                SQLComm.Parameters.AddWithValue("Job_Description", If(String.IsNullOrWhiteSpace(TextBoxJobDescription.Text.Trim()), DBNull.Value, Trim(TextBoxJobDescription.Text)))

                SQLComm.ExecuteNonQuery()
                'SQLConn.Close()
                MsgBox("New Job has been Created !!! Job ID is " & TextBoxJobID.Text)
                SQLComm.Parameters.Clear()
                '----------------------- Add Hiring Manager Name if not exist ---------------------
                SQLComm.CommandText = "Select Count(*) from EmployeeName Where Name = '" & Trim(ComboBoxHiringManager.Text) & "'"
                If SQLComm.ExecuteScalar > 0 Then
                Else
                    SQLComm.CommandText = "Insert into EmployeeName(Name) Values(@Name)"
                    SQLComm.Parameters.AddWithValue("Name", ComboBoxHiringManager.Text)
                    SQLComm.ExecuteNonQuery()
                End If
                SQLConn.Close()
                '----------------------- refresh in datagridview ----------------------------------
                Dim ds1 As New DataSet
                ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLComm.Connection = SQLConn
                SQLConn.Open()
                SQLComm = New SqlCommand(("Select * from JOBTABLE where Lower(Job_Position) LIKE '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Job_Status) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Recruiter) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Hiring_Manager) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Company2) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Position_Level) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Application_ID) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Candidate_Name) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Company1) LIKE '%" & LCase(Trim(txt_jobSearch.Text)) & "%'"), SQLConn)
                SQLComm.CommandTimeout = 30
                Dim DA1 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA1.Fill(ds1)
                DataGridView3.DataSource = ds1.Tables(0)
                SQLConn.Close()
                DataGridView3.DataBindings.Clear()
                SQLComm.Parameters.Clear()
                ConnStr = Nothing
                Label_jobFound.Text = DataGridView3.RowCount
                SQLConn.Dispose()
                DataGridView3.Sort(DataGridView3.Columns(6), direction:=ListSortDirection.Descending)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
            SQLComm.Dispose()
        End Try


    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
        FormMain.btn_createjob.BackColor = Color.Honeydew

    End Sub


    Private Sub FormCreateJob_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DS_SQL_JobTable_FormSearchJob.JobTable' table. You can move, or remove it, as needed.
        Me.JobTableTableAdapter.Fill(Me.DS_SQL_JobTable_FormSearchJob.JobTable)
        'TODO: This line of code loads data into the 'DSJobTable.JobTable' table. You can move, or remove it, as needed.
        DataGridView3.Sort(DataGridView3.Columns(6), direction:=ListSortDirection.Descending)
        Try
            Dim DR As SqlDataReader
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLComm.Connection = SQLConn
            SQLConn.Open()
            '------- Add List Item in Job Position 
            SQLComm = New SqlCommand("SELECT DISTINCT Job_Position FROM JobTable", SQLConn)
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
            SQLComm = New SqlCommand("SELECT DISTINCT Category_Name FROM Category", SQLConn)
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

            '------- Add List Item in Recruiter 
            SQLComm = New SqlCommand("SELECT DISTINCT RecruiterName FROM Recruiter", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            If DR.HasRows = True Then
                While DR.Read()
                    Me.ComboBoxRecruiter.Items.Add(DR("RecruiterName"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()
            '----------------------------------------

            '------- Add List Item in Hiring Manager
            SQLComm = New SqlCommand("SELECT DISTINCT Name FROM EmployeeName", SQLConn)
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
            SQLComm = New SqlCommand("SELECT DISTINCT CompanyName FROM CompanyList", SQLConn)
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
            ''------- Add List Item in Company2
            'SQLComm = New SQLCommand("SELECT DISTINCT CompanyGroup FROM CompanyList", SQLConn)
            'SQLComm.CommandTimeout = 30
            'DR = SQLComm.ExecuteReader()
            'If DR.HasRows = True Then
            '    While DR.Read()
            '        Me.ComboBoxCompany2.Items.Add(DR("CompanyGroup"))
            '    End While
            'End If
            'SQLComm.ResetCommandTimeout()
            '----------------------------------------
            SQLConn.Close()
            DateTimePickerOpenDate.Value = Date.Today
            DateTimePickerTargetDate.Value = Date.Today

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
        End Try

    End Sub

    Private Sub ButtonCreateClear_Click(sender As Object, e As EventArgs) Handles ButtonCreateClear.Click
        DateTimePickerOpenDate.Value = Today
        DateTimePickerTargetDate.Value = Today
        TextBoxJobID.Text = ""
        ComboBoxJobPosition.Text = ""
        ComboBoxCategory.SelectedIndex = -1
        ComboBoxJobType.Text = ""
        ComboBoxRecruiter.SelectedIndex = -1
        ComboBoxHiringManager.Text = ""
        ComboBoxCompany1.SelectedIndex = -1
        ComboBoxCompany2.SelectedIndex = -1
        ComboBoxPositionLevel.SelectedIndex = -1
        ComboBoxJobLocation.Text = ""
        ComboBoxExperience.Text = ""
        TextBoxJobDescription.Text = ""

    End Sub

    Private Sub ComboBoxCompany1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCompany1.SelectedIndexChanged
        Try
            SQLConn.Dispose()
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

    Private Sub txt_jobSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_jobSearch.KeyPress
        Try
            Dim ConnStr As String
            Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
            If tmp.KeyChar = ChrW(Keys.Enter) Then
                'SQLConn.Close()
                ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                Dim ds2 As New DataSet

                SQLConn.Open()
                'SQLComm = New SQLCommand("SELECT Job_ID, Job_Position, Job_Status, Recruiter, Open_Date, Target_Date, Company1, Position_Level, Total_Application, Application_ID, Candidate_Name, Joining_Date FROM JobTable WHERE Job_Position LIKE '%" & txt_jobSearch.Text & "%'", SQLConn)
                SQLComm = New SqlCommand(("Select * from JOBTABLE where Lower(Job_Position) LIKE '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Job_Status) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Recruiter) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Hiring_Manager) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Company2) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Position_Level) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Application_ID) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Candidate_Name) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Company1) LIKE '%" & LCase(Trim(txt_jobSearch.Text)) & "%'"), SQLConn)
                SQLComm.CommandTimeout = 30
                Dim DA2 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA2.Fill(ds2)
                DataGridView3.DataSource = ds2.Tables(0)
                SQLConn.Close()
                DataGridView3.DataBindings.Clear()
                SQLComm.Parameters.Clear()
                ConnStr = Nothing
                Label_jobFound.Text = DataGridView3.RowCount
                DataGridView3.Sort(DataGridView3.Columns(6), direction:=ListSortDirection.Descending)
            Else
                SQLConn.Dispose()
            End If
        Catch ex As Exception
            SQLConn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Btn_search_Click(sender As Object, e As EventArgs) Handles Btn_search.Click
        Try
            Dim ConnStr As String
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim ds2 As New DataSet

            SQLConn.Open()
            'SQLComm = New SQLCommand("SELECT Job_ID, Job_Position, Job_Status, Recruiter, Open_Date, Target_Date, Company1, Position_Level, Total_Application, Application_ID, Candidate_Name, Joining_Date FROM JobTable WHERE Job_Position LIKE '%" & txt_jobSearch.Text & "%'", SQLConn)
            SQLComm = New SqlCommand(("Select * from JOBTABLE where Lower(Job_Position) LIKE '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Job_Status) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Recruiter) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Hiring_Manager) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Company2) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Position_Level) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Application_ID) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Candidate_Name) Like '%" & LCase(Trim(txt_jobSearch.Text)) & "%' or Lower(Company1) LIKE '%" & LCase(Trim(txt_jobSearch.Text)) & "%'"), SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA2 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA2.Fill(ds2)
            DataGridView3.DataSource = ds2.Tables(0)
            SQLConn.Close()
            DataGridView3.DataBindings.Clear()
            SQLComm.Parameters.Clear()
            ConnStr = Nothing
            Label_jobFound.Text = DataGridView3.RowCount
            DataGridView3.Sort(DataGridView3.Columns(6), direction:=ListSortDirection.Descending)
            SQLConn.Dispose()
            txt_jobSearch.Focus()
        Catch ex As Exception
            SQLConn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class