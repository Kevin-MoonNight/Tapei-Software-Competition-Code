Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bits(80) As Integer
        '身放證字號
        Dim Text As String = conver(Mid(TextBox1.Text, 3, Len(TextBox1.Text)), 27)
        For i = 1 To 8
            bits(26 + 1 - i) = Mid(Text, Len(Text) + 1 - i, 1)
        Next
        '男女
        bits(27) = Mid(TextBox1.Text, 2, 1)
        '身分證字號英文
        Dim EngText As String = conver(Asc(Mid(TextBox1.Text, 1, 1)) - Asc("A"), 5)
        For i = 1 To Len(EngText)
            bits(32 + 1 - i) = Mid(EngText, i, 1)
        Next
        '出生年月日
        '日
        Dim birthday As String = conver(Val(Strings.Right(TextBox2.Text, 2)), 4)
        For i = 1 To Len(birthday)
            bits(37 + 1 - i) = Mid(birthday, i, 1)
        Next
        '月
        birthday = conver(Val(Mid(TextBox2.Text, 5, 2)), 4)
        For i = 1 To Len(birthday)
            bits(41 + 1 - i) = Mid(birthday, i, 1)
        Next
        '年
        birthday = conver(Val(Mid(TextBox2.Text, 5, 2)), 7)
        For i = 1 To Len(birthday)
            bits(48 + 1 - i) = Mid(birthday, i, 1)
        Next
        '婚姻
        If ComboBox1.Text = "已婚" Then
            bits(49) = 1
        Else
            bits(49) = 0
        End If
        '學歷
        Dim school As String = ""
        If ComboBox2.Text = "博士" Then
            school = "000"
        ElseIf ComboBox2.Text = "碩士" Then
            school = "001"
        ElseIf ComboBox2.Text = "大學" Then
            school = "010"
        ElseIf ComboBox2.Text = "專科" Then
            school = "011"
        ElseIf ComboBox2.Text = "高中" Then
            school = "100"
        ElseIf ComboBox2.Text = "國中" Then
            school = "101"
        ElseIf ComboBox2.Text = "小學" Then
            school = "110"
        ElseIf ComboBox2.Text = "未知" Then
            school = "111"
        End If
        For i = 1 To Len(school)
            bits(52 + 1 - i) = Mid(school, i, 1)
        Next
        '手機號碼
        Dim cellphone As String = conver(Mid(TextBox3.Text, 3, Len(TextBox3.Text)), 26)
        '開頭09
        For i = 1 To Len(cellphone)
            bits(79 + 1 - i) = Mid(cellphone, i, 1)
        Next
        TextBox4.Text = conver2(bits)
    End Sub
    Function conver(ByVal num As Integer, ByVal n As Integer) As String
        '10轉2進位
        Dim ans As String = ""
        Do Until num <= 0
            ans &= num Mod 2
            num = num \ 2
        Loop
        Do Until Len(ans) >= n
            ans = "0" & ans
        Loop
        Return ans
    End Function
    Function conver2(ByVal bits() As Integer)
        Dim ans As String = ""
        For i = 0 To 79
            Dim text As String = bits(i) & bits(i + 1) & bits(i + 2) & bits(i + 3)
            If text = "0000" Then
                ans = "0" & ans
            ElseIf text = "0001" Then
                ans = "1" & ans
            ElseIf text = "0010" Then
                ans = "2" & ans
            ElseIf text = "0011" Then
                ans = "3" & ans
            ElseIf text = "0100" Then
                ans = "4" & ans
            ElseIf text = "0101" Then
                ans = "5" & ans
            ElseIf text = "0110" Then
                ans = "6" & ans
            ElseIf text = "0111" Then
                ans = "7" & ans
            ElseIf text = "1000" Then
                ans = "8" & ans
            ElseIf text = "1001" Then
                ans = "9" & ans
            ElseIf text = "1010" Then
                ans = "A" & ans
            ElseIf text = "1011" Then
                ans = "B" & ans
            ElseIf text = "1100" Then
                ans = "C" & ans
            ElseIf text = "1101" Then
                ans = "D" & ans
            ElseIf text = "1110" Then
                ans = "E" & ans
            ElseIf text = "1111" Then
                ans = "F" & ans
            End If
            i += 3
        Next
        Return ans
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class
