using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos {
    public class DAOProducto {

        public List<Producto> obtenerTodos() {
            try {
                if (Conexion.conectar()) {
                    MySqlCommand comando = new MySqlCommand("select i.id, i.NombreCorto, i.Descripcion, i.Serie, i.Color, i.FechaAdquision, i.TipoAdquision, i.Observaciones, (select a.Nombre from areas a where a.id=i.areas_id) as 'Area', (select a.id from areas a where a.id=i.areas_id) as 'IDArea' from inventario i where i.activo=1;");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter lector = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    lector.Fill(resultado);
                    List<Producto> lista = new List<Producto>();
                    Producto obj = null;
                    foreach (DataRow fila in resultado.Rows) {
                        obj = new Producto();
                        obj.IDProducto = Int32.Parse(fila["id"].ToString());
                        obj.Nombre = fila["NombreCorto"].ToString();
                        obj.Descripcion = fila["Descripcion"].ToString();
                        obj.Serie = fila["Serie"].ToString();
                        obj.Color = fila["Color"].ToString();
                        obj.FechaAdquisicion = fila["FechaAdquision"].ToString();
                        obj.TipoAdquisicion = fila["TipoAdquision"].ToString();
                        obj.Observaciones = fila["Observaciones"].ToString();
                        obj.NombreArea = fila["Area"].ToString();
                        obj.IDArea = Int32.Parse(fila["IDArea"].ToString());
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


        public int ultimoRegistrado() {
            try {
                if (Conexion.conectar()) {
                    string query = "select max(id) from INVENTARIO;";
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


        public bool agregar(Producto prod) {
            try {
                if (Conexion.conectar()) {
                    string query = "insert into inventario values(@id,@NombreCorto,@Descripcion,@Serie,@Color,@FechaAdquision,@TipoAdquision,@Observaciones,1,@AREAS_ID);";
                    MySqlCommand comando = new MySqlCommand(query);
                    comando.Parameters.AddWithValue("@id", prod.IDProducto);
                    comando.Parameters.AddWithValue("@NombreCorto", prod.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", prod.Descripcion);
                    comando.Parameters.AddWithValue("@Serie", prod.Serie);
                    comando.Parameters.AddWithValue("@Color", prod.Color);
                    comando.Parameters.AddWithValue("@fechaAdquision", prod.FechaAdquisicion);
                    comando.Parameters.AddWithValue("@TipoAdquision", prod.TipoAdquisicion);
                    comando.Parameters.AddWithValue("@Observaciones", prod.Observaciones);
                    comando.Parameters.AddWithValue("@AREAS_ID", prod.IDArea);
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


        public bool modificar(Producto prod) {
            try {
                if (Conexion.conectar()) {
                    string query = "update INVENTARIO set NombreCorto=@nombre, Descripcion=@descripcion, Serie=@serie, Color=@color, FechaAdquision=@fechaAdquision, TipoAdquision=@tipoAdquision, Observaciones=@observaciones, Activo=1, AREAS_ID=@idArea where id=@id;";
                    MySqlCommand comando = new MySqlCommand(query);
                    comando.Parameters.AddWithValue("@nombre",prod.Nombre);
                    comando.Parameters.AddWithValue("@descripcion",prod.Descripcion);
                    comando.Parameters.AddWithValue("@serie", prod.Serie);
                    comando.Parameters.AddWithValue("@color", prod.Color);
                    comando.Parameters.AddWithValue("@fechaAdquision", prod.FechaAdquisicion);
                    comando.Parameters.AddWithValue("@tipoAdquision", prod.TipoAdquisicion);
                    comando.Parameters.AddWithValue("@observaciones", prod.Observaciones);
                    comando.Parameters.AddWithValue("@idArea", prod.IDArea);
                    comando.Parameters.AddWithValue("@id",prod.IDProducto);
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
                    MySqlCommand comando = new MySqlCommand(@"DELETE FROM INVENTARIO WHERE id=@id;");
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    int filasBorradas = comando.ExecuteNonQuery();
                    return (filasBorradas > 0);
                }
            }
            catch {
                try {
                    if (Conexion.conectar()) {
                        string query = "update INVENTARIO set activo=0 where id=@id;";
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
