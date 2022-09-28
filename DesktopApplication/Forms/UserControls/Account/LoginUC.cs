using DesktopApplication.Model;
using DesktopApplication.Model.Database;
using DesktopApplication.Model.Management;

namespace DesktopApplication {
    public partial class LoginUC : UserControl {
        private enum PasswordStatus {
            TooShort,
            NoLowercase,
            NoUppercase,
            NoNumber,
            NoSpecialCharacter,
            Correct
        }

        private Main parentForm;

        public LoginUC(Main parentForm) {
            this.parentForm = parentForm;
            InitializeComponent();
            labelEmailError.Text = "";
            labelPasswordError.Text = "";
            InitializePreferences();
        }
        #region UI design
        private void InitializePreferences() {
            //dummy code for testing
            Preferences.SetTheme(Theme.ColorTheme.Dark);

            labelEmailError.ForeColor = Preferences.Theme.ErrorColor;
            labelPasswordError.ForeColor = Preferences.Theme.ErrorColor;
            /*
            //main form
            this.BackColor = Preferences.Theme.BackgroundLevelOne;

            //group box
            groupBoxLogin.BackColor = Preferences.Theme.BackgroundLevelOne;
            groupBoxLogin.ForeColor = Preferences.Theme.ForegroundLevelOne;
            for (int i = 0; i < groupBoxLogin.Controls.Count; i++) {
                groupBoxLogin.Controls[i].BackColor = Preferences.Theme.BackgroundLevelTwo;
                groupBoxLogin.Controls[i].ForeColor = Preferences.Theme.ForegroundLevelTwo;
            }*/
        }
        #endregion
        private void textBoxEmail_TextChanged(object sender, EventArgs e) {
            if (textBoxEmail.Text.Length == 0) return;
            if (!ValidateEmail(textBoxEmail.Text)) labelEmailError.Text = "Email format incorrect!";
            else labelEmailError.Text = "";
        }

        private bool ValidateEmail(string text) {
            string[] atParts = text.Split('@');
            if (atParts.Length != 2) return false;
            if (atParts[0].Length == 0) return false;
            if (!atParts[1].Contains('.')) return false;
            string[] domainParts = atParts[1].Split('.');
            foreach (string item in domainParts) if (item.Length == 0) return false;
            foreach (char item in domainParts[domainParts.Length - 1]) if (!Char.IsLetter(item)) return false;
            return true;
        }

        private string PasswordStatusMessage(PasswordStatus status) {
            string text = "";
            switch (status) {
                case PasswordStatus.TooShort:
                    text = $"Too short, minimum {Globals.MinimumPasswordLength} characters needed";
                    break;
                case PasswordStatus.NoLowercase:
                    text = "No lowercase character present!";
                    break;
                case PasswordStatus.NoUppercase:
                    text = "No uppercase character present!";
                    break;
                case PasswordStatus.NoNumber:
                    text = "No number character present!";
                    break;
                case PasswordStatus.NoSpecialCharacter:
                    text = "No special character present!";
                    break;
            }
            return text;
        }

    private void maskedTextBoxPassword_TextChanged(object sender, EventArgs e) {
            if (maskedTextBoxPassword.Text.Length == 0) return;
            labelPasswordError.Text = PasswordStatusMessage(ValidatePasswordStatus(maskedTextBoxPassword.Text));
        }

        private PasswordStatus ValidatePasswordStatus(string text) {
            if (text.Length < Globals.MinimumPasswordLength) return PasswordStatus.TooShort;

            bool digit = false;
            bool lowerCase = false;
            bool upperCase = false;
            bool specialCharacter = false;

            for (int i = 0; i < text.Length; i++) {
                if (Char.IsDigit(text[i])) {
                    digit = true;
                    break;
                }
            }
            if (!digit) return PasswordStatus.NoNumber;

            for (int i = 0; i < text.Length; i++) {
                if (!Char.IsLetter(text[i])) continue;
                if (Char.IsUpper(text[i])) {
                    upperCase = true;
                    break;
                }
            }
            if (!upperCase) return PasswordStatus.NoUppercase;

            for (int i = 0; i < text.Length; i++) {
                if (!Char.IsLetter(text[i])) continue;
                if (Char.IsLower(text[i])) {
                    lowerCase = true;
                    break;
                }
            }
            if (!lowerCase) return PasswordStatus.NoLowercase;

            for (int i = 0; i < text.Length; i++) {
                if (!Char.IsLetterOrDigit(text[i])) {
                    specialCharacter = true;
                    break;
                }
            }
            if (!specialCharacter) return PasswordStatus.NoSpecialCharacter;

            return PasswordStatus.Correct;
        }

        private void buttonLogin_Click(object sender, EventArgs e) {
            bool emailValid = ValidateEmail(textBoxEmail.Text);
            PasswordStatus passwordValid = ValidatePasswordStatus(maskedTextBoxPassword.Text);
            if (emailValid && passwordValid == PasswordStatus.Correct) {
                User user = User.Empty;
                try {
                    user = DBHandler.User.LoginUser(textBoxEmail.Text, maskedTextBoxPassword.Text);
                } catch (GenericDatabaseException ex) {
                    MessageBox.Show(ex.Message);
                } catch (InvalidEmailException) {
                    MessageBox.Show("Email incorrect");
                } catch (InvalidPasswordException) {
                    MessageBox.Show("Password incorrect");
                } finally {
                    if (user.Id != Guid.Empty) {
                        parentForm.SetUser(user);
                        Dispose();
                    }
                }
            } else {
                if (!emailValid) labelEmailError.Text = "Email format incorrect!";
                if (passwordValid != PasswordStatus.Correct) labelPasswordError.Text = PasswordStatusMessage(passwordValid);
            }
        }
    }
}
