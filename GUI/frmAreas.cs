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
            dgvAreas.DataSource = new DAOArea().obtenerTodos();
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            if (dgvAreas.SelectedRows.Count == 0) {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                Area area = new Area();
                area.IDArea = Convert.ToInt32(dgvAreas.SelectedRows[0].Cells[0].Value.ToString());
                area.Nombre = dgvAreas.SelectedRows[0].Cells[1].Value.ToString();
                area.Ubicacion = dgvAreas.SelectedRows[0].Cells[2].Value.ToString();
                new frmCUAreas(area).ShowDialog();
                dgvAreas.DataSource = new DAOArea().obtenerTodos();
            }
            
        }

        private void frmAreas_FormClosed(object sender, FormClosedEventArgs e) {
            frmInicio frm = new frmInicio();
            frm.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            if (dgvAreas.SelectedRows.Count == 0) {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                int idArea = Convert.ToInt32(dgvAreas.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult ans = MessageBox.Show("¿Está seguro que desea eliminar el area seleccionada?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ans == DialogResult.Yes) {
                    if (new DAOArea().eliminar(idArea)) {
                        MessageBox.Show("Area eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvAreas.DataSource = new DAOArea().obtenerTodos();
                    }
                    else {
                        MessageBox.Show("NO se pudo eliminar el area seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
