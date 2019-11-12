Imports System.ComponentModel

Public Class MenuForm

    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    ''' <summary>
    ''' 社員名簿ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnStaffMaster_Click(sender As Object, e As EventArgs) Handles btnStaffMaster.Click
        My.Forms.StaffMasterForm.ShowDialog()
    End Sub
    ''' <summary>
    ''' 日報入力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnBuying_Click(sender As Object, e As EventArgs) Handles btnBuying.Click
        My.Forms.BuyingForm.ShowDialog()
    End Sub

    ''' <summary>
    ''' 取引先マスタ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnClientMaster_Click(sender As Object, e As EventArgs) Handles btnClientMaster.Click
        My.Forms.ClientMasterForm.ShowDialog()
    End Sub

    ''' <summary>
    ''' カレンダーマスタ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCalendarMaster_Click(sender As Object, e As EventArgs) Handles btnCalendarMaster.Click
        My.Forms.CalendarMasterForm.ShowDialog()
    End Sub

    ''' <summary>
    ''' 購入先マスタ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnShopMaster_Click(sender As Object, e As EventArgs) Handles btnShopMaster.Click
        My.Forms.ShopMasterForm.ShowDialog()
    End Sub

    ''' <summary>
    ''' 案件登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAnkenMaster_Click(sender As Object, e As EventArgs) Handles btnAnkenMaster.Click
        My.Forms.AnkenMasterForm.ShowDialog()
    End Sub

    ''' <summary>
    ''' 売上見込
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSalesPlan_Click(sender As Object, e As EventArgs) Handles btnSalesPlan.Click
        My.Forms.SalesPlanForm.ShowDialog()
    End Sub


    ''' <summary>
    ''' 閉じるボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        'アプリケーションを終了
        Me.Close()

    End Sub

    ''' <summary>
    ''' 画面終了イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenuForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If DialogResult.No = MessageBox.Show("アプリを終了します。よろしいですか？",
                                              "アプリの終了",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question
                                              ) Then

            e.Cancel = True
            Exit Sub

        End If

    End Sub


End Class