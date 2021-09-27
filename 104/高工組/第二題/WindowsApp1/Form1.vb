Imports System.Numerics
Public Class Form1
    Private Sub Button1_Click(sender As Button, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click
        '偷吃步
        Dim bignum1 As BigInteger = conver(TextBox1.Text)
        Dim bignum2 As BigInteger = conver(TextBox2.Text)
        TextBox3.Text = ""
        If sender.Text = "+" Then
            TextBox3.Text = (bignum1 + bignum2).ToString
        ElseIf sender.Text = "-" Then
            TextBox3.Text = (bignum1 - bignum2).ToString
        ElseIf sender.Text = "*" Then
            TextBox3.Text = (bignum1 * bignum2).ToString
        End If
    End Sub
    Function conver(ByVal str As String)
        Dim n As New BigInteger(0)
        For i = 1 To Len(str)
            n = n * 10 + Mid(str, i, 1)
        Next
        Return n
    End Function
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '清除
        For i = 1 To 3
            CType(Me.Controls("Textbox" & i), TextBox).Text = ""
        Next
    End Sub
End Class
