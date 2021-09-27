Public Class Form1
    Dim n As Integer
    Dim P1(), P2() As Point '存放點
    Dim T_Point As New ArrayList '判斷座標是否重複
    Dim arr(400, 260) As Integer
    Dim TheEnd As Boolean
    Dim Ans As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        n = Val(TextBox1.Text)
        If n >= 2 And n <= 7 Then
            '初始化
            T_Point.Clear()
            ReDim P1(n), P2(n)
            '產生點
            Dim ran As New Random
            For i = 1 To n
                '設定x座標、y座標
                Dim x_p, y_p As Integer
                Dim T_P As New Point(x_p, y_p)
                '點1
                '重複執行到該點沒執行過
                Do Until T_Point.Contains(T_P) = False And x_p <> 0 And y_p <> 0
                    x_p = ran.Next(150, 390) : y_p = ran.Next(10, 100)
                    T_P = New Point(x_p, y_p)
                Loop
                '輸出
                P1(i) = T_P : T_Point.Add(T_P)
                '點2
                '重複執行到該點沒執行過
                Do Until T_Point.Contains(T_P) = False And x_p <> 0 And y_p <> 0
                    x_p = ran.Next(10, 149) : y_p = ran.Next(101, 250)
                    T_P = New Point(x_p, y_p)
                Loop
                '輸出
                P2(i) = T_P : T_Point.Add(T_P)
            Next
            '虛畫線
            Dim g As Graphics = PictureBox1.CreateGraphics
            g.Clear(Color.White)
            For i = 1 To n
                Dim pen As New Pen(Brushes.Black)
                pen.DashStyle = Drawing2D.DashStyle.Dash
                '標點
                g.FillEllipse(Brushes.Black, P1(i).X - 3, P1(i).Y - 3, 6, 6) : g.FillEllipse(Brushes.Black, P2(i).X - 3, P2(i).Y - 3, 6, 6)
                '標數字
                g.DrawString(i, Me.Font, Brushes.Black, P1(i).X, P1(i).Y) : g.DrawString(i, Me.Font, Brushes.Black, P2(i).X, P2(i).Y)
                '畫虛線
                g.DrawLine(pen, P1(i).X, P1(i).Y, P1(i).X, P2(i).Y) : g.DrawLine(pen, P1(i).X, P1(i).Y, P2(i).X, P1(i).Y)
                g.DrawLine(pen, P1(i).X, P2(i).Y, P2(i).X, P2(i).Y) : g.DrawLine(pen, P2(i).X, P1(i).Y, P2(i).X, P2(i).Y)
            Next
        End If
    End Sub
    Sub InputO(ByVal P() As Point)
        Dim ran As New Random
        For i = 1 To n
            '設定x座標、y座標
            Dim x_p As Integer = ran.Next(10, 390)
            Dim y_p As Integer = ran.Next(10, 250)
            Dim T_P As New Point(x_p, y_p)
            '點1
            '重複執行到該點沒執行過
            Do Until T_Point.Contains(T_P) = False
                x_p = ran.Next(10, 390) : y_p = ran.Next(10, 250)
                T_P = New Point(x_p, y_p)
            Loop
            '輸出
            P(i) = T_P
        Next
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim g As Graphics = PictureBox1.CreateGraphics
        '清空畫布
        g.Clear(Color.White)
        ReDim arr(400, 260) '用來判斷劃過線的地方
        TheEnd = False : Ans = ""
        DFS(n, "")
        '畫線
        For i = 0 To UBound(Split(Ans, " "))
            If Split(Ans, " ")(i) <> "" Then
                Pic(Val(Split(Ans, " ")(i)), n - i)
            End If
        Next
    End Sub
    Function DFS(ByVal n As Integer, ByVal Text As String) As String
        If n = 0 And TheEnd <> True Then
            TheEnd = True
            Ans = Text
        Else
            If Move1(n) = True And TheEnd <> True Then '如果連線1可以走
                For J = P2(n).X To P1(n).X
                    arr(J, P1(n).Y) = 1
                Next
                For J = P1(n).Y To P2(n).Y
                    arr(P2(n).X, J) = 1
                Next
                DFS(n - 1, Text & "1 ")
                For J = P2(n).X To P1(n).X
                    arr(J, P1(n).Y) = 0
                Next
                For J = P1(n).Y To P2(n).Y
                    arr(P2(n).X, J) = 0
                Next
            End If
            If Move2(n) = True And TheEnd <> True Then '如果連線2可以走
                For J = P2(n).X To P1(n).X
                    arr(J, P2(n).Y) = 1
                Next
                For J = P1(n).Y To P2(n).Y
                    arr(P1(n).X, J) = 1
                Next
                DFS(n - 1, Text & "2 ")
                For J = P2(n).X To P1(n).X
                    arr(J, P2(n).Y) = 0
                Next
                For J = P1(n).Y To P2(n).Y
                    arr(P1(n).X, J) = 0
                Next
            End If
        End If
    End Function
    Function Move1(ByVal I As Integer) As Boolean
        For J = P2(I).X To P1(I).X
            If arr(J, P1(I).Y) = 1 Then
                Return False
            End If
        Next
        For J = P1(I).Y To P2(I).Y
            If arr(P2(I).X, J) = 1 Then
                Return False
            End If
        Next
        Return True
    End Function
    Function Move2(ByVal I As Integer) As Boolean
        For J = P2(I).X To P1(I).X
            If arr(J, P2(I).Y) = 1 Then
                Return False
            End If
        Next
        For J = P1(I).Y To P2(I).Y
            If arr(P1(I).X, J) = 1 Then
                Return False
            End If
        Next
        Return True
    End Function
    Sub Pic(ByVal P As Integer, ByVal I As Integer)
        Dim G As Graphics = PictureBox1.CreateGraphics
        '標點
        G.FillEllipse(Brushes.Black, P1(I).X - 3, P1(I).Y - 3, 6, 6) : G.FillEllipse(Brushes.Black, P2(I).X - 3, P2(I).Y - 3, 6, 6)
        '標數字
        G.DrawString(I, Me.Font, Brushes.Black, P1(I).X, P1(I).Y) : G.DrawString(I, Me.Font, Brushes.Black, P2(I).X, P2(I).Y)
        If P = 1 Then
            For J = P2(I).X To P1(I).X
                arr(J, P1(I).Y) = 1
            Next
            For J = P1(I).Y To P2(I).Y
                arr(P2(I).X, J) = 1
            Next
            '連線
            G.DrawLine(Pens.Black, P1(I).X, P1(I).Y, P2(I).X, P1(I).Y)
            G.DrawLine(Pens.Black, P2(I).X, P1(I).Y, P2(I).X, P2(I).Y)
        Else
            For J = P2(I).X To P1(I).X
                arr(J, P2(I).Y) = 1
            Next
            For J = P1(I).Y To P2(I).Y
                arr(P1(I).X, J) = 1
            Next
            '連線
            G.DrawLine(Pens.Black, P2(I).X, P2(I).Y, P1(I).X, P2(I).Y)
            G.DrawLine(Pens.Black, P1(I).X, P2(I).Y, P1(I).X, P1(I).Y)
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
End Class
