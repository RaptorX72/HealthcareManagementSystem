namespace DesktopApplication.Model.Database {
    public interface IDBHandler {
        public DBHAppointment Appointment();

        public DBHDoctor Doctor();

        public DBHMedicalNote MedicalNote();

        public DBHMedicalRecord MedicalRecord();

        public DBHMedicalTest MedicalTest();

        public DBHMedication Medication();

        public DBHPatient Patient();

        public DBHPerscription Perscription();

        public DBHSurgery Surgery();

        public DBHUser User();
    }
}
