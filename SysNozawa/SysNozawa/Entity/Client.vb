Imports MySql.Data.MySqlClient

Public Class Client

    Public id As Integer            '得意先番号
    Public code As String           '得意先コード
    Public name As String           '得意先名

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
        code = sqlResult("code")
        name = sqlResult("name")
    End Sub

End Class
