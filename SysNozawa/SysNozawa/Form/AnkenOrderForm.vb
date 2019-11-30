Public Class AnkenOrderForm

    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AnkenOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        setCmbSalesYearMonth()

        setDgvAnkenOrder()

    End Sub

    ''' <summary>
    ''' 表示売上年月変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbSalesYearMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSalesYearMonth.SelectedIndexChanged
        setDgvAnkenOrder()
    End Sub
    ''' <summary>
    ''' 案件受注リストの表示
    ''' </summary>
    Private Sub setDgvAnkenOrder()

        dgvAnkenOrder.DataSource = Nothing

        Dim dt As New DataTable
        Dim allAnken As New List(Of Anken)
        If cmbSalesYearMonth.Text.Count > 0 Then
            Dim salesYearMonth As Date = CDate(cmbSalesYearMonth.Text)
            allAnken = Ankens.selectSomeWhereSalesYearMonthForList(salesYearMonth.Year, salesYearMonth.Month)
        Else
            allAnken = Ankens.selectAllForList()
        End If

        For Each oneAnekn In allAnken

            Dim dc As New DataColumn
            dc.ColumnName = oneAnekn.id
            dc.Caption = oneAnekn.id
            dt.Columns.Add(dc)

        Next

        '工番
        Dim dr As DataRow = dt.NewRow
        For Each oneAnekn In allAnken
            dr(oneAnekn.id.ToString) = oneAnekn.code1 + oneAnekn.code2 + oneAnekn.code3
        Next
        dt.Rows.Add(dr)

        '件名
        dr = dt.NewRow
        For Each oneAnekn In allAnken
            dr(oneAnekn.id.ToString) = oneAnekn.name
        Next
        dt.Rows.Add(dr)

        '取引先
        dr = dt.NewRow
        For Each oneAnekn In allAnken
            dr(oneAnekn.id.ToString) = Clients.selectOneWhereId(oneAnekn.clientId).code
        Next
        dt.Rows.Add(dr)

        '売上年月
        dr = dt.NewRow
        For Each oneAnekn In allAnken
            dr(oneAnekn.id.ToString) = Format(oneAnekn.salesYearMonth, "yyyy/MM")
        Next
        dt.Rows.Add(dr)

        '受注範囲
        Dim drs As New List(Of DataRow)
        For i As Integer = 0 To 9
            dr = dt.NewRow
            drs.Add(dr)
        Next

        For Each oneAnekn In allAnken
            Dim allAnkenOrderRange As List(Of AnkenOrderRange) = AnkenOrderRanges.selectSomeWhereAnkenId(oneAnekn.id)

            Dim i As Integer = 0
            For Each oneAnkenOrderRange In allAnkenOrderRange
                drs(i)(oneAnekn.id.ToString) = oneAnkenOrderRange.name
                i = i + 1
            Next

        Next
        For Each dr In drs
            dt.Rows.Add(dr)
        Next

        '調整
        drs = New List(Of DataRow)
        For i As Integer = 0 To 5
            dr = dt.NewRow
            drs.Add(dr)
        Next

        For Each oneAnekn In allAnken
            Dim oneAdjustment As Adjustment = Adjustments.selectOneWhereAnkenId(oneAnekn.id)

            If IsNothing(oneAdjustment) = False Then
                ''
                Dim i As Integer = 0

                drs(i)(oneAnekn.id.ToString) = ""
                i = i + 1
                drs(i)(oneAnekn.id.ToString) = Staffs.selectOneWhereId(oneAdjustment.staffId).name
                i = i + 1
                drs(i)(oneAnekn.id.ToString) = oneAdjustment.fieldduration
                i = i + 1
                drs(i)(oneAnekn.id.ToString) = oneAdjustment.officeduration
                i = i + 1
                drs(i)(oneAnekn.id.ToString) = oneAdjustment.lacation
                i = i + 1
                drs(i)(oneAnekn.id.ToString) = oneAdjustment.note
            End If

        Next
        For Each dr In drs
            dt.Rows.Add(dr)
        Next

        dgvAnkenOrder.DataSource = dt

        With dgvAnkenOrder
            Dim rowId As Integer = 0
            .Rows(rowId).HeaderCell.Value = "工番"
            .Rows(rowId).DefaultCellStyle.BackColor = SystemColors.Highlight
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "件名"
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "取引先"
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "売上年月"
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "受注範囲"
            rowId = rowId + 10
            .Rows(rowId).HeaderCell.Value = "調整"
            .Rows(rowId).DefaultCellStyle.BackColor = SystemColors.Highlight
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "  担当者"
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "  現場作業期間"
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "  社内作業期間"
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "  現場"
            rowId = rowId + 1
            .Rows(rowId).HeaderCell.Value = "  備考"
            'rowId = rowId + 1
            '.Rows(rowId).HeaderCell.Value = "現場作業期間"


            .AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)

        End With

    End Sub

    ''' <summary>
    ''' 売上年月のセット
    ''' </summary>
    Private Sub setCmbSalesYearMonth()

        cmbSalesYearMonth.Items.Clear()
        Dim salesYearMonths As List(Of String) = Ankens.getAllSalesYearMonth()

        cmbSalesYearMonth.Items.Add("")
        For Each salesYearMonth In salesYearMonths
            cmbSalesYearMonth.Items.Add(salesYearMonth)
        Next

    End Sub

End Class