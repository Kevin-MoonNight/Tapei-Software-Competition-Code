Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '判斷該密碼是否正確
        If Conver(TextBox1.Text) = 0 Then
            TextBox2.Text = TextBox1.Text & " 是正確密碼文字"
        Else
            TextBox2.Text = TextBox1.Text & " 不是正確密碼文字"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '判斷該密碼不符合哪一項
        If Conver(TextBox3.Text) = 0 Then
            TextBox4.Text = TextBox3.Text & " 是正確密碼文字"
        Else
            TextBox4.Text = "本輸入密碼無法滿足第" & Conver(TextBox3.Text) & "條件"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '找出正確密碼
        Dim Text As String = TextBox5.Text
        TextBox7.Text = Conver2(Text)
        Text = TextBox6.Text
        TextBox8.Text = Conver2(Text)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Text(4) As String
        Text(1) = "L" : Text(2) = "M" : Text(3) = "N" : Text(4) = "O"
        Dim n As Integer = 0
        TextBox10.Text = ""
        For I = 1 To 4
            If Conver(Text(I) & Text(I) & Text(I)) = 0 Then
                n += 1 : TextBox10.Text &= Text(I) & Text(I) & Text(I) & "、"
            End If
        Next
        TextBox9.Text = n : TextBox10.Text = Mid(TextBox10.Text, 1, Len(TextBox10.Text) - 1)
    End Sub
    Function Conver2(ByVal Text As String) As String
        Dim X As Integer = 0
        For i = 1 To Len(Text)
            If Mid(Text, i, 1) = "X" Then
                X = i
            End If
        Next
        Dim Ans1, Ans2, Ans As String
        Ans1 = "" : Ans2 = "" : Ans = ""
        If X = 1 Then
            Ans1 = ""
            Ans2 = Mid(Text, X + 1, Len(Text))
        ElseIf X = 2 Or X = 3 Then
            Ans1 = Mid(Text, 1, X - 1)
            Ans2 = Mid(Text, X + 1, Len(Text))
        ElseIf X = 4 Then
            Ans1 = Mid(Text, 1, X - 1)
            Ans2 = ""
        End If
        For I = Asc("A") To Asc("Z")
            If Conver(Ans1 & Chr(I) & Ans2) = 0 Then
                Ans = Ans1 & Chr(I) & Ans2
            End If
        Next
        Return Ans
    End Function
    Function Conver(ByVal Text As String) As Integer
        Dim P(Asc("Z")) As Integer
        For I = 1 To Len(Text)
            P(Asc(Mid(Text, I, 1))) += 1
        Next
        '密碼最短為三個字
        If Len(Text) < 3 Then
            Return 1
        End If
        'K不能當字首
        If Mid(Text, 1, 1) = "K" Then
            Return 2
        End If
        '判斷是否有L有的話是否出現兩次
        If P(Asc("L")) = 2 Then
            Return 3
        End If
        '判斷後1個或2個字是否是M
        If Mid(Text, Len(Text), 1) = "M" Or Mid(Text, Len(Text) - 1, 1) = "M" Then
            Return 4
        End If
        '如果有字母K 則辦判斷裡面是否有N
        If P(Asc("K")) >= 1 And P(Asc("N")) = 0 Then
            Return 5
        End If
        '判斷是否有L 有的話O不能是最後一個
        If P(Asc("L")) = 0 And Mid(Text, Len(Text), 1) = "O" Then
            Return 6
        End If
        Return 0
    End Function
End Class
