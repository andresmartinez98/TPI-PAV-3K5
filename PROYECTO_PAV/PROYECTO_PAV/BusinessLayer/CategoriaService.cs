using PROYECTO_PAV.DataAccesLayer;
using PROYECTO_PAV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.BusinessLayer
{
    public class CategoriaService
    {
        private CategoriaDao oCategoriaDao;
        public CategoriaService()
        {
            oCategoriaDao = new CategoriaDao();
        }

        public IList<Categoria> ObtenerTodos()
        {
            return oCategoriaDao.GetAll();
        }

        public IList<Categoria> ConsultarCategoriaConFiltros(Dictionary<string, object> parametros)
        {
            return oCategoriaDao.GetCategoriasByFilters(parametros);
        }

        internal object ObtenerCategorias(string categoria)
        {
            return oCategoriaDao.GetCategoria(categoria);

        }

        internal bool CrearCategoria(Categoria oCategoria)
        {
            return oCategoriaDao.Create(oCategoria);

        }
        internal bool ActualizarCategoria(Categoria oCategoria)
        {

            return oCategoriaDao.Update(oCategoria);
        }
        internal bool EliminarCategoria(Categoria oCategoria)
        {
            return oCategoriaDao.Delete(oCategoria);

         }
    }
}
