Imports System.Globalization

Public Class textbox
    Public numb As String
    Public valu As Decimal
    Public clicked As Boolean

    Private Sub textbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        input.ResetText()
        TextBox1.ResetText()
        numb = ""
        clicked = False
        valu = 0
        numb = ""

        CheckBox3.Checked = False

        TextBox2.Visible = False
        Label5.Visible = False
        TextBox2.Text = "0"
        If CheckBox4.Checked = True Then
            Label3.Text = "Item name:"
            TextBox2.Visible = True
        End If

        Me.Show()
        Application.DoEvents()
        input.Focus()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        valu = Val(input.Text)
        numb = TextBox1.Text

        Me.Visible = False




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clicked = True
        Me.Close()
    End Sub

    Public Sub textbox_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        clicked = True

    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            TextBox2.Visible = True
            Label5.Visible = True
            CheckBox2.Visible = False
            CheckBox1.Visible = False
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            Label3.Text = "Item name:"
        Else
            TextBox2.Visible = False
            Label5.Visible = False
            CheckBox2.Visible = False
            CheckBox1.Visible = False
        End If


    End Sub



    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        Try
            If input.Text <> "" Then
                If CheckBox3.Checked = True Then
                    Dim a As Decimal = Convert.ToDecimal(input.Text / Form1.ratee)
                    a = Decimal.Round(a, 2, MidpointRounding.AwayFromZero)
                    input.Text = a.ToString
                Else
                    Dim a As Decimal = Convert.ToDecimal(input.Text * Form1.ratee)

                    input.Text = a.ToString
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        If Label2.Text = "" Or Label2.Text = "$" Then
            Label2.Text = "L.L"
        End If
        CheckBox1.Checked = True
        CheckBox2.Checked = False
        CheckBox1.BackColor = Color.Black
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click
        If Label2.Text = "" Or Label2.Text = "L.L" Then
            Label2.Text = "$"
            CheckBox1.Checked = False
            CheckBox2.Checked = True
        End If
    End Sub
End Class