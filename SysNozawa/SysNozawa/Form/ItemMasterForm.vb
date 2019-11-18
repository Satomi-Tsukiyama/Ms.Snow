Public Class ItemMasterForm

    Private inputType As New inputType
    Private selectId As Integer = 0

    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ItemMasterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        inputType = inputType.non
        selectId = 0

        '商品リスト表示
        setDgvItem()

        '商品名セット
        setCmbName()

        'メーカーセット
        setCmbMaker()

        '単位セット
        setCmbUnit()

        setOther()

    End Sub

    ''' <summary>
    ''' 商品選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItem.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        mitmEdit.Enabled = True
        mitmDelete.Enabled = True
        selectId = dgvItem.Rows(e.RowIndex).Cells("cId").Value

        Dim selectInfo As Item = Items.selectOne(selectId)

        cmbName.SelectedText = selectInfo.name
        txtKata.Text = selectInfo.kata
        cmbMaker.SelectedText = selectInfo.maker
        txtCode1.SelectedText = selectInfo.code1
        txtCode2.SelectedText = selectInfo.code2
        txtCode3.SelectedText = selectInfo.code3
        cmbUnit.SelectedText = selectInfo.unit
        txtQuantity.Text = selectInfo.quantity

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
        dgvItem.Enabled = False

        cmbName.Enabled = True
        cmbName.SelectedIndex = 0
        txtKata.Enabled = True
        txtKata.Text = ""
        txtCode1.Enabled = True
        txtCode1.Text = ""
        txtCode2.Enabled = True
        txtCode2.Text = ""
        txtCode3.Enabled = True
        txtCode3.Text = ""
        cmbUnit.Enabled = True
        cmbUnit.SelectedIndex = 0
        txtQuantity.Enabled = True
        txtQuantity.Text = ""

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
        dgvItem.Enabled = False

        cmbName.Enabled = True
        txtKata.Enabled = True
        txtKata.Enabled = True
        txtCode1.Enabled = True
        txtCode2.Enabled = True
        txtCode3.Enabled = True
        cmbUnit.Enabled = True
        txtQuantity.Enabled = True

        btnOK.Enabled = True
        btnOK.Text = "追加"
        btnCancel.Text = "中止"

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
            If txtSalesAmount.Text.Count > 0 Then
                insertInfo.salesAmount = txtSalesAmount.Text
            Else
                insertInfo.salesAmount = 0
            End If
            insertInfo.staffId = cmbStaff.SelectedValue
            insertInfo.staffName = cmbStaff.Text
            insertInfo.status = cmbStatus.SelectedValue

            If Ankens.insert(insertInfo) Then
                MessageBox.Show("追加しました。")
            Else
                MessageBox.Show("追加に失敗しました。")
                Exit Sub
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

    Private Sub setDgvItem()

        dgvItem.DataSource = Items.selectAll()

    End Sub

    Private Sub setCmbName()

        cmbName.Items.Clear()
        Dim itemNames As List(Of String) = Items.getAllName()

        cmbName.Items.Add("")
        For Each itemName In itemNames
            cmbName.Items.Add(itemName)
        Next

    End Sub

    Private Sub setCmbMaker()

        cmbMaker.Items.Clear()
        Dim itemMakers As List(Of String) = Items.getAllMaker()

        cmbMaker.Items.Add("")
        For Each itemMaker In itemMakers
            cmbMaker.Items.Add(itemMaker)
        Next

    End Sub

    Private Sub setCmbUnit()

        cmbUnit.Items.Clear()
        Dim itemUnits As List(Of String) = Items.getAllUnit()

        cmbUnit.Items.Add("")
        For Each itemUnit In itemUnits
            cmbUnit.Items.Add(itemUnit)
        Next

    End Sub

    Private Sub setOther()

        mitmAdd.Enabled = True
        mitmEdit.Enabled = False
        mitmDelete.Enabled = False
        dgvItem.Enabled = True

        cmbName.Enabled = False
        cmbName.SelectedIndex = 0
        txtKata.Enabled = False
        txtKata.Text = ""
        cmbMaker.Enabled = False
        cmbMaker.SelectedIndex = 0
        txtCode1.Enabled = False
        txtCode1.Text = ""
        txtCode2.Enabled = False
        txtCode2.Text = ""
        txtCode3.Enabled = False
        txtCode3.Text = ""
        cmbUnit.Enabled = False
        cmbUnit.SelectedIndex = 0
        txtQuantity.Enabled = False
        txtQuantity.Text = ""

        btnOK.Enabled = False
        btnOK.Text = "編集"
        btnCancel.Text = "閉じる"

    End Sub

    ''' <summary>
    ''' 入力した商品情報のチェック
    ''' </summary>
    ''' <returns></returns>
    Private Function check() As Boolean

        If inputType = inputType.insert And Ankens.isExistSameCode(cmbCode1.Text, txtCode2.Text, txtCode3.Text) Then
            MessageBox.Show("同一の工番がすでに存在します。")
            Return False
        End If

        If cmbName.Text.Count = 0 Then
            MessageBox.Show("商品名を入力してください。")
            Return False
        End If

        If txtKata.Text.Count = 0 Then
            MessageBox.Show("型式を正しく入力してください。")
            Return False
        End If

        If inputType = inputType.insert And Items.isExistSameCode(txtCode1.Text, txtCode2.Text, txtCode3.Text) Then
            MessageBox.Show("同一の工番がすでに存在します。")
            Return False
        End If

        If cmbStaff.Text.Count = 0 Then
            MessageBox.Show("作成者を正しく入力してください。")
            Return False
        End If

        Return True

    End Function


End Class