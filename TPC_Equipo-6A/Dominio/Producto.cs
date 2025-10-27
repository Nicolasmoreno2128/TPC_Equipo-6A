using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }

    }
}
