Imports System.Data.SqlClient

Public Class LoginForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Focus()
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            ShowError("Please enter your username.")
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            ShowError("Please enter your password.")
            txtPassword.Focus()
            Return
        End If

        AuthenticateUser(txtUsername.Text.Trim(), txtPassword.Text.Trim())
    End Sub

    Private Sub AuthenticateUser(username As String, password As String)
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim hashedPassword As String = HashPassword(password)

                Dim query As String =
                "SELECT UserID, FullName, Role FROM tbl_Users " &
                "WHERE Username = @user AND Password = @pass"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@user", username)
                    cmd.Parameters.AddWithValue("@pass", hashedPassword)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()

                            CurrentUser.UserID = CInt(reader("UserID"))
                            CurrentUser.FullName = reader("FullName").ToString()
                            CurrentUser.Role = reader("Role").ToString()

                            ' LOG THE LOGIN
                            WriteAuditLog("LOGIN", "Users", CurrentUser.UserID,
                                          CurrentUser.FullName & " logged in.")

                            Dim dashboard As New MDIParent1()
                            dashboard.Show()
                            Me.Hide()
                        End If
                    End Using
                End Using
            End Using

        Catch ex As SqlException
            ShowError("Database error: " & ex.Message)
        Catch ex As Exception
            ShowError("Cannot connect to database.")
        End Try
    End Sub

    Private Sub ShowError(message As String)
        lblError.Text = message
        lblError.Visible = True
    End Sub

    Private Sub ChkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.PasswordChar = If(chkShowPassword.Checked, Chr(0), ChrW(9679))
    End Sub

    Private Sub TxtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then txtPassword.Focus()
    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then BtnLogin_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        lblError.Visible = False
    End Sub

    Private Sub TxtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        lblError.Visible = False
    End Sub

End Class