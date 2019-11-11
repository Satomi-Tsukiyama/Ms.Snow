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
        dr("cStatus") = "未決定"
        dt.Rows.Add(dr)
        dr = dt.NewRow
        dr("cId") = 2
        dr("cStatus") = "見積済"
        dt.Rows.Add(dr)
        dr = dt.NewRow
        dr("cId") = 3
        dr("cStatus") = "決定"
        dt.Rows.Add(dr)
        dr = dt.NewRow
        dr("cId") = 4
        dr("cStatus") = "請求済"
        dt.Rows.Add(dr)
        dr = dt.NewRow
        dr("cId") = 99
        dr("cStatus") = "取消"
        dt.Rows.Add(dr)

        cmbStatus.DataSource = dt

        cmbStatus.ValueMember = "cId"
        cmbStatus.DisplayMember = "cStatus"

        cmbStatus.Enabled = False
        cmbStatus.SelectedIndex = 0

    End Sub

End Module
