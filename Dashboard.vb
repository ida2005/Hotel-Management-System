Public Class MDIParent1

    Private activeBtn As Button = Nothing
    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserInfo.Text = CurrentUser.FullName & "  |  " & CurrentUser.Role
        btnUsers.Visible = (CurrentUser.Role = "Admin")
        btnLogout.Location = New Point(Me.ClientSize.Width - 105, 10)
        lblUserInfo.Location = New Point(Me.ClientSize.Width - 400, 0)
    End Sub

    Private Sub MDIParent1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        btnLogout.Location = New Point(Me.ClientSize.Width - 105, 10)
        lblUserInfo.Location = New Point(Me.ClientSize.Width - 400, 0)
    End Sub

    Private Sub OpenChildForm(frm As Form, clickedBtn As Button)
        For Each child As Form In Me.MdiChildren
            child.Close()
        Next

        If activeBtn IsNot Nothing Then
            activeBtn.BackColor = Color.FromArgb(45, 45, 48)
        End If
        clickedBtn.BackColor = Color.FromArgb(0, 120, 215)
        activeBtn = clickedBtn

        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub
    Private Sub BtnBooking_Click(sender As Object, e As EventArgs) Handles btnBooking.Click
        OpenChildForm(New BookingForm(), btnBooking)
    End Sub

    Private Sub BtnCheckInOut_Click(sender As Object, e As EventArgs) Handles btnCheckInOut.Click
        OpenChildForm(New CheckInCheckOut(), btnCheckInOut)
    End Sub

    Private Sub BtnGuests_Click(sender As Object, e As EventArgs) Handles btnGuests.Click
        OpenChildForm(New GuestsManagement(), btnGuests)
    End Sub

    Private Sub BtnGuestView_Click(sender As Object, e As EventArgs) Handles btnGuestView.Click
        OpenChildForm(New GuestViewForm(), btnGuestView)
    End Sub

    Private Sub BtnRooms_Click(sender As Object, e As EventArgs) Handles btnRooms.Click
        OpenChildForm(New RoomManagement(), btnRooms)
    End Sub

    Private Sub BtnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        OpenChildForm(New UserForm(), btnUsers)
    End Sub
    Private Sub BtnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to logout?",
            "Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            CurrentUser.UserID = 0
            CurrentUser.FullName = ""
            CurrentUser.Role = ""

            For Each child As Form In Me.MdiChildren
                child.Close()
            Next

            Dim login As New LoginForm()
            login.Show()
            Me.Close()
        End If
    End Sub

End Class