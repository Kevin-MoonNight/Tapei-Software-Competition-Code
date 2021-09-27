Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim x0, x1, y, z As Double
        x0 = Val(TextBox1.Text) : x1 = Val(TextBox2.Text) : y = Val(TextBox3.Text) : z = Val(TextBox4.Text)
        If x0 + x1 > 1 Then
            RichTextBox1.Text = "無解"
        Else
            Dim n As Double = (x0 * y) + (x1 * z)

            RichTextBox1.Text = (((x0 * y) / n) + ((x1 * (z)) / n))
        End If

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim x0, x1, y, z As Double
        x0 = Val(TextBox1.Text) : x1 = Val(TextBox2.Text) : y = Val(TextBox3.Text) : z = Val(TextBox4.Text)
        If x0 + x1 > 1 Then
            RichTextBox1.Text = "無解"
        Else

        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
End Class
