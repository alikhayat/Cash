Imports System.IO
Imports System.Globalization
Imports System
Imports System.Drawing
Imports System.Net.NetworkInformation
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form
    Public count As Integer
    Dim prompt As String
    Public lbl As Label
    Dim val As Nullable(Of Decimal)
    Dim reason As String
    Public labelarray(249) As Label
    Dim i As Integer
    Public s As String
    Dim st As String
    Public sum As Decimal
    Public pathactive As String
    Public txt As String
    Public ratee As Decimal
    Dim fileToPrint As System.IO.StreamReader
    Dim spaces As String
    Dim printFont As System.Drawing.Font
    Public lblval(249, 1) As Decimal
    Public paid As Decimal
    Public paidc As Integer
    Public sent As Decimal
    Public sentc As Integer
    Public usd As Decimal
    Public LBP As Decimal
    Public mt As Decimal
    Public mtco As Integer
    Public alf As Decimal
    Public alfac As Integer
    Public og As Decimal
    Public ogc As Integer
    Public chk(249) As Boolean
    Public chkus(249) As Boolean
    Public edited(249) As Boolean
    Public lbvale(249) As Decimal
    Public profit As Decimal
    Public chkp(249) As Boolean
    Public profitt(249) As Decimal
    Public omtt As Decimal
    Public omtc As Integer
    Public InternetAcc As Decimal
    Public InternetSales As Decimal
    Public InternetSalesCount As Integer
    Private streamToPrint As StreamReader

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.activated = 1 Then
            Button11.Visible = False
        End If

        profit = My.Settings.profit
        rate.Text = My.Settings.rate
        ratee = Convert.ToInt32(rate.Text)
        sum = My.Settings.total
        count = My.Settings.count
        usd = My.Settings.usd
        LBP = My.Settings.lbp
        paid = My.Settings.paid
        paidc = My.Settings.paidc
        sent = My.Settings.sent
        sentc = My.Settings.sentc
        mt = My.Settings.mtc
        mtco = My.Settings.mtcc
        alf = My.Settings.alfa
        alfac = My.Settings.alfac
        og = My.Settings.ogero
        ogc = My.Settings.ogeroc
        omtt = My.Settings.omtt
        omtc = My.Settings.omtc
        InternetSales = My.Settings.InternetSales
        InternetSalesCount = My.Settings.InternetSalesCount
        InternetAcc = Get_InternetAccount()

        retc()
        updlist()
        lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
        s = ""
        txt = ""
        labels()
        labelstrings()
        retrieve()

        FlowLayoutPanel1.ScrollControlIntoView(lbl)
    End Sub
    Private Function Get_InternetAccountParam() As Decimal()
        Dim con As New OleDb.OleDbConnection(My.Settings.BundlesConnectionString)
        Dim Params(2) As Decimal
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open()
            End If
            Dim myadapter As New OleDb.OleDbDataAdapter("SELECT [VAT],[Tabe3],[rate] FROM [InternetSettings]", con)
            Dim ds As New DataSet
            myadapter.Fill(ds, "InternetSettings")
            If ds.Tables("InternetSettings").Rows.Count <> 0 Then
                If ds.Tables("InternetSettings").Rows(0)(0) <> Nothing And ds.Tables("InternetSettings").Rows(0)(1) <> Nothing And ds.Tables("InternetSettings").Rows(0)(2) <> Nothing Then
                    Params(0) = ds.Tables("InternetSettings").Rows(0)(0)
                    Params(1) = ds.Tables("InternetSettings").Rows(0)(1)
                    Params(2) = ds.Tables("InternetSettings").Rows(0)(2)
                    Return Params
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function
    Private Sub AdjustInternetAfterDelete(ByVal Cost As Decimal)
        Dim CurrentAmount As Decimal = Get_InternetAccount()
        Dim con As New OleDb.OleDbConnection(My.Settings.BundlesConnectionString)
        Try
            Dim NewVal As Decimal = CurrentAmount + Cost
                Dim sql As OleDb.OleDbCommand = New OleDb.OleDbCommand(String.Format("UPDATE InternetSettings SET [Account Balance] = {0}", NewVal), con)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                sql.ExecuteNonQuery()
                InternetAcc = NewVal
        Catch ex As Exception

        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    Private Function Get_InternetAccount() As Decimal
        Dim con As New OleDb.OleDbConnection(My.Settings.BundlesConnectionString)
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open()
            End If
            Dim myadapter As New OleDb.OleDbDataAdapter("SELECT [Account Balance] FROM [InternetSettings]", con)
            Dim ds As New DataSet
            myadapter.Fill(ds, "InternetSettings")
            If ds.Tables("InternetSettings").Rows.Count <> 0 Then
                If ds.Tables("InternetSettings").Rows(0)(0) <> Nothing Then
                    Return ds.Tables("InternetSettings").Rows(0)(0)
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function
    Private Function UpdateInternetAcc(ByVal Val As Decimal) As Boolean
        Dim con As New OleDb.OleDbConnection(My.Settings.BundlesConnectionString)
        Try
            Dim NewVal As Decimal = InternetAcc - Val
            If NewVal > 0 Then
                Dim sql As OleDb.OleDbCommand = New OleDb.OleDbCommand(String.Format("UPDATE InternetSettings SET [Account Balance] = {0}", NewVal), con)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                sql.ExecuteNonQuery()
                InternetAcc = NewVal
                Return True
            Else
                MsgBox("Check internet account settings")
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function
    Private Function Get_BundleCost(ByVal ID As Integer) As Decimal
        If ID < 0 Then
            Return 0
        End If
        Dim con As New OleDb.OleDbConnection(My.Settings.BundlesConnectionString)
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open()
            End If
            Dim Query As String = String.Format("SELECT [Cost] FROM [Bundles] WHERE [ID] = {0}", ID)
            Dim myadapter As New OleDb.OleDbDataAdapter(Query, con)
            Dim ds As New DataSet
            myadapter.Fill(ds, "Bundles")
            If ds.Tables("Bundles").Rows.Count <> 0 Then
                If ds.Tables("Bundles").Rows(0)(0) <> Nothing Then
                    Dim Bundle As Decimal = ds.Tables("Bundles").Rows(0)(0)
                    Dim Params() As Decimal = Get_InternetAccountParam()
                    If Not IsNothing(Params) Then
                        Dim BundleCost As Decimal = Bundle + (Bundle * (Params(0) / 100)) + Params(1)
                        BundleCost = (BundleCost * Params(2)) / 1500
                        Return BundleCost
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        count += 1
        If lbl.Text = "" Then
            lbl = labelarray(count - 1)
        Else
            lbl = labelarray(count - 1)
        End If

        plus()

    End Sub
    Private Sub labels()
        For i As Integer = 0 To UBound(labelarray)
            labelarray(i) = FlowLayoutPanel1.Controls.Item("label" & i + 1)
        Next
        lbl = labelarray(0)

    End Sub
    Private Sub plus()

        textbox.Label3.Text = "deposit reason"

        textbox.Label3.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
        textbox.TextBox1.Location = New Point(120, 179)
        textbox.Label3.Visible = True
        textbox.TextBox1.Visible = True
        textbox.CheckBox1.Visible = False
        textbox.CheckBox3.Visible = True
        textbox.Label4.Visible = True
        textbox.CheckBox1.Checked = False
        textbox.CheckBox2.Checked = False
        textbox.CheckBox2.Visible = False
        textbox.CheckBox4.Visible = True
        textbox.CheckBox4.Checked = False
        textbox.Label2.Text = "$"
        textbox.clicked = False
        textbox.ShowDialog()
       
        textbox.input.Focus()
        If textbox.clicked = True Then
            count -= 1
            Exit Sub
        ElseIf ((textbox.valu = 0) Or (textbox.valu.ToString = "")) Then
            MsgBox("invalid data")
            count -= 1
            Exit Sub
        ElseIf textbox.numb.Length = 0 Then
            textbox.numb = "Cash"


            lbl.Text = count & " )   " & String.Format("{0,-40}{1,-15}", textbox.valu & " $", textbox.numb) & "  " & TimeOfDay


            lbl.BackColor = Color.White
            sum = sum + textbox.valu
            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            lblval(count, 0) = textbox.valu
            If textbox.CheckBox1.Checked = True Then
                lbl.Text = count & " )   " & String.Format("{0,-20}{1,-20}{2,-15}", textbox.valu & " $", Decimal.Round(textbox.valu * ratee, 0, MidpointRounding.AwayFromZero) & " L.L", textbox.numb) & "  " & TimeOfDay
                LBP -= textbox.valu * ratee
                chk(count) = True
                chkus(count) = False
            ElseIf textbox.CheckBox2.Checked = True Then
                usd -= textbox.valu
                chkus(count) = True
                chk(count) = False
            ElseIf textbox.CheckBox4.Checked = True Then
                Try
                    profit += Convert.ToDecimal(textbox.TextBox2.Text)
                    profitt(count) = Convert.ToDecimal(textbox.TextBox2.Text)
                Catch ex As Exception

                End Try

                lbl.Text = count & " )   " & String.Format("{0,-20}{1,-20}{2,-15}", textbox.valu & " $", "Profit: " & textbox.TextBox2.Text.ToString & " $ ", textbox.numb) & "  " & TimeOfDay
                chkp(count) = True
                chk(count) = False
                chkus(count) = False
            End If
            FlowLayoutPanel1.ScrollControlIntoView(lbl)
            closingg()
        Else


            lbl.Text = count & " )   " & String.Format("{0,-40}{1,-15}", textbox.valu & " $", textbox.numb) & "  " & TimeOfDay

            lbl.BackColor = Color.White
            sum = sum + textbox.valu
            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            lblval(count, 0) = textbox.valu
            If textbox.CheckBox1.Checked = True Then
                lbl.Text = count & " )   " & String.Format("{0,-20}{1,-20}{2,-15}", textbox.valu & " $", textbox.valu * ratee & " L.L", textbox.numb) & "  " & TimeOfDay
                LBP -= textbox.valu * ratee
                chk(count) = True
                chkus(count) = False
            ElseIf textbox.CheckBox2.Checked = True Then
                usd -= textbox.valu
                chkus(count) = True
                chk(count) = False
            ElseIf textbox.CheckBox4.Checked = True Then
                Try
                    profit += Convert.ToDecimal(textbox.TextBox2.Text)
                    profitt(count) = Convert.ToDecimal(textbox.TextBox2.Text)
                Catch ex As Exception

                End Try

                lbl.Text = count & " )   " & String.Format("{0,-20}{1,-20}{2,-15}", textbox.valu & " $", "Profit: " & textbox.TextBox2.Text.ToString & " $ ", textbox.numb) & "  " & TimeOfDay
                chkp(count) = True
                chk(count) = False
                chkus(count) = False

            End If
            FlowLayoutPanel1.ScrollControlIntoView(lbl)
            closingg()
        End If

        updlist()

    End Sub
    Private Sub minus()
        textbox.Label3.Text = "withdraw reason"
        textbox.Label3.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)

        textbox.Label3.Visible = True
        textbox.TextBox1.Visible = True
        textbox.CheckBox1.Visible = False
        textbox.CheckBox1.Checked = False
        textbox.CheckBox2.Checked = False
        textbox.CheckBox2.Visible = False
        textbox.CheckBox4.Visible = False
        textbox.CheckBox4.Checked = False
        textbox.CheckBox3.Visible = True
        textbox.Label4.Visible = True

        textbox.Label2.Text = "$"
        textbox.clicked = False
        textbox.ShowDialog()
       
        textbox.input.Focus()



        If textbox.clicked = True Then
            count -= 1
            Exit Sub
        ElseIf ((textbox.valu = 0) Or (textbox.valu.ToString = "")) Then
            MsgBox("invalid data")
            count -= 1
            Exit Sub
        ElseIf textbox.numb.Length = 0 Then
            textbox.numb = "Cash"



            lbl.Text = count & " ) --" & String.Format("{0,-40}{1,-15}", textbox.valu & " $", textbox.numb) & "  " & TimeOfDay
            lbl.BackColor = Color.Silver
            sum = sum - textbox.valu
            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            lblval(count, 0) = textbox.valu
            If textbox.CheckBox1.Checked = True Then
                lbl.Text = count & " ) --" & String.Format("{0,-20}{1,-20}{2,-15}", textbox.valu & " $", Decimal.Round(textbox.valu * ratee, 0, MidpointRounding.AwayFromZero) & " L.L", textbox.numb) & "  " & TimeOfDay
                LBP += textbox.valu * ratee
                chk(count) = True
                chkus(count) = False
            ElseIf textbox.CheckBox2.Checked = True Then
                usd += textbox.valu
                chkus(count) = True
                chk(count) = False
            End If
            FlowLayoutPanel1.ScrollControlIntoView(lbl)
            closingg()
        Else


            lbl.Text = count & " ) --" & String.Format("{0,-40}{1,-15}", textbox.valu & " $", textbox.numb) & "  " & TimeOfDay
            lbl.BackColor = Color.Silver
            sum = sum - textbox.valu
            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            lblval(count, 0) = textbox.valu
            If textbox.CheckBox1.Checked = True Then
                lbl.Text = count & " ) --" & String.Format("{0,-20}{1,-20}{2,-15}", textbox.valu & " $", textbox.valu * ratee & " L.L", textbox.numb) & "  " & TimeOfDay
                LBP += textbox.valu * ratee
                chk(count) = True
                chkus(count) = False
            ElseIf textbox.CheckBox2.Checked = True Then
                usd += textbox.valu
                chkus(count) = True
                chk(count) = False
            End If
            FlowLayoutPanel1.ScrollControlIntoView(lbl)
            closingg()
        End If

        updlist()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        count += 1
        If lbl.Text = "" Then
            lbl = labelarray(count - 1)
        Else
            lbl = labelarray(count - 1)

        End If
        minus()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        count += 1
        If lbl.Text = "" Then
            lbl = labelarray(count - 1)
        Else
            lbl = labelarray(count - 1)

        End If
        westp()
    End Sub
    Private Sub westp()
        textbox.Label3.Text = "MTCN"
        textbox.Label3.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
        textbox.TextBox1.Location = New Point(114, 179)
        textbox.Label3.Visible = True
        textbox.CheckBox1.Visible = True
        textbox.CheckBox2.Visible = True
        textbox.CheckBox1.Checked = False
        textbox.CheckBox2.Checked = False
        textbox.TextBox1.Visible = True
        textbox.CheckBox4.Visible = False
        textbox.CheckBox4.Checked = False
        textbox.CheckBox3.Visible = False
        textbox.Label4.Visible = False
        textbox.Label2.Text = ""
        textbox.clicked = False
        textbox.ShowDialog()
        textbox.input.Focus()



        If textbox.clicked = True Then
            count -= 1
            Exit Sub
        ElseIf ((textbox.valu = 0) Or (textbox.valu.ToString = "") Or (textbox.numb.Length = 0) Or (textbox.numb.Length > 12)) Then
            MsgBox("invalid data")
            count -= 1
            Exit Sub
        ElseIf textbox.CheckBox1.Checked = False And textbox.CheckBox2.Checked = False Then
            MsgBox("please choose balance")
            westp()


        Else
            If textbox.CheckBox1.Checked = True Then
                Dim a As Decimal = textbox.valu


                lbl.Text = count & " )   " & String.Format("{0,-20}{1,-20}{2,-15}", Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero) & " $", a.ToString & " L.L", "(" & textbox.numb & ")") & "  " & TimeOfDay

                LBP -= a
                chk(count) = True
                chkus(count) = False
                lblval(count, 0) = textbox.valu / ratee
                sent += Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero)
                sum = sum + textbox.valu / ratee
            ElseIf textbox.CheckBox2.Checked = True Then
                lbl.Text = count & " )   " & String.Format("{0,-40}{1,-15}", textbox.valu & " $", "(" & textbox.numb & ")") & "  " & TimeOfDay
                usd -= textbox.valu
                chkus(count) = True
                chk(count) = False
                lblval(count, 0) = textbox.valu
                sent += textbox.valu
                sum = sum + textbox.valu
            End If

            lbl.BackColor = Color.Yellow

            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
           
            sentc += 1

            updlist()
            FlowLayoutPanel1.ScrollControlIntoView(lbl)
            closingg()
        End If

    End Sub
    Private Sub wmin()
        textbox.Label3.Text = "MTCN"
        textbox.Label3.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
        textbox.TextBox1.Location = New Point(114, 179)
        textbox.Label3.Visible = True
        textbox.TextBox1.Visible = True
        textbox.CheckBox1.Visible = True
        textbox.CheckBox2.Visible = True
        textbox.CheckBox1.Checked = False
        textbox.CheckBox2.Checked = False
        textbox.CheckBox4.Visible = False
        textbox.CheckBox4.Checked = False
        textbox.CheckBox3.Visible = False
        textbox.Label4.Visible = False
        textbox.Label2.Text = ""
        textbox.clicked = False
        textbox.ShowDialog()
        textbox.input.Focus()


        If textbox.clicked = True Then
            count -= 1
            Exit Sub
        ElseIf ((textbox.valu = 0) Or (textbox.valu.ToString = "") Or (textbox.numb.Length = 0) Or (textbox.numb.Length > 12)) Then
            MsgBox("invalid data")
            count -= 1
            Exit Sub
        ElseIf textbox.CheckBox1.Checked = False And textbox.CheckBox2.Checked = False Then
            MsgBox("please choose balance")
            wmin()

        Else

            If textbox.CheckBox1.Checked = True Then
                Dim a As Decimal = textbox.valu

                lbl.Text = count & " ) --" & String.Format("{0,-20}{1,-20}{2,-15}", Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero) & " $", a.ToString & " L.L", "(" & textbox.numb & ")") & "  " & TimeOfDay
                LBP += a
                chk(count) = True
                chkus(count) = False
                lblval(count, 0) = textbox.valu / ratee
                paid += Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero)
                sum = sum - textbox.valu / ratee
            ElseIf textbox.CheckBox2.Checked = True Then
                lbl.Text = count & " ) --" & String.Format("{0,-40}{1,-15}", textbox.valu & " $", "(" & textbox.numb & ")") & "  " & TimeOfDay
                usd += textbox.valu
                chkus(count) = True
                chk(count) = False
                lblval(count, 0) = textbox.valu
                paid += textbox.valu
                sum = sum - textbox.valu
            End If


            lbl.BackColor = Color.Orange

            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
           
            paidc += 1

            updlist()
            FlowLayoutPanel1.ScrollControlIntoView(lbl)
            closingg()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        count += 1
        If lbl.Text = "" Then
            lbl = labelarray(count - 1)
        Else
            lbl = labelarray(count - 1)

        End If
        wmin()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        count += 1
        If lbl.Text = "" Then
            lbl = labelarray(count - 1)
        Else
            lbl = labelarray(count - 1)

        End If
        mtc()
    End Sub
    Private Sub mtc()
        textbox.Label3.Text = "MTCN"
        textbox.Label3.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
        textbox.TextBox1.Location = New Point(114, 179)
        textbox.Label3.Visible = False
        textbox.TextBox1.Visible = False
        textbox.CheckBox1.Visible = False
        textbox.CheckBox2.Visible = False
        textbox.CheckBox1.Checked = False
        textbox.CheckBox2.Checked = False
        textbox.CheckBox4.Visible = False
        textbox.CheckBox4.Checked = False
        textbox.CheckBox3.Visible = False
        textbox.Label4.Visible = False
        textbox.Label2.Text = "L.L"
        textbox.clicked = False
        textbox.ShowDialog()
        textbox.input.Focus()

        If textbox.clicked = True Then
            count -= 1
            Exit Sub
        ElseIf ((textbox.valu = 0)) Then
            count -= 1
            MsgBox("invalid data")
            Exit Sub
        Else
            'Dim a As Decimal = textbox.valu

            textbox.numb = "MTC"
            lbl.Text = count & " )   " & String.Format("{0,-40}{1,-15}", Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero) & " $", textbox.numb) & "  " & TimeOfDay
            lblval(count, 0) = textbox.valu / ratee
            lbl.BackColor = Color.Aqua
            sum = sum + textbox.valu / ratee

            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            mt += Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero)
            mtco += 1
            LBP -= textbox.valu
            chk(count) = True
            chkus(count) = False
            updlist()
            FlowLayoutPanel1.ScrollControlIntoView(lbl)
            closingg()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        count += 1
        If lbl.Text = "" Then
            lbl = labelarray(count - 1)
        Else
            lbl = labelarray(count - 1)

        End If
        alfa()
    End Sub
    Public Sub alfa()
        textbox.Label3.Text = "ALFAN"
        textbox.Label3.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
        textbox.TextBox1.Location = New Point(114, 179)
        textbox.Label3.Visible = False
        textbox.TextBox1.Visible = False
        textbox.CheckBox1.Visible = False
        textbox.CheckBox2.Visible = False
        textbox.CheckBox1.Checked = False
        textbox.CheckBox2.Checked = False
        textbox.CheckBox4.Visible = False
        textbox.CheckBox4.Checked = False
        textbox.CheckBox3.Visible = False
        textbox.Label4.Visible = False
        textbox.Label2.Text = "L.L"
        textbox.clicked = False
        textbox.ShowDialog()
        textbox.input.Focus()


        If textbox.clicked = True Then
            count -= 1
            Exit Sub
        ElseIf ((textbox.valu = 0)) Then
            count -= 1
            MsgBox("invalid data")
            Exit Sub
        Else
            'If textbox.CheckBox1.Checked = True Then
            'Dim a As Decimal = textbox.valu

            textbox.numb = "ALFA"

            lbl.Text = count & " )   " & String.Format("{0,-40}{1,-15}", Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero) & " $", textbox.numb) & "  " & TimeOfDay
            lblval(count, 0) = textbox.valu / ratee
            lbl.BackColor = Color.Red
            sum = sum + textbox.valu / ratee

            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            alf += Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero)
            alfac += 1
            LBP -= textbox.valu
            chk(count) = True
            chkus(count) = False
            updlist()
            FlowLayoutPanel1.ScrollControlIntoView(lbl)
            closingg()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        count += 1
        If lbl.Text = "" Then
            lbl = labelarray(count - 1)
        Else
            lbl = labelarray(count - 1)

        End If
        ogero()
    End Sub
    Private Sub ogero()
        textbox.Label3.Visible = False
        textbox.TextBox1.Visible = False
        textbox.CheckBox1.Checked = True
        textbox.CheckBox2.Visible = False
        textbox.CheckBox2.Checked = False
        textbox.CheckBox4.Visible = False
        textbox.CheckBox4.Checked = False
        textbox.CheckBox1.Visible = False
        textbox.CheckBox3.Visible = False
        textbox.Label4.Visible = False
        textbox.Label2.Text = "L.L"
        textbox.clicked = False
        textbox.ShowDialog()
        textbox.input.Focus()


        If textbox.clicked = True Then
            count -= 1
            Exit Sub
        ElseIf ((textbox.valu = 0)) Then
            count -= 1
            MsgBox("invalid data")
            Exit Sub


        Else
            textbox.numb = "OGERO"


            lbl.Text = count & " )   " & String.Format("{0,-40}{1,-15}", Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero) & " $", textbox.numb) & "  " & TimeOfDay
            lblval(count, 0) = textbox.valu / ratee
            lbl.BackColor = Color.Green
            sum = sum + textbox.valu / ratee

            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            og += Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero)
            ogc += 1
            LBP -= textbox.valu
            chk(count) = True
            chkus(count) = False
            updlist()
            FlowLayoutPanel1.ScrollControlIntoView(lbl)
            closingg()
        End If
    End Sub

    Public Sub labelstrings()
        Dim dt As Date = Today.Date
        dt = dt.AddDays(-1)
        Dim dte = dt.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
        Dim temp As String = Application.StartupPath() & "\reports\" & dte & ".txt"
        If My.Computer.FileSystem.FileExists(del.filename) Then
            Dim lines As String() = File.ReadAllLines(del.filename)

            pathactive = del.filename
            Try
                For i As Integer = 0 To UBound(lines) - 32
                    Dim last As Char = lines(i).Last

                    If last = "!" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.White
                    ElseIf last = "@" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Silver
                    ElseIf last = "#" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Yellow
                    ElseIf last = "$" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Orange
                    ElseIf last = "%" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Aqua
                    ElseIf last = "^" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Red
                    ElseIf last = "&" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Green
                    ElseIf last = "*" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Pink
                    ElseIf last = "(" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.MintCream
                    ElseIf last = ")" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Wheat
                    ElseIf last = "_" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Violet
                    ElseIf last = "+" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.GhostWhite
                    ElseIf last = "|" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)
                        labelarray(i).BackColor = Color.Gold
                    ElseIf last = "`" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)
                        labelarray(i).BackColor = Color.Violet
                    ElseIf last <> "!" And last <> "@" And last <> "#" And last <> "$" And last <> "%" And last <> "^" And last <> "&" And last <> "*" And last <> "(" And last <> ")" And last <> "_" And last <> "+" And last <> "|" And last <> "`" Then
                        Exit Sub
                    End If
                Next
            Catch ex As Exception

            End Try
        ElseIf My.Computer.FileSystem.FileExists(temp) And Not My.Computer.FileSystem.FileExists(del.filename) Then
            Dim lines As String() = File.ReadAllLines(temp)
            pathactive = temp
            Try
                For i As Integer = 0 To UBound(lines) - 32

                    Dim last As Char = lines(i).Last



                    If last = "!" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.White
                    ElseIf last = "@" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Silver
                    ElseIf last = "#" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Yellow
                    ElseIf last = "$" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Orange
                    ElseIf last = "%" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Aqua
                    ElseIf last = "^" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Red
                    ElseIf last = "&" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Green
                    ElseIf last = "*" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Pink
                    ElseIf last = "(" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.MintCream
                    ElseIf last = ")" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Wheat
                    ElseIf last = "_" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.Violet
                    ElseIf last = "+" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)

                        labelarray(i).BackColor = Color.GhostWhite
                    ElseIf last = "|" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)
                        labelarray(i).BackColor = Color.Gold
                    ElseIf last = "`" Then
                        labelarray(i).Text = lines(i).Trim.Remove(lines(i).Length - 1)
                        labelarray(i).BackColor = Color.Violet
                    End If

                Next
            Catch ex As Exception

            End Try

        ElseIf Not My.Computer.FileSystem.FileExists(temp) And Not My.Computer.FileSystem.FileExists(del.filename) Then

            pathactive = del.filename
            My.Settings.total = 0
            lbtotal.Text = My.Settings.total
            del.ShowDialog()
            check.ShowDialog()
            Exit Sub
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        del.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        currency.ShowDialog()
    End Sub


    Private Sub printButton_Click(sender As Object, e As EventArgs) Handles printButton.Click
        closingg()
        Try
            streamToPrint = New StreamReader(pathactive)
            Try
                printFont = New Font("Lucida Sans Unicode", 10)
                Dim pd As New PrintDocument()
                AddHandler pd.PrintPage, AddressOf Me.pd_PrintPage
                pd.Print()
            Finally
                streamToPrint.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

        ' Print each line of the file.
        While count < linesPerPage
            line = streamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
            count += 1
        End While

        ' If more lines exist, print another page.
        If (line IsNot Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If
    End Sub
    Private Sub ids_Click(sender As Object, e As EventArgs) Handles ids.Click
        idss.ShowDialog()
    End Sub
    Public Sub updlist()

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        Decimal.Round(LBP, 0, MidpointRounding.AwayFromZero)
        ListBox1.Items.Add("PAID:" & "  " & paidc.ToString)

        ListBox1.Items.Add("SENT:" & "  " & sentc.ToString)

        ListBox1.Items.Add("BALANCE IN USD:  ")

        ListBox1.Items.Add("BALANCE IN LBP:  ")

        ListBox1.Items.Add("ALFA:  " & alfac.ToString)

        ListBox1.Items.Add("MTC:  " & mtco.ToString)

        ListBox1.Items.Add("OGERO:  " & ogc.ToString)
        ListBox1.Items.Add("OMT Services :   " & omtc.ToString)
        ListBox1.Items.Add("Internet Services :   " & InternetSalesCount.ToString)
        ListBox1.Items.Add("PROFIT (store items):  ")
        ListBox1.Items.Add("Debt:   ")
        ListBox1.Items.Add("---------------------")
        ListBox1.Items.Add("EUR (EURO)")
        ListBox1.Items.Add("CAD (Canadian dollar)")
        ListBox1.Items.Add("GBP (British pound)")
        ListBox1.Items.Add("JPY (Japanese yen)")
        ListBox1.Items.Add("SAR (Saudi riyal)")
        ListBox1.Items.Add("AUD (Australian dollar)")
        ListBox1.Items.Add("AED (UAE dirham)")
        ListBox1.Items.Add("SEK (Swedish krona)")
        ListBox1.Items.Add("QAR (Qatari riyal)")
        ListBox1.Items.Add("KWD (Kuwaiti dinar)")
        ListBox1.Items.Add("BHD (Bahraini dinar)")
        ListBox1.Items.Add("OMR (OMANI Riyal)")
        ListBox1.Items.Add("JOD (Jordanian Dinnar)")
        'ListBox1.Items.Add("CHF (SWISS FRANK)")

        ListBox2.Items.Add(Decimal.Round(paid, 2).ToString & " $")

        ListBox2.Items.Add(Decimal.Round(sent, 2).ToString & " $")

        ListBox2.Items.Add(usd.ToString("N2", CultureInfo.InvariantCulture) & " $")

        ListBox2.Items.Add(LBP.ToString("N2", CultureInfo.InvariantCulture) & " L.L")

        ListBox2.Items.Add(Decimal.Round(alf, 2).ToString & " $")

        ListBox2.Items.Add(Decimal.Round(mt, 2).ToString & " $")

        ListBox2.Items.Add(Decimal.Round(og, 2).ToString & " $")
        ListBox2.Items.Add(Decimal.Round(omtt, 2).ToString & " $")
        ListBox2.Items.Add(Decimal.Round(InternetSales, 2).ToString & " $")
        ListBox2.Items.Add(profit.ToString & " $")
        ListBox2.Items.Add(My.Settings.debit.ToString + " $")
        ListBox2.Items.Add("-------------")
        ListBox2.Items.Add(My.Settings.eur)
        ListBox2.Items.Add(My.Settings.cad)
        ListBox2.Items.Add(My.Settings.gbp)
        ListBox2.Items.Add(My.Settings.jpy)
        ListBox2.Items.Add(My.Settings.sar)
        ListBox2.Items.Add(My.Settings.aud)
        ListBox2.Items.Add(My.Settings.aed)
        ListBox2.Items.Add(My.Settings.sek)
        ListBox2.Items.Add(My.Settings.qar)
        ListBox2.Items.Add(My.Settings.kwd)
        ListBox2.Items.Add(My.Settings.bhd)
        ListBox2.Items.Add(My.Settings.omr)
        ListBox2.Items.Add(My.Settings.jod)
        'ListBox2.Items.Add(My.Settings.chf)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        check.ShowDialog()
    End Sub
    Public Sub good()
        count += 1
        If lbl.Text = "" Then
            lbl = labelarray(count - 1)
        Else
            lbl = labelarray(count - 1)

        End If
        Dim res As Integer = Convert.ToInt32(check.res)
        lbl.Text = count & " ) " & String.Format("{0,-40}{1,-15}", check.summ.Text & " $", "from :" & Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString & " $" & "  " & TimeOfDay)
        lbl.BackColor = Color.GhostWhite
        chk(count) = False
        chkus(count) = False
        lblval(count, 0) = res
        FlowLayoutPanel1.ScrollControlIntoView(lbl)
        closingg()
    End Sub
    Public Sub report()

        Dim report As String
        report = vbCrLf + "------------------------------------------------------------------" + vbCrLf + "PAID:  " + "  " + paidc.ToString + " = " + Decimal.Round(paid, 2, MidpointRounding.AwayFromZero).ToString _
       + " $" + vbCrLf + "SENT:  " & "  " & sentc.ToString + " = " + Decimal.Round(sent, 2, MidpointRounding.AwayFromZero).ToString + " $" + vbCrLf + "BALANCE IN USD:  " + usd.ToString("N1", CultureInfo.InvariantCulture) + " $" + vbCrLf + _
        "BALANCE IN LBP:  " + LBP.ToString("N1", CultureInfo.InvariantCulture) + " L.L" + vbCrLf + "your cash balance:  " + Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + "$" + vbCrLf + "ALFA:  " & alfac.ToString + " = " + alf.ToString + " $" + vbCrLf + "MTC:  " & mtco.ToString + " = " + mt.ToString + " $" + vbCrLf + "OGERO:  " & ogc.ToString + " = " + Decimal.Round(og, 2, MidpointRounding.AwayFromZero).ToString _
   + " $" + vbCrLf + "OMT services:    " + omtc.ToString + " = " + Decimal.Round(omtt, 2, MidpointRounding.AwayFromZero).ToString + " $" + vbCrLf + "PROFIT (store items):  " & profit.ToString + " $" + vbCrLf + "Debt:  " + My.Settings.debit.ToString + " $" + vbCrLf + "------------------------------------------------------------------" + vbCrLf + "EUR (EURO):  " + My.Settings.eur.ToString + vbCrLf _
        + "CAD (Canadian dollar):  " + My.Settings.cad.ToString + vbCrLf + "GBP (British pound):  " + My.Settings.gbp.ToString + vbCrLf + "JPY (Japanese yen):  " + My.Settings.jpy.ToString + vbCrLf _
        + "SAR (Saudi riyal):  " + My.Settings.sar.ToString + vbCrLf + "AUD (Australian dollar):  " + My.Settings.aud.ToString + vbCrLf _
        + "AED (UAE dirham):  " + My.Settings.aed.ToString + vbCrLf + "SEK (Swedish krona):  " + My.Settings.sek.ToString + vbCrLf + "QAR (Qatari riyal):  " + My.Settings.qar.ToString + vbCrLf _
        + "KWD (Kuwaiti dinar):  " + My.Settings.kwd.ToString + vbCrLf + "BHD (Bahraini dinar):  " + My.Settings.bhd.ToString + vbCrLf + "OMR (OMANI Riyal):  " + My.Settings.omr.ToString + vbCrLf _
        + "JOD (Jordanian Dinnar):  " + My.Settings.jod.ToString + vbCrLf + "CHF (SWISS FRANK):" + My.Settings.chf.ToString + vbCrLf + "------------------------------------------------------------------" + vbCrLf +
        "100$ x " + My.Settings.hun.ToString + "  --   100000L.L x " + My.Settings.lhun.ToString + vbCrLf + "50$ x " + My.Settings.fif.ToString + "  --   50000L.L x " + My.Settings.lfif.ToString + vbCrLf +
        "20$ x " + My.Settings.twen.ToString + "  --   20000L.L x " + My.Settings.ltwen.ToString + vbCrLf + "10$ x " + My.Settings.ten.ToString + "  --   10000L.L x " + My.Settings.lten.ToString + vbCrLf +
        "5$ x " + My.Settings.fiv.ToString + "  --   5000L.L x " + My.Settings.lfiv.ToString + vbCrLf + "1$ x " + My.Settings.one.ToString + "  --   1000L.L x " + My.Settings.lone.ToString + vbCrLf +
        "cheque($) x " + My.Settings.ch.ToString + "  --   cheque(L.L) x " + My.Settings.lch.ToString
        txt += report
    End Sub
    Private Sub arrayint()

        Dim s As String = ""
        For Each ss As Decimal In lblval
            s &= ss.ToString() & " "
        Next
        s = s.TrimEnd()
        Dim d As String = ""
        For Each ii As Boolean In chk
            d &= ii.ToString() & " "
        Next
        d = d.TrimEnd()

        Dim f As String = ""
        For Each ff As Boolean In chkus
            f &= ff.ToString() & " "
        Next
        f = f.TrimEnd()


        Dim c As String = ""
        For Each cc As Integer In currency.d
            c &= cc.ToString() & " "
        Next
        c = c.TrimEnd()
        Dim a As String = ""
        For Each aa As Integer In currency.a
            a &= aa.ToString() & " "
        Next
        a = a.TrimEnd
        Dim z As String = ""
        For Each zz As Decimal In profitt
            z &= zz.ToString() & " "
        Next
        z = z.TrimEnd()
        Dim y As String = ""
        For Each yy As Boolean In chkp
            y &= yy.ToString() & " "
        Next
        y = y.TrimEnd()
        My.Settings.lbval = s
        My.Settings.chk = d
        My.Settings.chkus = f
        My.Settings.cd = c
        My.Settings.am = a
        My.Settings.profitt = z
        My.Settings.chkp = y
    End Sub
    Private Sub retrieve()
        Try
            Dim input As String = My.Settings.lbval
            Dim ii() As String = input.Split(" ")

            For index As Integer = 0 To ii.Count - 1
                Decimal.TryParse(ii(index), lblval(index, 0))
            Next
            Dim input2 As String = My.Settings.chk
            Dim iii() As String = input2.Split(" ")
            For index As Integer = 0 To iii.Count - 1
                Boolean.TryParse(iii(index), chk(index))
            Next

            Dim input3 As String = My.Settings.chkus
            Dim iiii() As String = input3.Split(" ")
            For index As Integer = 0 To iiii.Count - 1
                Boolean.TryParse(iiii(index), chkus(index))
            Next
            Dim input4 As String = My.Settings.cd
            Dim c() As String = input4.Split(" ")
            For index As Integer = 0 To c.Count - 1
                Integer.TryParse(c(index), currency.d(index))
            Next
            Dim input5 As String = My.Settings.am
            Dim a() As String = input5.Split(" ")
            For index As Integer = 0 To a.Count - 1
                Integer.TryParse(a(index), currency.a(index))
            Next
            Dim inn As String = My.Settings.profitt
            Dim z() As String = inn.Split(" ")
            For index As Integer = 0 To z.Count - 1
                Decimal.TryParse(z(index), profitt(index))
            Next
            Dim innn As String = My.Settings.chkp
            Dim y() As String = innn.Split(" ")
            For index As Integer = 0 To y.Count - 1
                Boolean.TryParse(y(index), chkp(index))
            Next
        Catch ex As Exception

        End Try

    End Sub
    Public Sub deposit()
        count += 1
        Dim res As Integer = Convert.ToInt32(check.res)
        If lbl.Text = "" Then
            lbl = labelarray(count - 1)
        Else
            lbl = labelarray(count - 1)

        End If
        lbl.Text = count & " ) " & String.Format("{0,-55}", "you deposited:" & res & " $") & "  " & TimeOfDay

        lbl.BackColor = Color.Violet
        sum = sum + Convert.ToInt32(check.res)
        lbtotal.Text = sum.ToString + " $"
        lblval(count, 0) = res
        chk(count) = False
        chkus(count) = False
        check.Visible = False
        check.Close()
    End Sub
    Public Sub closingg()

        txt = ""
        My.Computer.FileSystem.WriteAllText _
   (pathactive, txt, False)
        My.Settings.total = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero)
        My.Settings.count = count
        My.Settings.sent = sent
        My.Settings.sentc = sentc
        My.Settings.paid = paid
        My.Settings.paidc = paidc
        My.Settings.mtcc = mtco
        My.Settings.mtc = mt
        My.Settings.alfa = alf
        My.Settings.alfac = alfac
        My.Settings.lbp = LBP
        My.Settings.ogero = og
        My.Settings.ogeroc = ogc
        My.Settings.usd = usd
        My.Settings.profit = profit
        My.Settings.omtt = omtt
        My.Settings.omtc = omtc
        My.Settings.InternetSales = InternetSales
        My.Settings.InternetSalesCount = InternetSalesCount

        For i As Integer = 0 To count


            If labelarray(i).BackColor = Color.White Then
                txt += labelarray(i).Text.TrimEnd + "!" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.Silver Then
                txt += labelarray(i).Text.TrimEnd + "@" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.Yellow Then
                txt += labelarray(i).Text.TrimEnd + "#" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.Orange Then
                txt += labelarray(i).Text.TrimEnd + "$" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.Aqua Then
                txt += labelarray(i).Text.TrimEnd + "%" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.Red Then
                txt += labelarray(i).Text.TrimEnd + "^" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.Green Then
                txt += labelarray(i).Text.TrimEnd + "&" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.Pink Then
                txt += labelarray(i).Text.TrimEnd + "*" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.MintCream Then
                txt += labelarray(i).Text.TrimEnd + "(" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.Wheat Then
                txt += labelarray(i).Text.TrimEnd + ")" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.Violet Then
                txt += labelarray(i).Text.TrimEnd + "_" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.GhostWhite Then
                txt += labelarray(i).Text.TrimEnd + "+" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.Gold Then
                txt += labelarray(i).Text.TrimEnd + "|" + vbCrLf
            ElseIf labelarray(i).BackColor = Color.Purple Then
                txt += labelarray(i).Text.TrimEnd + "~" + vbCrLf
            End If
        Next
        report()

        If My.Computer.FileSystem.FileExists(pathactive) Then
            My.Computer.FileSystem.WriteAllText _
    (pathactive, txt, False)
        Else
            Exit Sub
        End If
        arrayint()
        Dim a As String = lbtotal.Text.Replace("$", "").TrimEnd
        My.Settings.total = Convert.ToDecimal(a)
        My.Settings.rate = Convert.ToInt32(rate.Text)
        My.Settings.Save()

    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        closingg()
        Application.Exit()
    End Sub
    Public Sub cur()
        My.Settings.eur = currency.eur
        My.Settings.cad = currency.cad
        My.Settings.gbp = currency.gbp
        My.Settings.jpy = currency.jpy
        My.Settings.sar = currency.sar
        My.Settings.aud = currency.aud
        My.Settings.aed = currency.aed
        My.Settings.sek = currency.sek
        My.Settings.qar = currency.qar
        My.Settings.kwd = currency.kwd
        My.Settings.bhd = currency.bhd
        My.Settings.omr = currency.omr
        My.Settings.jod = currency.jod
        My.Settings.chf = currency.chf
    End Sub


    Private Sub rate_TextChanged(sender As Object, e As EventArgs) Handles rate.TextChanged
        Try
            ratee = Convert.ToDecimal(rate.Text)
        Catch ex As Exception

        End Try

    End Sub
    Public Sub retc()
        currency.eur = My.Settings.eur
        currency.cad = My.Settings.cad
        currency.gbp = My.Settings.gbp
        currency.jpy = My.Settings.jpy
        currency.sar = My.Settings.sar
        currency.aud = My.Settings.aud
        currency.aed = My.Settings.aed
        currency.sek = My.Settings.sek
        currency.qar = My.Settings.qar
        currency.kwd = My.Settings.kwd
        currency.bhd = My.Settings.bhd
        currency.omr = My.Settings.omr
        currency.jod = My.Settings.jod
        currency.chf = My.Settings.chf
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        security.Visible = True
        Me.Visible = False
    End Sub

    Private Sub Label1_DoubleClick(sender As Object, e As EventArgs) Handles Label99.DoubleClick, Label98.DoubleClick, Label97.DoubleClick, Label96.DoubleClick, Label95.DoubleClick, Label94.DoubleClick, Label93.DoubleClick, Label92.DoubleClick, Label91.DoubleClick, Label90.DoubleClick, Label9.DoubleClick, Label89.DoubleClick, Label88.DoubleClick, Label87.DoubleClick, Label86.DoubleClick, Label85.DoubleClick, Label84.DoubleClick, Label83.DoubleClick, Label82.DoubleClick, Label81.DoubleClick, Label80.DoubleClick, Label8.DoubleClick, Label79.DoubleClick, Label78.DoubleClick, Label77.DoubleClick, Label76.DoubleClick, Label75.DoubleClick, Label74.DoubleClick, Label73.DoubleClick, Label72.DoubleClick, Label71.DoubleClick, Label70.DoubleClick, Label7.DoubleClick, Label69.DoubleClick, Label68.DoubleClick, Label67.DoubleClick, Label66.DoubleClick, Label65.DoubleClick, Label64.DoubleClick, Label63.DoubleClick, Label62.DoubleClick, Label61.DoubleClick, Label60.DoubleClick, Label6.DoubleClick, Label59.DoubleClick, Label58.DoubleClick, Label57.DoubleClick, Label56.DoubleClick, Label55.DoubleClick, Label54.DoubleClick, Label53.DoubleClick, Label52.DoubleClick, Label51.DoubleClick, Label50.DoubleClick, Label5.DoubleClick, Label49.DoubleClick, Label48.DoubleClick, Label47.DoubleClick, Label46.DoubleClick, Label45.DoubleClick, Label44.DoubleClick, Label43.DoubleClick, Label42.DoubleClick, Label41.DoubleClick, Label40.DoubleClick, Label4.DoubleClick, Label39.DoubleClick, Label38.DoubleClick, Label37.DoubleClick, Label36.DoubleClick, Label35.DoubleClick, Label34.DoubleClick, Label33.DoubleClick, Label32.DoubleClick, Label31.DoubleClick, Label30.DoubleClick, Label3.DoubleClick, Label29.DoubleClick, Label28.DoubleClick, Label27.DoubleClick, Label26.DoubleClick, Label250.DoubleClick, Label25.DoubleClick, Label249.DoubleClick, Label248.DoubleClick, Label247.DoubleClick, Label246.DoubleClick, Label245.DoubleClick, Label244.DoubleClick, Label243.DoubleClick, Label242.DoubleClick, Label241.DoubleClick, Label240.DoubleClick, Label24.DoubleClick, Label239.DoubleClick, Label238.DoubleClick, Label237.DoubleClick, Label236.DoubleClick, Label235.DoubleClick, Label234.DoubleClick, Label233.DoubleClick, Label232.DoubleClick, Label231.DoubleClick, Label230.DoubleClick, Label23.DoubleClick, Label229.DoubleClick, Label228.DoubleClick, Label227.DoubleClick, Label226.DoubleClick, Label225.DoubleClick, Label224.DoubleClick, Label223.DoubleClick, Label222.DoubleClick, Label221.DoubleClick, Label220.DoubleClick, Label22.DoubleClick, Label219.DoubleClick, Label218.DoubleClick, Label217.DoubleClick, Label216.DoubleClick, Label215.DoubleClick, Label214.DoubleClick, Label213.DoubleClick, Label212.DoubleClick, Label211.DoubleClick, Label210.DoubleClick, Label21.DoubleClick, Label209.DoubleClick, Label208.DoubleClick, Label207.DoubleClick, Label206.DoubleClick, Label205.DoubleClick, Label204.DoubleClick, Label203.DoubleClick, Label202.DoubleClick, Label201.DoubleClick, Label200.DoubleClick, Label20.DoubleClick, Label2.DoubleClick, Label199.DoubleClick, Label198.DoubleClick, Label197.DoubleClick, Label196.DoubleClick, Label195.DoubleClick, Label194.DoubleClick, Label193.DoubleClick, Label192.DoubleClick, Label191.DoubleClick, Label190.DoubleClick, Label19.DoubleClick, Label189.DoubleClick, Label188.DoubleClick, Label187.DoubleClick, Label186.DoubleClick, Label185.DoubleClick, Label184.DoubleClick, Label183.DoubleClick, Label182.DoubleClick, Label181.DoubleClick, Label180.DoubleClick, Label18.DoubleClick, Label179.DoubleClick, Label178.DoubleClick, Label177.DoubleClick, Label176.DoubleClick, Label175.DoubleClick, Label174.DoubleClick, Label173.DoubleClick, Label172.DoubleClick, Label171.DoubleClick, Label170.DoubleClick, Label17.DoubleClick, Label169.DoubleClick, Label168.DoubleClick, Label167.DoubleClick, Label166.DoubleClick, Label165.DoubleClick, Label164.DoubleClick, Label163.DoubleClick, Label162.DoubleClick, Label161.DoubleClick, Label160.DoubleClick, Label16.DoubleClick, Label159.DoubleClick, Label158.DoubleClick, Label157.DoubleClick, Label156.DoubleClick, Label155.DoubleClick, Label154.DoubleClick, Label153.DoubleClick, Label152.DoubleClick, Label151.DoubleClick, Label150.DoubleClick, Label15.DoubleClick, Label149.DoubleClick, Label148.DoubleClick, Label147.DoubleClick, Label146.DoubleClick, Label145.DoubleClick, Label144.DoubleClick, Label143.DoubleClick, Label142.DoubleClick, Label141.DoubleClick, Label140.DoubleClick, Label14.DoubleClick, Label139.DoubleClick, Label138.DoubleClick, Label137.DoubleClick, Label136.DoubleClick, Label135.DoubleClick, Label134.DoubleClick, Label133.DoubleClick, Label132.DoubleClick, Label131.DoubleClick, Label130.DoubleClick, Label13.DoubleClick, Label129.DoubleClick, Label128.DoubleClick, Label127.DoubleClick, Label126.DoubleClick, Label125.DoubleClick, Label124.DoubleClick, Label123.DoubleClick, Label122.DoubleClick, Label121.DoubleClick, Label120.DoubleClick, Label12.DoubleClick, Label119.DoubleClick, Label118.DoubleClick, Label117.DoubleClick, Label116.DoubleClick, Label115.DoubleClick, Label114.DoubleClick, Label113.DoubleClick, Label112.DoubleClick, Label111.DoubleClick, Label110.DoubleClick, Label11.DoubleClick, Label109.DoubleClick, Label108.DoubleClick, Label107.DoubleClick, Label106.DoubleClick, Label105.DoubleClick, Label104.DoubleClick, Label103.DoubleClick, Label102.DoubleClick, Label101.DoubleClick, Label100.DoubleClick, Label10.DoubleClick, Label1.DoubleClick, FlowLayoutPanel1.DoubleClick
        Dim clickedlbl = TryCast(sender, Label)
        Dim auth As String = String.Empty
        Dim diag = New Authenticate

        If diag.ShowDialog = Windows.Forms.DialogResult.OK And diag.TextBox1.Text = My.Settings.Pass Then
            auth = diag.TextBox1.Text
        End If

        diag.Dispose()

        If auth = My.Settings.Pass Then
            If clickedlbl.Text.Length <> 0 And clickedlbl.BackColor <> Color.GhostWhite And clickedlbl.BackColor <> Color.MintCream Then
                prompt = "D for DELETE or E for EDIT"
                s = InputBox(prompt, prompt)

                If s = "d" Or s = "D" Or s = "delete" Or s = "DELETE" Then
                    If clickedlbl.BackColor = Color.White Or clickedlbl.BackColor = Color.Yellow Or clickedlbl.BackColor = Color.Red Or clickedlbl.BackColor = Color.Green Or clickedlbl.BackColor = Color.Aqua Or clickedlbl.BackColor = Color.Violet Or clickedlbl.BackColor = Color.Gold Or clickedlbl.BackColor = Color.Purple Then

                        clickedlbl.Text = clickedlbl.TabIndex + 1 & " )  " & String.Format("{0,-55}", "--DELETED--") & "  " & TimeOfDay

                        lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
                        If clickedlbl.BackColor = Color.Yellow Then

                            sent -= lblval(clickedlbl.TabIndex + 1, 0)
                            sentc -= 1
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)
                            If chk(clickedlbl.TabIndex + 1) = True Then
                                LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee
                            ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                                usd += lblval(clickedlbl.TabIndex + 1, 0)
                            End If


                            clickedlbl.BackColor = Color.MintCream
                        ElseIf clickedlbl.BackColor = Color.Gold Then
                            omtt -= lblval(clickedlbl.TabIndex + 1, 0)
                            omtc -= 1
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)
                            If chk(clickedlbl.TabIndex + 1) = True Then
                                LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee
                            ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                                usd += lblval(clickedlbl.TabIndex + 1, 0)
                            End If
                            clickedlbl.BackColor = Color.MintCream

                        ElseIf clickedlbl.BackColor = Color.Aqua Then

                            mt -= lblval(clickedlbl.TabIndex + 1, 0)
                            mtco -= 1
                            LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)


                            clickedlbl.BackColor = Color.MintCream
                        ElseIf clickedlbl.BackColor = Color.Red Then


                            alf -= lblval(clickedlbl.TabIndex + 1, 0)
                            alfac -= 1
                            LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)

                            clickedlbl.BackColor = Color.MintCream
                        ElseIf clickedlbl.BackColor = Color.Green Then


                            og -= lblval(clickedlbl.TabIndex + 1, 0)
                            ogc -= 1
                            LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)


                            clickedlbl.BackColor = Color.MintCream
                        ElseIf clickedlbl.BackColor = Color.Purple Then
                            InternetSales -= lblval(clickedlbl.TabIndex + 1, 0)
                            InternetSalesCount -= 1
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)
                            AdjustInternetAfterDelete(lblval(clickedlbl.TabIndex + 1, 1))
                            clickedlbl.BackColor = Color.MintCream
                        ElseIf clickedlbl.BackColor = Color.White Then
                            clickedlbl.BackColor = Color.MintCream
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)



                            If chk(clickedlbl.TabIndex + 1) = True Then
                                LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee

                            ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                                usd += lblval(clickedlbl.TabIndex + 1, 0)
                            ElseIf chkp(clickedlbl.TabIndex + 1) = True Then
                                profit -= profitt(clickedlbl.TabIndex + 1)
                            End If
                        ElseIf clickedlbl.BackColor = Color.Violet Then
                            clickedlbl.BackColor = Color.MintCream
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)

                        End If
                        lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
                        clickedlbl.BackColor = Color.MintCream
                        updlist()
                        FlowLayoutPanel1.ScrollControlIntoView(lbl)

                    Else
                        clickedlbl.Text = clickedlbl.TabIndex + 1 & " )  " & String.Format("{0,-55}", "--DELETED--") & "  " & TimeOfDay


                        lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
                        If clickedlbl.BackColor = Color.Orange Then
                            clickedlbl.BackColor = Color.MintCream

                            sum += lblval(clickedlbl.TabIndex + 1, 0)
                            paid -= lblval(clickedlbl.TabIndex + 1, 0)
                            paidc -= 1
                            If chk(clickedlbl.TabIndex + 1) = True Then
                                LBP -= lblval(clickedlbl.TabIndex + 1, 0) * ratee
                            ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                                usd -= lblval(clickedlbl.TabIndex + 1, 0)
                            End If
                        ElseIf clickedlbl.BackColor = Color.Silver Then
                            clickedlbl.BackColor = Color.MintCream

                            sum = sum + lblval(clickedlbl.TabIndex + 1, 0)
                            If chk(clickedlbl.TabIndex + 1) = True Then
                                LBP -= lblval(clickedlbl.TabIndex + 1, 0) * ratee
                            ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                                usd -= lblval(clickedlbl.TabIndex + 1, 0)
                            End If

                        ElseIf clickedlbl.BackColor = Color.Pink Then
                            If lblval(clickedlbl.TabIndex + 1, 0) < 0 Then
                                sum = sum + lblval(clickedlbl.TabIndex + 1, 0)
                                If currency.d(clickedlbl.TabIndex + 1) = 1 Then
                                    My.Settings.eur += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 2 Then
                                    My.Settings.cad += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 3 Then
                                    My.Settings.gbp += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 4 Then
                                    My.Settings.jpy += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 5 Then
                                    My.Settings.sar += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 6 Then
                                    My.Settings.aud += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 7 Then
                                    My.Settings.aed += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 8 Then
                                    My.Settings.sek += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 9 Then
                                    My.Settings.qar += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 10 Then
                                    My.Settings.kwd += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 11 Then
                                    My.Settings.bhd += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 12 Then
                                    My.Settings.omr += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 13 Then
                                    My.Settings.jod += currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 14 Then
                                    My.Settings.chf += currency.a(clickedlbl.TabIndex + 1)

                                End If
                            Else
                                sum = sum + lblval(clickedlbl.TabIndex + 1, 0)
                                If currency.d(clickedlbl.TabIndex + 1) = 1 Then
                                    My.Settings.eur -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 2 Then
                                    My.Settings.cad -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 3 Then
                                    My.Settings.gbp -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 4 Then
                                    My.Settings.jpy -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 5 Then
                                    My.Settings.sar -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 6 Then
                                    My.Settings.aud -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 7 Then
                                    My.Settings.aed -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 8 Then
                                    My.Settings.sek -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 9 Then
                                    My.Settings.qar -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 10 Then
                                    My.Settings.kwd -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 11 Then
                                    My.Settings.bhd -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 12 Then
                                    My.Settings.omr -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 13 Then
                                    My.Settings.jod -= currency.a(clickedlbl.TabIndex + 1)
                                ElseIf currency.d(clickedlbl.TabIndex + 1) = 14 Then
                                    My.Settings.chf -= currency.a(clickedlbl.TabIndex + 1)

                                End If

                            End If


                        End If
                        lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
                        clickedlbl.BackColor = Color.MintCream
                        updlist()
                        My.Settings.Save()
                        FlowLayoutPanel1.ScrollControlIntoView(lbl)
                    End If

                ElseIf s = "e" Or s = "E" Or s = "edit" Or s = "EDIT" Then

                    If clickedlbl.BackColor = Color.Yellow Then

                        textbox.Label3.Text = "MTCN"
                        textbox.Label3.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
                        textbox.TextBox1.Location = New Point(114, 179)
                        textbox.Label3.Visible = True
                        textbox.TextBox1.Visible = True
                        textbox.CheckBox1.Visible = True
                        textbox.CheckBox2.Visible = True
                        textbox.CheckBox4.Visible = False
                        textbox.CheckBox4.Checked = False
                        textbox.CheckBox3.Visible = False
                        textbox.Label4.Visible = False
                        textbox.Label2.Text = ""
                        If chk(clickedlbl.TabIndex + 1) = True Then
                            textbox.CheckBox1.Checked = True
                            textbox.CheckBox2.Checked = False
                        ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                            textbox.CheckBox2.Checked = True
                            textbox.CheckBox1.Checked = False
                        End If
                        textbox.clicked = False
                        textbox.ShowDialog()
                        textbox.input.Focus()
                        If textbox.clicked = True Then
                            Exit Sub
                        ElseIf ((textbox.valu = 0) Or (textbox.valu.ToString = "") Or (textbox.numb.Length = 0) Or (textbox.numb.Length > 12)) Then
                            MsgBox("invalid data")
                            Exit Sub
                        ElseIf textbox.CheckBox1.Checked = False And textbox.CheckBox2.Checked = False Then
                            MsgBox("please choose balance")
                            Exit Sub
                        Else

                            sent -= lblval(clickedlbl.TabIndex + 1, 0)
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)
                            If chk(clickedlbl.TabIndex + 1) = True Then
                                LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee

                            ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                                usd += lblval(clickedlbl.TabIndex + 1, 0)

                            End If
                            If textbox.CheckBox1.Checked = True Then
                                Dim a As Decimal = textbox.valu

                                clickedlbl.Text = clickedlbl.TabIndex + 1 & " )  " & String.Format("{0,-20}{1,-20}{2,-15}", Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero) & " $", a.ToString & " L.L", "(" & textbox.numb & ")") & "  " & TimeOfDay
                                LBP -= a
                                chk(clickedlbl.TabIndex + 1) = True
                                chkus(clickedlbl.TabIndex + 1) = False
                                sum = sum + textbox.valu / ratee
                                lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu / ratee
                                sent += Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero)
                            ElseIf textbox.CheckBox2.Checked = True Then
                                clickedlbl.Text = clickedlbl.TabIndex + 1 & " )  " & String.Format("{0,-40}{1,-15}", textbox.valu & " $", "(" & textbox.numb & ")") & "  " & TimeOfDay
                                usd -= textbox.valu
                                chkus(clickedlbl.TabIndex + 1) = True
                                chk(clickedlbl.TabIndex + 1) = False
                                sum = sum + textbox.valu
                                lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu
                                sent += textbox.valu
                            End If


                            clickedlbl.BackColor = Color.Yellow

                            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"

                            updlist()
                            FlowLayoutPanel1.ScrollControlIntoView(lbl)
                        End If
                    ElseIf clickedlbl.BackColor = Color.Orange Then

                        textbox.Label3.Text = "MTCN"
                        textbox.Label3.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
                        textbox.TextBox1.Location = New Point(114, 179)
                        textbox.Label3.Visible = True
                        textbox.CheckBox1.Visible = True
                        textbox.Label2.Text = ""
                        textbox.CheckBox2.Visible = True
                        textbox.CheckBox4.Visible = False
                        textbox.CheckBox4.Checked = False
                        textbox.CheckBox3.Visible = False
                        textbox.Label4.Visible = False
                        If chk(clickedlbl.TabIndex + 1) = True Then
                            textbox.CheckBox1.Checked = True
                            textbox.CheckBox2.Checked = False
                        ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                            textbox.CheckBox2.Checked = True
                            textbox.CheckBox1.Checked = False
                        End If
                        textbox.TextBox1.Visible = True
                        textbox.clicked = False
                        textbox.ShowDialog()

                        If textbox.clicked = True Then
                            Exit Sub
                        ElseIf ((textbox.valu = 0) Or (textbox.valu.ToString = "") Or (textbox.numb.Length = 0) Or (textbox.numb.Length > 12)) Then
                            MsgBox("invalid data")
                            Exit Sub
                        ElseIf textbox.CheckBox1.Checked = False And textbox.CheckBox2.Checked = False Then
                            MsgBox("please choose balance")
                            Exit Sub
                        Else

                            paid -= lblval(clickedlbl.TabIndex + 1, 0)
                            sum = sum + lblval(clickedlbl.TabIndex + 1, 0)
                            If chk(clickedlbl.TabIndex + 1) = True Then
                                LBP -= lblval(clickedlbl.TabIndex + 1, 0) * ratee

                            ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                                usd -= lblval(clickedlbl.TabIndex + 1, 0)

                            End If

                            If textbox.CheckBox1.Checked = True Then
                                Dim a As Decimal = textbox.valu

                                clickedlbl.Text = clickedlbl.TabIndex + 1 & " ) --" & String.Format("{0,-20}{1,-20}{2,-15}", Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero) & " $", a.ToString & " L.L", "(" & textbox.numb & ")") & "  " & TimeOfDay
                                LBP += a
                                chk(clickedlbl.TabIndex + 1) = True
                                chkus(clickedlbl.TabIndex + 1) = False
                                sum = sum - textbox.valu / ratee
                                paid += Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero)
                                lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu / ratee
                            ElseIf textbox.CheckBox2.Checked = True Then
                                clickedlbl.Text = clickedlbl.TabIndex + 1 & " ) --" & String.Format("{0,-40}{1,-15}", textbox.valu & " $", "(" & textbox.numb & ")") & "  " & TimeOfDay
                                chkus(clickedlbl.TabIndex + 1) = True
                                chk(clickedlbl.TabIndex + 1) = False
                                usd += textbox.valu
                                sum = sum - textbox.valu
                                paid += textbox.valu
                                lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu
                            End If

                            clickedlbl.BackColor = Color.Orange

                            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"

                            updlist()
                            FlowLayoutPanel1.ScrollControlIntoView(lbl)
                        End If
                    ElseIf clickedlbl.BackColor = Color.White Then

                        textbox.Label3.Text = "deposit reason"
                        textbox.Label3.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                        textbox.TextBox1.Location = New Point(120, 173)
                        textbox.Label3.Visible = True
                        textbox.CheckBox1.Visible = False
                        textbox.CheckBox2.Visible = False
                        textbox.TextBox1.Visible = True
                        textbox.CheckBox4.Visible = True
                        textbox.CheckBox3.Visible = True
                        textbox.Label4.Visible = True
                        textbox.Label2.Text = "$"
                        If chk(clickedlbl.TabIndex + 1) = True Then
                            textbox.CheckBox1.Checked = True
                            textbox.CheckBox2.Checked = False
                        ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                            textbox.CheckBox2.Checked = True
                            textbox.CheckBox1.Checked = False
                        ElseIf chkp(clickedlbl.TabIndex + 1) = True Then
                            textbox.CheckBox4.Checked = True
                            textbox.CheckBox1.Visible = False
                            textbox.CheckBox2.Visible = False
                            textbox.CheckBox1.Checked = False
                            textbox.CheckBox2.Checked = False
                            textbox.Label5.Visible = True
                            textbox.TextBox2.Visible = True
                            textbox.TextBox2.Text = profitt(clickedlbl.TabIndex + 1).ToString
                        ElseIf chk(clickedlbl.TabIndex + 1) = False And chkus(clickedlbl.TabIndex + 1) = False And chkp(clickedlbl.TabIndex + 1) = False Then
                            textbox.CheckBox1.Checked = False
                            textbox.CheckBox2.Checked = False

                            textbox.CheckBox4.Checked = False
                        End If
                        textbox.clicked = False
                        textbox.ShowDialog()

                        If textbox.clicked = True Then
                            Exit Sub
                        ElseIf ((textbox.valu = 0) Or (textbox.valu.ToString = "")) Then
                            MsgBox("invalid data")
                            Exit Sub
                        ElseIf textbox.numb.Length = 0 Then
                            textbox.numb = "Cash"
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)



                            If chk(clickedlbl.TabIndex + 1) = True Then
                                LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee

                            ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                                usd += lblval(clickedlbl.TabIndex + 1, 0)
                            ElseIf chkp(clickedlbl.TabIndex + 1) = True Then
                                profit -= profitt(clickedlbl.TabIndex + 1)

                            End If



                            clickedlbl.Text = clickedlbl.TabIndex + 1 & " )  " & String.Format("{0,-40}{1,-15}", textbox.valu & " $", textbox.numb) & "  " & TimeOfDay
                            clickedlbl.BackColor = Color.White
                            sum = sum + textbox.valu
                            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
                            edited(clickedlbl.TabIndex) = True
                            lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu
                            If textbox.CheckBox1.Checked = True Then
                                clickedlbl.Text = clickedlbl.TabIndex + 1 & " )  " & String.Format("{0,-20}{1,-20}{2,-15}", textbox.valu & " $", textbox.valu * ratee & " L.L", textbox.numb) & "  " & TimeOfDay

                                LBP -= textbox.valu * ratee
                                chk(clickedlbl.TabIndex + 1) = True
                                chkus(clickedlbl.TabIndex + 1) = False
                            ElseIf textbox.CheckBox2.Checked = True Then

                                usd -= textbox.valu
                                chkus(clickedlbl.TabIndex + 1) = True
                                chk(clickedlbl.TabIndex + 1) = False
                            ElseIf textbox.CheckBox4.Checked = True Then
                                Try
                                    profit += Convert.ToDecimal(textbox.TextBox2.Text)
                                    profitt(clickedlbl.TabIndex + 1) = Convert.ToDecimal(textbox.TextBox2.Text)
                                Catch ex As Exception

                                End Try
                                clickedlbl.Text = clickedlbl.TabIndex + 1 & " )   " & String.Format("{0,-20}{1,-20}{2,-15}", textbox.valu & " $", "Profit: " & textbox.TextBox2.Text.ToString & " $ ", textbox.numb) & "  " & TimeOfDay
                                chkp(clickedlbl.TabIndex + 1) = True
                                chk(clickedlbl.TabIndex + 1) = False
                                chkus(clickedlbl.TabIndex + 1) = False
                            End If
                            updlist()
                            FlowLayoutPanel1.ScrollControlIntoView(lbl)
                        Else


                            If chk(clickedlbl.TabIndex + 1) = True Then
                                LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee

                            ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                                usd += lblval(clickedlbl.TabIndex + 1, 0)
                            ElseIf chkp(clickedlbl.TabIndex + 1) Then
                                profit -= profitt(clickedlbl.TabIndex + 1)
                            End If


                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)
                            clickedlbl.Text = clickedlbl.TabIndex + 1 & " )  " & String.Format("{0,-40}{1,-15}", textbox.valu & " $", textbox.numb) & "  " & TimeOfDay
                            clickedlbl.BackColor = Color.White
                            sum = sum + textbox.valu
                            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
                            edited(clickedlbl.TabIndex) = True
                            lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu
                            If textbox.CheckBox1.Checked = True Then
                                clickedlbl.Text = clickedlbl.TabIndex + 1 & " )  " & String.Format("{0,-20}{1,-20}{2,-15}", textbox.valu & " $", Decimal.Round(textbox.valu * ratee, 0, MidpointRounding.AwayFromZero) & " L.L", textbox.numb) & "  " & TimeOfDay

                                LBP -= textbox.valu * ratee
                                chk(clickedlbl.TabIndex + 1) = True
                                chkus(clickedlbl.TabIndex + 1) = False
                            ElseIf textbox.CheckBox2.Checked = True Then

                                usd -= textbox.valu
                                chkus(clickedlbl.TabIndex + 1) = True
                                chk(clickedlbl.TabIndex + 1) = False
                            ElseIf textbox.CheckBox4.Checked = True Then
                                Try
                                    profit += Convert.ToDecimal(textbox.TextBox2.Text)
                                    profitt(clickedlbl.TabIndex + 1) = Convert.ToDecimal(textbox.TextBox2.Text)
                                Catch ex As Exception

                                End Try
                                clickedlbl.Text = clickedlbl.TabIndex + 1 & " )   " & String.Format("{0,-20}{1,-20}{2,-15}", textbox.valu & " $", "Profit: " & textbox.TextBox2.Text.ToString & " $ ", textbox.numb) & "  " & TimeOfDay
                                chkp(clickedlbl.TabIndex + 1) = True
                                chk(clickedlbl.TabIndex + 1) = False
                                chkus(clickedlbl.TabIndex + 1) = False
                            End If
                            updlist()
                            FlowLayoutPanel1.ScrollControlIntoView(lbl)
                        End If
                    ElseIf clickedlbl.BackColor = Color.Silver Then

                        textbox.Label3.Text = "withdraw reason"
                        textbox.Label3.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                        textbox.TextBox1.Location = New Point(120, 120)
                        textbox.Label3.Visible = True
                        textbox.CheckBox1.Visible = False
                        textbox.CheckBox2.Visible = False
                        textbox.CheckBox4.Visible = False
                        textbox.CheckBox4.Checked = False
                        textbox.CheckBox3.Visible = True
                        textbox.Label4.Visible = True
                        textbox.Label2.Text = "$"
                        If chk(clickedlbl.TabIndex + 1) = True Then
                            textbox.CheckBox1.Checked = True
                            textbox.CheckBox2.Checked = False
                        ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                            textbox.CheckBox2.Checked = True
                            textbox.CheckBox1.Checked = False
                        ElseIf chk(clickedlbl.TabIndex + 1) = False And chkus(clickedlbl.TabIndex + 1) = False Then
                            textbox.CheckBox1.Checked = False
                            textbox.CheckBox2.Checked = False

                            textbox.CheckBox4.Checked = False
                        End If
                        textbox.TextBox1.Visible = True
                        textbox.clicked = False
                        textbox.ShowDialog()

                        If textbox.clicked = True Then
                            Exit Sub
                        ElseIf ((textbox.valu = 0) Or (textbox.valu.ToString = "")) Then
                            MsgBox("invalid data")
                            Exit Sub
                        ElseIf textbox.numb.Length = 0 Then
                            textbox.numb = "Cash"


                            sum = sum + lblval(clickedlbl.TabIndex + 1, 0)
                            If chk(clickedlbl.TabIndex + 1) = True Then
                                LBP -= lblval(clickedlbl.TabIndex + 1, 0) * ratee

                            ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                                usd -= lblval(clickedlbl.TabIndex + 1, 0)

                            End If

                            clickedlbl.Text = clickedlbl.TabIndex + 1 & " ) --" & String.Format("{0,-40}{1,-15}", textbox.valu & " $", textbox.numb) & "  " & TimeOfDay
                            clickedlbl.BackColor = Color.Silver
                            sum = sum - textbox.valu
                            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"

                            lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu
                            If textbox.CheckBox1.Checked = True Then
                                clickedlbl.Text = clickedlbl.TabIndex + 1 & " ) --" & String.Format("{0,-20}{1,-20}{2,-15}", textbox.valu & " $", Decimal.Round(textbox.valu * ratee, 0, MidpointRounding.AwayFromZero) & " L.L", textbox.numb) & "  " & TimeOfDay

                                LBP += textbox.valu * ratee
                                chk(clickedlbl.TabIndex + 1) = True
                                chkus(clickedlbl.TabIndex + 1) = False
                            ElseIf textbox.CheckBox2.Checked = True Then

                                usd += textbox.valu
                                chkus(clickedlbl.TabIndex + 1) = True
                                chk(clickedlbl.TabIndex + 1) = False
                            End If
                            updlist()
                            FlowLayoutPanel1.ScrollControlIntoView(lbl)
                        Else


                            sum = sum + lblval(clickedlbl.TabIndex + 1, 0)
                            If chk(clickedlbl.TabIndex + 1) = True Then
                                LBP -= lblval(clickedlbl.TabIndex + 1, 0) * ratee

                            ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                                usd -= lblval(clickedlbl.TabIndex + 1, 0)

                            End If




                            clickedlbl.Text = clickedlbl.TabIndex + 1 & " ) --" & String.Format("{0,-40}{1,-15}", textbox.valu & " $", textbox.numb) & "  " & TimeOfDay
                            clickedlbl.BackColor = Color.Silver
                            sum = sum - textbox.valu
                            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"

                            lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu
                            If textbox.CheckBox1.Checked = True Then
                                clickedlbl.Text = clickedlbl.TabIndex + 1 & " ) --" & String.Format("{0,-20}{1,-20}{2,-15}", textbox.valu & " $", textbox.valu * ratee & " L.L", textbox.numb) & "  " & TimeOfDay

                                LBP += textbox.valu * ratee
                                chk(clickedlbl.TabIndex + 1) = True
                                chkus(clickedlbl.TabIndex + 1) = False
                            ElseIf textbox.CheckBox2.Checked = True Then

                                usd += textbox.valu
                                chkus(clickedlbl.TabIndex + 1) = True
                                chk(clickedlbl.TabIndex + 1) = False
                            End If
                            updlist()
                            FlowLayoutPanel1.ScrollControlIntoView(lbl)
                        End If
                    ElseIf clickedlbl.BackColor = Color.Aqua Then
                        textbox.Label3.Visible = False
                        textbox.TextBox1.Visible = False
                        textbox.CheckBox2.Visible = False
                        textbox.CheckBox2.Checked = False
                        textbox.CheckBox1.Checked = True
                        textbox.CheckBox4.Visible = False
                        textbox.CheckBox4.Checked = False
                        textbox.CheckBox3.Visible = False
                        textbox.Label4.Visible = False
                        textbox.Label2.Text = "L.L"
                        textbox.clicked = False
                        textbox.ShowDialog()

                        If textbox.clicked = True Or clickedlbl.BackColor = Color.GhostWhite Then
                            Exit Sub
                        ElseIf ((textbox.valu = 0)) Then
                            MsgBox("invalid data")
                            Exit Sub

                        Else
                            textbox.numb = "MTC"
                            mt -= lblval(clickedlbl.TabIndex + 1, 0)
                            LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)


                            clickedlbl.Text = clickedlbl.TabIndex + 1 & " ) " & String.Format("{0,-40}{1,-15}", Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero) & " $", textbox.numb) & "  " & TimeOfDay
                            clickedlbl.BackColor = Color.Aqua
                            sum = sum + textbox.valu / ratee
                            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
                            mt += Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero)
                            LBP -= textbox.valu
                            chk(clickedlbl.TabIndex + 1) = True
                            chkus(clickedlbl.TabIndex + 1) = False
                            lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu / ratee
                            updlist()
                            FlowLayoutPanel1.ScrollControlIntoView(lbl)
                        End If
                    ElseIf clickedlbl.BackColor = Color.Green Then

                        textbox.Label3.Visible = False
                        textbox.TextBox1.Visible = False
                        textbox.CheckBox2.Visible = False
                        textbox.CheckBox2.Checked = False
                        textbox.CheckBox1.Checked = True
                        textbox.CheckBox4.Visible = False
                        textbox.CheckBox4.Checked = False
                        textbox.CheckBox3.Visible = False
                        textbox.Label4.Visible = False
                        textbox.Label2.Text = "L.L"
                        textbox.clicked = False
                        textbox.ShowDialog()

                        If textbox.clicked = True Or clickedlbl.BackColor = Color.GhostWhite Then
                            Exit Sub
                        ElseIf ((textbox.valu = 0)) Then
                            MsgBox("invalid data")
                            Exit Sub

                        Else
                            textbox.numb = "OGERO"
                            og -= lblval(clickedlbl.TabIndex + 1, 0)
                            LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)


                            clickedlbl.Text = clickedlbl.TabIndex + 1 & " ) " & String.Format("{0,-40}{1,-15}", Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero) & " $", textbox.numb) & "  " & TimeOfDay
                            clickedlbl.BackColor = Color.Green
                            sum = sum + textbox.valu / ratee
                            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
                            og += Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero)
                            LBP -= textbox.valu
                            chk(clickedlbl.TabIndex + 1) = True
                            chkus(clickedlbl.TabIndex + 1) = False
                            lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu / ratee
                            updlist()
                            FlowLayoutPanel1.ScrollControlIntoView(lbl)
                        End If
                    ElseIf clickedlbl.BackColor = Color.Red Then

                        textbox.Label3.Visible = False
                        textbox.TextBox1.Visible = False
                        textbox.CheckBox2.Visible = False
                        textbox.CheckBox2.Checked = False
                        textbox.CheckBox1.Checked = True
                        textbox.CheckBox4.Visible = False
                        textbox.CheckBox4.Checked = False
                        textbox.CheckBox3.Visible = False
                        textbox.Label4.Visible = False
                        textbox.Label2.Text = "L.L"
                        textbox.clicked = False
                        textbox.ShowDialog()

                        If textbox.clicked = True Or clickedlbl.BackColor = Color.GhostWhite Then
                            Exit Sub
                        ElseIf ((textbox.valu = 0)) Then
                            MsgBox("invalid data")
                            Exit Sub

                        Else
                            textbox.numb = "ALFA"
                            alf -= lblval(clickedlbl.TabIndex + 1, 0)
                            LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee
                            sum = sum - lblval(clickedlbl.TabIndex + 1, 0)


                            clickedlbl.Text = clickedlbl.TabIndex + 1 & " ) " & String.Format("{0,-40}{1,-15}", Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero) & " $", textbox.numb) & "  " & TimeOfDay
                            clickedlbl.BackColor = Color.Red
                            sum = sum + textbox.valu / ratee
                            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
                            alf += Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero)
                            LBP -= textbox.valu
                            chk(clickedlbl.TabIndex + 1) = True
                            chkus(clickedlbl.TabIndex + 1) = False
                            lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu / ratee
                            updlist()
                            FlowLayoutPanel1.ScrollControlIntoView(lbl)
                        End If
                    End If
                ElseIf clickedlbl.BackColor = Color.Gold Then
                    textbox.Label3.Text = "Service"
                    textbox.Label3.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
                    textbox.TextBox1.Location = New Point(114, 179)
                    textbox.Label3.Visible = True
                    textbox.CheckBox1.Visible = True
                    textbox.CheckBox2.Visible = True
                    textbox.CheckBox1.Checked = False
                    textbox.CheckBox2.Checked = False
                    textbox.TextBox1.Visible = True
                    textbox.CheckBox4.Visible = False
                    textbox.CheckBox4.Checked = False
                    textbox.CheckBox3.Visible = False
                    textbox.Label4.Visible = False
                    textbox.Label2.Text = ""
                    If chk(clickedlbl.TabIndex + 1) = True Then
                        textbox.CheckBox1.Checked = True
                        textbox.CheckBox2.Checked = False
                    ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                        textbox.CheckBox2.Checked = True
                        textbox.CheckBox1.Checked = False
                    End If
                    textbox.clicked = False
                    textbox.ShowDialog()
                    textbox.input.Focus()
                    If textbox.clicked = True Then
                        Exit Sub
                    ElseIf ((textbox.valu = 0) Or (textbox.valu.ToString = "") Or (textbox.numb.Length = 0) Or (textbox.numb.Length > 12)) Then
                        MsgBox("invalid data")
                        Exit Sub
                    ElseIf textbox.CheckBox1.Checked = False And textbox.CheckBox2.Checked = False Then
                        MsgBox("please choose balance")
                        Exit Sub
                    Else

                        omtt -= lblval(clickedlbl.TabIndex + 1, 0)
                        sum = sum - lblval(clickedlbl.TabIndex + 1, 0)
                        If chk(clickedlbl.TabIndex + 1) = True Then
                            LBP += lblval(clickedlbl.TabIndex + 1, 0) * ratee

                        ElseIf chkus(clickedlbl.TabIndex + 1) = True Then
                            usd += lblval(clickedlbl.TabIndex + 1, 0)

                        End If
                        If textbox.CheckBox1.Checked = True Then
                            Dim a As Decimal = textbox.valu

                            clickedlbl.Text = clickedlbl.TabIndex + 1 & " )  " & String.Format("{0,-20}{1,-20}{2,-15}", Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero) & " $", a.ToString & " L.L", "(" & textbox.numb & ")") & "  " & TimeOfDay
                            LBP -= a
                            chk(clickedlbl.TabIndex + 1) = True
                            chkus(clickedlbl.TabIndex + 1) = False
                            sum = sum + textbox.valu / ratee
                            lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu / ratee
                            omtt += Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero)
                        ElseIf textbox.CheckBox2.Checked = True Then
                            clickedlbl.Text = clickedlbl.TabIndex + 1 & " )  " & String.Format("{0,-40}{1,-15}", textbox.valu & " $", "(" & textbox.numb & ")") & "  " & TimeOfDay
                            usd -= textbox.valu
                            chkus(clickedlbl.TabIndex + 1) = True
                            chk(clickedlbl.TabIndex + 1) = False
                            sum = sum + textbox.valu
                            lblval(clickedlbl.TabIndex + 1, 0) = textbox.valu
                            omtt += textbox.valu
                        End If


                        clickedlbl.BackColor = Color.Gold

                        lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"

                        updlist()
                        FlowLayoutPanel1.ScrollControlIntoView(lbl)
                    End If
                End If

            Else
                MsgBox("nothing selected")
                Exit Sub
            End If
                closingg()
            End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        sure.ShowDialog()
    End Sub
    Public Sub pd()
        For Each p As Label In Me.FlowLayoutPanel1.Controls
            Try
                If p.BackColor = Color.Pink Then
                    sum = sum + lblval(p.TabIndex + 1, 0)

                    p.Text = p.TabIndex + 1 & " )  " & String.Format("{0,-55}", "--DELETED--") & "  " & TimeOfDay
                    lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
                    p.BackColor = Color.MintCream
                    closingg()
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        count += 1
        If lbl.Text = "" Then
            lbl = labelarray(count - 1)
        Else
            lbl = labelarray(count - 1)

        End If
        omt()
    End Sub
    Private Sub omt()
        textbox.Label3.Text = "Service"
        textbox.Label3.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
        textbox.TextBox1.Location = New Point(114, 179)
        textbox.Label3.Visible = True
        textbox.CheckBox1.Visible = True
        textbox.CheckBox2.Visible = True
        textbox.CheckBox1.Checked = False
        textbox.CheckBox2.Checked = False
        textbox.TextBox1.Visible = True
        textbox.CheckBox4.Visible = False
        textbox.CheckBox4.Checked = False
        textbox.CheckBox3.Visible = False
        textbox.Label4.Visible = False
        textbox.Label2.Text = ""
        textbox.clicked = False
        textbox.ShowDialog()
        textbox.input.Focus()



        If textbox.clicked = True Then
            count -= 1
            Exit Sub
        ElseIf ((textbox.valu = 0) Or (textbox.valu.ToString = "") Or (textbox.numb.Length = 0) Or (textbox.numb.Length > 12)) Then
            MsgBox("invalid data")
            count -= 1
            Exit Sub
        ElseIf textbox.CheckBox1.Checked = False And textbox.CheckBox2.Checked = False Then
            MsgBox("please choose balance")
            omt()


        Else
            If textbox.CheckBox1.Checked = True Then
                Dim a As Decimal = textbox.valu


                lbl.Text = count & " )   " & String.Format("{0,-20}{1,-20}{2,-15}", Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero) & " $", a.ToString & " L.L", "(" & textbox.numb & ")") & "  " & TimeOfDay

                LBP -= a
                chk(count) = True
                chkus(count) = False
                lblval(count, 0) = textbox.valu / ratee
                omtt += Decimal.Round(textbox.valu / ratee, 2, MidpointRounding.AwayFromZero)
                sum = sum + textbox.valu / ratee
            ElseIf textbox.CheckBox2.Checked = True Then
                lbl.Text = count & " )   " & String.Format("{0,-40}{1,-15}", textbox.valu & " $", "(" & textbox.numb & ")") & "  " & TimeOfDay
                usd -= textbox.valu
                chkus(count) = True
                chk(count) = False
                lblval(count, 0) = textbox.valu
                omtt += textbox.valu
                sum = sum + textbox.valu
            End If



            lbl.BackColor = Color.Gold

            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"

            omtc += 1

            updlist()
            FlowLayoutPanel1.ScrollControlIntoView(lbl)
            closingg()
        End If
    End Sub
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        count += 1
        If lbl.Text = "" Then
            lbl = labelarray(count - 1)
        Else
            lbl = labelarray(count - 1)

        End If
        InternetAccount()
    End Sub
    Private Sub InternetAccount()
        Dim InternetSale As New InternetSales
        Dim DialogResult = InternetSale.ShowDialog()
        If DialogResult = Windows.Forms.DialogResult.Cancel Then
            count -= 1
            Exit Sub
        ElseIf DialogResult = Windows.Forms.DialogResult.OK Then
            Dim Val As Decimal = CDec(InternetSale.input.Text)
            Dim BundleCost As Decimal = Get_BundleCost(InternetSale.Bundles.SelectedItem.value)
            If BundleCost = 0 Then
                count -= 1
                MsgBox("Edit Bundle Cost")
                Exit Sub
            End If
            If InternetAcc - BundleCost < 0 Then
                count -= 1
                MsgBox("Not enought credits in internet account")
                Exit Sub
            Else
                If Not UpdateInternetAcc(BundleCost) Then
                    count -= 1
                    Exit Sub
                End If
            End If
            Dim Cus As String = InternetSale.TextBox1.Text
            Dim Bundle As String = InternetSale.Bundles.SelectedItem.key
            Bundle = Bundle.Substring(0, Bundle.LastIndexOf("-"))
            lbl.Text = count & " )   " & String.Format("{0,-40}{1,-15}", Val.ToString & " $", "(" & Cus & ")( " & Bundle & " )") & "  " & TimeOfDay
            lblval(count, 0) = Val
            lblval(count, 1) = BundleCost
            chkus(count) = False
            chk(count) = False
            sum += Val
            InternetSales += Val
            InternetSalesCount += 1
            lbl.BackColor = Color.Purple
            lbtotal.Text = Decimal.Round(sum, 2, MidpointRounding.AwayFromZero).ToString + " $"
            updlist()
            FlowLayoutPanel1.ScrollControlIntoView(lbl)
            closingg()
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        debits.Visible = True
    End Sub
    Public Sub debitplus()
        count += 1

        lbl = labelarray(count - 1)

        lbl.Text = count & " )   " & String.Format("{0,-40}{1,-15}", Decimal.Round(debitform.Label5.Text, 2, MidpointRounding.AwayFromZero) & " $", "From: " & debitform.Label4.Text) & "  " & TimeOfDay
        chk(count) = False
        chkus(count) = False
        updlist()
        FlowLayoutPanel1.ScrollControlIntoView(lbl)
        closingg()



    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        InventorySelection.ShowDialog()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim pas As String = String.Empty
        Try
            pas = InputBox("Enter current password", "Change password")
            If pas <> My.Settings.Pass Then
                MsgBox("Wrong password")
            Else
                My.Settings.Pass = InputBox("Enter new password", "Change password")
                MsgBox("Password changed")
            End If

        Catch ex As Exception
            MsgBox("Something went wrong")
        Finally

        End Try

    End Sub
    Private Sub Ntextbox()
        Dim txtbox As New textbox
    End Sub
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim diag = New Authenticate

        If diag.ShowDialog = Windows.Forms.DialogResult.OK And diag.TextBox1.Text = My.Settings.Pass Then
            InternetSettings.ShowDialog()
        Else
            MsgBox("Wrong Password")
        End If
    End Sub
End Class

