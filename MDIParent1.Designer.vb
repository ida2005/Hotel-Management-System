<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MDIParent1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlTopBar = New System.Windows.Forms.Panel()
        Me.lblSystemTitle = New System.Windows.Forms.Label()
        Me.lblUserInfo = New System.Windows.Forms.Label()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.btnBooking = New System.Windows.Forms.Button()
        Me.btnCheckInOut = New System.Windows.Forms.Button()
        Me.btnGuests = New System.Windows.Forms.Button()
        Me.btnGuestView = New System.Windows.Forms.Button()
        Me.btnRooms = New System.Windows.Forms.Button()
        Me.btnUsers = New System.Windows.Forms.Button()
        Me.pnlTopBar.SuspendLayout()
        Me.pnlSidebar.SuspendLayout()
        Me.SuspendLayout()

        '=== FORM ===
        Me.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
        Me.ClientSize = New System.Drawing.Size(1100, 680)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.IsMdiContainer = True
        Me.Name = "MDIParent1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hotel Management System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized

        '=== TOP BAR ===
        Me.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.pnlTopBar.Controls.Add(Me.lblSystemTitle)
        Me.pnlTopBar.Controls.Add(Me.lblUserInfo)
        Me.pnlTopBar.Controls.Add(Me.btnLogout)
        Me.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopBar.Location = New System.Drawing.Point(200, 0)
        Me.pnlTopBar.Name = "pnlTopBar"
        Me.pnlTopBar.Size = New System.Drawing.Size(900, 50)
        Me.pnlTopBar.TabIndex = 1

        '=== SYSTEM TITLE ===
        Me.lblSystemTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblSystemTitle.ForeColor = System.Drawing.Color.White
        Me.lblSystemTitle.Location = New System.Drawing.Point(10, 0)
        Me.lblSystemTitle.Name = "lblSystemTitle"
        Me.lblSystemTitle.Size = New System.Drawing.Size(350, 50)
        Me.lblSystemTitle.TabIndex = 0
        Me.lblSystemTitle.Text = "Hotel Management System"
        Me.lblSystemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        '=== USER INFO ===
        Me.lblUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblUserInfo.ForeColor = System.Drawing.Color.White
        Me.lblUserInfo.Location = New System.Drawing.Point(500, 0)
        Me.lblUserInfo.Name = "lblUserInfo"
        Me.lblUserInfo.Size = New System.Drawing.Size(450, 50)
        Me.lblUserInfo.TabIndex = 1
        Me.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight

        '=== LOGOUT BUTTON ===
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(200, 30, 30)
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(180, 0, 0)
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(960, 10)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(90, 30)
        Me.btnLogout.TabIndex = 2
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = False

        '=== SIDEBAR ===
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
        Me.pnlSidebar.Controls.Add(Me.btnDashboard)
        Me.pnlSidebar.Controls.Add(Me.btnBooking)
        Me.pnlSidebar.Controls.Add(Me.btnCheckInOut)
        Me.pnlSidebar.Controls.Add(Me.btnGuests)
        Me.pnlSidebar.Controls.Add(Me.btnGuestView)
        Me.pnlSidebar.Controls.Add(Me.btnRooms)
        Me.pnlSidebar.Controls.Add(Me.btnUsers)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(200, 680)
        Me.pnlSidebar.TabIndex = 2

        '=== SIDEBAR BUTTONS ===
        ' Dashboard (Y=0)
        Me.btnDashboard.BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
        Me.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDashboard.FlatAppearance.BorderSize = 0
        Me.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashboard.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnDashboard.ForeColor = System.Drawing.Color.White
        Me.btnDashboard.Location = New System.Drawing.Point(0, 0)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Size = New System.Drawing.Size(200, 45)
        Me.btnDashboard.TabIndex = 0
        Me.btnDashboard.Text = "  Dashboard"
        Me.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDashboard.UseVisualStyleBackColor = False

        ' Booking (Y=51)
        Me.btnBooking.BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
        Me.btnBooking.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBooking.FlatAppearance.BorderSize = 0
        Me.btnBooking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBooking.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnBooking.ForeColor = System.Drawing.Color.White
        Me.btnBooking.Location = New System.Drawing.Point(0, 51)
        Me.btnBooking.Name = "btnBooking"
        Me.btnBooking.Size = New System.Drawing.Size(200, 45)
        Me.btnBooking.TabIndex = 1
        Me.btnBooking.Text = "  Booking"
        Me.btnBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBooking.UseVisualStyleBackColor = False

        ' Check In / Out (Y=102)
        Me.btnCheckInOut.BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
        Me.btnCheckInOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheckInOut.FlatAppearance.BorderSize = 0
        Me.btnCheckInOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnCheckInOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckInOut.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnCheckInOut.ForeColor = System.Drawing.Color.White
        Me.btnCheckInOut.Location = New System.Drawing.Point(0, 102)
        Me.btnCheckInOut.Name = "btnCheckInOut"
        Me.btnCheckInOut.Size = New System.Drawing.Size(200, 45)
        Me.btnCheckInOut.TabIndex = 2
        Me.btnCheckInOut.Text = "  Check In / Out"
        Me.btnCheckInOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCheckInOut.UseVisualStyleBackColor = False

        ' Guest Management (Y=153)
        Me.btnGuests.BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
        Me.btnGuests.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuests.FlatAppearance.BorderSize = 0
        Me.btnGuests.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnGuests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuests.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnGuests.ForeColor = System.Drawing.Color.White
        Me.btnGuests.Location = New System.Drawing.Point(0, 153)
        Me.btnGuests.Name = "btnGuests"
        Me.btnGuests.Size = New System.Drawing.Size(200, 45)
        Me.btnGuests.TabIndex = 3
        Me.btnGuests.Text = "  Guest Management"
        Me.btnGuests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuests.UseVisualStyleBackColor = False

        ' Guest View (Y=204)
        Me.btnGuestView.BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
        Me.btnGuestView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuestView.FlatAppearance.BorderSize = 0
        Me.btnGuestView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnGuestView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuestView.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnGuestView.ForeColor = System.Drawing.Color.White
        Me.btnGuestView.Location = New System.Drawing.Point(0, 204)
        Me.btnGuestView.Name = "btnGuestView"
        Me.btnGuestView.Size = New System.Drawing.Size(200, 45)
        Me.btnGuestView.TabIndex = 4
        Me.btnGuestView.Text = "  Guest View"
        Me.btnGuestView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuestView.UseVisualStyleBackColor = False

        ' Room Management (Y=255)
        Me.btnRooms.BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
        Me.btnRooms.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRooms.FlatAppearance.BorderSize = 0
        Me.btnRooms.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRooms.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnRooms.ForeColor = System.Drawing.Color.White
        Me.btnRooms.Location = New System.Drawing.Point(0, 255)
        Me.btnRooms.Name = "btnRooms"
        Me.btnRooms.Size = New System.Drawing.Size(200, 45)
        Me.btnRooms.TabIndex = 5
        Me.btnRooms.Text = "  Room Management"
        Me.btnRooms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRooms.UseVisualStyleBackColor = False

        ' User Management (Y=306)
        Me.btnUsers.BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
        Me.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUsers.FlatAppearance.BorderSize = 0
        Me.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUsers.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnUsers.ForeColor = System.Drawing.Color.White
        Me.btnUsers.Location = New System.Drawing.Point(0, 306)
        Me.btnUsers.Name = "btnUsers"
        Me.btnUsers.Size = New System.Drawing.Size(200, 45)
        Me.btnUsers.TabIndex = 6
        Me.btnUsers.Text = "  User Management"
        Me.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUsers.UseVisualStyleBackColor = False

        '=== ADD CONTROLS TO FORM ===
        Me.Controls.Add(Me.pnlTopBar)
        Me.Controls.Add(Me.pnlSidebar)

        Me.pnlTopBar.ResumeLayout(False)
        Me.pnlSidebar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTopBar As System.Windows.Forms.Panel
    Friend WithEvents lblSystemTitle As System.Windows.Forms.Label
    Friend WithEvents lblUserInfo As System.Windows.Forms.Label
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents pnlSidebar As System.Windows.Forms.Panel
    Friend WithEvents btnDashboard As System.Windows.Forms.Button
    Friend WithEvents btnBooking As System.Windows.Forms.Button
    Friend WithEvents btnCheckInOut As System.Windows.Forms.Button
    Friend WithEvents btnGuests As System.Windows.Forms.Button
    Friend WithEvents btnGuestView As System.Windows.Forms.Button
    Friend WithEvents btnRooms As System.Windows.Forms.Button
    Friend WithEvents btnUsers As System.Windows.Forms.Button

End Class