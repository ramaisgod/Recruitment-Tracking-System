<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTop
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ComboBoxAppDetailsRecruiter = New System.Windows.Forms.ComboBox()
        Me.ButtonTopCountRefresh = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.screeningCount = New System.Windows.Forms.Label()
        Me.countAvg = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.openCount = New System.Windows.Forms.Label()
        Me.offertojoin = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tojoinCount = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.joinedCount = New System.Windows.Forms.Label()
        Me.sharedCount = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.offerdeclinedCount = New System.Windows.Forms.Label()
        Me.approvedCount = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.offeracceptedCount = New System.Windows.Forms.Label()
        Me.invitedCount = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.offeredCount = New System.Windows.Forms.Label()
        Me.visitedCount = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ComboBoxFY = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBoxAppDetailsRecruiter
        '
        Me.ComboBoxAppDetailsRecruiter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxAppDetailsRecruiter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxAppDetailsRecruiter.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ComboBoxAppDetailsRecruiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAppDetailsRecruiter.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBoxAppDetailsRecruiter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxAppDetailsRecruiter.FormattingEnabled = True
        Me.ComboBoxAppDetailsRecruiter.Location = New System.Drawing.Point(8, 26)
        Me.ComboBoxAppDetailsRecruiter.Name = "ComboBoxAppDetailsRecruiter"
        Me.ComboBoxAppDetailsRecruiter.Size = New System.Drawing.Size(150, 23)
        Me.ComboBoxAppDetailsRecruiter.TabIndex = 18
        '
        'ButtonTopCountRefresh
        '
        Me.ButtonTopCountRefresh.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ButtonTopCountRefresh.FlatAppearance.BorderSize = 0
        Me.ButtonTopCountRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTopCountRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonTopCountRefresh.Image = Global.InnerHeads.My.Resources.Resources.refresh
        Me.ButtonTopCountRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonTopCountRefresh.Location = New System.Drawing.Point(1285, 2)
        Me.ButtonTopCountRefresh.Name = "ButtonTopCountRefresh"
        Me.ButtonTopCountRefresh.Size = New System.Drawing.Size(54, 46)
        Me.ButtonTopCountRefresh.TabIndex = 41
        Me.ButtonTopCountRefresh.Text = "Refresh"
        Me.ButtonTopCountRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonTopCountRefresh.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 13
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.screeningCount, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.countAvg, 12, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 12, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.openCount, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.offertojoin, 11, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tojoinCount, 10, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 10, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.joinedCount, 9, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.sharedCount, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.offerdeclinedCount, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.approvedCount, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label19, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.offeracceptedCount, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.invitedCount, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label21, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.offeredCount, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.visitedCount, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 11, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(164, 1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.27273!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.72727!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1115, 48)
        Me.TableLayoutPanel1.TabIndex = 8
        '
        'screeningCount
        '
        Me.screeningCount.AutoSize = True
        Me.screeningCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.screeningCount.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.screeningCount.Location = New System.Drawing.Point(128, 25)
        Me.screeningCount.Name = "screeningCount"
        Me.screeningCount.Size = New System.Drawing.Size(16, 18)
        Me.screeningCount.TabIndex = 20
        Me.screeningCount.Text = "0"
        '
        'countAvg
        '
        Me.countAvg.AutoSize = True
        Me.countAvg.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.countAvg.ForeColor = System.Drawing.SystemColors.Highlight
        Me.countAvg.Location = New System.Drawing.Point(1023, 25)
        Me.countAvg.Name = "countAvg"
        Me.countAvg.Size = New System.Drawing.Size(16, 18)
        Me.countAvg.TabIndex = 44
        Me.countAvg.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label8.Location = New System.Drawing.Point(1023, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 18)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Avg. Time"
        '
        'openCount
        '
        Me.openCount.AutoSize = True
        Me.openCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.openCount.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.openCount.Location = New System.Drawing.Point(4, 25)
        Me.openCount.Name = "openCount"
        Me.openCount.Size = New System.Drawing.Size(16, 18)
        Me.openCount.TabIndex = 43
        Me.openCount.Text = "0"
        '
        'offertojoin
        '
        Me.offertojoin.AutoSize = True
        Me.offertojoin.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.offertojoin.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.offertojoin.Location = New System.Drawing.Point(929, 25)
        Me.offertojoin.Name = "offertojoin"
        Me.offertojoin.Size = New System.Drawing.Size(16, 18)
        Me.offertojoin.TabIndex = 39
        Me.offertojoin.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(128, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 18)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Screened"
        '
        'tojoinCount
        '
        Me.tojoinCount.AutoSize = True
        Me.tojoinCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tojoinCount.ForeColor = System.Drawing.Color.Orange
        Me.tojoinCount.Location = New System.Drawing.Point(862, 25)
        Me.tojoinCount.Name = "tojoinCount"
        Me.tojoinCount.Size = New System.Drawing.Size(16, 18)
        Me.tojoinCount.TabIndex = 38
        Me.tojoinCount.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label15.Location = New System.Drawing.Point(862, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 18)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "To Join"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label3.Location = New System.Drawing.Point(212, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 18)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Shared"
        '
        'joinedCount
        '
        Me.joinedCount.AutoSize = True
        Me.joinedCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.joinedCount.ForeColor = System.Drawing.Color.ForestGreen
        Me.joinedCount.Location = New System.Drawing.Point(799, 25)
        Me.joinedCount.Name = "joinedCount"
        Me.joinedCount.Size = New System.Drawing.Size(16, 18)
        Me.joinedCount.TabIndex = 36
        Me.joinedCount.Text = "0"
        '
        'sharedCount
        '
        Me.sharedCount.AutoSize = True
        Me.sharedCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sharedCount.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.sharedCount.Location = New System.Drawing.Point(212, 25)
        Me.sharedCount.Name = "sharedCount"
        Me.sharedCount.Size = New System.Drawing.Size(16, 18)
        Me.sharedCount.TabIndex = 22
        Me.sharedCount.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label17.Location = New System.Drawing.Point(799, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 18)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Joined"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label5.Location = New System.Drawing.Point(278, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 18)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Approved"
        '
        'offerdeclinedCount
        '
        Me.offerdeclinedCount.AutoSize = True
        Me.offerdeclinedCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.offerdeclinedCount.ForeColor = System.Drawing.Color.Red
        Me.offerdeclinedCount.Location = New System.Drawing.Point(680, 25)
        Me.offerdeclinedCount.Name = "offerdeclinedCount"
        Me.offerdeclinedCount.Size = New System.Drawing.Size(16, 18)
        Me.offerdeclinedCount.TabIndex = 34
        Me.offerdeclinedCount.Text = "0"
        '
        'approvedCount
        '
        Me.approvedCount.AutoSize = True
        Me.approvedCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.approvedCount.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.approvedCount.Location = New System.Drawing.Point(278, 25)
        Me.approvedCount.Name = "approvedCount"
        Me.approvedCount.Size = New System.Drawing.Size(16, 18)
        Me.approvedCount.TabIndex = 24
        Me.approvedCount.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label19.Location = New System.Drawing.Point(680, 1)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 18)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "Offer Declined"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label7.Location = New System.Drawing.Point(362, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 18)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Invited"
        '
        'offeracceptedCount
        '
        Me.offeracceptedCount.AutoSize = True
        Me.offeracceptedCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.offeracceptedCount.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.offeracceptedCount.Location = New System.Drawing.Point(559, 25)
        Me.offeracceptedCount.Name = "offeracceptedCount"
        Me.offeracceptedCount.Size = New System.Drawing.Size(16, 18)
        Me.offeracceptedCount.TabIndex = 32
        Me.offeracceptedCount.Text = "0"
        '
        'invitedCount
        '
        Me.invitedCount.AutoSize = True
        Me.invitedCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invitedCount.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.invitedCount.Location = New System.Drawing.Point(362, 25)
        Me.invitedCount.Name = "invitedCount"
        Me.invitedCount.Size = New System.Drawing.Size(16, 18)
        Me.invitedCount.TabIndex = 26
        Me.invitedCount.Text = "0"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label21.Location = New System.Drawing.Point(559, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(114, 18)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "Offer Accepted"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label9.Location = New System.Drawing.Point(426, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 18)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Visited"
        '
        'offeredCount
        '
        Me.offeredCount.AutoSize = True
        Me.offeredCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.offeredCount.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.offeredCount.Location = New System.Drawing.Point(489, 25)
        Me.offeredCount.Name = "offeredCount"
        Me.offeredCount.Size = New System.Drawing.Size(16, 18)
        Me.offeredCount.TabIndex = 30
        Me.offeredCount.Text = "0"
        '
        'visitedCount
        '
        Me.visitedCount.AutoSize = True
        Me.visitedCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.visitedCount.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.visitedCount.Location = New System.Drawing.Point(426, 25)
        Me.visitedCount.Name = "visitedCount"
        Me.visitedCount.Size = New System.Drawing.Size(16, 18)
        Me.visitedCount.TabIndex = 28
        Me.visitedCount.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label11.Location = New System.Drawing.Point(489, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 18)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Offered"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label4.Location = New System.Drawing.Point(929, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 18)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Offer : Join"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label6.Location = New System.Drawing.Point(4, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 18)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Open Positions"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ComboBoxFY)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Controls.Add(Me.ButtonTopCountRefresh)
        Me.Panel2.Controls.Add(Me.ComboBoxAppDetailsRecruiter)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1347, 50)
        Me.Panel2.TabIndex = 7
        '
        'ComboBoxFY
        '
        Me.ComboBoxFY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxFY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxFY.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ComboBoxFY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFY.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBoxFY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxFY.FormattingEnabled = True
        Me.ComboBoxFY.Location = New System.Drawing.Point(8, 2)
        Me.ComboBoxFY.Name = "ComboBoxFY"
        Me.ComboBoxFY.Size = New System.Drawing.Size(150, 23)
        Me.ComboBoxFY.TabIndex = 46
        '
        'FormTop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1347, 50)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormTop"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dashboard"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBoxAppDetailsRecruiter As ComboBox
    Friend WithEvents ButtonTopCountRefresh As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents screeningCount As Label
    Friend WithEvents countAvg As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents openCount As Label
    Friend WithEvents offertojoin As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tojoinCount As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents joinedCount As Label
    Friend WithEvents sharedCount As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents offerdeclinedCount As Label
    Friend WithEvents approvedCount As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents offeracceptedCount As Label
    Friend WithEvents invitedCount As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents offeredCount As Label
    Friend WithEvents visitedCount As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ComboBoxFY As ComboBox
End Class
