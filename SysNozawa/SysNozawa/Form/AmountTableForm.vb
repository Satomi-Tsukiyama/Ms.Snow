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

        dgvItemAmount.DataSource = Items.selectAll()



    End Sub
End Class