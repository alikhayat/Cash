Public Class InternetSales
    Dim dt As New DataTable
    Private Sub InternetSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillBundles()
    End Sub
    Private Sub FillBundles()
        FillDataset()

        If dt.Rows.Count <> 0 Then
            Dim Items As New List(Of String)()
            Items.Add(" ")

            For Each Row In dt.Rows
                If Row(6) = True Then
                    Items.Add(Row(2).ToString + "Mb - " + Row(3).ToString + "MB - " + Row(5).ToString + " $")
                End If
            Next

            Bundles.Items.AddRange(Items.ToArray)
        End If
    End Sub
    Private Sub FillDataset()
        Dim con As New OleDb.OleDbConnection(My.Settings.BundlesConnectionString)
        Dim Sql As String = "SELECT * FROM [Bundles]"
        Dim MyAdapter As New OleDb.OleDbDataAdapter(Sql, con)
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            MyAdapter.Fill(dt)
        Catch ex As Exception
            MsgBox("Database error")
            Me.Close()
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

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

    Private Sub Bundles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Bundles.SelectedIndexChanged
        If Bundles.Text <> " " Then
            input.Text = dt.Rows(Bundles.SelectedIndex - 1)(5)
        Else
            input.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub InternetSales_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If input.Text = String.Empty Or input.Text = " " Or input.Text = "0" Then
            MsgBox("Invalid Input")
            input.Focus()
            Exit Sub
        End If
        If TextBox1.Text = String.Empty Then
            MsgBox("Fill Customer")
            TextBox1.Focus()
            Exit Sub
        End If
        If Bundles.SelectedIndex = -1 Or Bundles.SelectedIndex = 0 Then
            MsgBox("Invalid Bundle")
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub input_KeyPress(sender As Object, e As KeyPressEventArgs) Handles input.KeyPress
        PreventChars(e)
    End Sub
    Private Sub PreventChars(ByVal e As KeyPressEventArgs)
        If (Not Char.IsControl(e.KeyChar) _
             AndAlso (Not Char.IsDigit(e.KeyChar) _
             AndAlso (e.KeyChar <> Microsoft.VisualBasic.ChrW(46)))) Then
            e.Handled = True
        End If
    End Sub
End Class