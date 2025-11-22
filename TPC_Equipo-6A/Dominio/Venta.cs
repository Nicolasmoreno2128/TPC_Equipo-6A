using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal TotalVenta   { get; set; }
        public bool Estado { get; set; }
        public Usuario Usuario { get; set; }
        public List<DetalleVenta> Detalles { get; set; }
        public List<Pago> Pagos { get; set; }

        public Venta()
        {
            Detalles = new List<DetalleVenta>();
            Pagos = new List<Pago>();
        }
    }
}
