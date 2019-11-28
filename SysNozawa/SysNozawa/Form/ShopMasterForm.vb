Imports System.ComponentModel

Public Class ShopMasterForm

    Private inputType As New inputType

    Private selectId As Integer = 0
    Private clientInfo As Shop = New Shop()

    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ShopMasterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        inputType = inputType.non
        selectId = 0

        '得意先リストの表示
        setDgvShop()

        setOther()

    End Sub

    ''' <summary>
    ''' 購入先選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvShop_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShop.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        mitmEdit.Enabled = True
        mitmDelete.Enabled = True
        selectId = dgvShop.Rows(e.RowIndex).Cells("cId").Value

        Dim selectInfo As Shop = Shops.selectOne(selectId)
        With selectInfo
            txtCode.Text = .code
            txtName.Text = .name
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
        dgvShop.Enabled = False
        txtCode.Enabled = True
        txtCode.Text = ""
        txtName.Enabled = True
        txtName.Text = ""
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

        dgvShop.Enabled = False
        txtCode.Enabled = True
        txtName.Enabled = True

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

        If Shops.delete(selectId) Then
            MessageBox.Show("削除しました。")
        Else
            MessageBox.Show("削除に失敗しました。")
            Exit Sub
        End If

        inputType = inputType.non
        selectId = 0

        setDgvShop()

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
                                              MessageBoxIcon.Question
                                              ) Then
                Exit Sub

            End If


            Dim insertInfo As New Shop
            With insertInfo
                .id = Shops.getNewId()
                .code = txtCode.Text
                .name = txtName.Text
            End With

            If Shops.insert(insertInfo) Then
                MessageBox.Show("追加しました。")
            Else
                MessageBox.Show("追加に失敗しました。")
                Exit Sub
            End If

        ElseIf inputType = inputType.update Then '編集クリック

            If DialogResult.No = MessageBox.Show("編集します。よろしいですか？",
                                              "編集",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question
                                              ) Then
                Exit Sub

            End If

            Dim updateInfo As New Shop
            With updateInfo
                .id = selectId
                .code = txtCode.Text
                .name = txtName.Text
            End With

            If Shops.update(updateInfo) Then
                MessageBox.Show("編集しました。")
            Else
                MessageBox.Show("編集に失敗しました。")
                Exit Sub
            End If

        Else
        End If

        inputType = inputType.non
        selectId = 0

        setDgvShop()

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
            dgvShop.Enabled = True
            txtCode.Enabled = False
            txtCode.Text = ""
            txtName.Enabled = False
            txtName.Text = ""
            btnOK.Text = "編集"
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
    Private Sub ShopMasterForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

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
    ''' 得意先リストの表示
    ''' </summary>
    Private Sub setDgvShop()

        '部署リスト
        dgvShop.DataSource = Shops.selectAllForDataTable()

    End Sub

    ''' <summary>
    ''' 他コントロールのセット
    ''' </summary>
    Private Sub setOther()

        mitmAdd.Enabled = True
        mitmEdit.Enabled = False
        mitmDelete.Enabled = False
        dgvShop.Enabled = True
        txtCode.Enabled = False
        txtCode.Text = ""
        txtName.Enabled = False
        txtName.Text = ""
        btnOK.Enabled = False
        btnOK.Text = "編集"
        btnCancel.Text = "閉じる"

    End Sub

    ''' <summary>
    '''入力した得意先情報のチェック
    ''' </summary>
    ''' <returns></returns>
    Private Function check() As Boolean

        If txtCode.Text.Count = 0 Then
            MessageBox.Show("取引先コードを入力してください。")
            Return False
        ElseIf txtName.Text.Count = 0 Then
            MessageBox.Show("取引先名を入力してください。")
            Return False
        Else
            Return True
        End If

    End Function

End Class