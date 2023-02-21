using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI {
    public partial class frmCUAreas : Form {

        public frmCUAreas() {
            InitializeComponent();
            int id = new DAOArea().ultimoRegistrado() + 1;
            if (id == 0) {
                id = 1;
            }
            txtID.Text = id.ToString();
        }

        public frmCUAreas(Area area) {
            InitializeComponent();
            txtID.Text = area.IDArea.ToString();
            txtNombre.Text = area.Nombre.ToString();
            txtUbicacion.Text = area.Ubicacion.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e){
            Area objArea = new Area();
            objArea.IDArea = Int32.Parse(txtID.Text.ToString());
            objArea.Nombre = txtNombre.Text;
            objArea.Ubicacion = txtUbicacion.Text;
            if (new DAOArea().agregar(objArea)) {
                MessageBox.Show("Area registrada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else {
                if(new DAOArea().modificar(objArea)) {
                    MessageBox.Show("Area modificada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmCUAreas_Load(object sender, EventArgs e) {
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
