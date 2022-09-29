using System.Text;
using DesktopApplication.Model.Healthcare;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHDoctor : DBHDoctor {
        private MySqlConnection con;

        public MySQLDBHDoctor(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
        }

        private Doctor FillDoctorWithReaderData(MySqlDataReader reader) {
            return new Doctor(
                reader.GetGuid("id"),
                reader.GetString("firstName"),
                reader.GetString("middleName"),
                reader.GetString("lastName"),
                Guid.Empty
            );
        }
        //TODO: Finish speciality functions
        public override Doctor AddDoctor(Doctor doctor) {
            Doctor newDoctor = doctor;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                try {
                    con.Open();
                    //check if guid already exists in database
                    while (true) {
                        cmd.CommandText = $"SELECT COUNT(id) FROM Doctor WHERE id = '{newDoctor.Id}'";
                        //if yes, generate a new guid
                        if ((Int64)cmd.ExecuteScalar() == 0) break;
                        else newDoctor = new Doctor(newDoctor.FirstName, newDoctor.MiddleName, newDoctor.LastName, newDoctor.SpecialityId);
                    }
                    cmd.CommandText = "INSERT INTO Doctor (id, firstName, middleName, lastName) VALUES (@id, @firstName, @middleName, @lastName)";
                    cmd.Parameters.AddWithValue("@id", newDoctor.Id);
                    cmd.Parameters.AddWithValue("@firstName", newDoctor.FirstName);
                    cmd.Parameters.AddWithValue("@middleName", newDoctor.MiddleName);
                    cmd.Parameters.AddWithValue("@lastName", newDoctor.LastName);
                    cmd.ExecuteNonQuery();
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
            return newDoctor;
        }

        public override void DeleteDoctor(Doctor doctor) {
            DeleteDoctorById(doctor.Id);
        }

        public override void DeleteDoctorById(Guid doctorId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                cmd.CommandText = $"DELETE FROM Doctor WHERE id = '{doctorId}'";
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

        public override List<Doctor> GetAllDoctors() {
            List<Doctor> doctors = new List<Doctor>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Doctor";
                try {
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) doctors.Add(FillDoctorWithReaderData(reader));
                    }
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
            return doctors;
        }

        public override Doctor GetDoctorById(Guid doctorId) {
            Doctor doctor = Doctor.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM Doctor WHERE id = '{doctorId}'";
                try {
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        reader.Read();
                        if (reader.HasRows) doctor = FillDoctorWithReaderData(reader);
                    }
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
            return doctor;
        }

        public override List<Doctor> GetDoctorsBySpecialityId(int specialityId) {
            throw new NotImplementedException();
        }

        public override List<Doctor> GetDoctorsOfPatient(Patient patient) {
            return GetDoctorsOfPatientById(patient.Id);
        }

        public override List<Doctor> GetDoctorsOfPatientById(Guid patientId) {
            List<Doctor> doctors = new List<Doctor>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                try {
                    con.Open();
                    cmd.CommandText = $"SELECT doctorId FROM DoctorPatientTreatment WHERE patientId = '{patientId}'";
                    StringBuilder sb = new StringBuilder();
                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        List<Guid> ids = new List<Guid>();
                        while (reader.Read()) ids.Add(reader.GetGuid("doctorId"));
                        sb.Append("SELECT * FROM Doctor WHERE id IN (");
                        for (int i = 0; i < ids.Count; i++) {
                            sb.Append($"'{ids[i].ToString()}'");
                            if (i < ids.Count - 1) sb.Append(", ");
                        }
                        sb.Append(")");
                    }
                    cmd.CommandText = sb.ToString();
                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) doctors.Add(FillDoctorWithReaderData(reader));
                    }
                } catch (MySqlException ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
            return doctors;
        }

        public override void UpdateDoctor(Doctor doctor) {
            UpdateDoctorById(doctor.Id, doctor);
        }

        public override void UpdateDoctorById(Guid doctorId, Doctor doctor) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                cmd.CommandText = $"UPDATE Doctor SET firstName = @firstName, middleName = @middleName, lastName = @lastName WHERE id = '{doctorId}'";
                cmd.Parameters.AddWithValue("@firstName", doctor.FirstName);
                cmd.Parameters.AddWithValue("@middleName", doctor.MiddleName);
                cmd.Parameters.AddWithValue("@lastName", doctor.LastName);
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

        public override void UpdateDoctors(List<Doctor> doctors) {
            foreach (Doctor doctor in doctors) UpdateDoctor(doctor);
        }
    }
}
