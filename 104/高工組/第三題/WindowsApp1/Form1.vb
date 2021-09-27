Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.ImageLocation = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '比對用
        Dim bitmap As New Bitmap(PictureBox1.Image)
        '輸出用
        Dim Newbitmap As New Bitmap(PictureBox1.Image)
        For i = 1 To bitmap.Width - 1
            For j = 1 To bitmap.Height - 1
                Dim c As Color
                c = bitmap.GetPixel(i, j)
                '判斷是否是白色
                If Val(c.R) = 255 Then
                    '擴散
                    For k = i - 1 To i + 1
                        For l = j - 1 To j + 1
                            If k >= 0 And k <= bitmap.Width - 1 And l >= 0 And l <= bitmap.Height - 1 Then
                                Newbitmap.SetPixel(k, l, Color.FromArgb(255, 255, 255))
                            End If
                        Next
                    Next
                End If
            Next
        Next
        '輸出
        PictureBox1.Image = Newbitmap
    End Sub
End Class
