Partial Class CheckInCheckOut
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.lblBookingID = New System.Windows.Forms.Label()
        Me.lblBookingIDValue = New System.Windows.Forms.Label()
        Me.lblGuestName = New System.Windows.Forms.Label()
        Me.lblGuestNameValue = New System.Windows.Forms.Label()
        Me.lblRoomNumber = New System.Windows.Forms.Label()
        Me.lblRoomNumberValue = New System.Windows.Forms.Label()
        Me.lblRoomType = New System.Windows.Forms.Label()
        Me.lblRoomTypeValue = New System.Windows.Forms.Label()
        Me.lblCheckIn = New System.Windows.Forms.Label()
        Me.lblCheckInValue = New System.Windows.Forms.Label()
        Me.lblCheckOut = New System.Windows.Forms.Label()
        Me.lblCheckOutValue = New System.Windows.Forms.Label()
        Me.lblNights = New System.Windows.Forms.Label()
        Me.lblNightsValue = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lblTotalAmountValue = New System.Windows.Forms.Label()
        Me.lblBookingStatus = New System.Windows.Forms.Label()
        Me.lblBookingStatusValue = New System.Windows.Forms.Label()
        Me.btnCheckIn = New System.Windows.Forms.Button()
        Me.btnCheckOut = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.cmbFilter = New System.Windows.Forms.ComboBox()
        Me.dgvBookings = New System.Windows.Forms.DataGridView()
        Me.pnlInfo.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        CType(Me.dgvBookings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        '=== FORM ===
        Me.ClientSize = New System.Drawing.Size(1060, 620)
        Me.BackColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CheckInCheckOut"
        Me.Text = "Check In / Check Out"
        Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)

        '=== LABEL: Title ===
        Me.lblTitle.AutoSize = False
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Size = New System.Drawing.Size(300, 35)
        Me.lblTitle.Text = "Check In / Check Out"
        Me.lblTitle.Name = "lblTitle"

        '=== PANEL: INFO (left side) ===
        Me.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInfo.Location = New System.Drawing.Point(20, 60)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(320, 540)
        Me.pnlInfo.BackColor = System.Drawing.Color.FromArgb(248, 248, 248)
        Me.pnlInfo.Controls.Add(Me.lblBookingID)
        Me.pnlInfo.Controls.Add(Me.lblBookingIDValue)
        Me.pnlInfo.Controls.Add(Me.lblGuestName)
        Me.pnlInfo.Controls.Add(Me.lblGuestNameValue)
        Me.pnlInfo.Controls.Add(Me.lblRoomNumber)
        Me.pnlInfo.Controls.Add(Me.lblRoomNumberValue)
        Me.pnlInfo.Controls.Add(Me.lblRoomType)
        Me.pnlInfo.Controls.Add(Me.lblRoomTypeValue)
        Me.pnlInfo.Controls.Add(Me.lblCheckIn)
        Me.pnlInfo.Controls.Add(Me.lblCheckInValue)
        Me.pnlInfo.Controls.Add(Me.lblCheckOut)
        Me.pnlInfo.Controls.Add(Me.lblCheckOutValue)
        Me.pnlInfo.Controls.Add(Me.lblNights)
        Me.pnlInfo.Controls.Add(Me.lblNightsValue)
        Me.pnlInfo.Controls.Add(Me.lblTotalAmount)
        Me.pnlInfo.Controls.Add(Me.lblTotalAmountValue)
        Me.pnlInfo.Controls.Add(Me.lblBookingStatus)
        Me.pnlInfo.Controls.Add(Me.lblBookingStatusValue)
        Me.pnlInfo.Controls.Add(Me.btnCheckIn)
        Me.pnlInfo.Controls.Add(Me.btnCheckOut)
        Me.pnlInfo.Controls.Add(Me.btnClear)

        ' ly starts at 20, gap = 40
        ' ly values: 20, 60, 100, 140, 180, 220, 260, 300, 340
        ' after status: ly += gap+10 = 390
        ' btnCheckIn at 390, btnCheckOut at 440, btnClear at 490

        '=== Booking ID (ly=20) ===
        Me.lblBookingID.AutoSize = True
        Me.lblBookingID.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblBookingID.Location = New System.Drawing.Point(15, 20)
        Me.lblBookingID.Name = "lblBookingID"
        Me.lblBookingID.Text = "Booking ID:"

        Me.lblBookingIDValue.AutoSize = True
        Me.lblBookingIDValue.Location = New System.Drawing.Point(130, 20)
        Me.lblBookingIDValue.Name = "lblBookingIDValue"
        Me.lblBookingIDValue.Text = "-"

        '=== Guest Name (ly=60) ===
        Me.lblGuestName.AutoSize = True
        Me.lblGuestName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblGuestName.Location = New System.Drawing.Point(15, 60)
        Me.lblGuestName.Name = "lblGuestName"
        Me.lblGuestName.Text = "Guest:"

        Me.lblGuestNameValue.AutoSize = True
        Me.lblGuestNameValue.Location = New System.Drawing.Point(130, 60)
        Me.lblGuestNameValue.Name = "lblGuestNameValue"
        Me.lblGuestNameValue.Text = "-"

        '=== Room Number (ly=100) ===
        Me.lblRoomNumber.AutoSize = True
        Me.lblRoomNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRoomNumber.Location = New System.Drawing.Point(15, 100)
        Me.lblRoomNumber.Name = "lblRoomNumber"
        Me.lblRoomNumber.Text = "Room No.:"

        Me.lblRoomNumberValue.AutoSize = True
        Me.lblRoomNumberValue.Location = New System.Drawing.Point(130, 100)
        Me.lblRoomNumberValue.Name = "lblRoomNumberValue"
        Me.lblRoomNumberValue.Text = "-"

        '=== Room Type (ly=140) ===
        Me.lblRoomType.AutoSize = True
        Me.lblRoomType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRoomType.Location = New System.Drawing.Point(15, 140)
        Me.lblRoomType.Name = "lblRoomType"
        Me.lblRoomType.Text = "Room Type:"

        Me.lblRoomTypeValue.AutoSize = True
        Me.lblRoomTypeValue.Location = New System.Drawing.Point(130, 140)
        Me.lblRoomTypeValue.Name = "lblRoomTypeValue"
        Me.lblRoomTypeValue.Text = "-"

        '=== Check In (ly=180) ===
        Me.lblCheckIn.AutoSize = True
        Me.lblCheckIn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCheckIn.Location = New System.Drawing.Point(15, 180)
        Me.lblCheckIn.Name = "lblCheckIn"
        Me.lblCheckIn.Text = "Check-In:"

        Me.lblCheckInValue.AutoSize = True
        Me.lblCheckInValue.Location = New System.Drawing.Point(130, 180)
        Me.lblCheckInValue.Name = "lblCheckInValue"
        Me.lblCheckInValue.Text = "-"

        '=== Check Out (ly=220) ===
        Me.lblCheckOut.AutoSize = True
        Me.lblCheckOut.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCheckOut.Location = New System.Drawing.Point(15, 220)
        Me.lblCheckOut.Name = "lblCheckOut"
        Me.lblCheckOut.Text = "Check-Out:"

        Me.lblCheckOutValue.AutoSize = True
        Me.lblCheckOutValue.Location = New System.Drawing.Point(130, 220)
        Me.lblCheckOutValue.Name = "lblCheckOutValue"
        Me.lblCheckOutValue.Text = "-"

        '=== Nights (ly=260) ===
        Me.lblNights.AutoSize = True
        Me.lblNights.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblNights.Location = New System.Drawing.Point(15, 260)
        Me.lblNights.Name = "lblNights"
        Me.lblNights.Text = "Nights:"

        Me.lblNightsValue.AutoSize = True
        Me.lblNightsValue.Location = New System.Drawing.Point(130, 260)
        Me.lblNightsValue.Name = "lblNightsValue"
        Me.lblNightsValue.Text = "-"

        '=== Total Amount (ly=300) ===
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.lblTotalAmount.Location = New System.Drawing.Point(15, 300)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Text = "Total Amount:"

        Me.lblTotalAmountValue.AutoSize = True
        Me.lblTotalAmountValue.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalAmountValue.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.lblTotalAmountValue.Location = New System.Drawing.Point(130, 300)
        Me.lblTotalAmountValue.Name = "lblTotalAmountValue"
        Me.lblTotalAmountValue.Text = "-"

        '=== Booking Status (ly=340) ===
        Me.lblBookingStatus.AutoSize = True
        Me.lblBookingStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblBookingStatus.Location = New System.Drawing.Point(15, 340)
        Me.lblBookingStatus.Name = "lblBookingStatus"
        Me.lblBookingStatus.Text = "Status:"

        Me.lblBookingStatusValue.AutoSize = True
        Me.lblBookingStatusValue.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblBookingStatusValue.Location = New System.Drawing.Point(130, 340)
        Me.lblBookingStatusValue.Name = "lblBookingStatusValue"
        Me.lblBookingStatusValue.Text = "-"

        '=== BUTTON: Check In (ly=390) ===
        Me.btnCheckIn.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.btnCheckIn.FlatAppearance.BorderSize = 0
        Me.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckIn.ForeColor = System.Drawing.Color.White
        Me.btnCheckIn.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCheckIn.Location = New System.Drawing.Point(15, 390)
        Me.btnCheckIn.Name = "btnCheckIn"
        Me.btnCheckIn.Size = New System.Drawing.Size(285, 40)
        Me.btnCheckIn.Text = "CHECK IN"
        Me.btnCheckIn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheckIn.Enabled = False

        '=== BUTTON: Check Out (ly=440) ===
        Me.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(200, 35, 51)
        Me.btnCheckOut.FlatAppearance.BorderSize = 0
        Me.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckOut.ForeColor = System.Drawing.Color.White
        Me.btnCheckOut.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCheckOut.Location = New System.Drawing.Point(15, 440)
        Me.btnCheckOut.Name = "btnCheckOut"
        Me.btnCheckOut.Size = New System.Drawing.Size(285, 40)
        Me.btnCheckOut.Text = "CHECK OUT"
        Me.btnCheckOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheckOut.Enabled = False

        '=== BUTTON: Clear (ly=490) ===
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(108, 117, 125)
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnClear.Location = New System.Drawing.Point(15, 490)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(285, 35)
        Me.btnClear.Text = "Clear Selection"
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand

        '=== PANEL: GRID (right side) ===
        Me.pnlGrid.Location = New System.Drawing.Point(360, 60)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(680, 540)
        Me.pnlGrid.Controls.Add(Me.lblSearch)
        Me.pnlGrid.Controls.Add(Me.txtSearch)
        Me.pnlGrid.Controls.Add(Me.btnSearch)
        Me.pnlGrid.Controls.Add(Me.lblFilter)
        Me.pnlGrid.Controls.Add(Me.cmbFilter)
        Me.pnlGrid.Controls.Add(Me.dgvBookings)

        '=== LABEL: Search ===
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(0, 5)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Text = "Search:"

        '=== TEXTBOX: Search ===
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(55, 2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(310, 25)

        '=== BUTTON: Search ===
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.btnSearch.Location = New System.Drawing.Point(375, 1)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 27)
        Me.btnSearch.Text = "Search"
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand

        '=== LABEL: Filter ===
        Me.lblFilter.AutoSize = True
        Me.lblFilter.Location = New System.Drawing.Point(460, 5)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Text = "Filter:"

        '=== COMBOBOX: Filter ===
        Me.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilter.Location = New System.Drawing.Point(500, 2)
        Me.cmbFilter.Name = "cmbFilter"
        Me.cmbFilter.Size = New System.Drawing.Size(175, 25)
        Me.cmbFilter.Items.AddRange(New Object() {"All", "Confirmed", "Checked In", "Checked Out", "Pending", "Cancelled"})

        '=== DATAGRIDVIEW ===
        Me.dgvBookings.AllowUserToAddRows = False
        Me.dgvBookings.AllowUserToDeleteRows = False
        Me.dgvBookings.ReadOnly = True
        Me.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBookings.MultiSelect = False
        Me.dgvBookings.BackgroundColor = System.Drawing.Color.White
        Me.dgvBookings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgvBookings.RowHeadersVisible = False
        Me.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBookings.Location = New System.Drawing.Point(0, 35)
        Me.dgvBookings.Name = "dgvBookings"
        Me.dgvBookings.Size = New System.Drawing.Size(678, 500)
        Me.dgvBookings.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.dgvBookings.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.dgvBookings.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.dgvBookings.ColumnHeadersHeight = 35
        Me.dgvBookings.EnableHeadersVisualStyles = False
        Me.dgvBookings.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dgvBookings.RowTemplate.Height = 30

        '=== ADD CONTROLS TO FORM ===
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlGrid)

        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGrid.PerformLayout()
        CType(Me.dgvBookings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents lblBookingID As System.Windows.Forms.Label
    Friend WithEvents lblBookingIDValue As System.Windows.Forms.Label
    Friend WithEvents lblGuestName As System.Windows.Forms.Label
    Friend WithEvents lblGuestNameValue As System.Windows.Forms.Label
    Friend WithEvents lblRoomNumber As System.Windows.Forms.Label
    Friend WithEvents lblRoomNumberValue As System.Windows.Forms.Label
    Friend WithEvents lblRoomType As System.Windows.Forms.Label
    Friend WithEvents lblRoomTypeValue As System.Windows.Forms.Label
    Friend WithEvents lblCheckIn As System.Windows.Forms.Label
    Friend WithEvents lblCheckInValue As System.Windows.Forms.Label
    Friend WithEvents lblCheckOut As System.Windows.Forms.Label
    Friend WithEvents lblCheckOutValue As System.Windows.Forms.Label
    Friend WithEvents lblNights As System.Windows.Forms.Label
    Friend WithEvents lblNightsValue As System.Windows.Forms.Label
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblTotalAmountValue As System.Windows.Forms.Label
    Friend WithEvents lblBookingStatus As System.Windows.Forms.Label
    Friend WithEvents lblBookingStatusValue As System.Windows.Forms.Label
    Friend WithEvents btnCheckIn As System.Windows.Forms.Button
    Friend WithEvents btnCheckOut As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblFilter As System.Windows.Forms.Label
    Friend WithEvents cmbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents dgvBookings As System.Windows.Forms.DataGridView

End Class