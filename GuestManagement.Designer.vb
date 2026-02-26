Partial Class GuestsManagement
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
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.lblIDType = New System.Windows.Forms.Label()
        Me.cmbIDType = New System.Windows.Forms.ComboBox()
        Me.lblIDNumber = New System.Windows.Forms.Label()
        Me.txtIDNumber = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgvGuests = New System.Windows.Forms.DataGridView()
        Me.pnlForm.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        CType(Me.dgvGuests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        '=== FORM ===
        Me.ClientSize = New System.Drawing.Size(1060, 620)
        Me.BackColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "GuestsManagement"
        Me.Text = "Guest Management"
        Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)

        '=== LABEL: Title ===
        Me.lblTitle.AutoSize = False
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Size = New System.Drawing.Size(300, 35)
        Me.lblTitle.Text = "Guest Management"
        Me.lblTitle.Name = "lblTitle"

        '=== PANEL: FORM (left side) ===
        Me.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlForm.Location = New System.Drawing.Point(20, 60)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Size = New System.Drawing.Size(320, 540)
        Me.pnlForm.BackColor = System.Drawing.Color.FromArgb(248, 248, 248)
        Me.pnlForm.Controls.Add(Me.lblFirstName)
        Me.pnlForm.Controls.Add(Me.txtFirstName)
        Me.pnlForm.Controls.Add(Me.lblLastName)
        Me.pnlForm.Controls.Add(Me.txtLastName)
        Me.pnlForm.Controls.Add(Me.lblEmail)
        Me.pnlForm.Controls.Add(Me.txtEmail)
        Me.pnlForm.Controls.Add(Me.lblPhone)
        Me.pnlForm.Controls.Add(Me.txtPhone)
        Me.pnlForm.Controls.Add(Me.lblAddress)
        Me.pnlForm.Controls.Add(Me.txtAddress)
        Me.pnlForm.Controls.Add(Me.lblIDType)
        Me.pnlForm.Controls.Add(Me.cmbIDType)
        Me.pnlForm.Controls.Add(Me.lblIDNumber)
        Me.pnlForm.Controls.Add(Me.txtIDNumber)
        Me.pnlForm.Controls.Add(Me.btnAdd)
        Me.pnlForm.Controls.Add(Me.btnUpdate)
        Me.pnlForm.Controls.Add(Me.btnDelete)
        Me.pnlForm.Controls.Add(Me.btnClear)

        '=== LABEL: First Name ===
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(15, 20)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Text = "First Name"

        '=== TEXTBOX: First Name ===
        Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirstName.Location = New System.Drawing.Point(15, 40)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(285, 25)

        '=== LABEL: Last Name ===
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(15, 75)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Text = "Last Name"

        '=== TEXTBOX: Last Name ===
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastName.Location = New System.Drawing.Point(15, 95)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(285, 25)

        '=== LABEL: Email ===
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(15, 130)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Text = "Email"

        '=== TEXTBOX: Email ===
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Location = New System.Drawing.Point(15, 150)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(285, 25)

        '=== LABEL: Phone ===
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(15, 185)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Text = "Phone"

        '=== TEXTBOX: Phone ===
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone.Location = New System.Drawing.Point(15, 205)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(285, 25)

        '=== LABEL: Address ===
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(15, 240)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Text = "Address"

        '=== TEXTBOX: Address ===
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Location = New System.Drawing.Point(15, 260)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(285, 55)
        Me.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical

        '=== LABEL: ID Type ===
        Me.lblIDType.AutoSize = True
        Me.lblIDType.Location = New System.Drawing.Point(15, 325)
        Me.lblIDType.Name = "lblIDType"
        Me.lblIDType.Text = "ID Type"

        '=== COMBOBOX: ID Type ===
        Me.cmbIDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIDType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbIDType.Location = New System.Drawing.Point(15, 345)
        Me.cmbIDType.Name = "cmbIDType"
        Me.cmbIDType.Size = New System.Drawing.Size(285, 25)
        Me.cmbIDType.Items.AddRange(New Object() {"Passport", "Driver's License", "National ID", "SSS ID", "PhilHealth ID"})

        '=== LABEL: ID Number ===
        Me.lblIDNumber.AutoSize = True
        Me.lblIDNumber.Location = New System.Drawing.Point(15, 380)
        Me.lblIDNumber.Name = "lblIDNumber"
        Me.lblIDNumber.Text = "ID Number"

        '=== TEXTBOX: ID Number ===
        Me.txtIDNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIDNumber.Location = New System.Drawing.Point(15, 400)
        Me.txtIDNumber.Name = "txtIDNumber"
        Me.txtIDNumber.Size = New System.Drawing.Size(285, 25)

        '=== BUTTON: Add ===
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.Location = New System.Drawing.Point(15, 445)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(130, 35)
        Me.btnAdd.Text = "Add Guest"
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand

        '=== BUTTON: Update ===
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.Location = New System.Drawing.Point(170, 445)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(130, 35)
        Me.btnUpdate.Text = "Update Guest"
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand

        '=== BUTTON: Delete ===
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(200, 35, 51)
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.Location = New System.Drawing.Point(15, 490)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(130, 35)
        Me.btnDelete.Text = "Delete Guest"
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand

        '=== BUTTON: Clear ===
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(108, 117, 125)
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnClear.Location = New System.Drawing.Point(170, 490)
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
        Me.pnlGrid.Controls.Add(Me.dgvGuests)

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

        '=== DATAGRIDVIEW: Guests ===
        Me.dgvGuests.AllowUserToAddRows = False
        Me.dgvGuests.AllowUserToDeleteRows = False
        Me.dgvGuests.ReadOnly = True
        Me.dgvGuests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGuests.MultiSelect = False
        Me.dgvGuests.BackgroundColor = System.Drawing.Color.White
        Me.dgvGuests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgvGuests.RowHeadersVisible = False
        Me.dgvGuests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGuests.Location = New System.Drawing.Point(0, 35)
        Me.dgvGuests.Name = "dgvGuests"
        Me.dgvGuests.Size = New System.Drawing.Size(678, 500)
        Me.dgvGuests.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.dgvGuests.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.dgvGuests.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.dgvGuests.ColumnHeadersHeight = 35
        Me.dgvGuests.EnableHeadersVisualStyles = False
        Me.dgvGuests.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dgvGuests.RowTemplate.Height = 30

        '=== ADD CONTROLS TO FORM ===
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.pnlGrid)

        Me.pnlForm.ResumeLayout(False)
        Me.pnlForm.PerformLayout()
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGrid.PerformLayout()
        CType(Me.dgvGuests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlForm As System.Windows.Forms.Panel
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblIDType As System.Windows.Forms.Label
    Friend WithEvents cmbIDType As System.Windows.Forms.ComboBox
    Friend WithEvents lblIDNumber As System.Windows.Forms.Label
    Friend WithEvents txtIDNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvGuests As System.Windows.Forms.DataGridView

End Class