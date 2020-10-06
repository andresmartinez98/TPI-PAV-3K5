using PROYECTO_PAV.DataAccesLayer;
using System;
using PROYECTO_PAV.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.BusinessLayer
{
    class ObjetivoService
    {
        private ObjetivoDao oObjetivoDao;

        public ObjetivoService()
        {
            oObjetivoDao = new ObjetivoDao();
        }


        public IList<Objetivo> ObtenerTodos()
        {
            return oObjetivoDao.GetAll();

        }
        public IList<Objetivo> ConsultarObjetivoConFiltros(Dictionary<string, object> parametros)
        {
            return oObjetivoDao.GetObjetivoByFilters(parametros);
        }

        internal object ObtenerObjetivo(string objetivo)
        {
            return oObjetivoDao.GetObjetivo(objetivo);
        }

        internal bool CrearObjetivo(Objetivo oObjetivo)
        {
            return oObjetivoDao.Create(oObjetivo);
        }
        internal bool EliminarObjetivo(Objetivo oObjetivoSelected)
        {
            return oObjetivoDao.Delete(oObjetivoSelected);
        }
        internal bool ActualizarObjetivo(Objetivo oObjetivoSelected)
        {
            return oObjetivoDao.Update(oObjetivoSelected);
        }

    }
}
