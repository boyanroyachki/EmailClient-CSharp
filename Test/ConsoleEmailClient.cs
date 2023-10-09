using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;
using static EmailClient.Common.AsciiMessages;
using static EmailClient.Common.Methods;

while (true)
{
    WelcomeMessage();

    Console.Write("Type your email adress here: ");
    string emailFrom = Console.ReadLine();
    if (String.IsNullOrEmpty(emailFrom) || String.IsNullOrWhiteSpace(emailFrom))
    {
        Console.WriteLine("Invalid email input!");
        break;
    }

    Console.Write("Type your password here: ");

    string password = Console.ReadLine();
    //SecureString password = GetPassword();

    if (String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password))
    {
        Console.WriteLine("Invalid email password!");
        break;
    }


    Console.WriteLine("Choose an option:");
    Console.WriteLine("Send email: [1]");
    Console.WriteLine("Check inbox: [2]");
    Console.Write("Type here: ");
    string command = Console.ReadLine();
    if (command == "1")
    {
        Console.Write("Email to: ");
        string emailTo = Console.ReadLine();
        if (String.IsNullOrEmpty(emailTo) || String.IsNullOrWhiteSpace(emailTo))
        {
            Console.WriteLine("Invalid recipient input!");
            break;
        }

        Console.Write("Type the topic of the message: ");
        string topic = Console.ReadLine();

        Console.Write("Write you message: ");
        string message = Console.ReadLine();

        try
        {
            SendEmail(emailFrom, password, emailTo, topic, message);
            //send
            SendMessageText();

        }
        catch (Exception ex)
        {
            ErrorMessageText();
            Console.WriteLine($"Failed to send email. Reason: {ex.Message}");
        }
    }
    if (command == "2")
    {
        using (var client = new ImapClient())
        {
            try
            {
                client.Connect("imap.gmail.com", 993, true);  //secure

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(emailFrom, password);

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
                    Console.WriteLine();
                }

                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error accured while opening your inbox. Reason: {ex.Message}");
            }

        }
    }

    Console.WriteLine();
    Console.Write("Use the email client again? y/n: ");
    string answer = Console.ReadLine();

    if (answer == "y")
    {
        Console.Clear();
    }
    else
    {
        EndSessionText();
        break;
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
        client.Connect("smtp.gmail.com", 465, true);
    }

    //add other types

    client.Authenticate(fromEmail, password);
    client.Send(emailMessage);
    client.Disconnect(true);
}





