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

            var strSql = "SELECT id_categoria, nombre , descripcion FROM Categorias WHERE borrado = 0 ";

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultado.Rows)
            {
                listadoBugs.Add(ObjectMapping(row));
            }

            return listadoBugs;
        }

        public IList<Categoria> GetCategoriasByFilters(Dictionary<string,object> parametros)
        {

            List<Categoria> listCategorias = new List<Categoria>();

            var strSql = String.Concat(" select * ",
                                       " from Categorias ",
                                       " where 1 = 1 ");

            if (parametros.ContainsKey("nombre"))
                strSql += " AND (nombre=@nombre) ";

            if (parametros.ContainsKey("borrado"))
                strSql += " AND (borrado=@borrado) ";



            var resultado = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

            foreach (DataRow row in resultado)
            {
                listCategorias.Add(ObjectMapping(row));

            }

            return listCategorias;

        }

        public Categoria GetCategoria(string categoria)


        {
            String strSql = string.Concat(  " select * ",
                                            " from Categorias ",
                                            " where nombre = @nombre and borrado=0 ");


            var parametros = new Dictionary<string, object>();
            parametros.Add("nombre", categoria);
            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);


            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;



        }
        internal bool Update(Categoria oCategoria)
        {

            string str_sql = " UPDATE Categorias SET nombre = @nombre, descripcion = @descripcion , borrado = 0 " +
                             " WHERE id_categoria = @id_categoria  ";

            var parametros = new Dictionary<string, object>();
            parametros.Add("nombre", oCategoria.Nombre);
            parametros.Add("Descripcion", oCategoria.Descripcion);
           
            parametros.Add("id_categoria", oCategoria.IdCategoria);

            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }
        internal bool Delete(Categoria oCategoria)
        {
            string str_sql = " UPDATE Categorias " +
                            " SET borrado = 1 " +
                            " WHERE id_categoria=@id_categoria";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_categoria", oCategoria.IdCategoria);
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }


        internal bool Create(Categoria oCategoria)
        {
            string str_sql = " INSERT into Categorias (nombre,descripcion,borrado) " +
                             " values(@nombre,@descripcion,0 )";

            var parametros = new Dictionary<string, object>();
            parametros.Add("nombre", oCategoria.Nombre);
            parametros.Add("Descripcion", oCategoria.Descripcion);
     


            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }




        private Categoria ObjectMapping(DataRow row)
        {
            Categoria oCategoria = new Categoria();


            oCategoria.IdCategoria = Convert.ToInt32(row["id_categoria"].ToString());
            oCategoria.Nombre = row["nombre"].ToString();
            oCategoria.Descripcion = row["descripcion"].ToString();

          

            return oCategoria;
        }
    }
}
