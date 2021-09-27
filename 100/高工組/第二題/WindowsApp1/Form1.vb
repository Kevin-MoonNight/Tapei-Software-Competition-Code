Public Class Form1
    Dim Max As Integer
    Dim P(6) As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim over As Integer = Val(TextBox19.Text)
        Max = 0
        Dim P2(6) As Boolean
        For I = 1 To 6
            P2(I) = False
        Next
        'DFS
        DFS(0, 0, P2)
        '輸出
        Label5.Text = "最佳組合="
        For I = 1 To 6
            If P(I) = True Then
                Label5.Text &= CType(Me.Controls("TEXTBOX" & I + 12), TextBox).Text & "+"
            End If
        Next
        Label5.Text = Mid(Label5.Text, 1, Len(Label5.Text) - 1)
        Label6.Text = "合計價格=" & Max
    End Sub
    Function DFS(ByVal Money As Integer, ByVal n As Integer, ByVal P2() As Boolean)
        '如果該組合價格最高且不超出重量範圍 就輸出
        If n <= 9 And Money > Max Then
            Max = Money
            For I = 1 To 6
                If P2(I) = True Then
                    P(I) = True
                Else
                    P(I) = False
                End If
            Next
        End If
        For I = 1 To 6
            '如果不會超過重量 就走
            If n + Val(CType(Me.Controls("TEXTBOX" & I + 6), TextBox).Text) <= 9 And P2(I) <> True Then
                P2(I) = True
                DFS(Money + Val(CType(Me.Controls("TEXTBOX" & I), TextBox).Text), n + Val(CType(Me.Controls("TEXTBOX" & I + 6), TextBox).Text), P2)
                P2(I) = False
            End If
        Next
    End Function
End Class
