Imports System.ComponentModel

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

        '入数単位セット
        setCmbQuantityUnit()

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

        Dim selectInfo As Item = Items.selectOneWhereId(selectId)

        With selectInfo
            cmbName.SelectedItem = .name
            txtKata.Text = .kata
            cmbMaker.SelectedItem = .maker
            txtCode1.Text = .code1
            txtCode2.Text = .code2
            txtCode3.Text = .code3
            cmbUnit.SelectedItem = .unit
            txtQuantity.Text = .quantity
            cmbQuantityUnit.SelectedItem = .quantityunit
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
        dgvItem.Enabled = False

        cmbName.Enabled = True
        cmbName.SelectedIndex = 0
        txtKata.Enabled = True
        txtKata.Text = ""
        cmbMaker.Enabled = True
        cmbMaker.SelectedIndex = 0
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
        cmbQuantityUnit.Enabled = True
        cmbQuantityUnit.SelectedIndex = 0

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
        cmbMaker.Enabled = True
        txtCode1.Enabled = True
        txtCode2.Enabled = True
        txtCode3.Enabled = True
        cmbUnit.Enabled = True
        txtQuantity.Enabled = True
        cmbQuantityUnit.Enabled = True

        btnOK.Enabled = True
        btnOK.Text = "編集"
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

            Dim insertInfo As New Item

            With insertInfo
                .id = Items.getNewId()
                .code1 = txtCode1.Text
                .code2 = txtCode2.Text
                .code3 = txtCode3.Text
                .name = cmbName.Text
                .kata = txtKata.Text
                .maker = cmbMaker.Text
                .unit = cmbUnit.Text
                If txtQuantity.Text.Count > 0 Then
                    .quantity = txtQuantity.Text
                Else
                    .quantity = Nothing
                End If
                .quantityunit = cmbQuantityUnit.Text

            End With


            If Items.insert(insertInfo) Then
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

            Dim updateInfo As New Item

            With updateInfo
                .id = selectId
                .code1 = txtCode1.Text
                .code2 = txtCode2.Text
                .code3 = txtCode3.Text
                .name = cmbName.Text
                .kata = txtKata.Text
                .maker = cmbMaker.Text
                .unit = cmbUnit.Text
                .quantity = txtQuantity.Text
                .quantityunit = cmbQuantityUnit.Text
            End With

            If Items.update(updateInfo) Then
                MessageBox.Show("編集しました。")
            Else
                MessageBox.Show("編集に失敗しました。")
                Exit Sub
            End If

        Else

        End If

        inputType = inputType.non
        selectId = 0

        setDgvItem()

        setCmbName()

        setCmbMaker()

        setCmbUnit()

        setCmbQuantityUnit()

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
            dgvItem.Enabled = True

            cmbName.Enabled = False
            cmbName.SelectedItem = ""
            txtKata.Enabled = False
            txtKata.Text = ""
            cmbMaker.Enabled = False
            cmbMaker.SelectedItem = ""
            txtCode1.Enabled = False
            txtCode1.Text = ""
            txtCode2.Enabled = False
            txtCode2.Text = ""
            txtCode3.Enabled = False
            txtCode3.Text = ""
            cmbUnit.Enabled = False
            cmbUnit.SelectedItem = ""
            txtQuantity.Enabled = False
            txtQuantity.Text = ""
            cmbQuantityUnit.Enabled = False
            cmbQuantityUnit.SelectedItem = ""

            btnOK.Enabled = False
            btnOK.Text = "編集"
            btnCancel.Text = "閉じる"

            '新規追加ボタン選択中
            mitmAdd.Select()

        Else '閉じるクリック
            Me.Close()
        End If

    End Sub

    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ItemMasterForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

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
    ''' 商品リストの表示
    ''' </summary>
    Private Sub setDgvItem()

        dgvItem.DataSource = Items.selectAll()

    End Sub

    ''' <summary>
    ''' 商品名のセット
    ''' </summary>
    Private Sub setCmbName()

        cmbName.Items.Clear()
        Dim allName As List(Of String) = Items.getAllName()

        cmbName.Items.Add("")
        For Each oneName In allName
            cmbName.Items.Add(oneName)
        Next

    End Sub

    ''' <summary>
    ''' メーカー名のセット
    ''' </summary>
    Private Sub setCmbMaker()

        cmbMaker.Items.Clear()
        Dim allMaker As List(Of String) = Items.getAllMaker()

        cmbMaker.Items.Add("")
        For Each oneMaker In allMaker
            cmbMaker.Items.Add(oneMaker)
        Next

    End Sub

    ''' <summary>
    ''' 単位のセット
    ''' </summary>
    Private Sub setCmbUnit()

        cmbUnit.Items.Clear()
        Dim allUnit As List(Of String) = Items.getAllUnit()

        cmbUnit.Items.Add("")
        For Each oneUnit In allUnit
            cmbUnit.Items.Add(oneUnit)
        Next

    End Sub

    ''' <summary>
    ''' 入数単位のセット
    ''' </summary>
    Private Sub setCmbQuantityUnit()

        cmbQuantityUnit.Items.Clear()
        Dim allQuantityUnits As List(Of String) = Items.getAllQuantityUnit()

        cmbQuantityUnit.Items.Add("")
        For Each oneQuantityUnits In allQuantityUnits
            cmbQuantityUnit.Items.Add(oneQuantityUnits)
        Next

    End Sub

    ''' <summary>
    ''' 他コントロールのセット
    ''' </summary>
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
        cmbQuantityUnit.Enabled = False
        cmbQuantityUnit.SelectedIndex = 0

        btnOK.Enabled = False
        btnOK.Text = "編集"
        btnCancel.Text = "閉じる"

    End Sub

    ''' <summary>
    ''' 入力した商品情報のチェック
    ''' </summary>
    ''' <returns></returns>
    Private Function check() As Boolean

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

        If cmbUnit.Text.Count = 0 Then
            MessageBox.Show("単位を正しく入力してください。")
            Return False
        End If

        Return True

    End Function

End Class