Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox4.Text = ""
        PictureBox1.ImageLocation = "C:\Users\User\Desktop\VB北市歷屆檔案\100\高工組\第一題\0.png" : PictureBox2.ImageLocation = "C:\Users\User\Desktop\VB北市歷屆檔案\100\高工組\第一題\0.png" : PictureBox3.ImageLocation = "C:\Users\User\Desktop\VB北市歷屆檔案\100\高工組\第一題\0.png"
        For I = 1 To Val(TextBox3.Text) - 1
            For J = 1 To Val(TextBox3.Text) - 1
                For K = 1 To Val(TextBox3.Text) - 1
                    If I + J = Val(TextBox1.Text) And I + K = Val(TextBox2.Text) And I <> J And J <> K And I <> K Then
                        If TextBox4.Text = "" Then
                            PictureBox1.ImageLocation = "C:\Users\User\Desktop\VB北市歷屆檔案\100\高工組\第一題\" & I & ".png"
                            PictureBox2.ImageLocation = "C:\Users\User\Desktop\VB北市歷屆檔案\100\高工組\第一題\" & J & ".png"
                            PictureBox3.ImageLocation = "C:\Users\User\Desktop\VB北市歷屆檔案\100\高工組\第一題\" & K & ".png"
                        End If
                        TextBox4.Text &= "A=" & I & " B=" & J & " C=" & K & vbNewLine
                    End If
                Next
            Next
        Next
        If TextBox4.Text = "" Then
            TextBox4.Text = "無解"
        End If
    End Sub
End Class
