Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class FormTop
    Dim SQLConn As New SqlConnection
    Dim SQLComm As New SqlCommand
    Dim ConnStr As String = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString

    Private Sub ComboBoxAppDetailsRecruiter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAppDetailsRecruiter.SelectedIndexChanged

        Try

            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()

            Dim FY_Start_Year As Integer = If(ComboBoxFY.Text <> "ALL", Mid(ComboBoxFY.Text, 3, 4), Today.Year)
            Dim FY_End_Year As Integer = If(ComboBoxFY.Text <> "ALL", Mid(ComboBoxFY.Text, 3, 2) & Mid(ComboBoxFY.Text, 8, 2), Today.Year)
            Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
            Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"


            '--------------------Open Position Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "" Then
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'OPEN'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'OPEN'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable WHERE  Recruiter = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Job_Status = 'OPEN'", SQLConn)
            End If
            openCount.Text = SQLComm.ExecuteScalar

            '--------------------Screening Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Screening = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Screening = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Screening = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Screening = 'Yes'", SQLConn)
            End If

            screeningCount.Text = SQLComm.ExecuteScalar


            '--------------------Shared Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Shared = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Shared = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Shared = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Shared = 'Yes'", SQLConn)
            End If

            sharedCount.Text = SQLComm.ExecuteScalar


            '--------------------Approved Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Interview = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Interview = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Interview = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Interview = 'Yes'", SQLConn)
            End If

            approvedCount.Text = SQLComm.ExecuteScalar


            '--------------------Invited Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Invited = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Invited = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Invited_Date >=" & FY_Start_Date & " AND Invited_Date <= " & FY_End_Date & ") AND Invited = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Invited_Date >=" & FY_Start_Date & " AND Invited_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Invited = 'Yes'", SQLConn)
            End If

            invitedCount.Text = SQLComm.ExecuteScalar

            '--------------------Visited Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Visited = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Visited = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Visited_Date >=" & FY_Start_Date & " AND Visited_Date <= " & FY_End_Date & ") AND Visited = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Visited_Date >=" & FY_Start_Date & " AND Visited_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Visited = 'Yes'", SQLConn)
            End If

            visitedCount.Text = SQLComm.ExecuteScalar

            '--------------------Offered Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer = 'Yes'", SQLConn)
            End If

            offeredCount.Text = SQLComm.ExecuteScalar


            '--------------------Offer accepted Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Accepted = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer_Accepted = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer_Accepted = 'Yes'", SQLConn)
            End If

            offeracceptedCount.Text = SQLComm.ExecuteScalar


            '--------------------Offer declined Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Status = 'Declined'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer_Status = 'Declined'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer_Status = 'Declined'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer_Status = 'Declined'", SQLConn)
            End If

            offerdeclinedCount.Text = SQLComm.ExecuteScalar

            '--------------------join Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Joining = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Joining = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Joining = 'Yes'", SQLConn)
            End If

            joinedCount.Text = SQLComm.ExecuteScalar

            '--------------------To join Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Application_Status = 'TO JOIN'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Application_Status = 'TO JOIN'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Application_Status = 'TO JOIN'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Application_Status = 'TO JOIN'", SQLConn)
            End If

            tojoinCount.Text = SQLComm.ExecuteScalar

            '-------------------- Avg Time to Join -------------------------------------------------------------------------------------

            SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'JOINED' AND Recruiter = " & "'" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            Dim chk As Integer
            chk = SQLComm.ExecuteScalar
            SQLComm.Parameters.Clear()

            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Recruiter = " & "'" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Recruiter = " & "'" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            End If

            If Not IsNumeric(SQLComm.ExecuteScalar) Then
                countAvg.Text = "0.00 Days"
            Else
                countAvg.Text = Format(SQLComm.ExecuteScalar, "0.00") & " Days"
            End If


            '--------------------Offer To join Ratio -------------------------------------------------------------------------------------
            If joinedCount.Text = 0 Or offeredCount.Text = 0 Then
                offertojoin.Text = "0.00%"
            Else
                offertojoin.Text = FormatPercent(joinedCount.Text / offeredCount.Text, NumDigitsAfterDecimal:=2)
            End If


            '--------------------------- Populate List of Candidates according to selected recruiter --------------------------------------------
            Dim ds1 As New DataSet
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ")", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Recruiter_Name = '" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            End If

            Dim DA1 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA1.Fill(ds1)
            FormProcess.DataGridView1.DataSource = ds1.Tables(0)
            FormProcess.DataGridView1.DataBindings.Clear()
            SQLComm.Parameters.Clear()
            ConnStr = Nothing
            FormProcess.Label_Found.Text = FormProcess.DataGridView1.RowCount
            FormProcess.DataGridView1.Sort(FormProcess.DataGridView1.Columns(FormProcess.DataGridView1.ColumnCount - 1), direction:=ListSortDirection.Descending)
            DA1.Dispose()
            SQLConn.Dispose()
            SQLComm.Dispose()
            '------------------------------------------------------------------------------------------------------------------------------------

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLComm.Dispose()
            SQLConn.Dispose()
        End Try

    End Sub

    Private Sub ButtonTopCountRefresh_Click(sender As Object, e As EventArgs) Handles ButtonTopCountRefresh.Click
        Try

            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()

            Dim FY_Start_Year As Integer = If(ComboBoxFY.Text <> "ALL", Mid(ComboBoxFY.Text, 3, 4), Today.Year)
            Dim FY_End_Year As Integer = If(ComboBoxFY.Text <> "ALL", Mid(ComboBoxFY.Text, 3, 2) & Mid(ComboBoxFY.Text, 8, 2), Today.Year)
            Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
            Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"


            '--------------------Open Position Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "" Then
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'OPEN'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'OPEN'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable WHERE  Recruiter = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Job_Status = 'OPEN'", SQLConn)
            End If
            openCount.Text = SQLComm.ExecuteScalar

            '--------------------Screening Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Screening = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Screening = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Screening = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Screening = 'Yes'", SQLConn)
            End If

            screeningCount.Text = SQLComm.ExecuteScalar


            '--------------------Shared Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Shared = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Shared = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Shared = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Shared = 'Yes'", SQLConn)
            End If

            sharedCount.Text = SQLComm.ExecuteScalar


            '--------------------Approved Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Interview = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Interview = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Interview = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Interview = 'Yes'", SQLConn)
            End If

            approvedCount.Text = SQLComm.ExecuteScalar


            '--------------------Invited Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Invited = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Invited = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Invited_Date >=" & FY_Start_Date & " AND Invited_Date <= " & FY_End_Date & ") AND Invited = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Invited_Date >=" & FY_Start_Date & " AND Invited_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Invited = 'Yes'", SQLConn)
            End If

            invitedCount.Text = SQLComm.ExecuteScalar

            '--------------------Visited Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Visited = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Visited = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Visited_Date >=" & FY_Start_Date & " AND Visited_Date <= " & FY_End_Date & ") AND Visited = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Visited_Date >=" & FY_Start_Date & " AND Visited_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Visited = 'Yes'", SQLConn)
            End If

            visitedCount.Text = SQLComm.ExecuteScalar

            '--------------------Offered Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer = 'Yes'", SQLConn)
            End If

            offeredCount.Text = SQLComm.ExecuteScalar


            '--------------------Offer accepted Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Accepted = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer_Accepted = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer_Accepted = 'Yes'", SQLConn)
            End If

            offeracceptedCount.Text = SQLComm.ExecuteScalar


            '--------------------Offer declined Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Status = 'Declined'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer_Status = 'Declined'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer_Status = 'Declined'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer_Status = 'Declined'", SQLConn)
            End If

            offerdeclinedCount.Text = SQLComm.ExecuteScalar

            '--------------------join Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Joining = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Joining = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Joining = 'Yes'", SQLConn)
            End If

            joinedCount.Text = SQLComm.ExecuteScalar

            '--------------------To join Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Application_Status = 'TO JOIN'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Application_Status = 'TO JOIN'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Application_Status = 'TO JOIN'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Application_Status = 'TO JOIN'", SQLConn)
            End If

            tojoinCount.Text = SQLComm.ExecuteScalar

            '-------------------- Avg Time to Join -------------------------------------------------------------------------------------

            SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'JOINED' AND Recruiter = " & "'" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            Dim chk As Integer
            chk = SQLComm.ExecuteScalar
            SQLComm.Parameters.Clear()

            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Recruiter = " & "'" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Recruiter = " & "'" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            End If

            If Not IsNumeric(SQLComm.ExecuteScalar) Then
                countAvg.Text = "0.00 Days"
            Else
                countAvg.Text = Format(SQLComm.ExecuteScalar, "0.00") & " Days"
            End If


            '--------------------Offer To join Ratio -------------------------------------------------------------------------------------
            If joinedCount.Text = 0 Or offeredCount.Text = 0 Then
                offertojoin.Text = "0.00%"
            Else
                offertojoin.Text = FormatPercent(joinedCount.Text / offeredCount.Text, NumDigitsAfterDecimal:=2)
            End If


            '--------------------------- Populate List of Candidates according to selected recruiter --------------------------------------------
            'Dim ds1 As New DataSet
            'If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
            '    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
            'ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
            '    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            'ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
            '    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ")", SQLConn)
            'Else
            '    SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Recruiter_Name = '" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            'End If

            'Dim DA1 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            'DA1.Fill(ds1)
            'FormProcess.DataGridView1.DataSource = ds1.Tables(0)
            'FormProcess.DataGridView1.DataBindings.Clear()
            'SQLComm.Parameters.Clear()
            'ConnStr = Nothing
            'FormProcess.Label_Found.Text = FormProcess.DataGridView1.RowCount
            'FormProcess.DataGridView1.Sort(FormProcess.DataGridView1.Columns(FormProcess.DataGridView1.ColumnCount - 1), direction:=ListSortDirection.Descending)
            'DA1.Dispose()
            SQLConn.Dispose()
            SQLComm.Dispose()
            '------------------------------------------------------------------------------------------------------------------------------------

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLComm.Dispose()
            SQLConn.Dispose()
        End Try

    End Sub

    Private Sub FormTop_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim DR As SqlDataReader
            Dim ConnStr As String
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            ConnStr = SQLConn.ConnectionString
            SQLComm.Connection = SQLConn
            SQLConn.Open()

            '------- Add List Item in Recruiter 
            SQLComm = New SqlCommand("SELECT RecruiterName FROM Recruiter", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            Me.ComboBoxAppDetailsRecruiter.Items.Add("ALL")
            If DR.HasRows = True Then
                While DR.Read()
                    Me.ComboBoxAppDetailsRecruiter.Items.Add(DR("RecruiterName"))
                End While
            End If
            SQLComm.ResetCommandTimeout()
            DR.Close()
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
            SQLComm = New SqlCommand("SELECT FY_Name FROM FY Where SetCurrent = 'Yes'", SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DT As New DataTable
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DT)
            ComboBoxFY.DataBindings.Add("Text", DT, "FY_Name")
            SQLConn.Close()
            SQLConn.Dispose()
            ComboBoxFY.DataBindings.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
            SQLConn.Dispose()
        End Try

        '--------------------------------------- Calculate Count on Top Pannel  ---------------------

        ComboBoxAppDetailsRecruiter.SelectedIndex = 0
        'ComboBoxFY.SelectedIndex = 0

        Try

            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()

            Dim FY_Start_Year As Integer = If(ComboBoxFY.Text <> "ALL", Mid(ComboBoxFY.Text, 3, 4), Today.Year)
            Dim FY_End_Year As Integer = If(ComboBoxFY.Text <> "ALL", Mid(ComboBoxFY.Text, 3, 2) & Mid(ComboBoxFY.Text, 8, 2), Today.Year)
            Dim FY_Start_Date As String = "'4-1-" & FY_Start_Year & "'"
            Dim FY_End_Date As String = "'3-31-" & FY_End_Year & "'"


            '--------------------Open Position Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "" Then
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'OPEN'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'OPEN'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM JobTable WHERE  Recruiter = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Job_Status = 'OPEN'", SQLConn)
            End If
            openCount.Text = SQLComm.ExecuteScalar

            '--------------------Screening Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Screening = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Screening = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Screening = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Screening_Date >=" & FY_Start_Date & " AND Screening_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Screening = 'Yes'", SQLConn)
            End If

            screeningCount.Text = SQLComm.ExecuteScalar


            '--------------------Shared Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Shared = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Shared = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Shared = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Shared_Date >=" & FY_Start_Date & " AND Shared_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Shared = 'Yes'", SQLConn)
            End If

            sharedCount.Text = SQLComm.ExecuteScalar


            '--------------------Approved Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Interview = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Interview = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Interview = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Interview_Date >=" & FY_Start_Date & " AND Interview_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Interview = 'Yes'", SQLConn)
            End If

            approvedCount.Text = SQLComm.ExecuteScalar


            '--------------------Invited Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Invited = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Invited = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Invited_Date >=" & FY_Start_Date & " AND Invited_Date <= " & FY_End_Date & ") AND Invited = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Invited_Date >=" & FY_Start_Date & " AND Invited_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Invited = 'Yes'", SQLConn)
            End If

            invitedCount.Text = SQLComm.ExecuteScalar

            '--------------------Visited Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Visited = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Visited = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Visited_Date >=" & FY_Start_Date & " AND Visited_Date <= " & FY_End_Date & ") AND Visited = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Visited_Date >=" & FY_Start_Date & " AND Visited_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Visited = 'Yes'", SQLConn)
            End If

            visitedCount.Text = SQLComm.ExecuteScalar

            '--------------------Offered Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer = 'Yes'", SQLConn)
            End If

            offeredCount.Text = SQLComm.ExecuteScalar


            '--------------------Offer accepted Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Accepted = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer_Accepted = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Offer_Accepted = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Accepted_Date >=" & FY_Start_Date & " AND Offer_Accepted_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer_Accepted = 'Yes'", SQLConn)
            End If

            offeracceptedCount.Text = SQLComm.ExecuteScalar


            '--------------------Offer declined Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Offer_Status = 'Declined'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer_Status = 'Declined'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Offer_Status = 'Declined'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Offer_Date >=" & FY_Start_Date & " AND Offer_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Offer_Status = 'Declined'", SQLConn)
            End If

            offerdeclinedCount.Text = SQLComm.ExecuteScalar

            '--------------------join Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Joining = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Joining = 'Yes'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Joining = 'Yes'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Joining = 'Yes'", SQLConn)
            End If

            joinedCount.Text = SQLComm.ExecuteScalar

            '--------------------To join Count -------------------------------------------------------------------------------------
            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where Application_Status = 'TO JOIN'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE  Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Application_Status = 'TO JOIN'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Application_Status = 'TO JOIN'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select Count(*) FROM ApplicationTable WHERE (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Recruiter_Name = " & "'" & ComboBoxAppDetailsRecruiter.Text & "' and Application_Status = 'TO JOIN'", SQLConn)
            End If

            tojoinCount.Text = SQLComm.ExecuteScalar

            '-------------------- Avg Time to Join -------------------------------------------------------------------------------------

            SQLComm = New SqlCommand("Select Count(*) FROM JobTable Where Job_Status = 'JOINED' AND Recruiter = " & "'" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            Dim chk As Integer
            chk = SQLComm.ExecuteScalar
            SQLComm.Parameters.Clear()

            If ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text <> "ALL" And ComboBoxFY.Text = "ALL" Then
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where Job_Status = 'JOINED' AND Recruiter = " & "'" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            ElseIf ComboBoxAppDetailsRecruiter.Text = "ALL" And ComboBoxFY.Text <> "ALL" Then
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED'", SQLConn)
            Else
                SQLComm = New SqlCommand("Select AVG(Elapsed_Time) FROM JobTable Where (Joining_Date >=" & FY_Start_Date & " AND Joining_Date <= " & FY_End_Date & ") AND Job_Status = 'JOINED' AND Recruiter = " & "'" & ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            End If

            If Not IsNumeric(SQLComm.ExecuteScalar) Then
                countAvg.Text = "0.00 Days"
            Else
                countAvg.Text = Format(SQLComm.ExecuteScalar, "0.00") & " Days"
            End If


            '--------------------Offer To join Ratio -------------------------------------------------------------------------------------
            If joinedCount.Text = 0 Or offeredCount.Text = 0 Then
                offertojoin.Text = "0.00%"
            Else
                offertojoin.Text = FormatPercent(joinedCount.Text / offeredCount.Text, NumDigitsAfterDecimal:=2)
            End If

            SQLConn.Dispose()
            SQLComm.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLComm.Dispose()
            SQLConn.Dispose()
        End Try

        '--------------------------------------------------------------------------------------------

    End Sub



    Private Sub ComboBoxFY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFY.SelectedIndexChanged
        ComboBoxAppDetailsRecruiter.SelectedIndex = -1
        ComboBoxAppDetailsRecruiter.Focus()
    End Sub
End Class