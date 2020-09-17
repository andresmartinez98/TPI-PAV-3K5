using PROYECTO_PAV.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.DataAccesLayer
{
   public class CategoriaDao
    {
        public IList<Categoria> GetAll()
        {
            List<Categoria> listadoBugs = new List<Categoria>();

            var strSql = "SELECT id_categoria, nombre FROM Categorias WHERE borrado = 0 ";

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultado.Rows)
            {
                listadoBugs.Add(ObjectMapping(row));
            }

            return listadoBugs;
        }

        private Categoria ObjectMapping(DataRow row)
        {
            Categoria oEstado = new Categoria
            {
                IdCategoria = Convert.ToInt32(row["id_categoria"].ToString()),
                Nombre = row["nombre"].ToString()
            };

            return oEstado;
        }
    }
}
