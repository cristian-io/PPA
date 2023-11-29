using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPA
{
    public partial class Form1 : Form
    {
        double precio = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.Date.ToString("d");
            lblPrecio.Text = (0).ToString("C");
        }

        private void cboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producto = cboProductos.Text;

            if (producto.Equals("Coleccion Enterizo Ajustabble")) precio = 75;
            if (producto.Equals("Coleccion Conjunto Pink")) precio = 80;
            if (producto.Equals("Coleccion Jogguers Camuflado")) precio = 65;
            if (producto.Equals("Coleccion Enterizo Tiras Largas")) precio = 75;
            if (producto.Equals("Coleccion Conjunto Deportivo")) precio = 75;


            lblPrecio.Text = precio.ToString("C");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //validando
            if (cboProductos.SelectedIndex == -1)
                MessageBox.Show("Debes selecionar un producto...!");
            else if (txtCantidad.Text == "")
                MessageBox.Show("Debes ingresar una cantidad...!");
            else if (cboTipo.SelectedIndex == -1)
                MessageBox.Show("Debes selecionar un tipo de pago...!");
            else
            {
                //Capturando datos
                string producto = cboProductos.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                string tipo = cboTipo.Text;

                //Procesar calculos 
                double subtotal = cantidad * precio;

                double descuento = 0, recargo = 0;

                if (tipo.Equals("Contado "))
                {
                    descuento = 0.05 * subtotal;
                }
                else
                {
                    recargo = 0.1 * subtotal;
                }
                double precioFinal = subtotal - descuento + recargo;

                // Impresion de resultados 
                ListViewItem fila = new ListViewItem(producto);
                fila.SubItems.Add(cantidad.ToString());
                fila.SubItems.Add(precio.ToString());
                fila.SubItems.Add(tipo);
                fila.SubItems.Add(descuento.ToString());
                fila.SubItems.Add(recargo.ToString());
                fila.SubItems.Add(precioFinal.ToString());


                lvVenta.Items.Add(fila);
                btnCancelar_Click(sender, e);
            }
        }
                
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboProductos.Text = "(Seleccione producto)";
            cboTipo.Text = "(Seleccione tipo)";
            txtCantidad.Clear();
            lblPrecio.Text = 0.ToString("C");
            cboProductos.Focus();

        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
