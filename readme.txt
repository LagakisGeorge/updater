����������

������� �� UPDW.TXT (������ ������ ) ME TO ARXEIO UPD.TXT (REMOTE)
�������� ��� ����� ����� (������) ��� 2 ������� ��� ������� �� ������� ��� ������




�� ������ �������� ������ :




        '���������� ��� �������� ��� ������ ������� ��� ����� copy to updw.txt & mercury.exe
       

        ' ��������� �� mercury ston old version folder

        ' ��������� �� updw.txt ston old version folder
       

        ' kanei copy to upd.txt sto c:\mercvb\updates\updw.txt
             
                File.Delete(gPath + "\mercury.zip")

        '������� thread ��� ��������� �� mercury.zip
        th1 = New Threading.Thread(AddressOf down)
        th1.Start()


