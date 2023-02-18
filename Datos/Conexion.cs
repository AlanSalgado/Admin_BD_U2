using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos {
    public class Conexion {
        public static MySqlConnection conexion;
        static string usuario = "root";
        static string password = "itsur12345";
        static string bd = "admbd";
        static string servidor = "localhost";
        static string puerto = "3306";

        public static bool conectar() {
            try {
                conexion = new MySqlConnection("Database=" + bd + ";Data Source=" + servidor + ";Port=" + puerto + ";User Id=" + usuario + ";Password=" + password);
                conexion.Open();
                return true;
            }
            catch {
                return false;
            }
        }

        public static void desconectar() {
            try {
                conexion.Close();
            }
            catch { 
            }
        }

    }
}
