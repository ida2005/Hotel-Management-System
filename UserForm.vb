Imports System.Data.SqlClient

Public Class UserForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private selectedUserID As Integer = -1

    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
    End Sub

    Private Sub LoadUsers(Optional filter As String = "")
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim query As String =
                "SELECT UserID, FullName, Username, Role FROM tbl_Users " &
                "WHERE (@filter = '' OR FullName LIKE @search " &
                "OR Username LIKE @search " &
                "OR Role LIKE @search) " &
                "ORDER BY FullName"

                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@filter", filter)
                cmd.Parameters.AddWithValue("@search", "%" & filter & "%")

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvUsers.DataSource = dt

                If dgvUsers.Columns.Contains("UserID") Then
                    dgvUsers.Columns("UserID").Visible = False
                End If

                If dgvUsers.Columns.Contains("FullName") Then dgvUsers.Columns("FullName").HeaderText = "Full Name"
                If dgvUsers.Columns.Contains("Username") Then dgvUsers.Columns("Username").HeaderText = "Username"
                If dgvUsers.Columns.Contains("Role") Then dgvUsers.Columns("Role").HeaderText = "Role"

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInputs(True) Then Return

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim checkCmd As New SqlCommand(
                "SELECT COUNT(*) FROM tbl_Users WHERE Username = @user", conn)
                checkCmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
                If CInt(checkCmd.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Username already exists. Please choose another.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtUsername.Focus()
                    Return
                End If

                Dim hashedPassword As String = HashPassword(txtPassword.Text.Trim())

                Dim cmd As New SqlCommand(
                "INSERT INTO tbl_Users (FullName, Username, Password, Role) " &
                "VALUES (@fn, @user, @pass, @role)", conn)
                cmd.Parameters.AddWithValue("@fn", txtFullName.Text.Trim())
                cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
                cmd.Parameters.AddWithValue("@pass", hashedPassword)
                cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString())

                cmd.ExecuteNonQuery()
                MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                WriteAuditLog("ADD", "User", -1,
                "Added user: " & txtUsername.Text.Trim() &
                " role: " & cmbRole.SelectedItem.ToString())
                ClearFields()
                LoadUsers()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedUserID = -1 Then
            MessageBox.Show("Please select a user to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If selectedUserID = CurrentUser.UserID Then
            MessageBox.Show("You cannot edit your own account here.", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateInputs(False) Then Return

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim query As String
                Dim cmd As New SqlCommand()
                cmd.Connection = conn

                If String.IsNullOrWhiteSpace(txtPassword.Text) Then
                    query = "UPDATE tbl_Users SET FullName=@fn, Username=@user, Role=@role WHERE UserID=@id"
                Else
                    Dim hashedPassword As String = HashPassword(txtPassword.Text.Trim())
                    query = "UPDATE tbl_Users SET FullName=@fn, Username=@user, Password=@pass, Role=@role WHERE UserID=@id"
                    cmd.Parameters.AddWithValue("@pass", hashedPassword)
                End If

                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@fn", txtFullName.Text.Trim())
                cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
                cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@id", selectedUserID)

                cmd.ExecuteNonQuery()
                MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                WriteAuditLog("UPDATE", "User", selectedUserID,
                "Updated user ID " & selectedUserID & ": " &
                txtUsername.Text.Trim() & " role: " & cmbRole.SelectedItem.ToString())
                ClearFields()
                LoadUsers()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedUserID = -1 Then
            MessageBox.Show("Please select a user to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Prevent deleting own account
        If selectedUserID = CurrentUser.UserID Then
            MessageBox.Show("You cannot delete your own account.", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this user?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            Try
                Using conn As New SqlConnection(connStr)
                    conn.Open()
                    Dim cmd As New SqlCommand(
                        "DELETE FROM tbl_Users WHERE UserID = @id", conn)
                    cmd.Parameters.AddWithValue("@id", selectedUserID)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    WriteAuditLog("DELETE", "User", selectedUserID,
                    "Deleted user ID " & selectedUserID)
                    ClearFields()
                    LoadUsers()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error deleting user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadUsers(txtSearch.Text.Trim())
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then LoadUsers(txtSearch.Text.Trim())
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Trim() = "" Then LoadUsers()
    End Sub

    Private Sub DgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
        If e.RowIndex < 0 Then Return

        Dim row As DataGridViewRow = dgvUsers.Rows(e.RowIndex)

        selectedUserID = CInt(row.Cells("UserID").Value)
        txtFullName.Text = row.Cells("FullName").Value?.ToString()
        txtUsername.Text = row.Cells("Username").Value?.ToString()
        txtPassword.Clear()
        txtConfirmPassword.Clear()
        cmbRole.SelectedItem = row.Cells("Role").Value?.ToString()

        ' Highlight if viewing own account
        If selectedUserID = CurrentUser.UserID Then
            lblTitle.Text = "User Management  (Your Account)"
        Else
            lblTitle.Text = "User Management"
        End If
    End Sub

    Private Sub DgvUsers_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvUsers.RowPrePaint
        If e.RowIndex < 0 Then Return

        Dim role As String = dgvUsers.Rows(e.RowIndex).Cells("Role").Value?.ToString()
        Dim uid As Integer = CInt(dgvUsers.Rows(e.RowIndex).Cells("UserID").Value)

        If uid = CurrentUser.UserID Then
            ' Highlight logged-in user row
            dgvUsers.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(210, 230, 255)
        ElseIf role = "Admin" Then
            dgvUsers.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 200)
        Else
            dgvUsers.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        End If
    End Sub

    Private Sub ChkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        Dim ch As Char = If(chkShowPassword.Checked, Chr(0), ChrW(9679))
        txtPassword.PasswordChar = ch
        txtConfirmPassword.PasswordChar = ch
    End Sub

    Private Function ValidateInputs(isNew As Boolean) As Boolean
        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Please enter the full name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please enter a username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If

        If txtUsername.Text.Trim().Length < 4 Then
            MessageBox.Show("Username must be at least 4 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If

        ' Password required for new users
        If isNew Then
            If String.IsNullOrWhiteSpace(txtPassword.Text) Then
                MessageBox.Show("Please enter a password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return False
            End If
        End If

        ' If password is filled, validate it
        If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
            If txtPassword.Text.Trim().Length < 6 Then
                MessageBox.Show("Password must be at least 6 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return False
            End If

            If txtPassword.Text <> txtConfirmPassword.Text Then
                MessageBox.Show("Passwords do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtConfirmPassword.Focus()
                Return False
            End If
        End If

        If cmbRole.SelectedIndex = -1 Then
            MessageBox.Show("Please select a role.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRole.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ClearFields()
        selectedUserID = -1
        txtFullName.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtConfirmPassword.Clear()
        cmbRole.SelectedIndex = -1
        chkShowPassword.Checked = False
        lblTitle.Text = "User Management"
        dgvUsers.ClearSelection()
        txtFullName.Focus()
    End Sub

End Class