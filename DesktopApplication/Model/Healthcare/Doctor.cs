namespace DesktopApplication.Model.Healthcare {
    public class Doctor {
        #region fields
        public Guid Id { get; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Guid SpecialityId { get; }

        public static Doctor Empty { get { return new Doctor(Guid.Empty, String.Empty, String.Empty, String.Empty, Guid.Empty); } }

        public bool IsEmpty { get { return Id == Guid.Empty; } }
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