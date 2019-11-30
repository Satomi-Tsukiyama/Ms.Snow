Imports MySql.Data.MySqlClient

Public Module Adjustments

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
            sqlStr = sqlStr + " FROM adjustment"

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
    '' 指定した案件IDのデータを出力
    '' </summary>
    '' <returns></returns>
    Public Function selectOneWhereAnkenId(ankenId As Integer) As Adjustment

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of Adjustment)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + " SELECT"
            sqlStr = sqlStr + "     *"
            sqlStr = sqlStr + " FROM adjustment"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND ankenid = " + ankenId.ToString + ""

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()

                list.Add(New Adjustment(rlt))

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

End Module
