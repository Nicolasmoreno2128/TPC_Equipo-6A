using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    [Serializable]
    public class Producto
    {
        public int IdProducto { get; set; }

        // FK “planas”
        public int IdMarcaFk { get; set; }
        public int IdCategoriaFk { get; set; }

        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string UrlImagen { get; set; }
        public decimal PrecioProducto { get; set; }
        public Marca IdMarca { get; set; }
        public Categoria IdCategoria { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }

    }
}
