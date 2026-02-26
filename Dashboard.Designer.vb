Partial Class DashboardForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()

        ' Stat Cards
        Me.pnlAvailable = New System.Windows.Forms.Panel()
        Me.lblAvailableCount = New System.Windows.Forms.Label()
        Me.lblAvailableTitle = New System.Windows.Forms.Label()

        Me.pnlReserved = New System.Windows.Forms.Panel()
        Me.lblReservedCount = New System.Windows.Forms.Label()
        Me.lblReservedTitle = New System.Windows.Forms.Label()

        Me.pnlOccupied = New System.Windows.Forms.Panel()
        Me.lblOccupiedCount = New System.Windows.Forms.Label()
        Me.lblOccupiedTitle = New System.Windows.Forms.Label()

        Me.pnlMaintenance = New System.Windows.Forms.Panel()
        Me.lblMaintenanceCount = New System.Windows.Forms.Label()
        Me.lblMaintenanceTitle = New System.Windows.Forms.Label()

        ' Today panels
        Me.pnlCheckIns = New System.Windows.Forms.Panel()
        Me.lblCheckInsTitle = New System.Windows.Forms.Label()
        Me.dgvCheckIns = New System.Windows.Forms.DataGridView()

        Me.pnlCheckOuts = New System.Windows.Forms.Panel()
        Me.lblCheckOutsTitle = New System.Windows.Forms.Label()
        Me.dgvCheckOuts = New System.Windows.Forms.DataGridView()

        Me.pnlRecentActivity = New System.Windows.Forms.Panel()
        Me.lblRecentTitle = New System.Windows.Forms.Label()
        Me.dgvRecentActivity = New System.Windows.Forms.DataGridView()

        Me.pnlAvailable.SuspendLayout()
        Me.pnlReserved.SuspendLayout()
        Me.pnlOccupied.SuspendLayout()
        Me.pnlMaintenance.SuspendLayout()
        Me.pnlCheckIns.SuspendLayout()
        Me.pnlCheckOuts.SuspendLayout()
        Me.pnlRecentActivity.SuspendLayout()
        CType(Me.dgvCheckIns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCheckOuts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRecentActivity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        '=== FORM ===
        Me.ClientSize = New System.Drawing.Size(1060, 620)
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DashboardForm"
        Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)

        '=== TITLE ===
        Me.lblTitle.AutoSize = False
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.lblTitle.Location = New System.Drawing.Point(25, 18)
        Me.lblTitle.Size = New System.Drawing.Size(400, 32)
        Me.lblTitle.Text = "Dashboard"
        Me.lblTitle.Name = "lblTitle"

        '=== DATE ===
        Me.lblDate.AutoSize = False
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120)
        Me.lblDate.Location = New System.Drawing.Point(27, 50)
        Me.lblDate.Size = New System.Drawing.Size(500, 20)
        Me.lblDate.Name = "lblDate"

        '=== REFRESH BUTTON ===
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.Location = New System.Drawing.Point(955, 25)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 32)
        Me.btnRefresh.Text = "⟳  Refresh"
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand

        '=== STAT CARDS (y=80, height=110, width=240, gap=15) ===
        ' Available
        Me.pnlAvailable.Location = New System.Drawing.Point(25, 82)
        Me.pnlAvailable.Size = New System.Drawing.Size(240, 110)
        Me.pnlAvailable.BackColor = System.Drawing.Color.White
        Me.pnlAvailable.Name = "pnlAvailable"
        Me.pnlAvailable.Controls.Add(Me.lblAvailableCount)
        Me.pnlAvailable.Controls.Add(Me.lblAvailableTitle)

        Me.lblAvailableCount.AutoSize = False
        Me.lblAvailableCount.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblAvailableCount.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.lblAvailableCount.Location = New System.Drawing.Point(15, 12)
        Me.lblAvailableCount.Size = New System.Drawing.Size(210, 58)
        Me.lblAvailableCount.Text = "0"
        Me.lblAvailableCount.Name = "lblAvailableCount"

        Me.lblAvailableTitle.AutoSize = False
        Me.lblAvailableTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblAvailableTitle.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.lblAvailableTitle.Location = New System.Drawing.Point(15, 75)
        Me.lblAvailableTitle.Size = New System.Drawing.Size(210, 22)
        Me.lblAvailableTitle.Text = "AVAILABLE ROOMS"
        Me.lblAvailableTitle.Name = "lblAvailableTitle"

        ' Reserved
        Me.pnlReserved.Location = New System.Drawing.Point(280, 82)
        Me.pnlReserved.Size = New System.Drawing.Size(240, 110)
        Me.pnlReserved.BackColor = System.Drawing.Color.White
        Me.pnlReserved.Name = "pnlReserved"
        Me.pnlReserved.Controls.Add(Me.lblReservedCount)
        Me.pnlReserved.Controls.Add(Me.lblReservedTitle)

        Me.lblReservedCount.AutoSize = False
        Me.lblReservedCount.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblReservedCount.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185)
        Me.lblReservedCount.Location = New System.Drawing.Point(15, 12)
        Me.lblReservedCount.Size = New System.Drawing.Size(210, 58)
        Me.lblReservedCount.Text = "0"
        Me.lblReservedCount.Name = "lblReservedCount"

        Me.lblReservedTitle.AutoSize = False
        Me.lblReservedTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblReservedTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185)
        Me.lblReservedTitle.Location = New System.Drawing.Point(15, 75)
        Me.lblReservedTitle.Size = New System.Drawing.Size(210, 22)
        Me.lblReservedTitle.Text = "RESERVED ROOMS"
        Me.lblReservedTitle.Name = "lblReservedTitle"

        ' Occupied
        Me.pnlOccupied.Location = New System.Drawing.Point(535, 82)
        Me.pnlOccupied.Size = New System.Drawing.Size(240, 110)
        Me.pnlOccupied.BackColor = System.Drawing.Color.White
        Me.pnlOccupied.Name = "pnlOccupied"
        Me.pnlOccupied.Controls.Add(Me.lblOccupiedCount)
        Me.pnlOccupied.Controls.Add(Me.lblOccupiedTitle)

        Me.lblOccupiedCount.AutoSize = False
        Me.lblOccupiedCount.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblOccupiedCount.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43)
        Me.lblOccupiedCount.Location = New System.Drawing.Point(15, 12)
        Me.lblOccupiedCount.Size = New System.Drawing.Size(210, 58)
        Me.lblOccupiedCount.Text = "0"
        Me.lblOccupiedCount.Name = "lblOccupiedCount"

        Me.lblOccupiedTitle.AutoSize = False
        Me.lblOccupiedTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblOccupiedTitle.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43)
        Me.lblOccupiedTitle.Location = New System.Drawing.Point(15, 75)
        Me.lblOccupiedTitle.Size = New System.Drawing.Size(210, 22)
        Me.lblOccupiedTitle.Text = "OCCUPIED ROOMS"
        Me.lblOccupiedTitle.Name = "lblOccupiedTitle"

        ' Maintenance
        Me.pnlMaintenance.Location = New System.Drawing.Point(790, 82)
        Me.pnlMaintenance.Size = New System.Drawing.Size(240, 110)
        Me.pnlMaintenance.BackColor = System.Drawing.Color.White
        Me.pnlMaintenance.Name = "pnlMaintenance"
        Me.pnlMaintenance.Controls.Add(Me.lblMaintenanceCount)
        Me.pnlMaintenance.Controls.Add(Me.lblMaintenanceTitle)

        Me.lblMaintenanceCount.AutoSize = False
        Me.lblMaintenanceCount.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblMaintenanceCount.ForeColor = System.Drawing.Color.FromArgb(211, 84, 0)
        Me.lblMaintenanceCount.Location = New System.Drawing.Point(15, 12)
        Me.lblMaintenanceCount.Size = New System.Drawing.Size(210, 58)
        Me.lblMaintenanceCount.Text = "0"
        Me.lblMaintenanceCount.Name = "lblMaintenanceCount"

        Me.lblMaintenanceTitle.AutoSize = False
        Me.lblMaintenanceTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblMaintenanceTitle.ForeColor = System.Drawing.Color.FromArgb(211, 84, 0)
        Me.lblMaintenanceTitle.Location = New System.Drawing.Point(15, 75)
        Me.lblMaintenanceTitle.Size = New System.Drawing.Size(210, 22)
        Me.lblMaintenanceTitle.Text = "UNDER MAINTENANCE"
        Me.lblMaintenanceTitle.Name = "lblMaintenanceTitle"

        '=== PANEL: Today Check Ins (y=210, height=185) ===
        Me.pnlCheckIns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCheckIns.BackColor = System.Drawing.Color.White
        Me.pnlCheckIns.Location = New System.Drawing.Point(25, 210)
        Me.pnlCheckIns.Size = New System.Drawing.Size(500, 185)
        Me.pnlCheckIns.Name = "pnlCheckIns"
        Me.pnlCheckIns.Controls.Add(Me.lblCheckInsTitle)
        Me.pnlCheckIns.Controls.Add(Me.dgvCheckIns)

        Me.lblCheckInsTitle.AutoSize = False
        Me.lblCheckInsTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCheckInsTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.lblCheckInsTitle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.lblCheckInsTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblCheckInsTitle.Size = New System.Drawing.Size(500, 32)
        Me.lblCheckInsTitle.Text = "  Today's Expected Check-Ins"
        Me.lblCheckInsTitle.Name = "lblCheckInsTitle"

        Me.dgvCheckIns.Location = New System.Drawing.Point(0, 32)
        Me.dgvCheckIns.Size = New System.Drawing.Size(498, 151)
        Me.dgvCheckIns.Name = "dgvCheckIns"
        Me.dgvCheckIns.AllowUserToAddRows = False
        Me.dgvCheckIns.AllowUserToDeleteRows = False
        Me.dgvCheckIns.ReadOnly = True
        Me.dgvCheckIns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCheckIns.MultiSelect = False
        Me.dgvCheckIns.BackgroundColor = System.Drawing.Color.White
        Me.dgvCheckIns.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCheckIns.RowHeadersVisible = False
        Me.dgvCheckIns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCheckIns.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.dgvCheckIns.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.dgvCheckIns.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.dgvCheckIns.ColumnHeadersHeight = 30
        Me.dgvCheckIns.EnableHeadersVisualStyles = False
        Me.dgvCheckIns.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dgvCheckIns.RowTemplate.Height = 28
        Me.dgvCheckIns.GridColor = System.Drawing.Color.FromArgb(230, 230, 230)

        '=== PANEL: Today Check Outs ===
        Me.pnlCheckOuts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCheckOuts.BackColor = System.Drawing.Color.White
        Me.pnlCheckOuts.Location = New System.Drawing.Point(535, 210)
        Me.pnlCheckOuts.Size = New System.Drawing.Size(495, 185)
        Me.pnlCheckOuts.Name = "pnlCheckOuts"
        Me.pnlCheckOuts.Controls.Add(Me.lblCheckOutsTitle)
        Me.pnlCheckOuts.Controls.Add(Me.dgvCheckOuts)

        Me.lblCheckOutsTitle.AutoSize = False
        Me.lblCheckOutsTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCheckOutsTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.lblCheckOutsTitle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.lblCheckOutsTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblCheckOutsTitle.Size = New System.Drawing.Size(495, 32)
        Me.lblCheckOutsTitle.Text = "  Today's Expected Check-Outs"
        Me.lblCheckOutsTitle.Name = "lblCheckOutsTitle"

        Me.dgvCheckOuts.Location = New System.Drawing.Point(0, 32)
        Me.dgvCheckOuts.Size = New System.Drawing.Size(493, 151)
        Me.dgvCheckOuts.Name = "dgvCheckOuts"
        Me.dgvCheckOuts.AllowUserToAddRows = False
        Me.dgvCheckOuts.AllowUserToDeleteRows = False
        Me.dgvCheckOuts.ReadOnly = True
        Me.dgvCheckOuts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCheckOuts.MultiSelect = False
        Me.dgvCheckOuts.BackgroundColor = System.Drawing.Color.White
        Me.dgvCheckOuts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCheckOuts.RowHeadersVisible = False
        Me.dgvCheckOuts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCheckOuts.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.dgvCheckOuts.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.dgvCheckOuts.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.dgvCheckOuts.ColumnHeadersHeight = 30
        Me.dgvCheckOuts.EnableHeadersVisualStyles = False
        Me.dgvCheckOuts.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dgvCheckOuts.RowTemplate.Height = 28
        Me.dgvCheckOuts.GridColor = System.Drawing.Color.FromArgb(230, 230, 230)

        '=== PANEL: Recent Activity (y=410, height=195) ===
        Me.pnlRecentActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRecentActivity.BackColor = System.Drawing.Color.White
        Me.pnlRecentActivity.Location = New System.Drawing.Point(25, 410)
        Me.pnlRecentActivity.Size = New System.Drawing.Size(1005, 195)
        Me.pnlRecentActivity.Name = "pnlRecentActivity"
        Me.pnlRecentActivity.Controls.Add(Me.lblRecentTitle)
        Me.pnlRecentActivity.Controls.Add(Me.dgvRecentActivity)

        Me.lblRecentTitle.AutoSize = False
        Me.lblRecentTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblRecentTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.lblRecentTitle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.lblRecentTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblRecentTitle.Size = New System.Drawing.Size(1005, 32)
        Me.lblRecentTitle.Text = "  Recent Activity"
        Me.lblRecentTitle.Name = "lblRecentTitle"

        Me.dgvRecentActivity.Location = New System.Drawing.Point(0, 32)
        Me.dgvRecentActivity.Size = New System.Drawing.Size(1003, 161)
        Me.dgvRecentActivity.Name = "dgvRecentActivity"
        Me.dgvRecentActivity.AllowUserToAddRows = False
        Me.dgvRecentActivity.AllowUserToDeleteRows = False
        Me.dgvRecentActivity.ReadOnly = True
        Me.dgvRecentActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecentActivity.MultiSelect = False
        Me.dgvRecentActivity.BackgroundColor = System.Drawing.Color.White
        Me.dgvRecentActivity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRecentActivity.RowHeadersVisible = False
        Me.dgvRecentActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRecentActivity.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.dgvRecentActivity.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.dgvRecentActivity.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.dgvRecentActivity.ColumnHeadersHeight = 30
        Me.dgvRecentActivity.EnableHeadersVisualStyles = False
        Me.dgvRecentActivity.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dgvRecentActivity.RowTemplate.Height = 28
        Me.dgvRecentActivity.GridColor = System.Drawing.Color.FromArgb(230, 230, 230)

        '=== ADD CONTROLS TO FORM ===
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.pnlAvailable)
        Me.Controls.Add(Me.pnlReserved)
        Me.Controls.Add(Me.pnlOccupied)
        Me.Controls.Add(Me.pnlMaintenance)
        Me.Controls.Add(Me.pnlCheckIns)
        Me.Controls.Add(Me.pnlCheckOuts)
        Me.Controls.Add(Me.pnlRecentActivity)

        Me.pnlAvailable.ResumeLayout(False)
        Me.pnlReserved.ResumeLayout(False)
        Me.pnlOccupied.ResumeLayout(False)
        Me.pnlMaintenance.ResumeLayout(False)
        Me.pnlCheckIns.ResumeLayout(False)
        Me.pnlCheckOuts.ResumeLayout(False)
        Me.pnlRecentActivity.ResumeLayout(False)
        CType(Me.dgvCheckIns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCheckOuts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRecentActivity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents pnlAvailable As System.Windows.Forms.Panel
    Friend WithEvents lblAvailableCount As System.Windows.Forms.Label
    Friend WithEvents lblAvailableTitle As System.Windows.Forms.Label
    Friend WithEvents pnlReserved As System.Windows.Forms.Panel
    Friend WithEvents lblReservedCount As System.Windows.Forms.Label
    Friend WithEvents lblReservedTitle As System.Windows.Forms.Label
    Friend WithEvents pnlOccupied As System.Windows.Forms.Panel
    Friend WithEvents lblOccupiedCount As System.Windows.Forms.Label
    Friend WithEvents lblOccupiedTitle As System.Windows.Forms.Label
    Friend WithEvents pnlMaintenance As System.Windows.Forms.Panel
    Friend WithEvents lblMaintenanceCount As System.Windows.Forms.Label
    Friend WithEvents lblMaintenanceTitle As System.Windows.Forms.Label
    Friend WithEvents pnlCheckIns As System.Windows.Forms.Panel
    Friend WithEvents lblCheckInsTitle As System.Windows.Forms.Label
    Friend WithEvents dgvCheckIns As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCheckOuts As System.Windows.Forms.Panel
    Friend WithEvents lblCheckOutsTitle As System.Windows.Forms.Label
    Friend WithEvents dgvCheckOuts As System.Windows.Forms.DataGridView
    Friend WithEvents pnlRecentActivity As System.Windows.Forms.Panel
    Friend WithEvents lblRecentTitle As System.Windows.Forms.Label
    Friend WithEvents dgvRecentActivity As System.Windows.Forms.DataGridView

End Class