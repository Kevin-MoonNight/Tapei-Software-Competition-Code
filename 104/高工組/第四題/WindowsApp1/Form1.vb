Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.ImageLocation = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim QM1, QM2 As Double
        Dim ua, oa2, ub, ob2 As Double
        Dim aP, bP As Double
        Dim bitmap As New Bitmap(PictureBox1.Image)
        Dim n As Double
        n = bitmap.Height * bitmap.Width
        For i = 0 To bitmap.Width - 1
            For j = 0 To bitmap.Height - 1
                Dim c As Color
                c = bitmap.GetPixel(i, j)
                aP = Val(c.R) - Val(c.G)
                bP = (Val(c.R) + Val(c.G)) * 0.5 - Val(c.B)
                ua += (1 / n) * aP
                oa2 += (1 / n) * (aP ^ 2 - ua ^ 2)
                ub += (1 / n) * bP
                ob2 += (1 / n) * (bP ^ 2 - ub ^ 2)
            Next
        Next
        TextBox1.Text = (Math.Sqrt(oa2 + ob2) + 0.3 * Math.Sqrt(ua ^ 2 + ub ^ 2)) / 85.59
        TextBox2.Text = 0.02 * Math.Log((oa2) / (Math.Abs(ua) ^ 0.2)) * Math.Log((ob2) / (Math.Abs(ub) ^ 0.2))
    End Sub
End Class
