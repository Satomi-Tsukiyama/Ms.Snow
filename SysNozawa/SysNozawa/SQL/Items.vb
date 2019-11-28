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
        Dim sqlStr As String = ""

        Dim maxId As Integer = 0

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 
        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + " SELECT"
            sqlStr = sqlStr + "     MAX(id) AS maxid"
            sqlStr = sqlStr + " FROM item"

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
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of String)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + "SELECT"
            sqlStr = sqlStr + "     DISTINCT name"
            sqlStr = sqlStr + " FROM item"

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
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of String)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + "SELECT"
            sqlStr = sqlStr + "     DISTINCT maker"
            sqlStr = sqlStr + " FROM item"

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
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of String)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + " SELECT"
            sqlStr = sqlStr + "     DISTINCT unit"
            sqlStr = sqlStr + " FROM item"

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

    ''' <summary>
    ''' 同じ商品コードの商品が存在するか
    ''' </summary>
    ''' <param name="code1"></param>
    ''' <param name="code2"></param>
    ''' <param name="code3"></param>
    ''' <returns></returns>
    Public Function isExistSameCode(code1 As String, code2 As String, code3 As String) As Boolean

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of Anken)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + " SELECT"
            sqlStr = sqlStr + "     *"
            sqlStr = sqlStr + " FROM item"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND item.code1 = '" + code1 + "'"
            sqlStr = sqlStr + "     AND item.code2 = '" + code2 + "'"
            sqlStr = sqlStr + "     AND item.code3 = '" + code3 + "'"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()

                list.Add(New Anken(rlt))

            End While

            'クローズ 
            con.Close()

        End Using


        Return list.Count > 0

    End Function

    '' <summary>
    '' 全商品をDataTableで出力
    '' </summary>
    '' <returns></returns>
    Public Function selectAll() As DataTable

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of Item)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + " SELECT"
            sqlStr = sqlStr + "     *"
            sqlStr = sqlStr + " FROM item"

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

    ''' <summary>
    ''' 指定したIDの商品情報を取得
    ''' </summary>
    ''' <param name="id">社員番号</param>
    ''' <returns></returns>
    Public Function selectOne(id As Integer) As Item

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of Item)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + " SELECT *"
            sqlStr = sqlStr + "     FROM item"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND item.id = " + id.ToString

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            If rlt.Read Then
                list.Add(New Item(rlt))
            End If

            'クローズ 
            con.Close()

        End Using

        If list.Count > 0 Then
            Return list(0)
        Else
            Return Nothing
        End If

    End Function

#End Region

