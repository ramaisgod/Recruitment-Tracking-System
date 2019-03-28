Imports System.Data.SqlClient
Imports excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.IO
Imports System.ComponentModel


Public Class FormSearchJob
    Dim SQLConn As New SqlConnection
    Dim SQLComm As New SqlCommand

    Dim ConnStr As String
    Private Sub FormSearchJob_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DS_SQL_JobTable_FormSearchJob.JobTable' table. You can move, or remove it, as needed.
        Me.JobTableTableAdapter1.Fill(Me.DS_SQL_JobTable_FormSearchJob.JobTable)
        'TODO: This line of code loads data into the 'DS_SQL_JobTable_FormSearchJob.JobTable' table. You can move, or remove it, as needed.
        'Me.JobTableTableAdapter1.Fill(Me.DS_SQL_JobTable_FormSearchJob.JobTable)
        Try

            RowsCount.Text = DataGridView1.RowCount
            '------------------- Search By Desable -----------------------------------
            SearchByJobID.Enabled = False
            SearchByRecruiter.Enabled = False
            'SearchByStatus.Enabled = False
            SearchByCategory.Enabled = False
            SearchByCompany.Enabled = False
            SearchByJobPosition.Enabled = False
            SearchByPositionLevel.Enabled = False
            'FilterStatus.Enabled = False

            '-------------------------------------------------------------------------
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
                    Me.SearchByJobID.Items.Add(DR("Job_ID"))
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
                    Me.SearchByRecruiter.Items.Add(DR("RecruiterName"))
                    'Me.FilterRecruiter.Items.Add(DR("RecruiterName"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()

            '------- Add List Item in Job Position 
            SQLComm = New SqlCommand("SELECT DISTINCT Job_Position FROM JobTable", SQLConn)
            SQLComm.CommandTimeout = 30
            DR = SQLComm.ExecuteReader()
            If DR.HasRows = True Then
                While DR.Read()
                    Me.SearchByJobPosition.Items.Add(DR("Job_Position"))
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
                    Me.SearchByCategory.Items.Add(DR("Category_Name"))
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
                    Me.SearchByCompany.Items.Add(DR("CompanyName"))
                End While
                DR.Close()
            End If
            SQLComm.ResetCommandTimeout()
            '----------------------------------------
            SQLConn.Close()

            SearchByRecruiter.Text = FormTop.ComboBoxAppDetailsRecruiter.Text

            DataGridView1.Sort(DataGridView1.Columns(2), direction:=ListSortDirection.Descending)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try

    End Sub



    Private Sub SearchByJobID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchByJobID.SelectedIndexChanged
        Try
            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = Color.Honeydew
            ButtonFilterOpen.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOffered.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterJoined.BackColor = SystemColors.GradientInactiveCaption
            ButtonToJoin.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterCancelled.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOnHold.BackColor = SystemColors.GradientInactiveCaption
            '---------------------------------------------------------------------------------------
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DT As New DataTable
            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE JOB_ID= '" & SearchByJobID.Text & "'", SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DataGridView1.DataSource = DT
            DA.Fill(DT)
            SQLConn.Close()

            '------------------------ Rows Count-------------------------
            RowsCount.Text = DataGridView1.RowCount
            '------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub

    Private Sub SearchByRecruiter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchByRecruiter.SelectedIndexChanged
        Try
            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = Color.Honeydew
            ButtonFilterOpen.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOffered.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterJoined.BackColor = SystemColors.GradientInactiveCaption
            ButtonToJoin.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterCancelled.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOnHold.BackColor = SystemColors.GradientInactiveCaption
            '---------------------------------------------------------------------------------------
            SQLConn.Close()

            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Recruiter= '" & SearchByRecruiter.Text & "'", SQLConn)
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


    Private Sub SearchByCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchByCategory.SelectedIndexChanged
        Try
            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = Color.Honeydew
            ButtonFilterOpen.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOffered.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterJoined.BackColor = SystemColors.GradientInactiveCaption
            ButtonToJoin.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterCancelled.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOnHold.BackColor = SystemColors.GradientInactiveCaption
            '---------------------------------------------------------------------------------------
            SQLConn.Close()

            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Category= '" & SearchByCategory.Text & "'", SQLConn)
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

    Private Sub SearchByCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchByCompany.SelectedIndexChanged
        Try
            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = Color.Honeydew
            ButtonFilterOpen.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOffered.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterJoined.BackColor = SystemColors.GradientInactiveCaption
            ButtonToJoin.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterCancelled.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOnHold.BackColor = SystemColors.GradientInactiveCaption
            '---------------------------------------------------------------------------------------
            SQLConn.Close()

            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Company1= '" & SearchByCompany.Text & "'", SQLConn)
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

    Private Sub SearchByJobPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchByJobPosition.SelectedIndexChanged
        Try
            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = Color.Honeydew
            ButtonFilterOpen.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOffered.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterJoined.BackColor = SystemColors.GradientInactiveCaption
            ButtonToJoin.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterCancelled.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOnHold.BackColor = SystemColors.GradientInactiveCaption
            '---------------------------------------------------------------------------------------
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Position= '" & SearchByJobPosition.Text & "'", SQLConn)
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

    Private Sub SearchByPositionLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchByPositionLevel.SelectedIndexChanged
        Try
            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = Color.Honeydew
            ButtonFilterOpen.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOffered.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterJoined.BackColor = SystemColors.GradientInactiveCaption
            ButtonToJoin.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterCancelled.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOnHold.BackColor = SystemColors.GradientInactiveCaption
            '---------------------------------------------------------------------------------------
            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Position_Level= '" & SearchByPositionLevel.Text & "'", SQLConn)
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

    Private Sub RadioButtonJobID_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonJobID.CheckedChanged


        SearchByJobID.Enabled = True
        SearchByJobID.Focus()
        SearchByRecruiter.Enabled = False
        'SearchByStatus.Enabled = False
        SearchByCategory.Enabled = False
        SearchByCompany.Enabled = False
        SearchByJobPosition.Enabled = False
        SearchByPositionLevel.Enabled = False

        'SearchByJobID.Text = ""
        SearchByRecruiter.Text = ""
        'SearchByStatus.Text = ""
        SearchByCategory.Text = ""
        SearchByCompany.Text = ""
        SearchByJobPosition.Text = ""
        SearchByPositionLevel.Text = ""
        'FilterRecruiter.Text = ""



    End Sub

    Private Sub RadioButtonRecruiter_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonRecruiter.CheckedChanged


        SearchByJobID.Enabled = False
        SearchByRecruiter.Enabled = True
        SearchByRecruiter.Focus()
        'SearchByStatus.Enabled = False
        SearchByCategory.Enabled = False
        SearchByCompany.Enabled = False
        SearchByJobPosition.Enabled = False
        SearchByPositionLevel.Enabled = False
        SearchByJobID.Text = ""
        'SearchByRecruiter.Text = ""
        'SearchByStatus.Text = ""
        SearchByCategory.Text = ""
        SearchByCompany.Text = ""
        SearchByJobPosition.Text = ""
        SearchByPositionLevel.Text = ""
        'FilterRecruiter.Text = ""

    End Sub



    Private Sub RadioButtonStatus_CheckedChanged(sender As Object, e As EventArgs)

        SearchByJobID.Enabled = False
        SearchByRecruiter.Enabled = False
        'SearchByStatus.Enabled = True
        SearchByCategory.Enabled = False
        SearchByCompany.Enabled = False
        SearchByJobPosition.Enabled = False
        SearchByPositionLevel.Enabled = False

        SearchByJobID.Text = ""
        SearchByRecruiter.Text = ""
        'SearchByStatus.Text = ""
        SearchByCategory.Text = ""
        SearchByCompany.Text = ""
        SearchByJobPosition.Text = ""
        SearchByPositionLevel.Text = ""
        'FilterRecruiter.Text = ""


    End Sub

    Private Sub RadioButtonCategory_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonCategory.CheckedChanged
        SearchByJobID.Enabled = False
        SearchByRecruiter.Enabled = False
        'SearchByStatus.Enabled = False
        SearchByCategory.Enabled = True
        SearchByCategory.Focus()
        SearchByCompany.Enabled = False
        SearchByJobPosition.Enabled = False
        SearchByPositionLevel.Enabled = False

        SearchByJobID.Text = ""
        SearchByRecruiter.Text = ""
        'SearchByStatus.Text = ""
        'SearchByCategory.Text = ""
        SearchByCompany.Text = ""
        SearchByJobPosition.Text = ""
        SearchByPositionLevel.Text = ""
        'FilterRecruiter.Text = ""


    End Sub

    Private Sub RadioButtonCompany_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonCompany.CheckedChanged
        SearchByJobID.Enabled = False
        SearchByRecruiter.Enabled = False
        'SearchByStatus.Enabled = False
        SearchByCategory.Enabled = False
        SearchByCompany.Enabled = True
        SearchByCompany.Focus()
        SearchByJobPosition.Enabled = False
        SearchByPositionLevel.Enabled = False

        SearchByJobID.Text = ""
        SearchByRecruiter.Text = ""
        'SearchByStatus.Text = ""
        SearchByCategory.Text = ""
        'SearchByCompany.Text = ""
        SearchByJobPosition.Text = ""
        SearchByPositionLevel.Text = ""
        'FilterRecruiter.Text = ""

    End Sub

    Private Sub RadioButtonJobPosition_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonJobPosition.CheckedChanged
        SearchByJobID.Enabled = False
        SearchByRecruiter.Enabled = False
        'SearchByStatus.Enabled = False
        SearchByCategory.Enabled = False
        SearchByCompany.Enabled = False
        SearchByJobPosition.Enabled = True
        SearchByJobPosition.Focus()
        SearchByPositionLevel.Enabled = False

        SearchByJobID.Text = ""
        SearchByRecruiter.Text = ""
        'SearchByStatus.Text = ""
        SearchByCategory.Text = ""
        SearchByCompany.Text = ""
        'SearchByJobPosition.Text = ""
        SearchByPositionLevel.Text = ""
        'FilterRecruiter.Text = ""


    End Sub

    Private Sub RadioButtonPositionLevel_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonPositionLevel.CheckedChanged
        SearchByJobID.Enabled = False
        SearchByRecruiter.Enabled = False
        'SearchByStatus.Enabled = False
        SearchByCategory.Enabled = False
        SearchByCompany.Enabled = False
        SearchByJobPosition.Enabled = False
        SearchByPositionLevel.Enabled = True
        SearchByPositionLevel.Focus()

        SearchByJobID.Text = ""
        SearchByRecruiter.Text = ""
        'SearchByStatus.Text = ""
        SearchByCategory.Text = ""
        SearchByCompany.Text = ""
        SearchByJobPosition.Text = ""
        'SearchByPositionLevel.Text = ""
        'FilterRecruiter.Text = ""


    End Sub




    Private Sub ButtonShowAll_Click(sender As Object, e As EventArgs) Handles ButtonShowAll.Click
        Try
            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = Color.Honeydew
            ButtonFilterOpen.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOffered.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterJoined.BackColor = SystemColors.GradientInactiveCaption
            ButtonToJoin.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterCancelled.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOnHold.BackColor = SystemColors.GradientInactiveCaption
            '---------------------------------------------------------------------------------------

            SearchByJobID.SelectedIndex = -1
            SearchByRecruiter.SelectedIndex = -1
            SearchByCategory.SelectedIndex = -1
            SearchByCompany.SelectedIndex = -1
            SearchByJobPosition.SelectedIndex = -1
            SearchByPositionLevel.SelectedIndex = -1

            '-------------------- Fetch All Records from JobTable-----------------------------------
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DT As New DataTable
            Dim DS As New DataSet
            SQLConn.Open()
            SQLComm = New SqlCommand("SELECT * FROM JOBTABLE", SQLConn)
            SQLComm.CommandTimeout = 30
            Dim DA As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
            DA.Fill(DS)
            DataGridView1.DataSource = DS.Tables(0)
            SQLConn.Close()
            '---------------------------------------------------------------------------------------

            '------------------------ Rows Count-------------------------
            RowsCount.Text = DataGridView1.RowCount
            '------------------------------------------------------------

            '----------------- Reset SearchBy Options ----------------------------------------------
            RadioButtonJobID.Checked = False
            RadioButtonRecruiter.Checked = False
            'RadioButtonStatus.Checked = False
            RadioButtonCategory.Checked = False
            RadioButtonCompany.Checked = False
            RadioButtonJobPosition.Checked = False
            RadioButtonPositionLevel.Checked = False

            SearchByJobID.Enabled = False
            SearchByRecruiter.Enabled = False
            'SearchByStatus.Enabled = False
            SearchByCategory.Enabled = False
            SearchByCompany.Enabled = False
            SearchByJobPosition.Enabled = False
            SearchByPositionLevel.Enabled = False
            '---------------------------------------------------------------------------------------

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub



    Private Sub Btn_ExportToExcel_Click(sender As Object, e As EventArgs) Handles Btn_ExportToExcel.Click

        Try
            'FilePath = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & ".xls"

            'Dim default_location As String = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            Dim default_location As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Recruitment_Job_Positions_Data_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xlsx"
            'Dim default_location As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            'Creating dataset to export
            Dim dset As New DataSet
            'add table to dataset
            dset.Tables.Add()
            'add column to that table
            For i As Integer = 0 To DataGridView1.ColumnCount - 1
                Application.DoEvents()
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
                For j = 0 To DataGridView1.ColumnCount - 1
                    wSheet.Cells(i + 2, j + 1).value = DataGridView1.Rows(i).Cells(j).Value.ToString
                Next j
                ProgressBar1.Value = i
            Next i

            wSheet.Columns.AutoFit()
            wSheet.Cells.WrapText = False
            wSheet.Range("U:U").ColumnWidth = 20
            wSheet.Range("Y:Y").ColumnWidth = 20
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
                'SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Candidate_Name LIKE '%" & txt_Search.Text & "%'", SQLConn)
                SQLComm = New SqlCommand(("Select * from JOBTABLE where Lower(Job_Position) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_Status) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Recruiter) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Hiring_Manager) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Company2) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Position_Level) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Application_ID) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Candidate_Name) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Company1) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%'"), SQLConn)
                SQLComm.CommandTimeout = 30
                Dim DA1 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA1.Fill(ds1)
                DataGridView1.DataSource = ds1.Tables(0)
                SQLConn.Close()
                DataGridView1.DataBindings.Clear()
                SQLComm.Parameters.Clear()
                ConnStr = Nothing
                RowsCount.Text = DataGridView1.RowCount
            Else
            End If
        Catch ex As Exception
            SQLConn.Close()
        End Try
    End Sub

    Private Sub ButtonFilterOpen_Click(sender As Object, e As EventArgs) Handles ButtonFilterOpen.Click
        Try

            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOpen.BackColor = Color.Honeydew
            ButtonFilterOffered.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterJoined.BackColor = SystemColors.GradientInactiveCaption
            ButtonToJoin.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterCancelled.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOnHold.BackColor = SystemColors.GradientInactiveCaption
            '---------------------------------------------------------------------------------------

            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            If RadioButtonJobID.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_ID = '" & SearchByJobID.Text & "' AND Job_Status = 'OPEN'", SQLConn)
            ElseIf RadioButtonRecruiter.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Recruiter = '" & SearchByRecruiter.Text & "' AND Job_Status = 'OPEN'", SQLConn)
            ElseIf RadioButtonCategory.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Category = '" & SearchByCategory.Text & "' AND Job_Status = 'OPEN'", SQLConn)
            ElseIf RadioButtonCompany.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Company1 = '" & SearchByCompany.Text & "' AND Job_Status = 'OPEN'", SQLConn)
            ElseIf RadioButtonJobPosition.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Job_Status = 'OPEN'", SQLConn)
            ElseIf RadioButtonPositionLevel.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Position_Level = '" & SearchByPositionLevel.Text & "' AND Job_Status = 'OPEN'", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'OPEN'", SQLConn)
            End If
            'SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'OPEN'", SQLConn)
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
            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOpen.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOffered.BackColor = Color.Honeydew
            ButtonFilterJoined.BackColor = SystemColors.GradientInactiveCaption
            ButtonToJoin.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterCancelled.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOnHold.BackColor = SystemColors.GradientInactiveCaption
            '---------------------------------------------------------------------------------------

            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            If RadioButtonJobID.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_ID = '" & SearchByJobID.Text & "' AND Job_Status = 'OFFERED'", SQLConn)
            ElseIf RadioButtonRecruiter.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Recruiter = '" & SearchByRecruiter.Text & "' AND Job_Status = 'OFFERED'", SQLConn)
            ElseIf RadioButtonCategory.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Category = '" & SearchByCategory.Text & "' AND Job_Status = 'OFFERED'", SQLConn)
            ElseIf RadioButtonCompany.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Company1 = '" & SearchByCompany.Text & "' AND Job_Status = 'OFFERED'", SQLConn)
            ElseIf RadioButtonJobPosition.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Job_Status = 'OFFERED'", SQLConn)
            ElseIf RadioButtonPositionLevel.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Position_Level = '" & SearchByPositionLevel.Text & "' AND Job_Status = 'OFFERED'", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'OFFERED'", SQLConn)
            End If
            'SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'OFFERED'", SQLConn)
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
            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOpen.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOffered.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterJoined.BackColor = Color.Honeydew
            ButtonToJoin.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterCancelled.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOnHold.BackColor = SystemColors.GradientInactiveCaption
            '---------------------------------------------------------------------------------------

            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            If RadioButtonJobID.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_ID = '" & SearchByJobID.Text & "' AND Job_Status = 'JOINED'", SQLConn)
            ElseIf RadioButtonRecruiter.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Recruiter = '" & SearchByRecruiter.Text & "' AND Job_Status = 'JOINED'", SQLConn)
            ElseIf RadioButtonCategory.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Category = '" & SearchByCategory.Text & "' AND Job_Status = 'JOINED'", SQLConn)
            ElseIf RadioButtonCompany.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Company1 = '" & SearchByCompany.Text & "' AND Job_Status = 'JOINED'", SQLConn)
            ElseIf RadioButtonJobPosition.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Job_Status = 'JOINED'", SQLConn)
            ElseIf RadioButtonPositionLevel.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Position_Level = '" & SearchByPositionLevel.Text & "' AND Job_Status = 'JOINED'", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'JOINED'", SQLConn)
            End If
            'SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'JOINED'", SQLConn)
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
            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOpen.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOffered.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterJoined.BackColor = SystemColors.GradientInactiveCaption
            ButtonToJoin.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterCancelled.BackColor = Color.Honeydew
            ButtonFilterOnHold.BackColor = SystemColors.GradientInactiveCaption
            '---------------------------------------------------------------------------------------

            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            If RadioButtonJobID.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_ID = '" & SearchByJobID.Text & "' AND Job_Status = 'CANCELLED'", SQLConn)
            ElseIf RadioButtonRecruiter.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Recruiter = '" & SearchByRecruiter.Text & "' AND Job_Status = 'CANCELLED'", SQLConn)
            ElseIf RadioButtonCategory.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Category = '" & SearchByCategory.Text & "' AND Job_Status = 'CANCELLED'", SQLConn)
            ElseIf RadioButtonCompany.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Company1 = '" & SearchByCompany.Text & "' AND Job_Status = 'CANCELLED'", SQLConn)
            ElseIf RadioButtonJobPosition.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Job_Status = 'CANCELLED'", SQLConn)
            ElseIf RadioButtonPositionLevel.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Position_Level = '" & SearchByPositionLevel.Text & "' AND Job_Status = 'CANCELLED'", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'CANCELLED'", SQLConn)
            End If
            'SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'CANCELLED'", SQLConn)
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

            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOpen.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOffered.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterJoined.BackColor = SystemColors.GradientInactiveCaption
            ButtonToJoin.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterCancelled.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOnHold.BackColor = Color.Honeydew
            '---------------------------------------------------------------------------------------

            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            If RadioButtonJobID.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_ID = '" & SearchByJobID.Text & "' AND Job_Status = 'ON-HOLD'", SQLConn)
            ElseIf RadioButtonRecruiter.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Recruiter = '" & SearchByRecruiter.Text & "' AND Job_Status = 'ON-HOLD'", SQLConn)
            ElseIf RadioButtonCategory.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Category = '" & SearchByCategory.Text & "' AND Job_Status = 'ON-HOLD'", SQLConn)
            ElseIf RadioButtonCompany.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Company1 = '" & SearchByCompany.Text & "' AND Job_Status = 'ON-HOLD'", SQLConn)
            ElseIf RadioButtonJobPosition.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Job_Status = 'ON-HOLD'", SQLConn)
            ElseIf RadioButtonPositionLevel.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Position_Level = '" & SearchByPositionLevel.Text & "' AND Job_Status = 'ON-HOLD'", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'ON-HOLD'", SQLConn)
            End If
            'SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Status = 'ON-HOLD'", SQLConn)
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



    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        FormProcess.CheckBoxNewCandidate.Checked = False
        Try

            FormProcess.MdiParent = FormMain
            FormProcess.Show()
            FormProcess.ComboBoxPJobID.DataBindings.Clear()
            FormProcess.ComboBoxPJobID.Text = DataGridView1.SelectedCells.Item(1).Value
            FormProcess.ComboBoxAppID.Text = ""
            FormProcess.ComboBoxAppID.DataBindings.Clear()
            If IsDBNull(DataGridView1.SelectedCells.Item(7).Value) Then
            Else
                FormProcess.ComboBoxAppID.Text = DataGridView1.SelectedCells.Item(7).Value
            End If
            Me.Hide()
            FormMain.btn_process.BackColor = SystemColors.GradientInactiveCaption
            FormMain.btn_OpenPosition.BackColor = Color.Honeydew

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLConn.Close()
        End Try
    End Sub

    'Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
    '    Label_selectedrows.Text = "Selected Rows :" & DataGridView1.SelectedRows.Count
    'End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.DataSourceChanged, DataGridView1.SelectionChanged, DataGridView1.Sorted
        '------------------------------- Datagridview color formatting -----------------------------------------------------
        DataGridView1.RowsDefaultCellStyle.BackColor = Nothing
        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            If Me.DataGridView1.Item(6, i).Value = "JOINED" Then
                Me.DataGridView1.Item(6, i).Style.BackColor = Color.LightGreen
                Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            ElseIf Me.DataGridView1.Item(6, i).Value = "OFFERED" Then
                Me.DataGridView1.Item(6, i).Style.BackColor = Color.Orange
                Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Orange
            ElseIf Me.DataGridView1.Item(6, i).Value = "CANCELLED" Then
                Me.DataGridView1.Item(6, i).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
            ElseIf Me.DataGridView1.Item(6, i).Value = "ON-HOLD" Then
                Me.DataGridView1.Item(6, i).Style.BackColor = Color.LightSlateGray
                Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightSlateGray
            Else
                Me.DataGridView1.Item(6, i).Style.BackColor = Color.White
                Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next i

        Label_selectedrows.Text = "Selected Rows : " & DataGridView1.SelectedRows.Count

    End Sub



    Private Sub ButtonToJoin_Click(sender As Object, e As EventArgs) Handles ButtonToJoin.Click
        Try
            '------------------Change Back Color ---------------------------------------------------
            ButtonShowAll.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOpen.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOffered.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterJoined.BackColor = SystemColors.GradientInactiveCaption
            ButtonToJoin.BackColor = Color.Honeydew
            ButtonFilterCancelled.BackColor = SystemColors.GradientInactiveCaption
            ButtonFilterOnHold.BackColor = SystemColors.GradientInactiveCaption
            '---------------------------------------------------------------------------------------

            SQLConn.Close()
            ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            SQLConn.ConnectionString = ConnStr
            SQLComm.Connection = SQLConn
            Dim DS As New DataSet
            SQLConn.Open()
            If RadioButtonJobID.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_ID = '" & SearchByJobID.Text & "' AND Joining_Date >= '" & Date.Today & "'", SQLConn)
            ElseIf RadioButtonRecruiter.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Recruiter = '" & SearchByRecruiter.Text & "' AND Joining_Date >= '" & Date.Today & "'", SQLConn)
            ElseIf RadioButtonCategory.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Category = '" & SearchByCategory.Text & "' AND Joining_Date >= '" & Date.Today & "'", SQLConn)
            ElseIf RadioButtonCompany.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Company1 = '" & SearchByCompany.Text & "' AND Joining_Date >= '" & Date.Today & "'", SQLConn)
            ElseIf RadioButtonJobPosition.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Job_Position = '" & SearchByJobPosition.Text & "' AND Joining_Date >= '" & Date.Today & "'", SQLConn)
            ElseIf RadioButtonPositionLevel.Checked = True Then
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Position_Level = '" & SearchByPositionLevel.Text & "' AND Joining_Date >= '" & Date.Today & "'", SQLConn)
            Else
                SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Joining_Date >= '" & Date.Today & "' Or Joining_Date > ' 1/1/1900 ' and Job_Status = 'OFFERED'", SQLConn)
            End If
            'SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Joining_Date >= '" & Date.Today & "' Or Joining_Date <= '" & Date.Today & "' and Job_Status = 'OFFERED'", SQLConn)
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txt_Search_TextChanged(sender As Object, e As EventArgs) Handles txt_Search.TextChanged

    End Sub

    Private Sub Btn_search_Click(sender As Object, e As EventArgs) Handles Btn_search.Click
        Try

            SQLConn.Close()
                ConnStr = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
                SQLConn.ConnectionString = ConnStr
                SQLComm.Connection = SQLConn
                Dim ds1 As New DataSet
                SQLConn.Open()
                'SQLComm = New SqlCommand("SELECT * FROM JOBTABLE WHERE Candidate_Name LIKE '%" & txt_Search.Text & "%'", SQLConn)
                SQLComm = New SqlCommand(("Select * from JOBTABLE where Lower(Job_Position) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_ID) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Job_Status) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Recruiter) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Hiring_Manager) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Company2) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Position_Level) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Application_ID) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Candidate_Name) Like '%" & LCase(Trim(txt_Search.Text)) & "%' or Lower(Company1) LIKE '%" & LCase(Trim(txt_Search.Text)) & "%'"), SQLConn)
                SQLComm.CommandTimeout = 30
                Dim DA1 As New SqlDataAdapter(SQLComm.CommandText, ConnStr)
                DA1.Fill(ds1)
                DataGridView1.DataSource = ds1.Tables(0)
                SQLConn.Close()
                DataGridView1.DataBindings.Clear()
                SQLComm.Parameters.Clear()
                ConnStr = Nothing
            RowsCount.Text = DataGridView1.RowCount
            DataGridView1.Sort(DataGridView1.Columns(12), direction:=ListSortDirection.Descending)
            txt_Search.Focus()
        Catch ex As Exception
            SQLConn.Close()
        End Try

    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
        FormMain.btn_OpenPosition.BackColor = Color.Honeydew
    End Sub

    Private Sub Btn_ExportSelection_Click(sender As Object, e As EventArgs) Handles Btn_ExportSelection.Click
        Try
            'FilePath = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & ".xls"

            'Dim default_location As String = Path.GetTempPath.ToString & "RecruitmentDataExport_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".xls"  'Application.StartupPath & "\Jadwal\" & periode.Text & ".xls"
            Dim default_location As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Recruitment_Job_Positions_Data_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xlsx"
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
            For i As Integer = 0 To DataGridView1.SelectedRows.Count - 1
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To DataGridView1.Columns.Count - 1
                    dr1(j) = DataGridView1.SelectedRows(i).Cells(j).Value
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
                wSheet.Cells(1, j + 1).value = DataGridView1.Columns(j).HeaderText
                wSheet.Cells(1, j + 1).interior.color = Color.LightCyan
                wSheet.Cells(1, j + 1).Font.Bold = True

            Next j


            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = DataGridView1.SelectedRows.Count
            ProgressBar1.Show()
            For i = 0 To DataGridView1.SelectedRows.Count - 1
                For j = 0 To DataGridView1.ColumnCount - 1
                    wSheet.Cells(i + 2, j + 1).value = DataGridView1.SelectedRows(i).Cells(j).Value.ToString
                Next j
                ProgressBar1.Value = i
            Next i

            wSheet.Columns.AutoFit()
            wSheet.Cells.WrapText = False
            wSheet.Range("U:U").ColumnWidth = 20
            wSheet.Range("Y:Y").ColumnWidth = 20
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
End Class