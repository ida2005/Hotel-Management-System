Public Class MDIParent1

    Private activeBtn As Button = Nothing
    Private inactivityTimer As New System.Windows.Forms.Timer()
    Private Const TIMEOUT_MINUTES As Integer = 5
    Private displayTimer As New System.Windows.Forms.Timer()
    Private remainingSeconds As Integer = TIMEOUT_MINUTES * 60

    Private Sub BtnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        OpenChildForm(New DashboardForm(), btnDashboard)
    End Sub

    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserInfo.Text = CurrentUser.FullName & "  |  " & CurrentUser.Role
        btnUsers.Visible = (CurrentUser.Role = "Admin")

        PositionTopBarControls()

        inactivityTimer.Interval = TIMEOUT_MINUTES * 60 * 1000
        AddHandler inactivityTimer.Tick, AddressOf InactivityTimer_Tick
        inactivityTimer.Start()

        displayTimer.Interval = 1000
        AddHandler displayTimer.Tick, AddressOf DisplayTimer_Tick
        displayTimer.Start()

        OpenChildForm(New DashboardForm(), btnDashboard)
    End Sub

    Private Sub MDIParent1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PositionTopBarControls()
    End Sub

    Private Sub PositionTopBarControls()
        Dim barWidth As Integer = pnlTopBar.Width
        btnLogout.Location = New Point(barWidth - 100, 10)
        lblUserInfo.Location = New Point(barWidth - 560, 0)
        lblUserInfo.Size = New Size(450, 50)
    End Sub

    Private Sub InactivityTimer_Tick(sender As Object, e As EventArgs)
        inactivityTimer.Stop()
        MessageBox.Show(
            "You have been logged out due to " & TIMEOUT_MINUTES & " minutes of inactivity.",
            "Session Timeout",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
        PerformLogout()
    End Sub

    Private Sub DisplayTimer_Tick(sender As Object, e As EventArgs)
        If remainingSeconds > 0 Then
            remainingSeconds -= 1
        End If

        Dim minutes As Integer = remainingSeconds \ 60
        Dim seconds As Integer = remainingSeconds Mod 60
        lblUserInfo.Text = CurrentUser.FullName & "  |  " & CurrentUser.Role &
                       "  |  Auto-logout in " & minutes & ":" & seconds.ToString("D2")
    End Sub

    Private Sub ResetInactivityTimer()
        inactivityTimer.Stop()
        inactivityTimer.Start()
        remainingSeconds = TIMEOUT_MINUTES * 60
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        ResetInactivityTimer()
    End Sub

    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        ResetInactivityTimer()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        ResetInactivityTimer()
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_MOUSEMOVE As Integer = &H200
        Const WM_KEYDOWN As Integer = &H100
        Const WM_LBUTTONDOWN As Integer = &H201
        Const WM_RBUTTONDOWN As Integer = &H204

        Select Case m.Msg
            Case WM_MOUSEMOVE, WM_KEYDOWN, WM_LBUTTONDOWN, WM_RBUTTONDOWN
                ResetInactivityTimer()
        End Select

        MyBase.WndProc(m)
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
            PerformLogout()
        End If
    End Sub

    Private Sub PerformLogout()
        inactivityTimer.Stop()
        displayTimer.Stop()

        WriteAuditLog("LOGOUT", "Users", CurrentUser.UserID,
                  CurrentUser.FullName & " logged out.")

        CurrentUser.UserID = 0
        CurrentUser.FullName = ""
        CurrentUser.Role = ""

        For Each child As Form In Me.MdiChildren
            child.Close()
        Next

        Dim login As New LoginForm()
        login.Show()
        Me.Close()
    End Sub

    Private Sub MDIParent1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        inactivityTimer.Stop()
        inactivityTimer.Dispose()
        displayTimer.Stop()
        displayTimer.Dispose()
    End Sub

End Class