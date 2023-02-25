using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.Conections;
using BookStore.Models;

namespace BookStore.pages
{
    public partial class Register : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            bool allgood = false;
            if (txtISBN.Text.Length > 0 && txtTitulo.Text.Length > 0 && txtAutores.Text.Length > 0 &&
                    txtSinopsis.Text.Length > 0 && txtAnPub.Text.Length > 0 && txtPais.Text.Length > 0 &&
                    txtNumEdi.Text.Length > 0)
                allgood = true;
            if (allgood)
            {
                Libro book = new Libro(
                        txtISBN.Text, txtTitulo.Text, txtAutores.Text, txtSinopsis.Text, txtAnPub.Text, txtPais.Text, txtNumEdi.Text
                    );
                
                if (new DAOBooks().Insert(book))
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    string script = "alert('Error de servidor');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                }
            }
            else
            {
                string script = "alert('Debe llenar todos los campos');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            }
        }
    }
}