Public Class Form1
    Dim arr(31, 31) As Integer
    Dim X, Y As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.ImageLocation = TextBox1.Text
        Dim Bitmap As New Bitmap(PictureBox1.Image)
        ReDim arr(31, 31)
        '尋找最左上角
        X = Integer.MaxValue : Y = Integer.MaxValue
        For i = 0 To 31
            For j = 0 To 31
                Dim C As New Color
                C = Bitmap.GetPixel(j * 5, i * 5)
                If Val(C.R) = 255 Then
                    arr(i, j) = 255
                    If i < X Then
                        X = i
                    End If
                    If j < Y Then
                        Y = j
                    End If
                End If
            Next
        Next
        TextBox2.Text = ""
        '總長21
        If O0(Bitmap) = True Then
            TextBox2.Text = 0
        ElseIf O1(Bitmap) = True Then
            TextBox2.Text = 1
        ElseIf O2(Bitmap) = True Then
            TextBox2.Text = 2
        ElseIf O3(Bitmap) = True Then
            TextBox2.Text = 3
        ElseIf O4(Bitmap) = True Then
            TextBox2.Text = 4
        ElseIf O5(Bitmap) = True Then
            TextBox2.Text = 5
        ElseIf O6(Bitmap) = True Then
            TextBox2.Text = 6
        ElseIf O7(Bitmap) = True Then
            TextBox2.Text = 7
        ElseIf O8(Bitmap) = True Then
            TextBox2.Text = 8
        ElseIf O9(Bitmap) = True Then
            TextBox2.Text = 9
        End If
        If TextBox2.Text = "" Then
            TextBox2.Text = "無法辨識"
        End If
    End Sub
    Function O0(ByVal Bitmap As Bitmap) As Boolean
        Dim C As New Color
        For j = Y To Y + 5 '6
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 6 To Y + 14 '9
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 15 To Y + 20 '6
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        Return True
    End Function
    Function O1(ByVal Bitmap As Bitmap) As Boolean
        Dim C As New Color
        For j = Y To Y + 1 '2
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 2 To Y + 2 '1
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 3 To Y + 19 '17
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 20 To Y + 20 '1
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        Return True
    End Function
    Function O2(ByVal Bitmap As Bitmap) As Boolean
        Dim C As New Color
        For j = Y To Y + 3 '4
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 4 To Y + 4 '1
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 5 To Y + 19 '15
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 20 To Y + 20 '1
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        Return True
    End Function
    Function O3(ByVal Bitmap As Bitmap) As Boolean
        Dim C As New Color
        For j = Y To Y + 2 '3
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 3 To Y + 3 '1
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 4 To Y + 18 '15
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 19 To Y + 19 '1
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 20 To Y + 20 '1
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        Return True
    End Function
    Function O4(ByVal Bitmap As Bitmap) As Boolean
        Dim C As New Color
        For j = Y To Y + 13 '14
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 14 To Y + 15 '2
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 16 To Y + 20 '5
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        Return True
    End Function
    Function O5(ByVal Bitmap As Bitmap) As Boolean
        Dim C As New Color
        For j = Y To Y + 6 '7
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 7 To Y + 7 '1
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 8 To Y + 17 '10
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 18 To Y + 18 '1
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 19 To Y + 20 '2
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        Return True
    End Function
    Function O6(ByVal Bitmap As Bitmap) As Boolean
        Dim C As New Color
        For j = Y To Y + 8 '9
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 9 To Y + 15 '7
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 16 To Y + 20 '5
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        Return True
    End Function
    Function O7(ByVal Bitmap As Bitmap) As Boolean
        Dim C As New Color
        For j = Y To Y + 3 '4
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 4 To Y + 5 '2
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 6 To Y + 20 '15
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        Return True
    End Function
    Function O8(ByVal Bitmap As Bitmap) As Boolean
        Dim C As New Color
        For j = Y To Y + 2 '3
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 3 To Y + 6 '4
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 7 To Y + 13 '7
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 14 To Y + 17 '4
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 18 To Y + 20 '3
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        Return True
    End Function
    Function O9(ByVal Bitmap As Bitmap) As Boolean
        Dim C As New Color
        For j = Y To Y + 3 '4
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 4 To Y + 9 '6
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        For j = Y + 10 To Y + 19 '10
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 255 Then
                Return False
            End If
        Next
        For j = Y + 20 To Y + 20 '1
            C = Bitmap.GetPixel(X, j)
            If Val(C.R) <> 0 Then
                Return False
            End If
        Next
        Return True
    End Function
End Class
