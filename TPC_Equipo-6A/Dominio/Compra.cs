using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Compra
    {
        public int idCompra { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public Proveedor Proveedor { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }



    }
}
