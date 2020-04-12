ΑΝΟΙΓΟΝΤΑΣ

ΕΛΕΓΧΕΙ ΤΟ UPDW.TXT (ΤΟΠΙΚΟ ΑΡΧΕΙΟ ) ME TO ARXEIO UPD.TXT (REMOTE)
ΔΙΑΒΑΖΕΙ ΤΗΝ ΠΡΩΤΗ ΣΕΙΡΑ (ΕΚΔΟΣΗ) ΤΩΒ 2 ΑΡΧΕΙΩΝ ΚΑΙ ΕΛΕΓΧΕΙ ΑΝ ΥΠΑΡΧΕΙ ΝΕΑ ΕΚΔΟΣΗ




ΑΝ ΠΑΤΗΣΩ ΚΑΤΕΒΑΣΕ ΕΚΔΟΣΗ :




        'δημιουργει τον καταλογο της παλιάς εκδοσης και κανει copy to updw.txt & mercury.exe
       

        ' μετακινει το mercury ston old version folder

        ' μετακινει το updw.txt ston old version folder
       

        ' kanei copy to upd.txt sto c:\mercvb\updates\updw.txt
             
                File.Delete(gPath + "\mercury.zip")

        'ανοιγει thread και κατεβάζει το mercury.zip
        th1 = New Threading.Thread(AddressOf down)
        th1.Start()


