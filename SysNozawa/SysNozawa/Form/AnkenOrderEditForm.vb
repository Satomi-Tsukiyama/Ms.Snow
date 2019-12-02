Imports System.ComponentModel

Public Class AnkenOrderEditForm

    Private inputType As New inputType
    Public selectId As Integer = 0

    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AnkenOrderEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        inputType = inputType.non

        setDgvAnkenOrderRange()

        setDgvAdjustment()

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

        dgvAnkenOrderRange.ReadOnly = False
        dgvAdjustment.ReadOnly = False

        btnOK.Enabled = True
        btnOK.Text = "更新"
        btnCancel.Text = "中止"

    End Sub

    ''' <summary>
    ''' 編集クリック
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

            '案件範囲
            Dim updateInfos As New List(Of AnkenOrderRange)

            Dim dt As DataTable = dgvAnkenOrderRange.DataSource
            For Each row As DataRow In dt.Rows

                If row("cId").ToString = "" And row("cName").ToString = "" Then
                    Continue For
                End If

                Dim updateInfo As New AnkenOrderRange

                With updateInfo
                    .id = If(row("cId").ToString = "", 0, CInt(row("cId")))
                    .ankenid = selectId
                    .name = If(row("cName").ToString = "", "", row("cName").ToString)
                End With

                updateInfos.Add(updateInfo)
            Next

            For Each updateinfo In updateInfos

                Dim ans As Boolean = False

                If updateinfo.id > 0 Then
                    ans = AnkenOrderRanges.update(updateinfo)
                Else
                    updateinfo.id = AnkenOrderRanges.getNewId()
                    ans = AnkenOrderRanges.insert(updateinfo)
                End If

                If ans Then
                    Continue For
                Else
                    MessageBox.Show("編集に失敗しました。")
                    Exit Sub
                End If
            Next


            MessageBox.Show("編集しました。")


        Else

        End If

        inputType = inputType.non

        setDgvAnkenOrderRange()

        setDgvAdjustment()

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

            mitmAdd.Enabled = False
            mitmEdit.Enabled = True
            mitmDelete.Enabled = False

            dgvAnkenOrderRange.ReadOnly = True
            dgvAdjustment.ReadOnly = True

            btnOK.Enabled = False
            btnOK.Text = "更新"
            btnCancel.Text = "閉じる"

        Else '閉じるクリック
            Me.Close()
        End If

    End Sub

    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AnkenOrderEditForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        '追加中/編集中
        If inputType = inputType.insert Or inputType = inputType.update Then

            If DialogResult.No = MessageBox.Show("編集内容が保存されていません。画面を閉じてもよろしいですが？",
                                              "編集",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question
                                              ) Then

                e.Cancel = True
                Exit Sub
            End If
        End If

    End Sub

    ''' <summary>
    ''' 受注範囲リストの表示
    ''' </summary>
    Public Sub setDgvAnkenOrderRange()

        dgvAnkenOrderRange.DataSource = Nothing

        Dim allAnkenOrderRange As List(Of AnkenOrderRange) = AnkenOrderRanges.selectSomeWhereAnkenId(selectId)

        Dim dt As New DataTable
        dt.Columns.Add("cId")
        dt.Columns.Add("cName")

        For Each oneAnkenOrderRange In allAnkenOrderRange

            Dim dr As DataRow = dt.NewRow
            dr("cId") = oneAnkenOrderRange.id
            dr("cName") = oneAnkenOrderRange.name
            dt.Rows.Add(dr)

        Next

        '空白行を足して10行にする
        For i As Integer = dt.Rows.Count To 10 - 1
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)
        Next

        dgvAnkenOrderRange.DataSource = dt

    End Sub

    ''' <summary>
    ''' 調整情報の表示
    ''' </summary>
    Private Sub setDgvAdjustment()

        dgvAdjustment.DataSource = Nothing

        Dim oneAdjustment As Adjustment = Adjustments.selectOneWhereAnkenId(selectId)

        Dim dt As New DataTable
        dt.Columns.Add("Column1")

        '担当者
        Dim dr As DataRow = dt.NewRow
        dr("Column1") = If(IsNothing(oneAdjustment) = False, Staffs.selectOneWhereId(oneAdjustment.staffId).name, "")
        dt.Rows.Add(dr)

        '現場作業期間
        dr = dt.NewRow
        dr("Column1") = If(IsNothing(oneAdjustment) = False, oneAdjustment.fieldduration, "")
        dt.Rows.Add(dr)

        '社内作業期間
        dr = dt.NewRow
        dr("Column1") = If(IsNothing(oneAdjustment) = False, oneAdjustment.officeduration, "")
        dt.Rows.Add(dr)

        '現場
        dr = dt.NewRow
        dr("Column1") = If(IsNothing(oneAdjustment) = False, oneAdjustment.lacation, "")
        dt.Rows.Add(dr)

        '備考
        dr = dt.NewRow
        dr("Column1") = If(IsNothing(oneAdjustment) = False, oneAdjustment.note, "")
        dt.Rows.Add(dr)

        dgvAdjustment.DataSource = dt

        With dgvAdjustment
            Dim rowId As Integer = 0
            .Rows(rowId).HeaderCell.Value = "担当者"
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "現場作業期間"
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "社内作業期間"
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "現場"
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "備考"

            .AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)

        End With

    End Sub

    ''' <summary>
    ''' 他コントロールセット
    ''' </summary>
    Private Sub setOther()

        mitmAdd.Enabled = False
        mitmEdit.Enabled = True
        mitmDelete.Enabled = False

        dgvAnkenOrderRange.ReadOnly = True
        dgvAdjustment.ReadOnly = True

        btnOK.Enabled = False
        btnOK.Text = "更新"
        btnCancel.Text = "閉じる"

        Dim selectInfo As Anken = Ankens.selectOneWhereId(selectId)

        With selectInfo
            lblCode.Text = .code1 + .code2 + .code3
            lblName.Text = .name

            Dim selectedAnkenClient As Client = Clients.selectOneWhereId(.clientId)
            lblClient.Text = selectedAnkenClient.code + " | " + selectedAnkenClient.name
            lblSalesYearMonth.Text = Format(.salesYearMonth, "yyyy/MM")

        End With
    End Sub

    ''' <summary>
    ''' 入力した案件情報のチェック
    ''' </summary>
    ''' <returns></returns>
    Private Function check() As Boolean


        Return True

    End Function


End Class