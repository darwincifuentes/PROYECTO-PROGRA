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
    public partial class Clientes : Form
    {
        List<CCliente> ctemp = new List<CCliente>();
        public Clientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CCliente tempal = new CCliente();                   // REGISTRA CLIENTES EN ARCHIVO TXT
            tempal.Nit = textBox1.Text;
            tempal.Nombre= textBox2.Text;
            tempal.Apellido = textBox3.Text;

            ctemp.Add(tempal);

            string fileName = "Clientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int i = 0; i < ctemp.Count; i++)
            {
                writer.WriteLine(ctemp[i].Nit);
                writer.WriteLine(ctemp[i].Nombre);
                writer.WriteLine(ctemp[i].Apellido);
            }
            //Cerrar el archivo
            writer.Close();
            MessageBox.Show("Datos Guardados Correctamente");
            textBox1.Text = ("");
            textBox2.Text = ("");
            textBox3.Text = ("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = "Clientes.txt";                       // MOSTRAR CLIENTES EN DATAGRIDVIEW
            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                CCliente tempal = new CCliente();
                tempal.Nit = reader.ReadLine();
                tempal.Nombre = reader.ReadLine();
                tempal.Apellido = reader.ReadLine();
                ctemp.Add(tempal);
            }
            //Cerrar el archivo
            reader.Close();
            //Mostrar los datos en una tabla
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = ctemp;
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ventas ven = new Ventas();
            ven.Show();
            this.Hide();
        }
    }
}
