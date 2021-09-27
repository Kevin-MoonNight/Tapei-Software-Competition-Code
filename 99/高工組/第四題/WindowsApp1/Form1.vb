Public Class Form1
    Private Sub Button1_Click(sender As Object, z As EventArgs) Handles Button1.Click
        Dim A, B, C, D, E, F As Integer
        If TextBox1.Text <> "3,3,1,0,0,0" Then
            MsgBox("違反題意")
        Else
            Dim num() As String = Split(TextBox1.Text, ",")
            A = num(0) : B = num(1) : C = num(2) : D = num(3) : E = num(4) : F = num(4)
            TextBox2.Text = DFS(A, B, C, D, E, F, A, B, C, D, E, F, "")
            'TextBox2.Text = "(" & A & "," & B & "," & C & "," & D & "," & E & "," & F & ")"
        End If
    End Sub
    Function DFS(ByRef A As Integer, ByRef B As Integer, ByRef C As Integer, ByRef D As Integer, ByRef E As Integer, ByRef F As Integer, ByVal Last_A As Integer, ByVal Last_B As Integer, ByVal Last_C As Integer, ByVal Last_D As Integer, ByVal Last_E As Integer, ByVal Last_F As Integer, ByVal str As String)
        '如果都送完了
        If A = 0 And B = 0 And C = 0 And D = 3 And E = 3 And F = 1 Then
            Return str & "(" & A & "," & B & "," & C & "," & D & "," & E & "," & F & ")"
        End If
        '如果野人大於傳教士則離開此路 回到上一個選擇
        If A > B And B <> 0 Or D > E And E <> 0 Then
            Exit Function
        ElseIf A = 3 And B = 3 And C = 1 And D = 0 And E = 0 And F = 0 And 3 <> Last_A Or 3 <> Last_B Or 1 <> Last_C Or 0 <> Last_D Or 0 <> Last_E Or 0 <> Last_F Then
            Exit Function
        Else
            If C = 1 Then
                '送1個野人
                If A >= 1 Then
                    'If A - 1 <> Last_A Or B <> Last_B Or C - 1 <> Last_C Or D + 1 <> Last_D Or E <> Last_E Or F + 1 <> Last_F Then
                    DFS(A - 1, B, C - 1, D + 1, E, F + 1, A, B, C, D, E, F, str & "(" & A - 1 & "," & B & "," & C - 1 & "," & D + 1 & "," & E & "," & F + 1 & ")" & vbNewLine)
                    'End If
                End If
                '送兩個野人
                If A >= 2 Then
                    'If A - 2 <> Last_A Or B <> Last_B Or C - 1 <> Last_C Or D + 2 <> Last_D Or E <> Last_E Or F + 1 <> Last_F Then
                    DFS(A - 2, B, C - 1, D + 2, E, F + 1, A, B, C, D, E, F, str & "(" & A - 2 & "," & B & "," & C - 1 & "," & D + 2 & "," & E & "," & F + 1 & ")" & vbNewLine)
                    'End If
                End If
                '送1傳教士
                If B >= 1 Then
                    'If A <> Last_A Or B - 1 <> Last_B Or C - 1 <> Last_C Or D <> Last_D Or E + 1 <> Last_E Or F + 1 <> Last_F Then
                    DFS(A, B - 1, C - 1, D, E + 1, F + 1, A, B, C, D, E, F, str & "(" & A & "," & B - 1 & "," & C - 1 & "," & D & "," & E + 1 & "," & F + 1 & ")" & vbNewLine)
                    'End If
                End If
                '送2傳教士
                If B >= 2 Then
                    'If A <> Last_A Or B - 2 <> Last_B Or C - 1 <> Last_C Or D <> Last_D Or E + 2 <> Last_E Or F + 1 <> Last_F Then
                    DFS(A, B - 2, C - 1, D, E + 2, F + 1, A, B, C, D, E, F, str & "(" & A & "," & B - 2 & "," & C - 1 & "," & D & "," & E + 2 & "," & F + 1 & ")" & vbNewLine)
                    'End If
                End If
                '野人或傳教士各送一個
                If A >= 1 And B >= 1 Then
                    'If A - 1 <> Last_A Or B - 1 <> Last_B Or C - 1 <> Last_C Or D + 1 <> Last_D Or E + 1 <> Last_E Or F + 1 <> Last_F Then
                    DFS(A - 1, B - 1, C - 1, D + 1, E + 1, F + 1, A, B, C, D, E, F, str & "(" & A - 1 & "," & B - 1 & "," & C - 1 & "," & D + 1 & "," & E + 1 & "," & F + 1 & ")" & vbNewLine)
                    'End If
                End If
            End If
            '如果有船才可以走
            If F = 1 Then
                '送1個野人
                If D >= 1 Then
                    '走過的路不要走
                    'If A + 1 <> Last_A Or B <> Last_B Or C + 1 <> Last_C Or D - 1 <> Last_D Or E <> Last_E Or F - 1 <> Last_F Then
                    DFS(A + 1, B, C + 1, D - 1, E, F - 1, A, B, C, D, E, F, str & "(" & A + 1 & "," & B & "," & C + 1 & "," & D - 1 & "," & E & "," & F - 1 & ")" & vbNewLine)
                    'End If
                End If
                '送兩個野人
                If D >= 2 Then
                    'If A + 2 <> Last_A Or B <> Last_B Or C + 2 <> Last_C Or D - 2 <> Last_D Or E <> Last_E Or F - 2 <> Last_F Then
                    DFS(A + 2, B, C + 1, D - 2, E, F - 1, A, B, C, D, E, F, str & "(" & A + 2 & "," & B & "," & C + 1 & "," & D - 2 & "," & E & "," & F - 1 & ")" & vbNewLine)
                    ' End If
                End If
                '送1傳教士
                If E >= 1 Then
                    ' If A <> Last_A Or B + 1 <> Last_B Or C + 1 <> Last_C Or D <> Last_D Or E - 1 <> Last_E Or F - 1 <> Last_F Then
                    DFS(A, B + 1, C + 1, D, E - 1, F - 1, A, B, C, D, E, F, str & "(" & A & "," & B + 1 & "," & C + 1 & "," & D & "," & E - 1 & "," & F - 1 & ")" & vbNewLine)
                    ' End If
                End If
                '送2傳教士
                If E >= 2 Then
                    'If A <> Last_A Or B + 2 <> Last_B Or C + 1 <> Last_C Or D <> Last_D Or E - 2 <> Last_E Or F - 1 <> Last_F Then
                    DFS(A, B + 2, C + 1, D, E - 2, F - 1, A, B, C, D, E, F, str & "(" & A & "," & B + 2 & "," & C + 1 & "," & D & "," & E - 2 & "," & F - 1 & ")" & vbNewLine)
                    ' End If
                End If
                '野人或傳教士各送一個
                If D >= 1 And E >= 1 Then
                    '  If A + 1 <> Last_A Or B + 1 <> Last_B Or C + 1 <> Last_C Or D - 1 <> Last_D Or E - 1 <> Last_E Or F - 1 <> Last_F Then
                    DFS(A + 1, B + 1, C + 1, D - 1, E - 1, F - 1, A, B, C, D, E, F, str & "(" & A + 1 & "," & B + 1 & "," & C + 1 & "," & D - 1 & "," & E - 1 & "," & F - 1 & ")" & vbNewLine)
                    '  End If
                End If
            End If
            '如果可以走加到路徑
            'TextBox2.Text &= "(" & A & "," & B & "," & C & "," & D & "," & E & "," & F & ")" & vbNewLine
        End If
    End Function
End Class
