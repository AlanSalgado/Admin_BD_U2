using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using MySql.Data.MySqlClient;
using System.Data;

namespace Datos {
    public class DAOArea
    {
        public List<Area> obtenerTodos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from Areas;");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter lector = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    lector.Fill(resultado);
                    List<Area> lista = new List<Area>();
                    Area obj = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        obj = new Area();
                        obj.IDArea = Int32.Parse(fila["id"].ToString());
                        obj.Nombre = fila["Nombre"].ToString();
                        obj.Ubicacion = fila["Ubicacion"].ToString();
                        lista.Add(obj);
                    }
                    return lista;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch
            {
                throw new Exception("No se pudo obtener la información de los usuarios");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public bool agregar(Area area)
        {
            try
            {
                if (Conexion.conectar())
                {
                    string query = "insert into areas values(@id,@Nombre,@Ubicacion);";
                    MySqlCommand comando = new MySqlCommand(query);
                    comando.Parameters.AddWithValue("@id", area.IDArea);
                    comando.Parameters.AddWithValue("@NombreCorto", area.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", area.Ubicacion);
                    comando.Connection = Conexion.conexion;
                    comando.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public bool modificar(Area area)
        {
            try
            {
                if (Conexion.conectar())
                {
                    string query = "update areas set nombre=@nombre, ubicacion=@ubicacion' where id=@id;";
                    MySqlCommand comando = new MySqlCommand(query);
                    comando.Parameters.AddWithValue("@nombre", area.Nombre);
                    comando.Parameters.AddWithValue("@ubicacion", area.Ubicacion);
                    comando.Parameters.AddWithValue("@id", area.IDArea);
                    comando.Connection = Conexion.conexion;
                    int filasEditadas = comando.ExecuteNonQuery();
                    return filasEditadas > 0;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                Conexion.desconectar();
            }
            return true;
        }

    }
}
