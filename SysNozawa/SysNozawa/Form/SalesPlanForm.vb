Imports System.ComponentModel

Public Class SalesPlanForm

    Private inputType As New inputType
    Private selectId As Integer = 0
    Private selectDataGridView As DataGridView

    Private lblMonths As Label()
    Private cmbClients As ComboBox()
    Private dgvSalesPlans As DataGridView()
    Private dgvElseSalesPlans As DataGridView()

    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SalesPlanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblMonths = {lblMonth1, lblMonth2, lblMonth3, lblMonth4, lblMonth5, lblMonth6}

        cmbClients = {cmbClient1, cmbClient2, cmbClient3, cmbClient4, cmbClient5, cmbClient6}

        dgvSalesPlans = {
        dgvRow1Column1, dgvRow1Column2, dgvRow1Column3, dgvRow1Column4, dgvRow1Column5, dgvRow1Column6,
        dgvRow2Column1, dgvRow2Column2, dgvRow2Column3, dgvRow2Column4, dgvRow2Column5, dgvRow2Column6,
        dgvRow3Column1, dgvRow3Column2, dgvRow3Column3, dgvRow3Column4, dgvRow3Column5, dgvRow3Column6,
        dgvRow4Column1, dgvRow4Column2, dgvRow4Column3, dgvRow4Column4, dgvRow4Column5, dgvRow4Column6,
        dgvRow5Column1, dgvRow5Column2, dgvRow5Column3, dgvRow5Column4, dgvRow5Column5, dgvRow5Column6,
        dgvRow6Column1, dgvRow6Column2, dgvRow6Column3, dgvRow6Column4, dgvRow6Column5, dgvRow6Column6}

        dgvElseSalesPlans = {
        dgvRow7Column1, dgvRow7Column2, dgvRow7Column3, dgvRow7Column4, dgvRow7Column5, dgvRow7Column6}

        setCmbClients()

        setDudSemester()

        mitmAdd.Enabled = False
        mitmEdit.Enabled = False
        mitmDelete.Enabled = False

    End Sub

    Private Sub SalesPlanForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        setDgvSalesPlans()
    End Sub

    Private Sub dtpDisplayYear_ValueChanged(sender As Object, e As EventArgs) Handles dtpDisplayYear.ValueChanged
        setDgvSalesPlans()
    End Sub

    Private Sub dudSemester_SelectedItemChanged(sender As Object, e As EventArgs) Handles dudSemester.SelectedItemChanged
        setDgvSalesPlans()
    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _
        cmbClient1.SelectedIndexChanged, cmbClient2.SelectedIndexChanged, cmbClient3.SelectedIndexChanged, cmbClient4.SelectedIndexChanged, cmbClient5.SelectedIndexChanged, cmbClient6.SelectedIndexChanged
        setDgvSalesPlans()
    End Sub

    Private Sub dgvSalesPlans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles _
            dgvRow1Column1.CellClick, dgvRow1Column2.CellClick, dgvRow1Column3.CellClick, dgvRow1Column4.CellClick, dgvRow1Column5.CellClick, dgvRow1Column6.CellClick,
            dgvRow2Column1.CellClick, dgvRow2Column2.CellClick, dgvRow2Column3.CellClick, dgvRow2Column4.CellClick, dgvRow2Column5.CellClick, dgvRow2Column6.CellClick,
            dgvRow3Column1.CellClick, dgvRow3Column2.CellClick, dgvRow3Column3.CellClick, dgvRow3Column4.CellClick, dgvRow3Column5.CellClick, dgvRow3Column6.CellClick,
            dgvRow4Column1.CellClick, dgvRow4Column2.CellClick, dgvRow4Column3.CellClick, dgvRow4Column4.CellClick, dgvRow4Column5.CellClick, dgvRow4Column6.CellClick,
            dgvRow5Column1.CellClick, dgvRow5Column2.CellClick, dgvRow5Column3.CellClick, dgvRow5Column4.CellClick, dgvRow5Column5.CellClick, dgvRow5Column6.CellClick,
            dgvRow6Column1.CellClick, dgvRow6Column2.CellClick, dgvRow6Column3.CellClick, dgvRow6Column4.CellClick, dgvRow6Column5.CellClick, dgvRow6Column6.CellClick,
            dgvRow7Column1.CellClick, dgvRow7Column2.CellClick, dgvRow7Column3.CellClick, dgvRow7Column4.CellClick, dgvRow7Column5.CellClick, dgvRow7Column6.CellClick

        Dim dgvSalesPlan As DataGridView = sender
        selectId = dgvSalesPlan.Rows(e.RowIndex).Cells(0).Value

    End Sub

    Private Sub dgvSalesPlans_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles _
            dgvRow1Column1.CellContentDoubleClick, dgvRow1Column2.CellContentDoubleClick, dgvRow1Column3.CellContentDoubleClick, dgvRow1Column4.CellContentDoubleClick, dgvRow1Column5.CellContentDoubleClick, dgvRow1Column6.CellContentDoubleClick,
            dgvRow2Column1.CellContentDoubleClick, dgvRow2Column2.CellContentDoubleClick, dgvRow2Column3.CellContentDoubleClick, dgvRow2Column4.CellContentDoubleClick, dgvRow2Column5.CellContentDoubleClick, dgvRow2Column6.CellContentDoubleClick,
            dgvRow3Column1.CellContentDoubleClick, dgvRow3Column2.CellContentDoubleClick, dgvRow3Column3.CellContentDoubleClick, dgvRow3Column4.CellContentDoubleClick, dgvRow3Column5.CellContentDoubleClick, dgvRow3Column6.CellContentDoubleClick,
            dgvRow4Column1.CellContentDoubleClick, dgvRow4Column2.CellContentDoubleClick, dgvRow4Column3.CellContentDoubleClick, dgvRow4Column4.CellContentDoubleClick, dgvRow4Column5.CellContentDoubleClick, dgvRow4Column6.CellContentDoubleClick,
            dgvRow5Column1.CellContentDoubleClick, dgvRow5Column2.CellContentDoubleClick, dgvRow5Column3.CellContentDoubleClick, dgvRow5Column4.CellContentDoubleClick, dgvRow5Column5.CellContentDoubleClick, dgvRow5Column6.CellContentDoubleClick,
            dgvRow6Column1.CellContentDoubleClick, dgvRow6Column2.CellContentDoubleClick, dgvRow6Column3.CellContentDoubleClick, dgvRow6Column4.CellContentDoubleClick, dgvRow6Column5.CellContentDoubleClick, dgvRow6Column6.CellContentDoubleClick,
            dgvRow7Column1.CellContentDoubleClick, dgvRow7Column2.CellContentDoubleClick, dgvRow7Column3.CellContentDoubleClick, dgvRow7Column4.CellContentDoubleClick, dgvRow7Column5.CellContentDoubleClick, dgvRow7Column6.CellContentDoubleClick

        Dim dgvSalesPlan As DataGridView = sender
        selectId = dgvSalesPlan.Rows(e.RowIndex).Cells(0).Value

        Dim childrenForm As New AnkenEditForm
        childrenForm.selectId = selectId
        childrenForm.ShowDialog()

        setDgvSalesPlans()

    End Sub

    Private Sub dgv_SalesPlans_RowContextMenuStripNeeded(sender As Object, e As DataGridViewRowContextMenuStripNeededEventArgs) Handles _
        dgvRow1Column1.RowContextMenuStripNeeded, dgvRow1Column2.RowContextMenuStripNeeded, dgvRow1Column3.RowContextMenuStripNeeded, dgvRow1Column4.RowContextMenuStripNeeded, dgvRow1Column5.RowContextMenuStripNeeded, dgvRow1Column6.RowContextMenuStripNeeded,
        dgvRow2Column1.RowContextMenuStripNeeded, dgvRow2Column2.RowContextMenuStripNeeded, dgvRow2Column3.RowContextMenuStripNeeded, dgvRow2Column4.RowContextMenuStripNeeded, dgvRow2Column5.RowContextMenuStripNeeded, dgvRow2Column6.RowContextMenuStripNeeded,
        dgvRow3Column1.RowContextMenuStripNeeded, dgvRow3Column2.RowContextMenuStripNeeded, dgvRow3Column3.RowContextMenuStripNeeded, dgvRow3Column4.RowContextMenuStripNeeded, dgvRow3Column5.RowContextMenuStripNeeded, dgvRow3Column6.RowContextMenuStripNeeded,
        dgvRow4Column1.RowContextMenuStripNeeded, dgvRow4Column2.RowContextMenuStripNeeded, dgvRow4Column3.RowContextMenuStripNeeded, dgvRow4Column4.RowContextMenuStripNeeded, dgvRow4Column5.RowContextMenuStripNeeded, dgvRow4Column6.RowContextMenuStripNeeded,
        dgvRow5Column1.RowContextMenuStripNeeded, dgvRow5Column2.RowContextMenuStripNeeded, dgvRow5Column3.RowContextMenuStripNeeded, dgvRow5Column4.RowContextMenuStripNeeded, dgvRow5Column5.RowContextMenuStripNeeded, dgvRow5Column6.RowContextMenuStripNeeded,
        dgvRow6Column1.RowContextMenuStripNeeded, dgvRow6Column2.RowContextMenuStripNeeded, dgvRow6Column3.RowContextMenuStripNeeded, dgvRow6Column4.RowContextMenuStripNeeded, dgvRow6Column5.RowContextMenuStripNeeded, dgvRow6Column6.RowContextMenuStripNeeded,
        dgvRow7Column1.RowContextMenuStripNeeded, dgvRow7Column2.RowContextMenuStripNeeded, dgvRow7Column3.RowContextMenuStripNeeded, dgvRow7Column4.RowContextMenuStripNeeded, dgvRow7Column5.RowContextMenuStripNeeded, dgvRow7Column6.RowContextMenuStripNeeded

        selectDataGridView = sender
        selectId = selectDataGridView.CurrentRow.Cells(0).Value
        e.ContextMenuStrip = cmsStatusChange

    End Sub

    Private Sub SalesPlanForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

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

        'コントロール設定を保存
        My.Settings.SalesPlanForm_cmbClient1_SelectedIndex = cmbClient1.SelectedValue
        My.Settings.SalesPlanForm_cmbClient2_SelectedIndex = cmbClient2.SelectedValue
        My.Settings.SalesPlanForm_cmbClient3_SelectedIndex = cmbClient3.SelectedValue
        My.Settings.SalesPlanForm_cmbClient4_SelectedIndex = cmbClient4.SelectedValue
        My.Settings.SalesPlanForm_cmbClient5_SelectedIndex = cmbClient5.SelectedValue
        My.Settings.SalesPlanForm_cmbClient6_SelectedIndex = cmbClient6.SelectedValue

        My.Settings.Save()

    End Sub

    Private Sub setDudSemester()

        dudSemester.Items.Clear()
        dudSemester.Items.Add("前期")
        dudSemester.Items.Add("後期")

        dtpDisplayYear.Value = Now
        Select Case Now.Month
            Case 6, 7, 8, 9, 10, 11
                dudSemester.SelectedIndex = 0
            Case Else
                dudSemester.SelectedIndex = 1

        End Select

    End Sub

    Private Sub setCmbClients()

        For Each cmbClient In cmbClients

            Dim ds As DataTable = Clients.selectAll()
            Dim dr As DataRow = ds.NewRow
            dr("cId") = 0
            ds.Rows.InsertAt(dr, 0)
            cmbClient.DataSource = ds

            cmbClient.ValueMember = "cId"
            cmbClient.DisplayMember = "cCode"

            cmbClient.Enabled = True

        Next

        cmbClient1.SelectedValue = My.Settings.SalesPlanForm_cmbClient1_SelectedIndex
        cmbClient2.SelectedValue = My.Settings.SalesPlanForm_cmbClient2_SelectedIndex
        cmbClient3.SelectedValue = My.Settings.SalesPlanForm_cmbClient3_SelectedIndex
        cmbClient4.SelectedValue = My.Settings.SalesPlanForm_cmbClient4_SelectedIndex
        cmbClient5.SelectedValue = My.Settings.SalesPlanForm_cmbClient5_SelectedIndex
        cmbClient6.SelectedValue = My.Settings.SalesPlanForm_cmbClient6_SelectedIndex

    End Sub

    Private Sub setLblSemesters()
        Select Case dudSemester.Text
            Case "前期"
                lblMonth1.Text = 6
                lblMonth2.Text = 7
                lblMonth3.Text = 8
                lblMonth4.Text = 9
                lblMonth5.Text = 10
                lblMonth6.Text = 11
            Case Else
                lblMonth1.Text = 12
                lblMonth2.Text = 1
                lblMonth3.Text = 2
                lblMonth4.Text = 3
                lblMonth5.Text = 4
                lblMonth6.Text = 5
        End Select
    End Sub

    Private Sub setDgvSalesPlans()

        setLblSemesters()

        If IsNothing(cmbClients) Then
            Exit Sub
        End If

        Dim year As Integer = dtpDisplayYear.Value.Year
        Dim month As Integer = lblMonths(0).Text

        For i As Integer = 0 To cmbClients.Count - 1

            year = dtpDisplayYear.Value.Year
            month = lblMonths(0).Text

            Dim cmbClient As ComboBox = cmbClients(i)

            If cmbClient.SelectedIndex > 0 Then

                For j As Integer = 0 To 5
                    dgvSalesPlans(6 * i + j).DataSource = Ankens.selectWhereClientAndSalesYearMonth(cmbClient.SelectedIndex, year, month)

                    month = month + 1
                    If month > 12 Then
                        year = year + 1
                        month = 1
                    End If
                Next

            Else '空白選択時

                For j As Integer = 0 To 5
                    dgvSalesPlans(6 * i + j).DataSource = Nothing
                Next

            End If

            For j As Integer = 0 To 5
                CommonSet.setDgvAnken_BackColor(dgvSalesPlans(6 * i + j))
            Next

        Next

        'year = dtpDisplayYear.Value.Year
        'month = lblMonths(0).Text

        ''その他の案件行
        'For Each dgvElseSalesPlan In dgvElseSalesPlans

        '    Dim selectedIndexs As New List(Of Integer)
        '    For Each cmbClient_ver2 In cmbClients
        '        If cmbClient_ver2.SelectedIndex > 0 Then
        '            selectedIndexs.Add(cmbClient_ver2.SelectedIndex)
        '        End If
        '    Next

        '    dgvElseSalesPlan.DataSource = Ankens.selectWhereElseClientAndSalesYearMonth(selectedIndexs, year, month)

        '    month = month + 1
        '    If month > 12 Then
        '        year = year + 1
        '        month = 1
        '    End If


        '    For j As Integer = 0 To 5
        '        CommonSet.setDgvAnken_BackColor(dgvElseSalesPlan)
        '    Next

        'Next

    End Sub

    Private Sub tsmi_Click(sender As Object, e As EventArgs) Handles _
        tsmiNoPlan.Click, tsmiEstimating.Click, tsmiDecided.Click, tsmiInvoiced.Click, tsmiCancel.Click

        Dim tsmi As ToolStripMenuItem = sender

        Select Case tsmi.Text
            Case "未定"
                Ankens.updateStatus(selectId, AnkenStatus.NoPlan)
            Case "見積中"
                Ankens.updateStatus(selectId, AnkenStatus.Estimating)
            Case "決定"
                Ankens.updateStatus(selectId, AnkenStatus.Decided)
            Case "請求済"
                Ankens.updateStatus(selectId, AnkenStatus.Invoiced)
            Case "取消"
                Ankens.updateStatus(selectId, AnkenStatus.Cancel)
        End Select

        setDgvSalesPlans()

    End Sub

    ''' <summary>
    ''' 前へボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnPre_Click(sender As Object, e As EventArgs) Handles btnPre.Click
        If dudSemester.Text = "前期" Then
            dudSemester.Text = "後期"
            dtpDisplayYear.Value = dtpDisplayYear.Value.AddYears(-1)
        Else
            dudSemester.Text = "前期"
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If dudSemester.Text = "前期" Then
            dudSemester.Text = "後期"
        Else
            dudSemester.Text = "前期"
            dtpDisplayYear.Value = dtpDisplayYear.Value.AddYears(1)
        End If
    End Sub
End Class