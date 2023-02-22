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
        static string usuario = "Saul2";
        static string password = "P=0f0uigB#";
        static string bd = "AdmBD";
        static string servidor = "192.168.23.49";
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
