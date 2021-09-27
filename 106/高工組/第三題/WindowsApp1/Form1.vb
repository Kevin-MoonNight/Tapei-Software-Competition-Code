Public Class Form1
    Dim Bitmap As New Bitmap(620, 620)
    Dim G As Graphics = Graphics.FromImage(Bitmap)
    Dim P(99) As PointF
    Dim P_n As Integer
    Dim Start As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox1.Checked = True
        Pic()
    End Sub
    Sub Pic()
        G.Clear(Color.White) '清除螢幕
        For i = 0 To 60
            '直
            G.DrawLine(Pens.Black, 10 + (i * 10), 10, 10 + (i * 10), 610)
            '橫
            G.DrawLine(Pens.Black, 10, 10 + (i * 10), 610, 10 + (i * 10))
        Next
        PictureBox1.Image = Bitmap
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '清除螢幕
        Pic()
        PictureBox1.Image = Bitmap
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '內插
        Dim L(P_n) As Lagrange
        For j = 0 To P_n '基底多項式j
            L(j).n = 1
            ReDim L(j).X(99)
            Dim T As Integer = 0
            If j = 0 Then
                T = 1
            End If
            L(j).X(0) = P(T).X * -1 : L(j).X(1) = 1
            For k = 0 To P_n '分配律
                If k <> j And k <> T Then '不執行自己
                    Dim ST_X(99) As Double
                    For I = 0 To 98 '相乘之前先把X記錄下來
                        ST_X(I) = L(j).X(I)
                    Next
                    For i = 0 To 99 Step 1 '相乘P(K).X
                        If ST_X(i) <> 0 Then
                            L(j).X(i) = ST_X(i) * (P(k).X * -1)
                        End If
                    Next
                    For i = 1 To 98 Step 1 '相乘X
                        If ST_X(i - 1) <> 0 Then '乘X會讓X的次方+1
                            L(j).X(i) += ST_X(i - 1)
                        End If
                    Next
                End If
                If k <> j Then
                    L(j).n *= (P(j).X - P(k).X) '分母相乘
                End If
            Next
        Next
        Dim P2 As Lagrange
        ReDim P2.X(99)
        For I = 0 To P_n
            For J = 99 To 0 Step -1
                If L(I).X(J) <> 0 Then '與Y相乘
                    P2.X(J) += (P(I).Y * L(I).X(J)) / L(I).n
                End If
            Next
        Next
        '畫圖
        'x 10 ~610 y 10 ~ 610
        '畫線
        Dim A1 As New PointF(10 + (0 * 10), 0)
        For I = 1 To 99
            A1.Y += (P2.X(I) * 0 ^ I)
        Next
        A1.Y = 610 - (10 * (A1.Y + P2.X(0)))
        For I = 0 To 60 Step 0.1
            Dim Y As Single = 0
            For J = 1 To 99
                Y += (P2.X(J) * I ^ J)
            Next
            Y = 610 - (10 * (Y + P2.X(0)))
            Dim X As Single = 10 + (I * 10)
            G.DrawLine(Pens.Red, A1.X, A1.Y, X, Y)
            A1.X = X : A1.Y = Y
        Next
        PictureBox1.Image = Bitmap
    End Sub
    Structure Lagrange
        Dim X() As Double
        Dim n As Double
    End Structure
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '讀檔
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Pic()
            FileOpen(1, OpenFileDialog1.FileName, OpenMode.Input)
            P_n = -1 : Start = 0
            Do Until EOF(1)
                P_n += 1
                Dim Text As String
                Text = LineInput(1)
                P(P_n).X = Val(Split(Text, " ")(0)) : P(P_n).Y = Val(Split(Text, " ")(1))
                If P(P_n).X <P(Start).X Then
                    Start = P_n
                End If
            Loop
            FileClose()
            '畫點
            Pic2()
        End If
    End Sub
    Sub Pic2()
        '畫點
        For i = 0 To P_n
            G.FillEllipse(Brushes.Blue, 10 + (10 * P(i).X) - 2, 610 - (10 * P(i).Y) - 2, 3, 3)
            G.DrawEllipse(Pens.Blue, 10 + (10 * P(i).X) - 3, 610 - (10 * P(i).Y) - 3, 5, 5)
        Next
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            G.Clear(Color.White) '清除螢幕
            PictureBox1.Image = Bitmap
            Button2_Click(sender, e)
            Pic2()
        Else
            Pic() '畫格線
            Pic2()
            Button2_Click(sender, e)
        End If
    End Sub
End Class
