using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHPerscription : DBHPerscription {
        private MySqlConnection con;

        public MySQLDBHPerscription(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
        }

        public override Perscription AddPerscription(Perscription perscription) {
            throw new NotImplementedException();
        }

        public override void DeleteAllPerscriptionsByDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override void DeleteAllPerscriptionsByDoctorId(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override void DeleteAllPerscriptionsByPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override void DeleteAllPerscriptionsByPatientId(Guid patientId) {
            throw new NotImplementedException();
        }

        public override void DeletePerscription(Perscription Perscription) {
            throw new NotImplementedException();
        }

        public override void DeletePerscriptionById(Guid perscriptionId) {
            throw new NotImplementedException();
        }

        public override List<Perscription> GetAllPerscriptions() {
            throw new NotImplementedException();
        }

        public override List<Perscription> GetAllPerscriptionsByDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override List<Perscription> GetAllPerscriptionsByDoctorId(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override List<Perscription> GetAllPerscriptionsByPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override List<Perscription> GetAllPerscriptionsByPatientId(Guid patientId) {
            throw new NotImplementedException();
        }

        public override Perscription GetPerscriptionById(Guid perscriptionId) {
            throw new NotImplementedException();
        }

        public override void UpdateAllPerscriptionsByDoctor(Doctor doctor, List<Perscription> Perscriptions) {
            throw new NotImplementedException();
        }

        public override void UpdateAllPerscriptionsByDoctorId(Guid doctorId, List<Perscription> Perscriptions) {
            throw new NotImplementedException();
        }

        public override void UpdateAllPerscriptionsByPatient(Patient patient, List<Perscription> Perscriptions) {
            throw new NotImplementedException();
        }

        public override void UpdateAllPerscriptionsByPatientId(Guid patientId, List<Perscription> Perscriptions) {
            throw new NotImplementedException();
        }

        public override void UpdatePerscription(Perscription Perscription) {
            throw new NotImplementedException();
        }

        public override void UpdatePerscriptionById(Guid perscriptionId, Perscription Perscription) {
            throw new NotImplementedException();
        }
    }
}
