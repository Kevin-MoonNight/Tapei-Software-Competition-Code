Public Class Form1
    Dim n As Integer = 1
    Private Sub Button1_Click(sender As Button, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click
        If Asc(TextBox1.Text) >= Asc("a") And Asc(TextBox1.Text) <= Asc("z") Or Asc(TextBox1.Text) >= Asc("A") And Asc(TextBox1.Text) <= Asc("Z") And Asc(TextBox2.Text) >= Asc("a") And Asc(TextBox2.Text) <= Asc("z") Or Asc(TextBox2.Text) >= Asc("A") And Asc(TextBox2.Text) <= Asc("Z") Then
        Else
            MsgBox("輸入的符號無效")
            Exit Sub
        End If
        If n Mod 2 = 1 Then
            sender.Text = TextBox1.Text
        Else
            sender.Text = TextBox2.Text
        End If
        If P() = True Then
            If n Mod 2 = 1 Then
                Label3.Text = "甲方勝"
            Else
                Label3.Text = "乙方勝"
            End If
            Exit Sub
        End If
        n += 1
        If n = 10 Then
            Label3.Text = "和局"
        End If
    End Sub
    Function P() As Boolean
        If Button1.Text = Button2.Text And Button2.Text = Button3.Text Or Button1.Text = Button4.Text And Button4.Text = Button7.Text Then
            If Button1.Text <> "" And Button2.Text <> "" And Button3.Text <> "" Or Button1.Text <> "" And Button4.Text <> "" And Button7.Text <> "" Then
                Return True
            End If
        ElseIf Button4.Text = Button5.Text And Button5.Text = Button6.Text Or Button2.Text = Button5.Text And Button5.Text = Button8.Text Then
            If Button4.Text <> "" And Button5.Text <> "" And Button6.Text <> "" Or Button2.Text <> "" And Button5.Text <> "" And Button8.Text <> "" Then
                Return True
            End If
        ElseIf Button7.Text = Button8.Text And Button8.Text = Button9.Text Or Button3.Text = Button6.Text And Button6.Text = Button9.Text Then
            If Button7.Text <> "" And Button8.Text <> "" And Button9.Text <> "" Or Button3.Text <> "" And Button6.Text <> "" And Button9.Text <> "" Then
                Return True
            End If
        ElseIf Button1.Text = Button5.Text And Button5.Text = Button9.Text Or Button3.Text = Button5.Text And Button5.Text = Button7.Text Then
            If Button1.Text <> "" And Button5.Text <> "" And Button9.Text <> "" Or Button3.Text <> "" And Button5.Text <> "" And Button7.Text <> "" Then
                Return True
            End If
        End If
            Return False
    End Function
End Class
