Public Class debitform
   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            My.Settings.debit -= Val(Label5.Text)
            Form1.sum += Val(Label5.Text)

            Form1.lbtotal.Text = Decimal.Round(Form1.sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            debits.Label5.Text = My.Settings.debit.ToString
            Form1.updlist()
            debits.delete()
            Me.Close()
        Else
            My.Settings.debit -= Val(TextBox1.Text)
            Form1.sum += Val(TextBox1.Text)
            Form1.lbtotal.Text = Decimal.Round(Form1.sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            debits.Label5.Text = My.Settings.debit.ToString
            Form1.updlist()
            debits.edit()
            Me.Close()
        End If
       
    End Sub

  
    Private Sub debitform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Visible = False
        Label9.Visible = False
        TextBox1.Clear()
        CheckBox1.Checked = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            TextBox1.Visible = False
            Label9.Visible = False
        Else
            TextBox1.Visible = True
            Label9.Visible = True
        End If
    End Sub
End Class