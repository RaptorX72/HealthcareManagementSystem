using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHSurgery : DBHSurgery {
        private MySqlConnection con;

        public MySQLDBHSurgery(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
        }

        private Surgery FillSurgeryWithReaderData(MySqlDataReader reader) {
            return new Surgery(
                reader.GetGuid("id"),
                reader.GetGuid("appointerId"),
                reader.GetGuid("surgeonId"),
                reader.GetGuid("patientId"),
                reader.GetDateTime("surgeryDate"),
                reader.GetString("note"),
                (SurgeryOutcome)reader.GetInt32("outcomeId")
            );
        }

        public override Surgery AddSurgery(Surgery surgery) {
            Surgery newSurgery = surgery;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                //check if guid already exists in database
                while (true) {
                    cmd.CommandText = $"SELECT Count(id) FROM Surgery WHERE id = '{newSurgery.Id}'";
                    //if yes, generate a new guid
                    if ((Int64)cmd.ExecuteScalar() == 0) break;
                    else newSurgery = new Surgery(newSurgery.AppointerDoctorId, newSurgery.SurgeonDoctorId, newSurgery.PatientId, newSurgery.Date, newSurgery.Notes, newSurgery.Outcome);
                }
                cmd.CommandText = "INSERT INTO Surgery (id, appointerId, surgeonId, patientId, surgeryDate, note, outcomeId) VALUES (@id, @appointerId, @surgeonId, @patientId, @surgeryDate, @note, @outcomeId)";
                cmd.Parameters.AddWithValue("@id", newSurgery.Id);
                cmd.Parameters.AddWithValue("@appointerId", newSurgery.AppointerDoctorId);
                cmd.Parameters.AddWithValue("@surgeonId", newSurgery.SurgeonDoctorId);
                cmd.Parameters.AddWithValue("@patientId", newSurgery.PatientId);
                cmd.Parameters.AddWithValue("@surgeryDate", newSurgery.Date);
                cmd.Parameters.AddWithValue("@note", newSurgery.Notes);
                cmd.Parameters.AddWithValue("@outcomeId", (int)newSurgery.Outcome);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return newSurgery;
        }

        public override void DeleteAllSurgeriesByAppointerDoctor(Doctor doctor) {
            DeleteAllSurgeriesByAppointerDoctorId(doctor.Id);
        }

        public override void DeleteAllSurgeriesByAppointerDoctorId(Guid doctorId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Surgery WHERE appointerId = '{doctorId}'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override void DeleteAllSurgeriesByDate(DateTime date) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Surgery WHERE surgeryDate = {date}";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override void DeleteAllSurgeriesByOutcome(SurgeryOutcome outcome) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Surgery WHERE outcomeId = '{(int)outcome}'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override void DeleteAllSurgeriesBySurgeon(Doctor doctor) {
            DeleteAllSurgeriesBySurgeonId(doctor.Id);
        }

        public override void DeleteAllSurgeriesBySurgeonId(Guid doctorId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Surgery WHERE surgeonId = '{doctorId}'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override void DeleteAllSurgeriesOfPatient(Patient patient) {
            DeleteAllSurgeriesOFPatientById(patient.Id);
        }

        public override void DeleteAllSurgeriesOFPatientById(Guid patientId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Surgery WHERE patientId = '{patientId}'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override void DeleteSurgery(Surgery surgery) {
            DeleteSurgeryById(surgery.Id);
        }

        public override void DeleteSurgeryById(Guid surgeryId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Surgery WHERE id = '{surgeryId}'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override List<Surgery> GetAllSurgeries() {
            List<Surgery> surgeries = new List<Surgery>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT * From Surgery";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) surgeries.Add(FillSurgeryWithReaderData(reader));
                }
                con.Close();
            }
            return surgeries;
        }

        public override List<Surgery> GetAllSurgeriesByAppointerDoctor(Doctor doctor) {
            return GetAllSurgeriesByAppointerDoctorId(doctor.Id);
        }

        public override List<Surgery> GetAllSurgeriesByAppointerDoctorId(Guid doctorId) {
            List<Surgery> surgeries = new List<Surgery>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From Surgery WHERE appointerId = '{doctorId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) surgeries.Add(FillSurgeryWithReaderData(reader));
                }
                con.Close();
            }
            return surgeries;
        }

        public override List<Surgery> GetAllSurgeriesByDate(DateTime date) {
            List<Surgery> surgeries = new List<Surgery>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From Surgery WHERE surgeryDate = {date}";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) surgeries.Add(FillSurgeryWithReaderData(reader));
                }
                con.Close();
            }
            return surgeries;
        }

        public override List<Surgery> GetAllSurgeriesByOutcome(SurgeryOutcome outcome) {
            List<Surgery> surgeries = new List<Surgery>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From Surgery WHERE outcomeId = '{(int)outcome}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) surgeries.Add(FillSurgeryWithReaderData(reader));
                }
                con.Close();
            }
            return surgeries;
        }

        public override List<Surgery> GetAllSurgeriesBySurgeon(Doctor doctor) {
            return GetAllSurgeriesBySurgeonId(doctor.Id);
        }

        public override List<Surgery> GetAllSurgeriesBySurgeonId(Guid doctorId) {
            List<Surgery> surgeries = new List<Surgery>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From Surgery WHERE surgeonId = '{doctorId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) surgeries.Add(FillSurgeryWithReaderData(reader));
                }
                con.Close();
            }
            return surgeries;
        }

        public override List<Surgery> GetAllSurgeriesOfPatient(Patient patient) {
            return GetAllSurgeriesOfPatientById(patient.Id);
        }

        public override List<Surgery> GetAllSurgeriesOfPatientById(Guid patientId) {
            List<Surgery> surgeries = new List<Surgery>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From Surgery WHERE patientId = '{patientId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) surgeries.Add(FillSurgeryWithReaderData(reader));
                }
                con.Close();
            }
            return surgeries;
        }

        public override Surgery GetSurgeryById(Guid surgeryId) {
            Surgery surgery = Surgery.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From Surgery WHERE id = '{surgeryId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    surgery = FillSurgeryWithReaderData(reader);
                }
                con.Close();
            }
            return surgery;
        }

        public override void UpdateSurgeries(List<Surgery> surgeries) {
            foreach (Surgery surgery in surgeries) UpdateSurgery(surgery);
        }

        public override void UpdateSurgery(Surgery surgery) {
            UpdateSurgeryById(surgery.Id, surgery);
        }

        public override void UpdateSurgeryById(Guid surgeryId, Surgery surgery) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"UPDATE Surgery SET appointerId = @appointerId, surgeonId = @surgeonId, patientId = @patientId, surgeryDate = @surgeryDate, note = @note, outcomeId = @outcomeId WHERE id = '{surgeryId}'";
                cmd.Parameters.AddWithValue("@appointerId", surgery.AppointerDoctorId);
                cmd.Parameters.AddWithValue("@surgeonId", surgery.SurgeonDoctorId);
                cmd.Parameters.AddWithValue("@patientId", surgery.PatientId);
                cmd.Parameters.AddWithValue("@surgeryDate", surgery.Date);
                cmd.Parameters.AddWithValue("@note", surgery.Notes);
                cmd.Parameters.AddWithValue("@outcomeId", (int)surgery.Outcome);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
