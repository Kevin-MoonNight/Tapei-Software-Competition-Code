Public Class Form1
    Dim n As Integer = 0
    '用來存放n筆資料路徑
    Dim DATA(999) As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '每讀入一次增加1筆資料
        n += 1
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            DATA(n) = OpenFileDialog1.FileName
        End If
        '存放n筆資料的路徑
        Dim Text(n) As String
        '存放總共有幾筆資料
        Dim P As Integer
        '載入資料
        For I = 1 To n
            FileOpen(I, DATA(I), OpenMode.Input)
            Input(I, Text(I))
            '計算有幾筆資料
            P += Val(Split(Text(I), " ")(1))
            FileClose()
        Next
        '宣告存放水平位址、垂直位址、類別 的陣列
        Dim x(P), y(P), L(P) As Integer
        Dim T As Integer = 1
        '載入資料
        For i = 1 To n
            '存放分割後的資料
            Dim DataText() As String = Split(Text(i), " ")
            '將資料輸入進陣列
            For j = 1 To Val(DataText(1))
                x(T) = Val(DataText(2 + ((j - 1) * 3)))
                y(T) = Val(DataText(2 + ((j - 1) * 3) + 1))
                L(T) = Val(DataText(2 + ((j - 1) * 3) + 2))
                T += 1
            Next
        Next
        '尋找最大、最小坐標值
        Dim MaxY, MinY, MaxX, MinX As Integer
        MaxY = 0 : MinY = 999999 : MaxX = 0 : MinX = 999999
        For i = 1 To P
            If x(i) > MaxX Then
                MaxX = x(i)
            End If
            If x(i) < MinX Then
                MinX = x(i)
            End If
            If y(i) > MaxY Then
                MaxY = y(i)
            End If
            If y(i) < MinY Then
                MinY = y(i)
            End If
        Next
        MaxX = conver(MaxX) : MaxY = conver(MaxY)
        MinX = conver2(MinX) : MinY = conver2(MinY)
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        'x 30 ~ 380 y 20 ~370 
        '上下左右
        g.DrawLine(Pens.Black, 30, 20, 380, 20)
        g.DrawLine(Pens.Black, 30, 370, 380, 370)
        g.DrawLine(Pens.Black, 30, 20, 30, 370)
        g.DrawLine(Pens.Black, 380, 20, 380, 370)
        Dim value_n As Single = 350 / 10
        For i = 1 To 11
            '左右
            g.DrawLine(Pens.Black, 30, 20 + ((i - 1) * value_n), 33, 20 + ((i - 1) * value_n))
            g.DrawLine(Pens.Black, 380, 20 + ((i - 1) * value_n), 377, 20 + ((i - 1) * value_n))
            g.DrawString(MaxY - (((MaxY - MinY) / 10) * (i - 1)), Me.Font, Brushes.Black, 1, 20 + ((i - 1) * value_n))
            '下上
            g.DrawLine(Pens.Black, 30 + ((i - 1) * value_n), 370, 30 + ((i - 1) * value_n), 367)
            g.DrawLine(Pens.Black, 30 + ((i - 1) * value_n), 20, 30 + ((i - 1) * value_n), 23)
            g.DrawString(MinX + (((MaxX - MinX) / 10) * (i - 1)), Me.Font, Brushes.Black, 30 + ((i - 1) * value_n), 390)
        Next
        Dim x_n, y_n As Single
        x_n = (350 / (MaxX - MinX)) : y_n = (350 / (MaxY - MinY))
        '把資料畫出來
        For i = 1 To P
            If L(i) = 1 Then
                g.DrawEllipse(Pens.Red, (30 + (x(i) * x_n)) - 3, (370 - (y(i) * y_n)) - 3, 5, 5)
            Else
                g.DrawString("＊", Me.Font, Brushes.Blue, (30 + (x(i) * x_n)) - 3, (370 - (y(i) * y_n)) - 3)
            End If
        Next
    End Sub
    Function conver(ByVal num As Integer) As Integer
        num = (Val(Mid(num, 1, 1)) + 1) * 100
        Return num
    End Function
    Function conver2(ByVal num As Integer) As Integer
        If num < 100 Then
            num = 0
        Else
            num = Val(Mid(num, 1, 1)) * 100
        End If
        Return num
    End Function
End Class
