Imports MySql.Data.MySqlClient

Public Module AnkenOrderRanges

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
            sqlStr = sqlStr + " FROM ankenorderrange"

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
    '' 全受注範囲の内指定した案件番号のデータをList(Of AnkenOrderRange)で出力
    '' </summary>
    '' <returns></returns>
    Public Function selectSomeWhereAnkenId(ankenId As Integer) As List(Of AnkenOrderRange)

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of AnkenOrderRange)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + " SELECT"
            sqlStr = sqlStr + "     *"
            sqlStr = sqlStr + " FROM ankenorderrange"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND ankenorderrange.ankenid = " + ankenId.ToString + ""
            sqlStr = sqlStr + " ORDER BY"
            sqlStr = sqlStr + "     ankenorderrange.id"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()

                list.Add(New AnkenOrderRange(rlt))

            End While

            'クローズ 
            con.Close()

        End Using

        Return list

    End Function

#End Region

#Region "更新"

    ''' <summary>
    ''' 案件範囲の更新
    ''' </summary>
    ''' <returns></returns>
    Public Function update(info As AnkenOrderRange) As Boolean

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
                    sqlStr = sqlStr + "     ankenorderrange"
                    sqlStr = sqlStr + " SET"
                    sqlStr = sqlStr + "     ankenid = " + .ankenid.ToString + ","
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
    ''' 案件範囲の追加
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    Public Function insert(info As AnkenOrderRange) As Boolean

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
                    sqlStr = sqlStr + "     ankenorderrange ("
                    sqlStr = sqlStr + "         id,"
                    sqlStr = sqlStr + "         ankenid,"
                    sqlStr = sqlStr + "         name,"
                    sqlStr = sqlStr + "         insertdatetime"
                    sqlStr = sqlStr + " ) VALUES ("
                    sqlStr = sqlStr + String.Format(" {0},", .id.ToString)
                    sqlStr = sqlStr + String.Format(" {0},", .ankenid.ToString)
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

End Module
