Imports System.Data.OleDb

Public Class BookingForm

    Private selectedBookingID As Integer = -1
    Private selectedRoomPrice As Decimal = 0

    ' ============================================================
    '  FORM LOAD
    ' ============================================================
    Private Sub BookingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGuests()
        LoadAvailableRooms()
        dtpCheckIn.Value = DateTime.Today
        dtpCheckOut.Value = DateTime.Today.AddDays(1)
        cmbStatus.SelectedIndex = 0
        LoadBookings()
    End Sub

    ' ============================================================
    '  LOAD GUESTS INTO COMBOBOX
    ' ============================================================
    Private Sub LoadGuests()
        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()
                Dim cmd As New OleDbCommand(
                    "SELECT GuestID, FirstName & ' ' & LastName AS FullName FROM tbl_Guests ORDER BY LastName", conn)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                cmbGuest.DataSource = Nothing
                Dim dt As New DataTable()
                dt.Load(reader)
                cmbGuest.DataSource = dt
                cmbGuest.DisplayMember = "FullName"
                cmbGuest.ValueMember = "GuestID"
                cmbGuest.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading guests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    '  LOAD AVAILABLE ROOMS INTO COMBOBOX
    ' ============================================================
    Private Sub LoadAvailableRooms()
        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()
                Dim cmd As New OleDbCommand(
                    "SELECT RoomID, RoomNumber & ' - ' & RoomType & ' (₱' & Price & ')' AS RoomInfo, Price " &
                    "FROM tbl_Rooms WHERE Status = 'Available' ORDER BY RoomNumber", conn)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                cmbRoom.DataSource = Nothing
                Dim dt As New DataTable()
                dt.Load(reader)
                cmbRoom.DataSource = dt
                cmbRoom.DisplayMember = "RoomInfo"
                cmbRoom.ValueMember = "RoomID"
                cmbRoom.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading rooms: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    '  LOAD ALL BOOKINGS INTO GRID
    ' ============================================================
    Private Sub LoadBookings(Optional filter As String = "")
        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                Dim query As String =
                    "SELECT b.BookingID, g.FirstName & ' ' & g.LastName AS GuestName, " &
                    "r.RoomNumber, r.RoomType, b.CheckInDate, b.CheckOutDate, " &
                    "b.TotalAmount, b.Status, b.DateBooked, b.Notes " &
                    "FROM (tbl_Bookings b " &
                    "INNER JOIN tbl_Guests g ON b.GuestID = g.GuestID) " &
                    "INNER JOIN tbl_Rooms r ON b.RoomID = r.RoomID"

                If filter <> "" Then
                    query &= " WHERE g.FirstName & ' ' & g.LastName LIKE '%" & filter & "%'" &
                             " OR r.RoomNumber LIKE '%" & filter & "%'" &
                             " OR b.Status LIKE '%" & filter & "%'"
                End If

                query &= " ORDER BY b.DateBooked DESC"

                Dim da As New OleDbDataAdapter(query, conn)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvBookings.DataSource = dt

                ' Hide BookingID
                If dgvBookings.Columns.Contains("BookingID") Then
                    dgvBookings.Columns("BookingID").Visible = False
                End If

                ' Rename headers
                If dgvBookings.Columns.Contains("GuestName") Then dgvBookings.Columns("GuestName").HeaderText = "Guest"
                If dgvBookings.Columns.Contains("RoomNumber") Then dgvBookings.Columns("RoomNumber").HeaderText = "Room No."
                If dgvBookings.Columns.Contains("RoomType") Then dgvBookings.Columns("RoomType").HeaderText = "Type"
                If dgvBookings.Columns.Contains("CheckInDate") Then dgvBookings.Columns("CheckInDate").HeaderText = "Check-In"
                If dgvBookings.Columns.Contains("CheckOutDate") Then dgvBookings.Columns("CheckOutDate").HeaderText = "Check-Out"
                If dgvBookings.Columns.Contains("TotalAmount") Then dgvBookings.Columns("TotalAmount").HeaderText = "Total (₱)"
                If dgvBookings.Columns.Contains("Status") Then dgvBookings.Columns("Status").HeaderText = "Status"
                If dgvBookings.Columns.Contains("DateBooked") Then dgvBookings.Columns("DateBooked").HeaderText = "Date Booked"
                If dgvBookings.Columns.Contains("Notes") Then dgvBookings.Columns("Notes").HeaderText = "Notes"

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading bookings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    '  ROOM SELECTION — Update price and recalculate
    ' ============================================================
    Private Sub cmbRoom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRoom.SelectedIndexChanged
        If cmbRoom.SelectedIndex = -1 Then
            selectedRoomPrice = 0
            lblPriceValue.Text = "0.00"
            CalculateTotal()
            Return
        End If

        Try
            Dim dt As DataTable = CType(cmbRoom.DataSource, DataTable)
            Dim row As DataRow = dt.Rows(cmbRoom.SelectedIndex)
            selectedRoomPrice = CDec(row("Price"))
            lblPriceValue.Text = selectedRoomPrice.ToString("N2")
            CalculateTotal()
        Catch ex As Exception
            selectedRoomPrice = 0
        End Try
    End Sub

    ' ============================================================
    '  DATE CHANGE — Recalculate total
    ' ============================================================
    Private Sub dtpCheckIn_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckIn.ValueChanged
        If dtpCheckIn.Value >= dtpCheckOut.Value Then
            dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1)
        End If
        CalculateTotal()
    End Sub

    Private Sub dtpCheckOut_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckOut.ValueChanged
        CalculateTotal()
    End Sub

    ' ============================================================
    '  CALCULATE TOTAL AMOUNT
    ' ============================================================
    Private Sub CalculateTotal()
        Dim nights As Integer = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days
        If nights < 1 Then nights = 0

        Dim total As Decimal = nights * selectedRoomPrice
        lblNightsValue.Text = nights.ToString()
        lblTotalValue.Text = total.ToString("N2")
    End Sub

    ' ============================================================
    '  ADD BOOKING
    ' ============================================================
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInputs() Then Return

        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                Dim nights As Integer = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days
                Dim total As Decimal = nights * selectedRoomPrice

                Dim cmd As New OleDbCommand(
                    "INSERT INTO tbl_Bookings (GuestID, RoomID, CheckInDate, CheckOutDate, TotalAmount, Status, DateBooked, Notes) " &
                    "VALUES (@gid, @rid, @cin, @cout, @total, @status, @dbooked, @notes)", conn)
                cmd.Parameters.AddWithValue("@gid", CInt(cmbGuest.SelectedValue))
                cmd.Parameters.AddWithValue("@rid", CInt(cmbRoom.SelectedValue))
                cmd.Parameters.AddWithValue("@cin", dtpCheckIn.Value.Date)
                cmd.Parameters.AddWithValue("@cout", dtpCheckOut.Value.Date)
                cmd.Parameters.AddWithValue("@total", total)
                cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@dbooked", DateTime.Now)
                cmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim())

                cmd.ExecuteNonQuery()

                ' Mark room as Occupied if Confirmed
                If cmbStatus.SelectedItem.ToString() = "Confirmed" Then
                    Dim updateRoom As New OleDbCommand(
                        "UPDATE tbl_Rooms SET Status='Occupied' WHERE RoomID=@rid", conn)
                    updateRoom.Parameters.AddWithValue("@rid", CInt(cmbRoom.SelectedValue))
                    updateRoom.ExecuteNonQuery()
                End If

                MessageBox.Show("Booking added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()
                LoadAvailableRooms()
                LoadBookings()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding booking: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    '  UPDATE BOOKING
    ' ============================================================
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedBookingID = -1 Then
            MessageBox.Show("Please select a booking to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateInputs() Then Return

        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                Dim nights As Integer = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days
                Dim total As Decimal = nights * selectedRoomPrice

                Dim cmd As New OleDbCommand(
                    "UPDATE tbl_Bookings SET GuestID=@gid, RoomID=@rid, CheckInDate=@cin, " &
                    "CheckOutDate=@cout, TotalAmount=@total, Status=@status, Notes=@notes " &
                    "WHERE BookingID=@id", conn)
                cmd.Parameters.AddWithValue("@gid", CInt(cmbGuest.SelectedValue))
                cmd.Parameters.AddWithValue("@rid", CInt(cmbRoom.SelectedValue))
                cmd.Parameters.AddWithValue("@cin", dtpCheckIn.Value.Date)
                cmd.Parameters.AddWithValue("@cout", dtpCheckOut.Value.Date)
                cmd.Parameters.AddWithValue("@total", total)
                cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim())
                cmd.Parameters.AddWithValue("@id", selectedBookingID)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()
                LoadAvailableRooms()
                LoadBookings()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating booking: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    '  DELETE BOOKING
    ' ============================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedBookingID = -1 Then
            MessageBox.Show("Please select a booking to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this booking?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            Try
                Using conn As New OleDbConnection(connStr)
                    conn.Open()
                    Dim cmd As New OleDbCommand(
                        "DELETE FROM tbl_Bookings WHERE BookingID = @id", conn)
                    cmd.Parameters.AddWithValue("@id", selectedBookingID)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Booking deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearFields()
                    LoadAvailableRooms()
                    LoadBookings()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error deleting booking: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ============================================================
    '  CLEAR BUTTON
    ' ============================================================
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    ' ============================================================
    '  SEARCH
    ' ============================================================
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadBookings(txtSearch.Text.Trim())
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then LoadBookings(txtSearch.Text.Trim())
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Trim() = "" Then LoadBookings()
    End Sub

    ' ============================================================
    '  DATAGRIDVIEW ROW CLICK — Populate form fields
    ' ============================================================
    Private Sub dgvBookings_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBookings.CellClick
        If e.RowIndex < 0 Then Return

        Dim row As DataGridViewRow = dgvBookings.Rows(e.RowIndex)
        selectedBookingID = CInt(row.Cells("BookingID").Value)

        dtpCheckIn.Value = CDate(row.Cells("CheckInDate").Value)
        dtpCheckOut.Value = CDate(row.Cells("CheckOutDate").Value)
        cmbStatus.SelectedItem = row.Cells("Status").Value?.ToString()
        txtNotes.Text = row.Cells("Notes").Value?.ToString()
    End Sub

    ' ============================================================
    '  COLOR CODE STATUS ROWS
    ' ============================================================
    Private Sub dgvBookings_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvBookings.RowPrePaint
        If e.RowIndex < 0 Then Return

        Dim status As String = dgvBookings.Rows(e.RowIndex).Cells("Status").Value?.ToString()

        Select Case status
            Case "Confirmed"
                dgvBookings.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220)
            Case "Pending"
                dgvBookings.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 200)
            Case "Cancelled"
                dgvBookings.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220)
        End Select
    End Sub

    ' ============================================================
    '  VALIDATE INPUTS
    ' ============================================================
    Private Function ValidateInputs() As Boolean
        If cmbGuest.SelectedIndex = -1 Then
            MessageBox.Show("Please select a guest.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbGuest.Focus()
            Return False
        End If

        If cmbRoom.SelectedIndex = -1 Then
            MessageBox.Show("Please select a room.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRoom.Focus()
            Return False
        End If

        If dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date Then
            MessageBox.Show("Check-out date must be after check-in date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpCheckOut.Focus()
            Return False
        End If

        If cmbStatus.SelectedIndex = -1 Then
            MessageBox.Show("Please select a booking status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
        End If

        Return True
    End Function

    ' ============================================================
    '  CLEAR FIELDS
    ' ============================================================
    Private Sub ClearFields()
        selectedBookingID = -1
        selectedRoomPrice = 0
        cmbGuest.SelectedIndex = -1
        cmbRoom.SelectedIndex = -1
        dtpCheckIn.Value = DateTime.Today
        dtpCheckOut.Value = DateTime.Today.AddDays(1)
        cmbStatus.SelectedIndex = 0
        txtNotes.Clear()
        lblNightsValue.Text = "0"
        lblPriceValue.Text = "0.00"
        lblTotalValue.Text = "0.00"
        dgvBookings.ClearSelection()
    End Sub

End Class