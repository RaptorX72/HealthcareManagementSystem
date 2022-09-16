namespace DesktopApplication.Model.Healthcare {
    public class Patient {
        #region fields
        public Guid Id { get; }

        public string FirstName { get; }

        public string MiddleName { get; }

        public string LastName { get; }
        #endregion
        #region constructors
        public Patient(Guid id, string firstName, string middleName, string lastName) {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
        #endregion
    }
}
