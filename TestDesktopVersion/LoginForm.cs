namespace TestDesktopVersion
{
    public partial class ChillMail : Form
    {
        public ChillMail()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            string userEmail = userEmailInput.Text;
            string userPassword = userPasswordInput.Text;

            MessageBox.Show(userEmail + " --- " + userPassword, "Hello");
           
        }
    }
}
