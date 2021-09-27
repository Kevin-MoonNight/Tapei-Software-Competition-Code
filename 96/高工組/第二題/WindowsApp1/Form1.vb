Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim num() As String = Split(TextBox1.Text, " ")
        Dim ans1, ans2 As Double
        ans1 = 0 : ans2 = 0
        Dim n, Max, Min As Double
        n = 6 : Max = 0 : Min = 9999
        '判斷輸入是否正確
        If UBound(num) <> n - 1 Then
            MsgBox("輸入錯誤請重新輸入")
            Exit Sub
        Else
            For i = 0 To UBound(num)
                '判斷是否有超過100或者是不是數字
                If Val(num(i)) > 100 Or IsNumeric(Val(num(i))) = False Then
                    MsgBox("輸入錯誤請重新輸入")
                    Exit Sub
                End If
            Next
        End If
        '平均
        For i = 0 To UBound(num)
            '計算平均
            ans1 += Val(num(i))
            '計算最大
            If Val(num(i)) > Max Then
                Max = Val(num(i))
            End If
            '最算最小
            If Val(num(i)) < Min Then
                Min = Val(num(i))
            End If
        Next
        ans1 = ans1 / n
        '標準差
        For i = 0 To UBound(num)
            ans2 += (Val(num(i)) - ans1) ^ 2
        Next
        ans2 = Math.Sqrt((1 / n) * ans2)
        Label2.Text = "平均值 = " & ans1
        Label3.Text = "最大值 = " & Max
        Label4.Text = "最小值 = " & Min
        Label5.Text = "標準差 = " & ans2
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = "10 30 50 60 80 100"
        Call Button1_Click(sender, e)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        Label2.Text = "平均值 = "
        Label3.Text = "最大值 = "
        Label4.Text = "最小值 = "
        Label5.Text = "標準差 = "
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub
End Class
