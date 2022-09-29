using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHPerscription : DBHPerscription {
        private MySqlConnection con;

        public MySQLDBHPerscription(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
        }

        private Perscription FillPerscriptionWithReaderData(MySqlDataReader reader) {
            return new Perscription(
                reader.GetGuid("id"),
                reader.GetGuid("patientId"),
                reader.GetGuid("doctorId"),
                DBHandler.Medication.GetMedicationById(reader.GetGuid("medicationId")),
                reader.GetString("note")
            );
        }

        public override Perscription AddPerscription(Perscription perscription) {
            Perscription newPerscription = perscription;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                try {
                    con.Open();
                    //check if guid already exists in database
                    while (true) {
                        cmd.CommandText = $"SELECT COUNT(id) FROM Perscription WHERE id = '{newPerscription.Id}'";
                        //if yes, generate a new guid
                        if ((Int64)cmd.ExecuteScalar() == 0) break;
                        else newPerscription = new Perscription(newPerscription.PatientId, newPerscription.DoctorId, newPerscription.Medication, newPerscription.Note);
                    }
                    cmd.CommandText = "INSERT INTO Perscription (id, patientId, doctorId, medicationId, note) VALUES (@id, @patientId, @doctorId, @medicationId, @note)";
                    cmd.Parameters.AddWithValue("@id", newPerscription.Id);
                    cmd.Parameters.AddWithValue("@patientId", newPerscription.PatientId);
                    cmd.Parameters.AddWithValue("@doctorId", newPerscription.DoctorId);
                    cmd.Parameters.AddWithValue("@medicationId", newPerscription.Medication.Id);
                    cmd.Parameters.AddWithValue("@note", newPerscription.Note);
                    cmd.ExecuteNonQuery();
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
            return newPerscription;
        }

        public override void DeleteAllPerscriptionsByDoctor(Doctor doctor) {
            DeleteAllPerscriptionsByDoctorId(doctor.Id);
        }

        public override void DeleteAllPerscriptionsByDoctorId(Guid doctorId) {
            //TODO: add delete notes
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                cmd.CommandText = $"DELETE FROM Perscription WHERE doctorId = '{doctorId}'";
                try {
                    con.Open();
                    cmd.ExecuteNonQuery();
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
        }

        public override void DeleteAllPerscriptionsOfPatient(Patient patient) {
            DeleteAllPerscriptionsOfPatientId(patient.Id);
        }

        public override void DeleteAllPerscriptionsOfPatientId(Guid patientId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                cmd.CommandText = $"DELETE FROM Perscription WHERE patientId = '{patientId}'";
                try {
                    con.Open();
                    cmd.ExecuteNonQuery();
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
        }

        public override void DeletePerscription(Perscription perscription) {
            DeletePerscriptionById(perscription.Id);
        }

        public override void DeletePerscriptionById(Guid perscriptionId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                cmd.CommandText = $"DELETE FROM Perscription WHERE id = '{perscriptionId}'";
                try {
                    con.Open();
                    cmd.ExecuteNonQuery();
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
        }

        public override List<Perscription> GetAllPerscriptions() {
            List<Perscription> perscriptions = new List<Perscription>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Perscription";
                try {
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) perscriptions.Add(FillPerscriptionWithReaderData(reader));
                    }
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
            return perscriptions;
        }

        public override List<Perscription> GetAllPerscriptionsByDoctor(Doctor doctor) {
            return GetAllPerscriptionsByDoctorId(doctor.Id);
        }

        public override List<Perscription> GetAllPerscriptionsByDoctorId(Guid doctorId) {
            List<Perscription> perscriptions = new List<Perscription>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM Perscription WHERE doctorId = '{doctorId}'";
                try {
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) perscriptions.Add(FillPerscriptionWithReaderData(reader));
                    }
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
            return perscriptions;
        }

        public override List<Perscription> GetAllPerscriptionsOfPatient(Patient patient) {
            return GetAllPerscriptionsOfPatientId(patient.Id);
        }

        public override List<Perscription> GetAllPerscriptionsOfPatientId(Guid patientId) {
            List<Perscription> perscriptions = new List<Perscription>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM Perscription WHERE patientId = '{patientId}'";
                try {
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) perscriptions.Add(FillPerscriptionWithReaderData(reader));
                    }
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
            return perscriptions;
        }

        public override Perscription GetPerscriptionById(Guid perscriptionId) {
            Perscription perscription = Perscription.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM Perscription WHERE id = '{perscriptionId}'";
                try {
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        reader.Read();
                        if (reader.HasRows) perscription = FillPerscriptionWithReaderData(reader);
                    }
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
            return perscription;
        }

        public override void UpdatePerscriptions(List<Perscription> perscriptions) {
            foreach (Perscription perscription in perscriptions) UpdatePerscription(perscription);
        }

        public override void UpdatePerscription(Perscription perscription) {
            UpdatePerscriptionById(perscription.Id, perscription);
        }

        public override void UpdatePerscriptionById(Guid perscriptionId, Perscription perscription) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                cmd.CommandText = $"UPDATE Perscription SET patientId = @patientId, doctorId = @doctorId, medicationId = @medicationId, note = @note WHERE id = '{perscriptionId}'";
                cmd.Parameters.AddWithValue("@patientId", perscription.PatientId);
                cmd.Parameters.AddWithValue("@doctorId", perscription.DoctorId);
                cmd.Parameters.AddWithValue("@medicationId", perscription.Medication.Id);
                cmd.Parameters.AddWithValue("@note", perscription.Note);
                try {
                    con.Open();
                    cmd.ExecuteNonQuery();
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
        }
    }
}
