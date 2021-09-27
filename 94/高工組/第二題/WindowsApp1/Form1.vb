Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a, b As Integer
        a = Val(TextBox1.Text) : b = Val(TextBox2.Text)
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        'y軸
        g.DrawLine(Pens.Blue, 180, 0, 180, 360)
        g.DrawString("y軸線", Me.Font, Brushes.Black, 180, 10)
        'x軸
        g.DrawLine(Pens.Blue, 0, 150, 360, 150)
        g.DrawString("x軸線", Me.Font, Brushes.Black, 320, 160)
        For i = -10 To 10 Step 0.1
            Dim x As Single = i
            Dim y As Single = (2 * (i ^ 2)) + (b * i) + 1
            '正規化
            If y >= -10 And y <= 10 Then
                If y >= 0 Then
                    y = 150 - (y * 10)
                Else
                    y = 150 + (y * 10)
                End If
                x = 180 + (x * 10)
                '畫點
                g.FillEllipse(Brushes.Red, x - 3, y - 3, 5, 5)
            End If
        Next
    End Sub
End Class
