Imports MySql.Data.MySqlClient

Public Class ItemAmount

    Public id As Integer '番号
    Public itemId As Integer '商品番号
    Public shopId As Integer '購入先番号
    Public amount As Decimal '金額
    Public note As String '備考

    ''' <summary>
    ''' インスタンス
    ''' </summary>
    Public Sub New()
    End Sub

    ''' <summary>
    ''' インスタンス
    ''' </summary>
    ''' <param name="sqlResult"></param>
    Public Sub New(sqlResult As MySqlDataReader)

        id = sqlResult("id")
        itemId = sqlResult("itemId")
        shopId = sqlResult("shopId")
        amount = sqlResult("amount")
        note = sqlResult("note").ToString

    End Sub

End Class
