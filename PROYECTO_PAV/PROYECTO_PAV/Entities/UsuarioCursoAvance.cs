using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.Entities
{
    class UsuarioCursoAvance
    {
        public int Avance { get; set; }
        public DateTime Fechafin { get; set; }
        public DateTime FechaInicio { get; set; }

        public string Nombre { get; set; }
        public Curso Curso { get; set; }
        public Usuario Usuario { get; set; }
    }
}
