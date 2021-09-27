Public Class Form2
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Bits(80) As Integer
        Dim InputText As String = Strings.StrReverse(TextBox4.Text)
        Dim n As Integer = 0
        Dim Text As String
        '轉回二進制
        For i = 1 To Len(InputText)
            Text = Conver1(Mid(InputText, i, 1))
            For j = 4 To 1 Step -1
                Bits(n) = Mid(Text, j, 1)
                n += 1
            Next
        Next
        TextBox1.Text = Chr(Asc("A") + Conver3(Conver2(32, 28, Bits))) & Bits(27) + 1 & Conver3(Conver2(26, 0, Bits))
        TextBox2.Text = 1900 + Conver3(Conver2(48, 42, Bits)) & Format(Conver3(Conver2(41, 38, Bits)), "00") & Format(Conver3(Conver2(37, 33, Bits)), "00")
        If Bits(49) = 1 Then
            ComboBox1.Text = "已婚"
        Else
            ComboBox1.Text = "未婚"
        End If
        Text = Conver2(52, 50, Bits)
        Do Until Len(Text) >= 3
            Text = "0" & Text
        Loop
        If Text = "000" Then
            ComboBox2.Text = "博士"
        ElseIf Text = "001" Then
            ComboBox2.Text = "碩士"
        ElseIf Text = "010" Then
            ComboBox2.Text = "大學"
        ElseIf Text = "011" Then
            ComboBox2.Text = "專科"
        ElseIf Text = "100" Then
            ComboBox2.Text = "高中"
        ElseIf Text = "101" Then
            ComboBox2.Text = "國中"
        ElseIf Text = "110" Then
            ComboBox2.Text = "小學"
        ElseIf Text = "111" Then
            ComboBox2.Text = "未知"
        End If
        TextBox3.Text = "09" & Conver3(Conver2(79, 53, Bits))
    End Sub
    Function Conver3(ByVal num As String)
        '二轉10進制
        Dim Ans As Integer = 0
        For i = Len(num) To 1 Step -1
            Ans += Val(Mid(num, Len(num) - i + 1, 1)) * (2 ^ (i - 1))
        Next
        Return Ans
    End Function
    Function Conver2(ByVal n1 As Integer, ByVal n2 As Integer, ByVal Bits() As Integer)
        Dim Ans As String = ""
        For i = n1 To n2 Step -1
            Ans &= Bits(i)
        Next
        Return Ans
    End Function
    Function Conver1(ByVal num As String)
        '16轉10
        If IsNumeric(num) = False Then
            num = Asc(num) - Asc("A")
            num = Val(num) + 10
        End If
        Dim Ans As String = ""
        '10轉2
        Do Until num = 0
            Ans = Val(num) Mod 2 & Ans
            num = Val(num) \ 2
        Loop
        Do Until Len(Ans) >= 4
            Ans = "0" & Ans
        Loop
        Return Ans
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Visible = False
        Form1.Show()
    End Sub
End Class