using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tienda_Ropa
{
    public partial class Form1 : Form
    {
        ConexionDB objetoDatos;   // Declaracion (objeto de la clase Base de Datos)

        List<Tienda> ropa;    // Array de la indumentaria

        public Form1()
        {
            InitializeComponent();
            objetoDatos = new ConexionDB();   // Creacion
            ropa = new List<Tienda>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            habilitar(false);
            cargarLista();
            cargarCombo();
        }

        private void habilitar(bool x)  // Interruptor
        {
            tbCodigo.Enabled = x;
            tbPrecio.Enabled = x;
            cbMarca.Enabled = x;
            rbRemera.Enabled = x;
            rbPantalon.Enabled = x;
            dtFechaIngreso.Enabled = x;
            btGuardar.Enabled = x;
            btSalir.Enabled = x;

            btNuevo.Enabled = !x;
            
        }

        private void limpiar()
        {
            tbCodigo.Text = "";
            tbPrecio.Text = "";
            cbMarca.SelectedIndex = -1;
            rbRemera.Checked = false;
            rbPantalon.Checked = false;
            dtFechaIngreso.Value = DateTime.Today;
        }

        private void cargarCombo()
        {
            DataTable tabla = objetoDatos.ConsultasDB("SELECT * FROM Marcas");

            cbMarca.DataSource = tabla;   // Para que haga la busqueda de las opciones

            cbMarca.DisplayMember = "nombreMarca";
            cbMarca.ValueMember = "id_Marca";

            cbMarca.DropDownStyle = ComboBoxStyle.DropDownList; 
        }

        private void cargarLista()    // Para que cargue cada elemento a la lista del formulario
        {
            ropa.Clear(); Lista_Ropa.Items.Clear();   // Limpiamos el array

            DataTable tabla = objetoDatos.ConsultasDB("SELECT * FROM Inventario");     // SIEMPRE LAS SENTENCIAS SE EJECUTAN ATRAVES DE TABLA

            foreach (DataRow fila in tabla.Rows)   // Creamos la variable fila para que busque todos los campos de la Base de Datos
            {
                Tienda t = new Tienda();

                t.Codigo = Convert.ToInt32(fila["codigo"]);
                t.Precio = Convert.ToInt32(fila["precio"]);
                t.Marca = Convert.ToInt32(fila["marca"]);
                t.Tipo = Convert.ToInt32(fila["tipo"]);
                t.Fecha_ingreso = Convert.ToDateTime(fila["fecha_ingreso"]);

                ropa.Add(t);    // Añadimos todas la indumentaria al array de ropa

                Lista_Ropa.Items.Add(t.ToString());
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            habilitar(true);
            limpiar();
            tbCodigo.Focus();
        }

        private bool validar()    // Para saber si el usuario completo las casillas
        {
            bool valido = true;   // Interruptor

            if (tbCodigo.Text == "")
            {
                MessageBox.Show("Debe ingresar el codigo de la prenda");
                tbCodigo.Focus();
                valido = false;
            }

            else if (tbPrecio.Text == "")
            {
                MessageBox.Show("Debe ingresar el precio de la prenda");
                tbPrecio.Focus();
                valido = false;
            }

            else if (cbMarca.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una marca de la prenda");
                cbMarca.Focus();
                valido = false;
            }

            else if (!rbRemera.Checked && !rbPantalon.Checked)
            {
                MessageBox.Show("Debe elegir que tipo de prenda es");
                rbRemera.Focus();
                valido = false;
            }

            else if (dtFechaIngreso.Value == DateTime.Today)
            {
                MessageBox.Show("Debe colocar la fecha de ingreso de la prenda");
                dtFechaIngreso.Focus();
                valido = false;
            }

            return valido;

        }

        private bool existe(Tienda unaprenda)   // De la lista Tienda va a entrar una prenda, osea una ropa
        {
            for(int i = 0; i < ropa.Count; i++)
            {
                if (ropa[i].Codigo == unaprenda.Codigo)
                {
                    return true;     // Osea que ya existe una prenda ocupando este lugar 
                }
            }

            return false;
        }

        
        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (validar())   // Siempre y cuando sea true
            {
                Tienda t = new Tienda();

                t.Codigo = int.Parse(tbCodigo.Text);
                t.Precio = int.Parse(tbPrecio.Text);
                t.Marca = Convert.ToInt32(cbMarca.SelectedValue);

                if (rbRemera.Checked)
                {
                    t.Tipo = 1;
                }
                else if (rbPantalon.Checked)
                {
                    t.Tipo = 2;
                }

                t.Fecha_ingreso = dtFechaIngreso.Value;

                if (!existe(t))     // Si no existe el objeto de Tienda 't' la creamos con la siguiente sentencia para que se guarde
                {
                    string insertSql = "INSERT INTO Inventario VALUES (" + t.Codigo + "," + t.Precio + "," + t.Marca + "," + t.Tipo + ",'" + t.Fecha_ingreso.ToString("yyyy/MM/dd") + "' ) ";

                    if (objetoDatos.ActualizarDB(insertSql)>0)
                    {
                        MessageBox.Show("Se ingreso correctamente una nueva prenda");
                        cargarLista();
                    }

                }

            }

            habilitar(false);

        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de abandonar la aplicación ?",
               "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                Close();
        }
    }
}