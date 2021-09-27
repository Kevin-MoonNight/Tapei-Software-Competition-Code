Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = "a" : Label2.Text = "b" : Label3.Text = "c" : Label4.Text = "d" : Label5.Text = ""
        For i = 1 To 6
            If Val(CType(Me.Controls("Textbox" & i), TextBox).Text) > 20 Or Val(CType(Me.Controls("Textbox" & i), TextBox).Text) < -20 Then
                Label5.Text = "數字超過範圍"
                Exit Sub
            End If
        Next
        For I = -20 To 20
            For J = -20 To 20
                For K = -20 To 20
                    For L = -20 To 20
                        If J + K = Val(TextBox1.Text) And I + J = Val(TextBox2.Text) And K + L = Val(TextBox3.Text) And I + L = Val(TextBox4.Text) And J + L = Val(TextBox5.Text) And I + K = Val(TextBox6.Text) Then
                            Label1.Text = I : Label2.Text = J : Label3.Text = K : Label4.Text = L
                            Exit Sub
                        End If
                    Next
                Next
            Next
        Next
        Label5.Text = "無解"
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class
