Imports MySql.Data.MySqlClient

Public Class Staff

    Public id As Integer            '社員番号
    Public name As String           '名前

    ''' <summary>
    ''' インスタンス
    ''' </summary>
    Public Sub New()
    End Sub

    ''' <summary>
    ''' インスタンス
    ''' </summary>
    ''' <param name="sqlResult">SQL結果</param>
    Public Sub New(sqlResult As MySqlDataReader)

        id = CInt(sqlResult("id"))
        name = sqlResult("name").ToString

    End Sub

End Class