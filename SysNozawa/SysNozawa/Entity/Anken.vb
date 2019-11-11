Imports MySql.Data.MySqlClient

Public Class Anken

    Public id As Integer            '案件番号
    Public code1 As String          '工番1
    Public code2 As String          '工番2
    Public code3 As String          '工番3
    Public name As String           '件名
    Public salesYearMonth As Date   '売上年月
    Public salesAmount As Decimal   '売上金額
    Public clientId As Integer      '客先ID
    Public clientCode As String     '客先コード
    Public clientName As String     '客先名
    Public status As Integer        '請求状況
    Public insertDate As Date       '作成日
    Public staffId As Integer       '従業員ID
    Public staffName As String      '従業員名


    Public Sub New()
    End Sub

    Public Sub New(sqlResult As MySqlDataReader)

        id = sqlResult("id")
        code1 = sqlResult("code1")
        code2 = sqlResult("code2")
        code3 = sqlResult("code3")
        name = sqlResult("name")
        salesYearMonth = sqlResult("salesyearmonth")
        salesAmount = sqlResult("salesamount")
        clientId = sqlResult("clientid")
        clientCode = sqlResult("clientcode")
        clientName = sqlResult("clientname")
        status = sqlResult("status")
        insertDate = sqlResult("insertdatetime")
        staffId = sqlResult("staffid")
        staffName = sqlResult("staffname")

    End Sub

End Class
