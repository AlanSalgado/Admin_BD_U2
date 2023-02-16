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
    public partial class frmAreas : Form {
        public frmAreas() {
            InitializeComponent();
            dgvAreas.DataSource = new DAOArea().obtenerTodos();
        }

        private void btnAgregar_Click(object sender, EventArgs e) {
            new frmCUAreas().ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            new frmCUAreas().ShowDialog();
        }

        private void frmAreas_FormClosed(object sender, FormClosedEventArgs e) {
            frmInicio frm = new frmInicio();
            frm.Show();
        }

        
    }
}
