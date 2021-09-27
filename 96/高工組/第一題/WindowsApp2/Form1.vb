Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bits(80) As Integer
        '身放證字號
        Dim Text As String = conver(Mid(TextBox1.Text, 3, Len(TextBox1.Text)), 27)
        For i = 1 To Len(Text)
            'MsgBox(Len(Text))
            bits(26 + 1 - i) = Mid(Text, i, 1)
        Next
        '男女
        If Val(Mid(TextBox1.Text, 2, 1)) = 1 Then
            bits(27) = 0
        Else
            bits(27) = 1
        End If
        '身分證字號英文
        Dim EngText As String = conver(Asc(Mid(TextBox1.Text, 1, 1)) - Asc("A"), 5)
        For i = 1 To Len(EngText)
            bits(32 + 1 - i) = Mid(EngText, i, 1)
        Next
        '出生年月日
        '日
        Dim birthday As String = conver(Val(Strings.Right(TextBox2.Text, 2)), 5)
        For i = 1 To Len(birthday)
            bits(37 + 1 - i) = Mid(birthday, i, 1)
        Next
        '月
        birthday = conver(Val(Mid(TextBox2.Text, 5, 2)), 4)
        For i = 1 To Len(birthday)
            bits(41 + 1 - i) = Mid(birthday, i, 1)
        Next
        '年
        birthday = conver(Val(Mid(TextBox2.Text, 1, 4)) - 1900, 7)
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
        Dim cellphone As String = conver(Mid(TextBox3.Text, 3, Len(TextBox3.Text)), 27)
        '開頭09
        For i = 1 To Len(cellphone)
            bits(79 + 1 - i) = Mid(cellphone, i, 1)
        Next
        TextBox4.Text = conver2(bits)
    End Sub
    Function conver(ByVal num As Integer, ByVal N As Integer) As String
        '10轉2進位
        Dim ans As String = ""
        Do Until num <= 0
            ans = num Mod 2 & ans
            num = num \ 2
        Loop
        Do Until Len(ans) >= N
            ans = "0" & ans
        Loop
        Return ans
    End Function
    Function conver3(ByVal num As String)
        '2轉10進制
        Dim ans As Integer = 0
        For i = Len(num) To 1 Step -1
            ans += Val(Mid(num, Len(num) - i + 1, 1)) * (2 ^ (i - 1))
        Next
        Return ans
    End Function
    Function conver2(ByVal bits() As Integer)
        Dim ans As String = ""
        For i = 79 To 0 Step -4
            Dim text As String = bits(i) & bits(i - 1) & bits(i - 2) & bits(i - 3)
            ans &= Hex(conver3(text))
        Next
        Return ans
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Visible = False
        Form2.Show()
    End Sub
End Class
