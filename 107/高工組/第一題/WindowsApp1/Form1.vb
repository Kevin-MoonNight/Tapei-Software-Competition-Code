Public Class Form1
    Dim n As Integer = 0
    Dim Text As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        n = 0
        Text = TextBox1.Text
        TextBox3.Text = ""
        DFS("")
        TextBox2.Text = n
    End Sub
    Function DFS(ByVal str As String)
        If Len(str) = Len(Text) Then
            n += 1
            TextBox3.Text &= str & vbNewLine
        Else
            For i = 1 To Len(Text)
                If InStr(str, Mid(Text, i, 1)) = 0 Then
                    DFS(str & Mid(Text, i, 1))
                End If
            Next
        End If
    End Function
End Class
