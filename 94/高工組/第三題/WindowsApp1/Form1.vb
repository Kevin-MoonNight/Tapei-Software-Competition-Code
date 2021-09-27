Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For I = 1 To 3
            CType(Me.Controls("Textbox" & I), TextBox).Enabled = False
            CType(Me.Controls("Textbox" & I), TextBox).Text = 0
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Stop()
        For I = 1 To 3
            CType(Me.Controls("Textbox" & I), TextBox).Enabled = True
        Next
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Start()
        For I = 1 To 3
            CType(Me.Controls("Textbox" & I), TextBox).Enabled = False
            Dim g As Graphics = PictureBox1.CreateGraphics
            g.FillEllipse(Brushes.Gray, 1, 1, 40, 40)
        Next
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer1.Stop()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Timer1.Stop()
        For I = 1 To 3
            CType(Me.Controls("Textbox" & I), TextBox).Text = 0
        Next
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '中斷點
        If Val(TextBox1.Text) = 0 And Val(TextBox2.Text) = 0 And Val(TextBox3.Text) = 0 Then
            Dim g As Graphics = PictureBox1.CreateGraphics
            g.FillEllipse(Brushes.Red, 1, 1, 40, 40)
            Timer1.Stop()
            Exit Sub
        End If
        Do Until Val(TextBox3.Text) <> 0
            If Val(TextBox2.Text) <> 0 Then
                TextBox2.Text = Val(TextBox2.Text) - 1
                TextBox3.Text = 60
            Else
                TextBox3.Text = Val(TextBox3.Text) - 1
                TextBox2.Text = 60
            End If
        Loop
        '減一秒
        TextBox3.Text = Val(TextBox3.Text) - 1
    End Sub
End Class
