using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using MySql.Data.MySqlClient;
using System.Data;

namespace Datos {
    public class DAOArea {
        public List<Area> obtenerTodos() {
            try {
                if (Conexion.conectar()) {
                    MySqlCommand comando = new MySqlCommand("select * from AREAS where activo=1;");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter lector = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    lector.Fill(resultado);
                    List<Area> lista = new List<Area>();
                    Area obj = null;
                    foreach (DataRow fila in resultado.Rows) {
                        obj = new Area();
                        obj.IDArea = Int32.Parse(fila["id"].ToString());
                        obj.Nombre = fila["Nombre"].ToString();
                        obj.Ubicacion = fila["Ubicacion"].ToString();
                        lista.Add(obj);
                    }
                    return lista;
                }
                else {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch {
                throw new Exception("No se pudo obtener la información de los usuarios");
            }
            finally {
                Conexion.desconectar();
            }
        }

        public List<string> obtenerAreas() {
            try {
                if (Conexion.conectar()) {
                    MySqlCommand comando = new MySqlCommand("select Nombre from AREAS where activo=1;");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter lector = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    lector.Fill(resultado);
                    List<string> lista = new List<string>();
                    foreach (DataRow fila in resultado.Rows) {
                        lista.Add(fila["Nombre"].ToString());
                    }
                    return lista;
                }
                else {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch {
                throw new Exception("No se pudo obtener la información de los usuarios");
            }
            finally {
                Conexion.desconectar();
            }
        }


        public Area obtenerUno(int id) {
            try {
                if (Conexion.conectar()) {
                    MySqlCommand comando = new MySqlCommand("select * from AREAS where id=@id;");
                    comando.Parameters.AddWithValue("@id",id);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    Area obj = null;
                    if (resultado.Rows.Count > 0) {
                        DataRow fila = resultado.Rows[0];
                        obj = new Area();
                        obj.IDArea = Int32.Parse(fila["id"].ToString());
                        obj.Nombre = fila["Nombre"].ToString();
                        obj.Ubicacion = fila["Ubicacion"].ToString();
                    }
                    return obj;
                }
                else {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch {
                throw new Exception("No se pudo obtener la información de los usuarios");
            }
            finally {
                Conexion.desconectar();
            }
        }

        public int obtenerUno(string nombre) {
            try {
                if (Conexion.conectar()) {
                    MySqlCommand comando = new MySqlCommand("select id from AREAS where Nombre=@nombre;");
                    comando.Parameters.AddWithValue("@nombre",nombre);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    int ans = -1;
                    if (resultado.Rows.Count > 0) {
                        DataRow fila = resultado.Rows[0];
                        ans = Int32.Parse(fila["id"].ToString());
                        
                    }
                    return ans;
                }
                else {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch {
                throw new Exception("No se pudo obtener la información de los usuarios");
            }
            finally {
                Conexion.desconectar();
            }
        }



        public int ultimoRegistrado() {
            try {
                if (Conexion.conectar()) {
                    string query = "select max(id) from AREAS;";
                    MySqlCommand comando = new MySqlCommand(query);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter lector = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    lector.Fill(resultado);
                    int ans = 0;
                    foreach (DataRow fila in resultado.Rows) {
                        ans = Int32.Parse(fila["max(id)"].ToString());
                    }
                    if (ans == 0) return 1;
                    return ans;
                }
                else {
                    return -1;
                }
            }
            catch {
                return -1;
            }
            finally {
                Conexion.desconectar();
            }
        }

        public bool agregar(Area area) {
            try {
                if (Conexion.conectar()) {
                    string query = "insert into AREAS values(@id,@Nombre,@Ubicacion,1);";
                    MySqlCommand comando = new MySqlCommand(query);
                    comando.Parameters.AddWithValue("@id", area.IDArea);
                    comando.Parameters.AddWithValue("@Nombre", area.Nombre);
                    comando.Parameters.AddWithValue("@Ubicacion", area.Ubicacion);
                    comando.Connection = Conexion.conexion;
                    int rowsaffected = comando.ExecuteNonQuery();
                    if (rowsaffected > 0) return true;
                    else return false;
                }
                else {
                    return false;
                }
            }
            catch {
                return false;
            }
            finally {
                Conexion.desconectar();
            }
        }

        public bool modificar(Area area) {
            try {
                if (Conexion.conectar()) {
                    string query = "update AREAS set Nombre=@nombre, Ubicacion=@ubicacion where id=@id;";
                    MySqlCommand comando = new MySqlCommand(query);
                    comando.Parameters.AddWithValue("@nombre", area.Nombre);
                    comando.Parameters.AddWithValue("@ubicacion", area.Ubicacion);
                    comando.Parameters.AddWithValue("@id", area.IDArea);
                    comando.Connection = Conexion.conexion;
                    int filasEditadas = comando.ExecuteNonQuery();
                    return filasEditadas > 0;
                }
            }
            catch {
                return false;
            }
            finally {
                Conexion.desconectar();
            }
            return true;
        }


        public bool eliminar(int id) {
            try {
                if (Conexion.conectar()) {
                    MySqlCommand comando = new MySqlCommand(@"DELETE FROM AREAS WHERE id=@id;");
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    int filasBorradas = comando.ExecuteNonQuery();
                    return (filasBorradas > 0);
                }
            }
            catch {
                try {
                    if (Conexion.conectar()) {
                        string query = "update AREAS set activo=0 where id=@id;";
                        MySqlCommand comando = new MySqlCommand(query);
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Connection = Conexion.conexion;
                        int filasEditadas = comando.ExecuteNonQuery();
                        return filasEditadas > 0;
                    }
                }
                catch {
                    return false;
                }
            }
            finally {
                Conexion.desconectar();
            }
            return true;
        }


    }
}
