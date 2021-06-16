using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstudiante.Models
{
    public class TipoUsuario
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }

    }
}
