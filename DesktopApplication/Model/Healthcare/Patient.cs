namespace DesktopApplication.Model.Healthcare {
    public class Patient {
        #region fields
        public Guid Id { get; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public static Patient Empty { get { return new Patient(Guid.Empty, String.Empty, String.Empty, String.Empty); } }

        public bool IsEmpty { get { return Id == Guid.Empty; } }
        #endregion

        #region constructors
        public Patient(Guid id, string firstName, string middleName, string lastName) {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public Patient(string firstName, string middleName, string lastName) {
            Id = Guid.NewGuid();
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
        #endregion
    }
}
