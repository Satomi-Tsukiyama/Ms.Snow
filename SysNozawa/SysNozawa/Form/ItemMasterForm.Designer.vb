<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemMasterForm
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mitmAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mitmEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mitmDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvItem = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtKata = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbUnit = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCode1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCode2 = New System.Windows.Forms.TextBox()
        Me.btnEditCode3 = New System.Windows.Forms.Button()
        Me.cmbMaker = New System.Windows.Forms.ComboBox()
        Me.cId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCode1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCode2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cKata = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMaker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mitmAdd, Me.mitmEdit, Me.mitmDelete})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(938, 33)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mitmAdd
        '
        Me.mitmAdd.Name = "mitmAdd"
        Me.mitmAdd.Size = New System.Drawing.Size(96, 29)
        Me.mitmAdd.Text = "新規追加"
        '
        'mitmEdit
        '
        Me.mitmEdit.Name = "mitmEdit"
        Me.mitmEdit.Size = New System.Drawing.Size(60, 29)
        Me.mitmEdit.Text = "編集"
        '
        'mitmDelete
        '
        Me.mitmDelete.Name = "mitmDelete"
        Me.mitmDelete.Size = New System.Drawing.Size(60, 29)
        Me.mitmDelete.Text = "削除"
        '
        'dgvItem
        '
        Me.dgvItem.AllowUserToAddRows = False
        Me.dgvItem.AllowUserToDeleteRows = False
        Me.dgvItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cId, Me.cCode1, Me.cCode2, Me.cCode, Me.cName, Me.cKata, Me.cMaker, Me.cUnit, Me.cQuantity})
        Me.dgvItem.Location = New System.Drawing.Point(20, 40)
        Me.dgvItem.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvItem.Name = "dgvItem"
        Me.dgvItem.ReadOnly = True
        Me.dgvItem.RowTemplate.Height = 21
        Me.dgvItem.Size = New System.Drawing.Size(898, 370)
        Me.dgvItem.TabIndex = 12
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmbMaker, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtKata, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtQuantity, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbUnit, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbName, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(20, 418)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(898, 257)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 180)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 18)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "単位"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 54)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "型番"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "商品名"
        '
        'cmbName
        '
        Me.cmbName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbName.FormattingEnabled = True
        Me.cmbName.Location = New System.Drawing.Point(94, 8)
        Me.cmbName.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbName.Name = "cmbName"
        Me.cmbName.Size = New System.Drawing.Size(304, 26)
        Me.cmbName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 129)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "商品コード"
        '
        'txtKata
        '
        Me.txtKata.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtKata.Location = New System.Drawing.Point(94, 50)
        Me.txtKata.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtKata.Name = "txtKata"
        Me.txtKata.Size = New System.Drawing.Size(304, 25)
        Me.txtKata.TabIndex = 4
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnEditCode3, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCode2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCode1, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(94, 130)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(522, 34)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'txtQuantity
        '
        Me.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtQuantity.Location = New System.Drawing.Point(94, 221)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(304, 25)
        Me.txtQuantity.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 224)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 18)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "入数"
        '
        'cmbUnit
        '
        Me.cmbUnit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbUnit.FormattingEnabled = True
        Me.cmbUnit.Location = New System.Drawing.Point(94, 176)
        Me.cmbUnit.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(94, 26)
        Me.cmbUnit.TabIndex = 20
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(767, 682)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(152, 40)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "閉じる"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(608, 682)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(152, 40)
        Me.btnOK.TabIndex = 17
        Me.btnOK.Text = "更新"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 96)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 18)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "メーカー"
        '
        'txtCode1
        '
        Me.txtCode1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCode1.Location = New System.Drawing.Point(5, 4)
        Me.txtCode1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCode1.Name = "txtCode1"
        Me.txtCode1.Size = New System.Drawing.Size(172, 25)
        Me.txtCode1.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(196, 8)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 18)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "ー"
        '
        'txtCode2
        '
        Me.txtCode2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCode2.Location = New System.Drawing.Point(239, 4)
        Me.txtCode2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCode2.Name = "txtCode2"
        Me.txtCode2.Size = New System.Drawing.Size(172, 25)
        Me.txtCode2.TabIndex = 21
        '
        'btnEditCode3
        '
        Me.btnEditCode3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditCode3.Location = New System.Drawing.Point(421, 4)
        Me.btnEditCode3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnEditCode3.Name = "btnEditCode3"
        Me.btnEditCode3.Size = New System.Drawing.Size(96, 26)
        Me.btnEditCode3.TabIndex = 19
        Me.btnEditCode3.Text = "連番編集"
        Me.btnEditCode3.UseVisualStyleBackColor = True
        '
        'cmbMaker
        '
        Me.cmbMaker.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbMaker.FormattingEnabled = True
        Me.cmbMaker.Location = New System.Drawing.Point(94, 92)
        Me.cmbMaker.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbMaker.Name = "cmbMaker"
        Me.cmbMaker.Size = New System.Drawing.Size(304, 26)
        Me.cmbMaker.TabIndex = 19
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
        Me.cCode1.HeaderText = "商品コード1"
        Me.cCode1.Name = "cCode1"
        Me.cCode1.ReadOnly = True
        Me.cCode1.Visible = False
        '
        'cCode2
        '
        Me.cCode2.DataPropertyName = "cCode2"
        Me.cCode2.HeaderText = "商品コード2"
        Me.cCode2.Name = "cCode2"
        Me.cCode2.ReadOnly = True
        Me.cCode2.Visible = False
        '
        'cCode
        '
        Me.cCode.DataPropertyName = "cCode"
        Me.cCode.HeaderText = "商品コード"
        Me.cCode.Name = "cCode"
        Me.cCode.ReadOnly = True
        '
        'cName
        '
        Me.cName.DataPropertyName = "cName"
        Me.cName.HeaderText = "品名"
        Me.cName.Name = "cName"
        Me.cName.ReadOnly = True
        '
        'cKata
        '
        Me.cKata.DataPropertyName = "cKata"
        Me.cKata.HeaderText = "型式"
        Me.cKata.Name = "cKata"
        Me.cKata.ReadOnly = True
        '
        'cMaker
        '
        Me.cMaker.DataPropertyName = "cMaker"
        Me.cMaker.HeaderText = "メーカー"
        Me.cMaker.Name = "cMaker"
        Me.cMaker.ReadOnly = True
        '
        'cUnit
        '
        Me.cUnit.DataPropertyName = "cUnit"
        Me.cUnit.HeaderText = "単位"
        Me.cUnit.Name = "cUnit"
        Me.cUnit.ReadOnly = True
        '
        'cQuantity
        '
        Me.cQuantity.DataPropertyName = "cQuantity"
        Me.cQuantity.HeaderText = "入数"
        Me.cQuantity.Name = "cQuantity"
        Me.cQuantity.ReadOnly = True
        '
        'ItemMasterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 738)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.dgvItem)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "ItemMasterForm"
        Me.Text = "商品マスタ"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mitmAdd As ToolStripMenuItem
    Friend WithEvents mitmEdit As ToolStripMenuItem
    Friend WithEvents mitmDelete As ToolStripMenuItem
    Friend WithEvents dgvItem As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbName As ComboBox
    Friend WithEvents txtKata As TextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents cmbUnit As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCode2 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCode1 As TextBox
    Friend WithEvents btnEditCode3 As Button
    Friend WithEvents cmbMaker As ComboBox
    Friend WithEvents cId As DataGridViewTextBoxColumn
    Friend WithEvents cCode1 As DataGridViewTextBoxColumn
    Friend WithEvents cCode2 As DataGridViewTextBoxColumn
    Friend WithEvents cCode As DataGridViewTextBoxColumn
    Friend WithEvents cName As DataGridViewTextBoxColumn
    Friend WithEvents cKata As DataGridViewTextBoxColumn
    Friend WithEvents cMaker As DataGridViewTextBoxColumn
    Friend WithEvents cUnit As DataGridViewTextBoxColumn
    Friend WithEvents cQuantity As DataGridViewTextBoxColumn
End Class
