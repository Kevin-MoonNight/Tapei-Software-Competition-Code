Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pic As New PictureBox
        pic.Load(TextBox3.Text)
        Dim BitMap As New Bitmap(pic.Image)
        Dim H, W As Integer
        H = Val(TextBox1.Text) : W = Val(TextBox2.Text)
        TextBox4.Text = ""
        For i = 0 To H - 1
            For J = 0 To W - 1
                Dim C As Color
                C = BitMap.GetPixel(J, i)
                If Val(C.R) > 128 Then
                    TextBox4.Text &= 255 & vbTab
                Else
                    TextBox4.Text &= 0 & vbTab
                End If
            Next
            TextBox4.Text &= vbNewLine
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pic As New PictureBox
        pic.Load(TextBox3.Text)
        Dim BitMap As New Bitmap(pic.Image)
        Dim H, W As Integer
        H = Val(TextBox1.Text) : W = Val(TextBox2.Text)
        TextBox5.Text = ""
        Dim arr(W, H) As Integer
        Dim arr2(W, H) As Boolean
        Dim n As Integer = 0

        For i = 0 To H - 1
            For J = 0 To W - 1
                Dim C As Color
                C = BitMap.GetPixel(J, i)
                '判斷是否是255
                If Val(C.R) > 128 Then
                    '存放有幾個255
                    Dim T As Integer = 0
                    '存放父代
                    Dim Min As Integer = -1
                    '判斷p q r s裡有幾個255
                    For K = i - 1 To i
                        For L = J - 1 To J + 1
                            '判斷不會超出範圍
                            If K >= 0 And K <= H - 1 And L >= 0 And L <= W - 1 Then
                                'x右邊不執行
                                If K <> i Or L <> J + 1 Then
                                    'x本身不會算在內
                                    If K <> i Or L <> J Then
                                        C = BitMap.GetPixel(L, K)
                                        '判斷有幾個255
                                        If Val(C.R) > 128 Then
                                            T += 1
                                            '父代
                                            If Min = -1 Then
                                                Min = arr(L, K)
                                            ElseIf arr(L, K) < Min Then
                                                Min = arr(L, K)
                                            End If

                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Next
                    '如果附近都沒有255 則為一個新的標籤
                    If T = 0 Then
                        n += 1
                        arr(J, i) = n

                    Else
                        For K = i - 1 To i
                            For L = J - 1 To J + 1
                                If K >= 0 And K <= H - 1 And L >= 0 And L <= W - 1 Then
                                    If K <> i Or L <> J + 1 Then
                                        C = BitMap.GetPixel(L, K)
                                        If Val(C.R) > 128 Then
                                            '如果該格本來就有數字 則把被蓋過的位置設成True
                                            If arr(L, K) <> 0 And arr(L, K) <> Min Then
                                                arr2(L, K) = True
                                            End If
                                            arr(L, K) = Min
                                        End If
                                    End If
                                End If
                            Next
                        Next
                    End If
                End If
            Next
        Next
        Dim ans As Integer = 0
        '輸出
        For i = 0 To H - 1
            For j = 0 To W - 1
                '用來判斷有幾個位置被蓋過
                If arr2(j, i) = True Then
                    ans += 1
                End If
                TextBox5.Text &= arr(j, i) & vbTab
            Next
            TextBox5.Text &= vbNewLine
        Next
        Label4.Text = "物件個數=" & n - ans
    End Sub
End Class
