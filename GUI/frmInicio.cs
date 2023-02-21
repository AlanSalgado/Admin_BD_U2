using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// System.Data.SqlClient

namespace GUI {
    public partial class frmInicio : Form {
        public frmInicio() {
            InitializeComponent();
            this.Tag = "0";
        }

        private void btnProductos_Click(object sender, EventArgs e) {
            frmProductos frmMenu = new frmProductos();
            frmMenu.Show();
            this.Tag = "1";
            this.Close();
        }

        private void btnAreas_Click(object sender, EventArgs e) {
            frmAreas frmMenu = new frmAreas();
            frmMenu.Show();
            this.Tag = "1";
            this.Close();
        }

        private void frmInicio_FormClosed(object sender, FormClosedEventArgs e) {
            if (this.Tag.ToString() == "0") Application.Exit();
        }

        private void btnIconoProd_Click(object sender, EventArgs e) {
            btnProductos_Click(this, new EventArgs());
        }

        private void btnIconoAreas_Click(object sender, EventArgs e) {
            btnAreas_Click(this, new EventArgs());
        }

        public void activarMano(object sender, EventArgs e) {
            Cursor = Cursors.Hand;
        }
        public void desactivarMano(object sender, EventArgs e) {
            Cursor = Cursors.Default;
        }

        private void frmInicio_Load(object sender, EventArgs e) {
            // BOTON PRODUCTOS
            btnProductos.MouseHover += new EventHandler(this.activarMano);
            btnProductos.MouseMove += new MouseEventHandler(this.activarMano);
            btnProductos.MouseLeave += new EventHandler(this.desactivarMano);
            // BOTON AREAS
            btnAreas.MouseHover += new EventHandler(this.activarMano);
            btnAreas.MouseMove += new MouseEventHandler(this.activarMano);
            btnAreas.MouseLeave += new EventHandler(this.desactivarMano);
            // BOTON ICONO PRODUCTOS
            btnIconoProd.MouseHover += new EventHandler(this.activarMano);
            btnIconoProd.MouseMove += new MouseEventHandler(this.activarMano);
            btnIconoProd.MouseLeave += new EventHandler(this.desactivarMano);
            // BOTON ICONO AREAS
            btnIconoAreas.MouseHover += new EventHandler(this.activarMano);
            btnIconoAreas.MouseMove += new MouseEventHandler(this.activarMano);
            btnIconoAreas.MouseLeave += new EventHandler(this.desactivarMano);
        }
    }
}
