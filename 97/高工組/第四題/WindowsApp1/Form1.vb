Public Class Form1
    Dim seed() As String = {"64", "73", "66", "64", "3b", "6b", "66", "6F", "41", "2c", "2e", "69", "79", "65", "77", "72", "6b", "6c", "64", "4a", "4b", "44", "48", "53", "55", "42"}
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim P(Len(TextBox1.Text)) As String
        For J = 1 To Len(TextBox1.Text)
            P(J) = Mid(TextBox1.Text, J, 1)
        Next
        Dim I As Integer = Val(TextBox2.Text)
        Dim n As Integer = Len(TextBox1.Text)
        Dim ans As String = TextBox2.Text
        For J = 1 To UBound(P)
            Dim Text1, Text2, Text3 As String
            Text1 = Conver1(seed(I))
            Text2 = Asc(P(J))
            Text3 = Hex(Text1 Xor Text2)
            Do Until Len(Text3) >= 2
                Text3 = "0" & Text3
            Loop
            ans &= Text3
            I += 1
        Next
        TextBox3.Text = ans
    End Sub
    Function Conver3(ByVal num As String)
        '2轉10
        Dim Ans As Integer = 0
        For i = Len(num) To 1 Step -1
            Ans += Val(Mid(num, Len(num) - i + 1, 1)) * (2 ^ (i - 1))
        Next
        Return Ans
    End Function
    Function Conver1(ByVal num As String)
        '16轉10
        Dim Ans As Integer = 0
        For i = Len(num) To 1 Step -1
            If IsNumeric(Mid(num, Len(num) - i + 1, 1)) = False Then
                Ans += (Asc(UCase(Mid(num, Len(num) - i + 1, 1))) - Asc("A") + 10) * (16 ^ (i - 1))
            Else
                Ans += Val(Mid(num, Len(num) - i + 1, 1)) * (16 ^ (i - 1))
            End If
        Next
        Return Ans
    End Function
    Function Conver2(ByVal num As Integer)
        '10轉2
        Dim Ans As String = ""
        Do Until num = 0
            Ans = num Mod 2 & Ans
            num = num \ 2
        Loop
        Return Ans
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Text As String = TextBox3.Text
        Dim Ans As String = ""
        If Len(Text) Mod 2 = 1 Then
            Label5.Text = "輸入有誤" : Exit Sub
        End If
        For j = 1 To Len(Text)
            If IsNumeric(Mid(Text, j, 1)) = False Then
                If Asc(UCase(Mid(Text, j, 1))) < Asc("A") And Asc(UCase(Mid(Text, j, 1))) > Asc("Z") Then
                    Label5.Text = "輸入有誤" : Exit Sub
                End If
            End If
        Next
        Dim I As Integer = Val(TextBox2.Text)
        For J = 3 To Len(Text) Step 2
            Dim Text1, Text2, Text3 As String
            Text3 = ""
            Text1 = Conver2(Conver1(seed(I)))
            Text2 = Conver2(Conver1(Mid(Text, J, 2)))
            Do Until Len(Text2) >= Len(Text1)
                Text2 = "0" & Text2
            Loop
            Do Until Len(Text1) >= Len(Text2)
                Text1 = "0" & Text1
            Loop
            For k = 1 To Len(Text1)
                If Val(Mid(Text2, k, 1)) = 0 Then
                    Text3 &= Mid(Text1, k, 1)
                Else
                    If Val(Mid(Text1, k, 1)) = 0 Then
                        Text3 &= 1
                    Else
                        Text3 &= 0
                    End If
                End If
            Next
            Ans &= Chr(Conver3(Text3))
            I += 1
        Next
        Label5.Text = Ans
    End Sub
End Class
