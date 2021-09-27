Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim num1() As String = Split("0," & TextBox1.Text, ",")
        Dim num2() As String = Split("0," & TextBox2.Text, ",")
        Dim x_n, y_n As Integer
        '判斷有幾個可以用的數值
        y_n = 0
        For i = 1 To UBound(num2)
            x_n = 0
            For j = 1 To UBound(num1)
                If num1(j) <> "" Then
                    x_n += 1
                End If
            Next
            If num2(i) <> "" Then
                y_n += 1
            End If
        Next
        '輸入數值
        Dim arr(y_n, x_n) As Integer
        For i = 1 To UBound(num2)
            For j = 1 To UBound(num1)
                If num1(j) <> "" Then
                    arr(0, j) = num1(j)
                End If
            Next
            If num2(i) <> "" Then
                arr(i, 0) = num2(i)
            End If
        Next
        '照公式計算
        For i = 1 To y_n
            For j = 1 To x_n
                If i = 1 And j = 1 Then
                    arr(i, j) = Math.Abs(arr(0, j) - arr(i, 0))
                ElseIf i = 1 And j > 1 Then
                    arr(i, j) = Math.Abs(arr(0, j) - arr(i, 0)) + arr(1, j - 1)
                ElseIf i > 1 And j = 1 Then
                    arr(i, j) = Math.Abs(arr(0, j) - arr(i, 0)) + arr(i - 1, 1)
                ElseIf i > 1 And j > 1 Then
                    Dim Min As Integer
                    Min = Math.Min(arr(i - 1, j), arr(i - 1, j - 1))
                    Min = Math.Min(Min, arr(i, j - 1))
                    arr(i, j) = Math.Abs(arr(0, j) - arr(i, 0)) + Min
                End If
            Next
        Next
        '輸出
        TextBox3.Text = ""
        For i = 0 To y_n
            For j = 0 To x_n
                TextBox3.Text &= arr(i, j) & vbTab
            Next
            TextBox3.Text &= vbNewLine
        Next
    End Sub
End Class
