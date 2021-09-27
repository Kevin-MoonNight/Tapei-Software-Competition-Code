Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a, m, b As Single
        a = Val(TextBox3.Text) : b = Val(TextBox4.Text) : m = Val(TextBox2.Text)
        Call pic(Val(TextBox1.Text))
        Dim g As Graphics = PictureBox1.CreateGraphics
        Dim Y_n As Single = (360 - 30) / 10
        Dim X_n As Single = (390 - 40) / Val(TextBox1.Text)
        '起點~a
        g.DrawLine(Pens.Blue, 40, 360, 40 + (X_n * (a)), 360)
        'a~m
        g.DrawLine(Pens.Blue, 40 + (X_n * (a)), 360, 40 + (X_n * (m)), 30)
        'm~b
        g.DrawLine(Pens.Blue, 40 + (X_n * (m)), 30, 40 + (X_n * (b)), 360)
        'b~終點
        g.DrawLine(Pens.Blue, 40 + (X_n * (b)), 360, 390, 360)
    End Sub
    Sub pic(ByVal x As Integer)
        '繪背景
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        '上下左右
        g.DrawLine(Pens.Black, 40, 20, 390, 20)
        g.DrawLine(Pens.Black, 40, 370, 390, 370)
        g.DrawLine(Pens.Black, 40, 20, 40, 370)
        g.DrawLine(Pens.Black, 390, 20, 390, 370)
        'y 20~370
        '範圍30~360
        Dim n As Single = (360 - 30) / 10
        For i = 0 To 10 Step 1
            g.DrawLine(Pens.Black, 390, 360 - (i * n), 387, 360 - (i * n))
            g.DrawLine(Pens.Black, 40, 360 - (i * n), 43, 360 - (i * n))
            g.DrawString(i / 10, Me.Font, Brushes.Black, 20, 355 - (i * n))
        Next
        'x 40~390
        Dim ST, Max_x As Integer
        Max_x = x
        ST = x / 10
        n = (390 - 40) / Max_x
        For i = 0 To Max_x Step ST
            g.DrawLine(Pens.Black, 40 + (i * n), 20, 40 + (i * n), 23)
            g.DrawLine(Pens.Black, 40 + (i * n), 370, 40 + (i * n), 367)
            g.DrawString(i, Me.Font, Brushes.Black, 35 + (i * n), 380)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a, b, c, d As Single
        a = Val(TextBox3.Text) : b = Val(TextBox4.Text) : c = Val(TextBox5.Text) : d = Val(TextBox6.Text)
        Call pic(Val(TextBox1.Text))
        Dim g As Graphics = PictureBox1.CreateGraphics
        Dim Y_n As Single = (360 - 30) / 10
        Dim X_n As Single = (390 - 40) / Val(TextBox1.Text)
        '起點~a
        g.DrawLine(Pens.Red, 40, 360, 40 + (X_n * (a)), 360)
        'a~b
        g.DrawLine(Pens.Red, 40 + (X_n * (a)), 360, 40 + (X_n * (b)), 30)
        'b~c
        g.DrawLine(Pens.Red, 40 + (X_n * (b)), 30, 40 + (X_n * (c)), 30)
        'c~d
        g.DrawLine(Pens.Red, 40 + (X_n * (c)), 30, 40 + (X_n * (d)), 360)
        'd~終點
        g.DrawLine(Pens.Red, 40 + (X_n * (d)), 360, 390, 360)
    End Sub
End Class
