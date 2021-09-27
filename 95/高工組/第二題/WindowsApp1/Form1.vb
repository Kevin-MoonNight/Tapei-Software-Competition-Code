Public Class Form1
    Private Sub HScrollBar1_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar1.ValueChanged
        TextBox5.Text = HScrollBar1.Value
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '載入圖片

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For I = 1 To 7
            CType(Me.Controls("Textbox" & I), TextBox).Text = ""
        Next
        ComboBox1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, z As EventArgs) Handles Button3.Click
        Dim a, b, c, d, e, f As Integer
        a = Val(TextBox1.Text)
        b = Val(TextBox2.Text)
        c = Val(ComboBox1.Text)
        d = Val(TextBox3.Text)
        e = Val(TextBox4.Text)
        f = Val(TextBox5.Text)
        If IsDBNull((c * e - b * f) / (a * e - b * d)) = True Or IsDBNull((a * f - c * d) / (a * e - b * d)) = False Then
            Dim bt As New Bitmap(PictureBox1.Image)
            PictureBox1.Image = PictureBox2.Image
            PictureBox2.Image = bt
            MsgBox("無解")
        Else
            TextBox6.Text = (c * e - b * f) / (a * e - b * d)
            TextBox7.Text = (a * f - c * d) / (a * e - b * d)
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub
End Class
