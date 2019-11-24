Imports MySql.Data.MySqlClient

Public Class Calendar

    Public id As Integer            '番号
    Public day As Date              '日付
    Public holidayflg As Integer    '休日フラグ

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
        day = sqlResult("day")
        holidayflg = sqlResult("holidayflg")

    End Sub

End Class
