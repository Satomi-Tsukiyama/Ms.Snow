Imports System.ComponentModel

Public Class SalesPlanForm

    Private inputType As New inputType
    Private selectId As Integer = 0
    Private selectRow As DataGridViewRow

    Private lblMonths As Label()
    Private cmbClients As ComboBox()
    Private dgvSalesPlans As DataGridView()

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

        setCmbClients()

        setDudSemester()

    End Sub

    Private Sub dtpDisplayYear_ValueChanged(sender As Object, e As EventArgs) Handles dtpDisplayYear.ValueChanged
        setDgvSalesPlans()
    End Sub

    Private Sub dudSemester_SelectedItemChanged(sender As Object, e As EventArgs) Handles dudSemester.SelectedItemChanged
        setDgvSalesPlans()
    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient1.SelectedIndexChanged, cmbClient2.SelectedIndexChanged, cmbClient3.SelectedIndexChanged, cmbClient4.SelectedIndexChanged
        setDgvSalesPlans()
    End Sub

    Private Sub dgvSalesPlans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles _
            dgvRow1Column1.CellClick, dgvRow1Column2.CellClick, dgvRow1Column3.CellClick, dgvRow1Column4.CellClick, dgvRow1Column5.CellClick, dgvRow1Column6.CellClick,
            dgvRow2Column1.CellClick, dgvRow2Column2.CellClick, dgvRow2Column3.CellClick, dgvRow2Column4.CellClick, dgvRow2Column5.CellClick, dgvRow2Column6.CellClick,
            dgvRow3Column1.CellClick, dgvRow3Column2.CellClick, dgvRow3Column3.CellClick, dgvRow3Column4.CellClick, dgvRow3Column5.CellClick, dgvRow3Column6.CellClick,
            dgvRow4Column1.CellClick, dgvRow4Column2.CellClick, dgvRow4Column3.CellClick, dgvRow4Column4.CellClick, dgvRow4Column5.CellClick, dgvRow4Column6.CellClick,
            dgvRow5Column1.CellClick, dgvRow5Column2.CellClick, dgvRow5Column3.CellClick, dgvRow5Column4.CellClick, dgvRow5Column5.CellClick, dgvRow5Column6.CellClick,
            dgvRow6Column1.CellClick, dgvRow6Column2.CellClick, dgvRow6Column3.CellClick, dgvRow6Column4.CellClick, dgvRow6Column5.CellClick, dgvRow6Column6.CellClick

        Dim dgvSalesPlan As DataGridView = sender
        selectRow = dgvSalesPlan.Rows(e.RowIndex)
        selectId = dgvSalesPlan.Rows(e.RowIndex).Cells(0).Value


    End Sub

    Private Sub dgvSalesPlans_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles _
            dgvRow1Column1.CellContentDoubleClick, dgvRow1Column2.CellContentDoubleClick, dgvRow1Column3.CellContentDoubleClick, dgvRow1Column4.CellContentDoubleClick, dgvRow1Column5.CellContentDoubleClick, dgvRow1Column6.CellContentDoubleClick,
            dgvRow2Column1.CellContentDoubleClick, dgvRow2Column2.CellContentDoubleClick, dgvRow2Column3.CellContentDoubleClick, dgvRow2Column4.CellContentDoubleClick, dgvRow2Column5.CellContentDoubleClick, dgvRow2Column6.CellContentDoubleClick,
            dgvRow3Column1.CellContentDoubleClick, dgvRow3Column2.CellContentDoubleClick, dgvRow3Column3.CellContentDoubleClick, dgvRow3Column4.CellContentDoubleClick, dgvRow3Column5.CellContentDoubleClick, dgvRow3Column6.CellContentDoubleClick,
            dgvRow4Column1.CellContentDoubleClick, dgvRow4Column2.CellContentDoubleClick, dgvRow4Column3.CellContentDoubleClick, dgvRow4Column4.CellContentDoubleClick, dgvRow4Column5.CellContentDoubleClick, dgvRow4Column6.CellContentDoubleClick,
            dgvRow5Column1.CellContentDoubleClick, dgvRow5Column2.CellContentDoubleClick, dgvRow5Column3.CellContentDoubleClick, dgvRow5Column4.CellContentDoubleClick, dgvRow5Column5.CellContentDoubleClick, dgvRow5Column6.CellContentDoubleClick,
            dgvRow6Column1.CellContentDoubleClick, dgvRow6Column2.CellContentDoubleClick, dgvRow6Column3.CellContentDoubleClick, dgvRow6Column4.CellContentDoubleClick, dgvRow6Column5.CellContentDoubleClick, dgvRow6Column6.CellContentDoubleClick


        Dim dgvSalesPlan As DataGridView = sender
        selectRow = dgvSalesPlan.Rows(e.RowIndex)
        selectId = dgvSalesPlan.Rows(e.RowIndex).Cells(0).Value

        Dim childrenForm As New AnkenEditForm
        childrenForm.selectId = selectId
        childrenForm.ShowDialog()

        setDgvSalesPlans()

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

        For i As Integer = 0 To cmbClients.Count - 1

            Dim cmbClient As ComboBox = cmbClients(i)
            If cmbClient.SelectedIndex > 0 Then

                dgvSalesPlans(6 * i + 0).DataSource = Ankens.selectWhereClientAndSalesYearMonth(cmbClient.SelectedIndex, dtpDisplayYear.Value.Year, lblMonths(0).Text)
                dgvSalesPlans(6 * i + 1).DataSource = Ankens.selectWhereClientAndSalesYearMonth(cmbClient.SelectedIndex, dtpDisplayYear.Value.Year, lblMonths(1).Text)
                dgvSalesPlans(6 * i + 2).DataSource = Ankens.selectWhereClientAndSalesYearMonth(cmbClient.SelectedIndex, dtpDisplayYear.Value.Year, lblMonths(2).Text)
                dgvSalesPlans(6 * i + 3).DataSource = Ankens.selectWhereClientAndSalesYearMonth(cmbClient.SelectedIndex, dtpDisplayYear.Value.Year, lblMonths(3).Text)
                dgvSalesPlans(6 * i + 4).DataSource = Ankens.selectWhereClientAndSalesYearMonth(cmbClient.SelectedIndex, dtpDisplayYear.Value.Year, lblMonths(4).Text)
                dgvSalesPlans(6 * i + 5).DataSource = Ankens.selectWhereClientAndSalesYearMonth(cmbClient.SelectedIndex, dtpDisplayYear.Value.Year, lblMonths(5).Text)

            Else '空白選択時　他のをすべて表示

                Dim selectedIndexs As New List(Of Integer)
                For Each cmbClient_ver2 In cmbClients
                    If cmbClient_ver2.SelectedIndex > 0 Then
                        selectedIndexs.Add(cmbClient_ver2.SelectedIndex)
                    End If
                Next

                dgvSalesPlans(6 * i + 0).DataSource = Ankens.selectWhereElseClientAndSalesYearMonth(selectedIndexs, dtpDisplayYear.Value.Year, lblMonths(0).Text)
                dgvSalesPlans(6 * i + 1).DataSource = Ankens.selectWhereElseClientAndSalesYearMonth(selectedIndexs, dtpDisplayYear.Value.Year, lblMonths(1).Text)
                dgvSalesPlans(6 * i + 2).DataSource = Ankens.selectWhereElseClientAndSalesYearMonth(selectedIndexs, dtpDisplayYear.Value.Year, lblMonths(2).Text)
                dgvSalesPlans(6 * i + 3).DataSource = Ankens.selectWhereElseClientAndSalesYearMonth(selectedIndexs, dtpDisplayYear.Value.Year, lblMonths(3).Text)
                dgvSalesPlans(6 * i + 4).DataSource = Ankens.selectWhereElseClientAndSalesYearMonth(selectedIndexs, dtpDisplayYear.Value.Year, lblMonths(4).Text)
                dgvSalesPlans(6 * i + 5).DataSource = Ankens.selectWhereElseClientAndSalesYearMonth(selectedIndexs, dtpDisplayYear.Value.Year, lblMonths(5).Text)


            End If
        Next
    End Sub


End Class