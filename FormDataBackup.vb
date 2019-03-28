Imports System.IO
Imports System.Data
Imports ClosedXML.Excel
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Office.Core
Imports System.IO.Directory
Imports Microsoft.Office.Interop


Partial Class FormDataBackup


    Dim SQLConn As New SqlConnection
    Dim SQLComm As New SqlCommand

    Private Sub FormDataBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SQLConn.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
        SQLComm.Connection = SQLConn
        Dim DR As SqlDataReader
        SQLConn.Open()
        '------- Add List Item in Recruiter 
        SQLComm = New SqlCommand("SELECT RecruiterName FROM Recruiter", SQLConn)
        SQLComm.CommandTimeout = 30
        DR = SQLComm.ExecuteReader()
        Me.ExportDataRecruiter.Items.Add("ALL")
        If DR.HasRows = True Then
            While DR.Read()
                ExportDataRecruiter.Items.Add(DR("RecruiterName"))
            End While
            DR.Close()
        End If
        ExportDataRecruiter.SelectedIndex = 0
        SQLConn.Close()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            'This section help you if your language is not English.
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
            Dim oExcel As Excel.Application
            Dim oBook As Excel.Workbook
            Dim oSheet As Excel.Worksheet
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Add(Type.Missing)
            oSheet = oBook.Worksheets(1)

            'Set final path
            Dim default_location As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & ExportDataRecruiter.Text & "_Data_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xlsx"
            'Dim fileName As String = ExportDataRecruiter.Text & "_RecruitmentData_Export_On_" & DateTime.Now.ToString("dd-MMM-yyyy HH_mm_ss") & ".xls"

            'Initialize the objects before use
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet
            Dim command As New SqlClient.SqlCommand
            Dim connection As New SqlClient.SqlConnection

            'Assign your connection string to connection object
            connection.ConnectionString = InnerHeads.My.Settings.SQL_IHDatabase_ConnectionString.ToString
            command.Connection = connection
            command.CommandType = CommandType.Text


            '----------------------------------- Export JobTable to Excel ----------------------------------------------
            If ExportDataRecruiter.Text = "ALL" Then
                command.CommandText = "Select Job_ID,Job_Position,Category,Job_Type,Job_Status,Recruiter,Hiring_Manager,Open_Date,Target_Date,Company1,Company2,Position_Level,Job_Location,Experience,Job_Description,Total_Application,Application_ID,Candidate_Name,Joining_Date,Elapsed_Time,Position_Modified,Modify_By,Modify_Date,Remarks,Resume_Source from JobTable"
            Else
                command.CommandText = "Select Job_ID,Job_Position,Category,Job_Type,Job_Status,Recruiter,Hiring_Manager,Open_Date,Target_Date,Company1,Company2,Position_Level,Job_Location,Experience,Job_Description,Total_Application,Application_ID,Candidate_Name,Joining_Date,Elapsed_Time,Position_Modified,Modify_By,Modify_Date,Remarks,Resume_Source from JobTable Where Recruiter = '" & ExportDataRecruiter.Text & "'"
            End If
            da.SelectCommand = command


            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            'Fill data to datatable
            connection.Open()
            da.Fill(ds)
            connection.Close()

            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim ProgBar As Long



            '-----------Progress Bar ---------------------
            ProgressBar1.Visible = True

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = ds.Tables(0).Rows.Count
            ProgBar = ds.Tables(0).Rows.Count



            For j = 0 To ds.Tables(0).Columns.Count - 1
                    Application.DoEvents()
                    oExcel.ActiveWorkbook.Sheets(1).Cells(1, j + 1) = ds.Tables(0).Columns(j).ColumnName
                Next

                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Application.DoEvents()
                    For j = 0 To ds.Tables(0).Columns.Count - 1
                        oExcel.ActiveWorkbook.Sheets(1).Cells(i + 2, j + 1) = ds.Tables(0).Rows(i).Item(j).ToString
                    Next
                    ProgressBar1.Value = i
                Next



                '----------------------------------- Export ApplicationTable to Excel ----------------------------------------------
                If ExportDataRecruiter.Text = "ALL" Then
                command.CommandText = "Select * from ApplicationTable"
            Else
                command.CommandText = "Select * from ApplicationTable Where Recruiter_Name = '" & ExportDataRecruiter.Text & "'"
            End If
            da.SelectCommand = command


            'Fill data to datatable
            ds = New DataSet
            connection.Open()
            da.Fill(ds)

            ProgressBar1.Minimum = ProgBar
            ProgressBar1.Maximum = ds.Tables(0).Rows.Count + ProgBar

            connection.Close()

            oExcel.ActiveWorkbook.Sheets.Add(After:=oExcel.ActiveWorkbook.Sheets(oExcel.ActiveWorkbook.Sheets.Count))
            oExcel.ActiveWorkbook.Sheets(2).Activate


            For j = 0 To ds.Tables(0).Columns.Count - 1
                Application.DoEvents()
                oExcel.ActiveWorkbook.Sheets(2).Cells(1, j + 1) = ds.Tables(0).Columns(j).ColumnName
            Next

            For i = 0 To ds.Tables(0).Rows.Count - 1
                    Application.DoEvents()
                    For j = 0 To ds.Tables(0).Columns.Count - 1
                        oExcel.ActiveWorkbook.Sheets(2).Cells(i + 2, j + 1) = ds.Tables(0).Rows(i).Item(j).ToString
                    Next
                    ProgressBar1.Value = ProgBar + i
                Next



            Label_filepath.Visible = True

            Dim finalPath = default_location

            txtFilePath.Text = default_location


            FormTop.ComboBoxAppDetailsRecruiter.Text = ExportDataRecruiter.Text

            Dim misValue As Object = System.Reflection.Missing.Value

            oExcel.Visible = True
            oExcel.UserControl = True
            oExcel.ActiveWorkbook.SaveAs(finalPath)
            oExcel.Workbooks.Open(finalPath)

            '--------------------- oExcel Formatting -------------------------------------
            oExcel.ActiveWorkbook.Sheets("Sheet1").Activate
            oExcel.Cells.Font.Name = "Arial"
            oExcel.ActiveWorkbook.Sheets("Sheet1").Range("A1:Y1").Interior.Color = Color.LightCyan
            oExcel.ActiveWorkbook.Sheets("Sheet1").Range("A1:Y1").Font.Bold = True
            oExcel.ActiveWorkbook.Sheets("Sheet1").Range("A1:Y1").EntireColumn.AutoFit()
            oExcel.ActiveWorkbook.Sheets("Sheet1").Cells.WrapText = False
            oExcel.ActiveWorkbook.Sheets("Sheet1").Range("O1:O1").ColumnWidth = 20
            oExcel.ActiveWorkbook.Sheets("Sheet1").Range("X1:X1").ColumnWidth = 20

            oExcel.ActiveWorkbook.Sheets("Sheet1").Name = "JobPositions"

            oExcel.ActiveWorkbook.Sheets("Sheet2").Activate
            oExcel.Cells.Font.Name = "Arial"
            oExcel.ActiveWorkbook.Sheets("Sheet2").Range("A1:AU1").Interior.Color = Color.LightCyan
            oExcel.ActiveWorkbook.Sheets("Sheet2").Range("A1:AU1").Font.Bold = True
            oExcel.ActiveWorkbook.Sheets("Sheet2").Range("A1:AU1").EntireColumn.AutoFit()
            oExcel.ActiveWorkbook.Sheets("Sheet2").Range("AL1").ColumnWidth = 30
            oExcel.ActiveWorkbook.Sheets("Sheet2").Cells.WrapText = False

            oExcel.ActiveWorkbook.Sheets("Sheet2").Name = "Applications"


            oExcel.ActiveWorkbook.Sheets.Add(Before:=oExcel.ActiveWorkbook.Sheets("JobPositions"))
            oExcel.ActiveWorkbook.Sheets(1).Name = "Summary"
            oExcel.Cells.Font.Name = "Arial"
            With oExcel.ActiveWorkbook.Sheets("Summary")
                .Range("A1").Value = "Summary - April To Till Date"
                .Range("A1:M1").Font.Bold = True
                .Range("A1:M1").Font.Name = "Arial"
                .Range("A1:M1").Font.Size = 20
                .Range("A1:M1").RowHeight = 30
                .Range("A1:M1").MergeCells = True
                .Range("A1:M1").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A1:M1").Interior.Color = Color.MidnightBlue
                .Range("A1:M1").Font.Color = Color.White

                .Range("A3").Value = "OPEN POSITIONS"
                .Range("A4").Value = FormTop.openCount.Text
                .Range("B3").Value = "SCREENED"
                .Range("B4").Value = FormTop.screeningCount.Text
                .Range("C3").Value = "SHARED"
                .Range("C4").Value = FormTop.sharedCount.Text
                .Range("D3").Value = "APPROVED"
                .Range("D4").Value = FormTop.approvedCount.Text
                .Range("E3").Value = "INVITED"
                .Range("E4").Value = FormTop.invitedCount.Text
                .Range("F3").Value = "VISITED"
                .Range("F4").Value = FormTop.visitedCount.Text
                .Range("G3").Value = "OFFERED"
                .Range("G4").Value = FormTop.offeredCount.Text
                .Range("H3").Value = "OFFER ACCEPTED"
                .Range("H4").Value = FormTop.offeracceptedCount.Text
                .Range("I3").Value = "OFFER DECLINED"
                .Range("I4").Value = FormTop.offerdeclinedCount.Text
                .Range("J3").Value = "JOINED"
                .Range("J4").Value = FormTop.joinedCount.Text
                .Range("K3").Value = "TO JOIN"
                .Range("K4").Value = FormTop.tojoinCount.Text
                .Range("L3").Value = "OFFER : JOIN"
                .Range("L4").Value = FormTop.offertojoin.Text
                .Range("M3").Value = "AVG. TIME"
                .Range("M4").Value = FormTop.countAvg.Text

                .Range("A3:M4").Font.Bold = True
                .Range("A3:M4").Font.Size = 12
                .Range("A3:M4").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A3:M4").Borders.Weight = 2
                .Range("A3:M4").Borders.Color = Color.Blue
                .Range("A3:M4").EntireColumn.AutoFit()
                .Range("A3:M3").Interior.Color = Color.MidnightBlue
                .Range("A3:M3").Font.Color = Color.White



            End With
            oExcel.ActiveWindow.Zoom = 90

                oExcel.ActiveWorkbook.Save()

            ProgressBar1.Visible = False
            'ProgressBar1.Value = 0
            Label_exportresult.Text = "Data Exported Successfully !!!"

            'MessageBox.Show("Data Export Successfully !!!")
            'oExcel.Visible = True
            'oExcel.Workbooks.Open(default_location)

            'Release the objects
            ReleaseObject(oSheet)
            'oBook.Close(False, Type.Missing, Type.Missing)
            ReleaseObject(oBook)
            'oExcel.Quit()
            ReleaseObject(oExcel)
            'Some time Office application does not quit after automation: 
            'so i am calling GC.Collect method.
            GC.Collect()
                oExcel = Nothing


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
            SQLConn.Dispose()
        End Try
    End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub ExportDataRecruiter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ExportDataRecruiter.SelectedIndexChanged
        Label_filepath.Visible = False
        txtFilePath.Text = ""
        ProgressBar1.Visible = False
        ProgressBar1.Minimum = 0
        ProgressBar1.Value = 0
        Label_exportresult.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


End Class