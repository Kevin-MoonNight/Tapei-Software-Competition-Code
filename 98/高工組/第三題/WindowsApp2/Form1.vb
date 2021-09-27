Public Class Form1
    Dim Tmp_n As Integer
    Dim Que As New Queue
    Dim Road As New ArrayList
    Dim AllTree() As Tree
    Dim Max As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Tmp_n = 0 : Que.Clear() : Road.Clear()
        Max = 0
        For i = 0 To Val(TextBox1.Text) - 1
            Max += 2 ^ i
        Next
        ReDim AllTree(Max)
        Max = 0
        For i = 0 To Val(TextBox1.Text) - 1
            Max += 2 ^ i
            For j = Max - (2 ^ (i)) + 1 To Max
                AllTree(j).n = Max - (2 ^ (i)) + 1
                AllTree(j).R = i
            Next
        Next
        BFS()
        '畫圖
        Dim G As Graphics = PictureBox1.CreateGraphics
        G.Clear(Color.White)
        Tmp_n = 40
        Dim O As New PointF(5, 5)
        For i = 0 To Road.Count - 1
            O.X = Tmp_n
            'Pic(圓圈點,樹,第幾個)
            Pic(O, Road(i), 1)
            Tmp_n += 100
            If Tmp_n > 600 Then
                Tmp_n = 40
                O.Y = 70
            End If
        Next
    End Sub
    Function P(ByVal O As PointF, ByVal A As Double, ByVal L As Integer)
        O.Y -= Math.Sin(Math.PI / 180 * A) * L
        O.X += Math.Cos(Math.PI / 180 * A) * L
        Return O
    End Function
    Sub Pic(ByVal O As PointF, ByVal Tmp() As Tree, ByVal n As Integer)
        Dim G As Graphics = PictureBox1.CreateGraphics
        G.DrawEllipse(Pens.Black, O.X, O.Y, 10, 10) '畫圓
        Dim A1 As New PointF
        O.X += 6 : O.Y += 10
        '如果是左子樹有走
        If Tmp(n).Left <> 0 Then
            A1 = P(O, -135, 20)
            G.DrawLine(Pens.Black, O.X, O.Y, A1.X, A1.Y) '畫線
            A1.X -= 5
            Pic(A1, Tmp, Tmp(n).Left) '呼叫
        End If
        '如果是右子樹有走
        If Tmp(n).Right <> 0 Then
            A1 = P(O, -45, 20)
            G.DrawLine(Pens.Black, O.X, O.Y, A1.X, A1.Y) '畫線
            Pic(A1, Tmp, Tmp(n).Right)
        End If
    End Sub
    Structure Tree
        Dim Left As Integer '左子樹
        Dim Right As Integer '右子樹
        Dim n As Integer '這一層的起始
        Dim R As Integer '第幾層
    End Structure
    Function Contain(ByVal Tmp() As Tree)
        For i = 0 To Road.Count - 1
            Dim T As Boolean = False  '判斷是否有出現相同解答
            For j = 1 To Max
                Dim Str As String = Tmp(j).Left & Tmp(j).Right & Tmp(j).n & Tmp(j).R
                Dim Str2 As String = Road(i)(j).Left & Road(i)(j).Right & Road(i)(j).n & Road(i)(j).R
                If Str <> Str2 Then '如果等於回傳False
                    T = True
                End If
            Next
            If T = False Then
                Return False
            End If
        Next
        Return True
    End Function
    Sub BFS()
        Que.Enqueue(AllTree)
        Do Until Que.Count = 0
            Dim Tmp() As Tree = Que.Dequeue
            Move(Tmp) 'BFS將可以走的路徑丟進Que裡
            If Move2(Tmp) = True And Contain(Tmp) = True Then '確認已經走滿N步且沒有出現過
                If Move2(Tmp) = True And Contain(Tmp) = True Then
                    Road.Add(Tmp)
                End If
            End If
        Loop
    End Sub
    Sub Move(ByVal Tmp() As Tree)
        '移動
        '判斷是否有走滿
        If Move2(Tmp) = False Then
            For i = 1 To Max
                '尋找尾端
                If Move3(Tmp, i) = True Then
                    '創造一個輸出用的樹
                    Dim AnsTmp(Max) As Tree
                    '右子樹可以走
                    If Tmp(i).Right = 0 Then
                        Tmp.CopyTo(AnsTmp, 0) '將樹複製過去
                        '計算右子樹是第幾個
                        AnsTmp(i).Right = ((AnsTmp(i).n - 1) + (2 ^ AnsTmp(i).R)) + (((i - AnsTmp(i).n) / (2 ^ (AnsTmp(i).R)) * (2 ^ (AnsTmp(i).R + 1)))) + 2
                        Que.Enqueue(AnsTmp)
                    End If
                    '左子樹可以走
                    If Tmp(i).Left = 0 Then
                        ReDim AnsTmp(Max)
                        Tmp.CopyTo(AnsTmp, 0) '將樹複製過去
                        '計算左子樹是第幾個
                        AnsTmp(i).Left = ((AnsTmp(i).n - 1) + (2 ^ AnsTmp(i).R)) + (((i - AnsTmp(i).n) / (2 ^ (AnsTmp(i).R))) * (2 ^ (AnsTmp(i).R + 1))) + 1
                        Que.Enqueue(AnsTmp)
                    End If
                End If
            Next
        End If
    End Sub
    Function Move2(ByVal Tmp() As Tree) As Boolean
        '判斷有沒有超出N個
        Dim P_Que As New Queue
        P_Que.Enqueue(1)
        Dim n As Integer = 1
        Do Until P_Que.Count = 0
            '判斷左右子樹是否有連接
            If Tmp(P_Que.Peek).Left <> 0 Then
                P_Que.Enqueue(Tmp(P_Que.Peek).Left)
                n += 1
            End If
            If Tmp(P_Que.Peek).Right <> 0 Then
                P_Que.Enqueue(Tmp(P_Que.Peek).Right)
                n += 1
            End If
            P_Que.Dequeue()
            '如果已經走滿 則輸出true
            If n = Val(TextBox1.Text) Then
                Return True
            End If
        Loop
        Return False
    End Function
    Function Move3(ByVal Tmp() As Tree, ByVal I As Integer) As Boolean
        If I = 1 Then
            Return True
        Else
            For j = 1 To I - 1
                '如果判斷點有沒有跟其他樹枝連起來 沒有則不是尾端
                If Tmp(j).Right = I Or Tmp(j).Left = I Then
                    Return True
                End If
            Next
            Return False
        End If
    End Function
End Class
