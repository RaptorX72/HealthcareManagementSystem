namespace DesktopApplication.Model.Management {
    public class User {
        #region fields
        public Guid Id { get; }

        public string Username { get; }

        public string Email { get; }

        public string Salt { get; }

        public string Password { get; }
        #endregion

        #region constructors
        public User(Guid id, string username, string email, string salt, string password) {
            Id = id;
            Username = username;
            Email = email;
            Salt = salt;
            Password = password;
        }

        public User(string username, string email, string password) {
            Id = Guid.NewGuid();
            Salt = CommonTools.GenerateRandomString(128);
            Username = username;
            Email = email;
            Password = HashPassword(Salt, password);
        }
        #endregion

        #region Methods
        //TODO: Implement proper hashing algorithm
        public static string HashPassword(string salt, string password) {
            return salt + password;
        }
        #endregion
    }
}
