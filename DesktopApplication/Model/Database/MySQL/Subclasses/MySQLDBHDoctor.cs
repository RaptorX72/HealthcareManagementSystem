using DesktopApplication.Model.Healthcare;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHDoctor : DBHDoctor {
        private MySqlConnection con;

        public MySQLDBHDoctor(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
        }

        public override Doctor AddDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override void DeleteDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override void DeleteDoctorById(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override List<Doctor> GetAllDoctors() {
            throw new NotImplementedException();
        }

        public override Doctor GetDoctorById(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override List<Doctor> GetDoctorsBySpecialityId(int specialityId) {
            throw new NotImplementedException();
        }

        public override List<Doctor> GetDoctorsOfPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override List<Doctor> GetDoctorsOfPatientById(Guid patientId) {
            throw new NotImplementedException();
        }

        public override void UpdateDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override void UpdateDoctorById(Guid doctorId, Doctor doctor) {
            throw new NotImplementedException();
        }

        public override void UpdateDoctorsOfPatient(Patient patient, List<Doctor> doctor) {
            throw new NotImplementedException();
        }

        public override void UpdateDoctorsOfPatientById(Guid patientId, List<Doctor> doctor) {
            throw new NotImplementedException();
        }
    }
}
