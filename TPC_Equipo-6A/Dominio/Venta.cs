using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Venta
    {
        public int idVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }


    }
}
