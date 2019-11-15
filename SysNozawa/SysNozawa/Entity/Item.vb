Imports MySql.Data.MySqlClient

Public Class Item

    Public id As Integer            '商品番号
    Public code1 As String          '商品コード1
    Public code2 As String          '商品コード2
    Public code3 As String          '商品コード3
    Public name As String           '品名
    Public kata As String             '型式
    Public maker As String         'メーカー
    Public unit As String          '単位
    Public quantity As Integer       '入数


    Public Sub New()
    End Sub

    Public Sub New(sqlResult As MySqlDataReader)

        id = sqlResult("id")
        code1 = sqlResult("code1")
        code2 = sqlResult("code2")
        code3 = sqlResult("code3")
        name = sqlResult("name")
        kata = sqlResult("kata")
        maker = sqlResult("maker")
        unit = sqlResult("unit")
        quantity = sqlResult("quantity")

    End Sub

End Class
