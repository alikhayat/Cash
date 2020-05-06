Public Class debitin
    Public amount As Decimal
    Public namee As String
    Public reason As String
    Public clicked As Boolean
    Private Sub debitin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        clicked = False
        Me.Show()
        Application.DoEvents()
        TextBox1.Focus()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If TextBox1.Text <> "" Then
                If CheckBox1.Checked = True Then
                    Dim a As Decimal = Convert.ToDecimal(TextBox1.Text / Form1.ratee)
                    a = Decimal.Round(a, 2, MidpointRounding.AwayFromZero)
                    TextBox1.Text = a.ToString
                Else
                    Dim a As Decimal = Convert.ToDecimal(TextBox1.Text * Form1.ratee)

                    TextBox1.Text = a.ToString
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clicked = True
        Me.Close()
    End Sub

    Private Sub debitin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        clicked = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        amount = Val(TextBox1.Text)
        namee = TextBox2.Text
        reason = TextBox3.Text
        Me.Visible = False
    End Sub
End Class