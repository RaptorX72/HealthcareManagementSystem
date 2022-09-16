namespace DesktopApplication.Model.Healthcare {
    public class Doctor {
        #region fields
        public Guid Id { get; }

        public string FirstName { get; }

        public string MiddleName { get; }

        public string LastName { get; }

        public Guid SpecialityId { get; }
        #endregion

        #region constructors
        public Doctor(Guid id, string firstName, string middleName, string lastName, Guid specialityId) {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            SpecialityId = specialityId;
        }
        #endregion
    }
}