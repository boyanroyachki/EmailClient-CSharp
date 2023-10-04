using MimeKit;
using MailKit.Net.Smtp;
using static EmailClient.Common.Methods;

Console.WriteLine("███████╗███╗░░░███╗░█████╗░██╗██╗░░░░░  ░█████╗░██╗░░░░░██╗███████╗███╗░░██╗████████╗");
Console.WriteLine("██╔════╝████╗░████║██╔══██╗██║██║░░░░░  ██╔══██╗██║░░░░░██║██╔════╝████╗░██║╚══██╔══╝");
Console.WriteLine("█████╗░░██╔████╔██║███████║██║██║░░░░░  ██║░░╚═╝██║░░░░░██║█████╗░░██╔██╗██║░░░██║░░░");
Console.WriteLine("██╔══╝░░██║╚██╔╝██║██╔══██║██║██║░░░░░  ██║░░██╗██║░░░░░██║██╔══╝░░██║╚████║░░░██║░░░");
Console.WriteLine("███████╗██║░╚═╝░██║██║░░██║██║███████╗  ╚█████╔╝███████╗██║███████╗██║░╚███║░░░██║░░░");
Console.WriteLine("╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝╚══════╝  ░╚════╝░╚══════╝╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░");

Console.Write("Type your email adress here: ");
string emailFrom = Console.ReadLine();

Console.Write("Type your password here: ");
string password = Console.ReadLine();

Console.Write("Email to: ");
string emailTo = Console.ReadLine();

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




