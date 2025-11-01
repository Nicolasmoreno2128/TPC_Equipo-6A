using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum Rol
    {
        Administrador = 0,
        Vendedor = 1,
    }
    public class Usuario
    {
        public long IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }        
        public string Apellido { get; set; }        
        public string Email { get; set; }
        public long Telefono { get; set; }
        public bool Estado { get; set; }
        public Rol Rol { get; set; }
    }
}
