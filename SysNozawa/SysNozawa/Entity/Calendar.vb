Imports MySql.Data.MySqlClient

Public Class Calendar

    Public id As Integer           '番号
    Public day As Date              '日付
    Public holidayflg As Integer    '休日フラグ

    Public Sub New()
    End Sub

    Public Sub New(sqlResult As MySqlDataReader)

        id = sqlResult("id")
        day = sqlResult("day")
        holidayflg = sqlResult("holidayflg")

    End Sub

End Class
