using MimeKit;
using MailKit.Net.Smtp;
using static EmailClient.Common.Methods;

while (true)
{
    Console.WriteLine("███████╗███╗░░░███╗░█████╗░██╗██╗░░░░░  ░█████╗░██╗░░░░░██╗███████╗███╗░░██╗████████╗");
    Console.WriteLine("██╔════╝████╗░████║██╔══██╗██║██║░░░░░  ██╔══██╗██║░░░░░██║██╔════╝████╗░██║╚══██╔══╝");
    Console.WriteLine("█████╗░░██╔████╔██║███████║██║██║░░░░░  ██║░░╚═╝██║░░░░░██║█████╗░░██╔██╗██║░░░██║░░░");
    Console.WriteLine("██╔══╝░░██║╚██╔╝██║██╔══██║██║██║░░░░░  ██║░░██╗██║░░░░░██║██╔══╝░░██║╚████║░░░██║░░░");
    Console.WriteLine("███████╗██║░╚═╝░██║██║░░██║██║███████╗  ╚█████╔╝███████╗██║███████╗██║░╚███║░░░██║░░░");
    Console.WriteLine("╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝╚══════╝  ░╚════╝░╚══════╝╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░");

    Console.Write("Type your email adress here: ");
    string emailFrom = Console.ReadLine();
    if (String.IsNullOrEmpty(emailFrom) || String.IsNullOrWhiteSpace(emailFrom))
    {
        Console.WriteLine("Invalid email input!");
        break;
    }

    Console.Write("Type your password here: ");
    string password = Console.ReadLine();
    if (String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password))
    {
        Console.WriteLine("Invalid email password!");
        break;
    }

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
        Console.WriteLine("░░░░░░░██████╗███████╗███╗░░██╗██████╗░░░░░░░");
        Console.WriteLine("░░░░░░██╔════╝██╔════╝████╗░██║██╔══██╗░░░░░░");
        Console.WriteLine("█████╗╚█████╗░█████╗░░██╔██╗██║██║░░██║█████╗");
        Console.WriteLine("╚════╝░╚═══██╗██╔══╝░░██║╚████║██║░░██║╚════╝");
        Console.WriteLine("░░░░░░██████╔╝███████╗██║░╚███║██████╔╝░░░░░░");
        Console.WriteLine("░░░░░░╚═════╝░╚══════╝╚═╝░░╚══╝╚═════╝░░░░░░░");

    }
    catch (Exception ex)
    {
        Console.WriteLine("███████╗██████╗░██████╗░░█████╗░██████╗░██╗");
        Console.WriteLine("██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗╚═╝");
        Console.WriteLine("█████╗░░██████╔╝██████╔╝██║░░██║██████╔╝░░░");
        Console.WriteLine("██╔══╝░░██╔══██╗██╔══██╗██║░░██║██╔══██╗░░░");
        Console.WriteLine("███████╗██║░░██║██║░░██║╚█████╔╝██║░░██║██╗");
        Console.WriteLine("╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝╚═╝");
        Console.WriteLine($"Failed to send email. Reason: {ex.Message}");
    }

    Console.WriteLine();
    Console.Write("Send another mail? y/n: ");
    string answer = Console.ReadLine();

    if (answer == "y")
    {
        Console.Clear();
    }
    else
    {
        Console.WriteLine("████████╗░█████╗░██╗░░██╗███████╗  ░█████╗░░█████╗░██████╗░███████╗██╗");
        Console.WriteLine("╚══██╔══╝██╔══██╗██║░██╔╝██╔════╝  ██╔══██╗██╔══██╗██╔══██╗██╔════╝██║");
        Console.WriteLine("░░░██║░░░███████║█████═╝░█████╗░░  ██║░░╚═╝███████║██████╔╝█████╗░░██║");
        Console.WriteLine("░░░██║░░░██╔══██║██╔═██╗░██╔══╝░░  ██║░░██╗██╔══██║██╔══██╗██╔══╝░░╚═╝");
        Console.WriteLine("░░░██║░░░██║░░██║██║░╚██╗███████╗  ╚█████╔╝██║░░██║██║░░██║███████╗██╗");
        Console.WriteLine("░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝  ░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝╚═╝");
        Console.WriteLine();
        Console.WriteLine();
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




