using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdVenta { get; set; }     
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; } 
        public string MetodoPago { get; set; } //Se puede usar un enum
    }
}

