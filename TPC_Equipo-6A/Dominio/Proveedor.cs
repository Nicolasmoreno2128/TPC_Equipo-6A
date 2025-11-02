using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
    }
}
