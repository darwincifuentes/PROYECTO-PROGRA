using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_PROGRA
{
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        private void MENU_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cont = 0;
                string clave;
                clave = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Codigo", "Codigo de Verificacion", "Codigo:", 500, 300);
                if (clave == "1234")
                {
                    InventarioProductos abri = new InventarioProductos();
                    abri.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Codigo no Valido");
                    Application.Exit();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            venta.Show();
            this.Hide();
        }
    }
}