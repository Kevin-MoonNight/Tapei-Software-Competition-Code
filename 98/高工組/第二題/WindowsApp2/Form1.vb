Public Class Form1
    Dim bt As Bitmap
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '隱藏
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            bt = New Bitmap(TextBox2.Text)
            Dim Txt As String = Conver(TextBox1.Text)
            Dim n As Integer = 0
            Dim L As String = Convert.ToString(Len(TextBox1.Text), 2)
            For i = 0 To bt.Height - 1
                For j = 0 To bt.Width - 1
                    Dim C As Color
                    C = bt.GetPixel(j, i)
                    n += 1 'Byte+1
                    Dim R, G, B As Integer : R = Int(C.R) : G = Int(C.G) : B = Int(C.B)
                    '加密
                    If n >= 64 Then
                        If n Mod 3 = 1 Then 'R
                            R = M(n, L, Txt, Int(C.R))
                        ElseIf n Mod 3 = 2 Then 'G
                            G = M(n, L, Txt, Int(C.G))
                        Else 'B
                            B = M(n, L, Txt, Int(C.B))
                        End If
                        bt.SetPixel(j, i, Color.FromArgb(R, G, B))
                        If Txt = "" Then '如果要加密的資訊加密完則離開程式
                            Dim OutTxt() As String = Split(SaveFileDialog1.FileName, "\")
                            Dim Ans As String = ""
                            For k = 0 To UBound(OutTxt) - 1
                                Ans &= OutTxt(k) & "\"
                            Next
                            bt.Save(Ans & "a2.bmp")
                            Exit Sub
                        End If
                    End If
                Next
            Next
        End If
    End Sub
    Function M(ByVal n As Integer, ByRef L As String, ByRef Txt As String, ByVal C As Integer) As Integer '加密
        Dim Ans As Integer = 0
        If n >= 64 And n <= 95 Then '是否有加密
            Ans = Pic1(n, Int(C))
        ElseIf n >= 96 And n <= 111 Then '加密字串的長度
            If Len(L) <> 0 Then
                Ans = Pic2(Mid(L, Len(L), 1), Int(C))
                L = Mid(L, 1, Len(L) - 1)
            Else
                Ans = Pic2(0, Int(C))
            End If
        ElseIf n >= 112 Then
            If Len(Txt) <> 0 Then
                Ans = Pic2(Mid(Txt, Len(Txt), 1), Int(C))
                Txt = Mid(Txt, 1, Len(Txt) - 1)
            End If
        End If
        Return Ans
    End Function
    Function Conver(ByVal Txt As String) As String
        Dim Ans As String = ""
        For i = 1 To Len(Txt)
            Dim Str As String = Convert.ToString(Asc(Mid(Txt, i, 1)), 2) '將字元轉成2進制
            Do Until Len(Str) = 8 '補0
                Str = "0" & Str
            Loop
            Ans &= Str
        Next
        Return Ans
    End Function
    Function Pic1(ByVal n As Integer, ByVal C As Integer) As Integer '設定是否是加密圖片
        Dim Ans As String = ""
        Ans = Convert.ToString(Int(C), 2) '轉成2進制
        Ans = Mid(Ans, 1, Len(Ans) - 1) & n Mod 2 '設定LSB
        Ans = Convert.ToInt32(Ans, 2) '轉回10進制
        Return Int(Ans)
    End Function
    Function Pic2(ByVal n As Integer, ByVal C As Integer) As Integer '隱藏資訊的長度
        Dim Ans As String = ""
        Ans = Convert.ToString(Int(C), 2) '轉成2進制
        Ans = Mid(Ans, 1, Len(Ans) - 1) & n '設定LSB
        Ans = Convert.ToInt32(Ans, 2) '轉回10進制
        Return Int(Ans)
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '讀出
        'Dim bt As New Bitmap(TextBox3.Text)
        If P(bt) = False Then    '判斷是否有加密
            TextBox4.Text = TextBox3.Text & " 圖檔未被嵌入隱藏資訊"
        Else '讀取
            Dim n As Integer
            Dim L As String = ""
            Dim Txt As String = ""
            n = 0 : TextBox4.Text = ""
            For i = 0 To bt.Height - 1
                For j = 0 To bt.Width - 1
                    Dim C As Color
                    C = bt.GetPixel(j, i)
                    n += 1 'Byte+1
                    Dim R, G, B As Integer : R = Int(C.R) : G = Int(C.G) : B = Int(C.B)
                    If n >= 96 And n <= 111 Then '查看隱藏資訊的長度
                        Dim Color As String = ""
                        If n Mod 3 = 1 Then 'R
                            Color = Convert.ToString(Int(C.R), 2)
                        ElseIf n Mod 3 = 2 Then 'G
                            Color = Convert.ToString(Int(C.G), 2)
                        Else 'B
                            Color = Convert.ToString(Int(C.B), 2)
                        End If
                        L = Mid(Color, Len(Color), 1) & L
                    ElseIf n >= 112 Then '讀取隱藏字串
                        If n = 112 Then '將長度從2進制轉成10進制
                            L = Convert.ToInt32(L, 2)
                        End If
                        Dim Color As String = ""
                        If n Mod 3 = 1 Then 'R
                            Color = Convert.ToString(Int(C.R), 2)
                        ElseIf n Mod 3 = 2 Then 'G
                            Color = Convert.ToString(Int(C.G), 2)
                        Else 'B
                            Color = Convert.ToString(Int(C.B), 2)
                        End If
                        Txt = Mid(Color, Len(Color), 1) & Txt

                    End If
                    If n = 111 + Val(L) * 8 Then '輸出
                        Dim Ans As String = ""
                        For k = 1 To Int(L)
                            Ans &= Chr(Convert.ToInt32(Mid(Txt, 1, 8), 2))
                            Txt = Mid(Txt, 9, Len(Txt))
                        Next
                        TextBox4.Text = Ans
                        Exit Sub
                    End If
                Next
            Next
        End If
    End Sub
    Function P(ByVal bt As Bitmap) As Boolean
        '判斷該圖片是否有隱藏資訊
        Dim n As Integer = 0
        For i = 0 To bt.Height - 1
            For j = 0 To bt.Width - 1
                Dim C As Color = bt.GetPixel(j, i)
                Dim CP As Integer
                Dim Str As String = ""
                n += 1
                If n >= 64 Then
                    If n Mod 3 = 1 Then 'R
                        Str = Convert.ToString(Int(C.R), 2)
                    ElseIf n Mod 3 = 2 Then 'G
                        Str = Convert.ToString(Int(C.G), 2)
                    Else 'B
                        Str = Convert.ToString(Int(C.B), 2)
                    End If
                    Do Until Len(Str) = 8 '補0
                        Str = "0" & Str
                    Loop
                    CP = Int(Mid(Str, 8, 1))
                    If CP <> n Mod 2 Then '判斷是否一樣
                        Return False
                    ElseIf n = 95 Then
                        Return True
                    End If
                End If
            Next
        Next
    End Function
End Class
