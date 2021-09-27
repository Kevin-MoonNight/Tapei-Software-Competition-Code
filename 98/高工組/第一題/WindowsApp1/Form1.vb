Public Class Form1
    Dim m, c As Double
    Dim n As Single
    Dim x(3), y(3) As Single
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim g As Graphics = PictureBox1.CreateGraphics
        n = 300 / 63
        g.Clear(Color.White)
        'y 20 ~320
        g.DrawLine(Pens.Black, 30, 10, 30, 320)
        g.DrawString("Y", Me.Font, Brushes.Black, 10, 10)
        For i = 0 To 63
            If i Mod 10 = 0 Then
                g.DrawString(i, Me.Font, Brushes.Black, 10, 320 - (i * n))
            End If
            g.DrawLine(Pens.Black, 30 - 3, 320 - (i * n), 30 + 3, 320 - (i * n))
        Next
        'x 30 330
        g.DrawLine(Pens.Black, 30, 320, 340, 320)
        g.DrawString("X", Me.Font, Brushes.Black, 330, 330)
        For i = 0 To 63
            If i Mod 10 = 0 Then
                g.DrawString(i, Me.Font, Brushes.Black, 25 + (i * n), 330)
            End If
            g.DrawLine(Pens.Black, 30 + (i * n), 320 - 3, 30 + (i * n), 320 + 3)
        Next
        x(1) = Val(TextBox1.Text) : y(1) = Val(TextBox2.Text)
        x(2) = Val(TextBox3.Text) : y(2) = Val(TextBox4.Text)
        x(3) = Val(TextBox5.Text) : y(3) = Val(TextBox6.Text)
        g.DrawEllipse(Pens.Blue, 30 + (x(1) * n) - 2, 320 - (y(1) * n) - 2, 3, 3)
        g.DrawEllipse(Pens.Blue, 30 + (x(2) * n) - 2, 320 - (y(2) * n) - 2, 3, 3)
        g.DrawEllipse(Pens.Blue, 30 + (x(3) * n) - 2, 320 - (y(3) * n) - 2, 3, 3)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim x_y, all_x, all_y, x_2 As Double
        x_y = 0 : all_x = 0 : all_y = 0 : x_2 = 0
        For i = 1 To 3
            x_y += x(i) * y(i)
            all_x += x(i)
            all_y += y(i)
            x_2 += x(i) ^ 2
        Next
        m = 0 : c = 0
        '計算m
        For i = 1 To 3
            m = (3 * (x_y) - (all_x) * (all_y)) / (3 * (x_2) - (all_x) ^ 2)
            c = ((x_2) * (all_y) - (all_x) * (x_y)) / (3 * (x_2) - (all_x) ^ 2)
        Next
        Label10.Text = "m=" & m
        Label11.Text = "c=" & c
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim g As Graphics = PictureBox1.CreateGraphics
        Dim y1, y2, x1, x2 As Single
        y1 = -1 : y2 = 64
        For i = 0 To 63
            If 320 - ((m * i + c) * n) <= 320 Then
                y1 = 320 - ((m * i + c) * n)
                x1 = 30 + i * n
                Exit For
            End If
        Next
        For i = 63 To 0 Step -1
            If 320 - ((m * i + c) * n) >= 20 Then
                y2 = 320 - ((m * i + c) * n)
                x2 = 30 + i * n
                Exit For
            End If
        Next
        g.DrawLine(Pens.Red, x1, y1, x2, y2)
    End Sub
End Class
