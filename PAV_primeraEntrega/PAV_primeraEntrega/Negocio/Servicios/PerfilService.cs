using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PAV_primeraEntrega.Datos.Dao.implementacion;
using PAV_primeraEntrega.Negocio.Entidades;

namespace PAV_primeraEntrega.Negocio.Servicios
{
    public class PerfilService
    {
        private PerfillDaoSqlImp dao;

        public PerfilService()
        {
            dao = new PerfillDaoSqlImp();
        }


        public List<Perfil> FindByNombre(string filter)
        {
            return dao.FindByNombre(filter);
        }

    

       


        public bool borrarPerfil(int id)
        {
            return dao.delete(id);
        }

        public bool crearPerfil(string nombre, List<int> ids)
        {
           

            Perfil oNuevo = new Perfil(0, nombre;

            return dao.add(oNuevo);
        }
    }
}
}
