Imports MySql.Data.MySqlClient

Public Class Item

    Public id As Integer            '商品番号
    Public code1 As String          '商品コード1
    Public code2 As String          '商品コード2
    Public code3 As String          '商品コード3
    Public name As String           '品名
    Public kata As String           '型式
    Public maker As String          'メーカー
    Public unit As String           '単位
    Public quantity As Nullable(Of Integer)      '入数

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
        code1 = sqlResult("code1").ToString
        code2 = sqlResult("code2").ToString
        code3 = sqlResult("code3").ToString
        name = sqlResult("name")
        kata = sqlResult("kata")
        maker = sqlResult("maker")
        unit = sqlResult("unit")
        quantity = sqlResult("quantity")

    End Sub

End Class
