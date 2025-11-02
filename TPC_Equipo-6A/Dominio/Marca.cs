using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    [Serializable]
    public class Marca
    {
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }
        public string DescripcionMarca { get; set; }
        public bool Estado { get; set; }

    }
}
