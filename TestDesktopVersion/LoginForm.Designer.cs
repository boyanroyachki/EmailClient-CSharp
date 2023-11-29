namespace TestDesktopVersion
{
    partial class ChillMail
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChillMail));
            userEmail = new Label();
            userEmailInput = new TextBox();
            userPassword = new Label();
            LogInButton = new Button();
            userPasswordInput = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // userEmail
            // 
            userEmail.AutoSize = true;
            userEmail.Location = new Point(133, 91);
            userEmail.Name = "userEmail";
            userEmail.Size = new Size(106, 23);
            userEmail.TabIndex = 0;
            userEmail.Text = "Email Adress";
            // 
            // userEmailInput
            // 
            userEmailInput.Location = new Point(133, 129);
            userEmailInput.Name = "userEmailInput";
            userEmailInput.PlaceholderText = "Your email adress";
            userEmailInput.Size = new Size(262, 30);
            userEmailInput.TabIndex = 1;
            // 
            // userPassword
            // 
            userPassword.AutoSize = true;
            userPassword.Location = new Point(133, 206);
            userPassword.Name = "userPassword";
            userPassword.Size = new Size(80, 23);
            userPassword.TabIndex = 2;
            userPassword.Text = "Password";
            // 
            // LogInButton
            // 
            LogInButton.BackColor = SystemColors.ActiveCaption;
            LogInButton.Cursor = Cursors.Hand;
            LogInButton.Location = new Point(133, 331);
            LogInButton.Name = "LogInButton";
            LogInButton.Size = new Size(170, 56);
            LogInButton.TabIndex = 4;
            LogInButton.Text = "Log in";
            LogInButton.UseVisualStyleBackColor = false;
            LogInButton.Click += LogInButton_Click;
            // 
            // userPasswordInput
            // 
            userPasswordInput.Location = new Point(133, 245);
            userPasswordInput.Name = "userPasswordInput";
            userPasswordInput.PlaceholderText = "Your password";
            userPasswordInput.Size = new Size(262, 30);
            userPasswordInput.TabIndex = 5;
            userPasswordInput.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(583, 34);
            button1.Name = "button1";
            button1.Size = new Size(196, 65);
            button1.TabIndex = 6;
            button1.Text = "Welcome";
            button1.UseCompatibleTextRendering = true;
            button1.UseVisualStyleBackColor = true;
            // 
            // ChillMail
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1334, 828);
            Controls.Add(button1);
            Controls.Add(userPasswordInput);
            Controls.Add(LogInButton);
            Controls.Add(userPassword);
            Controls.Add(userEmailInput);
            Controls.Add(userEmail);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChillMail";
            Text = "Chill-Mail";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label userEmail;
        private TextBox userEmailInput;
        private Label userPassword;
        private Button LogInButton;
        private TextBox userPasswordInput;
        private Button button1;
    }
}
