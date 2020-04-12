Imports System.IO
Imports System.Net
Imports System.Threading.Thread

Imports System.IO.Compression



'Imports System.Net.WebClient
Public Class Form1
    Dim th1 As Threading.Thread
    Dim gPath As String = "c:\mercvb\updates"
    Dim gVerServ As String = ""
    Dim gVerWork As String = ""






    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles download.Click


        'δημιουργει τον καταλογο της παλιάς εκδοσης και κανει copy to updw.txt & mercury.exe
        If Directory.Exists(gPath + "\" + gVerWork) Then
        Else
            Directory.CreateDirectory(gPath + "\" + gVerWork)
        End If

        ' μετακινει το mercury ston old version folder
        If File.Exists(gPath + "\mercury.exe") Then
            If File.Exists(gPath + "\" + gVerWork + "\mercury.exe") Then
            Else
                File.Move(gPath + "\mercury.exe", gPath + "\" + gVerWork + "\mercury.exe")
            End If

        End If

        ' μετακινει το updw.txt ston old version folder
        If File.Exists(gPath + "\updw.txt") Then
            If File.Exists(gPath + "\" + gVerWork + "\updw.txt") Then
            Else
                File.Move(gPath + "\updw.txt", gPath + "\" + gVerWork + "\updw.txt")
            End If

        End If


        ' kanei copy to upd.txt sto c:\mercvb\updates\updw.txt
        If File.Exists(gPath + "\upd.txt") Then

            If File.Exists(gPath + "\updw.txt") Then
                File.Delete(gPath + "\updw.txt")
            End If
            File.Copy(gPath + "\upd.txt", gPath + "\updw.txt")
        End If

        'σβηνει το παλιό zip για να έρθει το νέο
        If File.Exists(gPath + "\mercury.zip") Then
            File.Delete(gPath + "\mercury.zip")
        End If



        Timer1.Enabled = True

        ProgressBar1.Maximum = 14

        'ανοιγει thread και κατεβάζει το mercury.zip
        th1 = New Threading.Thread(AddressOf down)
        th1.Start()






    End Sub

    Sub down()

        Dim CLIENT As WebClient = New WebClient()
        CLIENT.Credentials = New NetworkCredential("mercury", "mercury12345678!!!")

        '  CLIENT.DownloadFile( ftp://62.103.69.140:50001/update.inf", gPath + "\upd.inf")  ftp://62.103.69.140:50001/mercury/update.inf"


        CLIENT.DownloadFile(
            "ftp://192.168.1.100:50001/mercury.zip", gPath + "\mercury.zip")
        '   "ftp://62.103.69.140:50001/mercury.zip", gPath + "\mercury.zip")
        ' MsgBox("ολοκληρώθηκε")
        ' th1.Abort()
        UnZip()







        '  ProgressBar1.Value = ProgressBar1.Maximum
        ' th1.Abort()
        MsgBox("ολοκληρώθηκε")

    End Sub




    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If File.Exists(gPath + "\merc.zip") Then

            Dim myFile As New FileInfo(gPath + "\merc.zip")
            Dim sizeInBytes As Long = myFile.Length
            Me.Text = Format(sizeInBytes / 1000000, "##0.00")
            ProgressBar1.Value = sizeInBytes / 1000000


        End If

    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 0
        Try
            File.Delete(gPath + "\upd.txt")
            ' File.Delete(gPath + "\mercury.exe")
        Catch ex As Exception

        End Try


        Try

            Dim CLIENT As WebClient = New WebClient()
            CLIENT.Credentials = New NetworkCredential("mercury", "mercury12345678!!!")

            CLIENT.DownloadFile(
                 "ftp://192.168.1.100:50001/mercury/update.inf", gPath + "\upd.txt")
            '  "ftp://62.103.69.140:50001/mercury/update.inf", gPath + "\upd.txt")


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
            download.Enabled = False

            Exit Sub

        End If


        If File.Exists(gPath + "/updw.txt") Then
            FileOpen(1, gPath + "/updw.txt", OpenMode.Input)
            gVerWork = LineInput(1)

            FileClose(1)
            If gVerServ > gVerWork Then
                mes.Text = "υπαρχει νέα έκδοση " + gVerServ
                '.Enabled = True


            Else
                mes.Text = "Εχετε την τελευταία έκδοση"
            End If




        Else
            mes.Text = "υπαρχει νέα έκδοση " + gVerServ


        End If




    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        UnZip()

    End Sub

    'Declare the shell object
    '  Dim shObj As Object = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"))

    Sub UnZip()


        ' Dim startPath As String = "c:\example\start"
        Dim zipPath As String = gPath + "\mercury.zip" '"c:\example\result.zip"
        Dim extractPath As String = gPath ' "c:\example\extract"

        If File.Exists(gPath + "\mercury.exe") Then
            File.Delete(gPath + "\mercury.exe")
        End If
        ZipFile.ExtractToDirectory(zipPath, extractPath)


        ' εαν υπάρχει σίγουρα στον φάκελο , σβησε το c:\mercvb\mercury.exe και αντέγραψε στην θέση του το νέο exe
        If File.Exists(gPath + "\mercury.exe") Then

            For Each proc As Process In Process.GetProcessesByName("mercury")
                proc.Kill()
                Sleep(2000)
            Next





            If File.Exists("c:\mercvb\mercury.exe") Then
                File.Delete("c:\mercvb\mercury.exe")

            End If


            File.Copy(gPath + "\mercury.exe", "c:\mercvb\mercury.exe")
        End If


    End Sub







End Class
