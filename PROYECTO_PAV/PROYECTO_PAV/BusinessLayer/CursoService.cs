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





        public IList<Curso> ObtenerNombreCurso()
        {
            return oCursoDao.GetNombreCursos();

        }
        public IList<Curso> ConsultarCursoConFiltros(Dictionary<string, object> parametros)
        {
            return oCursoDao.GetCursoByFilters(parametros);
        }
        public IList<Curso> ConsultarCursoConFiltrosGestion(Dictionary<string, object> parametros)
        {
            return oCursoDao.GetCursoByFiltersGestion(parametros);
        }
    
        internal object ObtenerCurso(string curso)
        {
            return oCursoDao.GetCurso(curso);
        }

        internal bool CrearCurso(Curso oCurso)
        {
            return oCursoDao.Create(oCurso);
        }

        internal bool ModificarDelete(Curso oCursoSelected, Objetivo oObjetivo)
        {
            return oCursoDao.ModificarEliminado(oCursoSelected,oObjetivo);
        }

        

        internal bool EliminarCursoObjetivo(Curso oCursoSelected)
        {
            return oCursoDao.DeleteObjetivoCursos(oCursoSelected);
        }
        internal bool EliminarCurso(Curso oCursoSelected)
        {
            return oCursoDao.Delete(oCursoSelected);
        }
        internal bool Existe(Curso oCurso, Objetivo oLista)
        {
            return oCursoDao.ExisteObjetivoBorrado(oCurso, oLista);
        }

        internal bool ActualizarCursos(Curso oCursoSelected)
        {
            return oCursoDao.Update(oCursoSelected);
        }
    }
}
