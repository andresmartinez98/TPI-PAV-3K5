using PROYECTO_PAV.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_PAV.DataAccesLayer
{
     public class CursoDao
    {

        public IList<Curso> GetAll()
        {
            List<Curso> listadoCurso = new List<Curso>();
            
            String strSql = string.Concat(" SELECT  c.*, ",
                                            "        o.*, ",
                                            "        oc.puntos, ",                                                         
                                            "        k.nombre as 'nombreCat'  ",                                            
                                            " FROM Cursos c",
                                            " LEFT JOIN Categorias k ON (c.id_categoria = k.id_categoria) ",
                                            " LEFT JOIN ObjetivosCursos oc ON (c.id_curso = oc.id_curso)",
                                            " LEFT JOIN Objetivos o ON(oc.id_objetivo = o.id_objetivo)",
                                            " WHERE c.borrado = 0 ");
            var curso = DataManager.GetInstance().ConsultaSQL(strSql);
            var objetivo = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in curso.Rows)
            {
                listadoCurso.Add(ObjectMapping(row));
            }

            return listadoCurso;
        }

        public IList<Curso> GetNombreCursos()
        {
            List<Curso> listadoCurso = new List<Curso>();

            String strSql = string.Concat(" SELECT c.*,ca.nombre as 'nombreCat'  from Cursos c join Categorias ca on (c.id_categoria=ca.id_categoria) where c.borrado=0") ;
            var curso = DataManager.GetInstance().ConsultaSQL(strSql);
            var objetivo = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in curso.Rows)
            {
                listadoCurso.Add(ObjectMapping(row));
            }

            return listadoCurso;
        }
        private Curso ObjectMapping(DataRow row )
        {   Curso oCurso = new Curso();
          
            
            List<Objetivo> objetivo = new List<Objetivo>();   
            
                oCurso.IdCurso =Convert.ToInt32(row["id_curso"].ToString());
                oCurso.Nombre = row["nombre"].ToString();
                oCurso.Descripcion = row["descripcion"].ToString();
                oCurso.FechaVigencia = Convert.ToDateTime(row["fecha_vigencia"].ToString());
                oCurso.Borrado = Convert.ToBoolean(row["borrado"].ToString());
                         
                oCurso.Categoria = new Categoria();
           
                



                oCurso.Categoria.IdCategoria = Convert.ToInt32(row["id_categoria"].ToString());
                oCurso.Categoria.Nombre = row["nombreCat"].ToString();
            
      
                
           return oCurso;            
        }


        public IList<Curso> C(Dictionary<string, object> parametros)
        {
            List<Curso> listadoCurso = new List<Curso>();
            String strSql = string.Concat(" SELECT c.*, ",
                                                       "        o.*, ",
                                                       "        oc.puntos, ",
                                                       "        k.nombre as 'nombreCat'  ",
                                                       " FROM Cursos c",
                                                       " LEFT JOIN Categorias k ON (c.id_categoria = k.id_categoria) ",
                                                       " LEFT JOIN ObjetivosCursos oc ON (c.id_curso = oc.id_curso)",
                                                       " LEFT JOIN Objetivos o ON(oc.id_objetivo = o.id_objetivo)",
                                                       " WHERE 1=1");
            if (parametros.ContainsKey("nombre"))
                strSql += " AND (c.nombre=@nombre) ";

            if (parametros.ContainsKey("categoria"))
                strSql += " AND (a.nombre=@categoria) ";

            if (parametros.ContainsKey("fecha_vigencia"))
                strSql += " AND (c.fecha_vigencia <= @fecha_vigencia ) ";

            if (parametros.ContainsKey("borrado"))
                strSql += " AND (c.borrado=@borrado) ";

            var resultado = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

            foreach (DataRow row in resultado)
            {
                listadoCurso.Add(ObjectMapping(row));
            }

            return listadoCurso;
        }

        public IList<Curso> GetCursoByFiltersAll(Dictionary<string, object> parametros)
        {
            List<Curso> listadoCurso = new List<Curso>();
            String strSql = string.Concat(" SELECT c.*, ",
                                                       "        o.*, ",
                                                       "        oc.puntos, ",
                                                       "        k.nombre as 'nombreCat'  ",
                                                       " FROM Cursos c",
                                                       " LEFT JOIN Categorias k ON (c.id_categoria = k.id_categoria) ",
                                                       " LEFT JOIN ObjetivosCursos oc ON (c.id_curso = oc.id_curso)",
                                                       " LEFT JOIN Objetivos o ON(oc.id_objetivo = o.id_objetivo)",
                                                       " WHERE 1=1");
            if (parametros.ContainsKey("nombre"))
                strSql += " AND (c.nombre=@nombre) ";

            if (parametros.ContainsKey("categoria"))
                strSql += " AND (a.nombre=@categoria) ";

            if (parametros.ContainsKey("fecha_vigencia"))
                strSql += " AND (c.fecha_vigencia <= @fecha_vigencia ) ";

            if (parametros.ContainsKey("borrado"))
                strSql += " AND (c.borrado=@borrado) ";

            var resultado = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

            foreach (DataRow row in resultado)
            {
                listadoCurso.Add(ObjectMapping(row));
            }

            return listadoCurso;
        }

        public IList<Curso> GetCursoByFilters(Dictionary<string, object> parametros)
        {
            List<Curso> listadoCurso = new List<Curso>();
            String strSql = string.Concat(" SELECT c.*, ",
                                                       "        o.*, ",
                                                       "        oc.puntos, ",
                                                       "        k.nombre as 'nombreCat'  ",
                                                       " FROM Cursos c",
                                                       " LEFT JOIN Categorias k ON (c.id_categoria = k.id_categoria) ",
                                                       " LEFT JOIN ObjetivosCursos oc ON (c.id_curso = oc.id_curso)",
                                                       " LEFT JOIN Objetivos o ON(oc.id_objetivo = o.id_objetivo)",
                                                       " WHERE 1=1");
            if (parametros.ContainsKey("nombre"))
                strSql += " AND (c.nombre=@nombre) ";

            if (parametros.ContainsKey("categoria"))
                strSql += " AND (a.nombre=@categoria) ";

            if (parametros.ContainsKey("fecha_vigencia"))
                strSql += " AND (c.fecha_vigencia <= @fecha_vigencia ) ";

            if (parametros.ContainsKey("borrado"))
                strSql += " AND (c.borrado=@borrado) ";

            var resultado = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

            foreach (DataRow row in resultado)
            {
                listadoCurso.Add(ObjectMapping(row));
            }

            return listadoCurso;
        }


        public IList<Curso> GetCursoByFiltersGestion(Dictionary<string, object> parametros)
        {
            List<Curso> listadoCurso = new List<Curso>();

            var strSql = String.Concat(" SELECT c.id_curso, ",
                                       "        c.nombre, ",
                                       "        c.descripcion, ",
                                       "        c.fecha_vigencia, ",
                                       "        a.nombre as nombreCat, ",
                                       "        c.id_categoria, ",
                                       "        c.borrado ",
                                       " FROM Cursos c ",
                                       " INNER JOIN Categorias a on (a.id_categoria = c.id_categoria) ",
                                       " WHERE 1 = 1 ");

            if (parametros.ContainsKey("nombre"))
                strSql += " AND (c.nombre=@nombre) ";

            if (parametros.ContainsKey("categoria"))
                strSql += " AND (a.nombre=@categoria) ";

            if (parametros.ContainsKey("fecha_vigencia"))
                strSql += " AND (c.fecha_vigencia <= @fecha_vigencia ) ";

            if (parametros.ContainsKey("borrado"))
                strSql += " AND (c.borrado=@borrado) ";

            var resultado = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

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
                                            "        c.borrado , ",
                                            "        k.nombre as 'nombreCat'  ",
                                            " FROM Cursos c",
                                            " INNER JOIN Categorias k ON c.id_categoria = k.id_categoria ",
                                            " WHERE c.borrado = 0 ",
                                            " AND c.nombre=@nombre ");

            var parametros = new Dictionary<string, object>();
            parametros.Add("nombre", nombreCurso);
           
            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

           
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }



       
        internal bool ModificarEliminado(Curso oCurso,Objetivo oObjetivo)
        {

            string str_sql = " UPDATE ObjetivosCursos SET  puntos = @puntos , borrado = 0 " +
                             " WHERE id_curso = @id_curso AND id_objetivo=@id_objetivo  ";

           



          
           
                var parametros = new Dictionary<string, object>();
                parametros.Add("id_objetivo", oObjetivo.IdObjetivo);
                parametros.Add("id_curso", oCurso.IdCurso);
                parametros.Add("puntos", oObjetivo.Puntos);
                
           return(DataManager.GetInstance().EjecutarSQL(str_sql, parametros)==1);
          
        }



        internal bool Create(Curso oCurso)
        {
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();


                string str_sql = " INSERT into Cursos (nombre,descripcion,fecha_vigencia,id_categoria,borrado) " +
                                 " values(@nombre,@descripcion,@fecha_vigencia,@id_categoria,0 )";

                var parametros = new Dictionary<string, object>();
                parametros.Add("nombre", oCurso.Nombre);
                parametros.Add("Descripcion", oCurso.Descripcion);
                parametros.Add("fecha_vigencia", oCurso.FechaVigencia);
                parametros.Add("id_categoria", oCurso.Categoria.IdCategoria);



                if (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1)
                {
                    string strSql = string.Concat(" SELECT c.id_curso, ",
                                                "        c.nombre, ",
                                                "        c.descripcion, ",
                                                "        c.fecha_vigencia, ",
                                                "        c.id_categoria , ",
                                                "        c.borrado , ",
                                                "        k.nombre as 'nombreCat'  ",
                                                " FROM Cursos c",
                                                " INNER JOIN Categorias k ON c.id_categoria = k.id_categoria ",
                                                " WHERE c.borrado = 0 ",
                                                " AND c.nombre=@nombre ");

                    var parametros3 = new Dictionary<string, object>();
                    parametros3.Add("nombre", oCurso.Nombre);

                    var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);


                    if (resultado.Rows.Count > 0)
                    {
                        ObjectMapping(resultado.Rows[0]);
                    }

                    int id = 0;
                    Curso variable = new Curso();



                    id = Convert.ToInt32(resultado.Rows[0]["id_curso"].ToString());



                    foreach (var itemObjeto in oCurso.Objetivo)
                    {



                        string str_sql2 = "  Insert into ObjetivosCursos(id_objetivo,id_curso,puntos,borrado) " +
                                           "  values(@id_objetivo,@id_curso,@puntos, 0)";

                        var parametros2 = new Dictionary<string, object>();

                        parametros2.Add("id_objetivo", itemObjeto.IdObjetivo);
                        parametros2.Add("id_curso", id);
                        parametros2.Add("puntos", itemObjeto.Puntos);
                        DataManager.GetInstance().EjecutarSQL(str_sql2, parametros2);
                    }
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                dm.Rollback();
                throw ex;
                //MessageBox.Show("Error al registrar el curso! " + ex.Message + ex.StackTrace, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return false;
            }
            finally
            {
                // Cierra la conexión 
                dm.Close();
            }
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
            
            string str_sql2 = "  Insert into ObjetivosCursos(id_objetivo,id_curso,puntos,borrado) " +
                                       "  values(@id_objetivo,@id_curso,@puntos, 0)";
             

            foreach (var itemObjeto in oCurso.Objetivo)
            {
                var parametros2 = new Dictionary<string, object>();                                            
                parametros2.Add("id_objetivo", itemObjeto.IdObjetivo);
                parametros2.Add("id_curso", oCurso.IdCurso);
                parametros2.Add("puntos", itemObjeto.Puntos);
                DataManager.GetInstance().EjecutarSQL(str_sql2, parametros2);
            }
               
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }



        internal bool ExisteObjetivoBorrado(Curso oCurso, Objetivo oLista)
        {

            string str_sql = " Select * From ObjetivosCursos Where id_curso=@id_curso AND id_objetivo=@id_objetivo AND borrado=1 ";
     
            var parametros = new Dictionary<string, object>();
            
          
            parametros.Add("id_objetivo", oLista.IdObjetivo);

            parametros.Add("id_curso", oCurso.IdCurso);

            var resultado = DataManager.GetInstance().ConsultaSQL(str_sql, parametros);


            if (resultado.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        internal bool Delete(Curso oCurso)
        {
            string str_sql = " UPDATE Cursos " +
                            " SET borrado = 1 " +
                            " WHERE id_curso=@id_curso";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_curso", oCurso.IdCurso);
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }

        internal bool DeleteObjetivoCursos(Curso oCurso)
        {
           
            string str_sql = " UPDATE ObjetivosCursos SET  borrado = 1 " +
                          " WHERE id_curso = @id_curso AND id_objetivo=@id_Objetivo  ";
            var parametros2 = new Dictionary<string, object>();
            foreach (var itemObjeto in oCurso.Objetivo)
            {          

                parametros2.Add("id_objetivo", itemObjeto.IdObjetivo);
                parametros2.Add("id_curso", oCurso.IdCurso);                              

            }
       
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros2) == 1);
        }
    }
}
