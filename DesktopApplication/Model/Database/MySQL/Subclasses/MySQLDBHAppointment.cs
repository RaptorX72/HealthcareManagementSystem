﻿using DesktopApplication.Model.Healthcare;
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
                reader.GetGuid("id"),
                reader.GetDateTime("appointmentDate"),
                reader.GetGuid("doctorId"),
                reader.GetGuid("patientId"),
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
                    cmd.CommandText = $"SELECT COUNT(id) FROM Appointment WHERE id = '{appointment.Id}'";
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
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
            }
            return newAppointment;
        }

        public override void DeleteAllAppointmentsByDate(DateTime date) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Appointment WHERE appointmentDate = '{date.ToString(Globals.DateFormat)}'";
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
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
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
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
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
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
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
            }
        }

        public override List<Appointment> GetAllAppointments() {
            List<Appointment> appointments = new List<Appointment>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT * FROM Appointment";
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
                cmd.CommandText = $"SELECT * FROM Appointment WHERE appointmentDate = '{date.ToString(Globals.DateFormat)}'";
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
                cmd.CommandText = $"SELECT * FROM Appointment WHERE doctorId = '{doctorId}'";
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
                cmd.CommandText = $"SELECT * FROM Appointment WHERE patientId = '{patientId}'";
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
                cmd.CommandText = $"SELECT * FROM Appointment WHERE id = '{appointmentId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    if (reader.HasRows) appointment = FillAppointmentWithReaderData(reader);
                }
                con.Close();
            }
            return appointment;
        }

        public override void UpdateAppointments(List<Appointment> appointments) {
            foreach (Appointment appointment in appointments) UpdateAppointment(appointment);
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
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
            }
        }
    }
}
