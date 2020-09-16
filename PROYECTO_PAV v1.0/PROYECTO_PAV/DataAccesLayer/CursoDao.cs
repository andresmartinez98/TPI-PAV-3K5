using PROYECTO_PAV.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.DataAccesLayer
{
     public class CursoDao
    {

        public IList<Curso> GetAll()
        {
            List<Curso> listadoCurso = new List<Curso>();

            String strSql = string.Concat(  " SELECT c.id_curso, ",
                                            "        c.nombre, ",
                                            "        c.descripcion, ",
                                            "        c.fecha_vigencia, ",
                                            "        c.id_categoria , ",
                                            "        k.nombre as 'nombreCat'  ",
                                            " FROM Cursos c",
                                            " INNER JOIN Categorias k ON c.id_categoria = k.id_categoria ",
                                            " WHERE c.borrado = 0 ");
            var resultado = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultado.Rows)
            {
                listadoCurso.Add(ObjectMapping(row));
            }

            return listadoCurso;
        }

       private Curso ObjectMapping(DataRow row)
        {
            Curso oCurso = new Curso();
                       
                oCurso.IdCurso =Convert.ToInt32( row["id_curso"].ToString());
                oCurso.Nombre = row["nombre"].ToString();
                oCurso.Descripcion = row["descripcion"].ToString();
                oCurso.FechaVigencia = Convert.ToDateTime(row["fecha_vigencia"].ToString());
                             
                oCurso.Categoria = new Categoria();

                oCurso.Categoria.IdCategoria = Convert.ToInt32(row["id_categoria"].ToString());
                oCurso.Categoria.Nombre = row["nombreCat"].ToString();
                
                return oCurso;            
        }

        public IList<Curso> GetCursoByFilters(Dictionary<string,object> parametros)
        {
            List<Curso> listadoCurso = new List<Curso>();

            var strSql = String.Concat(" SELECT c.id_curso, ",
                                       "        c.nombre, ",
                                       "        c.descripcion, ",
                                       "        c.fecha_vigencia, ", 
                                       "        a.nombre as nombreCat, ", 
                                       "        c.id_categoria ",
                                       " FROM Cursos c ",
                                       " INNER JOIN Categorias a on (a.id_categoria = c.id_categoria) ",
                                       " WHERE 1 = 1 " );

            if (parametros.ContainsKey("nombre"))
                strSql += " AND (c.nombre=@nombre) "; 
            
            if (parametros.ContainsKey("categoria"))
                strSql += " AND (a.nombre=@categoria) ";

            if (parametros.ContainsKey("fecha_vigencia"))
                strSql += " AND (c.fecha_vigencia <= @fecha_vigencia ) ";
           
            strSql += " AND c.borrado=0 AND a.borrado=0 ";

        
            var resultado = (DataRowCollection) DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

            foreach (DataRow row in resultado)
            {
                listadoCurso.Add(ObjectMapping(row));
            }

            return listadoCurso;
        }

        public Curso GetCurso(string nombreCurso)
        {

            String strSql = string.Concat(  " SELECT c.id_curso, ",
                                            "        c.nombre, ",
                                            "        c.descripcion, ",
                                            "        c.fecha_vigencia, ",
                                            "        c.id_categoria , ",
                                            "        k.nombre as 'nombreCat'  ",
                                            " FROM Cursos c",
                                            " INNER JOIN Categorias k ON c.id_categoria = k.id_categoria ",
                                            " WHERE c.borrado = 0 ",
                                            "       AND c.nombre=@nombre ");

            var parametros = new Dictionary<string, object>();
            parametros.Add("nombre", nombreCurso);
           
            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

           
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        internal bool Create(Curso oCurso)
        {
            string str_sql = " INSERT into Cursos (nombre,descripcion,fecha_vigencia,id_categoria,borrado) " +
                             " values(@nombre,@descripcion,@fecha_vigencia,@id_categoria,0 )";

            var parametros = new Dictionary<string, object>();
            parametros.Add("nombre", oCurso.Nombre);
            parametros.Add("Descripcion", oCurso.Descripcion);
            parametros.Add("fecha_vigencia", oCurso.FechaVigencia);
            parametros.Add("id_categoria", oCurso.Categoria.IdCategoria);

            
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }

        internal bool Update(Curso oCurso)
        {

            string str_sql = " UPDATE Cursos SET nombre = @nombre, descripcion = @descripcion , fecha_vigencia = @fecha_vigencia , id_categoria = @id_categoria, borrado = 0 " +
                             " WHERE id_curso = @id_curso  ";

            var parametros = new Dictionary<string, object>();
            parametros.Add("nombre", oCurso.Nombre);
            parametros.Add("Descripcion", oCurso.Descripcion);
            parametros.Add("fecha_vigencia", oCurso.FechaVigencia);
            parametros.Add("id_categoria", oCurso.Categoria.IdCategoria);
            parametros.Add("id_curso", oCurso.IdCurso);

            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }

        internal bool Delete(Curso oCurso)
        {
            string str_sql =" UPDATE Cursos "+
                            " SET borrado = 1 "+
                            " WHERE id_curso=@id_curso";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_curso", oCurso.IdCurso);
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }
    }
}
