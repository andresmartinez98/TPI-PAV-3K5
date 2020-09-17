using PROYECTO_PAV.DataAccesLayer;
using PROYECTO_PAV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.BusinessLayer
{
    public class CursoService
    {
        private CursoDao oCursoDao;
        public CursoService()
        {
            oCursoDao = new CursoDao();
        }

        public IList<Curso> ObtenerTodos()
        {
            return oCursoDao.GetAll();

        }
        public IList<Curso> ConsultarCursoConFiltros(Dictionary<string, object> parametros)
        {
            return oCursoDao.GetCursoByFilters(parametros);
        }
        internal object ObtenerCurso(string curso)
        {
            return oCursoDao.GetCurso(curso);
        }

        internal bool CrearCurso(Curso oCurso)
        {
            return oCursoDao.Create(oCurso);
        }

        internal bool EliminarCurso(Curso oCursoSelected)
        {
            return oCursoDao.Delete(oCursoSelected);
        }

        internal bool ActualizarCurso(Curso oCursoSelected)
        {
            return oCursoDao.Update(oCursoSelected);
        }
    }
}
