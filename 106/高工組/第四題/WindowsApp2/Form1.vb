Imports System.Numerics
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim In_Text As String = TextBox1.Text
        Dim Text As String = ""
        Dim Text2 As String = "0000"
        Dim N As Integer = 0
        TextBox2.Text = ""
        For i = 1 To Len(In_Text)
            Text &= Hex(Asc((Mid(In_Text, i, 1)))) '轉成ASCII再轉成16進制
        Next
        Do Until conver(Text & Text2) Mod 34943 = 0 '判斷
            Text2 = Hex(N) '將N轉成16進制
            Do Until Len(Text2) = 4 '一定要滿2Byte
                Text2 = "0" & Text2
            Loop
            N += 1
        Loop
        TextBox2.Text = Mid(Text2, 1, 2) & " " & Mid(Text2, 3, 2)
    End Sub
    Function conver(ByVal num As String) As BigInteger
        '16轉10進制
        Dim ans As BigInteger = 0
        For i = 1 To Len(num)
            Dim n As Integer
            If IsNumeric(Mid(num, i, 1)) = False Then
                n = (Asc(UCase(Mid(num, i, 1))) - Asc("A")) + 10
            Else
                n = Val(Mid(num, i, 1))
            End If
            ans += n * 16 ^ (Len(num) - i)
        Next
        Return ans
    End Function
End Class
