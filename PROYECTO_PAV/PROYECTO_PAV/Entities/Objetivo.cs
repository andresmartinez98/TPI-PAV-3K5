using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.Entities
{
    public class Objetivo
    {
        /* Fue modificada la creacion de la BD. En la tabla 'Objetivos' la PK se instancio como:
           " [id_objetivo] [int] IDENTITY(1,1) NOT NULL, " */
        public int IdObjetivo { get; set; }

        public string  NombreCorto { get; set; }

        public string NombreLargo { get; set; }

        public bool Borrado { get; set; }

        public int Puntos { get; set; }

        public Objetivo() 
        {
        
        }


    }
}
