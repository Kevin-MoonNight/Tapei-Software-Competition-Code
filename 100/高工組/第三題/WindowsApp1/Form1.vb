Public Class Form1
    Dim Min, Max, u, Q As Double
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        Min = Val(TextBox2.Text) : Max = Val(TextBox1.Text) : u = Val(TextBox3.Text) : Q = Val(TextBox4.Text)
        Dim New_Pen As New Pen(Brushes.Black)
        '設虛線
        New_Pen.DashStyle = Drawing2D.DashStyle.Dash
        'Y 30 ~430
        Dim Y_n As Single = 400 / 11
        Dim num As Double = 1
        g.DrawLine(Pens.Black, 30, 30, 30, 430)
        For I = 1 To 12
            g.DrawLine(New_Pen, 30, 30 + (Y_n * (I - 1)), 430, 30 + (Y_n * (I - 1)))
            g.DrawString((num - ((I - 1) * 0.1)), Me.Font, Brushes.Black, 10, 25 + (Y_n * (I - 1)))
        Next
        'X 30 ~ 430
        Dim X_n As Single = 400 / 10
        num = Min
        g.DrawLine(Pens.Black, 30, 430, 430, 430)
        For I = 1 To 11
            g.DrawLine(New_Pen, 30 + (X_n * (I - 1)), 30, 30 + (X_n * (I - 1)), 430)
            g.DrawString(num + ((I - 1) * ((Math.Abs(Min) + Math.Abs(Max)) / 10)), Me.Font, Brushes.Black, 30 + (X_n * (I - 1)), 440)
        Next
        '畫圖
        Dim L As Double = 30
        Dim ST As New PointF(L, 430 - Y_n)
        For i = Min To Max Step 0.01
            Dim O As New PointF(L, 430 - Y_n)
            If ComboBox1.Text = "紅色" Then
                g.DrawLine(Pens.Red, ST, P(O, i, 400 - Y_n))
            ElseIf ComboBox1.Text = "藍色" Then
                g.DrawLine(Pens.Blue, ST, P(O, i, 400 - Y_n))
            ElseIf ComboBox1.Text = "黃色" Then
                g.DrawLine(Pens.Yellow, ST, P(O, i, 400 - Y_n))
            ElseIf ComboBox1.Text = "黑色" Then
                g.DrawLine(Pens.Blue, ST, P(O, i, 400 - Y_n))
            End If
            ST = P(O, i, 400 - Y_n)
            L += ((400 / (Math.Abs(Min) + Math.Abs(Max))) * 0.01)
        Next
    End Sub
    Function P(ByVal O As PointF, ByVal x As Double, ByVal L As Double)
        O.Y -= (1 / (Math.Sqrt(2 * Math.PI * Q))) * Math.Exp((((x - u) ^ 2) / (2 * Q)) * -1) * L
        Return O
    End Function
End Class
