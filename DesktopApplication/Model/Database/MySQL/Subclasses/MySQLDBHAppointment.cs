using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHAppointment : DBHAppointment {
        private MySqlConnection con;

        public MySQLDBHAppointment(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
        }

        private Appointment FillAppointmentWithReaderData(MySqlDataReader reader) {
            return new Appointment(
                Guid.Parse(reader.GetString("id")),
                reader.GetDateTime("appointmentDate"),
                Guid.Parse(reader.GetString("doctorId")),
                Guid.Parse(reader.GetString("patientId")),
                reader.GetString("note")
            );
        }
        //TODO: Finish speciality functions
        public override Appointment AddAppointment(Appointment appointment) {
            Appointment newAppointment = appointment;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                //check if guid already exists in database
                while (true) {
                    cmd.CommandText = $"SELECT Count(id) FROM Appointment WHERE id = '{appointment.Id}'";
                    //if yes, generate a new guid
                    if ((Int64)cmd.ExecuteScalar() == 0) break;
                    else newAppointment = new Appointment(newAppointment.Date, newAppointment.DoctorId, newAppointment.PatientId, newAppointment.Notes);
                }
                cmd.CommandText = "INSERT INTO Appointment (id, appointmentDate, doctorId, patientId, note) VALUES (@id, @date, @doctorId, @patientId, @note)";
                cmd.Parameters.AddWithValue("@id", newAppointment.Id);
                cmd.Parameters.AddWithValue("@date", newAppointment.Date);
                cmd.Parameters.AddWithValue("@doctorId", newAppointment.DoctorId);
                cmd.Parameters.AddWithValue("@patientId", newAppointment.PatientId);
                cmd.Parameters.AddWithValue("@note", newAppointment.Notes);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return newAppointment;
        }

        public override void DeleteAllAppointmentsByDate(DateTime date) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Appointment WHERE appointmentDate = {date}";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override void DeleteAllAppointmentsByDoctor(Doctor doctor) {
            DeleteAllAppointmentsByDoctorId(doctor.Id);
        }

        public override void DeleteAllAppointmentsByDoctorId(Guid doctorId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Appointment WHERE doctorId = '{doctorId}'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override void DeleteAllAppointmentsByPatient(Patient patient) {
            DeleteAllAppointmentsByPatientId(patient.Id);
        }

        public override void DeleteAllAppointmentsByPatientId(Guid patientId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Appointment WHERE patientId = '{patientId}'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override void DeleteAllAppointmentsBySpecialityId(Guid specialityId) {
            throw new NotImplementedException();
        }

        public override void DeleteAppointment(Appointment appointment) {
            DeleteAppointmentById(appointment.Id);
        }

        public override void DeleteAppointmentById(Guid appointmentId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Appointment WHERE id = '{appointmentId}'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override List<Appointment> GetAllAppointments() {
            List<Appointment> appointments = new List<Appointment>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT * From Appointment";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) appointments.Add(FillAppointmentWithReaderData(reader));
                }
                con.Close();
            }
            return appointments;
        }

        public override List<Appointment> GetAllAppointmentsByDate(DateTime date) {
            List<Appointment> appointments = new List<Appointment>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From Appointment WHERE appointmentDate = {date}";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) appointments.Add(FillAppointmentWithReaderData(reader));
                }
                con.Close();
            }
            return appointments;
        }

        public override List<Appointment> GetAllAppointmentsByDoctor(Doctor doctor) {
            return GetAllAppointmentsByDoctorId(doctor.Id);
        }

        public override List<Appointment> GetAllAppointmentsByDoctorId(Guid doctorId) {
            List<Appointment> appointments = new List<Appointment>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From Appointment WHERE doctorId = '{doctorId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) appointments.Add(FillAppointmentWithReaderData(reader));
                }
                con.Close();
            }
            return appointments;
        }

        public override List<Appointment> GetAllAppointmentsByPatient(Patient patient) {
            return GetAllAppointmentsByPatientId(patient.Id);
        }

        public override List<Appointment> GetAllAppointmentsByPatientId(Guid patientId) {
            List<Appointment> appointments = new List<Appointment>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From Appointment WHERE patientId = '{patientId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) appointments.Add(FillAppointmentWithReaderData(reader));
                }
                con.Close();
            }
            return appointments;
        }

        public override List<Appointment> GetAllAppointmentsBySpecialityId(Guid specialityId) {
            throw new NotImplementedException();
        }

        public override Appointment GetAppointmentById(Guid appointmentId) {
            Appointment appointment = Appointment.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From User WHERE id = '{appointmentId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    appointment = FillAppointmentWithReaderData(reader);
                }
                con.Close();
            }
            return appointment;
        }

        public override void UpdateAllAppointmentsByDate(DateTime date, List<Appointment> appointments) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                foreach (Appointment appointment in appointments) {
                    if (appointment.Date != date) continue;
                    cmd.CommandText = $"UPDATE Appointment SET appointmentDate = @date, doctorId = @doctorId, patientId = @patientId, note = @note WHERE id = '{appointment.Id}' AND appointmentDate = {appointment.Date}";
                    cmd.Parameters.AddWithValue("@date", appointment.Date);
                    cmd.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                    cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
                    cmd.Parameters.AddWithValue("@note", appointment.Notes);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public override void UpdateAllAppointmentsByDoctor(Doctor doctor, List<Appointment> appointments) {
            UpdateAllAppointmentsByDoctorId(doctor.Id, appointments);
        }

        public override void UpdateAllAppointmentsByDoctorId(Guid doctorId, List<Appointment> appointments) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                foreach (Appointment appointment in appointments) {
                    if (appointment.DoctorId != doctorId) continue;
                    cmd.CommandText = $"UPDATE Appointment SET appointmentDate = @date, doctorId = @doctorId, patientId = @patientId, note = @note WHERE id = '{appointment.Id}' AND doctorId = '{appointment.DoctorId}'";
                    cmd.Parameters.AddWithValue("@date", appointment.Date);
                    cmd.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                    cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
                    cmd.Parameters.AddWithValue("@note", appointment.Notes);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public override void UpdateAllAppointmentsByPatient(Patient patient, List<Appointment> appointments) {
            UpdateAllAppointmentsByPatientId(patient.Id, appointments);
        }

        public override void UpdateAllAppointmentsByPatientId(Guid patientId, List<Appointment> appointments) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                foreach (Appointment appointment in appointments) {
                    if (appointment.PatientId != patientId) continue;
                    cmd.CommandText = $"UPDATE Appointment SET appointmentDate = @date, doctorId = @doctorId, patientId = @patientId, note = @note WHERE id = '{appointment.Id}' AND patientId = '{appointment.PatientId}'";
                    cmd.Parameters.AddWithValue("@date", appointment.Date);
                    cmd.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                    cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
                    cmd.Parameters.AddWithValue("@note", appointment.Notes);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public override void UpdateAllAppointmentsBySpecialityId(Guid specialityId, List<Appointment> appointments) {
            throw new NotImplementedException();
        }

        public override void UpdateAppointment(Appointment appointment) {
            UpdateAppointmentById(appointment.Id, appointment);
        }

        public override void UpdateAppointmentById(Guid appointmentId, Appointment appointment) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"UPDATE Appointment SET appointmentDate = @date, doctorId = @doctorId, patientId = @patientId, note = @note WHERE id = '{appointmentId}'";
                cmd.Parameters.AddWithValue("@date", appointment.Date);
                cmd.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
                cmd.Parameters.AddWithValue("@note", appointment.Notes);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
