Public Module CommonSet

    ''' <summary>
    ''' 工番1のセット
    ''' </summary>
    Public Sub setCmbCode1(ByRef cmbCode1 As ComboBox)

        With cmbCode1
            .Items.Clear()
            .Items.Add("")
            .Items.Add("A")
            .Items.Add("B")
            .Items.Add("G")
            .Items.Add("K")
            .Items.Add("S")
            .Items.Add("T")
            .Items.Add("Z")

            .Enabled = False
            .SelectedItem = ""
        End With

    End Sub

    ''' <summary>
    ''' 取引先のセット
    ''' </summary>
    Public Sub setCmbClient(ByRef cmbClient As ComboBox)

        With cmbClient
            .DataSource = Nothing

            Dim ds As DataTable = Clients.selectAll()
            Dim dr As DataRow = ds.NewRow
            dr("cId") = 0
            ds.Rows.InsertAt(dr, 0)

            .DataSource = ds

            .ValueMember = "cId"
            .DisplayMember = "cCode"

            .Enabled = False
            .SelectedIndex = 0
        End With

    End Sub

    ''' <summary>
    ''' 従業員のセット
    ''' </summary>
    Public Sub setCmbStaff(ByRef cmbStaff As ComboBox)

        With cmbStaff
            .DataSource = Nothing

            Dim ds As DataTable = Staffs.selectAll()
            Dim dr As DataRow = ds.NewRow
            dr("cId") = 0
            ds.Rows.InsertAt(dr, 0)

            .DataSource = ds

            .ValueMember = "cId"
            .DisplayMember = "cName"

            .Enabled = False
            .SelectedIndex = 0
        End With

    End Sub

    ''' <summary>
    ''' 請求状況のセット
    ''' </summary>
    ''' <param name="cmbStatus"></param>
    Public Sub setCmbStatus(ByRef cmbStatus As ComboBox)

        With cmbStatus
            .DataSource = Nothing

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

            .DataSource = dt

            .ValueMember = "cId"
            .DisplayMember = "cStatus"

            .Enabled = False
            .SelectedIndex = 0
        End With

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

            With dgvAnken.Rows(rowIndex)
                Select Case .Cells(cStatus_index).Value
                    Case AnkenStatus.NoPlan
                        .DefaultCellStyle.BackColor = Color.LemonChiffon
                        .DefaultCellStyle.ForeColor = Color.Black
                    Case AnkenStatus.Estimating
                        .DefaultCellStyle.BackColor = Color.YellowGreen
                        .DefaultCellStyle.ForeColor = Color.Black
                    Case AnkenStatus.Decided
                        .DefaultCellStyle.BackColor = Color.Violet
                        .DefaultCellStyle.ForeColor = Color.Black
                    Case AnkenStatus.Invoiced
                        .DefaultCellStyle.BackColor = Color.Cyan
                        .DefaultCellStyle.ForeColor = Color.Black
                    Case AnkenStatus.Cancel
                        .DefaultCellStyle.BackColor = Color.Black
                        .DefaultCellStyle.ForeColor = Color.White
                    Case Else
                        .DefaultCellStyle.BackColor = Color.White
                        .DefaultCellStyle.ForeColor = Color.Black
                End Select
            End With

        Next

    End Sub

End Module
