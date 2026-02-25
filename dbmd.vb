Module dbmb

    Public connStr As String =
        "Data Source=(localdb)\MSSQLLocalDB;" &
        "Initial Catalog=HotelManagementSystem;" &
        "Integrated Security=True;" &
        "TrustServerCertificate=True;"

    Public Class CurrentUserInfo
        Public UserID As Integer
        Public FullName As String
        Public Role As String
    End Class

    Public CurrentUser As New CurrentUserInfo()

End Module