Public Class Form1
    Dim x1, y1, x2, y2, x3, y3 As Integer
    Dim a, b, c As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '畫座標
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        '畫x軸
        g.DrawString("X", Me.Font, Brushes.Black, 10, 210)
        g.DrawLine(Pens.Black, 10, 200, 430, 200)
        For I = 0 To 20
            g.DrawLine(Pens.Black, 20 + (I * 20), 195, 20 + (I * 20), 205)
        Next
        '畫Y軸
        g.DrawString("Y", Me.Font, Brushes.Black, 200 - 5, 410)
        g.DrawLine(Pens.Black, 220, 0, 220, 420)
        For I = 0 To 20
            g.DrawLine(Pens.Black, 215, 0 + (I * 20), 225, 0 + (I * 20))
        Next
    End Sub
    Sub InputO()
        x1 = Val(TextBox1.Text) : y1 = Val(TextBox2.Text)
        x2 = Val(TextBox3.Text) : y2 = Val(TextBox4.Text)
        x3 = Val(TextBox5.Text) : y3 = Val(TextBox6.Text)
        a = Math.Sqrt((x2 - x3) ^ 2 + (y2 - y3) ^ 2)
        b = Math.Sqrt((x3 - x1) ^ 2 + (y3 - y1) ^ 2)
        c = Math.Sqrt((x2 - x1) ^ 2 + (y2 - y1) ^ 2)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '畫點
        '設定座標
        InputO()
        Dim g As Graphics = PictureBox1.CreateGraphics
        Call Button1_Click(sender, e)
        Dim X, Y As Integer
        X = Val(TextBox1.Text) : Y = Val(TextBox2.Text)
        '正規化
        X = Conver_X(X) : Y = Conver_Y(Y)
        '畫點1
        g.FillEllipse(Brushes.Red, X - 3, Y - 3, 5, 5)
        g.DrawString("A", Me.Font, Brushes.Black, X - 3, Y - 3)

        X = Val(TextBox3.Text) : Y = Val(TextBox4.Text)
        '正規化
        X = Conver_X(X) : Y = Conver_Y(Y)
        '畫點2
        g.FillEllipse(Brushes.Yellow, X - 3, Y - 3, 5, 5)
        g.DrawString("B", Me.Font, Brushes.Black, X - 3, Y - 3)

        X = Val(TextBox5.Text) : Y = Val(TextBox6.Text)
        '正規化
        X = Conver_X(X) : Y = Conver_Y(Y)
        '畫點3
        g.FillEllipse(Brushes.Blue, X - 3, Y - 3, 5, 5)
        g.DrawString("C", Me.Font, Brushes.Black, X - 3, Y - 3)
    End Sub
    Function Conver_X(ByVal x As Integer) As Integer
        '正規化
        If x < 0 Then
            x = 220 - (Math.Abs(x) * 20)
        ElseIf x = 0 Then
            x = 220
        ElseIf x > 0 Then
            x = 220 + (x * 20)
        End If
        Return x
    End Function
    Function Conver_Y(ByVal y As Integer) As Integer
        If y < 0 Then
            y = 220 + (Math.Abs(y) * 20)
        ElseIf y = 0 Then
            y = 220
        ElseIf y > 0 Then
            y = 220 - (y * 20)
        End If
        Return y
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '畫三邊
        Dim g As Graphics = PictureBox1.CreateGraphics
        '畫線
        g.DrawLine(Pens.Pink, Conver_X(Val(TextBox1.Text)), Conver_Y(Val(TextBox2.Text)), Conver_X(Val(TextBox3.Text)), Conver_Y(Val(TextBox4.Text)))
        g.DrawLine(Pens.Gray, Conver_X(Val(TextBox1.Text)), Conver_Y(Val(TextBox2.Text)), Conver_X(Val(TextBox5.Text)), Conver_Y(Val(TextBox6.Text)))
        g.DrawLine(Pens.Purple, Conver_X(Val(TextBox3.Text)), Conver_Y(Val(TextBox4.Text)), Conver_X(Val(TextBox5.Text)), Conver_Y(Val(TextBox6.Text)))
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call Button1_Click(sender, e)
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        InputO()
        Label11.Text = Math.Abs(x1 * y2 + x2 * y3 + x3 * y1 - x2 * y1 - x3 * y2 - x1 * y3) / 2 '面積
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        InputO()
        Label12.Text = Format(Math.Acos((b ^ 2 + c ^ 2 - a ^ 2) / (2 * b * c)) * 180 / Math.PI, "#") '角A
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        InputO()
        Label13.Text = Format(Math.Acos((a ^ 2 + c ^ 2 - b ^ 2) / (2 * c * a)) * 180 / Math.PI, "#") '角B
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        InputO()
        Label14.Text = Format(Math.Acos((a ^ 2 + b ^ 2 - c ^ 2) / (2 * a * b)) * 180 / Math.PI, "#") '角C
    End Sub
End Class
