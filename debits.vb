Imports System.Data.OleDb

Public Class debits

    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter
    Dim countd As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        debitin.ShowDialog()
        If debitin.clicked = True Then
            Exit Sub
        ElseIf debitin.TextBox1.Text = "" Or debitin.TextBox2.Text = "" Or debitin.TextBox3.Text = "" Then
            MsgBox("invalid data")
        Else
            Dim objcmd As New System.Data.OleDb.OleDbCommand
            Dim con As New OleDb.OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=" & Application.StartupPath() & "\debit.mdb")
            con.Open()
            countd += 1
            Dim a = Convert.ToInt32(debitin.amount)
            Dim strSql = ("insert into debit values ('" & countd & "' , '" & debitin.namee & "', '" + debitin.reason & "', '" & debitin.TextBox1.Text & "', '" & Now.ToString + "')")
            objcmd = New OleDbCommand(strSql, con)

            objcmd.ExecuteNonQuery()
            My.Settings.countd = countd
            con.Close()


            Me.DebitTableAdapter.Fill(Me.DebitDataSet.debit)
            My.Settings.debit += debitin.amount
            Form1.sum -= debitin.amount

            Form1.lbtotal.Text = Decimal.Round(Form1.sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            Label5.Text = My.Settings.debit.ToString
            Form1.updlist()
            Exit Sub


        End If

        'TODO: This line of code loads data into the 'DebitsDataSet2.debits' table. You can move, or remove it, as needed.
        Me.DebitTableAdapter.Fill(Me.DebitDataSet.debit)




    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Dim con As New OleDb.OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=" & Application.StartupPath() & "\debit.mdb")
        Con.Open()
        Dim myadapter As New OleDb.OleDbDataAdapter("select * from debit where Name like'" + TextBox1.Text + "%'", con)
        Dim ds As New DataSet
        myadapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Label3.Text = DataGridView1.RowCount.ToString

        Con.Close()
    End Sub

    Private Sub debits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DebitDataSet.debit' table. You can move, or remove it, as needed.
        Me.DebitTableAdapter.Fill(Me.DebitDataSet.debit)
        

        Label5.Text = My.Settings.debit.ToString
        countd = My.Settings.countd
    End Sub

    

    


    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Try
            debitform.Label8.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
            debitform.Label4.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
            debitform.Label5.Text = DataGridView1.SelectedRows(0).Cells(3).Value.ToString
            debitform.Label6.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString
            debitform.Label12.Text = DataGridView1.SelectedRows(0).Cells(4).Value.ToString
            debitform.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub delete()

        DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
        For Each row As DataGridViewRow In DataGridView1.SelectedRows
            DataGridView1.Rows.Remove(row)
        Next
        Dim con As New OleDb.OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=" & Application.StartupPath() & "\debit.mdb")
        con.Open()
        Dim delcmd As New OleDbCommand("delete * from debit where ID=" & debitform.Label8.Text & " ", con)
        delcmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record is deleted")
    End Sub
    Public Sub edit()
        Dim amount As Decimal = Val(debitform.Label5.Text) - Val(debitform.TextBox1.Text)
        Dim cmdText As String = "UPDATE [debit] SET [Amount]=? " +
                 "WHERE [ID]=?"

        Using con = New OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=" & Application.StartupPath() & "\debit.mdb")
            Using cmd = New OleDbCommand(cmdText, con)
                con.Open()
                cmd.Parameters.AddWithValue("@p1", Convert.ToString(amount))
                cmd.Parameters.AddWithValue("@p2", debitform.Label8.Text)

                cmd.ExecuteNonQuery()
            End Using
        End Using
        'TODO: This line of code loads data into the 'DebitsDataSet2.debits' table. You can move, or remove it, as needed.
        Me.DebitTableAdapter.Fill(Me.DebitDataSet.debit)
    End Sub
End Class