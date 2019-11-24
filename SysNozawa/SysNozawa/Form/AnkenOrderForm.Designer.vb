<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnkenOrderForm
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
        Me.dgvAnkenOrder = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvAnkenOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mitmAdd, Me.mitmEdit, Me.mitmDelete})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1105, 33)
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
        'dgvAnkenOrder
        '
        Me.dgvAnkenOrder.AllowUserToAddRows = False
        Me.dgvAnkenOrder.AllowUserToDeleteRows = False
        Me.dgvAnkenOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAnkenOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAnkenOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAnkenOrder.Location = New System.Drawing.Point(23, 48)
        Me.dgvAnkenOrder.Name = "dgvAnkenOrder"
        Me.dgvAnkenOrder.ReadOnly = True
        Me.dgvAnkenOrder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvAnkenOrder.RowTemplate.Height = 27
        Me.dgvAnkenOrder.Size = New System.Drawing.Size(1051, 749)
        Me.dgvAnkenOrder.TabIndex = 12
        '
        'AnkenOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1105, 828)
        Me.Controls.Add(Me.dgvAnkenOrder)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "AnkenOrderForm"
        Me.Text = "受注管理"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvAnkenOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mitmAdd As ToolStripMenuItem
    Friend WithEvents mitmEdit As ToolStripMenuItem
    Friend WithEvents mitmDelete As ToolStripMenuItem
    Friend WithEvents dgvAnkenOrder As DataGridView
End Class
