Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class FormChangeJobID
    Dim SQLConn As New SqlConnection
    Dim SQLComm As New SqlCommand

    Dim ConnStr As String


    Private Sub FormChangeJobID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DS_SQL_JobTable_FormSearchJob.JobTable' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'DS_ApplicationTable_SQL.ApplicationTable' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'DS_SQL_JobTable_FormSearchJob.JobTable' table. You can move, or remove it, as needed.
        'Me.JobTableTableAdapter3.Fill(Me.DS_SQL_JobTable_FormSearchJob.JobTable)
        'TODO: This line of code loads data into the 'DS_SQL_JobTable_FormCandidate.JobTable' table. You can move, or remove it, as needed.
        ''''  Me.JobTableTableAdapter2.Fill(Me.DS_SQL_JobTable_FormCandidate.JobTable)
        'TODO: This line of code loads data into the 'DS_ApplicationTable_SQL.ApplicationTable' table. You can move, or remove it, as needed.
        '''''Me.ApplicationTableTableAdapter3.Fill(Me.DS_ApplicationTable_SQL.ApplicationTable)
        'TODO: This line of code loads data into the 'DSChange_NewJobID.JobTable' table. You can move, or remove it, as needed.
        'Me.JobTableTableAdapter1.Fill(Me.DSChange_NewJobID.JobTable)
        'TODO: This line of code loads data into the 'DSChange_AppID.ApplicationTable' table. You can move, or remove it, as needed.
        'Me.ApplicationTableTableAdapter2.Fill(Me.DSChange_AppID.ApplicationTable)
        'TODO: This line of code loads data into the 'DSAppChangeJobID.ApplicationTable' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'IHDatabaseDataSet4.JobTable' table. You can move, or remove it, as needed.
        'Me.JobTableTableAdapter.Fill(Me.IHDatabaseDataSet4.JobTable)
        'Me.ApplicationTableTableAdapter.Fill(Me.DSAppChangeJobID.ApplicationTable)

        Try
            SQLConn.Close()
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLComm.Connection = SQLConn
            Dim DR As SqlDataReader
            SQLConn.Open()
            '------- Add List Item in Job ID
            SQLComm = New SqlCommand("SELECT Job_ID FROM JobTable", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            If DR.HasRows = True Then
                While DR.Read()
                    'Me.ComboBoxPJobIDChange.Items.Add(DR("Job_ID"))
                    Me.ComboBoxNewJobID.Items.Add(DR("Job_ID"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()
            '----------------------------------------
            ''--------------Add List Item in App ID -----------------------------------
            'ComboBoxAppID.Items.Clear()
            'ComboBoxAppID.Text = ""
            'SQLComm = New SqlCommand("Select Application_ID from ApplicationTable", SQLConn)
            'SQLComm.CommandTimeout = 30
            'DR = SQLComm.ExecuteReader()
            'If DR.HasRows = True Then
            '    While DR.Read()
            '        Me.ComboBoxAppID.Items.Add(DR("Application_ID"))
            '    End While
            '    DR.Close()
            'End If
            'SQLComm.ResetCommandTimeout()
            ''--------------------------------------------------------------------------
            SQLConn.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
        End Try

        Try
            Me.JobTableTableAdapter.Fill(Me.DS_SQL_JobTable_FormSearchJob.JobTable)
            Me.ApplicationTableTableAdapter.Fill(Me.DS_ApplicationTable_SQL.ApplicationTable)


        Catch ex As Exception
        End Try

        'DataGridView3.Sort(DataGridView3.Columns(8), direction:=ListSortDirection.Descending)
        'DataGridView1.Sort(DataGridView1.Columns(DataGridView1.ColumnCount - 1), direction:=ListSortDirection.Descending)

        ComboBoxAppID.SelectedIndex = -1
        ComboBoxNewJobID.SelectedIndex = -1

    End Sub


    Private Sub ComboBoxAppID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAppID.SelectedIndexChanged

        '---------------------------- Clear All Dates field ----------------------------------------------
        TextBoxOldApplicationStatus.Text = ""
        TextBoxCandidateName.Text = ""
        TextBoxOldApplicationStatus.Text = ""
        ComboBoxOldJobID.Text = ""
        TextBoxOldJobStatus.Text = ""
        DateTimePickerOpenDateOld.Text = Today()
        TextBoxOldCompanyName.Text = ""
        TextBoxOldJobPosition.Text = ""
        ComboBoxOldRecruiter.Text = ""
        '------------------------------------------------------------------------------------------------

        Try
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DT As New DataTable
            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Application_ID= '" & ComboBoxAppID.Text & "'", SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DT)

            TextBoxCandidateName.DataBindings.Add("Text", DT, "Candidate_Name")
            TextBoxOldApplicationStatus.DataBindings.Add("Text", DT, "Application_Status")
            ComboBoxOldJobID.DataBindings.Add("Text", DT, "Job_ID")
            TextBoxOldJobStatus.DataBindings.Add("Text", DT, "Job_Status")
            DateTimePickerOpenDateOld.DataBindings.Add("Value", DT, "Job_OpenDate")
            TextBoxOldCompanyName.DataBindings.Add("Text", DT, "Company1")
            TextBoxOldJobPosition.DataBindings.Add("Text", DT, "Job_Position")
            ComboBoxOldRecruiter.DataBindings.Add("Text", DT, "Recruiter_Name")

            SQLConn.Close()

            '--------------Clear Data Binding -------------------------------------
            ComboBoxAppID.DataBindings.Clear()
            TextBoxCandidateName.DataBindings.Clear()
            TextBoxOldApplicationStatus.DataBindings.Clear()
            ComboBoxOldJobID.DataBindings.Clear()
            TextBoxOldJobStatus.DataBindings.Clear()
            DateTimePickerOpenDateOld.DataBindings.Clear()
            TextBoxOldCompanyName.DataBindings.Clear()
            TextBoxOldJobPosition.DataBindings.Clear()
            ComboBoxOldRecruiter.DataBindings.Clear()

            SQLComm.Parameters.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub



    Private Sub txt_Search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Search.KeyPress
        Try
            Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
            If tmp.KeyChar = ChrW(Keys.Enter) Then
                SQLConn.Close()
                ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                Dim ds1 As New DataSet
                SQLConn.Open()
                'SQLComm = New SQLCommand("SELECT * FROM ApplicationTable WHERE Candidate_Name LIKE '%" & txt_Search.Text & "%'", SQLConn)
                SQLComm = New SqlCommand(("Select * from ApplicationTable where Lower(Candidate_Name) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(E_Mail) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Phone) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_Position) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Company1) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_Category) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Recruiter_Name) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Resume_Source) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Decline_Reason) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Comments) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Next_Steps) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Application_ID) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%'"), SQLConn)
                SQLComm.CommandTimeout = 30
                Dim DA1 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA1.Fill(ds1)
                DataGridView1.DataSource = ds1.Tables(0)
                SQLConn.Close()
                DataGridView1.DataBindings.Clear()
                SQLComm.Parameters.Clear()
                ConnStr = Nothing
                Label_Found.Text = DataGridView1.RowCount
                DataGridView1.Sort(DataGridView1.Columns(DataGridView1.ColumnCount - 1), direction:=ListSortDirection.Descending)
            Else
                SQLConn.Dispose()
            End If
        Catch ex As Exception
            SQLConn.Close()
        End Try
    End Sub



    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            ComboBoxAppID.Text = ""
            ComboBoxAppID.DataBindings.Clear()
            ComboBoxAppID.Text = DataGridView1.SelectedCells.Item(3).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBoxChangeNewJobID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxNewJobID.SelectedIndexChanged

        '-------------Clear Data ------------------------------------------ 
        TextBoxNewJobStatus.Text = ""
        DateTimePickerOpenDateNew.Text = ""
        TextBoxNewJobPosition.Text = ""
        TextBoxNewCompany.Text = ""
        TextBoxNewRecruiter.Text = ""
        TextBoxNewHiringMgr.Text = ""
        TextBoxNewCategory.Text = ""
        SQLComm.Parameters.Clear()

        ''------------------------------------------------------------------
        Try
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DT As New DataTable
            'SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE JOB_ID = '" & ComboBoxNewJobID.Text & "'", SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)

            DA.Fill(DT)
            TextBoxNewJobStatus.DataBindings.Add(New Binding("Text", DT, "Job_Status"))
            DateTimePickerOpenDateNew.DataBindings.Add(New Binding("Text", DT, "Open_Date"))
            TextBoxNewJobPosition.DataBindings.Add(New Binding("Text", DT, "Job_Position"))
            TextBoxNewCompany.DataBindings.Add(New Binding("Text", DT, "Company1"))
            TextBoxNewRecruiter.DataBindings.Add(New Binding("Text", DT, "Recruiter"))
            TextBoxNewHiringMgr.DataBindings.Add(New Binding("Text", DT, "Hiring_Manager"))
            TextBoxNewCategory.DataBindings.Add(New Binding("Text", DT, "Category"))
            SQLConn.Close()

            TextBoxNewJobStatus.DataBindings.Clear()
            DateTimePickerOpenDateNew.DataBindings.Clear()
            TextBoxNewJobPosition.DataBindings.Clear()
            TextBoxNewCompany.DataBindings.Clear()
            TextBoxNewRecruiter.DataBindings.Clear()
            TextBoxNewHiringMgr.DataBindings.Clear()
            TextBoxNewCategory.DataBindings.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
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
                'SQLComm = New SQLCommand("SELECT * FROM JobTable WHERE Job_Position LIKE '%" & txt_jobSearch.Text & "%'", SQLConn)
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
                DataGridView3.Sort(DataGridView3.Columns(8), direction:=ListSortDirection.Descending)
            Else
                SQLConn.Dispose()
            End If
        Catch ex As Exception
            SQLConn.Close()
        End Try
    End Sub



    Private Sub DataGridView3_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellDoubleClick
        Try
            ComboBoxNewJobID.Text = ""
            ComboBoxNewJobID.DataBindings.Clear()
            ComboBoxNewJobID.Text = DataGridView3.SelectedCells.Item(2).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonChangeJobID_Click(sender As Object, e As EventArgs) Handles ButtonChangeJobID.Click
        Try

            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn

            If ComboBoxAppID.Text = "" Then
                MessageBox.Show("Kindly select Application ID")
                ComboBoxAppID.Focus()
                'ElseIf TextBoxPApplicationStatus.Text = "JOINED" Then
                '    MessageBox.Show("Candidate is already Joined !!!. Kindly select another Application ID.")
                '    ComboBoxAppID.Focus()
            ElseIf ComboBoxOldJobID.Text = ComboBoxNewJobID.Text Then
                MessageBox.Show("New Job ID and Old Job ID are same. Kindly select different New Job ID !!!")
                ComboBoxNewJobID.Focus()
            ElseIf TextBoxOldJobStatus.Text = "JOINED" And TextBoxOldApplicationStatus.Text = "JOINED" Then
                MessageBox.Show("Candidate is already Joined !!!. Kindly select another Application ID.")
                ComboBoxNewJobID.Focus()
            ElseIf ComboBoxNewJobID.Text = "" Then
                MessageBox.Show("Please Select New Job ID")
                ComboBoxNewJobID.Focus()
            ElseIf TextBoxNewJobStatus.Text = "JOINED" Then
                MessageBox.Show("Someone is already Joined on target Job ID " & ComboBoxNewJobID.Text & " !!!. Kindly select another Job ID.")
                ComboBoxNewJobID.Focus()
            ElseIf TextBoxNewJobStatus.Text = "CANCELLED" Or TextBoxNewJobStatus.Text = "ON-HOLD" Then
                MessageBox.Show("Target Job ID is " & TextBoxNewJobStatus.Text & " !!!. Kindly select another Job ID.")
                ComboBoxNewJobID.Focus()
            ElseIf TextBoxNewJobStatus.Text = "OFFERED" Then
                MessageBox.Show("Someone is already Offered on target Job ID " & ComboBoxNewJobID.Text & " !!!. Kindly select another Job ID.")
                ComboBoxNewJobID.Focus()
            ElseIf TextBoxOldApplicationStatus.Text = "OFFERED" And ComboBoxNewJobID.Text = "111" Then
                MessageBox.Show("You can't put Offered candidate on Uncategorized Job ID. Kindly select another Job ID. !!!")
                ComboBoxNewJobID.Focus()
            ElseIf TextBoxOldApplicationStatus.Text = "TO JOIN" And ComboBoxNewJobID.Text = "111" Then
                MessageBox.Show("You can't put 'To Join' candidate on Uncategorized Job ID. Kindly select another Job ID. !!!")
                ComboBoxNewJobID.Focus()
            ElseIf TextBoxOldApplicationStatus.Text = "OFFERED DECLINED" And ComboBoxNewJobID.Text = "111" Then
                MessageBox.Show("You can't put 'Offer Declined' candidate on Uncategorized Job ID. Kindly select another Job ID. !!!")
                ComboBoxNewJobID.Focus()

            ElseIf (TextBoxOldApplicationStatus.Text = "OFFERED" OrElse TextBoxOldApplicationStatus.Text = "TO JOIN") And ComboBoxNewJobID.Text <> "111" Then

                SQLConn.Open()
                SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_ID = @Job_ID, Job_Status = @Job_Status, Job_OpenDate = @Job_OpenDate, Job_Position = @Job_Position,Company1 = @Company1,Job_Category = @Job_Category,Change_Job_ID=@Change_Job_ID,Old_Job_ID=@Old_Job_ID,Last_Modified =@Last_Modified Where Application_ID = '" & ComboBoxAppID.Text & "'")
                SQLComm.Parameters.Add("@Job_ID", SqlDbType.Char).Value = ComboBoxNewJobID.Text
                SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OFFERED"


                SQLComm.Parameters.Add("@Job_OpenDate", SqlDbType.Date).Value = DateTimePickerOpenDateNew.Value
                SQLComm.Parameters.Add("@Job_Position", SqlDbType.Char).Value = TextBoxNewJobPosition.Text
                SQLComm.Parameters.Add("@Company1", SqlDbType.Char).Value = TextBoxNewCompany.Text
                SQLComm.Parameters.Add("@Job_Category", SqlDbType.Char).Value = TextBoxNewCategory.Text
                SQLComm.Parameters.Add("@Change_Job_ID", SqlDbType.Char).Value = "Yes"
                SQLComm.Parameters.Add("@Old_Job_ID", SqlDbType.Char).Value = ComboBoxOldJobID.Text
                SQLComm.Parameters.Add("@Last_Modified", SqlDbType.DateTime).Value = Date.Now
                SQLComm.ExecuteNonQuery()

                SQLComm.Parameters.Clear()
                '--------------------------------------------------------------------
                SQLComm.CommandText = ""
                SQLComm.CommandText = ("UPDATE ApplicationTable Set Job_Status = @Job_Status Where Job_ID = '" & ComboBoxNewJobID.Text & "'")
                SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OFFERED"

                SQLComm.ExecuteNonQuery()

                SQLComm.Parameters.Clear()
                SQLComm.CommandText = ""
                SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status Where Job_ID = '" & ComboBoxOldJobID.Text & "'")
                If TextBoxOldJobStatus.Text = "OFFERED" Then
                    SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OPEN"
                    SQLComm.ExecuteNonQuery()
                Else
                    SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = TextBoxOldJobStatus.Text
                    SQLComm.ExecuteNonQuery()
                End If
                '--------------------------------------------------------------------

                '------ Update in JobTable ----- with Old Job ID ---------------------
                Dim AppRec As Integer
                SQLComm.CommandText = ""
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE JOB_ID = '" & ComboBoxOldJobID.Text & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                AppRec = SQLComm.ExecuteScalar
                '----------------------------------- 
                Dim appID As Integer
                SQLComm.CommandText = ""
                SQLComm = New SqlCommand("SELECT Count(*) FROM JobTable WHERE Application_ID = '" & ComboBoxAppID.Text & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                appID = SQLComm.ExecuteScalar
                '----------------------------------- 
                SQLComm.Parameters.Clear()

                If appID >= 1 Then
                    SQLComm.CommandText = ""
                    SQLComm.CommandText = ("UPDATE JobTable SET Job_Status = @Job_Status,Application_ID = @Application_ID, Candidate_Name = @Candidate_Name,Resume_Source=@Resume_Source,Total_Application=@Total_Application,Joining_Date=@Joining_Date Where Job_ID = '" & ComboBoxOldJobID.Text & "'")
                    If ComboBoxOldJobID.Text = "111" Then
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "Uncategorized"
                    Else
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OPEN"
                    End If
                    SQLComm.Parameters.Add("@Application_ID", SqlDbType.Char).Value = " "
                    SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = " "
                    SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = " "
                    SQLComm.Parameters.Add("@Total_Application", SqlDbType.Float).Value = AppRec
                    SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = #1/1/1900#
                    SQLComm.ExecuteNonQuery()
                Else
                End If
                '-----------------------------------------------------------------------

                '------ Update in JobTable ----- with New Job ID ---------------------
                SQLComm.CommandText = ""
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE JOB_ID = '" & ComboBoxNewJobID.Text & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                AppRec = SQLComm.ExecuteScalar
                '----------------------------------- 
                Dim ResumeSource As String
                SQLComm.CommandText = ""
                SQLComm = New SqlCommand("SELECT Resume_Source FROM ApplicationTable WHERE Application_ID = '" & ComboBoxAppID.Text & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                ResumeSource = SQLComm.ExecuteScalar
                '-----------------------------------
                '----------------------------------- 
                Dim GetJoiningDate As Date
                SQLComm.CommandText = ""
                SQLComm = New SqlCommand("SELECT Joining_Date FROM ApplicationTable WHERE Application_ID = '" & ComboBoxAppID.Text & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                GetJoiningDate = SQLComm.ExecuteScalar
                '-------------------------------------------

                SQLComm.Parameters.Clear()
                SQLComm.CommandText = ""
                SQLComm.CommandText = ("UPDATE JobTable SET Job_Status = @Job_Status,Application_ID = @Application_ID, Candidate_Name = @Candidate_Name,Resume_Source=@Resume_Source,Total_Application=@Total_Application,Joining_Date=@Joining_Date Where Job_ID = '" & ComboBoxNewJobID.Text & "'")
                SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OFFERED"
                SQLComm.Parameters.Add("@Application_ID", SqlDbType.Char).Value = ComboBoxAppID.Text
                SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = TextBoxCandidateName.Text
                SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = ResumeSource
                SQLComm.Parameters.Add("@Total_Application", SqlDbType.Float).Value = AppRec
                SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = GetJoiningDate


                SQLComm.ExecuteNonQuery()
                '------------------------------------
                SQLConn.Close()
                SQLComm.Parameters.Clear()
                Dim tempAppID As String
                tempAppID = ComboBoxAppID.Text
                MessageBox.Show("Job ID has been changed Successfully !!!")
                ComboBoxAppID.SelectedIndex = -1
                ComboBoxAppID.Text = tempAppID
                ComboBoxNewJobID.SelectedIndex = -1

            Else

                SQLComm.Parameters.Clear()
                SQLConn.Open()
                SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_ID = @Job_ID, Job_Status = @Job_Status, Job_OpenDate = @Job_OpenDate, Job_Position = @Job_Position,Company1 = @Company1,Job_Category = @Job_Category,Change_Job_ID=@Change_Job_ID,Old_Job_ID=@Old_Job_ID,Last_Modified =@Last_Modified Where Application_ID = '" & ComboBoxAppID.Text & "'")
                SQLComm.Parameters.Add("@Job_ID", SqlDbType.Char).Value = ComboBoxNewJobID.Text
                SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = TextBoxNewJobStatus.Text
                SQLComm.Parameters.Add("@Job_OpenDate", SqlDbType.Date).Value = DateTimePickerOpenDateNew.Value
                SQLComm.Parameters.Add("@Job_Position", SqlDbType.Char).Value = TextBoxNewJobPosition.Text
                SQLComm.Parameters.Add("@Company1", SqlDbType.Char).Value = TextBoxNewCompany.Text
                SQLComm.Parameters.Add("@Job_Category", SqlDbType.Char).Value = TextBoxNewCategory.Text
                SQLComm.Parameters.Add("@Change_Job_ID", SqlDbType.Char).Value = "Yes"
                SQLComm.Parameters.Add("@Old_Job_ID", SqlDbType.Char).Value = ComboBoxOldJobID.Text
                SQLComm.Parameters.Add("@Last_Modified", SqlDbType.DateTime).Value = Date.Now

                SQLComm.ExecuteNonQuery()

                '--------------------------------------------------------------------

                '--------------------------------------------------------------------

                '------ Update in JobTable ----- with New Job ID ---------------------
                Dim AppRec As Integer
                SQLComm.Parameters.Clear()
                SQLComm.CommandText = ""
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE JOB_ID = '" & ComboBoxNewJobID.Text & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                AppRec = SQLComm.ExecuteScalar
                '----------------------------------- 

                '-----------------------------------
                SQLComm.Parameters.Clear()
                SQLComm.CommandText = ("UPDATE JobTable SET Total_Application=@Total_Application Where Job_ID = '" & ComboBoxNewJobID.Text & "'")
                SQLComm.Parameters.Add("@Total_Application", SqlDbType.Float).Value = AppRec
                SQLComm.ExecuteNonQuery()
                '------------------------------------


                '------ Update in JobTable ----- with Old Job ID ---------------------
                SQLComm.Parameters.Clear()
                SQLComm.CommandText = ""
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE JOB_ID = '" & ComboBoxOldJobID.Text & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                AppRec = SQLComm.ExecuteScalar
                '----------------------------------- 

                SQLComm.Parameters.Clear()
                SQLComm.CommandText = ("UPDATE JobTable SET Total_Application=@Total_Application Where Job_ID = '" & ComboBoxOldJobID.Text & "'")
                SQLComm.Parameters.Add("@Total_Application", SqlDbType.Float).Value = AppRec
                SQLComm.ExecuteNonQuery()
                SQLConn.Close()
                '-----------------------------------------------------------------------
                SQLComm.Parameters.Clear()
                Dim tempAppID As String
                tempAppID = ComboBoxAppID.Text
                MessageBox.Show("Job ID has been changed Successfully !!!")
                ComboBoxAppID.SelectedIndex = -1
                ComboBoxAppID.Text = tempAppID
                ComboBoxNewJobID.SelectedIndex = -1

            End If

            SQLConn.Close()
            '----------------------- refresh in datagridview ----------------------------------
            Dim ds1 As New DataSet
            SQLConn.Open()
            SQLComm = New SqlCommand(("Select * from ApplicationTable where Lower(Candidate_Name) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(E_Mail) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Phone) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_Position) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Company1) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_Category) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Recruiter_Name) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Resume_Source) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Decline_Reason) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Comments) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Next_Steps) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Application_ID) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%'"), SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA1 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA1.Fill(ds1)
            DataGridView1.DataSource = ds1.Tables(0)
            SQLConn.Close()
            DataGridView1.DataBindings.Clear()
            SQLComm.Parameters.Clear()
            ConnStr = Nothing
            Label_Found.Text = DataGridView1.RowCount
            SQLConn.Dispose()
            DataGridView1.Sort(DataGridView1.Columns(DataGridView1.ColumnCount - 1), direction:=ListSortDirection.Descending)



        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub

    Private Sub ButtonChangeJobIDClear_Click(sender As Object, e As EventArgs) Handles ButtonChangeJobIDClear.Click

        ComboBoxOldJobID.SelectedIndex = -1
        ComboBoxNewJobID.SelectedIndex = -1

    End Sub

    Private Sub ButtonChangeJobIDClose_Click(sender As Object, e As EventArgs) Handles ButtonChangeJobIDClose.Click
        Me.Close()
        FormMain.btn_ChangeJobID.BackColor = Color.Honeydew

    End Sub


    Private Sub ComboBoxAppID_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAppID.SelectedValueChanged
        '---------------------------- Clear All Dates field ----------------------------------------------

        TextBoxOldApplicationStatus.Text = ""
        TextBoxCandidateName.Text = ""
        TextBoxOldApplicationStatus.Text = ""
        ComboBoxOldJobID.Text = ""
        TextBoxOldJobStatus.Text = ""
        DateTimePickerOpenDateOld.Text = Today()
        TextBoxOldCompanyName.Text = ""
        TextBoxOldJobPosition.Text = ""
        ComboBoxOldRecruiter.Text = ""


        '------------------------------------------------------------------------------------------------
        Try
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DT As New DataTable
            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Application_ID= '" & ComboBoxAppID.Text & "'", SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DT)

            TextBoxCandidateName.DataBindings.Add("Text", DT, "Candidate_Name")
            TextBoxOldApplicationStatus.DataBindings.Add("Text", DT, "Application_Status")
            ComboBoxOldJobID.DataBindings.Add("Text", DT, "Job_ID")
            TextBoxOldJobStatus.DataBindings.Add("Text", DT, "Job_Status")
            DateTimePickerOpenDateOld.DataBindings.Add("Value", DT, "Job_OpenDate")
            TextBoxOldCompanyName.DataBindings.Add("Text", DT, "Company1")
            TextBoxOldJobPosition.DataBindings.Add("Text", DT, "Job_Position")
            ComboBoxOldRecruiter.DataBindings.Add("Text", DT, "Recruiter_Name")

            SQLConn.Close()

            '--------------Clear Data Binding -------------------------------------
            TextBoxCandidateName.DataBindings.Clear()
            TextBoxOldApplicationStatus.DataBindings.Clear()
            ComboBoxOldJobID.DataBindings.Clear()
            TextBoxOldJobStatus.DataBindings.Clear()
            DateTimePickerOpenDateOld.DataBindings.Clear()
            TextBoxOldCompanyName.DataBindings.Clear()
            TextBoxOldJobPosition.DataBindings.Clear()
            ComboBoxOldRecruiter.DataBindings.Clear()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub

    Private Sub txt_Search_TextChanged(sender As Object, e As EventArgs) Handles txt_Search.TextChanged

    End Sub

    Private Sub txt_jobSearch_TextChanged(sender As Object, e As EventArgs) Handles txt_jobSearch.TextChanged

    End Sub

    Private Sub ComboBoxNewJobID_Leave(sender As Object, e As EventArgs) Handles ComboBoxNewJobID.Leave
        '-------- Check If Job ID already exist in database -------------------------
        Try
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.Close()
            SQLConn.Open()
            Dim cmd As String
            cmd = "SELECT Count(*) FROM JobTable Where Job_ID = '" & ComboBoxNewJobID.Text & "'"
            SQLComm.CommandText = cmd
            If ComboBoxNewJobID.Text = "" Then
            ElseIf SQLComm.ExecuteScalar <= 0 Then
                MessageBox.Show("Invalid Job ID !!!.")
                ComboBoxNewJobID.Focus()
                ComboBoxNewJobID.SelectAll()
                SQLConn.Close()
                SQLComm.Parameters.Clear()
                ComboBoxNewJobID.DataBindings.Clear()
                Exit Sub
            Else
                SQLConn.Close()
                ComboBoxChangeNewJobID_SelectedIndexChanged(sender, e)
            End If
            SQLComm.Parameters.Clear()
            SQLConn.Dispose()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
            SQLConn.Dispose()
        End Try
    End Sub

    Private Sub ComboBoxAppID_Leave(sender As Object, e As EventArgs) Handles ComboBoxAppID.Leave

        '-------- Check If Application ID already exist in database -------------------------
        Try
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.Close()
            SQLConn.Open()
            Dim cmd As String
            cmd = "SELECT Count(*) FROM ApplicationTable Where Application_ID = '" & ComboBoxAppID.Text & "'"
            SQLComm.CommandText = cmd
            If ComboBoxAppID.Text = "" Then
            ElseIf SQLComm.ExecuteScalar <= 0 Then
                MessageBox.Show("Invalid Application ID !!!.")
                ComboBoxAppID.Focus()
                ComboBoxAppID.SelectAll()
                SQLConn.Close()
                SQLComm.Parameters.Clear()
                ComboBoxAppID.DataBindings.Clear()
                Exit Sub
            Else
                SQLConn.Close()
                ComboBoxAppID_SelectedIndexChanged(sender, e)
            End If
            SQLComm.Parameters.Clear()
            SQLConn.Dispose()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
            SQLConn.Dispose()
        End Try

    End Sub

    Private Sub Btn_searchApp_Click(sender As Object, e As EventArgs) Handles Btn_searchApp.Click
        Try
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim ds1 As New DataSet
            SQLConn.Open()
            'SQLComm = New SQLCommand("SELECT * FROM ApplicationTable WHERE Candidate_Name LIKE '%" & txt_Search.Text & "%'", SQLConn)
            SQLComm = New SqlCommand(("Select * from ApplicationTable where Lower(Candidate_Name) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(E_Mail) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Phone) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_Position) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Company1) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_Category) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Recruiter_Name) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Resume_Source) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Decline_Reason) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Comments) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Next_Steps) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Application_ID) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%'"), SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA1 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA1.Fill(ds1)
            DataGridView1.DataSource = ds1.Tables(0)
            SQLConn.Close()
            DataGridView1.DataBindings.Clear()
            SQLComm.Parameters.Clear()
            ConnStr = Nothing
            Label_Found.Text = DataGridView1.RowCount
            DataGridView1.Sort(DataGridView1.Columns(DataGridView1.ColumnCount - 1), direction:=ListSortDirection.Descending)
            SQLConn.Dispose()
            txt_Search.Focus()
        Catch ex As Exception
            SQLConn.Close()
        End Try
    End Sub

    Private Sub Btn_searchJob_Click(sender As Object, e As EventArgs) Handles Btn_searchJob.Click
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
            DataGridView3.DataSource = ds2.Tables(0)
            SQLConn.Close()
            DataGridView3.DataBindings.Clear()
            SQLComm.Parameters.Clear()
            ConnStr = Nothing
            Label_jobFound.Text = DataGridView3.RowCount
            DataGridView3.Sort(DataGridView3.Columns(8), direction:=ListSortDirection.Descending)
            SQLConn.Dispose()
            txt_jobSearch.Focus()
        Catch ex As Exception
            SQLConn.Close()
        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub
End Class