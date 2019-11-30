Imports MySql.Data.MySqlClient

Public Class Adjustment

    Public id As Integer            '番号
    Public ankenId As Integer       '案件番号
    Public staffId As Integer       '担当従業員番号
    Public fieldduration As String  '現地作業期間
    Public officeduration As String '社内作業期間
    Public lacation As String       '現地箇所
    Public note As String           '備考

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
        ankenId = sqlResult("ankenId")
        staffId = sqlResult("staffId")
        fieldduration = sqlResult("fieldduration").ToString
        officeduration = sqlResult("officeduration").ToString
        lacation = sqlResult("lacation").ToString
        note = sqlResult("note").ToString

    End Sub

End Class
