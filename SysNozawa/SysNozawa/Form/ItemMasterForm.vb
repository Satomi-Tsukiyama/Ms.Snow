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

End Class