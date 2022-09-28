namespace DesktopApplication {
    partial class LoginUC {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.labelPasswordError = new System.Windows.Forms.Label();
            this.labelEmailError = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBoxPassword = new System.Windows.Forms.MaskedTextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.groupBoxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Controls.Add(this.labelPasswordError);
            this.groupBoxLogin.Controls.Add(this.labelEmailError);
            this.groupBoxLogin.Controls.Add(this.buttonLogin);
            this.groupBoxLogin.Controls.Add(this.label2);
            this.groupBoxLogin.Controls.Add(this.label1);
            this.groupBoxLogin.Controls.Add(this.maskedTextBoxPassword);
            this.groupBoxLogin.Controls.Add(this.textBoxEmail);
            this.groupBoxLogin.Location = new System.Drawing.Point(315, 152);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(260, 210);
            this.groupBoxLogin.TabIndex = 0;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Login";
            // 
            // labelPasswordError
            // 
            this.labelPasswordError.AutoSize = true;
            this.labelPasswordError.Location = new System.Drawing.Point(29, 140);
            this.labelPasswordError.Name = "labelPasswordError";
            this.labelPasswordError.Size = new System.Drawing.Size(85, 15);
            this.labelPasswordError.TabIndex = 6;
            this.labelPasswordError.Text = "Password error";
            // 
            // labelEmailError
            // 
            this.labelEmailError.AutoSize = true;
            this.labelEmailError.Location = new System.Drawing.Point(29, 63);
            this.labelEmailError.Name = "labelEmailError";
            this.labelEmailError.Size = new System.Drawing.Size(64, 15);
            this.labelEmailError.TabIndex = 5;
            this.labelEmailError.Text = "Email error";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(29, 167);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(200, 23);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "E-mail";
            // 
            // maskedTextBoxPassword
            // 
            this.maskedTextBoxPassword.Location = new System.Drawing.Point(29, 114);
            this.maskedTextBoxPassword.Name = "maskedTextBoxPassword";
            this.maskedTextBoxPassword.PasswordChar = '•';
            this.maskedTextBoxPassword.Size = new System.Drawing.Size(200, 23);
            this.maskedTextBoxPassword.TabIndex = 1;
            this.maskedTextBoxPassword.TextChanged += new System.EventHandler(this.maskedTextBoxPassword_TextChanged);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(29, 37);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(200, 23);
            this.textBoxEmail.TabIndex = 0;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // LoginUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLogin);
            this.Name = "LoginUC";
            this.Size = new System.Drawing.Size(900, 540);
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxLogin;
        private MaskedTextBox maskedTextBoxPassword;
        private TextBox textBoxEmail;
        private Label label1;
        private Label label2;
        private Button buttonLogin;
        private Label labelEmailError;
        private Label labelPasswordError;
    }
}
