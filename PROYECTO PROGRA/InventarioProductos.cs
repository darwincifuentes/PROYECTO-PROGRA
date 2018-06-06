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
        
       static int posicionmodificar;
       static List<CInventario> inve = new List<CInventario>();
        
        public InventarioProductos()
        {
            

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CInventario tempal = new CInventario();                         //GUARDAR EN ARCHIVO DE TEXTO   
            tempal.Producto = textBox1.Text;
            tempal.Precio = textBox2.Text;
            tempal.Cantidad = textBox3.Text;
            inve.Add(tempal);

            string fileName = "Productos.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int i = 0; i < inve.Count; i++)
            {
                writer.WriteLine(inve[i].Producto);
                writer.WriteLine(inve[i].Precio);
                writer.WriteLine(inve[i].Cantidad);
            }
            //Cerrar el archivo
            writer.Close();
            MessageBox.Show("Datos Guardados Correctamente");
            textBox1.Text = ("");
            textBox2.Text = ("");
            textBox3.Text = ("");
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

            string fileName = @"C: \Users\Darwin Rodrigo\Desktop\programacion u\progra 3\PROYECTO PROGRA\PROYECTO PROGRA\bin\Debug\Productos.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Se cargan los datos del archivo a la lista de clientes
            while (reader.Peek() > -1)
            {
                //Leer los datos y guardarlos en un temporal
                CInventario tempal = new CInventario();                         //GUARDAR EN ARCHIVO DE TEXTO   
                tempal.Producto = reader.ReadLine();
                tempal.Precio = reader.ReadLine();
                tempal.Cantidad = reader.ReadLine();

                //Agregar a la lista el temporal
                inve.Add(tempal);
            }
            reader.Close();

            //Se recorre la lista de clientes
            for (int i = 0; i < inve.Count; i++)
            {
                //Si se el dato a buscar es igual al dato de la lista mostrarlo en los textbox
                if (inve[i].Producto == textBox1.Text)
                {
                    textBox1.Text = inve[i].Producto;
                    textBox2.Text = inve[i].Precio;
                    textBox3.Text = inve[i].Cantidad;
                    
                    //Guardar en que posicion se encontró el dato para utilizarla mas adelante al momento de modificar
                    posicionmodificar = i;

                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            //Los datos modificados de los textbox, se sobreescriben en la posición donde se encontró el dato
            inve[posicionmodificar].Producto = textBox1.Text;
            inve[posicionmodificar].Precio = textBox2.Text;
            inve[posicionmodificar].Cantidad = textBox3.Text;


            string fileName = @"C: \Users\Darwin Rodrigo\Desktop\programacion u\progra 3\PROYECTO PROGRA\PROYECTO PROGRA\bin\Debug\Productos.txt";

            //Para que sobreescriba los datos existentes se usa CREATE
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);
            //Se recorre toda la lista de clientes, que incluye a los ya modificados y se vuelve a grabar al archivo
            for (int i = 0; i < inve.Count; i++)
            {

                writer.WriteLine(inve[i].Producto);
                writer.WriteLine(inve[i].Precio);
                writer.WriteLine(inve[i].Cantidad);
                

            }

            //Cerrar el archivo
            writer.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
