using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication.Model.Database {
    public class DBHandler {
        private static IDBHandler database;

        public static void SetDataBaseType(DataBaseType type, DBConnectionInfo info) {
            switch (type) {
                case DataBaseType.MySQL:
                    database = new MySQLDBHandler(info);
                    break;
                case DataBaseType.SQLServer:
                    database = new MySQLDBHandler(info);
                    break;
                case DataBaseType.SQLite:
                    database = new MySQLDBHandler(info);
                    break;
            }
        }

        public static DBHAppointment Appointment { get { return database.Appointment(); } }

        public static DBHDoctor Doctor { get { return database.Doctor(); } }

        public static DBHMedicalNote MedicalNote { get { return database.MedicalNote(); } }

        public static DBHMedicalRecord MedicalRecord { get { return database.MedicalRecord(); } }

        public static DBHMedicalTest MedicalTest { get { return database.MedicalTest(); } }

        public static DBHMedication Medication { get { return database.Medication(); } }

        public static DBHPatient Patient { get { return database.Patient(); } }

        public static DBHPerscription Perscription { get { return database.Perscription(); } }

        public static DBHSurgery Surgery { get { return database.Surgery(); } }

        public static DBHUser User { get { return database.User(); } }
    }
}
