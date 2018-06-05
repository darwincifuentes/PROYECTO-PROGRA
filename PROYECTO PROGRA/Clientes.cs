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
        int posicionmodificar;
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

            string fileName = @"C: \Users\Darwin Rodrigo\Desktop\programacion u\progra 3\PROYECTO PROGRA\PROYECTO PROGRA\bin\Debug\Clientes1.txt";
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
            for (int i = 0; i <ctemp.Count; i++)
            {
                if (textBox3)
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            string fileName = @"C: \Users\Darwin Rodrigo\Desktop\programacion u\progra 3\PROYECTO PROGRA\PROYECTO PROGRA\bin\Debug\Clientes1.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Se cargan los datos del archivo a la lista de clientes
            while (reader.Peek() > -1)
            {
                CCliente tempal = new CCliente();
                tempal.Nit = reader.ReadLine();
                tempal.Nombre = reader.ReadLine();
                tempal.Apellido = reader.ReadLine();
                ctemp.Add(tempal);
            }
            reader.Close();

            //Se recorre la lista de clientes
            for (int i = 0; i < ctemp.Count; i++)
            {
                //Si se el dato a buscar es igual al dato de la lista mostrarlo en los textbox
                if (ctemp[i].Nombre == textBox2.Text)
                {
                    textBox2.Text = ctemp[i].Nombre;
                    textBox3.Text = ctemp[i].Apellido;
                    textBox1.Text = ctemp[i].Nit;
                    //Guardar en que posicion se encontró el dato para utilizarla mas adelante al momento de modificar
                    posicionmodificar = i;

                }

            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Los datos modificados de los textbox, se sobreescriben en la posición donde se encontró el dato
            ctemp[posicionmodificar].Nombre = textBox2.Text;
            ctemp[posicionmodificar].Apellido = textBox3.Text;
            ctemp[posicionmodificar].Nit = textBox1.Text;


            string fileName = @"C: \Users\Darwin Rodrigo\Desktop\programacion u\progra 3\PROYECTO PROGRA\PROYECTO PROGRA\bin\Debug\Clientes1.txt";

            //Para que sobreescriba los datos existentes se usa CREATE
            FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);
            //Se recorre toda la lista de clientes, que incluye a los ya modificados y se vuelve a grabar al archivo
            for (int i = 0; i < ctemp.Count; i++)
            {

                writer.WriteLine(ctemp[i].Nombre);
                writer.WriteLine(ctemp[i].Apellido);
                writer.WriteLine(ctemp[i].Nit);
                

            }

            //Cerrar el archivo
            writer.Close();
        }
    }
}
