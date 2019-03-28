Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System.Data.SqlClient
Public Class FormMain
    Dim SQLConn As New SqlConnection
    Dim SQLComm As New SqlCommand
    Private Sub btn_OpenPosition_Click(sender As Object, e As EventArgs) Handles btn_OpenPosition.Click

        For Each frm As Form In Me.MdiChildren
            If frm.Name = "FormTop" Then
            ElseIf frm.Name = "FormSearchJob" Then
            Else
                frm.Close()
            End If
        Next

        FormSearchJob.MdiParent = Me
        FormSearchJob.Show()
        btn_process.BackColor = Color.Honeydew
        btn_newcandidate.BackColor = Color.Honeydew
        btn_createjob.BackColor = Color.Honeydew
        btn_OpenPosition.BackColor = Color.Honeydew
        btn_application.BackColor = Color.Honeydew
        btn_ChangeJobID.BackColor = Color.Honeydew
        btn_ModifyJobPosition.BackColor = Color.Honeydew
        btn_Analysis.BackColor = Color.Honeydew
        Btn_DataBackup.BackColor = Color.Honeydew
        btn_OpenPosition.BackColor = SystemColors.GradientInactiveCaption
        btn_ExportData.BackColor = Color.Honeydew

        '------------------------------- Datagridview color formatting -----------------------------------------------------
        FormSearchJob.DataGridView1.RowsDefaultCellStyle.BackColor = Nothing
        Try
            For i As Integer = 0 To FormSearchJob.DataGridView1.Rows.Count - 1
                If FormSearchJob.DataGridView1.Item(6, i).Value = "JOINED" Then
                    FormSearchJob.DataGridView1.Item(6, i).Style.BackColor = Color.LightGreen
                    FormSearchJob.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf FormSearchJob.DataGridView1.Item(6, i).Value = "OFFERED" Then
                    FormSearchJob.DataGridView1.Item(6, i).Style.BackColor = Color.Orange
                    FormSearchJob.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Orange
                ElseIf FormSearchJob.DataGridView1.Item(6, i).Value = "CANCELLED" Then
                    FormSearchJob.DataGridView1.Item(6, i).Style.BackColor = Color.Red
                    FormSearchJob.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
                ElseIf FormSearchJob.DataGridView1.Item(6, i).Value = "ON-HOLD" Then
                    FormSearchJob.DataGridView1.Item(6, i).Style.BackColor = Color.LightSlateGray
                    FormSearchJob.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightSlateGray
                Else
                    FormSearchJob.DataGridView1.Item(6, i).Style.BackColor = Color.White
                    FormSearchJob.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If
            Next i
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
        '-------------------------------------------------------------------------------------------------------------------

    End Sub

    Private Sub btn_process_Click(sender As Object, e As EventArgs) Handles btn_process.Click

        'If Me.ActiveMdiChild IsNot Nothing Then
        '    ActiveMdiChild.Close()
        '    btn_process.BackColor = Color.Honeydew
        '    btn_newcandidate.BackColor = Color.Honeydew
        '    btn_createjob.BackColor = Color.Honeydew
        '    btn_OpenPosition.BackColor = Color.Honeydew
        '    btn_application.BackColor = Color.Honeydew
        '    btn_ChangeJobID.BackColor = Color.Honeydew
        '    btn_ModifyJobPosition.BackColor = Color.Honeydew
        '    btn_Analysis.BackColor = Color.Honeydew
        'Else
        'End If
        'FormTop.MdiParent = Me
        'FormTop.Show()
        For Each frm As Form In Me.MdiChildren
            If frm.Name <> "FormTop" Then
                frm.Close()
            Else
            End If
        Next
        FormProcess.MdiParent = Me
        FormProcess.Show()
        btn_process.BackColor = Color.Honeydew
        btn_newcandidate.BackColor = Color.Honeydew
        btn_createjob.BackColor = Color.Honeydew
        btn_OpenPosition.BackColor = Color.Honeydew
        btn_application.BackColor = Color.Honeydew
        btn_ChangeJobID.BackColor = Color.Honeydew
        btn_ModifyJobPosition.BackColor = Color.Honeydew
        btn_Analysis.BackColor = Color.Honeydew
        btn_process.BackColor = SystemColors.GradientInactiveCaption
        Btn_DataBackup.BackColor = Color.Honeydew
        btn_ExportData.BackColor = Color.Honeydew
    End Sub

    Public Sub btn_newcandidate_Click(sender As Object, e As EventArgs) Handles btn_newcandidate.Click

        For Each frm As Form In Me.MdiChildren
            If frm.Name <> "FormTop" Then
                frm.Close()
            Else
            End If
        Next
        FormCandidate.MdiParent = Me
        FormCandidate.Show()
        btn_process.BackColor = Color.Honeydew
        btn_newcandidate.BackColor = Color.Honeydew
        btn_createjob.BackColor = Color.Honeydew
        btn_OpenPosition.BackColor = Color.Honeydew
        btn_application.BackColor = Color.Honeydew
        btn_ChangeJobID.BackColor = Color.Honeydew
        btn_ModifyJobPosition.BackColor = Color.Honeydew
        btn_Analysis.BackColor = Color.Honeydew
        btn_newcandidate.BackColor = SystemColors.GradientInactiveCaption
        Btn_DataBackup.BackColor = Color.Honeydew
        btn_ExportData.BackColor = Color.Honeydew
    End Sub

    Private Sub btn_createjob_Click(sender As Object, e As EventArgs) Handles btn_createjob.Click

        For Each frm As Form In Me.MdiChildren
            If frm.Name <> "FormTop" Then
                frm.Close()
            Else
            End If
        Next
        FormPwd.MdiParent = Me
        FormPwd.Show()
        FormPwd.TextBox1.Focus()
        'FormCreateJob.MdiParent = Me
        'FormCreateJob.Show()
        btn_process.BackColor = Color.Honeydew
        btn_newcandidate.BackColor = Color.Honeydew
        btn_createjob.BackColor = Color.Honeydew
        btn_OpenPosition.BackColor = Color.Honeydew
        btn_application.BackColor = Color.Honeydew
        btn_ChangeJobID.BackColor = Color.Honeydew
        btn_ModifyJobPosition.BackColor = Color.Honeydew
        btn_Analysis.BackColor = Color.Honeydew
        Btn_DataBackup.BackColor = Color.Honeydew
        btn_ExportData.BackColor = Color.Honeydew
        btn_createjob.BackColor = SystemColors.GradientInactiveCaption
    End Sub

    Private Sub btn_application_Click(sender As Object, e As EventArgs) Handles btn_application.Click

        For Each frm As Form In Me.MdiChildren
            If frm.Name = "FormTop" Then
            ElseIf frm.Name = "FormApplications" Then
            Else
                frm.Close()
            End If
        Next
        FormApplications.MdiParent = Me
        FormApplications.Show()
        btn_process.BackColor = Color.Honeydew
        btn_newcandidate.BackColor = Color.Honeydew
        btn_createjob.BackColor = Color.Honeydew
        btn_OpenPosition.BackColor = Color.Honeydew
        btn_application.BackColor = Color.Honeydew
        btn_ChangeJobID.BackColor = Color.Honeydew
        btn_ModifyJobPosition.BackColor = Color.Honeydew
        btn_Analysis.BackColor = Color.Honeydew
        Btn_DataBackup.BackColor = Color.Honeydew
        btn_ExportData.BackColor = Color.Honeydew
        btn_application.BackColor = SystemColors.GradientInactiveCaption
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_ChangeJobID.Click

        For Each frm As Form In Me.MdiChildren
            If frm.Name <> "FormTop" Then
                frm.Close()
            Else
            End If
        Next
        FormChangeJobID.MdiParent = Me
        FormChangeJobID.Show()
        btn_process.BackColor = Color.Honeydew
        btn_newcandidate.BackColor = Color.Honeydew
        btn_createjob.BackColor = Color.Honeydew
        btn_OpenPosition.BackColor = Color.Honeydew
        btn_application.BackColor = Color.Honeydew
        btn_ChangeJobID.BackColor = Color.Honeydew
        btn_ModifyJobPosition.BackColor = Color.Honeydew
        btn_Analysis.BackColor = Color.Honeydew
        Btn_DataBackup.BackColor = Color.Honeydew
        btn_ExportData.BackColor = Color.Honeydew
        btn_ChangeJobID.BackColor = SystemColors.GradientInactiveCaption
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_ModifyJobPosition.Click

        For Each frm As Form In Me.MdiChildren
            If frm.Name <> "FormTop" Then
                frm.Close()
            Else
            End If
        Next
        FormModifyPositions.MdiParent = Me
        FormModifyPositions.Show()
        btn_process.BackColor = Color.Honeydew
        btn_newcandidate.BackColor = Color.Honeydew
        btn_createjob.BackColor = Color.Honeydew
        btn_OpenPosition.BackColor = Color.Honeydew
        btn_application.BackColor = Color.Honeydew
        btn_ChangeJobID.BackColor = Color.Honeydew
        btn_ModifyJobPosition.BackColor = Color.Honeydew
        btn_Analysis.BackColor = Color.Honeydew
        Btn_DataBackup.BackColor = Color.Honeydew
        btn_ExportData.BackColor = Color.Honeydew
        btn_ModifyJobPosition.BackColor = SystemColors.GradientInactiveCaption
    End Sub

    Private Sub FormMain_Load(sender, e) Handles MyBase.Load

        Me.Width = Screen.PrimaryScreen.Bounds.Width - 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height - 20

        Try
            Dim ConnStr As String = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            SQLConn.Open()
            Label_check_connection.Visible = False
            Button_Retry.Visible = False
            'MessageBox.Show("Database Connected...")
            SQLConn.Dispose()
            FormTop.MdiParent = Me
            FormTop.Show()
            btn_process.Enabled = True
            btn_newcandidate.Enabled = True
            btn_createjob.Enabled = True
            btn_OpenPosition.Enabled = True
            btn_application.Enabled = True
            btn_ChangeJobID.Enabled = True
            btn_ModifyJobPosition.Enabled = True
            btn_Analysis.Enabled = True
            Btn_DataBackup.Enabled = True
            btn_ExportData.Enabled = True
            btn_ModifyJobPosition.Enabled = True
        Catch ex As Exception
            If MessageBox.Show("SQL Database Connection Failed. Check Your Network Connection or Contact IT Team. !!!", "Network Error !!!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = DialogResult.Retry Then
                FormMain_Load(sender, e)
                Label_check_connection.Text = "SQL Database Not Connected..."
            Else
                Label_check_connection.Visible = True
                Button_Retry.Visible = True
                btn_process.Enabled = False
                btn_newcandidate.Enabled = False
                btn_createjob.Enabled = False
                btn_OpenPosition.Enabled = False
                btn_application.Enabled = False
                btn_ChangeJobID.Enabled = False
                btn_ModifyJobPosition.Enabled = False
                btn_Analysis.Enabled = False
                Btn_DataBackup.Enabled = False
                btn_ExportData.Enabled = False
                btn_ModifyJobPosition.Enabled = False
            End If

            SQLConn.Dispose()
            SQLComm.Dispose()
        End Try

    End Sub


    Private Sub btn_Analysis_Click(sender As Object, e As EventArgs) Handles btn_Analysis.Click

        For Each frm As Form In Me.MdiChildren
            If frm.Name <> "FormTop" Then
                frm.Close()
            Else
            End If
        Next
        FormAnalytics.MdiParent = Me
        FormAnalytics.Show()
        btn_process.BackColor = Color.Honeydew
        btn_newcandidate.BackColor = Color.Honeydew
        btn_createjob.BackColor = Color.Honeydew
        btn_OpenPosition.BackColor = Color.Honeydew
        btn_application.BackColor = Color.Honeydew
        btn_ChangeJobID.BackColor = Color.Honeydew
        btn_ModifyJobPosition.BackColor = Color.Honeydew
        btn_Analysis.BackColor = Color.Honeydew
        Btn_DataBackup.BackColor = Color.Honeydew
        btn_ExportData.BackColor = Color.Honeydew
        btn_Analysis.BackColor = SystemColors.GradientInactiveCaption

    End Sub


    Private Sub Btn_DataBackup_Click(sender As Object, e As EventArgs) Handles Btn_DataBackup.Click
        For Each frm As Form In Me.MdiChildren
            If frm.Name <> "FormTop" Then
                frm.Close()
            Else
            End If
        Next
        btn_process.BackColor = Color.Honeydew
        btn_newcandidate.BackColor = Color.Honeydew
        btn_createjob.BackColor = Color.Honeydew
        btn_OpenPosition.BackColor = Color.Honeydew
        btn_application.BackColor = Color.Honeydew
        btn_ChangeJobID.BackColor = Color.Honeydew
        btn_ModifyJobPosition.BackColor = Color.Honeydew
        btn_Analysis.BackColor = Color.Honeydew
        btn_Analysis.BackColor = Color.Honeydew
        btn_ExportData.BackColor = Color.Honeydew
        Btn_DataBackup.BackColor = SystemColors.GradientInactiveCaption

        '-------------- Data Backup -------------------------------------------
        'On Error Resume Next
        Try
            Dim DestinationPath As String
            Dim FileName As String
            Dim Fldr As New CommonOpenFileDialog
            Fldr.IsFolderPicker = True
            Fldr.Title = "Select Backup Destination Folder"
            If Fldr.ShowDialog() = DialogResult.OK Then
                DestinationPath = Fldr.FileName
            Else Exit Sub
            End If
            FileName = "Backup_Recruitment_Database_" & Format(Now, "dd-MMM-yyyy_hhmm")

            Dim sqlConnectionString As String = "Data Source=RK-PC;Initial Catalog=IHDatabase;Integrated Security=True"
            Dim conn As New SqlConnection(sqlConnectionString)
            conn.Open()

            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "BACKUP DATABASE IHDatabase TO DISK='" & DestinationPath & "\" & FileName & ".bak'"

            'cmd.CommandText = "BACKUP DATABASE IHDatabase TO DISK='E:\MyProject\IH\InnerHeads - SQL\Database\" & FileName & ".bak'"

            cmd.Connection = conn
            cmd.ExecuteNonQuery()
            conn.Dispose()

            MessageBox.Show("Successfully Backup Database !!!")
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try


    End Sub

    Private Sub btn_ExportData_Click(sender As Object, e As EventArgs) Handles btn_ExportData.Click
        For Each frm As Form In Me.MdiChildren
            If frm.Name <> "FormTop" Then
                frm.Close()
            Else
            End If
        Next
        btn_process.BackColor = Color.Honeydew
        btn_newcandidate.BackColor = Color.Honeydew
        btn_createjob.BackColor = Color.Honeydew
        btn_OpenPosition.BackColor = Color.Honeydew
        btn_application.BackColor = Color.Honeydew
        btn_ChangeJobID.BackColor = Color.Honeydew
        btn_ModifyJobPosition.BackColor = Color.Honeydew
        btn_Analysis.BackColor = Color.Honeydew
        btn_Analysis.BackColor = Color.Honeydew
        Btn_DataBackup.BackColor = Color.Honeydew
        btn_ExportData.BackColor = SystemColors.GradientInactiveCaption
        FormDataBackup.MdiParent = Me
        FormDataBackup.Show()
    End Sub

    Private Sub Btn_CTC_Calc_Click(sender As Object, e As EventArgs) Handles Btn_CTC_Calc.Click
        'For Each frm As Form In Me.MdiChildren
        '    If frm.Name <> "FormTop" Then
        '        frm.Close()
        '    Else
        '    End If
        'Next
        'btn_process.BackColor = Color.Honeydew
        'btn_newcandidate.BackColor = Color.Honeydew
        'btn_createjob.BackColor = Color.Honeydew
        'btn_OpenPosition.BackColor = Color.Honeydew
        'btn_application.BackColor = Color.Honeydew
        'btn_ChangeJobID.BackColor = Color.Honeydew
        'btn_ModifyJobPosition.BackColor = Color.Honeydew
        'btn_Analysis.BackColor = Color.Honeydew
        'btn_Analysis.BackColor = Color.Honeydew
        'Btn_DataBackup.BackColor = Color.Honeydew
        'btn_ExportData.BackColor = Color.Honeydew
        'Btn_CTC_Calc.BackColor = SystemColors.GradientInactiveCaption
        'FormCTCCalculator.MdiParent = Me
        FormCTCCalculator.Show()

    End Sub

    Private Sub Button_Retry_Click(sender As Object, e As EventArgs) Handles Button_Retry.Click
        Button_Retry.Visible = False
        'Label_check_connection.Text = "Connecting to database..."
        FormMain_Load(sender, e)
    End Sub
End Class
