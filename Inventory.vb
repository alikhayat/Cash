Imports System.Data.OleDb

Public Class Inventory

    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.CustomFormat = "dd-MM-yyyy"
    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox10.KeyPress, TextBox8.KeyPress, TextBox6.KeyPress, TextBox11.KeyPress, TextBox12.KeyPress, TextBox13.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = String.Empty Or TextBox6.Text = String.Empty Or TextBox8.Text = String.Empty Then
            MsgBox("Please fill in manditory fields")
        Else
            Dim objcmd As New System.Data.OleDb.OleDbCommand

            Dim con As New OleDb.OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + Application.StartupPath() & "\Database2.mdb;Jet OLEDB:Database Password=janitani;")
            Try
                con.Open()

                Dim strSql = ("insert into inventory values ('" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "', '" + DateTimePicker1.Value + "', '" + TextBox10.Text + "', '" + ComboBox1.Text + "', '" + TextBox8.Text + "', '" + TextBox6.Text + "', '" + TextBox11.Text + "', '" + TextBox12.Text + "', '" + TextBox13.Text + "')")
                objcmd = New OleDbCommand(strSql, con)
                objcmd.ExecuteNonQuery()

                con.Close()
            Catch ex As Exception

            End Try


            clear()
            MsgBox("added")
            Me.Close()
            InventorySelection.ShowDialog()
        End If
    End Sub
    Public Sub clear()
        TextBox1.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox8.Clear()
        ComboBox1.SelectedIndex = -1

    End Sub
End Class