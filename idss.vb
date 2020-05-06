Imports System.Data.OleDb
Imports System.IO


Public Class idss

    Dim dbprovider As String
    Dim dbsource As String
    Dim ds As New DataSet
    Dim da As OleDb.OleDbDataAdapter
    Dim constring As String = "PROVIDER=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=" & Application.StartupPath() & "\idss.mdb"
    Dim mycon As OleDbConnection
    Dim tables As DataTableCollection
    Dim source1 As New BindingSource
    Private sMyScanner As String = String.Empty
    Public pcount As Integer
    Dim loading As Boolean = False






    Private Sub ids_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'IdssDataSet.idss' table. You can move, or remove it, as needed.
        Me.IdssTableAdapter.Fill(Me.IdssDataSet.idss)
       


        Try
            'TODO: This line of code loads data into the 'IdsDataSet1.ids' table. You can move, or remove it, as needed.
            Me.IdssTableAdapter.Fill(Me.IdssDataSet.idss)
        Catch ex As Exception

        End Try
        pcount = My.Settings.pcount








        dbprovider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        dbsource = "DATA SOURCE=" & Path.Combine(Directory.GetCurrentDirectory(), "idss.mdb")

    End Sub




    Private Sub saved_Click(sender As Object, e As EventArgs) Handles saved.Click
        Try
            If scan.Text <> "" And scan2.Text <> "" Then
                Dim objcmd As New System.Data.OleDb.OleDbCommand
                Dim con As New OleDb.OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=" & Application.StartupPath() & "\idss.mdb")
                con.Open()
                Dim strSql = ("insert into idss values ('" + first.Text + "', '" + middlee.Text + "', '" + last.Text + "', '" + idtype.Text + "', '" + country.Text + "', '" + idnumb.Text + "', '" + birth.Text + "', '" + exp.Text + "', '" + phone.Text + "', '" + scan.Text + "', '" + scan2.Text + "')")
                objcmd = New OleDbCommand(strSql, con)


                objcmd.ExecuteNonQuery()

                con.Close()

                MsgBox("saved")
                Me.IdssTableAdapter.Fill(Me.IdssDataSet.idss)
            ElseIf scan.Text <> "" And scan2.Text = "" Then
                Dim objcmd As New System.Data.OleDb.OleDbCommand
                Dim con As New OleDb.OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=" & Application.StartupPath() & "\idss.mdb")
                con.Open()
                Dim strSql = ("insert into idss values ('" + first.Text + "', '" + middlee.Text + "', '" + last.Text + "', '" + idtype.Text + "', '" + country.Text + "', '" + idnumb.Text + "', '" + birth.Text + "', '" + exp.Text + "', '" + phone.Text + "', '" + scan.Text + "', '" + "Non" + "')")
                objcmd = New OleDbCommand(strSql, con)


                objcmd.ExecuteNonQuery()

                con.Close()

                MsgBox("saved")
                Me.IdssTableAdapter.Fill(Me.IdssDataSet.idss)
            ElseIf scan.Text = "" And scan2.Text <> "" Then
                Dim objcmd As New System.Data.OleDb.OleDbCommand
                Dim con As New OleDb.OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=" & Application.StartupPath() & "\idss.mdb")
                con.Open()
                Dim strSql = ("insert into idss values ('" + first.Text + "', '" + middlee.Text + "', '" + last.Text + "', '" + idtype.Text + "', '" + country.Text + "', '" + idnumb.Text + "', '" + birth.Text + "', '" + exp.Text + "', '" + phone.Text + "', '" + "Non" + "', '" + scan2.Text + "')")
                objcmd = New OleDbCommand(strSql, con)


                objcmd.ExecuteNonQuery()

                con.Close()

                MsgBox("saved")
            ElseIf scan.Text = "" And scan2.Text = "" Then
                Dim objcmd As New System.Data.OleDb.OleDbCommand
                Dim con As New OleDb.OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=" & Application.StartupPath() & "\idss.mdb")
                con.Open()
                Dim strSql = ("insert into idss values ('" + first.Text + "', '" + middlee.Text + "', '" + last.Text + "', '" + idtype.Text + "', '" + country.Text + "', '" + idnumb.Text + "', '" + birth.Text + "', '" + exp.Text + "', '" + phone.Text + "', '" + "Non" + "', '" + "Non" + "')")
                objcmd = New OleDbCommand(strSql, con)


                objcmd.ExecuteNonQuery()

                con.Close()

                MsgBox("saved")
            End If
        Catch ex As Exception

        End Try
        Me.IdssTableAdapter.Fill(Me.IdssDataSet.idss)







        first.Text = ""
        middlee.Text = ""
        last.Text = ""
        idtype.Text = ""
        country.Text = ""
        birth.Text = ""
        idnumb.Text = ""
        exp.Text = ""
        phone.Text = ""
        scan.Text = ""
        scan2.Text = ""
        first.Focus()
        Refresh()
    End Sub


    Private Sub DataGridView1_selectionchanged(sender As Object, e As EventArgs) Handles DataGridView1.CellMouseClick
        Try
            idshow.first.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
            idshow.middle.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
            idshow.last.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString
            idshow.idtype.Text = DataGridView1.SelectedRows(0).Cells(3).Value.ToString
            idshow.country.Text = DataGridView1.SelectedRows(0).Cells(4).Value.ToString
            idshow.idnumb.Text = DataGridView1.SelectedRows(0).Cells(5).Value.ToString
            idshow.birth.Text = DataGridView1.SelectedRows(0).Cells(6).Value.ToString
            idshow.exp.Text = DataGridView1.SelectedRows(0).Cells(7).Value.ToString
            idshow.phone.Text = DataGridView1.SelectedRows(0).Cells(8).Value.ToString
            idshow.scan.Text = DataGridView1.SelectedRows(0).Cells(9).Value.ToString
            idshow.Label12.Text = DataGridView1.SelectedRows(0).Cells(10).Value.ToString

            idshow.ShowDialog()
            Me.Close()
        Catch

        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_selectionchanged(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged, TextBox2.TextChanged, TextBox1.TextChanged, TextBox4.TextChanged
        Dim Con As OleDb.OleDbConnection
        Con = New OleDb.OleDbConnection(dbprovider & dbsource)
        Con.Open()
        Dim myadapter As New OleDb.OleDbDataAdapter("select * from idss where name like'" + TextBox1.Text + "%' and middle like'" + TextBox2.Text + "%' and lastName like'" + TextBox3.Text + "%' and phoneNumber like'" + TextBox4.Text + "%'", Con)
        Dim ds As New DataSet
        myadapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Label11.Text = DataGridView1.RowCount.ToString
        Con.Close()
    End Sub

    
   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            'Set the scan source for your scan.
            sMyScanner = TWAINLIB.GetScanSource
            'Scan images from source and place the file path in a list of string for later access.
            TWAINLIB.SaveFileLocation(Path.Combine(Directory.GetCurrentDirectory(), "idimages\" & pcount.ToString))
            TWAINLIB.TwainOperations.SaveFileLocation(Path.Combine(Directory.GetCurrentDirectory(), "idimages\" & pcount.ToString))
            Dim lstFiles As List(Of String) = TWAINLIB.ScanImages(".bmp", True, sMyScanner)
            loading = True
        Catch ex As Exception

        End Try
        aquire()
       
    End Sub
    Private Sub btnSelectSource_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectSource.Click
        Try
            'Set the scan source for your scan.
            sMyScanner = TWAINLIB.GetScanSource
            'Scan images from source and place the file path in a list of string for later access.
            TWAINLIB.SaveFileLocation(Path.Combine(Directory.GetCurrentDirectory(), "idimages\" & pcount.ToString))
            TWAINLIB.TwainOperations.SaveFileLocation(Path.Combine(Directory.GetCurrentDirectory(), "idimages\" & pcount.ToString))
            Dim lstFiles As List(Of String) = TWAINLIB.ScanImages(".bmp", True, sMyScanner)
            loading = True
        Catch ex As Exception

        End Try
        aquire2()
    End Sub
    Private Sub aquire()
        If loading = True Then


            PictureBox1.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), "idimages\" & pcount.ToString & "_0000.bmp"))

            scan.Text = pcount.ToString & "_0000"
            pcount += 1
            My.Settings.pcount = pcount
        End If

    End Sub


    Private Sub aquire2()
        If loading = True Then


            PictureBox2.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), "idimages\" & pcount.ToString & "_0000.bmp"))

            scan2.Text = pcount.ToString & "_0000"
            pcount += 1
            My.Settings.pcount = pcount
        End If
    End Sub

End Class
