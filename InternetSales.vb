Public Class InternetSales
    Dim dt As New DataTable
    Private Sub InternetSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Bundles.DisplayMember = "Key"
        Me.Bundles.ValueMember = "Value"
        FillBundles()
    End Sub
    Private Sub FillBundles()
        FillDataset()

        If dt.Rows.Count <> 0 Then
            'Dim Items As New List(Of String)()
            Bundles.Items.Add(New DictionaryEntry(" ", 0))

            For Each Row In dt.Rows
                If Row(6) = True Then
                    Bundles.Items.Add(New DictionaryEntry(Row(2).ToString + "Mb - " + Row(3).ToString + "GB - " + Row(5).ToString + " $", CInt(Row(0))))
                End If
            Next
        End If
    End Sub
    Private Sub FillDataset()
        Dim con As New OleDb.OleDbConnection(My.Settings.BundlesConnectionString)
        Dim Sql As String = String.Format("SELECT * FROM [Bundles] WHERE [Active] = {0}", True)
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