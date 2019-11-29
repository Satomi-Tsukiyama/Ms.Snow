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
            sqlStr = sqlStr + " FROM anken"

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
    ''' 全ての工番2を取得
    ''' </summary>
    ''' <returns></returns>
    Public Function getAllCode2() As List(Of String)

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
            sqlStr = sqlStr + "SELECT DISTINCT code2"
            sqlStr = sqlStr + " FROM anken"

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
    ''' 全ての売上年月を取得
    ''' </summary>
    ''' <returns></returns>
    Public Function getAllSalesYearMonth() As List(Of String)

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim dateList As New List(Of Date)
        Dim stringList As New List(Of String)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + "SELECT DISTINCT salesyearmonth"
            sqlStr = sqlStr + " FROM anken"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()
                dateList.Add(rlt("salesyearmonth"))
            End While

            'クローズ 
            con.Close()

        End Using

        '日を削除(yyyy/MM/dd→yyyy/MM)
        For Each oneDate In dateList
            stringList.Add(Format(oneDate, "yyyy/MM"))
        Next
        '重複除外
        stringList.Distinct

        Return stringList

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
        Dim sqlStr As String = ""

        Dim maxCode3 As Integer = 0

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 
        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + " SELECT"
            sqlStr = sqlStr + "     MAX(code3) AS maxcode3"
            sqlStr = sqlStr + " FROM anken"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND code2 = '" + code2 + "'"

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

    ''' <summary>
    ''' 同じ工番と名前の組み合わせの案件が存在するか
    ''' </summary>
    ''' <param name="code1"></param>
    ''' <param name="code2"></param>
    ''' <param name="code3"></param>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Public Function isExistSameCode(code1 As String, code2 As String, code3 As String, name As String) As Boolean

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
            sqlStr = sqlStr + "     anken.*,"
            sqlStr = sqlStr + "     client.code AS clientcode,"
            sqlStr = sqlStr + "     client.name AS clientname,"
            sqlStr = sqlStr + "     staff.name AS staffname"
            sqlStr = sqlStr + " FROM anken"
            sqlStr = sqlStr + "     LEFT JOIN client ON anken.clientid = client.id"
            sqlStr = sqlStr + "     LEFT JOIN staff ON anken.staffid = staff.id"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND anken.code1 = '" + code1 + "'"
            sqlStr = sqlStr + "     AND anken.code2 = '" + code2 + "'"
            sqlStr = sqlStr + "     AND anken.code3 = '" + code3 + "'"
            sqlStr = sqlStr + "     AND anken.name = '" + name + "'"

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
    '' 全案件をDataTableで出力
    '' </summary>
    '' <returns></returns>
    Public Function selectAllForDataTable() As DataTable


        Return ToDataTable(selectAllForList())

    End Function

    '' <summary>
    '' 全案件をDataTableで出力
    '' </summary>
    '' <returns></returns>
    Public Function selectAllForList() As List(Of Anken)

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
            sqlStr = sqlStr + "     anken.*,"
            sqlStr = sqlStr + "     client.code AS clientcode,"
            sqlStr = sqlStr + "     client.name AS clientname,"
            sqlStr = sqlStr + "     staff.name AS staffname"
            sqlStr = sqlStr + " FROM anken"
            sqlStr = sqlStr + "     LEFT JOIN client ON anken.clientid = client.id"
            sqlStr = sqlStr + "     LEFT JOIN staff ON anken.staffid = staff.id"
            sqlStr = sqlStr + " ORDER BY"
            sqlStr = sqlStr + "     anken.code2,"
            sqlStr = sqlStr + "     anken.code3"

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

        Return list

    End Function

    '' <summary>
    '' 指定した売上年月のデータをList(Of Anken)で出力
    '' </summary>
    '' <returns></returns>
    Public Function selectWhereSalesYearMonthForList(year As Integer, month As Integer) As List(Of Anken)

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

            '売上年月の下限
            Dim lower As Date = CDate(year.ToString + "/" + month.ToString + "/" + "1")

            '売上年月の上限
            Dim upper As Date
            If month = 12 Then
                upper = CDate((year + 1).ToString + "/" + "1" + "/" + "1")
            Else
                upper = CDate(year.ToString + "/" + (month + 1).ToString + "/" + "1")
            End If

            sqlStr = sqlStr + " SELECT"
            sqlStr = sqlStr + "     anken.*,"
            sqlStr = sqlStr + "     client.code AS clientcode,"
            sqlStr = sqlStr + "     client.name AS clientname,"
            sqlStr = sqlStr + "     staff.name AS staffname"
            sqlStr = sqlStr + " FROM anken"
            sqlStr = sqlStr + "     LEFT JOIN client ON anken.clientid = client.id"
            sqlStr = sqlStr + "     LEFT JOIN staff ON anken.staffid = staff.id"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND anken.salesyearmonth >= '" + lower.ToShortDateString + "'"
            sqlStr = sqlStr + "     AND Anken.salesYearMonth < '" + upper.ToShortDateString + "'"
            sqlStr = sqlStr + " ORDER BY"
            sqlStr = sqlStr + "     anken.code2,"
            sqlStr = sqlStr + "     anken.code3"

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

        Return list

    End Function


    '' <summary>
    '' 全案件をの内指定したCode2の案件をDataTableで出力
    '' </summary>
    '' <returns></returns>
    Public Function selectWhereCode2(code2 As String) As DataTable

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
            sqlStr = sqlStr + "SELECT"
            sqlStr = sqlStr + "     anken.*,"
            sqlStr = sqlStr + "     client.code AS clientcode,"
            sqlStr = sqlStr + "     client.name AS clientname,"
            sqlStr = sqlStr + "     staff.name AS staffname"
            sqlStr = sqlStr + " FROM anken"
            sqlStr = sqlStr + "     LEFT JOIN client ON anken.clientid = client.id"
            sqlStr = sqlStr + "     LEFT JOIN staff ON anken.staffid = staff.id"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND anken.code2 = '" + code2 + "'"
            sqlStr = sqlStr + " ORDER BY"
            sqlStr = sqlStr + "     anken.code3"

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
    ''' 指定した取引先IDと売上年月のデータをDataTableで出力
    ''' </summary>
    ''' <param name="clientId"></param>
    ''' <param name="year"></param>
    ''' <param name="month"></param>
    ''' <returns></returns>
    Public Function selectWhereClientAndSalesYearMonth(clientId As Integer, year As Integer, month As Integer) As DataTable

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

            '売上年月の下限
            Dim lower As Date = CDate(year.ToString + "/" + month.ToString + "/" + "1")

            '売上年月の上限
            Dim upper As Date
            If month = 12 Then
                upper = CDate((year + 1).ToString + "/" + "1" + "/" + "1")
            Else
                upper = CDate(year.ToString + "/" + (month + 1).ToString + "/" + "1")
            End If

            sqlStr = sqlStr + "SELECT"
            sqlStr = sqlStr + "     anken.*,"
            sqlStr = sqlStr + "     client.code AS clientcode,"
            sqlStr = sqlStr + "     client.name AS clientname,"
            sqlStr = sqlStr + "     staff.name AS staffname"
            sqlStr = sqlStr + " FROM anken"
            sqlStr = sqlStr + "     LEFT JOIN client ON anken.clientid = client.id"
            sqlStr = sqlStr + "     LEFT JOIN staff ON anken.staffid = staff.id"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND anken.clientid = " + clientId.ToString
            sqlStr = sqlStr + "     AND anken.salesyearmonth >= '" + lower.ToShortDateString + "'"
            sqlStr = sqlStr + "     AND Anken.salesYearMonth < '" + upper.ToShortDateString + "'"
            sqlStr = sqlStr + " ORDER BY"
            sqlStr = sqlStr + "     anken.code2,"
            sqlStr = sqlStr + "     anken.code3"

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
    ''' 指定した売上年月のデータの内、指定した取引先ID以外のデータをDataTableで出力
    ''' </summary>
    ''' <param name="clientIds_list"></param>
    ''' <param name="year"></param>
    ''' <param name="month"></param>
    ''' <returns></returns>
    Public Function selectWhereElseClientAndSalesYearMonth(clientIds_list As List(Of Integer), year As Integer, month As Integer) As DataTable

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of Anken)

        Dim a As Integer() = clientIds_list.ToArray

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文

            '売上年月の下限
            Dim lower As Date = CDate(year.ToString + "/" + month.ToString + "/" + "1")

            '売上年月の上限
            Dim upper As Date
            If month = 12 Then
                upper = CDate((year + 1).ToString + "/" + "1" + "/" + "1")
            Else
                upper = CDate(year.ToString + "/" + (month + 1).ToString + "/" + "1")
            End If

            sqlStr = sqlStr + "SELECT"
            sqlStr = sqlStr + "     anken.*,"
            sqlStr = sqlStr + "     client.code AS clientcode,"
            sqlStr = sqlStr + "     client.name AS clientname,"
            sqlStr = sqlStr + "     staff.name AS staffname"
            sqlStr = sqlStr + " FROM anken"
            sqlStr = sqlStr + "     LEFT JOIN client ON anken.clientid = client.id"
            sqlStr = sqlStr + "     LEFT JOIN staff ON anken.staffid = staff.id"
            sqlStr = sqlStr + " WHERE 0 = 0"

            If clientIds_list.Count > 0 Then
                sqlStr = sqlStr + " AND anken.clientid NOT IN (0"

                For Each clientId In clientIds_list
                    sqlStr = sqlStr + String.Format(",{0}", clientId.ToString)
                Next

                sqlStr = sqlStr + ")"
            End If

            sqlStr = sqlStr + "     AND anken.salesyearmonth >= '" + lower.ToShortDateString + "'"
            sqlStr = sqlStr + "     AND Anken.salesYearMonth < '" + upper.ToShortDateString + "'"

            sqlStr = sqlStr + " ORDER BY"
            sqlStr = sqlStr + "     anken.clientid,"
            sqlStr = sqlStr + "     anken.code2,"
            sqlStr = sqlStr + "     anken.code3"

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
    ''' 指定したIDの案件情報を取得
    ''' </summary>
    ''' <param name="id">社員番号</param>
    ''' <returns></returns>
    Public Function selectOne(id As Integer) As Anken

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
            sqlStr = sqlStr + "     anken.*,"
            sqlStr = sqlStr + "     client.code AS clientcode,"
            sqlStr = sqlStr + "     client.name AS clientname,"
            sqlStr = sqlStr + "     staff.name AS staffname"
            sqlStr = sqlStr + " FROM anken"
            sqlStr = sqlStr + "     LEFT JOIN client ON anken.clientid = client.id"
            sqlStr = sqlStr + "     LEFT JOIN staff ON anken.staffid = staff.id"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND anken.id = " + id.ToString

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
                    sqlStr = sqlStr + "     anken"
                    sqlStr = sqlStr + " SET"
                    sqlStr = sqlStr + "     code1 = '" + .code1 + "',"
                    sqlStr = sqlStr + "     code2 = '" + .code2 + "',"
                    sqlStr = sqlStr + "     code3 = '" + .code3 + "',"
                    sqlStr = sqlStr + "     name = '" + .name + "',"
                    sqlStr = sqlStr + "     clientid = " + .clientId.ToString + ","
                    sqlStr = sqlStr + "     staffid = " + .staffId.ToString + ","
                    sqlStr = sqlStr + "     status = " + .status.ToString + ","
                    sqlStr = sqlStr + "     salesyearmonth = '" + .salesYearMonth.ToShortDateString + "',"
                    sqlStr = sqlStr + "     salesamount = " + .salesAmount.ToString + ","
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
        Dim sqlStr As String = ""

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        Try

            'コネクション生成 
            Using con As New MySqlConnection(connectionString)

                '接続 
                con.Open()

                'SQL文 
                sqlStr = sqlStr + " UPDATE"
                sqlStr = sqlStr + "     anken"
                sqlStr = sqlStr + " SET"
                sqlStr = sqlStr + "     status = " + status.ToString + ","
                sqlStr = sqlStr + "     updatedatetime = now()"
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
                    sqlStr = sqlStr + "     anken ("
                    sqlStr = sqlStr + "         id,"
                    sqlStr = sqlStr + "         code1,"
                    sqlStr = sqlStr + "         code2,"
                    sqlStr = sqlStr + "         code3,"
                    sqlStr = sqlStr + "         name,"
                    sqlStr = sqlStr + "         clientid,"
                    sqlStr = sqlStr + "         staffid,"
                    sqlStr = sqlStr + "         status,"
                    sqlStr = sqlStr + "         salesyearmonth,"
                    sqlStr = sqlStr + "         salesamount,"
                    sqlStr = sqlStr + "         insertdatetime"
                    sqlStr = sqlStr + " ) VALUES ("
                    sqlStr = sqlStr + String.Format(" {0},", .id.ToString)
                    sqlStr = sqlStr + String.Format(" '{0}',", .code1)
                    sqlStr = sqlStr + String.Format(" '{0}',", .code2)
                    sqlStr = sqlStr + String.Format(" '{0}',", .code3)
                    sqlStr = sqlStr + String.Format(" '{0}',", .name)
                    sqlStr = sqlStr + String.Format(" '{0}',", .clientId.ToString)
                    sqlStr = sqlStr + String.Format(" '{0}',", .staffId.ToString)
                    sqlStr = sqlStr + String.Format(" '{0}',", .status.ToString)
                    sqlStr = sqlStr + String.Format(" '{0}',", .salesYearMonth.ToShortDateString)
                    sqlStr = sqlStr + String.Format(" '{0}',", .salesAmount.ToString)
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
    ''' 部署情報の削除
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
                sqlStr = sqlStr + " DELETE FROM anken "
                sqlStr = sqlStr + " WHERE 0 = 0 "
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
    ''' List(Of Anken)をDataTableに変換
    ''' </summary>
    ''' <param name="list"></param>
    ''' <returns></returns>
    Private Function ToDataTable(list As List(Of Anken)) As DataTable

        Dim dt As DataTable = New DataTable("ankenList")
        With dt.Columns
            .Add("cId")
            .Add("cCode1")
            .Add("cCode2")
            .Add("cCode3")
            .Add("cCode")
            .Add("cName")
            .Add("cSalesYearMonth")
            .Add("cSalesAmount")
            .Add("cStatus")
            .Add("cClientID")
            .Add("cClient")
            .Add("cInsertDate")
            .Add("cStaffID")
            .Add("cStaffName")
        End With

        '結果を表示 
        For Each anken In list

            Dim dr As DataRow = dt.NewRow

            With anken
                dr("cId") = .id        '案件番号
                dr("cCode1") = .code1  '工番1
                dr("cCode2") = .code2  '工番2
                dr("cCode3") = .code3  '工番3
                dr("cCode") = .code1 + .code2 + .code3  '工番
                dr("cName") = .name    '件名
                dr("cSalesYearMonth") = .salesYearMonth.ToString("yyyy年MM月")    '売上年月(yyyy年MM月表記)
                dr("cSalesAmount") = .salesAmount.ToString("#,0")    '売上金額(100,000,000表記)
                dr("cClientID") = .clientId    '取引先ID
                dr("cClient") = .clientCode ' + " | " + anken.clientName    '取引先
                dr("cStatus") = .status '請求状況
                dr("cInsertDate") = .insertDate.ToShortDateString   '作成日(yyyy/MM/dd表記)
                dr("cStaffID") = .staffId    '作成者ID
                dr("cStaffName") = .staffName    '作成者名
            End With

            dt.Rows.Add(dr)

        Next

        Return dt

    End Function

End Module
