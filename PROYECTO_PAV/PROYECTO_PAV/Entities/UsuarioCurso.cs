using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.Entities
{
     public class UsuarioCurso
    {
        public Usuario Usuario { get; set; }

        public Curso Curso  { get; set; }

        public int Puntuacion { get; set; }

        public string Observaciones { get; set; }

        public DateTime FechaInicio { get; set; }

        public  DateTime FechaFin { get; set; }
    }
}