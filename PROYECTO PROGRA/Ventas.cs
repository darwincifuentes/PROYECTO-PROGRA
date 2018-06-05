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
    public partial class Ventas : Form
    {
        List<CCliente> cte = new List<CCliente>();
        public Ventas()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                comboBox1.Items.Add(i + 1);
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            // BUSCAR CLIENTE POR NIT CASO CONTRARIO REGISTRAR EL CLIENTE

            string fileName = @"C: \Users\Darwin Rodrigo\Desktop\programacion u\progra 3\PROYECTO PROGRA\PROYECTO PROGRA\bin\Debug\Clientes.txt";
            
             FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {

                CCliente altemp = new CCliente();
                altemp.Nit = reader.ReadLine();
                altemp.Nombre = reader.ReadLine();
                altemp.Apellido = reader.ReadLine();
                cte.Add(altemp);
            }

            bool encontrado = false;
            // RECCORER Y BUSCAR ALUMNO POR CARNET=============================
            for (int i = 0; i < cte.Count; i++)
            {
                if (cte[i].Nit == comboBox1.Text)
                {
                    label5.Text = cte[i].Nombre;
                    encontrado = true;
                }
            }
            if (!encontrado)
                {
                MessageBox.Show("Cliente No Registrado");
                Clientes novo = new Clientes();
                novo.Show();
                this.Hide();
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MENU men = new MENU();
            men.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
