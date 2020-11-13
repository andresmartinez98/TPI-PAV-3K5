using PROYECTO_PAV.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.DataAccesLayer
{
    class ObjetivoDao
    {


        public IList<Objetivo> GetAll()
        {
            List<Objetivo> listObjetivo = new List<Objetivo>();

            String strSql = string.Concat(" SELECT * "+
                                                  
                                        " FROM Objetivos  ");
            
            var resultado = DataManager.GetInstance().ConsultaSQL(strSql);


            foreach (DataRow row in resultado.Rows)
            {
                listObjetivo.Add(ObjectMapping(row));
            }

            return listObjetivo;
        }
        private Objetivo ObjectMapping(DataRow row)
        {
            Objetivo oObjetivo = new Objetivo();

            oObjetivo.IdObjetivo = Convert.ToInt32(row["id_objetivo"].ToString());
            oObjetivo.NombreCorto = row["nombre_corto"].ToString();
            oObjetivo.NombreLargo = row["nombre_largo"].ToString();
           
             //oObjetivo.Puntos= Convert.ToInt32(row["puntos"].ToString()); 
            
           
           
            oObjetivo.Borrado = Convert.ToBoolean(row["borrado"].ToString());


            return oObjetivo;
        }

        public IList<Objetivo> GetObjetivoByFilters(Dictionary<string, object> parametros)
        {
            List<Objetivo> listObjetivo = new List<Objetivo>();

            String strSql = string.Concat(" SELECT c.*, ",
                                             "        o.*, ",
                                             "        oc.puntos, ",
                                             
                                             "        k.nombre as 'nombreCat'  ",
                                             " FROM Cursos c",
                                             " LEFT JOIN Categorias k ON (c.id_categoria = k.id_categoria) ",
                                             " LEFT JOIN ObjetivosCursos oc ON (c.id_curso = oc.id_curso)",
                                             " LEFT JOIN Objetivos o ON(oc.id_objetivo = o.id_objetivo)",
                                             " WHERE c.borrado = 0  AND oc.borrado=0 ");

            if (parametros.ContainsKey("id_curso"))
                strSql += " AND (c.id_curso=@id_curso) ";
            if (parametros.ContainsKey("nombre_largo"))
                strSql += " AND (nombre_largo=@nombre_largo) ";

            if (parametros.ContainsKey("nombre_corto"))
                strSql += " AND (nombre_corto=@nombre_corto) ";
            
            if (parametros.ContainsKey("borrado"))
                strSql += " AND (borrado=@borrado) ";

        


            var resultado = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

            foreach (DataRow row in resultado)
            {
                listObjetivo.Add(ObjectMappingPuntos(row));
            }

            return listObjetivo;
        }
        public IList<Objetivo> GetObjetivoByFiltersAll(Dictionary<string, object> parametros)
        {
            List<Objetivo> listObjetivo = new List<Objetivo>();

            String strSql = string.Concat(" SELECT c.*, ",
                                             "        o.*, ",
                                             "        oc.puntos, ",

                                             "        k.nombre as 'nombreCat'  ",
                                             " FROM Cursos c",
                                             " LEFT JOIN Categorias k ON (c.id_categoria = k.id_categoria) ",
                                             " LEFT JOIN ObjetivosCursos oc ON (c.id_curso = oc.id_curso)",
                                             " LEFT JOIN Objetivos o ON(oc.id_objetivo = o.id_objetivo)",
                                             " WHERE c.borrado = 0  AND  ");

            if (parametros.ContainsKey("id_curso"))
                strSql += " AND (c.id_curso=@id_curso) ";
            if (parametros.ContainsKey("nombre_largo"))
                strSql += " AND (nombre_largo=@nombre_largo) ";

            if (parametros.ContainsKey("nombre_corto"))
                strSql += " AND (nombre_corto=@nombre_corto) ";

            if (parametros.ContainsKey("borrado"))
                strSql += " AND (borrado=@borrado) ";




            var resultado = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

            foreach (DataRow row in resultado)
            {
                listObjetivo.Add(ObjectMappingPuntos(row));
            }

            return listObjetivo;
        }
        public IList<Objetivo> GetObjetivoByFiltersAllObjetivoCurso(Dictionary<string, object> parametros)
        {
            List<Objetivo> listObjetivo = new List<Objetivo>();

            String strSql = string.Concat(" SELECT c.*, ",
                                             "        o.*, ",
                                             "        oc.puntos, ",

                                             "        k.nombre as 'nombreCat'  ",
                                             " FROM Cursos c",
                                             " LEFT JOIN Categorias k ON (c.id_categoria = k.id_categoria) ",
                                             " LEFT JOIN ObjetivosCursos oc ON (c.id_curso = oc.id_curso)",
                                             " LEFT JOIN Objetivos o ON(oc.id_objetivo = o.id_objetivo)",
                                             " WHERE c.borrado = 0  AND  ");

            if (parametros.ContainsKey("id_curso"))
                strSql += " AND (c.id_curso=@id_curso) ";
         




            var resultado = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

            foreach (DataRow row in resultado)
            {
                listObjetivo.Add(ObjectMappingPuntos(row));
            }

            return listObjetivo;
        }


        public IList<Objetivo> ObjetivoByFilters(Dictionary<string, object> parametros)
        {
            List<Objetivo> listObjetivo = new List<Objetivo>();

            String strSql = string.Concat(" Select o.* " +
                                          "  from objetivos o " +
                                          "where 1=1      ");

            if (parametros.ContainsKey("id_curso"))
                strSql += " AND (c.id_curso=@id_curso) ";
            if (parametros.ContainsKey("nombre_largo"))
                strSql += " AND (nombre_largo=@nombre_largo) ";

            if (parametros.ContainsKey("nombre_corto"))
                strSql += " AND (nombre_corto=@nombre_corto) ";

            if (parametros.ContainsKey("borrado"))
                strSql += " AND (borrado=@borrado) ";




            var resultado = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

            foreach (DataRow row in resultado)
            {
                listObjetivo.Add(ObjectMapping(row));
            }

            return listObjetivo;
        }

        private Objetivo ObjectMappingPuntos(DataRow row)
        {
            Objetivo oObjetivo = new Objetivo();

            oObjetivo.IdObjetivo = Convert.ToInt32(row["id_objetivo"].ToString());
            oObjetivo.NombreCorto = row["nombre_corto"].ToString();
            oObjetivo.NombreLargo = row["nombre_largo"].ToString();

            oObjetivo.Puntos= Convert.ToInt32(row["puntos"].ToString()); 



            oObjetivo.Borrado = Convert.ToBoolean(row["borrado"].ToString());


            return oObjetivo;
        }
        public Objetivo GetObjetivo(string nombreObjetivo)
        {

            String strSql = string.Concat(" SELECT * ",
                                          " FROM Objetivos ",
                                          " WHERE borrado =0  and ( nombre_largo=@nombre or nombre_corto=@nombre)");



            var parametros = new Dictionary<string, object>();
            parametros.Add("nombre", nombreObjetivo);

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);


            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Objetivo> GetObjetivoByFiltersId(Dictionary<string, object> parametros)
        {
            List<Objetivo> listObjetivo = new List<Objetivo>();
            String strSql = string.Concat(" SELECT o.*, ",
                                        "    oc.puntos ",
                                         " FROM Cursos c",
                                      " LEFT JOIN Categorias k ON (c.id_categoria = k.id_categoria) ",
                                      " LEFT JOIN ObjetivosCursos oc ON (c.id_curso = oc.id_curso)",
                                      " LEFT JOIN Objetivos o ON(oc.id_objetivo = o.id_objetivo)",
                                      " WHERE c.borrado = 0  ");
            
           
        

            if (parametros.ContainsKey("id_curso"))
                strSql += " AND (id_curso=@id_curso) ";




           var resultado = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;
            
            foreach (DataRow row in resultado)
            {
                listObjetivo.Add(ObjectMapping(row));
            }

            return listObjetivo;


        }


        internal bool Create(Objetivo oObjetivo)
        {
            string str_sql = " INSERT into Objetivos  ( nombre_largo,nombre_corto,borrado) " +
                             " values (@nombre_largo , @nombre_corto,0 )";

            var parametros = new Dictionary<string, object>();
            parametros.Add("nombre_largo", oObjetivo.NombreLargo);
            parametros.Add("nombre_corto", oObjetivo.NombreCorto);
  


            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }

        //internal bool ExisteObjetivo(Objetivo oObjetivo)
        //{
           
        //    string str_sql = " Select * From Objetivo WHERE nombre_largo=@

        //    var parametros = new Dictionary<string, object>();
        //    parametros.Add("nombre_largo", oObjetivo.NombreLargo);
        //    parametros.Add("nombre_corto", oObjetivo.NombreCorto);



        //    return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        //}
        internal bool Delete(Objetivo oObjetivo)
        {
            string str_sql = " UPDATE Objetivos " +
                            " SET borrado = 1 " +
                            " WHERE id_objetivo=@id_objetivo";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_objetivo", oObjetivo.IdObjetivo);
            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }


        internal bool Update(Objetivo oObjetivo)
        {

            string str_sql = " UPDATE Objetivos SET nombre_largo = @nombre_largo,nombre_corto = @nombre_corto, borrado = 0 " +
                             " WHERE id_objetivo = @id_objetivo  ";

            var parametros = new Dictionary<string, object>();
            parametros.Add("nombre_largo", oObjetivo.NombreLargo);
            parametros.Add("nombre_corto", oObjetivo.NombreCorto);
           
            parametros.Add("id_objetivo", oObjetivo.IdObjetivo);

            return (DataManager.GetInstance().EjecutarSQL(str_sql, parametros) == 1);
        }





    }
}
