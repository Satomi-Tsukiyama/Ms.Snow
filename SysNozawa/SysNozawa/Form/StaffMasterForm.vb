Imports System.ComponentModel

Public Class StaffMasterForm

    Private inputType As New inputType
    Private selectId As Integer = 0

    ''' <summary>
    ''' ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub StaffMasterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        inputType = inputType.non
        selectId = 0

        '従業員リストの表示
        setDgvStaff()

        setOther()

    End Sub

    ''' <summary>
    ''' 従業員選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvStaff_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStaff.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        mitmEdit.Enabled = True
        mitmDelete.Enabled = True
        selectId = dgvStaff.Rows(e.RowIndex).Cells("cId").Value

        Dim selectInfo As Staff = Staffs.selectOne(selectId)

        txtName.Text = selectInfo.name

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
        dgvStaff.Enabled = False
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
        dgvStaff.Enabled = False
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

        If Staffs.delete(selectId) Then
            MessageBox.Show("削除しました。")
        Else
            MessageBox.Show("削除に失敗しました。")
        End If

        inputType = inputType.non
        selectId = 0

        setDgvStaff()

        setOther()

    End Sub

    ''' <summary>
    ''' 追加/更新クリック
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


            Dim insertInfo As New Staff
            insertInfo.id = Staffs.getNewId()
            insertInfo.name = txtName.Text

            If Staffs.insert(insertInfo) Then
                MessageBox.Show("追加しました。")
            Else
                MessageBox.Show("追加に失敗しました。")
            End If

        ElseIf inputType = inputType.update Then '編集クリック

            If DialogResult.No = MessageBox.Show("編集します。よろしいですか？",
                                                 "編集",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question
                                                 ) Then
                Exit Sub

            End If

            Dim updateInfo As New Staff
            updateInfo.id = selectId
            updateInfo.name = txtName.Text

            If Staffs.update(updateInfo) Then
                MessageBox.Show("編集しました。")
            Else
                MessageBox.Show("編集に失敗しました。")
            End If

        Else
        End If

        inputType = inputType.non
        selectId = 0

        setDgvStaff()

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
            dgvStaff.Enabled = True
            txtName.Enabled = False
            txtName.Text = ""
            btnOK.Text = "編集"
            btnCancel.Text = "閉じる"

        Else '閉じるクリック
            Me.Close()
        End If

    End Sub

    ''' <summary>
    ''' ×クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub StaffMasterForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

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
    Private Sub setDgvStaff()

        '部署リスト
        dgvStaff.DataSource = Staffs.selectAll()

    End Sub

    Private Sub setOther()

        mitmAdd.Enabled = True
        mitmEdit.Enabled = False
        mitmDelete.Enabled = False
        dgvStaff.Enabled = True
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

        If txtName.Text.Count = 0 Then
            MessageBox.Show("従業員名を入力してください。")
            Return False
        Else
            Return True
        End If

    End Function

End Class