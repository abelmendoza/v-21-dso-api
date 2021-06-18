using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstudiante.Models
{
    public class Persona
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correoPersonal { get; set; }
        public string celular { get; set; }
        public string direccion { get; set; }
        public string carnet { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public bool estado { get; set; }

    }
}
