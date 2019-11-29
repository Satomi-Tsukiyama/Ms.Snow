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

        'Dim datatable As DataTable
        'DataTable = Nothing
        'DataTable.Rows(0).he
        'dgvAnkenOrder.DataSource = DataTable
        dgvAnkenOrder.DataSource = Nothing
        'dgvAnkenOrder.DataSource = Ankens.selectAllForDataTable()

        Dim dt As New DataTable
        Dim allAnken As New List(Of Anken)
        If cmbSalesYearMonth.Text.Count > 0 Then
            Dim salesYearMonth As Date = CDate(cmbSalesYearMonth.Text)
            allAnken = Ankens.selectWhereSalesYearMonthForList(salesYearMonth.Year, salesYearMonth.Month)
        Else
            allAnken = Ankens.selectAllForList()
        End If


        For Each oneAnekn In allAnken

            Dim dc As New DataColumn
            dc.ColumnName = oneAnekn.code1 + oneAnekn.code2 + oneAnekn.code3 + ":" + oneAnekn.name '件名
            dc.Caption = oneAnekn.id
            dt.Columns.Add(dc)

            'dt.Rows.Add()
            'dt.Rows(0).Item(oneAnekn.id) = oneAnekn.code1 + oneAnekn.code2 + oneAnekn.code3 '工番
            'dt.Rows.Add()
            'dt.Rows(1).Item(oneAnekn.id) = oneAnekn.salesYearMonth '売上年月


            'Dim allAnkenOrderRange As List(Of AnkenOrderRange) = AnkenOrderRanges.selectWhereAnkenId(oneAnekn.id)
            'For Each oneAnkenOrderRange In allAnkenOrderRange
            '    dt.Rows(0).Item(oneAnekn.id) = oneAnkenOrderRange.name
            'Next

        Next

        dgvAnkenOrder.DataSource = dt

        'With dgvAnkenOrder

        '    .Rows(0).HeaderCell.Value = "工番"
        '    .Rows(1).HeaderCell.Value = "取引先"
        '    .Rows(2).HeaderCell.Value = "売上年月"
        '    .Rows(3).HeaderCell.Value = "受注範囲"
        '    .Rows(4).HeaderCell.Value = ""
        '    .AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)

        'End With

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