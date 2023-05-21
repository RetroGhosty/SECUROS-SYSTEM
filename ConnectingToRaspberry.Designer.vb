<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConnectingToRaspberry
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Button1 = New Button()
        Label2 = New Label()
        Label3 = New Label()
        Button2 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(209, 37)
        Label1.TabIndex = 0
        Label1.Text = "Send something"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(12, 49)
        Button1.Name = "Button1"
        Button1.Size = New Size(90, 51)
        Button1.TabIndex = 2
        Button1.Text = "What is 1+1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(12, 178)
        Label2.Name = "Label2"
        Label2.Size = New Size(122, 28)
        Label2.TabIndex = 3
        Label2.Text = "No response"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(12, 141)
        Label3.Name = "Label3"
        Label3.Size = New Size(283, 37)
        Label3.TabIndex = 4
        Label3.Text = "Raspberry Pi Response"
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(108, 49)
        Button2.Name = "Button2"
        Button2.Size = New Size(101, 51)
        Button2.TabIndex = 5
        Button2.Text = "Say my name"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' ConnectingToRaspberry
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(581, 289)
        Controls.Add(Button2)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Name = "ConnectingToRaspberry"
        Text = "ConnectingToRaspberry"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
End Class
