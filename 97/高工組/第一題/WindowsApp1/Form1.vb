Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim N As Integer = Val(TextBox1.Text)
        Dim T As Integer
        TextBox2.Text = ""
        If N > 1000 Or N < 1 Then
            MsgBox("請重新輸入n")
        Else
            For I = 1 To N
                T = 0
                For J = 1 To I
                    If I Mod J = 0 Then
                        T += 1
                    End If
                Next
                If T = 2 Then
                    TextBox2.Text &= I & vbNewLine
                End If
            Next
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim num1 As Integer = Val(TextBox3.Text)
        Dim num2 As Integer = Val(TextBox4.Text)
        TextBox5.Text = vbTab & num1 & "  " & num2 & vbNewLine & "............................" & vbNewLine
        Dim n As Integer = 2
        Do Until n > num1 Or n > num2
            If num1 Mod n = 0 And num2 Mod n = 0 Then
                num1 /= n : num2 /= n
                TextBox5.Text &= "      " & n & "      " & num1 & "    " & num2 & vbNewLine & "............................" & vbNewLine
            Else
                n += 1
            End If
        Loop
        num1 = Val(TextBox3.Text)
        num2 = Val(TextBox4.Text)
        '求最大公因數
        Dim min As Integer = Math.Min(num1, num2)
        For i = min To 1 Step -1
            If num1 Mod i = 0 And num2 Mod i = 0 Then
                Label4.Text = "最大公因數" & "    " & i
                Exit For
            End If
        Next
        Dim ans1, ans2 As Integer
        ans1 = 1 : ans2 = 1
        '最小公倍數
        Do Until ans1 * num1 = ans2 * num2
            If ans1 * num1 > ans2 * num2 Then
                ans2 += 1
            Else
                ans1 += 1
            End If
        Loop
        Label5.Text = "最小公倍數" & "    " & ans1 * num1
    End Sub
End Class
