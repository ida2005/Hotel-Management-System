Imports System.Data.SqlClient

Public Class DashboardForm

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If lblDate IsNot Nothing Then
            lblDate.Text = "Today is " & DateTime.Now.ToString("dddd, MMMM dd, yyyy")
        End If
        LoadDashboard()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDashboard()
    End Sub

    Private Sub LoadDashboard()
        LoadRoomStats()
        LoadTodayCheckIns()
        LoadTodayCheckOuts()
        LoadRecentActivity()
    End Sub

    Private Sub LoadRoomStats()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim cmd As New SqlCommand(
                    "SELECT Status, COUNT(*) AS Total FROM tbl_Rooms GROUP BY Status", conn)

                Using reader = cmd.ExecuteReader()
                    ' Reset all counts first
                    lblAvailableCount.Text = "0"
                    lblReservedCount.Text = "0"
                    lblOccupiedCount.Text = "0"
                    lblMaintenanceCount.Text = "0"

                    While reader.Read()
                        Dim status As String = reader("Status").ToString()
                        Dim count As String = reader("Total").ToString()

                        Select Case status
                            Case "Available"
                                lblAvailableCount.Text = count
                            Case "Reserved"
                                lblReservedCount.Text = count
                            Case "Occupied"
                                lblOccupiedCount.Text = count
                            Case "Maintenance"
                                lblMaintenanceCount.Text = count
                        End Select
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading room stats: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadTodayCheckIns()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim cmd As New SqlCommand(
                    "SELECT g.FirstName + ' ' + g.LastName AS Guest, " &
                    "r.RoomNumber AS Room, r.RoomType AS Type, " &
                    "b.TotalAmount AS Total, b.Status " &
                    "FROM tbl_Bookings b " &
                    "INNER JOIN tbl_Guests g ON b.GuestID = g.GuestID " &
                    "INNER JOIN tbl_Rooms r ON b.RoomID = r.RoomID " &
                    "WHERE CAST(b.CheckInDate AS DATE) = CAST(GETDATE() AS DATE) " &
                    "AND b.Status IN ('Confirmed', 'Pending') " &
                    "ORDER BY b.CheckInDate", conn)

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvCheckIns.DataSource = dt

                If dgvCheckIns.Columns.Contains("Guest") Then dgvCheckIns.Columns("Guest").HeaderText = "Guest"
                If dgvCheckIns.Columns.Contains("Room") Then dgvCheckIns.Columns("Room").HeaderText = "Room"
                If dgvCheckIns.Columns.Contains("Type") Then dgvCheckIns.Columns("Type").HeaderText = "Type"
                If dgvCheckIns.Columns.Contains("Total") Then dgvCheckIns.Columns("Total").HeaderText = "Total (₱)"
                If dgvCheckIns.Columns.Contains("Status") Then dgvCheckIns.Columns("Status").HeaderText = "Status"

                lblCheckInsTitle.Text = "Today's Expected Check-Ins (" & dt.Rows.Count & ")"
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading check-ins: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadTodayCheckOuts()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim cmd As New SqlCommand(
                    "SELECT g.FirstName + ' ' + g.LastName AS Guest, " &
                    "r.RoomNumber AS Room, r.RoomType AS Type, " &
                    "b.TotalAmount AS Total, b.Status " &
                    "FROM tbl_Bookings b " &
                    "INNER JOIN tbl_Guests g ON b.GuestID = g.GuestID " &
                    "INNER JOIN tbl_Rooms r ON b.RoomID = r.RoomID " &
                    "WHERE CAST(b.CheckOutDate AS DATE) = CAST(GETDATE() AS DATE) " &
                    "AND b.Status = 'Checked In' " &
                    "ORDER BY b.CheckOutDate", conn)

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvCheckOuts.DataSource = dt

                If dgvCheckOuts.Columns.Contains("Guest") Then dgvCheckOuts.Columns("Guest").HeaderText = "Guest"
                If dgvCheckOuts.Columns.Contains("Room") Then dgvCheckOuts.Columns("Room").HeaderText = "Room"
                If dgvCheckOuts.Columns.Contains("Type") Then dgvCheckOuts.Columns("Type").HeaderText = "Type"
                If dgvCheckOuts.Columns.Contains("Total") Then dgvCheckOuts.Columns("Total").HeaderText = "Total (₱)"
                If dgvCheckOuts.Columns.Contains("Status") Then dgvCheckOuts.Columns("Status").HeaderText = "Status"

                lblCheckOutsTitle.Text = "Today's Expected Check-Outs (" & dt.Rows.Count & ")"
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading check-outs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadRecentActivity()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim cmd As New SqlCommand(
                    "SELECT TOP 20 FullName, Action, TableName, Details, LogDate " &
                    "FROM tbl_AuditLog " &
                    "ORDER BY LogDate DESC", conn)

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvRecentActivity.DataSource = dt

                If dgvRecentActivity.Columns.Contains("FullName") Then dgvRecentActivity.Columns("FullName").HeaderText = "User"
                If dgvRecentActivity.Columns.Contains("Action") Then dgvRecentActivity.Columns("Action").HeaderText = "Action"
                If dgvRecentActivity.Columns.Contains("TableName") Then dgvRecentActivity.Columns("TableName").HeaderText = "Module"
                If dgvRecentActivity.Columns.Contains("Details") Then dgvRecentActivity.Columns("Details").HeaderText = "Details"
                If dgvRecentActivity.Columns.Contains("LogDate") Then dgvRecentActivity.Columns("LogDate").HeaderText = "Date & Time"

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading recent activity: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvRecentActivity_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvRecentActivity.RowPrePaint
        If e.RowIndex < 0 Then Return

        Dim action As String = dgvRecentActivity.Rows(e.RowIndex).Cells("Action").Value?.ToString()

        Select Case action
            Case "ADD"
                dgvRecentActivity.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220)
            Case "UPDATE"
                dgvRecentActivity.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(210, 230, 255)
            Case "DELETE"
                dgvRecentActivity.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220)
            Case "LOGIN"
                dgvRecentActivity.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
            Case "LOGOUT"
                dgvRecentActivity.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
        End Select
    End Sub

End Class