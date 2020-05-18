Imports System.Management
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.InteropServices


Public Class security
    Dim ac As Integer
    Dim year As String = "C:\Windows\y.txt"

    Private Sub security_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox1.Text = GetSerial().ToString
        If My.Settings.za7et = 10 Then
            My.Settings.trial = 2
        End If
        Dim trialpath As String = "C:\Windows\t.txt"
        If My.Settings.triald = 0 Then
            If File.Exists(trialpath) Then
                Button2.Visible = False
            End If

        End If
        If My.Settings.trial = 1 Then
            Button2.Text = "continue"
        ElseIf My.Settings.trial = 0 Then
            Button2.Text = "trial"
        ElseIf My.Settings.trial = 2 Or HandleRegistry() = False Then
            Button2.Visible = False

        End If
        If My.Settings.activated = 1 And File.Exists("C:\Windows\a.txt") Then

            If yearr() = False Then
                Form1.ShowDialog()
                Me.Visible = False
            Else
                MsgBox("your annual license has ended")
                My.Settings.index += 1
                My.Settings.activated = 0
                Button2.Visible = False
                TextBox1.Text = GetSerial().ToString
            End If

        End If
    End Sub
    Public Function GetSerial() As Long
        Dim mc As New ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim mac As String = ""

        Dim moc As ManagementObjectCollection = mc.GetInstances

        For Each mo As ManagementObject In moc
            If mo.Item("IPEnabled") Then
                mac = mo.Item("MacAddress").ToString
                Exit For
            End If
        Next

        mc.Dispose()

        
        Dim sum As Long = 0

        Dim index As Integer = My.Settings.index
        For Each ch As Char In mac
            If Char.IsDigit(ch) Then
                sum += sum + Integer.Parse(ch) * (index * 2)
            ElseIf Char.IsLetter(ch) Then
                Select Case ch.ToString.ToUpper
                    Case "A"
                        sum += sum + 10 * (index * 2)
                    Case "B"
                        sum += sum + 11 * (index * 2)
                    Case "C"
                        sum += sum + 12 * (index * 2)
                    Case "D"
                        sum += sum + 13 * (index * 2)
                    Case "E"
                        sum += sum + 14 * (index * 2)
                    Case "F"
                        sum += sum + 15 * (index * 2)
                End Select
            End If
            index += 1

        Next

        Return sum
    End Function
    Public Function CheckKey(ByVal key As Long) As Boolean
        Dim x As Long = TextBox1.Text
        Dim y As Long = x * x + 53 / x + 113 * (x / 4)
        Return y = key
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim key As Long


        Try
            key = Convert.ToInt64(TextBox2.Text)
            CheckKey(key)
            If CheckKey(key) = False Then
                ac = 0
                My.Settings.activated = 0
                MsgBox("wrong serial number,please contact 70/180466")
                Application.Exit()

            ElseIf CheckKey(key) = True Then
                ac = 1
                My.Settings.activated = 1
                MsgBox("your product is now activated")
                File.Create("C:\Windows\a.txt").Close()
                File.WriteAllText("C:\Windows\a.txt", "On")
                Button2.Visible = False
                Me.Visible = False
                If File.Exists(year) Then
                    File.WriteAllText(year, Now)
                Else
                    File.Create(year).Close()
                    File.WriteAllText(year, Now)
                End If


                Form1.Show()

            Else
                End
            End If
        Catch ex As Exception
        Finally

        End Try
        
       

    End Sub

    Private Sub security_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed   
        My.Settings.Save()
    End Sub
    Public Function HandleRegistry() As Boolean
        Dim firstRunDate As Date
        Dim trialpath As String = "C:\Windows\t.txt"
       
        Try
            Dim rd As String = File.ReadAllText(trialpath)
            firstRunDate = Date.Parse(rd)
            If rd = "" Then
                Return False

            End If
        Catch ex As Exception

        End Try


        If firstRunDate = Nothing Then
            firstRunDate = Now

        ElseIf (Now - firstRunDate).Days > 2 Then
            Return False
        End If
        Return True
    End Function

    
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim trialpath As String = "C:\Windows\t.txt"
        My.Settings.za7et += 1
        If Not File.Exists(trialpath) Then
            File.Create(trialpath).Close()

        End If

        If My.Settings.triald = 0 Then
            Try
                Dim s As New StreamWriter(trialpath)
                s.Write(Now)
                s.Close()
                MsgBox("trial activated ")
                Me.Visible = False
                Form1.Show()

                My.Settings.trial = 1
                My.Settings.triald = 1
                My.Settings.Save()


            Catch ex As Exception
                MsgBox("retry")
            End Try
           

        End If
       
        Dim result = HandleRegistry()


        If result = False Then
            MsgBox("trial has expired please activate your product")
            My.Settings.trial = 2
        ElseIf My.Settings.trial = 1 And result = True Then

            Me.Visible = False
            Form1.Show()
        End If

    End Sub
    Public Function yearr() As Boolean
        Dim a As String = File.ReadAllText(year)
        Dim b As Date = Date.Parse(a)
        If (Now - b).Days > 364 Then
            Return True
        Else : Return False
        End If
    End Function
   
End Class