Imports MySql.Data.MySqlClient

Public Module Clients

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
            sqlStr = sqlStr + " FROM client"

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

    '' <summary>
    '' 全取引先をDataTableで出力
    '' </summary>
    '' <returns></returns>
    Public Function selectAll() As DataTable

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of Client)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + " SELECT"
            sqlStr = sqlStr + "     *"
            sqlStr = sqlStr + " FROM client"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()

                list.Add(New Client(rlt))

            End While

            'クローズ 
            con.Close()

        End Using

        Return ToDataTable(list)

    End Function

    ''' <summary>
    ''' 指定したIDの取引先情報を取得
    ''' </summary>
    ''' <param name="id">社員番号</param>
    ''' <returns></returns>
    Public Function selectOneWhereId(id As Integer) As Client

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of Client)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + " SELECT"
            sqlStr = sqlStr + "     *"
            sqlStr = sqlStr + " FROM client"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND id = " + id.ToString

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()
                list.Add(New Client(rlt))
            End While

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
    ''' 取引先情報の更新
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    Public Function update(info As Client) As Boolean

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
                    sqlStr = sqlStr + "       client"
                    sqlStr = sqlStr + " SET"
                    sqlStr = sqlStr + "     code = '" + .code + "',"
                    sqlStr = sqlStr + "     name = '" + .name + "',"
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
    ''' 取引先情報の追加
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    Public Function insert(info As Client) As Boolean

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
                    sqlStr = sqlStr + " INSERT INTO"
                    sqlStr = sqlStr + "     client ("
                    sqlStr = sqlStr + "         id,"
                    sqlStr = sqlStr + "         code,"
                    sqlStr = sqlStr + "         name,"
                    sqlStr = sqlStr + "         insertdatetime"
                    sqlStr = sqlStr + " ) VALUES ("
                    sqlStr = sqlStr + String.Format(" {0},", .id.ToString)
                    sqlStr = sqlStr + String.Format(" '{0}',", .code)
                    sqlStr = sqlStr + String.Format(" '{0}',", .name)
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

#Region "削除"

    ''' <summary>
    ''' 取引先情報の削除
    ''' </summary>
    ''' <param name="id">ID</param>
    ''' <returns></returns>
    Public Function delete(id As Integer) As Boolean
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
                sqlStr = sqlStr + " DELETE FROM client "
                sqlStr = sqlStr + " WHERE 0 = 0"
                sqlStr = sqlStr + "     AND id = " + id.ToString

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
    ''' List(Of Client)をDataTableに変換
    ''' </summary>
    ''' <param name="list"></param>
    ''' <returns></returns>
    Private Function ToDataTable(list As List(Of Client)) As DataTable

        Dim dt As DataTable = New DataTable("clientList")
        With dt.Columns
            .Add("cId")
            .Add("cCode")
            .Add("cName")
        End With

        '結果を表示 
        For Each client In list

            Dim dr As DataRow = dt.NewRow
            With client
                dr("cId") = .id '取引先番号
                dr("cCode") = .code '取引先コード
                dr("cName") = .name '取引先名
            End With

            dt.Rows.Add(dr)

        Next

        Return dt

    End Function

End Module
