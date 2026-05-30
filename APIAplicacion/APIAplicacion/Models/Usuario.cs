using System;
using System.Collections.Generic;
using System.Text;

namespace APIAplicacion.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime FechaDeNacimiento { get; set; }

    }
}
