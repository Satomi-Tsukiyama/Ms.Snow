﻿Imports MySql.Data.MySqlClient

Public Class Shop

    Public id As Integer            '購入先番号
    Public code As String           '購入先コード
    Public name As String           '購入先名

    Public Sub New()
    End Sub

    Public Sub New(sqlResult As MySqlDataReader)

        id = sqlResult("id")
        code = sqlResult("code")
        name = sqlResult("name")
    End Sub

End Class
