Imports MySql.Data.MySqlClient

Public Module Calendars

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
            sqlStr = sqlStr + " FROM calendar"

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
    ''' 該当日付の休日情報を取得
    ''' </summary>
    ''' <param name="day"></param>
    ''' <returns></returns>
    Public Function selectHolidayWhereDay(day As Date) As Calendar

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of Calendar)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文 
            sqlStr = sqlStr + " SELECT"
            sqlStr = sqlStr + "     *"
            sqlStr = sqlStr + " FROM calendar"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND day = '" + day.ToShortDateString + "'"
            sqlStr = sqlStr + "     AND holidayflg IS NOT NULL"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()

                list.Add(New Calendar(rlt))

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

    ''' <summary>
    ''' 該当年月の休日情報を取得
    ''' </summary>
    ''' <param name="year"></param>
    ''' <param name="month"></param>
    ''' <returns></returns>
    Public Function selectHolidayWhereYearMonth(year As Integer, month As Integer) As List(Of Calendar)

        Dim cmd As MySqlCommand
        Dim rlt As MySqlDataReader

        Dim connectionString As String
        Dim sqlStr As String = ""

        'リスト初期化
        Dim list As New List(Of Calendar)

        '接続文字列
        connectionString = Configuration.ConfigurationManager.ConnectionStrings("MySqlConnection").ConnectionString

        'コネクション生成 

        Using con As New MySqlConnection(connectionString)

            '接続 
            con.Open()

            'SQL文
            Dim lower As Date = CDate(year.ToString + "/" + month.ToString + "/" + "1")

            Dim upper As Date
            If month = 12 Then
                upper = CDate((year + 1).ToString + "/" + "1" + "/" + "1")
            Else
                upper = CDate(year.ToString + "/" + (month + 1).ToString + "/" + "1")
            End If

            sqlStr = sqlStr + " SELECT"
            sqlStr = sqlStr + "     *"
            sqlStr = sqlStr + " FROM calendar"
            sqlStr = sqlStr + " WHERE 0 = 0"
            sqlStr = sqlStr + "     AND day >= '" + lower.ToShortDateString + "'"
            sqlStr = sqlStr + "     AND day < '" + upper.ToShortDateString + "'"
            sqlStr = sqlStr + "     AND holidayflg IS NOT NULL"

            'MySQLCommand作成 
            cmd = New MySqlCommand(sqlStr, con)

            'SQL文実行 
            rlt = cmd.ExecuteReader

            '結果を表示 
            While rlt.Read()

                list.Add(New Calendar(rlt))

            End While

            'クローズ 
            con.Close()

        End Using

        If list.Count > 0 Then
            Return list
        Else
            Return Nothing
        End If

    End Function

#End Region

#Region "更新"

    ''' <summary>
    ''' カレンダー情報の更新
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    Public Function update(info As Calendar) As Boolean

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
                    sqlStr = sqlStr + "     calendar"
                    sqlStr = sqlStr + " SET"
                    sqlStr = sqlStr + "     day = '" + .day.ToShortDateString + "'"
                    sqlStr = sqlStr + "     holidayflg = " + .holidayflg.ToString + ","
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
    ''' カレンダー情報の追加
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    Public Function insert(info As Calendar) As Boolean

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
                    sqlStr = sqlStr + "       calendar ("
                    sqlStr = sqlStr + "         id,"
                    sqlStr = sqlStr + "         day,"
                    sqlStr = sqlStr + "         holidayflg,"
                    sqlStr = sqlStr + "         insertdatetime"
                    sqlStr = sqlStr + " ) VALUES ("
                    sqlStr = sqlStr + String.Format(" {0},", .id.ToString)
                    sqlStr = sqlStr + String.Format(" '{0}',", .day.ToShortDateString)
                    sqlStr = sqlStr + String.Format(" '{0}',", .holidayflg.ToString)
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
