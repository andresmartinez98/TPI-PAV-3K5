using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.Entities
{
   public  class Curso
    {
        /* Fue modificada la creacion de la BD. En la tabla 'Cursos' la PK se instancio como:
           " [id_curso] [int] IDENTITY(1,1) NOT NULL, " */
        public int IdCurso { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaVigencia { get; set; }

        public Categoria Categoria { get; set; }

        //public List<Objetivo> Objetivo { get; set; }

        public Curso()
        {
            //Objetivo = new List<Objetivo>();
        }

        public override string ToString()
        {
            return Nombre ;
        }
    }
}
