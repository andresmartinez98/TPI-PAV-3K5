using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAV_primeraEntrega.Negocio.Entidades
{
   public class Usuario
    {
        private int IdUsuario { get; set; }
        public string  Password { get; set; }
        public string Email { get; set; }
        public bool Borrado { get; set; }
        public string Estado { get; set; }
        public Perfil Perfil { get; set; }

    }
}
