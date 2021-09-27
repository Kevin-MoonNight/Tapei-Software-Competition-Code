Public Class Form1
    Dim NewButton(5, 5) As Button
    Dim P As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To 4
            For j = 0 To 4
                NewButton(i, j) = New Button
                NewButton(i, j).Size = New Size(40, 40)
                NewButton(i, j).BackColor = Color.White
                NewButton(i, j).Location = New Point(10 + ((j) * 50), 10 + ((i) * 50))
                Controls.Add(NewButton(i, j))
                AddHandler NewButton(i, j).Click, AddressOf Buttontext
            Next
        Next
    End Sub
    Private Sub Buttontext(sender As Button, e As EventArgs)
        If P = False Then
            sender.BackColor = Color.White
        Else
            sender.BackColor = Color.Black
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        P = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        P = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For i = 0 To 4
            For j = 0 To 4
                If NewButton(i, j).BackColor = Color.Black Then
                    NewButton(i, j).BackColor = Color.White
                    NewButton((1 * i + 1 * j) Mod 5, (1 * i + 2 * j) Mod 5).BackColor = Color.Black
                End If
            Next
        Next
    End Sub
End Class
