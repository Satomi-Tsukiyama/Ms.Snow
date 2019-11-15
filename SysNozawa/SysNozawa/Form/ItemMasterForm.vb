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

        txtCode1.Text = selectInfo.code1
        txtCode2.Text = selectInfo.code2
        txtCode3.Text = selectInfo.code3
        cmbName.SelectedText = selectInfo.name

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


End Class