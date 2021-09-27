Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim G As Graphics = PictureBox1.CreateGraphics
        G.Clear(Color.White)
        'X 50~450 Y 50 ~350
        '上
        G.DrawLine(Pens.Black, 50, 50, 450, 50)
        '下
        G.DrawLine(Pens.Black, 50, 350, 450, 350)
        '左
        G.DrawLine(Pens.Black, 50, 50, 50, 350)
        '右
        G.DrawLine(Pens.Black, 450, 50, 450, 350)
        '畫虛線
        'Y
        Dim PEN1 As New Pen(Brushes.Black)
        PEN1.DashStyle = Drawing2D.DashStyle.Dash
        Dim N As Integer = 300 / 8
        For I = 1 To 7
            G.DrawLine(PEN1, 50, 50 + (I * N), 450, 50 + (I * N))
        Next
        '標數字
        For I = 0 To 8
            G.DrawString((8 - I) * 10, Me.Font, Brushes.Black, 30, 40 + (I * N))
        Next
        'X
        N = 400 / 10
        For I = 1 To 9
            G.DrawLine(PEN1, 50 + (I * N), 50, 50 + (I * N), 350)
        Next
        '標數字
        For I = 0 To 10
            G.DrawString(I * 10, Me.Font, Brushes.Black, 40 + (I * N), 360)
        Next
        '功率-負載電阻波形
        G.DrawString("功率-負載電阻波形", Me.Font, Brushes.Black, 200, 30)
        '負載電阻(歐姆)
        G.DrawString("負載電阻(歐姆)", Me.Font, Brushes.Black, 200, 380)
        '畫曲線
        For i = Val(TextBox1.Text) To Val(TextBox2.Text) Step 1

        Next















    End Sub
End Class
