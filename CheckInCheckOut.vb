Imports System.Data.SqlClient
Public Class CheckInCheckOut

    Public Sub New()
        InitializeComponent()
    End Sub

    Private selectedBookingID As Integer = -1
    Private selectedRoomID As Integer = -1
    Private selectedStatus As String = ""

    Private Sub CheckInCheckOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If cmbFilter IsNot Nothing Then
                cmbFilter.SelectedIndex = 0
            End If

            If btnCheckIn IsNot Nothing Then
                btnCheckIn.Enabled = False
            End If

            If btnCheckOut IsNot Nothing Then
                btnCheckOut.Enabled = False
            End If

            LoadBookings()
        Catch ex As Exception
            MessageBox.Show("Error loading form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadBookings(Optional filter As String = "", Optional statusFilter As String = "All")
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim query As String =
                "SELECT b.BookingID, g.FirstName + ' ' + g.LastName AS GuestName, " &
                "r.RoomNumber, r.RoomType, b.CheckInDate, b.CheckOutDate, " &
                "b.TotalAmount, b.Status, b.Notes, b.RoomID " &
                "FROM tbl_Bookings b " &
                "INNER JOIN tbl_Guests g ON b.GuestID = g.GuestID " &
                "INNER JOIN tbl_Rooms r ON b.RoomID = r.RoomID " &
                "WHERE (@filter = '' OR g.FirstName + ' ' + g.LastName LIKE @search " &
                "OR r.RoomNumber LIKE @search) " &
                "AND (@status = 'All' OR b.Status = @status) " &
                "ORDER BY b.CheckInDate DESC"

                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@filter", filter)
                cmd.Parameters.AddWithValue("@search", "%" & filter & "%")
                cmd.Parameters.AddWithValue("@status", statusFilter)

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvBookings.DataSource = dt

                For Each col As String In {"BookingID", "RoomID", "Notes"}
                    If dgvBookings.Columns.Contains(col) Then
                        dgvBookings.Columns(col).Visible = False
                    End If
                Next

                If dgvBookings.Columns.Contains("GuestName") Then dgvBookings.Columns("GuestName").HeaderText = "Guest"
                If dgvBookings.Columns.Contains("RoomNumber") Then dgvBookings.Columns("RoomNumber").HeaderText = "Room No."
                If dgvBookings.Columns.Contains("RoomType") Then dgvBookings.Columns("RoomType").HeaderText = "Type"
                If dgvBookings.Columns.Contains("CheckInDate") Then dgvBookings.Columns("CheckInDate").HeaderText = "Check-In"
                If dgvBookings.Columns.Contains("CheckOutDate") Then dgvBookings.Columns("CheckOutDate").HeaderText = "Check-Out"
                If dgvBookings.Columns.Contains("TotalAmount") Then dgvBookings.Columns("TotalAmount").HeaderText = "Total (₱)"
                If dgvBookings.Columns.Contains("Status") Then dgvBookings.Columns("Status").HeaderText = "Status"

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading bookings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvBookings_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBookings.CellClick
        If e.RowIndex < 0 Then Return

        Dim row As DataGridViewRow = dgvBookings.Rows(e.RowIndex)

        selectedBookingID = CInt(row.Cells("BookingID").Value)
        selectedRoomID = CInt(row.Cells("RoomID").Value)
        selectedStatus = row.Cells("Status").Value?.ToString()

        Dim checkIn As Date = CDate(row.Cells("CheckInDate").Value)
        Dim checkOut As Date = CDate(row.Cells("CheckOutDate").Value)
        Dim nights As Integer = (checkOut - checkIn).Days

        lblBookingIDValue.Text = selectedBookingID.ToString()
        lblGuestNameValue.Text = row.Cells("GuestName").Value?.ToString()
        lblRoomNumberValue.Text = row.Cells("RoomNumber").Value?.ToString()
        lblRoomTypeValue.Text = row.Cells("RoomType").Value?.ToString()
        lblCheckInValue.Text = checkIn.ToShortDateString()
        lblCheckOutValue.Text = checkOut.ToShortDateString()
        lblNightsValue.Text = nights.ToString()
        lblTotalAmountValue.Text = "₱" & CDec(row.Cells("TotalAmount").Value).ToString("N2")
        lblBookingStatusValue.Text = selectedStatus

        ' Color status label
        Select Case selectedStatus
            Case "Confirmed"
                lblBookingStatusValue.ForeColor = Color.DarkGreen
            Case "Checked In"
                lblBookingStatusValue.ForeColor = Color.DarkBlue
            Case "Checked Out"
                lblBookingStatusValue.ForeColor = Color.Gray
            Case "Cancelled"
                lblBookingStatusValue.ForeColor = Color.Red
            Case Else
                lblBookingStatusValue.ForeColor = Color.DarkOrange
        End Select

        ' Enable/disable buttons based on status
        btnCheckIn.Enabled = (selectedStatus = "Confirmed")
        btnCheckOut.Enabled = (selectedStatus = "Checked In")
    End Sub

    Private Sub btnCheckIn_Click(sender As Object, e As EventArgs) Handles btnCheckIn.Click
        If selectedBookingID = -1 Then
            MessageBox.Show("Please select a booking first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm As DialogResult = MessageBox.Show(
            "Confirm CHECK IN for " & lblGuestNameValue.Text & "?",
            "Confirm Check In",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            Try
                Using conn As New SqlConnection(connStr)
                    conn.Open()

                    Dim cmd As New SqlCommand(
                        "UPDATE tbl_Bookings SET Status='Checked In' WHERE BookingID=@id", conn)
                    cmd.Parameters.AddWithValue("@id", selectedBookingID)
                    cmd.ExecuteNonQuery()

                    Dim roomCmd As New SqlCommand(
                        "UPDATE tbl_Rooms SET Status='Occupied' WHERE RoomID=@rid", conn)
                    roomCmd.Parameters.AddWithValue("@rid", selectedRoomID)
                    roomCmd.ExecuteNonQuery()

                    MessageBox.Show("Guest successfully checked in!", "Check In", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    WriteAuditLog("UPDATE", "Booking", selectedBookingID,
                    "Checked in guest: " & lblGuestNameValue.Text &
                    " room: " & lblRoomNumberValue.Text &
                    " booking ID: " & selectedBookingID)
                    ClearInfo()
                    LoadBookings("", cmbFilter.Text)
                End Using
            Catch ex As Exception
                MessageBox.Show("Error during check in: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        If selectedBookingID = -1 Then
            MessageBox.Show("Please select a booking first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm As DialogResult = MessageBox.Show(
            "Confirm CHECK OUT for " & lblGuestNameValue.Text & "?" &
            Environment.NewLine & "Total Amount: " & lblTotalAmountValue.Text,
            "Confirm Check Out",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            Try
                Using conn As New SqlConnection(connStr)
                    conn.Open()

                    Dim cmd As New SqlCommand(
                        "UPDATE tbl_Bookings SET Status='Checked Out' WHERE BookingID=@id", conn)
                    cmd.Parameters.AddWithValue("@id", selectedBookingID)
                    cmd.ExecuteNonQuery()

                    Dim roomCmd As New SqlCommand(
                        "UPDATE tbl_Rooms SET Status='Available' WHERE RoomID=@rid", conn)
                    roomCmd.Parameters.AddWithValue("@rid", selectedRoomID)
                    roomCmd.ExecuteNonQuery()

                    MessageBox.Show("Guest successfully checked out! Room is now available.", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    WriteAuditLog("UPDATE", "Booking", selectedBookingID,
                    "Checked out guest: " & lblGuestNameValue.Text &
                    " room: " & lblRoomNumberValue.Text &
                    " total: " & lblTotalAmountValue.Text &
                    " booking ID: " & selectedBookingID)
                    ClearInfo()
                    LoadBookings("", cmbFilter.Text)
                End Using
            Catch ex As Exception
                MessageBox.Show("Error during check out: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearInfo()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadBookings(txtSearch.Text.Trim(), cmbFilter.Text)
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then LoadBookings(txtSearch.Text.Trim(), cmbFilter.Text)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Trim() = "" Then LoadBookings("", cmbFilter.Text)
    End Sub

    Private Sub cmbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilter.SelectedIndexChanged
        LoadBookings(txtSearch.Text.Trim(), cmbFilter.Text)
    End Sub

    Private Sub dgvBookings_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvBookings.RowPrePaint
        If e.RowIndex < 0 Then Return

        Dim status As String = dgvBookings.Rows(e.RowIndex).Cells("Status").Value?.ToString()

        Select Case status
            Case "Confirmed"
                dgvBookings.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220)
            Case "Checked In"
                dgvBookings.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(210, 230, 255)
            Case "Checked Out"
                dgvBookings.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230)
            Case "Pending"
                dgvBookings.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 200)
            Case "Cancelled"
                dgvBookings.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220)
        End Select
    End Sub

    Private Sub ClearInfo()
        selectedBookingID = -1
        selectedRoomID = -1
        selectedStatus = ""

        lblBookingIDValue.Text = "-"
        lblGuestNameValue.Text = "-"
        lblRoomNumberValue.Text = "-"
        lblRoomTypeValue.Text = "-"
        lblCheckInValue.Text = "-"
        lblCheckOutValue.Text = "-"
        lblNightsValue.Text = "-"
        lblTotalAmountValue.Text = "-"
        lblBookingStatusValue.Text = "-"
        lblBookingStatusValue.ForeColor = Color.Black

        btnCheckIn.Enabled = False
        btnCheckOut.Enabled = False
        dgvBookings.ClearSelection()
    End Sub

End Class