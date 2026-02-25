Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class GuestsManagement

    Private selectedGuestID As Integer = -1

    ' ============================================================
    '  FORM LOAD
    ' ============================================================
    Private Sub GuestsManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGuests()
    End Sub

    ' ============================================================
    '  LOAD ALL GUESTS INTO GRID
    ' ============================================================
    Private Sub LoadGuests(Optional filter As String = "")
        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                Dim query As String =
                    "SELECT GuestID, FirstName, LastName, Email, Phone, Address, IDType, IDNumber, DateAdded " &
                    "FROM tbl_Guests"

                If filter <> "" Then
                    query &= " WHERE FirstName LIKE '%" & filter & "%'" &
                             " OR LastName LIKE '%" & filter & "%'" &
                             " OR Email LIKE '%" & filter & "%'" &
                             " OR Phone LIKE '%" & filter & "%'" &
                             " OR IDNumber LIKE '%" & filter & "%'"
                End If

                query &= " ORDER BY LastName, FirstName"

                Dim da As New OleDbDataAdapter(query, conn)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvGuests.DataSource = dt

                ' Hide GuestID column
                If dgvGuests.Columns.Contains("GuestID") Then
                    dgvGuests.Columns("GuestID").Visible = False
                End If

                ' Rename headers
                If dgvGuests.Columns.Contains("FirstName") Then dgvGuests.Columns("FirstName").HeaderText = "First Name"
                If dgvGuests.Columns.Contains("LastName") Then dgvGuests.Columns("LastName").HeaderText = "Last Name"
                If dgvGuests.Columns.Contains("Email") Then dgvGuests.Columns("Email").HeaderText = "Email"
                If dgvGuests.Columns.Contains("Phone") Then dgvGuests.Columns("Phone").HeaderText = "Phone"
                If dgvGuests.Columns.Contains("Address") Then dgvGuests.Columns("Address").HeaderText = "Address"
                If dgvGuests.Columns.Contains("IDType") Then dgvGuests.Columns("IDType").HeaderText = "ID Type"
                If dgvGuests.Columns.Contains("IDNumber") Then dgvGuests.Columns("IDNumber").HeaderText = "ID Number"
                If dgvGuests.Columns.Contains("DateAdded") Then dgvGuests.Columns("DateAdded").HeaderText = "Date Added"

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading guests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    '  ADD GUEST
    ' ============================================================
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInputs() Then Return

        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                Dim cmd As New OleDbCommand(
                    "INSERT INTO tbl_Guests (FirstName, LastName, Email, Phone, Address, IDType, IDNumber, DateAdded) " &
                    "VALUES (@fn, @ln, @email, @phone, @addr, @idtype, @idnum, @date)", conn)
                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim())
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim())
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim())
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim())
                cmd.Parameters.AddWithValue("@idtype", cmbIDType.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@idnum", txtIDNumber.Text.Trim())
                cmd.Parameters.AddWithValue("@date", DateTime.Now)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Guest added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()
                LoadGuests()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding guest: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    '  UPDATE GUEST
    ' ============================================================
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedGuestID = -1 Then
            MessageBox.Show("Please select a guest from the list to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateInputs() Then Return

        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                Dim cmd As New OleDbCommand(
                    "UPDATE tbl_Guests SET FirstName=@fn, LastName=@ln, Email=@email, Phone=@phone, " &
                    "Address=@addr, IDType=@idtype, IDNumber=@idnum WHERE GuestID=@id", conn)
                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim())
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim())
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim())
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim())
                cmd.Parameters.AddWithValue("@idtype", cmbIDType.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@idnum", txtIDNumber.Text.Trim())
                cmd.Parameters.AddWithValue("@id", selectedGuestID)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Guest updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()
                LoadGuests()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating guest: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    '  DELETE GUEST
    ' ============================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedGuestID = -1 Then
            MessageBox.Show("Please select a guest from the list to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this guest?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            Try
                Using conn As New OleDbConnection(connStr)
                    conn.Open()

                    Dim cmd As New OleDbCommand(
                        "DELETE FROM tbl_Guests WHERE GuestID = @id", conn)
                    cmd.Parameters.AddWithValue("@id", selectedGuestID)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Guest deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearFields()
                    LoadGuests()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error deleting guest: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        LoadGuests(txtSearch.Text.Trim())
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then LoadGuests(txtSearch.Text.Trim())
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Trim() = "" Then LoadGuests()
    End Sub

    ' ============================================================
    '  DATAGRIDVIEW ROW CLICK — Populate form fields
    ' ============================================================
    Private Sub dgvGuests_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGuests.CellClick
        If e.RowIndex < 0 Then Return

        Dim row As DataGridViewRow = dgvGuests.Rows(e.RowIndex)

        selectedGuestID = CInt(row.Cells("GuestID").Value)
        txtFirstName.Text = row.Cells("FirstName").Value?.ToString()
        txtLastName.Text = row.Cells("LastName").Value?.ToString()
        txtEmail.Text = row.Cells("Email").Value?.ToString()
        txtPhone.Text = row.Cells("Phone").Value?.ToString()
        txtAddress.Text = row.Cells("Address").Value?.ToString()
        cmbIDType.SelectedItem = row.Cells("IDType").Value?.ToString()
        txtIDNumber.Text = row.Cells("IDNumber").Value?.ToString()
    End Sub

    ' ============================================================
    '  VALIDATE INPUTS
    ' ============================================================
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MessageBox.Show("Please enter the guest's first name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtLastName.Text) Then
            MessageBox.Show("Please enter the guest's last name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLastName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtPhone.Text) Then
            MessageBox.Show("Please enter the guest's phone number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhone.Focus()
            Return False
        End If

        If Not String.IsNullOrWhiteSpace(txtEmail.Text) Then
            If Not Regex.IsMatch(txtEmail.Text.Trim(), "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
                MessageBox.Show("Please enter a valid email address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmail.Focus()
                Return False
            End If
        End If

        If cmbIDType.SelectedIndex = -1 Then
            MessageBox.Show("Please select an ID type.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbIDType.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtIDNumber.Text) Then
            MessageBox.Show("Please enter the ID number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtIDNumber.Focus()
            Return False
        End If

        Return True
    End Function

    ' ============================================================
    '  CLEAR FIELDS
    ' ============================================================
    Private Sub ClearFields()
        selectedGuestID = -1
        txtFirstName.Clear()
        txtLastName.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
        cmbIDType.SelectedIndex = -1
        txtIDNumber.Clear()
        dgvGuests.ClearSelection()
        txtFirstName.Focus()
    End Sub

End Class