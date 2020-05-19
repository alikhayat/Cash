Public Class check
    Public res As Decimal
    Public valu(13) As Integer

    Private Sub check_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.depo = False Then
            Button1.Visible = False
            Button3.Visible = True

        End If
        loads()
        TextBox1.Focus()
        checkk()
        chk()
    End Sub

    
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged, TextBox8.TextChanged, TextBox7.TextChanged, TextBox6.TextChanged, TextBox5.TextChanged, TextBox4.TextChanged, TextBox3.TextChanged, TextBox2.TextChanged, TextBox14.TextChanged, TextBox13.TextChanged, TextBox12.TextChanged, TextBox11.TextChanged, TextBox10.TextChanged, TextBox1.TextChanged
        checkk()


    End Sub
    Private Sub checkk()
        Dim rate As Decimal = Form1.ratee
        Dim onhand As Decimal = Val(-Form1.sum), hund As Decimal = Val(TextBox1.Text) * 100, fif As Decimal = Val(TextBox2.Text) * 50, twen As Decimal = Val(TextBox3.Text) * 20, ten As Decimal = Val(TextBox4.Text) * 10, five As Decimal = Val(TextBox5.Text) * 5, one As Decimal = Val(TextBox6.Text) * 1, us As Decimal = Val(TextBox7.Text) * 1
        Dim lhun As Decimal = Val(TextBox8.Text) * 100000 / rate
        Dim lfif As Decimal = Val(TextBox9.Text) * 50000 / rate
        Dim ltwen As Decimal = Val(TextBox10.Text) * 20000 / rate
        Dim lten As Decimal = Val(TextBox11.Text) * 10000 / rate
        Dim lfiv As Decimal = Val(TextBox12.Text) * 5000 / rate
        Dim lone As Decimal = Val(TextBox13.Text) * 1000 / rate
        Dim lb As Decimal = Val(TextBox14.Text) * 1000 / rate

        res = onhand + hund + fif + twen + ten + five + one + us + lhun + lfif + ltwen + lten + lfiv + lone + lb

        If res < 0 Then
            summ.Text = "MISSING " & Space(2) & Decimal.Round(res.ToString, 2, MidpointRounding.AwayFromZero)
        ElseIf res > 0 Then
            summ.Text = "EXTRA " & Space(2) & Decimal.Round(res.ToString, 2, MidpointRounding.AwayFromZero)
        ElseIf res = 0 Then
            summ.Text = "GOOD"
        End If
    End Sub
   

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.good()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.deposit()
        My.Settings.depo = True
        Me.Visible = False
    End Sub
    Private Sub chk()
        If Form1.count = 0 Then
            Button3.Visible = True
            Button1.Visible = False
        Else
            Button3.Visible = False
            Button1.Visible = True
        End If
    End Sub
    Public Sub save()
        Try
            My.Settings.hun = TextBox1.Text
            My.Settings.fif = TextBox2.Text
            My.Settings.twen = TextBox3.Text
            My.Settings.ten = TextBox4.Text
            My.Settings.fiv = TextBox5.Text
            My.Settings.one = TextBox6.Text
            My.Settings.ch = TextBox7.Text
            My.Settings.lhun = TextBox8.Text
            My.Settings.lfif = TextBox9.Text
            My.Settings.ltwen = TextBox10.Text
            My.Settings.lten = TextBox11.Text
            My.Settings.lfiv = TextBox12.Text
            My.Settings.lone = TextBox13.Text
            My.Settings.lch = TextBox14.Text
        Catch ex As Exception

        End Try
       
    End Sub
   
    

    Private Sub check_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        save()
    End Sub
    Public Sub loads()
        Try
            TextBox1.Text = My.Settings.hun
            TextBox2.Text = My.Settings.fif
            TextBox3.Text = My.Settings.twen
            TextBox4.Text = My.Settings.ten
            TextBox5.Text = My.Settings.fiv
            TextBox6.Text = My.Settings.one
            TextBox7.Text = My.Settings.ch
            TextBox8.Text = My.Settings.lhun
            TextBox9.Text = My.Settings.lfif
            TextBox10.Text = My.Settings.ltwen
            TextBox11.Text = My.Settings.lten
            TextBox12.Text = My.Settings.lfiv
            TextBox13.Text = My.Settings.lone
            TextBox14.Text = My.Settings.lch
        Catch ex As Exception

        End Try
    End Sub
End Class