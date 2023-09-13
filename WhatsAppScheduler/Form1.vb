Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI

Public Class Form1

    ' Declare the ChromeDriver instance that will be used throughout the form
    Dim driver As ChromeDriver

    ''' <summary>
    ''' Handles the Form Load event. Initializes the ChromeDriver, sets up the Chrome profile, 
    ''' and checks if the user is already logged into WhatsApp Web.
    ''' </summary>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Get the current execution directory
        Dim executionDirectory As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

        ' Define the path for the Chrome profile
        Dim chromeProfileDirectory As String = System.IO.Path.Combine(executionDirectory, "ChromeProfile")

        ' If the Chrome profile directory doesn't exist, create it
        If Not System.IO.Directory.Exists(chromeProfileDirectory) Then
            System.IO.Directory.CreateDirectory(chromeProfileDirectory)
        End If


        Dim service As ChromeDriverService = ChromeDriverService.CreateDefaultService()
        service.HideCommandPromptWindow = True

        ' Set up Chrome options to use the specified profile directory
        Dim chromeOptions As New ChromeOptions()
        chromeOptions.AddArgument($"user-data-dir={chromeProfileDirectory}")

        ' Initialize the Chrome driver with the specified options
        driver = New ChromeDriver(service, chromeOptions)

        ' Navigate to WhatsApp Web
        driver.Navigate().GoToUrl("https://web.whatsapp.com/")

        driver.Manage().Window.Size = New System.Drawing.Size(800, 600)


        ' Wait for a specific element to determine if the user is logged in
        Dim wait As New WebDriverWait(driver, TimeSpan.FromSeconds(10))
        Dim loggedIn As Boolean = False

        Try
            ' If the search input textbox is present, it means the user is logged in
            wait.Until(Function(d) d.FindElements(By.XPath("//div[@title='Search input textbox']")).Count > 0)
            loggedIn = True
        Catch ex As WebDriverTimeoutException
            ' If the element is not found within the timeout, it means the user is not logged in
            loggedIn = False
        End Try

        ' Enable or disable the Login and Logout buttons based on the login status
        Button1.Enabled = Not loggedIn
        btnLogout.Enabled = loggedIn
    End Sub

    ''' <summary>
    ''' Handles the Login button click event. Navigates to WhatsApp Web.
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        driver.Navigate().GoToUrl("https://web.whatsapp.com/")
    End Sub

    ''' <summary>
    ''' Handles the Form Closed event. Closes and quits the ChromeDriver to release resources.
    ''' </summary>
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If driver IsNot Nothing Then
            driver.Close()
            driver.Quit()
        End If
    End Sub

    ''' <summary>
    ''' Handles the Schedule button click event. Initializes the countdown based on the set schedule.
    ''' </summary>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim initialTimeSpan As TimeSpan = dtpSchedule.Value - DateTime.Now
        lblCountdown.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", initialTimeSpan.Hours, initialTimeSpan.Minutes, initialTimeSpan.Seconds)
        countDownTimer.Start()
    End Sub

    ''' <summary>
    ''' Sends the message to the selected contact in WhatsApp Web.
    ''' Splits multiline messages and sends them with newlines.
    ''' </summary>
    Private Sub SendMessage()
        ' Locate the message input box
        Dim messageBox = driver.FindElement(By.XPath("//div[@contenteditable='true' and @title='Type a message']"))

        ' Split the message by newline and send each line
        Dim lines As String() = txtMessage.Text.Split(New String() {vbNewLine}, StringSplitOptions.None)
        For Each line As String In lines
            messageBox.SendKeys(line)
            messageBox.SendKeys(Keys.Shift + Keys.Enter) ' Adds a newline
        Next

        ' Remove the last newline and send the message
        messageBox.SendKeys(Keys.Backspace)
        messageBox.SendKeys(Keys.Enter)
    End Sub

    ''' <summary>
    ''' Handles the Text Changed event for the recipient textbox. Restarts the search timer with every change.
    ''' </summary>
    Private Sub txtRecipient_TextChanged(sender As Object, e As EventArgs) Handles txtRecipient.TextChanged
        SearchTextTimer.Stop()
        SearchTextTimer.Start()
    End Sub

    ''' <summary>
    ''' Handles the Search Timer tick event. Searches for the specified recipient in WhatsApp Web.
    ''' </summary>
    Private Sub SearchTextTimer_Tick(sender As Object, e As EventArgs) Handles SearchTextTimer.Tick
        SearchTextTimer.Stop()

        ' Locate the search bar and clear it
        Dim searchBar = driver.FindElement(By.XPath("//div[@contenteditable='true' and @title='Search input textbox']"))
        For i As Integer = 1 To 60
            searchBar.SendKeys(Keys.Backspace)
        Next

        ' If the textbox is empty, return
        If String.IsNullOrEmpty(txtRecipient.Text) Then
            Return
        End If

        ' Search for the specified recipient
        searchBar.SendKeys(txtRecipient.Text)
        System.Threading.Thread.Sleep(2000)

        Dim recipientName As String = txtRecipient.Text
        Dim xpathQuery As String = $"//div[@role='listitem']//span[@title='{recipientName}']"

        Dim desiredChats = driver.FindElements(By.XPath(xpathQuery))
        If desiredChats.Count > 0 Then
            desiredChats(0).Click()
        End If
    End Sub

    ''' <summary>
    ''' Handles the Send button click event. Sends the message immediately.
    ''' </summary>
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SendMessage()
    End Sub

    ''' <summary>
    ''' Handles the Logout button click event. Logs out of WhatsApp Web.
    ''' </summary>
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Click on the menu button to reveal the dropdown
        Dim menuButton = driver.FindElement(By.XPath("//div[@aria-label='Menu']"))
        menuButton.Click()

        ' Wait for the logout button to appear and then click it
        Dim wait As New WebDriverWait(driver, TimeSpan.FromSeconds(10))
        Dim logoutElement As IWebElement = wait.Until(Function(d) d.FindElement(By.XPath("//div[@aria-label='Log out']")))
        logoutElement.Click()
    End Sub

    ''' <summary>
    ''' Handles the Countdown Timer tick event. Updates the countdown label and sends the message when the time reaches zero.
    ''' </summary>
    Private Sub countDownTimer_Tick(sender As Object, e As EventArgs) Handles countDownTimer.Tick
        Dim remainingTime As TimeSpan = dtpSchedule.Value - DateTime.Now

        If remainingTime.TotalSeconds <= 0 Then
            SendMessage()
            lblCountdown.Text = "Message Sent!!"
            countDownTimer.Stop()
        Else
            lblCountdown.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds)
        End If
    End Sub
End Class