Imports System.ComponentModel

Public Class FormProcess
    Dim SQLConn As New SqlConnection
    Dim SQLComm As New SqlCommand
    Dim ConnStr As String

    Private Sub ButtonProcessClose_Click(sender As Object, e As EventArgs) Handles ButtonProcessClose.Click
        Me.Close()
        FormMain.btn_process.BackColor = Color.Honeydew
    End Sub

    Private Sub FormProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DS_ApplicationTable_SQL.ApplicationTable' table. You can move, or remove it, as needed.
        'Me.ApplicationTableTableAdapter.Fill(Me.DS_ApplicationTable_SQL.ApplicationTable)


        Try
            'TODO: This line of code loads data into the 'DataSetSearchCandidate.ApplicationTable' table. You can move, or remove it, as needed.
            'Me.ApplicationTableTableAdapter.Fill(Me.DataSetSearchCandidate.ApplicationTable)
            'Label_Found.Text = DataGridView1.RowCount

            '-------------------------------------------------------------------------------------
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
                    Me.ComboBoxPJobID.Items.Add(DR("Job_ID"))
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
                    Me.ComboBoxCRecruiter.Items.Add(DR("RecruiterName"))
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
                    Me.ComboBoxPResumeSource.Items.Add(DR("Resume_Source"))
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
                    Me.ComboBoxPLocation.Items.Add(DR("CityName"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()

            '------- Add List Item in Rejected By
            SQLComm = New SqlCommand("Select Rejected_By from RejectedBy", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader
            If DR.HasRows = True Then
                While DR.Read
                    Me.ComboBoxRejectedBy.Items.Add(DR("Rejected_By"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()

            '------- Add List Item in Reason for Reject
            SQLComm = New SqlCommand("Select Decline_Reason from DeclineReason", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader
            If DR.HasRows = True Then
                While DR.Read
                    Me.ComboBoxReason.Items.Add(DR("Decline_Reason"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()

            '------- Add List Item in Notice Period
            SQLComm = New SqlCommand("Select Notice_Period from Notice", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader
            If DR.HasRows = True Then
                While DR.Read
                    Me.ComboBoxNoticePeriod.Items.Add(DR("Notice_Period"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()

            '------- Add List Item in Next_Steps
            SQLComm = New SqlCommand("SELECT Distinct Next_Steps FROM nextsteps", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            If DR.HasRows = True Then
                While DR.Read()
                    Me.ComboBoxNextSteps.Items.Add(DR("Next_Steps"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()
            SQLConn.Dispose()
            '--------------------------- Populate List of Candidates according to selected recruiter --------------------------------------------
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()
            Dim ds1 As New DataSet
            If FormTop.ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                SQLComm = New SqlCommand("SELECT * FROM ApplicationTable", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM ApplicationTable WHERE Recruiter_Name = '" & FormTop.ComboBoxAppDetailsRecruiter.Text & "'", SQLConn)
            End If
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

            SQLConn.Close()


            '-------------- Clear DateTimePicker ------------------------------
            DateTimePickerShare.Checked = False
            DateTimePickerInterview.Checked = False
            DateTimePickerOffer.Checked = False
            DateTimePickerOfferAccept.Checked = False
            DateTimePickerJoining.Checked = False
            DateTimePickerInvite.Checked = False
            DateTimePickerVisit.Checked = False

            DateTimePickerPScreeningDate.CustomFormat = " "
            DateTimePickerShare.CustomFormat = " "
            DateTimePickerInterview.CustomFormat = " "
            DateTimePickerOffer.CustomFormat = " "
            DateTimePickerOfferAccept.CustomFormat = " "
            DateTimePickerJoining.CustomFormat = " "
            DateTimePickerInvite.CustomFormat = " "
            DateTimePickerVisit.CustomFormat = " "

            '------------------------------------------------------------------
            DataGridView1.Sort(DataGridView1.Columns(DataGridView1.ColumnCount - 1), direction:=ListSortDirection.Descending)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub



    Private Sub ComboBoxAppID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAppID.SelectedIndexChanged
        'Private Sub ComboBoxAppID_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAppID.SelectedValueChanged

        '---------------------------- Clear All Dates field ----------------------------------------------
        Try

            TextBoxPApplicationStatus.Text = ""
            ComboBoxChangeStatus.Text = ""
            SameJobYes.Checked = True
            SameJobNo.Checked = False
            DateTimePickerPScreeningDate.Value = #1/1/1900#
            ComboBoxReason.DropDownStyle = ComboBoxStyle.DropDown
            ComboBoxPResumeSource.Text = ""
            ComboBoxPLocation.Text = ""
            TextBoxCurrentCTC.Text = ""
            TextBoxAcceptedCTC.Text = ""
            TextBoxPExperience.Text = ""
            TextBoxPCandidateName.Text = ""
            TextBoxPEmail.Text = ""
            TextBoxPMobile.Text = ""
            ComboBoxCRecruiter.SelectedIndex = -1
            ComboBoxRejectedBy.Text = ""
            ComboBoxRejectedBy.SelectedIndex = -1
            ComboBoxReason.Text = ""
            ComboBoxReason.SelectedIndex = -1
            DateTimePickerShare.Value = #1/1/1900#
            txtSD.Text = ""
            DateTimePickerInterview.Value = #1/1/1900#
            txtID.Text = ""
            DateTimePickerOffer.Value = #1/1/1900#
            txtOD.Text = ""
            ComboBoxOfferStatus.Text = "NA"
            DateTimePickerOfferAccept.Value = #1/1/1900#
            txtOAD.Text = ""
            DateTimePickerJoining.Value = #1/1/1900#
            txtJD.Text = ""
            DateTimePickerInvite.Value = #1/1/1900#
            txtInD.Text = ""
            DateTimePickerVisit.Value = #1/1/1900#
            txtVD.Text = ""
            ComboBoxInviteGoa.Text = "No"
            ComboBoxVisited.Text = "No"
            TextBoxVisitCost.Text = "0"
            TextBoxComments.Text = ""
            ComboBoxNextSteps.SelectedIndex = -1
            ComboBoxNoticePeriod.SelectedIndex = -1



            '------------------------------------------------------------------------------------------------------------------------------------
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

            TextBoxPApplicationStatus.DataBindings.Add("Text", DT, "Application_Status")
            'DateTimePickerPScreeningDate.CustomFormat = "dd-MMM-yyyy"
            DateTimePickerPScreeningDate.DataBindings.Add("Value", DT, "Screening_Date")
            ComboBoxPResumeSource.DataBindings.Add("Text", DT, "Resume_Source")
            ComboBoxPLocation.DataBindings.Add("Text", DT, "Location")
            TextBoxCurrentCTC.DataBindings.Add("Text", DT, "Current_CTC")
            TextBoxAcceptedCTC.DataBindings.Add("Text", DT, "Accepted_CTC")
            TextBoxPExperience.DataBindings.Add("Text", DT, "Experience")
            TextBoxPCandidateName.DataBindings.Add("Text", DT, "Candidate_Name")
            ComboBoxCRecruiter.DataBindings.Add("Text", DT, "Recruiter_Name")
            TextBoxPEmail.DataBindings.Add("Text", DT, "E_Mail")
            TextBoxPMobile.DataBindings.Add("Text", DT, "Phone")
            ComboBoxRejectedBy.DataBindings.Add("Text", DT, "Rejected_By")
            ComboBoxReason.DataBindings.Add("Text", DT, "Decline_Reason")
            TextBoxComments.DataBindings.Add("Text", DT, "Comments")
            'DateTimePickerShare.CustomFormat = "dd-MMM-yyyy"
            DateTimePickerShare.DataBindings.Add("Value", DT, "Shared_Date")
            'DateTimePickerInterview.CustomFormat = "dd-MMM-yyyy"
            DateTimePickerInterview.DataBindings.Add("Value", DT, "Interview_Date")
            'DateTimePickerOffer.CustomFormat = "dd-MMM-yyyy"
            DateTimePickerOffer.DataBindings.Add("Value", DT, "Offer_Date")
            ComboBoxOfferStatus.DataBindings.Add("Text", DT, "Offer_Status")
            'DateTimePickerOfferAccept.CustomFormat = "dd-MMM-yyyy"
            DateTimePickerOfferAccept.DataBindings.Add("Value", DT, "Offer_Accepted_Date")
            'DateTimePickerJoining.CustomFormat = "dd-MMM-yyyy"
            DateTimePickerJoining.DataBindings.Add("Value", DT, "Joining_Date")
            ComboBoxInviteGoa.DataBindings.Add("Text", DT, "Invited")
            'DateTimePickerInvite.CustomFormat = "dd-MMM-yyyy"
            DateTimePickerInvite.DataBindings.Add("Value", DT, "Invited_Date")
            ComboBoxVisited.DataBindings.Add("Text", DT, "Visited")
            'DateTimePickerVisit.CustomFormat = "dd-MMM-yyyy"
            DateTimePickerVisit.DataBindings.Add("Value", DT, "Visited_Date")
            TextBoxVisitCost.DataBindings.Add("Text", DT, "Visit_Cost")
            ComboBoxNextSteps.DataBindings.Add("Text", DT, "Next_Steps")
            ComboBoxNoticePeriod.DataBindings.Add("Text", DT, "Notice_Period")

            SQLConn.Close()
            SQLConn.Dispose()
            '--------------Clear Data Binding -------------------------------------
            TextBoxPApplicationStatus.DataBindings.Clear()
            ComboBoxChangeStatus.DataBindings.Clear()
            SameJobYes.DataBindings.Clear()
            SameJobNo.DataBindings.Clear()
            DateTimePickerPScreeningDate.DataBindings.Clear()
            ComboBoxPResumeSource.DataBindings.Clear()
            ComboBoxPLocation.DataBindings.Clear()
            TextBoxCurrentCTC.DataBindings.Clear()
            TextBoxAcceptedCTC.DataBindings.Clear()
            TextBoxPExperience.DataBindings.Clear()
            TextBoxPCandidateName.DataBindings.Clear()
            TextBoxPEmail.DataBindings.Clear()
            TextBoxPMobile.DataBindings.Clear()
            ComboBoxCRecruiter.DataBindings.Clear()
            ComboBoxRejectedBy.DataBindings.Clear()
            ComboBoxReason.DataBindings.Clear()
            DateTimePickerShare.DataBindings.Clear()
            txtSD.DataBindings.Clear()
            DateTimePickerInterview.DataBindings.Clear()
            txtID.DataBindings.Clear()
            DateTimePickerOffer.DataBindings.Clear()
            txtOD.DataBindings.Clear()
            ComboBoxOfferStatus.DataBindings.Clear()
            DateTimePickerOfferAccept.DataBindings.Clear()
            txtOAD.DataBindings.Clear()
            DateTimePickerJoining.DataBindings.Clear()
            txtJD.DataBindings.Clear()
            DateTimePickerInvite.DataBindings.Clear()
            txtInD.DataBindings.Clear()
            DateTimePickerVisit.DataBindings.Clear()
            txtVD.DataBindings.Clear()
            ComboBoxInviteGoa.DataBindings.Clear()
            ComboBoxVisited.DataBindings.Clear()
            TextBoxVisitCost.DataBindings.Clear()
            TextBoxComments.DataBindings.Clear()
            ComboBoxNextSteps.DataBindings.Clear()
            ComboBoxNoticePeriod.DataBindings.Clear()

            '------------------------------------------------------------------------------------------------


            '---------------------------Status Drop Down Item-------------------------------------------

            If TextBoxPApplicationStatus.Text = "SCREENED" Or TextBoxPApplicationStatus.Text = "Screened" Then
                ComboBoxChangeStatus.Enabled = True
                ComboBoxChangeStatus.Items.Clear()
                ComboBoxChangeStatus.Items.Add("SCREENED")
                ComboBoxChangeStatus.Items.Add("SHARED")
                ComboBoxChangeStatus.Items.Add("APPROVED")
                ComboBoxChangeStatus.Items.Add("OFFERED")
                ComboBoxChangeStatus.Items.Add("REJECT")

            ElseIf TextBoxPApplicationStatus.Text = "SHARED" Or TextBoxPApplicationStatus.Text = "Shared" Then
                ComboBoxChangeStatus.Enabled = True
                ComboBoxChangeStatus.Items.Clear()
                ComboBoxChangeStatus.Items.Add("SHARED")
                ComboBoxChangeStatus.Items.Add("APPROVED")
                ComboBoxChangeStatus.Items.Add("OFFERED")
                ComboBoxChangeStatus.Items.Add("REJECT")
            ElseIf TextBoxPApplicationStatus.Text = "APPROVED" Or TextBoxPApplicationStatus.Text = "Approved" Then
                ComboBoxChangeStatus.Enabled = True
                ComboBoxChangeStatus.Items.Clear()
                ComboBoxChangeStatus.Items.Add("APPROVED")
                ComboBoxChangeStatus.Items.Add("OFFERED")
                ComboBoxChangeStatus.Items.Add("REJECT")
            ElseIf TextBoxPApplicationStatus.Text = "OFFERED" Or TextBoxPApplicationStatus.Text = "Offered" Then
                ComboBoxChangeStatus.Enabled = True
                ComboBoxChangeStatus.Items.Clear()
                ComboBoxChangeStatus.Items.Add("OFFERED")
                ComboBoxChangeStatus.Items.Add("OFFER DECLINED")
                ComboBoxChangeStatus.Items.Add("TO JOIN")
                ComboBoxChangeStatus.Items.Add("JOINED")

            ElseIf TextBoxPApplicationStatus.Text = "OFFER DECLINED" Or TextBoxPApplicationStatus.Text = "Offer Declined" Then
                ComboBoxChangeStatus.Enabled = True
                ComboBoxChangeStatus.Items.Clear()
                ComboBoxChangeStatus.Items.Add("OFFERED")
                ComboBoxChangeStatus.Items.Add("OFFER DECLINED")
                ComboBoxChangeStatus.Items.Add("TO JOIN")
                ComboBoxChangeStatus.Items.Add("JOINED")

            ElseIf TextBoxPApplicationStatus.Text = "TO JOIN" Or TextBoxPApplicationStatus.Text = "To Join" Then
                ComboBoxChangeStatus.Enabled = True
                ComboBoxChangeStatus.Items.Clear()
                ComboBoxChangeStatus.Items.Add("OFFERED")
                ComboBoxChangeStatus.Items.Add("TO JOIN")
                ComboBoxChangeStatus.Items.Add("JOINED")
                ComboBoxChangeStatus.Items.Add("OFFER DECLINED")

            ElseIf TextBoxPApplicationStatus.Text = "JOINED" Or TextBoxPApplicationStatus.Text = "Joined" Then
                ComboBoxChangeStatus.Enabled = True
                ComboBoxChangeStatus.Items.Clear()
                ComboBoxChangeStatus.Items.Add("JOINED")
                ComboBoxChangeStatus.Items.Add("TO JOIN")
                ComboBoxChangeStatus.Items.Add("OFFER DECLINED")
            ElseIf TextBoxPApplicationStatus.Text = "REJECT" Or TextBoxPApplicationStatus.Text = "Reject" Then
                ComboBoxChangeStatus.Items.Clear()
                ComboBoxChangeStatus.Items.Add("SHARED")
                ComboBoxChangeStatus.Items.Add("APPROVED")
                ComboBoxChangeStatus.Items.Add("OFFERED")
                ComboBoxChangeStatus.Items.Add("REJECT")
            Else
                ComboBoxChangeStatus.Enabled = True
                ComboBoxChangeStatus.Items.Clear()
                ComboBoxChangeStatus.Items.Add("REJECT")
            End If


            '--------------------------- Field Enable Desable -----------------------------------------------------------

            If TextBoxPApplicationStatus.Text = "SCREENED" Or TextBoxPApplicationStatus.Text = "Screened" Then
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = False
                DateTimePickerInterview.Enabled = False
                DateTimePickerOffer.Enabled = False
                ComboBoxOfferStatus.Enabled = False
                DateTimePickerOfferAccept.Enabled = False
                DateTimePickerJoining.Enabled = False
                DateTimePickerInvite.Enabled = False
                DateTimePickerVisit.Enabled = False
                ComboBoxInviteGoa.Enabled = False
                TextBoxVisitCost.Enabled = False
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = False

            ElseIf TextBoxPApplicationStatus.Text = "SHARED" Or TextBoxPApplicationStatus.Text = "Shared" Then
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = False
                DateTimePickerOffer.Enabled = False
                ComboBoxOfferStatus.Enabled = False
                DateTimePickerOfferAccept.Enabled = False
                DateTimePickerJoining.Enabled = False
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = False

            ElseIf TextBoxPApplicationStatus.Text = "APPROVED" Or TextBoxPApplicationStatus.Text = "Approved" Then
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = True
                DateTimePickerOffer.Enabled = False
                ComboBoxOfferStatus.Enabled = False
                DateTimePickerOfferAccept.Enabled = False
                DateTimePickerJoining.Enabled = False
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = False


            ElseIf TextBoxPApplicationStatus.Text = "OFFERED" Or TextBoxPApplicationStatus.Text = "Offered" Then
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = True
                DateTimePickerOffer.Enabled = True
                ComboBoxOfferStatus.Enabled = False
                DateTimePickerOfferAccept.Enabled = True
                DateTimePickerJoining.Enabled = False
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = False

            ElseIf TextBoxPApplicationStatus.Text = "TO JOIN" Or TextBoxPApplicationStatus.Text = "To Join" Then
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = True
                DateTimePickerOffer.Enabled = True
                ComboBoxOfferStatus.Enabled = False
                DateTimePickerOfferAccept.Enabled = True
                DateTimePickerJoining.Enabled = True
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = False

            ElseIf TextBoxPApplicationStatus.Text = "JOINED" Or TextBoxPApplicationStatus.Text = "Joined" Then
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = True
                DateTimePickerOffer.Enabled = True
                ComboBoxOfferStatus.Enabled = False
                DateTimePickerOfferAccept.Enabled = True
                DateTimePickerJoining.Enabled = True
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = False

            ElseIf TextBoxPApplicationStatus.Text = "REJECT" Or TextBoxPApplicationStatus.Text = "Reject" Then
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = False
                DateTimePickerInterview.Enabled = False
                DateTimePickerOffer.Enabled = False
                ComboBoxOfferStatus.Enabled = False
                DateTimePickerOfferAccept.Enabled = False
                DateTimePickerJoining.Enabled = False
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxRejectedBy.Enabled = True
                ComboBoxReason.Enabled = True

            ElseIf TextBoxPApplicationStatus.Text = "OFFER DECLINED" Or TextBoxPApplicationStatus.Text = "Offer Declined" Then
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = True
                DateTimePickerOffer.Enabled = True
                ComboBoxOfferStatus.Enabled = False
                DateTimePickerOfferAccept.Enabled = True
                DateTimePickerJoining.Enabled = False
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = True

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub

    Private Sub DateTimePickerPScreeningDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerPScreeningDate.ValueChanged


        If DateTimePickerPScreeningDate.Value <= #1/1/1900# Then
            DateTimePickerPScreeningDate.CustomFormat = " "
        Else
            DateTimePickerPScreeningDate.CustomFormat = "dd-MMM-yyyy"
        End If

    End Sub
    Private Sub DateTimePickerShare_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerShare.ValueChanged

        If DateTimePickerShare.Value = #1/1/1900# Then
            txtSD.Text = ""
        Else
            DateTimePickerShare.CustomFormat = "dd-MMM-yyyy"
            txtSD.Text = Format(DateTimePickerShare.Value, "dd-MMM-yyyy")
        End If

    End Sub

    Private Sub DateTimePickerInterview_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerInterview.ValueChanged
        If DateTimePickerInterview.Value = #1/1/1900# Then
            txtID.Text = ""
        Else
            DateTimePickerInterview.CustomFormat = "dd-MMM-yyyy"
            txtID.Text = Format(DateTimePickerInterview.Value, "dd-MMM-yyyy")
        End If

    End Sub

    Private Sub DateTimePickerOffer_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerOffer.ValueChanged
        If DateTimePickerOffer.Value = #1/1/1900# Then
            txtOD.Text = ""
        Else
            DateTimePickerOffer.CustomFormat = "dd-MMM-yyyy"
            txtOD.Text = Format(DateTimePickerOffer.Value, "dd-MMM-yyyy")

        End If


    End Sub

    Private Sub DateTimePickerOfferAccept_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerOfferAccept.ValueChanged
        If DateTimePickerOfferAccept.Value = #1/1/1900# Then
            txtOAD.Text = ""
            'ComboBoxOfferStatus.Text = ""
        Else
            DateTimePickerOfferAccept.CustomFormat = "dd-MMM-yyyy"
            txtOAD.Text = Format(DateTimePickerOfferAccept.Value, "dd-MMM-yyyy")
            'ComboBoxOfferStatus.Text = "Accepted"
        End If

    End Sub

    Private Sub DateTimePickerJoining_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerJoining.ValueChanged
        If DateTimePickerJoining.Value = #1/1/1900# Then
            txtJD.Text = ""
        Else
            DateTimePickerJoining.CustomFormat = "dd-MMM-yyyy"
            txtJD.Text = Format(DateTimePickerJoining.Value, "dd-MMM-yyyy")
        End If

    End Sub

    Private Sub DateTimePickerInvite_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerInvite.ValueChanged
        If DateTimePickerInvite.Value = #1/1/1900# Then
            txtInD.Text = ""
            ComboBoxInviteGoa.Text = "No"
        Else
            DateTimePickerInvite.CustomFormat = "dd-MMM-yyyy"
            txtInD.Text = Format(DateTimePickerInvite.Value, "dd-MMM-yyyy")
            ComboBoxInviteGoa.Text = "Yes"
        End If

    End Sub

    Private Sub DateTimePickerVisit_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerVisit.ValueChanged
        If DateTimePickerVisit.Value = #1/1/1900# Then
            txtVD.Text = ""
            ComboBoxVisited.Text = "No"
        Else
            DateTimePickerVisit.CustomFormat = "dd-MMM-yyyy"
            txtVD.Text = Format(DateTimePickerVisit.Value, "dd-MMM-yyyy")
            ComboBoxVisited.Text = "Yes"
            ComboBoxInviteGoa.Text = "Yes"
        End If

    End Sub


    Private Sub ComboBoxPJobID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPJobID.SelectedIndexChanged
        ''------------------Clear Filled values ----------------------------
        TextBoxPJobStatus.Text = ""
        DateTimePickerPOpenDate.Text = ""
        TextBoxPJobPosition.Text = ""
        TextBoxPCompanyName.Text = ""
        TextBoxPRecruiter.Text = ""
        TextBoxAppRec.Text = ""
        TextBoxElapseTime.Text = ""

        TextBoxPApplicationStatus.Text = ""
        'ComboBoxChangeStatus.Text = ""
        ComboBoxChangeStatus.SelectedIndex = -1
        SameJobYes.Checked = False
        SameJobNo.Checked = False
        'DateTimePickerPScreeningDate.CustomFormat = " "
        ComboBoxPResumeSource.Text = ""
        ComboBoxPLocation.Text = ""
        TextBoxCurrentCTC.Text = ""
        TextBoxAcceptedCTC.Text = ""
        TextBoxPExperience.Text = ""
        TextBoxPCandidateName.Text = ""
        TextBoxPEmail.Text = ""
        TextBoxPMobile.Text = ""
        ComboBoxCRecruiter.SelectedIndex = -1
        'ComboBoxRejectedBy.Text = ""
        'ComboBoxReason.Text = ""
        ComboBoxRejectedBy.SelectedIndex = -1
        ComboBoxReason.SelectedIndex = -1
        DateTimePickerShare.CustomFormat = " "
        txtSD.Text = ""
        DateTimePickerInterview.CustomFormat = " "
        txtID.Text = ""
        DateTimePickerOffer.CustomFormat = " "
        txtOD.Text = ""
        ComboBoxOfferStatus.Text = "NA"
        DateTimePickerOfferAccept.CustomFormat = " "
        txtOAD.Text = ""
        DateTimePickerJoining.CustomFormat = " "
        txtJD.Text = ""
        DateTimePickerInvite.CustomFormat = " "
        txtInD.Text = ""
        DateTimePickerVisit.CustomFormat = " "
        txtVD.Text = ""
        ComboBoxInviteGoa.Text = "No"
        ComboBoxVisited.Text = "No"
        TextBoxVisitCost.Text = "0"
        TextBoxComments.Text = ""
        ComboBoxNextSteps.SelectedIndex = -1
        ComboBoxNoticePeriod.SelectedIndex = -1
        ''------------------------------------------------------------------
        Try
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DT As New DataTable
            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE JOB_ID = '" & ComboBoxPJobID.Text & "'", SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)

            DA.Fill(DT)
            TextBoxPJobStatus.DataBindings.Add(New Binding("Text", DT, "Job_Status"))
            DateTimePickerPOpenDate.DataBindings.Add(New Binding("Text", DT, "Open_Date"))
            TextBoxPJobPosition.DataBindings.Add(New Binding("Text", DT, "Job_Position"))
            TextBoxPCompanyName.DataBindings.Add(New Binding("Text", DT, "Company1"))
            TextBoxPRecruiter.DataBindings.Add(New Binding("Text", DT, "Recruiter"))
            SQLConn.Close()

            TextBoxPJobStatus.DataBindings.Clear()
            DateTimePickerPOpenDate.DataBindings.Clear()
            TextBoxPJobPosition.DataBindings.Clear()
            TextBoxPCompanyName.DataBindings.Clear()
            TextBoxPRecruiter.DataBindings.Clear()


            '------ Count of Total No. of Application Received ---------------------
            Dim AppRec As Integer
            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE JOB_ID= '" & ComboBoxPJobID.Text & "'", SQLConn)
            SQLComm.CommandTimeout = 30
            AppRec = SQLComm.ExecuteScalar
            TextBoxAppRec.Text = AppRec

            SQLConn.Close()
            '-----------------------------------------------------------------------


            '---------------- Calculate Elapsed Time --------------------------------
            'TextBoxElapseTime.Text = Int(Val(DateTime.Now) - Val(DateTimePickerPOpenDate.Value)) & " Days"
            TextBoxElapseTime.Text = (DateTime.Now).Subtract(DateTimePickerPOpenDate.Value).Days + 1 & " Days"

            '--------------Add List Item in App ID -----------------------------------
            ComboBoxAppID.Items.Clear()
            ComboBoxAppID.Text = ""
            Dim DR As SqlDataReader
            SQLComm = New SqlCommand("Select Application_ID from ApplicationTable Where Job_ID = '" & ComboBoxPJobID.Text & "'", SQLConn)
            SQLComm.CommandTimeout = 30
            SQLConn.Open()
            DR = SQLComm.ExecuteReader()
            If DR.HasRows = True Then
                While DR.Read()
                    Me.ComboBoxAppID.Items.Add(DR("Application_ID"))
                End While
            End If
            SQLComm.ResetCommandTimeout()
            '----------------------------------------

            SQLConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub

    Private Sub ButtonProcessUpdate_Click(sender As Object, e As EventArgs) Handles ButtonProcessUpdate.Click

        Try
            SQLComm.Parameters.Clear()
            DataBindings.Clear()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn

            If ComboBoxPJobID.Text = "" Then
                MessageBox.Show("Please Select Job ID")
                ComboBoxPJobID.Focus()
            ElseIf TextBoxPJobStatus.Text = "CANCELLED" Or TextBoxPJobStatus.Text = "ON-HOLD" Then
                MessageBox.Show("Job Status is " & TextBoxPJobStatus.Text & " !!!. Kindly select another Job ID", "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ComboBoxPJobID.Focus()
                Exit Sub
            ElseIf TextBoxPJobStatus.Text = "JOINED" And TextBoxPApplicationStatus.Text = "JOINED" Then
                MessageBox.Show("Candidate Status is " & TextBoxPJobStatus.Text & ". !!!", "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ComboBoxAppID.Focus()
                Exit Sub
            ElseIf TextBoxPJobStatus.Text = "JOINED" And TextBoxPApplicationStatus.Text = "TO JOIN" Then
                MessageBox.Show("Job Status is " & TextBoxPJobStatus.Text & ". !!!", "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ComboBoxPJobID.Focus()
                Exit Sub
            ElseIf TextBoxPJobStatus.Text = "JOINED" And TextBoxPApplicationStatus.Text = "OFFERED" Then
                MessageBox.Show("Job Status is " & TextBoxPJobStatus.Text & ". !!!", "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ComboBoxPJobID.Focus()
                Exit Sub
            ElseIf TextBoxPJobStatus.Text = "JOINED" And ComboBoxChangeStatus.Text = "OFFERED" Then
                MessageBox.Show("Job Status is " & TextBoxPJobStatus.Text & ". !!!", "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ComboBoxPJobID.Focus()
                Exit Sub
            ElseIf TextBoxPJobStatus.Text = "JOINED" And TextBoxPApplicationStatus.Text = "OFFER DECLINED" Then
                MessageBox.Show("Candidate Status is " & TextBoxPApplicationStatus.Text & ". !!!", "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ComboBoxAppID.Focus()
                Exit Sub
            ElseIf TextBoxPJobStatus.Text = "JOINED" And ComboBoxChangeStatus.Text = "OFFER DECLINED" Then
                MessageBox.Show("Job Status Is " & TextBoxPJobStatus.Text & " !!!.", "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ComboBoxPJobID.Focus()
                Exit Sub
            ElseIf ComboBoxAppID.Text = "" Then
                MessageBox.Show("Please Select Application ID")
                ComboBoxAppID.Focus()
            ElseIf String.IsNullOrWhiteSpace(TextBoxPCandidateName.Text) Then
                MessageBox.Show("Enter Candidate Name !!!")
                TextBoxPCandidateName.Focus()
            ElseIf ComboBoxChangeStatus.Text = "" Then
                MessageBox.Show("Please Select Status")
                ComboBoxChangeStatus.Focus()
            ElseIf DateTimePickerPOpenDate.Value > DateTimePickerPScreeningDate.Value Then
                MessageBox.Show("Please check Job Open Date. Job Open Date must be less than Candidate Screening Date. !!!")
                DateTimePickerPScreeningDate.Focus()
                Exit Sub
            ElseIf ComboBoxNextSteps.Text = "" Then
                MessageBox.Show("Please Select 'Assign To' Tag. !!!")
                ComboBoxNextSteps.Focus()
                Exit Sub
            ElseIf ComboBoxNoticePeriod.Text = "" Then
                MessageBox.Show("Please Select Notice Period !!!")
                ComboBoxNoticePeriod.Focus()
                Exit Sub
            End If

            '------------------------- IF REJECT -----------------------------------------------------------
            Select Case ComboBoxChangeStatus.Text

                Case "REJECT"
                    If ComboBoxRejectedBy.Text = "" Then
                        MessageBox.Show("Please Select Rejected By")
                        ComboBoxRejectedBy.Focus()
                    ElseIf ComboBoxReason.Text = "" Then
                        MessageBox.Show("Please Select Reason For Reject")
                        ComboBoxReason.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And ComboBoxInviteGoa.Text <> "Yes" Then
                        MessageBox.Show("Please Select Invite")
                        ComboBoxInviteGoa.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Invite Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Visit Date")
                        DateTimePickerVisit.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value < DateTimePickerShare.Value Then
                        MessageBox.Show("Invite Date must be greater than Share Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value < DateTimePickerInvite.Value Then
                        MessageBox.Show("Visit Date must be greater than Invite Date")
                        DateTimePickerVisit.Focus()
                    Else
                        SQLConn.Open()
                        SQLComm.CommandText = ("UPDATE ApplicationTable Set Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name, Candidate_Name = @Candidate_Name, E_Mail = @E_Mail, Phone = @Phone, Location = @Location, Resume_Source = @Resume_Source, Experience = @Experience, Current_CTC = @Current_CTC, Accepted_CTC = @Accepted_CTC, Screening =@Screening, Screening_Date =@Screening_Date,Shared = @Shared, Shared_Date = @Shared_Date, Interview = @Interview, Interview_Date = @Interview_Date, Invited = @Invited, Invited_Date = @Invited_Date, Visited = @Visited, Visited_Date = @Visited_Date, Visit_Cost = @Visit_Cost, Offer = @Offer, Offer_Date = @Offer_Date, Offer_Accepted =@Offer_Accepted, Offer_Accepted_Date = @Offer_Accepted_Date, Offer_Status = @Offer_Status, Joining = @Joining, Joining_Date = @Joining_Date, Decline_Reason = @Decline_Reason, Comments = @Comments, Rejected = @Rejected, Rejected_By = @Rejected_By, Elapsed_Time = @Elapsed_Time, Application_Stage = @Application_Stage, Next_Steps =@Next_Steps, Last_Modified =@Last_Modified, Notice_Period = @Notice_Period Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        'SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Status = @Offer_Status,Offer_Accepted_Date = @Offer_Accepted_Date,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = TextBoxPJobStatus.Text
                        SQLComm.Parameters.Add("@Application_Status", SqlDbType.Char).Value = "REJECT"
                        SQLComm.Parameters.Add("@Recruiter_Name", SqlDbType.Char).Value = ComboBoxCRecruiter.Text
                        SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = StrConv(StrConv(If(String.IsNullOrWhiteSpace(Trim(TextBoxPCandidateName.Text)), DBNull.Value, Trim(TextBoxPCandidateName.Text)), VbStrConv.ProperCase), VbStrConv.ProperCase)
                        SQLComm.Parameters.Add("@E_Mail", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPEmail.Text)), DBNull.Value, Trim(TextBoxPEmail.Text))
                        SQLComm.Parameters.Add("@Phone", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPMobile.Text)), DBNull.Value, Trim(TextBoxPMobile.Text))
                        SQLComm.Parameters.Add("@Location", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxPLocation.Text)), DBNull.Value, Trim(ComboBoxPLocation.Text))
                        SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = Trim(ComboBoxPResumeSource.Text)
                        SQLComm.Parameters.Add("@Experience", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(TextBoxPExperience.Text), DBNull.Value, Trim(TextBoxPExperience.Text))
                        SQLComm.Parameters.Add("@Current_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxCurrentCTC.Text)), DBNull.Value, Trim(TextBoxCurrentCTC.Text))
                        SQLComm.Parameters.Add("@Accepted_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxAcceptedCTC.Text)), DBNull.Value, Trim(TextBoxAcceptedCTC.Text))
                        SQLComm.Parameters.Add("@Screening", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Screening_Date", SqlDbType.Date).Value = DateTimePickerPScreeningDate.Value
                        If DateTimePickerShare.Value <= #1/1/1900# Then
                            SQLComm.Parameters.Add("@Shared", SqlDbType.Char).Value = "No"
                            SQLComm.Parameters.Add("@Shared_Date", SqlDbType.Date).Value = DateTimePickerShare.Value
                        Else
                            SQLComm.Parameters.Add("@Shared", SqlDbType.Char).Value = "Yes"
                            SQLComm.Parameters.Add("@Shared_Date", SqlDbType.Date).Value = DateTimePickerShare.Value
                        End If
                        If DateTimePickerInterview.Value <= #1/1/1900# Then
                            SQLComm.Parameters.Add("@Interview", SqlDbType.Char).Value = "No"
                            SQLComm.Parameters.Add("@Interview_Date", SqlDbType.Date).Value = DateTimePickerInterview.Value
                        Else
                            SQLComm.Parameters.Add("@Interview", SqlDbType.Char).Value = "Yes"
                            SQLComm.Parameters.Add("@Interview_Date", SqlDbType.Date).Value = DateTimePickerInterview.Value
                        End If
                        If ComboBoxInviteGoa.Text = "Yes" Then
                            SQLComm.Parameters.Add("@Invited", SqlDbType.Char).Value = ComboBoxInviteGoa.Text
                            SQLComm.Parameters.Add("@Invited_Date", SqlDbType.Date).Value = DateTimePickerInvite.Value
                        Else
                            SQLComm.Parameters.Add("@Invited", SqlDbType.Char).Value = "No"
                            SQLComm.Parameters.Add("@Invited_Date", SqlDbType.Date).Value = #1/1/1900#
                        End If
                        If ComboBoxVisited.Text = "Yes" Then
                            SQLComm.Parameters.Add("@Visited", SqlDbType.Char).Value = ComboBoxVisited.Text
                            SQLComm.Parameters.Add("@Visited_Date", SqlDbType.Date).Value = DateTimePickerVisit.Value
                        Else
                            SQLComm.Parameters.Add("@Visited", SqlDbType.Char).Value = "No"
                            SQLComm.Parameters.Add("@Visited_Date", SqlDbType.Date).Value = #1/1/1900#
                        End If
                        SQLComm.Parameters.Add("@Visit_Cost", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxVisitCost.Text)), DBNull.Value, Trim(TextBoxVisitCost.Text))

                        If DateTimePickerOffer.Value <= #1/1/1900# Then
                            SQLComm.Parameters.Add("@Offer", SqlDbType.Char).Value = "No"
                            SQLComm.Parameters.Add("@Offer_Date", SqlDbType.Date).Value = DateTimePickerOffer.Value
                        Else
                            SQLComm.Parameters.Add("@Offer", SqlDbType.Char).Value = "Yes"
                            SQLComm.Parameters.Add("@Offer_Date", SqlDbType.Date).Value = DateTimePickerOffer.Value
                        End If

                        If DateTimePickerOfferAccept.Value > #1/1/1900# Then
                            SQLComm.Parameters.Add("@Offer_Accepted", SqlDbType.Char).Value = "Yes"
                            SQLComm.Parameters.Add("@Offer_Accepted_Date", SqlDbType.Date).Value = DateTimePickerOfferAccept.Value
                        Else
                            SQLComm.Parameters.Add("@Offer_Accepted", SqlDbType.Char).Value = "No"
                            SQLComm.Parameters.Add("@Offer_Accepted_Date", SqlDbType.Date).Value = #1/1/1900#
                        End If

                        SQLComm.Parameters.Add("@Offer_Status", SqlDbType.Char).Value = ComboBoxOfferStatus.Text
                        SQLComm.Parameters.Add("@Joining", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Decline_Reason", SqlDbType.Char).Value = ComboBoxReason.Text
                        SQLComm.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxComments.Text)), DBNull.Value, Trim(TextBoxComments.Text))
                        SQLComm.Parameters.Add("@Rejected", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Rejected_By", SqlDbType.Char).Value = ComboBoxRejectedBy.Text
                        SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTime.Now).Subtract(DateTimePickerPOpenDate.Value).Days + 1


                        If DateTimePickerOffer.Value > #1/1/1900# Then
                            SQLComm.Parameters.Add("@Application_Stage", SqlDbType.Char).Value = "OFFER"
                        ElseIf DateTimePickerInterview.Value > #1/1/1900# Then
                            SQLComm.Parameters.Add("@Application_Stage", SqlDbType.Char).Value = "INTERVIEW"
                        ElseIf DateTimePickerShare.Value > #1/1/1900# Then
                            SQLComm.Parameters.Add("@Application_Stage", SqlDbType.Char).Value = "SHARED"
                        Else
                            SQLComm.Parameters.Add("@Application_Stage", SqlDbType.Char).Value = "SCREENING"
                        End If

                        SQLComm.Parameters.Add("@Next_Steps", SqlDbType.Char).Value = ComboBoxNextSteps.Text
                        SQLComm.Parameters.Add("@Last_Modified", SqlDbType.DateTime).Value = Date.Now
                        SQLComm.Parameters.Add("@Notice_Period", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxNoticePeriod.Text)), DBNull.Value, Trim(ComboBoxNoticePeriod.Text))

                        SQLComm.ExecuteNonQuery()

                        '----------------- Update in Job Table-----------------------------------
                        SQLComm.Parameters.Clear()
                        SQLComm = New SqlCommand("Select Application_ID from JobTable Where Job_ID = '" & ComboBoxPJobID.Text & "'", SQLConn)

                        'SQLComm.CommandTimeout = 30

                        If IsDBNull(SQLComm.ExecuteScalar) Then
                            SQLComm.Parameters.Clear()

                        ElseIf SQLComm.ExecuteScalar = ComboBoxAppID.Text Then
                            SQLComm.Parameters.Clear()
                            SQLComm.CommandText = ("UPDATE JobTable SET Job_Status = @Job_Status,Application_ID = @Application_ID, Candidate_Name = @Candidate_Name,Elapsed_Time = @Elapsed_Time,Joining_Date=@Joining_Date,Total_Application=@Total_Application,Resume_Source=@Resume_Source Where Job_ID = '" & ComboBoxPJobID.Text & "'")
                            SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = TextBoxPJobStatus.Text
                            SQLComm.Parameters.Add("@Application_ID", SqlDbType.Char).Value = DBNull.Value
                            SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = DBNull.Value
                            SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTime.Now).Subtract(DateTimePickerPOpenDate.Value).Days + 1
                            SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = #1/1/1900#
                            SQLComm.Parameters.Add("@Total_Application", SqlDbType.Float).Value = TextBoxAppRec.Text
                            SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = DBNull.Value

                            SQLComm.ExecuteNonQuery()

                            SQLComm.Parameters.Clear()
                            SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status Where Job_ID = '" & ComboBoxPJobID.Text & "'")
                            SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = TextBoxPJobStatus.Text
                            SQLComm.ExecuteNonQuery()
                            SQLConn.Close()
                        Else

                        End If

                        TextBoxPApplicationStatus.Text = "REJECT"
                        ComboBoxChangeStatus.Text = ""
                        SQLComm.Parameters.Clear()
                        SQLConn.Close()
                        MessageBox.Show("Updated Successfully")

                        '----------------------- refresh in datagridview ----------------------------------
                        Dim ds1 As New DataSet
                        SQLConn.Open()
                        If FormTop.ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                            SQLComm = New SqlCommand(("Select * from ApplicationTable"), SQLConn) 'where Lower(Candidate_Name) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(E_Mail) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Phone) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_Position) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Company1) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_Category) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Recruiter_Name) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Resume_Source) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Decline_Reason) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Comments) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Next_Steps) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Application_ID) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%'"), SQLConn)
                        Else
                            SQLComm = New SqlCommand(("Select * from ApplicationTable where Recruiter_Name = '" & FormTop.ComboBoxAppDetailsRecruiter.Text & "'"), SQLConn) 'AND (Lower(Candidate_Name) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(E_Mail) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Phone) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_Position) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Company1) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_Category) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Recruiter_Name) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Resume_Source) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Decline_Reason) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Comments) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Next_Steps) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Application_ID) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%')"), SQLConn)
                        End If
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
                    End If

                    '------------------------- IF SCREENED -----------------------------------------------------------
                Case "SCREENED"

                    If DateTimePickerPScreeningDate.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Screening Date")
                        DateTimePickerPScreeningDate.Focus()
                    Else
                        SQLConn.Open()
                        SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Accepted=@Offer_Accepted,Offer_Accepted_Date = @Offer_Accepted_Date,Offer_Status = @Offer_Status,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage,Next_Steps=@Next_Steps,Last_Modified=@Last_Modified,Notice_Period=@Notice_Period Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        'SQLComm.CommandText = ("UPDATE ApplicationTable Set Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Status = @Offer_Status,Offer_Accepted_Date = @Offer_Accepted_Date,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = TextBoxPJobStatus.Text
                        SQLComm.Parameters.Add("@Application_Status", SqlDbType.Char).Value = "SCREENED"
                        SQLComm.Parameters.Add("@Recruiter_Name", SqlDbType.Char).Value = ComboBoxCRecruiter.Text
                        SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = StrConv(If(String.IsNullOrWhiteSpace(Trim(TextBoxPCandidateName.Text)), DBNull.Value, Trim(TextBoxPCandidateName.Text)), VbStrConv.ProperCase)
                        SQLComm.Parameters.Add("@E_Mail", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPEmail.Text)), DBNull.Value, Trim(TextBoxPEmail.Text))
                        SQLComm.Parameters.Add("@Phone", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPMobile.Text)), DBNull.Value, Trim(TextBoxPMobile.Text))
                        SQLComm.Parameters.Add("@Location", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxPLocation.Text)), DBNull.Value, Trim(ComboBoxPLocation.Text))
                        SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = Trim(ComboBoxPResumeSource.Text)
                        SQLComm.Parameters.Add("@Experience", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(TextBoxPExperience.Text), DBNull.Value, Trim(TextBoxPExperience.Text))
                        SQLComm.Parameters.Add("@Current_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxCurrentCTC.Text)), DBNull.Value, Trim(TextBoxCurrentCTC.Text))
                        SQLComm.Parameters.Add("@Accepted_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxAcceptedCTC.Text)), DBNull.Value, Trim(TextBoxAcceptedCTC.Text))
                        SQLComm.Parameters.Add("@Screening", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Screening_Date", SqlDbType.Date).Value = DateTimePickerPScreeningDate.Value
                        SQLComm.Parameters.Add("@Shared", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Shared_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Interview", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Interview_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Invited", SqlDbType.Char).Value = ComboBoxInviteGoa.Text
                        SQLComm.Parameters.Add("@Invited_Date", SqlDbType.Date).Value = DateTimePickerInvite.Value
                        SQLComm.Parameters.Add("@Visited", SqlDbType.Char).Value = ComboBoxVisited.Text
                        SQLComm.Parameters.Add("@Visited_Date", SqlDbType.Date).Value = DateTimePickerVisit.Value
                        SQLComm.Parameters.Add("@Visit_Cost", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxVisitCost.Text)), DBNull.Value, Trim(TextBoxVisitCost.Text))
                        SQLComm.Parameters.Add("@Offer", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Offer_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Offer_Accepted", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Offer_Accepted_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Offer_Status", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Joining", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Decline_Reason", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxComments.Text)), DBNull.Value, Trim(TextBoxComments.Text))
                        SQLComm.Parameters.Add("@Rejected", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Rejected_By", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTime.Now).Subtract(DateTimePickerPOpenDate.Value).Days + 1
                        SQLComm.Parameters.Add("@Application_Stage", SqlDbType.Char).Value = "SCREENING"
                        SQLComm.Parameters.Add("@Next_Steps", SqlDbType.Char).Value = ComboBoxNextSteps.Text
                        SQLComm.Parameters.Add("@Last_Modified", SqlDbType.DateTime).Value = Date.Now
                        SQLComm.Parameters.Add("@Notice_Period", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxNoticePeriod.Text)), DBNull.Value, Trim(ComboBoxNoticePeriod.Text))
                        'SQLComm.Parameters.Add("@Change_Job_ID", SqlDbType.Char).Value = "No"
                        'SQLComm.Parameters.Add("@Old_Job_ID", SqlDbType.Char).Value = "NA"
                        TextBoxPApplicationStatus.Text = "SCREENED"
                        ComboBoxChangeStatus.Text = ""
                        SQLComm.ExecuteNonQuery()
                        SQLConn.Close()
                        MessageBox.Show("Updated Successfully")
                        '----------------------- refresh in datagridview ----------------------------------
                        Dim ds1 As New DataSet
                        SQLConn.Open()
                        If FormTop.ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                            SQLComm = New SqlCommand(("Select * from ApplicationTable"), SQLConn)
                        Else
                            SQLComm = New SqlCommand(("Select * from ApplicationTable where Recruiter_Name = '" & FormTop.ComboBoxAppDetailsRecruiter.Text & "'"), SQLConn)
                        End If
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
                    End If

                    '------------------------- IF SHARED -----------------------------------------------------------
                Case "SHARED"
                    If DateTimePickerShare.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Shared Date")
                        DateTimePickerShare.Focus()
                    ElseIf txtSD.Text = "" Then
                        MessageBox.Show("Please Select Shared Date")
                        DateTimePickerShare.Focus()
                    ElseIf DateTimePickerShare.Value < DateTimePickerPScreeningDate.Value Then
                        MessageBox.Show("Share Date must be greater than Screening Date")
                        DateTimePickerShare.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And ComboBoxInviteGoa.Text <> "Yes" Then
                        MessageBox.Show("Please Select Invite")
                        ComboBoxInviteGoa.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Invite Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Visit Date")
                        DateTimePickerVisit.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value < DateTimePickerShare.Value Then
                        MessageBox.Show("Invite Date must be greater than Share Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value < DateTimePickerInvite.Value Then
                        MessageBox.Show("Visit Date must be greater than Invite Date")
                        DateTimePickerVisit.Focus()
                    Else
                        SQLConn.Open()
                        SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Accepted=@Offer_Accepted,Offer_Accepted_Date = @Offer_Accepted_Date,Offer_Status = @Offer_Status,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage,Next_Steps=@Next_Steps,Last_Modified=@Last_Modified,Notice_Period=@Notice_Period Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        'SQLComm.CommandText = ("UPDATE ApplicationTable Set Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Status = @Offer_Status,Offer_Accepted_Date = @Offer_Accepted_Date,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = TextBoxPJobStatus.Text
                        SQLComm.Parameters.Add("@Application_Status", SqlDbType.Char).Value = "SHARED"
                        SQLComm.Parameters.Add("@Recruiter_Name", SqlDbType.Char).Value = ComboBoxCRecruiter.Text
                        SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = StrConv(If(String.IsNullOrWhiteSpace(Trim(TextBoxPCandidateName.Text)), DBNull.Value, Trim(TextBoxPCandidateName.Text)), VbStrConv.ProperCase)
                        SQLComm.Parameters.Add("@E_Mail", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPEmail.Text)), DBNull.Value, Trim(TextBoxPEmail.Text))
                        SQLComm.Parameters.Add("@Phone", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPMobile.Text)), DBNull.Value, Trim(TextBoxPMobile.Text))
                        SQLComm.Parameters.Add("@Location", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxPLocation.Text)), DBNull.Value, Trim(ComboBoxPLocation.Text))
                        SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = Trim(ComboBoxPResumeSource.Text)
                        SQLComm.Parameters.Add("@Experience", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(TextBoxPExperience.Text), DBNull.Value, Trim(TextBoxPExperience.Text))
                        SQLComm.Parameters.Add("@Current_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxCurrentCTC.Text)), DBNull.Value, Trim(TextBoxCurrentCTC.Text))
                        SQLComm.Parameters.Add("@Accepted_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxAcceptedCTC.Text)), DBNull.Value, Trim(TextBoxAcceptedCTC.Text))
                        SQLComm.Parameters.Add("@Screening", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Screening_Date", SqlDbType.Date).Value = DateTimePickerPScreeningDate.Value
                        SQLComm.Parameters.Add("@Shared", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Shared_Date", SqlDbType.Date).Value = DateTimePickerShare.Value
                        SQLComm.Parameters.Add("@Interview", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Interview_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Invited", SqlDbType.Char).Value = ComboBoxInviteGoa.Text
                        SQLComm.Parameters.Add("@Invited_Date", SqlDbType.Date).Value = DateTimePickerInvite.Value
                        SQLComm.Parameters.Add("@Visited", SqlDbType.Char).Value = ComboBoxVisited.Text
                        SQLComm.Parameters.Add("@Visited_Date", SqlDbType.Date).Value = DateTimePickerVisit.Value
                        SQLComm.Parameters.Add("@Visit_Cost", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxVisitCost.Text)), DBNull.Value, Trim(TextBoxVisitCost.Text))
                        SQLComm.Parameters.Add("@Offer", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Offer_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Offer_Accepted", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Offer_Accepted_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Offer_Status", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Joining", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Decline_Reason", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxComments.Text)), DBNull.Value, Trim(TextBoxComments.Text))
                        SQLComm.Parameters.Add("@Rejected", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Rejected_By", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTime.Now).Subtract(DateTimePickerPOpenDate.Value).Days + 1
                        SQLComm.Parameters.Add("@Application_Stage", SqlDbType.Char).Value = "SHARED"
                        SQLComm.Parameters.Add("@Next_Steps", SqlDbType.Char).Value = ComboBoxNextSteps.Text
                        SQLComm.Parameters.Add("@Last_Modified", SqlDbType.DateTime).Value = Date.Now
                        SQLComm.Parameters.Add("@Notice_Period", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxNoticePeriod.Text)), DBNull.Value, Trim(ComboBoxNoticePeriod.Text))
                        'SQLComm.Parameters.Add("@Change_Job_ID", SqlDbType.Char).Value = "No"
                        'SQLComm.Parameters.Add("@Old_Job_ID", SqlDbType.Char).Value = "NA"
                        TextBoxPApplicationStatus.Text = "SHARED"
                        ComboBoxChangeStatus.Text = ""
                        SQLComm.ExecuteNonQuery()
                        SQLConn.Close()
                        MessageBox.Show("Updated Successfully")
                        '----------------------- refresh in datagridview ----------------------------------
                        Dim ds1 As New DataSet
                        SQLConn.Open()
                        If FormTop.ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                            SQLComm = New SqlCommand(("Select * from ApplicationTable"), SQLConn)
                        Else
                            SQLComm = New SqlCommand(("Select * from ApplicationTable where Recruiter_Name = '" & FormTop.ComboBoxAppDetailsRecruiter.Text & "'"), SQLConn)
                        End If
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
                    End If

                    '------------------------- IF APPROVED -----------------------------------------------------------
                Case "APPROVED"

                    If DateTimePickerInterview.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Interview Date")
                        DateTimePickerInterview.Focus()
                    ElseIf txtID.Text = "" Then
                        MessageBox.Show("Please Select Interview Date")
                        DateTimePickerInterview.Focus()
                    ElseIf DateTimePickerShare.Value < DateTimePickerPScreeningDate.Value Then
                        MessageBox.Show("Share Date must be greater than Screening Date")
                        DateTimePickerShare.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And ComboBoxInviteGoa.Text <> "Yes" Then
                        MessageBox.Show("Please Select Invite")
                        ComboBoxInviteGoa.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Invite Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Visit Date")
                        DateTimePickerVisit.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value < DateTimePickerShare.Value Then
                        MessageBox.Show("Invite Date must be greater than Share Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value < DateTimePickerInvite.Value Then
                        MessageBox.Show("Visit Date must be greater than Invite Date")
                        DateTimePickerVisit.Focus()
                    ElseIf DateTimePickerInterview.Value < DateTimePickerShare.Value Then
                        MessageBox.Show("Interview Date must be greater than Share Date")
                        DateTimePickerVisit.Focus()
                    Else
                        SQLConn.Open()
                        SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Accepted=@Offer_Accepted,Offer_Accepted_Date = @Offer_Accepted_Date,Offer_Status = @Offer_Status,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage,Next_Steps=@Next_Steps,Last_Modified=@Last_Modified,Notice_Period=@Notice_Period Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        'SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Status = @Offer_Status,Offer_Accepted_Date = @Offer_Accepted_Date,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = TextBoxPJobStatus.Text
                        SQLComm.Parameters.Add("@Application_Status", SqlDbType.Char).Value = "APPROVED"
                        SQLComm.Parameters.Add("@Recruiter_Name", SqlDbType.Char).Value = ComboBoxCRecruiter.Text
                        SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = StrConv(If(String.IsNullOrWhiteSpace(Trim(TextBoxPCandidateName.Text)), DBNull.Value, Trim(TextBoxPCandidateName.Text)), VbStrConv.ProperCase)
                        SQLComm.Parameters.Add("@E_Mail", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPEmail.Text)), DBNull.Value, Trim(TextBoxPEmail.Text))
                        SQLComm.Parameters.Add("@Phone", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPMobile.Text)), DBNull.Value, Trim(TextBoxPMobile.Text))
                        SQLComm.Parameters.Add("@Location", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxPLocation.Text)), DBNull.Value, Trim(ComboBoxPLocation.Text))
                        SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = Trim(Trim(ComboBoxPResumeSource.Text))
                        SQLComm.Parameters.Add("@Experience", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(TextBoxPExperience.Text), DBNull.Value, Trim(TextBoxPExperience.Text))
                        SQLComm.Parameters.Add("@Current_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxCurrentCTC.Text)), DBNull.Value, Trim(TextBoxCurrentCTC.Text))
                        SQLComm.Parameters.Add("@Accepted_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxAcceptedCTC.Text)), DBNull.Value, Trim(TextBoxAcceptedCTC.Text))
                        SQLComm.Parameters.Add("@Screening", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Screening_Date", SqlDbType.Date).Value = DateTimePickerPScreeningDate.Value
                        SQLComm.Parameters.Add("@Shared", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Shared_Date", SqlDbType.Date).Value = DateTimePickerShare.Value
                        SQLComm.Parameters.Add("@Interview", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Interview_Date", SqlDbType.Date).Value = DateTimePickerInterview.Value
                        SQLComm.Parameters.Add("@Invited", SqlDbType.Char).Value = ComboBoxInviteGoa.Text
                        SQLComm.Parameters.Add("@Invited_Date", SqlDbType.Date).Value = DateTimePickerInvite.Value
                        SQLComm.Parameters.Add("@Visited", SqlDbType.Char).Value = ComboBoxVisited.Text
                        SQLComm.Parameters.Add("@Visited_Date", SqlDbType.Date).Value = DateTimePickerVisit.Value
                        SQLComm.Parameters.Add("@Visit_Cost", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxVisitCost.Text)), DBNull.Value, Trim(TextBoxVisitCost.Text))
                        SQLComm.Parameters.Add("@Offer", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Offer_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Offer_Accepted", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Offer_Accepted_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Offer_Status", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Joining", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Decline_Reason", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxComments.Text)), DBNull.Value, Trim(TextBoxComments.Text))
                        SQLComm.Parameters.Add("@Rejected", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Rejected_By", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTime.Now).Subtract(DateTimePickerPOpenDate.Value).Days + 1
                        SQLComm.Parameters.Add("@Application_Stage", SqlDbType.Char).Value = "INTERVIEW"
                        SQLComm.Parameters.Add("@Next_Steps", SqlDbType.Char).Value = ComboBoxNextSteps.Text
                        SQLComm.Parameters.Add("@Last_Modified", SqlDbType.DateTime).Value = Date.Now
                        SQLComm.Parameters.Add("@Notice_Period", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxNoticePeriod.Text)), DBNull.Value, Trim(ComboBoxNoticePeriod.Text))
                        'SQLComm.Parameters.Add("@Change_Job_ID", SqlDbType.Char).Value = "No"
                        'SQLComm.Parameters.Add("@Old_Job_ID", SqlDbType.Char).Value = "NA"

                        TextBoxPApplicationStatus.Text = "APPROVED"
                        ComboBoxChangeStatus.Text = ""
                        SQLComm.ExecuteNonQuery()
                        SQLConn.Close()
                        MessageBox.Show("Updated Successfully")
                        '----------------------- refresh in datagridview ----------------------------------
                        Dim ds1 As New DataSet
                        SQLConn.Open()
                        If FormTop.ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                            SQLComm = New SqlCommand(("Select * from ApplicationTable"), SQLConn)
                        Else
                            SQLComm = New SqlCommand(("Select * from ApplicationTable where Recruiter_Name = '" & FormTop.ComboBoxAppDetailsRecruiter.Text & "'"), SQLConn)
                        End If
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
                    End If

                    '------------------------- IF OFFERED -----------------------------------------------------------
                Case "OFFERED"

                    If ComboBoxChangeStatus.Text = "OFFERED" And TextBoxPJobStatus.Text = "OFFERED" AndAlso TextBoxPApplicationStatus.Text <> "OFFERED" AndAlso TextBoxPApplicationStatus.Text <> "TO JOIN" Then
                        MessageBox.Show("Someone is already offered for this position. Please Select another Job ID !!!.")
                        ComboBoxPJobID.Focus()
                    ElseIf ComboBoxChangeStatus.Text = "OFFERED" And ComboBoxPJobID.Text = "111" Then
                        MessageBox.Show("You can't OFFER to Uncategorized candidate. Kindly change the Job ID. !!!.")
                        ComboBoxPJobID.Focus()
                    ElseIf Trim(TextBoxAcceptedCTC.Text) = "" Then
                        MessageBox.Show("Please Enter Accepted CTC yearly (Example: 1250000)")
                        TextBoxAcceptedCTC.Focus()
                    ElseIf DateTimePickerOffer.Value = #1/1/1900# Then
                        MessageBox.Show("Please Select Offer Date")
                        DateTimePickerOffer.Focus()
                    ElseIf txtOD.Text = "" Then
                        MessageBox.Show("Please Select Offer Date")
                        DateTimePickerOffer.Focus()
                    ElseIf DateTimePickerShare.Value < DateTimePickerPScreeningDate.Value Then
                        MessageBox.Show("Share Date must be greater than Screening Date")
                        DateTimePickerShare.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And ComboBoxInviteGoa.Text <> "Yes" Then
                        MessageBox.Show("Please Select Invite")
                        ComboBoxInviteGoa.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Invite Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Visit Date")
                        DateTimePickerVisit.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value < DateTimePickerShare.Value Then
                        MessageBox.Show("Invite Date must be greater than Share Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value < DateTimePickerInvite.Value Then
                        MessageBox.Show("Visit Date must be greater than Invite Date")
                        DateTimePickerVisit.Focus()
                    ElseIf DateTimePickerInterview.Value < DateTimePickerShare.Value Then
                        MessageBox.Show("Interview Date must be greater than Share Date")
                        DateTimePickerVisit.Focus()
                    ElseIf DateTimePickerOffer.Value < DateTimePickerInterview.Value Then
                        MessageBox.Show("Offer Date must be greater than Interview Date")
                        DateTimePickerOffer.Focus()
                    ElseIf DateTimePickerOfferAccept.Value <> #1/1/1900# AndAlso DateTimePickerOfferAccept.Value < DateTimePickerOffer.Value Then
                        MessageBox.Show("Offer Accepted Date must be greater than Offer Date")
                        DateTimePickerOfferAccept.Focus()
                    Else
                        SQLConn.Open()
                        SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Accepted=@Offer_Accepted,Offer_Accepted_Date = @Offer_Accepted_Date,Offer_Status = @Offer_Status,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage,Next_Steps=@Next_Steps,Last_Modified=@Last_Modified, Notice_Period = @Notice_Period Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        'SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Status = @Offer_Status,Offer_Accepted_Date = @Offer_Accepted_Date,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OFFERED"
                        SQLComm.Parameters.Add("@Application_Status", SqlDbType.Char).Value = "OFFERED"
                        SQLComm.Parameters.Add("@Recruiter_Name", SqlDbType.Char).Value = ComboBoxCRecruiter.Text
                        SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = StrConv(If(String.IsNullOrWhiteSpace(Trim(TextBoxPCandidateName.Text)), DBNull.Value, Trim(TextBoxPCandidateName.Text)), VbStrConv.ProperCase)
                        SQLComm.Parameters.Add("@E_Mail", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPEmail.Text)), DBNull.Value, Trim(TextBoxPEmail.Text))
                        SQLComm.Parameters.Add("@Phone", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPMobile.Text)), DBNull.Value, Trim(TextBoxPMobile.Text))
                        SQLComm.Parameters.Add("@Location", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxPLocation.Text)), DBNull.Value, Trim(ComboBoxPLocation.Text))
                        SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = Trim(ComboBoxPResumeSource.Text)
                        SQLComm.Parameters.Add("@Experience", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(TextBoxPExperience.Text), DBNull.Value, Trim(TextBoxPExperience.Text))
                        SQLComm.Parameters.Add("@Current_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxCurrentCTC.Text)), DBNull.Value, Trim(TextBoxCurrentCTC.Text))
                        SQLComm.Parameters.Add("@Accepted_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxAcceptedCTC.Text)), DBNull.Value, Trim(TextBoxAcceptedCTC.Text))
                        SQLComm.Parameters.Add("@Screening", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Screening_Date", SqlDbType.Date).Value = DateTimePickerPScreeningDate.Value
                        SQLComm.Parameters.Add("@Shared", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Shared_Date", SqlDbType.Date).Value = DateTimePickerShare.Value
                        SQLComm.Parameters.Add("@Interview", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Interview_Date", SqlDbType.Date).Value = DateTimePickerInterview.Value
                        SQLComm.Parameters.Add("@Invited", SqlDbType.Char).Value = ComboBoxInviteGoa.Text
                        SQLComm.Parameters.Add("@Invited_Date", SqlDbType.Date).Value = DateTimePickerInvite.Value
                        SQLComm.Parameters.Add("@Visited", SqlDbType.Char).Value = ComboBoxVisited.Text
                        SQLComm.Parameters.Add("@Visited_Date", SqlDbType.Date).Value = DateTimePickerVisit.Value
                        SQLComm.Parameters.Add("@Visit_Cost", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxVisitCost.Text)), DBNull.Value, Trim(TextBoxVisitCost.Text))
                        SQLComm.Parameters.Add("@Offer", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Offer_Date", SqlDbType.Date).Value = DateTimePickerOffer.Value

                        If DateTimePickerOfferAccept.Value > #1/1/1900# Then
                            SQLComm.Parameters.Add("@Offer_Accepted", SqlDbType.Char).Value = "Yes"
                            SQLComm.Parameters.Add("@Offer_Accepted_Date", SqlDbType.Date).Value = DateTimePickerOfferAccept.Value
                            SQLComm.Parameters.Add("@Offer_Status", SqlDbType.Char).Value = "Accepted"
                        Else
                            SQLComm.Parameters.Add("@Offer_Accepted", SqlDbType.Char).Value = "No"
                            SQLComm.Parameters.Add("@Offer_Accepted_Date", SqlDbType.Date).Value = #1/1/1900#
                            SQLComm.Parameters.Add("@Offer_Status", SqlDbType.Char).Value = "Pending"
                        End If

                        SQLComm.Parameters.Add("@Joining", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Decline_Reason", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxComments.Text)), DBNull.Value, Trim(TextBoxComments.Text))
                        SQLComm.Parameters.Add("@Rejected", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Rejected_By", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTimePickerOffer.Value).Subtract(DateTimePickerPOpenDate.Value).Days + 1
                        SQLComm.Parameters.Add("@Application_Stage", SqlDbType.Char).Value = "OFFER"
                        SQLComm.Parameters.Add("@Next_Steps", SqlDbType.Char).Value = ComboBoxNextSteps.Text
                        SQLComm.Parameters.Add("@Last_Modified", SqlDbType.DateTime).Value = Date.Now
                        SQLComm.Parameters.Add("@Notice_Period", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxNoticePeriod.Text)), DBNull.Value, Trim(ComboBoxNoticePeriod.Text))
                        'SQLComm.Parameters.Add("@Change_Job_ID", SqlDbType.Char).Value = "No"
                        'SQLComm.Parameters.Add("@Old_Job_ID", SqlDbType.Char).Value = "NA"
                        TextBoxPApplicationStatus.Text = "OFFERED"
                        SQLComm.ExecuteNonQuery()

                        '----------------- Update in Job Table-----------------------------------
                        SQLComm.Parameters.Clear()
                        SQLComm.CommandText = ("UPDATE JobTable SET Job_Status = @Job_Status,Application_ID = @Application_ID, Candidate_Name = @Candidate_Name,Resume_Source=@Resume_Source,Joining_Date = @Joining_Date Where Job_ID = '" & ComboBoxPJobID.Text & "'")

                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OFFERED"
                        SQLComm.Parameters.Add("@Application_ID", SqlDbType.Char).Value = ComboBoxAppID.Text
                        SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = StrConv(If(String.IsNullOrWhiteSpace(Trim(TextBoxPCandidateName.Text)), DBNull.Value, Trim(TextBoxPCandidateName.Text)), VbStrConv.ProperCase)
                        SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = Trim(ComboBoxPResumeSource.Text)
                        SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = #1/1/1900#

                        SQLComm.ExecuteNonQuery()

                        SQLComm.Parameters.Clear()
                        SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status Where Job_ID = '" & ComboBoxPJobID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OFFERED"
                        SQLComm.ExecuteNonQuery()
                        '------------------------------------------------------------------------
                        TextBoxPJobStatus.Text = "OFFERED"
                        ComboBoxChangeStatus.Text = ""
                        SQLConn.Close()
                        MessageBox.Show("Updated Successfully")
                        '----------------------- refresh in datagridview ----------------------------------
                        Dim ds1 As New DataSet
                        SQLConn.Open()
                        If FormTop.ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                            SQLComm = New SqlCommand(("Select * from ApplicationTable"), SQLConn)
                        Else
                            SQLComm = New SqlCommand(("Select * from ApplicationTable where Recruiter_Name = '" & FormTop.ComboBoxAppDetailsRecruiter.Text & "'"), SQLConn)
                        End If
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
                    End If

                    '------------------------- IF OFFER DECLINED -----------------------------------------------------------
                Case "OFFER DECLINED"

                    If ComboBoxChangeStatus.Text = "OFFER DECLINED" And TextBoxPJobStatus.Text = "OFFERED" AndAlso TextBoxPApplicationStatus.Text <> "OFFERED" AndAlso TextBoxPApplicationStatus.Text <> "TO JOIN" Then
                        MessageBox.Show("Someone is already offered for this position. Please Select another Job ID !!!.")
                        ComboBoxPJobID.Focus()
                    ElseIf ComboBoxChangeStatus.Text = "OFFER DECLINED" And ComboBoxPJobID.Text = "111" Then
                        MessageBox.Show("You can't make 'OFFER DECLINED' to Uncategorized candidate. Kindly change the Job ID. !!!.")
                        ComboBoxPJobID.Focus()
                    ElseIf DateTimePickerOffer.Value = #1/1/1900# Then
                        MessageBox.Show("Please Select Offer Date")
                        DateTimePickerOffer.Focus()
                    ElseIf txtOD.Text = "" Then
                        MessageBox.Show("Please Select Offer Date")
                        DateTimePickerOffer.Focus()
                    ElseIf DateTimePickerOffer.Value = #1/1/1900# Then
                        MessageBox.Show("Please Select Offer Date")
                        DateTimePickerOffer.Focus()
                    ElseIf DateTimePickerShare.Value < DateTimePickerPScreeningDate.Value Then
                        MessageBox.Show("Share Date must be greater than Screening Date")
                        DateTimePickerShare.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And ComboBoxInviteGoa.Text <> "Yes" Then
                        MessageBox.Show("Please Select Invite")
                        ComboBoxInviteGoa.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Invite Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Visit Date")
                        DateTimePickerVisit.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value < DateTimePickerShare.Value Then
                        MessageBox.Show("Invite Date must be greater than Share Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value < DateTimePickerInvite.Value Then
                        MessageBox.Show("Visit Date must be greater than Invite Date")
                        DateTimePickerVisit.Focus()
                    ElseIf DateTimePickerInterview.Value < DateTimePickerShare.Value Then
                        MessageBox.Show("Interview Date must be greater than Share Date")
                        DateTimePickerVisit.Focus()
                    ElseIf DateTimePickerOffer.Value < DateTimePickerInterview.Value Then
                        MessageBox.Show("Offer Date must be greater than Interview Date")
                        DateTimePickerOffer.Focus()
                    ElseIf DateTimePickerOfferAccept.Value > #1/1/1900# AndAlso DateTimePickerOfferAccept.Value < DateTimePickerOffer.Value Then
                        MessageBox.Show("Offer Accepted Date must be greater than Offer Date")
                        DateTimePickerOfferAccept.Focus()
                    ElseIf ComboBoxReason.Text = "" Then
                        MessageBox.Show("Please select Offer Decline Reason")
                        ComboBoxReason.Focus()
                    Else
                        SQLConn.Open()
                        SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Accepted=@Offer_Accepted,Offer_Accepted_Date = @Offer_Accepted_Date,Offer_Status = @Offer_Status,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage,Next_Steps=@Next_Steps,Last_Modified=@Last_Modified, Notice_Period = @Notice_Period Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        'SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Status = @Offer_Status,Offer_Accepted_Date = @Offer_Accepted_Date,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OPEN"
                        SQLComm.Parameters.Add("@Application_Status", SqlDbType.Char).Value = "OFFER DECLINED"
                        SQLComm.Parameters.Add("@Recruiter_Name", SqlDbType.Char).Value = ComboBoxCRecruiter.Text
                        SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = StrConv(If(String.IsNullOrWhiteSpace(Trim(TextBoxPCandidateName.Text)), DBNull.Value, Trim(TextBoxPCandidateName.Text)), VbStrConv.ProperCase)
                        SQLComm.Parameters.Add("@E_Mail", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPEmail.Text)), DBNull.Value, Trim(TextBoxPEmail.Text))
                        SQLComm.Parameters.Add("@Phone", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPMobile.Text)), DBNull.Value, Trim(TextBoxPMobile.Text))
                        SQLComm.Parameters.Add("@Location", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxPLocation.Text)), DBNull.Value, Trim(ComboBoxPLocation.Text))
                        SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = Trim(ComboBoxPResumeSource.Text)
                        SQLComm.Parameters.Add("@Experience", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(TextBoxPExperience.Text), DBNull.Value, Trim(TextBoxPExperience.Text))
                        SQLComm.Parameters.Add("@Current_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxCurrentCTC.Text)), DBNull.Value, Trim(TextBoxCurrentCTC.Text))
                        SQLComm.Parameters.Add("@Accepted_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxAcceptedCTC.Text)), DBNull.Value, Trim(TextBoxAcceptedCTC.Text))
                        SQLComm.Parameters.Add("@Screening", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Screening_Date", SqlDbType.Date).Value = DateTimePickerPScreeningDate.Value
                        SQLComm.Parameters.Add("@Shared", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Shared_Date", SqlDbType.Date).Value = DateTimePickerShare.Value
                        SQLComm.Parameters.Add("@Interview", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Interview_Date", SqlDbType.Date).Value = DateTimePickerInterview.Value
                        SQLComm.Parameters.Add("@Invited", SqlDbType.Char).Value = ComboBoxInviteGoa.Text
                        SQLComm.Parameters.Add("@Invited_Date", SqlDbType.Date).Value = DateTimePickerInvite.Value
                        SQLComm.Parameters.Add("@Visited", SqlDbType.Char).Value = ComboBoxVisited.Text
                        SQLComm.Parameters.Add("@Visited_Date", SqlDbType.Date).Value = DateTimePickerVisit.Value
                        SQLComm.Parameters.Add("@Visit_Cost", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxVisitCost.Text)), DBNull.Value, Trim(TextBoxVisitCost.Text))
                        SQLComm.Parameters.Add("@Offer", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Offer_Date", SqlDbType.Date).Value = DateTimePickerOffer.Value
                        If DateTimePickerOfferAccept.Value > #1/1/1900# Then
                            SQLComm.Parameters.Add("@Offer_Accepted", SqlDbType.Char).Value = "Yes"
                        Else
                            SQLComm.Parameters.Add("@Offer_Accepted", SqlDbType.Char).Value = "No"
                        End If
                        SQLComm.Parameters.Add("@Offer_Accepted_Date", SqlDbType.Date).Value = DateTimePickerOfferAccept.Value
                        SQLComm.Parameters.Add("@Offer_Status", SqlDbType.Char).Value = ComboBoxOfferStatus.Text
                        SQLComm.Parameters.Add("@Joining", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Decline_Reason", SqlDbType.Char).Value = ComboBoxReason.Text
                        SQLComm.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxComments.Text)), DBNull.Value, Trim(TextBoxComments.Text))
                        SQLComm.Parameters.Add("@Rejected", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Rejected_By", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTime.Now).Subtract(DateTimePickerPOpenDate.Value).Days + 1
                        SQLComm.Parameters.Add("@Application_Stage", SqlDbType.Char).Value = "OFFER"
                        SQLComm.Parameters.Add("@Next_Steps", SqlDbType.Char).Value = ComboBoxNextSteps.Text
                        SQLComm.Parameters.Add("@Last_Modified", SqlDbType.DateTime).Value = Date.Now
                        SQLComm.Parameters.Add("@Notice_Period", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxNoticePeriod.Text)), DBNull.Value, Trim(ComboBoxNoticePeriod.Text))
                        'SQLComm.Parameters.Add("@Change_Job_ID", SqlDbType.Char).Value = "No"
                        'SQLComm.Parameters.Add("@Old_Job_ID", SqlDbType.Char).Value = "NA"
                        TextBoxPApplicationStatus.Text = "OFFER DECLINED"
                        SQLComm.ExecuteNonQuery()

                        '----------------- Update in Job Table-----------------------------------
                        SQLComm.Parameters.Clear()
                        SQLComm.CommandText = ("UPDATE JobTable SET Job_Status = @Job_Status,Application_ID = @Application_ID, Candidate_Name = @Candidate_Name,Elapsed_Time = @Elapsed_Time,Joining_Date=@Joining_Date,Total_Application=@Total_Application,Resume_Source=@Resume_Source Where Job_ID = '" & ComboBoxPJobID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OPEN"
                        SQLComm.Parameters.Add("@Application_ID", SqlDbType.Char).Value = DBNull.Value
                        SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = DBNull.Value
                        SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTime.Now).Subtract(DateTimePickerPOpenDate.Value).Days + 1
                        SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = #1/1/1900#
                        SQLComm.Parameters.Add("@Total_Application", SqlDbType.Float).Value = TextBoxAppRec.Text
                        SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = DBNull.Value

                        SQLComm.ExecuteNonQuery()

                        SQLComm.Parameters.Clear()
                        SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status Where Job_ID = '" & ComboBoxPJobID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OPEN"
                        SQLComm.ExecuteNonQuery()

                        '------------------------------------------------------------------------
                        TextBoxPJobStatus.Text = "OPEN"
                        ComboBoxChangeStatus.Text = ""
                        SQLConn.Close()
                        MessageBox.Show("Updated Successfully")
                        '----------------------- refresh in datagridview ----------------------------------
                        Dim ds1 As New DataSet
                        SQLConn.Open()
                        If FormTop.ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                            SQLComm = New SqlCommand(("Select * from ApplicationTable"), SQLConn)
                        Else
                            SQLComm = New SqlCommand(("Select * from ApplicationTable where Recruiter_Name = '" & FormTop.ComboBoxAppDetailsRecruiter.Text & "'"), SQLConn)
                        End If
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
                    End If

                    '------------------------- IF TO JOIN -----------------------------------------------------------
                Case "TO JOIN"

                    If ComboBoxChangeStatus.Text = "TO JOIN" And TextBoxPJobStatus.Text = "OFFERED" AndAlso TextBoxPApplicationStatus.Text <> "OFFERED" AndAlso TextBoxPApplicationStatus.Text <> "TO JOIN" Then
                        MessageBox.Show("Someone is already offered for this position. Please Select another Job ID !!!.")
                    ElseIf ComboBoxChangeStatus.Text = "TO JOIN" And ComboBoxPJobID.Text = "111" Then
                        MessageBox.Show("You can't make 'To Join' to Uncategorized candidate. Kindly change the Job ID. !!!.")
                        ComboBoxPJobID.Focus()
                    ElseIf DateTimePickerOffer.Value = #1/1/1900# Then
                        MessageBox.Show("Please Select Offer Date")
                        DateTimePickerOffer.Focus()
                    ElseIf txtOD.Text = "" Then
                        MessageBox.Show("Please Select Offer Date")
                        DateTimePickerOffer.Focus()
                    ElseIf DateTimePickerOffer.Value = #1/1/1900# Then
                        MessageBox.Show("Please Select Offer Date")
                        DateTimePickerOffer.Focus()
                    ElseIf Trim(TextBoxAcceptedCTC.Text) = "" Then
                        MessageBox.Show("Please Enter Accepted CTC yearly (Example:  1250000)")
                        TextBoxAcceptedCTC.Focus()
                    ElseIf DateTimePickerShare.Value < DateTimePickerPScreeningDate.Value Then
                        MessageBox.Show("Share Date must be greater than Screening Date")
                        DateTimePickerShare.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And ComboBoxInviteGoa.Text <> "Yes" Then
                        MessageBox.Show("Please Select Invite")
                        ComboBoxInviteGoa.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Invite Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Visit Date")
                        DateTimePickerVisit.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value < DateTimePickerShare.Value Then
                        MessageBox.Show("Invite Date must be greater than Share Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value < DateTimePickerInvite.Value Then
                        MessageBox.Show("Visit Date must be greater than Invite Date")
                        DateTimePickerVisit.Focus()
                    ElseIf DateTimePickerInterview.Value < DateTimePickerShare.Value Then
                        MessageBox.Show("Interview Date must be greater than Share Date")
                        DateTimePickerVisit.Focus()
                    ElseIf DateTimePickerOffer.Value < DateTimePickerInterview.Value Then
                        MessageBox.Show("Offer Date must be greater than Interview Date")
                        DateTimePickerOffer.Focus()
                    ElseIf DateTimePickerOfferAccept.Value = #1/1/1900# Then
                        MessageBox.Show("Please Select Offer Accepted Date")
                        DateTimePickerOfferAccept.Focus()
                    ElseIf txtOAD.Text = "" Then
                        MessageBox.Show("Please Select Offer Accepted Date")
                        DateTimePickerOfferAccept.Focus()
                    ElseIf DateTimePickerOfferAccept.Value < DateTimePickerOffer.Value Then
                        MessageBox.Show("Offer Accepted Date must be greater than offer Date.")
                        DateTimePickerOfferAccept.Focus()
                    ElseIf ComboBoxOfferStatus.Text <> "Accepted" Then
                        MessageBox.Show("Offer Status must be accepted")
                        ComboBoxOfferStatus.Focus()
                    ElseIf DateTimePickerJoining.Value <= #1/1/1900# Then
                        MessageBox.Show("Kindly select Joining Date.")
                        DateTimePickerJoining.Focus()

                    ElseIf DateTimePickerJoining.Value > #1/1/1900# AndAlso DateTimePickerJoining.Value < DateTimePickerOfferAccept.Value Then
                        MessageBox.Show("Joining Date must be greater than Offer Accepted Date.!!!")
                        DateTimePickerJoining.Focus()

                    ElseIf DateTimePickerJoining.Value > #1/1/1900# AndAlso DateTimePickerJoining.Value >= DateTimePickerOfferAccept.Value AndAlso DateTimePickerJoining.Value <= Today Then
                        MessageBox.Show("Joining Date should not be less than Today. Kindly select 'JOINED' status if Joining Date is less than Today. !!!")
                        DateTimePickerJoining.Focus()
                        SQLConn.Dispose()

                    ElseIf DateTimePickerJoining.Value > Today Then
                        SQLConn.Open()
                        SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Accepted=@Offer_Accepted,Offer_Accepted_Date = @Offer_Accepted_Date,Offer_Status = @Offer_Status,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage,Next_Steps=@Next_Steps,Last_Modified=@Last_Modified, Notice_Period=@Notice_Period Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        'SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Status = @Offer_Status,Offer_Accepted_Date = @Offer_Accepted_Date,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OFFERED"
                        SQLComm.Parameters.Add("@Application_Status", SqlDbType.Char).Value = "TO JOIN"
                        SQLComm.Parameters.Add("@Recruiter_Name", SqlDbType.Char).Value = ComboBoxCRecruiter.Text
                        SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = StrConv(If(String.IsNullOrWhiteSpace(Trim(TextBoxPCandidateName.Text)), DBNull.Value, Trim(TextBoxPCandidateName.Text)), VbStrConv.ProperCase)
                        SQLComm.Parameters.Add("@E_Mail", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPEmail.Text)), DBNull.Value, Trim(TextBoxPEmail.Text))
                        SQLComm.Parameters.Add("@Phone", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPMobile.Text)), DBNull.Value, Trim(TextBoxPMobile.Text))
                        SQLComm.Parameters.Add("@Location", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxPLocation.Text)), DBNull.Value, Trim(ComboBoxPLocation.Text))
                        SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = Trim(ComboBoxPResumeSource.Text)
                        SQLComm.Parameters.Add("@Experience", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(TextBoxPExperience.Text), DBNull.Value, Trim(TextBoxPExperience.Text))
                        SQLComm.Parameters.Add("@Current_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxCurrentCTC.Text)), DBNull.Value, Trim(TextBoxCurrentCTC.Text))
                        SQLComm.Parameters.Add("@Accepted_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxAcceptedCTC.Text)), DBNull.Value, Trim(TextBoxAcceptedCTC.Text))
                        SQLComm.Parameters.Add("@Screening", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Screening_Date", SqlDbType.Date).Value = DateTimePickerPScreeningDate.Value
                        SQLComm.Parameters.Add("@Shared", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Shared_Date", SqlDbType.Date).Value = DateTimePickerShare.Value
                        SQLComm.Parameters.Add("@Interview", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Interview_Date", SqlDbType.Date).Value = DateTimePickerInterview.Value
                        SQLComm.Parameters.Add("@Invited", SqlDbType.Char).Value = ComboBoxInviteGoa.Text
                        SQLComm.Parameters.Add("@Invited_Date", SqlDbType.Date).Value = DateTimePickerInvite.Value
                        SQLComm.Parameters.Add("@Visited", SqlDbType.Char).Value = ComboBoxVisited.Text
                        SQLComm.Parameters.Add("@Visited_Date", SqlDbType.Date).Value = DateTimePickerVisit.Value
                        SQLComm.Parameters.Add("@Visit_Cost", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxVisitCost.Text)), DBNull.Value, Trim(TextBoxVisitCost.Text))
                        SQLComm.Parameters.Add("@Offer", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Offer_Date", SqlDbType.Date).Value = DateTimePickerOffer.Value
                        SQLComm.Parameters.Add("@Offer_Accepted", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Offer_Accepted_Date", SqlDbType.Date).Value = DateTimePickerOfferAccept.Value
                        SQLComm.Parameters.Add("@Offer_Status", SqlDbType.Char).Value = "Accepted"
                        SQLComm.Parameters.Add("@Joining", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = DateTimePickerJoining.Value
                        SQLComm.Parameters.Add("@Decline_Reason", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxComments.Text)), DBNull.Value, Trim(TextBoxComments.Text))
                        SQLComm.Parameters.Add("@Rejected", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Rejected_By", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTimePickerOffer.Value).Subtract(DateTimePickerPOpenDate.Value).Days + 1
                        SQLComm.Parameters.Add("@Application_Stage", SqlDbType.Char).Value = "OFFER"
                        SQLComm.Parameters.Add("@Next_Steps", SqlDbType.Char).Value = ComboBoxNextSteps.Text
                        SQLComm.Parameters.Add("@Last_Modified", SqlDbType.DateTime).Value = Date.Now
                        SQLComm.Parameters.Add("@Notice_Period", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxNoticePeriod.Text)), DBNull.Value, Trim(ComboBoxNoticePeriod.Text))
                        'SQLComm.Parameters.Add("@Change_Job_ID", SqlDbType.Char).Value = "No"
                        'SQLComm.Parameters.Add("@Old_Job_ID", SqlDbType.Char).Value = "NA"
                        TextBoxPApplicationStatus.Text = "TO JOIN"
                        SQLComm.ExecuteNonQuery()
                        '----------------- Update in Job Table-----------------------------------
                        SQLComm.Parameters.Clear()
                        SQLComm.CommandText = ("UPDATE JobTable SET Job_Status = @Job_Status,Application_ID = @Application_ID, Candidate_Name = @Candidate_Name,Recruiter = @Recruiter,Elapsed_Time = @Elapsed_Time,Joining_Date=@Joining_Date,Total_Application=@Total_Application,Resume_Source=@Resume_Source Where Job_ID = '" & ComboBoxPJobID.Text & "'")

                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OFFERED"
                        SQLComm.Parameters.Add("@Application_ID", SqlDbType.Char).Value = ComboBoxAppID.Text
                        SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = StrConv(If(String.IsNullOrWhiteSpace(Trim(TextBoxPCandidateName.Text)), DBNull.Value, Trim(TextBoxPCandidateName.Text)), VbStrConv.ProperCase)
                        SQLComm.Parameters.Add("@Recruiter", SqlDbType.Char).Value = ComboBoxCRecruiter.Text
                        SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTimePickerOffer.Value).Subtract(DateTimePickerPOpenDate.Value).Days + 1
                        SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = DateTimePickerJoining.Value
                        SQLComm.Parameters.Add("@Total_Application", SqlDbType.Float).Value = TextBoxAppRec.Text
                        SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = Trim(ComboBoxPResumeSource.Text)

                        SQLComm.ExecuteNonQuery()
                        SQLComm.Parameters.Clear()
                        SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status Where Job_ID = '" & ComboBoxPJobID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "OFFERED"
                        SQLComm.ExecuteNonQuery()
                        '------------------------------------------------------------------------
                        TextBoxPJobStatus.Text = "OFFERED"
                        ComboBoxChangeStatus.Text = ""

                        SQLConn.Close()
                        MessageBox.Show("Updated Successfully")
                        '----------------------- refresh in datagridview ----------------------------------
                        Dim ds1 As New DataSet
                        SQLConn.Open()
                        If FormTop.ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                            SQLComm = New SqlCommand(("Select * from ApplicationTable"), SQLConn)
                        Else
                            SQLComm = New SqlCommand(("Select * from ApplicationTable where Recruiter_Name = '" & FormTop.ComboBoxAppDetailsRecruiter.Text & "'"), SQLConn)
                        End If
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
                    End If

                    '------------------------- IF JOINED -----------------------------------------------------------
                Case "JOINED"

                    If ComboBoxChangeStatus.Text = "JOINED" And TextBoxPJobStatus.Text = "OFFERED" AndAlso TextBoxPApplicationStatus.Text <> "OFFERED" AndAlso TextBoxPApplicationStatus.Text <> "TO JOIN" Then
                        MessageBox.Show("Someone is already offered for this position. Please Select another Job ID !!!.")
                    ElseIf ComboBoxChangeStatus.Text = "JOINED" And ComboBoxPJobID.Text = "111" Then
                        MessageBox.Show("You can't make 'JOINED' to Uncategorized candidate. Kindly change the Job ID. !!!.")
                        ComboBoxPJobID.Focus()
                    ElseIf DateTimePickerJoining.Value = #1/1/1900# Then
                        MessageBox.Show("Please Select Joining Date")
                        DateTimePickerJoining.Focus()
                    ElseIf txtJD.Text = "" Then
                        MessageBox.Show("Please Select Joining Date")
                        DateTimePickerJoining.Focus()
                    ElseIf DateTimePickerJoining.Value > Today Then
                        MessageBox.Show("Joining Date should not be greater than Today. Kindly select TO JOIN status if Joining Date is greater than Today. !!!")
                        DateTimePickerJoining.Focus()
                    ElseIf DateTimePickerOffer.Value = #1/1/1900# Then
                        MessageBox.Show("Please Select Offer Date")
                        DateTimePickerOffer.Focus()
                    ElseIf txtOD.Text = "" Then
                        MessageBox.Show("Please Select Offer Date")
                        DateTimePickerOffer.Focus()
                    ElseIf DateTimePickerOffer.Value = #1/1/1900# Then
                        MessageBox.Show("Please Select Offer Date")
                        DateTimePickerOffer.Focus()
                    ElseIf Trim(TextBoxAcceptedCTC.Text) = "" Then
                        MessageBox.Show("Please Enter Accepted CTC yearly (Example:  1250000)")
                        TextBoxAcceptedCTC.Focus()
                    ElseIf DateTimePickerShare.Value < DateTimePickerPScreeningDate.Value Then
                        MessageBox.Show("Share Date must be greater than Screening Date")
                        DateTimePickerShare.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And ComboBoxInviteGoa.Text <> "Yes" Then
                        MessageBox.Show("Please Select Invite")
                        ComboBoxInviteGoa.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Invite Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value <= #1/1/1900# Then
                        MessageBox.Show("Please Select Visit Date")
                        DateTimePickerVisit.Focus()
                    ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value < DateTimePickerShare.Value Then
                        MessageBox.Show("Invite Date must be greater than Share Date")
                        DateTimePickerInvite.Focus()
                    ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value < DateTimePickerInvite.Value Then
                        MessageBox.Show("Visit Date must be greater than Invite Date")
                        DateTimePickerVisit.Focus()
                    ElseIf DateTimePickerInterview.Value < DateTimePickerShare.Value Then
                        MessageBox.Show("Interview Date must be greater than Share Date")
                        DateTimePickerVisit.Focus()
                    ElseIf DateTimePickerOffer.Value < DateTimePickerInterview.Value Then
                        MessageBox.Show("Offer Date must be greater than Interview Date")
                        DateTimePickerOffer.Focus()
                    ElseIf DateTimePickerOfferAccept.Value = #1/1/1900# Then
                        MessageBox.Show("Please Select Offer Accepted Date")
                        DateTimePickerOfferAccept.Focus()
                    ElseIf txtOAD.Text = "" Then
                        MessageBox.Show("Please Select Offer Accepted Date")
                        DateTimePickerOfferAccept.Focus()
                    ElseIf DateTimePickerOfferAccept.Value < DateTimePickerOffer.Value Then
                        MessageBox.Show("Offer Accepted Date must be greater than offer Date.")
                        DateTimePickerOfferAccept.Focus()
                    ElseIf ComboBoxOfferStatus.Text <> "Accepted" Then
                        MessageBox.Show("Offer Status must be accepted")
                        ComboBoxOfferStatus.Focus()
                    ElseIf DateTimePickerOfferAccept.Value > DateTimePickerJoining.Value Then
                        MessageBox.Show("Offer Accepted Date must be less than Joining Date.")
                        DateTimePickerOfferAccept.Focus()
                    ElseIf DateTimePickerJoining.Value >= DateTimePickerOfferAccept.Value AndAlso DateTimePickerJoining.Value <= Today Then
                        SQLConn.Open()
                        SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Accepted=@Offer_Accepted,Offer_Accepted_Date = @Offer_Accepted_Date,Offer_Status = @Offer_Status,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage,Next_Steps=@Next_Steps,Last_Modified=@Last_Modified, Notice_Period=@Notice_Period Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        'SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status, Application_Status = @Application_Status, Recruiter_Name = @Recruiter_Name,Candidate_Name = @Candidate_Name,E_Mail = @E_Mail,Phone = @Phone,Location = @Location,Resume_Source = @Resume_Source,Experience = @Experience,Current_CTC = @Current_CTC,Accepted_CTC = @Accepted_CTC,Screening=@Screening,Screening_Date=@Screening_Date,Shared = @Shared,Shared_Date = @Shared_Date,Interview = @Interview,Interview_Date = @Interview_Date,Invited = @Invited,Invited_Date = @Invited_Date,Visited = @Visited,Visited_Date = @Visited_Date,Visit_Cost = @Visit_Cost,Offer = @Offer,Offer_Date = @Offer_Date,Offer_Status = @Offer_Status,Offer_Accepted_Date = @Offer_Accepted_Date,Joining = @Joining,Joining_Date = @Joining_Date,Decline_Reason = @Decline_Reason,Comments = @Comments,Rejected = @Rejected,Rejected_By = @Rejected_By,Elapsed_Time = @Elapsed_Time,Application_Stage = @Application_Stage Where Application_ID = '" & ComboBoxAppID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "JOINED"
                        SQLComm.Parameters.Add("@Application_Status", SqlDbType.Char).Value = "JOINED"
                        SQLComm.Parameters.Add("@Recruiter_Name", SqlDbType.Char).Value = ComboBoxCRecruiter.Text
                        SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = StrConv(If(String.IsNullOrWhiteSpace(Trim(TextBoxPCandidateName.Text)), DBNull.Value, Trim(TextBoxPCandidateName.Text)), VbStrConv.ProperCase)
                        SQLComm.Parameters.Add("@E_Mail", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPEmail.Text)), DBNull.Value, Trim(TextBoxPEmail.Text))
                        SQLComm.Parameters.Add("@Phone", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxPMobile.Text)), DBNull.Value, Trim(TextBoxPMobile.Text))
                        SQLComm.Parameters.Add("@Location", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxPLocation.Text)), DBNull.Value, Trim(ComboBoxPLocation.Text))
                        SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = Trim(ComboBoxPResumeSource.Text)
                        SQLComm.Parameters.Add("@Experience", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(TextBoxPExperience.Text), DBNull.Value, Trim(TextBoxPExperience.Text))
                        SQLComm.Parameters.Add("@Current_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxCurrentCTC.Text)), DBNull.Value, Trim(TextBoxCurrentCTC.Text))
                        SQLComm.Parameters.Add("@Accepted_CTC", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxAcceptedCTC.Text)), DBNull.Value, Trim(TextBoxAcceptedCTC.Text))
                        SQLComm.Parameters.Add("@Screening", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Screening_Date", SqlDbType.Date).Value = DateTimePickerPScreeningDate.Value
                        SQLComm.Parameters.Add("@Shared", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Shared_Date", SqlDbType.Date).Value = DateTimePickerShare.Value
                        SQLComm.Parameters.Add("@Interview", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Interview_Date", SqlDbType.Date).Value = DateTimePickerInterview.Value
                        SQLComm.Parameters.Add("@Invited", SqlDbType.Char).Value = ComboBoxInviteGoa.Text
                        SQLComm.Parameters.Add("@Invited_Date", SqlDbType.Date).Value = DateTimePickerInvite.Value
                        SQLComm.Parameters.Add("@Visited", SqlDbType.Char).Value = ComboBoxVisited.Text
                        SQLComm.Parameters.Add("@Visited_Date", SqlDbType.Date).Value = DateTimePickerVisit.Value
                        SQLComm.Parameters.Add("@Visit_Cost", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxVisitCost.Text)), DBNull.Value, Trim(TextBoxVisitCost.Text))
                        SQLComm.Parameters.Add("@Offer", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Offer_Date", SqlDbType.Date).Value = DateTimePickerOffer.Value
                        SQLComm.Parameters.Add("@Offer_Accepted", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Offer_Accepted_Date", SqlDbType.Date).Value = DateTimePickerOfferAccept.Value
                        SQLComm.Parameters.Add("@Offer_Status", SqlDbType.Char).Value = "Accepted"
                        SQLComm.Parameters.Add("@Joining", SqlDbType.Char).Value = "Yes"
                        SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = DateTimePickerJoining.Value
                        SQLComm.Parameters.Add("@Decline_Reason", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = If(String.IsNullOrWhiteSpace(Trim(TextBoxComments.Text)), DBNull.Value, Trim(TextBoxComments.Text))
                        SQLComm.Parameters.Add("@Rejected", SqlDbType.Char).Value = "No"
                        SQLComm.Parameters.Add("@Rejected_By", SqlDbType.Char).Value = "NA"
                        SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTimePickerOffer.Value).Subtract(DateTimePickerPOpenDate.Value).Days + 1
                        SQLComm.Parameters.Add("@Application_Stage", SqlDbType.Char).Value = "JOINED"
                        SQLComm.Parameters.Add("@Next_Steps", SqlDbType.Char).Value = ComboBoxNextSteps.Text
                        SQLComm.Parameters.Add("@Last_Modified", SqlDbType.DateTime).Value = Date.Now
                        SQLComm.Parameters.Add("@Notice_Period", SqlDbType.Char).Value = If(String.IsNullOrWhiteSpace(Trim(ComboBoxNoticePeriod.Text)), DBNull.Value, Trim(ComboBoxNoticePeriod.Text))
                        'SQLComm.Parameters.Add("@Change_Job_ID", SqlDbType.Char).Value = "No"
                        'SQLComm.Parameters.Add("@Old_Job_ID", SqlDbType.Char).Value = "NA"
                        TextBoxPApplicationStatus.Text = "JOINED"
                        SQLComm.ExecuteNonQuery()
                        '----------------- Update in Job Table-----------------------------------
                        SQLComm.Parameters.Clear()
                        SQLComm.CommandText = ("UPDATE JobTable SET Job_Status = @Job_Status,Application_ID = @Application_ID, Candidate_Name = @Candidate_Name,Recruiter = @Recruiter,Elapsed_Time = @Elapsed_Time,Joining_Date=@Joining_Date,Total_Application=@Total_Application,Resume_Source=@Resume_Source Where Job_ID = '" & ComboBoxPJobID.Text & "'")

                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "JOINED"
                        SQLComm.Parameters.Add("@Application_ID", SqlDbType.Char).Value = ComboBoxAppID.Text
                        SQLComm.Parameters.Add("@Candidate_Name", SqlDbType.Char).Value = StrConv(If(String.IsNullOrWhiteSpace(Trim(TextBoxPCandidateName.Text)), DBNull.Value, Trim(TextBoxPCandidateName.Text)), VbStrConv.ProperCase)
                        SQLComm.Parameters.Add("@Recruiter", SqlDbType.Char).Value = ComboBoxCRecruiter.Text
                        SQLComm.Parameters.Add("@Elapsed_Time", SqlDbType.Float).Value = (DateTimePickerOffer.Value).Subtract(DateTimePickerPOpenDate.Value).Days + 1
                        SQLComm.Parameters.Add("@Joining_Date", SqlDbType.Date).Value = DateTimePickerJoining.Value
                        SQLComm.Parameters.Add("@Total_Application", SqlDbType.Float).Value = TextBoxAppRec.Text
                        SQLComm.Parameters.Add("@Resume_Source", SqlDbType.Char).Value = Trim(ComboBoxPResumeSource.Text)

                        SQLComm.ExecuteNonQuery()


                        SQLComm.Parameters.Clear()
                        SQLComm.CommandText = ("UPDATE ApplicationTable SET Job_Status = @Job_Status Where Job_ID = '" & ComboBoxPJobID.Text & "'")
                        SQLComm.Parameters.Add("@Job_Status", SqlDbType.Char).Value = "JOINED"
                        SQLComm.ExecuteNonQuery()

                        '------------------------------------------------------------------------
                        TextBoxPJobStatus.Text = "JOINED"
                        ComboBoxChangeStatus.Text = ""
                        SQLConn.Close()
                        MessageBox.Show("Updated Successfully")
                        '----------------------- refresh in datagridview ----------------------------------
                        Dim ds1 As New DataSet
                        SQLConn.Open()
                        If FormTop.ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                            SQLComm = New SqlCommand(("Select * from ApplicationTable"), SQLConn)
                        Else
                            SQLComm = New SqlCommand(("Select * from ApplicationTable where Recruiter_Name = '" & FormTop.ComboBoxAppDetailsRecruiter.Text & "'"), SQLConn)
                        End If
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
                        SQLComm.Dispose()
                        DataGridView1.Sort(DataGridView1.Columns(DataGridView1.ColumnCount - 1), direction:=ListSortDirection.Descending)
                    Else

                    End If


            End Select

            SQLConn.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
            SQLConn.Dispose()
        End Try

    End Sub

    Private Sub ComboBoxChangeStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxChangeStatus.SelectedIndexChanged

        Try
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLComm.Connection = SQLConn
            Dim DR As SqlDataReader

            ComboBoxReason.DropDownStyle = ComboBoxStyle.DropDownList

            ComboBoxOfferStatus.Text = ""
            If ComboBoxChangeStatus.Text = "SCREENED" Then
                'Call FieldColor()
                '-----------Value-------
                DateTimePickerShare.Value = #1/1/1900#
                DateTimePickerInterview.Value = #1/1/1900#
                DateTimePickerOffer.Value = #1/1/1900#
                ComboBoxOfferStatus.Text = "NA"
                DateTimePickerOfferAccept.Value = #1/1/1900#
                DateTimePickerJoining.Value = #1/1/1900#
                DateTimePickerInvite.Value = #1/1/1900#
                DateTimePickerVisit.Value = #1/1/1900#
                ComboBoxInviteGoa.Text = "No"
                'ComboBoxRejectedBy.Text = "NA"
                'ComboBoxReason.Text = "NA"
                ComboBoxRejectedBy.SelectedIndex = -1
                ComboBoxReason.SelectedIndex = -1
                '------------------
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = False
                DateTimePickerInterview.Enabled = False
                DateTimePickerOffer.Enabled = False
                ComboBoxOfferStatus.Text = "NA"
                ComboBoxOfferStatus.Enabled = False
                DateTimePickerOfferAccept.Enabled = False
                DateTimePickerJoining.Enabled = False
                DateTimePickerInvite.Enabled = False
                DateTimePickerVisit.Enabled = False
                ComboBoxInviteGoa.Enabled = False
                ComboBoxVisited.Enabled = False
                TextBoxVisitCost.Enabled = False
                ComboBoxOfferStatus.Enabled = False
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = False

            ElseIf ComboBoxChangeStatus.Text = "SHARED" Then
                '-----------Value-------
                DateTimePickerInterview.Value = #1/1/1900#
                DateTimePickerOffer.Value = #1/1/1900#
                DateTimePickerOfferAccept.Value = #1/1/1900#
                DateTimePickerJoining.Value = #1/1/1900#
                DateTimePickerInvite.Value = #1/1/1900#
                DateTimePickerVisit.Value = #1/1/1900#
                ComboBoxInviteGoa.Text = "No"
                ComboBoxOfferStatus.Text = "NA"
                'ComboBoxRejectedBy.Text = "NA"
                'ComboBoxReason.Text = "NA"
                ComboBoxRejectedBy.SelectedIndex = -1
                ComboBoxReason.SelectedIndex = -1
                '------------------

                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = False
                DateTimePickerOffer.Enabled = False
                ComboBoxOfferStatus.Text = "NA"
                ComboBoxOfferStatus.Enabled = False
                DateTimePickerOfferAccept.Enabled = False
                DateTimePickerJoining.Enabled = False
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                ComboBoxVisited.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxOfferStatus.Enabled = False
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = False

            ElseIf ComboBoxChangeStatus.Text = "APPROVED" Then
                '-----------Value-------
                DateTimePickerOffer.Value = #1/1/1900#
                ComboBoxOfferStatus.Text = "NA"
                DateTimePickerOfferAccept.Value = #1/1/1900#
                DateTimePickerJoining.Value = #1/1/1900#
                'ComboBoxRejectedBy.Text = "NA"
                'ComboBoxReason.Text = "NA"
                ComboBoxRejectedBy.SelectedIndex = -1
                ComboBoxReason.SelectedIndex = -1
                '------------------
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = True
                DateTimePickerOffer.Enabled = False
                ComboBoxOfferStatus.Text = "NA"
                ComboBoxOfferStatus.Enabled = False
                DateTimePickerOfferAccept.Enabled = False
                DateTimePickerJoining.Enabled = False
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                ComboBoxVisited.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxOfferStatus.Enabled = False
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = False


            ElseIf ComboBoxChangeStatus.Text = "OFFERED" Then
                '-----------Value-------
                'DateTimePickerOfferAccept.Value = #1/1/1900#
                DateTimePickerJoining.Value = #1/1/1900#
                'ComboBoxRejectedBy.Text = "NA"
                'ComboBoxReason.Text = "NA"
                ComboBoxRejectedBy.SelectedIndex = -1
                ComboBoxReason.SelectedIndex = -1
                '------------------
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = True
                DateTimePickerOffer.Enabled = True
                ComboBoxOfferStatus.Text = "Pending"
                DateTimePickerOfferAccept.Enabled = True
                DateTimePickerJoining.Enabled = False
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                ComboBoxVisited.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = False

            ElseIf ComboBoxChangeStatus.Text = "TO JOIN" Then
                '-----------Value-------
                'DateTimePickerOfferAccept.Value = #1/1/1900#
                'DateTimePickerJoining.Value = #1/1/1900#
                'ComboBoxRejectedBy.Text = "NA"
                'ComboBoxReason.Text = "NA"
                ComboBoxRejectedBy.SelectedIndex = -1
                ComboBoxReason.SelectedIndex = -1
                '------------------
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = True
                DateTimePickerOffer.Enabled = True
                ComboBoxOfferStatus.Text = "Accepted"
                DateTimePickerOfferAccept.Enabled = True
                DateTimePickerJoining.Enabled = True
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                ComboBoxVisited.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = False

            ElseIf ComboBoxChangeStatus.Text = "JOINED" Then
                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = True
                DateTimePickerOffer.Enabled = True
                ComboBoxOfferStatus.Enabled = False
                DateTimePickerOfferAccept.Enabled = True
                DateTimePickerJoining.Enabled = True
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                ComboBoxVisited.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = False
                ComboBoxRejectedBy.SelectedIndex = -1
                ComboBoxReason.SelectedIndex = -1
                ComboBoxOfferStatus.Text = "Accepted"

            ElseIf ComboBoxChangeStatus.Text = "REJECT" Then

                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = True
                DateTimePickerOffer.Enabled = True
                DateTimePickerOffer.Value = #1/1/1900#
                DateTimePickerOfferAccept.Enabled = False
                DateTimePickerOfferAccept.Value = #1/1/1900#
                DateTimePickerJoining.Enabled = False
                DateTimePickerJoining.Value = #1/1/1900#
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                ComboBoxVisited.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxOfferStatus.Enabled = False
                ComboBoxRejectedBy.Enabled = True
                ComboBoxReason.Enabled = True
                'ComboBoxRejectedBy.Text = ""
                'ComboBoxReason.Text = ""
                ComboBoxRejectedBy.SelectedIndex = -1
                ComboBoxReason.SelectedIndex = -1
                ComboBoxOfferStatus.Text = "NA"
                LabelReason.Text = "Reason for Reject :"
                '------- Add List Item in Reason for Decline
                SQLConn.Open()
                SQLComm = New SqlCommand("Select Decline_Reason from DeclineReason", SQLConn)
                SQLComm.CommandTimeout = 30
                DR = SQLComm.ExecuteReader
                Me.ComboBoxReason.Items.Clear()
                If DR.HasRows = True Then
                    While DR.Read
                        Me.ComboBoxReason.Items.Add(DR("Decline_Reason"))
                    End While
                    DR.Close()
                End If
                SQLComm.ResetCommandTimeout()
                SQLConn.Close()


            ElseIf ComboBoxChangeStatus.Text = "REJECT" And TextBoxPApplicationStatus.Text = "OFFERED" Then

                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = True
                DateTimePickerOffer.Enabled = True
                DateTimePickerOffer.Value = #1/1/1900#
                DateTimePickerOfferAccept.Enabled = False
                DateTimePickerJoining.Enabled = False
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                ComboBoxVisited.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxOfferStatus.Enabled = False
                ComboBoxRejectedBy.Enabled = True
                ComboBoxReason.Enabled = True
                ComboBoxRejectedBy.SelectedIndex = -1
                ComboBoxReason.SelectedIndex = -1
                ComboBoxOfferStatus.Text = "Declined"
                LabelReason.Text = "Reason for Reject :"

            ElseIf ComboBoxChangeStatus.Text = "OFFER DECLINED" Then

                DateTimePickerPScreeningDate.Enabled = True
                DateTimePickerShare.Enabled = True
                DateTimePickerInterview.Enabled = True
                DateTimePickerOffer.Enabled = True
                DateTimePickerOfferAccept.Enabled = True
                'DateTimePickerOfferAccept.Value = #1/1/1900#
                DateTimePickerJoining.Enabled = False
                DateTimePickerJoining.Value = #1/1/1900#
                DateTimePickerInvite.Enabled = True
                DateTimePickerVisit.Enabled = True
                ComboBoxInviteGoa.Enabled = True
                ComboBoxVisited.Enabled = True
                TextBoxVisitCost.Enabled = True
                ComboBoxOfferStatus.Enabled = False
                ComboBoxRejectedBy.Enabled = False
                ComboBoxReason.Enabled = True
                ComboBoxRejectedBy.SelectedIndex = -1
                ComboBoxReason.SelectedIndex = -1
                ComboBoxOfferStatus.Text = "Declined"
                LabelReason.Text = "Reason for Offer Decline :"

                '------- Add List Item in Reason for Offer Decline
                SQLConn.Open()
                SQLComm = New SqlCommand("Select OFFER_DECLINE_REASON from OfferDeclineReason", SQLConn)
                SQLComm.CommandTimeout = 30
                DR = SQLComm.ExecuteReader
                Me.ComboBoxReason.Items.Clear()
                If DR.HasRows = True Then
                    While DR.Read
                        Me.ComboBoxReason.Items.Add(DR("OFFER_DECLINE_REASON"))
                    End While
                    DR.Close()
                End If
                SQLComm.ResetCommandTimeout()
                SQLConn.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub


    Private Sub ComboBoxReason_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxReason.SelectedIndexChanged

        'If TextBoxPApplicationStatus.Text <> "OFFERED" And ComboBoxReason.Text = "Offer Decline" Then
        '    MessageBox.Show("Candidate must be offered for 'Offer Decline' reason.")
        '    ComboBoxReason.Text = ""
        '    ComboBoxReason.SelectedIndex = -1

        If ComboBoxChangeStatus.Text = "OFFER DECLINED" Then
            ComboBoxOfferStatus.Text = "Declined"
        Else
            ComboBoxOfferStatus.Text = "NA"
        End If
    End Sub

    Private Sub ComboBoxInviteGoa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxInviteGoa.SelectedIndexChanged

        If ComboBoxInviteGoa.Text = "Yes" Then
            'DateTimePickerInvite.Enabled = True
            'ComboBoxVisited.Enabled = True

        Else
            ComboBoxVisited.Text = "No"
            DateTimePickerVisit.Value = #1/1/1900#
            'DateTimePickerInvite.Enabled = False
            'ComboBoxVisited.Enabled = False
            DateTimePickerInvite.Value = #1/1/1900#
        End If

    End Sub

    Private Sub ComboBoxVisited_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxVisited.SelectedIndexChanged

        If ComboBoxVisited.Text = "Yes" Then
            'DateTimePickerVisit.Enabled = True
            'ComboBoxInviteGoa.Enabled = True
        Else
            'DateTimePickerVisit.Enabled = False
            DateTimePickerVisit.Value = #1/1/1900#
            'ComboBoxInviteGoa.Enabled = True
        End If

    End Sub

    Private Sub txt_Search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Search.KeyPress
        Try
            'SQLConn.Close()
            'ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            'SQLConn.ConnectionString = ConnStr
            'SQLComm.Connection = SQLConn
            'Dim ds1 As New DataSet
            'SQLConn.Open()
            'SQLComm = New sqlcommand("SELECT * FROM ApplicationTable WHERE Candidate_Name LIKE '%" & txt_Search.Text & "%'", SQLConn)
            'SQLComm.CommandTimeout = 30
            'Dim DA1 As New sqldataadapter(SQLComm.CommandText, ConnStr)
            'DA1.Fill(ds1)
            'DataGridView1.DataSource = ds1.Tables(0)
            'SQLConn.Close()
            'DataGridView1.DataBindings.Clear()
            'SQLComm.Parameters.Clear()
            'ConnStr = Nothing
            'Label_Found.Text = DataGridView1.RowCount
            'SQLConn.Dispose()

            '--------------------------------------Search on hit enter key -------------------------
            Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
            If tmp.KeyChar = ChrW(Keys.Enter) Then
                SQLConn.Close()
                ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                Dim ds1 As New DataSet
                SQLConn.Open()
                'SQLComm = New sqlcommand("SELECT * FROM ApplicationTable WHERE Candidate_Name LIKE '%" & txt_Search.Text & "%'", SQLConn)
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
            Else
                SQLConn.Dispose()
            End If

        Catch ex As Exception
            SQLConn.Close()
            SQLConn.Dispose()
        End Try
    End Sub







    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        CheckBoxNewCandidate.Checked = False
        Try
            ComboBoxPJobID.Text = ""
            ComboBoxPJobID.DataBindings.Clear()
            ComboBoxPJobID.Text = DataGridView1.SelectedCells.Item(3).Value

            ComboBoxAppID.Text = ""
            ComboBoxAppID.DataBindings.Clear()
            ComboBoxAppID.Text = DataGridView1.SelectedCells.Item(9).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextBoxPApplicationStatus_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPApplicationStatus.TextChanged

        '---------------------------Status Drop Down Item-------------------------------------------

        If TextBoxPApplicationStatus.Text = "SCREENED" Or TextBoxPApplicationStatus.Text = "Screened" Then
            ComboBoxChangeStatus.Enabled = True
            ComboBoxChangeStatus.Items.Clear()
            ComboBoxChangeStatus.Items.Add("SCREENED")
            ComboBoxChangeStatus.Items.Add("SHARED")
            ComboBoxChangeStatus.Items.Add("APPROVED")
            ComboBoxChangeStatus.Items.Add("OFFERED")
            ComboBoxChangeStatus.Items.Add("REJECT")

        ElseIf TextBoxPApplicationStatus.Text = "SHARED" Or TextBoxPApplicationStatus.Text = "Shared" Then
            ComboBoxChangeStatus.Enabled = True
            ComboBoxChangeStatus.Items.Clear()
            ComboBoxChangeStatus.Items.Add("SHARED")
            ComboBoxChangeStatus.Items.Add("APPROVED")
            ComboBoxChangeStatus.Items.Add("OFFERED")
            ComboBoxChangeStatus.Items.Add("REJECT")
        ElseIf TextBoxPApplicationStatus.Text = "APPROVED" Or TextBoxPApplicationStatus.Text = "Approved" Then
            ComboBoxChangeStatus.Enabled = True
            ComboBoxChangeStatus.Items.Clear()
            ComboBoxChangeStatus.Items.Add("APPROVED")
            ComboBoxChangeStatus.Items.Add("OFFERED")
            ComboBoxChangeStatus.Items.Add("REJECT")
        ElseIf TextBoxPApplicationStatus.Text = "OFFERED" Or TextBoxPApplicationStatus.Text = "Offered" Then
            ComboBoxChangeStatus.Enabled = True
            ComboBoxChangeStatus.Items.Clear()
            ComboBoxChangeStatus.Items.Add("OFFERED")
            ComboBoxChangeStatus.Items.Add("OFFER DECLINED")
            ComboBoxChangeStatus.Items.Add("TO JOIN")
            ComboBoxChangeStatus.Items.Add("JOINED")

        ElseIf TextBoxPApplicationStatus.Text = "OFFER DECLINED" Or TextBoxPApplicationStatus.Text = "Offer Declined" Then
            ComboBoxChangeStatus.Enabled = True
            ComboBoxChangeStatus.Items.Clear()
            ComboBoxChangeStatus.Items.Add("OFFERED")
            ComboBoxChangeStatus.Items.Add("OFFER DECLINED")
            ComboBoxChangeStatus.Items.Add("TO JOIN")
            ComboBoxChangeStatus.Items.Add("JOINED")

        ElseIf TextBoxPApplicationStatus.Text = "TO JOIN" Or TextBoxPApplicationStatus.Text = "To Join" Then
            ComboBoxChangeStatus.Enabled = True
            ComboBoxChangeStatus.Items.Clear()
            ComboBoxChangeStatus.Items.Add("OFFERED")
            ComboBoxChangeStatus.Items.Add("TO JOIN")
            ComboBoxChangeStatus.Items.Add("JOINED")
            ComboBoxChangeStatus.Items.Add("OFFER DECLINED")

        ElseIf TextBoxPApplicationStatus.Text = "JOINED" Or TextBoxPApplicationStatus.Text = "Joined" Then
            ComboBoxChangeStatus.Enabled = True
            ComboBoxChangeStatus.Items.Clear()
            ComboBoxChangeStatus.Items.Add("JOINED")
            ComboBoxChangeStatus.Items.Add("TO JOIN")
            ComboBoxChangeStatus.Items.Add("OFFER DECLINED")
        ElseIf TextBoxPApplicationStatus.Text = "REJECT" Or TextBoxPApplicationStatus.Text = "Reject" Then
            ComboBoxChangeStatus.Items.Clear()
            ComboBoxChangeStatus.Items.Add("SHARED")
            ComboBoxChangeStatus.Items.Add("APPROVED")
            ComboBoxChangeStatus.Items.Add("OFFERED")
            ComboBoxChangeStatus.Items.Add("REJECT")
        Else
            ComboBoxChangeStatus.Enabled = True
            ComboBoxChangeStatus.Items.Clear()
            ComboBoxChangeStatus.Items.Add("REJECT")
        End If


        '--------------------------- Field Enable Desable -----------------------------------------------------------

        If TextBoxPApplicationStatus.Text = "SCREENED" Or TextBoxPApplicationStatus.Text = "Screened" Then
            DateTimePickerPScreeningDate.Enabled = True
            DateTimePickerShare.Enabled = False
            DateTimePickerInterview.Enabled = False
            DateTimePickerOffer.Enabled = False
            ComboBoxOfferStatus.Enabled = False
            DateTimePickerOfferAccept.Enabled = False
            DateTimePickerJoining.Enabled = False
            DateTimePickerInvite.Enabled = False
            DateTimePickerVisit.Enabled = False
            ComboBoxInviteGoa.Enabled = False
            TextBoxVisitCost.Enabled = False
            ComboBoxRejectedBy.Enabled = False
            ComboBoxReason.Enabled = False

        ElseIf TextBoxPApplicationStatus.Text = "SHARED" Or TextBoxPApplicationStatus.Text = "Shared" Then
            DateTimePickerPScreeningDate.Enabled = True
            DateTimePickerShare.Enabled = True
            DateTimePickerInterview.Enabled = False
            DateTimePickerOffer.Enabled = False
            ComboBoxOfferStatus.Enabled = False
            DateTimePickerOfferAccept.Enabled = False
            DateTimePickerJoining.Enabled = False
            DateTimePickerInvite.Enabled = True
            DateTimePickerVisit.Enabled = True
            ComboBoxInviteGoa.Enabled = True
            TextBoxVisitCost.Enabled = True
            ComboBoxRejectedBy.Enabled = False
            ComboBoxReason.Enabled = False

        ElseIf TextBoxPApplicationStatus.Text = "APPROVED" Or TextBoxPApplicationStatus.Text = "Approved" Then
            DateTimePickerPScreeningDate.Enabled = True
            DateTimePickerShare.Enabled = True
            DateTimePickerInterview.Enabled = True
            DateTimePickerOffer.Enabled = False
            ComboBoxOfferStatus.Enabled = False
            DateTimePickerOfferAccept.Enabled = False
            DateTimePickerJoining.Enabled = False
            DateTimePickerInvite.Enabled = True
            DateTimePickerVisit.Enabled = True
            ComboBoxInviteGoa.Enabled = True
            TextBoxVisitCost.Enabled = True
            ComboBoxRejectedBy.Enabled = False
            ComboBoxReason.Enabled = False


        ElseIf TextBoxPApplicationStatus.Text = "OFFERED" Or TextBoxPApplicationStatus.Text = "Offered" Then
            DateTimePickerPScreeningDate.Enabled = True
            DateTimePickerShare.Enabled = True
            DateTimePickerInterview.Enabled = True
            DateTimePickerOffer.Enabled = True
            ComboBoxOfferStatus.Enabled = False
            DateTimePickerOfferAccept.Enabled = True
            DateTimePickerJoining.Enabled = False
            DateTimePickerInvite.Enabled = True
            DateTimePickerVisit.Enabled = True
            ComboBoxInviteGoa.Enabled = True
            TextBoxVisitCost.Enabled = True
            ComboBoxRejectedBy.Enabled = False
            ComboBoxReason.Enabled = False

        ElseIf TextBoxPApplicationStatus.Text = "TO JOIN" Or TextBoxPApplicationStatus.Text = "To Join" Then
            DateTimePickerPScreeningDate.Enabled = True
            DateTimePickerShare.Enabled = True
            DateTimePickerInterview.Enabled = True
            DateTimePickerOffer.Enabled = True
            ComboBoxOfferStatus.Enabled = False
            DateTimePickerOfferAccept.Enabled = True
            DateTimePickerJoining.Enabled = True
            DateTimePickerInvite.Enabled = True
            DateTimePickerVisit.Enabled = True
            ComboBoxInviteGoa.Enabled = True
            TextBoxVisitCost.Enabled = True
            ComboBoxRejectedBy.Enabled = False
            ComboBoxReason.Enabled = False

        ElseIf TextBoxPApplicationStatus.Text = "JOINED" Or TextBoxPApplicationStatus.Text = "Joined" Then
            DateTimePickerPScreeningDate.Enabled = True
            DateTimePickerShare.Enabled = True
            DateTimePickerInterview.Enabled = True
            DateTimePickerOffer.Enabled = True
            ComboBoxOfferStatus.Enabled = False
            DateTimePickerOfferAccept.Enabled = True
            DateTimePickerJoining.Enabled = True
            DateTimePickerInvite.Enabled = True
            DateTimePickerVisit.Enabled = True
            ComboBoxInviteGoa.Enabled = True
            TextBoxVisitCost.Enabled = True
            ComboBoxRejectedBy.Enabled = False
            ComboBoxReason.Enabled = False

        ElseIf TextBoxPApplicationStatus.Text = "REJECT" Or TextBoxPApplicationStatus.Text = "Reject" Then
            DateTimePickerPScreeningDate.Enabled = True
            DateTimePickerShare.Enabled = False
            DateTimePickerInterview.Enabled = False
            DateTimePickerOffer.Enabled = False
            ComboBoxOfferStatus.Enabled = False
            DateTimePickerOfferAccept.Enabled = False
            DateTimePickerJoining.Enabled = False
            DateTimePickerInvite.Enabled = True
            DateTimePickerVisit.Enabled = True
            ComboBoxInviteGoa.Enabled = True
            TextBoxVisitCost.Enabled = True
            ComboBoxRejectedBy.Enabled = True
            ComboBoxReason.Enabled = True

        ElseIf TextBoxPApplicationStatus.Text = "OFFER DECLINED" Or TextBoxPApplicationStatus.Text = "Offer Declined" Then
            DateTimePickerPScreeningDate.Enabled = True
            DateTimePickerShare.Enabled = True
            DateTimePickerInterview.Enabled = True
            DateTimePickerOffer.Enabled = True
            ComboBoxOfferStatus.Enabled = False
            DateTimePickerOfferAccept.Enabled = True
            DateTimePickerJoining.Enabled = False
            DateTimePickerInvite.Enabled = True
            DateTimePickerVisit.Enabled = True
            ComboBoxInviteGoa.Enabled = True
            TextBoxVisitCost.Enabled = True
            ComboBoxRejectedBy.Enabled = False
            ComboBoxReason.Enabled = True

        End If

    End Sub



    Private Sub TextBoxAcceptedCTC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxAcceptedCTC.KeyPress


        'If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then e.KeyChar = ""

        If (Not e.KeyChar = ChrW(Keys.Back) And ("0123456789").IndexOf(e.KeyChar) = -1) Or (e.KeyChar = "." And Trim(TextBoxAcceptedCTC.Text).ToCharArray().Count(Function(c) c = ".") > 0) Then
            e.Handled = True
        End If

    End Sub



    Private Sub TextBoxVisitCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxVisitCost.KeyPress
        If (Not e.KeyChar = ChrW(Keys.Back) And ("0123456789").IndexOf(e.KeyChar) = -1) Or (e.KeyChar = "." And Trim(TextBoxVisitCost.Text).ToCharArray().Count(Function(c) c = ".") > 0) Then
            e.Handled = True
        End If
    End Sub



    Private Sub ComboBoxPJobID_Leave(sender As Object, e As EventArgs) Handles ComboBoxPJobID.Leave
        'ComboBoxPJobID_SelectedIndexChanged(sender, e)

        '-------- Check If Job ID already exist in database -------------------------
        Try
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.Close()
            SQLConn.Open()
            Dim cmd As String
            cmd = "SELECT Count(*) FROM JobTable Where Job_ID = '" & ComboBoxPJobID.Text & "'"
            SQLComm.CommandText = cmd
            If ComboBoxPJobID.Text = "" Then
            ElseIf SQLComm.ExecuteScalar <= 0 Then
                MessageBox.Show("Invalid Job ID !!!.")
                ComboBoxPJobID.Focus()
                ComboBoxPJobID.SelectAll()
                SQLConn.Close()
                SQLComm.Parameters.Clear()
                ComboBoxPJobID.DataBindings.Clear()
                Exit Sub
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

    Private Sub ComboBoxAppID_Leave(sender As Object, e As EventArgs) Handles ComboBoxAppID.Leave
        'ComboBoxAppID_SelectedIndexChanged(sender, e)
        '-------- Check If Application ID already exist in database -------------------------
        Try
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.Close()
            SQLConn.Open()
            Dim cmd As String
            cmd = "SELECT Count(*) FROM ApplicationTable Where Application_ID = '" & ComboBoxAppID.Text & "' AND Job_ID = '" & ComboBoxPJobID.Text & "'"
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
            End If
            SQLComm.Parameters.Clear()
            SQLConn.Dispose()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
            SQLConn.Dispose()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txt_Search_TextChanged(sender As Object, e As EventArgs) Handles txt_Search.TextChanged

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub ButtonProcessAddNew_Click(sender As Object, e As EventArgs) Handles ButtonProcessAddNew.Click
        Try
            SQLConn.Close()
            Dim ConnStr As String
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString

            '-------- Check If Candidate already exist in database with same Application ID -------------------------
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()
            Dim cmd As String
            cmd = "SELECT Count(*) FROM ApplicationTable Where Application_ID = '" & Trim(ComboBoxAppID.Text) & "'"
            SQLComm.CommandText = cmd

            If ComboBoxPJobID.Text = "" Then
                MessageBox.Show("Please Select Job ID")
                ComboBoxPJobID.Focus()
            ElseIf TextBoxPJobStatus.Text <> "OPEN" And TextBoxPJobStatus.Text <> "OFFERED" AndAlso TextBoxPJobStatus.Text <> "Uncategorized" Then
                MessageBox.Show("Job Status is " & TextBoxPJobStatus.Text & " !!!. Please Select another Job ID")
                ComboBoxPJobID.Focus()
            ElseIf ComboBoxChangeStatus.Text = "" Then
                MessageBox.Show("Please Select Status")
                ComboBoxChangeStatus.Focus()
            ElseIf DateTimePickerPOpenDate.Value > DateTimePickerPScreeningDate.Value Then
                MessageBox.Show("Please check Job Open Date. Job Open Date must be less than Candidate Screening Date. !!!")
                DateTimePickerPScreeningDate.Focus()
                Exit Sub
            ElseIf DateTimePickerPScreeningDate.Value <= #1/1/1900# Then
                MessageBox.Show("Please Select Screening Date")
                DateTimePickerPScreeningDate.Focus()
            ElseIf ComboBoxPResumeSource.Text = "" Then
                MessageBox.Show("Plese Select Resume Source")
                ComboBoxPResumeSource.Focus()
            ElseIf ComboBoxPLocation.Text = "" Then
                MessageBox.Show("Plese Enter Candidate Location")
                ComboBoxPLocation.Focus()
            ElseIf TextBoxPCandidateName.Text = "" Then
                MessageBox.Show("Plese Enter Candidate Name")
                TextBoxPCandidateName.Focus()
            ElseIf TextBoxPEmail.Text = "" Then
                MessageBox.Show("Please Enter Candidate Email address")
                TextBoxPEmail.Focus()
            ElseIf TextBoxPMobile.Text = "" Then
                MessageBox.Show("Plese Enter Phone Number")
                TextBoxPMobile.Focus()
            ElseIf ComboBoxCRecruiter.Text = "" Then
                MessageBox.Show("Plese Select Recruiter Name")
                ComboBoxCRecruiter.Focus()

            ElseIf ComboBoxChangeStatus.Text = "SHARED" And DateTimePickerShare.Value <= #1/1/1900# Then
                MessageBox.Show("Please Select Share Date")
                DateTimePickerShare.Focus()
            ElseIf ComboBoxChangeStatus.Text = "SHARED" AndAlso DateTimePickerShare.Value < DateTimePickerPScreeningDate.Value Then
                MessageBox.Show("Share Date must be greater than Screening Date")
                DateTimePickerShare.Focus()
            ElseIf ComboBoxChangeStatus.Text = "APPROVED" And DateTimePickerInterview.Value <= #1/1/1900# Then
                MessageBox.Show("Please Select Interview Date")
                DateTimePickerInterview.Focus()
            ElseIf ComboBoxChangeStatus.Text = "APPROVED" And DateTimePickerShare.Value <= #1/1/1900# Then
                MessageBox.Show("Please Select Share Date")
                DateTimePickerShare.Focus()
            ElseIf ComboBoxChangeStatus.Text = "APPROVED" AndAlso DateTimePickerInterview.Value < DateTimePickerShare.Value Then
                MessageBox.Show("Interview Date must be greater than Share Date")
                DateTimePickerInterview.Focus()
            ElseIf ComboBoxChangeStatus.Text = "APPROVED" AndAlso DateTimePickerShare.Value < DateTimePickerPScreeningDate.Value Then
                MessageBox.Show("Share Date must be greater than Screening Date")
                DateTimePickerShare.Focus()
            ElseIf ComboBoxVisited.Text = "Yes" And ComboBoxInviteGoa.Text <> "Yes" Then
                MessageBox.Show("Please Select Invite")
                ComboBoxInviteGoa.Focus()
            ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value <= #1/1/1900# Then
                MessageBox.Show("Please Select Invite Date")
                DateTimePickerInvite.Focus()
            ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value <= #1/1/1900# Then
                MessageBox.Show("Please Select Visit Date")
                DateTimePickerVisit.Focus()
            ElseIf ComboBoxInviteGoa.Text = "Yes" And DateTimePickerInvite.Value < DateTimePickerShare.Value Then
                MessageBox.Show("Invite Date must be greater than Share Date")
                DateTimePickerInvite.Focus()
            ElseIf ComboBoxVisited.Text = "Yes" And DateTimePickerVisit.Value < DateTimePickerInvite.Value Then
                MessageBox.Show("Visit Date must be greater than Invite Date")
                DateTimePickerVisit.Focus()
            ElseIf ComboBoxChangeStatus.Text = "REJECT" And ComboBoxRejectedBy.Text = "" Then
                MessageBox.Show("Please Select Rejected By")
                ComboBoxRejectedBy.Focus()
            ElseIf ComboBoxChangeStatus.Text = "REJECT" And ComboBoxReason.Text = "" Then
                MessageBox.Show("Please Select Reason for Reject")
                ComboBoxReason.Focus()
            ElseIf ComboBoxChangeStatus.Text = "REJECT" And DateTimePickerShare.Value > #1/1/1900# And DateTimePickerShare.Value < DateTimePickerPScreeningDate.Value Then
                MessageBox.Show("Share Date must be greater than Screening Date")
                DateTimePickerShare.Focus()
            ElseIf ComboBoxChangeStatus.Text = "REJECT" And DateTimePickerInterview.Value > #1/1/1900# And DateTimePickerInterview.Value < DateTimePickerShare.Value Then
                MessageBox.Show("Interview Date must be greater than Share Date")
                DateTimePickerInterview.Focus()
            ElseIf ComboBoxChangeStatus.Text = "REJECT" And DateTimePickerInterview.Value > #1/1/1900# And DateTimePickerInterview.Value < DateTimePickerPScreeningDate.Value Then
                MessageBox.Show("Interview Date must be greater than Screening Date")
                DateTimePickerInterview.Focus()
            ElseIf ComboBoxNextSteps.Text = "" Then
                MessageBox.Show("Please Select 'Assign To' Tag. !!!")
                ComboBoxNextSteps.Focus()
            ElseIf SQLComm.ExecuteScalar > 0 Then
                MessageBox.Show("You already added '" & TextBoxPCandidateName.Text.Trim() & "' awhile ago. !!!. Application ID is " & ComboBoxAppID.Text & ".")
                SQLComm.CommandText = ""
                SQLConn.Dispose()
                Exit Sub

            Else

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
                        ComboBoxAppID.Text = DR("MAXIMUM").ToString
                        newNumber = CInt(Val(ComboBoxAppID.Text))
                        FirstName = ComboBoxCRecruiter.Text.Substring(0, 2) & "-"
                        ComboBoxAppID.Text = FirstName.ToUpper & CStr(newNumber) + 1
                    End While
                End If
                SQLConn.Close()

                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                SQLConn.Open()
                SQLComm.CommandText = ""
                'SQLComm.CommandText = "INSERT INTO ApplicationTable(S_NO,Job_ID,Job_Status,Job_OpenDate,Job_Position,Job_Category,Application_ID,Application_Status,Recruiter_Name,Candidate_Name,E_Mail,Phone,Location,Resume_Source,Experience,Screening,Screening_Date,Elapsed_Time,Application_Stage,Change_Job_ID) VALUES(@S_NO,@Job_ID,@Job_Status,@Job_OpenDate,@Job_Position,@Job_Category,@Application_ID,@Application_Status,@Recruiter_Name,@Candidate_Name,@E_Mail,@Phone,@Location,@Resume_Source,@Experience,@Screening,@Screening_Date,@Elapsed_Time,@Application_Stage,@Change_Job_ID)"

                SQLComm.CommandText = "INSERT INTO ApplicationTable(S_NO,Job_ID,Job_Status,Job_OpenDate,Job_Position,Job_Category,Application_ID,Application_Status,Recruiter_Name,Candidate_Name,E_Mail,Phone,Location,Resume_Source,Experience,Current_CTC,Screening,Screening_Date,Shared,Shared_Date,Interview,Interview_Date,Invited,Invited_Date,Visited,Visited_Date,Visit_Cost,Offer,Offer_Date,Offer_Accepted,Offer_Accepted_Date,Offer_Status,Joining,Joining_Date,Rejected,Elapsed_Time,Application_Stage,Change_Job_ID,Old_Job_ID,Decline_Reason,Rejected_By,Company1,Last_Modified,Next_Steps,Comments,Notice_Period) VALUES(@S_NO,@Job_ID,@Job_Status,@Job_OpenDate,@Job_Position,@Job_Category,@Application_ID,@Application_Status,@Recruiter_Name,@Candidate_Name,@E_Mail,@Phone,@Location,@Resume_Source,@Experience,@Current_CTC,@Screening,@Screening_Date,@Shared,@Shared_Date,@Interview,@Interview_Date,@Invited,@Invited_Date,@Visited,@Visited_Date,@Visit_Cost,@Offer,@Offer_Date,@Offer_Accepted,@Offer_Accepted_Date,@Offer_Status,@Joining,@Joining_Date,@Rejected,@Elapsed_Time,@Application_Stage,@Change_Job_ID,@Old_Job_ID,@Decline_Reason,@Rejected_By,@Company1,@Last_Modified,@Next_Steps,@Comments,@Notice_Period)"

                SQLComm.Parameters.AddWithValue("S_NO", CStr(newNumber) + 1)
                SQLComm.Parameters.AddWithValue("Job_ID", ComboBoxPJobID.Text)
                SQLComm.Parameters.AddWithValue("Job_Status", TextBoxPJobStatus.Text)
                SQLComm.Parameters.AddWithValue("Job_OpenDate", DateTimePickerPOpenDate.Value)
                SQLComm.Parameters.AddWithValue("Job_Position", TextBoxPJobPosition.Text)
                SQLComm.Parameters.AddWithValue("Job_Category", New SqlCommand("SELECT Category FROM JobTable Where Job_ID = '" & Trim(ComboBoxPJobID.Text) & "'", SQLConn).ExecuteScalar)
                SQLComm.Parameters.AddWithValue("Application_ID", ComboBoxAppID.Text)
                SQLComm.Parameters.AddWithValue("Application_Status", ComboBoxChangeStatus.Text)
                SQLComm.Parameters.AddWithValue("Recruiter_Name", ComboBoxCRecruiter.Text)
                SQLComm.Parameters.AddWithValue("Candidate_Name", StrConv(Trim(TextBoxPCandidateName.Text), VbStrConv.ProperCase))
                SQLComm.Parameters.AddWithValue("E_Mail", If(String.IsNullOrWhiteSpace(Trim(TextBoxPEmail.Text)), DBNull.Value, Trim(TextBoxPEmail.Text)))
                SQLComm.Parameters.AddWithValue("Phone", If(String.IsNullOrWhiteSpace(Trim(TextBoxPMobile.Text)), DBNull.Value, Trim(TextBoxPMobile.Text)))
                SQLComm.Parameters.AddWithValue("Location", If(String.IsNullOrWhiteSpace(Trim(ComboBoxPLocation.Text)), DBNull.Value, Trim(ComboBoxPLocation.Text)))
                SQLComm.Parameters.AddWithValue("Resume_Source", ComboBoxPResumeSource.Text)
                SQLComm.Parameters.AddWithValue("Experience", If(String.IsNullOrWhiteSpace(TextBoxPExperience.Text.Trim()), DBNull.Value, TextBoxPExperience.Text.Trim()))
                SQLComm.Parameters.AddWithValue("Current_CTC", If(String.IsNullOrWhiteSpace(TextBoxCurrentCTC.Text.Trim()), DBNull.Value, TextBoxCurrentCTC.Text.Trim()))
                SQLComm.Parameters.AddWithValue("Accepted_CTC", If(String.IsNullOrWhiteSpace(TextBoxAcceptedCTC.Text.Trim()), DBNull.Value, TextBoxAcceptedCTC.Text.Trim()))

                SQLComm.Parameters.AddWithValue("Screening", "Yes")
                SQLComm.Parameters.AddWithValue("Screening_Date", DateTimePickerPScreeningDate.Value.Date)

                If DateTimePickerShare.Value <= #1/1/1900# Then
                    SQLComm.Parameters.AddWithValue("Shared", "No")
                    SQLComm.Parameters.AddWithValue("Shared_Date", DateTimePickerShare.Value.Date)
                Else
                    SQLComm.Parameters.AddWithValue("Shared", "Yes")
                    SQLComm.Parameters.AddWithValue("Shared_Date", DateTimePickerShare.Value.Date)
                End If
                If DateTimePickerInterview.Value <= #1/1/1900# Then
                    SQLComm.Parameters.AddWithValue("Interview", "No")
                    SQLComm.Parameters.AddWithValue("Interview_Date", DateTimePickerInterview.Value.Date)
                Else
                    SQLComm.Parameters.AddWithValue("Interview", "Yes")
                    SQLComm.Parameters.AddWithValue("Interview_Date", DateTimePickerInterview.Value.Date)
                End If

                'SQLComm.Parameters.AddWithValue("Shared", "No")
                'SQLComm.Parameters.AddWithValue("Shared_Date", #1/1/1900#)
                'SQLComm.Parameters.AddWithValue("Interview", "No")
                'SQLComm.Parameters.AddWithValue("Interview_Date", #1/1/1900#)
                SQLComm.Parameters.AddWithValue("Invited", ComboBoxInviteGoa.Text)
                SQLComm.Parameters.AddWithValue("Invited_Date", DateTimePickerInvite.Value.Date)
                SQLComm.Parameters.AddWithValue("Visited", ComboBoxVisited.Text)
                SQLComm.Parameters.AddWithValue("Visited_Date", DateTimePickerVisit.Value.Date)
                SQLComm.Parameters.AddWithValue("Visit_Cost", TextBoxVisitCost.Text)
                SQLComm.Parameters.AddWithValue("Offer", "No")
                SQLComm.Parameters.AddWithValue("Offer_Date", #1/1/1900#)
                SQLComm.Parameters.AddWithValue("Offer_Accepted", "No")
                SQLComm.Parameters.AddWithValue("Offer_Accepted_Date", #1/1/1900#)
                SQLComm.Parameters.AddWithValue("Offer_Status", "NA")
                SQLComm.Parameters.AddWithValue("Joining", "No")
                SQLComm.Parameters.AddWithValue("Joining_Date", #1/1/1900#)
                If ComboBoxChangeStatus.Text <> "REJECT" Then
                    SQLComm.Parameters.AddWithValue("Rejected", "No")
                Else
                    SQLComm.Parameters.AddWithValue("Rejected", "Yes")
                End If

                SQLComm.Parameters.AddWithValue("Elapsed_Time", (DateTime.Now).Subtract(DateTimePickerPOpenDate.Value).Days + 1)

                If DateTimePickerOffer.Value > #1/1/1900# Then
                    SQLComm.Parameters.AddWithValue("Application_Stage", "OFFER")
                ElseIf DateTimePickerInterview.Value > #1/1/1900# Then
                    SQLComm.Parameters.AddWithValue("Application_Stage", "INTERVIEW")
                ElseIf DateTimePickerShare.Value > #1/1/1900# Then
                    SQLComm.Parameters.AddWithValue("Application_Stage", "SHARED")
                Else
                    SQLComm.Parameters.AddWithValue("Application_Stage", "SCREENING")
                End If

                'SQLComm.Parameters.AddWithValue("Application_Stage", "SCREENING")

                SQLComm.Parameters.AddWithValue("Change_Job_ID", "No")
                SQLComm.Parameters.AddWithValue("Old_Job_ID", "NA")

                If ComboBoxChangeStatus.Text <> "REJECT" Then
                    SQLComm.Parameters.AddWithValue("Decline_Reason", "NA")
                    SQLComm.Parameters.AddWithValue("Rejected_By", "NA")
                Else
                    SQLComm.Parameters.AddWithValue("Decline_Reason", ComboBoxReason.Text)
                    SQLComm.Parameters.AddWithValue("Rejected_By", ComboBoxRejectedBy.Text)
                End If

                SQLComm.Parameters.AddWithValue("Company1", TextBoxPCompanyName.Text)
                SQLComm.Parameters.AddWithValue("Last_Modified", Date.Now)
                SQLComm.Parameters.AddWithValue("Next_Steps", ComboBoxNextSteps.Text)
                SQLComm.Parameters.AddWithValue("Comments", If(String.IsNullOrWhiteSpace(TextBoxComments.Text.Trim()), DBNull.Value, TextBoxComments.Text.Trim()))
                SQLComm.Parameters.AddWithValue("Notice_Period", If(String.IsNullOrWhiteSpace(Trim(ComboBoxNoticePeriod.Text)), DBNull.Value, Trim(ComboBoxNoticePeriod.Text)))

                SQLComm.ExecuteNonQuery()
                SQLComm.Parameters.Clear()
                TextBoxPApplicationStatus.Text = ComboBoxChangeStatus.Text
                MessageBox.Show("Saved !!!")
                Dim tempJobID, tempAppID As String
                tempJobID = ComboBoxPJobID.Text
                tempAppID = ComboBoxAppID.Text
                ButtonProcessUpdate.Enabled = True
                CheckBoxNewCandidate.Checked = False
                ComboBoxPJobID.Text = tempJobID
                ComboBoxAppID.Text = tempAppID
                SQLConn.Close()
                'ButtonProcessAddNew.Enabled = False

                '------ Count of Total No. of Application Received and Update in JobTable ---------------------
                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                Dim AppRec As Integer
                SQLConn.Open()
                SQLComm = New SqlCommand("SELECT Count(*) FROM ApplicationTable WHERE JOB_ID= '" & ComboBoxPJobID.Text & "'", SQLConn)
                SQLComm.CommandTimeout = 30
                AppRec = SQLComm.ExecuteScalar
                SQLComm.CommandText = ("UPDATE JobTable SET Total_Application = @Total_Application Where Job_ID = '" & ComboBoxPJobID.Text & "'")
                SQLComm.Parameters.Add("@Total_Application", SqlDbType.Int).Value = AppRec
                SQLComm.ExecuteNonQuery()
                SQLConn.Close()
                SQLComm.Parameters.Clear()

                '----------------------- refresh in datagridview ----------------------------------
                Dim ds1 As New DataSet
                SQLConn.Open()
                If FormTop.ComboBoxAppDetailsRecruiter.Text = "ALL" Then
                    SQLComm = New SqlCommand(("Select * from ApplicationTable"), SQLConn)
                Else
                    SQLComm = New SqlCommand(("Select * from ApplicationTable where Recruiter_Name = '" & FormTop.ComboBoxAppDetailsRecruiter.Text & "'"), SQLConn)
                End If
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

            End If

            'End If
            SQLConn.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Dispose()
            SQLComm.Dispose()
        End Try

    End Sub

    Private Sub CheckBoxNewCandidate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxNewCandidate.CheckedChanged
        If CheckBoxNewCandidate.Checked = True Then
            ButtonProcessUpdate.Enabled = False
            ButtonProcessAddNew.Enabled = True
            ComboBoxAppID.Enabled = False
            ComboBoxPJobID.SelectedIndex = -1
            ComboBoxPJobID.Focus()
            ComboBoxAppID.SelectedIndex = -1
            DateTimePickerPScreeningDate.Value = Date.Today
            ComboBoxCRecruiter.SelectedIndex = -1
            ComboBoxRejectedBy.SelectedIndex = -1
            ComboBoxReason.SelectedIndex = -1
            ComboBoxNextSteps.SelectedIndex = -1
            ComboBoxInviteGoa.Text = "No"
            ComboBoxVisited.Text = "No"
            DateTimePickerOffer.Enabled = False
            DateTimePickerOfferAccept.Enabled = False
            ComboBoxOfferStatus.Text = "NA"
            DateTimePickerJoining.Enabled = False
            TextBoxVisitCost.Text = ""
            TextBoxComments.Text = ""

            '------------------- Load ComboBox Items ------------------
            ComboBoxChangeStatus.Items.Clear()
            ComboBoxChangeStatus.Items.Add("SCREENED")
            ComboBoxChangeStatus.Items.Add("SHARED")
            ComboBoxChangeStatus.Items.Add("APPROVED")
            ComboBoxChangeStatus.Items.Add("REJECT")
            '-------------------------------------------------------------
            ComboBoxChangeStatus.SelectedIndex = 0

        Else

            ButtonProcessUpdate.Enabled = True
            ButtonProcessAddNew.Enabled = False
            ComboBoxAppID.Enabled = True
            ComboBoxPJobID.SelectedIndex = -1
            ComboBoxPJobID.Focus()
            ComboBoxAppID.SelectedIndex = -1
            DateTimePickerPScreeningDate.Value = Date.Today
            ComboBoxCRecruiter.SelectedIndex = -1
            ComboBoxRejectedBy.SelectedIndex = -1
            ComboBoxReason.SelectedIndex = -1
            ComboBoxNextSteps.SelectedIndex = -1


            ''------------------- Load ComboBox Items ------------------
            ComboBoxChangeStatus.Items.Clear()
            'ComboBoxChangeStatus.Items.Add("SCREENED")
            'ComboBoxChangeStatus.Items.Add("SHARED")
            'ComboBoxChangeStatus.Items.Add("APPROVED")
            'ComboBoxChangeStatus.Items.Add("REJECT")
            ''-------------------------------------------------------------
            ComboBoxChangeStatus.SelectedIndex = -1

        End If
    End Sub

    Private Sub TextBoxPEmail_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPEmail.TextChanged

    End Sub

    Private Sub TextBoxPEmail_Leave(sender As Object, e As EventArgs) Handles TextBoxPEmail.Leave
        '-------- Check If Candidate already exist in database -------------------------
        Try
            If CheckBoxNewCandidate.Checked = False Then
            Else

                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString
                SQLConn.Close()
                SQLConn.Open()
                Dim cmd As String
                cmd = "SELECT Count(*) FROM ApplicationTable Where E_Mail <> '' And E_Mail = '" & Trim(TextBoxPEmail.Text) & "'"
                SQLComm.CommandText = cmd
                If SQLComm.ExecuteScalar > 0 Then

                    Select Case MessageBox.Show("Email ID already exist in Database. Do you want to make duplicate ?", "Warning !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        Case MsgBoxResult.Yes
                        Case MsgBoxResult.Cancel
                            TextBoxPEmail.Focus()
                            TextBoxPEmail.SelectAll()
                            SQLConn.Close()
                            SQLComm.Parameters.Clear()
                            TextBoxPEmail.DataBindings.Clear()
                            Exit Sub
                        Case MsgBoxResult.No
                            TextBoxPEmail.Focus()
                            TextBoxPEmail.SelectAll()
                            SQLConn.Close()
                            SQLComm.Parameters.Clear()
                            TextBoxPEmail.DataBindings.Clear()
                            Exit Sub
                    End Select

                Else
                    SQLConn.Close()
                End If
            End If
            SQLComm.Parameters.Clear()
            SQLConn.Dispose()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
            SQLConn.Dispose()
        End Try
    End Sub

    Private Sub TextBoxPMobile_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPMobile.TextChanged

    End Sub

    Private Sub TextBoxPMobile_Leave(sender As Object, e As EventArgs) Handles TextBoxPMobile.Leave
        '-------- Check If Candidate already exist in database -------------------------
        Try
            If CheckBoxNewCandidate.Checked = False Then
            Else
                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString
                SQLConn.Close()
                SQLConn.Open()
                Dim cmd As String
                cmd = "SELECT Count(*) FROM ApplicationTable Where Phone <> '' and Phone = '" & Trim(TextBoxPMobile.Text) & "'"
                SQLComm.CommandText = cmd
                If SQLComm.ExecuteScalar > 0 Then

                    Select Case MessageBox.Show("Phone number already exist in Database. Do you want to make duplicate ?", "Warning !!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        Case MsgBoxResult.Yes
                        Case MsgBoxResult.Cancel
                            TextBoxPMobile.Focus()
                            TextBoxPMobile.SelectAll()
                            SQLConn.Close()
                            SQLComm.Parameters.Clear()
                            TextBoxPMobile.DataBindings.Clear()
                            Exit Sub
                        Case MsgBoxResult.No
                            TextBoxPMobile.Focus()
                            TextBoxPMobile.SelectAll()
                            SQLConn.Close()
                            SQLComm.Parameters.Clear()
                            TextBoxPMobile.DataBindings.Clear()
                            Exit Sub
                    End Select

                Else
                    SQLConn.Close()
                End If
            End If
            SQLComm.Parameters.Clear()
            SQLConn.Dispose()

        Catch ex As Exception
            SQLConn.Dispose()
        End Try
    End Sub

    Private Sub ButtonProcessClear_Click(sender As Object, e As EventArgs) Handles ButtonProcessClear.Click
        ComboBoxPJobID.SelectedIndex = -1
    End Sub

    Private Sub Btn_search_Click(sender As Object, e As EventArgs) Handles Btn_search.Click
        Try
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim ds1 As New DataSet
            SQLConn.Open()
            'SQLComm = New sqlcommand("SELECT * FROM ApplicationTable WHERE Candidate_Name LIKE '%" & txt_Search.Text & "%'", SQLConn)
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
            txt_Search.Focus()
            SQLConn.Dispose()
            DataGridView1.Sort(DataGridView1.Columns(DataGridView1.ColumnCount - 1), direction:=ListSortDirection.Descending)

        Catch ex As Exception
            SQLConn.Close()
        SQLConn.Dispose()
        End Try
    End Sub

    Private Sub Btn_SaveNextSteps_Click(sender As Object, e As EventArgs) Handles Btn_SaveNextSteps.Click
        ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
        SQLConn.ConnectionString = ConnStr
        SQLComm.Connection = SQLConn

        If String.IsNullOrEmpty(ComboBoxAppID.Text) Then
            MessageBox.Show("Please Enter Application ID")
            ComboBoxAppID.Focus()
        ElseIf String.IsNullOrEmpty(ComboBoxNextSteps.Text) Then
            MessageBox.Show("Please Select 'Assign To' Tag !!!")
            ComboBoxNextSteps.Focus()
        Else
            SQLConn.Open()
            SQLComm.CommandText = ("UPDATE applicationtable SET Next_Steps = @Next_Steps,Last_Modified=@Last_Modified  Where Application_ID = '" & ComboBoxAppID.Text & "'")
            SQLComm.Parameters.Add("@Next_Steps", SqlDbType.Char).Value = ComboBoxNextSteps.Text
            SQLComm.Parameters.Add("@Last_Modified", SqlDbType.DateTime).Value = Date.Now
            SQLComm.ExecuteNonQuery()
            MessageBox.Show("Saved !!!")
            SQLComm.Parameters.Clear()
            'SQLConn.Dispose()
            '----------------------- refresh in datagridview ----------------------------------
            Dim ds1 As New DataSet
            'SQLConn.Open()
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

        End If
        SQLConn.Dispose()
    End Sub

    Private Sub TextBoxAcceptedCTC_TextChanged(sender As Object, e As EventArgs) Handles TextBoxAcceptedCTC.TextChanged

    End Sub

    Private Sub TextBoxVisitCost_TextChanged(sender As Object, e As EventArgs) Handles TextBoxVisitCost.TextChanged

    End Sub
End Class