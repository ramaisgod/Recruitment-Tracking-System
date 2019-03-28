Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class FormCandidate

    Dim SQLConn As New SqlConnection
    Dim SQLComm As New SqlCommand

    Dim ConnStr As String
    'Dim ConnStr As String = "Data Source=E:\MyProject\IH\InnerHeads\IHDatabase.mdb; Provider=Microsoft.Jet.Oledb.4.0;"

    Private Sub FormCandidate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DS_SQL_JobTable_FormCandidate.JobTable' table. You can move, or remove it, as needed.
        Me.JobTableTableAdapter1.Fill(Me.DS_SQL_JobTable_FormCandidate.JobTable)
        Try
            ProgressBar1.Visible = False
            ProgressBar1.Value = 0
            DateTimePickerScreeningDate_import.Value = Today
            SQLConn.Close()
            'TODO: This line of code loads data into the 'IHDatabaseDataSet2.JobTable' table. You can move, or remove it, as needed.
            'Me.JobTableTableAdapter.Fill(Me.IHDatabaseDataSet2.JobTable)
            DateTimePickerScreeningDate.Value = Today

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
                    Me.ComboBoxJobID.Items.Add(DR("Job_ID"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()
            '----------------------------------------

            '------- Add List Item in Recruiter 
            SQLComm = New SqlCommand("SELECT RecruiterName FROM Recruiter", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            If DR.HasRows = True Then
                While DR.Read()
                    Me.ComboBoxRecruiter2.Items.Add(DR("RecruiterName"))
                    Me.ComboBoxRecruiter2_import.Items.Add(DR("RecruiterName"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()

            '------- Add List Item in ResumeSource
            SQLComm = New SqlCommand("Select Resume_Source from ResumeSource", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader
            If DR.HasRows = True Then
                While DR.Read
                    Me.ComboBoxResumeSource.Items.Add(DR("Resume_Source"))
                    Me.ComboBoxResumeSource_import.Items.Add(DR("Resume_Source"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()

            '------- Add List Item in City
            SQLComm = New SqlCommand("Select CityName from City", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader
            If DR.HasRows = True Then
                While DR.Read
                    Me.ComboBoxLocation.Items.Add(DR("CityName"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()
            SQLConn.Close()

            DataGridView3.Sort(DataGridView3.Columns(6), direction:=ListSortDirection.Descending)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try


    End Sub


    Private Sub txt_jobSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_jobSearch.KeyPress
        Try
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



    Private Sub DataGridView3_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellDoubleClick
        Try
            If TabPage1.Focus = True Then
                ComboBoxJobID.Text = ""
                ComboBoxJobID.DataBindings.Clear()
                ComboBoxJobID.Text = DataGridView3.SelectedCells.Item(0).Value
            Else

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub


    Private Sub ComboBoxJobID_Leave(sender As Object, e As EventArgs) Handles ComboBoxJobID.Leave

        '-------- Check If Job ID already exist in database -------------------------
        Try
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.Close()
            SQLConn.Open()
            Dim cmd As String
            cmd = "SELECT Count(*) FROM JobTable Where Job_ID = '" & ComboBoxJobID.Text & "'"
            SQLComm.CommandText = cmd
            If ComboBoxJobID.Text = "" Then
            ElseIf SQLComm.ExecuteScalar <= 0 Then
                MessageBox.Show("Invalid Job ID !!!.")
                ComboBoxJobID.Focus()
                ComboBoxJobID.SelectAll()
                SQLConn.Close()
                SQLComm.Parameters.Clear()
                ComboBoxJobID.DataBindings.Clear()
                Exit Sub
            Else
                SQLConn.Close()
                ComboBoxJobID_SelectedIndexChanged_1(sender, e)
            End If
            SQLComm.Parameters.Clear()
            SQLConn.Dispose()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
            SQLConn.Dispose()
        End Try

    End Sub

    Private Sub TextBoxEmail_Leave(sender As Object, e As EventArgs) Handles TextBoxEmail.Leave
        '-------- Check If Candidate already exist in database -------------------------
        Try
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString
            SQLConn.Close()
            SQLConn.Open()
            Dim cmd As String
            cmd = "SELECT Count(*) FROM ApplicationTable Where E_Mail <> '' And E_Mail = '" & Trim(TextBoxEmail.Text) & "'"
            SQLComm.CommandText = cmd
            If SQLComm.ExecuteScalar > 0 Then

                Select Case MessageBox.Show("Email ID already exist in Database. Do you want to make duplicate ?", "Warning !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    Case MsgBoxResult.Yes
                    Case MsgBoxResult.Cancel
                        TextBoxEmail.Focus()
                        TextBoxEmail.SelectAll()
                        SQLConn.Close()
                        SQLComm.Parameters.Clear()
                        TextBoxEmail.DataBindings.Clear()
                        Exit Sub
                    Case MsgBoxResult.No
                        TextBoxEmail.Focus()
                        TextBoxEmail.SelectAll()
                        SQLConn.Close()
                        SQLComm.Parameters.Clear()
                        TextBoxEmail.DataBindings.Clear()
                        Exit Sub
                End Select

            Else
                SQLConn.Close()
            End If
            SQLComm.Parameters.Clear()
            SQLConn.Dispose()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
            SQLConn.Dispose()
        End Try

    End Sub

    Private Sub TextBoxMobile_Leave(sender As Object, e As EventArgs) Handles TextBoxMobile.Leave
        '-------- Check If Candidate already exist in database -------------------------
        Try
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString
            SQLConn.Close()
            SQLConn.Open()
            Dim cmd As String
            cmd = "SELECT Count(*) FROM ApplicationTable Where Phone <> '' and Phone = '" & Trim(TextBoxMobile.Text) & "'"
            SQLComm.CommandText = cmd
            If SQLComm.ExecuteScalar > 0 Then

                Select Case MessageBox.Show("Phone number already exist in Database. Do you want to make duplicate ?", "Warning !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    Case MsgBoxResult.Yes
                    Case MsgBoxResult.Cancel
                        TextBoxMobile.Focus()
                        TextBoxMobile.SelectAll()
                        SQLConn.Close()
                        SQLComm.Parameters.Clear()
                        TextBoxMobile.DataBindings.Clear()
                        Exit Sub
                    Case MsgBoxResult.No
                        TextBoxMobile.Focus()
                        TextBoxMobile.SelectAll()
                        SQLConn.Close()
                        SQLComm.Parameters.Clear()
                        TextBoxMobile.DataBindings.Clear()
                        Exit Sub
                End Select

            Else
                SQLConn.Close()
            End If
            SQLComm.Parameters.Clear()
            SQLConn.Dispose()

        Catch ex As Exception
            SQLConn.Dispose()
        End Try
    End Sub

    Private Sub ButtonAddCandidate_Click_1(sender As Object, e As EventArgs) Handles ButtonAddCandidate.Click
        Try
            SQLConn.Close()
            Dim ConnStr As String
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString

            '-------- Check If Candidate already exist in database with same Application ID -------------------------
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()
            Dim cmd, cmd1 As String
            cmd = "SELECT Count(*) FROM ApplicationTable Where Application_ID = '" & Trim(TextBoxApplicationID.Text) & "'"
            SQLComm.CommandText = cmd


            If ComboBoxJobID.Text = "" Then
                MessageBox.Show("Please Select Job ID")
                ComboBoxJobID.Focus()
            ElseIf TextBoxJobStatus.Text <> "OPEN" And TextBoxJobStatus.Text <> "OFFERED" AndAlso TextBoxJobStatus.Text <> "Uncategorized" Then
                MessageBox.Show("Job Status is " & TextBoxJobStatus.Text & " !!!. Please Select another Job ID")
                ComboBoxJobID.Focus()
            ElseIf ComboBoxRecruiter2.Text = "" Then
                MessageBox.Show("Plese select Recruiter Name")
                ComboBoxRecruiter2.Focus()
            ElseIf DateTimePickerOpenDate.Value > DateTimePickerScreeningDate.Value Then
                MessageBox.Show("Please check Job Open Date. Job Open Date must be less than Candidate Screening Date. !!!")
                DateTimePickerScreeningDate.Focus()
                Exit Sub
            ElseIf ComboBoxResumeSource.Text = "" Then
                MessageBox.Show("Plese select Application Source")
                ComboBoxResumeSource.Focus()
            ElseIf TextBoxCandidateName.Text = "" Then
                MessageBox.Show("Plese Enter Candidate Name")
                TextBoxCandidateName.Focus()
            ElseIf TextBoxEmail.Text = "" Then
                MessageBox.Show("Please Enter Candidate Email address")
                TextBoxEmail.Focus()
            ElseIf TextBoxMobile.Text = "" Then
                MessageBox.Show("Plese Enter Phone Number")
                TextBoxMobile.Focus()


            ElseIf SQLComm.ExecuteScalar > 0 Then
                MessageBox.Show("You already added '" & TextBoxCandidateName.Text.Trim() & "' awhile ago. !!!", "Recruitment Tracking System !!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SQLComm.CommandText = ""
                SQLConn.Dispose()
                Exit Sub

            Else
                '-------------------------------------------------------------------------------
                SQLConn.Close()
                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                SQLConn.Open()
                cmd1 = "SELECT Count(*) FROM ApplicationTable Where (Phone = '" & Trim(TextBoxMobile.Text) & "' OR E_Mail = '" & Trim(TextBoxEmail.Text) & "') AND (Company1 = '" & TextBoxCompanyName.Text & "')"
                SQLComm.CommandText = cmd1
                If SQLComm.ExecuteScalar > 0 Then
                    MessageBox.Show("'" & TextBoxCandidateName.Text.Trim() & "' already exist in database with same venture !!!", "Recruitment Tracking System !!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SQLConn.Dispose()
                    Exit Sub

                End If
                '-------------------------------------------------------------------------------

                ' ------ Get Maximum Number from ApplicationTable for New Application ID -------
                SQLConn.Close()
                        SQLComm.CommandText = ""
                        SQLConn.ConnectionString = ConnStr
                        SQLComm.Connection = SQLConn
                        SQLConn.Open()
                        Dim DR As SqlDataReader
                        Dim newNumber As Integer
                        Dim FirstName As String
                        cmd = "SELECT MAX(S_NO) AS MAXIMUM FROM ApplicationTable"
                        SQLComm.CommandText = cmd
                        DR = SQLComm.ExecuteReader
                        If DR.HasRows Then
                            While DR.Read()
                                TextBoxApplicationID.Text = DR("MAXIMUM").ToString
                                newNumber = CInt(Val(TextBoxApplicationID.Text))
                                FirstName = ComboBoxRecruiter2.Text.Substring(0, 2) & "-"
                                TextBoxApplicationID.Text = FirstName.ToUpper & CStr(newNumber) + 1
                            End While
                        End If
                        SQLConn.Close()

                        SQLConn.ConnectionString = ConnStr
                        SQLComm.Connection = SQLConn
                        SQLConn.Open()
                        SQLComm.CommandText = ""
                        'SQLComm.CommandText = "INSERT INTO ApplicationTable(S_NO,Job_ID,Job_Status,Job_OpenDate,Job_Position,Job_Category,Application_ID,Application_Status,Recruiter_Name,Candidate_Name,E_Mail,Phone,Location,Resume_Source,Experience,Screening,Screening_Date,Elapsed_Time,Application_Stage,Change_Job_ID) VALUES(@S_NO,@Job_ID,@Job_Status,@Job_OpenDate,@Job_Position,@Job_Category,@Application_ID,@Application_Status,@Recruiter_Name,@Candidate_Name,@E_Mail,@Phone,@Location,@Resume_Source,@Experience,@Screening,@Screening_Date,@Elapsed_Time,@Application_Stage,@Change_Job_ID)"

                        SQLComm.CommandText = "INSERT INTO ApplicationTable(S_NO,Job_ID,Job_Status,Job_OpenDate,Job_Position,Job_Category,Application_ID,Application_Status,Recruiter_Name,Candidate_Name,E_Mail,Phone,Location,Resume_Source,Experience,Screening,Screening_Date,Shared,Shared_Date,Interview,Interview_Date,Invited,Invited_Date,Visited,Visited_Date,Visit_Cost,Offer,Offer_Date,Offer_Accepted,Offer_Accepted_Date,Offer_Status,Joining,Joining_Date,Rejected,Elapsed_Time,Application_Stage,Change_Job_ID,Old_Job_ID,Decline_Reason,Rejected_By,Company1,Last_Modified) VALUES(@S_NO,@Job_ID,@Job_Status,@Job_OpenDate,@Job_Position,@Job_Category,@Application_ID,@Application_Status,@Recruiter_Name,@Candidate_Name,@E_Mail,@Phone,@Location,@Resume_Source,@Experience,@Screening,@Screening_Date,@Shared,@Shared_Date,@Interview,@Interview_Date,@Invited,@Invited_Date,@Visited,@Visited_Date,@Visit_Cost,@Offer,@Offer_Date,@Offer_Accepted,@Offer_Accepted_Date,@Offer_Status,@Joining,@Joining_Date,@Rejected,@Elapsed_Time,@Application_Stage,@Change_Job_ID,@Old_Job_ID,@Decline_Reason,@Rejected_By,@Company1,@Last_Modified)"

                        SQLComm.Parameters.AddWithValue("S_NO", CStr(newNumber) + 1)
                        SQLComm.Parameters.AddWithValue("Job_ID", ComboBoxJobID.Text)
                        SQLComm.Parameters.AddWithValue("Job_Status", TextBoxJobStatus.Text)
                SQLComm.Parameters.AddWithValue("Job_OpenDate", DateTimePickerOpenDate.Value)
                SQLComm.Parameters.AddWithValue("Job_Position", TextBoxJobPosition.Text)
                SQLComm.Parameters.AddWithValue("Job_Category", TextBoxJobCategory.Text)
                SQLComm.Parameters.AddWithValue("Application_ID", TextBoxApplicationID.Text)
                SQLComm.Parameters.AddWithValue("Application_Status", "SCREENED")
                SQLComm.Parameters.AddWithValue("Recruiter_Name", ComboBoxRecruiter2.Text)
                'SQLComm.Parameters.AddWithValue("Candidate_Name", Trim(TextBoxCandidateName.Text))
                SQLComm.Parameters.AddWithValue("Candidate_Name", StrConv(Trim(TextBoxCandidateName.Text), VbStrConv.ProperCase))
                SQLComm.Parameters.AddWithValue("E_Mail", If(String.IsNullOrWhiteSpace(Trim(TextBoxEmail.Text)), DBNull.Value, Trim(TextBoxEmail.Text)))
                SQLComm.Parameters.AddWithValue("Phone", If(String.IsNullOrWhiteSpace(Trim(TextBoxMobile.Text)), DBNull.Value, Trim(TextBoxMobile.Text)))
                SQLComm.Parameters.AddWithValue("Location", If(String.IsNullOrWhiteSpace(Trim(ComboBoxLocation.Text)), DBNull.Value, Trim(ComboBoxLocation.Text)))
                SQLComm.Parameters.AddWithValue("Resume_Source", ComboBoxResumeSource.Text)
                SQLComm.Parameters.AddWithValue("Experience", If(String.IsNullOrWhiteSpace(TextBoxExperience.Text.Trim()), DBNull.Value, TextBoxExperience.Text.Trim()))
                SQLComm.Parameters.AddWithValue("Screening", "Yes")
                SQLComm.Parameters.AddWithValue("Screening_Date", DateTimePickerScreeningDate.Value.Date)
                SQLComm.Parameters.AddWithValue("Shared", "No")
                SQLComm.Parameters.AddWithValue("Shared_Date", #1/1/1900#)
                SQLComm.Parameters.AddWithValue("Interview", "No")
                SQLComm.Parameters.AddWithValue("Interview_Date", #1/1/1900#)
                SQLComm.Parameters.AddWithValue("Invited", "No")
                SQLComm.Parameters.AddWithValue("Invited_Date", #1/1/1900#)
                SQLComm.Parameters.AddWithValue("Visited", "No")
                SQLComm.Parameters.AddWithValue("Visited_Date", #1/1/1900#)
                SQLComm.Parameters.AddWithValue("Visit_Cost", "0")
                SQLComm.Parameters.AddWithValue("Offer", "No")
                SQLComm.Parameters.AddWithValue("Offer_Date", #1/1/1900#)
                SQLComm.Parameters.AddWithValue("Offer_Accepted", "No")
                SQLComm.Parameters.AddWithValue("Offer_Accepted_Date", #1/1/1900#)
                SQLComm.Parameters.AddWithValue("Offer_Status", "NA")
                SQLComm.Parameters.AddWithValue("Joining", "No")
                SQLComm.Parameters.AddWithValue("Joining_Date", #1/1/1900#)
                SQLComm.Parameters.AddWithValue("Rejected", "No")
                SQLComm.Parameters.AddWithValue("Elapsed_Time", (DateTime.Now).Subtract(DateTimePickerOpenDate.Value).Days + 1)
                SQLComm.Parameters.AddWithValue("Application_Stage", "SCREENING")
                SQLComm.Parameters.AddWithValue("Change_Job_ID", "No")
                SQLComm.Parameters.AddWithValue("Old_Job_ID", "NA")
                SQLComm.Parameters.AddWithValue("Decline_Reason", "NA")
                SQLComm.Parameters.AddWithValue("Rejected_By", "NA")
                SQLComm.Parameters.AddWithValue("@Company1", TextBoxCompanyName.Text)
                SQLComm.Parameters.AddWithValue("@Last_Modified", Date.Now)
                SQLComm.ExecuteNonQuery()
                SQLConn.Close()
                SQLComm.Parameters.Clear()
                TextBoxApplicationStatus.Text = "SCREENED"
                MessageBox.Show("Saved !!!")

                '------ Count of Total No. of Application Received and Update in JobTable ---------------------

                Dim AppRec As Integer
                SQLConn.Open()
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE JOB_ID= '" & ComboBoxJobID.Text & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                AppRec = SQLComm.ExecuteScalar
                SQLComm.CommandText = ("UPDATE JobTable SET Total_Application = @Total_Application Where Job_ID = '" & ComboBoxJobID.Text & "'")
                SQLComm.Parameters.Add("@Total_Application", SqlDbType.Int).Value = AppRec
                SQLComm.ExecuteNonQuery()
                SQLConn.Close()
                SQLComm.Parameters.Clear()
            End If
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
            SQLConn.Dispose()
            SQLComm.Dispose()
        End Try

    End Sub

    Private Sub ComboBoxJobID_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBoxJobID.SelectedIndexChanged
        '------------------ Clear Fields ----------------------------------------
        TextBoxJobStatus.Text = ""
        TextBoxJobPosition.Text = ""
        TextBoxCompanyName.Text = ""
        ComboBoxRecruiter2.Text = ""
        ComboBoxRecruiter2.SelectedIndex = -1
        TextBoxJobCategory.Text = ""
        TextBoxApplicationID.Text = ""
        TextBoxApplicationStatus.Text = "SCREENED"
        ComboBoxResumeSource.Text = ""
        TextBoxCandidateName.Text = ""
        TextBoxEmail.Text = ""
        TextBoxMobile.Text = ""
        ComboBoxLocation.Text = ""
        TextBoxExperience.Text = ""

        '------------------------------------------------------------------------
        Try
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DT As New DataTable

            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE JOB_ID= '" & ComboBoxJobID.Text & "'", SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DT)
            TextBoxJobStatus.DataBindings.Add("Text", DT, "Job_Status")
            DateTimePickerOpenDate.DataBindings.Add("Text", DT, "Open_Date")
            TextBoxJobPosition.DataBindings.Add("Text", DT, "Job_Position")
            TextBoxCompanyName.DataBindings.Add("Text", DT, "Company1")
            TextBoxJobCategory.DataBindings.Add("Text", DT, "Category")
            ComboBoxRecruiter2.DataBindings.Add("Text", DT, "Recruiter")
            SQLConn.Close()

            TextBoxJobStatus.DataBindings.Clear()
            DateTimePickerOpenDate.DataBindings.Clear()
            TextBoxJobPosition.DataBindings.Clear()
            TextBoxCompanyName.DataBindings.Clear()
            TextBoxJobCategory.DataBindings.Clear()
            ComboBoxRecruiter2.DataBindings.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
        FormMain.btn_newcandidate.BackColor = Color.Honeydew
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        TextBoxApplicationID.Text = ""
        TextBoxApplicationStatus.Text = ""
        ComboBoxResumeSource.Text = ""
        TextBoxCandidateName.Text = ""
        TextBoxEmail.Text = ""
        TextBoxMobile.Text = ""
        ComboBoxLocation.Text = ""
        TextBoxExperience.Text = ""
        DateTimePickerScreeningDate.Value = Today
    End Sub

    Private Sub ButtonClearAll_Click_1(sender As Object, e As EventArgs) Handles ButtonClearAll.Click
        ComboBoxJobID.Text = ""
        TextBoxJobStatus.Text = ""
        TextBoxJobPosition.Text = ""
        TextBoxCompanyName.Text = ""
        ComboBoxRecruiter2.Text = ""
        TextBoxJobCategory.Text = ""
        TextBoxApplicationID.Text = ""
        TextBoxApplicationStatus.Text = ""
        ComboBoxResumeSource.Text = ""
        TextBoxCandidateName.Text = ""
        TextBoxEmail.Text = ""
        TextBoxMobile.Text = ""
        ComboBoxLocation.Text = ""
        TextBoxExperience.Text = ""
        DateTimePickerScreeningDate.Value = Today
    End Sub

    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles ButtonFileBrowse.Click
        Try
            Using FileDialog As New OpenFileDialog
                FileDialog.Title = "Select Excel File"
                FileDialog.Filter = "All Excel Files|*.xls;*.xlsx;*.xlsb;*.xlsm"

                If FileDialog.ShowDialog() <> DialogResult.OK Then
                    txtFilePath.Text = "Not Selected"
                    Exit Sub
                Else
                    txtFilePath.Text = FileDialog.FileName
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonAdd_Import_Click(sender As Object, e As EventArgs) Handles ButtonAdd_Import.Click
        'On Error Resume Next

        Try
            'If ComboBoxJobID_import.Text = "" Then
            '    MessageBox.Show("Please Select Job ID")
            '    ComboBoxJobID_import.Focus()
            'ElseIf TextBoxJobStatus_import.Text <> "OPEN" And TextBoxJobStatus_import.Text <> "OFFERED" AndAlso TextBoxJobStatus_import.Text <> "Uncategorized" Then
            '    MessageBox.Show("Job Status is " & TextBoxJobStatus_import.Text & " !!!. Please Select another Job ID")
            '    ComboBoxJobID_import.Focus()
            If ComboBoxRecruiter2_import.Text = "" Then
                MessageBox.Show("Plese select Recruiter Name")
                ComboBoxRecruiter2_import.Focus()
            ElseIf ComboBoxResumeSource_import.Text = "" Then
                MessageBox.Show("Plese select Application Source")
                ComboBoxResumeSource_import.Focus()
            ElseIf txtFilePath.Text = "Not Selected" Then
                MessageBox.Show("File Not Found. Please select Excel File. !!!")
                ButtonFileBrowse.Focus()
            Else
                Dim Excel As New Microsoft.Office.Interop.Excel.Application
                Dim misValue = System.Reflection.Missing.Value
                Excel.ScreenUpdating = False
                Excel.DisplayAlerts = False
                Dim rng As Microsoft.Office.Interop.Excel.Range
                Dim cell As Microsoft.Office.Interop.Excel.Range
                Excel.Workbooks.Open(txtFilePath.Text)
                Excel.ActiveWorkbook.Sheets(1).Activate

                If Excel.ActiveWorkbook.Sheets(1).Range("A1").Value = "Job_ID" And Excel.ActiveWorkbook.Sheets(1).Range("B1").Value = "Candidate_Name" And Excel.ActiveWorkbook.Sheets(1).Range("C1").Value = "Phone" And Excel.ActiveWorkbook.Sheets(1).Range("D1").Value = "E_Mail" Then
                Else
                    MessageBox.Show("Selected Excel File is Incorrect. Kindly select correct Excel File !!!.")
                    'Excel.Visible = True
                    Excel.ScreenUpdating = True
                    Excel.DisplayAlerts = True
                    rng = Nothing
                    cell = Nothing

                    Excel.ActiveWorkbook.Close(False, misValue, misValue)
                    Excel.Quit()
                    'Excel.Visible = False

                    ' Excel = Nothing
                    releaseObject(Excel)
                    releaseObject(rng)
                    releaseObject(cell)
                    releaseObject(misValue)
                    GC.Collect()
                    Excel = Nothing

                    Exit Sub
                End If

                Dim LastRow As Integer = Excel.ActiveSheet.UsedRange.Rows.Count
                If LastRow <= 1 Then
                    ProgressBar1.Visible = False

                    MessageBox.Show("Data not found in attached Excel Sheet.")
                    'Excel.Visible = True
                    Excel.ScreenUpdating = True
                    Excel.DisplayAlerts = True
                    rng = Nothing
                    cell = Nothing
                    'Excel.ActiveWorkbook.Close(False, misValue, misValue)
                    'Excel.Quit()
                    'Excel.Visible = False
                    releaseObject(Excel)
                    releaseObject(rng)
                    releaseObject(cell)
                    releaseObject(misValue)
                    GC.Collect()
                    Excel = Nothing
                    Exit Sub
                Else
                End If

                Excel.Visible = False

                Excel.ActiveWorkbook.Sheets(1).Range("H1").Value = "Import_Status"
                Excel.ActiveWorkbook.Sheets(1).Range("H1").Interior.Color = Color.LightCyan
                Excel.ActiveWorkbook.Sheets(1).Range("H1").Font.Bold = True
                Excel.ActiveWorkbook.Sheets(1).Range("H1").EntireColumn.AutoFit()
                Excel.ActiveWorkbook.Sheets(1).Range("H1").ColumnWidth = 30

                rng = Excel.ActiveWorkbook.Sheets(1).Range("A2:A" & LastRow)

                Dim countrow As Integer = 0
                Dim ConnStr As String
                Dim cmd As Integer
                ProgressBar1.Visible = True
                Dim AppRec As Integer

                For Each cell In rng
                    ''-------- Check If Candidate already exist in database -------------------------
                    SQLConn.Dispose()
                    ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                    SQLConn.ConnectionString = ConnStr
                    SQLComm.Connection = SQLConn
                    SQLConn.Open()
                    SQLComm = New SqlCommand("SELECT Job_Status FROM JobTable Where Job_ID = '" & Trim(cell.Value) & "'", SQLConn)
                    If String.IsNullOrEmpty(SQLComm.ExecuteScalar) Then
                        cell.Offset(0, 7).Value = "Job ID Not Exist"
                        cell.Offset(0, 7).Interior.Color = Color.Red
                    ElseIf SQLComm.ExecuteScalar <> "OPEN" And SQLComm.ExecuteScalar <> "OFFERED" AndAlso SQLComm.ExecuteScalar <> "Uncategorized" Then
                        cell.Offset(0, 7).Value = "Job Status is '" & SQLComm.ExecuteScalar & "'"
                        cell.Offset(0, 7).Interior.Color = Color.Red
                    Else

                        If String.IsNullOrEmpty(cell.Value) Then
                            SQLComm.CommandText = ""
                            cmd = -1
                        ElseIf String.IsNullOrEmpty(cell.Offset(0, 1).Value) Then
                            SQLComm.CommandText = ""
                            cmd = -1
                        ElseIf String.IsNullOrEmpty(cell.Offset(0, 2).Value) AndAlso String.IsNullOrEmpty(cell.Offset(0, 3).Value) Then
                            SQLComm.CommandText = ""
                            cmd = -1
                        ElseIf String.IsNullOrEmpty(cell.Offset(0, 3).Value) AndAlso Not String.IsNullOrEmpty(cell.Offset(0, 2).Value) Then
                            SQLComm.CommandText = ""
                            SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable Where Phone = '" & Trim(cell.Offset(0, 2).Value) & "'", SQLConn)
                            cmd = SQLComm.ExecuteScalar
                        ElseIf String.IsNullOrEmpty(cell.Offset(0, 2).Value) AndAlso Not String.IsNullOrEmpty(cell.Offset(0, 3).Value) Then
                            SQLComm.CommandText = ""
                            SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable Where E_Mail = '" & Trim(cell.Offset(0, 3).Value) & "'", SQLConn)
                            cmd = SQLComm.ExecuteScalar
                        ElseIf Not String.IsNullOrEmpty(cell.Offset(0, 2).Value) AndAlso Not String.IsNullOrEmpty(cell.Offset(0, 3).Value) Then
                            SQLComm.CommandText = ""
                            SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable Where E_Mail = '" & Trim(cell.Offset(0, 3).Value) & "' OR Phone = '" & Trim(cell.Offset(0, 2).Value) & "'", SQLConn)
                            cmd = SQLComm.ExecuteScalar
                        Else
                            cmd = -1
                        End If


                        If cmd < 0 Then '
                            cell.Offset(0, 7).Value = "Failed"
                            cell.Offset(0, 7).Interior.Color = Color.Red
                        ElseIf cmd > 0 Then
                            cell.Offset(0, 7).Value = "Already Exist"
                            cell.Offset(0, 7).Interior.Color = Color.Orange

                        Else

                            SQLComm.Parameters.Clear()
                            ' ------ Get Maximum Number from ApplicationTable for New Application ID -------
                            SQLComm.CommandText = ""
                            Dim DR As SqlDataReader
                            Dim newNumber As Integer
                            Dim FirstName As String

                            SQLComm.CommandText = "SELECT MAX(S_NO) AS MAXIMUM FROM ApplicationTable"
                            DR = SQLComm.ExecuteReader
                            If DR.HasRows Then
                                While DR.Read()
                                    TextBoxApplicationID_import.Text = DR("MAXIMUM").ToString
                                    newNumber = CInt(Val(TextBoxApplicationID_import.Text))
                                    FirstName = ComboBoxRecruiter2_import.Text.Substring(0, 2) & "-"
                                    TextBoxApplicationID_import.Text = FirstName.ToUpper & CStr(newNumber) + 1
                                End While
                            End If
                            DR.Close()

                            SQLComm.CommandText = ""

                            SQLComm.CommandText = "INSERT INTO ApplicationTable(S_NO,Job_ID,Job_Status,Job_OpenDate,Job_Position,Job_Category,Application_ID,Application_Status,Recruiter_Name,Candidate_Name,E_Mail,Phone,Location,Resume_Source,Experience,Screening,Screening_Date,Shared,Shared_Date,Interview,Interview_Date,Invited,Invited_Date,Visited,Visited_Date,Visit_Cost,Offer,Offer_Date,Offer_Accepted,Offer_Accepted_Date,Offer_Status,Joining,Joining_Date,Rejected,Elapsed_Time,Application_Stage,Change_Job_ID,Old_Job_ID,Decline_Reason,Rejected_By,Company1,Current_CTC,Last_Modified) VALUES(@S_NO,@Job_ID,@Job_Status,@Job_OpenDate,@Job_Position,@Job_Category,@Application_ID,@Application_Status,@Recruiter_Name,@Candidate_Name,@E_Mail,@Phone,@Location,@Resume_Source,@Experience,@Screening,@Screening_Date,@Shared,@Shared_Date,@Interview,@Interview_Date,@Invited,@Invited_Date,@Visited,@Visited_Date,@Visit_Cost,@Offer,@Offer_Date,@Offer_Accepted,@Offer_Accepted_Date,@Offer_Status,@Joining,@Joining_Date,@Rejected,@Elapsed_Time,@Application_Stage,@Change_Job_ID,@Old_Job_ID,@Decline_Reason,@Rejected_By,@Company1,@Current_CTC,@Last_Modified)"

                            SQLComm.Parameters.AddWithValue("S_NO", CStr(newNumber) + 1)
                            SQLComm.Parameters.AddWithValue("Job_ID", Trim(cell.Value))
                            SQLComm.Parameters.AddWithValue("Job_Status", New SqlCommand("SELECT Job_Status FROM JobTable Where Job_ID = '" & Trim(cell.Value) & "'", SQLConn).ExecuteScalar)
                            SQLComm.Parameters.AddWithValue("Job_OpenDate", New SqlCommand("SELECT Open_Date FROM JobTable Where Job_ID = '" & Trim(cell.Value) & "'", SQLConn).ExecuteScalar)
                            SQLComm.Parameters.AddWithValue("Job_Position", New SqlCommand("SELECT Job_Position FROM JobTable Where Job_ID = '" & Trim(cell.Value) & "'", SQLConn).ExecuteScalar)
                            SQLComm.Parameters.AddWithValue("Job_Category", New SqlCommand("SELECT Category FROM JobTable Where Job_ID = '" & Trim(cell.Value) & "'", SQLConn).ExecuteScalar)
                            SQLComm.Parameters.AddWithValue("Application_ID", TextBoxApplicationID_import.Text)
                            SQLComm.Parameters.AddWithValue("Application_Status", "SCREENED")
                            SQLComm.Parameters.AddWithValue("Recruiter_Name", ComboBoxRecruiter2_import.Text)
                            SQLComm.Parameters.AddWithValue("Candidate_Name", Trim(cell.Offset(0, 1).Value))

                            SQLComm.Parameters.AddWithValue("E_Mail", If(String.IsNullOrEmpty(Trim(cell.Offset(0, 3).Value)), DBNull.Value, Trim(cell.Offset(0, 3).Value)))
                            SQLComm.Parameters.AddWithValue("Phone", If(String.IsNullOrEmpty(Trim((cell.Offset(0, 2).Value))), DBNull.Value, Trim(cell.Offset(0, 2).Value)))
                            SQLComm.Parameters.AddWithValue("Location", If(String.IsNullOrEmpty(Trim(cell.Offset(0, 5).Value)), DBNull.Value, Trim(cell.Offset(0, 5).Value)))

                            SQLComm.Parameters.AddWithValue("Resume_Source", ComboBoxResumeSource_import.Text)

                            SQLComm.Parameters.AddWithValue("Experience", If(String.IsNullOrEmpty(Trim(cell.Offset(0, 4).Value)), DBNull.Value, Trim(cell.Offset(0, 4).Value)))

                            SQLComm.Parameters.AddWithValue("Screening", "Yes")
                            SQLComm.Parameters.AddWithValue("Screening_Date", DateTimePickerScreeningDate_import.Value.Date)
                            SQLComm.Parameters.AddWithValue("Shared", "No")
                            SQLComm.Parameters.AddWithValue("Shared_Date", #1/1/1900#)
                            SQLComm.Parameters.AddWithValue("Interview", "No")
                            SQLComm.Parameters.AddWithValue("Interview_Date", #1/1/1900#)
                            SQLComm.Parameters.AddWithValue("Invited", "No")
                            SQLComm.Parameters.AddWithValue("Invited_Date", #1/1/1900#)
                            SQLComm.Parameters.AddWithValue("Visited", "No")
                            SQLComm.Parameters.AddWithValue("Visited_Date", #1/1/1900#)
                            SQLComm.Parameters.AddWithValue("Visit_Cost", "0")
                            SQLComm.Parameters.AddWithValue("Offer", "No")
                            SQLComm.Parameters.AddWithValue("Offer_Date", #1/1/1900#)
                            SQLComm.Parameters.AddWithValue("Offer_Accepted", "No")
                            SQLComm.Parameters.AddWithValue("Offer_Accepted_Date", #1/1/1900#)
                            SQLComm.Parameters.AddWithValue("Offer_Status", "NA")
                            SQLComm.Parameters.AddWithValue("Joining", "No")
                            SQLComm.Parameters.AddWithValue("Joining_Date", #1/1/1900#)
                            SQLComm.Parameters.AddWithValue("Rejected", "No")
                            SQLComm.Parameters.AddWithValue("Elapsed_Time", (DateTime.Now).Subtract((New SqlCommand("SELECT Open_Date FROM JobTable Where Job_ID = '" & Trim(cell.Value) & "'", SQLConn).ExecuteScalar)).Days + 1)
                            SQLComm.Parameters.AddWithValue("Application_Stage", "SCREENING")
                            SQLComm.Parameters.AddWithValue("Change_Job_ID", "No")
                            SQLComm.Parameters.AddWithValue("Old_Job_ID", "NA")
                            SQLComm.Parameters.AddWithValue("Decline_Reason", "NA")
                            SQLComm.Parameters.AddWithValue("Rejected_By", "NA")
                            SQLComm.Parameters.AddWithValue("@Company1", New SqlCommand("SELECT Company1 FROM JobTable Where Job_ID = '" & Trim(cell.Value) & "'", SQLConn).ExecuteScalar)

                            SQLComm.Parameters.AddWithValue("Current_CTC", If(String.IsNullOrEmpty(Trim(cell.Offset(0, 6).Value)), DBNull.Value, Trim(cell.Offset(0, 6).Value).ToString))
                            SQLComm.Parameters.AddWithValue("Last_Modified", Date.Now)

                            SQLComm.ExecuteNonQuery()
                            SQLConn.Close()
                            SQLComm.Parameters.Clear()
                            cell.Offset(0, 7).Value = "Success"
                            cell.Offset(0, 7).Interior.Color = Color.LightGreen
                            countrow = countrow + 1
                        End If
                        SQLConn.Close()
                        ProgressBar1.Value = ProgressBar1.Value + 1
                        ProgressBar1.Maximum = rng.Rows.Count
                        ProgressBar1.Step = rng.Rows.Count / ProgressBar1.Value
                    End If

                    '------ Count of Total No. of Application Received and Update in JobTable ---------------------
                    SQLConn.Close()
                    SQLConn.Open()
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE JOB_ID= '" & Trim(cell.Value) & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    AppRec = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ("UPDATE JobTable SET Total_Application = @Total_Application Where Job_ID = '" & Trim(cell.Value) & "'")
                    SQLComm.Parameters.Add("@Total_Application", SqlDbType.Int).Value = AppRec
                    SQLComm.ExecuteNonQuery()
                    SQLConn.Close()
                    SQLConn.Dispose()
                    SQLComm.Parameters.Clear()
                Next cell

                ProgressBar1.Value = 0
                ProgressBar1.Visible = False

                MessageBox.Show(countrow & " rows Successfully Imported !!!")
                Excel.Visible = True
                Excel.UserControl = True
                Excel.ScreenUpdating = True
                Excel.DisplayAlerts = True
                rng = Nothing
                cell = Nothing
                releaseObject(Excel)
                releaseObject(rng)
                releaseObject(cell)
                releaseObject(misValue)
                GC.Collect()
                Excel = Nothing
                'Excel.ActiveWorkbook.Close(False, misValue, misValue)
                'Excel.Quit()

            End If

            SQLConn.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
        End Try

    End Sub


    Private Sub releaseObject(ByVal obj As Object)
        'Try
        '    Dim intRel As Integer = 0
        '    Do
        '        intRel = System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
        '    Loop While intRel > 0
        '    MsgBox("Final Released obj # " & intRel)
        'Catch ex As Exception
        '    MsgBox("Error releasing object" & ex.ToString)
        '    obj = Nothing
        'Finally
        '    GC.Collect()
        'End Try

        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()

        End Try

    End Sub

    Private Sub ButtonClear_Import_Click(sender As Object, e As EventArgs) Handles ButtonClear_Import.Click
        TextBoxApplicationID_import.Text = ""
        TextBoxApplicationStatus_import.Text = ""
        ComboBoxResumeSource_import.SelectedIndex = -1
        ComboBoxRecruiter2_import.SelectedIndex = -1
        DateTimePickerScreeningDate_import.Value = Date.Today
        txtFilePath.Text = "Not Selected"

    End Sub

    Private Sub ButtonClose_Import_Click(sender As Object, e As EventArgs) Handles ButtonClose_Import.Click
        Me.Close()
        FormMain.btn_newcandidate.BackColor = Color.Honeydew
    End Sub


    Private Sub ButtonDownloadFormat_Click(sender As Object, e As EventArgs) Handles ButtonDownloadFormat.Click
        Try
            Dim Excel As New Microsoft.Office.Interop.Excel.Application
            Excel.Visible = True
            Excel.UserControl = True
            Excel.Workbooks.Add()
            Excel.Cells.Font.Name = "Arial"

            With Excel.ActiveWorkbook.Sheets(1)
                .Range("A1:G1").Interior.Color = Color.LightCyan
                .Range("A1:G1").Font.Bold = True
                .Range("A1:G1").EntireColumn.AutoFit()
                .Range("B1:C1").ColumnWidth = 25
                .Range("D1").ColumnWidth = 35
                .Range("E1:G1").ColumnWidth = 20

                .Range("A1").Value = "Job_ID"
                .Range("B1").Value = "Candidate_Name"
                .Range("C1").Value = "Phone"
                .Range("D1").Value = "E_Mail"
                .Range("E1").Value = "Experience"
                .Range("F1").Value = "Location"
                .Range("G1").Value = "Current_CTC"
            End With
            Excel.ActiveWorkbook.Sheets(1).Activate
            Excel = Nothing
            releaseObject(Excel)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Btn_search_Click(sender As Object, e As EventArgs) Handles Btn_search.Click
        Try
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
