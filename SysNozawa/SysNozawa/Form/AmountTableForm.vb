Public Class AmountTableForm

    Private inputType As New inputType
    Private selectId As Integer = 0

    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AmountTableForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        inputType = inputType.non
        selectId = 0

        '商品リスト表示
        setDgvItemAmount()

    End Sub

    ''' <summary>
    ''' 単価表の表示
    ''' </summary>
    Private Sub setDgvItemAmount()

        Dim dt As DataTable = Items.selectAll()

        Dim allShop As List(Of Shop) = Shops.selectAllForList()
        For Each oneShop In allShop

            dt.Columns.Add(oneShop.code)

        Next

        dgvItemAmount.DataSource = dt

    End Sub
End Class