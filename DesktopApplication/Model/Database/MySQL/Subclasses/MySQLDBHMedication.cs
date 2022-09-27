using System.Text;
using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using DesktopApplication.Model.Supplies;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHMedication : DBHMedication {
        private MySqlConnection con;

        public MySQLDBHMedication(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
        }

        private Medication FillMedicationWithReaderData(MySqlDataReader reader) {
            return new Medication(
                reader.GetGuid("id"),
                reader.GetString("name"),
                reader.GetString("mainIngredient"),
                reader.GetDouble("dosage"),
                reader.GetDouble("size"),
                (UnitOfMeasurement)reader.GetInt32("unitOfMeasurement")
            );
        }

        public override Medication AddMedication(Medication medication) {
            Medication newMedication = medication;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                //check if guid already exists in database
                while (true) {
                    cmd.CommandText = $"SELECT Count(id) FROM Medication WHERE id = '{medication.Id}'";
                    //if yes, generate a new guid
                    if ((Int64)cmd.ExecuteScalar() == 0) break;
                    else newMedication = new Medication(newMedication.Name, newMedication.MainIngedient, newMedication.Dosage, newMedication.Size, newMedication.UnitOfMeasurement);
                }
                cmd.CommandText = "INSERT INTO Medication (id, name, mainIngredient, dosage, size, uniOfMeasurementId) VALUES (@id, @name, @mainIngredient, @dosage, @size, @unitOfMeasurementId)";
                cmd.Parameters.AddWithValue("@id", newMedication.Id);
                cmd.Parameters.AddWithValue("@name", newMedication.Name);
                cmd.Parameters.AddWithValue("@mainIngredient", newMedication.MainIngedient);
                cmd.Parameters.AddWithValue("@dosage", newMedication.Dosage);
                cmd.Parameters.AddWithValue("@size", newMedication.Size);
                cmd.Parameters.AddWithValue("@unitOfMeasurementId", newMedication.UnitOfMeasurement);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return newMedication;
        }

        public override void DeleteMedication(Medication medication) {
            DeleteMedicationById(medication.Id);
        }

        public override void DeleteMedicationById(Guid medicationId) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"DELETE FROM Medication WHERE id = '{medicationId}'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public override List<Medication> GetAllMedications() {
            List<Medication> medications = new List<Medication>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT * FROM Medication";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) medications.Add(FillMedicationWithReaderData(reader));
                }
                con.Close();
            }
            return medications;
        }

        public override List<Medication> GetAllMedicationsOfPatient(Patient patient) {
            return GetAllMedicationsOfPatientById(patient.Id);
        }

        public override List<Medication> GetAllMedicationsOfPatientById(Guid patientId) {
            List<Medication> medications = new List<Medication>();
            List<Perscription> perscriptions = DBHandler.Perscription.GetAllPerscriptionsByPatientId(patientId);
            foreach (Perscription perscription in perscriptions) medications.Add(perscription.Medication);
            return medications;
        }

        public override Medication GetMedicationById(Guid medicationId) {
            Medication medication = Medication.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * FROM Medication WHERE id = '{medicationId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    medication = FillMedicationWithReaderData(reader);
                }
                con.Close();
            }
            return medication;
        }

        public override void UpdateMedication(Medication medication) {
            UpdateMedicationById(medication.Id, medication);
        }

        public override void UpdateMedicationById(Guid medicationId, Medication medication) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"UPDATE Medication SET name = @name, mainIngredient = @mainIngredient, dosage = @dosage, size = @size, unitOfMeasurementId = @unitOfMeasurementId WHERE id = '{medicationId}'";
                cmd.Parameters.AddWithValue("@name", medication.Name);
                cmd.Parameters.AddWithValue("@mainIngredient", medication.MainIngedient);
                cmd.Parameters.AddWithValue("@dosage", medication.Dosage);
                cmd.Parameters.AddWithValue("@size", medication.Size);
                cmd.Parameters.AddWithValue("@unitOfMeasurementId", medication.UnitOfMeasurement);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
