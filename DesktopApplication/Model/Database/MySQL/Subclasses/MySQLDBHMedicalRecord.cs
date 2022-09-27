using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHMedicalRecord : DBHMedicalRecord {
        private MySqlConnection con;
        private MySqlConnection bloodCon;

        public MySQLDBHMedicalRecord(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
            bloodCon = CommonTools.CreateMySQLConnection(info);
        }

        private BloodType GetBloodTypeById(int id) {
            BloodType bloodType = BloodType.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = bloodCon;
                cmd.CommandText = $"SELECT * FROM BloodType WHERE id = {id}";
                bloodCon.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    if (reader.HasRows) bloodType = new BloodType(reader.GetString("protein"), reader.GetBoolean("rh"));
                }
            }
            bloodCon.Close();
            return bloodType;
        }

        private int GetIdOfBloodType(BloodType type) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = bloodCon;
                cmd.CommandText = $"SELECT id FROM BloodType WHERE protein = '{type.BloodAntigen}' AND rh = {type.Rh}";
                bloodCon.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    int res = reader.GetInt32("id");
                    bloodCon.Close();
                    return res;
                }
            }
        }

        private MedicalRecord FillMedicalRecordWithReaderData(MySqlDataReader reader) {
            return new MedicalRecord(
                reader.GetGuid("id"),
                reader.GetGuid("patientId"),
                reader.GetDateTime("birthDate"),
                reader.GetString("gender"),
                GetBloodTypeById(reader.GetInt32("bloodTypeId")),
                reader.GetDouble("height"),
                reader.GetDouble("weight"),
                DBHandler.Perscription.GetAllPerscriptionsOfPatientId(reader.GetGuid("patientId")),
                DBHandler.MedicalNote.GetAllMedicalNotesOfPatientId(reader.GetGuid("patientId"))
            );
        }

        public override MedicalRecord AddMedicalRecord(MedicalRecord record) {
            MedicalRecord newMedicalRecord = record;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                //check if guid already exists in database
                while (true) {
                    cmd.CommandText = $"SELECT COUNT(id) FROM MedicalRecord WHERE id = '{newMedicalRecord.Id}'";
                    //if yes, generate a new guid
                    if ((Int64)cmd.ExecuteScalar() == 0) break;
                    else newMedicalRecord = new MedicalRecord(
                        newMedicalRecord.PatientId,
                        newMedicalRecord.BirthDate,
                        newMedicalRecord.Gender,
                        newMedicalRecord.BloodType,
                        newMedicalRecord.Height,
                        newMedicalRecord.Weight,
                        newMedicalRecord.Perscriptions,
                        newMedicalRecord.Notes
                    );
                }
                cmd.CommandText = "INSERT INTO MedicalRecord (id, patientId, birthDate, gender, bloodTypeId, height, weight) VALUES (@id, @patientId, @birthDate, @gender, @bloodTypeId, @height, @weight)";
                cmd.Parameters.AddWithValue("@id", newMedicalRecord.Id);
                cmd.Parameters.AddWithValue("@patientId", newMedicalRecord.PatientId);
                cmd.Parameters.AddWithValue("@birthDate", newMedicalRecord.BirthDate);
                cmd.Parameters.AddWithValue("@gender", newMedicalRecord.Gender);
                cmd.Parameters.AddWithValue("@bloodTypeId", GetIdOfBloodType(newMedicalRecord.BloodType));
                cmd.Parameters.AddWithValue("@height", newMedicalRecord.Height);
                cmd.Parameters.AddWithValue("@weight", newMedicalRecord.Weight);
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
            }
            return newMedicalRecord;
        }

        public override void DeleteMedicalRecord(MedicalRecord medicalRecord) {
            DeleteMedicalRecordById(medicalRecord.Id);
        }

        public override void DeleteMedicalRecordById(Guid medicalRecordId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM MedicalRecord WHERE id = '{medicalRecordId}'";
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
            }
        }

        public override List<MedicalRecord> GetAllMedicalRecords() {
            List<MedicalRecord> medicalRecords = new List<MedicalRecord>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT * FROM MedicalRecord";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) medicalRecords.Add(FillMedicalRecordWithReaderData(reader));
                }
                con.Close();
            }
            return medicalRecords;
        }

        public override MedicalRecord GetMedicalRecordById(Guid medicalRecordId) {
            MedicalRecord medicalRecord = MedicalRecord.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * FROM MedicalRecord WHERE id = '{medicalRecordId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    if (reader.HasRows) medicalRecord = FillMedicalRecordWithReaderData(reader);
                }
                con.Close();
            }
            return medicalRecord;
        }

        public override MedicalRecord GetMedicalRecordOfPatient(Patient patient) {
            return GetMedicalRecordOfPatientById(patient.Id);
        }

        public override MedicalRecord GetMedicalRecordOfPatientById(Guid patientId) {
            MedicalRecord medicalRecord = MedicalRecord.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * FROM MedicalRecord WHERE patientId = '{patientId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    if (reader.HasRows) medicalRecord = FillMedicalRecordWithReaderData(reader);
                }
                con.Close();
            }
            return medicalRecord;
        }

        public override void UpdateMedicalRecord(MedicalRecord medicalRecord) {
            UpdateMedicalRecordById(medicalRecord.Id, medicalRecord);
        }

        public override void UpdateMedicalRecordById(Guid medicalRecordId, MedicalRecord medicalRecord) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"UPDATE MedicalRecord SET patientId = @patientId, birthDate = @birthDate, gender = @gender, bloodTypeId = @bloodTypeId, height = @height, weight = @weight WHERE id = '{medicalRecordId}'";
                cmd.Parameters.AddWithValue("@patientId", medicalRecord.PatientId);
                cmd.Parameters.AddWithValue("@birthDate", medicalRecord.BirthDate);
                cmd.Parameters.AddWithValue("@gender", medicalRecord.Gender);
                cmd.Parameters.AddWithValue("@bloodTypeId", GetIdOfBloodType(medicalRecord.BloodType));
                cmd.Parameters.AddWithValue("@height", medicalRecord.Height);
                cmd.Parameters.AddWithValue("@weight", medicalRecord.Weight);
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
