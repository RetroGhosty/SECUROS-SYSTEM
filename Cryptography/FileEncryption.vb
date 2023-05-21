Imports System.IO
Imports System.Security.Cryptography

Public Class FileEncryption

    Public Shared Sub EncryptFile(inputFile As String, outputFile As String, password As String)
        Dim encryptedFile As String = outputFile & ".encrypted"

        Using aesAlg As New AesCryptoServiceProvider()
            aesAlg.Key = GenerateKey(password, aesAlg.KeySize)
            aesAlg.GenerateIV()

            Using outputFileStream As New FileStream(encryptedFile, FileMode.Create)
                ' Write the IV to the beginning of the output file
                outputFileStream.Write(aesAlg.IV, 0, aesAlg.IV.Length)

                Using cryptoStream As New CryptoStream(outputFileStream, aesAlg.CreateEncryptor(), CryptoStreamMode.Write)
                    Using inputFileStream As New FileStream(inputFile, FileMode.Open)
                        ' Encrypt the file
                        inputFileStream.CopyTo(cryptoStream)
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Public Shared Sub DecryptFile(inputFile As String, outputFile As String, password As String)
        Dim decryptedFile As String = outputFile

        If outputFile.EndsWith(".encrypted") Then
            decryptedFile = outputFile.Substring(0, outputFile.Length - 10)
        End If

        Using aesAlg As New AesCryptoServiceProvider()
            aesAlg.Key = GenerateKey(password, aesAlg.KeySize)

            ' Read the IV from the beginning of the input file
            Dim ivBytes(aesAlg.BlockSize \ 8 - 1) As Byte
            Using inputFileStream As New FileStream(inputFile, FileMode.Open)
                inputFileStream.Read(ivBytes, 0, ivBytes.Length)
            End Using

            aesAlg.IV = ivBytes

            Using outputFileStream As New FileStream(decryptedFile, FileMode.Create)
                Using cryptoStream As New CryptoStream(outputFileStream, aesAlg.CreateDecryptor(), CryptoStreamMode.Write)
                    Using inputFileStream As New FileStream(inputFile, FileMode.Open)
                        ' Decrypt the file
                        inputFileStream.Position = aesAlg.BlockSize \ 8 ' Skip the IV
                        inputFileStream.CopyTo(cryptoStream)
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Shared Function GenerateKey(password As String, keySize As Integer) As Byte()
        Using sha256 As New SHA256CryptoServiceProvider()
            Dim passwordBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(password)
            Dim hashBytes As Byte() = sha256.ComputeHash(passwordBytes)
            Dim keyBytes(keySize \ 8 - 1) As Byte
            Array.Copy(hashBytes, keyBytes, keyBytes.Length)
            Return keyBytes
        End Using
    End Function

End Class
