using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Security;
using static EmailClient.Common.AsciiMessages;
using static EmailClient.Common.Methods;


bool loggedIn = false;          //
string emailFrom = null;       // -> variables, needed from the start
SecureString password = null; //

while (true)
{

    WelcomeMessage();

    if (loggedIn)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Logged in as {emailFrom}");
        Console.ResetColor();
    }  //logged in message

    if (!loggedIn)
    {
        //
        Console.Write("Type your email address here: ");
        emailFrom = Console.ReadLine();
        //

        //
        if (!IsUserInputValid(emailFrom, "Invalid email input!"))
        {
            break;
        }
        //

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Type your password here: ");
        Console.ResetColor();
        //password = Console.ReadLine();
        password = ReadPassword();
    }

    Console.WriteLine();
    Console.WriteLine("Choose an option:");
    Console.WriteLine();
    Console.WriteLine("Send email: [1]");
    Console.WriteLine("Check inbox: [2]");

    Console.WriteLine();
    Console.Write("Type here: ");
    string command = Console.ReadLine();


    if (command == "1" || command == "[1]")
    {
        Console.Write("Email to: ");
        string emailTo = Console.ReadLine();
        if (String.IsNullOrEmpty(emailTo) || String.IsNullOrWhiteSpace(emailTo))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid recipient input!");
            break;
        }

        //
        Console.Write("Type the topic of the message: ");
        string topic = Console.ReadLine();
        //

        //
        Console.Write("Write you message: ");
        string message = Console.ReadLine();
        //

        try
        {
            SendEmail(emailFrom, ConvertToUnsecureString(password), emailTo, topic, message);
            //send
            SendMessageText();

        }
        catch (Exception ex)
        {
            ErrorMessageText();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Failed to send email. Reason: {ex.Message}");
            Console.ResetColor();
        }
    }

    if (command == "2" || command == "[2]")
    {
        using (var client = new ImapClient())
        {
            try
            {
                client.Connect("imap.gmail.com", 993, true);  //secure

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                //client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(emailFrom, ConvertToUnsecureString(password));
                loggedIn = true;

                // Get the inbox folder and open it.
                var inbox = client.Inbox;
                inbox.Open(MailKit.FolderAccess.ReadOnly);

                Console.WriteLine($"Total messages: {inbox.Count}");
                Console.WriteLine($"Recent messages: {inbox.Recent}");

                // Fetch the recent messages. Let's say the last 10:
                for (int i = inbox.Count - 1; i >= inbox.Count - 10 && i >= 0; i--)
                {
                    var message = inbox.GetMessage(i);
                    Console.WriteLine($"Subject: {message.Subject}, From: {message.From}");
                    Console.WriteLine($"Message: ");
                    Console.WriteLine($"{message.TextBody}");
                    Console.WriteLine(" - - - - - - -");
                    Console.WriteLine();
                }

                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error accured while opening your inbox. Reason: {ex.Message}");
                Console.ResetColor();
            }

        }
    }

    Console.WriteLine();
    Console.Write("Use the email client again? y/n: ");
    string answer = Console.ReadLine();

    if (answer.ToLower() == "y")
    {
        Console.Clear();
    }
    else if (answer.ToLower() == "n")
    {
        Console.WriteLine("You will be logged out. Proceed? y/n");
        answer = Console.ReadLine();

        if (answer.ToLower() == "y")
        {
            loggedIn = false;
            Console.Clear();
            EndSessionText();
            break;
        }
        else if (answer.ToLower() == "n")
        {
            Console.Clear();
        }
    }


}

void SendEmail(string fromEmail, string password, string toEmail, string subject, string message)
{
    var emailMessage = new MimeMessage();

    emailMessage.From.Add(new MailboxAddress("", fromEmail));
    emailMessage.To.Add(new MailboxAddress("", toEmail));

    emailMessage.Subject = subject;
    emailMessage.Body = new TextPart("plain") { Text = message };

    var client = new SmtpClient();
    if (GemEmailType(fromEmail) == "gmail.com")
    {
        client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
    }

    //add other types

    client.Authenticate(fromEmail, password);
    loggedIn = true;
    client.Send(emailMessage);
    client.Disconnect(true);
}

bool IsUserInputValid(string userInput, string errorMessage)
{
    if (String.IsNullOrEmpty(userInput) || String.IsNullOrWhiteSpace(userInput))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.ResetColor();

        return false;
    }
    return true;
}

//string ReadPassword()
//{
//    string newPass = "";
//    while (true)
//    {
//        ConsoleKeyInfo key = Console.ReadKey(true);
//        if (key.Key == ConsoleKey.Enter)
//        {
//            break;
//        }
//        if (key.Key == ConsoleKey.Backspace && newPass.Length > 0)
//        {
//            newPass = newPass[0..^1];
//            Console.Write("\b \b"); // Erases the last asterisk
//        }
//        else if (!char.IsControl(key.KeyChar))
//        {
//            newPass += key.KeyChar;
//            Console.Write("*"); // Or use '\0' if you don't want to show anything
//        }
//    }
//    Console.WriteLine();
//    return newPass;
//}

SecureString ReadPassword()
{
    var password = new SecureString();
    while (true)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Enter)
        {
            break;
        }
        if (key.Key == ConsoleKey.Backspace && password.Length > 0)
        {
            password.RemoveAt(password.Length - 1);
            Console.Write("\b \b");
        }
        else if (!char.IsControl(key.KeyChar))
        {
            password.AppendChar(key.KeyChar);
            Console.Write("*");
        }
    }
    Console.WriteLine();
    return password;
}
string ConvertToUnsecureString(SecureString securePassword)
{
    if (securePassword == null)
    {
        return string.Empty;
    }

    IntPtr unmanagedString = IntPtr.Zero;
    try
    {
        unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
        return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
    }
    finally
    {
        System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
    }
}

