namespace DesktopApplication.Model.Supplies {
    public class Medication {
        #region fields
        public Guid Id { get; }

        public string Name { get; }

        public string MainIngedient { get; }

        public double Dosage { get; }

        public double Size { get; }

        public UnitOfMeasurement UnitOfMeasurement { get; }
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
        #endregion
    }
}
