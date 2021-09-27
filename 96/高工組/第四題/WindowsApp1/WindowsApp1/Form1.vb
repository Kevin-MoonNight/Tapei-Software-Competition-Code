Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim G As Graphics = PictureBox1.CreateGraphics
        Dim M As Integer = Val(TextBox1.Text)
        Dim t As Double = Val(TextBox2.Text)
        Dim NewPen As New Pen(Brushes.Gray)
        NewPen.DashStyle = Drawing2D.DashStyle.Dash
        If M Mod 2 = 0 Then
            M -= 1
        End If
        G.Clear(Color.White)
        G.DrawLine(NewPen, 30, 200, 630, 200)
        'y
        G.DrawLine(Pens.Black, 30, 50, 30, 250)
        For I = 1.5 To -0.5 Step -0.1
            Dim Y As Single
            Y = 50 + (1.5 - I) * 100
            G.DrawLine(Pens.Black, 27, Y, 30, Y)
        Next
        For I = 1.5 To -0.5 Step -0.5 '標數字
            Dim Y As Single
            Y = 50 + (1.5 - I) * 100
            G.DrawLine(Pens.Black, 25, Y, 30, Y)
            G.DrawString(Format(I, "#.0"), Me.Font, Brushes.Black, 5, Y - 3)
        Next
        'X
        G.DrawLine(Pens.Black, 30, 250, 630, 250)
        For I = 0 To 6 Step 0.1
            Dim X As Single
            X = 30 + (I) * 100
            G.DrawLine(Pens.Black, X, 250, X, 253)
        Next
        For I = 0 To 6 Step 0.5 '標數字
            Dim X As Single
            X = 30 + (I) * 100
            G.DrawLine(Pens.Black, X, 250, X, 255)
            G.DrawString(Format(I - 3, "#.0"), Me.Font, Brushes.Black, X - 10, 270)
        Next
        Dim A1 As New PointF(30, 200)
        Dim L As Integer = 1
        For I = -3 To 3 Step t * 10
            Dim O As New PointF(30 + (L), 200)
            G.DrawLine(Pens.Blue, A1.X, A1.Y, A1.X, P(I, M))
            A1.X = O.X : A1.Y = P(I, M)
            L += 1
        Next
    End Sub
    Function P(ByVal t As Double, ByVal M As Double)
        Dim Y As Double = 0
        For K = 1 To M Step 2
            Y += (2 / (K * Math.PI)) * Math.Cos(K * Math.PI * t + ((-1) ^ ((K - 1) / 2) - 1) * (Math.PI / 2))
        Next
        Y += (1 / 2)
        Y = 200 - (100 * Y)
        Return Y
    End Function
End Class
