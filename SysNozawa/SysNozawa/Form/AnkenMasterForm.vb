Imports System.ComponentModel

Public Class AnkenMasterForm

    Private inputType As New inputType
    Private selectId As Integer = 0

    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AnkenMasterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        inputType = inputType.non
        selectId = 0

        '従業員リストの表示
        setDgvAnken()

        '工番1のセット
        CommonSet.setCmbCode1(cmbCode1)

        '取引先のセット
        CommonSet.setCmbClient(cmbClient)

        '従業員のセット
        CommonSet.setCmbStaff(cmbStaff)

        '請求状況のセット
        CommonSet.setCmbStatus(cmbStatus)

        setOther()

    End Sub

    ''' <summary>
    ''' 案件選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvAnken_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAnken.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        mitmEdit.Enabled = True
        mitmDelete.Enabled = True
        selectId = dgvAnken.Rows(e.RowIndex).Cells("cId").Value

        Dim selectInfo As Anken = Ankens.selectOne(selectId)

        cmbCode1.SelectedItem = selectInfo.code1
        txtCode2.Text = selectInfo.code2
        txtCode3.Text = selectInfo.code3
        txtName.Text = selectInfo.name
        cmbClient.SelectedValue = selectInfo.clientId
        dtpSalesYearMonth.Value = selectInfo.salesYearMonth
        txtSalesAmount.Text = CDec(selectInfo.salesAmount).ToString("#,0")
        cmbStaff.SelectedValue = selectInfo.staffId
        cmbStatus.SelectedValue = selectInfo.status

    End Sub

    ''' <summary>
    ''' 新規追加クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mitmAdd_Click(sender As Object, e As EventArgs) Handles mitmAdd.Click

        inputType = inputType.insert

        mitmAdd.Enabled = False
        mitmEdit.Enabled = False
        mitmDelete.Enabled = False
        dgvAnken.Enabled = False

        cmbCode1.Enabled = True
        cmbCode1.SelectedItem = ""
        txtCode2.Enabled = True
        txtCode2.Text = ""
        txtCode3.Enabled = False
        txtCode3.Text = ""
        txtName.Enabled = True
        txtName.Text = ""
        cmbClient.Enabled = True
        cmbClient.SelectedIndex = 0
        dtpSalesYearMonth.Enabled = True
        dtpSalesYearMonth.Value = Now
        txtSalesAmount.Enabled = True
        txtSalesAmount.Text = ""
        cmbStaff.Enabled = True
        cmbStaff.SelectedIndex = 0
        cmbStatus.Enabled = True
        cmbStatus.SelectedIndex = 0


        btnOK.Enabled = True
        btnOK.Text = "追加"
        btnCancel.Text = "中止"

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
        dgvAnken.Enabled = False

        cmbCode1.Enabled = True
        txtCode2.Enabled = True
        txtCode3.Enabled = False
        txtName.Enabled = True
        cmbClient.Enabled = True
        dtpSalesYearMonth.Enabled = True
        txtSalesAmount.Enabled = True
        cmbStaff.Enabled = True
        cmbStatus.Enabled = True

        btnOK.Enabled = True
        btnOK.Text = "編集"
        btnCancel.Text = "中止"

    End Sub

    ''' <summary>
    ''' 削除クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mitmDelete_Click(sender As Object, e As EventArgs) Handles mitmDelete.Click

        If DialogResult.No = MessageBox.Show("削除します。よろしいですか？",
                                              "削除",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question
                                              ) Then
            Exit Sub

        End If

        inputType = inputType.delete

        If Ankens.delete(selectId) Then
            MessageBox.Show("削除しました。")
        Else
            MessageBox.Show("削除に失敗しました。")
        End If

        inputType = inputType.non
        selectId = 0

        setDgvAnken()

        setOther()

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

            If DialogResult.No = MessageBox.Show("追加します。よろしいですか？",
                                                 "追加",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question) Then
                Exit Sub

            End If

            Dim insertInfo As New Anken
            insertInfo.id = Ankens.getNewId()
            insertInfo.code1 = cmbCode1.Text
            insertInfo.code2 = txtCode2.Text
            insertInfo.code3 = txtCode3.Text
            insertInfo.name = txtName.Text
            insertInfo.clientId = cmbClient.SelectedValue
            insertInfo.clientCode = cmbClient.Text
            insertInfo.salesYearMonth = dtpSalesYearMonth.Value
            insertInfo.salesAmount = txtSalesAmount.Text
            insertInfo.staffId = cmbStaff.SelectedValue
            insertInfo.staffName = cmbStaff.Text
            insertInfo.status = cmbStatus.SelectedValue

            If Ankens.insert(insertInfo) Then
                MessageBox.Show("追加しました。")
            Else
                MessageBox.Show("追加に失敗しました。")
            End If

        ElseIf inputType = inputType.update Then '編集クリック

            If DialogResult.No = MessageBox.Show("編集します。よろしいですか？",
                                                 "編集",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question) Then
                Exit Sub

            End If

            Dim updateInfo As New Anken
            updateInfo.id = selectId
            updateInfo.code1 = cmbCode1.Text
            updateInfo.code2 = txtCode2.Text
            updateInfo.code3 = txtCode3.Text
            updateInfo.name = txtName.Text
            updateInfo.clientId = cmbClient.SelectedValue
            updateInfo.clientCode = cmbClient.SelectedText
            updateInfo.salesYearMonth = dtpSalesYearMonth.Value
            updateInfo.salesAmount = txtSalesAmount.Text
            updateInfo.staffId = cmbStaff.SelectedValue
            updateInfo.staffName = cmbStaff.SelectedText
            updateInfo.status = cmbStatus.SelectedValue


            If Ankens.update(updateInfo) Then
                MessageBox.Show("編集しました。")
            Else
                MessageBox.Show("編集に失敗しました。")
            End If

        Else

        End If

        inputType = inputType.non
        selectId = 0

        setDgvAnken()

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

            mitmAdd.Enabled = True
            mitmEdit.Enabled = False
            mitmDelete.Enabled = False
            dgvAnken.Enabled = True

            cmbCode1.Enabled = False
            cmbCode1.SelectedItem = ""
            txtCode2.Enabled = False
            txtCode2.Text = ""
            txtCode3.Enabled = False
            txtCode3.Text = ""
            txtName.Enabled = False
            txtName.Text = ""
            cmbClient.Enabled = False
            cmbClient.SelectedIndex = 0

            dtpSalesYearMonth.Enabled = False
            dtpSalesYearMonth.Value = Now
            txtSalesAmount.Enabled = False
            txtSalesAmount.Text = ""

            cmbStaff.Enabled = False
            cmbStaff.SelectedIndex = 0

            cmbStatus.Enabled = False
            cmbStatus.SelectedIndex = 0


            btnOK.Enabled = False
            btnOK.Text = "編集"
            btnCancel.Text = "閉じる"

        Else '閉じるクリック
            Me.Close()
        End If

    End Sub

    ''' <summary>
    ''' 工番1選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbCode1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCode1.SelectedIndexChanged

        If inputType = inputType.insert Then

            If cmbCode1.Text = "" Or txtCode2.Text = "" Then
                Exit Sub
            End If

            txtCode3.Text = Ankens.getNewCode3(txtCode2.Text).ToString("D2")

        End If

    End Sub

    ''' <summary>
    ''' 工番2入力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtCode2_TextChanged(sender As Object, e As EventArgs) Handles txtCode2.TextChanged

        If inputType = inputType.insert Then

            If cmbCode1.Text = "" Or txtCode2.Text = "" Then
                Exit Sub
            End If

            txtCode3.Text = Ankens.getNewCode3(txtCode2.Text).ToString("D2")

        End If

    End Sub

    ''' <summary>
    ''' 売上金額に金額入力のみ許可
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtSalesAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSalesAmount.KeyPress

        If (e.KeyChar < "0"c Or e.KeyChar > "9"c) _
         And e.KeyChar <> vbBack And e.KeyChar <> "." Then
            e.Handled = True
        End If

    End Sub

    ''' <summary>
    ''' 売上金額に3桁カンマ区切り
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtSalesAmount_Leave(sender As Object, e As EventArgs) Handles txtSalesAmount.Leave

        If IsNumeric(txtSalesAmount.Text) Then
            txtSalesAmount.Text = CDec(txtSalesAmount.Text).ToString("#,0")
        End If

    End Sub

    ''' <summary>
    ''' 売上金額の3桁カンマ区切り解除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtSalesAmount_Enter(sender As Object, e As EventArgs) Handles txtSalesAmount.Enter

        If IsNumeric(txtSalesAmount.Text) Then
            txtSalesAmount.Text = CDec(txtSalesAmount.Text)
        End If

    End Sub

    ''' <summary>
    ''' ×クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AnkenMasterForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

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
    ''' 従業員リストの表示
    ''' </summary>
    Private Sub setDgvAnken()

        '案件リスト
        dgvAnken.DataSource = Ankens.selectAll()



    End Sub

    Private Sub setOther()

        mitmAdd.Enabled = True
        mitmEdit.Enabled = False
        mitmDelete.Enabled = False
        dgvAnken.Enabled = True

        cmbCode1.Enabled = False
        cmbCode1.SelectedItem = ""
        txtCode2.Enabled = False
        txtCode2.Text = ""
        txtCode3.Enabled = False
        txtCode3.Text = ""
        txtName.Enabled = False
        txtName.Text = ""
        cmbClient.Enabled = False
        cmbClient.SelectedIndex = 0

        dtpSalesYearMonth.Enabled = False
        dtpSalesYearMonth.Value = Now
        txtSalesAmount.Enabled = False
        txtSalesAmount.Text = ""

        btnOK.Enabled = False
        btnOK.Text = "編集"
        btnCancel.Text = "閉じる"

    End Sub


    ''' <summary>
    ''' 入力した案件情報のチェック
    ''' </summary>
    ''' <returns></returns>
    Private Function check() As Boolean

        If inputType = inputType.insert And Ankens.getCountSameCode(cmbCode1.Text, txtCode2.Text, txtCode3.Text) Then
            MessageBox.Show("同一の工番がすでに存在します。")
            Return False
        End If

        If txtName.Text.Count = 0 Then
            MessageBox.Show("件名を入力してください。")
            Return False
        End If

        If cmbClient.Text.Count = 0 Then
            MessageBox.Show("取引先を正しく入力してください。")
            Return False
        End If

        If cmbStaff.Text.Count = 0 Then
            MessageBox.Show("作成者を正しく入力してください。")
            Return False
        End If

        Return True

    End Function


End Class