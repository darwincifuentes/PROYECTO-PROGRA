using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PROGRA
{
    class CInventario
    {
        string producto;
        string cantidad;
        string precio;

        public string Precio { get => precio; set => precio = value; }
       
        public string Producto { get => producto; set => producto = value; }
        public string Cantidad { get => cantidad; set => cantidad = value; }
    }
}
