Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim n As Integer = Val(TextBox1.Text)
        If n Mod 2 = 1 And n >= 3 And n <= 11 Then
            TextBox2.Text = "成功"
            Dim X, Y, num As Integer
            Dim arr(n, n) As Integer
            X = 1 : Y = n \ 2 + 1 : num = 1
            arr(X, Y) = num
            For i = 1 To n ^ 2 - 1
                num += 1
                '判斷左上位置
                Dim ST_X, ST_Y As Integer
                ST_X = X : ST_Y = Y
                ST_X -= 1 : ST_Y -= 1
                If ST_X <= 0 Then
                    ST_X = n + ST_X
                End If
                If ST_Y <= 0 Then
                    ST_Y = n + ST_Y
                End If
                '判斷左上能不能走
                If arr(ST_X, ST_Y) = 0 Then
                    X = ST_X : Y = ST_Y
                    arr(X, Y) = num
                Else
                    '不能走左上往下走
                    ST_X = X : ST_Y = Y
                    ST_X += 1
                    If ST_X > n Then
                        ST_X -= n
                    End If
                    X = ST_X : Y = ST_Y
                    arr(X, Y) = num
                End If
            Next
            '動態生成輸出
            Dim text(n, n) As TextBox
            For i = 1 To n
                For j = 1 To n
                    text(i, j) = New TextBox
                    text(i, j).Size = New Size(22, 22)
                    text(i, j).Location = New Point(30 + 30 * j, 30 + 30 * i)
                    text(i, j).Text = arr(i, j)
                    Controls.Add(text(i, j))
                Next
            Next
        Else
            TextBox2.Text = "錯誤"
        End If
    End Sub
End Class
