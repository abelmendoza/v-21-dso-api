using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstudiante.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public int personaId { get; set; }
        public int tipoUsuarioId { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public bool estado { get; set; }

    }
}
