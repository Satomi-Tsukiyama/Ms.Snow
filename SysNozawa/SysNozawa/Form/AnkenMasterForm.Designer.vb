<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnkenMasterForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mitmAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mitmEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mitmDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvAnken = New System.Windows.Forms.DataGridView()
        Me.cId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCode1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCode2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCode3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSalesYearMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSalesAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cClientID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cClient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cInsertDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStaffID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStaffName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbCode1 = New System.Windows.Forms.ComboBox()
        Me.txtCode3 = New System.Windows.Forms.TextBox()
        Me.txtCode2 = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cmbClient = New System.Windows.Forms.ComboBox()
        Me.dtpSalesYearMonth = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSalesAmount = New System.Windows.Forms.TextBox()
        Me.cmbStaff = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbCode2 = New System.Windows.Forms.ComboBox()
        Me.btnEditCode3 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvAnken, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mitmAdd, Me.mitmEdit, Me.mitmDelete})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(704, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mitmAdd
        '
        Me.mitmAdd.Name = "mitmAdd"
        Me.mitmAdd.Size = New System.Drawing.Size(68, 22)
        Me.mitmAdd.Text = "新規追加"
        '
        'mitmEdit
        '
        Me.mitmEdit.Name = "mitmEdit"
        Me.mitmEdit.Size = New System.Drawing.Size(44, 22)
        Me.mitmEdit.Text = "編集"
        '
        'mitmDelete
        '
        Me.mitmDelete.Name = "mitmDelete"
        Me.mitmDelete.Size = New System.Drawing.Size(44, 22)
        Me.mitmDelete.Text = "削除"
        '
        'dgvAnken
        '
        Me.dgvAnken.AllowUserToAddRows = False
        Me.dgvAnken.AllowUserToDeleteRows = False
        Me.dgvAnken.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAnken.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAnken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAnken.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cId, Me.cCode1, Me.cCode2, Me.cCode3, Me.cCode, Me.cName, Me.cSalesYearMonth, Me.cSalesAmount, Me.cClientID, Me.cClient, Me.cStatus, Me.cInsertDate, Me.cStaffID, Me.cStaffName})
        Me.dgvAnken.Location = New System.Drawing.Point(28, 116)
        Me.dgvAnken.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dgvAnken.Name = "dgvAnken"
        Me.dgvAnken.ReadOnly = True
        Me.dgvAnken.RowTemplate.Height = 27
        Me.dgvAnken.Size = New System.Drawing.Size(649, 303)
        Me.dgvAnken.TabIndex = 11
        '
        'cId
        '
        Me.cId.DataPropertyName = "cId"
        Me.cId.HeaderText = ""
        Me.cId.Name = "cId"
        Me.cId.ReadOnly = True
        Me.cId.Visible = False
        '
        'cCode1
        '
        Me.cCode1.DataPropertyName = "cCode1"
        Me.cCode1.HeaderText = "工番1"
        Me.cCode1.Name = "cCode1"
        Me.cCode1.ReadOnly = True
        Me.cCode1.Visible = False
        '
        'cCode2
        '
        Me.cCode2.DataPropertyName = "cCode2"
        Me.cCode2.HeaderText = "工番2"
        Me.cCode2.Name = "cCode2"
        Me.cCode2.ReadOnly = True
        Me.cCode2.Visible = False
        '
        'cCode3
        '
        Me.cCode3.DataPropertyName = "cCode3"
        Me.cCode3.HeaderText = "工番3"
        Me.cCode3.Name = "cCode3"
        Me.cCode3.ReadOnly = True
        Me.cCode3.Visible = False
        '
        'cCode
        '
        Me.cCode.DataPropertyName = "cCode"
        Me.cCode.FillWeight = 70.0!
        Me.cCode.HeaderText = "工番"
        Me.cCode.Name = "cCode"
        Me.cCode.ReadOnly = True
        '
        'cName
        '
        Me.cName.DataPropertyName = "cName"
        Me.cName.FillWeight = 130.0!
        Me.cName.HeaderText = "件名"
        Me.cName.Name = "cName"
        Me.cName.ReadOnly = True
        '
        'cSalesYearMonth
        '
        Me.cSalesYearMonth.DataPropertyName = "cSalesYearMonth"
        DataGridViewCellStyle7.Format = "yyyy年MM月"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.cSalesYearMonth.DefaultCellStyle = DataGridViewCellStyle7
        Me.cSalesYearMonth.HeaderText = "売上年月"
        Me.cSalesYearMonth.Name = "cSalesYearMonth"
        Me.cSalesYearMonth.ReadOnly = True
        '
        'cSalesAmount
        '
        Me.cSalesAmount.DataPropertyName = "cSalesAmount"
        DataGridViewCellStyle8.Format = "C0"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.cSalesAmount.DefaultCellStyle = DataGridViewCellStyle8
        Me.cSalesAmount.HeaderText = "売上金額"
        Me.cSalesAmount.Name = "cSalesAmount"
        Me.cSalesAmount.ReadOnly = True
        '
        'cClientID
        '
        Me.cClientID.DataPropertyName = "cClientID"
        Me.cClientID.HeaderText = "取引先ID"
        Me.cClientID.Name = "cClientID"
        Me.cClientID.ReadOnly = True
        Me.cClientID.Visible = False
        '
        'cClient
        '
        Me.cClient.DataPropertyName = "cClient"
        Me.cClient.HeaderText = "取引先"
        Me.cClient.Name = "cClient"
        Me.cClient.ReadOnly = True
        '
        'cStatus
        '
        Me.cStatus.DataPropertyName = "cStatus"
        Me.cStatus.HeaderText = "請求状況"
        Me.cStatus.Name = "cStatus"
        Me.cStatus.ReadOnly = True
        Me.cStatus.Visible = False
        '
        'cInsertDate
        '
        Me.cInsertDate.DataPropertyName = "cInsertDate"
        DataGridViewCellStyle9.Format = "D"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.cInsertDate.DefaultCellStyle = DataGridViewCellStyle9
        Me.cInsertDate.HeaderText = "作成日"
        Me.cInsertDate.Name = "cInsertDate"
        Me.cInsertDate.ReadOnly = True
        '
        'cStaffID
        '
        Me.cStaffID.DataPropertyName = "cStaffID"
        Me.cStaffID.HeaderText = "作成者ID"
        Me.cStaffID.Name = "cStaffID"
        Me.cStaffID.ReadOnly = True
        Me.cStaffID.Visible = False
        '
        'cStaffName
        '
        Me.cStaffName.DataPropertyName = "cStaffName"
        Me.cStaffName.HeaderText = "作成者"
        Me.cStaffName.Name = "cStaffName"
        Me.cStaffName.ReadOnly = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtName, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbClient, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpSalesYearMonth, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbStaff, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbStatus, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 1, 5)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(28, 423)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(649, 226)
        Me.TableLayoutPanel1.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(85, 203)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 12)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "（必須）"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 203)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "請求状況"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(85, 170)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "（必須）"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 74)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "取引先"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 42)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "件名"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "工番"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 170)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "作成者"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 138)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "売上金額"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 106)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "売上年月"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cmbCode1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCode3, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCode2, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnEditCode3, 3, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(130, 2)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(350, 28)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'cmbCode1
        '
        Me.cmbCode1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCode1.FormattingEnabled = True
        Me.cmbCode1.Location = New System.Drawing.Point(2, 4)
        Me.cmbCode1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbCode1.Name = "cmbCode1"
        Me.cmbCode1.Size = New System.Drawing.Size(83, 20)
        Me.cmbCode1.TabIndex = 0
        '
        'txtCode3
        '
        Me.txtCode3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCode3.Location = New System.Drawing.Point(176, 4)
        Me.txtCode3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtCode3.Name = "txtCode3"
        Me.txtCode3.ReadOnly = True
        Me.txtCode3.Size = New System.Drawing.Size(83, 19)
        Me.txtCode3.TabIndex = 2
        '
        'txtCode2
        '
        Me.txtCode2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCode2.Location = New System.Drawing.Point(89, 4)
        Me.txtCode2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtCode2.Name = "txtCode2"
        Me.txtCode2.Size = New System.Drawing.Size(83, 19)
        Me.txtCode2.TabIndex = 1
        '
        'txtName
        '
        Me.txtName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(130, 38)
        Me.txtName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(517, 19)
        Me.txtName.TabIndex = 5
        '
        'cmbClient
        '
        Me.cmbClient.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(130, 70)
        Me.cmbClient.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(139, 20)
        Me.cmbClient.TabIndex = 8
        '
        'dtpSalesYearMonth
        '
        Me.dtpSalesYearMonth.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpSalesYearMonth.CustomFormat = "yyyy/MM"
        Me.dtpSalesYearMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSalesYearMonth.Location = New System.Drawing.Point(130, 102)
        Me.dtpSalesYearMonth.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtpSalesYearMonth.Name = "dtpSalesYearMonth"
        Me.dtpSalesYearMonth.ShowUpDown = True
        Me.dtpSalesYearMonth.Size = New System.Drawing.Size(122, 19)
        Me.dtpSalesYearMonth.TabIndex = 10
        Me.dtpSalesYearMonth.Value = New Date(2019, 10, 1, 0, 0, 0, 0)
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.57143!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.42857!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label6, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtSalesAmount, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(130, 134)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(210, 20)
        Me.TableLayoutPanel3.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(141, 4)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "円"
        '
        'txtSalesAmount
        '
        Me.txtSalesAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSalesAmount.Location = New System.Drawing.Point(2, 2)
        Me.txtSalesAmount.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSalesAmount.Name = "txtSalesAmount"
        Me.txtSalesAmount.Size = New System.Drawing.Size(135, 19)
        Me.txtSalesAmount.TabIndex = 0
        Me.txtSalesAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbStaff
        '
        Me.cmbStaff.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbStaff.FormattingEnabled = True
        Me.cmbStaff.Location = New System.Drawing.Point(130, 166)
        Me.cmbStaff.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbStaff.Name = "cmbStaff"
        Me.cmbStaff.Size = New System.Drawing.Size(139, 20)
        Me.cmbStaff.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(85, 10)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "（必須）"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(85, 42)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "（必須）"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(85, 74)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "（必須）"
        '
        'cmbStatus
        '
        Me.cmbStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(130, 199)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(139, 20)
        Me.cmbStatus.TabIndex = 16
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(592, 659)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 27)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "閉じる"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(497, 659)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(91, 27)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "更新"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label14, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbCode2, 1, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(28, 41)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(649, 67)
        Me.TableLayoutPanel4.TabIndex = 17
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(21, 10)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 12)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "工番月"
        '
        'cmbCode2
        '
        Me.cmbCode2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbCode2.FormattingEnabled = True
        Me.cmbCode2.Location = New System.Drawing.Point(66, 6)
        Me.cmbCode2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbCode2.Name = "cmbCode2"
        Me.cmbCode2.Size = New System.Drawing.Size(122, 20)
        Me.cmbCode2.TabIndex = 2
        '
        'btnEditCode3
        '
        Me.btnEditCode3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnEditCode3.Location = New System.Drawing.Point(268, 3)
        Me.btnEditCode3.Name = "btnEditCode3"
        Me.btnEditCode3.Size = New System.Drawing.Size(75, 22)
        Me.btnEditCode3.TabIndex = 3
        Me.btnEditCode3.Text = "連番編集"
        Me.btnEditCode3.UseVisualStyleBackColor = True
        '
        'AnkenMasterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 693)
        Me.Controls.Add(Me.TableLayoutPanel4)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.dgvAnken)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "AnkenMasterForm"
        Me.Text = "案件登録"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvAnken, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mitmAdd As ToolStripMenuItem
    Friend WithEvents mitmEdit As ToolStripMenuItem
    Friend WithEvents mitmDelete As ToolStripMenuItem
    Friend WithEvents dgvAnken As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents txtCode3 As TextBox
    Friend WithEvents txtCode2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSalesAmount As TextBox
    Friend WithEvents dtpSalesYearMonth As DateTimePicker
    Friend WithEvents cmbStaff As ComboBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbClient As ComboBox
    Friend WithEvents cmbCode1 As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents cId As DataGridViewTextBoxColumn
    Friend WithEvents cCode1 As DataGridViewTextBoxColumn
    Friend WithEvents cCode2 As DataGridViewTextBoxColumn
    Friend WithEvents cCode3 As DataGridViewTextBoxColumn
    Friend WithEvents cCode As DataGridViewTextBoxColumn
    Friend WithEvents cName As DataGridViewTextBoxColumn
    Friend WithEvents cSalesYearMonth As DataGridViewTextBoxColumn
    Friend WithEvents cSalesAmount As DataGridViewTextBoxColumn
    Friend WithEvents cClientID As DataGridViewTextBoxColumn
    Friend WithEvents cClient As DataGridViewTextBoxColumn
    Friend WithEvents cStatus As DataGridViewTextBoxColumn
    Friend WithEvents cInsertDate As DataGridViewTextBoxColumn
    Friend WithEvents cStaffID As DataGridViewTextBoxColumn
    Friend WithEvents cStaffName As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbCode2 As ComboBox
    Friend WithEvents btnEditCode3 As Button
End Class
