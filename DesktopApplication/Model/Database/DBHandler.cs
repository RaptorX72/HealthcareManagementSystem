using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication.Model.Database {
    public class DBHandler {
        private static IDBHandler database;

        public static IDBHandler DB { get { return database; } }

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
    }
}
