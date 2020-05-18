Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Public Class currency
    Dim rate As Decimal = 0
    Dim contro1 As textbox
    Public curr As String
    Public amou As Decimal
    Public eur, cad, gbp, jpy, sar, aud, aed, sek, qar, kwd, bhd, omr, jod, chf As Integer
    Public d(249) As Integer
    Public a(249) As Integer



    Private Sub currency_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Visible = False
        WebBrowser1.Navigate("http://i.dailymail.co.uk/i/pix/2016/04/12/17/3319F40400000578-3536223-image-a-6_1460477307107.jpg")
        ret()
        NumericUpDown1.Value = 1
        amount.Text = ""
        marketrate.Text = ""
        sum.Text = ""
        ComboBox1.SelectedIndex = 0
        update()
    End Sub
    Public Sub update()

    Dim Str As System.IO.Stream
    Dim srRead As System.IO.StreamReader
        Try
    ' make a Web request
    Dim req As System.Net.WebRequest = System.Net.WebRequest.Create("https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=" + Mid(ComboBox1.SelectedItem, 1, 3) + "&to_currency=USD&apikey=ABP0JFWVK2RFVW6J")
    Dim resp As System.Net.WebResponse = req.GetResponse
            Str = resp.GetResponseStream
            srRead = New System.IO.StreamReader(Str)
    ' read all the text 
            RichTextBox1.Text = srRead.ReadToEnd

    Dim x As String = Mid(RichTextBox1.Lines(6), 30, 8)
            RichTextBox1.Text = x
            rate = Val(Mid(x, x.IndexOf(",") + 2))
            marketrate.Text = rate
    Dim temp As String = (Val(marketrate.Text) * ((100 - NumericUpDown1.Value) / 100)).ToString
            ourate.Text = Mid(temp, 1, temp.IndexOf(".") + 5)



            temp = Math.Floor(Val(ourate.Text) * Val(amount.Text))
            sum.Text = temp.ToString


        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
            marketrate.Text = "FAILED"
            ourate.Text = "FAILED"
        Finally
    ' Close Stream and StreamReader when done
            srRead.Close()
            Str.Close()
        End Try
    End Sub
    Private Sub amount_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles amount.Enter
        amount = sender
    End Sub
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged, NumericUpDown1.KeyPress
        Dim temp As String = (Val(marketrate.Text) * ((100 - NumericUpDown1.Value) / 100)).ToString
        ourate.Text = Mid(temp, 1, temp.IndexOf(".") + 5)


        temp = Math.Floor(Val(ourate.Text) * Val(amount.Text))
        sum.Text = temp.ToString
    End Sub
    Private Sub amount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles amount.TextChanged
        Dim temp As Decimal = 0
        temp = Math.Floor(Val(ourate.Text) * Val(amount.Text))
        sum.Text = temp.ToString
    End Sub
    Private Sub combobox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownClosed
        Update()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.count += 1
        If Form1.lbl.Text = "" Then
            Form1.lbl = Form1.labelarray(Form1.count - 1)
        Else
            Form1.lbl = Form1.labelarray(Form1.count - 1)

        End If
        Form1.lbl.Text = Form1.count & " ) --" & String.Format("{0,-20}{1,-20}{2,-15}", sum.Text & " $", amount.Text, ComboBox1.Text) & "  " & TimeOfDay
        Form1.lbl.BackColor = Color.Pink
        Form1.sum -= Val(sum.Text)
        Form1.lbtotal.Text = Decimal.Round(Form1.sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
        Form1.chk(Form1.count) = False
        Form1.chkus(Form1.count) = False
        Form1.lblval(Form1.count, 0) = Val(sum.Text)
        fill()

        Form1.updlist()
        Form1.FlowLayoutPanel1.ScrollControlIntoView(Form1.lbl)
        Me.Close()
    End Sub
    Public Sub fill()


        Select Case ComboBox1.SelectedIndex
            Case 0
                eur += Val(amount.Text)
                d(Form1.count) = 1
                a(Form1.count) = Val(amount.Text)
            Case 1
                cad += Val(amount.Text)
                d(Form1.count) = 2
                a(Form1.count) = Val(amount.Text)
            Case 2
                gbp += Val(amount.Text)
                d(Form1.count) = 3
                a(Form1.count) = Val(amount.Text)
            Case 3
                jpy += Val(amount.Text)
                d(Form1.count) = 4
                a(Form1.count) = Val(amount.Text)
            Case 4
                sar += Val(amount.Text)
                d(Form1.count) = 5
                a(Form1.count) = Val(amount.Text)
            Case 5
                aud += Val(amount.Text)
                d(Form1.count) = 6
                a(Form1.count) = Val(amount.Text)
            Case 6
                aed += Val(amount.Text)
                d(Form1.count) = 7
                a(Form1.count) = Val(amount.Text)
            Case 7
                sek += Val(amount.Text)
                d(Form1.count) = 8
                a(Form1.count) = Val(amount.Text)
            Case 8
                qar += Val(amount.Text)
                d(Form1.count) = 9
                a(Form1.count) = Val(amount.Text)
            Case 9
                kwd += Val(amount.Text)
                d(Form1.count) = 10
                a(Form1.count) = Val(amount.Text)
            Case 10
                bhd += Val(amount.Text)
                d(Form1.count) = 11
                a(Form1.count) = Val(amount.Text)
            Case 11
                omr += Val(amount.Text)
                d(Form1.count) = 12
                a(Form1.count) = Val(amount.Text)
            Case 12
                jod += Val(amount.Text)
                d(Form1.count) = 13
                a(Form1.count) = Val(amount.Text)
            Case 13
                chf += Val(amount.Text)
                d(Form1.count) = 14
                a(Form1.count) = Val(amount.Text)
        End Select
        My.Settings.eur = eur
        My.Settings.cad = cad
        My.Settings.gbp = gbp
        My.Settings.jpy = jpy
        My.Settings.sar = sar
        My.Settings.aud = aud
        My.Settings.aed = aed
        My.Settings.sek = sek
        My.Settings.qar = qar
        My.Settings.kwd = kwd
        My.Settings.bhd = bhd
        My.Settings.omr = omr
        My.Settings.jod = jod
        My.Settings.chf = chf
    End Sub
    Public Sub ret()
        eur = My.Settings.eur
        cad = My.Settings.cad
        gbp = My.Settings.gbp
        jpy = My.Settings.jpy
        sar = My.Settings.sar
        aud = My.Settings.aud
        aed = My.Settings.aed
        sek = My.Settings.sek
        qar = My.Settings.qar
        kwd = My.Settings.kwd
        bhd = My.Settings.bhd
        omr = My.Settings.omr
        jod = My.Settings.jod
        chf = My.Settings.chf
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.count += 1
        If Form1.lbl.Text = "" Then
            Form1.lbl = Form1.labelarray(Form1.count - 1)
        Else
            Form1.lbl = Form1.labelarray(Form1.count - 1)

        End If
        Form1.lbl.Text = Form1.count & " )   " & String.Format("{0,-20}{1,-20}{2,-15}", sum.Text & " $", amount.Text, ComboBox1.Text) & "  " & TimeOfDay
        Form1.lbl.BackColor = Color.Pink
        Form1.sum += Val(sum.Text)

        Form1.lbtotal.Text = Decimal.Round(Form1.sum, 2, MidpointRounding.AwayFromZero).ToString + " $"

        Form1.chk(Form1.count) = False
        Form1.chkus(Form1.count) = False
        Form1.lblval(Form1.count, 0) = -Val(sum.Text)
        fills()

        Form1.updlist()
        Form1.FlowLayoutPanel1.ScrollControlIntoView(Form1.lbl)
        Form1.closingg()
        Me.Close()
    End Sub
    Public Sub fills()
        Select Case ComboBox1.SelectedIndex
            Case 0
                eur -= Val(amount.Text)
                d(Form1.count) = 1
                a(Form1.count) = Val(amount.Text)
            Case 1
                cad -= Val(amount.Text)
                d(Form1.count) = 2
                a(Form1.count) = Val(amount.Text)
            Case 2
                gbp -= Val(amount.Text)
                d(Form1.count) = 3
                a(Form1.count) = Val(amount.Text)
            Case 3
                jpy -= Val(amount.Text)
                d(Form1.count) = 4
                a(Form1.count) = Val(amount.Text)
            Case 4
                sar -= Val(amount.Text)
                d(Form1.count) = 5
                a(Form1.count) = Val(amount.Text)
            Case 5
                aud -= Val(amount.Text)
                d(Form1.count) = 6
                a(Form1.count) = Val(amount.Text)
            Case 6
                aed -= Val(amount.Text)
                d(Form1.count) = 7
                a(Form1.count) = Val(amount.Text)
            Case 7
                sek -= Val(amount.Text)
                d(Form1.count) = 8
                a(Form1.count) = Val(amount.Text)
            Case 8
                qar -= Val(amount.Text)
                d(Form1.count) = 9
                a(Form1.count) = Val(amount.Text)
            Case 9
                kwd -= Val(amount.Text)
                d(Form1.count) = 10
                a(Form1.count) = Val(amount.Text)
            Case 10
                bhd -= Val(amount.Text)
                d(Form1.count) = 11
                a(Form1.count) = Val(amount.Text)
            Case 11
                omr -= Val(amount.Text)
                d(Form1.count) = 12
                a(Form1.count) = Val(amount.Text)
            Case 12
                jod -= Val(amount.Text)
                d(Form1.count) = 13
                a(Form1.count) = Val(amount.Text)
            Case 13
                chf -= Val(amount.Text)
                d(Form1.count) = 14
                a(Form1.count) = Val(amount.Text)
        End Select
        My.Settings.eur = eur
        My.Settings.cad = cad
        My.Settings.gbp = gbp
        My.Settings.jpy = jpy
        My.Settings.sar = sar
        My.Settings.aud = aud
        My.Settings.aed = aed
        My.Settings.sek = sek
        My.Settings.qar = qar
        My.Settings.kwd = kwd
        My.Settings.bhd = bhd
        My.Settings.omr = omr
        My.Settings.jod = jod
        My.Settings.chf = chf
    End Sub
    Public Sub approve()
        My.Settings.eur = eur
        My.Settings.cad = cad
        My.Settings.gbp = gbp
        My.Settings.jpy = jpy
        My.Settings.sar = sar
        My.Settings.aud = aud
        My.Settings.aed = aed
        My.Settings.sek = sek
        My.Settings.qar = qar
        My.Settings.kwd = kwd
        My.Settings.bhd = bhd
        My.Settings.omr = omr
        My.Settings.jod = jod
        My.Settings.chf = chf
    End Sub

End Class
