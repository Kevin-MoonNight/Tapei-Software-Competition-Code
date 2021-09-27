Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim N As Integer = Val(TextBox1.Text)
        Dim M As Integer = Val(TextBox2.Text)
        TextBox3.Text = "淘汰順序："
        Dim P(N) As Boolean
        '用來判斷是否淘汰到N-1個人
        Dim Win As Integer = 0
        Dim tmp As Integer = 0
        Do Until Win = N - 1
            '數M個 
            For i = 1 To M
                tmp += 1
                '判斷被數到的是否有無被淘汰 如果被淘汰就往前1個直到數到沒被淘汰過的
                '如果超出範圍從頭開始繼續數
                If tmp > N Then
                    tmp -= N
                End If
                Do Until P(tmp) = False
                    tmp += 1
                    '如果超出範圍從頭開始繼續數
                    If tmp > N Then
                        tmp -= N
                    End If
                Loop
            Next
            P(tmp) = True
            Win += 1
            TextBox3.Text &= tmp & " "
        Loop
        '輸出最後贏家
        For i = 1 To N
            If P(i) = False Then
                TextBox3.Text &= vbNewLine & "最後贏家：" & i
            End If
        Next
    End Sub
End Class
