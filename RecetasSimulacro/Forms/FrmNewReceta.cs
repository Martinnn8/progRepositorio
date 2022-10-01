using RecetasSimulacro.Datos_Sql.Implementaciones;
using RecetasSimulacro.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSimulacro.Forms
{
    public partial class FrmNewReceta : Form
    {
        private Receta receta;
        private object oServicio;

        public FrmNewReceta()
        {
            InitializeComponent();
            receta = new Receta();
        }

        private void FrmNewReceta_Load(object sender, EventArgs e)
        {

        }

        // M

        private void CagarIngredientes()
        {
            cboProducto.DataSource = oServicio.ObtenerIngredientes();
            cboProducto.DisplayMember = "Nombre";
            cboProducto.ValueMember = "IdIngrediente";
        }

        private void LimpiarCampos()
        {
            txtCheff.Text = "";
            txtNombre.Text = "";
            cboTipo.SelectedIndex = -1;
            cboProducto.SelectedIndex = -1;
            nudCantidad.Value = 1;
            dgvDetalles.Rows.Clear();
            lblNro.Text = "Receta #:" + oServicio.ProximaReceta().ToString();
            lblTotalIngredientes.Text = "Total de Ingredientes: ";
        }

        private bool existe(string selectItm)
        {
            bool aux = false;

            foreach(DataGridViewRow item in dgvDetalles.Rows)
            {
                if (item.Cells["ingrediente"].Value.ToString().Equals(selectItm))
                {
                    aux = true;
                    break;
                }
            }

            return aux;
        }


        // B

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }
            else if(cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de receta valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTipo.Focus();
                return;
            }
            else if(dgvDetalles.Rows.Count < 3)
            {
                MessageBox.Show("Debe ingresar al menos tres ingredientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvDetalles.Focus();
                return;
            }

            receta.Cheff = txtCheff.Text;
            receta.Nombre = txtNombre.Text;
            receta.TipoReceta = cboTipo.SelectedIndex;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if(result == DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {
                return;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cboProducto.SelectedIndex != -1)
            {
                if (!existe(cboProducto.Text))
                {
                    DetalleReceta det = new DetalleReceta();
                    det.Cantidad = (int)nudCantidad.Value;
                    det.Ingrediente = (Ingrediente)cboProducto.SelectedItem;

                    receta.AgregarDetalle(det);

                    dgvDetalles.Rows.Add(new object[] { det.Ingrediente.IdIngrediente, det.Ingrediente.Nombre, det.Cantidad });

                    lblTotalIngredientes.Text = "Total de ingredientes: " + dgvDetalles.Rows.Count.ToString();

                }
            }
        }


    }
}
