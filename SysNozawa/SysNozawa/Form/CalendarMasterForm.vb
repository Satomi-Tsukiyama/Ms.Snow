Imports System.ComponentModel

Public Class CalendarMasterForm

    Private inputType As New inputType

    Private btnDays As Button()

    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CalendarMasterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnDays = {
        btnRow1Col1, btnRow1Col2, btnRow1Col3, btnRow1Col4, btnRow1Col5, btnRow1Col6, btnRow1Col7,
        btnRow2Col1, btnRow2Col2, btnRow2Col3, btnRow2Col4, btnRow2Col5, btnRow2Col6, btnRow2Col7,
        btnRow3Col1, btnRow3Col2, btnRow3Col3, btnRow3Col4, btnRow3Col5, btnRow3Col6, btnRow3Col7,
        btnRow4Col1, btnRow4Col2, btnRow4Col3, btnRow4Col4, btnRow4Col5, btnRow4Col6, btnRow4Col7,
        btnRow5Col1, btnRow5Col2, btnRow5Col3, btnRow5Col4, btnRow5Col5, btnRow5Col6, btnRow5Col7}

        'カレンダーの表示
        setCalendar()

        setOther()
    End Sub

    ''' <summary>
    ''' 編集クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mitmEdit_Click(sender As Object, e As EventArgs) Handles mitmEdit.Click

        inputType = inputType.update
        mitmAdd.Enabled = False
        mitmEdit.Enabled = False
        mitmDelete.Enabled = False

        dtpDisplayYearMonth.Enabled = False

        '有効
        For Each btnDay In btnDays
            btnDay.Enabled = True
        Next

        btnOK.Enabled = True
        btnOK.Text = "編集"
        btnCancel.Text = "中止"

    End Sub

    ''' <summary>
    ''' 年月変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dtpDisplayYearMonth_ValueChanged(sender As Object, e As EventArgs) Handles dtpDisplayYearMonth.ValueChanged

        'ボタンの表示/非表示
        setbtnDays_Visible()

        '休日のボタン背景色の変更
        setBtnDays_BackColor()

    End Sub

    ''' <summary>
    ''' 日付クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnDays_Click(sender As Object, e As EventArgs) Handles _
            btnRow1Col1.Click, btnRow1Col2.Click, btnRow1Col3.Click, btnRow1Col4.Click, btnRow1Col5.Click, btnRow1Col6.Click, btnRow1Col7.Click,
            btnRow2Col1.Click, btnRow2Col2.Click, btnRow2Col3.Click, btnRow2Col4.Click, btnRow2Col5.Click, btnRow2Col6.Click, btnRow2Col7.Click,
            btnRow3Col1.Click, btnRow3Col2.Click, btnRow3Col3.Click, btnRow3Col4.Click, btnRow3Col5.Click, btnRow3Col6.Click, btnRow3Col7.Click,
            btnRow4Col1.Click, btnRow4Col2.Click, btnRow4Col3.Click, btnRow4Col4.Click, btnRow4Col5.Click, btnRow4Col6.Click, btnRow4Col7.Click,
            btnRow5Col1.Click, btnRow5Col2.Click, btnRow5Col3.Click, btnRow5Col4.Click, btnRow5Col5.Click, btnRow5Col6.Click, btnRow5Col7.Click

        Dim clickButton As Button = CType(sender, Button)

        Select Case clickButton.BackColor
            Case Color.White
                clickButton.BackColor = Color.Blue
            Case Color.Blue
                clickButton.BackColor = Color.Red
            Case Color.Red
                clickButton.BackColor = Color.White
        End Select

    End Sub

    ''' <summary>
    ''' 追加/編集クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        '入力情報のチェック
        If check() = False Then
            Exit Sub
        End If

        '追加クリック
        If inputType = inputType.insert Then

        ElseIf inputType = inputType.update Then '編集クリック

            If DialogResult.No = MessageBox.Show("編集します。よろしいですか？",
                                                 "編集",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question) Then
                Exit Sub

            End If

            Dim errorInfo As New List(Of Calendar)
            For Each btnDay In btnDays

                '非表示ボタンの処理スルー
                If btnDay.Visible = False Then
                    Continue For
                End If

                Dim infoday As Date = CDate(dtpDisplayYearMonth.Value.Year.ToString + "/" + dtpDisplayYearMonth.Value.Month.ToString + "/" + btnDay.Text)
                Dim holiday As Calendar = Calendars.selectHolidayWhereDay(infoday)

                Dim info As New Calendar
                info.day = infoday

                Select Case btnDay.BackColor
                    Case Color.Blue '休日
                        info.holidayflg = 1
                    Case Color.Red '法休
                        info.holidayflg = 2
                    Case Else
                        Continue For
                End Select

                If IsNothing(holiday) Then '新規登録

                    info.id = Calendars.getNewId()

                    If Calendars.insert(info) = False Then
                        errorInfo.Add(info)
                    End If

                Else '休日フラグ更新

                    info.id = holiday.id

                    If info.holidayflg = holiday.holidayflg Then
                        Continue For
                    End If

                    If Calendars.update(info) = False Then
                        errorInfo.Add(info)
                    End If

                End If

            Next

            If errorInfo.Count = 0 Then
                MessageBox.Show("編集しました。")
            Else
                MessageBox.Show("編集に失敗しました。")
                Exit Sub
            End If

        Else

        End If

        inputType = inputType.non

        setCalendar()

        setOther()

    End Sub

    ''' <summary>
    ''' 閉じる/中止クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        '中止クリック
        If inputType = inputType.insert Or inputType = inputType.update Then
            inputType = inputType.non

            setCalendar()
            setOther()

        Else '閉じるクリック
            Me.Close()
        End If

    End Sub


    ''' <summary>
    ''' カレンダーの表示
    ''' </summary>
    Private Sub setCalendar()

        dtpDisplayYearMonth.Enabled = True
        dtpDisplayYearMonth.Value = Now()

        '無効
        For Each btnDay In btnDays
            btnDay.Enabled = False
        Next

        'ボタンの表示/非表示
        setBtnDays_Visible()

        '休日のボタン背景色の変更
        setBtnDays_BackColor()

    End Sub

    ''' <summary>
    ''' ボタンの表示/非表示
    ''' </summary>
    Private Sub setBtnDays_Visible()

        Dim yearmonth As Date = dtpDisplayYearMonth.Value

        '全表示
        For Each btnDay In btnDays
            btnDay.Visible = False
            btnDay.Text = ""
        Next

        '1日の曜日取得
        Dim WeekdayOf1th As inputType = Weekday(CDate(yearmonth.Year.ToString + "/" + yearmonth.Month.ToString + "/1"))
        Dim btnNoOf1th As Integer = WeekdayOf1th

        '月の日数取得
        Dim DaysInMonth As Integer = DateTime.DaysInMonth(yearmonth.Year, yearmonth.Month)
        Dim btnNoOfEnd As Integer = btnNoOf1th + DaysInMonth - 1

        Dim dayNo As Integer = 1
        For i = 1 To btnDays.Count
            If i >= WeekdayOf1th And i <= btnNoOfEnd Then
                btnDays(i - 1).Visible = True
                btnDays(i - 1).Text = dayNo
                dayNo = dayNo + 1
            End If
        Next

    End Sub

    ''' <summary>
    ''' 休日のボタン背景色の変更
    ''' </summary>
    Private Sub setBtnDays_BackColor()

        Dim yearmonth As Date = dtpDisplayYearMonth.Value

        '全色白
        For Each btnDay In btnDays
            btnDay.BackColor = Color.White
        Next

        '1日の曜日取得
        Dim WeekdayOf1th As inputType = Weekday(CDate(yearmonth.Year.ToString + "/" + yearmonth.Month.ToString + "/1"))
        Dim btnNoOf1th As Integer = WeekdayOf1th

        '休日取得
        Dim holidays As List(Of Calendar) = Calendars.selectHolidayWhereYearMonth(yearmonth.Year, yearmonth.Month)

        If IsNothing(holidays) = False Then
            For Each holiday In holidays
                If holiday.holidayflg = 1 Then '休日→青
                    btnDays(btnNoOf1th + (holiday.day.Day - 1) - 1).BackColor = Color.Blue
                Else '法休→赤
                    btnDays(btnNoOf1th + (holiday.day.Day - 1) - 1).BackColor = Color.Red
                End If
            Next
        End If

    End Sub

    Private Sub setOther()

        mitmAdd.Enabled = False
        mitmEdit.Enabled = True
        mitmDelete.Enabled = False

        Dim startday As Date = CDate(dtpDisplayYearMonth.Value.Year.ToString + "/1/1")
        Dim endday As Date = CDate((dtpDisplayYearMonth.Value.Year + 1).ToString + "/1/1")
        lblDaysOfYear.Text = String.Format("{0}日", DateDiff(DateInterval.Day, startday, endday))


        btnOK.Enabled = False
        btnOK.Text = "編集"
        btnCancel.Text = "閉じる"

    End Sub

    ''' <summary>
    ''' 入力した案件情報のチェック
    ''' </summary>
    ''' <returns></returns>
    Private Function check() As Boolean

        Return True
    End Function


End Class