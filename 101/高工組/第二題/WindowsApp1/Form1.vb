Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.ImageLocation = TextBox1.Text
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim bitmap As New Bitmap(PictureBox1.Image)
        Dim Max_X, Min_X, Max_Y, Min_Y As Integer
        Max_X = 0 : Max_Y = 0 : Min_X = 999999 : Min_Y = 999999
        For i = 1 To bitmap.Width - 1
            For j = 1 To bitmap.Height - 1
                Dim C As New Color
                '取得該格像素
                C = bitmap.GetPixel(i, j)
                If Val(C.R) <= 100 Then
                    If i > Max_X Then
                        Max_X = i
                    ElseIf i < Min_X Then
                        Min_X = i
                    End If
                    If j > Max_Y Then
                        Max_Y = j
                    ElseIf j < Min_Y Then
                        Min_Y = j
                    End If
                End If
            Next
        Next
        For i = Min_X To Max_X
            '上
            bitmap.SetPixel(i, Min_Y, Color.Red)
            '下
            bitmap.SetPixel(i, Max_Y, Color.Red)
        Next
        For i = Min_Y To Max_Y
            '左
            bitmap.SetPixel(Min_X, i, Color.Red)
            '右
            bitmap.SetPixel(Max_X, i, Color.Red)
        Next
        PictureBox1.Image = bitmap
    End Sub
End Class
