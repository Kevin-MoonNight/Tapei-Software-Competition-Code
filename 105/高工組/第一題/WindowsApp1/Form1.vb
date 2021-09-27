Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            FileOpen(1, OpenFileDialog1.FileName, OpenMode.Input)
            Dim text, str As String
            Dim P(999) As String
            Dim N(999) As Integer
            Do Until EOF(1) = True
                text = LineInput(1)
                str &= "、" & text
            Loop
            '輸入
            For I = 0 To UBound(Split(str, "、"))
                If Split(str, "、")(I) <> "" Then
                    '判斷是否有同樣的
                    For J = 1 To 999
                        '有的話數量+1
                        If Split(str, "、")(I) = P(J) Then
                            N(J) += 1
                            Exit For
                        Else
                            '沒有的畫加進陣列裡
                            If P(J) = "" Then
                                P(J) = Split(str, "、")(I)
                                N(J) += 1
                                Exit For
                            End If
                        End If
                    Next
                End If
            Next
            '排大小
            For I = 1 To 999
                For J = 1 To 999
                    Dim STstr As String
                    Dim STnum As Integer
                    If N(I) > N(J) Then
                        '文字對調
                        STstr = P(J)
                        P(J) = P(I)
                        P(I) = STstr
                        '數量對調
                        STnum = N(J)
                        N(J) = N(I)
                        N(I) = STnum
                    End If
                Next
            Next
            '輸出
            TextBox1.Text = P(1) : TextBox2.Text = P(2) : TextBox3.Text = P(3) : TextBox4.Text = P(4) : TextBox5.Text = P(5)
        End If
    End Sub
End Class
