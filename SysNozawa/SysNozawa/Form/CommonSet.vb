Public Module CommonSet

    ''' <summary>
    ''' 工番1のセット
    ''' </summary>
    Public Sub setCmbCode1(ByRef cmbCode1 As ComboBox)

        cmbCode1.Items.Clear()
        cmbCode1.Items.Add("")
        cmbCode1.Items.Add("A")
        cmbCode1.Items.Add("B")
        cmbCode1.Items.Add("G")
        cmbCode1.Items.Add("K")
        cmbCode1.Items.Add("S")
        cmbCode1.Items.Add("T")
        cmbCode1.Items.Add("Z")

        cmbCode1.Enabled = False
        cmbCode1.SelectedItem = ""

    End Sub

    ''' <summary>
    ''' 取引先のセット
    ''' </summary>
    Public Sub setCmbClient(ByRef cmbClient As ComboBox)

        cmbClient.DataSource = Nothing
        Dim ds As DataTable = Clients.selectAll()
        Dim dr As DataRow = ds.NewRow
        dr("cId") = 0
        ds.Rows.InsertAt(dr, 0)
        cmbClient.DataSource = ds

        cmbClient.ValueMember = "cId"
        cmbClient.DisplayMember = "cCode"

        cmbClient.Enabled = False
        cmbClient.SelectedIndex = 0

    End Sub

    ''' <summary>
    ''' 従業員のセット
    ''' </summary>
    Public Sub setCmbStaff(ByRef cmbStaff As ComboBox)

        cmbStaff.DataSource = Nothing
        Dim ds As DataTable = Staffs.selectAll()
        Dim dr As DataRow = ds.NewRow
        dr("cId") = 0
        ds.Rows.InsertAt(dr, 0)
        cmbStaff.DataSource = ds

        cmbStaff.ValueMember = "cId"
        cmbStaff.DisplayMember = "cName"

        cmbStaff.Enabled = False
        cmbStaff.SelectedIndex = 0

    End Sub

    Public Sub setCmbStatus(ByRef cmbStatus As ComboBox)

        cmbStatus.DataSource = Nothing

        Dim dt As New DataTable
        dt.Columns.Add("cId")
        dt.Columns.Add("cStatus")

        Dim dr As DataRow = dt.NewRow
        dr("cId") = 1
        dr("cStatus") = ANKEN_STATUS.ToText(dr("cId"))
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("cId") = 2
        dr("cStatus") = ANKEN_STATUS.ToText(dr("cId"))
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("cId") = 3
        dr("cStatus") = ANKEN_STATUS.ToText(dr("cId"))
        dt.Rows.Add(dr)
        dr = dt.NewRow
        dr("cId") = 4
        dr("cStatus") = ANKEN_STATUS.ToText(dr("cId"))
        dt.Rows.Add(dr)
        dr = dt.NewRow
        dr("cId") = 5
        dr("cStatus") = ANKEN_STATUS.ToText(dr("cId"))
        dt.Rows.Add(dr)
        dr = dt.NewRow
        dr("cId") = 99
        dr("cStatus") = ANKEN_STATUS.ToText(dr("cId"))
        dt.Rows.Add(dr)

        cmbStatus.DataSource = dt

        cmbStatus.ValueMember = "cId"
        cmbStatus.DisplayMember = "cStatus"

        cmbStatus.Enabled = False
        cmbStatus.SelectedIndex = 0

    End Sub

    ''' <summary>
    ''' 請求状況によって背景色を設定
    ''' </summary>
    ''' <param name="dgvAnken"></param>
    Public Sub setDgvAnken_BackColor(ByRef dgvAnken As DataGridView)

        Dim cStatus_index As Integer = 0
        For Each column As DataGridViewColumn In dgvAnken.Columns
            If column.DataPropertyName = "cStatus" Then
                cStatus_index = column.Index
            End If
        Next


        For rowIndex = 0 To dgvAnken.Rows.Count - 1

            Select Case dgvAnken.Rows(rowIndex).Cells(cStatus_index).Value
                Case AnkenStatus.NoPlan
                    dgvAnken.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LemonChiffon
                    dgvAnken.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black
                Case AnkenStatus.Estimating
                    dgvAnken.Rows(rowIndex).DefaultCellStyle.BackColor = Color.YellowGreen
                    dgvAnken.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black
                Case AnkenStatus.Decided
                    dgvAnken.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Violet
                    dgvAnken.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black
                Case AnkenStatus.Invoiced
                    dgvAnken.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Cyan
                    dgvAnken.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black
                Case AnkenStatus.Cancel
                    dgvAnken.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Black
                    dgvAnken.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.White
                Case Else
                    dgvAnken.Rows(rowIndex).DefaultCellStyle.BackColor = Color.White
                    dgvAnken.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black
            End Select

        Next

    End Sub

End Module
