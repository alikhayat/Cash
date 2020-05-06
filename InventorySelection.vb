Imports System.Data.OleDb

Public Class InventorySelection


    Private Sub InventorySelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dt = New DataTable()
            Dim myConnToAccess = New OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + Application.StartupPath() & "\Database2.mdb;Jet OLEDB:Database Password=janitani;")


            myConnToAccess.Open()

            Dim da = New OleDbDataAdapter("SELECT * from Inventory", myConnToAccess)


            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception

        End Try
        



    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged, TextBox2.TextChanged, TextBox1.TextChanged
        Try
            Dim dt = New DataTable()
            Dim myConnToAccess = New OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + Application.StartupPath() & "\Database2.mdb;Jet OLEDB:Database Password=janitani;")


            myConnToAccess.Open()

            Dim da = New OleDbDataAdapter("SELECT * from Inventory Where ID like'" + TextBox1.Text + "%' and Description like'" + TextBox2.Text + "%' and RetailPrice like'" + TextBox3.Text + "%'", myConnToAccess)


            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Try
            Inventory.TextBox1.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
            Inventory.TextBox2.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
            Inventory.TextBox3.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString
            Inventory.TextBox4.Text = DataGridView1.SelectedRows(0).Cells(3).Value.ToString
            Inventory.TextBox5.Text = DataGridView1.SelectedRows(0).Cells(4).Value.ToString

            Inventory.DateTimePicker1.Value = DataGridView1.SelectedRows(0).Cells(5).Value
            Inventory.TextBox10.Text = DataGridView1.SelectedRows(0).Cells(6).Value.ToString
            If DataGridView1.SelectedRows(0).Cells(7).Value.ToString = "EACH" Then
                Inventory.ComboBox1.SelectedIndex = 0
            ElseIf DataGridView1.SelectedRows(0).Cells(7).Value.ToString = "PALLET" Then
                Inventory.ComboBox1.SelectedIndex = 1
            ElseIf DataGridView1.SelectedRows(0).Cells(7).Value.ToString = "BOX" Then
                Inventory.ComboBox1.SelectedIndex = 2
            End If
            Inventory.TextBox8.Text = DataGridView1.SelectedRows(0).Cells(8).Value.ToString

            Inventory.TextBox6.Text = DataGridView1.SelectedRows(0).Cells(9).Value.ToString
            Inventory.TextBox11.Text = DataGridView1.SelectedRows(0).Cells(10).Value.ToString
            Inventory.TextBox12.Text = DataGridView1.SelectedRows(0).Cells(11).Value.ToString
            Inventory.TextBox13.Text = DataGridView1.SelectedRows(0).Cells(12).Value.ToString

            Me.Close()
            Inventory.ShowDialog()

        Catch ex As Exception

        End Try
        
    End Sub
End Class