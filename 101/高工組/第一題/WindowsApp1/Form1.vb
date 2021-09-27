Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim N1, N2, N3, N4, X, Y As Integer
        N1 = Val(TextBox1.Text) : N2 = Val(TextBox2.Text) : N3 = Val(TextBox3.Text) : N4 = Val(TextBox4.Text)
        TextBox5.Text = ""
        For i = 1 To 1000 Step 1
            For j = 1 To 1000 Step 1
                Dim num As Double = i * j
                Do Until Strings.Right(num, 1) <> "0"
                    If num / 10 = N1 And ((i * j) / (num / 10)) + ((i + j) * N2) + (i * N3) + (j * N4) = i * j Then
                        TextBox5.Text = "X=" & i & " Y=" & j & vbNewLine
                    End If
                    num = num / 10
                Loop
                If num = N1 And ((i * j) / (num)) + ((i + j) * N2) + (i * N3) + (j * N4) = i * j Then
                    TextBox5.Text = "X=" & i & " Y=" & j & vbNewLine
                End If
            Next
        Next
        If TextBox5.Text = "" Then
            TextBox5.Text = "無解"
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class
