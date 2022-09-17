using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHSurgery : DBHSurgery {
        private MySqlConnection con;

        public MySQLDBHSurgery(MySqlConnection con) {
            this.con = con;
        }

        public override Surgery AddSurgery(Surgery surgery) {
            throw new NotImplementedException();
        }

        public override void DeleteAllSurgeriesByAppointerDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override void DeleteAllSurgeriesByAppointerDoctorId(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override void DeleteAllSurgeriesByDate(DateTime date) {
            throw new NotImplementedException();
        }

        public override void DeleteAllSurgeriesByOutcome(SurgeryOutcome outcome) {
            throw new NotImplementedException();
        }

        public override void DeleteAllSurgeriesBySurgeon(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override void DeleteAllSurgeriesBySurgeonId(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override void DeleteAllSurgeriesOfPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override void DeleteAllSurgeriesOFPatientById(Guid patientId) {
            throw new NotImplementedException();
        }

        public override void DeleteSurgery(Surgery Surgery) {
            throw new NotImplementedException();
        }

        public override void DeleteSurgeryById(Guid surgeryId) {
            throw new NotImplementedException();
        }

        public override List<Surgery> GetAllSurgeries() {
            throw new NotImplementedException();
        }

        public override List<Surgery> GetAllSurgeriesByAppointerDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override List<Surgery> GetAllSurgeriesByAppointerDoctorId(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override List<Surgery> GetAllSurgeriesByDate(DateTime date) {
            throw new NotImplementedException();
        }

        public override List<Surgery> GetAllSurgeriesByOutcome(SurgeryOutcome outcome) {
            throw new NotImplementedException();
        }

        public override List<Surgery> GetAllSurgeriesBySurgeon(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override List<Surgery> GetAllSurgeriesBySurgeonId(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override List<Surgery> GetAllSurgeriesOfPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override List<Surgery> GetAllSurgeriesOfPatientById(Guid patientId) {
            throw new NotImplementedException();
        }

        public override Surgery GetSurgeryById(Guid surgeryId) {
            throw new NotImplementedException();
        }

        public override void UpdateAllSurgeriesByAppointerDoctor(Doctor doctor, List<Surgery> Surgeries) {
            throw new NotImplementedException();
        }

        public override void UpdateAllSurgeriesByAppointerDoctorId(Guid doctorId, List<Surgery> Surgeries) {
            throw new NotImplementedException();
        }

        public override void UpdateAllSurgeriesByDate(DateTime date, List<Surgery> Surgeries) {
            throw new NotImplementedException();
        }

        public override void UpdateAllSurgeriesByOutcome(SurgeryOutcome outcome, List<Surgery> Surgeries) {
            throw new NotImplementedException();
        }

        public override void UpdateAllSurgeriesBySurgeon(Doctor doctor, List<Surgery> Surgeries) {
            throw new NotImplementedException();
        }

        public override void UpdateAllSurgeriesBySurgeonId(Guid doctorId, List<Surgery> Surgeries) {
            throw new NotImplementedException();
        }

        public override void UpdateAllSurgeriesOfPatient(Patient patient, List<Surgery> Surgeries) {
            throw new NotImplementedException();
        }

        public override void UpdateAllSurgeriesOfPatientById(Guid patientId, List<Surgery> Surgeries) {
            throw new NotImplementedException();
        }

        public override void UpdateSurgery(Surgery Surgery) {
            throw new NotImplementedException();
        }

        public override void UpdateSurgeryById(Guid surgeryId, Surgery Surgery) {
            throw new NotImplementedException();
        }
    }
}
