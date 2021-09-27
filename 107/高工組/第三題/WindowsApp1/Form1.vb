Public Class Form1
    Dim M_Max(8, 8), A_Max(8, 8) As Double
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.ImageLocation = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim xBlock, yBlock As Integer
        xBlock = Val(TextBox1.Text) : yBlock = Val(TextBox2.Text)
        Dim Bitmap As New Bitmap(PictureBox1.Image)
        Dim Gx, Gy, M, A As Double
        For i = 1 To 8
            For j = 1 To 8
                M_Max(i, j) = 0 : A_Max(i, j) = 0
            Next
        Next
        For i = yBlock * 8 To yBlock * 8 + 8
            For j = xBlock * 8 To xBlock * 8 + 8
                Dim c As Color
                c = Bitmap.GetPixel(j, i)
                Dim j1, j_1, i1, i_1 As Integer
                'R
                If j + 1 <= xBlock * 8 + 8 Then
                    j1 = Val(Bitmap.GetPixel(j + 1, i).R)
                Else
                    j1 = 0
                End If
                If j - 1 >= xBlock * 8 Then
                    j_1 = Val(Bitmap.GetPixel(j - 1, i).R)
                Else
                    j_1 = 0
                End If
                If i + 1 <= yBlock * 8 + 8 Then
                    i1 = Val(Bitmap.GetPixel(j, i + 1).R)
                Else
                    i1 = 0
                End If
                If i - 1 >= yBlock * 8 Then
                    i_1 = Val(Bitmap.GetPixel(j, i - 1).R)
                Else
                    i_1 = 0
                End If
                Gx = j1 - j_1
                Gy = i1 - i_1
                M = Math.Sqrt(Gx ^ 2 + Gy ^ 2)
                A = Math.Atan(Gy / Gx) * (180 / Math.PI)
                If M > M_Max(j, i) Then
                    M_Max(j, i) = M
                End If
                If A > A_Max(j, i) Then
                    A_Max(j, i) = A
                End If
                'G
                If j + 1 <= xBlock * 8 + 8 Then
                    j1 = Val(Bitmap.GetPixel(j + 1, i).G)
                Else
                    j1 = 0
                End If
                If j - 1 >= xBlock * 8 Then
                    j_1 = Val(Bitmap.GetPixel(j - 1, i).G)
                Else
                    j_1 = 0
                End If
                If i + 1 <= yBlock * 8 + 8 Then
                    i1 = Val(Bitmap.GetPixel(j, i + 1).G)
                Else
                    i1 = 0
                End If
                If i - 1 >= yBlock * 8 Then
                    i_1 = Val(Bitmap.GetPixel(j, i - 1).G)
                Else
                    i_1 = 0
                End If
                Gx = j1 - j_1
                Gy = i1 - i_1
                M = Math.Sqrt(Gx ^ 2 + Gy ^ 2)
                A = Math.Atan(Gy / Gx) * (180 / Math.PI)
                If M > M_Max(j, i) Then
                    M_Max(j, i) = M
                End If
                If A > A_Max(j, i) Then
                    A_Max(j, i) = A
                End If
                'B
                If j + 1 <= xBlock * 8 + 8 Then
                    j1 = Val(Bitmap.GetPixel(j + 1, i).B)
                Else
                    j1 = 0
                End If
                If j - 1 >= xBlock * 8 Then
                    j_1 = Val(Bitmap.GetPixel(j - 1, i).B)
                Else
                    j_1 = 0
                End If
                If i + 1 <= yBlock * 8 + 8 Then
                    i1 = Val(Bitmap.GetPixel(j, i + 1).B)
                Else
                    i1 = 0
                End If
                If i - 1 >= yBlock * 8 Then
                    i_1 = Val(Bitmap.GetPixel(j, i - 1).B)
                Else
                    i_1 = 0
                End If
                Gx = j1 - j_1
                Gy = i1 - i_1
                M = Math.Sqrt(Gx ^ 2 + Gy ^ 2)
                A = Math.Atan(Gy / Gx) * (180 / Math.PI)
                If M > M_Max(j, i) Then
                    M_Max(j, i) = M
                End If
                If A > A_Max(j, i) Then
                    A_Max(j, i) = A
                End If
            Next
        Next
        '測試用
        'M_Max(1, 1) = 212 : M_Max(2, 1) = 156 : M_Max(3, 1) = 108 : M_Max(4, 1) = 86 : M_Max(5, 1) = 84 : M_Max(6, 1) = 81 : M_Max(7, 1) = 78 : M_Max(8, 1) = 78
        'M_Max(1, 2) = 161 : M_Max(2, 2) = 83 : M_Max(3, 2) = 66 : M_Max(4, 2) = 19 : M_Max(5, 2) = 16 : M_Max(6, 2) = 10 : M_Max(7, 2) = 9 : M_Max(8, 2) = 8
        'M_Max(1, 3) = 170 : M_Max(2, 3) = 94 : M_Max(3, 3) = 80 : M_Max(4, 3) = 21 : M_Max(5, 3) = 17 : M_Max(6, 3) = 10 : M_Max(7, 3) = 12 : M_Max(8, 3) = 14
        'M_Max(1, 4) = 165 : M_Max(2, 4) = 98 : M_Max(3, 4) = 81 : M_Max(4, 4) = 22 : M_Max(5, 4) = 18 : M_Max(6, 4) = 10 : M_Max(7, 4) = 16 : M_Max(8, 4) = 16
        'M_Max(1, 5) = 151 : M_Max(2, 5) = 109 : M_Max(3, 5) = 70 : M_Max(4, 5) = 16 : M_Max(5, 5) = 17 : M_Max(6, 5) = 13 : M_Max(7, 5) = 18 : M_Max(8, 5) = 18
        'M_Max(1, 6) = 133 : M_Max(2, 6) = 104 : M_Max(3, 6) = 47 : M_Max(4, 6) = 15 : M_Max(5, 6) = 14 : M_Max(6, 6) = 16 : M_Max(7, 6) = 19 : M_Max(8, 6) = 21
        'M_Max(1, 7) = 120 : M_Max(2, 7) = 79 : M_Max(3, 7) = 23 : M_Max(4, 7) = 14 : M_Max(5, 7) = 11 : M_Max(6, 7) = 18 : M_Max(7, 7) = 15 : M_Max(8, 7) = 18
        'M_Max(1, 8) = 110 : M_Max(2, 8) = 51 : M_Max(3, 8) = 11 : M_Max(4, 8) = 16 : M_Max(5, 8) = 8 : M_Max(6, 8) = 19 : M_Max(7, 8) = 12 : M_Max(8, 8) = 15

        'A_Max(1, 1) = 53 : A_Max(2, 1) = 107 : A_Max(3, 1) = 115 : A_Max(4, 1) = 97 : A_Max(5, 1) = 92 : A_Max(6, 1) = 91 : A_Max(7, 1) = 89 : A_Max(8, 1) = 86
        'A_Max(1, 2) = 23 : A_Max(2, 2) = 150 : A_Max(3, 2) = 168 : A_Max(4, 2) = 126 : A_Max(5, 2) = 105 : A_Max(6, 2) = 135 : A_Max(7, 2) = 96 : A_Max(8, 2) = 120
        'A_Max(1, 3) = 10 : A_Max(2, 3) = 170 : A_Max(3, 3) = 176 : A_Max(4, 3) = -149 : A_Max(5, 3) = 130 : A_Max(6, 3) = 156 : A_Max(7, 3) = 90 : A_Max(8, 3) = 155
        'A_Max(1, 4) = -2 : A_Max(2, 4) = -168 : A_Max(3, 4) = -167 : A_Max(4, 4) = -146 : A_Max(5, 4) = 158 : A_Max(6, 4) = 143 : A_Max(7, 4) = -142 : A_Max(8, 4) = 153
        'A_Max(1, 5) = -12 : A_Max(2, 5) = -155 : A_Max(3, 5) = -158 : A_Max(4, 5) = 142 : A_Max(5, 5) = 170 : A_Max(6, 5) = 99 : A_Max(7, 5) = -142 : A_Max(8, 5) = 124
        'A_Max(1, 6) = -23 : A_Max(2, 6) = -149 : A_Max(3, 6) = -153 : A_Max(4, 6) = 143 : A_Max(5, 6) = 168 : A_Max(6, 6) = 79 : A_Max(7, 6) = -141 : A_Max(8, 6) = 104
        'A_Max(1, 7) = -24 : A_Max(2, 7) = -149 : A_Max(3, 7) = -151 : A_Max(4, 7) = -25 : A_Max(5, 7) = -5 : A_Max(6, 7) = -142 : A_Max(7, 7) = -143 : A_Max(8, 7) = 103
        'A_Max(1, 8) = -20 : A_Max(2, 8) = -156 : A_Max(3, 8) = 34 : A_Max(4, 8) = -4 : A_Max(5, 8) = 7 : A_Max(6, 8) = -152 : A_Max(7, 8) = 59 : A_Max(8, 8) = 127
        TextBox3.Text = "" : TextBox4.Text = ""
        For i = 1 To 8
            For j = 1 To 8
                TextBox3.Text &= Format(M_Max(j, i), "0") & "     "
                TextBox4.Text &= Format(A_Max(j, i), "0") & "     "
            Next
            TextBox3.Text &= vbNewLine
            TextBox4.Text &= vbNewLine
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim HOG(8) As Double
        For i = 0 To 8
            HOG(i) = 0
        Next

        For I = 1 To 8
            For J = 1 To 8
                For K = 0 To 8
                    If Math.Abs(A_Max(J, I)) >= 20 * K And Math.Abs(A_Max(J, I)) <= 20 * (K + 1) And K + 1 <= 8 Then
                        HOG(K) += M_Max(J, I) * ((((K + 1) * 20) - Math.Abs(A_Max(J, I))) / 20)
                        HOG(K + 1) += M_Max(J, I) * ((20 - (((K + 1) * 20) - Math.Abs(A_Max(J, I)))) / 20)
                        Exit For
                    ElseIf Math.Abs(A_Max(J, I)) >= 20 * 8 And K = 8 Then
                        HOG(K) += M_Max(J, I) * ((((K + 1) * 20) - Math.Abs(A_Max(J, I))) / 20)
                        HOG(0) += M_Max(J, I) * ((20 - (((K + 1) * 20) - Math.Abs(A_Max(J, I)))) / 20)
                        Exit For
                    End If
                Next
            Next
        Next
        '輸出
        TextBox5.Text = ""
        For I = 0 To 8
            TextBox5.Text &= I & ":" & Format(HOG(I), "0.0") & "  "
        Next
    End Sub
End Class
