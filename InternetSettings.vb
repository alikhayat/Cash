Public Class InternetSettings
    Dim con As New OleDb.OleDbConnection(My.Settings.BundlesConnectionString)
    Dim dt As New DataTable
    Private Sub InternetSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'BundlesDataSet1.Bundles' table. You can move, or remove it, as needed.
        Me.BundlesTableAdapter.Fill(Me.BundlesDataSet1.Bundles)

        Fill_Dataset()
        Fill_Form(dt)
        BundleCount.Text = Get_ActiveBundlesCount()
    End Sub    
    Private Sub Fill_Dataset()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open()
            End If
            Dim myadapter As New OleDb.OleDbDataAdapter("SELECT * FROM [InternetSettings]", con)
            Dim ds As New DataSet
            myadapter.Fill(ds, "InternetSettings")
            dt = ds.Tables("InternetSettings")
        Catch ex As Exception
            MsgBox("Unable to reach database,closing...")
            Me.Close()
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    Private Sub Fill_Form(ByVal datatable As DataTable)
        For Each Row In datatable.Rows
            TextBox1.Text = CType(Row(0), String)
            TextBox2.Text = CType(Row(1), String)
            TextBox3.Text = CType(Row(2), String)
            TextBox4.Text = CType(Row(3), String)
        Next
    End Sub
    Private Function Get_ActiveBundlesCount() As String
        Dim Count As Integer = 0
        Me.BundlesTableAdapter.Fill(Me.BundlesDataSet1.Bundles)
        For i As Integer = 0 To BundlesDataSet1.Tables(0).Rows.Count - 1
            If BundlesDataSet1.Tables(0).Rows(i)(6) = True Then
                Count += 1
            End If
        Next
        Return CStr(Count)
    End Function

    Private Sub InternetSettings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.ValidateChildren()
            Me.BundlesBindingSource.EndEdit()
            Me.BundlesTableAdapter.Update(Me.BundlesDataSet1.Bundles)
            MsgBox("Updated")
        Catch ex As Exception
            MsgBox("Validation Error")
        Finally
            BundleCount.Text = Get_ActiveBundlesCount()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim sql As OleDb.OleDbCommand = New OleDb.OleDbCommand(String.Format("UPDATE InternetSettings SET [Account Balance] = {0},[VAT] = {1},[tabe3] = {2},[rate] = {3}", TextBox1.Text.Trim, TextBox2.Text.Trim, TextBox3.Text.Trim, TextBox4.Text.Trim), con)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql.ExecuteNonQuery()
            Form1.InternetAcc = CDec(TextBox1.Text.Trim)
            MsgBox("Updated")
        Catch ex As Exception
            MsgBox("Validation Error")
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text.Trim = String.Empty Then
            TextBox1.Text = 0
        End If
    End Sub
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text.Trim = "0" Then
            TextBox1.Text = String.Empty
        End If
    End Sub
    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If TextBox2.Text.Trim = String.Empty Then
            TextBox2.Text = "11"
        End If
    End Sub
    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        If TextBox3.Text.Trim = String.Empty Then
            TextBox3.Text = "250"
        End If
    End Sub
    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        If TextBox4.Text.Trim = String.Empty Then
            TextBox4.Text = "1515"
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        PreventChars(e)
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        PreventChars(e)
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        PreventChars(e)
    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
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