using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAV_primeraEntrega.Negocio.Entidades
{
    public class Perfil
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        

        public bool Borrado { get; set; }

        

        public Perfil(int id, String nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
            
        }
    }
}
