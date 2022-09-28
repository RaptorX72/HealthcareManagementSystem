using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;
using System.Text;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHMedicalNote : DBHMedicalNote {
        private MySqlConnection con;

        public MySQLDBHMedicalNote(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
        }

        private MedicalNote FillMedicalNoteWithReaderData(MySqlDataReader reader) {
            return new MedicalNote(
                reader.GetGuid("id"),
                reader.GetGuid("appointmentId"),
                reader.GetString("note")
            );
        }

        public override MedicalNote AddMedicalNote(MedicalNote medicalNote) {
            MedicalNote newMedicalNote = medicalNote;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                //check if guid already exists in database
                while (true) {
                    cmd.CommandText = $"SELECT COUNT(id) FROM MedicalNote WHERE id = '{newMedicalNote.Id}'";
                    //if yes, generate a new guid
                    if ((Int64)cmd.ExecuteScalar() == 0) break;
                    else newMedicalNote = new MedicalNote(newMedicalNote.AppointmentId, newMedicalNote.Note);
                }
                cmd.CommandText = "INSERT INTO MedicalNote (id, appointmentId, note) VALUES (@id, @appointmentId, @note)";
                cmd.Parameters.AddWithValue("@id", newMedicalNote.Id);
                cmd.Parameters.AddWithValue("@appointmentId", newMedicalNote.AppointmentId);
                cmd.Parameters.AddWithValue("@note", newMedicalNote.Note);
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
            return newMedicalNote;
        }

        public override void DeleteAllMedicalNotesByDoctor(Doctor doctor) {
            DeleteAllMedicalNotesByDoctorId(doctor.Id);
        }

        public override void DeleteAllMedicalNotesByDoctorId(Guid doctorId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                List<Appointment> appointments = DBHandler.Appointment.GetAllAppointmentsByDoctorId(doctorId);
                StringBuilder sb = new StringBuilder();
                sb.Append("DELETE FROM MedicalNote WHERE appointmentId IN (");
                for (int i = 0; i < appointments.Count; i++) {
                    sb.Append($"'{appointments[i].Id}'");
                    if (i < appointments.Count - 1) sb.Append(", ");
                }
                sb.Append(")");
                cmd.CommandText = sb.ToString();
                con.Open();
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
        }

        public override void DeleteAllMedicalNotesOfPatient(Patient patient) {
            DeleteAllMedicalNotesOfPatientById(patient.Id);
        }

        public override void DeleteAllMedicalNotesOfPatientById(Guid patientId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                List<Appointment> appointments = DBHandler.Appointment.GetAllAppointmentsByPatientId(patientId);
                StringBuilder sb = new StringBuilder();
                sb.Append("DELETE FROM MedicalNote WHERE appointmentId IN (");
                for (int i = 0; i < appointments.Count; i++) {
                    sb.Append($"'{appointments[i].Id}'");
                    if (i < appointments.Count - 1) sb.Append(", ");
                }
                sb.Append(")");
                cmd.CommandText = sb.ToString();
                con.Open();
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
        }

        public override void DeleteMedicalNote(MedicalNote medicalNote) {
            DeleteMedicalNoteById(medicalNote.Id);
        }

        public override void DeleteMedicalNoteById(Guid medicalNoteId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM MedicalNote WHERE id = '{medicalNoteId}'";
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
        }

        public override List<MedicalNote> GetAllMedicalNotes() {
            List<MedicalNote> medicalNotes = new List<MedicalNote>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT * FROM MedicalNote";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) medicalNotes.Add(FillMedicalNoteWithReaderData(reader));
                }
                con.Close();
            }
            return medicalNotes;
        }

        public override List<MedicalNote> GetAllMedicalNotesByDoctor(Doctor doctor) {
            return GetAllMedicalNotesByDoctorId(doctor.Id);
        }

        public override List<MedicalNote> GetAllMedicalNotesByDoctorId(Guid doctorId) {
            List<MedicalNote> medicalNotes = new List<MedicalNote>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                List<Appointment> appointments = DBHandler.Appointment.GetAllAppointmentsByDoctorId(doctorId);
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM MedicalNote WHERE appointmentId IN (");
                for (int i = 0; i < appointments.Count; i++) {
                    sb.Append($"'{appointments[i].Id}'");
                    if (i < appointments.Count - 1) sb.Append(", ");
                }
                sb.Append(")");
                cmd.CommandText = sb.ToString();
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) medicalNotes.Add(FillMedicalNoteWithReaderData(reader));
                }
                con.Close();
            }
            return medicalNotes;
        }

        public override List<MedicalNote> GetAllMedicalNotesOfPatient(Patient patient) {
            return GetAllMedicalNotesOfPatientId(patient.Id);
        }

        public override List<MedicalNote> GetAllMedicalNotesOfPatientId(Guid patientId) {
            List<MedicalNote> medicalNotes = new List<MedicalNote>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                List<Appointment> appointments = DBHandler.Appointment.GetAllAppointmentsByPatientId(patientId);
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM MedicalNote WHERE appointmentId IN (");
                for (int i = 0; i < appointments.Count; i++) {
                    sb.Append($"'{appointments[i].Id}'");
                    if (i < appointments.Count - 1) sb.Append(", ");
                }
                sb.Append(")");
                cmd.CommandText = sb.ToString();
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) medicalNotes.Add(FillMedicalNoteWithReaderData(reader));
                }
                con.Close();
            }
            return medicalNotes;
        }

        public override MedicalNote GetMedicalNoteByAppointment(Appointment appointment) {
            return GetMedicalNoteByAppointmentId(appointment.Id);
        }

        public override MedicalNote GetMedicalNoteByAppointmentId(Guid appointmentId) {
            MedicalNote medicalNote = MedicalNote.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * FROM MedicalNote WHERE appointmentId = '{appointmentId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    if (reader.HasRows) medicalNote = FillMedicalNoteWithReaderData(reader);
                }
                con.Close();
            }
            return medicalNote;
        }

        public override MedicalNote GetMedicalNoteById(Guid medicalNoteId) {
            MedicalNote medicalNote = MedicalNote.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * FROM MedicalNote WHERE id = '{medicalNoteId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    if (reader.HasRows) medicalNote = FillMedicalNoteWithReaderData(reader);
                }
                con.Close();
            }
            return medicalNote;
        }

        public override void UpdateMedicalNote(MedicalNote medicalNote) {
            UpdateMedicalNoteById(medicalNote.Id, medicalNote);
        }

        public override void UpdateMedicalNoteById(Guid medicalNoteId, MedicalNote medicalNote) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"UPDATE MedicalNote SET appointmentId = @appointmentId, note = @note WHERE id = '{medicalNoteId}'";
                cmd.Parameters.AddWithValue("@appointerId", medicalNote.AppointmentId);
                cmd.Parameters.AddWithValue("@note", medicalNote.Note);
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
        }

        public override void UpdateMedicalNotes(List<MedicalNote> medicalNotes) {
            foreach (MedicalNote medicalNote in medicalNotes) UpdateMedicalNote(medicalNote);
        }
    }
}
