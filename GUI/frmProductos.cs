using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI {
    public partial class frmProductos : Form {
        public frmProductos() {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e) {
            new frmCUProductos().ShowDialog();
        }

        private void frmProductos_FormClosed(object sender, FormClosedEventArgs e) {
            frmInicio frm = new frmInicio();
            frm.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            new frmCUProductos().ShowDialog();
        }
    }
}
