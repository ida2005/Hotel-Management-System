Partial Class BookingForm
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
        Me.pnlForm = New System.Windows.Forms.Panel()
        Me.lblGuest = New System.Windows.Forms.Label()
        Me.cmbGuest = New System.Windows.Forms.ComboBox()
        Me.lblRoom = New System.Windows.Forms.Label()
        Me.cmbRoom = New System.Windows.Forms.ComboBox()
        Me.lblCheckIn = New System.Windows.Forms.Label()
        Me.dtpCheckIn = New System.Windows.Forms.DateTimePicker()
        Me.lblCheckOut = New System.Windows.Forms.Label()
        Me.dtpCheckOut = New System.Windows.Forms.DateTimePicker()
        Me.lblNights = New System.Windows.Forms.Label()
        Me.lblNightsValue = New System.Windows.Forms.Label()
        Me.lblPricePerNight = New System.Windows.Forms.Label()
        Me.lblPriceValue = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTotalValue = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgvBookings = New System.Windows.Forms.DataGridView()
        Me.pnlForm.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        CType(Me.dgvBookings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        '=== FORM ===
        Me.ClientSize = New System.Drawing.Size(1060, 620)
        Me.BackColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "BookingForm"
        Me.Text = "Booking Management"
        Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)

        '=== LABEL: Title ===
        Me.lblTitle.AutoSize = False
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Size = New System.Drawing.Size(300, 35)
        Me.lblTitle.Text = "Booking Management"
        Me.lblTitle.Name = "lblTitle"

        '=== PANEL: FORM (left side) ===
        Me.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlForm.Location = New System.Drawing.Point(20, 60)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Size = New System.Drawing.Size(320, 540)
        Me.pnlForm.BackColor = System.Drawing.Color.FromArgb(248, 248, 248)
        Me.pnlForm.Controls.Add(Me.lblGuest)
        Me.pnlForm.Controls.Add(Me.cmbGuest)
        Me.pnlForm.Controls.Add(Me.lblRoom)
        Me.pnlForm.Controls.Add(Me.cmbRoom)
        Me.pnlForm.Controls.Add(Me.lblCheckIn)
        Me.pnlForm.Controls.Add(Me.dtpCheckIn)
        Me.pnlForm.Controls.Add(Me.lblCheckOut)
        Me.pnlForm.Controls.Add(Me.dtpCheckOut)
        Me.pnlForm.Controls.Add(Me.lblNights)
        Me.pnlForm.Controls.Add(Me.lblNightsValue)
        Me.pnlForm.Controls.Add(Me.lblPricePerNight)
        Me.pnlForm.Controls.Add(Me.lblPriceValue)
        Me.pnlForm.Controls.Add(Me.lblTotal)
        Me.pnlForm.Controls.Add(Me.lblTotalValue)
        Me.pnlForm.Controls.Add(Me.lblStatus)
        Me.pnlForm.Controls.Add(Me.cmbStatus)
        Me.pnlForm.Controls.Add(Me.lblNotes)
        Me.pnlForm.Controls.Add(Me.txtNotes)
        Me.pnlForm.Controls.Add(Me.btnAdd)
        Me.pnlForm.Controls.Add(Me.btnUpdate)
        Me.pnlForm.Controls.Add(Me.btnDelete)
        Me.pnlForm.Controls.Add(Me.btnClear)

        '=== LABEL: Guest ===
        Me.lblGuest.AutoSize = True
        Me.lblGuest.Location = New System.Drawing.Point(15, 15)
        Me.lblGuest.Name = "lblGuest"
        Me.lblGuest.Text = "Guest"

        '=== COMBOBOX: Guest ===
        Me.cmbGuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbGuest.Location = New System.Drawing.Point(15, 35)
        Me.cmbGuest.Name = "cmbGuest"
        Me.cmbGuest.Size = New System.Drawing.Size(285, 25)

        '=== LABEL: Room ===
        Me.lblRoom.AutoSize = True
        Me.lblRoom.Location = New System.Drawing.Point(15, 70)
        Me.lblRoom.Name = "lblRoom"
        Me.lblRoom.Text = "Room (Available Only)"

        '=== COMBOBOX: Room ===
        Me.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbRoom.Location = New System.Drawing.Point(15, 90)
        Me.cmbRoom.Name = "cmbRoom"
        Me.cmbRoom.Size = New System.Drawing.Size(285, 25)

        '=== LABEL: Check In ===
        Me.lblCheckIn.AutoSize = True
        Me.lblCheckIn.Location = New System.Drawing.Point(15, 125)
        Me.lblCheckIn.Name = "lblCheckIn"
        Me.lblCheckIn.Text = "Check-In Date"

        '=== DTP: Check In ===
        Me.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpCheckIn.Location = New System.Drawing.Point(15, 145)
        Me.dtpCheckIn.Name = "dtpCheckIn"
        Me.dtpCheckIn.Size = New System.Drawing.Size(285, 25)

        '=== LABEL: Check Out ===
        Me.lblCheckOut.AutoSize = True
        Me.lblCheckOut.Location = New System.Drawing.Point(15, 180)
        Me.lblCheckOut.Name = "lblCheckOut"
        Me.lblCheckOut.Text = "Check-Out Date"

        '=== DTP: Check Out ===
        Me.dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpCheckOut.Location = New System.Drawing.Point(15, 200)
        Me.dtpCheckOut.Name = "dtpCheckOut"
        Me.dtpCheckOut.Size = New System.Drawing.Size(285, 25)

        '=== SUMMARY PANEL LABELS ===
        Me.lblNights.AutoSize = True
        Me.lblNights.Location = New System.Drawing.Point(15, 238)
        Me.lblNights.Name = "lblNights"
        Me.lblNights.Text = "Nights:"
        Me.lblNights.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)

        Me.lblNightsValue.AutoSize = True
        Me.lblNightsValue.Location = New System.Drawing.Point(120, 238)
        Me.lblNightsValue.Name = "lblNightsValue"
        Me.lblNightsValue.Text = "0"

        Me.lblPricePerNight.AutoSize = True
        Me.lblPricePerNight.Location = New System.Drawing.Point(15, 260)
        Me.lblPricePerNight.Name = "lblPricePerNight"
        Me.lblPricePerNight.Text = "Price/Night:"
        Me.lblPricePerNight.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)

        Me.lblPriceValue.AutoSize = True
        Me.lblPriceValue.Location = New System.Drawing.Point(120, 260)
        Me.lblPriceValue.Name = "lblPriceValue"
        Me.lblPriceValue.Text = "0.00"

        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(15, 282)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Text = "Total Amount:"
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)

        Me.lblTotalValue.AutoSize = True
        Me.lblTotalValue.Location = New System.Drawing.Point(120, 282)
        Me.lblTotalValue.Name = "lblTotalValue"
        Me.lblTotalValue.Text = "0.00"
        Me.lblTotalValue.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)

        '=== LABEL: Status ===
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(15, 310)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Text = "Booking Status"

        '=== COMBOBOX: Status ===
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStatus.Location = New System.Drawing.Point(15, 330)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(285, 25)
        Me.cmbStatus.Items.AddRange(New Object() {"Pending", "Confirmed", "Cancelled"})

        '=== LABEL: Notes ===
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(15, 365)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Text = "Notes"

        '=== TEXTBOX: Notes ===
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.Location = New System.Drawing.Point(15, 385)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(285, 55)
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical

        '=== BUTTON: Add ===
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.Location = New System.Drawing.Point(15, 455)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(130, 35)
        Me.btnAdd.Text = "Add Booking"
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand

        '=== BUTTON: Update ===
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.Location = New System.Drawing.Point(170, 455)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(130, 35)
        Me.btnUpdate.Text = "Update Booking"
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand

        '=== BUTTON: Delete ===
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(200, 35, 51)
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.Location = New System.Drawing.Point(15, 500)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(130, 35)
        Me.btnDelete.Text = "Delete Booking"
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand

        '=== BUTTON: Clear ===
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(108, 117, 125)
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnClear.Location = New System.Drawing.Point(170, 500)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(130, 35)
        Me.btnClear.Text = "Clear"
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand

        '=== PANEL: GRID (right side) ===
        Me.pnlGrid.Location = New System.Drawing.Point(360, 60)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(680, 540)
        Me.pnlGrid.Controls.Add(Me.lblSearch)
        Me.pnlGrid.Controls.Add(Me.txtSearch)
        Me.pnlGrid.Controls.Add(Me.btnSearch)
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
        Me.txtSearch.Size = New System.Drawing.Size(480, 25)

        '=== BUTTON: Search ===
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.btnSearch.Location = New System.Drawing.Point(545, 1)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 27)
        Me.btnSearch.Text = "Search"
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand

        '=== DATAGRIDVIEW: Bookings ===
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
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.pnlGrid)

        Me.pnlForm.ResumeLayout(False)
        Me.pnlForm.PerformLayout()
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGrid.PerformLayout()
        CType(Me.dgvBookings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlForm As System.Windows.Forms.Panel
    Friend WithEvents lblGuest As System.Windows.Forms.Label
    Friend WithEvents cmbGuest As System.Windows.Forms.ComboBox
    Friend WithEvents lblRoom As System.Windows.Forms.Label
    Friend WithEvents cmbRoom As System.Windows.Forms.ComboBox
    Friend WithEvents lblCheckIn As System.Windows.Forms.Label
    Friend WithEvents dtpCheckIn As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCheckOut As System.Windows.Forms.Label
    Friend WithEvents dtpCheckOut As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNights As System.Windows.Forms.Label
    Friend WithEvents lblNightsValue As System.Windows.Forms.Label
    Friend WithEvents lblPricePerNight As System.Windows.Forms.Label
    Friend WithEvents lblPriceValue As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblTotalValue As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvBookings As System.Windows.Forms.DataGridView

End Class