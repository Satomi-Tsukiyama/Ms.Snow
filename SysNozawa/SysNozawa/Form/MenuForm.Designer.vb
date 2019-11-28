<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuForm
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
        Me.btnBuying = New System.Windows.Forms.Button()
        Me.btnStaffMaster = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnClientMaster = New System.Windows.Forms.Button()
        Me.btnItemMaster = New System.Windows.Forms.Button()
        Me.btnShopMaster = New System.Windows.Forms.Button()
        Me.btnCalendarMaster = New System.Windows.Forms.Button()
        Me.btnAnkenMaster = New System.Windows.Forms.Button()
        Me.btnSalesPlan = New System.Windows.Forms.Button()
        Me.btnAnkenOrder = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBuying
        '
        Me.btnBuying.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBuying.Location = New System.Drawing.Point(98, 152)
        Me.btnBuying.Name = "btnBuying"
        Me.btnBuying.Size = New System.Drawing.Size(408, 45)
        Me.btnBuying.TabIndex = 0
        Me.btnBuying.Text = "仕入登録"
        Me.btnBuying.UseVisualStyleBackColor = True
        '
        'btnStaffMaster
        '
        Me.btnStaffMaster.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnStaffMaster.Location = New System.Drawing.Point(44, 3)
        Me.btnStaffMaster.Name = "btnStaffMaster"
        Me.btnStaffMaster.Size = New System.Drawing.Size(408, 42)
        Me.btnStaffMaster.TabIndex = 1
        Me.btnStaffMaster.Text = "従業員マスタ"
        Me.btnStaffMaster.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClose.Location = New System.Drawing.Point(855, 663)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(243, 46)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "閉じる"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox2.Location = New System.Drawing.Point(28, 390)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1068, 255)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "マスタ"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnClientMaster, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnStaffMaster, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnItemMaster, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnShopMaster, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCalendarMaster, 0, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(37, 38)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(995, 192)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'btnClientMaster
        '
        Me.btnClientMaster.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClientMaster.Location = New System.Drawing.Point(44, 51)
        Me.btnClientMaster.Name = "btnClientMaster"
        Me.btnClientMaster.Size = New System.Drawing.Size(408, 42)
        Me.btnClientMaster.TabIndex = 2
        Me.btnClientMaster.Text = "得意先マスタ"
        Me.btnClientMaster.UseVisualStyleBackColor = True
        '
        'btnItemMaster
        '
        Me.btnItemMaster.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnItemMaster.Location = New System.Drawing.Point(542, 51)
        Me.btnItemMaster.Name = "btnItemMaster"
        Me.btnItemMaster.Size = New System.Drawing.Size(408, 42)
        Me.btnItemMaster.TabIndex = 9
        Me.btnItemMaster.Text = "商品マスタ"
        Me.btnItemMaster.UseVisualStyleBackColor = True
        '
        'btnShopMaster
        '
        Me.btnShopMaster.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnShopMaster.Location = New System.Drawing.Point(542, 3)
        Me.btnShopMaster.Name = "btnShopMaster"
        Me.btnShopMaster.Size = New System.Drawing.Size(408, 42)
        Me.btnShopMaster.TabIndex = 8
        Me.btnShopMaster.Text = "購入先マスタ"
        Me.btnShopMaster.UseVisualStyleBackColor = True
        '
        'btnCalendarMaster
        '
        Me.btnCalendarMaster.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCalendarMaster.Location = New System.Drawing.Point(44, 99)
        Me.btnCalendarMaster.Name = "btnCalendarMaster"
        Me.btnCalendarMaster.Size = New System.Drawing.Size(408, 42)
        Me.btnCalendarMaster.TabIndex = 7
        Me.btnCalendarMaster.Text = "カレンダーマスタ"
        Me.btnCalendarMaster.UseVisualStyleBackColor = True
        '
        'btnAnkenMaster
        '
        Me.btnAnkenMaster.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAnkenMaster.Location = New System.Drawing.Point(98, 86)
        Me.btnAnkenMaster.Name = "btnAnkenMaster"
        Me.btnAnkenMaster.Size = New System.Drawing.Size(408, 45)
        Me.btnAnkenMaster.TabIndex = 5
        Me.btnAnkenMaster.Text = "案件登録"
        Me.btnAnkenMaster.UseVisualStyleBackColor = True
        '
        'btnSalesPlan
        '
        Me.btnSalesPlan.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSalesPlan.Location = New System.Drawing.Point(607, 86)
        Me.btnSalesPlan.Name = "btnSalesPlan"
        Me.btnSalesPlan.Size = New System.Drawing.Size(408, 45)
        Me.btnSalesPlan.TabIndex = 6
        Me.btnSalesPlan.Text = "売上見込"
        Me.btnSalesPlan.UseVisualStyleBackColor = True
        '
        'btnAnkenOrder
        '
        Me.btnAnkenOrder.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAnkenOrder.Location = New System.Drawing.Point(607, 152)
        Me.btnAnkenOrder.Name = "btnAnkenOrder"
        Me.btnAnkenOrder.Size = New System.Drawing.Size(408, 45)
        Me.btnAnkenOrder.TabIndex = 7
        Me.btnAnkenOrder.Text = "受注管理"
        Me.btnAnkenOrder.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.Location = New System.Drawing.Point(98, 221)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(408, 45)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "単価表"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1112, 722)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnAnkenOrder)
        Me.Controls.Add(Me.btnBuying)
        Me.Controls.Add(Me.btnSalesPlan)
        Me.Controls.Add(Me.btnAnkenMaster)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "MenuForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メニュー"
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBuying As Button
    Friend WithEvents btnStaffMaster As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnClientMaster As Button
    Friend WithEvents btnCalendarMaster As Button
    Friend WithEvents btnAnkenMaster As Button
    Friend WithEvents btnShopMaster As Button
    Friend WithEvents btnSalesPlan As Button
    Friend WithEvents btnItemMaster As Button
    Friend WithEvents btnAnkenOrder As Button
    Friend WithEvents Button1 As Button
End Class
