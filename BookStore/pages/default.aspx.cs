using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.Conections;
namespace BookStore.pages
{
    public partial class Books : System.Web.UI.Page
    {
        private void cargarTabla(Libro[] libros)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ISBN", typeof(string)));
            dt.Columns.Add(new DataColumn("Titulo", typeof(string)));
            dt.Columns.Add(new DataColumn("Autor", typeof(string)));
            dt.Columns.Add(new DataColumn("Sinopsis", typeof(string)));
            dt.Columns.Add(new DataColumn("Edicion", typeof(string)));
            dt.Columns.Add(new DataColumn("Año de publicacion", typeof(string)));
            dt.Columns.Add(new DataColumn("Pais de publicacion", typeof(string)));

            for (int i = 0; i < libros.Length; i++)
            {
                if (libros[i] != null)
                dt.Rows.Add(libros[i].ISBN, libros[i].Titulo, libros[i].Autor, libros[i].Sinopsis, libros[i].NumEdicion,
                    libros[i].AnioPublicacion, libros[i].PaisPublicacion);
            }

            GridView1.DataSource = dt;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string script = "alert('Bienvenid@');";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            //cargarTabla(new DAOBooks().GetAll());
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}