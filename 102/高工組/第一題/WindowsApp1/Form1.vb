Public Class Form1
    Dim arr(5, 5) As Integer
    Dim New_arr(5, 5) As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '輸入資料
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            FileOpen(1, OpenFileDialog1.FileName, OpenMode.Input)
            TextBox1.Text = vbTab
            For i = 1 To 5
                For j = 1 To 5
                    Input(1, arr(i, j))
                    TextBox1.Text &= arr(i, j) & vbTab
                Next
                TextBox1.Text &= vbNewLine & vbTab
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = vbTab
        For i = 0 To 5
            For j = 0 To 5
                '初始化
                New_arr(i, j) = 0
                For k = i To 1 Step -1
                    For l = j To 1 Step -1
                        New_arr(i, j) += arr(k, l)
                    Next
                Next
                '輸出
                TextBox2.Text &= New_arr(i, j) & vbTab
            Next
            TextBox2.Text &= vbNewLine & vbTab
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim x, y As Integer
        x = Val(TextBox5.Text) - 1
        y = Val(TextBox6.Text) - 1
        TextBox7.Text = new_arr(x, y)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim x1, y1, x2, y2, n, num As Integer
        x1 = Val(TextBox3.Text) - 1
        y1 = Val(TextBox4.Text) - 1
        x2 = Val(TextBox5.Text) - 1
        y2 = Val(TextBox6.Text) - 1
        n = 0 : num = 0
        For i = x1 To x2
            For j = y1 To y2
                n += 1
                num += arr(i, j)
            Next
        Next
        TextBox8.Text = num / n
    End Sub
End Class
