Public Class FormPwd
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not TextBox1.Text = "ramaisgod" Then
            MessageBox.Show("Please Enter Correct Password !!!", "Password Required !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox1.Focus()
        Else
            Me.Close()
            FormCreateJob.MdiParent = FormMain
            FormCreateJob.Show()
            FormMain.btn_process.BackColor = Color.Honeydew
            FormMain.btn_newcandidate.BackColor = Color.Honeydew
            FormMain.btn_createjob.BackColor = Color.Honeydew
            FormMain.btn_OpenPosition.BackColor = Color.Honeydew
            FormMain.btn_application.BackColor = Color.Honeydew
            FormMain.btn_ChangeJobID.BackColor = Color.Honeydew
            FormMain.btn_ModifyJobPosition.BackColor = Color.Honeydew
            FormMain.btn_Analysis.BackColor = Color.Honeydew
            FormMain.Btn_DataBackup.BackColor = Color.Honeydew
            FormMain.btn_ExportData.BackColor = Color.Honeydew
            FormMain.btn_createjob.BackColor = SystemColors.GradientInactiveCaption
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub FormPwd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
    End Sub
End Class