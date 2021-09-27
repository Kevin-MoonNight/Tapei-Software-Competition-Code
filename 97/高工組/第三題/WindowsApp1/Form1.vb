Public Class Form1
    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp, TextBox2.KeyUp, TextBox3.KeyUp
        For i = 1 To 6
            CType(Me.Controls("button" & i), Button).BackColor = Color.White
        Next
        If e.KeyCode.Enter Then
            If TextBox1.Text = "教務長" Or TextBox2.Text = "行政中心" Or TextBox3.Text = "成績查詢" Then
                Button1.BackColor = Color.Pink
            ElseIf TextBox1.Text = "網管" Or TextBox2.Text = "資訊大樓" Or TextBox3.Text = "列印輸出" Then
                Button3.BackColor = Color.Pink
            ElseIf TextBox1.Text = "KIMI" Or TextBox2.Text = "學生宿舍區" Or TextBox3.Text = "用餐" Then
                Button4.BackColor = Color.Pink
            ElseIf TextBox1.Text = "ALONSO" Or TextBox2.Text = "教育大樓" Or TextBox3.Text = "上課" Then
                Button2.BackColor = Color.Pink
            ElseIf TextBox1.Text = "學生會會長" Or TextBox2.Text = "學生活動中心" Or TextBox3.Text = "社團活動" Then
                Button6.BackColor = Color.Pink
            ElseIf TextBox1.Text = "教練" Or TextBox2.Text = "體育場" Or TextBox3.Text = "游泳" Then
                Button5.BackColor = Color.Pink
            End If
        End If
    End Sub
End Class
