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
    Cancel = 99 'キャンセル
End Enum


