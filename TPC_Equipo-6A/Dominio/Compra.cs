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
        public DateTime? FechaRecepcion { get; set; }
        public decimal TotalCompra { get; set; }
        public int IdProveedor { get; set; }
        public bool Estado { get; set; }
        public List<DetalleCompra> Detalles { get; set; }
    }
}
