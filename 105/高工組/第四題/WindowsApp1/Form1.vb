Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.ImageLocation = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Bitmap As New Bitmap(PictureBox1.Image)
        Dim NewBitmap As New Bitmap(PictureBox1.Image)
        '轉灰階
        For i = 0 To Bitmap.Height - 1
            For j = 0 To Bitmap.Width - 1
                Dim c As Color
                c = Bitmap.GetPixel(j, i)
                '灰階的值=(R+B+G)/3
                Dim n As Integer = (Val(c.R) + Val(c.G) + Val(c.B)) / 3
                NewBitmap.SetPixel(j, i, Color.FromArgb(n, n, n))
            Next
        Next
        PictureBox1.Image = NewBitmap
    End Sub

    Private Sub Button3_Click(sender As Button, e As EventArgs) Handles Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click
        Dim Bitmap As New Bitmap(PictureBox1.Image)
        Dim NewBitmap As New Bitmap(PictureBox1.Image)
        For i = 0 To Bitmap.Height - 1
            For j = 0 To Bitmap.Width - 1
                Dim c As Color
                c = Bitmap.GetPixel(j, i)
                Dim Ix, Iy, I2x, I2y, Ixy As Double
                For k = -1 To 1
                    If j + k >= 0 And j + k + 1 <= Bitmap.Width - 1 And i - 1 >= 0 Then
                        Ix += Val(Bitmap.GetPixel(j + k, i - 1).R)
                    End If
                    If j + k >= 0 And j + k + 1 <= Bitmap.Width - 1 And i + 1 <= Bitmap.Height - 1 Then
                        Ix -= Val(Bitmap.GetPixel(j + k, i + 1).R)
                    End If
                    If i + k >= 0 And i + k <= Bitmap.Width - 1 And j - 1 >= 0 Then
                        Iy += Val(Bitmap.GetPixel(j - 1, i + k).R)
                    End If
                    If i + k >= 0 And i + k <= Bitmap.Width - 1 And j + 1 <= Bitmap.Width - 1 Then
                        Iy -= Val(Bitmap.GetPixel(j + 1, i + k).R)
                    End If
                Next
                Ix *= 0.166666667
                Iy *= 0.166666667
                I2x = Ix ^ 2
                I2y = Iy ^ 2
                Ixy = Ix * Iy
                '水平
                If sender.Text = Button3.Text Then
                        If Ix >= 255 Then
                            Ix = 255
                        ElseIf Ix <= 0 Then
                            Ix = 0
                        End If
                        NewBitmap.SetPixel(j, i, Color.FromArgb(Ix, Ix, Ix))
                    ElseIf sender.Text = Button4.Text Then
                        If Iy >= 255 Then
                            Iy = 255
                        ElseIf Iy <= 0 Then
                            Iy = 0
                        End If
                        '垂直
                        NewBitmap.SetPixel(j, i, Color.FromArgb(Iy, Iy, Iy))
                    ElseIf sender.Text = Button5.Text Then
                        If I2x >= 255 Then
                            I2x = 255
                        ElseIf Ix <= 0 Then
                            I2x = 0
                        End If
                        '水平、水平
                        NewBitmap.SetPixel(j, i, Color.FromArgb(I2x, I2x, I2x))
                    ElseIf sender.Text = Button6.Text Then
                        If I2y >= 255 Then
                            I2y = 255
                        ElseIf I2y <= 0 Then
                            I2y = 0
                        End If
                        '垂直、垂直
                        NewBitmap.SetPixel(j, i, Color.FromArgb(I2y, I2y, I2y))
                    ElseIf sender.Text = Button7.Text Then
                        If Ixy >= 255 Then
                            Ixy = 255
                        ElseIf Ixy <= 0 Then
                            Ixy = 0
                        End If
                        '水平、垂直
                        NewBitmap.SetPixel(j, i, Color.FromArgb(Ixy, Ixy, Ixy))
                    End If

            Next
        Next
        PictureBox2.Image = NewBitmap
    End Sub
End Class
