using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PROYECTO_PROGRA
{
    public partial class InventarioProductos : Form
    {
        List<CInventario> inve = new List<CInventario>();
        
        public InventarioProductos()
        {
            

            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                comboBox1.Items.Add(i+1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CInventario tempal = new CInventario();                         //GUARDAR EN ARCHIVO DE TEXTO   
            tempal.Producto = textBox1.Text;
            tempal.Cantidad = Convert.ToInt16(comboBox1.Text);
            tempal.Precio= textBox2.Text;

            inve.Add(tempal);

            string fileName = "Productos.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int i = 0; i < inve.Count; i++)
            {
                writer.WriteLine(inve[i].Producto);
                writer.WriteLine(inve[i].Cantidad);
                writer.WriteLine(inve[i].Precio);
            }
            //Cerrar el archivo
            writer.Close();
            MessageBox.Show("Datos Guardados Correctamente");
            comboBox1.Text=("");
            textBox2.Text = ("");
            textBox1.Text = ("");
        }

        private void InventarioProductos_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MENU menu = new MENU();
            menu.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
