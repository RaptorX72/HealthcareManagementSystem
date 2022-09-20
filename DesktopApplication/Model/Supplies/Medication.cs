namespace DesktopApplication.Model.Supplies {
    public class Medication {
        #region fields
        public Guid Id { get; }

        public string Name { get; }

        public string MainIngedient { get; }

        public double Dosage { get; }

        public double Size { get; }

        public UnitOfMeasurement UnitOfMeasurement { get; }

        public static Medication Empty { get { return new Medication(Guid.Empty, String.Empty, String.Empty, 0, 0, UnitOfMeasurement.g); } }
        #endregion

        #region constructors
        public Medication(Guid id, string name, string mainIngedient, double dosage, double size, UnitOfMeasurement unitOfMeasurement) {
            Id = id;
            Name = name;
            MainIngedient = mainIngedient;
            Dosage = dosage;
            Size = size;
            UnitOfMeasurement = unitOfMeasurement;
        }

        public Medication(string name, string mainIngedient, double dosage, double size, UnitOfMeasurement unitOfMeasurement) {
            Id = Guid.NewGuid();
            Name = name;
            MainIngedient = mainIngedient;
            Dosage = dosage;
            Size = size;
            UnitOfMeasurement = unitOfMeasurement;
        }
        #endregion
    }
}
