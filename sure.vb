Public Class sure

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.eur = 0
        My.Settings.cad = 0
        My.Settings.gbp = 0
        My.Settings.jpy = 0
        My.Settings.sar = 0
        My.Settings.aud = 0
        My.Settings.aed = 0
        My.Settings.sek = 0
        My.Settings.qar = 0
        My.Settings.kwd = 0
        My.Settings.bhd = 0
        My.Settings.omr = 0
        My.Settings.jod = 0
        My.Settings.chf = 0

        currency.eur = 0
        currency.cad = 0
        currency.gbp = 0
        currency.jpy = 0
        currency.sar = 0
        currency.aud = 0
        currency.aed = 0
        currency.sek = 0
        currency.qar = 0
        currency.kwd = 0
        currency.bhd = 0
        currency.omr = 0
        currency.jod = 0
        currency.chf = 0
        Form1.pd()
        Form1.updlist()
        Me.Close()
    End Sub

    Private Sub sure_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class