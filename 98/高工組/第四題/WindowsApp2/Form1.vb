Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        Dim n As Single = 450 / 45
        Dim pen1 As New Pen(Brushes.Black)
        pen1.DashStyle = Drawing2D.DashStyle.Dash
        '上
        g.DrawLine(Pens.Black, 30, 30, 480, 30)
        '下
        g.DrawLine(Pens.Black, 30, 280, 480, 280)
        '左
        g.DrawLine(Pens.Black, 30, 30, 30, 280)
        '右
        g.DrawLine(Pens.Black, 480, 30, 480, 280)
        g.DrawString("求飛行軌跡vs不同初始角度 ", Me.Font, Brushes.Black, 200, 10)
        'y30 ~280
        For i = 25 To 0 Step -5
            g.DrawString(i, Me.Font, Brushes.Black, 10, 20 + (n * (25 - i)))
            g.DrawLine(pen1, 30, 30 + (n * (25 - i)), 480, 30 + (n * (25 - i)))
        Next
        'x 30~480
        For i = 0 To 45 Step 5
            g.DrawString(i, Me.Font, Brushes.Black, 20 + (n * (i)), 300)
            g.DrawLine(pen1, 30 + (n * i), 30, 30 + (n * i), 280)
        Next
        g.DrawString("x(公尺)", Me.Font, Brushes.Black, 230, 330)
        TextBox1.Text = ""
        Dim Vxo, Vyo, x, y, V0, g1 As Double
        V0 = 20 : g1 = -9.81
        For i = 0 To 90 Step 1
            Vyo = Math.Sin(i)
            Vxo = V0 * Math.Cos(i)
            x = 0 + Vxo
            TextBox1.Text &= i & " " & x & vbNewLine
            'If i Mod 5 = 0 And i <> 0 And i <> 90 Then
            '    Dim A1 As New PointF(30 + (0 * n), 280 - (0 * n))
            '    For K = 0 To x
            '        Vyo = V0 * Math.Sin(i)
            '        y = 0 + (Vyo) + (1 / 2) * g1
            '        Dim O As New PointF(30 + (y * n), 280 - (y * n))
            '        g.DrawLine(Pens.Blue, A1, O)
            '        A1 = O
            '    Next
            'End If
        Next
    End Sub
End Class
