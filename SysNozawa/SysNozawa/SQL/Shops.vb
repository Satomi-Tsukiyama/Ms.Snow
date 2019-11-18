Imports MySql.Data.MySqlClient

Public Module Shops

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
            sqlStr = "SELECT MAX(id) AS maxid"
            sqlStr = sqlStr + " FROM shop"

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
    '' 全購入先をDataTableで出力
    '' </summary>
    '' <returns></returns>
    Public Function selectAll() As DataTable

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        'リスト初期化
        Dim list As New List(Of Shop)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "SELECT *"
            sqlStr = sqlStr + " FROM shop"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()

                list.Add(New Shop(rlt))

            End While

            'クローズ 
            con.Close()

        End Using

        Return ToDataTable(list)

    End Function

    ''' <summary>
    ''' 指定したIDの購入先情報を取得
    ''' </summary>
    ''' <param name="id">社員番号</param>
    ''' <returns></returns>
    Public Function selectOne(id As Integer) As Shop

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        'リスト初期化
        Dim list As New List(Of Shop)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "SELECT *"
            sqlStr = sqlStr + " FROM shop"
            sqlStr = sqlStr + String.Format(" WHERE id = {0}", id)

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            If rlt.Read Then
                list.Add(New Shop(rlt))
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
    ''' 購入先情報の更新
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    Public Function update(info As Shop) As Boolean

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        Try

            'コネクション生成 
            Using con As New MySqlConnection(connectionString)

                '接続 
                con.Open()

                'SQL文 
                sqlStr = "UPDATE shop SET"
                sqlStr = sqlStr + String.Format(" code = '{0}',", info.code)
                sqlStr = sqlStr + String.Format(" name = '{0}',", info.name)
                sqlStr = sqlStr + " updatedatetime = now()"

                sqlStr = sqlStr + String.Format(" WHERE id = {0}", info.id)

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
    ''' 購入先情報の追加
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    Public Function insert(info As Shop) As Boolean

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        Try

            'コネクション生成 
            Using con As New MySqlConnection(connectionString)

                '接続 
                con.Open()

                'SQL文 
                sqlStr = "INSERT INTO shop ("
                sqlStr = sqlStr + "  id"
                sqlStr = sqlStr + ", code"
                sqlStr = sqlStr + ", name"
                sqlStr = sqlStr + ", insertdatetime"

                sqlStr = sqlStr + ") VALUES ("
                sqlStr = sqlStr + String.Format(" {0}", info.id)
                sqlStr = sqlStr + String.Format(", '{0}'", info.code)
                sqlStr = sqlStr + String.Format(", '{0}'", info.name)
                sqlStr = sqlStr + ", now()"
                sqlStr = sqlStr + ")"

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
    ''' 購入先情報の削除
    ''' </summary>
    ''' <param name="id">ID</param>
    ''' <returns></returns>
    Public Function delete(id As Integer) As Boolean
        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        Try

            'コネクション生成 
            Using con As New MySqlConnection(connectionString)

                '接続 
                con.Open()

                'SQL文 
                sqlStr = "DELETE FROM shop "
                sqlStr = sqlStr + String.Format(" WHERE id = {0}", id)

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
    ''' List(Of Anken)をDataTableに変換
    ''' </summary>
    ''' <param name="list"></param>
    ''' <returns></returns>
    Private Function ToDataTable(list As List(Of Shop)) As DataTable

        Dim dt As DataTable = New DataTable("shopList")
        dt.Columns.Add("cId")
        dt.Columns.Add("cCode")
        dt.Columns.Add("cName")


        '結果を表示 
        For Each shop In list

            Dim dr As DataRow = dt.NewRow

            dr("cId") = shop.id '購入先番号
            dr("cCode") = shop.code '購入先コード
            dr("cName") = shop.name '購入先名

            dt.Rows.Add(dr)

        Next

        Return dt

    End Function

End Module
