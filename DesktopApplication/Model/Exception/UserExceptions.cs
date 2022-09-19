namespace DesktopApplication.Model {
    public class InvalidEmailException : Exception {
        public InvalidEmailException() { }

        public InvalidEmailException(string message) : base(message) { }

        public InvalidEmailException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class InvalidPasswordException : Exception {
        public InvalidPasswordException() { }

        public InvalidPasswordException(string message) : base(message) { }

        public InvalidPasswordException(string message, Exception innerException) : base(message, innerException) { }
    }
}
