Imports System.IO
Imports System.Globalization

Public Class del
    Dim count As Integer
    Dim dt As Date = Today.Date
    Public dte = dt.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
    Public filename As String = Application.StartupPath() & "\reports\" & dte & ".txt"
    Dim clicked As Boolean = False
    Private Sub del_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = DateString
        If File.Exists(filename) Then
            MsgBox("you already created a new day")

            Me.Close()

        End If
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = Label1.Text Then
            My.Settings.total = 0
            Form1.sum = 0
            Form1.lbtotal.Text = Form1.sum
            statdel()
            File.Create(filename).Dispose()
            For Each Label In Form1.FlowLayoutPanel1.Controls
                Label.text = ""
                Label.backcolor = Color.LightGray
            Next
            Form1.pathactive = filename
            Form1.txt = ""
            My.Settings.count = 0
            Form1.count = 0
            Form1.lbl = Form1.labelarray(0)
            Form1.updlist()
            For i As Integer = 0 To 159
                Form1.edited(i) = False
                Form1.lbvale(i) = 0
                Form1.chk(i) = False
                Form1.chkus(i) = False
            Next
            My.Settings.lbval = ""
            My.Settings.chk = ""
            My.Settings.chkus = ""
            My.Settings.cd = ""
            My.Settings.am = ""
            My.Settings.profitt = ""
            My.Settings.chkp = ""
            My.Settings.rate = 1500
            checkdel()

            check.ShowDialog()
            Form1.updlist()
            Me.Close()
        Else
            MsgBox("invalid date entry")
            Me.Close()
        End If
    End Sub
    Private Sub statdel()    
        Form1.sent = 0
        Form1.sentc = 0
        Form1.paid = 0
        Form1.paidc = 0
        Form1.mtco = 0
        Form1.mt = 0
        Form1.alf = 0
        Form1.alfac = 0
        Form1.LBP = 0
        Form1.og = 0
        Form1.ogc = 0
        Form1.usd = 0
        Form1.profit = 0
        Form1.omtt = 0
        Form1.omtc = 0
        Form1.InternetSales = 0
        Form1.InternetSalesCount = 0
        Form1.InternetSalesCost = 0
        My.Settings.sent = 0
        My.Settings.sentc = 0
        My.Settings.paid = 0
        My.Settings.paidc = 0
        My.Settings.mtcc = 0
        My.Settings.mtc = 0
        My.Settings.alfa = 0
        My.Settings.alfac = 0
        My.Settings.lbp = 0
        My.Settings.ogero = 0
        My.Settings.ogeroc = 0
        My.Settings.usd = 0
        My.Settings.profit = 0
        My.Settings.omtt = 0
        My.Settings.omtc = 0
        My.Settings.InternetSales = 0
        My.Settings.InternetSalesCount = 0
        My.Settings.InternetSalesCost = 0
    End Sub
    Public Sub checkdel()
        My.Settings.hun = ""
        My.Settings.fif = ""
        My.Settings.twen = ""
        My.Settings.ten = ""
        My.Settings.fiv = ""
        My.Settings.one = ""
        My.Settings.ch = ""
        My.Settings.lhun = ""
        My.Settings.lfif = ""
        My.Settings.ltwen = ""
        My.Settings.lten = ""
        My.Settings.lfiv = ""
        My.Settings.lone = ""
        My.Settings.lch = ""
        My.Settings.depo = False
    End Sub
End Class