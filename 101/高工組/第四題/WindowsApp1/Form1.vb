Imports System
Imports System.IO
Imports System.Text
Public Class Form1
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim T As Boolean = False
        For i = 1 To Len(TextBox1.Text)
            For j = 1 To 17
                If Mid(TextBox1.Text, i, 1) = CType(Me.Controls("Button" & j), Button).Text Then
                    T = True
                    Exit For
                End If
            Next
            If T = True Then
                T = False
            Else
                MsgBox("運算式有誤")
                Exit Sub
            End If
        Next
        '方法一 偷吃步
        'Dim ans As New MSScriptControl.ScriptControl
        'ans.Language = "VBSCRIPT"
        'Try
        '    MsgBox(ans.Eval(TextBox1.Text))
        '    '創建一個文字檔
        '    Dim fs As FileStream = File.Create("C:\Users\User\Desktop\b.txt")
        '    '設定裡面的文字
        '    Dim text As Byte() = New UTF8Encoding(True).GetBytes(TextBox1.Text & "=" & ans.Eval(TextBox1.Text))
        '    fs.Write(text, 0, text.Length)
        '    fs.Close()
        'Catch
        '    MsgBox("運算式有誤")
        'End Try

        '方法二 原始方法
        '轉後序
        Dim st As New Stack
        Dim que As New Queue
        Dim ans As String = ""
        '將運算式轉成後序丟進堆疊
        For i = 1 To Len(TextBox1.Text)
            If Mid(TextBox1.Text, i, 1) = "(" Then
                st.Push(Mid(TextBox1.Text, i, 1))
            ElseIf Mid(TextBox1.Text, i, 1) = ")" Then
                Do Until st.Peek = "("
                    que.Enqueue(st.Pop)
                Loop
                st.Pop()
            Else
                If Mid(TextBox1.Text, i, 1) <> "+" And Mid(TextBox1.Text, i, 1) <> "-" And Mid(TextBox1.Text, i, 1) <> "*" And Mid(TextBox1.Text, i, 1) <> "/" Then
                    que.Enqueue(Mid(TextBox1.Text, i, 1))
                Else
                    st.Push(Mid(TextBox1.Text, i, 1))
                End If
            End If
        Next
        '將剩下的輸出丟進堆疊
        Do Until st.Count = 0
            que.Enqueue(st.Pop)
        Loop
        '存放運算子
        Dim num1, num2 As String
        num1 = "" : num2 = ""
        '一直執行直到算完
        Do Until que.Count = 1 And IsNumeric(que.Peek) = True
                Dim P As Boolean = False
                Dim P_que As New Queue(que)
                '判斷堆疊裡還有無數字
                For I = 0 To P_que.Count - 1
                    If IsNumeric(P_que.Dequeue) = True Then
                        P = True
                        Exit For
                    End If
                Next
            '如果堆疊裡已經沒數字跟運算子也沒了
            If P = False And num1 <> "" And num2 = "" Then
                MsgBox("運算式有誤")
                Exit Sub
            End If
            '如果取出來的是數字
            If IsNumeric(que.Peek) = True Then
                    If num1 <> "" And num2 <> "" Then
                        MsgBox("運算式有誤")
                        Exit Sub
                    End If
                    If num1 = "" Then
                        num1 = que.Dequeue
                    ElseIf num2 = "" Then
                        num2 = que.Dequeue
                    End If
                Else
                    '如果有數字可以計算的話
                    If num1 <> "" And num2 <> "" Then
                        If que.Peek = "+" Then
                            '將運算結果在輸入進去
                            que.Enqueue(Val(num1) + Val(num2))
                        ElseIf que.Peek = "-" Then
                            que.Enqueue(Val(num1) - Val(num2))
                        ElseIf que.Peek = "*" Then
                            que.Enqueue(Val(num1) * Val(num2))
                        ElseIf que.Peek = "/" Then
                            que.Enqueue(Val(num1) / Val(num2))
                        End If
                        '將運算元取出
                        que.Dequeue()
                        '清空運算數字
                        num1 = "" : num2 = ""
                    Else
                        '將運算元重新丟回去
                        que.Enqueue(que.Dequeue)
                    End If
                End If
            Loop
        '輸出
        MsgBox(que.Peek)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click
        TextBox1.Text &= sender.text
    End Sub
End Class
