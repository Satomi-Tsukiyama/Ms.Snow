Public Class AnkenOrderForm

    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AnkenOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        setDgvAnkenOrder()

    End Sub

    ''' <summary>
    ''' 案件受注リストの表示
    ''' </summary>
    Private Sub setDgvAnkenOrder()

        'Dim datatable As DataTable
        'DataTable = Nothing
        'DataTable.Rows(0).he
        'dgvAnkenOrder.DataSource = DataTable
        dgvAnkenOrder.DataSource = Nothing
        dgvAnkenOrder.DataSource = Ankens.selectAll()
        With dgvAnkenOrder

            .Rows(0).HeaderCell.Value = "案件名"
            .Rows(1).HeaderCell.Value = "取引先"
            .Rows(2).HeaderCell.Value = "売上年月"
            .Rows(3).HeaderCell.Value = "受注範囲"
            .Rows(5).HeaderCell.Value = "納期"
            .AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)

        End With

    End Sub

End Class