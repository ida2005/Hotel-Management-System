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
        Me.btnBooking = New System.Windows.Forms.Button()
        Me.btnCheckInOut = New System.Windows.Forms.Button()
        Me.btnGuests = New System.Windows.Forms.Button()
        Me.btnGuestView = New System.Windows.Forms.Button()
        Me.btnRooms = New System.Windows.Forms.Button()
        Me.btnUsers = New System.Windows.Forms.Button()
        Me.pnlTopBar.SuspendLayout()
        Me.pnlSidebar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTopBar
        '
        Me.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.pnlTopBar.Controls.Add(Me.lblSystemTitle)
        Me.pnlTopBar.Controls.Add(Me.lblUserInfo)
        Me.pnlTopBar.Controls.Add(Me.btnLogout)
        Me.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopBar.Location = New System.Drawing.Point(200, 0)
        Me.pnlTopBar.Name = "pnlTopBar"
        Me.pnlTopBar.Size = New System.Drawing.Size(900, 50)
        Me.pnlTopBar.TabIndex = 1
        '
        'lblSystemTitle
        '
        Me.lblSystemTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblSystemTitle.ForeColor = System.Drawing.Color.White
        Me.lblSystemTitle.Location = New System.Drawing.Point(3, 0)
        Me.lblSystemTitle.Name = "lblSystemTitle"
        Me.lblSystemTitle.Size = New System.Drawing.Size(350, 50)
        Me.lblSystemTitle.TabIndex = 0
        Me.lblSystemTitle.Text = "Hotel Management System"
        Me.lblSystemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserInfo
        '
        Me.lblUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblUserInfo.ForeColor = System.Drawing.Color.White
        Me.lblUserInfo.Location = New System.Drawing.Point(700, 0)
        Me.lblUserInfo.Name = "lblUserInfo"
        Me.lblUserInfo.Size = New System.Drawing.Size(280, 50)
        Me.lblUserInfo.TabIndex = 1
        Me.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(990, 10)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(90, 30)
        Me.btnLogout.TabIndex = 2
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
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
        '
        'btnBooking
        '
        Me.btnBooking.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnBooking.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBooking.FlatAppearance.BorderSize = 0
        Me.btnBooking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBooking.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnBooking.ForeColor = System.Drawing.Color.White
        Me.btnBooking.Location = New System.Drawing.Point(0, 0)
        Me.btnBooking.Name = "btnBooking"
        Me.btnBooking.Size = New System.Drawing.Size(200, 45)
        Me.btnBooking.TabIndex = 0
        Me.btnBooking.Text = "  Booking"
        Me.btnBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBooking.UseVisualStyleBackColor = False
        '
        'btnCheckInOut
        '
        Me.btnCheckInOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnCheckInOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheckInOut.FlatAppearance.BorderSize = 0
        Me.btnCheckInOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnCheckInOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckInOut.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnCheckInOut.ForeColor = System.Drawing.Color.White
        Me.btnCheckInOut.Location = New System.Drawing.Point(0, 51)
        Me.btnCheckInOut.Name = "btnCheckInOut"
        Me.btnCheckInOut.Size = New System.Drawing.Size(200, 45)
        Me.btnCheckInOut.TabIndex = 1
        Me.btnCheckInOut.Text = "  Check In / Out"
        Me.btnCheckInOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCheckInOut.UseVisualStyleBackColor = False
        '
        'btnGuests
        '
        Me.btnGuests.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnGuests.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuests.FlatAppearance.BorderSize = 0
        Me.btnGuests.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnGuests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuests.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnGuests.ForeColor = System.Drawing.Color.White
        Me.btnGuests.Location = New System.Drawing.Point(0, 102)
        Me.btnGuests.Name = "btnGuests"
        Me.btnGuests.Size = New System.Drawing.Size(200, 45)
        Me.btnGuests.TabIndex = 2
        Me.btnGuests.Text = "  Guest Management"
        Me.btnGuests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuests.UseVisualStyleBackColor = False
        '
        'btnGuestView
        '
        Me.btnGuestView.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnGuestView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuestView.FlatAppearance.BorderSize = 0
        Me.btnGuestView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnGuestView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuestView.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnGuestView.ForeColor = System.Drawing.Color.White
        Me.btnGuestView.Location = New System.Drawing.Point(0, 153)
        Me.btnGuestView.Name = "btnGuestView"
        Me.btnGuestView.Size = New System.Drawing.Size(200, 45)
        Me.btnGuestView.TabIndex = 3
        Me.btnGuestView.Text = "  Guest View"
        Me.btnGuestView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuestView.UseVisualStyleBackColor = False
        '
        'btnRooms
        '
        Me.btnRooms.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnRooms.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRooms.FlatAppearance.BorderSize = 0
        Me.btnRooms.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRooms.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnRooms.ForeColor = System.Drawing.Color.White
        Me.btnRooms.Location = New System.Drawing.Point(0, 204)
        Me.btnRooms.Name = "btnRooms"
        Me.btnRooms.Size = New System.Drawing.Size(200, 45)
        Me.btnRooms.TabIndex = 4
        Me.btnRooms.Text = "  Room Management"
        Me.btnRooms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRooms.UseVisualStyleBackColor = False
        '
        'btnUsers
        '
        Me.btnUsers.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUsers.FlatAppearance.BorderSize = 0
        Me.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUsers.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnUsers.ForeColor = System.Drawing.Color.White
        Me.btnUsers.Location = New System.Drawing.Point(0, 255)
        Me.btnUsers.Name = "btnUsers"
        Me.btnUsers.Size = New System.Drawing.Size(200, 45)
        Me.btnUsers.TabIndex = 5
        Me.btnUsers.Text = "  User Management"
        Me.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUsers.UseVisualStyleBackColor = False
        '
        'MDIParent1
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1100, 680)
        Me.Controls.Add(Me.pnlTopBar)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.IsMdiContainer = True
        Me.Name = "MDIParent1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hotel Management System - Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlTopBar.ResumeLayout(False)
        Me.pnlSidebar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    '=== CONTROL DECLARATIONS ===
    Friend WithEvents pnlTopBar As System.Windows.Forms.Panel
    Friend WithEvents lblSystemTitle As System.Windows.Forms.Label
    Friend WithEvents lblUserInfo As System.Windows.Forms.Label
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents pnlSidebar As System.Windows.Forms.Panel
    Friend WithEvents btnBooking As System.Windows.Forms.Button
    Friend WithEvents btnCheckInOut As System.Windows.Forms.Button
    Friend WithEvents btnGuests As System.Windows.Forms.Button
    Friend WithEvents btnGuestView As System.Windows.Forms.Button
    Friend WithEvents btnRooms As System.Windows.Forms.Button
    Friend WithEvents btnUsers As System.Windows.Forms.Button

End Class