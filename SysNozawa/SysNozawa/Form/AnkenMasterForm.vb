Imports System.ComponentModel

Public Class AnkenMasterForm

    Private inputType As New inputType
    Private selectId As Integer = 0
    Private editCode3Flg As Boolean = False

    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AnkenMasterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        inputType = inputType.non
        selectId = 0

        '工番2のセット
        setCmbCode2()

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
    ''' 検索工番の変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbCode2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCode2.SelectedIndexChanged
        setDgvAnken()
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

        Dim selectInfo As Anken = Ankens.selectOneWhereId(selectId)

        With selectInfo
            cmbCode1.SelectedItem = .code1
            txtCode2.Text = .code2
            txtCode3.Text = .code3
            txtName.Text = .name
            cmbClient.SelectedValue = .clientId
            dtpSalesYearMonth.Value = .salesYearMonth
            txtSalesAmount.Text = CDec(.salesAmount).ToString("#,0")
            cmbStaff.SelectedValue = .staffId
            cmbStatus.SelectedValue = .status
        End With

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
        btnEditCode3.Enabled = True
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

        '工番1を選択中
        cmbCode1.Select()

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
        btnEditCode3.Enabled = True
        txtCode3.Enabled = False
        txtName.Enabled = True
        cmbClient.Enabled = True
        dtpSalesYearMonth.Enabled = True
        txtSalesAmount.Enabled = True
        cmbStaff.Enabled = True
        cmbStatus.Enabled = True

        btnOK.Enabled = True
        btnOK.Text = "更新"
        btnCancel.Text = "中止"

        '工番1を選択中
        cmbCode1.Select()

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
            Exit Sub
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

            With insertInfo
                .id = Ankens.getNewId()
                .code1 = cmbCode1.Text
                .code2 = txtCode2.Text
                .code3 = txtCode3.Text
                .name = txtName.Text
                .clientId = cmbClient.SelectedValue
                .clientCode = cmbClient.Text
                .salesYearMonth = dtpSalesYearMonth.Value.AddDays((-1) * (dtpSalesYearMonth.Value.Day - 1))
                If txtSalesAmount.Text.Count > 0 Then
                    .salesAmount = txtSalesAmount.Text
                Else
                    .salesAmount = 0
                End If
                .staffId = cmbStaff.SelectedValue
                .staffName = cmbStaff.Text
                .status = cmbStatus.SelectedValue
            End With


            If Ankens.insert(insertInfo) Then
                MessageBox.Show("追加しました。")
            Else
                MessageBox.Show("追加に失敗しました。")
                Exit Sub
            End If

        ElseIf inputType = inputType.update Then '編集クリック

            If DialogResult.No = MessageBox.Show("編集します。よろしいですか？",
                                                 "更新",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question) Then
                Exit Sub

            End If

            Dim updateInfo As New Anken

            With updateInfo
                .id = selectId
                .code1 = cmbCode1.Text
                .code2 = txtCode2.Text
                .code3 = txtCode3.Text
                .name = txtName.Text
                .clientId = cmbClient.SelectedValue
                .clientCode = cmbClient.SelectedText
                .salesYearMonth = dtpSalesYearMonth.Value.AddDays((-1) * (dtpSalesYearMonth.Value.Day - 1))
                .salesAmount = txtSalesAmount.Text
                .staffId = cmbStaff.SelectedValue
                .staffName = cmbStaff.SelectedText
                .status = cmbStatus.SelectedValue
            End With

            If Ankens.update(updateInfo) Then
                MessageBox.Show("編集しました。")
            Else
                MessageBox.Show("編集に失敗しました。")
                Exit Sub
            End If

        Else

        End If

        inputType = inputType.non
        selectId = 0

        setCmbCode2()

        setDgvAnken()

        setOther()

        '新規追加ボタン選択中
        mitmAdd.Select()

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
            btnEditCode3.Enabled = False
            btnEditCode3.Text = "連番編集"
            txtCode3.ReadOnly = True
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
            btnOK.Text = "更新"
            btnCancel.Text = "閉じる"

            '新規追加ボタン選択中
            mitmAdd.Select()

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

        If cmbCode1.Text = "" Then
            Exit Sub
        End If

        txtCode3.Text = Ankens.getNewCode3(txtCode2.Text).ToString("D2")

    End Sub

    ''' <summary>
    ''' 工番2入力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtCode2_TextChanged(sender As Object, e As EventArgs) Handles txtCode2.TextChanged

        If cmbCode1.Text = "" Or txtCode2.Text = "" Then
            Exit Sub
        End If

        txtCode3.Text = Ankens.getNewCode3(txtCode2.Text).ToString("D2")

    End Sub

    ''' <summary>
    ''' 工番3入力許可
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnEditCode3_Click(sender As Object, e As EventArgs) Handles btnEditCode3.Click

        If editCode3Flg Then

            txtCode3.ReadOnly = True
            txtCode3.Enabled = False
            If cmbCode1.Text = "" Or txtCode2.Text = "" Then
                txtCode3.Text = ""
            Else
                txtCode3.Text = Ankens.getNewCode3(txtCode2.Text).ToString("D2")
            End If

            editCode3Flg = False
            btnEditCode3.Text = "連番編集"

        Else

            txtCode3.ReadOnly = False
            txtCode3.Enabled = True

            editCode3Flg = True
            btnEditCode3.Text = "連番自動"

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
    ''' フォームクローズ
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
    ''' 工番2のセット
    ''' </summary>
    Private Sub setCmbCode2()

        cmbCode2.Items.Clear()
        Dim code2s As List(Of String) = Ankens.getAllCode2()

        cmbCode2.Items.Add("")
        For Each code2 In code2s
            cmbCode2.Items.Add(code2)
        Next

    End Sub

    ''' <summary>
    ''' 従業員リストの表示
    ''' </summary>
    Private Sub setDgvAnken()

        If cmbCode2.Text.Count > 0 Then
            '案件リスト
            dgvAnken.DataSource = Ankens.selectSomeWhereCode2(cmbCode2.Text)
        Else
            '案件リスト
            dgvAnken.DataSource = Ankens.selectAllForDataTable()
        End If

        '背景色設定
        CommonSet.setDgvAnken_BackColor(dgvAnken)

    End Sub

    ''' <summary>
    ''' 他コントロールセット
    ''' </summary>
    Private Sub setOther()

        mitmAdd.Enabled = True
        mitmEdit.Enabled = False
        mitmDelete.Enabled = False
        dgvAnken.Enabled = True

        cmbCode1.Enabled = False
        cmbCode1.SelectedItem = ""
        txtCode2.Enabled = False
        txtCode2.Text = ""
        txtCode3.ReadOnly = True
        txtCode3.Enabled = False
        txtCode3.Text = ""
        btnEditCode3.Enabled = False
        btnEditCode3.Text = "連番編集"
        editCode3Flg = False
        txtName.Enabled = False
        txtName.Text = ""
        cmbClient.Enabled = False
        cmbClient.SelectedIndex = 0

        dtpSalesYearMonth.Enabled = False
        dtpSalesYearMonth.Value = Now
        txtSalesAmount.Enabled = False
        txtSalesAmount.Text = ""

        btnOK.Enabled = False
        btnOK.Text = "更新"
        btnCancel.Text = "閉じる"

    End Sub

    ''' <summary>
    ''' 入力した案件情報のチェック
    ''' </summary>
    ''' <returns></returns>
    Private Function check() As Boolean

        If inputType = inputType.insert And Ankens.isExistSameCode(cmbCode1.Text, txtCode2.Text, txtCode3.Text, txtName.Text) Then
            MessageBox.Show("同一の工番,名前の組み合わせがすでに存在します。")
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