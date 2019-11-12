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
        Me.btnShopMaster = New System.Windows.Forms.Button()
        Me.btnClientMaster = New System.Windows.Forms.Button()
        Me.btnCalendarMaster = New System.Windows.Forms.Button()
        Me.btnAnkenMaster = New System.Windows.Forms.Button()
        Me.btnSalesPlan = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBuying
        '
        Me.btnBuying.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBuying.Location = New System.Drawing.Point(99, 151)
        Me.btnBuying.Name = "btnBuying"
        Me.btnBuying.Size = New System.Drawing.Size(408, 45)
        Me.btnBuying.TabIndex = 0
        Me.btnBuying.Text = "仕入登録"
        Me.btnBuying.UseVisualStyleBackColor = True
        '
        'btnStaffMaster
        '
        Me.btnStaffMaster.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnStaffMaster.Location = New System.Drawing.Point(542, 13)
        Me.btnStaffMaster.Name = "btnStaffMaster"
        Me.btnStaffMaster.Size = New System.Drawing.Size(408, 45)
        Me.btnStaffMaster.TabIndex = 1
        Me.btnStaffMaster.Text = "従業員マスタ"
        Me.btnStaffMaster.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClose.Location = New System.Drawing.Point(855, 663)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(244, 47)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "閉じる"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 390)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1069, 206)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "マスタ"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnShopMaster, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnStaffMaster, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnClientMaster, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCalendarMaster, 1, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(36, 38)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(995, 145)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'btnShopMaster
        '
        Me.btnShopMaster.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnShopMaster.Location = New System.Drawing.Point(44, 86)
        Me.btnShopMaster.Name = "btnShopMaster"
        Me.btnShopMaster.Size = New System.Drawing.Size(408, 45)
        Me.btnShopMaster.TabIndex = 8
        Me.btnShopMaster.Text = "購入先マスタ"
        Me.btnShopMaster.UseVisualStyleBackColor = True
        '
        'btnClientMaster
        '
        Me.btnClientMaster.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClientMaster.Location = New System.Drawing.Point(44, 13)
        Me.btnClientMaster.Name = "btnClientMaster"
        Me.btnClientMaster.Size = New System.Drawing.Size(408, 45)
        Me.btnClientMaster.TabIndex = 2
        Me.btnClientMaster.Text = "得意先マスタ"
        Me.btnClientMaster.UseVisualStyleBackColor = True
        '
        'btnCalendarMaster
        '
        Me.btnCalendarMaster.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCalendarMaster.Location = New System.Drawing.Point(542, 86)
        Me.btnCalendarMaster.Name = "btnCalendarMaster"
        Me.btnCalendarMaster.Size = New System.Drawing.Size(408, 45)
        Me.btnCalendarMaster.TabIndex = 7
        Me.btnCalendarMaster.Text = "カレンダーマスタ"
        Me.btnCalendarMaster.UseVisualStyleBackColor = True
        '
        'btnAnkenMaster
        '
        Me.btnAnkenMaster.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAnkenMaster.Location = New System.Drawing.Point(99, 86)
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
        'MenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1111, 722)
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
End Class
