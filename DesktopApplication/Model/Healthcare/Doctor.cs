namespace DesktopApplication.Model.Healthcare {
    public class Doctor {
        #region fields
        public Guid Id { get; }

        public string FirstName { get; }

        public string MiddleName { get; }

        public string LastName { get; }

        public Guid SpecialityId { get; }

        public static Doctor Empty { get { return new Doctor(Guid.Empty, String.Empty, String.Empty, String.Empty, Guid.Empty); } }
        #endregion

        #region constructors
        public Doctor(Guid id, string firstName, string middleName, string lastName, Guid specialityId) {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            SpecialityId = specialityId;
        }

        public Doctor(string firstName, string middleName, string lastName, Guid specialityId) {
            Id = Guid.NewGuid();
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            SpecialityId = specialityId;
        }
        #endregion
    }
}