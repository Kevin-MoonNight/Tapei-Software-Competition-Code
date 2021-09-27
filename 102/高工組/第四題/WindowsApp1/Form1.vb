Public Class Form1
    Dim Newbitmap(,) As Double
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.Load(TextBox1.Text)
        Dim Bitmap1 As New Bitmap(PictureBox1.Image)
        ReDim Newbitmap(Bitmap1.Width, Bitmap1.Height)
        TextBox2.Text = ""
        For i = 0 To Bitmap1.Width - 1
            For j = 0 To Bitmap1.Height - 1
                Dim c As New Color
                c = Bitmap1.GetPixel(i, j)
                Newbitmap(i, j) = Val(c.R)
                TextBox2.Text &= "_" & c.R
            Next
            TextBox2.Text &= vbNewLine
        Next
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Bitmap1 As New Bitmap(PictureBox1.Image)
        For i = 0 To Bitmap1.Width - 1
            For j = 0 To Bitmap1.Height - 1
                Dim err As Double
                '判斷
                If Newbitmap(i, j) >= 128 Then
                    err = Newbitmap(i, j) - 255
                    Newbitmap(i, j) = 255

                Else
                    err = Newbitmap(i, j)
                    Newbitmap(i, j) = 0
                End If
                '擴散誤差值
                For k = i To i + 1
                    For l = j - 1 To j + 1
                        '確保不會超出點陣圖範圍
                        If k >= 0 And k <= Bitmap1.Width - 1 And l >= 0 And l <= Bitmap1.Height - 1 Then
                            '前一個不執行
                            If k = i And l = j - 1 Then
                            Else
                                '判斷點不執行
                                If k = i And l = j Then
                                Else
                                    If k = i And l = j + 1 Then
                                        '7/16
                                        Newbitmap(k, l) += err * (7 / 16)
                                    ElseIf k = i + 1 And l = j - 1 Then
                                        '3/16
                                        Newbitmap(k, l) += err * (3 / 16)
                                    ElseIf k = i + 1 And l = j Then
                                        '5/16
                                        Newbitmap(k, l) += err * (5 / 16)
                                    ElseIf k = i + 1 And l = j + 1 Then
                                        '1/16
                                        Newbitmap(k, l) += err * (1 / 16)
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
            Next
        Next
        '輸出
        TextBox3.Text = ""
        For i = 1 To Bitmap1.Width - 1
            For j = 1 To Bitmap1.Height - 1
                Bitmap1.SetPixel(i, j, Color.FromArgb(Newbitmap(i, j)))
                TextBox3.Text &= "_" & Newbitmap(i, j)
            Next
            TextBox3.Text &= vbNewLine
        Next
        PictureBox2.Image = Bitmap1
    End Sub
End Class
