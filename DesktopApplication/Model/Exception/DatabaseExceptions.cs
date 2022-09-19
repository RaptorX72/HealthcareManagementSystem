namespace DesktopApplication.Model {
    public class GenericDatabaseException : Exception {
        public GenericDatabaseException() {
        }

        public GenericDatabaseException(string? message) : base(message) {
        }

        public GenericDatabaseException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
