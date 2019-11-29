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
            sqlStr = "SELECT MAX(id) AS maxid"
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
    Public Function selectWhereAnkenId(ankenId As Integer) As List(Of AnkenOrderRange)

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
            sqlStr = sqlStr + "SELECT"
            sqlStr = sqlStr + "     *,"
            sqlStr = sqlStr + " FROM ankenorderrange"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND ankenorderrange.ankenid = " + ankenId.ToString + ""
            sqlStr = sqlStr + " ORDER BY"
            sqlStr = sqlStr + "     anken.id"

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

End Module
