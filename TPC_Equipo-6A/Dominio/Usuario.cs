﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }        
        public string Apellido { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public bool Estado { get; set; }
    }
}
