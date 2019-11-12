Imports MySql.Data.MySqlClient

Public Module Ankens

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
            sqlStr = sqlStr + " from anken"

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

    Public Function getAllCode2() As List(Of String)

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
            sqlStr = "select distinct anken.code2"
            sqlStr = sqlStr + " from anken"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()
                list.Add(rlt("code2"))
            End While

            'クローズ 
            con.Close()

        End Using

        Return list

    End Function

    ''' <summary>
    ''' 新規追加用の新しい工番3を生成
    ''' </summary>
    ''' <param name="code2"></param>
    ''' <returns></returns>
    Public Function getNewCode3(code2 As String) As Integer

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        Dim maxCode3 As Integer = 0

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 
        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "select max(code3) as maxcode3"
            sqlStr = sqlStr + " from anken"
            sqlStr = sqlStr + String.Format(" where code2 = '{0}'", code2)

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()

                If IsNothing(rlt("maxcode3")) Or rlt("maxcode3").ToString.Length = 0 Then
                Else
                    maxCode3 = rlt("maxcode3")
                End If


            End While

            'クローズ 
            con.Close()

        End Using

        Return maxCode3 + 1
    End Function

    Public Function getCountSameCode(code1 As String, code2 As String, code3 As String) As Boolean

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '社員リスト初期化
        Dim list As New List(Of Anken)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "select anken.*,"
            sqlStr = sqlStr + " client.code as clientcode,"
            sqlStr = sqlStr + " client.name as clientname,"
            sqlStr = sqlStr + " staff.name as staffname"
            sqlStr = sqlStr + " from anken"
            sqlStr = sqlStr + " left join client on anken.clientid = client.id"
            sqlStr = sqlStr + " left join staff on anken.staffid = staff.id"
            sqlStr = sqlStr + " Where 0 = 0"
            sqlStr = sqlStr + String.Format(" and anken.code1 = '{0}'", code1)
            sqlStr = sqlStr + String.Format(" and anken.code2 = '{0}'", code2)
            sqlStr = sqlStr + String.Format(" and anken.code3 = '{0}'", code3)

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

        Return list.Count

    End Function

    '' <summary>
    '' 全案件をDataTableで出力
    '' </summary>
    '' <returns></returns>
    Public Function selectAll() As DataTable

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '社員リスト初期化
        Dim list As New List(Of Anken)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "select anken.*,"
            sqlStr = sqlStr + " client.code as clientcode,"
            sqlStr = sqlStr + " client.name as clientname,"
            sqlStr = sqlStr + " staff.name as staffname"
            sqlStr = sqlStr + " from anken"
            sqlStr = sqlStr + " left join client on anken.clientid = client.id"
            sqlStr = sqlStr + " left join staff on anken.staffid = staff.id"
            sqlStr = sqlStr + " order by anken.code2, anken.code3"

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

        Return ToDataTable(list)

    End Function

    '' <summary>
    '' 全案件をDataTableで出力
    '' </summary>
    '' <returns></returns>
    Public Function selectWhereCode2(code2 As String) As DataTable

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '社員リスト初期化
        Dim list As New List(Of Anken)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "select anken.*,"
            sqlStr = sqlStr + " client.code as clientcode,"
            sqlStr = sqlStr + " client.name as clientname,"
            sqlStr = sqlStr + " staff.name as staffname"
            sqlStr = sqlStr + " from anken"
            sqlStr = sqlStr + " left join client on anken.clientid = client.id"
            sqlStr = sqlStr + " left join staff on anken.staffid = staff.id"
            sqlStr = sqlStr + " Where 0 = 0"
            sqlStr = sqlStr + String.Format(" and anken.code2 = '{0}'", code2)
            sqlStr = sqlStr + " order by anken.code2"

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

        Return ToDataTable(list)

    End Function

    Public Function selectWhereClientAndSalesYearMonth(clientId As Integer, yaer As Integer, month As Integer) As DataTable

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '社員リスト初期化
        Dim list As New List(Of Anken)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "select anken.*,"
            sqlStr = sqlStr + " client.code as clientcode,"
            sqlStr = sqlStr + " client.name as clientname,"
            sqlStr = sqlStr + " staff.name as staffname"
            sqlStr = sqlStr + " from anken"
            sqlStr = sqlStr + " left join client on anken.clientid = client.id"
            sqlStr = sqlStr + " left join staff on anken.staffid = staff.id"
            sqlStr = sqlStr + " Where 0 = 0"
            sqlStr = sqlStr + String.Format(" and anken.clientid = {0}", clientId)
            sqlStr = sqlStr + String.Format(" and anken.salesyearmonth >= '{0}'", CDate(yaer.ToString + "/" + month.ToString + "/" + "1"))
            If month = 12 Then
                sqlStr = sqlStr + String.Format(" and anken.salesyearmonth < '{0}'", CDate((yaer + 1).ToString + "/" + "1" + "/" + "1"))
            Else
                sqlStr = sqlStr + String.Format(" and anken.salesyearmonth < '{0}'", CDate(yaer.ToString + "/" + (month + 1).ToString + "/" + "1"))

            End If


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

        Return ToDataTable(list)

    End Function

    Public Function selectWhereElseClientAndSalesYearMonth(clientIds_list As List(Of Integer), yaer As Integer, month As Integer) As DataTable

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '社員リスト初期化
        Dim list As New List(Of Anken)

        Dim a As Integer() = clientIds_list.ToArray

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "select anken.*,"
            sqlStr = sqlStr + " client.code as clientcode,"
            sqlStr = sqlStr + " client.name as clientname,"
            sqlStr = sqlStr + " staff.name as staffname"
            sqlStr = sqlStr + " from anken"
            sqlStr = sqlStr + " left join client on anken.clientid = client.id"
            sqlStr = sqlStr + " left join staff on anken.staffid = staff.id"
            sqlStr = sqlStr + " Where 0 = 0"

            If clientIds_list.Count > 0 Then
                sqlStr = sqlStr + " and anken.clientid not in (0"

                For Each clientId In clientIds_list
                    sqlStr = sqlStr + String.Format(",{0}", clientId)
                Next

                sqlStr = sqlStr + ")"
            End If

            sqlStr = sqlStr + String.Format(" and anken.salesyearmonth >= '{0}'", CDate(yaer.ToString + "/" + month.ToString + "/" + "1"))
            If month = 12 Then
                sqlStr = sqlStr + String.Format(" and anken.salesyearmonth < '{0}'", CDate((yaer + 1).ToString + "/" + "1" + "/" + "1"))
            Else
                sqlStr = sqlStr + String.Format(" and anken.salesyearmonth < '{0}'", CDate(yaer.ToString + "/" + (month + 1).ToString + "/" + "1"))

            End If


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

        Return ToDataTable(list)

    End Function

    ''' <summary>
    ''' 社員情報を取得
    ''' </summary>
    ''' <param name="id">社員番号</param>
    ''' <returns></returns>
    Public Function selectOne(id As Integer) As Anken

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String

        '社員リスト初期化
        Dim list As New List(Of Anken)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = "select anken.*,"
            sqlStr = sqlStr + " client.code as clientcode,"
            sqlStr = sqlStr + " client.name as clientname,"
            sqlStr = sqlStr + " staff.name as staffname"
            sqlStr = sqlStr + " from anken"
            sqlStr = sqlStr + " left join client on anken.clientid = client.id"
            sqlStr = sqlStr + " left join staff on anken.staffid = staff.id"
            sqlStr = sqlStr + String.Format(" Where anken.id = {0}", id)

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            If rlt.Read Then
                list.Add(New Anken(rlt))
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
    ''' 取引先情報の更新
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    Public Function update(info As Anken) As Boolean

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
                sqlStr = "update anken set"
                sqlStr = sqlStr + String.Format(" code1 = '{0}',", info.code1)
                sqlStr = sqlStr + String.Format(" code2 = '{0}',", info.code2)
                sqlStr = sqlStr + String.Format(" code3 = '{0}',", info.code3)
                sqlStr = sqlStr + String.Format(" name = '{0}',", info.name)
                sqlStr = sqlStr + String.Format(" clientid = {0},", info.clientId)
                sqlStr = sqlStr + String.Format(" staffid = {0},", info.staffId)
                sqlStr = sqlStr + String.Format(" status = {0},", info.status)
                sqlStr = sqlStr + String.Format(" salesyearmonth = '{0}',", info.salesYearMonth)
                sqlStr = sqlStr + String.Format(" salesamount = {0},", info.salesAmount)
                sqlStr = sqlStr + " updatedatetime = now()"

                sqlStr = sqlStr + String.Format(" where id = {0}", info.id)

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

    ''' <summary>
    ''' 請求状況の更新
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="status"></param>
    ''' <returns></returns>
    Public Function updateStatus(id As Integer, status As Integer) As Boolean

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
                sqlStr = "update anken set"
                sqlStr = sqlStr + String.Format(" status = {0},", status)
                sqlStr = sqlStr + " updatedatetime = now()"

                sqlStr = sqlStr + String.Format(" where id = {0}", id)

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
    ''' 部署情報の追加
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    Public Function insert(info As Anken) As Boolean

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
                sqlStr = "insert into anken ("
                sqlStr = sqlStr + "  id"
                sqlStr = sqlStr + ", code1"
                sqlStr = sqlStr + ", code2"
                sqlStr = sqlStr + ", code3"
                sqlStr = sqlStr + ", name"
                sqlStr = sqlStr + ", clientid"
                sqlStr = sqlStr + ", staffid"
                sqlStr = sqlStr + ", status"
                sqlStr = sqlStr + ", salesyearmonth"
                sqlStr = sqlStr + ", salesamount"
                sqlStr = sqlStr + ", insertdatetime"

                sqlStr = sqlStr + ") values ("
                sqlStr = sqlStr + String.Format(" {0}", info.id)
                sqlStr = sqlStr + String.Format(", '{0}'", info.code1)
                sqlStr = sqlStr + String.Format(", '{0}'", info.code2)
                sqlStr = sqlStr + String.Format(", '{0}'", info.code3)
                sqlStr = sqlStr + String.Format(", '{0}'", info.name)
                sqlStr = sqlStr + String.Format(", '{0}'", info.clientId)
                sqlStr = sqlStr + String.Format(", '{0}'", info.staffId)
                sqlStr = sqlStr + String.Format(", '{0}'", info.status)
                sqlStr = sqlStr + String.Format(", '{0}'", info.salesYearMonth)
                sqlStr = sqlStr + String.Format(", '{0}'", info.salesAmount)
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
    ''' 部署情報の削除
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
                sqlStr = "delete from anken "
                sqlStr = sqlStr + String.Format(" where id = {0}", id)

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
    Private Function ToDataTable(list As List(Of Anken)) As DataTable

        Dim dt As DataTable = New DataTable("ankenList")
        dt.Columns.Add("cId")
        dt.Columns.Add("cCode1")
        dt.Columns.Add("cCode2")
        dt.Columns.Add("cCode3")
        dt.Columns.Add("cCode")
        dt.Columns.Add("cName")
        dt.Columns.Add("cSalesYearMonth")
        dt.Columns.Add("cSalesAmount")
        dt.Columns.Add("cStatus")
        dt.Columns.Add("cClientID")
        dt.Columns.Add("cClient")
        dt.Columns.Add("cInsertDate")
        dt.Columns.Add("cStaffID")
        dt.Columns.Add("cStaffName")

        '結果を表示 
        For Each anken In list

            Dim dr As DataRow = dt.NewRow

            dr("cId") = anken.id        '案件番号
            dr("cCode1") = anken.code1  '工番1
            dr("cCode2") = anken.code2  '工番2
            dr("cCode3") = anken.code3  '工番3
            dr("cCode") = anken.code1 + anken.code2 + anken.code3  '工番
            dr("cName") = anken.name    '件名
            dr("cSalesYearMonth") = anken.salesYearMonth.ToString("yyyy年MM月")    '売上年月(yyyy年MM月表記)
            dr("cSalesAmount") = anken.salesAmount.ToString("#,0")    '売上金額(100,000,000表記)
            dr("cClientID") = anken.clientId    '取引先ID
            dr("cClient") = anken.clientCode ' + " | " + anken.clientName    '取引先
            dr("cStatus") = anken.status '請求状況
            dr("cInsertDate") = anken.insertDate.ToShortDateString   '作成日(yyyy/MM/dd表記)
            dr("cStaffID") = anken.staffId    '作成者ID
            dr("cStaffName") = anken.staffName    '作成者名

            dt.Rows.Add(dr)

        Next

        Return dt

    End Function

End Module
