Public Class Form1
    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        Dim BT As New Bitmap(e.Data.GetData(DataFormats.FileDrop)(0).ToString)
        Dim Str As String = ""
        Dim Ans As String = ""
        Do Until Str = "0x00" Or Str = "NULL" Or Str = "\0"
            Dim Txt As String = ""
            For i = 0 To BT.Height - 1
                For j = 0 To BT.Width - 1
                    Dim C As Color
                    C = BT.GetPixel(j, i)
                    Dim R, G, B As Integer
                    R = Val(Mid(Convert.ToString(Int(C.R), 2), 8, 1)) : G = Val(Mid(Convert.ToString(Int(C.R), 2), 8, 1)) : B = Val(Mid(Convert.ToString(Int(C.B), 2), 8, 1))



                Next
            Next
        Loop
        TextBox1.Text = Ans
        PictureBox1.Image = BT
    End Sub
End Class
