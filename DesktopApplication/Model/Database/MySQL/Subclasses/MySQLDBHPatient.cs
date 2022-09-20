using DesktopApplication.Model.Healthcare;
using MySql.Data.MySqlClient;
using System.Text;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHPatient : DBHPatient {
        private MySqlConnection con;

        public MySQLDBHPatient(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
        }

        private Patient FillPatientWithReaderData(MySqlDataReader reader) {
            return new Patient(
                reader.GetGuid("id"),
                reader.GetString("firstName"),
                reader.GetString("middleName"),
                reader.GetString("lastName")
            );
        }

        public override Patient AddPatient(Patient patient) {
            Patient newPatient = patient;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                //check if guid already exists in database
                while (true) {
                    cmd.CommandText = $"SELECT Count(id) FROM Doctor WHERE id = '{newPatient.Id}'";
                    //if yes, generate a new guid
                    if ((Int64)cmd.ExecuteScalar() == 0) break;
                    else newPatient = new Patient(newPatient.FirstName, newPatient.MiddleName, newPatient.LastName);
                }
                cmd.CommandText = "INSERT INTO Doctor (id, firstName, middleName, lastName) VALUES (@id, @firstName, @middleName, @lastName)";
                cmd.Parameters.AddWithValue("@id", newPatient.Id);
                cmd.Parameters.AddWithValue("@firstName", newPatient.Id);
                cmd.Parameters.AddWithValue("@middleName", newPatient.Id);
                cmd.Parameters.AddWithValue("@lastName", newPatient.Id);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return newPatient;
        }

        public override void DeletePatient(Patient patient) {
            DeletePatientById(patient.Id);
        }

        public override void DeletePatientById(Guid patientId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Patient WHERE id = '{patientId}'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override List<Patient> GetAllPatients() {
            List<Patient> patients = new List<Patient>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT * From Patient";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) patients.Add(FillPatientWithReaderData(reader));
                }
                con.Close();
            }
            return patients;
        }

        public override Patient GetPatientById(Guid patientId) {
            Patient patient = Patient.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From Doctor WHERE id = '{patientId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    patient = FillPatientWithReaderData(reader);
                }
                con.Close();
            }
            return patient;
        }

        public override List<Patient> GetPatientsOfDoctor(Doctor doctor) {
            return GetPatientsOfDoctorById(doctor.Id);
        }

        public override List<Patient> GetPatientsOfDoctorById(Guid doctorId) {
            List<Patient> patients = new List<Patient>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT patientId From DoctorPatientTreatment WHERE doctorId = '{doctorId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    List<Guid> doctorIds = new List<Guid>();
                    while (reader.Read()) doctorIds.Add(Guid.Parse(reader.GetString("patientId")));
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * From Doctor WHERE id IN (");
                    for (int i = 0; i < doctorIds.Count; i++) {
                        sb.Append($"'{doctorIds[i].ToString()}'");
                        if (i < doctorIds.Count - 1) sb.Append(", ");
                    }
                    sb.Append(")");
                    cmd.CommandText = sb.ToString();
                    while (reader.Read()) patients.Add(FillPatientWithReaderData(reader));
                }
                con.Close();
            }
            return patients;
        }

        public override void UpdatePatient(Patient patient) {
            UpdatePatientById(patient.Id, patient);
        }

        public override void UpdatePatientById(Guid patientId, Patient patient) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"UPDATE Patient SET firstName = @firstName, middleName = @middleName, lastName = @lastName WHERE id = '{patientId}'";
                cmd.Parameters.AddWithValue("@firstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@middleName", patient.MiddleName);
                cmd.Parameters.AddWithValue("@lastName", patient.LastName);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override void UpdatePatients(List<Patient> patients) {
            foreach (Patient patient in patients)  UpdatePatient(patient);
        }
    }
}
