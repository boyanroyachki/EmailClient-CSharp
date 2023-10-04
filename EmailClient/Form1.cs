using MailKit.Net.Smtp;
using MimeKit;

namespace EmailClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                SendEmail(UserEmailInput.Text, UserPasswordInput.Text, RecieverEmailInput.Text, SubjectInput.Text, richTextBox1.Text);
                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email. Reason: {ex.Message}");
            }
        }
        private void SendEmail(string fromEmail, string password, string toEmail, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("", fromEmail));
            emailMessage.To.Add(new MailboxAddress("", toEmail));

            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            var client = new SmtpClient();

            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate(fromEmail, password);
            client.Send(emailMessage);
            client.Disconnect(true);
        }
    }
}