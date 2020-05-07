Public Class InternetSales

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        Try
            If input.Text <> "" Then
                If CheckBox3.Checked = True Then
                    Dim a As Decimal = Convert.ToDecimal(input.Text / Form1.ratee)
                    a = Decimal.Round(a, 2, MidpointRounding.AwayFromZero)
                    input.Text = a.ToString
                Else
                    Dim a As Decimal = Convert.ToDecimal(input.Text * Form1.ratee)

                    input.Text = a.ToString
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class