Imports System.IO
Imports System.Net.Sockets

Public Class TCP
    Private Sub TransferFile(filePath As String)
        ' Server details
        Dim serverIP As String = "192.168.0.100"
        Dim serverPort As Integer = 1234

        Try
            ' Connect to the server
            Using client As New TcpClient(serverIP, serverPort)
                Dim networkStream As NetworkStream = client.GetStream()

                ' Read the file as a byte array
                Dim fileBytes As Byte() = File.ReadAllBytes(filePath)

                ' Send the file size to the server
                Dim fileSizeBytes As Byte() = BitConverter.GetBytes(fileBytes.Length)
                networkStream.Write(fileSizeBytes, 0, fileSizeBytes.Length)

                ' Send the file contents to the server
                networkStream.Write(fileBytes, 0, fileBytes.Length)

                ' Close the network stream and the TCP client
                networkStream.Close()
                client.Close()
            End Using

            ' Display a success message
            MessageBox.Show("File transferred successfully to the server.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ' Display an error message
            MessageBox.Show("An error occurred while transferring the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
