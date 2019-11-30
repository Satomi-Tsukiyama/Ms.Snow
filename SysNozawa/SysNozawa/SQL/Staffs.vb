Imports MySql.Data.MySqlClient

Public Module Staffs

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
            sqlStr = sqlStr + " FROM staff"

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
    ''' 全社員情報を取得
    ''' </summary>
    ''' <returns></returns>
    Public Function selectAll() As DataTable

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of Staff)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + " SELECT *"
            sqlStr = sqlStr + " FROM staff"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()

                list.Add(New Staff(rlt))

            End While

            'クローズ 
            con.Close()

        End Using

        Return ToDataTable(list)

    End Function

    ''' <summary>
    ''' 指定したIDの社員情報を取得
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function selectOneWhereId(Optional id As Integer = Nothing) As Staff

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of Staff)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文
            sqlStr = sqlStr + " SELECT *"
            sqlStr = sqlStr + " FROM staff"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND id = " + id.ToString

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()
                list.Add(New Staff(rlt))
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

#Region "追加"

    ''' <summary>
    ''' 社員情報を更新
    ''' </summary>
    ''' <param name="info">社員情報</param>
    ''' <returns></returns>
    Public Function insert(info As Staff) As Boolean

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
                    sqlStr = sqlStr + "     staff ("
                    sqlStr = sqlStr + "         id,"
                    sqlStr = sqlStr + "         name,"
                    sqlStr = sqlStr + "         insertdatetime"
                    sqlStr = sqlStr + " ) VALUES ("
                    sqlStr = sqlStr + String.Format(" '{0}',", .id.ToString)
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

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

#End Region

#Region "更新"

    ''' <summary>
    ''' 社員情報を更新
    ''' </summary>
    ''' <param name="info">社員情報</param>
    ''' <returns></returns>
    Public Function update(info As Staff) As Boolean

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
                    sqlStr = sqlStr + "     staff"
                    sqlStr = sqlStr + " SET"
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

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

#End Region

#Region "削除"

    ''' <summary>
    ''' 社員情報を更新
    ''' </summary>
    ''' <param name="id">社員ID</param>
    ''' <returns></returns>
    Public Function delete(id As Integer)

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
                sqlStr = sqlStr + " DELETE FROM staff "
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
    ''' List(Of Staff)をDataTableに変換
    ''' </summary>
    ''' <param name="list"></param>
    ''' <returns></returns>
    Private Function ToDataTable(list As List(Of Staff)) As DataTable

        Dim dt As DataTable = New DataTable("staffList")
        With dt.Columns
            .Add("cId")
            .Add("cName")
        End With

        '結果を表示 
        For Each staff In list

            Dim dr As DataRow = dt.NewRow
            With staff
                dr("cId") = .id '従業員番号
                dr("cName") = .name '氏名
            End With

            dt.Rows.Add(dr)

        Next

        Return dt

    End Function

End Module
