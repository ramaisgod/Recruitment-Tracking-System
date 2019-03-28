Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports Microsoft.Office.Interop

Public Class FormApplications
    Dim SQLConn As New SqlConnection
    Dim SQLComm As New SqlCommand

    Private Sub Applications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DS_ApplicationTable_SQL.ApplicationTable' table. You can move, or remove it, as needed.
        'Me.ApplicationTableTableAdapter1.Fill(Me.DS_ApplicationTable_SQL.ApplicationTable)
        'TODO: This line of code loads data into the 'IHDatabaseDataSet3.ApplicationTable' table. You can move, or remove it, as needed.
        Try

            DateRangeFrom.Value = Today
            DateRangeTo.Value = Today
            DateRange.Checked = False
            DateRangeALL.Checked = True
            Dim ConnStr As String

            applicationsCount.Text = DataGridView3.Rows.Count
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()
            Dim DR As SqlDataReader
            '------- Add List Item in Recruiter 
            SQLComm = New SqlCommand("SELECT RecruiterName FROM Recruiter", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            Me.SearchByRecruiter.Items.Add("ALL")
            If DR.HasRows = True Then
                While DR.Read()
                    Me.SearchByRecruiter.Items.Add(DR("RecruiterName"))
                End While
                DR.Close()
            End If

            '------- Add List Item in Company 
            SQLComm = New SqlCommand("SELECT CompanyName FROM CompanyList", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            Me.SearchByCompany.Items.Add("ALL")
            If DR.HasRows = True Then
                While DR.Read()
                    Me.SearchByCompany.Items.Add(DR("CompanyName"))
                End While
                DR.Close()
            End If

            '------- Add List Item in Positions
            SQLComm = New SqlCommand("SELECT DISTINCT Job_Position FROM JobTable", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            Me.SearchByJobPosition.Items.Add("ALL")
            If DR.HasRows = True Then
                While DR.Read()
                    Me.SearchByJobPosition.Items.Add(DR("Job_Position"))
                End While
                DR.Close()
            End If
            '------- Add List Item in Job ID
            SQLComm = New SqlCommand("SELECT Job_ID FROM JobTable", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            Me.SearchByJobID.Items.Add("ALL")
            If DR.HasRows = True Then
                While DR.Read()
                    Me.SearchByJobID.Items.Add(DR("Job_ID"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()
            '----------------------------------------
            '------- Add List Item in Next Steps
            SQLComm = New SqlCommand("SELECT DISTINCT Next_Steps FROM NextSteps", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            Me.SearchByNextSteps.Items.Add("ALL")
            Me.ComboBoxNextSteps.Items.Add("")
            If DR.HasRows = True Then
                While DR.Read()
                    Me.SearchByNextSteps.Items.Add(DR("Next_Steps"))
                    Me.ComboBoxNextSteps.Items.Add(DR("Next_Steps"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()
            '----------------------------------------
            '------- Add List Item in FY
            SQLComm = New SqlCommand("SELECT FY_Name FROM FY", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            Me.ComboBoxFY.Items.Add("ALL")
            If DR.HasRows = True Then
                While DR.Read()
                    Me.ComboBoxFY.Items.Add(DR("FY_Name"))
                End While
            End If
            SQLComm.ResetCommandTimeout()
            DR.Close()
            '----------------------------------------
            '------- Add Set Current FY in FY Box
            'ComboBoxFY.SelectedIndex = 0
            SQLComm = New SqlCommand("SELECT FY_Name FROM FY Where SetCurrent = 'Yes'", SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DT As New DataTable
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DT)
            ComboBoxFY.DataBindings.Add("Text", DT, "FY_Name")
            SQLConn.Close()
            SQLConn.Dispose()
            ComboBoxFY.DataBindings.Clear()
            '--------------------------------------------
            SQLConn.Close()
            SearchByRecruiter.Text = FormTop.ComboBoxAppDetailsRecruiter.Text

            DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
        End Try
    End Sub

    Private Sub Button_All_ShowAll_Click(sender As Object, e As EventArgs) Handles Button_All_ShowAll.Click
        Try

            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = Color.Honeydew
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            Dim DS As New DataSet
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            'SQLConn.Open()
            SQLConn.Close()
            If SearchByRecruiter.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & SearchByRecruiter.Text & "'", SQLConn)
                    End If
                Else

                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Recruiter_Name = '" & SearchByRecruiter.Text & "' AND (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByCompany.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "'", SQLConn)
                    End If
                Else
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Company1 = '" & SearchByCompany.Text & "' AND (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn

                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobPosition.Enabled = True Then

                If DateRangeALL.Checked = True Then
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_Position = " & "'" & SearchByJobPosition.Text & "'", SQLConn)
                    End If
                Else
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Job_Position = '" & SearchByJobPosition.Text & "' AND (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn

                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobID.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_ID = " & "'" & SearchByJobID.Text & "'", SQLConn)
                    End If
                Else
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Job_ID = '" & SearchByJobID.Text & "' AND Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn

                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByNextSteps.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Next_Steps = " & "'" & SearchByNextSteps.Text & "'", SQLConn)
                    End If
                Else
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Next_Steps = '" & SearchByNextSteps.Text & "' AND Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn

                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button_Shared_Click(sender As Object, e As EventArgs) Handles Button_Shared.Click

        Try
            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = SystemColors.GradientInactiveCaption
            Button_Shared.BackColor = Color.Honeydew
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            Dim DS As New DataSet
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            'SQLConn.Open()
            SQLConn.Close()
            If SearchByRecruiter.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes'", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & SearchByRecruiter.Text & "' AND Shared='Yes'", SQLConn)
                    End If
                Else
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & SearchByRecruiter.Text & "' AND Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByCompany.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes'", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "' AND Shared='Yes'", SQLConn)
                    End If
                Else
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Company1 = '" & SearchByCompany.Text & "' AND Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobPosition.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes'", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_Position = " & "'" & SearchByJobPosition.Text & "' AND Shared='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobID.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes'", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_ID = " & "'" & SearchByJobID.Text & "' AND Shared='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_ID = '" & SearchByJobID.Text & "' AND Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByNextSteps.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes'", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Next_Steps = " & "'" & SearchByNextSteps.Text & "' AND Shared='Yes'", SQLConn)
                    End If
                Else
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Next_Steps = '" & SearchByNextSteps.Text & "' AND Shared = 'Yes' And (Shared_Date >= '" & DateRangeFrom.Value & "' AND Shared_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button_Approved_Click(sender As Object, e As EventArgs) Handles Button_Approved.Click
        Try
            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = SystemColors.GradientInactiveCaption
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = Color.Honeydew
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            Dim DS As New DataSet
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            'SQLConn.Open()
            SQLConn.Close()
            If SearchByRecruiter.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes'", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & SearchByRecruiter.Text & "' AND Interview='Yes'", SQLConn)
                    End If
                Else
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & SearchByRecruiter.Text & "' AND Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByCompany.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes'", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "' AND Interview='Yes'", SQLConn)
                    End If
                Else
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Company1 = '" & SearchByCompany.Text & "' AND Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobPosition.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes'", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_Position = " & "'" & SearchByJobPosition.Text & "' AND Interview='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobID.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes'", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_ID = " & "'" & SearchByJobID.Text & "' AND Interview='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_ID = '" & SearchByJobID.Text & "' AND Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByNextSteps.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes'", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Next_Steps = " & "'" & SearchByNextSteps.Text & "' AND Interview='Yes'", SQLConn)
                    End If
                Else
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Next_Steps = '" & SearchByNextSteps.Text & "' AND Interview = 'Yes' And (Interview_Date >= '" & DateRangeFrom.Value & "' AND Interview_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If

                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button_Invited_Click(sender As Object, e As EventArgs) Handles Button_Invited.Click
        Try
            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = SystemColors.GradientInactiveCaption
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = Color.Honeydew
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            Dim DS As New DataSet
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            'SQLConn.Open()
            SQLConn.Close()
            If SearchByRecruiter.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes'", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & SearchByRecruiter.Text & "' AND Invited='Yes'", SQLConn)
                    End If
                Else
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & SearchByRecruiter.Text & "' AND Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByCompany.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes'", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "' AND Invited='Yes'", SQLConn)
                    End If
                Else
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Company1 = '" & SearchByCompany.Text & "' AND Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobPosition.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes'", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_Position = " & "'" & SearchByJobPosition.Text & "' AND Invited='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobID.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes'", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_ID = " & "'" & SearchByJobID.Text & "' AND Invited='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_ID = '" & SearchByJobID.Text & "' AND Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByNextSteps.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes'", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Next_Steps = " & "'" & SearchByNextSteps.Text & "' AND Invited='Yes'", SQLConn)
                    End If
                Else
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Next_Steps = '" & SearchByNextSteps.Text & "' AND Invited = 'Yes' And (Invited_Date >= '" & DateRangeFrom.Value & "' AND Invited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button_Visited_Click(sender As Object, e As EventArgs) Handles Button_Visited.Click
        Try
            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = SystemColors.GradientInactiveCaption
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = Color.Honeydew
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            Dim DS As New DataSet
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            'SQLConn.Open()
            SQLConn.Close()
            If SearchByRecruiter.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes'", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & SearchByRecruiter.Text & "' AND Visited='Yes'", SQLConn)
                    End If
                Else
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & SearchByRecruiter.Text & "' AND Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByCompany.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes'", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "' AND Visited='Yes'", SQLConn)
                    End If
                Else
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Company1 = '" & SearchByCompany.Text & "' AND Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobPosition.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes'", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_Position = " & "'" & SearchByJobPosition.Text & "' AND Visited='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobID.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes'", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_ID = " & "'" & SearchByJobID.Text & "' AND Visited='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_ID = '" & SearchByJobID.Text & "' AND Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByNextSteps.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes'", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Next_Steps = " & "'" & SearchByNextSteps.Text & "' AND Visited='Yes'", SQLConn)
                    End If
                Else
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Next_Steps = '" & SearchByNextSteps.Text & "' AND Visited = 'Yes' And (Visited_Date >= '" & DateRangeFrom.Value & "' AND Visited_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button_Offered_Click(sender As Object, e As EventArgs) Handles Button_Offered.Click
        Try

            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = SystemColors.GradientInactiveCaption
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = Color.Honeydew
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            Dim DS As New DataSet
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            'SQLConn.Open()
            SQLConn.Close()
            If SearchByRecruiter.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes'", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & SearchByRecruiter.Text & "' AND Offer='Yes'", SQLConn)
                    End If
                Else
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & SearchByRecruiter.Text & "' AND Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByCompany.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes'", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "' AND Offer='Yes'", SQLConn)
                    End If
                Else
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Company1 = '" & SearchByCompany.Text & "' AND Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobPosition.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes'", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_Position = " & "'" & SearchByJobPosition.Text & "' AND Offer='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobID.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes'", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_ID = " & "'" & SearchByJobID.Text & "' AND Offer='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_ID = '" & SearchByJobID.Text & "' AND Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByNextSteps.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes'", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Next_Steps = " & "'" & SearchByNextSteps.Text & "' AND Offer='Yes'", SQLConn)
                    End If
                Else
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Next_Steps = '" & SearchByNextSteps.Text & "' AND Offer = 'Yes' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub Button_OfferAccepted_Click(sender As Object, e As EventArgs) Handles Button_OfferAccepted.Click
        Try
            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = SystemColors.GradientInactiveCaption
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = Color.Honeydew
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            Dim DS As New DataSet
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            'SQLConn.Open()
            SQLConn.Close()
            If SearchByRecruiter.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes'", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & SearchByRecruiter.Text & "' AND Offer_Accepted='Yes'", SQLConn)
                    End If
                Else
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & SearchByRecruiter.Text & "' AND Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)
                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByCompany.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes'", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "' AND Offer_Accepted='Yes'", SQLConn)
                    End If
                Else
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Company1 = '" & SearchByCompany.Text & "' AND Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobPosition.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes'", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_Position = " & "'" & SearchByJobPosition.Text & "' AND Offer_Accepted='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobID.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes'", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_ID = " & "'" & SearchByJobID.Text & "' AND Offer_Accepted='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_ID = '" & SearchByJobID.Text & "' AND Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByNextSteps.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes'", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Next_Steps = " & "'" & SearchByNextSteps.Text & "' AND Offer_Accepted='Yes'", SQLConn)
                    End If
                Else
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Next_Steps = '" & SearchByNextSteps.Text & "' AND Offer_Accepted = 'Yes' And (Offer_Accepted_Date >= '" & DateRangeFrom.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button_OfferDeclined_Click(sender As Object, e As EventArgs) Handles Button_OfferDeclined.Click
        Try
            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = SystemColors.GradientInactiveCaption
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = Color.Honeydew
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            Dim DS As New DataSet
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            'SQLConn.Open()
            SQLConn.Close()


            If SearchByRecruiter.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined'", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & SearchByRecruiter.Text & "' AND Offer_Status = 'Declined'", SQLConn)
                    End If
                Else
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & SearchByRecruiter.Text & "' AND Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByCompany.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined'", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "' AND Offer_Status = 'Declined'", SQLConn)
                    End If
                Else
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Company1 = '" & SearchByCompany.Text & "' AND Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobPosition.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined'", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_Position = " & "'" & SearchByJobPosition.Text & "' AND Offer_Status = 'Declined'", SQLConn)
                    End If
                Else
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobID.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined'", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_ID = " & "'" & SearchByJobID.Text & "' AND Offer_Status = 'Declined'", SQLConn)
                    End If
                Else
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_ID = '" & SearchByJobID.Text & "' AND Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByNextSteps.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined'", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Next_Steps = " & "'" & SearchByNextSteps.Text & "' AND Offer_Status = 'Declined'", SQLConn)
                    End If
                Else
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Next_Steps = '" & SearchByNextSteps.Text & "' AND Offer_Status = 'Declined' And (Offer_Date >= '" & DateRangeFrom.Value & "' AND Offer_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button_Joined_Click(sender As Object, e As EventArgs) Handles Button_Joined.Click
        Try
            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = SystemColors.GradientInactiveCaption
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = Color.Honeydew
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            Dim DS As New DataSet
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            'SQLConn.Open()
            SQLConn.Close()
            If SearchByRecruiter.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes'", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & SearchByRecruiter.Text & "' AND Joining='Yes'", SQLConn)
                    End If
                Else
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & SearchByRecruiter.Text & "' AND Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)
                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByCompany.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes'", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "' AND Joining='Yes'", SQLConn)
                    End If
                Else
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Company1 = '" & SearchByCompany.Text & "' AND Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobPosition.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes'", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_Position = " & "'" & SearchByJobPosition.Text & "' AND Joining='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobID.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes'", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_ID = " & "'" & SearchByJobID.Text & "' AND Joining='Yes'", SQLConn)
                    End If
                Else
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_ID = '" & SearchByJobID.Text & "' AND Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByNextSteps.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes'", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Next_Steps = " & "'" & SearchByNextSteps.Text & "' AND Joining='Yes'", SQLConn)
                    End If
                Else
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Next_Steps = '" & SearchByNextSteps.Text & "' AND Joining = 'Yes' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button_Rejected_Click(sender As Object, e As EventArgs) Handles Button_Rejected.Click
        Try
            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = SystemColors.GradientInactiveCaption
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = Color.Honeydew
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            Dim DS As New DataSet
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            'SQLConn.Open()
            SQLConn.Close()
            If SearchByRecruiter.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT'", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & SearchByRecruiter.Text & "' AND Application_Status = 'REJECT'", SQLConn)
                    End If
                Else
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & SearchByRecruiter.Text & "' AND Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)
                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByCompany.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT'", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "' AND Application_Status = 'REJECT'", SQLConn)
                    End If
                Else
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Company1 = '" & SearchByCompany.Text & "' AND Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobPosition.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT'", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_Position = " & "'" & SearchByJobPosition.Text & "' AND Application_Status = 'REJECT'", SQLConn)
                    End If
                Else
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobID.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT'", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_ID = " & "'" & SearchByJobID.Text & "' AND Application_Status = 'REJECT'", SQLConn)
                    End If
                Else
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_ID = '" & SearchByJobID.Text & "' AND Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByNextSteps.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT'", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Next_Steps = " & "'" & SearchByNextSteps.Text & "' AND Application_Status = 'REJECT'", SQLConn)
                    End If
                Else
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Next_Steps = '" & SearchByNextSteps.Text & "' AND Application_Status = 'REJECT' And (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button_ToJoin_Click(sender As Object, e As EventArgs) Handles Button_ToJoin.Click
        Try
            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = SystemColors.GradientInactiveCaption
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = Color.Honeydew
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            Dim DS As New DataSet
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            'SQLConn.Open()
            SQLConn.Close()
            If SearchByRecruiter.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN'", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & SearchByRecruiter.Text & "' AND Application_Status = 'TO JOIN'", SQLConn)
                    End If
                Else
                    If SearchByRecruiter.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByRecruiter.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & SearchByRecruiter.Text & "' AND Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)
                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByCompany.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN'", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "' AND Application_Status = 'TO JOIN'", SQLConn)
                    End If
                Else
                    If SearchByCompany.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByCompany.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Company1 = '" & SearchByCompany.Text & "' AND Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobPosition.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN'", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_Position = " & "'" & SearchByJobPosition.Text & "' AND Application_Status = 'TO JOIN'", SQLConn)
                    End If
                Else
                    If SearchByJobPosition.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobPosition.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByJobID.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN'", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_ID = " & "'" & SearchByJobID.Text & "' AND Application_Status = 'TO JOIN'", SQLConn)
                    End If
                Else
                    If SearchByJobID.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByJobID.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Job_ID = '" & SearchByJobID.Text & "' AND Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            ElseIf SearchByNextSteps.Enabled = True Then
                If DateRangeALL.Checked = True Then
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN'", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN'", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Next_Steps = " & "'" & SearchByNextSteps.Text & "' AND Application_Status = 'TO JOIN'", SQLConn)
                    End If
                Else
                    If SearchByNextSteps.Text = "" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    ElseIf SearchByNextSteps.Text = "ALL" Then
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    Else
                        SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Next_Steps = '" & SearchByNextSteps.Text & "' AND Application_Status = 'TO JOIN' And (Joining_Date >= '" & DateRangeFrom.Value & "' AND Joining_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                    End If
                End If
                SQLComm.Connection = SQLConn
                SQLComm.CommandTimeout = 30
                Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA.Fill(DS)
                DataGridView3.DataSource = DS.Tables(0)
                SQLConn.Close()

                '------------------------ Rows Count-------------------------
                applicationsCount.Text = DataGridView3.RowCount
                '------------------------------------------------------------

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    Private Sub txt_AppSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_AppSearch.KeyPress

        Try
            'SQLConn.Close()
            'Dim ConnStr As String
            'ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            'SQLConn.ConnectionString = ConnStr
            'SQLComm.Connection = SQLConn
            'Dim ds1 As New DataSet
            'SQLConn.Open()
            'SQLComm = New SQL.OleDbCommand("SELECT * FROM ApplicationTable WHERE Candidate_Name LIKE '%" & txt_AppSearch.Text & "%'", SQLConn)
            'SQLComm.CommandTimeout = 30
            'Dim DA1 As New SQL.OleDbDataAdapter(SQLComm.CommandText, ConnStr)
            'DA1.Fill(ds1)
            'DataGridView3.DataSource = ds1.Tables(0)
            'SQLConn.Close()
            'DataGridView3.DataBindings.Clear()
            'SQLComm.Parameters.Clear()
            'ConnStr = Nothing
            'applicationsCount.Text = DataGridView3.RowCount

            '--------------------------------------Search on hit enter key -------------------------
            Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
            If tmp.KeyChar = ChrW(Keys.Enter) Then
                DateRangeALL.Checked = True
                SQLConn.Close()
                Dim ConnStr As String
                ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                Dim ds1 As New DataSet
                SQLConn.Open()
                'SQLComm = New SQL.OleDbCommand("SELECT * FROM ApplicationTable WHERE Candidate_Name LIKE '%" & txt_AppSearch.Text & "%'", SQLConn)
                SQLComm = New SqlCommand(("Select * from ApplicationTable where Lower(Candidate_Name) LIKE '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(E_Mail) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Phone) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Job_Position) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Company1) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Job_Category) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Recruiter_Name) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Resume_Source) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Decline_Reason) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Comments) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Next_Steps) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Application_ID) LIKE '%" & LCase(Trim(txt_AppSearch.Text)) & "%'"), SQLConn)
                SQLComm.CommandTimeout = 30
                Dim DA1 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA1.Fill(ds1)
                DataGridView3.DataSource = ds1.Tables(0)
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)
                SQLConn.Close()
                DataGridView3.DataBindings.Clear()
                SQLComm.Parameters.Clear()
                ConnStr = Nothing
                applicationsCount.Text = DataGridView3.RowCount
            Else
            End If
        Catch ex As Exception
            SQLConn.Dispose()
        End Try
    End Sub



    Private Sub Btn_ExportToExcel_Click(sender As Object, e As EventArgs) Handles Btn_ExportToExcel.Click
        Try
            'FilePath = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & ".xls"

            'Dim default_location As String = Path.GetTempPath.ToString & "Recruitment_Applications_DataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xlsx"
            Dim default_location As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Recruitment_Applications_Data_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xlsx"
            'Dim default_location As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  
            'Creating dataset to export
            Dim dset As New DataSet
            'add table to dataset
            dset.Tables.Add()
            'add column to that table
            For i As Integer = 0 To DataGridView3.ColumnCount - 1
                Application.DoEvents()
                dset.Tables(0).Columns.Add(DataGridView3.Columns(i).HeaderText)
            Next
            'add rows to the table
            Dim dr1 As DataRow
            For i As Integer = 0 To DataGridView3.RowCount - 1
                Application.DoEvents()
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To DataGridView3.Columns.Count - 1
                    dr1(j) = DataGridView3.Rows(i).Cells(j).Value
                Next
                dset.Tables(0).Rows.Add(dr1)
            Next

            Dim excel As New Microsoft.Office.Interop.Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            excel.Visible = False
            excel.UserControl = True

            wBook = excel.Workbooks.Add(System.Reflection.Missing.Value)
            wSheet = wBook.Sheets("sheet1")
            'excel.Range("A50:I50").EntireColumn.AutoFit()
            With wBook
                .Sheets("Sheet1").Select()
                .Sheets(1).Name = "Applications"
            End With

            Dim dt As System.Data.DataTable = dset.Tables(0)
            wSheet.Cells(1).value = "Recruitment Data"


            For j = 0 To DataGridView3.ColumnCount - 1
                Application.DoEvents()
                wSheet.Cells(1, j + 1).value = DataGridView3.Columns(j).HeaderText
                wSheet.Cells(1, j + 1).interior.color = Color.LightCyan
                wSheet.Cells(1, j + 1).Font.Bold = True

            Next j

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = DataGridView3.RowCount
            ProgressBar1.Show()
            For i = 0 To DataGridView3.RowCount - 1
                Application.DoEvents()
                For j = 0 To DataGridView3.ColumnCount - 1
                    wSheet.Cells(i + 2, j + 1).value = DataGridView3.Rows(i).Cells(j).Value.ToString
                Next j
                ProgressBar1.Value = i
            Next i

            wSheet.Columns.AutoFit()
            wSheet.Range("AL:AL").ColumnWidth = 20
            wSheet.Cells.WrapText = False

            Dim blnFileOpen As Boolean = False
            Try
                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(default_location)
                fileTemp.Close()
            Catch ex As Exception
                blnFileOpen = False
            End Try

            If System.IO.File.Exists(default_location) Then
                System.IO.File.Delete(default_location)
            End If

            wBook.SaveAs(default_location)
            excel.Workbooks.Open(default_location)
            excel.Visible = True

            ProgressBar1.Hide()
            ProgressBar1.Value = 0

            'MessageBox.Show("Successful")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonQuickExport_Click(sender As Object, e As EventArgs) Handles ButtonQuickExport.Click

        Dim FilePath As String
        FilePath = Path.GetTempPath.ToString & "Recruitment_DataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"

        Dim _mFileStream As New IO.StreamWriter(FilePath, False)

        Try
            _mFileStream.WriteLine("<?xml version=""1.0""?>")
            _mFileStream.WriteLine("<?mso-application progid=""Excel.Sheet""?>")
            _mFileStream.WriteLine("<ss:Workbook xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"">")
            _mFileStream.WriteLine("    <ss:Styles>")
            _mFileStream.WriteLine("        <ss:Style ss:ID=""1"">")
            _mFileStream.WriteLine("           <ss:Font ss:Bold=""1""/>")
            _mFileStream.WriteLine("           <ss:FontName=""Courier New""/>")
            _mFileStream.WriteLine("        </ss:Style>")
            _mFileStream.WriteLine("    </ss:Styles>")
            _mFileStream.WriteLine("    <ss:Worksheet ss:Name=""Sheet1"">")
            _mFileStream.WriteLine("        <ss:Table>")
            For x As Integer = 0 To DataGridView3.Columns.Count - 1
                _mFileStream.WriteLine("            <ss:Column ss:Width=""{0}""/>", DataGridView3.Columns.Item(x).Width)
            Next
            _mFileStream.WriteLine("            <ss:Row ss:StyleID=""1"">")
            For i As Integer = 0 To DataGridView3.Columns.Count - 1
                _mFileStream.WriteLine("                <ss:Cell>")
                _mFileStream.WriteLine(String.Format("                   <ss:Data ss:Type=""String"">{0}</ss:Data>", DataGridView3.Columns.Item(i).HeaderText))
                _mFileStream.WriteLine("</ss:Cell>")
            Next
            _mFileStream.WriteLine("            </ss:Row>")
            For intRow As Integer = 0 To DataGridView3.RowCount - 1
                _mFileStream.WriteLine(String.Format("            <ss:Row ss:Height =""{0}"">", DataGridView3.Rows(intRow).Height))
                For intCol As Integer = 0 To DataGridView3.Columns.Count - 1
                    _mFileStream.WriteLine("                <ss:Cell>")
                    _mFileStream.WriteLine(String.Format("                   <ss:Data ss:Type=""String"">{0}</ss:Data>", DataGridView3.Item(intCol, intRow).Value.ToString))
                    _mFileStream.WriteLine("                </ss:Cell>")
                Next
                _mFileStream.WriteLine("            </ss:Row>")
            Next
            _mFileStream.WriteLine("        </ss:Table>")
            _mFileStream.WriteLine("    </ss:Worksheet>")
            _mFileStream.WriteLine("</ss:Workbook>")
            _mFileStream.Close()
            _mFileStream.Dispose()
            _mFileStream = Nothing

            '------------------ Open Excel file ----------------------------------

            Dim excel As New Microsoft.Office.Interop.Excel.Application
            excel.Workbooks.Open(FilePath)
            excel.Visible = True
            '---------------------------------------------------------------------

        Catch ex As Exception
            _mFileStream.Close()
            _mFileStream.Dispose()
            _mFileStream = Nothing
            MessageBox.Show("Error While Exporting Data To Excel. Error : " & ex.Message)
        End Try

    End Sub

    Private Sub ComboBoxAppDetailsRecruiter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchByRecruiter.SelectedIndexChanged
        Try

            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = Color.Honeydew
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLConn.Open()
            If DateRangeALL.Checked = True Then

                If SearchByRecruiter.Text = "" Then
                    'SQLComm = New SQL.OleDbCommand("SELECT * FROM ApplicationTable", SQLConn)
                ElseIf SearchByRecruiter.Text = "ALL" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                Else
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & SearchByRecruiter.Text & "'", SQLConn)
                End If

            Else
                If SearchByRecruiter.Text = "" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                ElseIf SearchByRecruiter.Text = "ALL" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                Else
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Recruiter_Name = '" & SearchByRecruiter.Text & "' AND (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                End If
            End If
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DS)
            DataGridView3.DataSource = DS.Tables(0)
            SQLConn.Close()
            DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)


            '------------------------ Rows Count-------------------------
            applicationsCount.Text = DataGridView3.RowCount
            '------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
        End Try

    End Sub



    Private Sub DataGridView3_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellDoubleClick
        FormProcess.CheckBoxNewCandidate.Checked = False
        Try

            FormProcess.MdiParent = FormMain
            FormProcess.Show()


            FormProcess.ComboBoxPJobID.DataBindings.Clear()
            FormProcess.ComboBoxPJobID.Text = Me.DataGridView3.SelectedCells.Item(1).Value


            FormProcess.ComboBoxAppID.DataBindings.Clear()
            FormProcess.ComboBoxAppID.Text = Me.DataGridView3.SelectedCells.Item(8).Value


            Me.Hide()
            FormMain.btn_process.BackColor = Color.Honeydew
            FormMain.btn_newcandidate.BackColor = Color.Honeydew
            FormMain.btn_createjob.BackColor = Color.Honeydew
            FormMain.btn_OpenPosition.BackColor = Color.Honeydew
            FormMain.btn_application.BackColor = Color.Honeydew
            FormMain.btn_ChangeJobID.BackColor = Color.Honeydew
            FormMain.btn_ModifyJobPosition.BackColor = Color.Honeydew
            FormMain.btn_Analysis.BackColor = Color.Honeydew
            FormMain.btn_process.BackColor = SystemColors.GradientInactiveCaption

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RadioButtonRecruiter_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButtonRecruiter.CheckedChanged
        If RadioButtonRecruiter.Checked = True Then

            SearchByRecruiter.Enabled = True
            SearchByRecruiter.Focus()
            SearchByCompany.Enabled = False
            SearchByJobPosition.Enabled = False
            SearchByJobID.Enabled = False
            SearchByNextSteps.Enabled = False

            SearchByRecruiter.SelectedIndex = -1
            SearchByCompany.SelectedIndex = -1
            SearchByJobPosition.SelectedIndex = -1
            SearchByJobID.SelectedIndex = -1
            SearchByNextSteps.SelectedIndex = -1

        Else

            SearchByRecruiter.Enabled = False
            SearchByCompany.Enabled = False
            SearchByJobPosition.Enabled = False
            SearchByJobID.Enabled = False
            SearchByNextSteps.Enabled = False

            SearchByRecruiter.SelectedIndex = -1
            SearchByCompany.SelectedIndex = -1
            SearchByJobPosition.SelectedIndex = -1
            SearchByJobID.SelectedIndex = -1
            SearchByNextSteps.SelectedIndex = -1
        End If

    End Sub

    Private Sub RadioButtonCompany_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonCompany.CheckedChanged
        If RadioButtonCompany.Checked = True Then

            SearchByRecruiter.Enabled = False
            SearchByCompany.Enabled = True
            SearchByCompany.Focus()
            SearchByJobPosition.Enabled = False
            SearchByJobID.Enabled = False
            SearchByNextSteps.Enabled = False

            SearchByRecruiter.SelectedIndex = -1
            SearchByCompany.SelectedIndex = -1
            SearchByJobPosition.SelectedIndex = -1
            SearchByJobID.SelectedIndex = -1
            SearchByNextSteps.SelectedIndex = -1
        Else
            SearchByJobID.Enabled = False
            SearchByRecruiter.Enabled = False
            SearchByCompany.Enabled = False
            SearchByJobPosition.Enabled = False
            SearchByNextSteps.Enabled = False

            SearchByRecruiter.SelectedIndex = -1
            SearchByCompany.SelectedIndex = -1
            SearchByJobPosition.SelectedIndex = -1
            SearchByJobID.SelectedIndex = -1
            SearchByNextSteps.SelectedIndex = -1
        End If
    End Sub

    Private Sub RadioButtonJobPosition_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonJobPosition.CheckedChanged
        If RadioButtonJobPosition.Checked = True Then

            SearchByJobID.Enabled = False
            SearchByRecruiter.Enabled = False
            SearchByCompany.Enabled = False
            SearchByJobPosition.Enabled = True
            SearchByJobPosition.Focus()
            SearchByNextSteps.Enabled = False

            SearchByJobID.SelectedIndex = -1
            SearchByRecruiter.SelectedIndex = -1
            SearchByCompany.SelectedIndex = -1
            SearchByJobPosition.SelectedIndex = -1
            SearchByNextSteps.SelectedIndex = -1
        Else
            SearchByJobID.Enabled = False
            SearchByRecruiter.Enabled = False
            SearchByCompany.Enabled = False
            SearchByJobPosition.Enabled = False
            SearchByNextSteps.Enabled = False

            SearchByJobID.SelectedIndex = -1
            SearchByRecruiter.SelectedIndex = -1
            SearchByCompany.SelectedIndex = -1
            SearchByJobPosition.SelectedIndex = -1
            SearchByNextSteps.SelectedIndex = -1
        End If
    End Sub

    Private Sub RadioButtonJobID_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonJobID.CheckedChanged
        If RadioButtonJobID.Checked = True Then

            SearchByJobID.Enabled = True
            SearchByJobID.Focus()
            SearchByRecruiter.Enabled = False
            SearchByCompany.Enabled = False
            SearchByJobPosition.Enabled = False
            SearchByNextSteps.Enabled = False

            SearchByJobID.SelectedIndex = -1
            SearchByRecruiter.SelectedIndex = -1
            SearchByCompany.SelectedIndex = -1
            SearchByJobPosition.SelectedIndex = -1
            SearchByNextSteps.SelectedIndex = -1
        Else
            SearchByJobID.Enabled = False
            SearchByRecruiter.Enabled = False
            SearchByCompany.Enabled = False
            SearchByJobPosition.Enabled = False
            SearchByNextSteps.Enabled = False

            SearchByJobID.SelectedIndex = -1
            SearchByRecruiter.SelectedIndex = -1
            SearchByCompany.SelectedIndex = -1
            SearchByJobPosition.SelectedIndex = -1
            SearchByNextSteps.SelectedIndex = -1
        End If
    End Sub

    Private Sub SearchByCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchByCompany.SelectedIndexChanged
        Try

            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = Color.Honeydew
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            'SQLConn.Open()
            SQLConn.Close()
            SQLConn.ConnectionString = ConnStr
            If DateRangeALL.Checked = True Then
                If SearchByCompany.Text = "" Then
                    'SQLComm = New SQL.OleDbCommand("SELECT * FROM ApplicationTable", SQLConn)
                ElseIf SearchByCompany.Text = "ALL" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                Else
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "'", SQLConn)
                End If
            Else
                If SearchByCompany.Text = "" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                ElseIf SearchByCompany.Text = "ALL" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                Else
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Company1 = " & "'" & SearchByCompany.Text & "'", SQLConn)
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Company1 = '" & SearchByCompany.Text & "' AND (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                End If
            End If
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DS)
            DataGridView3.DataSource = DS.Tables(0)
            SQLConn.Close()
            DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)
            '------------------------ Rows Count-------------------------
            applicationsCount.Text = DataGridView3.RowCount
            '------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SearchByJobPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchByJobPosition.SelectedIndexChanged
        Try

            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = Color.Honeydew
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            'SQLConn.Open()
            SQLConn.Close()
            SQLConn.ConnectionString = ConnStr
            If DateRangeALL.Checked = True Then
                If SearchByJobPosition.Text = "" Then
                    'SQLComm = New SQL.OleDbCommand("SELECT * FROM ApplicationTable", SQLConn)
                ElseIf SearchByJobPosition.Text = "ALL" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                Else
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_Position = " & "'" & SearchByJobPosition.Text & "'", SQLConn)
                End If
            Else
                If SearchByJobPosition.Text = "" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                ElseIf SearchByJobPosition.Text = "ALL" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                Else
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Job_Position = '" & SearchByJobPosition.Text & "' AND (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                End If
            End If
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DS)
            DataGridView3.DataSource = DS.Tables(0)
            SQLConn.Close()
            DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)

            '------------------------ Rows Count-------------------------
            applicationsCount.Text = DataGridView3.RowCount
            '------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SearchByJobID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchByJobID.SelectedIndexChanged
        Try

            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = Color.Honeydew
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            'SQLConn.Open()
            SQLConn.Close()
            SQLConn.ConnectionString = ConnStr
            If DateRangeALL.Checked = True Then
                If SearchByJobID.Text = "" Then
                    'SQLComm = New SQL.OleDbCommand("SELECT * FROM ApplicationTable", SQLConn)
                ElseIf SearchByJobID.Text = "ALL" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                Else
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Job_ID = " & "'" & SearchByJobID.Text & "'", SQLConn)
                End If
            Else
                If SearchByJobID.Text = "" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                ElseIf SearchByJobID.Text = "ALL" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                Else
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Job_ID = '" & SearchByJobID.Text & "' AND (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                End If
            End If
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DS)
            DataGridView3.DataSource = DS.Tables(0)
            SQLConn.Close()
            DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)

            '------------------------ Rows Count-------------------------
            applicationsCount.Text = DataGridView3.RowCount
            '------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_AppSearch_TextChanged(sender As Object, e As EventArgs) Handles txt_AppSearch.TextChanged

    End Sub



    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateRange_CheckedChanged(sender As Object, e As EventArgs) Handles DateRange.CheckedChanged
        'If DateRange.Checked = True Then
        '    DateRangeALL.Checked = False
        '    DateRangeFrom.Enabled = True
        '    DateRangeTo.Enabled = True
        'Else
        '    DateRangeALL.Checked = True
        '    DateRange.Checked = False
        '    DateRangeFrom.Enabled = False
        '    DateRangeTo.Enabled = False
        'End If
        SearchByRecruiter.SelectedIndex = -1
        SearchByCompany.SelectedIndex = -1
        SearchByJobPosition.SelectedIndex = -1
        SearchByJobID.SelectedIndex = -1
    End Sub

    Private Sub DateRangeALL_CheckedChanged(sender As Object, e As EventArgs) Handles DateRangeALL.CheckedChanged
        'If DateRangeALL.Checked = True Then
        '    DateRangeFrom.Enabled = False
        '    DateRangeTo.Enabled = False
        '    DateRange.Checked = False
        'Else
        '    DateRange.Checked = True
        '    DateRangeFrom.Enabled = True
        '    DateRangeTo.Enabled = True
        'End If

        SearchByRecruiter.SelectedIndex = -1
        SearchByCompany.SelectedIndex = -1
        SearchByJobPosition.SelectedIndex = -1
        SearchByJobID.SelectedIndex = -1

    End Sub

    Private Sub DateRangeFrom_ValueChanged(sender As Object, e As EventArgs) Handles DateRangeFrom.ValueChanged
        DateRange.Checked = True
        SearchByRecruiter.SelectedIndex = -1
        SearchByCompany.SelectedIndex = -1
        SearchByJobPosition.SelectedIndex = -1
        SearchByJobID.SelectedIndex = -1
    End Sub

    Private Sub DateRangeTo_ValueChanged(sender As Object, e As EventArgs) Handles DateRangeTo.ValueChanged
        DateRange.Checked = True
        SearchByRecruiter.SelectedIndex = -1
        SearchByCompany.SelectedIndex = -1
        SearchByJobPosition.SelectedIndex = -1
        SearchByJobID.SelectedIndex = -1
    End Sub



    Private Sub DataGridView3_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView3.SelectionChanged
        Label_selectedrow.Text = "Selected Rows: " & DataGridView3.SelectedRows.Count

    End Sub





    Private Sub RadioButtonInterviewBy_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonNextSteps.CheckedChanged
        If RadioButtonNextSteps.Checked = True Then

            SearchByNextSteps.Enabled = True
            SearchByNextSteps.Focus()
            SearchByJobID.Enabled = False
            SearchByRecruiter.Enabled = False
            SearchByCompany.Enabled = False
            SearchByJobPosition.Enabled = False

            SearchByJobID.SelectedIndex = -1
            SearchByRecruiter.SelectedIndex = -1
            SearchByCompany.SelectedIndex = -1
            SearchByJobPosition.SelectedIndex = -1
            SearchByNextSteps.SelectedIndex = -1

        Else
            SearchByNextSteps.Enabled = False
            SearchByJobID.Enabled = False
            SearchByRecruiter.Enabled = False
            SearchByCompany.Enabled = False
            SearchByJobPosition.Enabled = False

            SearchByJobID.SelectedIndex = -1
            SearchByRecruiter.SelectedIndex = -1
            SearchByCompany.SelectedIndex = -1
            SearchByJobPosition.SelectedIndex = -1
            SearchByNextSteps.SelectedIndex = -1

        End If

    End Sub

    Private Sub SearchByNextSteps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchByNextSteps.SelectedIndexChanged
        Try

            '------------------------Change Button Back Color ------------------------------------------
            Button_All_ShowAll.BackColor = Color.Honeydew
            Button_Shared.BackColor = SystemColors.GradientInactiveCaption
            Button_Approved.BackColor = SystemColors.GradientInactiveCaption
            Button_Invited.BackColor = SystemColors.GradientInactiveCaption
            Button_Visited.BackColor = SystemColors.GradientInactiveCaption
            Button_Offered.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferAccepted.BackColor = SystemColors.GradientInactiveCaption
            Button_OfferDeclined.BackColor = SystemColors.GradientInactiveCaption
            Button_Joined.BackColor = SystemColors.GradientInactiveCaption
            Button_ToJoin.BackColor = SystemColors.GradientInactiveCaption
            Button_Rejected.BackColor = SystemColors.GradientInactiveCaption
            '-------------------------------------------------------------------------------------------

            Dim ConnStr As String
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            'SQLConn.Open()
            SQLConn.Close()
            SQLConn.ConnectionString = ConnStr
            If DateRangeALL.Checked = True Then
                If SearchByNextSteps.Text = "" Then
                    'SQLComm = New SQL.OleDbCommand("SELECT * FROM ApplicationTable", SQLConn)
                ElseIf SearchByNextSteps.Text = "ALL" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
                Else
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE  Next_Steps = " & "'" & SearchByNextSteps.Text & "'", SQLConn)
                End If
            Else
                If SearchByNextSteps.Text = "" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                ElseIf SearchByNextSteps.Text = "ALL" Then
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "'", SQLConn)
                Else
                    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable Where Next_Steps = '" & SearchByNextSteps.Text & "' AND (Screening_Date >= '" & DateRangeFrom.Value & "' AND Screening_Date <= '" & DateRangeTo.Value & "')", SQLConn)
                End If
            End If
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DS)
            DataGridView3.DataSource = DS.Tables(0)
            SQLConn.Close()
            DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)

            '------------------------ Rows Count-------------------------
            applicationsCount.Text = DataGridView3.RowCount
            '------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Btn_search_Click(sender As Object, e As EventArgs) Handles Btn_search.Click
        Try
            DateRangeALL.Checked = True
            SQLConn.Close()
                Dim ConnStr As String
                ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                Dim ds1 As New DataSet
                SQLConn.Open()
                'SQLComm = New SQL.OleDbCommand("SELECT * FROM ApplicationTable WHERE Candidate_Name LIKE '%" & txt_AppSearch.Text & "%'", SQLConn)
                SQLComm = New SqlCommand(("Select * from ApplicationTable where Lower(Candidate_Name) LIKE '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(E_Mail) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Phone) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Job_Position) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Company1) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Job_Category) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Recruiter_Name) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Resume_Source) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Decline_Reason) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Comments) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Next_Steps) Like '%" & LCase(Trim(txt_AppSearch.Text)) & "%' or Lower(Application_ID) LIKE '%" & LCase(Trim(txt_AppSearch.Text)) & "%'"), SQLConn)
                SQLComm.CommandTimeout = 30
                Dim DA1 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA1.Fill(ds1)
            DataGridView3.DataSource = ds1.Tables(0)
            DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)
            SQLConn.Close()
                DataGridView3.DataBindings.Clear()
                SQLComm.Parameters.Clear()
                ConnStr = Nothing
                applicationsCount.Text = DataGridView3.RowCount
            txt_AppSearch.Focus()

        Catch ex As Exception
            SQLConn.Dispose()
        End Try
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
        FormMain.btn_application.BackColor = Color.Honeydew
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_ExportSelection.Click
        Try
            'FilePath = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & ".xls"

            'Dim default_location As String = Path.GetTempPath.ToString & "Recruitment_Applications_DataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xlsx"
            Dim default_location As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Recruitment_Applications_Data_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xlsx"
            'Dim default_location As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  
            'Creating dataset to export
            Dim dset As New DataSet
            'add table to dataset
            dset.Tables.Add()
            'add column to that table
            For i As Integer = 0 To DataGridView3.ColumnCount - 1
                dset.Tables(0).Columns.Add(DataGridView3.Columns(i).HeaderText)
            Next
            'add rows to the table
            Dim dr1 As DataRow
            For i As Integer = 0 To DataGridView3.SelectedRows.Count - 1
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To DataGridView3.Columns.Count - 1
                    dr1(j) = DataGridView3.SelectedRows(i).Cells(j).Value
                Next
                dset.Tables(0).Rows.Add(dr1)
            Next

            Dim excel As New Microsoft.Office.Interop.Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            excel.Visible = False
            excel.UserControl = True

            wBook = excel.Workbooks.Add(System.Reflection.Missing.Value)
            wSheet = wBook.Sheets("sheet1")
            'excel.Range("A50:I50").EntireColumn.AutoFit()
            With wBook
                .Sheets("Sheet1").Select()
                .Sheets(1).Name = "Applications"
            End With

            Dim dt As System.Data.DataTable = dset.Tables(0)
            wSheet.Cells(1).value = "Recruitment Data"


            For j = 0 To DataGridView3.ColumnCount - 1
                wSheet.Cells(1, j + 1).value = DataGridView3.Columns(j).HeaderText
                wSheet.Cells(1, j + 1).interior.color = Color.LightCyan
                wSheet.Cells(1, j + 1).Font.Bold = True

            Next j

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = DataGridView3.SelectedRows.Count
            ProgressBar1.Show()
            For i = 0 To DataGridView3.SelectedRows.Count - 1
                For j = 0 To DataGridView3.ColumnCount - 1
                    wSheet.Cells(i + 2, j + 1).value = DataGridView3.SelectedRows(i).Cells(j).Value.ToString
                Next j
                ProgressBar1.Value = i
            Next i

            wSheet.Columns.AutoFit()
            wSheet.Range("AL:AL").ColumnWidth = 20
            wSheet.Cells.WrapText = False

            Dim blnFileOpen As Boolean = False
            Try
                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(default_location)
                fileTemp.Close()
            Catch ex As Exception
                blnFileOpen = False
            End Try

            If System.IO.File.Exists(default_location) Then
                System.IO.File.Delete(default_location)
            End If

            wBook.SaveAs(default_location)
            excel.Workbooks.Open(default_location)
            excel.Visible = True

            ProgressBar1.Hide()
            ProgressBar1.Value = 0

            'MessageBox.Show("Successful")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Btn_SendEmail_Click(sender As Object, e As EventArgs) Handles Btn_SendEmail.Click

        Try
            ' Create the Outlook application.

            'Dim oApp As New Outlook.Application()
            ' Create a new mail item.
            'Dim oMsg As Outlook.MailItem = DirectCast(oApp.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)
            'With oMsg
            '.To = DataGridView3.SelectedRows.Item(0).Cells(11).Value
            '.Body = "Hi " & DataGridView3.SelectedRows.Item(0).Cells(9).Value
            '.Display()
            'End With
            ' Set HTMLBody.
            'add the body of the email
            'oMsg.HTMLBody = "Hi "
            'Add an attachment.
            'Dim sDisplayName As [String] = "MyAttachment"
            'Dim iPosition As Integer = CInt(oMsg.Body.Length) + 1
            'Dim iAttachType As Integer = CInt(Outlook.OlAttachmentType.olByValue)
            'now attached the file
            'Dim oAttach As Outlook.Attachment = oMsg.Attachments.Add("C:\\fileName.jpg", iAttachType, iPosition, sDisplayName)
            'Subject line
            'oMsg.Subject = "Your Subject will go here."
            ' Add a recipient.
            'Dim oRecips As Outlook.Recipients = DirectCast(oMsg.Recipients, Outlook.Recipients)
            ' Change the recipient in the next line if necessary.
            'Dim oRecip As Outlook.Recipient = DirectCast(oRecips.Add(DataGridView3.SelectedRows.Item(0).Cells(11).Value), Outlook.Recipient)
            'oRecip.Resolve()
            ' Send.
            'oMsg.Send()
            'oMsg.Display()
            'Clean up.
            'oRecip = Nothing
            'oRecips = Nothing
            'oMsg = Nothing
            'oApp = Nothing
            'end of try block

            'Dim SigString As String
            'Dim Signature As String
            ''Change only Mysig.htm to the name of your signature
            'SigString = Environ("appdata") & "\Microsoft\Signatures\Ram Krishna Prasad.htm"
            'If Dir(SigString) <> "" Then
            '    Signature = GetBoiler(SigString)
            'Else
            '    Signature = ""
            'End If

            Dim oApp, oMail As Object
            Dim fname As String() = StrConv(Trim(DataGridView3.SelectedRows.Item(0).Cells(9).Value), vbProperCase).Split(New Char() {" "})
            oApp = CreateObject("Outlook.Application")
            oMail = oApp.CreateItem(Outlook.OlItemType.olMailItem)
            'fname = fname.Split(" "c).ToString

            With oMail
                .To = Trim(DataGridView3.SelectedRows.Item(0).Cells(11).Value)
                'Signature = .HTMLBody
                .HTMLBody = "Hi " & fname(0) & "," & "<br> <br> <br>" '& Signature
                .bodyformat = Outlook.OlBodyFormat.olFormatHTML


                .Display()
            End With

            oApp = Nothing
            oMail = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Function GetBoiler(ByVal sFile As String) As String
        'Dick Kusleika
        Dim fso As Object
        Dim ts As Object
        fso = CreateObject("Scripting.FileSystemObject")
        ts = fso.GetFile(sFile).OpenAsTextStream(1, -2)
        GetBoiler = ts.readall
        ts.Close
    End Function

    Private Sub ComboBoxFY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFY.SelectedIndexChanged

        Dim FY_Start_Year As Integer = If(ComboBoxFY.Text <> "ALL", Mid(ComboBoxFY.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY.Text <> "ALL", Mid(ComboBoxFY.Text, 3, 2) & Mid(ComboBoxFY.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "4-1-" & FY_Start_Year
        Dim FY_End_Date As String = "3-31-" & FY_End_Year

        If Not ComboBoxFY.Text = "ALL" Then
            DateRange.Checked = True
            DateRangeFrom.Value = FY_Start_Date
            DateRangeTo.Value = FY_End_Date
        Else
            DateRangeALL.Checked = True
        End If
        SQLConn.Dispose()
        Button_All_ShowAll_Click(sender, e)

    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub DataGridView3_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView3.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            FormProcess.CheckBoxNewCandidate.Checked = False
            Try

                FormProcess.MdiParent = FormMain
                FormProcess.Show()


                FormProcess.ComboBoxPJobID.DataBindings.Clear()
                FormProcess.ComboBoxPJobID.Text = Me.DataGridView3.SelectedCells.Item(1).Value


                FormProcess.ComboBoxAppID.DataBindings.Clear()
                FormProcess.ComboBoxAppID.Text = Me.DataGridView3.SelectedCells.Item(8).Value


                Me.Hide()
                FormMain.btn_process.BackColor = Color.Honeydew
                FormMain.btn_newcandidate.BackColor = Color.Honeydew
                FormMain.btn_createjob.BackColor = Color.Honeydew
                FormMain.btn_OpenPosition.BackColor = Color.Honeydew
                FormMain.btn_application.BackColor = Color.Honeydew
                FormMain.btn_ChangeJobID.BackColor = Color.Honeydew
                FormMain.btn_ModifyJobPosition.BackColor = Color.Honeydew
                FormMain.btn_Analysis.BackColor = Color.Honeydew
                FormMain.btn_process.BackColor = SystemColors.GradientInactiveCaption

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Btn_SaveNextSteps_Click(sender As Object, e As EventArgs) Handles Btn_SaveNextSteps.Click
        Try
            Dim ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn

            If ComboBoxNextSteps.Text = "" Then
                MessageBox.Show("Please Select 'Assign To' Tag !!!")
                ComboBoxNextSteps.Focus()
            Else
                SQLConn.Open()
                For i As Integer = 0 To DataGridView3.SelectedRows.Count - 1
                    SQLComm.CommandText = ("UPDATE applicationtable SET Next_Steps = @Next_Steps,Last_Modified=@Last_Modified  Where Application_ID = '" & DataGridView3.SelectedRows.Item(i).Cells(8).Value & "'")
                    SQLComm.Parameters.Add("@Next_Steps", SqlDbType.Char).Value = ComboBoxNextSteps.Text
                    SQLComm.Parameters.Add("@Last_Modified", SqlDbType.DateTime).Value = Date.Now
                    SQLComm.ExecuteNonQuery()
                    SQLComm.Parameters.Clear()
                Next i
                MessageBox.Show("Success !!!", "Recruitment", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SQLComm.Parameters.Clear()
                ComboBoxNextSteps.SelectedIndex = 0

                '----------------------- refresh in datagridview ----------------------------------
                Dim ds1 As New DataSet
                'SQLConn.Open()
                SQLComm = New SqlCommand(("Select * from ApplicationTable"), SQLConn)
                SQLComm.CommandTimeout = 30
                Dim DA1 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA1.Fill(ds1)
                DataGridView3.DataSource = ds1.Tables(0)
                SQLConn.Close()
                DataGridView3.DataBindings.Clear()
                SQLComm.Parameters.Clear()
                ConnStr = Nothing
                SQLConn.Dispose()
                DataGridView3.Sort(DataGridView3.Columns(DataGridView3.ColumnCount - 1), direction:=ListSortDirection.Descending)

            End If

            SQLConn.Dispose()
            SQLComm.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
            SQLComm.Dispose()
        End Try
    End Sub


End Class