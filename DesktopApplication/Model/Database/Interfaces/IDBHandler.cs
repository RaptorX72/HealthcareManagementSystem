namespace DesktopApplication.Model.Database.Interfaces {
    public interface IDBHandler {
        public static IDBHandler? Instance { get; }

        public static IDBHandlerAppointment? Appointment { get; }

        public static IDBHandlerDoctor? Doctor { get; }

        public static IDBHandlerMedicalNote? MedicalNote { get; }

        public static IDBHandlerMedicalRecord? MedicalRecord { get; }

        public static IDBHandlerMedicalTest? MedicalTest { get; }

        public static IDBHandlerMedication? Medication { get; }

        public static IDBHandlerPatient? Patient { get; }

        public static IDBHandlerPerscription? Perscription { get; }

        public static IDBHandlerSurgery? Surgery { get; }

        public static IDBHandlerUser? User { get; }
    }
}
