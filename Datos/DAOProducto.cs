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
                    MySqlCommand comando = new MySqlCommand("select * from inventario;");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter lector = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    lector.Fill(resultado);
                    List<Producto> lista = new List<Producto>();
                    Producto obj = null;
                    foreach (DataRow fila in resultado.Rows) {
                        obj = new Producto();
                        obj.IDProducto = fila["id"].ToString();
                        obj.Nombre = fila["NombreCorto"].ToString();
                        obj.Descripcion = fila["Descripcion"].ToString();
                        obj.Serie = fila["Serie"].ToString();
                        obj.Color = fila["Color"].ToString();
                        obj.FechaAdquisicion = fila["FechaAdquision"].ToString();
                        obj.TipoAdquisicion = fila["TipoAdquision"].ToString();
                        obj.Observaciones = fila["Observaciones"].ToString();
                        obj.IDArea = Int32.Parse(fila["AREAS_ID"].ToString());
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


        public bool agregar(Producto prod) {
            try {
                if (Conexion.conectar()) {
                    string query = "insert into inventario values(@id,@NombreCorto,@Descripcion,@Serie,@Color,@FechaAdquision,@TipoAdquision,@Observaciones,@AREAS_ID);";
                    MySqlCommand comando = new MySqlCommand(query);
                    comando.Parameters.AddWithValue("@id", prod.IDProducto);
                    comando.Parameters.AddWithValue("@NombreCorto", prod.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", prod.Descripcion);
                    comando.Parameters.AddWithValue("@Serie", prod.Serie);
                    comando.Parameters.AddWithValue("@Color", prod.Color);
                    comando.Parameters.AddWithValue("@fechaAdquision", prod.FechaAdquisicion);
                    comando.Parameters.AddWithValue("@Observaciones", prod.Observaciones);
                    comando.Parameters.AddWithValue("@AREAS_ID", prod.IDArea);
                    comando.Connection = Conexion.conexion;
                    comando.ExecuteNonQuery();
                    return true;
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


    }
}
