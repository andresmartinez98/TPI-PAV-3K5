using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.Entities
{
   public  class Categoria
    {
        /* Fue modificada la creacion de la BD. En la tabla 'Categorias' la PK se instancio como:
           " [id_cateogria] [int] IDENTITY(1,1) NOT NULL, " */
        public int IdCategoria { get; set; }

        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }

        public Categoria() { }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
