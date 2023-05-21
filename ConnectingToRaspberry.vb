Imports System.Net.Sockets
Imports System.Text

Public Class ConnectingToRaspberry
    'Dim command As String = "SCAN_FINGERPRINT" ' Replace with the specific command you want to send

    Private Function SendToRaspberry(ByVal theMessage As String)
        Dim client As New TcpClient()
        Dim serverIp As String = "192.168.2.101" ' Replace with the Raspberry Pi IP address
        Dim serverPort As Integer = 5000 ' Replace with the port number on which the Raspberry Pi is listening
        Try
            client.Connect(serverIp, serverPort)
            ' Send command to Raspberry Pi
            Dim stream As NetworkStream = client.GetStream()
            Dim commandBytes As Byte() = Encoding.ASCII.GetBytes(theMessage)
            stream.Write(commandBytes, 0, commandBytes.Length)

            ' Receive response from Raspberry Pi
            Dim responseBytes(client.ReceiveBufferSize) As Byte
            Dim bytesRead As Integer = stream.Read(responseBytes, 0, client.ReceiveBufferSize)
            Dim response As String = Encoding.ASCII.GetString(responseBytes, 0, bytesRead)


            Return response
            stream.Close()
            client.Close()
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
        Return Nothing
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label2.Text = SendToRaspberry("addnumber")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label2.Text = SendToRaspberry("Say developer name")
    End Sub

    Private Sub ConnectingToRaspberry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        /saduasd9asdsad
    End Sub
End Class