Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim X(3), Y(3) As Double
        '載入資料
        For I = 1 To 3
            X(I) = Val(CType(Me.Controls("Textbox" & 1 + (I - 1) * 2), TextBox).Text)
            Y(I) = Val(CType(Me.Controls("Textbox" & 2 + (I - 1) * 2), TextBox).Text)
        Next
        Dim L(3) As Double
        L(1) = Val(Format(Math.Sqrt(((X(2) - X(1)) ^ 2) + ((Y(2) - Y(1)) ^ 2)), "#.###"))
        L(2) = Val(Format(Math.Sqrt(((X(3) - X(2)) ^ 2) + ((Y(3) - Y(2)) ^ 2)), "#.###"))
        L(3) = Val(Format(Math.Sqrt(((X(3) - X(1)) ^ 2) + ((Y(3) - Y(1)) ^ 2)), "#.###"))
        Label1.Text = "座標1~座標2 邊長=" & L(1)
        Label2.Text = "座標2~座標3 邊長=" & L(2)
        Label3.Text = "座標3~座標1 邊長=" & L(3)
        '判斷有無相同點座標
        Dim T As Integer = 0
        Dim a, b, c As Double
        '排大小
        For i = 1 To 3
            For j = 1 To 3
                Dim st As Double
                If L(i) < L(j) Then
                    st = L(j)
                    L(j) = L(i)
                    L(i) = st
                    Exit For
                End If
            Next
        Next
        a = L(1) : b = L(2) : c = L(3)
        For I = 1 To 3
            T = 0
            For J = 1 To 3
                If X(I) = X(J) And Y(I) = Y(J) Then
                    T += 1
                End If
            Next
            If T = 2 Then
                Label4.Text = "有相同點座標"
                Exit Sub
            End If
        Next
        '判斷是否為一直線
        If X(1) = Y(1) And X(2) = Y(2) And X(3) = Y(3) Then
            Label4.Text = "此三點為一直線"
            Exit Sub
        End If
        '判斷是否是正三角形
        If L(1) = L(2) And L(2) = L(3) Then
            Label4.Text = "此為正三角形"
            Exit Sub
        End If
        '判斷等腰、等腰直角三角形
        For I = 1 To 3
            T = 0
            For J = 1 To 3
                If L(I) = L(J) Then
                    T += 1
                End If
            Next
            If T = 2 And Val(Format(a * a + b * b, "#")) = Val(Format(c * c, "#")) Then
                Label4.Text = "此為等腰直角三角形"
                Exit Sub
            ElseIf T = 2 Then
                Label4.Text = "此為等腰三角形"
                Exit Sub
            End If
        Next
        '判斷直角、銳角、鈍角三角形
        If a * a + b * b = c * c Then
            Label4.Text = "此為直角三角形"
        ElseIf a * a + b * b > c * c Then
            Label4.Text = "此為銳角三角形"
        ElseIf a * a + b * b < c * c Then
            Label4.Text = "此為鈍角三角形"
        End If
    End Sub
End Class
