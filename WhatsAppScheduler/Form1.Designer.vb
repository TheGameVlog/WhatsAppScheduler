<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Button1 = New Button()
        Button2 = New Button()
        dtpSchedule = New DateTimePicker()
        Label1 = New Label()
        Label2 = New Label()
        txtRecipient = New TextBox()
        txtMessage = New TextBox()
        Label3 = New Label()
        SearchTextTimer = New Timer(components)
        Button3 = New Button()
        btnLogout = New Button()
        lblCountdown = New Label()
        countDownTimer = New Timer(components)
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(12, 12)
        Button1.Name = "Button1"
        Button1.Size = New Size(137, 23)
        Button1.TabIndex = 0
        Button1.Text = "Login to Whatsapp"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(276, 245)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 1
        Button2.Text = "Schedule"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' dtpSchedule
        ' 
        dtpSchedule.CustomFormat = "dd-MMM-yyyy HH:mm tt"
        dtpSchedule.Format = DateTimePickerFormat.Custom
        dtpSchedule.Location = New Point(151, 60)
        dtpSchedule.Name = "dtpSchedule"
        dtpSchedule.Size = New Size(200, 23)
        dtpSchedule.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(21, 64)
        Label1.Name = "Label1"
        Label1.Size = New Size(124, 15)
        Label1.TabIndex = 3
        Label1.Text = "Schedule Date && Time"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(22, 97)
        Label2.Name = "Label2"
        Label2.Size = New Size(97, 15)
        Label2.TabIndex = 4
        Label2.Text = "Recipient Name :"
        ' 
        ' txtRecipient
        ' 
        txtRecipient.Location = New Point(151, 93)
        txtRecipient.Name = "txtRecipient"
        txtRecipient.Size = New Size(200, 23)
        txtRecipient.TabIndex = 5
        ' 
        ' txtMessage
        ' 
        txtMessage.Location = New Point(151, 126)
        txtMessage.Multiline = True
        txtMessage.Name = "txtMessage"
        txtMessage.Size = New Size(200, 99)
        txtMessage.TabIndex = 7
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(22, 130)
        Label3.Name = "Label3"
        Label3.Size = New Size(59, 15)
        Label3.TabIndex = 6
        Label3.Text = "Message :"
        ' 
        ' SearchTextTimer
        ' 
        SearchTextTimer.Interval = 500
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(195, 245)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 8
        Button3.Text = "Send Now"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' btnLogout
        ' 
        btnLogout.Location = New Point(210, 12)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(148, 23)
        btnLogout.TabIndex = 9
        btnLogout.Text = "Logout From Whatsapp"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' lblCountdown
        ' 
        lblCountdown.AutoSize = True
        lblCountdown.Font = New Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point)
        lblCountdown.Location = New Point(25, 308)
        lblCountdown.Name = "lblCountdown"
        lblCountdown.Size = New Size(0, 65)
        lblCountdown.TabIndex = 10
        ' 
        ' countDownTimer
        ' 
        countDownTimer.Interval = 1000
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(370, 395)
        Controls.Add(lblCountdown)
        Controls.Add(btnLogout)
        Controls.Add(Button3)
        Controls.Add(txtMessage)
        Controls.Add(Label3)
        Controls.Add(txtRecipient)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(dtpSchedule)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents dtpSchedule As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRecipient As TextBox
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SearchTextTimer As Timer
    Friend WithEvents Button3 As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents lblCountdown As Label
    Friend WithEvents countDownTimer As Timer
End Class
