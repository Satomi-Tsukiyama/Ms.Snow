<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AmountTableForm
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
        Me.dgvItemAmount = New System.Windows.Forms.DataGridView()
        Me.cId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCode1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCode2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCode3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cKata = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMaker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvItemAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvItemAmount
        '
        Me.dgvItemAmount.AllowUserToAddRows = False
        Me.dgvItemAmount.AllowUserToDeleteRows = False
        Me.dgvItemAmount.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItemAmount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvItemAmount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemAmount.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cId, Me.cCode1, Me.cCode2, Me.cCode3, Me.cCode, Me.cName, Me.cKata, Me.cMaker, Me.cUnit, Me.cQuantity})
        Me.dgvItemAmount.Location = New System.Drawing.Point(14, 22)
        Me.dgvItemAmount.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvItemAmount.Name = "dgvItemAmount"
        Me.dgvItemAmount.ReadOnly = True
        Me.dgvItemAmount.RowTemplate.Height = 21
        Me.dgvItemAmount.Size = New System.Drawing.Size(1132, 557)
        Me.dgvItemAmount.TabIndex = 13
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
        'cCode3
        '
        Me.cCode3.DataPropertyName = "cCode3"
        Me.cCode3.HeaderText = "商品コード3"
        Me.cCode3.Name = "cCode3"
        Me.cCode3.ReadOnly = True
        Me.cCode3.Visible = False
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
        'AmountTableForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1172, 608)
        Me.Controls.Add(Me.dgvItemAmount)
        Me.Name = "AmountTableForm"
        Me.Text = "単価表"
        CType(Me.dgvItemAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvItemAmount As DataGridView
    Friend WithEvents cId As DataGridViewTextBoxColumn
    Friend WithEvents cCode1 As DataGridViewTextBoxColumn
    Friend WithEvents cCode2 As DataGridViewTextBoxColumn
    Friend WithEvents cCode3 As DataGridViewTextBoxColumn
    Friend WithEvents cCode As DataGridViewTextBoxColumn
    Friend WithEvents cName As DataGridViewTextBoxColumn
    Friend WithEvents cKata As DataGridViewTextBoxColumn
    Friend WithEvents cMaker As DataGridViewTextBoxColumn
    Friend WithEvents cUnit As DataGridViewTextBoxColumn
    Friend WithEvents cQuantity As DataGridViewTextBoxColumn
End Class
