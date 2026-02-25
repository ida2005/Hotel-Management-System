Imports System.Data.OleDb

Public Class RoomManagement

    Private selectedRoomID As Integer = -1

    ' ============================================================
    '  FORM LOAD
    ' ============================================================
    Private Sub RoomManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRooms()
    End Sub

    ' ============================================================
    '  LOAD ALL ROOMS INTO GRID
    ' ============================================================
    Private Sub LoadRooms(Optional filter As String = "")
        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                Dim query As String =
                    "SELECT RoomID, RoomNumber, RoomType, Price, Status, Description " &
                    "FROM tbl_Rooms"

                If filter <> "" Then
                    query &= " WHERE RoomNumber LIKE '%" & filter & "%'" &
                             " OR RoomType LIKE '%" & filter & "%'" &
                             " OR Status LIKE '%" & filter & "%'"
                End If

                query &= " ORDER BY RoomNumber"

                Dim da As New OleDbDataAdapter(query, conn)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvRooms.DataSource = dt

                ' Hide RoomID column
                If dgvRooms.Columns.Contains("RoomID") Then
                    dgvRooms.Columns("RoomID").Visible = False
                End If

                ' Rename column headers
                If dgvRooms.Columns.Contains("RoomNumber") Then dgvRooms.Columns("RoomNumber").HeaderText = "Room No."
                If dgvRooms.Columns.Contains("RoomType") Then dgvRooms.Columns("RoomType").HeaderText = "Type"
                If dgvRooms.Columns.Contains("Price") Then dgvRooms.Columns("Price").HeaderText = "Price/Night"
                If dgvRooms.Columns.Contains("Status") Then dgvRooms.Columns("Status").HeaderText = "Status"
                If dgvRooms.Columns.Contains("Description") Then dgvRooms.Columns("Description").HeaderText = "Description"

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading rooms: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    '  ADD ROOM
    ' ============================================================
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInputs() Then Return

        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                ' Check duplicate room number
                Dim checkCmd As New OleDbCommand(
                    "SELECT COUNT(*) FROM tbl_Rooms WHERE RoomNumber = @num", conn)
                checkCmd.Parameters.AddWithValue("@num", txtRoomNumber.Text.Trim())
                If CInt(checkCmd.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Room number already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim cmd As New OleDbCommand(
                    "INSERT INTO tbl_Rooms (RoomNumber, RoomType, Price, Status, Description) " &
                    "VALUES (@num, @type, @price, @status, @desc)", conn)
                cmd.Parameters.AddWithValue("@num", txtRoomNumber.Text.Trim())
                cmd.Parameters.AddWithValue("@type", cmbRoomType.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@price", CDec(txtPrice.Text.Trim()))
                cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim())

                cmd.ExecuteNonQuery()
                MessageBox.Show("Room added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()
                LoadRooms()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding room: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    '  UPDATE ROOM
    ' ============================================================
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedRoomID = -1 Then
            MessageBox.Show("Please select a room from the list to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateInputs() Then Return

        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                Dim cmd As New OleDbCommand(
                    "UPDATE tbl_Rooms SET RoomNumber=@num, RoomType=@type, Price=@price, " &
                    "Status=@status, Description=@desc WHERE RoomID=@id", conn)
                cmd.Parameters.AddWithValue("@num", txtRoomNumber.Text.Trim())
                cmd.Parameters.AddWithValue("@type", cmbRoomType.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@price", CDec(txtPrice.Text.Trim()))
                cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@id", selectedRoomID)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Room updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()
                LoadRooms()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating room: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    '  DELETE ROOM
    ' ============================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedRoomID = -1 Then
            MessageBox.Show("Please select a room from the list to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this room?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            Try
                Using conn As New OleDbConnection(connStr)
                    conn.Open()

                    Dim cmd As New OleDbCommand(
                        "DELETE FROM tbl_Rooms WHERE RoomID = @id", conn)
                    cmd.Parameters.AddWithValue("@id", selectedRoomID)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Room deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearFields()
                    LoadRooms()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error deleting room: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        LoadRooms(txtSearch.Text.Trim())
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then LoadRooms(txtSearch.Text.Trim())
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Trim() = "" Then LoadRooms()
    End Sub

    ' ============================================================
    '  DATAGRIDVIEW ROW CLICK — Populate form fields
    ' ============================================================
    Private Sub dgvRooms_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRooms.CellClick
        If e.RowIndex < 0 Then Return

        Dim row As DataGridViewRow = dgvRooms.Rows(e.RowIndex)

        selectedRoomID = CInt(row.Cells("RoomID").Value)
        txtRoomNumber.Text = row.Cells("RoomNumber").Value.ToString()
        cmbRoomType.SelectedItem = row.Cells("RoomType").Value.ToString()
        txtPrice.Text = row.Cells("Price").Value.ToString()
        cmbStatus.SelectedItem = row.Cells("Status").Value.ToString()
        txtDescription.Text = row.Cells("Description").Value.ToString()
    End Sub

    ' ============================================================
    '  COLOR CODE STATUS ROWS
    ' ============================================================
    Private Sub dgvRooms_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvRooms.RowPrePaint
        If e.RowIndex < 0 Then Return

        Dim status As String = dgvRooms.Rows(e.RowIndex).Cells("Status").Value?.ToString()

        Select Case status
            Case "Available"
                dgvRooms.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220)
            Case "Occupied"
                dgvRooms.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220)
            Case "Maintenance"
                dgvRooms.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 200)
        End Select
    End Sub

    ' ============================================================
    '  VALIDATE INPUTS
    ' ============================================================
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtRoomNumber.Text) Then
            MessageBox.Show("Please enter a room number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoomNumber.Focus()
            Return False
        End If

        If cmbRoomType.SelectedIndex = -1 Then
            MessageBox.Show("Please select a room type.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRoomType.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtPrice.Text) Then
            MessageBox.Show("Please enter a price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            Return False
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(txtPrice.Text.Trim(), price) OrElse price <= 0 Then
            MessageBox.Show("Please enter a valid price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            Return False
        End If

        If cmbStatus.SelectedIndex = -1 Then
            MessageBox.Show("Please select a status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
        End If

        Return True
    End Function

    ' ============================================================
    '  CLEAR FIELDS
    ' ============================================================
    Private Sub ClearFields()
        selectedRoomID = -1
        txtRoomNumber.Clear()
        cmbRoomType.SelectedIndex = -1
        txtPrice.Clear()
        cmbStatus.SelectedIndex = -1
        txtDescription.Clear()
        dgvRooms.ClearSelection()
        txtRoomNumber.Focus()
    End Sub

End Class