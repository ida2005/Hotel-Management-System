Partial Class GuestViewForm
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
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlGuests = New System.Windows.Forms.Panel()
        Me.lblGuestsTitle = New System.Windows.Forms.Label()
        Me.dgvGuests = New System.Windows.Forms.DataGridView()
        Me.pnlDetails = New System.Windows.Forms.Panel()
        Me.lblDetailsTitle = New System.Windows.Forms.Label()
        Me.lblGuestID = New System.Windows.Forms.Label()
        Me.lblGuestIDValue = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblFullNameValue = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblEmailValue = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblPhoneValue = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblAddressValue = New System.Windows.Forms.Label()
        Me.lblIDType = New System.Windows.Forms.Label()
        Me.lblIDTypeValue = New System.Windows.Forms.Label()
        Me.lblIDNumber = New System.Windows.Forms.Label()
        Me.lblIDNumberValue = New System.Windows.Forms.Label()
        Me.lblDateAdded = New System.Windows.Forms.Label()
        Me.lblDateAddedValue = New System.Windows.Forms.Label()
        Me.pnlBookings = New System.Windows.Forms.Panel()
        Me.lblBookingsTitle = New System.Windows.Forms.Label()
        Me.dgvBookingHistory = New System.Windows.Forms.DataGridView()
        Me.pnlSearch.SuspendLayout()
        Me.pnlGuests.SuspendLayout()
        Me.pnlDetails.SuspendLayout()
        Me.pnlBookings.SuspendLayout()
        CType(Me.dgvGuests, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBookingHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        '=== FORM ===
        Me.ClientSize = New System.Drawing.Size(1060, 620)
        Me.BackColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "GuestViewForm"
        Me.Text = "Guest View"
        Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)

        '=== LABEL: Title ===
        Me.lblTitle.AutoSize = False
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Size = New System.Drawing.Size(300, 35)
        Me.lblTitle.Text = "Guest View"
        Me.lblTitle.Name = "lblTitle"

        '=== PANEL: SEARCH BAR ===
        Me.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSearch.BackColor = System.Drawing.Color.FromArgb(248, 248, 248)
        Me.pnlSearch.Location = New System.Drawing.Point(20, 55)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(1020, 45)
        Me.pnlSearch.Controls.Add(Me.lblSearch)
        Me.pnlSearch.Controls.Add(Me.txtSearch)
        Me.pnlSearch.Controls.Add(Me.btnSearch)
        Me.pnlSearch.Controls.Add(Me.btnRefresh)

        '=== LABEL: Search ===
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(10, 12)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Text = "Search Guest:"

        '=== TEXTBOX: Search ===
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(100, 9)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(400, 25)

        '=== BUTTON: Search ===
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.btnSearch.Location = New System.Drawing.Point(510, 8)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 27)
        Me.btnSearch.Text = "Search"
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand

        '=== BUTTON: Refresh ===
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(108, 117, 125)
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.btnRefresh.Location = New System.Drawing.Point(600, 8)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(80, 27)
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand

        '=== PANEL: GUESTS GRID (top left) ===
        Me.pnlGuests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlGuests.Location = New System.Drawing.Point(20, 110)
        Me.pnlGuests.Name = "pnlGuests"
        Me.pnlGuests.Size = New System.Drawing.Size(580, 280)
        Me.pnlGuests.Controls.Add(Me.lblGuestsTitle)
        Me.pnlGuests.Controls.Add(Me.dgvGuests)

        '=== LABEL: Guests Title ===
        Me.lblGuestsTitle.AutoSize = False
        Me.lblGuestsTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblGuestsTitle.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.lblGuestsTitle.Location = New System.Drawing.Point(5, 5)
        Me.lblGuestsTitle.Size = New System.Drawing.Size(200, 25)
        Me.lblGuestsTitle.Text = "Guest List"
        Me.lblGuestsTitle.Name = "lblGuestsTitle"

        '=== DATAGRIDVIEW: Guests ===
        Me.dgvGuests.AllowUserToAddRows = False
        Me.dgvGuests.AllowUserToDeleteRows = False
        Me.dgvGuests.ReadOnly = True
        Me.dgvGuests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGuests.MultiSelect = False
        Me.dgvGuests.BackgroundColor = System.Drawing.Color.White
        Me.dgvGuests.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvGuests.RowHeadersVisible = False
        Me.dgvGuests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGuests.Location = New System.Drawing.Point(0, 30)
        Me.dgvGuests.Name = "dgvGuests"
        Me.dgvGuests.Size = New System.Drawing.Size(578, 248)
        Me.dgvGuests.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.dgvGuests.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.dgvGuests.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.dgvGuests.ColumnHeadersHeight = 32
        Me.dgvGuests.EnableHeadersVisualStyles = False
        Me.dgvGuests.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dgvGuests.RowTemplate.Height = 28

        '=== PANEL: DETAILS (top right) ===
        Me.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetails.BackColor = System.Drawing.Color.FromArgb(248, 248, 248)
        Me.pnlDetails.Location = New System.Drawing.Point(615, 110)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(425, 280)
        Me.pnlDetails.Controls.Add(Me.lblDetailsTitle)
        Me.pnlDetails.Controls.Add(Me.lblGuestID)
        Me.pnlDetails.Controls.Add(Me.lblGuestIDValue)
        Me.pnlDetails.Controls.Add(Me.lblFullName)
        Me.pnlDetails.Controls.Add(Me.lblFullNameValue)
        Me.pnlDetails.Controls.Add(Me.lblEmail)
        Me.pnlDetails.Controls.Add(Me.lblEmailValue)
        Me.pnlDetails.Controls.Add(Me.lblPhone)
        Me.pnlDetails.Controls.Add(Me.lblPhoneValue)
        Me.pnlDetails.Controls.Add(Me.lblAddress)
        Me.pnlDetails.Controls.Add(Me.lblAddressValue)
        Me.pnlDetails.Controls.Add(Me.lblIDType)
        Me.pnlDetails.Controls.Add(Me.lblIDTypeValue)
        Me.pnlDetails.Controls.Add(Me.lblIDNumber)
        Me.pnlDetails.Controls.Add(Me.lblIDNumberValue)
        Me.pnlDetails.Controls.Add(Me.lblDateAdded)
        Me.pnlDetails.Controls.Add(Me.lblDateAddedValue)

        '=== LABEL: Details Title ===
        Me.lblDetailsTitle.AutoSize = False
        Me.lblDetailsTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.lblDetailsTitle.Location = New System.Drawing.Point(5, 5)
        Me.lblDetailsTitle.Size = New System.Drawing.Size(200, 25)
        Me.lblDetailsTitle.Text = "Guest Details"
        Me.lblDetailsTitle.Name = "lblDetailsTitle"

        '=== DETAIL LABELS HELPER ===
        Dim dy As Integer = 35
        Dim dGap As Integer = 28
        Dim lblX As Integer = 10
        Dim valX As Integer = 110

        '=== Guest ID ===
        Me.lblGuestID.AutoSize = True
        Me.lblGuestID.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblGuestID.Location = New System.Drawing.Point(lblX, dy)
        Me.lblGuestID.Name = "lblGuestID"
        Me.lblGuestID.Text = "Guest ID:"

        Me.lblGuestIDValue.AutoSize = True
        Me.lblGuestIDValue.Location = New System.Drawing.Point(valX, dy)
        Me.lblGuestIDValue.Name = "lblGuestIDValue"
        Me.lblGuestIDValue.Text = "-"
        dy += dGap

        '=== Full Name ===
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblFullName.Location = New System.Drawing.Point(lblX, dy)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Text = "Full Name:"

        Me.lblFullNameValue.AutoSize = True
        Me.lblFullNameValue.Location = New System.Drawing.Point(valX, dy)
        Me.lblFullNameValue.Name = "lblFullNameValue"
        Me.lblFullNameValue.Text = "-"
        dy += dGap

        '=== Email ===
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmail.Location = New System.Drawing.Point(lblX, dy)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Text = "Email:"

        Me.lblEmailValue.AutoSize = True
        Me.lblEmailValue.Location = New System.Drawing.Point(valX, dy)
        Me.lblEmailValue.Name = "lblEmailValue"
        Me.lblEmailValue.Text = "-"
        dy += dGap

        '=== Phone ===
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPhone.Location = New System.Drawing.Point(lblX, dy)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Text = "Phone:"

        Me.lblPhoneValue.AutoSize = True
        Me.lblPhoneValue.Location = New System.Drawing.Point(valX, dy)
        Me.lblPhoneValue.Name = "lblPhoneValue"
        Me.lblPhoneValue.Text = "-"
        dy += dGap

        '=== Address ===
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAddress.Location = New System.Drawing.Point(lblX, dy)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Text = "Address:"

        Me.lblAddressValue.AutoSize = False
        Me.lblAddressValue.Location = New System.Drawing.Point(valX, dy)
        Me.lblAddressValue.Size = New System.Drawing.Size(300, 35)
        Me.lblAddressValue.Name = "lblAddressValue"
        Me.lblAddressValue.Text = "-"
        dy += dGap + 10

        '=== ID Type ===
        Me.lblIDType.AutoSize = True
        Me.lblIDType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIDType.Location = New System.Drawing.Point(lblX, dy)
        Me.lblIDType.Name = "lblIDType"
        Me.lblIDType.Text = "ID Type:"

        Me.lblIDTypeValue.AutoSize = True
        Me.lblIDTypeValue.Location = New System.Drawing.Point(valX, dy)
        Me.lblIDTypeValue.Name = "lblIDTypeValue"
        Me.lblIDTypeValue.Text = "-"
        dy += dGap

        '=== ID Number ===
        Me.lblIDNumber.AutoSize = True
        Me.lblIDNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIDNumber.Location = New System.Drawing.Point(lblX, dy)
        Me.lblIDNumber.Name = "lblIDNumber"
        Me.lblIDNumber.Text = "ID Number:"

        Me.lblIDNumberValue.AutoSize = True
        Me.lblIDNumberValue.Location = New System.Drawing.Point(valX, dy)
        Me.lblIDNumberValue.Name = "lblIDNumberValue"
        Me.lblIDNumberValue.Text = "-"
        dy += dGap

        '=== Date Added ===
        Me.lblDateAdded.AutoSize = True
        Me.lblDateAdded.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDateAdded.Location = New System.Drawing.Point(lblX, dy)
        Me.lblDateAdded.Name = "lblDateAdded"
        Me.lblDateAdded.Text = "Date Added:"

        Me.lblDateAddedValue.AutoSize = True
        Me.lblDateAddedValue.Location = New System.Drawing.Point(valX, dy)
        Me.lblDateAddedValue.Name = "lblDateAddedValue"
        Me.lblDateAddedValue.Text = "-"

        '=== PANEL: BOOKING HISTORY (bottom full width) ===
        Me.pnlBookings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBookings.Location = New System.Drawing.Point(20, 400)
        Me.pnlBookings.Name = "pnlBookings"
        Me.pnlBookings.Size = New System.Drawing.Size(1020, 210)
        Me.pnlBookings.Controls.Add(Me.lblBookingsTitle)
        Me.pnlBookings.Controls.Add(Me.dgvBookingHistory)

        '=== LABEL: Booking History Title ===
        Me.lblBookingsTitle.AutoSize = False
        Me.lblBookingsTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblBookingsTitle.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.lblBookingsTitle.Location = New System.Drawing.Point(5, 5)
        Me.lblBookingsTitle.Size = New System.Drawing.Size(300, 25)
        Me.lblBookingsTitle.Text = "Booking History"
        Me.lblBookingsTitle.Name = "lblBookingsTitle"

        '=== DATAGRIDVIEW: Booking History ===
        Me.dgvBookingHistory.AllowUserToAddRows = False
        Me.dgvBookingHistory.AllowUserToDeleteRows = False
        Me.dgvBookingHistory.ReadOnly = True
        Me.dgvBookingHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBookingHistory.MultiSelect = False
        Me.dgvBookingHistory.BackgroundColor = System.Drawing.Color.White
        Me.dgvBookingHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvBookingHistory.RowHeadersVisible = False
        Me.dgvBookingHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBookingHistory.Location = New System.Drawing.Point(0, 30)
        Me.dgvBookingHistory.Name = "dgvBookingHistory"
        Me.dgvBookingHistory.Size = New System.Drawing.Size(1018, 178)
        Me.dgvBookingHistory.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.dgvBookingHistory.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.dgvBookingHistory.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.dgvBookingHistory.ColumnHeadersHeight = 32
        Me.dgvBookingHistory.EnableHeadersVisualStyles = False
        Me.dgvBookingHistory.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dgvBookingHistory.RowTemplate.Height = 28

        '=== ADD CONTROLS TO FORM ===
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.pnlGuests)
        Me.Controls.Add(Me.pnlDetails)
        Me.Controls.Add(Me.pnlBookings)

        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.pnlGuests.ResumeLayout(False)
        Me.pnlDetails.ResumeLayout(False)
        Me.pnlDetails.PerformLayout()
        Me.pnlBookings.ResumeLayout(False)
        CType(Me.dgvGuests, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBookingHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents pnlGuests As System.Windows.Forms.Panel
    Friend WithEvents lblGuestsTitle As System.Windows.Forms.Label
    Friend WithEvents dgvGuests As System.Windows.Forms.DataGridView
    Friend WithEvents pnlDetails As System.Windows.Forms.Panel
    Friend WithEvents lblDetailsTitle As System.Windows.Forms.Label
    Friend WithEvents lblGuestID As System.Windows.Forms.Label
    Friend WithEvents lblGuestIDValue As System.Windows.Forms.Label
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblFullNameValue As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblEmailValue As System.Windows.Forms.Label
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents lblPhoneValue As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblAddressValue As System.Windows.Forms.Label
    Friend WithEvents lblIDType As System.Windows.Forms.Label
    Friend WithEvents lblIDTypeValue As System.Windows.Forms.Label
    Friend WithEvents lblIDNumber As System.Windows.Forms.Label
    Friend WithEvents lblIDNumberValue As System.Windows.Forms.Label
    Friend WithEvents lblDateAdded As System.Windows.Forms.Label
    Friend WithEvents lblDateAddedValue As System.Windows.Forms.Label
    Friend WithEvents pnlBookings As System.Windows.Forms.Panel
    Friend WithEvents lblBookingsTitle As System.Windows.Forms.Label
    Friend WithEvents dgvBookingHistory As System.Windows.Forms.DataGridView

End Class