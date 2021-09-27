Imports System
Imports System.IO
Imports System.Text
Public Class Form1
    Dim Str As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            FileOpen(1, OpenFileDialog1.FileName, OpenMode.Input)
            Dim text As String
            Str = ""
            Do Until EOF(1)
                text = LineInput(1)
                Str &= text & vbNewLine
            Loop
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ans As String = "<!DOCTYPE html>" & vbNewLine

        ans &= "<html>" & vbNewLine
        ans &= "<head><title>顯示各類食材熱量</tiltle>" & vbNewLine
        ans &= "<style>img {width:100%;height:auto;}</style>" & vbNewLine
        ans &= "</head>" & vbNewLine
        ans &= "<body>" & vbNewLine
        ans &= "<table cellspacing = " & Val(TextBox2.Text) & " border = " & Val(TextBox1.Text) & " >" & vbNewLine & vbNewLine
        Dim n As Integer
        Dim NewStr() As String = Split(Str, vbNewLine)
        For i = 0 To UBound(NewStr)
            ans &= "<tr>" & vbNewLine
            n = i
            '輸出文字
            For j = i To i + Val(TextBox3.Text) - 1
                If j <= UBound(NewStr) Then
                    If NewStr(j) <> "" Then
                        Dim text() As String = Split(NewStr(j), vbTab)
                        ans &= "<td style=""background-color:lightgray"">" & text(0) & "<br>" & text(1) & "</td>" & vbNewLine
                    End If
                End If
                n += 1
            Next

            ans &= "<td style=""background-color:lightgray""><br></td>" & vbNewLine
            ans &= "</tr>" & vbNewLine
            '輸出圖片
            For j = i To i + Val(TextBox3.Text) - 1
                If j <= UBound(NewStr) Then
                    If NewStr(j) <> "" Then
                        Dim text() As String = Split(NewStr(j), vbTab)
                        ans &= "<td><img src=""" & text(0) & ".jpg""" & "</td>" & vbNewLine
                    End If
                End If
            Next
            ans &= "</tr>" & vbNewLine
            i = n - 1

        Next
        ans &= vbNewLine & "</table>" & vbNewLine
        ans &= "</body></html>" & vbNewLine
        TextBox4.Text = ans

        Dim fs As FileStream = File.Create("C:\Users\User\Desktop\123.html")
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(ans)
        fs.Write(info, 0, info.Length)
        fs.Close()
    End Sub
End Class
