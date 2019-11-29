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
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.売上年月 = New System.Windows.Forms.Label()
        Me.cmbSalesYearMonth = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvAnkenOrder, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MenuStrip1.Size = New System.Drawing.Size(818, 24)
        Me.MenuStrip1.TabIndex = 11
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
        'dgvAnkenOrder
        '
        Me.dgvAnkenOrder.AllowUserToAddRows = False
        Me.dgvAnkenOrder.AllowUserToDeleteRows = False
        Me.dgvAnkenOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAnkenOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAnkenOrder.Location = New System.Drawing.Point(14, 116)
        Me.dgvAnkenOrder.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dgvAnkenOrder.Name = "dgvAnkenOrder"
        Me.dgvAnkenOrder.ReadOnly = True
        Me.dgvAnkenOrder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvAnkenOrder.RowTemplate.Height = 27
        Me.dgvAnkenOrder.Size = New System.Drawing.Size(786, 415)
        Me.dgvAnkenOrder.TabIndex = 12
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.売上年月, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbSalesYearMonth, 1, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(14, 35)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(786, 67)
        Me.TableLayoutPanel4.TabIndex = 18
        '
        '売上年月
        '
        Me.売上年月.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.売上年月.AutoSize = True
        Me.売上年月.Location = New System.Drawing.Point(35, 10)
        Me.売上年月.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.売上年月.Name = "売上年月"
        Me.売上年月.Size = New System.Drawing.Size(41, 12)
        Me.売上年月.TabIndex = 1
        Me.売上年月.Text = "工番月"
        '
        'cmbSalesYearMonth
        '
        Me.cmbSalesYearMonth.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSalesYearMonth.FormattingEnabled = True
        Me.cmbSalesYearMonth.Location = New System.Drawing.Point(80, 6)
        Me.cmbSalesYearMonth.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbSalesYearMonth.Name = "cmbSalesYearMonth"
        Me.cmbSalesYearMonth.Size = New System.Drawing.Size(122, 20)
        Me.cmbSalesYearMonth.TabIndex = 2
        '
        'AnkenOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 552)
        Me.Controls.Add(Me.TableLayoutPanel4)
        Me.Controls.Add(Me.dgvAnkenOrder)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "AnkenOrderForm"
        Me.Text = "受注管理"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvAnkenOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mitmAdd As ToolStripMenuItem
    Friend WithEvents mitmEdit As ToolStripMenuItem
    Friend WithEvents mitmDelete As ToolStripMenuItem
    Friend WithEvents dgvAnkenOrder As DataGridView
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents 売上年月 As Label
    Friend WithEvents cmbSalesYearMonth As ComboBox
End Class
