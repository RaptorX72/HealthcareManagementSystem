using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHMedicalTest : DBHMedicalTest {
        //TODO: Implement medical test result as well to fully use class
        private MySqlConnection con;

        public MySQLDBHMedicalTest(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
        }

        private MedicalTest FillMedicalTestWithReaderData(MySqlDataReader reader) {
            //TODO: Add test result as well
            return new MedicalTest(
                reader.GetGuid("id"),
                reader.GetGuid("doctorId"),
                reader.GetGuid("patientId"),
                (MedicalTestType)(reader.GetInt32("testTypeId") - 1),
                MedicalTestResult.Empty
            );
        }

        public override MedicalTest AddMedicalTest(MedicalTest medicalTest) {
            MedicalTest newMedicalTest = medicalTest;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                //check if guid already exists in database
                while (true) {
                    cmd.CommandText = $"SELECT COUNT(id) FROM MedicalTest WHERE id = '{newMedicalTest.Id}'";
                    //if yes, generate a new guid
                    if ((Int64)cmd.ExecuteScalar() == 0) break;
                    else newMedicalTest = new MedicalTest(newMedicalTest.DoctorId, newMedicalTest.PatientId, newMedicalTest.MedicalTestType);
                }
                cmd.CommandText = "INSERT INTO MedicalTest (id, doctorId, patientId, testTypeId) VALUES (@id, @doctorId, @patientId, @testTypeId)";
                cmd.Parameters.AddWithValue("@id", newMedicalTest.Id);
                cmd.Parameters.AddWithValue("@doctorId", newMedicalTest.DoctorId);
                cmd.Parameters.AddWithValue("@patientId", newMedicalTest.PatientId);
                cmd.Parameters.AddWithValue("@testTypeId", (int)newMedicalTest.MedicalTestType + 1);
                //TODO: Add result as well if exists
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
            }
            return newMedicalTest;
        }

        public override void DeleteAllMedicalTestsByDoctor(Doctor doctor) {
            DeleteAllMedicalTestsByDoctorId(doctor.Id);
        }

        public override void DeleteAllMedicalTestsByDoctorId(Guid doctorId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM MedicalTest WHERE doctorId = '{doctorId}'";
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
            }
        }

        public override void DeleteAllMedicalTestsByType(MedicalTestType medicalTestType) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM MedicalTest WHERE testTypeId = {(int)medicalTestType + 1}";
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
            }
        }

        public override void DeleteAllMedicalTestsOfPatient(Patient patient) {
            DeleteAllMedicalTestsOfPatientById(patient.Id);
        }

        public override void DeleteAllMedicalTestsOfPatientById(Guid patientId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM MedicalTest WHERE doctorId = '{patientId}'";
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
            }
        }

        public override void DeleteMedicalTest(MedicalTest medicalTest) {
            DeleteMedicalTestById(medicalTest.Id);
        }

        public override void DeleteMedicalTestById(Guid medicalTestId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM MedicalTest WHERE id = '{medicalTestId}'";
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
            }
        }

        public override List<MedicalTest> GetAllMedicalTests() {
            List<MedicalTest> medicalTests = new List<MedicalTest>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT * FROM MedicalTest";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) medicalTests.Add(FillMedicalTestWithReaderData(reader));
                }
                con.Close();
            }
            return medicalTests;
        }

        public override List<MedicalTest> GetAllMedicalTestsByDoctor(Doctor doctor) {
            return GetAllMedicalTestsByDoctorId(doctor.Id);
        }

        public override List<MedicalTest> GetAllMedicalTestsByDoctorId(Guid doctorId) {
            List<MedicalTest> medicalTests = new List<MedicalTest>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * FROM MedicalTest WHERE doctorId = '{doctorId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) medicalTests.Add(FillMedicalTestWithReaderData(reader));
                }
                con.Close();
            }
            return medicalTests;
        }

        public override List<MedicalTest> GetAllMedicalTestsByType(MedicalTestType medicalTestType) {
            List<MedicalTest> medicalTests = new List<MedicalTest>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * FROM MedicalTest WHERE testTypeId = {(int)medicalTestType + 1}";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) medicalTests.Add(FillMedicalTestWithReaderData(reader));
                }
                con.Close();
            }
            return medicalTests;
        }

        public override List<MedicalTest> GetAllMedicalTestsOfPatient(Patient patient) {
            return GetAllMedicalTestsOfPatientById(patient.Id);
        }

        public override List<MedicalTest> GetAllMedicalTestsOfPatientById(Guid patientId) {
            List<MedicalTest> medicalTests = new List<MedicalTest>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * FROM MedicalTest WHERE patientId = '{patientId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) medicalTests.Add(FillMedicalTestWithReaderData(reader));
                }
                con.Close();
            }
            return medicalTests;
        }

        public override MedicalTest GetMedicalTestById(Guid medicalTestId) {
            MedicalTest medicalTest = MedicalTest.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * FROM MedicalTest WHERE id = '{medicalTestId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    if (reader.HasRows) medicalTest = FillMedicalTestWithReaderData(reader);
                }
                con.Close();
            }
            return medicalTest;
        }

        public override void UpdateMedicalTest(MedicalTest medicalTest) {
            UpdateMedicalTestById(medicalTest.Id, medicalTest);
        }

        public override void UpdateMedicalTestById(Guid medicalTestId, MedicalTest medicalTest) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"UPDATE MedicalTest SET doctorId = @doctorId, patientId = @patientId, testTypeId = @testTypeId WHERE id = '{medicalTestId}'";
                cmd.Parameters.AddWithValue("@doctorId", medicalTest.DoctorId);
                cmd.Parameters.AddWithValue("@patientId", medicalTest.PatientId);
                cmd.Parameters.AddWithValue("@testTypeId", (int)medicalTest.MedicalTestType + 1);
                try {
                    cmd.ExecuteNonQuery();
                } catch (MySqlException) {
                    throw;
                } finally {
                    con.Close();
                }
            }
        }

        public override void UpdateMedicalTests(List<MedicalTest> medicalTests) {
            foreach (MedicalTest medicalTest in medicalTests) UpdateMedicalTest(medicalTest);
        }
    }
}
