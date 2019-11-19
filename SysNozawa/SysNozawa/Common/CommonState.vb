''' <summary>
''' 画面モード
''' </summary>
Public Enum inputType
    non         '閲覧モード
    insert      '新規追加モード
    update      '更新モード
    delete      '削除モード
End Enum


''' <summary>
''' 案件テーブル：請求状況
''' </summary>
Public Enum AnkenStatus
    NoPlan = 1 '未定
    Estimating = 2 '見積中
    Decided = 3 '決定
    Invoiced = 4 '請求済
    Deposited = 5 '入金済
    Cancel = 99 '取消
End Enum

Public Module ANKEN_STATUS

    Public Function ToText(status As Integer) As String

        Select Case status
            Case AnkenStatus.NoPlan
                Return "未定"
            Case AnkenStatus.Estimating
                Return "見積中"
            Case AnkenStatus.Decided
                Return "決定"
            Case AnkenStatus.Invoiced
                Return "請求済"
            Case AnkenStatus.Deposited
                Return "入金済"
            Case Else
                Return "取消"
        End Select

    End Function

End Module



