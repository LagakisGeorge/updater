Imports System.IO
Imports System.Net
Imports System.Threading.Thread
Imports System.IO.Compression
Imports System.Net.WebClient
Public Class Form1
    Dim th1 As Threading.Thread
    Dim gPath As String = "c:\mercvb\updates"
    Dim gVerServ As String
    Dim gVerWork As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles download.Click

        If Directory.Exists(gPath + "\" + gVerWork) Then
        Else
            Directory.CreateDirectory(gPath + "\" + gVerWork)
        End If
        If File.Exists(gPath + "\m2.exe") Then
            File.Move(gPath + "\m2.exe", gPath + "\" + gVerWork + "\m2.exe")
        End If

        If File.Exists(gPath + "\updw.txt") Then
            File.Move(gPath + "\updw.txt", gPath + "\" + gVerWork + "\updw.txt")
        End If




        Timer1.Enabled = True

        ProgressBar1.Maximum = 14
        th1 = New Threading.Thread(AddressOf down)
        th1.Start()






    End Sub

    Sub down()

        Dim CLIENT As WebClient = New WebClient()
        CLIENT.Credentials = New NetworkCredential("mercury", "mercury12345678!!!")

        '  CLIENT.DownloadFile( ftp://62.103.69.140:50001/mercury/update.inf", gPath + "\upd.inf")


        CLIENT.DownloadFile(
          "ftp://62.103.69.140:50001/mercfcon.exe", gPath + "\m2.exe")
        MsgBox("ολοκληρώθηκε")
        th1.Abort()
        ProgressBar1.Value = ProgressBar1.Maximum


    End Sub




    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If File.Exists(gPath + "\m2.exe") Then

            Dim myFile As New FileInfo(gPath + "\m2.exe")
            Dim sizeInBytes As Long = myFile.Length
            Me.Text = Format(sizeInBytes / 1000000, "##0.00")
            ProgressBar1.Value = sizeInBytes / 1000000


        End If

    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 0
        Try
            File.Delete(gPath + "\upd.txt")
        Catch ex As Exception

        End Try


        Try

            Dim CLIENT As WebClient = New WebClient()
            CLIENT.Credentials = New NetworkCredential("mercury", "mercury12345678!!!")

            CLIENT.DownloadFile(
    "ftp://62.103.69.140:50001/mercury/update.inf", gPath + "\upd.txt")


            '   .CLIENT.DownloadFile(
            ' "ftp://62.103.69.140:50001/mercfcon.exe", gPath + "\m2.exe")
            ' MsgBox("ολοκληρώθηκε")
            '   th1.Abort()
            ' ProgressBar1.Value = ProgressBar1.Maximum

        Catch ex As Exception

        End Try



        If File.Exists(gPath + "/upd.txt") Then
            FileOpen(1, gPath + "/upd.txt", OpenMode.Input)
            gVerServ = LineInput(1)

            FileClose(1)
        Else
            mes.Text = "Δεν εγινε σύνδεση με Κεντρικό"
            Exit Sub

        End If


        If File.Exists(gPath + "/updw.txt") Then
            FileOpen(1, gPath + "/updw.txt", OpenMode.Input)
            gVerWork = LineInput(1)

            FileClose(1)
            If gVerServ > gVerWork Then
                mes.Text = "υπαρχει νέα έκδοση " + gVerServ

            Else
                mes.Text = "Εχετε την τελευταία έκδοση"
            End If




        Else
            mes.Text = "νεα έκοδοση "


        End If




    End Sub
End Class
