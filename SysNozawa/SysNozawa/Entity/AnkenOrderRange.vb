Imports MySql.Data.MySqlClient

Public Class AnkenOrderRange

    Public id As Integer            '番号
    Public ankenid As Integer       '案件番号
    Public name As String           '件名

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
        ankenid = sqlResult("ankenid")
        name = sqlResult("name")

    End Sub

End Class
