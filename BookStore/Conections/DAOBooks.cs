using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BookStore.pages;
using BookStore.Models;

namespace BookStore.Conections
{
    public class DAOBooks
    {
        private string connection = "Data Source=20.80.245.8,1433; Initial Catalog=Practica;" +
            "User ID=System;Password=#Access02;";

        public bool Insert(Libro book)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO BOOKS values" +
                        "(@ISBN,@Titulo,@Autor,@Sinopsis,@Edicion,@Anio,@Pais)";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.Parameters.AddWithValue("@Titulo", book.Titulo);
                    command.Parameters.AddWithValue("@Autor", book.Autor);
                    command.Parameters.AddWithValue("@Sinopsis", book.Sinopsis);
                    command.Parameters.AddWithValue("@Edicion", book.NumEdicion);
                    command.Parameters.AddWithValue("@Anio", book.AnioPublicacion);
                    command.Parameters.AddWithValue("@Pais", book.PaisPublicacion);

                    int RowsAffected = command.ExecuteNonQuery();

                    if(RowsAffected<1)
                        return false;
                }
                catch (Exception)
                {
                    throw;
                }

                return true;
            }
        }

        public Libro[] GetAll()
        {
            Libro[] libros = new Libro[7];
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM [books]";
                    SqlCommand command = new SqlCommand(query, conn);
                    using (SqlDataReader results = command.ExecuteReader())
                    {
                        int i = 0;
                        while (results.Read())
                        {
                            libros[i++] = new Libro(
                                    results[0].ToString(),
                                    results[1].ToString(),
                                    results[2].ToString(),
                                    results[3].ToString(),
                                    results[5].ToString(),
                                    results[6].ToString(),
                                    results[4].ToString()
                                );
                            results.NextResult();
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return libros;
        }



    }
}