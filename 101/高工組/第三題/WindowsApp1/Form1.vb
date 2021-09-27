Public Class Form1
    Dim Median, Max, Min, IQR, Q3, Q1, Outlier, Max_over, Min_over As Single
    Dim num() As Double
    Dim num_text() As TextBox '宣告
    Dim L() As Label
    '執行繪圖
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ''輸入資料
        'For i = 1 To Val(TextBox1.Text)
        '    num(i) = Val(num_text(i).Text)
        'Next
        'ReDim num(Val(TextBox1.Text))
        num(1) = 39
        num(2) = 32
        num(3) = 20
        num(4) = 34
        num(5) = 40
        num(6) = 33
        num(7) = 31
        num(8) = 29
        num(9) = 25
        num(10) = 30
        num(11) = 31
        num(12) = 32
        num(13) = 22
        '重新排序
        For i = 1 To Val(TextBox1.Text)
            For j = 1 To Val(TextBox1.Text)
                If num(i) < num(j) Then
                    Dim ST As Double
                    ST = num(j)
                    num(j) = num(i)
                    num(i) = ST
                End If
            Next
        Next
        '找出最大、最小值、中值、Q1、Q3
        Max = num(UBound(num)) : Min = num(1)
        Median = (50 / 100) * Val(TextBox1.Text)
        Q1 = (25 / 100) * Val(TextBox1.Text)
        Q3 = (75 / 100) * Val(TextBox1.Text)
        If Median <> Int(Median) Then
            Median = num(Int(1 + Median))
        Else
            Median = (num(Int(Median)) + num(Int(Median + 1))) / 2
        End If
        If Q1 <> Int(Q1) Then
            Q1 = num(1 + Int(Q1))
        Else
            Q1 = (num(Int(Q1)) + num(Int(Q1 + 1))) / 2
        End If
        If Q3 <> Int(Q3) Then
            Q3 = num(1 + Int(Q3))
        Else
            Q3 = (num(Int(Q3)) + num(Int(Q3 + 1))) / 2
        End If
        'IQR、最小、最大上下限Outlier
        IQR = Q3 - Q1
        Max_over = Q3 + IQR
        Min_over = Q1 - IQR
        For i = Min To Max
            If i < Min_over Or i > Max_over Then
                Outlier = i
                Exit For
            End If
        Next
        TextBox2.Text = Max : TextBox3.Text = Min : TextBox4.Text = Max_over : TextBox5.Text = IQR : TextBox6.Text = Q3 : TextBox7.Text = Median : TextBox8.Text = Q1 : TextBox9.Text = Min_over : TextBox10.Text = Outlier
        '畫圖
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        'x 40~ 380 y 40~380
        '上下
        g.DrawLine(Pens.Black, 40, 40, 400, 40)
        g.DrawLine(Pens.Black, 40, 400, 400, 400)
        '左右
        g.DrawLine(Pens.Black, 40, 40, 40, 400)
        g.DrawLine(Pens.Black, 400, 40, 400, 400)

        '標刻度50~390
        Dim n As Double = Max - Min / 10
        Dim pixel_n As Single = 340 / (Max - Min)
        Dim str As String = Max
        For i = 1 To Max - Min + 1
            If str Mod 2 = 0 Then
                g.DrawString(str, Me.Font, Brushes.Black, 10, 50 + (i - 1) * pixel_n)
                g.DrawLine(Pens.Black, 40, 50 + (i - 1) * pixel_n, 43, 50 + (i - 1) * pixel_n)
                g.DrawLine(Pens.Black, 400, 50 + (i - 1) * pixel_n, 397, 50 + (i - 1) * pixel_n)
            End If
            str -= 1
        Next
        '畫盒
        '中間點210
        'Min
        g.DrawLine(Pens.Black, 210 - 20, 390 - (Min_over - Min) * pixel_n, 210 + 20, 390 - (Min_over - Min) * pixel_n)
        'Max
        g.DrawLine(Pens.Black, 210 - 20, 390 - (Max_over - Min) * pixel_n, 210 + 20, 390 - (Max_over - Min) * pixel_n)
        'Median
        g.DrawLine(Pens.Red, 210 - 40, 390 - (Median - Min) * pixel_n, 210 + 40, 390 - (Median - Min) * pixel_n)
        'Q3
        g.DrawLine(Pens.Blue, 210 - 40, 390 - (Q3 - Min) * pixel_n, 210 + 40, 390 - (Q3 - Min) * pixel_n)
        'Q1
        g.DrawLine(Pens.Blue, 210 - 40, 390 - (Q1 - Min) * pixel_n, 210 + 40, 390 - (Q1 - Min) * pixel_n)
        'Q3 Q1連起來
        g.DrawLine(Pens.Blue, 210 - 40, 390 - (Q1 - Min) * pixel_n, 210 - 40, 390 - (Q3 - Min) * pixel_n)
        g.DrawLine(Pens.Blue, 210 + 40, 390 - (Q1 - Min) * pixel_n, 210 + 40, 390 - (Q3 - Min) * pixel_n)
        Dim pen1 As New Pen(Brushes.Black)
        pen1.DashStyle = Drawing2D.DashStyle.Dash
        'IQR
        g.DrawLine(pen1, 210, 390 - (Max_over - Min) * pixel_n, 210, 390 - (Q3 - Min) * pixel_n)
        g.DrawLine(pen1, 210, 390 - (Min_over - Min) * pixel_n, 210, 390 - (Q1 - Min) * pixel_n)
        g.DrawString("+", Me.Font, Brushes.Red, 210 - 3, 390 - ((Outlier - Min) * pixel_n) - 3)
    End Sub
    '輸入資料
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then '如果按下Enter
            ReDim num(Val(TextBox1.Text))
            ReDim num_text(Val(TextBox1.Text))  '宣告
            ReDim L(Val(TextBox1.Text))
            For i = 1 To Val(TextBox1.Text)
                num_text(i) = New TextBox : L(i) = New Label '分配空間
                num_text(i).Size = New Size(100, 22) '設定大小 
                L(i).Text = "第" & i & "筆資料" '設定文字
                num_text(i).Location = New Point(71, 6 + (i * 30)) : L(i).Location = New Point(10, 6 + (i * 30)) '設定位置
                Controls.Add(num_text(i)) : Controls.Add(L(i)) '輸出
            Next
        End If
    End Sub
End Class
