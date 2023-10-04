namespace EmailClient
{
    partial class Form1
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
            Title = new Label();
            userMail = new Label();
            UserEmailInput = new TextBox();
            userPassword = new Label();
            UserPasswordInput = new TextBox();
            toAdress = new Label();
            RecieverEmailInput = new TextBox();
            Subject = new Label();
            SubjectInput = new TextBox();
            mailInput = new Label();
            sendButton = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            Title.Location = new Point(39, 28);
            Title.Name = "Title";
            Title.Size = new Size(165, 26);
            Title.TabIndex = 0;
            Title.Text = "EMAIL CLIENT";
            // 
            // userMail
            // 
            userMail.AutoSize = true;
            userMail.Location = new Point(39, 77);
            userMail.Name = "userMail";
            userMail.Size = new Size(82, 20);
            userMail.TabIndex = 1;
            userMail.Text = "User email:";
            // 
            // UserEmailInput
            // 
            UserEmailInput.BackColor = Color.DimGray;
            UserEmailInput.Location = new Point(39, 119);
            UserEmailInput.Name = "UserEmailInput";
            UserEmailInput.Size = new Size(273, 27);
            UserEmailInput.TabIndex = 2;
            // 
            // userPassword
            // 
            userPassword.AutoSize = true;
            userPassword.Location = new Point(39, 149);
            userPassword.Name = "userPassword";
            userPassword.Size = new Size(73, 20);
            userPassword.TabIndex = 3;
            userPassword.Text = "Password:";
            // 
            // UserPasswordInput
            // 
            UserPasswordInput.BackColor = Color.DimGray;
            UserPasswordInput.Location = new Point(39, 192);
            UserPasswordInput.Name = "UserPasswordInput";
            UserPasswordInput.Size = new Size(273, 27);
            UserPasswordInput.TabIndex = 4;
            UserPasswordInput.UseSystemPasswordChar = true;
            // 
            // toAdress
            // 
            toAdress.AutoSize = true;
            toAdress.Location = new Point(39, 222);
            toAdress.Name = "toAdress";
            toAdress.Size = new Size(28, 20);
            toAdress.TabIndex = 5;
            toAdress.Text = "To:";
            // 
            // RecieverEmailInput
            // 
            RecieverEmailInput.BackColor = Color.DimGray;
            RecieverEmailInput.Location = new Point(39, 260);
            RecieverEmailInput.Name = "RecieverEmailInput";
            RecieverEmailInput.Size = new Size(273, 27);
            RecieverEmailInput.TabIndex = 6;
            // 
            // Subject
            // 
            Subject.AutoSize = true;
            Subject.Location = new Point(459, 77);
            Subject.Name = "Subject";
            Subject.Size = new Size(61, 20);
            Subject.TabIndex = 7;
            Subject.Text = "Subject:";
            // 
            // SubjectInput
            // 
            SubjectInput.BackColor = Color.DimGray;
            SubjectInput.Location = new Point(459, 119);
            SubjectInput.Multiline = true;
            SubjectInput.Name = "SubjectInput";
            SubjectInput.ScrollBars = ScrollBars.Both;
            SubjectInput.Size = new Size(273, 50);
            SubjectInput.TabIndex = 8;
            // 
            // mailInput
            // 
            mailInput.AutoSize = true;
            mailInput.Location = new Point(459, 172);
            mailInput.Name = "mailInput";
            mailInput.Size = new Size(70, 20);
            mailInput.TabIndex = 10;
            mailInput.Text = "Message:";
            // 
            // sendButton
            // 
            sendButton.ForeColor = Color.Black;
            sendButton.Location = new Point(459, 368);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(78, 54);
            sendButton.TabIndex = 11;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.DimGray;
            richTextBox1.Location = new Point(459, 215);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            richTextBox1.Size = new Size(273, 126);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(sendButton);
            Controls.Add(mailInput);
            Controls.Add(SubjectInput);
            Controls.Add(Subject);
            Controls.Add(RecieverEmailInput);
            Controls.Add(toAdress);
            Controls.Add(UserPasswordInput);
            Controls.Add(userPassword);
            Controls.Add(UserEmailInput);
            Controls.Add(userMail);
            Controls.Add(Title);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title;
        private Label userMail;
        private TextBox UserEmailInput;
        private Label userPassword;
        private TextBox UserPasswordInput;
        private Label toAdress;
        private TextBox RecieverEmailInput;
        private Label Subject;
        private TextBox SubjectInput;
        private Label mailInput;
        private Button sendButton;
        private RichTextBox richTextBox1;
    }
}