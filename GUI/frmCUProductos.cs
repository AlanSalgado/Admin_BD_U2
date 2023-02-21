using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;
using Datos;

namespace GUI {
    public partial class frmCUProductos : Form {

        public frmCUProductos() {
            InitializeComponent();
            int id = new DAOProducto().ultimoRegistrado() + 1;
            if (id == 0) {
                id = 1;
            }
            txtID.Text = id.ToString();
            cmbAdquisicion.Items.Add("Comprada en fisico");
            cmbAdquisicion.Items.Add("Comprada en linea");
            cmbAdquisicion.Items.Add("Prestada");
            cmbAdquisicion.Items.Add("Rentada");
            cmbAdquisicion.SelectedIndex = 0;
            cmbArea.DataSource = new DAOArea().obtenerAreas();
            cmbArea.SelectedIndex = 0;
        }

        public frmCUProductos(Producto prod) {
            InitializeComponent();
            cmbAdquisicion.Items.Add("Comprada en fisico");
            cmbAdquisicion.Items.Add("Comprada en linea");
            cmbAdquisicion.Items.Add("Prestada");
            cmbAdquisicion.Items.Add("Rentada");
            cmbAdquisicion.SelectedItem = prod.TipoAdquisicion;
            cmbArea.DataSource = new DAOArea().obtenerAreas();
            cmbArea.SelectedItem = prod.NombreArea;
            txtID.Text = prod.IDProducto.ToString();
            txtNombre.Text = prod.Nombre.ToString();
            txtDescripcion.Text = prod.Descripcion.ToString();
            txtSerie.Text = prod.Serie.ToString();
            txtColor.Text = prod.Color;
            txtObservaciones.Text = prod.Observaciones.ToString();
            // casteo de fechas
            int year = Convert.ToInt32(prod.FechaAdquisicion.Substring(6, 4));
            int month = Convert.ToInt32(prod.FechaAdquisicion.Substring(3, 2));
            int day = Convert.ToInt32(prod.FechaAdquisicion.Substring(0, 2));
            DateTime fecha = new DateTime(year, month, day);
            dtpFecha.Value = fecha;  
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        public string castingFecha(string fecha) {
            string output = "";
            output += fecha.Substring(0, 2);
            output += '-';
            output += fecha.Substring(3, 2);
            output += '-';
            output += fecha.Substring(6,4);
            return output;
        }

        private void btnAgregar_Click(object sender, EventArgs e) {
            Producto prod = new Producto();
            prod.IDProducto = Int32.Parse(txtID.Text.ToString());
            prod.Nombre = txtNombre.Text;
            prod.Descripcion = txtDescripcion.Text;
            prod.Serie = txtSerie.Text;
            prod.FechaAdquisicion = castingFecha(dtpFecha.Text);
            prod.Color = txtColor.Text;
            prod.TipoAdquisicion = cmbAdquisicion.SelectedItem.ToString();
            prod.NombreArea = cmbArea.SelectedItem.ToString();
            prod.Observaciones = txtObservaciones.Text;
            prod.IDArea = new DAOArea().obtenerUno(cmbArea.Text);
            if (new DAOProducto().agregar(prod)) {
                MessageBox.Show("Producto registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else {
                if(new DAOProducto().modificar(prod)) {
                    MessageBox.Show("Producto modificado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else {
                    MessageBox.Show("NO se pudo almacenar la información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void activarMano(object sender, EventArgs e) {
            Cursor = Cursors.Hand;
        }
        public void desactivarMano(object sender, EventArgs e) {
            Cursor = Cursors.Default;
        }

        private void frmCUProductos_Load(object sender, EventArgs e) {
            // BOTON AGREGAR
            btnAgregar.MouseHover += new EventHandler(this.activarMano);
            btnAgregar.MouseMove += new MouseEventHandler(this.activarMano);
            btnAgregar.MouseLeave += new EventHandler(this.desactivarMano);
            // BOTON CANCELAR
            btnCancelar.MouseHover += new EventHandler(this.activarMano);
            btnCancelar.MouseMove += new MouseEventHandler(this.activarMano);
            btnCancelar.MouseLeave += new EventHandler(this.desactivarMano);
        }
    }
}
