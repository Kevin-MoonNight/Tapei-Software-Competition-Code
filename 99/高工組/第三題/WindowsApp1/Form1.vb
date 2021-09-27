Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.ImageLocation = TextBox1.Text
        Dim Bitmap As New Bitmap(TextBox1.Text)
        Dim P(2) As Point
        Dim C As Color
        P(1).X = Integer.MaxValue : P(2).X = Integer.MinValue
        For i = 0 To Bitmap.Height - 1 Step 1
            For J = 0 To Bitmap.Width - 1 Step 1
                C = Bitmap.GetPixel(J, i)
                If Val(C.R) <= 125 Then
                    '點1
                    If J < P(1).X Then
                        P(1).X = J
                        P(1).Y = i
                    End If
                    '點2
                    If J > P(2).X Then
                        P(2).X = J
                        P(2).Y = i
                    End If
                End If
            Next
        Next
        For i = 1 To 2
            P(i).Y = 31 - P(i).Y
        Next
        Label2.Text = "線段左邊端(" & P(1).X & "," & P(1).Y & ")點座標"
        Label3.Text = "線段左邊端(" & P(2).X & "," & P(2).Y & ")點座標"
        Label4.Text = "線段斜率" & Format((P(2).Y - P(1).Y) / (P(2).X - P(1).X), "0.##")
    End Sub
End Class
