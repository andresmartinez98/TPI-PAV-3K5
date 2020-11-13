using PROYECTO_PAV.DataAccesLayer;
using PROYECTO_PAV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.BusinessLayer
{
    class UsuarioCursoAvanceService
    {
        private UsuarioCursoAvanceDao OCursoAvanceDao;
        public UsuarioCursoAvanceService()
        {
            OCursoAvanceDao = new UsuarioCursoAvanceDao();
        }
        public IList<UsuarioCursoAvance> ConsultarCursoConFiltros(Dictionary<string, object> parametros)
        {
            return OCursoAvanceDao.GetCursoByFiltersAvance(parametros);
        }

        internal bool CrearCursoUsuario(UsuarioCursoAvance oCurso)
        {
            return OCursoAvanceDao.Create(oCurso);
        }
    }
}
