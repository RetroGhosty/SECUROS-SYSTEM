
Imports System.IO
Imports System.Security.Cryptography.Xml
Imports System.Windows.Forms.Design
Imports System.Windows.Forms.VisualStyles

Public Class Form1
    Dim SecretKey As String = "JapaneseDream"
    Dim EncryptedFolder = "Encrypted Folder"
    Dim DecryptedFolder = "Decrypted Folder"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Open the OpenFileDialog
        OpenFileDialog1.Multiselect = True
        OpenFileDialog1.Filter = "Document Files (*.docx)(*.pdf)(*.xlsx)|*.docx; *.pdf; *.xlsx"
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Open the OpenFileDialog
        OpenFileDialog2.Multiselect = True
        OpenFileDialog2.Filter = "Encrypted Documents (*.encrypted)|*.encrypted"
        OpenFileDialog2.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim selectedFilePath As String()
        selectedFilePath = OpenFileDialog1.FileNames
        Dim DestinationFilePath = FileSystem.CurDir + "\" + EncryptedFolder
        For Each eachFileName In selectedFilePath
            Dim GetFileNames = Path.GetFileName(eachFileName)
            Dim DestFile = Path.Combine(DestinationFilePath, GetFileNames)

            FileEncryption.EncryptFile(eachFileName, DestFile, SecretKey)
        Next
    End Sub
    Private Sub OpenFileDialog2_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk
        Dim selectedFilePath As String()
        selectedFilePath = OpenFileDialog2.FileNames
        Dim DestinationFilePath = FileSystem.CurDir + "\" + DecryptedFolder
        For Each eachFileName In selectedFilePath
            Dim GetFileNames = Path.GetFileName(eachFileName)
            Dim DestFile = Path.Combine(DestinationFilePath, GetFileNames)

            FileEncryption.DecryptFile(eachFileName, DestFile, SecretKey)
            My.Computer.FileSystem.DeleteFile(eachFileName)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Directory.Exists(EncryptedFolder) = False Then
            MessageBox.Show($"{EncryptedFolder} not found. Automatically creating it")
            Directory.CreateDirectory(EncryptedFolder)
        End If

        If Directory.Exists(DecryptedFolder) = False Then
            MessageBox.Show($"{DecryptedFolder} not found. Automatically creating it")
            Directory.CreateDirectory(DecryptedFolder)
        End If
    End Sub

End Class
