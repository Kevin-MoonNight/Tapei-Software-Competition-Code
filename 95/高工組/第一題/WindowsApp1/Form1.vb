Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim T As Boolean = False
        Dim X, Y As Double
        Dim r, O As Double
        '判斷是直角或極座標
        If Val(TextBox1.Text) < 0 Or Val(TextBox2.Text) < 0 And UBound(Split(TextBox2.Text, ".")) <> 1 Or Val(TextBox1.Text) > 0 And Val(TextBox2.Text) > 0 Then
            '如果是直角座標
            X = Val(TextBox1.Text) : Y = Val(TextBox2.Text)
            TextBox3.Text = Math.Sqrt((X) ^ 2 + (Y) ^ 2)
            TextBox4.Text = Format(Math.Atan2(Y, X) * (180 / Math.PI), "0.0000")
        Else
            '如果是極座標
            r = Val(TextBox1.Text) : O = Val(TextBox2.Text)

            Dim S As Double = O / (180 / Math.PI)



            TextBox3.Text = X
            TextBox4.Text = Y
        End If

    End Sub
End Class
