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


    }
}
