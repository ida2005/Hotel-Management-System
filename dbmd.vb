Module dbmb

    Public connStr As String =
        "Data Source=LESTER\SQLEXPRESS;" &
        "Initial Catalog=HotelManagementSystem;" &
        "Integrated Security=True;" &
        "TrustServerCertificate=True;"

    Public Class CurrentUserInfo
        Public UserID As Integer
        Public FullName As String
        Public Role As String
    End Class

    Public CurrentUser As New CurrentUserInfo()
    Public Function HashPassword(password As String) As String
        Using sha256 As System.Security.Cryptography.SHA256 =
                  System.Security.Cryptography.SHA256.Create()

            Dim bytes As Byte() =
                System.Text.Encoding.UTF8.GetBytes(password)

            Dim hashBytes As Byte() = sha256.ComputeHash(bytes)

            Dim sb As New System.Text.StringBuilder()
            For Each b As Byte In hashBytes
                sb.Append(b.ToString("x2"))
            Next
            Return sb.ToString()
        End Using
    End Function

    Public Sub WriteAuditLog(action As String, tableName As String,
                              recordID As Integer, details As String)
        Try
            Using conn As New System.Data.SqlClient.SqlConnection(connStr)
                conn.Open()
                Dim cmd As New System.Data.SqlClient.SqlCommand(
                    "INSERT INTO tbl_AuditLog (UserID, FullName, Action, TableName, RecordID, Details, LogDate) " &
                    "VALUES (@uid, @name, @action, @table, @rid, @details, @date)", conn)
                cmd.Parameters.AddWithValue("@uid", CurrentUser.UserID)
                cmd.Parameters.AddWithValue("@name", CurrentUser.FullName)
                cmd.Parameters.AddWithValue("@action", action)
                cmd.Parameters.AddWithValue("@table", tableName)
                cmd.Parameters.AddWithValue("@rid", recordID)
                cmd.Parameters.AddWithValue("@details", details)
                cmd.Parameters.AddWithValue("@date", DateTime.Now)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
        End Try
    End Sub

End Module