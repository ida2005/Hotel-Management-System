Partial Class RoomManagement
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlForm = New System.Windows.Forms.Panel()
        Me.lblRoomNumber = New System.Windows.Forms.Label()
        Me.txtRoomNumber = New System.Windows.Forms.TextBox()
        Me.lblRoomType = New System.Windows.Forms.Label()
        Me.cmbRoomType = New System.Windows.Forms.ComboBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgvRooms = New System.Windows.Forms.DataGridView()
        Me.pnlForm.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        CType(Me.dgvRooms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        '=== FORM ===
        Me.ClientSize = New System.Drawing.Size(1060, 620)
        Me.BackColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RoomManagement"
        Me.Text = "Room Management"
        Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)

        '=== LABEL: Title ===
        Me.lblTitle.AutoSize = False
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Size = New System.Drawing.Size(300, 35)
        Me.lblTitle.Text = "Room Management"
        Me.lblTitle.Name = "lblTitle"

        '=== PANEL: FORM (left side) ===
        Me.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlForm.Location = New System.Drawing.Point(20, 60)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Size = New System.Drawing.Size(320, 540)
        Me.pnlForm.BackColor = System.Drawing.Color.FromArgb(248, 248, 248)
        Me.pnlForm.Controls.Add(Me.lblRoomNumber)
        Me.pnlForm.Controls.Add(Me.txtRoomNumber)
        Me.pnlForm.Controls.Add(Me.lblRoomType)
        Me.pnlForm.Controls.Add(Me.cmbRoomType)
        Me.pnlForm.Controls.Add(Me.lblPrice)
        Me.pnlForm.Controls.Add(Me.txtPrice)
        Me.pnlForm.Controls.Add(Me.lblStatus)
        Me.pnlForm.Controls.Add(Me.cmbStatus)
        Me.pnlForm.Controls.Add(Me.lblDescription)
        Me.pnlForm.Controls.Add(Me.txtDescription)
        Me.pnlForm.Controls.Add(Me.btnAdd)
        Me.pnlForm.Controls.Add(Me.btnUpdate)
        Me.pnlForm.Controls.Add(Me.btnDelete)
        Me.pnlForm.Controls.Add(Me.btnClear)

        '=== LABEL: Room Number ===
        Me.lblRoomNumber.AutoSize = True
        Me.lblRoomNumber.Location = New System.Drawing.Point(15, 20)
        Me.lblRoomNumber.Name = "lblRoomNumber"
        Me.lblRoomNumber.Text = "Room Number"

        '=== TEXTBOX: Room Number ===
        Me.txtRoomNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRoomNumber.Location = New System.Drawing.Point(15, 40)
        Me.txtRoomNumber.Name = "txtRoomNumber"
        Me.txtRoomNumber.Size = New System.Drawing.Size(285, 25)

        '=== LABEL: Room Type ===
        Me.lblRoomType.AutoSize = True
        Me.lblRoomType.Location = New System.Drawing.Point(15, 80)
        Me.lblRoomType.Name = "lblRoomType"
        Me.lblRoomType.Text = "Room Type"

        '=== COMBOBOX: Room Type ===
        Me.cmbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRoomType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbRoomType.Location = New System.Drawing.Point(15, 100)
        Me.cmbRoomType.Name = "cmbRoomType"
        Me.cmbRoomType.Size = New System.Drawing.Size(285, 25)
        Me.cmbRoomType.Items.AddRange(New Object() {"Single", "Double", "Suite", "Deluxe", "Family"})

        '=== LABEL: Price ===
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Location = New System.Drawing.Point(15, 140)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Text = "Price per Night"

        '=== TEXTBOX: Price ===
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice.Location = New System.Drawing.Point(15, 160)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(285, 25)

        '=== LABEL: Status ===
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(15, 200)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Text = "Status"

        '=== COMBOBOX: Status ===
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStatus.Location = New System.Drawing.Point(15, 220)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(285, 25)
        Me.cmbStatus.Items.AddRange(New Object() {"Available", "Occupied", "Maintenance"})

        '=== LABEL: Description ===
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(15, 260)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Text = "Description"

        '=== TEXTBOX: Description ===
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Location = New System.Drawing.Point(15, 280)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(285, 80)
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical

        '=== BUTTON: Add ===
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.Location = New System.Drawing.Point(15, 380)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(130, 35)
        Me.btnAdd.Text = "Add Room"
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand

        '=== BUTTON: Update ===
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.Location = New System.Drawing.Point(170, 380)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(130, 35)
        Me.btnUpdate.Text = "Update Room"
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand

        '=== BUTTON: Delete ===
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(200, 35, 51)
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.Location = New System.Drawing.Point(15, 430)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(130, 35)
        Me.btnDelete.Text = "Delete Room"
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand

        '=== BUTTON: Clear ===
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(108, 117, 125)
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnClear.Location = New System.Drawing.Point(170, 430)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(130, 35)
        Me.btnClear.Text = "Clear"
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand

        '=== PANEL: GRID (right side) ===
        Me.pnlGrid.Location = New System.Drawing.Point(360, 60)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(680, 540)
        Me.pnlGrid.Controls.Add(Me.lblSearch)
        Me.pnlGrid.Controls.Add(Me.txtSearch)
        Me.pnlGrid.Controls.Add(Me.btnSearch)
        Me.pnlGrid.Controls.Add(Me.dgvRooms)

        '=== LABEL: Search ===
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(0, 5)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Text = "Search:"

        '=== TEXTBOX: Search ===
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(55, 2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(480, 25)

        '=== BUTTON: Search ===
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.btnSearch.Location = New System.Drawing.Point(545, 1)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 27)
        Me.btnSearch.Text = "Search"
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand

        '=== DATAGRIDVIEW: Rooms ===
        Me.dgvRooms.AllowUserToAddRows = False
        Me.dgvRooms.AllowUserToDeleteRows = False
        Me.dgvRooms.ReadOnly = True
        Me.dgvRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRooms.MultiSelect = False
        Me.dgvRooms.BackgroundColor = System.Drawing.Color.White
        Me.dgvRooms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgvRooms.RowHeadersVisible = False
        Me.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRooms.Location = New System.Drawing.Point(0, 35)
        Me.dgvRooms.Name = "dgvRooms"
        Me.dgvRooms.Size = New System.Drawing.Size(678, 500)
        Me.dgvRooms.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.dgvRooms.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.dgvRooms.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.dgvRooms.ColumnHeadersHeight = 35
        Me.dgvRooms.EnableHeadersVisualStyles = False
        Me.dgvRooms.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dgvRooms.RowTemplate.Height = 30

        '=== ADD CONTROLS TO FORM ===
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.pnlGrid)

        Me.pnlForm.ResumeLayout(False)
        Me.pnlForm.PerformLayout()
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGrid.PerformLayout()
        CType(Me.dgvRooms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlForm As System.Windows.Forms.Panel
    Friend WithEvents lblRoomNumber As System.Windows.Forms.Label
    Friend WithEvents txtRoomNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblRoomType As System.Windows.Forms.Label
    Friend WithEvents cmbRoomType As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvRooms As System.Windows.Forms.DataGridView

End Class