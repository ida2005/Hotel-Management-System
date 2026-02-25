Imports System.Data.OleDb

Public Class GuestViewForm

    Private selectedGuestID As Integer = -1
    Private Sub GuestViewForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGuests()
    End Sub
    Private Sub LoadGuests(Optional filter As String = "")
        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                Dim query As String =
                    "SELECT GuestID, FirstName & ' ' & LastName AS FullName, " &
                    "Email, Phone, IDType, DateAdded " &
                    "FROM tbl_Guests"

                If filter <> "" Then
                    query &= " WHERE FirstName & ' ' & LastName LIKE '%" & filter & "%'" &
                             " OR Email LIKE '%" & filter & "%'" &
                             " OR Phone LIKE '%" & filter & "%'" &
                             " OR IDType LIKE '%" & filter & "%'"
                End If

                query &= " ORDER BY LastName, FirstName"

                Dim da As New OleDbDataAdapter(query, conn)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvGuests.DataSource = dt

                If dgvGuests.Columns.Contains("GuestID") Then
                    dgvGuests.Columns("GuestID").Visible = False
                End If

                If dgvGuests.Columns.Contains("FullName") Then dgvGuests.Columns("FullName").HeaderText = "Full Name"
                If dgvGuests.Columns.Contains("Email") Then dgvGuests.Columns("Email").HeaderText = "Email"
                If dgvGuests.Columns.Contains("Phone") Then dgvGuests.Columns("Phone").HeaderText = "Phone"
                If dgvGuests.Columns.Contains("IDType") Then dgvGuests.Columns("IDType").HeaderText = "ID Type"
                If dgvGuests.Columns.Contains("DateAdded") Then dgvGuests.Columns("DateAdded").HeaderText = "Date Added"

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading guests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadBookingHistory(guestID As Integer)
        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                Dim query As String =
                    "SELECT b.BookingID, r.RoomNumber, r.RoomType, " &
                    "b.CheckInDate, b.CheckOutDate, b.TotalAmount, b.Status, b.DateBooked " &
                    "FROM tbl_Bookings b " &
                    "INNER JOIN tbl_Rooms r ON b.RoomID = r.RoomID " &
                    "WHERE b.GuestID = @gid " &
                    "ORDER BY b.DateBooked DESC"

                Dim cmd As New OleDbCommand(query, conn)
                cmd.Parameters.AddWithValue("@gid", guestID)

                Dim da As New OleDbDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvBookingHistory.DataSource = dt

                If dgvBookingHistory.Columns.Contains("BookingID") Then
                    dgvBookingHistory.Columns("BookingID").Visible = False
                End If

                If dgvBookingHistory.Columns.Contains("RoomNumber") Then dgvBookingHistory.Columns("RoomNumber").HeaderText = "Room No."
                If dgvBookingHistory.Columns.Contains("RoomType") Then dgvBookingHistory.Columns("RoomType").HeaderText = "Type"
                If dgvBookingHistory.Columns.Contains("CheckInDate") Then dgvBookingHistory.Columns("CheckInDate").HeaderText = "Check-In"
                If dgvBookingHistory.Columns.Contains("CheckOutDate") Then dgvBookingHistory.Columns("CheckOutDate").HeaderText = "Check-Out"
                If dgvBookingHistory.Columns.Contains("TotalAmount") Then dgvBookingHistory.Columns("TotalAmount").HeaderText = "Total (₱)"
                If dgvBookingHistory.Columns.Contains("Status") Then dgvBookingHistory.Columns("Status").HeaderText = "Status"
                If dgvBookingHistory.Columns.Contains("DateBooked") Then dgvBookingHistory.Columns("DateBooked").HeaderText = "Date Booked"

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading booking history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadGuestDetails(guestID As Integer)
        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                Dim cmd As New OleDbCommand(
                    "SELECT GuestID, FirstName, LastName, Email, Phone, " &
                    "Address, IDType, IDNumber, DateAdded " &
                    "FROM tbl_Guests WHERE GuestID = @gid", conn)
                cmd.Parameters.AddWithValue("@gid", guestID)

                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        lblGuestIDValue.Text = reader("GuestID").ToString()
                        lblFullNameValue.Text = reader("FirstName").ToString() & " " & reader("LastName").ToString()
                        lblEmailValue.Text = reader("Email").ToString()
                        lblPhoneValue.Text = reader("Phone").ToString()
                        lblAddressValue.Text = reader("Address").ToString()
                        lblIDTypeValue.Text = reader("IDType").ToString()
                        lblIDNumberValue.Text = reader("IDNumber").ToString()
                        lblDateAddedValue.Text = CDate(reader("DateAdded")).ToShortDateString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading guest details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    '  DATAGRIDVIEW: GUEST ROW CLICK
    ' ============================================================
    Private Sub DgvGuests_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGuests.CellClick
        If e.RowIndex < 0 Then Return

        Dim row As DataGridViewRow = dgvGuests.Rows(e.RowIndex)
        selectedGuestID = CInt(row.Cells("GuestID").Value)

        LoadGuestDetails(selectedGuestID)
        LoadBookingHistory(selectedGuestID)
        lblBookingsTitle.Text = "Booking History — " & row.Cells("FullName").Value?.ToString()
    End Sub

    Private Sub DgvBookingHistory_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvBookingHistory.RowPrePaint
        If e.RowIndex < 0 Then Return

        Dim status As String = dgvBookingHistory.Rows(e.RowIndex).Cells("Status").Value?.ToString()

        Select Case status
            Case "Confirmed"
                dgvBookingHistory.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220)
            Case "Checked In"
                dgvBookingHistory.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(210, 230, 255)
            Case "Checked Out"
                dgvBookingHistory.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230)
            Case "Pending"
                dgvBookingHistory.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 200)
            Case "Cancelled"
                dgvBookingHistory.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220)
        End Select
    End Sub
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadGuests(txtSearch.Text.Trim())
        ClearDetails()
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadGuests(txtSearch.Text.Trim())
            ClearDetails()
        End If
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Trim() = "" Then
            LoadGuests()
            ClearDetails()
        End If
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        LoadGuests()
        ClearDetails()
    End Sub
    Private Sub ClearDetails()
        selectedGuestID = -1
        lblGuestIDValue.Text = "-"
        lblFullNameValue.Text = "-"
        lblEmailValue.Text = "-"
        lblPhoneValue.Text = "-"
        lblAddressValue.Text = "-"
        lblIDTypeValue.Text = "-"
        lblIDNumberValue.Text = "-"
        lblDateAddedValue.Text = "-"
        dgvBookingHistory.DataSource = Nothing
        lblBookingsTitle.Text = "Booking History"
        dgvGuests.ClearSelection()
    End Sub

End Class