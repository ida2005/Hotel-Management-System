Imports System.Data.SqlClient

Public Class BookingForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private selectedBookingID As Integer = -1
    Private selectedRoomPrice As Decimal = 0

    Private Sub BookingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGuests()
        LoadAvailableRooms()
        dtpCheckIn.Value = DateTime.Today
        dtpCheckOut.Value = DateTime.Today.AddDays(1)
        cmbStatus.SelectedIndex = 0
        LoadBookings()
    End Sub

    Private Sub LoadGuests()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand(
                "SELECT GuestID, FirstName + ' ' + LastName AS FullName " &
                "FROM tbl_Guests ORDER BY LastName", conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()

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

    Private Sub LoadAvailableRooms(Optional currentRoomID As Integer = -1)
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim cmd As New SqlCommand(
                    "SELECT RoomID, " &
                    "RoomNumber + ' - ' + RoomType + ' (₱' + CAST(Price AS NVARCHAR(20)) + ')' AS RoomInfo, " &
                    "Price " &
                    "FROM tbl_Rooms " &
                    "WHERE Status IN ('Available', 'Reserved') OR RoomID = @currentRoom " &
                    "ORDER BY RoomNumber", conn)
                cmd.Parameters.AddWithValue("@currentRoom", currentRoomID)

                Dim reader As SqlDataReader = cmd.ExecuteReader()

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

    Private Sub LoadBookings(Optional filter As String = "")
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim query As String =
                "SELECT b.BookingID, g.FirstName + ' ' + g.LastName AS GuestName, " &
                "r.RoomNumber, r.RoomType, b.CheckInDate, b.CheckOutDate, " &
                "b.TotalAmount, b.Status, b.DateBooked, b.Notes " &
                "FROM tbl_Bookings b " &
                "INNER JOIN tbl_Guests g ON b.GuestID = g.GuestID " &
                "INNER JOIN tbl_Rooms r ON b.RoomID = r.RoomID " &
                "WHERE (@filter = '' OR g.FirstName + ' ' + g.LastName LIKE @search " &
                "OR r.RoomNumber LIKE @search " &
                "OR b.Status LIKE @search) " &
                "ORDER BY b.DateBooked DESC"

                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@filter", filter)
                cmd.Parameters.AddWithValue("@search", "%" & filter & "%")

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvBookings.DataSource = dt

                If dgvBookings.Columns.Contains("BookingID") Then
                    dgvBookings.Columns("BookingID").Visible = False
                End If

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

    Private Sub dtpCheckIn_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckIn.ValueChanged
        If dtpCheckIn.Value >= dtpCheckOut.Value Then
            dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1)
        End If
        CalculateTotal()
    End Sub

    Private Sub dtpCheckOut_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckOut.ValueChanged
        CalculateTotal()
    End Sub

    Private Sub CalculateTotal()
        Dim nights As Integer = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days
        If nights < 1 Then nights = 0

        Dim total As Decimal = nights * selectedRoomPrice
        lblNightsValue.Text = nights.ToString()
        lblTotalValue.Text = total.ToString("N2")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInputs() Then Return

        Dim roomID As Integer = CInt(cmbRoom.SelectedValue)
        Dim checkIn As Date = dtpCheckIn.Value.Date
        Dim checkOut As Date = dtpCheckOut.Value.Date

        If HasDateOverlap(roomID, checkIn, checkOut) Then
            MessageBox.Show(
            "This room is already booked for the selected dates." & Environment.NewLine &
            "Please choose different dates or a different room.",
            "Date Conflict",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim nights As Integer = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days
                Dim total As Decimal = nights * selectedRoomPrice

                Dim cmd As New SqlCommand(
                "INSERT INTO tbl_Bookings (GuestID, RoomID, CheckInDate, CheckOutDate, TotalAmount, Status, DateBooked, Notes) " &
                "VALUES (@gid, @rid, @cin, @cout, @total, @status, @dbooked, @notes)", conn)
                cmd.Parameters.AddWithValue("@gid", CInt(cmbGuest.SelectedValue))
                cmd.Parameters.AddWithValue("@rid", roomID)
                cmd.Parameters.AddWithValue("@cin", checkIn)
                cmd.Parameters.AddWithValue("@cout", checkOut)
                cmd.Parameters.AddWithValue("@total", total)
                cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@dbooked", DateTime.Now)
                cmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim())

                cmd.ExecuteNonQuery()

                Dim newBookingStatus As String = cmbStatus.SelectedItem.ToString()
                Dim roomStatus As String = ""

                Select Case newBookingStatus
                    Case "Confirmed"
                        roomStatus = "Reserved"
                    Case "Pending"
                        roomStatus = "Available"
                    Case "Cancelled"
                        roomStatus = "Available"
                End Select

                If roomStatus <> "" Then
                    Dim updateRoom As New SqlCommand(
                    "UPDATE tbl_Rooms SET Status=@status WHERE RoomID=@rid", conn)
                    updateRoom.Parameters.AddWithValue("@status", roomStatus)
                    updateRoom.Parameters.AddWithValue("@rid", roomID)
                    updateRoom.ExecuteNonQuery()
                End If

                MessageBox.Show("Booking added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                WriteAuditLog("ADD", "Booking", -1,
                "Added booking for guest ID " & CInt(cmbGuest.SelectedValue) &
                " room ID " & CInt(cmbRoom.SelectedValue) &
                " check-in " & dtpCheckIn.Value.Date.ToShortDateString() &
                " check-out " & dtpCheckOut.Value.Date.ToShortDateString() &
                " status: " & cmbStatus.SelectedItem.ToString())

                ClearFields()
                LoadAvailableRooms()
                LoadBookings()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding booking: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedBookingID = -1 Then
            MessageBox.Show("Please select a booking to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateInputs() Then Return

        Dim roomID As Integer = CInt(cmbRoom.SelectedValue)
        Dim checkIn As Date = dtpCheckIn.Value.Date
        Dim checkOut As Date = dtpCheckOut.Value.Date

        If HasDateOverlap(roomID, checkIn, checkOut, selectedBookingID) Then
            MessageBox.Show(
            "This room is already booked for the selected dates." & Environment.NewLine &
            "Please choose different dates or a different room.",
            "Date Conflict",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim oldStatus As String = ""
                Dim oldRoomID As Integer = -1

                Dim getOldCmd As New SqlCommand(
                "SELECT Status, RoomID FROM tbl_Bookings WHERE BookingID = @id", conn)
                getOldCmd.Parameters.AddWithValue("@id", selectedBookingID)

                Using reader = getOldCmd.ExecuteReader()
                    If reader.Read() Then
                        oldStatus = reader("Status").ToString()
                        oldRoomID = CInt(reader("RoomID"))
                    End If
                End Using

                Dim newStatus As String = cmbStatus.SelectedItem.ToString()
                Dim newRoomID As Integer = CInt(cmbRoom.SelectedValue)
                Dim nights As Integer = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days
                Dim total As Decimal = nights * selectedRoomPrice

                Dim cmd As New SqlCommand(
                "UPDATE tbl_Bookings SET GuestID=@gid, RoomID=@rid, CheckInDate=@cin, " &
                "CheckOutDate=@cout, TotalAmount=@total, Status=@status, Notes=@notes " &
                "WHERE BookingID=@id", conn)
                cmd.Parameters.AddWithValue("@gid", CInt(cmbGuest.SelectedValue))
                cmd.Parameters.AddWithValue("@rid", newRoomID)
                cmd.Parameters.AddWithValue("@cin", dtpCheckIn.Value.Date)
                cmd.Parameters.AddWithValue("@cout", dtpCheckOut.Value.Date)
                cmd.Parameters.AddWithValue("@total", total)
                cmd.Parameters.AddWithValue("@status", newStatus)
                cmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim())
                cmd.Parameters.AddWithValue("@id", selectedBookingID)
                cmd.ExecuteNonQuery()

                If oldRoomID <> newRoomID Then
                    Dim freeOldRoom As New SqlCommand(
                    "UPDATE tbl_Rooms SET Status='Available' WHERE RoomID=@rid", conn)
                    freeOldRoom.Parameters.AddWithValue("@rid", oldRoomID)
                    freeOldRoom.ExecuteNonQuery()
                End If

                Select Case newStatus
                    Case "Confirmed"
                        Dim reserveRoom As New SqlCommand(
                        "UPDATE tbl_Rooms SET Status='Reserved' WHERE RoomID=@rid", conn)
                        reserveRoom.Parameters.AddWithValue("@rid", newRoomID)
                        reserveRoom.ExecuteNonQuery()

                    Case "Pending", "Cancelled"
                        Dim freeRoom As New SqlCommand(
                        "UPDATE tbl_Rooms SET Status='Available' WHERE RoomID=@rid", conn)
                        freeRoom.Parameters.AddWithValue("@rid", newRoomID)
                        freeRoom.ExecuteNonQuery()
                End Select
                MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                WriteAuditLog("UPDATE", "Booking", selectedBookingID,
                "Updated booking ID " & selectedBookingID &
                " new status: " & cmbStatus.SelectedItem.ToString() &
                " check-in " & dtpCheckIn.Value.Date.ToShortDateString() &
                " check-out " & dtpCheckOut.Value.Date.ToShortDateString())

                ClearFields()
                LoadAvailableRooms()
                LoadBookings()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating booking: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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
                Using conn As New SqlConnection(connStr)
                    conn.Open()

                    Dim roomID As Integer = -1
                    Dim status As String = ""

                    Dim getCmd As New SqlCommand(
                    "SELECT RoomID, Status FROM tbl_Bookings WHERE BookingID = @id", conn)
                    getCmd.Parameters.AddWithValue("@id", selectedBookingID)

                    Using reader = getCmd.ExecuteReader()
                        If reader.Read() Then
                            roomID = CInt(reader("RoomID"))
                            status = reader("Status").ToString()
                        End If
                    End Using

                    Dim cmd As New SqlCommand(
                    "DELETE FROM tbl_Bookings WHERE BookingID = @id", conn)
                    cmd.Parameters.AddWithValue("@id", selectedBookingID)
                    cmd.ExecuteNonQuery()

                    If status = "Confirmed" OrElse status = "Checked In" Then
                        Dim freeRoom As New SqlCommand(
                        "UPDATE tbl_Rooms SET Status='Available' WHERE RoomID=@rid", conn)
                        freeRoom.Parameters.AddWithValue("@rid", roomID)
                        freeRoom.ExecuteNonQuery()
                    End If

                    MessageBox.Show("Booking deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    WriteAuditLog("DELETE", "Booking", selectedBookingID,
                    "Deleted booking ID " & selectedBookingID)

                    ClearFields()
                    LoadAvailableRooms()
                    LoadBookings()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error deleting booking: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadBookings(txtSearch.Text.Trim())
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then LoadBookings(txtSearch.Text.Trim())
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Trim() = "" Then LoadBookings()
    End Sub

    Private Sub dgvBookings_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBookings.CellClick
        If e.RowIndex < 0 Then Return

        Dim row As DataGridViewRow = dgvBookings.Rows(e.RowIndex)
        selectedBookingID = CInt(row.Cells("BookingID").Value)

        ' Get the RoomID and GuestID of this booking from the database
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim cmd As New SqlCommand(
                "SELECT GuestID, RoomID, CheckInDate, CheckOutDate, Status, Notes " &
                "FROM tbl_Bookings WHERE BookingID = @id", conn)
                cmd.Parameters.AddWithValue("@id", selectedBookingID)

                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim guestID As Integer = CInt(reader("GuestID"))
                        Dim roomID As Integer = CInt(reader("RoomID"))

                        ' Reload rooms including the current booked room
                        LoadAvailableRooms(roomID)

                        ' Now set all form fields
                        cmbGuest.SelectedValue = guestID
                        cmbRoom.SelectedValue = roomID
                        dtpCheckIn.Value = CDate(reader("CheckInDate"))
                        dtpCheckOut.Value = CDate(reader("CheckOutDate"))
                        cmbStatus.SelectedItem = reader("Status").ToString()
                        txtNotes.Text = reader("Notes")?.ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading booking details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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

    Private Function HasDateOverlap(roomID As Integer, checkIn As Date, checkOut As Date,
                                 Optional excludeBookingID As Integer = -1) As Boolean
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim cmd As New SqlCommand(
                "SELECT COUNT(*) FROM tbl_Bookings " &
                "WHERE RoomID = @rid " &
                "AND BookingID <> @excludeID " &
                "AND Status NOT IN ('Cancelled', 'Checked Out') " &
                "AND @checkIn < CheckOutDate " &
                "AND @checkOut > CheckInDate", conn)

                cmd.Parameters.AddWithValue("@rid", roomID)
                cmd.Parameters.AddWithValue("@excludeID", excludeBookingID)
                cmd.Parameters.AddWithValue("@checkIn", checkIn)
                cmd.Parameters.AddWithValue("@checkOut", checkOut)

                Dim count As Integer = CInt(cmd.ExecuteScalar())
                Return count > 0
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking date availability: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End Try
    End Function

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

        LoadAvailableRooms()
    End Sub
End Class