Public Class Form1
    Dim P1(4), N1(13), P2(4), N2(13) As Integer

    Dim Pic(5), Pic2(5) As PictureBox
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '動態生成
        For i = 1 To 5
            Pic(i) = New PictureBox
            Pic(i).Size = New Size(200, 150)
            Pic(i).SizeMode = PictureBoxSizeMode.StretchImage
            Pic(i).Location = New Point(10 + (50 * (i - 1)), 60)
        Next
        FileOpen(1, TextBox1.Text, OpenMode.Input)
        Label1.Text = LineInput(1)
        Dim Text() As String = Split(Label1.Text, " ")
        For i = UBound(Text) To 0 Step -1
            Dim n As Integer = 0
            n += Val(Mid(Text(i), 2, 1))
            N1(Val(Mid(Text(i), 2, 1))) += 1
            If Mid(Text(i), 1, 1) = "C" Then
                P1(4) += 1
                n += 13 * 3
            ElseIf Mid(Text(i), 1, 1) = "D" Then
                P1(3) += 1
                n += 13 * 2
            ElseIf Mid(Text(i), 1, 1) = "H" Then
                P1(2) += 1
                n += 13 * 1
            ElseIf Mid(Text(i), 1, 1) = "S" Then
                P1(1) += 1
            End If
            Pic(i + 1).Image = New Bitmap("C:\Users\User\Desktop\VB北市歷屆檔案\106\高工組\第二題\" & n & ".gif")
            Controls.Add(Pic(i + 1))
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i = 1 To 13
            N2(i) = 0
        Next
        For i = 1 To 4
            P2(i) = 0
        Next
        Dim Rand As New Random
        For i = 1 To 5
            Controls.Remove(Pic2(i))
            Pic2(i) = New PictureBox
            Pic2(i).Size = New Size(200, 150)
            Pic2(i).SizeMode = PictureBoxSizeMode.StretchImage
            Pic2(i).Location = New Point(10 + (50 * (i - 1)), 260)
        Next
        For i = 5 To 1 Step -1
            Dim text As String = ""
            Dim P As Integer
            Dim n As Integer = 0
            '隨機設定數字
            n = Rand.Next(1, 14)
            N2(n) += 1
            '隨機設定花色
            P = Rand.Next(1, 5)
            P2(P) += 1
            n += 13 * (P - 1)
            Pic2(i).Image = Nothing
            Pic2(i).Image = New Bitmap("C:\Users\User\Desktop\VB北市歷屆檔案\106\高工組\第二題\" & n & ".gif")
            Controls.Add(Pic2(i))
        Next
        '判斷
        Dim num1, num2 As Integer
        num1 = 0 : num2 = 0
        num1 = conver(N1, P1)
        num2 = conver(N2, P2)
        TextBox2.Text = ""
        If num1 = 10 Then
            TextBox2.Text &= "甲方類別：4張相同" & vbNewLine
        ElseIf num1 = 7 Then
            TextBox2.Text &= "甲方類別：3+2張相同" & vbNewLine
        ElseIf num1 = 5 Then
            TextBox2.Text &= "甲方類別：3張相同" & vbNewLine
        ElseIf num1 = 4 Then
            TextBox2.Text &= "甲方類別：2+2張相同" & vbNewLine
        ElseIf num1 = 2 Then
            TextBox2.Text &= "甲方類別：2張相同" & vbNewLine
        ElseIf num1 = 1 Then
            TextBox2.Text &= "甲方類別：花色相同" & vbNewLine
        ElseIf num1 = 0 Then
            TextBox2.Text &= "甲方類別：其他" & vbNewLine
        End If
        If num2 = 10 Then
            TextBox2.Text &= "乙方類別：4張相同" & vbNewLine
        ElseIf num2 = 7 Then
            TextBox2.Text &= "乙方類別：3+2張相同" & vbNewLine
        ElseIf num2 = 5 Then
            TextBox2.Text &= "乙方類別：3張相同" & vbNewLine
        ElseIf num2 = 4 Then
            TextBox2.Text &= "乙方類別：2+2張相同" & vbNewLine
        ElseIf num2 = 2 Then
            TextBox2.Text &= "乙方類別：2張相同" & vbNewLine
        ElseIf num2 = 1 Then
            TextBox2.Text &= "乙方類別：花色相同" & vbNewLine
        ElseIf num2 = 0 Then
            TextBox2.Text &= "乙方類別：其他" & vbNewLine
        Else
            TextBox2.Text = "Y"
            Exit Sub
        End If

        If num1 > num2 Then
            TextBox2.Text &= "甲方獲勝" & vbNewLine
        ElseIf num2 > num1 Then
            TextBox2.Text &= "乙方獲勝" & vbNewLine
        ElseIf num1 = num2 Then
            TextBox2.Text &= "和局" & vbNewLine
        End If
    End Sub
    Function conver(ByVal n() As Integer, ByVal p() As Integer) As Integer
        Dim num1 As Integer = 0
        For i = 1 To 13
            Dim T As Boolean = False
            '4
            If n(i) >= 4 Then
                num1 += 10
                Exit For
            ElseIf N(i) = 3 Then
                '3+2
                For j = 1 To 13
                    If n(j) = 2 Then
                        T = True
                    End If
                Next
                '3
                If T = False Then
                    num1 += 5
                Else
                    num1 += 7
                End If
                Exit For
            ElseIf n(i) = 2 Then
                T = False
                '3+2
                For j = 1 To 13
                    If n(j) = 3 Then
                        T = True
                    End If
                Next
                If T = True Then
                    num1 += 7
                    Exit For
                End If
                '2+2
                For j = 1 To 13
                    If i <> j And n(j) = 2 Then
                        T = True
                    End If
                Next
                '2
                If T = False Then
                    num1 += 2
                Else
                    num1 += 4
                End If
                Exit For
            End If
        Next
        If num1 = 0 Then
            '花色相同
            For j = 1 To 4
                If p(j) = 5 Then
                    num1 += 1
                    Exit For
                End If
            Next
        End If
        Return num1
    End Function
End Class
