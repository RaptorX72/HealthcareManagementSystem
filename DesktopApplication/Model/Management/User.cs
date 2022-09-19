namespace DesktopApplication.Model.Management {
    public class User {
        #region fields
        private string email;
        private string password;
        #endregion

        #region properties
        public Guid Id { get; }

        public string Username { get; }

        public string Email { get { return email; } }

        public string Salt { get; }

        public string Password { get { return password; } }

        public static User Empty { get { return new User(Guid.Empty, String.Empty, String.Empty, String.Empty, String.Empty); } }
        #endregion

        #region constructors
        public User(Guid id, string username, string email, string salt, string password) {
            Id = id;
            Username = username;
            this.email = email;
            Salt = salt;
            this.password = password;
        }

        public User(string username, string email, string password) {
            Id = Guid.NewGuid();
            Username = username;
            this.email = email;
            Salt = CommonTools.GenerateRandomString(128);
            this.password = HashPassword(Salt, password);
        }

        public User(string username, string email, string salt, string password) {
            Id = Guid.NewGuid();
            Username = username;
            this.email = email;
            Salt = salt;
            this.password = password;
        }
        #endregion

        #region Methods
        //TODO: Implement proper hashing algorithm
        public static string HashPassword(string salt, string password) {
            return salt + password;
        }

        public void UpdatePassword(string password) {
            this.password = HashPassword(Salt, password);
        }

        public void UpdateEmail(string email) {
            this.email = email;
        }
        #endregion
    }
}
