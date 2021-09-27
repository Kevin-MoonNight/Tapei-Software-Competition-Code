Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Len(TextBox1.Text) > 5 Or Len(TextBox1.Text) > 8 Then
            MsgBox("傳遞訊息的長度不大於8小於5位元")
        Else
            For I = 1 To Len(TextBox1.Text)
                If Mid(TextBox1.Text, I, 1) <> "1" Or Mid(TextBox1.Text, I, 1) <> "0" Then
                    MsgBox("傳遞訊息的值應是0或1")
                End If
            Next
        End If
    End Sub
End Class
