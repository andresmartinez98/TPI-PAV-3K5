using PROYECTO_PAV.DataAccesLayer;
using PROYECTO_PAV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.BusinessLayer
{
    class UsuarioCursoService
    {

        private UsuarioCursoDao OCursoDao;

        public UsuarioCursoService()
        {
            OCursoDao = new UsuarioCursoDao();
        }

        public IList<UsuarioCurso> ObtenerTodos()
        {
            return OCursoDao.GetAll();
        }

        public void ActualizarAvance(UsuarioCurso oCurso,int avance)
        {
           OCursoDao.ActualizarAvanceUsuario(oCurso, avance);
        }
        public IList<UsuarioCurso> ConsultarCursoConFiltrosGestion(Dictionary<string, object> parametros)
        {
            return OCursoDao.GetCursoByFiltersGestion(parametros);
        }


       



    }
}
