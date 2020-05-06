Imports System.IO

Public Class idshow

    Private Sub idshow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        idss.Close()
    End Sub

    Private Sub scan_Click(sender As Object, e As EventArgs) Handles scan.Click
        Try

            Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "idimages\" & scan.Text & ".bmp"))
        Catch ex As Exception
            MsgBox(ex.Message + Path.Combine(Directory.GetCurrentDirectory(), "idimages\" & scan.Text))
        End Try
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Try

            Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "idimages\" & Label12.Text & ".bmp"))
        Catch ex As Exception
            MsgBox(ex.Message + Path.Combine(Directory.GetCurrentDirectory(), "idimages\" & Label12.Text))
        End Try
    End Sub
End Class