#Region "更新"

    ''' <summary>
    ''' 商品情報の更新
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    Public Function update(info As Item) As Boolean

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        Try

            'コネクション生成 
            Using con As New MySqlConnection(connectionString)

                '接続 
                con.Open()

                'SQL文
                With info
                    sqlStr = sqlStr + " UPDATE"
                    sqlStr = sqlStr + "     item"
                    sqlStr = sqlStr + " SET"
                    sqlStr = sqlStr + "     code1 = '" + .code1 + "',"
                    sqlStr = sqlStr + "     code2 = '" + .code2 + "',"
                    sqlStr = sqlStr + "     code3 = '" + .code3 + "',"
                    sqlStr = sqlStr + "     name = '" + .name + "',"
                    sqlStr = sqlStr + "     kata = '" + .kata + "',"
                    sqlStr = sqlStr + "     maker = '" + .maker + "',"
                    sqlStr = sqlStr + "     unit = '" + .unit + "',"
                    If IsNothing(.quantity) Then
                        sqlStr = sqlStr + "     quantity = NULL,"
                    Else
                        sqlStr = sqlStr + "     quantity = '" + .quantity.ToString + "',"
                    End If
                    sqlStr = sqlStr + "     quantityunit = '" + .quantityunit + "',"
                    sqlStr = sqlStr + "     updatedatetime = now()"
                    sqlStr = sqlStr + " WHERE 0 = 0"
                    sqlStr = sqlStr + "     AND id = " + .id.ToString
                End With

                'MySQLCommand作成 
                cmd = New MySqlCommand(sqlStr, con)

                'SQL文実行 
                rlt = cmd.ExecuteReader

                'クローズ 
                con.Close()

            End Using

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "追加"

    ''' <summary>
    ''' 商品情報の追加
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    Public Function insert(info As Item) As Boolean

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        Try

            'コネクション生成 
            Using con As New MySqlConnection(connectionString)

                '接続 
                con.Open()

                'SQL文
                With info
                    sqlStr = sqlStr + "INSERT INTO"
                    sqlStr = sqlStr + "     item ("
                    sqlStr = sqlStr + "         id,"
                    sqlStr = sqlStr + "         code1,"
                    sqlStr = sqlStr + "         code2,"
                    sqlStr = sqlStr + "         code3,"
                    sqlStr = sqlStr + "         name,"
                    sqlStr = sqlStr + "         kata,"
                    sqlStr = sqlStr + "         maker,"
                    sqlStr = sqlStr + "         unit,"
                    sqlStr = sqlStr + "         quantity,"
                    sqlStr = sqlStr + "         quantityunit,"
                    sqlStr = sqlStr + "         insertdatetime"
                    sqlStr = sqlStr + " ) VALUES ("
                    sqlStr = sqlStr + String.Format(" {0},", .id.ToString)
                    sqlStr = sqlStr + String.Format(" '{0},'", .code1)
                    sqlStr = sqlStr + String.Format(" '{0},'", .code2)
                    sqlStr = sqlStr + String.Format(" '{0},'", .code3)
                    sqlStr = sqlStr + String.Format(" '{0},'", .name)
                    sqlStr = sqlStr + String.Format(" '{0},'", .kata)
                    sqlStr = sqlStr + String.Format(" '{0},'", .maker)
                    sqlStr = sqlStr + String.Format(" '{0},'", .unit)
                    If IsNothing(.quantity) Then
                        sqlStr = sqlStr + " NULL,"
                    Else
                        sqlStr = sqlStr + String.Format(" {0},", .quantity.ToString)
                    End If
                    sqlStr = sqlStr + String.Format(" '{0},'", .quantityunit)

                    sqlStr = sqlStr + " now()"
                    sqlStr = sqlStr + ")"
                End With

                'MySQLCommand作成 
                cmd = New MySqlCommand(sqlStr, con)

                'SQL文実行 
                rlt = cmd.ExecuteReader

                'クローズ 
                con.Close()

            End Using

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


#End Region

    ''' <summary>
    ''' List(Of Item)をDataTableに変換
    ''' </summary>
    ''' <param name="list"></param>
    ''' <returns></returns>
    Private Function ToDataTable(list As List(Of Item)) As DataTable

        Dim dt As DataTable = New DataTable("ankenList")
        With dt.Columns
            .Add("cId")
            .Add("cCode1")
            .Add("cCode2")
            .Add("cCode3")
            .Add("cCode")
            .Add("cName")
            .Add("cKata")
            .Add("cMaker")
            .Add("cUnit")
            .Add("cQuantity")
        End With

        '結果を表示 
        For Each item In list

            Dim dr As DataRow = dt.NewRow
            With item
                dr("cId") = .id        '商品番号
                dr("cCode1") = .code1  '商品コード1
                dr("cCode2") = .code2  '商品コード2
                dr("cCode3") = .code3  '商品コード3
                dr("cCode") = .code1 + "-" + .code2 + "-" + .code3  '商品コード
                dr("cName") = .name  '品名
                dr("cKata") = .kata    '型式
                dr("cMaker") = .maker    'メーカー
                dr("cUnit") = .unit   '単位
                dr("cQuantity") = .quantity.ToString + .quantityunit    '入数+入数単位
            End With

            dt.Rows.Add(dr)

        Next

        Return dt

    End Function

End Module
