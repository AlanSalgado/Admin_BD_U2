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
    public partial class frmProductos : Form {
        public frmProductos() {
            InitializeComponent();
            dgvInventario.DataSource = new DAOProducto().obtenerTodos();
            dgvInventario.Columns["IDArea"].Visible = false;
            //dgvInventario.Columns["TipoAdquisicion"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e) {
            new frmCUProductos().ShowDialog();
            dgvInventario.DataSource = new DAOProducto().obtenerTodos();
            dgvInventario.Columns["IDArea"].Visible = false;
            //dgvInventario.Columns["TipoAdquisicion"].Visible = false;
        }

        private void frmProductos_FormClosed(object sender, FormClosedEventArgs e) {
            frmInicio frm = new frmInicio();
            frm.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            if (dgvInventario.SelectedRows.Count == 0) {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                Producto prod = new Producto();
                prod.IDProducto = Convert.ToInt32(dgvInventario.SelectedRows[0].Cells[0].Value.ToString());
                prod.Nombre = dgvInventario.SelectedRows[0].Cells[1].Value.ToString();
                prod.Descripcion = dgvInventario.SelectedRows[0].Cells[2].Value.ToString();
                prod.Serie = dgvInventario.SelectedRows[0].Cells[3].Value.ToString();
                prod.Color = dgvInventario.SelectedRows[0].Cells[4].Value.ToString();
                prod.FechaAdquisicion = dgvInventario.SelectedRows[0].Cells[5].Value.ToString();
                prod.TipoAdquisicion = dgvInventario.SelectedRows[0].Cells[6].Value.ToString();
                prod.Observaciones = dgvInventario.SelectedRows[0].Cells[7].Value.ToString();
                prod.NombreArea = dgvInventario.SelectedRows[0].Cells[8].Value.ToString();
                new frmCUProductos (prod).ShowDialog();
                dgvInventario.DataSource = new DAOProducto().obtenerTodos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            if (dgvInventario.SelectedRows.Count == 0) {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                int idProd = Convert.ToInt32(dgvInventario.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult ans = MessageBox.Show("¿Está seguro que desea eliminar el producto seleccionada?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ans == DialogResult.Yes) {
                    if (new DAOProducto().eliminar(idProd)) {
                        MessageBox.Show("Producto eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvInventario.DataSource = new DAOProducto().obtenerTodos();
                        dgvInventario.Columns["IDArea"].Visible = false;
                    }
                    else {
                        MessageBox.Show("NO se pudo eliminar el producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void activarMano(object sender, EventArgs e) {
            Cursor = Cursors.Hand;
        }
        public void desactivarMano(object sender, EventArgs e) {
            Cursor = Cursors.Default;
        }

        private void frmProductos_Load(object sender, EventArgs e) {
            // BOTON AGREGAR
            btnAgregar.MouseHover += new EventHandler(this.activarMano);
            btnAgregar.MouseMove += new MouseEventHandler(this.activarMano);
            btnAgregar.MouseLeave += new EventHandler(this.desactivarMano);
            // BOTON MODIFICAR
            btnModificar.MouseHover += new EventHandler(this.activarMano);
            btnModificar.MouseMove += new MouseEventHandler(this.activarMano);
            btnModificar.MouseLeave += new EventHandler(this.desactivarMano);
            // BOTON ELIMINAR
            btnEliminar.MouseHover += new EventHandler(this.activarMano);
            btnEliminar.MouseMove += new MouseEventHandler(this.activarMano);
            btnEliminar.MouseLeave += new EventHandler(this.desactivarMano);
        }
    }
}
