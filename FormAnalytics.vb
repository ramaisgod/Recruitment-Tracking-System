Imports System.IO
Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Public Class FormAnalytics
    Dim SQLConn As New SqlConnection
    Dim SQLComm As New SqlCommand
    Dim ConnStr As String = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString


    Private Sub FormSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'DS_SQL_OfferDeclineReason.OfferDeclineReason' table. You can move, or remove it, as needed.
        Me.OfferDeclineReasonTableAdapter1.Fill(Me.DS_SQL_OfferDeclineReason.OfferDeclineReason)
        'TODO: This line of code loads data into the 'DS_SQL_RejectedBy.RejectedBy' table. You can move, or remove it, as needed.
        Me.RejectedByTableAdapter1.Fill(Me.DS_SQL_RejectedBy.RejectedBy)
        'TODO: This line of code loads data into the 'DS_SQL_DeclineReason.DeclineReason' table. You can move, or remove it, as needed.
        Me.DeclineReasonTableAdapter1.Fill(Me.DS_SQL_DeclineReason.DeclineReason)
        'TODO: This line of code loads data into the 'DS_SQL_ResumeSource.ResumeSource' table. You can move, or remove it, as needed.
        Me.ResumeSourceTableAdapter1.Fill(Me.DS_SQL_ResumeSource.ResumeSource)
        'TODO: This line of code loads data into the 'DS_SQL_Recruiter.Recruiter' table. You can move, or remove it, as needed.
        Me.RecruiterTableAdapter1.Fill(Me.DS_SQL_Recruiter.Recruiter)
        'TODO: This line of code loads data into the 'DS_SQL_CompanyList.CompanyList' table. You can move, or remove it, as needed.
        Me.CompanyListTableAdapter1.Fill(Me.DS_SQL_CompanyList.CompanyList)
        'TODO: This line of code loads data into the 'DS_SQL_JobTable_FormCandidate.JobTable' table. You can move, or remove it, as needed.
        Me.JobTableTableAdapter1.Fill(Me.DS_SQL_JobTable_FormCandidate.JobTable)


        '------------------------------- Add Recruiter in Combobox -----------------------------
        Try
            SQLConn.Dispose()
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()
            Dim DR As SqlDataReader
            '------- Add List Item in Recruiter 
            SQLComm = New SqlCommand("SELECT RecruiterName FROM Recruiter", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            Me.BreakdownRecruiter.Items.Add(" ")
            Me.ComboBoxAnalysisRecruiter.Items.Add("ALL")
            Me.DashboardRecruiter.Items.Add("ALL")
            Me.BreakdownRecruiter.Items.Add("ALL")
            If DR.HasRows = True Then
                While DR.Read()
                    Me.ComboBoxAnalysisRecruiter.Items.Add(DR("RecruiterName"))
                    Me.DashboardRecruiter.Items.Add(DR("RecruiterName"))
                    Me.BreakdownRecruiter.Items.Add(DR("RecruiterName"))
                End While
                DR.Close()
            End If

            SQLComm.ResetCommandTimeout()
            '----------------------------------------
            '------- Add List Item in Company Name 
            SQLComm = New SqlCommand("SELECT CompanyName FROM CompanyList", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            Me.BreakdownCompany.Items.Add(" ")
            Me.BreakdownCompany.Items.Add("ALL")
            Me.attr_company.Items.Add("ALL")
            If DR.HasRows = True Then
                While DR.Read()
                    Me.BreakdownCompany.Items.Add(DR("CompanyName"))
                    Me.attr_company.Items.Add(DR("CompanyName"))
                End While
                DR.Close()
            End If

            SQLComm.ResetCommandTimeout()
            '----------------------------------------
            '------- Add List Item in Company Group
            SQLComm = New SqlCommand("SELECT DISTINCT CompanyGroup FROM CompanyList", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            Me.BreakdownGroupCompany.Items.Add(" ")
            Me.BreakdownGroupCompany.Items.Add("ALL")
            Me.attr_groupcompany.Items.Add("ALL")
            If DR.HasRows = True Then
                While DR.Read()
                    Me.BreakdownGroupCompany.Items.Add(DR("CompanyGroup"))
                    Me.attr_groupcompany.Items.Add(DR("CompanyGroup"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()
            '----------------------------------------
            '------- Add List Item in FY
            SQLComm = New SqlCommand("SELECT FY_Name FROM FY", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            Me.ComboBoxFY1.Items.Add("ALL")
            Me.ComboBoxFY2.Items.Add("ALL")
            Me.ComboBoxFY3.Items.Add("ALL")
            Me.ComboBoxFY4.Items.Add("ALL")
            Me.ComboBoxFY5.Items.Add("ALL")
            Me.ComboBoxFY6.Items.Add("ALL")
            Me.ComboBoxFY7.Items.Add("ALL")
            Me.ComboBoxFY8.Items.Add("ALL")
            Me.ComboBoxFY9.Items.Add("ALL")
            Me.ComboBoxFY10.Items.Add("ALL")
            If DR.HasRows = True Then
                While DR.Read()
                    Me.ComboBoxFY1.Items.Add(DR("FY_Name"))
                    Me.ComboBoxFY2.Items.Add(DR("FY_Name"))
                    Me.ComboBoxFY3.Items.Add(DR("FY_Name"))
                    Me.ComboBoxFY4.Items.Add(DR("FY_Name"))
                    Me.ComboBoxFY5.Items.Add(DR("FY_Name"))
                    Me.ComboBoxFY6.Items.Add(DR("FY_Name"))
                    Me.ComboBoxFY7.Items.Add(DR("FY_Name"))
                    Me.ComboBoxFY8.Items.Add(DR("FY_Name"))
                    Me.ComboBoxFY9.Items.Add(DR("FY_Name"))
                    Me.ComboBoxFY10.Items.Add(DR("FY_Name"))
                    Me.ComboBoxFY11.Items.Add(DR("FY_Name"))
                    Me.ComboBoxFY12.Items.Add(DR("FY_Name"))
                    Me.ComboBoxFY_CPH.Items.Add(DR("FY_Name"))
                End While
            End If
            DR.Close()

            '----------------------------------------
            '------- Set Current FY --------------------
            SQLComm = New SqlCommand("SELECT FY_Name FROM FY Where SetCurrent = 'Yes'", SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DT As New DataTable
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DT)
            ComboBoxFY1.DataBindings.Add("Text", DT, "FY_Name")
            ComboBoxFY1.DataBindings.Clear()
            'ComboBoxFY11.DataBindings.Clear()
            ComboBoxFY11.Text = ComboBoxFY1.Text
            ComboBoxFY12.Text = ComboBoxFY1.Text
            '-------------------------------------------
            ComboBoxAnalysisRecruiter.SelectedIndex = 0
            DashboardRecruiter.Text = FormTop.ComboBoxAppDetailsRecruiter.Text
            ComboBoxFY2.Text = ComboBoxFY1.Text
            ComboBoxFY3.Text = ComboBoxFY1.Text
            ComboBoxFY4.Text = ComboBoxFY1.Text
            ComboBoxFY5.Text = ComboBoxFY1.Text
            ComboBoxFY6.Text = ComboBoxFY1.Text
            ComboBoxFY7.Text = ComboBoxFY1.Text
            ComboBoxFY8.Text = ComboBoxFY1.Text
            ComboBoxFY9.Text = ComboBoxFY1.Text
            ComboBoxFY10.Text = ComboBoxFY1.Text
            ComboBoxFY_CPH.Text = ComboBoxFY1.Text
            SQLComm.Dispose()
            SQLConn.Dispose()
            DA.Dispose()
            DT.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
            SQLConn.Dispose()
        End Try

        ''---------------------------------------------------
        DateRangeFrom4.Value = Date.Today
        DateRangeTo4.Value = Date.Today
        DateRangeFrom5.Value = Date.Today
        DateRangeTo5.Value = Date.Today
        DateRangeFrom6.Value = Date.Today
        DateRangeTo6.Value = Date.Today
        DateRangeFrom7.Value = Date.Today
        DateRangeTo7.Value = Date.Today
        attr_groupcompany.SelectedIndex = 0
        attr_company.SelectedIndex = 0

        Dim FY_Start_Year As Integer = If(ComboBoxFY1.Text <> "ALL", Mid(ComboBoxFY1.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY1.Text <> "ALL", Mid(ComboBoxFY1.Text, 3, 2) & Mid(ComboBoxFY1.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"


        '---------------------------------- Data for Funnel  -------------------------------------------

        Try
            SQLConn.Dispose()
            SQLConn.ConnectionString = ConnStr
            SQLConn.Open()

            '-------------------- Load Funnel Chart -------------------------
            Me.FunnelChart1.Series("Series1").Points.Clear()

            '--------------------Screening Count -------------------------------------------------------------------------------------

            If DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Screening = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text <> "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Screening = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Screening = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Screening = 'Yes'", SQLConn)
            End If

            Me.FunnelChart1.Series("Series1").Points.AddXY("SCREENED", SQLComm.ExecuteScalar)

            '--------------------Shared Count -------------------------------------------------------------------------------------
            If DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Shared = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text <> "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Shared = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Shared = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Shared = 'Yes'", SQLConn)
            End If

            Me.FunnelChart1.Series("Series1").Points.AddXY("SHARED", SQLComm.ExecuteScalar)

            '--------------------Approved Count -------------------------------------------------------------------------------------
            If DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Interview = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text <> "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Interview = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Interview = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Interview = 'Yes'", SQLConn)
            End If

            Me.FunnelChart1.Series("Series1").Points.AddXY("INTERVIEWED", SQLComm.ExecuteScalar)


            '--------------------Offered Count -------------------------------------------------------------------------------------
            If DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text <> "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Offer = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Offer = 'Yes'", SQLConn)
            End If

            Me.FunnelChart1.Series("Series1").Points.AddXY("OFFERED", SQLComm.ExecuteScalar)

            '--------------------Offer accepted Count -------------------------------------------------------------------------------------
            If DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Accepted = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text <> "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Offer_Accepted = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Offer_Accepted = 'Yes'", SQLConn)
            End If

            Me.FunnelChart1.Series("Series1").Points.AddXY("OFFER ACCEPTED", SQLComm.ExecuteScalar)

            '--------------------join Count -------------------------------------------------------------------------------------
            If DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Joining = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text <> "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Joining = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Joining = 'Yes'", SQLConn)
            End If

            Me.FunnelChart1.Series("Series1").Points.AddXY("JOINED", SQLComm.ExecuteScalar)

            SQLComm.Dispose()
            SQLConn.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        SQLComm.Dispose()
        SQLConn.Dispose()
        End Try

        '-------------------------------------- Recruitment KPI Calculation ---------------------------------------------------------
        Try
            SQLConn.Dispose()
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()
            If ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Interview = 'Yes' AND Rejected = 'No'", SQLConn)
                qc.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer = 'Yes'", SQLConn)
                Dim offer As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Accepted = 'Yes'", SQLConn)
                oar.Text = FormatPercent(SQLComm.ExecuteScalar / offer, "0")
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED'", SQLConn)
                ttf.Text = FormatNumber(SQLComm.ExecuteScalar, 0) & " Days"
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'JOINED' or Job_Status = 'OPEN' or Job_Status = 'OFFERED' ", SQLConn)
                Dim totalposition As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'JOINED'", SQLConn)
                htg.Text = FormatPercent(SQLComm.ExecuteScalar / totalposition, "0")

                Dim total_joined As Integer
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Joining = 'Yes'", SQLConn)
                total_joined = SQLComm.ExecuteScalar
                Dim total_recruitmentcost As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Sum(Total) FROM RecruitmentCost", SQLConn)
                total_recruitmentcost = SQLComm.ExecuteScalar
                Dim total_recruitersalary As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Sum(Salary) FROM RecruiterSalary", SQLConn)
                total_recruitersalary = SQLComm.ExecuteScalar
                cph.Text = "Rs. " & FormatNumber((total_recruitmentcost + total_recruitersalary) / total_joined, "0")

            Else

                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Interview = 'Yes' AND Rejected = 'No'", SQLConn)
                qc.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes'", SQLConn)
                Dim offer As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes'", SQLConn)
                oar.Text = FormatPercent(SQLComm.ExecuteScalar / offer, "0")
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED'", SQLConn)
                ttf.Text = FormatNumber(SQLComm.ExecuteScalar, 0) & " Days"
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & " AND Job_Status = 'JOINED') or Job_Status = 'OPEN' or Job_Status = 'OFFERED' ", SQLConn)
                Dim totalposition As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED'", SQLConn)
                htg.Text = FormatPercent(SQLComm.ExecuteScalar / totalposition, "0")

                Dim total_joined As Integer
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes'", SQLConn)
                total_joined = SQLComm.ExecuteScalar
                Dim total_recruitmentcost As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Sum(Total) FROM RecruitmentCost Where (Month >=" & FY_Start_Date & " AND Month <= " & FY_End_Date & ")", SQLConn)
                total_recruitmentcost = SQLComm.ExecuteScalar
                Dim total_recruitersalary As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Sum(Salary) FROM RecruiterSalary Where (Month >=" & FY_Start_Date & " AND Month <= " & FY_End_Date & ")", SQLConn)
                total_recruitersalary = SQLComm.ExecuteScalar
                cph.Text = "Rs. " & FormatNumber((total_recruitmentcost + total_recruitersalary) / total_joined, "0")

            End If
            SQLComm.Dispose()
            SQLConn.Dispose()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            SQLConn.Dispose()
            SQLComm.Dispose()
        End Try

        BreakdownRecruiter.SelectedIndex = 0
        BreakdownCompany.SelectedIndex = 0
        BreakdownGroupCompany.SelectedIndex = 0

        '---------- Run attrition rate ---------------
        Button_Refresh11_Click(sender, e)
        Label_attrition.Text = ytd_attr.Text
        '---------------------------------------------
    End Sub




    Private Sub Button_Query_Click(sender As Object, e As EventArgs) Handles Button_Refresh4.Click

        Dim FY_Start_Year As Integer = If(ComboBoxFY4.Text <> "ALL", Mid(ComboBoxFY4.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY4.Text <> "ALL", Mid(ComboBoxFY4.Text, 3, 2) & Mid(ComboBoxFY4.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        If RadioButtonDateRange.Checked = True And DateRangeFrom4.Value > DateRangeTo4.Value Then
            MessageBox.Show("Check Date Range !!!")
            DateRangeTo4.Focus()
            Exit Sub
        End If

        Dim i As Integer
        SQLConn.Dispose()
        SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
        SQLComm.Connection = SQLConn
        ProgressQuery.Show()
        ProgressQuery.Minimum = 0
        ProgressQuery.Maximum = DataGridView1.RowCount
        SQLConn.Open()
        SQLComm.Connection = SQLConn

        '----------------------------------------Position Wise -----------------------------------------------
        Try
            If RadioButtonFY.Checked = True Then
                If ComboBoxFY4.Text = "ALL" Then
                    For i = 0 To DataGridView1.Rows.Count - 1
                        Application.DoEvents()
                        ProgressQuery.Value = i
                        '------Screened Count ---------------------------------------
                        Dim ScreenCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Screening = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        ScreenCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Shared Count ---------------------------------------
                        Dim SharedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Shared = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        SharedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Approved Count ---------------------------------------
                        Dim ApprovedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Interview = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        ApprovedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Invited Count ---------------------------------------
                        Dim InvitedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Invited = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        InvitedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Visited Count ---------------------------------------
                        Dim VisitedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Visited = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        VisitedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Offer Count ---------------------------------------
                        Dim OfferedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        OfferedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Offer_accepted Count ---------------------------------------
                        Dim OfferacceptedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer_Accepted = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        OfferacceptedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Offer_declined Count ---------------------------------------
                        Dim OfferdeclinedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer_Status = 'Declined' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        OfferdeclinedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Join Count ---------------------------------------
                        Dim JoinCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Joining = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        JoinCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""

                        '------To Join Count ---------------------------------------
                        Dim ToJoinCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Joining_Date > '" & Date.Today & "' And Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        ToJoinCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""

                        SQLComm.Parameters.Clear()


                        '------Offer To Join Count ---------------------------------------
                        Dim OfferToJoinCount As Decimal
                        If OfferedCount = 0 Or JoinCount = 0 Then
                            OfferToJoinCount = "0"
                        Else
                            OfferToJoinCount = (JoinCount / OfferedCount) * 100
                        End If

                        SQLComm.Connection = SQLConn
                        SQLComm.CommandText = ("UPDATE JobTable Set SCREENED = @SCREENED,Shared=@Shared, APPROVED =@APPROVED, INVITED =@INVITED, VISITED =@VISITED, OFFERED =@OFFERED, OFFER_ACCEPTED =@OFFER_ACCEPTED, OFFER_DECLINED =@OFFER_DECLINED, JOINED =@JOINED, TO_JOIN =@TO_JOIN, OFFER_TO_JOIN_RATIO =@OFFER_TO_JOIN_RATIO Where Job_ID = '" & DataGridView1.Item(0, i).Value & "'")

                        SQLComm.Parameters.AddWithValue("@SCREENED", SqlDbType.Char).Value = ScreenCount
                        SQLComm.Parameters.AddWithValue("@SHARED", SqlDbType.Char).Value = SharedCount
                        SQLComm.Parameters.AddWithValue("@APPROVED", SqlDbType.Char).Value = ApprovedCount
                        SQLComm.Parameters.AddWithValue("@INVITED", SqlDbType.Char).Value = InvitedCount
                        SQLComm.Parameters.AddWithValue("@VISITED", SqlDbType.Char).Value = VisitedCount
                        SQLComm.Parameters.AddWithValue("@OFFERED", SqlDbType.Char).Value = OfferedCount
                        SQLComm.Parameters.AddWithValue("@OFFER_ACCEPTED", SqlDbType.Char).Value = OfferacceptedCount
                        SQLComm.Parameters.AddWithValue("@OFFER_DECLINED", SqlDbType.Char).Value = OfferdeclinedCount
                        SQLComm.Parameters.AddWithValue("@JOINED", SqlDbType.Char).Value = JoinCount
                        SQLComm.Parameters.AddWithValue("@TO_JOIN", SqlDbType.Char).Value = ToJoinCount
                        SQLComm.Parameters.AddWithValue("@OFFER_TO_JOIN_RATIO", SqlDbType.Float).Value = OfferToJoinCount

                        SQLComm.ExecuteNonQuery()

                    Next i
                    MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'DataGridView1.DataSource = DS_SQL_JobTable_FormCandidate.JobTable

                Else

                    For i = 0 To DataGridView1.Rows.Count - 1
                        Application.DoEvents()
                        ProgressQuery.Value = i
                        '------Screened Count ---------------------------------------
                        Dim ScreenCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Screening = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        ScreenCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Shared Count ---------------------------------------
                        Dim SharedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Shared = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        SharedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Approved Count ---------------------------------------
                        Dim ApprovedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Interview = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        ApprovedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Invited Count ---------------------------------------
                        Dim InvitedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Invited_Date >=" & FY_Start_Date & " AND Invited_Date <= " & FY_End_Date & ") AND Invited = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        InvitedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Visited Count ---------------------------------------
                        Dim VisitedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Visited_Date >=" & FY_Start_Date & " AND Visited_Date <= " & FY_End_Date & ") AND Visited = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        VisitedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Offer Count ---------------------------------------
                        Dim OfferedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        OfferedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Offer_accepted Count ---------------------------------------
                        Dim OfferacceptedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        OfferacceptedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Offer_declined Count ---------------------------------------
                        Dim OfferdeclinedCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer_Status = 'Declined' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        OfferdeclinedCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""
                        '------Join Count ---------------------------------------
                        Dim JoinCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        JoinCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""

                        '------To Join Count ---------------------------------------
                        Dim ToJoinCount As Integer
                        SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining_Date > '" & Date.Today & "' And Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                        SQLComm.CommandTimeout = 30
                        ToJoinCount = SQLComm.ExecuteScalar
                        SQLComm.CommandText = ""

                        SQLComm.Parameters.Clear()


                        '------Offer To Join Count ---------------------------------------
                        Dim OfferToJoinCount As Decimal
                        If OfferedCount = 0 Or JoinCount = 0 Then
                            OfferToJoinCount = "0"
                        Else
                            OfferToJoinCount = (JoinCount / OfferedCount) * 100
                        End If

                        SQLComm.Connection = SQLConn
                        SQLComm.CommandText = ("UPDATE JobTable Set SCREENED = @SCREENED,Shared=@Shared, APPROVED =@APPROVED, INVITED =@INVITED, VISITED =@VISITED, OFFERED =@OFFERED, OFFER_ACCEPTED =@OFFER_ACCEPTED, OFFER_DECLINED =@OFFER_DECLINED, JOINED =@JOINED, TO_JOIN =@TO_JOIN, OFFER_TO_JOIN_RATIO =@OFFER_TO_JOIN_RATIO Where Job_ID = '" & DataGridView1.Item(0, i).Value & "'")

                        SQLComm.Parameters.AddWithValue("@SCREENED", SqlDbType.Char).Value = ScreenCount
                        SQLComm.Parameters.AddWithValue("@SHARED", SqlDbType.Char).Value = SharedCount
                        SQLComm.Parameters.AddWithValue("@APPROVED", SqlDbType.Char).Value = ApprovedCount
                        SQLComm.Parameters.AddWithValue("@INVITED", SqlDbType.Char).Value = InvitedCount
                        SQLComm.Parameters.AddWithValue("@VISITED", SqlDbType.Char).Value = VisitedCount
                        SQLComm.Parameters.AddWithValue("@OFFERED", SqlDbType.Char).Value = OfferedCount
                        SQLComm.Parameters.AddWithValue("@OFFER_ACCEPTED", SqlDbType.Char).Value = OfferacceptedCount
                        SQLComm.Parameters.AddWithValue("@OFFER_DECLINED", SqlDbType.Char).Value = OfferdeclinedCount
                        SQLComm.Parameters.AddWithValue("@JOINED", SqlDbType.Char).Value = JoinCount
                        SQLComm.Parameters.AddWithValue("@TO_JOIN", SqlDbType.Char).Value = ToJoinCount
                        SQLComm.Parameters.AddWithValue("@OFFER_TO_JOIN_RATIO", SqlDbType.Float).Value = OfferToJoinCount

                        SQLComm.ExecuteNonQuery()

                    Next i
                    MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'DataGridView1.DataSource = DS_SQL_JobTable_FormCandidate.JobTable
                End If

            Else

                For i = 0 To DataGridView1.Rows.Count - 1
                    Application.DoEvents()
                    ProgressQuery.Value = i
                    '------Screened Count ---------------------------------------
                    Dim ScreenCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Screening_Date >='" & DateRangeFrom4.Value & "' AND Screening_Date <= '" & DateRangeTo4.Value & "') AND Screening = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ScreenCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Shared Count ---------------------------------------
                    Dim SharedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Shared_Date >='" & DateRangeFrom4.Value & "' AND Shared_Date <=' " & DateRangeTo4.Value & "') AND Shared = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    SharedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Approved Count ---------------------------------------
                    Dim ApprovedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Interview_Date >='" & DateRangeFrom4.Value & "' AND Interview_Date <=' " & DateRangeTo4.Value & "') AND Interview = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ApprovedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Invited Count ---------------------------------------
                    Dim InvitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Invited_Date >='" & DateRangeFrom4.Value & "' AND Invited_Date <=' " & DateRangeTo4.Value & "') AND Invited = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    InvitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Visited Count ---------------------------------------
                    Dim VisitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Visited_Date >='" & DateRangeFrom4.Value & "' AND Visited_Date <=' " & DateRangeTo4.Value & "') AND Visited = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    VisitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer Count ---------------------------------------
                    Dim OfferedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >='" & DateRangeFrom4.Value & "' AND Offer_Date <=' " & DateRangeTo4.Value & "') AND Offer = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_accepted Count ---------------------------------------
                    Dim OfferacceptedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >='" & DateRangeFrom4.Value & "' AND Offer_Accepted_Date <=' " & DateRangeTo4.Value & "') AND Offer_Accepted = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferacceptedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_declined Count ---------------------------------------
                    Dim OfferdeclinedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >='" & DateRangeFrom4.Value & "' AND Offer_Date <=' " & DateRangeTo4.Value & "') AND Offer_Status = 'Declined' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                    OfferdeclinedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Join Count ---------------------------------------
                    Dim JoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >='" & DateRangeFrom4.Value & "' AND Joining_Date <=' " & DateRangeTo4.Value & "') AND Joining = 'Yes' and Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    JoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    '------To Join Count ---------------------------------------
                    Dim ToJoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >='" & DateRangeFrom4.Value & "' AND Joining_Date <=' " & DateRangeTo4.Value & "') AND Joining_Date > '" & Date.Today & "' And Job_ID = '" & DataGridView1.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ToJoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Parameters.Clear()


                    '------Offer To Join Count ---------------------------------------
                    Dim OfferToJoinCount As Decimal
                    If OfferedCount = 0 Or JoinCount = 0 Then
                        OfferToJoinCount = "0"
                    Else
                        OfferToJoinCount = (JoinCount / OfferedCount) * 100
                    End If

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE JobTable Set SCREENED = @SCREENED,Shared=@Shared, APPROVED =@APPROVED, INVITED =@INVITED, VISITED =@VISITED, OFFERED =@OFFERED, OFFER_ACCEPTED =@OFFER_ACCEPTED, OFFER_DECLINED =@OFFER_DECLINED, JOINED =@JOINED, TO_JOIN =@TO_JOIN, OFFER_TO_JOIN_RATIO =@OFFER_TO_JOIN_RATIO Where Job_ID = '" & DataGridView1.Item(0, i).Value & "'")

                    SQLComm.Parameters.AddWithValue("@SCREENED", SqlDbType.Char).Value = ScreenCount
                    SQLComm.Parameters.AddWithValue("@SHARED", SqlDbType.Char).Value = SharedCount
                    SQLComm.Parameters.AddWithValue("@APPROVED", SqlDbType.Char).Value = ApprovedCount
                    SQLComm.Parameters.AddWithValue("@INVITED", SqlDbType.Char).Value = InvitedCount
                    SQLComm.Parameters.AddWithValue("@VISITED", SqlDbType.Char).Value = VisitedCount
                    SQLComm.Parameters.AddWithValue("@OFFERED", SqlDbType.Char).Value = OfferedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_ACCEPTED", SqlDbType.Char).Value = OfferacceptedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_DECLINED", SqlDbType.Char).Value = OfferdeclinedCount
                    SQLComm.Parameters.AddWithValue("@JOINED", SqlDbType.Char).Value = JoinCount
                    SQLComm.Parameters.AddWithValue("@TO_JOIN", SqlDbType.Char).Value = ToJoinCount
                    SQLComm.Parameters.AddWithValue("@OFFER_TO_JOIN_RATIO", SqlDbType.Float).Value = OfferToJoinCount

                    SQLComm.ExecuteNonQuery()

                Next i

                SQLConn.Close()
                MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'DataGridView1.DataSource = DS_SQL_JobTable_FormCandidate.JobTable

                ''---------------------Refresh Chart1 ------------------------------
                'Me.Chart1.Series("Hired").Points.Clear()
                'For i = 0 To DataGridView3.Rows.Count - 1
                '    Me.Chart1.Series("Hired").Points.AddXY(DataGridView3.Item(0, i).Value, DataGridView3.Item(9, i).Value)
                'Next i
                ''-------------------------------------------------------------

                ''---------------------Refresh Chart2 ------------------------------
                'Me.Chart2.Series("Series1").Points.Clear()
                'For i = 0 To DataGridView3.Rows.Count - 1
                '    Me.Chart2.Series("Series1").Points.AddXY(DataGridView3.Item(0, i).Value, DataGridView3.Item(11, i).Value)
                'Next i
            End If

            DataGridView1.DataSource = DS_SQL_JobTable_FormCandidate.JobTable
            Me.JobTableTableAdapter1.Fill(Me.DS_SQL_JobTable_FormCandidate.JobTable)

            DataGridView1.Refresh()
            SQLComm.Parameters.Clear()
            ProgressQuery.Hide()
            ProgressQuery.Minimum = 0


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
            SQLConn.Close()
        End Try

    End Sub

    Private Sub ButtonShowAll_Click(sender As Object, e As EventArgs) Handles ButtonShowAll.Click
        Try

            SQLConn.Close()
            '-------------------- Fetch All Records from JobTable-----------------------------------
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DT As New DataTable
            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM JOBTABLE", SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DataGridView1.DataSource = DT
            DA.Fill(DT)
            SQLConn.Close()
            '---------------------------------------------------------------------------------------
            ComboBoxAnalysisRecruiter.SelectedIndex = 0

            '------------------------ Rows Count-------------------------
            RowsCount.Text = DataGridView1.RowCount

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
            SQLConn.Close()
        End Try
    End Sub

    Private Sub ButtonFilterOpen_Click(sender As Object, e As EventArgs) Handles ButtonFilterOpen.Click
        Try

            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            If ComboBoxAnalysisRecruiter.Text = "" Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'OPEN'", SQLConn)
            ElseIf ComboBoxAnalysisRecruiter.Text = "ALL" Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'OPEN'", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'OPEN' and Recruiter = '" & ComboBoxAnalysisRecruiter.Text & "'", SQLConn)
            End If

            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DS)
            DataGridView1.DataSource = DS.Tables(0)
            SQLConn.Close()

            '------------------------ Rows Count-------------------------
            RowsCount.Text = DataGridView1.RowCount
            '------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub


    Private Sub ButtonFilterOffered_Click(sender As Object, e As EventArgs) Handles ButtonFilterOffered.Click
        Try
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            If ComboBoxAnalysisRecruiter.Text = "" Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'OFFERED'", SQLConn)
            ElseIf ComboBoxAnalysisRecruiter.Text = "ALL" Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'OFFERED'", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'OFFERED' and Recruiter = '" & ComboBoxAnalysisRecruiter.Text & "'", SQLConn)
            End If
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DS)
            DataGridView1.DataSource = DS.Tables(0)
            SQLConn.Close()

            '------------------------ Rows Count-------------------------
            RowsCount.Text = DataGridView1.RowCount
            '------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub

    Private Sub ButtonFilterJoined_Click(sender As Object, e As EventArgs) Handles ButtonFilterJoined.Click
        Try
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            If ComboBoxAnalysisRecruiter.Text = "" Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'JOINED'", SQLConn)
            ElseIf ComboBoxAnalysisRecruiter.Text = "ALL" Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'JOINED'", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'JOINED' and Recruiter = '" & ComboBoxAnalysisRecruiter.Text & "'", SQLConn)
            End If
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DS)
            DataGridView1.DataSource = DS.Tables(0)
            SQLConn.Close()

            '------------------------ Rows Count-------------------------
            RowsCount.Text = DataGridView1.RowCount
            '------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub

    Private Sub ButtonFilterCancelled_Click(sender As Object, e As EventArgs) Handles ButtonFilterCancelled.Click
        Try
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            If ComboBoxAnalysisRecruiter.Text = "" Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'CANCELLED'", SQLConn)
            ElseIf ComboBoxAnalysisRecruiter.Text = "ALL" Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'CANCELLED'", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'CANCELLED' and Recruiter = '" & ComboBoxAnalysisRecruiter.Text & "'", SQLConn)
            End If
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DS)
            DataGridView1.DataSource = DS.Tables(0)
            SQLConn.Close()

            '------------------------ Rows Count-------------------------
            RowsCount.Text = DataGridView1.RowCount
            '------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub

    Private Sub ButtonFilterOnHold_Click(sender As Object, e As EventArgs) Handles ButtonFilterOnHold.Click
        Try
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            If ComboBoxAnalysisRecruiter.Text = "" Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'ON-HOLD'", SQLConn)
            ElseIf ComboBoxAnalysisRecruiter.Text = "ALL" Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'ON-HOLD'", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'ON-HOLD' and Recruiter = '" & ComboBoxAnalysisRecruiter.Text & "'", SQLConn)
            End If
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DS)
            DataGridView1.DataSource = DS.Tables(0)
            SQLConn.Close()

            '------------------------ Rows Count-------------------------
            RowsCount.Text = DataGridView1.RowCount
            '------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub

    Private Sub Btn_ExportToExcel_Click(sender As Object, e As EventArgs) Handles Btn_ExportToExcel.Click
        Try
            'FilePath = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & ".xls"

            'Dim default_location As String = Path.GetTempPath.ToString & "RecruitmentPositionExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            Dim default_location As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\JobPositions_Data_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xlsx"
            'Dim default_location As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            'Creating dataset to export
            Dim dset As New DataSet
            'add table to dataset
            dset.Tables.Add()
            'add column to that table
            For i As Integer = 0 To DataGridView1.ColumnCount - 1
                dset.Tables(0).Columns.Add(DataGridView1.Columns(i).HeaderText)
            Next
            'add rows to the table
            Dim dr1 As DataRow
            For i As Integer = 0 To DataGridView1.RowCount - 1
                Application.DoEvents()
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To DataGridView1.Columns.Count - 1
                    dr1(j) = DataGridView1.Rows(i).Cells(j).Value
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
                .Sheets(1).Name = "JobPositions"
            End With

            Dim dt As System.Data.DataTable = dset.Tables(0)
            wSheet.Cells(1).value = "Recruitment Data"


            For j = 0 To DataGridView1.ColumnCount - 1
                Application.DoEvents()
                wSheet.Cells(1, j + 1).value = DataGridView1.Columns(j).HeaderText
                wSheet.Cells(1, j + 1).interior.color = Color.LightCyan
                wSheet.Cells(1, j + 1).Font.Bold = True

            Next j

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = DataGridView1.RowCount
            ProgressBar1.Show()
            For i = 0 To DataGridView1.RowCount - 1
                Application.DoEvents()
                For J = 0 To DataGridView1.ColumnCount - 1
                    wSheet.Cells(i + 2, J + 1).value = DataGridView1.Rows(i).Cells(J).Value.ToString
                Next J
                ProgressBar1.Value = i
            Next i

            wSheet.Columns.AutoFit()
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

            ProgressBar1.Value = 0
            ProgressBar1.Hide()

            'MessageBox.Show("Successful")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub

    Private Sub ComboBoxAnalysisRecruiter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAnalysisRecruiter.SelectedIndexChanged
        Try
            Dim ConnStr As String
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            'SQLConn.Open()
            SQLConn.Close()
            SQLConn.ConnectionString = ConnStr

            If ComboBoxAnalysisRecruiter.Text = "" Then
                SQLComm = New SqlCommand("SELECT * FROM JobTable", SQLConn)
            ElseIf ComboBoxAnalysisRecruiter.Text = "ALL" Then
                SQLComm = New SqlCommand("SELECT * FROM JobTable", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM JobTable WHERE  Recruiter = " & "'" & ComboBoxAnalysisRecruiter.Text & "'", SQLConn)
            End If

            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DS)
            DataGridView1.DataSource = DS.Tables(0)
            SQLConn.Close()

            '------------------------ Rows Count-------------------------
            RowsCount.Text = DataGridView1.RowCount
            '------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub

    Private Sub ButtonCompanyExportToExcel_Click(sender As Object, e As EventArgs) Handles ButtonCompanyExportToExcel.Click
        Try
            'FilePath = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & ".xls"

            'Dim default_location As String = Path.GetTempPath.ToString & "RecruitmentCompanyExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            Dim default_location As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Company_Data_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xlsx"
            'Dim default_location As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            'Creating dataset to export
            Dim dset As New DataSet
            'add table to dataset
            dset.Tables.Add()
            'add column to that table
            For i As Integer = 0 To DataGridView2.ColumnCount - 1
                dset.Tables(0).Columns.Add(DataGridView2.Columns(i).HeaderText)
            Next
            'add rows to the table
            Dim dr1 As DataRow
            For i As Integer = 0 To DataGridView2.RowCount - 1
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To DataGridView2.Columns.Count - 1
                    dr1(j) = DataGridView2.Rows(i).Cells(j).Value
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
                .Sheets(1).Name = "JobPositions"
            End With

            Dim dt As System.Data.DataTable = dset.Tables(0)
            wSheet.Cells(1).value = "Recruitment Data"


            For J = 0 To DataGridView2.ColumnCount - 1
                wSheet.Cells(1, J + 1).value = DataGridView2.Columns(J).HeaderText
                wSheet.Cells(1, J + 1).interior.color = Color.LightCyan
                wSheet.Cells(1, J + 1).Font.Bold = True

            Next J


            For i = 0 To DataGridView2.RowCount - 1
                For J = 0 To DataGridView2.ColumnCount - 1
                    wSheet.Cells(i + 2, J + 1).value = DataGridView2.Rows(i).Cells(J).Value.ToString
                Next J
            Next i

            wSheet.Columns.AutoFit()
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

            'MessageBox.Show("Successful")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub

    Private Sub ButtonRecruiterExportToExcel_Click(sender As Object, e As EventArgs) Handles ButtonRecruiterExportToExcel.Click
        Try
            'FilePath = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & ".xls"

            'Dim default_location As String = Path.GetTempPath.ToString & "RecruitmentRecruiterExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            Dim default_location As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Recruiter_Data_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xlsx"
            'Dim default_location As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
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
            For i As Integer = 0 To DataGridView3.RowCount - 1
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
                .Sheets(1).Name = "JobPositions"
            End With

            Dim dt As System.Data.DataTable = dset.Tables(0)
            wSheet.Cells(1).value = "Recruitment Data"


            For J = 0 To DataGridView3.ColumnCount - 1
                wSheet.Cells(1, J + 1).value = DataGridView3.Columns(J).HeaderText
                wSheet.Cells(1, J + 1).interior.color = Color.LightCyan
                wSheet.Cells(1, J + 1).Font.Bold = True

            Next J


            For i = 0 To DataGridView3.RowCount - 1
                For J = 0 To DataGridView3.ColumnCount - 1
                    wSheet.Cells(i + 2, J + 1).value = DataGridView3.Rows(i).Cells(J).Value.ToString
                Next J
            Next i

            wSheet.Columns.AutoFit()
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

            'MessageBox.Show("Successful")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub

    Private Sub ButtonAppSourceExpToXL_Click(sender As Object, e As EventArgs) Handles ButtonAppSourceExpToXL.Click
        Try
            'FilePath = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & ".xls"

            'Dim default_location As String = Path.GetTempPath.ToString & "RecruitmentResumeSourceExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            Dim default_location As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\ResumeSource_Data_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xlsx"
            'Dim default_location As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            'Creating dataset to export
            Dim dset As New DataSet
            'add table to dataset
            dset.Tables.Add()
            'add column to that table
            For i As Integer = 0 To DataGridView4.ColumnCount - 1
                dset.Tables(0).Columns.Add(DataGridView4.Columns(i).HeaderText)
            Next
            'add rows to the table
            Dim dr1 As DataRow
            For i As Integer = 0 To DataGridView4.RowCount - 1
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To DataGridView4.Columns.Count - 1
                    dr1(j) = DataGridView4.Rows(i).Cells(j).Value
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
                .Sheets(1).Name = "JobPositions"
            End With

            Dim dt As System.Data.DataTable = dset.Tables(0)
            wSheet.Cells(1).value = "Recruitment Data"


            For J = 0 To DataGridView4.ColumnCount - 1
                wSheet.Cells(1, J + 1).value = DataGridView4.Columns(J).HeaderText
                wSheet.Cells(1, J + 1).interior.color = Color.LightCyan
                wSheet.Cells(1, J + 1).Font.Bold = True

            Next J


            For i = 0 To DataGridView4.RowCount - 1
                For J = 0 To DataGridView4.ColumnCount - 1
                    wSheet.Cells(i + 2, J + 1).value = DataGridView4.Rows(i).Cells(J).Value.ToString
                Next J
            Next i

            wSheet.Columns.AutoFit()
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

            'MessageBox.Show("Successful")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub

    Private Sub ButtonDeclineExportToExcel_Click(sender As Object, e As EventArgs) Handles ButtonDeclineExportToExcel.Click
        Try
            'FilePath = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & ".xls"

            'Dim default_location As String = Path.GetTempPath.ToString & "RecruitmentDeclineReasonExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            Dim default_location As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\DeclineReason_Data_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xlsx"
            'Dim default_location As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            'Creating dataset to export
            Dim dset As New DataSet
            'add table to dataset
            dset.Tables.Add()
            'add column to that table
            For i As Integer = 0 To DataGridView5.ColumnCount - 1
                dset.Tables(0).Columns.Add(DataGridView5.Columns(i).HeaderText)
            Next
            'add rows to the table
            Dim dr1 As DataRow
            For i As Integer = 0 To DataGridView5.RowCount - 1
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To DataGridView5.Columns.Count - 1
                    dr1(j) = DataGridView5.Rows(i).Cells(j).Value
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
                .Sheets(1).Name = "JobPositions"
            End With

            Dim dt As System.Data.DataTable = dset.Tables(0)
            wSheet.Cells(1).value = "Recruitment Data"


            For J = 0 To DataGridView5.ColumnCount - 1
                wSheet.Cells(1, J + 1).value = DataGridView5.Columns(J).HeaderText
                wSheet.Cells(1, J + 1).interior.color = Color.LightCyan
                wSheet.Cells(1, J + 1).Font.Bold = True

            Next J


            For i = 0 To DataGridView5.RowCount - 1
                For J = 0 To DataGridView5.ColumnCount - 1
                    wSheet.Cells(i + 2, J + 1).value = DataGridView5.Rows(i).Cells(J).Value.ToString
                Next J
            Next i

            wSheet.Columns.AutoFit()
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

            'MessageBox.Show("Successful")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub

    Private Sub ButtonRejectedByExportToExcel_Click(sender As Object, e As EventArgs) Handles ButtonRejectedByExportToExcel.Click
        Try
            'FilePath = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & ".xls"

            'Dim default_location As String = Path.GetTempPath.ToString & "RecruitmentRejectedByExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            Dim default_location As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\RejectedBy_Data_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xlsx"
            'Dim default_location As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            'Creating dataset to export
            Dim dset As New DataSet
            'add table to dataset
            dset.Tables.Add()
            'add column to that table
            For i As Integer = 0 To DataGridView6.ColumnCount - 1
                dset.Tables(0).Columns.Add(DataGridView6.Columns(i).HeaderText)
            Next
            'add rows to the table
            Dim dr1 As DataRow
            For i As Integer = 0 To DataGridView6.RowCount - 1
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To DataGridView6.Columns.Count - 1
                    dr1(j) = DataGridView6.Rows(i).Cells(j).Value
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
                .Sheets(1).Name = "JobPositions"
            End With

            Dim dt As System.Data.DataTable = dset.Tables(0)
            wSheet.Cells(1).value = "Recruitment Data"


            For J = 0 To DataGridView6.ColumnCount - 1
                wSheet.Cells(1, J + 1).value = DataGridView6.Columns(J).HeaderText
                wSheet.Cells(1, J + 1).interior.color = Color.LightCyan
                wSheet.Cells(1, J + 1).Font.Bold = True

            Next J


            For i = 0 To DataGridView6.RowCount - 1
                For J = 0 To DataGridView6.ColumnCount - 1
                    wSheet.Cells(i + 2, J + 1).value = DataGridView6.Rows(i).Cells(J).Value.ToString
                Next J
            Next i

            wSheet.Columns.AutoFit()
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

            'MessageBox.Show("Successful")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub

    Private Sub ButtonOfferDeclineReasonExportToXL_Click(sender As Object, e As EventArgs) Handles ButtonOfferDeclineReasonExportToXL.Click
        Try
            'FilePath = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & ".xls"

            'Dim default_location As String = Path.GetTempPath.ToString & "RecruitmentOfferDeclinedExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            Dim default_location As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\OfferDeclinedReason_Data_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xlsx"
            'Dim default_location As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            'Creating dataset to export
            Dim dset As New DataSet
            'add table to dataset
            dset.Tables.Add()
            'add column to that table
            For i As Integer = 0 To DataGridView7.ColumnCount - 1
                dset.Tables(0).Columns.Add(DataGridView7.Columns(i).HeaderText)
            Next
            'add rows to the table
            Dim dr1 As DataRow
            For i As Integer = 0 To DataGridView7.RowCount - 1
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To DataGridView7.Columns.Count - 1
                    dr1(j) = DataGridView7.Rows(i).Cells(j).Value
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
                .Sheets(1).Name = "JobPositions"
            End With

            Dim dt As System.Data.DataTable = dset.Tables(0)
            wSheet.Cells(1).value = "Recruitment Data"


            For J = 0 To DataGridView7.ColumnCount - 1
                wSheet.Cells(1, J + 1).value = DataGridView7.Columns(J).HeaderText
                wSheet.Cells(1, J + 1).interior.color = Color.LightCyan
                wSheet.Cells(1, J + 1).Font.Bold = True

            Next J


            For i = 0 To DataGridView7.RowCount - 1
                For J = 0 To DataGridView7.ColumnCount - 1
                    wSheet.Cells(i + 2, J + 1).value = DataGridView7.Rows(i).Cells(J).Value.ToString
                Next J
            Next i

            wSheet.Columns.AutoFit()
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

            'MessageBox.Show("Successful")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub

    Private Sub DashboardRecruiter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DashboardRecruiter.SelectedIndexChanged
        Try
            SQLConn.Dispose()
            SQLConn.ConnectionString = ConnStr
            SQLConn.Open()

            Dim FY_Start_Year As Integer = If(ComboBoxFY1.Text <> "ALL", Mid(ComboBoxFY1.Text, 3, 4), Today.Year)
            Dim FY_End_Year As Integer = If(ComboBoxFY1.Text <> "ALL", Mid(ComboBoxFY1.Text, 3, 2) & Mid(ComboBoxFY1.Text, 8, 2), Today.Year)
            Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
            Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

            '-------------------- Load Funnel Chart -------------------------
            Me.FunnelChart1.Series("Series1").Points.Clear()
            GroupBox1.Text = DashboardRecruiter.Text

            '--------------------Screening Count -------------------------------------------------------------------------------------

            If DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Screening = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text <> "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Screening = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Screening = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Screening = 'Yes'", SQLConn)
            End If

            Dim screen As Integer = SQLComm.ExecuteScalar
            Me.FunnelChart1.Series("Series1").Points.AddXY("SCREENED", SQLComm.ExecuteScalar)

            '--------------------Shared Count -------------------------------------------------------------------------------------
            If DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Shared = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text <> "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Shared = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Shared = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Shared = 'Yes'", SQLConn)
            End If

            Me.FunnelChart1.Series("Series1").Points.AddXY("SHARED", SQLComm.ExecuteScalar)
            Dim share As Integer = SQLComm.ExecuteScalar

            If share = 0 Or screen = 0 Then
                Y_share.Text = "0 IN 0"
                YP_share.Text = "0%"
            Else
                Y_share.Text = "1 IN " & Format(screen / share, "0.00")
                YP_share.Text = FormatPercent(share / screen, "0.00")
            End If

            '--------------------Approved Count -------------------------------------------------------------------------------------
            If DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Interview = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text <> "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Interview = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Interview = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Interview = 'Yes'", SQLConn)
            End If

            Me.FunnelChart1.Series("Series1").Points.AddXY("INTERVIEWED", SQLComm.ExecuteScalar)

            Dim interview As Integer = SQLComm.ExecuteScalar

            If interview = 0 Or share = 0 Then
                Y_Interview.Text = "0 IN 0"
                YP_interview.Text = "0%"
            Else
                Y_Interview.Text = "1 IN " & Format(share / interview, "0.00")
                YP_interview.Text = FormatPercent(interview / share, "0.00")
            End If


            '--------------------Offered Count -------------------------------------------------------------------------------------
            If DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text <> "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Offer = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Offer = 'Yes'", SQLConn)
            End If

            Me.FunnelChart1.Series("Series1").Points.AddXY("OFFERED", SQLComm.ExecuteScalar)

            Dim offer As Integer = SQLComm.ExecuteScalar
            If interview = 0 Or offer = 0 Then
                Y_offer.Text = "0 IN 0"
                YP_offer.Text = "0%"
            Else
                Y_offer.Text = "1 IN " & Format(interview / offer, "0.00")
                YP_offer.Text = FormatPercent(offer / interview, "0.00")
            End If
            '--------------------Offer accepted Count -------------------------------------------------------------------------------------
            If DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Accepted = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text <> "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Offer_Accepted = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Offer_Accepted = 'Yes'", SQLConn)
            End If

            Me.FunnelChart1.Series("Series1").Points.AddXY("OFFER ACCEPTED", SQLComm.ExecuteScalar)

            Dim offeraccept As Integer = SQLComm.ExecuteScalar
            If offeraccept = 0 Or offer = 0 Then
                Y_OfferAccept.Text = "0 IN 0"
                YP_OfferAccept.Text = "0%"
            Else
                Y_OfferAccept.Text = "1 IN " & Format(offer / offeraccept, "0.00")
                YP_OfferAccept.Text = FormatPercent(offeraccept / offer, "0.00")
            End If

            '--------------------join Count -------------------------------------------------------------------------------------
            If DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Joining = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text <> "ALL" And ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Joining = 'Yes'", SQLConn)
            ElseIf DashboardRecruiter.Text = "ALL" And ComboBoxFY1.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DashboardRecruiter.Text & "' and Joining = 'Yes'", SQLConn)
            End If

            Me.FunnelChart1.Series("Series1").Points.AddXY("JOINED", SQLComm.ExecuteScalar)


            Dim join As Integer = SQLComm.ExecuteScalar
            If offeraccept = 0 Or join = 0 Then
                Y_join.Text = "0 IN 0"
                YP_Join.Text = "0%"
            Else
                Y_join.Text = "1 IN " & Format(offeraccept / join, "0.00")
                YP_Join.Text = FormatPercent(join / offeraccept, "0.00")
            End If


            Me.FunnelChart1.Series("Series1").IsValueShownAsLabel = True

            SQLConn.Dispose()
            SQLComm.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()

        End Try


    End Sub




    Private Sub BreakdownRecruiter_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles BreakdownRecruiter.SelectedIndexChanged
        On Error Resume Next
        If BreakdownRecruiter.SelectedIndex = 0 Then
            Exit Sub
        Else
        End If
        '------------------------- Clear All Labels------------------------------------ 
        BD_J.Text = "0"
        BD_O.Text = "0"
        BD_OTJ.Text = "0%"
        BD_ATF.Text = "0 Days"
        BD_OA.Text = "0%"
        BD_OP.Text = "0"
        j_hc.Text = "0"
        j_me.Text = "0"
        j_hc_pr.Text = "0"
        j_hc_pv.Text = "0"
        j_hc_in.Text = "0"
        j_me_pr.Text = "0"
        j_me_pv.Text = "0"
        j_me_in.Text = "0"
        o_hc.Text = "0"
        o_me.Text = "0"
        o_hc_pr.Text = "0"
        o_hc_pv.Text = "0"
        o_hc_in.Text = "0"
        o_me_pr.Text = "0"
        o_me_pv.Text = "0"
        o_me_in.Text = "0"
        otj_hc.Text = "0%"
        otj_me.Text = "0%"
        otj_hc_pr.Text = "0%"
        otj_hc_pv.Text = "0%"
        otj_hc_in.Text = "0%"
        otj_me_pr.Text = "0%"
        otj_me_pv.Text = "0%"
        otj_me_in.Text = "0%"
        atf_hc.Text = "0 Days"
        atf_me.Text = "0 Days"
        atf_hc_pr.Text = "0 Days"
        atf_me_pr.Text = "0 Days"
        atf_hc_pv.Text = "0 Days"
        atf_me_pv.Text = "0 Days"
        atf_hc_in.Text = "0 Days"
        atf_me_in.Text = "0 Days"
        oa_hc.Text = "0%"
        oa_me.Text = "0%"
        oa_hc_pr.Text = "0%"
        oa_me_pr.Text = "0%"
        oa_hc_pv.Text = "0%"
        oa_me_pv.Text = "0%"
        oa_hc_in.Text = "0%"
        oa_me_in.Text = "0%"
        op_hc.Text = "0"
        op_me.Text = "0"
        op_hc_pr.Text = "0"
        op_me_pr.Text = "0"
        op_hc_pv.Text = "0"
        op_me_pv.Text = "0"
        op_hc_in.Text = "0"
        op_me_in.Text = "0"

        BreakdownCompany.SelectedIndex = 0
        BreakdownGroupCompany.SelectedIndex = 0
        '------------------------------------------------------------------------------
        'Try
        Dim FY_Start_Year As Integer = If(ComboBoxFY2.Text <> "ALL", Mid(ComboBoxFY2.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY2.Text <> "ALL", Mid(ComboBoxFY2.Text, 3, 2) & Mid(ComboBoxFY2.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        If ComboBoxFY2.Text = "ALL" Then

            If BreakdownRecruiter.Text = "ALL" Then

                btn_BreakDown_Refresh_Click(sender, e)

            Else

                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLComm.Connection = SQLConn

                '------------------------------------------Overall---------------------------------------------------------------------------------
                SQLConn.Open()
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Joining = 'Yes' AND Recruiter_Name = '" & BreakdownRecruiter.Text & "'", SQLConn)
                BD_J.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer = 'Yes' AND Recruiter_Name = '" & BreakdownRecruiter.Text & "'", SQLConn)
                BD_O.Text = SQLComm.ExecuteScalar

                If BD_J.Text = 0 Or BD_O.Text = 0 Then
                    BD_OTJ.Text = "0%"
                Else
                    BD_OTJ.Text = FormatPercent(BD_J.Text / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                BD_ATF.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Accepted = 'Yes' AND Recruiter_Name = '" & BreakdownRecruiter.Text & "'", SQLConn)
                If BD_O.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    BD_OA.Text = "0%"
                Else
                    BD_OA.Text = FormatPercent(SQLComm.ExecuteScalar / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If


                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                BD_OP.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offer to Join --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                If o_hc.Text = 0 Or j_hc.Text = 0 Then
                    otj_hc.Text = "0%"
                Else
                    otj_hc.Text = FormatPercent(j_hc.Text / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me.Text = 0 Or j_me.Text = 0 Then
                    otj_me.Text = "0%"
                Else
                    otj_me.Text = FormatPercent(j_me.Text / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Head/CXO --> Company wise ----------------
                If o_hc_pr.Text = 0 Or j_hc_pr.Text = 0 Then
                    otj_hc_pr.Text = "0%"
                Else
                    otj_hc_pr.Text = FormatPercent(j_hc_pr.Text / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_pv.Text = 0 Or j_hc_pv.Text = 0 Then
                    otj_hc_pv.Text = "0%"
                Else
                    otj_hc_pv.Text = FormatPercent(j_hc_pv.Text / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_in.Text = 0 Or j_hc_in.Text = 0 Then
                    otj_hc_in.Text = "0%"
                Else
                    otj_hc_in.Text = FormatPercent(j_hc_in.Text / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Mid/Entry --> Company wise ----------------
                If o_me_pr.Text = 0 Or j_me_pr.Text = 0 Then
                    otj_me_pr.Text = "0%"
                Else
                    otj_me_pr.Text = FormatPercent(j_me_pr.Text / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_pv.Text = 0 Or j_me_pv.Text = 0 Then
                    otj_me_pv.Text = "0%"
                Else
                    otj_me_pv.Text = FormatPercent(j_me_pv.Text / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_in.Text = 0 Or j_me_in.Text = 0 Then
                    otj_me_in.Text = "0%"
                Else
                    otj_me_in.Text = FormatPercent(j_me_in.Text / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If


                '------------------------------------------Avg Time to Fill --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                atf_hc.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Recruiter = '" & BreakdownRecruiter.Text & "' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Prototyze ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                atf_hc_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Recruiter = '" & BreakdownRecruiter.Text & "' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Pvt Unlimited ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                atf_hc_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                atf_me_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> InnerHeads ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                atf_hc_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                atf_me_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc.Text = "0%"
                Else
                    oa_hc.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me.Text = "0%"
                Else
                    oa_me.Text = FormatPercent(SQLComm.ExecuteScalar / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Prototyze---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pr.Text = "0%"
                Else
                    oa_hc_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pr.Text = "0%"
                Else
                    oa_me_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pv.Text = "0%"
                Else
                    oa_hc_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pv.Text = "0%"
                Else
                    oa_me_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_in.Text = "0%"
                Else
                    oa_hc_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_in.Text = "0%"
                Else
                    oa_me_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry ----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Prototyze----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_me_pr.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Pvt Unlimited----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_me_pv.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> InnerHeads----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_hc_in.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_me_in.Text = SQLComm.ExecuteScalar

                SQLConn.Dispose()
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message)
                '    SQLConn.Dispose()
                'End Try
            End If

        Else

            If BreakdownRecruiter.Text = "ALL" Then

                btn_BreakDown_Refresh_Click(sender, e)

            Else

                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLComm.Connection = SQLConn

                '------------------------------------------Overall---------------------------------------------------------------------------------
                SQLConn.Open()
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes' AND Recruiter_Name = '" & BreakdownRecruiter.Text & "'", SQLConn)
                BD_J.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes' AND Recruiter_Name = '" & BreakdownRecruiter.Text & "'", SQLConn)
                BD_O.Text = SQLComm.ExecuteScalar

                If BD_J.Text = 0 Or BD_O.Text = 0 Then
                    BD_OTJ.Text = "0%"
                Else
                    BD_OTJ.Text = FormatPercent(BD_J.Text / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                BD_ATF.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes' AND Recruiter_Name = '" & BreakdownRecruiter.Text & "'", SQLConn)
                If BD_O.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    BD_OA.Text = "0%"
                Else
                    BD_OA.Text = FormatPercent(SQLComm.ExecuteScalar / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If


                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                BD_OP.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offer to Join --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                If o_hc.Text = 0 Or j_hc.Text = 0 Then
                    otj_hc.Text = "0%"
                Else
                    otj_hc.Text = FormatPercent(j_hc.Text / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me.Text = 0 Or j_me.Text = 0 Then
                    otj_me.Text = "0%"
                Else
                    otj_me.Text = FormatPercent(j_me.Text / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Head/CXO --> Company wise ----------------
                If o_hc_pr.Text = 0 Or j_hc_pr.Text = 0 Then
                    otj_hc_pr.Text = "0%"
                Else
                    otj_hc_pr.Text = FormatPercent(j_hc_pr.Text / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_pv.Text = 0 Or j_hc_pv.Text = 0 Then
                    otj_hc_pv.Text = "0%"
                Else
                    otj_hc_pv.Text = FormatPercent(j_hc_pv.Text / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_in.Text = 0 Or j_hc_in.Text = 0 Then
                    otj_hc_in.Text = "0%"
                Else
                    otj_hc_in.Text = FormatPercent(j_hc_in.Text / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Mid/Entry --> Company wise ----------------
                If o_me_pr.Text = 0 Or j_me_pr.Text = 0 Then
                    otj_me_pr.Text = "0%"
                Else
                    otj_me_pr.Text = FormatPercent(j_me_pr.Text / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_pv.Text = 0 Or j_me_pv.Text = 0 Then
                    otj_me_pv.Text = "0%"
                Else
                    otj_me_pv.Text = FormatPercent(j_me_pv.Text / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_in.Text = 0 Or j_me_in.Text = 0 Then
                    otj_me_in.Text = "0%"
                Else
                    otj_me_in.Text = FormatPercent(j_me_in.Text / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If


                '------------------------------------------Avg Time to Fill --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                atf_hc.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Recruiter = '" & BreakdownRecruiter.Text & "' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Prototyze ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                atf_hc_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Recruiter = '" & BreakdownRecruiter.Text & "' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Pvt Unlimited ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                atf_hc_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                atf_me_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> InnerHeads ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                atf_hc_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                atf_me_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc.Text = "0%"
                Else
                    oa_hc.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me.Text = "0%"
                Else
                    oa_me.Text = FormatPercent(SQLComm.ExecuteScalar / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Prototyze---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pr.Text = "0%"
                Else
                    oa_hc_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pr.Text = "0%"
                Else
                    oa_me_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pv.Text = "0%"
                Else
                    oa_hc_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pv.Text = "0%"
                Else
                    oa_me_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_in.Text = "0%"
                Else
                    oa_hc_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Recruiter_Name = '" & BreakdownRecruiter.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_in.Text = "0%"
                Else
                    oa_me_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry ----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Prototyze----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_me_pr.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Pvt Unlimited----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_me_pv.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> InnerHeads----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO' AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_hc_in.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Recruiter = '" & BreakdownRecruiter.Text & "'", SQLConn)
                op_me_in.Text = SQLComm.ExecuteScalar

                SQLConn.Dispose()

            End If
        End If
    End Sub

    Private Sub btn_BreakDown_Refresh_Click(sender As System.Object, e As System.EventArgs) Handles btn_BreakDown_Refresh.Click

        '------------------------- Clear All Labels------------------------------------ 
        BD_J.Text = "0"
        BD_O.Text = "0"
        BD_OTJ.Text = "0%"
        BD_ATF.Text = "0 Days"
        BD_OA.Text = "0%"
        BD_OP.Text = "0"
        j_hc.Text = "0"
        j_me.Text = "0"
        j_hc_pr.Text = "0"
        j_hc_pv.Text = "0"
        j_hc_in.Text = "0"
        j_me_pr.Text = "0"
        j_me_pv.Text = "0"
        j_me_in.Text = "0"
        o_hc.Text = "0"
        o_me.Text = "0"
        o_hc_pr.Text = "0"
        o_hc_pv.Text = "0"
        o_hc_in.Text = "0"
        o_me_pr.Text = "0"
        o_me_pv.Text = "0"
        o_me_in.Text = "0"
        otj_hc.Text = "0%"
        otj_me.Text = "0%"
        otj_hc_pr.Text = "0%"
        otj_hc_pv.Text = "0%"
        otj_hc_in.Text = "0%"
        otj_me_pr.Text = "0%"
        otj_me_pv.Text = "0%"
        otj_me_in.Text = "0%"
        atf_hc.Text = "0 Days"
        atf_me.Text = "0 Days"
        atf_hc_pr.Text = "0 Days"
        atf_me_pr.Text = "0 Days"
        atf_hc_pv.Text = "0 Days"
        atf_me_pv.Text = "0 Days"
        atf_hc_in.Text = "0 Days"
        atf_me_in.Text = "0 Days"
        oa_hc.Text = "0%"
        oa_me.Text = "0%"
        oa_hc_pr.Text = "0%"
        oa_me_pr.Text = "0%"
        oa_hc_pv.Text = "0%"
        oa_me_pv.Text = "0%"
        oa_hc_in.Text = "0%"
        oa_me_in.Text = "0%"
        op_hc.Text = "0"
        op_me.Text = "0"
        op_hc_pr.Text = "0"
        op_me_pr.Text = "0"
        op_hc_pv.Text = "0"
        op_me_pv.Text = "0"
        op_hc_in.Text = "0"
        op_me_in.Text = "0"
        '---------------------------------------------

        On Error Resume Next
        Dim FY_Start_Year As Integer = If(ComboBoxFY2.Text <> "ALL", Mid(ComboBoxFY2.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY2.Text <> "ALL", Mid(ComboBoxFY2.Text, 3, 2) & Mid(ComboBoxFY2.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        '--------------ComboBoxFY = ALL -------------
        If ComboBoxFY2.Text = "ALL" Then
            If BreakdownRecruiter.Text = "ALL" Or BreakdownCompany.Text = "ALL" OrElse BreakdownGroupCompany.Text = "ALL" Then

                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLComm.Connection = SQLConn

                '------------------------------------------Overall---------------------------------------------------------------------------------
                SQLConn.Open()
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Joining = 'Yes'", SQLConn)
                BD_J.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer = 'Yes'", SQLConn)
                BD_O.Text = SQLComm.ExecuteScalar

                If BD_J.Text = 0 Or BD_O.Text = 0 Then
                    BD_OTJ.Text = "0%"
                Else
                    BD_OTJ.Text = FormatPercent(BD_J.Text / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED'", SQLConn)
                BD_ATF.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Accepted = 'Yes'", SQLConn)
                If BD_O.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    BD_OA.Text = "0%"
                Else
                    BD_OA.Text = FormatPercent(SQLComm.ExecuteScalar / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED')", SQLConn)
                BD_OP.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offer to Join --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                If o_hc.Text = 0 Or j_hc.Text = 0 Then
                    otj_hc.Text = "0%"
                Else
                    otj_hc.Text = FormatPercent(j_hc.Text / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me.Text = 0 Or j_me.Text = 0 Then
                    otj_me.Text = "0%"
                Else
                    otj_me.Text = FormatPercent(j_me.Text / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Head/CXO --> Company wise ----------------
                If o_hc_pr.Text = 0 Or j_hc_pr.Text = 0 Then
                    otj_hc_pr.Text = "0%"
                Else
                    otj_hc_pr.Text = FormatPercent(j_hc_pr.Text / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_pv.Text = 0 Or j_hc_pv.Text = 0 Then
                    otj_hc_pv.Text = "0%"
                Else
                    otj_hc_pv.Text = FormatPercent(j_hc_pv.Text / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_in.Text = 0 Or j_hc_in.Text = 0 Then
                    otj_hc_in.Text = "0%"
                Else
                    otj_hc_in.Text = FormatPercent(j_hc_in.Text / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Mid/Entry --> Company wise ----------------
                If o_me_pr.Text = 0 Or j_me_pr.Text = 0 Then
                    otj_me_pr.Text = "0%"
                Else
                    otj_me_pr.Text = FormatPercent(j_me_pr.Text / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_pv.Text = 0 Or j_me_pv.Text = 0 Then
                    otj_me_pv.Text = "0%"
                Else
                    otj_me_pv.Text = FormatPercent(j_me_pv.Text / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_in.Text = 0 Or j_me_in.Text = 0 Then
                    otj_me_in.Text = "0%"
                Else
                    otj_me_in.Text = FormatPercent(j_me_in.Text / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If



                '------------------------------------------Avg Time to Fill --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Position_Level = 'Head/CXO'", SQLConn)
                atf_hc.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Prototyze ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO'", SQLConn)
                atf_hc_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Pvt Unlimited ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO'", SQLConn)
                atf_hc_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> InnerHeads ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO'", SQLConn)
                atf_hc_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc.Text = "0%"
                Else
                    oa_hc.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me.Text = "0%"
                Else
                    oa_me.Text = FormatPercent(SQLComm.ExecuteScalar / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Prototyze---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pr.Text = "0%"
                Else
                    oa_hc_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pr.Text = "0%"
                Else
                    oa_me_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pv.Text = "0%"
                Else
                    oa_hc_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pv.Text = "0%"
                Else
                    oa_me_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_in.Text = "0%"
                Else
                    oa_hc_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_in.Text = "0%"
                Else
                    oa_me_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry ----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Position_Level = 'Head/CXO'", SQLConn)
                op_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                op_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Prototyze----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO'", SQLConn)
                op_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                op_me_pr.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Pvt Unlimited----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO'", SQLConn)
                op_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                op_me_pv.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> InnerHeads----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO'", SQLConn)
                op_hc_in.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                op_me_in.Text = SQLComm.ExecuteScalar

                SQLConn.Dispose()

            ElseIf BreakdownRecruiter.SelectedIndex > 0 Then
                BreakdownRecruiter_SelectedIndexChanged(sender, e)
            ElseIf BreakdownCompany.SelectedIndex > 0 Then
                BreakdownCompany_SelectedIndexChanged(sender, e)
            ElseIf BreakdownGroupCompany.SelectedIndex > 0 Then
                BreakdownGroupCompany_SelectedIndexChanged(sender, e)
            End If

        Else
            '---------------------- ComboboxFY Not equal to ALL -----------------------------
            If BreakdownRecruiter.Text = "ALL" Or BreakdownCompany.Text = "ALL" OrElse BreakdownGroupCompany.Text = "ALL" Then

                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLComm.Connection = SQLConn

                '------------------------------------------Overall---------------------------------------------------------------------------------
                SQLConn.Open()
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes'", SQLConn)
                BD_J.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes'", SQLConn)
                BD_O.Text = SQLComm.ExecuteScalar

                If BD_J.Text = 0 Or BD_O.Text = 0 Then
                    BD_OTJ.Text = "0%"
                Else
                    BD_OTJ.Text = FormatPercent(BD_J.Text / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED'", SQLConn)
                BD_ATF.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes'", SQLConn)
                If BD_O.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    BD_OA.Text = "0%"
                Else
                    BD_OA.Text = FormatPercent(SQLComm.ExecuteScalar / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED')", SQLConn)
                BD_OP.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offer to Join --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                If o_hc.Text = 0 Or j_hc.Text = 0 Then
                    otj_hc.Text = "0%"
                Else
                    otj_hc.Text = FormatPercent(j_hc.Text / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me.Text = 0 Or j_me.Text = 0 Then
                    otj_me.Text = "0%"
                Else
                    otj_me.Text = FormatPercent(j_me.Text / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Head/CXO --> Company wise ----------------
                If o_hc_pr.Text = 0 Or j_hc_pr.Text = 0 Then
                    otj_hc_pr.Text = "0%"
                Else
                    otj_hc_pr.Text = FormatPercent(j_hc_pr.Text / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_pv.Text = 0 Or j_hc_pv.Text = 0 Then
                    otj_hc_pv.Text = "0%"
                Else
                    otj_hc_pv.Text = FormatPercent(j_hc_pv.Text / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_in.Text = 0 Or j_hc_in.Text = 0 Then
                    otj_hc_in.Text = "0%"
                Else
                    otj_hc_in.Text = FormatPercent(j_hc_in.Text / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Mid/Entry --> Company wise ----------------
                If o_me_pr.Text = 0 Or j_me_pr.Text = 0 Then
                    otj_me_pr.Text = "0%"
                Else
                    otj_me_pr.Text = FormatPercent(j_me_pr.Text / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_pv.Text = 0 Or j_me_pv.Text = 0 Then
                    otj_me_pv.Text = "0%"
                Else
                    otj_me_pv.Text = FormatPercent(j_me_pv.Text / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_in.Text = 0 Or j_me_in.Text = 0 Then
                    otj_me_in.Text = "0%"
                Else
                    otj_me_in.Text = FormatPercent(j_me_in.Text / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If



                '------------------------------------------Avg Time to Fill --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Position_Level = 'Head/CXO'", SQLConn)
                atf_hc.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Prototyze ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO'", SQLConn)
                atf_hc_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Pvt Unlimited ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO'", SQLConn)
                atf_hc_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> InnerHeads ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO'", SQLConn)
                atf_hc_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc.Text = "0%"
                Else
                    oa_hc.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me.Text = "0%"
                Else
                    oa_me.Text = FormatPercent(SQLComm.ExecuteScalar / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Prototyze---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pr.Text = "0%"
                Else
                    oa_hc_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pr.Text = "0%"
                Else
                    oa_me_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pv.Text = "0%"
                Else
                    oa_hc_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pv.Text = "0%"
                Else
                    oa_me_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_in.Text = "0%"
                Else
                    oa_hc_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_in.Text = "0%"
                Else
                    oa_me_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry ----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Position_Level = 'Head/CXO'", SQLConn)
                op_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                op_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Prototyze----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO'", SQLConn)
                op_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                op_me_pr.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Pvt Unlimited----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO'", SQLConn)
                op_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                op_me_pv.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> InnerHeads----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO'", SQLConn)
                op_hc_in.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                op_me_in.Text = SQLComm.ExecuteScalar

                SQLConn.Dispose()

            ElseIf BreakdownRecruiter.SelectedIndex > 0 Then
                BreakdownRecruiter_SelectedIndexChanged(sender, e)
            ElseIf BreakdownCompany.SelectedIndex > 0 Then
                BreakdownCompany_SelectedIndexChanged(sender, e)
            ElseIf BreakdownGroupCompany.SelectedIndex > 0 Then
                BreakdownGroupCompany_SelectedIndexChanged(sender, e)
            End If


        End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        '    SQLConn.Dispose()
        'End Try

    End Sub

    Private Sub BreakdownCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BreakdownCompany.SelectedIndexChanged
        On Error Resume Next
        If BreakdownCompany.SelectedIndex = 0 Then
            Exit Sub
        Else
        End If

        '------------------------- Clear All Labels------------------------------------ 
        BD_J.Text = "0"
        BD_O.Text = "0"
        BD_OTJ.Text = "0%"
        BD_ATF.Text = "0 Days"
        BD_OA.Text = "0%"
        BD_OP.Text = "0"
        j_hc.Text = "0"
        j_me.Text = "0"
        j_hc_pr.Text = "0"
        j_hc_pv.Text = "0"
        j_hc_in.Text = "0"
        j_me_pr.Text = "0"
        j_me_pv.Text = "0"
        j_me_in.Text = "0"
        o_hc.Text = "0"
        o_me.Text = "0"
        o_hc_pr.Text = "0"
        o_hc_pv.Text = "0"
        o_hc_in.Text = "0"
        o_me_pr.Text = "0"
        o_me_pv.Text = "0"
        o_me_in.Text = "0"
        otj_hc.Text = "0%"
        otj_me.Text = "0%"
        otj_hc_pr.Text = "0%"
        otj_hc_pv.Text = "0%"
        otj_hc_in.Text = "0%"
        otj_me_pr.Text = "0%"
        otj_me_pv.Text = "0%"
        otj_me_in.Text = "0%"
        atf_hc.Text = "0 Days"
        atf_me.Text = "0 Days"
        atf_hc_pr.Text = "0 Days"
        atf_me_pr.Text = "0 Days"
        atf_hc_pv.Text = "0 Days"
        atf_me_pv.Text = "0 Days"
        atf_hc_in.Text = "0 Days"
        atf_me_in.Text = "0 Days"
        oa_hc.Text = "0%"
        oa_me.Text = "0%"
        oa_hc_pr.Text = "0%"
        oa_me_pr.Text = "0%"
        oa_hc_pv.Text = "0%"
        oa_me_pv.Text = "0%"
        oa_hc_in.Text = "0%"
        oa_me_in.Text = "0%"
        op_hc.Text = "0"
        op_me.Text = "0"
        op_hc_pr.Text = "0"
        op_me_pr.Text = "0"
        op_hc_pv.Text = "0"
        op_me_pv.Text = "0"
        op_hc_in.Text = "0"
        op_me_in.Text = "0"

        BreakdownRecruiter.SelectedIndex = 0
        BreakdownGroupCompany.SelectedIndex = 0

        Dim FY_Start_Year As Integer = If(ComboBoxFY2.Text <> "ALL", Mid(ComboBoxFY2.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY2.Text <> "ALL", Mid(ComboBoxFY2.Text, 3, 2) & Mid(ComboBoxFY2.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        '------------------------------------------------------------------------------
        'Try
        If ComboBoxFY2.Text = "ALL" Then

            If BreakdownCompany.Text = "ALL" Then

                btn_BreakDown_Refresh_Click(sender, e)

            Else

                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLComm.Connection = SQLConn

                '------------------------------------------Overall---------------------------------------------------------------------------------
                SQLConn.Open()
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Joining = 'Yes' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                BD_J.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer = 'Yes' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                BD_O.Text = SQLComm.ExecuteScalar

                If BD_J.Text = 0 Or BD_O.Text = 0 Then
                    BD_OTJ.Text = "0%"
                Else
                    BD_OTJ.Text = FormatPercent(BD_J.Text / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                BD_ATF.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Accepted = 'Yes' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                If BD_O.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    BD_OA.Text = "0%"
                Else
                    BD_OA.Text = FormatPercent(SQLComm.ExecuteScalar / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If


                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                BD_OP.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offer to Join --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                If o_hc.Text = 0 Or j_hc.Text = 0 Then
                    otj_hc.Text = "0%"
                Else
                    otj_hc.Text = FormatPercent(j_hc.Text / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me.Text = 0 Or j_me.Text = 0 Then
                    otj_me.Text = "0%"
                Else
                    otj_me.Text = FormatPercent(j_me.Text / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Head/CXO --> Company wise ----------------
                If o_hc_pr.Text = 0 Or j_hc_pr.Text = 0 Then
                    otj_hc_pr.Text = "0%"
                Else
                    otj_hc_pr.Text = FormatPercent(j_hc_pr.Text / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_pv.Text = 0 Or j_hc_pv.Text = 0 Then
                    otj_hc_pv.Text = "0%"
                Else
                    otj_hc_pv.Text = FormatPercent(j_hc_pv.Text / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_in.Text = 0 Or j_hc_in.Text = 0 Then
                    otj_hc_in.Text = "0%"
                Else
                    otj_hc_in.Text = FormatPercent(j_hc_in.Text / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Mid/Entry --> Company wise ----------------
                If o_me_pr.Text = 0 Or j_me_pr.Text = 0 Then
                    otj_me_pr.Text = "0%"
                Else
                    otj_me_pr.Text = FormatPercent(j_me_pr.Text / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_pv.Text = 0 Or j_me_pv.Text = 0 Then
                    otj_me_pv.Text = "0%"
                Else
                    otj_me_pv.Text = FormatPercent(j_me_pv.Text / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_in.Text = 0 Or j_me_in.Text = 0 Then
                    otj_me_in.Text = "0%"
                Else
                    otj_me_in.Text = FormatPercent(j_me_in.Text / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If


                '------------------------------------------Avg Time to Fill --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                atf_hc.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company1 = '" & BreakdownCompany.Text & "' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Prototyze ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                atf_hc_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Company1 = '" & BreakdownCompany.Text & "' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Pvt Unlimited ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                atf_hc_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                atf_me_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> InnerHeads ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                atf_hc_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                atf_me_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc.Text = "0%"
                Else
                    oa_hc.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me.Text = "0%"
                Else
                    oa_me.Text = FormatPercent(SQLComm.ExecuteScalar / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Prototyze---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pr.Text = "0%"
                Else
                    oa_hc_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pr.Text = "0%"
                Else
                    oa_me_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pv.Text = "0%"
                Else
                    oa_hc_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pv.Text = "0%"
                Else
                    oa_me_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_in.Text = "0%"
                Else
                    oa_hc_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_in.Text = "0%"
                Else
                    oa_me_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry ----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Prototyze----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_me_pr.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Pvt Unlimited----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_me_pv.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> InnerHeads----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_hc_in.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_me_in.Text = SQLComm.ExecuteScalar

                SQLConn.Dispose()
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message)
                '    SQLConn.Dispose()
                'End Try
            End If

        Else

            If BreakdownCompany.Text = "ALL" Then

                btn_BreakDown_Refresh_Click(sender, e)

            Else

                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLComm.Connection = SQLConn

                '------------------------------------------Overall---------------------------------------------------------------------------------
                SQLConn.Open()
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                BD_J.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                BD_O.Text = SQLComm.ExecuteScalar

                If BD_J.Text = 0 Or BD_O.Text = 0 Then
                    BD_OTJ.Text = "0%"
                Else
                    BD_OTJ.Text = FormatPercent(BD_J.Text / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                BD_ATF.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                If BD_O.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    BD_OA.Text = "0%"
                Else
                    BD_OA.Text = FormatPercent(SQLComm.ExecuteScalar / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If


                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                BD_OP.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offer to Join --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                If o_hc.Text = 0 Or j_hc.Text = 0 Then
                    otj_hc.Text = "0%"
                Else
                    otj_hc.Text = FormatPercent(j_hc.Text / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me.Text = 0 Or j_me.Text = 0 Then
                    otj_me.Text = "0%"
                Else
                    otj_me.Text = FormatPercent(j_me.Text / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Head/CXO --> Company wise ----------------
                If o_hc_pr.Text = 0 Or j_hc_pr.Text = 0 Then
                    otj_hc_pr.Text = "0%"
                Else
                    otj_hc_pr.Text = FormatPercent(j_hc_pr.Text / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_pv.Text = 0 Or j_hc_pv.Text = 0 Then
                    otj_hc_pv.Text = "0%"
                Else
                    otj_hc_pv.Text = FormatPercent(j_hc_pv.Text / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_in.Text = 0 Or j_hc_in.Text = 0 Then
                    otj_hc_in.Text = "0%"
                Else
                    otj_hc_in.Text = FormatPercent(j_hc_in.Text / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Mid/Entry --> Company wise ----------------
                If o_me_pr.Text = 0 Or j_me_pr.Text = 0 Then
                    otj_me_pr.Text = "0%"
                Else
                    otj_me_pr.Text = FormatPercent(j_me_pr.Text / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_pv.Text = 0 Or j_me_pv.Text = 0 Then
                    otj_me_pv.Text = "0%"
                Else
                    otj_me_pv.Text = FormatPercent(j_me_pv.Text / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_in.Text = 0 Or j_me_in.Text = 0 Then
                    otj_me_in.Text = "0%"
                Else
                    otj_me_in.Text = FormatPercent(j_me_in.Text / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If


                '------------------------------------------Avg Time to Fill --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                atf_hc.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company1 = '" & BreakdownCompany.Text & "' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Prototyze ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                atf_hc_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Company1 = '" & BreakdownCompany.Text & "' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Pvt Unlimited ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                atf_hc_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                atf_me_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> InnerHeads ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                atf_hc_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                atf_me_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc.Text = "0%"
                Else
                    oa_hc.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me.Text = "0%"
                Else
                    oa_me.Text = FormatPercent(SQLComm.ExecuteScalar / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Prototyze---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pr.Text = "0%"
                Else
                    oa_hc_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pr.Text = "0%"
                Else
                    oa_me_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pv.Text = "0%"
                Else
                    oa_hc_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pv.Text = "0%"
                Else
                    oa_me_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_in.Text = "0%"
                Else
                    oa_hc_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND ApplicationTable.Company1 = '" & BreakdownCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_in.Text = "0%"
                Else
                    oa_me_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry ----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Prototyze----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_me_pr.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Pvt Unlimited----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_me_pv.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> InnerHeads----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO' AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_hc_in.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company1 = '" & BreakdownCompany.Text & "'", SQLConn)
                op_me_in.Text = SQLComm.ExecuteScalar

                SQLConn.Dispose()
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message)
                '    SQLConn.Dispose()
                'End Try


            End If
        End If
    End Sub

    Private Sub BreakdownGroupCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BreakdownGroupCompany.SelectedIndexChanged

        On Error Resume Next
        If BreakdownGroupCompany.SelectedIndex = 0 Then
            Exit Sub
        Else
        End If

        '------------------------- Clear All Labels------------------------------------ 
        BD_J.Text = "0"
        BD_O.Text = "0"
        BD_OTJ.Text = "0%"
        BD_ATF.Text = "0 Days"
        BD_OA.Text = "0%"
        BD_OP.Text = "0"
        j_hc.Text = "0"
        j_me.Text = "0"
        j_hc_pr.Text = "0"
        j_hc_pv.Text = "0"
        j_hc_in.Text = "0"
        j_me_pr.Text = "0"
        j_me_pv.Text = "0"
        j_me_in.Text = "0"
        o_hc.Text = "0"
        o_me.Text = "0"
        o_hc_pr.Text = "0"
        o_hc_pv.Text = "0"
        o_hc_in.Text = "0"
        o_me_pr.Text = "0"
        o_me_pv.Text = "0"
        o_me_in.Text = "0"
        otj_hc.Text = "0%"
        otj_me.Text = "0%"
        otj_hc_pr.Text = "0%"
        otj_hc_pv.Text = "0%"
        otj_hc_in.Text = "0%"
        otj_me_pr.Text = "0%"
        otj_me_pv.Text = "0%"
        otj_me_in.Text = "0%"
        atf_hc.Text = "0 Days"
        atf_me.Text = "0 Days"
        atf_hc_pr.Text = "0 Days"
        atf_me_pr.Text = "0 Days"
        atf_hc_pv.Text = "0 Days"
        atf_me_pv.Text = "0 Days"
        atf_hc_in.Text = "0 Days"
        atf_me_in.Text = "0 Days"
        oa_hc.Text = "0%"
        oa_me.Text = "0%"
        oa_hc_pr.Text = "0%"
        oa_me_pr.Text = "0%"
        oa_hc_pv.Text = "0%"
        oa_me_pv.Text = "0%"
        oa_hc_in.Text = "0%"
        oa_me_in.Text = "0%"
        op_hc.Text = "0"
        op_me.Text = "0"
        op_hc_pr.Text = "0"
        op_me_pr.Text = "0"
        op_hc_pv.Text = "0"
        op_me_pv.Text = "0"
        op_hc_in.Text = "0"
        op_me_in.Text = "0"

        BreakdownRecruiter.SelectedIndex = 0
        BreakdownCompany.SelectedIndex = 0
        '------------------------------------------------------------------------------

        Dim FY_Start_Year As Integer = If(ComboBoxFY2.Text <> "ALL", Mid(ComboBoxFY2.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY2.Text <> "ALL", Mid(ComboBoxFY2.Text, 3, 2) & Mid(ComboBoxFY2.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        'Try

        If ComboBoxFY2.Text = "ALL" Then

            If BreakdownGroupCompany.Text = "ALL" Then

                btn_BreakDown_Refresh_Click(sender, e)

            Else

                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLComm.Connection = SQLConn
                '"Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                '------------------------------------------Overall---------------------------------------------------------------------------------
                SQLConn.Open()
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID WHERE ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                BD_J.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID WHERE ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                BD_O.Text = SQLComm.ExecuteScalar

                If BD_J.Text = 0 Or BD_O.Text = 0 Then
                    BD_OTJ.Text = "0%"
                Else
                    BD_OTJ.Text = FormatPercent(BD_J.Text / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                BD_ATF.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID Where ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                If BD_O.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    BD_OA.Text = "0%"
                Else
                    BD_OA.Text = FormatPercent(SQLComm.ExecuteScalar / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If


                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                BD_OP.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offer to Join --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                If o_hc.Text = 0 Or j_hc.Text = 0 Then
                    otj_hc.Text = "0%"
                Else
                    otj_hc.Text = FormatPercent(j_hc.Text / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me.Text = 0 Or j_me.Text = 0 Then
                    otj_me.Text = "0%"
                Else
                    otj_me.Text = FormatPercent(j_me.Text / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Head/CXO --> Company wise ----------------
                If o_hc_pr.Text = 0 Or j_hc_pr.Text = 0 Then
                    otj_hc_pr.Text = "0%"
                Else
                    otj_hc_pr.Text = FormatPercent(j_hc_pr.Text / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_pv.Text = 0 Or j_hc_pv.Text = 0 Then
                    otj_hc_pv.Text = "0%"
                Else
                    otj_hc_pv.Text = FormatPercent(j_hc_pv.Text / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_in.Text = 0 Or j_hc_in.Text = 0 Then
                    otj_hc_in.Text = "0%"
                Else
                    otj_hc_in.Text = FormatPercent(j_hc_in.Text / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Mid/Entry --> Company wise ----------------
                If o_me_pr.Text = 0 Or j_me_pr.Text = 0 Then
                    otj_me_pr.Text = "0%"
                Else
                    otj_me_pr.Text = FormatPercent(j_me_pr.Text / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_pv.Text = 0 Or j_me_pv.Text = 0 Then
                    otj_me_pv.Text = "0%"
                Else
                    otj_me_pv.Text = FormatPercent(j_me_pv.Text / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_in.Text = 0 Or j_me_in.Text = 0 Then
                    otj_me_in.Text = "0%"
                Else
                    otj_me_in.Text = FormatPercent(j_me_in.Text / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If


                '------------------------------------------Avg Time to Fill --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                atf_hc.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = '" & BreakdownGroupCompany.Text & "' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Prototyze ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                atf_hc_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Company2 = '" & BreakdownGroupCompany.Text & "' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Pvt Unlimited ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                atf_hc_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                atf_me_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> InnerHeads ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                atf_hc_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                atf_me_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc.Text = "0%"
                Else
                    oa_hc.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me.Text = "0%"
                Else
                    oa_me.Text = FormatPercent(SQLComm.ExecuteScalar / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Prototyze---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pr.Text = "0%"
                Else
                    oa_hc_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pr.Text = "0%"
                Else
                    oa_me_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pv.Text = "0%"
                Else
                    oa_hc_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pv.Text = "0%"
                Else
                    oa_me_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_in.Text = "0%"
                Else
                    oa_hc_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_in.Text = "0%"
                Else
                    oa_me_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry ----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Prototyze----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_me_pr.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Pvt Unlimited----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_me_pv.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> InnerHeads----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_hc_in.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_me_in.Text = SQLComm.ExecuteScalar

                SQLConn.Dispose()
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message)
                '    SQLConn.Dispose()
                'End Try
            End If

        Else

            If BreakdownGroupCompany.Text = "ALL" Then

                btn_BreakDown_Refresh_Click(sender, e)

            Else

                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLComm.Connection = SQLConn
                '"Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where ApplicationTable.Joining = 'Yes' AND ApplicationTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                '------------------------------------------Overall---------------------------------------------------------------------------------
                SQLConn.Open()
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID WHERE (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                BD_J.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID WHERE (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                BD_O.Text = SQLComm.ExecuteScalar

                If BD_J.Text = 0 Or BD_O.Text = 0 Then
                    BD_OTJ.Text = "0%"
                Else
                    BD_OTJ.Text = FormatPercent(BD_J.Text / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                BD_ATF.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID Where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                If BD_O.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    BD_OA.Text = "0%"
                Else
                    BD_OA.Text = FormatPercent(SQLComm.ExecuteScalar / BD_O.Text, NumDigitsAfterDecimal:=0)
                End If


                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                BD_OP.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                j_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Joined --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Joining_Date >=" & FY_Start_Date & " AND ApplicationTable.Joining_Date <= " & FY_End_Date & ") AND ApplicationTable.Joining = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                j_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO and MID/Entry---------------------------------------------------------------------------------

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> Head/CXO --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                o_hc_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offered --> MID/Entry --> Company wise ----------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                o_me_in.Text = SQLComm.ExecuteScalar

                '------------------------------------------Offer to Join --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                If o_hc.Text = 0 Or j_hc.Text = 0 Then
                    otj_hc.Text = "0%"
                Else
                    otj_hc.Text = FormatPercent(j_hc.Text / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me.Text = 0 Or j_me.Text = 0 Then
                    otj_me.Text = "0%"
                Else
                    otj_me.Text = FormatPercent(j_me.Text / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Head/CXO --> Company wise ----------------
                If o_hc_pr.Text = 0 Or j_hc_pr.Text = 0 Then
                    otj_hc_pr.Text = "0%"
                Else
                    otj_hc_pr.Text = FormatPercent(j_hc_pr.Text / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_pv.Text = 0 Or j_hc_pv.Text = 0 Then
                    otj_hc_pv.Text = "0%"
                Else
                    otj_hc_pv.Text = FormatPercent(j_hc_pv.Text / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_hc_in.Text = 0 Or j_hc_in.Text = 0 Then
                    otj_hc_in.Text = "0%"
                Else
                    otj_hc_in.Text = FormatPercent(j_hc_in.Text / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer to Join --> Mid/Entry --> Company wise ----------------
                If o_me_pr.Text = 0 Or j_me_pr.Text = 0 Then
                    otj_me_pr.Text = "0%"
                Else
                    otj_me_pr.Text = FormatPercent(j_me_pr.Text / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_pv.Text = 0 Or j_me_pv.Text = 0 Then
                    otj_me_pv.Text = "0%"
                Else
                    otj_me_pv.Text = FormatPercent(j_me_pv.Text / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                If o_me_in.Text = 0 Or j_me_in.Text = 0 Then
                    otj_me_in.Text = "0%"
                Else
                    otj_me_in.Text = FormatPercent(j_me_in.Text / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If


                '------------------------------------------Avg Time to Fill --> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                atf_hc.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = '" & BreakdownGroupCompany.Text & "' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Prototyze ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                atf_hc_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Prototyze' AND Company2 = '" & BreakdownGroupCompany.Text & "' AND (Position_Level = 'Mid' OR Position_Level = 'Entry')", SQLConn)
                atf_me_pr.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> Pvt Unlimited ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                atf_hc_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                atf_me_pv.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                '------------------------------------------Avg Time to Fill --> Head/CXO/Mid/Entry --> InnerHeads ----------------
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                atf_hc_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"

                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                atf_me_in.Text = Format(SQLComm.ExecuteScalar, "0") & " Days"


                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc.Text = "0%"
                Else
                    oa_hc.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me.Text = "0%"
                Else
                    oa_me.Text = FormatPercent(SQLComm.ExecuteScalar / o_me.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Prototyze---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Prototyze' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pr.Text = "0%"
                Else
                    oa_hc_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Prototyze' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pr.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pr.Text = "0%"
                Else
                    oa_me_pr.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pr.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_pv.Text = "0%"
                Else
                    oa_hc_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'Pvt Unlimited' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_pv.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_pv.Text = "0%"
                Else
                    oa_me_pv.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_pv.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Offer Accepted %--> Head/CXO and MID/Entry --> Pvt Unlimited---------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And JobTable.Position_Level ='Head/CXO'", SQLConn)
                If o_hc_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_hc_in.Text = "0%"
                Else
                    oa_hc_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_hc_in.Text, NumDigitsAfterDecimal:=0)
                End If

                SQLComm = New SqlCommand("Select count(*) From ApplicationTable Left Join JobTable On JobTable.Job_ID=ApplicationTable.Job_ID where (ApplicationTable.Offer_Accepted_Date >=" & FY_Start_Date & " AND ApplicationTable.Offer_Accepted_Date <= " & FY_End_Date & ") AND ApplicationTable.Offer_Accepted = 'Yes' AND JobTable.Company2 = '" & BreakdownGroupCompany.Text & "' And JobTable.Company2 = 'InnerHeads' And (JobTable.Position_Level ='Mid' OR JobTable.Position_Level ='Entry')", SQLConn)
                If o_me_in.Text = 0 Or SQLComm.ExecuteScalar = 0 Then
                    oa_me_in.Text = "0%"
                Else
                    oa_me_in.Text = FormatPercent(SQLComm.ExecuteScalar / o_me_in.Text, NumDigitsAfterDecimal:=0)
                End If

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry ----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_hc.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_me.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Prototyze----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_hc_pr.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Prototyze' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_me_pr.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> Pvt Unlimited----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_hc_pv.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'Pvt Unlimited' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_me_pv.Text = SQLComm.ExecuteScalar

                '------------------------------------------Open Positions--> Head/CXO and MID/Entry --> InnerHeads----------------------------------------------------------------------------------
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND Position_Level = 'Head/CXO' AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_hc_in.Text = SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Job_Status = 'OPEN' OR Job_Status = 'OFFERED') AND Company2 = 'InnerHeads' AND (Position_Level = 'Mid' OR Position_Level = 'Entry') AND Company2 = '" & BreakdownGroupCompany.Text & "'", SQLConn)
                op_me_in.Text = SQLComm.ExecuteScalar

                SQLConn.Dispose()
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message)
                '    SQLConn.Dispose()
                'End Try
            End If

        End If
    End Sub

    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        If TabBreakDownAnalysis.Focus = True Then
            BreakdownRecruiter.Text = FormTop.ComboBoxAppDetailsRecruiter.Text
        End If
    End Sub

    Private Sub ComboBoxFY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFY1.SelectedIndexChanged

        DashboardRecruiter.SelectedIndex = 0


        Dim FY_Start_Year As Integer = If(ComboBoxFY1.Text <> "ALL", Mid(ComboBoxFY1.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY1.Text <> "ALL", Mid(ComboBoxFY1.Text, 3, 2) & Mid(ComboBoxFY1.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        '-------------------------------------- Recruitment KPI Calculation ---------------------------------------------------------
        Try
            Dim ConnStr As String

            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn

            SQLConn.Open()
            If ComboBoxFY1.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Interview = 'Yes' AND Rejected = 'No'", SQLConn)
                qc.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer = 'Yes'", SQLConn)
                Dim offer As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Accepted = 'Yes'", SQLConn)
                oar.Text = FormatPercent(SQLComm.ExecuteScalar / offer, "0")
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED'", SQLConn)
                ttf.Text = FormatNumber(SQLComm.ExecuteScalar, 0) & " Days"
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'JOINED' or Job_Status = 'OPEN' or Job_Status = 'OFFERED' ", SQLConn)
                Dim totalposition As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'JOINED'", SQLConn)
                htg.Text = FormatPercent(SQLComm.ExecuteScalar / totalposition, "0")

                Dim total_joined As Integer
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Joining = 'Yes'", SQLConn)
                total_joined = SQLComm.ExecuteScalar
                Dim total_recruitmentcost As Integer = SQLComm.ExecuteScalar
                'SQLComm = New SqlCommand("Select Sum(Total) FROM RecruitmentCost", SQLConn)
                SQLComm = New SqlCommand("Select Sum(ISNULL(Subscription,0) + ISNULL(Infrastructure,0) + ISNULL(Postage_Courier,0) + ISNULL(IT_Expenses,0) + ISNULL(Printing_Stationery,0) + ISNULL(Supervison_Charges_GJ,0) + ISNULL(Visit_Cost,0)) from RecruitmentCost", SQLConn)
                total_recruitmentcost = SQLComm.ExecuteScalar
                Dim total_recruitersalary As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Sum(Salary) FROM RecruiterSalary", SQLConn)
                total_recruitersalary = SQLComm.ExecuteScalar
                cph.Text = "Rs. " & FormatNumber((total_recruitmentcost + total_recruitersalary) / total_joined, "0")

            Else

                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Interview = 'Yes' AND Rejected = 'No'", SQLConn)
                qc.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes'", SQLConn)
                Dim offer As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes'", SQLConn)
                oar.Text = FormatPercent(SQLComm.ExecuteScalar / offer, "0")
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED'", SQLConn)

                If IsDBNull(SQLComm.ExecuteScalar) Then
                    ttf.Text = "0 Days"
                Else
                    ttf.Text = FormatNumber(SQLComm.ExecuteScalar, 0) & " Days"
                End If

                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & " AND Job_Status = 'JOINED') or Job_Status = 'OPEN' or Job_Status = 'OFFERED' ", SQLConn)
                Dim totalposition As Integer = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED'", SQLConn)
                htg.Text = FormatPercent(SQLComm.ExecuteScalar / totalposition, "0")

                Dim total_joined As Integer
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes'", SQLConn)
                total_joined = SQLComm.ExecuteScalar
                Dim total_recruitmentcost As Integer = SQLComm.ExecuteScalar
                'SQLComm = New SqlCommand("Select Sum(Total) FROM RecruitmentCost Where (Month >=" & FY_Start_Date & " AND Month <= " & FY_End_Date & ")", SQLConn)
                SQLComm = New SqlCommand("Select Sum(ISNULL(Subscription,0) + ISNULL(Infrastructure,0) + ISNULL(Postage_Courier,0) + ISNULL(IT_Expenses,0) + ISNULL(Printing_Stationery,0) + ISNULL(Supervison_Charges_GJ,0) + ISNULL(Visit_Cost,0)) from RecruitmentCost Where (Month >=" & FY_Start_Date & " AND Month <= " & FY_End_Date & ")", SQLConn)


                If IsDBNull(SQLComm.ExecuteScalar) Then
                    total_recruitmentcost = 0
                Else
                    total_recruitmentcost = SQLComm.ExecuteScalar
                End If

                Dim total_recruitersalary As Integer '= SQLComm.ExecuteScalar

                SQLComm = New SqlCommand("Select Sum(Salary) FROM RecruiterSalary Where (Month >=" & FY_Start_Date & " AND Month <= " & FY_End_Date & ")", SQLConn)
                If IsDBNull(SQLComm.ExecuteScalar) Then
                    total_recruitersalary = 0
                Else
                    total_recruitersalary = SQLComm.ExecuteScalar
                End If

                If total_joined = 0 Then
                    cph.Text = "NA"
                Else
                    cph.Text = "Rs. " & FormatNumber((total_recruitmentcost + total_recruitersalary) / total_joined, "0")
                End If

                '--------- Attrition Rate --------------
                SQLConn.Dispose()
                SQLComm.Dispose()
                ComboBoxFY11.Text = ComboBoxFY1.Text
                Call Button_Refresh11_Click(sender, e)
                Label_attrition.Text = ytd_attr.Text
            End If
            DashboardRecruiter.SelectedIndex = -1
            DashboardRecruiter.SelectedIndex = 0
            SQLConn.Dispose()
            SQLComm.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
            SQLComm.Dispose()
        End Try


    End Sub

    Private Sub ComboBoxFY2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFY2.SelectedIndexChanged
        BreakdownRecruiter.SelectedIndex = -1
        BreakdownCompany.SelectedIndex = -1
        BreakdownGroupCompany.SelectedIndex = -1
    End Sub

    Private Sub ComboBoxFY3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFY3.SelectedIndexChanged

        Dim FY_Start_Year As Integer = If(ComboBoxFY3.Text <> "ALL", Mid(ComboBoxFY3.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY3.Text <> "ALL", Mid(ComboBoxFY3.Text, 3, 2) & Mid(ComboBoxFY3.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        Try
            Dim i As Integer
            Dim a As Integer
            Dim b As Integer
            Dim c As Integer
            Me.Chart1.Series("Hired").Points.Clear()
            Me.Chart2.Series("Series1").Points.Clear()

            For i = 0 To DataGridView3.Rows.Count - 1
                '--------------------chart1-------------
                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                SQLConn.Open()

                If ComboBoxFY3.Text = "ALL" Then
                    SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DataGridView3.Item(0, i).Value & "' and Joining = 'Yes'", SQLConn)
                Else
                    SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DataGridView3.Item(0, i).Value & "' and Joining = 'Yes'", SQLConn)
                End If
                a = SQLComm.ExecuteScalar
                Me.Chart1.Series("Hired").Points.AddXY(DataGridView3.Item(0, i).Value, a)

                '-------------------chart2--------------
                Dim sqlcomm2 As New SqlCommand
                sqlcomm2.Connection = SQLConn

                If ComboBoxFY3.Text = "ALL" Then
                    sqlcomm2 = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & DataGridView3.Item(0, i).Value & "' and Offer = 'Yes'", SQLConn)
                Else
                    sqlcomm2 = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & DataGridView3.Item(0, i).Value & "' and Offer = 'Yes'", SQLConn)
                End If
                b = sqlcomm2.ExecuteScalar

                If a = 0 Or b = 0 Then
                    c = 0
                Else
                    c = ((a / b) * 100)
                End If
                Me.Chart2.Series("Series1").Points.AddXY(DataGridView3.Item(0, i).Value, c)

                SQLConn.Dispose()
                SQLComm.Dispose()
                sqlcomm2.Dispose()

            Next i
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
            SQLComm.Dispose()
        End Try

    End Sub

    Private Sub DateRangeFrom_ValueChanged(sender As Object, e As EventArgs) Handles DateRangeFrom4.ValueChanged
        RadioButtonDateRange.Checked = True
        'ComboBoxFY4.SelectedIndex = -1

    End Sub

    Private Sub ComboBoxFY4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFY4.SelectedIndexChanged
        RadioButtonFY.Checked = True
    End Sub

    Private Sub Button_Refresh5_Click(sender As Object, e As EventArgs) Handles Button_Refresh5.Click
        Dim FY_Start_Year As Integer = If(ComboBoxFY5.Text <> "ALL", Mid(ComboBoxFY5.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY5.Text <> "ALL", Mid(ComboBoxFY5.Text, 3, 2) & Mid(ComboBoxFY5.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        If RadioButtonDateRange5.Checked = True And DateRangeFrom5.Value > DateRangeTo5.Value Then
            MessageBox.Show("Check Date Range !!!")
            DateRangeTo5.Focus()
            Exit Sub
        End If

        Dim i As Integer
        SQLConn.Dispose()
        SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
        SQLComm.Connection = SQLConn
        ProgressBar5.Show()
        ProgressBar5.Minimum = 0
        ProgressBar5.Maximum = DataGridView2.RowCount
        SQLConn.Open()
        '----------------------------------------------------Company Wise--------------------------------
        If RadioButtonFY5.Checked = True Then

            If ComboBoxFY5.Text = "ALL" Then
                For i = 0 To DataGridView2.Rows.Count - 1
                    Application.DoEvents()
                    ProgressBar5.Value = i
                    '------Screened Count ---------------------------------------
                    Dim ScreenCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Screening = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ScreenCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Shared Count ---------------------------------------
                    Dim SharedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Shared = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    SharedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Approved Count ---------------------------------------
                    Dim ApprovedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Interview = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ApprovedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Invited Count ---------------------------------------
                    Dim InvitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Invited = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    InvitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Visited Count ---------------------------------------
                    Dim VisitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Visited = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    VisitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer Count ---------------------------------------
                    Dim OfferedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_accepted Count ---------------------------------------
                    Dim OfferacceptedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer_Accepted = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferacceptedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_declined Count ---------------------------------------
                    Dim OfferdeclinedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer_Status = 'Declined' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    OfferdeclinedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Join Count ---------------------------------------
                    Dim JoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Joining = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    JoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------To Join Count ---------------------------------------
                    Dim ToJoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Joining_Date > '" & Date.Today & "' And Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ToJoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Parameters.Clear()


                    '------Offer To Join Count ---------------------------------------
                    Dim OfferToJoinCount As Decimal
                    If OfferedCount = 0 Or JoinCount = 0 Then
                        OfferToJoinCount = "0"
                    Else
                        OfferToJoinCount = (JoinCount / OfferedCount) * 100
                    End If

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE CompanyList Set SCREENED = @SCREENED,Shared=@Shared, APPROVED =@APPROVED, INVITED =@INVITED, VISITED =@VISITED, OFFERED =@OFFERED, OFFER_ACCEPTED =@OFFER_ACCEPTED, OFFER_DECLINED =@OFFER_DECLINED, JOINED =@JOINED, TO_JOIN =@TO_JOIN, OFFER_TO_JOIN_RATIO =@OFFER_TO_JOIN_RATIO Where CompanyName = '" & DataGridView2.Item(0, i).Value & "'")

                    SQLComm.Parameters.AddWithValue("@SCREENED", SqlDbType.Char).Value = ScreenCount
                    SQLComm.Parameters.AddWithValue("@SHARED", SqlDbType.Char).Value = SharedCount
                    SQLComm.Parameters.AddWithValue("@APPROVED", SqlDbType.Char).Value = ApprovedCount
                    SQLComm.Parameters.AddWithValue("@INVITED", SqlDbType.Char).Value = InvitedCount
                    SQLComm.Parameters.AddWithValue("@VISITED", SqlDbType.Char).Value = VisitedCount
                    SQLComm.Parameters.AddWithValue("@OFFERED", SqlDbType.Char).Value = OfferedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_ACCEPTED", SqlDbType.Char).Value = OfferacceptedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_DECLINED", SqlDbType.Char).Value = OfferdeclinedCount
                    SQLComm.Parameters.AddWithValue("@JOINED", SqlDbType.Char).Value = JoinCount
                    SQLComm.Parameters.AddWithValue("@TO_JOIN", SqlDbType.Char).Value = ToJoinCount
                    SQLComm.Parameters.AddWithValue("@OFFER_TO_JOIN_RATIO", SqlDbType.Float).Value = OfferToJoinCount

                    SQLComm.ExecuteNonQuery()

                Next i
                'MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                For i = 0 To DataGridView2.Rows.Count - 1
                    Application.DoEvents()
                    ProgressBar5.Value = i
                    '------Screened Count ---------------------------------------
                    Dim ScreenCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Screening = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ScreenCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Shared Count ---------------------------------------
                    Dim SharedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Shared = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    SharedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Approved Count ---------------------------------------
                    Dim ApprovedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Interview = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ApprovedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Invited Count ---------------------------------------
                    Dim InvitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Invited_Date >=" & FY_Start_Date & " AND Invited_Date <= " & FY_End_Date & ") AND Invited = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    InvitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Visited Count ---------------------------------------
                    Dim VisitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Visited_Date >=" & FY_Start_Date & " AND Visited_Date <= " & FY_End_Date & ") AND Visited = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    VisitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer Count ---------------------------------------
                    Dim OfferedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_accepted Count ---------------------------------------
                    Dim OfferacceptedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferacceptedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_declined Count ---------------------------------------
                    Dim OfferdeclinedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer_Status = 'Declined' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    OfferdeclinedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Join Count ---------------------------------------
                    Dim JoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    JoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------To Join Count ---------------------------------------
                    Dim ToJoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining_Date > '" & Date.Today & "' And Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ToJoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Parameters.Clear()


                    '------Offer To Join Count ---------------------------------------
                    Dim OfferToJoinCount As Decimal
                    If OfferedCount = 0 Or JoinCount = 0 Then
                        OfferToJoinCount = "0"
                    Else
                        OfferToJoinCount = (JoinCount / OfferedCount) * 100
                    End If

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE CompanyList Set SCREENED = @SCREENED,Shared=@Shared, APPROVED =@APPROVED, INVITED =@INVITED, VISITED =@VISITED, OFFERED =@OFFERED, OFFER_ACCEPTED =@OFFER_ACCEPTED, OFFER_DECLINED =@OFFER_DECLINED, JOINED =@JOINED, TO_JOIN =@TO_JOIN, OFFER_TO_JOIN_RATIO =@OFFER_TO_JOIN_RATIO Where CompanyName = '" & DataGridView2.Item(0, i).Value & "'")

                    SQLComm.Parameters.AddWithValue("@SCREENED", SqlDbType.Char).Value = ScreenCount
                    SQLComm.Parameters.AddWithValue("@SHARED", SqlDbType.Char).Value = SharedCount
                    SQLComm.Parameters.AddWithValue("@APPROVED", SqlDbType.Char).Value = ApprovedCount
                    SQLComm.Parameters.AddWithValue("@INVITED", SqlDbType.Char).Value = InvitedCount
                    SQLComm.Parameters.AddWithValue("@VISITED", SqlDbType.Char).Value = VisitedCount
                    SQLComm.Parameters.AddWithValue("@OFFERED", SqlDbType.Char).Value = OfferedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_ACCEPTED", SqlDbType.Char).Value = OfferacceptedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_DECLINED", SqlDbType.Char).Value = OfferdeclinedCount
                    SQLComm.Parameters.AddWithValue("@JOINED", SqlDbType.Char).Value = JoinCount
                    SQLComm.Parameters.AddWithValue("@TO_JOIN", SqlDbType.Char).Value = ToJoinCount
                    SQLComm.Parameters.AddWithValue("@OFFER_TO_JOIN_RATIO", SqlDbType.Float).Value = OfferToJoinCount

                    SQLComm.ExecuteNonQuery()

                Next i

            End If
            MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            For i = 0 To DataGridView2.Rows.Count - 1
                Application.DoEvents()
                ProgressBar5.Value = i
                '------Screened Count ---------------------------------------
                Dim ScreenCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Screening_Date >='" & DateRangeFrom5.Value & "' AND Screening_Date <= '" & DateRangeTo5.Value & "') AND Screening = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                ScreenCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Shared Count ---------------------------------------
                Dim SharedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Shared_Date >='" & DateRangeFrom5.Value & "' AND Shared_Date <= '" & DateRangeTo5.Value & "') AND Shared = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                SharedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Approved Count ---------------------------------------
                Dim ApprovedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Interview_Date >='" & DateRangeFrom5.Value & "' AND Interview_Date <= '" & DateRangeTo5.Value & "') AND Interview = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                ApprovedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Invited Count ---------------------------------------
                Dim InvitedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Invited_Date >='" & DateRangeFrom5.Value & "' AND Invited_Date <= '" & DateRangeTo5.Value & "') AND Invited = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                InvitedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Visited Count ---------------------------------------
                Dim VisitedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Visited_Date >='" & DateRangeFrom5.Value & "' AND Visited_Date <= '" & DateRangeTo5.Value & "') AND Visited = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                VisitedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Offer Count ---------------------------------------
                Dim OfferedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >='" & DateRangeFrom5.Value & "' AND Offer_Date <= '" & DateRangeTo5.Value & "') AND Offer = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                OfferedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Offer_accepted Count ---------------------------------------
                Dim OfferacceptedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >='" & DateRangeFrom5.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo5.Value & "') AND Offer_Accepted = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                OfferacceptedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Offer_declined Count ---------------------------------------
                Dim OfferdeclinedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >='" & DateRangeFrom5.Value & "' AND Offer_Date <= '" & DateRangeTo5.Value & "') AND Offer_Status = 'Declined' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                OfferdeclinedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Join Count ---------------------------------------
                Dim JoinCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >='" & DateRangeFrom5.Value & "' AND Joining_Date <= '" & DateRangeTo5.Value & "') AND Joining = 'Yes' and Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                JoinCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------To Join Count ---------------------------------------
                Dim ToJoinCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >='" & DateRangeFrom5.Value & "' AND Joining_Date <= '" & DateRangeTo5.Value & "') AND Joining_Date > '" & Date.Today & "' And Company1 = '" & DataGridView2.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                ToJoinCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""

                SQLComm.Parameters.Clear()


                '------Offer To Join Count ---------------------------------------
                Dim OfferToJoinCount As Decimal
                If OfferedCount = 0 Or JoinCount = 0 Then
                    OfferToJoinCount = "0"
                Else
                    OfferToJoinCount = (JoinCount / OfferedCount) * 100
                End If

                SQLComm.Connection = SQLConn
                SQLComm.CommandText = ("UPDATE CompanyList Set SCREENED = @SCREENED,Shared=@Shared, APPROVED =@APPROVED, INVITED =@INVITED, VISITED =@VISITED, OFFERED =@OFFERED, OFFER_ACCEPTED =@OFFER_ACCEPTED, OFFER_DECLINED =@OFFER_DECLINED, JOINED =@JOINED, TO_JOIN =@TO_JOIN, OFFER_TO_JOIN_RATIO =@OFFER_TO_JOIN_RATIO Where CompanyName = '" & DataGridView2.Item(0, i).Value & "'")

                SQLComm.Parameters.AddWithValue("@SCREENED", SqlDbType.Char).Value = ScreenCount
                SQLComm.Parameters.AddWithValue("@SHARED", SqlDbType.Char).Value = SharedCount
                SQLComm.Parameters.AddWithValue("@APPROVED", SqlDbType.Char).Value = ApprovedCount
                SQLComm.Parameters.AddWithValue("@INVITED", SqlDbType.Char).Value = InvitedCount
                SQLComm.Parameters.AddWithValue("@VISITED", SqlDbType.Char).Value = VisitedCount
                SQLComm.Parameters.AddWithValue("@OFFERED", SqlDbType.Char).Value = OfferedCount
                SQLComm.Parameters.AddWithValue("@OFFER_ACCEPTED", SqlDbType.Char).Value = OfferacceptedCount
                SQLComm.Parameters.AddWithValue("@OFFER_DECLINED", SqlDbType.Char).Value = OfferdeclinedCount
                SQLComm.Parameters.AddWithValue("@JOINED", SqlDbType.Char).Value = JoinCount
                SQLComm.Parameters.AddWithValue("@TO_JOIN", SqlDbType.Char).Value = ToJoinCount
                SQLComm.Parameters.AddWithValue("@OFFER_TO_JOIN_RATIO", SqlDbType.Float).Value = OfferToJoinCount

                SQLComm.ExecuteNonQuery()

            Next i
            MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        DataGridView2.DataSource = DS_SQL_CompanyList.CompanyList
        Me.CompanyListTableAdapter1.Fill(Me.DS_SQL_CompanyList.CompanyList)
        DataGridView2.Refresh()
        SQLConn.Dispose()
        SQLComm.Parameters.Clear()
        ProgressBar5.Hide()
        ProgressBar5.Minimum = 0

    End Sub

    Private Sub Button_Refresh6_Click(sender As Object, e As EventArgs) Handles Button_Refresh6.Click
        Dim FY_Start_Year As Integer = If(ComboBoxFY6.Text <> "ALL", Mid(ComboBoxFY6.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY6.Text <> "ALL", Mid(ComboBoxFY6.Text, 3, 2) & Mid(ComboBoxFY6.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        If RadioButtonDateRange6.Checked = True And DateRangeFrom6.Value > DateRangeTo6.Value Then
            MessageBox.Show("Check Date Range !!!")
            DateRangeTo6.Focus()
            Exit Sub
        End If

        Dim i As Integer
        SQLConn.Dispose()
        SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
        SQLComm.Connection = SQLConn
        ProgressBar6.Show()
        ProgressBar6.Minimum = 0
        ProgressBar6.Maximum = DataGridView3.RowCount
        SQLComm.Connection = SQLConn
        SQLConn.Open()

        '----------------------------------------------------Recruiter Wise-----------------------------------------------------
        If RadioButtonFY6.Checked = True Then

            If ComboBoxFY6.Text = "ALL" Then
                For i = 0 To DataGridView3.Rows.Count - 1
                    Application.DoEvents()
                    ProgressBar6.Value = i
                    '------Screened Count ---------------------------------------
                    Dim ScreenCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Screening = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ScreenCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Shared Count ---------------------------------------
                    Dim SharedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Shared = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    SharedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Approved Count ---------------------------------------
                    Dim ApprovedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Interview = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ApprovedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Invited Count ---------------------------------------
                    Dim InvitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Invited = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    InvitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Visited Count ---------------------------------------
                    Dim VisitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Visited = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    VisitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer Count ---------------------------------------
                    Dim OfferedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_accepted Count ---------------------------------------
                    Dim OfferacceptedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer_Accepted = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferacceptedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_declined Count ---------------------------------------
                    Dim OfferdeclinedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer_Status = 'Declined' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    OfferdeclinedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Join Count ---------------------------------------
                    Dim JoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Joining = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    JoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------To Join Count ---------------------------------------
                    Dim ToJoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Joining_Date > '" & Date.Today & "' And Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ToJoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Parameters.Clear()


                    '------Offer To Join Count ---------------------------------------
                    Dim OfferToJoinCount As Decimal
                    If OfferedCount = 0 Or JoinCount = 0 Then
                        OfferToJoinCount = "0"
                    Else
                        OfferToJoinCount = (JoinCount / OfferedCount) * 100
                    End If

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE Recruiter Set SCREENED = @SCREENED,Shared=@Shared, APPROVED =@APPROVED, INVITED =@INVITED, VISITED =@VISITED, OFFERED =@OFFERED, OFFER_ACCEPTED =@OFFER_ACCEPTED, OFFER_DECLINED =@OFFER_DECLINED, JOINED =@JOINED, TO_JOIN =@TO_JOIN, OFFER_TO_JOIN_RATIO =@OFFER_TO_JOIN_RATIO Where RecruiterName = '" & DataGridView3.Item(0, i).Value & "'")

                    SQLComm.Parameters.AddWithValue("@SCREENED", SqlDbType.Char).Value = ScreenCount
                    SQLComm.Parameters.AddWithValue("@SHARED", SqlDbType.Char).Value = SharedCount
                    SQLComm.Parameters.AddWithValue("@APPROVED", SqlDbType.Char).Value = ApprovedCount
                    SQLComm.Parameters.AddWithValue("@INVITED", SqlDbType.Char).Value = InvitedCount
                    SQLComm.Parameters.AddWithValue("@VISITED", SqlDbType.Char).Value = VisitedCount
                    SQLComm.Parameters.AddWithValue("@OFFERED", SqlDbType.Char).Value = OfferedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_ACCEPTED", SqlDbType.Char).Value = OfferacceptedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_DECLINED", SqlDbType.Char).Value = OfferdeclinedCount
                    SQLComm.Parameters.AddWithValue("@JOINED", SqlDbType.Char).Value = JoinCount
                    SQLComm.Parameters.AddWithValue("@TO_JOIN", SqlDbType.Char).Value = ToJoinCount
                    SQLComm.Parameters.AddWithValue("@OFFER_TO_JOIN_RATIO", SqlDbType.Float).Value = OfferToJoinCount

                    SQLComm.ExecuteNonQuery()

                Next i

            Else

                For i = 0 To DataGridView3.Rows.Count - 1
                    Application.DoEvents()
                    ProgressBar6.Value = i
                    '------Screened Count ---------------------------------------
                    Dim ScreenCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Screening = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ScreenCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Shared Count ---------------------------------------
                    Dim SharedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Shared = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    SharedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Approved Count ---------------------------------------
                    Dim ApprovedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Interview = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ApprovedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Invited Count ---------------------------------------
                    Dim InvitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Invited_Date >=" & FY_Start_Date & " AND Invited_Date <= " & FY_End_Date & ") AND Invited = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    InvitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Visited Count ---------------------------------------
                    Dim VisitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Visited_Date >=" & FY_Start_Date & " AND Visited_Date <= " & FY_End_Date & ") AND Visited = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    VisitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer Count ---------------------------------------
                    Dim OfferedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_accepted Count ---------------------------------------
                    Dim OfferacceptedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferacceptedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_declined Count ---------------------------------------
                    Dim OfferdeclinedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer_Status = 'Declined' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    OfferdeclinedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Join Count ---------------------------------------
                    Dim JoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    JoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------To Join Count ---------------------------------------
                    Dim ToJoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining_Date > '" & Date.Today & "' And Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ToJoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Parameters.Clear()


                    '------Offer To Join Count ---------------------------------------
                    Dim OfferToJoinCount As Decimal
                    If OfferedCount = 0 Or JoinCount = 0 Then
                        OfferToJoinCount = "0"
                    Else
                        OfferToJoinCount = (JoinCount / OfferedCount) * 100
                    End If

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE Recruiter Set SCREENED = @SCREENED,Shared=@Shared, APPROVED =@APPROVED, INVITED =@INVITED, VISITED =@VISITED, OFFERED =@OFFERED, OFFER_ACCEPTED =@OFFER_ACCEPTED, OFFER_DECLINED =@OFFER_DECLINED, JOINED =@JOINED, TO_JOIN =@TO_JOIN, OFFER_TO_JOIN_RATIO =@OFFER_TO_JOIN_RATIO Where RecruiterName = '" & DataGridView3.Item(0, i).Value & "'")

                    SQLComm.Parameters.AddWithValue("@SCREENED", SqlDbType.Char).Value = ScreenCount
                    SQLComm.Parameters.AddWithValue("@SHARED", SqlDbType.Char).Value = SharedCount
                    SQLComm.Parameters.AddWithValue("@APPROVED", SqlDbType.Char).Value = ApprovedCount
                    SQLComm.Parameters.AddWithValue("@INVITED", SqlDbType.Char).Value = InvitedCount
                    SQLComm.Parameters.AddWithValue("@VISITED", SqlDbType.Char).Value = VisitedCount
                    SQLComm.Parameters.AddWithValue("@OFFERED", SqlDbType.Char).Value = OfferedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_ACCEPTED", SqlDbType.Char).Value = OfferacceptedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_DECLINED", SqlDbType.Char).Value = OfferdeclinedCount
                    SQLComm.Parameters.AddWithValue("@JOINED", SqlDbType.Char).Value = JoinCount
                    SQLComm.Parameters.AddWithValue("@TO_JOIN", SqlDbType.Char).Value = ToJoinCount
                    SQLComm.Parameters.AddWithValue("@OFFER_TO_JOIN_RATIO", SqlDbType.Float).Value = OfferToJoinCount

                    SQLComm.ExecuteNonQuery()

                Next i

            End If
            SQLConn.Close()
            MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            For i = 0 To DataGridView3.Rows.Count - 1
                Application.DoEvents()
                ProgressBar6.Value = i
                '------Screened Count ---------------------------------------
                Dim ScreenCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Screening_Date >='" & DateRangeFrom6.Value & "' AND Screening_Date <= '" & DateRangeTo6.Value & "') AND Screening = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                ScreenCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Shared Count ---------------------------------------
                Dim SharedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Shared_Date >='" & DateRangeFrom6.Value & "' AND Shared_Date <= '" & DateRangeTo6.Value & "') AND Shared = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                SharedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Approved Count ---------------------------------------
                Dim ApprovedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Interview_Date >='" & DateRangeFrom6.Value & "' AND Interview_Date <= '" & DateRangeTo6.Value & "') AND Interview = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                ApprovedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Invited Count ---------------------------------------
                Dim InvitedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Invited_Date >='" & DateRangeFrom6.Value & "' AND Invited_Date <= '" & DateRangeTo6.Value & "') AND Invited = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                InvitedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Visited Count ---------------------------------------
                Dim VisitedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Visited_Date >='" & DateRangeFrom6.Value & "' AND Visited_Date <= '" & DateRangeTo6.Value & "') AND Visited = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                VisitedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Offer Count ---------------------------------------
                Dim OfferedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >='" & DateRangeFrom6.Value & "' AND Offer_Date <= '" & DateRangeTo6.Value & "') AND Offer = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                OfferedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Offer_accepted Count ---------------------------------------
                Dim OfferacceptedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >='" & DateRangeFrom6.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo6.Value & "') AND Offer_Accepted = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                OfferacceptedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Offer_declined Count ---------------------------------------
                Dim OfferdeclinedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >='" & DateRangeFrom6.Value & "' AND Offer_Date <= '" & DateRangeTo6.Value & "') AND Offer_Status = 'Declined' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                OfferdeclinedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Join Count ---------------------------------------
                Dim JoinCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >='" & DateRangeFrom6.Value & "' AND Joining_Date <= '" & DateRangeTo6.Value & "') AND Joining = 'Yes' and Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                JoinCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------To Join Count ---------------------------------------
                Dim ToJoinCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >='" & DateRangeFrom6.Value & "' AND Joining_Date <= '" & DateRangeTo6.Value & "') AND Joining_Date > '" & Date.Today & "' And Recruiter_Name = '" & DataGridView3.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                ToJoinCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""

                SQLComm.Parameters.Clear()


                '------Offer To Join Count ---------------------------------------
                Dim OfferToJoinCount As Decimal
                If OfferedCount = 0 Or JoinCount = 0 Then
                    OfferToJoinCount = "0"
                Else
                    OfferToJoinCount = (JoinCount / OfferedCount) * 100
                End If

                SQLComm.Connection = SQLConn
                SQLComm.CommandText = ("UPDATE Recruiter Set SCREENED = @SCREENED,Shared=@Shared, APPROVED =@APPROVED, INVITED =@INVITED, VISITED =@VISITED, OFFERED =@OFFERED, OFFER_ACCEPTED =@OFFER_ACCEPTED, OFFER_DECLINED =@OFFER_DECLINED, JOINED =@JOINED, TO_JOIN =@TO_JOIN, OFFER_TO_JOIN_RATIO =@OFFER_TO_JOIN_RATIO Where RecruiterName = '" & DataGridView3.Item(0, i).Value & "'")

                SQLComm.Parameters.AddWithValue("@SCREENED", SqlDbType.Char).Value = ScreenCount
                SQLComm.Parameters.AddWithValue("@SHARED", SqlDbType.Char).Value = SharedCount
                SQLComm.Parameters.AddWithValue("@APPROVED", SqlDbType.Char).Value = ApprovedCount
                SQLComm.Parameters.AddWithValue("@INVITED", SqlDbType.Char).Value = InvitedCount
                SQLComm.Parameters.AddWithValue("@VISITED", SqlDbType.Char).Value = VisitedCount
                SQLComm.Parameters.AddWithValue("@OFFERED", SqlDbType.Char).Value = OfferedCount
                SQLComm.Parameters.AddWithValue("@OFFER_ACCEPTED", SqlDbType.Char).Value = OfferacceptedCount
                SQLComm.Parameters.AddWithValue("@OFFER_DECLINED", SqlDbType.Char).Value = OfferdeclinedCount
                SQLComm.Parameters.AddWithValue("@JOINED", SqlDbType.Char).Value = JoinCount
                SQLComm.Parameters.AddWithValue("@TO_JOIN", SqlDbType.Char).Value = ToJoinCount
                SQLComm.Parameters.AddWithValue("@OFFER_TO_JOIN_RATIO", SqlDbType.Float).Value = OfferToJoinCount

                SQLComm.ExecuteNonQuery()

            Next i

            MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        DataGridView3.DataSource = DS_SQL_Recruiter.Recruiter
        Me.RecruiterTableAdapter1.Fill(Me.DS_SQL_Recruiter.Recruiter)
        DataGridView3.Refresh()

        SQLConn.Dispose()
        SQLComm.Parameters.Clear()
        ProgressBar6.Hide()
        ProgressBar6.Minimum = 0

    End Sub

    Private Sub Button_Refresh7_Click(sender As Object, e As EventArgs) Handles Button_Refresh7.Click
        Dim FY_Start_Year As Integer = If(ComboBoxFY7.Text <> "ALL", Mid(ComboBoxFY7.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY7.Text <> "ALL", Mid(ComboBoxFY7.Text, 3, 2) & Mid(ComboBoxFY7.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        If RadioButtonDateRange7.Checked = True And DateRangeFrom7.Value > DateRangeTo7.Value Then
            MessageBox.Show("Check Date Range !!!")
            DateRangeTo7.Focus()
            Exit Sub
        End If

        Dim i As Integer
        SQLConn.Dispose()
        SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
        SQLComm.Connection = SQLConn
        ProgressBar7.Show()
        ProgressBar7.Minimum = 0
        ProgressBar7.Maximum = DataGridView4.RowCount
        SQLComm.Connection = SQLConn
        SQLConn.Open()

        '----------------------------------------------------Resume Source Wise-----------------------------------------------------
        If RadioButtonFY7.Checked = True Then

            If ComboBoxFY7.Text = "ALL" Then
                For i = 0 To DataGridView4.Rows.Count - 1
                    Application.DoEvents()
                    ProgressBar7.Value = i
                    '------Screened Count ---------------------------------------
                    Dim ScreenCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Screening = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ScreenCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Shared Count ---------------------------------------
                    Dim SharedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Shared = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    SharedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Approved Count ---------------------------------------
                    Dim ApprovedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Interview = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ApprovedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Invited Count ---------------------------------------
                    Dim InvitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Invited = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    InvitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Visited Count ---------------------------------------
                    Dim VisitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Visited = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    VisitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer Count ---------------------------------------
                    Dim OfferedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_accepted Count ---------------------------------------
                    Dim OfferacceptedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer_Accepted = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferacceptedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_declined Count ---------------------------------------
                    Dim OfferdeclinedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Offer_Status = 'Declined' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    OfferdeclinedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Join Count ---------------------------------------
                    Dim JoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Joining = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    JoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------To Join Count ---------------------------------------
                    Dim ToJoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Joining_Date > '" & Date.Today & "' And Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ToJoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Parameters.Clear()


                    '------Offer To Join Count ---------------------------------------
                    Dim OfferToJoinCount As Decimal
                    If OfferedCount = 0 Or JoinCount = 0 Then
                        OfferToJoinCount = "0"
                    Else
                        OfferToJoinCount = (JoinCount / OfferedCount) * 100
                    End If

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE ResumeSource Set SCREENED = @SCREENED,Shared=@Shared, APPROVED =@APPROVED, INVITED =@INVITED, VISITED =@VISITED, OFFERED =@OFFERED, OFFER_ACCEPTED =@OFFER_ACCEPTED, OFFER_DECLINED =@OFFER_DECLINED, JOINED =@JOINED, TO_JOIN =@TO_JOIN, OFFER_TO_JOIN_RATIO =@OFFER_TO_JOIN_RATIO Where Resume_Source = '" & DataGridView4.Item(0, i).Value & "'")

                    SQLComm.Parameters.AddWithValue("@SCREENED", SqlDbType.Char).Value = ScreenCount
                    SQLComm.Parameters.AddWithValue("@SHARED", SqlDbType.Char).Value = SharedCount
                    SQLComm.Parameters.AddWithValue("@APPROVED", SqlDbType.Char).Value = ApprovedCount
                    SQLComm.Parameters.AddWithValue("@INVITED", SqlDbType.Char).Value = InvitedCount
                    SQLComm.Parameters.AddWithValue("@VISITED", SqlDbType.Char).Value = VisitedCount
                    SQLComm.Parameters.AddWithValue("@OFFERED", SqlDbType.Char).Value = OfferedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_ACCEPTED", SqlDbType.Char).Value = OfferacceptedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_DECLINED", SqlDbType.Char).Value = OfferdeclinedCount
                    SQLComm.Parameters.AddWithValue("@JOINED", SqlDbType.Char).Value = JoinCount
                    SQLComm.Parameters.AddWithValue("@TO_JOIN", SqlDbType.Char).Value = ToJoinCount
                    SQLComm.Parameters.AddWithValue("@OFFER_TO_JOIN_RATIO", SqlDbType.Float).Value = OfferToJoinCount

                    SQLComm.ExecuteNonQuery()

                Next i

            Else

                For i = 0 To DataGridView4.Rows.Count - 1
                    Application.DoEvents()
                    ProgressBar7.Value = i
                    '------Screened Count ---------------------------------------
                    Dim ScreenCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Screening = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ScreenCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Shared Count ---------------------------------------
                    Dim SharedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Shared = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    SharedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Approved Count ---------------------------------------
                    Dim ApprovedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Interview = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ApprovedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Invited Count ---------------------------------------
                    Dim InvitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Invited_Date >=" & FY_Start_Date & " AND Invited_Date <= " & FY_End_Date & ") AND Invited = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    InvitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Visited Count ---------------------------------------
                    Dim VisitedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Visited_Date >=" & FY_Start_Date & " AND Visited_Date <= " & FY_End_Date & ") AND Visited = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    VisitedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer Count ---------------------------------------
                    Dim OfferedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_accepted Count ---------------------------------------
                    Dim OfferacceptedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferacceptedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Offer_declined Count ---------------------------------------
                    Dim OfferdeclinedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer_Status = 'Declined' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    OfferdeclinedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------Join Count ---------------------------------------
                    Dim JoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    JoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""
                    '------To Join Count ---------------------------------------
                    Dim ToJoinCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining_Date > '" & Date.Today & "' And Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    ToJoinCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Parameters.Clear()


                    '------Offer To Join Count ---------------------------------------
                    Dim OfferToJoinCount As Decimal
                    If OfferedCount = 0 Or JoinCount = 0 Then
                        OfferToJoinCount = "0"
                    Else
                        OfferToJoinCount = (JoinCount / OfferedCount) * 100
                    End If

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE ResumeSource Set SCREENED = @SCREENED,Shared=@Shared, APPROVED =@APPROVED, INVITED =@INVITED, VISITED =@VISITED, OFFERED =@OFFERED, OFFER_ACCEPTED =@OFFER_ACCEPTED, OFFER_DECLINED =@OFFER_DECLINED, JOINED =@JOINED, TO_JOIN =@TO_JOIN, OFFER_TO_JOIN_RATIO =@OFFER_TO_JOIN_RATIO Where Resume_Source = '" & DataGridView4.Item(0, i).Value & "'")

                    SQLComm.Parameters.AddWithValue("@SCREENED", SqlDbType.Char).Value = ScreenCount
                    SQLComm.Parameters.AddWithValue("@SHARED", SqlDbType.Char).Value = SharedCount
                    SQLComm.Parameters.AddWithValue("@APPROVED", SqlDbType.Char).Value = ApprovedCount
                    SQLComm.Parameters.AddWithValue("@INVITED", SqlDbType.Char).Value = InvitedCount
                    SQLComm.Parameters.AddWithValue("@VISITED", SqlDbType.Char).Value = VisitedCount
                    SQLComm.Parameters.AddWithValue("@OFFERED", SqlDbType.Char).Value = OfferedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_ACCEPTED", SqlDbType.Char).Value = OfferacceptedCount
                    SQLComm.Parameters.AddWithValue("@OFFER_DECLINED", SqlDbType.Char).Value = OfferdeclinedCount
                    SQLComm.Parameters.AddWithValue("@JOINED", SqlDbType.Char).Value = JoinCount
                    SQLComm.Parameters.AddWithValue("@TO_JOIN", SqlDbType.Char).Value = ToJoinCount
                    SQLComm.Parameters.AddWithValue("@OFFER_TO_JOIN_RATIO", SqlDbType.Float).Value = OfferToJoinCount

                    SQLComm.ExecuteNonQuery()

                Next i

            End If
            SQLConn.Close()
            MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            For i = 0 To DataGridView4.Rows.Count - 1
                Application.DoEvents()
                ProgressBar7.Value = i
                '------Screened Count ---------------------------------------
                Dim ScreenCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Screening_Date >='" & DateRangeFrom7.Value & "' AND Screening_Date <= '" & DateRangeTo7.Value & "') AND Screening = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                ScreenCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Shared Count ---------------------------------------
                Dim SharedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Shared_Date >='" & DateRangeFrom7.Value & "' AND Shared_Date <= '" & DateRangeTo7.Value & "') AND Shared = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                SharedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Approved Count ---------------------------------------
                Dim ApprovedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Interview_Date >='" & DateRangeFrom7.Value & "' AND Interview_Date <= '" & DateRangeTo7.Value & "') AND Interview = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                ApprovedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Invited Count ---------------------------------------
                Dim InvitedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Invited_Date >='" & DateRangeFrom7.Value & "' AND Invited_Date <= '" & DateRangeTo7.Value & "') AND Invited = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                InvitedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Visited Count ---------------------------------------
                Dim VisitedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Visited_Date >='" & DateRangeFrom7.Value & "' AND Visited_Date <= '" & DateRangeTo7.Value & "') AND Visited = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                VisitedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Offer Count ---------------------------------------
                Dim OfferedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >='" & DateRangeFrom7.Value & "' AND Offer_Date <= '" & DateRangeTo7.Value & "') AND Offer = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                OfferedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Offer_accepted Count ---------------------------------------
                Dim OfferacceptedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >='" & DateRangeFrom7.Value & "' AND Offer_Accepted_Date <= '" & DateRangeTo7.Value & "') AND Offer_Accepted = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                OfferacceptedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Offer_declined Count ---------------------------------------
                Dim OfferdeclinedCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >='" & DateRangeFrom7.Value & "' AND Offer_Date <= '" & DateRangeTo7.Value & "') AND Offer_Status = 'Declined' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                OfferdeclinedCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------Join Count ---------------------------------------
                Dim JoinCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >='" & DateRangeFrom7.Value & "' AND Joining_Date <= '" & DateRangeTo7.Value & "') AND Joining = 'Yes' and Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                JoinCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""
                '------To Join Count ---------------------------------------
                Dim ToJoinCount As Integer
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Joining_Date >='" & DateRangeFrom7.Value & "' AND Joining_Date <= '" & DateRangeTo7.Value & "') AND Joining_Date > '" & Date.Today & "' And Resume_Source = '" & DataGridView4.Item(0, i).Value & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                ToJoinCount = SQLComm.ExecuteScalar
                SQLComm.CommandText = ""

                SQLComm.Parameters.Clear()


                '------Offer To Join Count ---------------------------------------
                Dim OfferToJoinCount As Decimal
                If OfferedCount = 0 Or JoinCount = 0 Then
                    OfferToJoinCount = "0"
                Else
                    OfferToJoinCount = (JoinCount / OfferedCount) * 100
                End If

                SQLComm.Connection = SQLConn
                SQLComm.CommandText = ("UPDATE ResumeSource Set SCREENED = @SCREENED,Shared=@Shared, APPROVED =@APPROVED, INVITED =@INVITED, VISITED =@VISITED, OFFERED =@OFFERED, OFFER_ACCEPTED =@OFFER_ACCEPTED, OFFER_DECLINED =@OFFER_DECLINED, JOINED =@JOINED, TO_JOIN =@TO_JOIN, OFFER_TO_JOIN_RATIO =@OFFER_TO_JOIN_RATIO Where Resume_Source = '" & DataGridView4.Item(0, i).Value & "'")

                SQLComm.Parameters.AddWithValue("@SCREENED", SqlDbType.Char).Value = ScreenCount
                SQLComm.Parameters.AddWithValue("@SHARED", SqlDbType.Char).Value = SharedCount
                SQLComm.Parameters.AddWithValue("@APPROVED", SqlDbType.Char).Value = ApprovedCount
                SQLComm.Parameters.AddWithValue("@INVITED", SqlDbType.Char).Value = InvitedCount
                SQLComm.Parameters.AddWithValue("@VISITED", SqlDbType.Char).Value = VisitedCount
                SQLComm.Parameters.AddWithValue("@OFFERED", SqlDbType.Char).Value = OfferedCount
                SQLComm.Parameters.AddWithValue("@OFFER_ACCEPTED", SqlDbType.Char).Value = OfferacceptedCount
                SQLComm.Parameters.AddWithValue("@OFFER_DECLINED", SqlDbType.Char).Value = OfferdeclinedCount
                SQLComm.Parameters.AddWithValue("@JOINED", SqlDbType.Char).Value = JoinCount
                SQLComm.Parameters.AddWithValue("@TO_JOIN", SqlDbType.Char).Value = ToJoinCount
                SQLComm.Parameters.AddWithValue("@OFFER_TO_JOIN_RATIO", SqlDbType.Float).Value = OfferToJoinCount

                SQLComm.ExecuteNonQuery()

            Next i

            MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        DataGridView4.DataSource = DS_SQL_ResumeSource.ResumeSource
        Me.ResumeSourceTableAdapter1.Fill(Me.DS_SQL_ResumeSource.ResumeSource)

        SQLConn.Dispose()
        SQLComm.Parameters.Clear()
        ProgressBar7.Hide()
        ProgressBar7.Minimum = 0
    End Sub

    Private Sub Button_Refresh8_Click(sender As Object, e As EventArgs) Handles Button_Refresh8.Click
        Dim FY_Start_Year As Integer = If(ComboBoxFY8.Text <> "ALL", Mid(ComboBoxFY8.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY8.Text <> "ALL", Mid(ComboBoxFY8.Text, 3, 2) & Mid(ComboBoxFY8.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        Dim i As Integer
        SQLConn.Dispose()
        SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
        SQLComm.Connection = SQLConn

        If TabCVRejectReason.Focus = True Then
            '----------------------------------------------------CV Reject Reason Count Count-----------------------------------------------------
            SQLComm.Connection = SQLConn
            SQLConn.Open()

            If ComboBoxFY8.Text = "ALL" Then
                For i = 0 To DataGridView5.Rows.Count - 1
                    Application.DoEvents()

                    Dim CVRejectCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Decline_Reason = '" & DataGridView5.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    CVRejectCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE DeclineReason Set Total = @Total Where Decline_Reason = '" & DataGridView5.Item(0, i).Value & "'")
                    SQLComm.Parameters.AddWithValue("@Total", SqlDbType.Int).Value = CVRejectCount
                    SQLComm.ExecuteNonQuery()
                Next i

            Else

                For i = 0 To DataGridView5.Rows.Count - 1
                    Application.DoEvents()

                    Dim CVRejectCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Decline_Reason = '" & DataGridView5.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    CVRejectCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE DeclineReason Set Total = @Total Where Decline_Reason = '" & DataGridView5.Item(0, i).Value & "'")
                    SQLComm.Parameters.AddWithValue("@Total", SqlDbType.Int).Value = CVRejectCount
                    SQLComm.ExecuteNonQuery()
                Next i

            End If
            SQLConn.Close()
            MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)

            DataGridView5.DataSource = DS_SQL_DeclineReason.DeclineReason
            Me.DeclineReasonTableAdapter1.Fill(Me.DS_SQL_DeclineReason.DeclineReason)


        End If
        SQLComm.Parameters.Clear()

    End Sub

    Private Sub Button_Refresh9_Click(sender As Object, e As EventArgs) Handles Button_Refresh9.Click
        Dim FY_Start_Year As Integer = If(ComboBoxFY9.Text <> "ALL", Mid(ComboBoxFY9.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY9.Text <> "ALL", Mid(ComboBoxFY9.Text, 3, 2) & Mid(ComboBoxFY9.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        Dim i As Integer
        SQLConn.Dispose()
        SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
        SQLComm.Connection = SQLConn

        If TabRejectedBy.Focus = True Then
            '----------------------------------------------------Rejected By Count-----------------
            SQLComm.Connection = SQLConn
            SQLConn.Open()

            If ComboBoxFY9.Text = "ALL" Then
                For i = 0 To DataGridView6.Rows.Count - 1
                    Application.DoEvents()

                    '-----------Rejected By Count ---------------------------------------
                    Dim RejectedByCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Rejected_By = '" & DataGridView6.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    RejectedByCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE RejectedBy Set Total = @Total Where Rejected_By = '" & DataGridView6.Item(0, i).Value & "'")
                    SQLComm.Parameters.AddWithValue("@Total", SqlDbType.Int).Value = RejectedByCount
                    SQLComm.ExecuteNonQuery()
                Next i

            Else

                For i = 0 To DataGridView6.Rows.Count - 1
                    Application.DoEvents()

                    '-----------Rejected By Count ---------------------------------------
                    Dim RejectedByCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Rejected_By = '" & DataGridView6.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    RejectedByCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE RejectedBy Set Total = @Total Where Rejected_By = '" & DataGridView6.Item(0, i).Value & "'")
                    SQLComm.Parameters.AddWithValue("@Total", SqlDbType.Int).Value = RejectedByCount
                    SQLComm.ExecuteNonQuery()
                Next i

            End If
            SQLConn.Close()
            MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)


            DataGridView6.DataSource = DS_SQL_RejectedBy.RejectedBy
            Me.RejectedByTableAdapter1.Fill(Me.DS_SQL_RejectedBy.RejectedBy)

        End If
        SQLComm.Parameters.Clear()
    End Sub

    Private Sub Button_Refresh10_Click(sender As Object, e As EventArgs) Handles Button_Refresh10.Click
        Dim FY_Start_Year As Integer = If(ComboBoxFY10.Text <> "ALL", Mid(ComboBoxFY10.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY10.Text <> "ALL", Mid(ComboBoxFY10.Text, 3, 2) & Mid(ComboBoxFY10.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        Dim i As Integer
        SQLConn.Dispose()
        SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
        SQLComm.Connection = SQLConn

        If TabOfferDeclineReason.Focus = True Then
            '----------------------------------------------------Offer Declined Reason Count-----------------------------------------------------
            SQLComm.Connection = SQLConn
            SQLConn.Open()

            If ComboBoxFY10.Text = "ALL" Then
                For i = 0 To DataGridView7.Rows.Count - 1
                    Application.DoEvents()

                    '------------------Total Offer Declined Count ---------------------------------------
                    Dim OfferDeclinedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE Application_Status = 'OFFER DECLINED' and Decline_Reason = '" & DataGridView7.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferDeclinedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE OfferDeclineReason Set Total = @Total Where OFFER_DECLINE_REASON = '" & DataGridView7.Item(0, i).Value & "'")
                    SQLComm.Parameters.AddWithValue("@Total", SqlDbType.Int).Value = OfferDeclinedCount
                    SQLComm.ExecuteNonQuery()
                Next i

            Else

                For i = 0 To DataGridView7.Rows.Count - 1
                    Application.DoEvents()

                    '------------------Total Offer Declined Count ---------------------------------------
                    Dim OfferDeclinedCount As Integer
                    SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Application_Status = 'OFFER DECLINED' and Decline_Reason = '" & DataGridView7.Item(0, i).Value & "'", SQLConn)
                    SQLComm.CommandTimeout = 30
                    OfferDeclinedCount = SQLComm.ExecuteScalar
                    SQLComm.CommandText = ""

                    SQLComm.Connection = SQLConn
                    SQLComm.CommandText = ("UPDATE OfferDeclineReason Set Total = @Total Where OFFER_DECLINE_REASON = '" & DataGridView7.Item(0, i).Value & "'")
                    SQLComm.Parameters.AddWithValue("@Total", SqlDbType.Int).Value = OfferDeclinedCount
                    SQLComm.ExecuteNonQuery()
                Next i

            End If
            SQLConn.Close()
            MessageBox.Show("Updated Successfully !!!", "Recruitment Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridView7.DataSource = DS_SQL_OfferDeclineReason.OfferDeclineReason
            Me.OfferDeclineReasonTableAdapter1.Fill(Me.DS_SQL_OfferDeclineReason.OfferDeclineReason)
        End If
        SQLComm.Parameters.Clear()
    End Sub

    Private Sub ComboBoxFY5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFY5.SelectedIndexChanged
        RadioButtonFY5.Checked = True
    End Sub

    Private Sub DateRangeTo4_ValueChanged(sender As Object, e As EventArgs) Handles DateRangeTo4.ValueChanged
        RadioButtonDateRange.Checked = True
    End Sub

    Private Sub DateRangeFrom5_ValueChanged(sender As Object, e As EventArgs) Handles DateRangeFrom5.ValueChanged
        RadioButtonDateRange5.Checked = True
    End Sub

    Private Sub DateRangeTo5_ValueChanged(sender As Object, e As EventArgs) Handles DateRangeTo5.ValueChanged
        RadioButtonDateRange5.Checked = True
    End Sub

    Private Sub ComboBoxFY6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFY6.SelectedIndexChanged
        RadioButtonFY6.Checked = True
    End Sub

    Private Sub DateRangeFrom6_ValueChanged(sender As Object, e As EventArgs) Handles DateRangeFrom6.ValueChanged
        RadioButtonDateRange6.Checked = True
    End Sub

    Private Sub DateRangeTo6_ValueChanged(sender As Object, e As EventArgs) Handles DateRangeTo6.ValueChanged
        RadioButtonDateRange6.Checked = True
    End Sub

    Private Sub ComboBoxFY7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFY7.SelectedIndexChanged
        RadioButtonFY7.Checked = True
    End Sub

    Private Sub DateRangeFrom7_ValueChanged(sender As Object, e As EventArgs) Handles DateRangeFrom7.ValueChanged
        RadioButtonDateRange7.Checked = True
    End Sub

    Private Sub DateRangeTo7_ValueChanged(sender As Object, e As EventArgs) Handles DateRangeTo7.ValueChanged
        RadioButtonDateRange7.Checked = True
    End Sub

    Private Sub Button_Refresh11_Click(sender As Object, e As EventArgs) Handles Button_Refresh11.Click
        Try
            Dim FY_Start_Year As Integer = If(ComboBoxFY11.Text <> "ALL", Mid(ComboBoxFY11.Text, 3, 4), Today.Year)
            Dim FY_End_Year As Integer = If(ComboBoxFY11.Text <> "ALL", Mid(ComboBoxFY11.Text, 3, 2) & Mid(ComboBoxFY11.Text, 8, 2), Today.Year)
            Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
            Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

            '------Change Month Name according to financial year---------------
            Label_apr.Text = "APR-" & Mid(ComboBoxFY11.Text, 5, 2)
            Label_may.Text = "MAY-" & Mid(ComboBoxFY11.Text, 5, 2)
            Label_jun.Text = "JUN-" & Mid(ComboBoxFY11.Text, 5, 2)
            Label_jul.Text = "JUL-" & Mid(ComboBoxFY11.Text, 5, 2)
            Label_aug.Text = "AUG-" & Mid(ComboBoxFY11.Text, 5, 2)
            Label_sep.Text = "SEP-" & Mid(ComboBoxFY11.Text, 5, 2)
            Label_oct.Text = "OCT-" & Mid(ComboBoxFY11.Text, 5, 2)
            Label_nov.Text = "NOV-" & Mid(ComboBoxFY11.Text, 5, 2)
            Label_dec.Text = "DEC-" & Mid(ComboBoxFY11.Text, 5, 2)
            Label_jan.Text = "JAN-" & Mid(ComboBoxFY11.Text, 8, 2)
            Label_feb.Text = "FEB-" & Mid(ComboBoxFY11.Text, 8, 2)
            Label_mar.Text = "MAR-" & Mid(ComboBoxFY11.Text, 8, 2)


            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()

            If (RadioButton_Company.Checked = True Or RadioButton_GroupCompany.Checked = True) And (attr_company.Text = "ALL" And attr_groupcompany.Text = "ALL") Then
                '------------------------------ Hired ----------------
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='4-1-" & FY_Start_Year & "' AND Joining_Date <= '4-30-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                apr_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='5-1-" & FY_Start_Year & "' AND Joining_Date <= '5-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                may_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='6-1-" & FY_Start_Year & "' AND Joining_Date <= '6-30-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                jun_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='7-1-" & FY_Start_Year & "' AND Joining_Date <= '7-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                jul_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='8-1-" & FY_Start_Year & "' AND Joining_Date <= '8-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                aug_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='9-1-" & FY_Start_Year & "' AND Joining_Date <= '9-30-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                sep_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='10-1-" & FY_Start_Year & "' AND Joining_Date <= '10-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                oct_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='11-1-" & FY_Start_Year & "' AND Joining_Date <= '11-30-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                nov_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='12-1-" & FY_Start_Year & "' AND Joining_Date <= '12-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                dec_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='1-1-" & FY_End_Year & "' AND Joining_Date <= '1-31-" & FY_End_Year & "') AND Joining = 'Yes'", SQLConn)
                jan_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='2-1-" & FY_End_Year & "' AND Joining_Date <= '2-" & System.DateTime.DaysInMonth(FY_End_Year, 2) & "-" & FY_End_Year & "') AND Joining = 'Yes'", SQLConn)
                feb_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='3-1-" & FY_End_Year & "' AND Joining_Date <= '3-31-" & FY_End_Year & "') AND Joining = 'Yes'", SQLConn)
                mar_hired.Text = SQLComm.ExecuteScalar

                ytd_hired.Text = Int(apr_hired.Text) + Int(may_hired.Text) + Int(jun_hired.Text) + Int(jul_hired.Text) + Int(aug_hired.Text) + Int(sep_hired.Text) + Int(oct_hired.Text) + Int(nov_hired.Text) + Int(dec_hired.Text) + Int(jan_hired.Text) + Int(feb_hired.Text) + Int(mar_hired.Text)

                '------------------------------ Opening Balance ----------------
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Month = '4-1-" & FY_Start_Year & "'", SQLConn)
                apr_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Month = '5-1-" & FY_Start_Year & "'", SQLConn)
                may_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Month = '6-1-" & FY_Start_Year & "'", SQLConn)
                jun_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Month = '7-1-" & FY_Start_Year & "'", SQLConn)
                jul_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Month = '8-1-" & FY_Start_Year & "'", SQLConn)
                aug_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Month = '9-1-" & FY_Start_Year & "'", SQLConn)
                sep_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Month = '10-1-" & FY_Start_Year & "'", SQLConn)
                oct_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Month = '11-1-" & FY_Start_Year & "'", SQLConn)
                nov_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Month = '12-1-" & FY_Start_Year & "'", SQLConn)
                dec_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Month = '1-1-" & FY_End_Year & "'", SQLConn)
                jan_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Month = '2-1-" & FY_End_Year & "'", SQLConn)
                feb_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Month = '3-1-" & FY_End_Year & "'", SQLConn)
                mar_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)

                ytd_opening.Text = apr_opening.Text

                '------------------------------ Exit ----------------
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where (Leaving_Date >='4-1-" & FY_Start_Year & "' AND Leaving_Date <= '4-30-" & FY_Start_Year & "') ", SQLConn)
                apr_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where (Leaving_Date >='5-1-" & FY_Start_Year & "' AND Leaving_Date <= '5-31-" & FY_Start_Year & "') ", SQLConn)
                may_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where (Leaving_Date >='6-1-" & FY_Start_Year & "' AND Leaving_Date <= '6-30-" & FY_Start_Year & "') ", SQLConn)
                jun_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where (Leaving_Date >='7-1-" & FY_Start_Year & "' AND Leaving_Date <= '7-31-" & FY_Start_Year & "') ", SQLConn)
                jul_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where (Leaving_Date >='8-1-" & FY_Start_Year & "' AND Leaving_Date <= '8-31-" & FY_Start_Year & "') ", SQLConn)
                aug_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where (Leaving_Date >='9-1-" & FY_Start_Year & "' AND Leaving_Date <= '9-30-" & FY_Start_Year & "') ", SQLConn)
                sep_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where (Leaving_Date >='10-1-" & FY_Start_Year & "' AND Leaving_Date <= '10-31-" & FY_Start_Year & "') ", SQLConn)
                oct_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where (Leaving_Date >='11-1-" & FY_Start_Year & "' AND Leaving_Date <= '11-30-" & FY_Start_Year & "') ", SQLConn)
                nov_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where (Leaving_Date >='12-1-" & FY_Start_Year & "' AND Leaving_Date <= '12-31-" & FY_Start_Year & "') ", SQLConn)
                dec_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where (Leaving_Date >='1-1-" & FY_End_Year & "' AND Leaving_Date <= '1-31-" & FY_End_Year & "') ", SQLConn)
                jan_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where (Leaving_Date >='2-1-" & FY_End_Year & "' AND Leaving_Date <= '2-28-" & FY_End_Year & "') ", SQLConn)
                feb_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where (Leaving_Date >='3-1-" & FY_End_Year & "' AND Leaving_Date <= '3-31-" & FY_End_Year & "') ", SQLConn)
                mar_exit.Text = SQLComm.ExecuteScalar

                ytd_exit.Text = Int(apr_exit.Text) + Int(may_exit.Text) + Int(jun_exit.Text) + Int(jul_exit.Text) + Int(aug_exit.Text) + Int(sep_exit.Text) + Int(oct_exit.Text) + Int(nov_exit.Text) + Int(dec_exit.Text) + Int(jan_exit.Text) + Int(feb_exit.Text) + Int(mar_exit.Text)

                '------------------------------ Closing Balance ----------------
                apr_closing.Text = Int(apr_opening.Text) + Int(apr_hired.Text) - Int(apr_exit.Text)
                may_closing.Text = Int(may_opening.Text) + Int(may_hired.Text) - Int(may_exit.Text)
                jun_closing.Text = Int(jun_opening.Text) + Int(jun_hired.Text) - Int(jun_exit.Text)
                jul_closing.Text = Int(jul_opening.Text) + Int(jul_hired.Text) - Int(jul_exit.Text)
                aug_closing.Text = Int(aug_opening.Text) + Int(aug_hired.Text) - Int(aug_exit.Text)
                sep_closing.Text = Int(sep_opening.Text) + Int(sep_hired.Text) - Int(sep_exit.Text)
                oct_closing.Text = Int(oct_opening.Text) + Int(oct_hired.Text) - Int(oct_exit.Text)
                nov_closing.Text = Int(nov_opening.Text) + Int(nov_hired.Text) - Int(nov_exit.Text)
                dec_closing.Text = Int(dec_opening.Text) + Int(dec_hired.Text) - Int(dec_exit.Text)
                jan_closing.Text = Int(jan_opening.Text) + Int(jan_hired.Text) - Int(jan_exit.Text)
                feb_closing.Text = Int(feb_opening.Text) + Int(feb_hired.Text) - Int(feb_exit.Text)
                mar_closing.Text = Int(mar_opening.Text) + Int(mar_hired.Text) - Int(mar_exit.Text)

                ytd_closing.Text = Int(ytd_opening.Text) + Int(ytd_hired.Text) - Int(ytd_exit.Text)

                '------------------------------ Average  ----------------
                apr_avg.Text = If(IsError(Int((Int(apr_opening.Text) + Int(apr_closing.Text)) / 2)), 0, Int((Int(apr_opening.Text) + Int(apr_closing.Text)) / 2))
                may_avg.Text = If(IsError(Int((Int(may_opening.Text) + Int(may_closing.Text)) / 2)), 0, Int((Int(may_opening.Text) + Int(may_closing.Text)) / 2))
                jun_avg.Text = If(IsError(Int((Int(jun_opening.Text) + Int(jun_closing.Text)) / 2)), 0, Int((Int(jun_opening.Text) + Int(jun_closing.Text)) / 2))
                jul_avg.Text = If(IsError(Int((Int(jul_opening.Text) + Int(jul_closing.Text)) / 2)), 0, Int((Int(jul_opening.Text) + Int(jul_closing.Text)) / 2))
                aug_avg.Text = If(IsError(Int((Int(aug_opening.Text) + Int(aug_closing.Text)) / 2)), 0, Int((Int(aug_opening.Text) + Int(aug_closing.Text)) / 2))
                sep_avg.Text = If(IsError(Int((Int(sep_opening.Text) + Int(sep_closing.Text)) / 2)), 0, Int((Int(sep_opening.Text) + Int(sep_closing.Text)) / 2))
                oct_avg.Text = If(IsError(Int((Int(oct_opening.Text) + Int(oct_closing.Text)) / 2)), 0, Int((Int(oct_opening.Text) + Int(oct_closing.Text)) / 2))
                nov_avg.Text = If(IsError(Int((Int(nov_opening.Text) + Int(nov_closing.Text)) / 2)), 0, Int((Int(nov_opening.Text) + Int(nov_closing.Text)) / 2))
                dec_avg.Text = If(IsError(Int((Int(dec_opening.Text) + Int(dec_closing.Text)) / 2)), 0, Int((Int(dec_opening.Text) + Int(dec_closing.Text)) / 2))
                jan_avg.Text = If(IsError(Int((Int(jan_opening.Text) + Int(jan_closing.Text)) / 2)), 0, Int((Int(jan_opening.Text) + Int(jan_closing.Text)) / 2))
                feb_avg.Text = If(IsError(Int((Int(feb_opening.Text) + Int(feb_closing.Text)) / 2)), 0, Int((Int(feb_opening.Text) + Int(feb_closing.Text)) / 2))
                mar_avg.Text = If(IsError(Int((Int(mar_opening.Text) + Int(mar_closing.Text)) / 2)), 0, Int((Int(mar_opening.Text) + Int(mar_closing.Text)) / 2))
                ytd_avg.Text = If(IsError(Int((Int(ytd_opening.Text) + Int(ytd_closing.Text)) / 2)), 0, Int((Int(ytd_opening.Text) + Int(ytd_closing.Text)) / 2))

                '-----------------Attrition Rate -------------------------------

                If Int(apr_exit.Text) <= 0 Or Int(apr_avg.Text) <= 0 Then
                    apr_attr.Text = "0" & "%"
                Else
                    apr_attr.Text = Int((Int(apr_exit.Text) / Int(apr_avg.Text)) * 100) & "%"
                End If
                If Int(may_exit.Text) <= 0 Or Int(may_avg.Text) <= 0 Then
                    may_attr.Text = "0" & "%"
                Else
                    may_attr.Text = Int((Int(may_exit.Text) / Int(may_avg.Text)) * 100) & "%"
                End If
                If Int(jun_exit.Text) <= 0 Or Int(jun_avg.Text) <= 0 Then
                    jun_attr.Text = "0" & "%"
                Else
                    jun_attr.Text = Int((Int(jun_exit.Text) / Int(jun_avg.Text)) * 100) & "%"
                End If
                If Int(jul_exit.Text) <= 0 Or Int(jul_avg.Text) <= 0 Then
                    jul_attr.Text = "0" & "%"
                Else
                    jul_attr.Text = Int((Int(jul_exit.Text) / Int(jul_avg.Text)) * 100) & "%"
                End If
                If Int(aug_exit.Text) <= 0 Or Int(aug_avg.Text) <= 0 Then
                    aug_attr.Text = "0" & "%"
                Else
                    aug_attr.Text = Int((Int(aug_exit.Text) / Int(aug_avg.Text)) * 100) & "%"
                End If
                If Int(sep_exit.Text) <= 0 Or Int(sep_avg.Text) <= 0 Then
                    sep_attr.Text = "0" & "%"
                Else
                    sep_attr.Text = Int((Int(sep_exit.Text) / Int(sep_avg.Text)) * 100) & "%"
                End If
                If Int(oct_exit.Text) <= 0 Or Int(oct_avg.Text) <= 0 Then
                    oct_attr.Text = "0" & "%"
                Else
                    oct_attr.Text = Int((Int(oct_exit.Text) / Int(oct_avg.Text)) * 100) & "%"
                End If
                If Int(nov_exit.Text) <= 0 Or Int(nov_avg.Text) <= 0 Then
                    nov_attr.Text = "0" & "%"
                Else
                    nov_attr.Text = Int((Int(nov_exit.Text) / Int(nov_avg.Text)) * 100) & "%"
                End If
                If Int(dec_exit.Text) <= 0 Or Int(dec_avg.Text) <= 0 Then
                    dec_attr.Text = "0" & "%"
                Else
                    dec_attr.Text = Int((Int(dec_exit.Text) / Int(dec_avg.Text)) * 100) & "%"
                End If
                If Int(jan_exit.Text) <= 0 Or Int(jan_avg.Text) <= 0 Then
                    jan_attr.Text = "0" & "%"
                Else
                    jan_attr.Text = Int((Int(jan_exit.Text) / Int(jan_avg.Text)) * 100) & "%"
                End If
                If Int(feb_exit.Text) <= 0 Or Int(feb_avg.Text) <= 0 Then
                    feb_attr.Text = "0" & "%"
                Else
                    feb_attr.Text = Int((Int(feb_exit.Text) / Int(feb_avg.Text)) * 100) & "%"
                End If
                If Int(mar_exit.Text) <= 0 Or Int(mar_avg.Text) <= 0 Then
                    mar_attr.Text = "0" & "%"
                Else
                    mar_attr.Text = Int((Int(mar_exit.Text) / Int(mar_avg.Text)) * 100) & "%"
                End If
                If Int(ytd_exit.Text) <= 0 Or Int(ytd_avg.Text) <= 0 Then
                    ytd_attr.Text = "0" & "%"
                Else
                    ytd_attr.Text = Int((Int(ytd_exit.Text) / Int(ytd_avg.Text)) * 100) & "%"
                End If

                '----------Attrition Graph --------------------------
                AttritionChart.Series("attr_rate").Points.Clear()
                AttritionChart.Series("attr_rate").Points.AddXY(Label_apr.Text, If(Int(apr_exit.Text) <= 0 Or Int(apr_avg.Text) <= 0, 0, Int((Int(apr_exit.Text) / Int(apr_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_may.Text, If(Int(may_exit.Text) <= 0 Or Int(may_avg.Text) <= 0, 0, Int((Int(may_exit.Text) / Int(may_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_jun.Text, If(Int(jun_exit.Text) <= 0 Or Int(jun_avg.Text) <= 0, 0, Int((Int(jun_exit.Text) / Int(jun_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_jul.Text, If(Int(jul_exit.Text) <= 0 Or Int(jul_avg.Text) <= 0, 0, Int((Int(jul_exit.Text) / Int(jul_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_aug.Text, If(Int(aug_exit.Text) <= 0 Or Int(aug_avg.Text) <= 0, 0, Int((Int(aug_exit.Text) / Int(aug_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_sep.Text, If(Int(sep_exit.Text) <= 0 Or Int(sep_avg.Text) <= 0, 0, Int((Int(sep_exit.Text) / Int(sep_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_oct.Text, If(Int(oct_exit.Text) <= 0 Or Int(oct_avg.Text) <= 0, 0, Int((Int(oct_exit.Text) / Int(oct_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_nov.Text, If(Int(nov_exit.Text) <= 0 Or Int(nov_avg.Text) <= 0, 0, Int((Int(nov_exit.Text) / Int(nov_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_dec.Text, If(Int(dec_exit.Text) <= 0 Or Int(dec_avg.Text) <= 0, 0, Int((Int(dec_exit.Text) / Int(dec_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_jan.Text, If(Int(jan_exit.Text) <= 0 Or Int(jan_avg.Text) <= 0, 0, Int((Int(jan_exit.Text) / Int(jan_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_feb.Text, If(Int(feb_exit.Text) <= 0 Or Int(feb_avg.Text) <= 0, 0, Int((Int(feb_exit.Text) / Int(feb_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_mar.Text, If(Int(mar_exit.Text) <= 0 Or Int(mar_avg.Text) <= 0, 0, Int((Int(mar_exit.Text) / Int(mar_avg.Text)) * 100)))
                '--------------------------------------------------------------------------------------------

            ElseIf RadioButton_Company.Checked = True And attr_company.Text <> "ALL" Then

                '------------------------------ Hired ----------------
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Company1='" & attr_company.Text & "' AND (Joining_Date >='4-1-" & FY_Start_Year & "' AND Joining_Date <= '4-30-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                apr_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Company1='" & attr_company.Text & "' AND (Joining_Date >='5-1-" & FY_Start_Year & "' AND Joining_Date <= '5-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                may_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Company1='" & attr_company.Text & "' AND (Joining_Date >='6-1-" & FY_Start_Year & "' AND Joining_Date <= '6-30-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                jun_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Company1='" & attr_company.Text & "' AND (Joining_Date >='7-1-" & FY_Start_Year & "' AND Joining_Date <= '7-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                jul_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Company1='" & attr_company.Text & "' AND (Joining_Date >='8-1-" & FY_Start_Year & "' AND Joining_Date <= '8-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                aug_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Company1='" & attr_company.Text & "' AND (Joining_Date >='9-1-" & FY_Start_Year & "' AND Joining_Date <= '9-30-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                sep_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Company1='" & attr_company.Text & "' AND (Joining_Date >='10-1-" & FY_Start_Year & "' AND Joining_Date <= '10-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                oct_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Company1='" & attr_company.Text & "' AND (Joining_Date >='11-1-" & FY_Start_Year & "' AND Joining_Date <= '11-30-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                nov_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Company1='" & attr_company.Text & "' AND (Joining_Date >='12-1-" & FY_Start_Year & "' AND Joining_Date <= '12-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
                dec_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Company1='" & attr_company.Text & "' AND (Joining_Date >='1-1-" & FY_End_Year & "' AND Joining_Date <= '1-31-" & FY_End_Year & "') AND Joining = 'Yes'", SQLConn)
                jan_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Company1='" & attr_company.Text & "' AND (Joining_Date >='2-1-" & FY_End_Year & "' AND Joining_Date <= '2-28-" & FY_End_Year & "') AND Joining = 'Yes'", SQLConn)
                feb_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Company1='" & attr_company.Text & "' AND (Joining_Date >='3-1-" & FY_End_Year & "' AND Joining_Date <= '3-31-" & FY_End_Year & "') AND Joining = 'Yes'", SQLConn)
                mar_hired.Text = SQLComm.ExecuteScalar

                ytd_hired.Text = Int(apr_hired.Text) + Int(may_hired.Text) + Int(jun_hired.Text) + Int(jul_hired.Text) + Int(aug_hired.Text) + Int(sep_hired.Text) + Int(oct_hired.Text) + Int(nov_hired.Text) + Int(dec_hired.Text) + Int(jan_hired.Text) + Int(feb_hired.Text) + Int(mar_hired.Text)

                '------------------------------ Opening Balance ----------------
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Company='" & attr_company.Text & "' AND Month = '4-1-" & FY_Start_Year & "'", SQLConn)
                apr_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Company='" & attr_company.Text & "' AND Month = '5-1-" & FY_Start_Year & "'", SQLConn)
                may_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Company='" & attr_company.Text & "' AND Month = '6-1-" & FY_Start_Year & "'", SQLConn)
                jun_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Company='" & attr_company.Text & "' AND Month = '7-1-" & FY_Start_Year & "'", SQLConn)
                jul_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Company='" & attr_company.Text & "' AND Month = '8-1-" & FY_Start_Year & "'", SQLConn)
                aug_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Company='" & attr_company.Text & "' AND Month = '9-1-" & FY_Start_Year & "'", SQLConn)
                sep_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Company='" & attr_company.Text & "' AND Month = '10-1-" & FY_Start_Year & "'", SQLConn)
                oct_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Company='" & attr_company.Text & "' AND Month = '11-1-" & FY_Start_Year & "'", SQLConn)
                nov_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Company='" & attr_company.Text & "' AND Month = '12-1-" & FY_Start_Year & "'", SQLConn)
                dec_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Company='" & attr_company.Text & "' AND Month = '1-1-" & FY_End_Year & "'", SQLConn)
                jan_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Company='" & attr_company.Text & "' AND Month = '2-1-" & FY_End_Year & "'", SQLConn)
                feb_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where Company='" & attr_company.Text & "' AND Month = '3-1-" & FY_End_Year & "'", SQLConn)
                mar_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)

                ytd_opening.Text = apr_opening.Text

                '------------------------------ Exit ----------------
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Company='" & attr_company.Text & "' AND (Leaving_Date >='4-1-" & FY_Start_Year & "' AND Leaving_Date <= '4-30-" & FY_Start_Year & "') ", SQLConn)
                apr_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Company='" & attr_company.Text & "' AND (Leaving_Date >='5-1-" & FY_Start_Year & "' AND Leaving_Date <= '5-31-" & FY_Start_Year & "') ", SQLConn)
                may_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Company='" & attr_company.Text & "' AND (Leaving_Date >='6-1-" & FY_Start_Year & "' AND Leaving_Date <= '6-30-" & FY_Start_Year & "') ", SQLConn)
                jun_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Company='" & attr_company.Text & "' AND (Leaving_Date >='7-1-" & FY_Start_Year & "' AND Leaving_Date <= '7-31-" & FY_Start_Year & "') ", SQLConn)
                jul_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Company='" & attr_company.Text & "' AND (Leaving_Date >='8-1-" & FY_Start_Year & "' AND Leaving_Date <= '8-31-" & FY_Start_Year & "') ", SQLConn)
                aug_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Company='" & attr_company.Text & "' AND (Leaving_Date >='9-1-" & FY_Start_Year & "' AND Leaving_Date <= '9-30-" & FY_Start_Year & "') ", SQLConn)
                sep_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Company='" & attr_company.Text & "' AND (Leaving_Date >='10-1-" & FY_Start_Year & "' AND Leaving_Date <= '10-31-" & FY_Start_Year & "') ", SQLConn)
                oct_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Company='" & attr_company.Text & "' AND (Leaving_Date >='11-1-" & FY_Start_Year & "' AND Leaving_Date <= '11-30-" & FY_Start_Year & "') ", SQLConn)
                nov_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Company='" & attr_company.Text & "' AND (Leaving_Date >='12-1-" & FY_Start_Year & "' AND Leaving_Date <= '12-31-" & FY_Start_Year & "') ", SQLConn)
                dec_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Company='" & attr_company.Text & "' AND (Leaving_Date >='1-1-" & FY_End_Year & "' AND Leaving_Date <= '1-31-" & FY_End_Year & "') ", SQLConn)
                jan_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Company='" & attr_company.Text & "' AND (Leaving_Date >='2-1-" & FY_End_Year & "' AND Leaving_Date <= '2-28-" & FY_End_Year & "') ", SQLConn)
                feb_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Company='" & attr_company.Text & "' AND (Leaving_Date >='3-1-" & FY_End_Year & "' AND Leaving_Date <= '3-31-" & FY_End_Year & "') ", SQLConn)
                mar_exit.Text = SQLComm.ExecuteScalar

                ytd_exit.Text = Int(apr_exit.Text) + Int(may_exit.Text) + Int(jun_exit.Text) + Int(jul_exit.Text) + Int(aug_exit.Text) + Int(sep_exit.Text) + Int(oct_exit.Text) + Int(nov_exit.Text) + Int(dec_exit.Text) + Int(jan_exit.Text) + Int(feb_exit.Text) + Int(mar_exit.Text)

                '------------------------------ Closing Balance ----------------
                apr_closing.Text = Int(apr_opening.Text) + Int(apr_hired.Text) - Int(apr_exit.Text)
                may_closing.Text = Int(may_opening.Text) + Int(may_hired.Text) - Int(may_exit.Text)
                jun_closing.Text = Int(jun_opening.Text) + Int(jun_hired.Text) - Int(jun_exit.Text)
                jul_closing.Text = Int(jul_opening.Text) + Int(jul_hired.Text) - Int(jul_exit.Text)
                aug_closing.Text = Int(aug_opening.Text) + Int(aug_hired.Text) - Int(aug_exit.Text)
                sep_closing.Text = Int(sep_opening.Text) + Int(sep_hired.Text) - Int(sep_exit.Text)
                oct_closing.Text = Int(oct_opening.Text) + Int(oct_hired.Text) - Int(oct_exit.Text)
                nov_closing.Text = Int(nov_opening.Text) + Int(nov_hired.Text) - Int(nov_exit.Text)
                dec_closing.Text = Int(dec_opening.Text) + Int(dec_hired.Text) - Int(dec_exit.Text)
                jan_closing.Text = Int(jan_opening.Text) + Int(jan_hired.Text) - Int(jan_exit.Text)
                feb_closing.Text = Int(feb_opening.Text) + Int(feb_hired.Text) - Int(feb_exit.Text)
                mar_closing.Text = Int(mar_opening.Text) + Int(mar_hired.Text) - Int(mar_exit.Text)

                ytd_closing.Text = Int(ytd_opening.Text) + Int(ytd_hired.Text) - Int(ytd_exit.Text)

                '------------------------------ Average  ----------------
                apr_avg.Text = If(IsError(Int((Int(apr_opening.Text) + Int(apr_closing.Text)) / 2)), 0, Int((Int(apr_opening.Text) + Int(apr_closing.Text)) / 2))
                may_avg.Text = If(IsError(Int((Int(may_opening.Text) + Int(may_closing.Text)) / 2)), 0, Int((Int(may_opening.Text) + Int(may_closing.Text)) / 2))
                jun_avg.Text = If(IsError(Int((Int(jun_opening.Text) + Int(jun_closing.Text)) / 2)), 0, Int((Int(jun_opening.Text) + Int(jun_closing.Text)) / 2))
                jul_avg.Text = If(IsError(Int((Int(jul_opening.Text) + Int(jul_closing.Text)) / 2)), 0, Int((Int(jul_opening.Text) + Int(jul_closing.Text)) / 2))
                aug_avg.Text = If(IsError(Int((Int(aug_opening.Text) + Int(aug_closing.Text)) / 2)), 0, Int((Int(aug_opening.Text) + Int(aug_closing.Text)) / 2))
                sep_avg.Text = If(IsError(Int((Int(sep_opening.Text) + Int(sep_closing.Text)) / 2)), 0, Int((Int(sep_opening.Text) + Int(sep_closing.Text)) / 2))
                oct_avg.Text = If(IsError(Int((Int(oct_opening.Text) + Int(oct_closing.Text)) / 2)), 0, Int((Int(oct_opening.Text) + Int(oct_closing.Text)) / 2))
                nov_avg.Text = If(IsError(Int((Int(nov_opening.Text) + Int(nov_closing.Text)) / 2)), 0, Int((Int(nov_opening.Text) + Int(nov_closing.Text)) / 2))
                dec_avg.Text = If(IsError(Int((Int(dec_opening.Text) + Int(dec_closing.Text)) / 2)), 0, Int((Int(dec_opening.Text) + Int(dec_closing.Text)) / 2))
                jan_avg.Text = If(IsError(Int((Int(jan_opening.Text) + Int(jan_closing.Text)) / 2)), 0, Int((Int(jan_opening.Text) + Int(jan_closing.Text)) / 2))
                feb_avg.Text = If(IsError(Int((Int(feb_opening.Text) + Int(feb_closing.Text)) / 2)), 0, Int((Int(feb_opening.Text) + Int(feb_closing.Text)) / 2))
                mar_avg.Text = If(IsError(Int((Int(mar_opening.Text) + Int(mar_closing.Text)) / 2)), 0, Int((Int(mar_opening.Text) + Int(mar_closing.Text)) / 2))
                ytd_avg.Text = If(IsError(Int((Int(ytd_opening.Text) + Int(ytd_closing.Text)) / 2)), 0, Int((Int(ytd_opening.Text) + Int(ytd_closing.Text)) / 2))

                '-----------------Attrition Rate -------------------------------

                If Int(apr_exit.Text) <= 0 Or Int(apr_avg.Text) <= 0 Then
                    apr_attr.Text = "0" & "%"
                Else
                    apr_attr.Text = Int((Int(apr_exit.Text) / Int(apr_avg.Text)) * 100) & "%"
                End If
                If Int(may_exit.Text) <= 0 Or Int(may_avg.Text) <= 0 Then
                    may_attr.Text = "0" & "%"
                Else
                    may_attr.Text = Int((Int(may_exit.Text) / Int(may_avg.Text)) * 100) & "%"
                End If
                If Int(jun_exit.Text) <= 0 Or Int(jun_avg.Text) <= 0 Then
                    jun_attr.Text = "0" & "%"
                Else
                    jun_attr.Text = Int((Int(jun_exit.Text) / Int(jun_avg.Text)) * 100) & "%"
                End If
                If Int(jul_exit.Text) <= 0 Or Int(jul_avg.Text) <= 0 Then
                    jul_attr.Text = "0" & "%"
                Else
                    jul_attr.Text = Int((Int(jul_exit.Text) / Int(jul_avg.Text)) * 100) & "%"
                End If
                If Int(aug_exit.Text) <= 0 Or Int(aug_avg.Text) <= 0 Then
                    aug_attr.Text = "0" & "%"
                Else
                    aug_attr.Text = Int((Int(aug_exit.Text) / Int(aug_avg.Text)) * 100) & "%"
                End If
                If Int(sep_exit.Text) <= 0 Or Int(sep_avg.Text) <= 0 Then
                    sep_attr.Text = "0" & "%"
                Else
                    sep_attr.Text = Int((Int(sep_exit.Text) / Int(sep_avg.Text)) * 100) & "%"
                End If
                If Int(oct_exit.Text) <= 0 Or Int(oct_avg.Text) <= 0 Then
                    oct_attr.Text = "0" & "%"
                Else
                    oct_attr.Text = Int((Int(oct_exit.Text) / Int(oct_avg.Text)) * 100) & "%"
                End If
                If Int(nov_exit.Text) <= 0 Or Int(nov_avg.Text) <= 0 Then
                    nov_attr.Text = "0" & "%"
                Else
                    nov_attr.Text = Int((Int(nov_exit.Text) / Int(nov_avg.Text)) * 100) & "%"
                End If
                If Int(dec_exit.Text) <= 0 Or Int(dec_avg.Text) <= 0 Then
                    dec_attr.Text = "0" & "%"
                Else
                    dec_attr.Text = Int((Int(dec_exit.Text) / Int(dec_avg.Text)) * 100) & "%"
                End If
                If Int(jan_exit.Text) <= 0 Or Int(jan_avg.Text) <= 0 Then
                    jan_attr.Text = "0" & "%"
                Else
                    jan_attr.Text = Int((Int(jan_exit.Text) / Int(jan_avg.Text)) * 100) & "%"
                End If
                If Int(feb_exit.Text) <= 0 Or Int(feb_avg.Text) <= 0 Then
                    feb_attr.Text = "0" & "%"
                Else
                    feb_attr.Text = Int((Int(feb_exit.Text) / Int(feb_avg.Text)) * 100) & "%"
                End If
                If Int(mar_exit.Text) <= 0 Or Int(mar_avg.Text) <= 0 Then
                    mar_attr.Text = "0" & "%"
                Else
                    mar_attr.Text = Int((Int(mar_exit.Text) / Int(mar_avg.Text)) * 100) & "%"
                End If
                If Int(ytd_exit.Text) <= 0 Or Int(ytd_avg.Text) <= 0 Then
                    ytd_attr.Text = "0" & "%"
                Else
                    ytd_attr.Text = Int((Int(ytd_exit.Text) / Int(ytd_avg.Text)) * 100) & "%"
                End If

                '----------Attrition Graph --------------------------
                AttritionChart.Series("attr_rate").Points.Clear()
                AttritionChart.Series("attr_rate").Points.AddXY(Label_apr.Text, If(Int(apr_exit.Text) <= 0 Or Int(apr_avg.Text) <= 0, 0, Int((Int(apr_exit.Text) / Int(apr_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_may.Text, If(Int(may_exit.Text) <= 0 Or Int(may_avg.Text) <= 0, 0, Int((Int(may_exit.Text) / Int(may_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_jun.Text, If(Int(jun_exit.Text) <= 0 Or Int(jun_avg.Text) <= 0, 0, Int((Int(jun_exit.Text) / Int(jun_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_jul.Text, If(Int(jul_exit.Text) <= 0 Or Int(jul_avg.Text) <= 0, 0, Int((Int(jul_exit.Text) / Int(jul_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_aug.Text, If(Int(aug_exit.Text) <= 0 Or Int(aug_avg.Text) <= 0, 0, Int((Int(aug_exit.Text) / Int(aug_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_sep.Text, If(Int(sep_exit.Text) <= 0 Or Int(sep_avg.Text) <= 0, 0, Int((Int(sep_exit.Text) / Int(sep_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_oct.Text, If(Int(oct_exit.Text) <= 0 Or Int(oct_avg.Text) <= 0, 0, Int((Int(oct_exit.Text) / Int(oct_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_nov.Text, If(Int(nov_exit.Text) <= 0 Or Int(nov_avg.Text) <= 0, 0, Int((Int(nov_exit.Text) / Int(nov_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_dec.Text, If(Int(dec_exit.Text) <= 0 Or Int(dec_avg.Text) <= 0, 0, Int((Int(dec_exit.Text) / Int(dec_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_jan.Text, If(Int(jan_exit.Text) <= 0 Or Int(jan_avg.Text) <= 0, 0, Int((Int(jan_exit.Text) / Int(jan_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_feb.Text, If(Int(feb_exit.Text) <= 0 Or Int(feb_avg.Text) <= 0, 0, Int((Int(feb_exit.Text) / Int(feb_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_mar.Text, If(Int(mar_exit.Text) <= 0 Or Int(mar_avg.Text) <= 0, 0, Int((Int(mar_exit.Text) / Int(mar_avg.Text)) * 100)))
                '--------------------------------------------------------------------------------------------

            ElseIf RadioButton_GroupCompany.Checked = True And attr_groupcompany.Text <> "ALL" Then ' working here

                '------------------------------ Hired ----------------
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join CompanyList on CompanyList.CompanyName = ApplicationTable.Company1 Where CompanyList.CompanyGroup='" & attr_groupcompany.Text & "' AND (ApplicationTable.Joining_Date >='4-1-" & FY_Start_Year & "' AND ApplicationTable.Joining_Date <= '4-30-" & FY_Start_Year & "') AND ApplicationTable.Joining = 'Yes'", SQLConn)
                apr_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join CompanyList on CompanyList.CompanyName = ApplicationTable.Company1 Where CompanyList.CompanyGroup='" & attr_groupcompany.Text & "' AND (ApplicationTable.Joining_Date >='5-1-" & FY_Start_Year & "' AND ApplicationTable.Joining_Date <= '5-31-" & FY_Start_Year & "') AND ApplicationTable.Joining = 'Yes'", SQLConn)
                may_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join CompanyList on CompanyList.CompanyName = ApplicationTable.Company1 Where CompanyList.CompanyGroup='" & attr_groupcompany.Text & "' AND (ApplicationTable.Joining_Date >='6-1-" & FY_Start_Year & "' AND ApplicationTable.Joining_Date <= '6-30-" & FY_Start_Year & "') AND ApplicationTable.Joining = 'Yes'", SQLConn)
                jun_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join CompanyList on CompanyList.CompanyName = ApplicationTable.Company1 Where CompanyList.CompanyGroup='" & attr_groupcompany.Text & "' AND (ApplicationTable.Joining_Date >='7-1-" & FY_Start_Year & "' AND ApplicationTable.Joining_Date <= '7-31-" & FY_Start_Year & "') AND ApplicationTable.Joining = 'Yes'", SQLConn)
                jul_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join CompanyList on CompanyList.CompanyName = ApplicationTable.Company1 Where CompanyList.CompanyGroup='" & attr_groupcompany.Text & "' AND (ApplicationTable.Joining_Date >='8-1-" & FY_Start_Year & "' AND ApplicationTable.Joining_Date <= '8-31-" & FY_Start_Year & "') AND ApplicationTable.Joining = 'Yes'", SQLConn)
                aug_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join CompanyList on CompanyList.CompanyName = ApplicationTable.Company1 Where CompanyList.CompanyGroup='" & attr_groupcompany.Text & "' AND (ApplicationTable.Joining_Date >='9-1-" & FY_Start_Year & "' AND ApplicationTable.Joining_Date <= '9-30-" & FY_Start_Year & "') AND ApplicationTable.Joining = 'Yes'", SQLConn)
                sep_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join CompanyList on CompanyList.CompanyName = ApplicationTable.Company1 Where CompanyList.CompanyGroup='" & attr_groupcompany.Text & "' AND (ApplicationTable.Joining_Date >='10-1-" & FY_Start_Year & "' AND ApplicationTable.Joining_Date <= '10-31-" & FY_Start_Year & "') AND ApplicationTable.Joining = 'Yes'", SQLConn)
                oct_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join CompanyList on CompanyList.CompanyName = ApplicationTable.Company1 Where CompanyList.CompanyGroup='" & attr_groupcompany.Text & "' AND (ApplicationTable.Joining_Date >='11-1-" & FY_Start_Year & "' AND ApplicationTable.Joining_Date <= '11-30-" & FY_Start_Year & "') AND ApplicationTable.Joining = 'Yes'", SQLConn)
                nov_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join CompanyList on CompanyList.CompanyName = ApplicationTable.Company1 Where CompanyList.CompanyGroup='" & attr_groupcompany.Text & "' AND (ApplicationTable.Joining_Date >='12-1-" & FY_Start_Year & "' AND ApplicationTable.Joining_Date <= '12-31-" & FY_Start_Year & "') AND ApplicationTable.Joining = 'Yes'", SQLConn)
                dec_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join CompanyList on CompanyList.CompanyName = ApplicationTable.Company1 Where CompanyList.CompanyGroup='" & attr_groupcompany.Text & "' AND (ApplicationTable.Joining_Date >='1-1-" & FY_End_Year & "' AND ApplicationTable.Joining_Date <= '1-31-" & FY_End_Year & "') AND ApplicationTable.Joining = 'Yes'", SQLConn)
                jan_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join CompanyList on CompanyList.CompanyName = ApplicationTable.Company1 Where CompanyList.CompanyGroup='" & attr_groupcompany.Text & "' AND (ApplicationTable.Joining_Date >='2-1-" & FY_End_Year & "' AND ApplicationTable.Joining_Date <= '2-28-" & FY_End_Year & "') AND ApplicationTable.Joining = 'Yes'", SQLConn)
                feb_hired.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Left Join CompanyList on CompanyList.CompanyName = ApplicationTable.Company1 Where CompanyList.CompanyGroup='" & attr_groupcompany.Text & "' AND (ApplicationTable.Joining_Date >='3-1-" & FY_End_Year & "' AND ApplicationTable.Joining_Date <= '3-31-" & FY_End_Year & "') AND ApplicationTable.Joining = 'Yes'", SQLConn)
                mar_hired.Text = SQLComm.ExecuteScalar

                ytd_hired.Text = Int(apr_hired.Text) + Int(may_hired.Text) + Int(jun_hired.Text) + Int(jul_hired.Text) + Int(aug_hired.Text) + Int(sep_hired.Text) + Int(oct_hired.Text) + Int(nov_hired.Text) + Int(dec_hired.Text) + Int(jan_hired.Text) + Int(feb_hired.Text) + Int(mar_hired.Text)

                '------------------------------ Opening Balance ----------------
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where group_company='" & attr_groupcompany.Text & "' AND Month = '4-1-" & FY_Start_Year & "'", SQLConn)
                apr_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where group_company='" & attr_groupcompany.Text & "' AND Month = '5-1-" & FY_Start_Year & "'", SQLConn)
                may_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where group_company='" & attr_groupcompany.Text & "' AND Month = '6-1-" & FY_Start_Year & "'", SQLConn)
                jun_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where group_company='" & attr_groupcompany.Text & "' AND Month = '7-1-" & FY_Start_Year & "'", SQLConn)
                jul_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where group_company='" & attr_groupcompany.Text & "' AND Month = '8-1-" & FY_Start_Year & "'", SQLConn)
                aug_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where group_company='" & attr_groupcompany.Text & "' AND Month = '9-1-" & FY_Start_Year & "'", SQLConn)
                sep_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where group_company='" & attr_groupcompany.Text & "' AND Month = '10-1-" & FY_Start_Year & "'", SQLConn)
                oct_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where group_company='" & attr_groupcompany.Text & "' AND Month = '11-1-" & FY_Start_Year & "'", SQLConn)
                nov_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where group_company='" & attr_groupcompany.Text & "' AND Month = '12-1-" & FY_Start_Year & "'", SQLConn)
                dec_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where group_company='" & attr_groupcompany.Text & "' AND Month = '1-1-" & FY_End_Year & "'", SQLConn)
                jan_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where group_company='" & attr_groupcompany.Text & "' AND Month = '2-1-" & FY_End_Year & "'", SQLConn)
                feb_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)
                SQLComm = New SqlCommand("Select Sum(employee_count) FROM HeadCount Where group_company='" & attr_groupcompany.Text & "' AND Month = '3-1-" & FY_End_Year & "'", SQLConn)
                mar_opening.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, SQLComm.ExecuteScalar)

                ytd_opening.Text = apr_opening.Text

                '------------------------------ Exit ----------------
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Group_Company='" & attr_groupcompany.Text & "' AND (Leaving_Date >='4-1-" & FY_Start_Year & "' AND Leaving_Date <= '4-30-" & FY_Start_Year & "') ", SQLConn)
                apr_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Group_Company='" & attr_groupcompany.Text & "' AND (Leaving_Date >='5-1-" & FY_Start_Year & "' AND Leaving_Date <= '5-31-" & FY_Start_Year & "') ", SQLConn)
                may_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Group_Company='" & attr_groupcompany.Text & "' AND (Leaving_Date >='6-1-" & FY_Start_Year & "' AND Leaving_Date <= '6-30-" & FY_Start_Year & "') ", SQLConn)
                jun_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Group_Company='" & attr_groupcompany.Text & "' AND (Leaving_Date >='7-1-" & FY_Start_Year & "' AND Leaving_Date <= '7-31-" & FY_Start_Year & "') ", SQLConn)
                jul_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Group_Company='" & attr_groupcompany.Text & "' AND (Leaving_Date >='8-1-" & FY_Start_Year & "' AND Leaving_Date <= '8-31-" & FY_Start_Year & "') ", SQLConn)
                aug_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Group_Company='" & attr_groupcompany.Text & "' AND (Leaving_Date >='9-1-" & FY_Start_Year & "' AND Leaving_Date <= '9-30-" & FY_Start_Year & "') ", SQLConn)
                sep_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Group_Company='" & attr_groupcompany.Text & "' AND (Leaving_Date >='10-1-" & FY_Start_Year & "' AND Leaving_Date <= '10-31-" & FY_Start_Year & "') ", SQLConn)
                oct_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Group_Company='" & attr_groupcompany.Text & "' AND (Leaving_Date >='11-1-" & FY_Start_Year & "' AND Leaving_Date <= '11-30-" & FY_Start_Year & "') ", SQLConn)
                nov_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Group_Company='" & attr_groupcompany.Text & "' AND (Leaving_Date >='12-1-" & FY_Start_Year & "' AND Leaving_Date <= '12-31-" & FY_Start_Year & "') ", SQLConn)
                dec_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Group_Company='" & attr_groupcompany.Text & "' AND (Leaving_Date >='1-1-" & FY_End_Year & "' AND Leaving_Date <= '1-31-" & FY_End_Year & "') ", SQLConn)
                jan_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Group_Company='" & attr_groupcompany.Text & "' AND (Leaving_Date >='2-1-" & FY_End_Year & "' AND Leaving_Date <= '2-28-" & FY_End_Year & "') ", SQLConn)
                feb_exit.Text = SQLComm.ExecuteScalar
                SQLComm = New SqlCommand("Select Count(*) FROM ExitEmployee Where Group_Company='" & attr_groupcompany.Text & "' AND (Leaving_Date >='3-1-" & FY_End_Year & "' AND Leaving_Date <= '3-31-" & FY_End_Year & "') ", SQLConn)
                mar_exit.Text = SQLComm.ExecuteScalar

                ytd_exit.Text = Int(apr_exit.Text) + Int(may_exit.Text) + Int(jun_exit.Text) + Int(jul_exit.Text) + Int(aug_exit.Text) + Int(sep_exit.Text) + Int(oct_exit.Text) + Int(nov_exit.Text) + Int(dec_exit.Text) + Int(jan_exit.Text) + Int(feb_exit.Text) + Int(mar_exit.Text)

                '------------------------------ Closing Balance ----------------
                apr_closing.Text = Int(apr_opening.Text) + Int(apr_hired.Text) - Int(apr_exit.Text)
                may_closing.Text = Int(may_opening.Text) + Int(may_hired.Text) - Int(may_exit.Text)
                jun_closing.Text = Int(jun_opening.Text) + Int(jun_hired.Text) - Int(jun_exit.Text)
                jul_closing.Text = Int(jul_opening.Text) + Int(jul_hired.Text) - Int(jul_exit.Text)
                aug_closing.Text = Int(aug_opening.Text) + Int(aug_hired.Text) - Int(aug_exit.Text)
                sep_closing.Text = Int(sep_opening.Text) + Int(sep_hired.Text) - Int(sep_exit.Text)
                oct_closing.Text = Int(oct_opening.Text) + Int(oct_hired.Text) - Int(oct_exit.Text)
                nov_closing.Text = Int(nov_opening.Text) + Int(nov_hired.Text) - Int(nov_exit.Text)
                dec_closing.Text = Int(dec_opening.Text) + Int(dec_hired.Text) - Int(dec_exit.Text)
                jan_closing.Text = Int(jan_opening.Text) + Int(jan_hired.Text) - Int(jan_exit.Text)
                feb_closing.Text = Int(feb_opening.Text) + Int(feb_hired.Text) - Int(feb_exit.Text)
                mar_closing.Text = Int(mar_opening.Text) + Int(mar_hired.Text) - Int(mar_exit.Text)

                ytd_closing.Text = Int(ytd_opening.Text) + Int(ytd_hired.Text) - Int(ytd_exit.Text)

                '------------------------------ Average  ----------------
                apr_avg.Text = If(IsError(Int((Int(apr_opening.Text) + Int(apr_closing.Text)) / 2)), 0, Int((Int(apr_opening.Text) + Int(apr_closing.Text)) / 2))
                may_avg.Text = If(IsError(Int((Int(may_opening.Text) + Int(may_closing.Text)) / 2)), 0, Int((Int(may_opening.Text) + Int(may_closing.Text)) / 2))
                jun_avg.Text = If(IsError(Int((Int(jun_opening.Text) + Int(jun_closing.Text)) / 2)), 0, Int((Int(jun_opening.Text) + Int(jun_closing.Text)) / 2))
                jul_avg.Text = If(IsError(Int((Int(jul_opening.Text) + Int(jul_closing.Text)) / 2)), 0, Int((Int(jul_opening.Text) + Int(jul_closing.Text)) / 2))
                aug_avg.Text = If(IsError(Int((Int(aug_opening.Text) + Int(aug_closing.Text)) / 2)), 0, Int((Int(aug_opening.Text) + Int(aug_closing.Text)) / 2))
                sep_avg.Text = If(IsError(Int((Int(sep_opening.Text) + Int(sep_closing.Text)) / 2)), 0, Int((Int(sep_opening.Text) + Int(sep_closing.Text)) / 2))
                oct_avg.Text = If(IsError(Int((Int(oct_opening.Text) + Int(oct_closing.Text)) / 2)), 0, Int((Int(oct_opening.Text) + Int(oct_closing.Text)) / 2))
                nov_avg.Text = If(IsError(Int((Int(nov_opening.Text) + Int(nov_closing.Text)) / 2)), 0, Int((Int(nov_opening.Text) + Int(nov_closing.Text)) / 2))
                dec_avg.Text = If(IsError(Int((Int(dec_opening.Text) + Int(dec_closing.Text)) / 2)), 0, Int((Int(dec_opening.Text) + Int(dec_closing.Text)) / 2))
                jan_avg.Text = If(IsError(Int((Int(jan_opening.Text) + Int(jan_closing.Text)) / 2)), 0, Int((Int(jan_opening.Text) + Int(jan_closing.Text)) / 2))
                feb_avg.Text = If(IsError(Int((Int(feb_opening.Text) + Int(feb_closing.Text)) / 2)), 0, Int((Int(feb_opening.Text) + Int(feb_closing.Text)) / 2))
                mar_avg.Text = If(IsError(Int((Int(mar_opening.Text) + Int(mar_closing.Text)) / 2)), 0, Int((Int(mar_opening.Text) + Int(mar_closing.Text)) / 2))
                ytd_avg.Text = If(IsError(Int((Int(ytd_opening.Text) + Int(ytd_closing.Text)) / 2)), 0, Int((Int(ytd_opening.Text) + Int(ytd_closing.Text)) / 2))

                '-----------------Attrition Rate -------------------------------

                If Int(apr_exit.Text) <= 0 Or Int(apr_avg.Text) <= 0 Then
                    apr_attr.Text = "0" & "%"
                Else
                    apr_attr.Text = Int((Int(apr_exit.Text) / Int(apr_avg.Text)) * 100) & "%"
                End If
                If Int(may_exit.Text) <= 0 Or Int(may_avg.Text) <= 0 Then
                    may_attr.Text = "0" & "%"
                Else
                    may_attr.Text = Int((Int(may_exit.Text) / Int(may_avg.Text)) * 100) & "%"
                End If
                If Int(jun_exit.Text) <= 0 Or Int(jun_avg.Text) <= 0 Then
                    jun_attr.Text = "0" & "%"
                Else
                    jun_attr.Text = Int((Int(jun_exit.Text) / Int(jun_avg.Text)) * 100) & "%"
                End If
                If Int(jul_exit.Text) <= 0 Or Int(jul_avg.Text) <= 0 Then
                    jul_attr.Text = "0" & "%"
                Else
                    jul_attr.Text = Int((Int(jul_exit.Text) / Int(jul_avg.Text)) * 100) & "%"
                End If
                If Int(aug_exit.Text) <= 0 Or Int(aug_avg.Text) <= 0 Then
                    aug_attr.Text = "0" & "%"
                Else
                    aug_attr.Text = Int((Int(aug_exit.Text) / Int(aug_avg.Text)) * 100) & "%"
                End If
                If Int(sep_exit.Text) <= 0 Or Int(sep_avg.Text) <= 0 Then
                    sep_attr.Text = "0" & "%"
                Else
                    sep_attr.Text = Int((Int(sep_exit.Text) / Int(sep_avg.Text)) * 100) & "%"
                End If
                If Int(oct_exit.Text) <= 0 Or Int(oct_avg.Text) <= 0 Then
                    oct_attr.Text = "0" & "%"
                Else
                    oct_attr.Text = Int((Int(oct_exit.Text) / Int(oct_avg.Text)) * 100) & "%"
                End If
                If Int(nov_exit.Text) <= 0 Or Int(nov_avg.Text) <= 0 Then
                    nov_attr.Text = "0" & "%"
                Else
                    nov_attr.Text = Int((Int(nov_exit.Text) / Int(nov_avg.Text)) * 100) & "%"
                End If
                If Int(dec_exit.Text) <= 0 Or Int(dec_avg.Text) <= 0 Then
                    dec_attr.Text = "0" & "%"
                Else
                    dec_attr.Text = Int((Int(dec_exit.Text) / Int(dec_avg.Text)) * 100) & "%"
                End If
                If Int(jan_exit.Text) <= 0 Or Int(jan_avg.Text) <= 0 Then
                    jan_attr.Text = "0" & "%"
                Else
                    jan_attr.Text = Int((Int(jan_exit.Text) / Int(jan_avg.Text)) * 100) & "%"
                End If
                If Int(feb_exit.Text) <= 0 Or Int(feb_avg.Text) <= 0 Then
                    feb_attr.Text = "0" & "%"
                Else
                    feb_attr.Text = Int((Int(feb_exit.Text) / Int(feb_avg.Text)) * 100) & "%"
                End If
                If Int(mar_exit.Text) <= 0 Or Int(mar_avg.Text) <= 0 Then
                    mar_attr.Text = "0" & "%"
                Else
                    mar_attr.Text = Int((Int(mar_exit.Text) / Int(mar_avg.Text)) * 100) & "%"
                End If
                If Int(ytd_exit.Text) <= 0 Or Int(ytd_avg.Text) <= 0 Then
                    ytd_attr.Text = "0" & "%"
                Else
                    ytd_attr.Text = Int((Int(ytd_exit.Text) / Int(ytd_avg.Text)) * 100) & "%"
                End If

                '----------Attrition Graph --------------------------
                AttritionChart.Series("attr_rate").Points.Clear()
                AttritionChart.Series("attr_rate").Points.AddXY(Label_apr.Text, If(Int(apr_exit.Text) <= 0 Or Int(apr_avg.Text) <= 0, 0, Int((Int(apr_exit.Text) / Int(apr_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_may.Text, If(Int(may_exit.Text) <= 0 Or Int(may_avg.Text) <= 0, 0, Int((Int(may_exit.Text) / Int(may_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_jun.Text, If(Int(jun_exit.Text) <= 0 Or Int(jun_avg.Text) <= 0, 0, Int((Int(jun_exit.Text) / Int(jun_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_jul.Text, If(Int(jul_exit.Text) <= 0 Or Int(jul_avg.Text) <= 0, 0, Int((Int(jul_exit.Text) / Int(jul_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_aug.Text, If(Int(aug_exit.Text) <= 0 Or Int(aug_avg.Text) <= 0, 0, Int((Int(aug_exit.Text) / Int(aug_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_sep.Text, If(Int(sep_exit.Text) <= 0 Or Int(sep_avg.Text) <= 0, 0, Int((Int(sep_exit.Text) / Int(sep_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_oct.Text, If(Int(oct_exit.Text) <= 0 Or Int(oct_avg.Text) <= 0, 0, Int((Int(oct_exit.Text) / Int(oct_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_nov.Text, If(Int(nov_exit.Text) <= 0 Or Int(nov_avg.Text) <= 0, 0, Int((Int(nov_exit.Text) / Int(nov_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_dec.Text, If(Int(dec_exit.Text) <= 0 Or Int(dec_avg.Text) <= 0, 0, Int((Int(dec_exit.Text) / Int(dec_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_jan.Text, If(Int(jan_exit.Text) <= 0 Or Int(jan_avg.Text) <= 0, 0, Int((Int(jan_exit.Text) / Int(jan_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_feb.Text, If(Int(feb_exit.Text) <= 0 Or Int(feb_avg.Text) <= 0, 0, Int((Int(feb_exit.Text) / Int(feb_avg.Text)) * 100)))
                AttritionChart.Series("attr_rate").Points.AddXY(Label_mar.Text, If(Int(mar_exit.Text) <= 0 Or Int(mar_avg.Text) <= 0, 0, Int((Int(mar_exit.Text) / Int(mar_avg.Text)) * 100)))
                '--------------------------------------------------------------------------------------------

            End If

            SQLComm.Dispose()
            SQLConn.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLComm.Dispose()
            SQLConn.Dispose()
        End Try
    End Sub

    Private Sub ComboBoxFY11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFY11.SelectedIndexChanged
        Dim FY_Start_Year As Integer = If(ComboBoxFY1.Text <> "ALL", Mid(ComboBoxFY1.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY1.Text <> "ALL", Mid(ComboBoxFY1.Text, 3, 2) & Mid(ComboBoxFY1.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        Label_apr.Text = "APR-" & Mid(ComboBoxFY11.Text, 5, 2)
        Label_may.Text = "MAY-" & Mid(ComboBoxFY11.Text, 5, 2)
        Label_jun.Text = "JUN-" & Mid(ComboBoxFY11.Text, 5, 2)
        Label_jul.Text = "JUL-" & Mid(ComboBoxFY11.Text, 5, 2)
        Label_aug.Text = "AUG-" & Mid(ComboBoxFY11.Text, 5, 2)
        Label_sep.Text = "SEP-" & Mid(ComboBoxFY11.Text, 5, 2)
        Label_oct.Text = "OCT-" & Mid(ComboBoxFY11.Text, 5, 2)
        Label_nov.Text = "NOV-" & Mid(ComboBoxFY11.Text, 5, 2)
        Label_dec.Text = "DEC-" & Mid(ComboBoxFY11.Text, 5, 2)
        Label_jan.Text = "JAN-" & Mid(ComboBoxFY11.Text, 8, 2)
        Label_feb.Text = "FEB-" & Mid(ComboBoxFY11.Text, 8, 2)
        Label_mar.Text = "MAR-" & Mid(ComboBoxFY11.Text, 8, 2)

    End Sub

    Private Sub attr_company_SelectedIndexChanged(sender As Object, e As EventArgs) Handles attr_company.SelectedIndexChanged
        RadioButton_Company.Checked = True
    End Sub

    Private Sub attr_groupcompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles attr_groupcompany.SelectedIndexChanged
        RadioButton_GroupCompany.Checked = True
    End Sub

    Private Sub Button_Refresh12_Click(sender As Object, e As EventArgs) Handles Button_Refresh12.Click
        Try
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()
            '----------------- Annual Budget ---------------------
            SQLComm = New SqlCommand("select Annual_Budget from RecruitmentBudget where MONTH=(select max(month) from RecruitmentBudget Where FY='" & ComboBoxFY12.Text & "') and Category='Recruitment' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            ab_rec.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar / 100000, NumDigitsAfterDecimal:=2))

            SQLComm = New SqlCommand("select Annual_Budget from RecruitmentBudget where MONTH=(select max(month) from RecruitmentBudget Where FY='" & ComboBoxFY12.Text & "') and Category='People Development' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            ab_pd.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar / 100000, NumDigitsAfterDecimal:=2))

            SQLComm = New SqlCommand("select Annual_Budget from RecruitmentBudget where MONTH=(select max(month) from RecruitmentBudget Where FY='" & ComboBoxFY12.Text & "') and Category='Employee Engagment' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            ab_ee.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar / 100000, NumDigitsAfterDecimal:=2))

            SQLComm = New SqlCommand("select Annual_Budget from RecruitmentBudget where MONTH=(select max(month) from RecruitmentBudget Where FY='" & ComboBoxFY12.Text & "') and Category='Administration' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            ab_adm.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar / 100000, NumDigitsAfterDecimal:=2))

            SQLComm = New SqlCommand("select Annual_Budget from RecruitmentBudget where MONTH=(select max(month) from RecruitmentBudget Where FY='" & ComboBoxFY12.Text & "') and Category='Partner Relations' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            ab_pr.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar / 100000, NumDigitsAfterDecimal:=2))

            ab_total.Text = Convert.ToDecimal(ab_rec.Text) + Convert.ToDecimal(ab_pd.Text) + Convert.ToDecimal(ab_ee.Text) + Convert.ToDecimal(ab_adm.Text) + Convert.ToDecimal(ab_pr.Text)
            ab_total.Text = FormatNumber(Convert.ToDecimal(ab_total.Text), NumDigitsAfterDecimal:=2)

            '----------------- Balance Budget ---------------------
            SQLComm = New SqlCommand("select sum(Actual_Expenses) from RecruitmentBudget where Category='Recruitment' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            bal_rec.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar / 100000, NumDigitsAfterDecimal:=2))
            bal_rec.Text = Convert.ToDecimal(ab_rec.Text) - Convert.ToDecimal(bal_rec.Text)

            SQLComm = New SqlCommand("select sum(Actual_Expenses) from RecruitmentBudget where Category='People Development' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            bal_pd.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar / 100000, NumDigitsAfterDecimal:=2))
            bal_pd.Text = Convert.ToDecimal(ab_pd.Text) - Convert.ToDecimal(bal_pd.Text)

            SQLComm = New SqlCommand("select sum(Actual_Expenses) from RecruitmentBudget where Category='Employee Engagment' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            bal_ee.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar / 100000, NumDigitsAfterDecimal:=2))
            bal_ee.Text = Convert.ToDecimal(ab_ee.Text) - Convert.ToDecimal(bal_ee.Text)

            SQLComm = New SqlCommand("select sum(Actual_Expenses) from RecruitmentBudget where Category='Administration' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            bal_adm.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar / 100000, NumDigitsAfterDecimal:=2))
            bal_adm.Text = Convert.ToDecimal(ab_adm.Text) - Convert.ToDecimal(bal_adm.Text)

            SQLComm = New SqlCommand("select sum(Actual_Expenses) from RecruitmentBudget where Category='Partner Relations' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            bal_pr.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar / 100000, NumDigitsAfterDecimal:=2))
            bal_pr.Text = Convert.ToDecimal(ab_pr.Text) - Convert.ToDecimal(bal_pr.Text)

            bal_total.Text = Convert.ToDecimal(bal_rec.Text) + Convert.ToDecimal(bal_pd.Text) + Convert.ToDecimal(bal_ee.Text) + Convert.ToDecimal(bal_adm.Text) + Convert.ToDecimal(bal_pr.Text)
            bal_total.Text = FormatNumber(Convert.ToDecimal(bal_total.Text), NumDigitsAfterDecimal:=2)

            '----------------- Monthly Budget ---------------------
            rec_m_est.Text = FormatNumber((Convert.ToDecimal(ab_rec.Text) / 12), NumDigitsAfterDecimal:=2)
            pd_m_est.Text = FormatNumber((Convert.ToDecimal(ab_pd.Text) / 12), NumDigitsAfterDecimal:=2)
            ee_m_est.Text = FormatNumber((Convert.ToDecimal(ab_ee.Text) / 12), NumDigitsAfterDecimal:=2)
            adm_m_est.Text = FormatNumber((Convert.ToDecimal(ab_adm.Text) / 12), NumDigitsAfterDecimal:=2)
            pr_m_est.Text = FormatNumber((Convert.ToDecimal(ab_pr.Text) / 12), NumDigitsAfterDecimal:=2)
            total_m_est.Text = Convert.ToDecimal(rec_m_est.Text) + Convert.ToDecimal(pd_m_est.Text) + Convert.ToDecimal(ee_m_est.Text) + Convert.ToDecimal(adm_m_est.Text) + Convert.ToDecimal(pr_m_est.Text)

            '----------------- Actual Budget ---------------------
            SQLComm = New SqlCommand("select sum(Actual_Expenses) from RecruitmentBudget where Category='Recruitment' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            Dim rec_actual As Decimal = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, NumDigitsAfterDecimal:=2))

            SQLComm = New SqlCommand("select sum(Actual_Expenses) from RecruitmentBudget where Category='People Development' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            Dim pd_actual As Decimal = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, NumDigitsAfterDecimal:=2))

            SQLComm = New SqlCommand("select sum(Actual_Expenses) from RecruitmentBudget where Category='Employee Engagment' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            Dim ee_actual As Decimal = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, NumDigitsAfterDecimal:=2))

            SQLComm = New SqlCommand("select sum(Actual_Expenses) from RecruitmentBudget where Category='Administration' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            Dim adm_actual As Decimal = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, NumDigitsAfterDecimal:=2))

            SQLComm = New SqlCommand("select sum(Actual_Expenses) from RecruitmentBudget where Category='Partner Relations' and FY='" & ComboBoxFY12.Text & "'", SQLConn)
            Dim pr_actual As Decimal = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, NumDigitsAfterDecimal:=2))


            Dim totalmonth As Integer
            SQLComm = New SqlCommand("select count(distinct Month) from RecruitmentBudget where FY='" & ComboBoxFY12.Text & "'", SQLConn)
            totalmonth = SQLComm.ExecuteScalar()
            If totalmonth = 0 Then
                rec_m_actual.Text = 0.0
                pd_m_actual.Text = 0.0
                ee_m_actual.Text = 0.0
                adm_m_actual.Text = 0.0
                pr_m_actual.Text = 0.0
                total_m_actual.Text = 0.0
            Else
                rec_m_actual.Text = FormatNumber((rec_actual / totalmonth) / 100000, NumDigitsAfterDecimal:=2)
                pd_m_actual.Text = FormatNumber((pd_actual / totalmonth) / 100000, NumDigitsAfterDecimal:=2)
                ee_m_actual.Text = FormatNumber((ee_actual / totalmonth) / 100000, NumDigitsAfterDecimal:=2)
                adm_m_actual.Text = FormatNumber((adm_actual / totalmonth) / 100000, NumDigitsAfterDecimal:=2)
                pr_m_actual.Text = FormatNumber((pr_actual / totalmonth) / 100000, NumDigitsAfterDecimal:=2)
                total_m_actual.Text = Convert.ToDecimal(rec_m_actual.Text) + Convert.ToDecimal(pd_m_actual.Text) + Convert.ToDecimal(ee_m_actual.Text) + Convert.ToDecimal(adm_m_actual.Text) + Convert.ToDecimal(pr_m_actual.Text)
            End If

            '----------------- Quartly Budget ---------------------
            rec_q_est.Text = FormatNumber((Convert.ToDecimal(ab_rec.Text) / 4), NumDigitsAfterDecimal:=2)
            pd_q_est.Text = FormatNumber((Convert.ToDecimal(ab_pd.Text) / 4), NumDigitsAfterDecimal:=2)
            ee_q_est.Text = FormatNumber((Convert.ToDecimal(ab_ee.Text) / 4), NumDigitsAfterDecimal:=2)
            adm_q_est.Text = FormatNumber((Convert.ToDecimal(ab_adm.Text) / 4), NumDigitsAfterDecimal:=2)
            pr_q_est.Text = FormatNumber((Convert.ToDecimal(ab_pr.Text) / 4), NumDigitsAfterDecimal:=2)
            total_q_est.Text = Convert.ToDecimal(rec_q_est.Text) + Convert.ToDecimal(pd_q_est.Text) + Convert.ToDecimal(ee_q_est.Text) + Convert.ToDecimal(adm_q_est.Text) + Convert.ToDecimal(pr_q_est.Text)

            '----------------- Quartly Actual ---------------------
            rec_q_actual.Text = FormatNumber((rec_actual / 4) / 100000, NumDigitsAfterDecimal:=2)
            pd_q_actual.Text = FormatNumber((pd_actual / 4) / 100000, NumDigitsAfterDecimal:=2)
            ee_q_actual.Text = FormatNumber((ee_actual / 4) / 100000, NumDigitsAfterDecimal:=2)
            adm_q_actual.Text = FormatNumber((adm_actual / 4) / 100000, NumDigitsAfterDecimal:=2)
            pr_q_actual.Text = FormatNumber((pr_actual / 4) / 100000, NumDigitsAfterDecimal:=2)
            total_q_actual.Text = Convert.ToDecimal(rec_q_actual.Text) + Convert.ToDecimal(pd_q_actual.Text) + Convert.ToDecimal(ee_q_actual.Text) + Convert.ToDecimal(adm_q_actual.Text) + Convert.ToDecimal(pr_q_actual.Text)

            '----------------- YTD Budget ---------------------
            rec_ytd_est.Text = FormatNumber((Convert.ToDecimal(ab_rec.Text) / 12) * 12, NumDigitsAfterDecimal:=2)
            pd_ytd_est.Text = FormatNumber((Convert.ToDecimal(ab_pd.Text) / 12) * 12, NumDigitsAfterDecimal:=2)
            ee_ytd_est.Text = FormatNumber((Convert.ToDecimal(ab_ee.Text) / 12) * 12, NumDigitsAfterDecimal:=2)
            adm_ytd_est.Text = FormatNumber((Convert.ToDecimal(ab_adm.Text) / 12) * 12, NumDigitsAfterDecimal:=2)
            pr_ytd_est.Text = FormatNumber((Convert.ToDecimal(ab_pr.Text) / 12) * 12, NumDigitsAfterDecimal:=2)
            total_ytd_est.Text = Convert.ToDecimal(rec_ytd_est.Text) + Convert.ToDecimal(pd_ytd_est.Text) + Convert.ToDecimal(ee_ytd_est.Text) + Convert.ToDecimal(adm_ytd_est.Text) + Convert.ToDecimal(pr_ytd_est.Text)

            '----------------- YTD Actual ---------------------
            rec_ytd_actual.Text = FormatNumber(rec_actual / 100000, NumDigitsAfterDecimal:=2)
            pd_ytd_actual.Text = FormatNumber(pd_actual / 100000, NumDigitsAfterDecimal:=2)
            ee_ytd_actual.Text = FormatNumber(ee_actual / 100000, NumDigitsAfterDecimal:=2)
            adm_ytd_actual.Text = FormatNumber(adm_actual / 100000, NumDigitsAfterDecimal:=2)
            pr_ytd_actual.Text = FormatNumber(pr_actual / 100000, NumDigitsAfterDecimal:=2)
            total_ytd_actual.Text = Convert.ToDecimal(rec_ytd_actual.Text) + Convert.ToDecimal(pd_ytd_actual.Text) + Convert.ToDecimal(ee_ytd_actual.Text) + Convert.ToDecimal(adm_ytd_actual.Text) + Convert.ToDecimal(pr_ytd_actual.Text)

            '--------- Last Update date------------------------
            Dim lastupdate As New Date
            SQLComm = New SqlCommand("select max(Last_Modified) from RecruitmentBudget where FY='" & ComboBoxFY12.Text & "'", SQLConn)
            lastupdate = If(IsDBNull(SQLComm.ExecuteScalar), #1/1/1900#, SQLComm.ExecuteScalar)

            If lastupdate = #1/1/1900# Then
                Label_LastUpdate.Text = "*Last Update Not Available."
            Else
                Label_LastUpdate.Text = "*Last Update on " & Format(lastupdate, "dd-MMMM-yyyy")
            End If

            SQLConn.Dispose()
            SQLComm.Dispose()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
            SQLComm.Dispose()

        End Try

    End Sub

    Private Sub ComboBoxFY_CPH_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFY_CPH.SelectedIndexChanged
        Dim FY_Start_Year As Integer = If(ComboBoxFY_CPH.Text <> "ALL", Mid(ComboBoxFY_CPH.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY_CPH.Text <> "ALL", Mid(ComboBoxFY_CPH.Text, 3, 2) & Mid(ComboBoxFY_CPH.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        label_cph_apr.Text = "APR-" & Mid(ComboBoxFY_CPH.Text, 5, 2)
        label_cph_may.Text = "MAY-" & Mid(ComboBoxFY_CPH.Text, 5, 2)
        label_cph_jun.Text = "JUN-" & Mid(ComboBoxFY_CPH.Text, 5, 2)
        label_cph_jul.Text = "JUL-" & Mid(ComboBoxFY_CPH.Text, 5, 2)
        label_cph_aug.Text = "AUG-" & Mid(ComboBoxFY_CPH.Text, 5, 2)
        label_cph_sep.Text = "SEP-" & Mid(ComboBoxFY_CPH.Text, 5, 2)
        label_cph_oct.Text = "OCT-" & Mid(ComboBoxFY_CPH.Text, 5, 2)
        label_cph_nov.Text = "NOV-" & Mid(ComboBoxFY_CPH.Text, 5, 2)
        label_cph_dec.Text = "DEC-" & Mid(ComboBoxFY_CPH.Text, 5, 2)
        label_cph_jan.Text = "JAN-" & Mid(ComboBoxFY_CPH.Text, 8, 2)
        label_cph_feb.Text = "FEB-" & Mid(ComboBoxFY_CPH.Text, 8, 2)
        label_cph_mar.Text = "MAR-" & Mid(ComboBoxFY_CPH.Text, 8, 2)

    End Sub

    Private Sub Button_Refresh_CPH_Click(sender As Object, e As EventArgs) Handles Button_Refresh_CPH.Click
        Dim FY_Start_Year As Integer = If(ComboBoxFY_CPH.Text <> "ALL", Mid(ComboBoxFY_CPH.Text, 3, 4), Today.Year)
        Dim FY_End_Year As Integer = If(ComboBoxFY_CPH.Text <> "ALL", Mid(ComboBoxFY_CPH.Text, 3, 2) & Mid(ComboBoxFY_CPH.Text, 8, 2), Today.Year)
        Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
        Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"

        Try
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()

            '------------------------------ Recruitment figure ----------------
            SQLComm = New SqlCommand("Select Sum(Salary) from RecruiterSalary where Month='4-1-" & FY_Start_Year & "'", SQLConn)
            Label_cph_rec_apr.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0)) ' FormatNumber(SQLComm.ExecuteScalar, 0)
            SQLComm = New SqlCommand("Select Sum(Salary) from RecruiterSalary where Month='5-1-" & FY_Start_Year & "'", SQLConn)
            Label_cph_rec_may.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Salary) from RecruiterSalary where Month='6-1-" & FY_Start_Year & "'", SQLConn)
            Label_cph_rec_jun.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Salary) from RecruiterSalary where Month='7-1-" & FY_Start_Year & "'", SQLConn)
            Label_cph_rec_jul.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Salary) from RecruiterSalary where Month='8-1-" & FY_Start_Year & "'", SQLConn)
            Label_cph_rec_aug.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Salary) from RecruiterSalary where Month='9-1-" & FY_Start_Year & "'", SQLConn)
            Label_cph_rec_sep.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Salary) from RecruiterSalary where Month='10-1-" & FY_Start_Year & "'", SQLConn)
            Label_cph_rec_oct.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Salary) from RecruiterSalary where Month='11-1-" & FY_Start_Year & "'", SQLConn)
            Label_cph_rec_nov.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Salary) from RecruiterSalary where Month='12-1-" & FY_Start_Year & "'", SQLConn)
            Label_cph_rec_dec.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Salary) from RecruiterSalary where Month='1-1-" & FY_End_Year & "'", SQLConn)
            Label_cph_rec_jan.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Salary) from RecruiterSalary where Month='2-1-" & FY_End_Year & "'", SQLConn)
            Label_cph_rec_feb.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Salary) from RecruiterSalary where Month='3-1-" & FY_End_Year & "'", SQLConn)
            Label_cph_rec_mar.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))

            Label_cph_rec_ytd.Text = Int(Label_cph_rec_apr.Text) + Int(Label_cph_rec_may.Text) + Int(Label_cph_rec_jun.Text) + Int(Label_cph_rec_jul.Text) + Int(Label_cph_rec_aug.Text) + Int(Label_cph_rec_sep.Text) + Int(Label_cph_rec_oct.Text) + Int(Label_cph_rec_nov.Text) + Int(Label_cph_rec_dec.Text) + Int(Label_cph_rec_jan.Text) + Int(Label_cph_rec_feb.Text) + Int(Label_cph_rec_mar.Text)
            Label_cph_rec_ytd.Text = FormatNumber(Label_cph_rec_ytd.Text, 0)

            '------------------------------ Subscription figure ----------------
            SQLComm = New SqlCommand("Select Sum(Subscription) from RecruitmentCost where Month='4-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_sub_apr.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Subscription) from RecruitmentCost where Month='5-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_sub_may.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Subscription) from RecruitmentCost where Month='6-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_sub_jun.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Subscription) from RecruitmentCost where Month='7-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_sub_jul.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Subscription) from RecruitmentCost where Month='8-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_sub_aug.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Subscription) from RecruitmentCost where Month='9-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_sub_sep.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Subscription) from RecruitmentCost where Month='10-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_sub_oct.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Subscription) from RecruitmentCost where Month='11-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_sub_nov.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Subscription) from RecruitmentCost where Month='12-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_sub_dec.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Subscription) from RecruitmentCost where Month='1-1-" & FY_End_Year & "'", SQLConn)
            label_cph_sub_jan.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Subscription) from RecruitmentCost where Month='2-1-" & FY_End_Year & "'", SQLConn)
            label_cph_sub_feb.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Subscription) from RecruitmentCost where Month='3-1-" & FY_End_Year & "'", SQLConn)
            label_cph_sub_mar.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))

            label_cph_sub_ytd.Text = Int(label_cph_sub_apr.Text) + Int(label_cph_sub_may.Text) + Int(label_cph_sub_jun.Text) + Int(label_cph_sub_jul.Text) + Int(label_cph_sub_aug.Text) + Int(label_cph_sub_sep.Text) + Int(label_cph_sub_oct.Text) + Int(label_cph_sub_nov.Text) + Int(label_cph_sub_dec.Text) + Int(label_cph_sub_jan.Text) + Int(label_cph_sub_feb.Text) + Int(label_cph_sub_mar.Text)
            label_cph_sub_ytd.Text = FormatNumber(label_cph_sub_ytd.Text, 0)

            '------------------------------ Infrastructure figure ----------------
            SQLComm = New SqlCommand("Select Sum(Infrastructure) from RecruitmentCost where Month='4-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_inf_apr.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Infrastructure) from RecruitmentCost where Month='5-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_inf_may.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Infrastructure) from RecruitmentCost where Month='6-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_inf_jun.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Infrastructure) from RecruitmentCost where Month='7-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_inf_jul.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Infrastructure) from RecruitmentCost where Month='8-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_inf_aug.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Infrastructure) from RecruitmentCost where Month='9-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_inf_sep.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Infrastructure) from RecruitmentCost where Month='10-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_inf_oct.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Infrastructure) from RecruitmentCost where Month='11-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_inf_nov.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Infrastructure) from RecruitmentCost where Month='12-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_inf_dec.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Infrastructure) from RecruitmentCost where Month='1-1-" & FY_End_Year & "'", SQLConn)
            label_cph_inf_jan.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Infrastructure) from RecruitmentCost where Month='2-1-" & FY_End_Year & "'", SQLConn)
            label_cph_inf_feb.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Infrastructure) from RecruitmentCost where Month='3-1-" & FY_End_Year & "'", SQLConn)
            label_cph_inf_mar.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))

            label_cph_inf_ytd.Text = Int(label_cph_inf_apr.Text) + Int(label_cph_inf_may.Text) + Int(label_cph_inf_jun.Text) + Int(label_cph_inf_jul.Text) + Int(label_cph_inf_aug.Text) + Int(label_cph_inf_sep.Text) + Int(label_cph_inf_oct.Text) + Int(label_cph_inf_nov.Text) + Int(label_cph_inf_dec.Text) + Int(label_cph_inf_jan.Text) + Int(label_cph_inf_feb.Text) + Int(label_cph_inf_mar.Text)
            label_cph_inf_ytd.Text = FormatNumber(label_cph_inf_ytd.Text, 0)

            '------------------------------ Postage & Courier figure ----------------
            SQLComm = New SqlCommand("Select Sum(Postage_Courier) from RecruitmentCost where Month='4-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_pc_apr.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Postage_Courier) from RecruitmentCost where Month='5-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_pc_may.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Postage_Courier) from RecruitmentCost where Month='6-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_pc_jun.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Postage_Courier) from RecruitmentCost where Month='7-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_pc_jul.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Postage_Courier) from RecruitmentCost where Month='8-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_pc_aug.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Postage_Courier) from RecruitmentCost where Month='9-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_pc_sep.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Postage_Courier) from RecruitmentCost where Month='10-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_pc_oct.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Postage_Courier) from RecruitmentCost where Month='11-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_pc_nov.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Postage_Courier) from RecruitmentCost where Month='12-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_pc_dec.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Postage_Courier) from RecruitmentCost where Month='1-1-" & FY_End_Year & "'", SQLConn)
            label_cph_pc_jan.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Postage_Courier) from RecruitmentCost where Month='2-1-" & FY_End_Year & "'", SQLConn)
            label_cph_pc_feb.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Postage_Courier) from RecruitmentCost where Month='3-1-" & FY_End_Year & "'", SQLConn)
            label_cph_pc_mar.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))

            label_cph_pc_ytd.Text = Int(label_cph_pc_apr.Text) + Int(label_cph_pc_may.Text) + Int(label_cph_pc_jun.Text) + Int(label_cph_pc_jul.Text) + Int(label_cph_pc_aug.Text) + Int(label_cph_pc_sep.Text) + Int(label_cph_pc_oct.Text) + Int(label_cph_pc_nov.Text) + Int(label_cph_pc_dec.Text) + Int(label_cph_pc_jan.Text) + Int(label_cph_pc_feb.Text) + Int(label_cph_pc_mar.Text)
            label_cph_pc_ytd.Text = FormatNumber(label_cph_pc_ytd.Text, 0)

            '------------------------------ IT Expenses figure ----------------
            SQLComm = New SqlCommand("Select Sum(IT_Expenses) from RecruitmentCost where Month='4-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_it_apr.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(IT_Expenses) from RecruitmentCost where Month='5-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_it_may.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(IT_Expenses) from RecruitmentCost where Month='6-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_it_jun.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(IT_Expenses) from RecruitmentCost where Month='7-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_it_jul.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(IT_Expenses) from RecruitmentCost where Month='8-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_it_aug.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(IT_Expenses) from RecruitmentCost where Month='9-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_it_sep.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(IT_Expenses) from RecruitmentCost where Month='10-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_it_oct.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(IT_Expenses) from RecruitmentCost where Month='11-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_it_nov.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(IT_Expenses) from RecruitmentCost where Month='12-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_it_dec.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(IT_Expenses) from RecruitmentCost where Month='1-1-" & FY_End_Year & "'", SQLConn)
            label_cph_it_jan.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(IT_Expenses) from RecruitmentCost where Month='2-1-" & FY_End_Year & "'", SQLConn)
            label_cph_it_feb.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(IT_Expenses) from RecruitmentCost where Month='3-1-" & FY_End_Year & "'", SQLConn)
            label_cph_it_mar.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))

            label_cph_it_ytd.Text = Int(label_cph_it_apr.Text) + Int(label_cph_it_may.Text) + Int(label_cph_it_jun.Text) + Int(label_cph_it_jul.Text) + Int(label_cph_it_aug.Text) + Int(label_cph_it_sep.Text) + Int(label_cph_it_oct.Text) + Int(label_cph_it_nov.Text) + Int(label_cph_it_dec.Text) + Int(label_cph_it_jan.Text) + Int(label_cph_it_feb.Text) + Int(label_cph_it_mar.Text)
            label_cph_it_ytd.Text = FormatNumber(label_cph_it_ytd.Text, 0)

            '------------------------------ Printing and Stationery figure ----------------
            SQLComm = New SqlCommand("Select Sum(Printing_Stationery) from RecruitmentCost where Month='4-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_ps_apr.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Printing_Stationery) from RecruitmentCost where Month='5-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_ps_may.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Printing_Stationery) from RecruitmentCost where Month='6-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_ps_jun.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Printing_Stationery) from RecruitmentCost where Month='7-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_ps_jul.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Printing_Stationery) from RecruitmentCost where Month='8-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_ps_aug.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Printing_Stationery) from RecruitmentCost where Month='9-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_ps_sep.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Printing_Stationery) from RecruitmentCost where Month='10-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_ps_oct.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Printing_Stationery) from RecruitmentCost where Month='11-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_ps_nov.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Printing_Stationery) from RecruitmentCost where Month='12-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_ps_dec.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Printing_Stationery) from RecruitmentCost where Month='1-1-" & FY_End_Year & "'", SQLConn)
            label_cph_ps_jan.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Printing_Stationery) from RecruitmentCost where Month='2-1-" & FY_End_Year & "'", SQLConn)
            label_cph_ps_feb.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Printing_Stationery) from RecruitmentCost where Month='3-1-" & FY_End_Year & "'", SQLConn)
            label_cph_ps_mar.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))

            label_cph_ps_ytd.Text = Int(label_cph_ps_apr.Text) + Int(label_cph_ps_may.Text) + Int(label_cph_ps_jun.Text) + Int(label_cph_ps_jul.Text) + Int(label_cph_ps_aug.Text) + Int(label_cph_ps_sep.Text) + Int(label_cph_ps_oct.Text) + Int(label_cph_ps_nov.Text) + Int(label_cph_ps_dec.Text) + Int(label_cph_ps_jan.Text) + Int(label_cph_ps_feb.Text) + Int(label_cph_ps_mar.Text)
            label_cph_ps_ytd.Text = FormatNumber(label_cph_ps_ytd.Text, 0)

            '------------------------------ Supervison_Charges_GJ figure ----------------
            SQLComm = New SqlCommand("Select Sum(Supervison_Charges_GJ) from RecruitmentCost where Month='4-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_gj_apr.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Supervison_Charges_GJ) from RecruitmentCost where Month='5-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_gj_may.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Supervison_Charges_GJ) from RecruitmentCost where Month='6-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_gj_jun.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Supervison_Charges_GJ) from RecruitmentCost where Month='7-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_gj_jul.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Supervison_Charges_GJ) from RecruitmentCost where Month='8-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_gj_aug.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Supervison_Charges_GJ) from RecruitmentCost where Month='9-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_gj_sep.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Supervison_Charges_GJ) from RecruitmentCost where Month='10-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_gj_oct.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Supervison_Charges_GJ) from RecruitmentCost where Month='11-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_gj_nov.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Supervison_Charges_GJ) from RecruitmentCost where Month='12-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_gj_dec.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Supervison_Charges_GJ) from RecruitmentCost where Month='1-1-" & FY_End_Year & "'", SQLConn)
            label_cph_gj_jan.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Supervison_Charges_GJ) from RecruitmentCost where Month='2-1-" & FY_End_Year & "'", SQLConn)
            label_cph_gj_feb.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Supervison_Charges_GJ) from RecruitmentCost where Month='3-1-" & FY_End_Year & "'", SQLConn)
            label_cph_gj_mar.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))

            label_cph_gj_ytd.Text = Int(label_cph_gj_apr.Text) + Int(label_cph_gj_may.Text) + Int(label_cph_gj_jun.Text) + Int(label_cph_gj_jul.Text) + Int(label_cph_gj_aug.Text) + Int(label_cph_gj_sep.Text) + Int(label_cph_gj_oct.Text) + Int(label_cph_gj_nov.Text) + Int(label_cph_gj_dec.Text) + Int(label_cph_gj_jan.Text) + Int(label_cph_gj_feb.Text) + Int(label_cph_gj_mar.Text)
            label_cph_gj_ytd.Text = FormatNumber(label_cph_gj_ytd.Text, 0)


            '------------------------------ Visit Cost figure ----------------
            SQLComm = New SqlCommand("Select Sum(Visit_Cost) from RecruitmentCost where Month='4-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_vc_apr.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Visit_Cost) from RecruitmentCost where Month='5-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_vc_may.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Visit_Cost) from RecruitmentCost where Month='6-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_vc_jun.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Visit_Cost) from RecruitmentCost where Month='7-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_vc_jul.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Visit_Cost) from RecruitmentCost where Month='8-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_vc_aug.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Visit_Cost) from RecruitmentCost where Month='9-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_vc_sep.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Visit_Cost) from RecruitmentCost where Month='10-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_vc_oct.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Visit_Cost) from RecruitmentCost where Month='11-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_vc_nov.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Visit_Cost) from RecruitmentCost where Month='12-1-" & FY_Start_Year & "'", SQLConn)
            label_cph_vc_dec.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Visit_Cost) from RecruitmentCost where Month='1-1-" & FY_End_Year & "'", SQLConn)
            label_cph_vc_jan.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Visit_Cost) from RecruitmentCost where Month='2-1-" & FY_End_Year & "'", SQLConn)
            label_cph_vc_feb.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))
            SQLComm = New SqlCommand("Select Sum(Visit_Cost) from RecruitmentCost where Month='3-1-" & FY_End_Year & "'", SQLConn)
            label_cph_vc_mar.Text = If(IsDBNull(SQLComm.ExecuteScalar) = True, 0, FormatNumber(SQLComm.ExecuteScalar, 0))

            label_cph_vc_ytd.Text = Int(label_cph_vc_apr.Text) + Int(label_cph_vc_may.Text) + Int(label_cph_vc_jun.Text) + Int(label_cph_vc_jul.Text) + Int(label_cph_vc_aug.Text) + Int(label_cph_vc_sep.Text) + Int(label_cph_vc_oct.Text) + Int(label_cph_vc_nov.Text) + Int(label_cph_vc_dec.Text) + Int(label_cph_vc_jan.Text) + Int(label_cph_vc_feb.Text) + Int(label_cph_vc_mar.Text)
            label_cph_vc_ytd.Text = FormatNumber(label_cph_vc_ytd.Text, 0)


            '------------------------------ Grand Total figure ----------------

            label_cph_total_apr.Text = Int(Label_cph_rec_apr.Text) + Int(label_cph_sub_apr.Text) + Int(label_cph_inf_apr.Text) + Int(label_cph_pc_apr.Text) + Int(label_cph_it_apr.Text) + Int(label_cph_ps_apr.Text) + Int(label_cph_gj_apr.Text) + Int(label_cph_vc_apr.Text)
            label_cph_total_apr.Text = FormatNumber(label_cph_total_apr.Text, 0)
            label_cph_total_may.Text = Int(Label_cph_rec_may.Text) + Int(label_cph_sub_may.Text) + Int(label_cph_inf_may.Text) + Int(label_cph_pc_may.Text) + Int(label_cph_it_may.Text) + Int(label_cph_ps_may.Text) + Int(label_cph_gj_may.Text) + Int(label_cph_vc_may.Text)
            label_cph_total_may.Text = FormatNumber(label_cph_total_may.Text, 0)
            label_cph_total_jun.Text = Int(Label_cph_rec_jun.Text) + Int(label_cph_sub_jun.Text) + Int(label_cph_inf_jun.Text) + Int(label_cph_pc_jun.Text) + Int(label_cph_it_jun.Text) + Int(label_cph_ps_jun.Text) + Int(label_cph_gj_jun.Text) + Int(label_cph_vc_jun.Text)
            label_cph_total_jun.Text = FormatNumber(label_cph_total_jun.Text, 0)
            label_cph_total_jul.Text = Int(Label_cph_rec_jul.Text) + Int(label_cph_sub_jul.Text) + Int(label_cph_inf_jul.Text) + Int(label_cph_pc_jul.Text) + Int(label_cph_it_jul.Text) + Int(label_cph_ps_jul.Text) + Int(label_cph_gj_jul.Text) + Int(label_cph_vc_jul.Text)
            label_cph_total_jul.Text = FormatNumber(label_cph_total_jul.Text, 0)
            label_cph_total_aug.Text = Int(Label_cph_rec_aug.Text) + Int(label_cph_sub_aug.Text) + Int(label_cph_inf_aug.Text) + Int(label_cph_pc_aug.Text) + Int(label_cph_it_aug.Text) + Int(label_cph_ps_aug.Text) + Int(label_cph_gj_aug.Text) + Int(label_cph_vc_aug.Text)
            label_cph_total_aug.Text = FormatNumber(label_cph_total_aug.Text, 0)
            label_cph_total_sep.Text = Int(Label_cph_rec_sep.Text) + Int(label_cph_sub_sep.Text) + Int(label_cph_inf_sep.Text) + Int(label_cph_pc_sep.Text) + Int(label_cph_it_sep.Text) + Int(label_cph_ps_sep.Text) + Int(label_cph_gj_sep.Text) + Int(label_cph_vc_sep.Text)
            label_cph_total_sep.Text = FormatNumber(label_cph_total_sep.Text, 0)
            label_cph_total_oct.Text = Int(Label_cph_rec_oct.Text) + Int(label_cph_sub_oct.Text) + Int(label_cph_inf_oct.Text) + Int(label_cph_pc_oct.Text) + Int(label_cph_it_oct.Text) + Int(label_cph_ps_oct.Text) + Int(label_cph_gj_oct.Text) + Int(label_cph_vc_oct.Text)
            label_cph_total_oct.Text = FormatNumber(label_cph_total_oct.Text, 0)
            label_cph_total_nov.Text = Int(Label_cph_rec_nov.Text) + Int(label_cph_sub_nov.Text) + Int(label_cph_inf_nov.Text) + Int(label_cph_pc_nov.Text) + Int(label_cph_it_nov.Text) + Int(label_cph_ps_nov.Text) + Int(label_cph_gj_nov.Text) + Int(label_cph_vc_nov.Text)
            label_cph_total_nov.Text = FormatNumber(label_cph_total_nov.Text, 0)
            label_cph_total_dec.Text = Int(Label_cph_rec_dec.Text) + Int(label_cph_sub_dec.Text) + Int(label_cph_inf_dec.Text) + Int(label_cph_pc_dec.Text) + Int(label_cph_it_dec.Text) + Int(label_cph_ps_dec.Text) + Int(label_cph_gj_dec.Text) + Int(label_cph_vc_dec.Text)
            label_cph_total_dec.Text = FormatNumber(label_cph_total_dec.Text, 0)
            label_cph_total_jan.Text = Int(Label_cph_rec_jan.Text) + Int(label_cph_sub_jan.Text) + Int(label_cph_inf_jan.Text) + Int(label_cph_pc_jan.Text) + Int(label_cph_it_jan.Text) + Int(label_cph_ps_jan.Text) + Int(label_cph_gj_jan.Text) + Int(label_cph_vc_jan.Text)
            label_cph_total_jan.Text = FormatNumber(label_cph_total_jan.Text, 0)
            label_cph_total_feb.Text = Int(Label_cph_rec_feb.Text) + Int(label_cph_sub_feb.Text) + Int(label_cph_inf_feb.Text) + Int(label_cph_pc_feb.Text) + Int(label_cph_it_feb.Text) + Int(label_cph_ps_feb.Text) + Int(label_cph_gj_feb.Text) + Int(label_cph_vc_feb.Text)
            label_cph_total_feb.Text = FormatNumber(label_cph_total_feb.Text, 0)
            label_cph_total_mar.Text = Int(Label_cph_rec_mar.Text) + Int(label_cph_sub_mar.Text) + Int(label_cph_inf_mar.Text) + Int(label_cph_pc_mar.Text) + Int(label_cph_it_mar.Text) + Int(label_cph_ps_mar.Text) + Int(label_cph_gj_mar.Text) + Int(label_cph_vc_mar.Text)
            label_cph_total_mar.Text = FormatNumber(label_cph_total_mar.Text, 0)

            label_cph_total_ytd.Text = Int(Label_cph_rec_ytd.Text) + Int(label_cph_sub_ytd.Text) + Int(label_cph_inf_ytd.Text) + Int(label_cph_pc_ytd.Text) + Int(label_cph_it_ytd.Text) + Int(label_cph_ps_ytd.Text) + Int(label_cph_gj_ytd.Text) + Int(label_cph_vc_ytd.Text)
            label_cph_total_ytd.Text = FormatNumber(label_cph_total_ytd.Text, 0)

            '------------------------------ Hired ----------------
            SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='4-1-" & FY_Start_Year & "' AND Joining_Date <= '4-30-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
            label_cph_hired_apr.Text = SQLComm.ExecuteScalar
            SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='5-1-" & FY_Start_Year & "' AND Joining_Date <= '5-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
            label_cph_hired_may.Text = SQLComm.ExecuteScalar
            SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='6-1-" & FY_Start_Year & "' AND Joining_Date <= '6-30-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
            label_cph_hired_jun.Text = SQLComm.ExecuteScalar
            SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='7-1-" & FY_Start_Year & "' AND Joining_Date <= '7-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
            label_cph_hired_jul.Text = SQLComm.ExecuteScalar
            SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='8-1-" & FY_Start_Year & "' AND Joining_Date <= '8-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
            label_cph_hired_aug.Text = SQLComm.ExecuteScalar
            SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='9-1-" & FY_Start_Year & "' AND Joining_Date <= '9-30-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
            label_cph_hired_sep.Text = SQLComm.ExecuteScalar
            SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='10-1-" & FY_Start_Year & "' AND Joining_Date <= '10-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
            label_cph_hired_oct.Text = SQLComm.ExecuteScalar
            SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='11-1-" & FY_Start_Year & "' AND Joining_Date <= '11-30-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
            label_cph_hired_nov.Text = SQLComm.ExecuteScalar
            SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='12-1-" & FY_Start_Year & "' AND Joining_Date <= '12-31-" & FY_Start_Year & "') AND Joining = 'Yes'", SQLConn)
            label_cph_hired_dec.Text = SQLComm.ExecuteScalar
            SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='1-1-" & FY_End_Year & "' AND Joining_Date <= '1-31-" & FY_End_Year & "') AND Joining = 'Yes'", SQLConn)
            label_cph_hired_jan.Text = SQLComm.ExecuteScalar
            SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='2-1-" & FY_End_Year & "' AND Joining_Date <= '2-" & System.DateTime.DaysInMonth(FY_End_Year, 2) & "-" & FY_End_Year & "') AND Joining = 'Yes'", SQLConn)
            label_cph_hired_feb.Text = SQLComm.ExecuteScalar
            SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >='3-1-" & FY_End_Year & "' AND Joining_Date <= '3-31-" & FY_End_Year & "') AND Joining = 'Yes'", SQLConn)
            label_cph_hired_mar.Text = SQLComm.ExecuteScalar

            label_cph_hired_ytd.Text = Int(label_cph_hired_apr.Text) + Int(label_cph_hired_may.Text) + Int(label_cph_hired_jun.Text) + Int(label_cph_hired_jul.Text) + Int(label_cph_hired_aug.Text) + Int(label_cph_hired_sep.Text) + Int(label_cph_hired_oct.Text) + Int(label_cph_hired_nov.Text) + Int(label_cph_hired_dec.Text) + Int(label_cph_hired_jan.Text) + Int(label_cph_hired_feb.Text) + Int(label_cph_hired_mar.Text)
            label_cph_hired_ytd.Text = FormatNumber(label_cph_hired_ytd.Text, 0)


            '------------------------------ Cost per hire calculation figure ----------------

            label_cph_cph_apr.Text = If(Int(label_cph_total_apr.Text) = 0 Or Int(label_cph_hired_apr.Text) = 0, 0, FormatNumber(Int(label_cph_total_apr.Text) / Int(label_cph_hired_apr.Text), 0))
            label_cph_cph_may.Text = If(Int(label_cph_total_may.Text) = 0 Or Int(label_cph_hired_may.Text) = 0, 0, FormatNumber(Int(label_cph_total_may.Text) / Int(label_cph_hired_may.Text), 0))
            label_cph_cph_jun.Text = If(Int(label_cph_total_jun.Text) = 0 Or Int(label_cph_hired_jun.Text) = 0, 0, FormatNumber(Int(label_cph_total_jun.Text) / Int(label_cph_hired_jun.Text), 0))
            label_cph_cph_jul.Text = If(Int(label_cph_total_jul.Text) = 0 Or Int(label_cph_hired_jul.Text) = 0, 0, FormatNumber(Int(label_cph_total_jul.Text) / Int(label_cph_hired_jul.Text), 0))
            label_cph_cph_aug.Text = If(Int(label_cph_total_aug.Text) = 0 Or Int(label_cph_hired_aug.Text) = 0, 0, FormatNumber(Int(label_cph_total_aug.Text) / Int(label_cph_hired_aug.Text), 0))
            label_cph_cph_sep.Text = If(Int(label_cph_total_sep.Text) = 0 Or Int(label_cph_hired_sep.Text) = 0, 0, FormatNumber(Int(label_cph_total_sep.Text) / Int(label_cph_hired_sep.Text), 0))
            label_cph_cph_oct.Text = If(Int(label_cph_total_oct.Text) = 0 Or Int(label_cph_hired_oct.Text) = 0, 0, FormatNumber(Int(label_cph_total_oct.Text) / Int(label_cph_hired_oct.Text), 0))
            label_cph_cph_nov.Text = If(Int(label_cph_total_nov.Text) = 0 Or Int(label_cph_hired_nov.Text) = 0, 0, FormatNumber(Int(label_cph_total_nov.Text) / Int(label_cph_hired_nov.Text), 0))
            label_cph_cph_dec.Text = If(Int(label_cph_total_dec.Text) = 0 Or Int(label_cph_hired_dec.Text) = 0, 0, FormatNumber(Int(label_cph_total_nov.Text) / Int(label_cph_hired_nov.Text), 0))
            label_cph_cph_jan.Text = If(Int(label_cph_total_jan.Text) = 0 Or Int(label_cph_hired_jan.Text) = 0, 0, FormatNumber(Int(label_cph_total_jan.Text) / Int(label_cph_hired_jan.Text), 0))
            label_cph_cph_feb.Text = If(Int(label_cph_total_feb.Text) = 0 Or Int(label_cph_hired_feb.Text) = 0, 0, FormatNumber(Int(label_cph_total_feb.Text) / Int(label_cph_hired_feb.Text), 0))
            label_cph_cph_mar.Text = If(Int(label_cph_total_mar.Text) = 0 Or Int(label_cph_hired_mar.Text) = 0, 0, FormatNumber(Int(label_cph_total_mar.Text) / Int(label_cph_hired_mar.Text), 0))

            label_cph_cph_ytd.Text = Int(Label_cph_rec_ytd.Text) + Int(label_cph_sub_ytd.Text) + Int(label_cph_inf_ytd.Text) + Int(label_cph_pc_ytd.Text) + Int(label_cph_it_ytd.Text) + Int(label_cph_ps_ytd.Text) + Int(label_cph_gj_ytd.Text) + Int(label_cph_vc_ytd.Text)
            label_cph_cph_ytd.Text = If(Int(label_cph_total_ytd.Text) = 0 Or Int(label_cph_hired_ytd.Text) = 0, 0, FormatNumber(Int(label_cph_total_ytd.Text) / Int(label_cph_hired_ytd.Text), 0))


            SQLComm.Dispose()
            SQLConn.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLComm.Dispose()
            SQLConn.Dispose()
        End Try
    End Sub

End Class