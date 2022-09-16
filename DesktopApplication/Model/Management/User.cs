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
        #endregion
    }
}
