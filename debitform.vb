Public Class debitform
   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            debits.delete()
            My.Settings.debit -= Val(Label5.Text)
            Form1.sum += Val(Label5.Text)

            Form1.lbtotal.Text = Decimal.Round(Form1.sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            debits.Label5.Text = My.Settings.debit.ToString
            Form1.updlist()
            AddLabel(1)
            Me.Close()
        Else
            debits.edit()
            My.Settings.debit -= Val(TextBox1.Text)
            Form1.sum += Val(TextBox1.Text)
            Form1.lbtotal.Text = Decimal.Round(Form1.sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            debits.Label5.Text = My.Settings.debit.ToString
            Form1.updlist()
            AddLabel(0)
            Me.Close()
        End If

    End Sub
    Private Sub AddLabel(Mode As Integer)
        Form1.count += 1
        Form1.lbl = Form1.labelarray(Form1.count - 1)
        Form1.lbl.BackColor = Color.Lavender
        If Mode = 1 Then
            Form1.lbl.Text = Form1.count & " ) " & String.Format("{0,-35}{1,-15}", Decimal.Round(Val(Label5.Text), 2, MidpointRounding.AwayFromZero) & " $", "Debit payed from: " & Label4.Text & "   " & TimeOfDay)
        Else
            If TextBox1.Text <> "" And TextBox1.Text <> String.Empty Then
                Form1.lbl.Text = Form1.count & " ) " & String.Format("{0,-35}{1,-15}", Decimal.Round(Val(TextBox1.Text), 2, MidpointRounding.AwayFromZero) & " $", "Debit payed: " & Label4.Text & "   " & TimeOfDay)
            End If

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