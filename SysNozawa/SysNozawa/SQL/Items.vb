Imports MySql.Data.MySqlClient

Public Module Items

#Region "取得"

    ''' <summary>
    ''' 新規追加用の新しいIDを生成
    ''' </summary>
    ''' <returns></returns>
    Public Function getNewId() As Integer

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        Dim maxId As Integer = 0

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 
        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "select max(id) as maxid"
            sqlStr = sqlStr + " from item"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()

                If IsNothing(rlt("maxid")) Or rlt("maxid").ToString.Length = 0 Then
                Else
                    maxId = rlt("maxid")
                End If


            End While

            'クローズ 
            con.Close()

        End Using

        Return maxId + 1

    End Function

    ''' <summary>
    ''' 全ての品名を取得
    ''' </summary>
    ''' <returns></returns>
    Public Function getAllName() As List(Of String)

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '社員リスト初期化
        Dim list As New List(Of String)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "select distinct name"
            sqlStr = sqlStr + " from item"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()
                list.Add(rlt("name"))
            End While

            'クローズ 
            con.Close()

        End Using

        Return list

    End Function

    ''' <summary>
    ''' 全てのメーカー名を取得
    ''' </summary>
    ''' <returns></returns>
    Public Function getAllMaker() As List(Of String)

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '社員リスト初期化
        Dim list As New List(Of String)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "select distinct maker"
            sqlStr = sqlStr + " from item"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()
                list.Add(rlt("maker"))
            End While

            'クローズ 
            con.Close()

        End Using

        Return list

    End Function


    ''' <summary>
    ''' 全ての単位を取得
    ''' </summary>
    ''' <returns></returns>
    Public Function getAllUnit() As List(Of String)

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '社員リスト初期化
        Dim list As New List(Of String)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "select distinct unit"
            sqlStr = sqlStr + " from item"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()
                list.Add(rlt("unit"))
            End While

            'クローズ 
            con.Close()

        End Using

        Return list

    End Function

    '' <summary>
    '' 全商品をDataTableで出力
    '' </summary>
    '' <returns></returns>
    Public Function selectAll() As DataTable

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '社員リスト初期化
        Dim list As New List(Of Item)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "select *"
            sqlStr = sqlStr + " from item"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()

                list.Add(New Item(rlt))


            End While

            'クローズ 
            con.Close()

        End Using

        Return ToDataTable(list)

    End Function

#End Region


    ''' <summary>
    ''' List(Of Anken)をDataTableに変換
    ''' </summary>
    ''' <param name="list"></param>
    ''' <returns></returns>
    Private Function ToDataTable(list As List(Of Item)) As DataTable

        Dim dt As DataTable = New DataTable("ankenList")
        dt.Columns.Add("cId")
        dt.Columns.Add("cCode1")
        dt.Columns.Add("cCode2")
        dt.Columns.Add("cCode")
        dt.Columns.Add("cName")
        dt.Columns.Add("cKata")
        dt.Columns.Add("cMaker")
        dt.Columns.Add("cUnit")
        dt.Columns.Add("cQuantity")

        '結果を表示 
        For Each item In list

            Dim dr As DataRow = dt.NewRow

            dr("cId") = item.id        '商品番号
            dr("cCode1") = item.code1  '商品コード1
            dr("cCode2") = item.code2  '商品コード2
            dr("cCode") = item.code1 + "-" + item.code2  '商品コード
            dr("cName") = item.name  '品名
            dr("cKata") = item.kata    '型式
            dr("cMaker") = item.maker    'メーカー
            dr("cUnit") = item.unit   '単位
            dr("cQuantity") = item.quantity    '入数

            dt.Rows.Add(dr)

        Next

        Return dt

    End Function

End Module
