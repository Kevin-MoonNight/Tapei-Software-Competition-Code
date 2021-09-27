Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ans(10) As Integer
        Dim str1, str2 As String
        '防止多個空白
        str1 = conver2(TextBox1.Text)
        str2 = conver2(TextBox3.Text)
        '計算
        ans = conver(Split(str1 & " "), ans, True)
        ans = conver(Split(str2 & " "), ans, False)
        '清除上次答案
        TextBox4.Text = ""
        '輸出
        For i = 10 To 0 Step -1
            If ans(i) <> 0 Then
                TextBox4.Text &= ans(i) & " " & i & " "
            End If
        Next
    End Sub
    Function conver2(ByVal strtext As String) As String
        Dim str As String = ""
        For i = 0 To UBound(Split(strtext, " "))
            If IsNumeric(Split(strtext, " ")(i)) = True Then
                str &= Split(strtext, " ")(i) & " "
            End If
        Next
        Return str
    End Function
    Function conver(ByVal str() As String, ByVal ans() As Integer, ByVal T As Boolean)
        '存放乘法
        Dim st(10) As Integer
        For i = 0 To UBound(str) - 1
            '判斷是不是數字
            If IsNumeric(str(i)) = True Then
                Dim num As Integer = str(i)
                '判斷加減乘
                If TextBox2.Text = "+" Or ans(str(i + 1)) = 0 And T = True Then
                    ans(str(i + 1)) += str(i)
                ElseIf TextBox2.Text = "-" Then
                    ans(str(i + 1)) -= str(i)
                ElseIf TextBox2.Text = "*" Then
                    For J = 0 To UBound(ans) - 1
                        If ans(J) <> 0 Then
                            st(str(i + 1) + J) += Val(str(i)) * ans(J)
                        End If
                    Next
                End If
                i += 1
            End If
        Next
        If TextBox2.Text = "*" And T = False Then
            Return st
        End If
        Return ans
    End Function
End Class
