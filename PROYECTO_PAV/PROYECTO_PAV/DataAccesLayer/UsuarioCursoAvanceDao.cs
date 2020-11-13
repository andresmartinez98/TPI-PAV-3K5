using PROYECTO_PAV.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.DataAccesLayer
{
    class UsuarioCursoAvanceDao
    {


        public IList<UsuarioCursoAvance> GetCursoByFiltersAvance(Dictionary<string, object> parametros)
        {
            List<UsuarioCursoAvance> listadoCurso = new List<UsuarioCursoAvance>();
            //var strSql = "select u.usuario,uca.inicio,uca.fin,uca.porc_avance,cu.nombre , uc.id_usuario,uc.puntuacion,uc.observaciones , cu.id_curso " +
            //"from Usuarios u inner join UsuariosCurso uc on(u.id_usuario = uc.id_usuario) " +
            //                "inner join UsuariosCursoAvance uca on(uc.id_usuario = uca.id_usuario) " +
            //                "inner join Cursos cu on(cu.id_curso = uc.id_curso) " +
            //                "where cu.borrado = 0 ";

            var strSql = "select Distinct u.usuario,uca.inicio,uca.fin,uca.porc_avance,cu.nombre , uc.id_usuario,uc.puntuacion,uc.observaciones , cu.id_curso " +
            "from Usuarios u  join UsuariosCurso uc on(u.id_usuario = uc.id_usuario) " +
                            " join UsuariosCursoAvance uca on(uc.id_usuario = uca.id_usuario) " +
                            " join Cursos cu on(cu.id_curso = uc.id_curso) " +
                            "where cu.borrado = 0 and uca.id_curso=uc.id_curso ";


            if (parametros.ContainsKey("id_usuario"))
                strSql += " AND (uc.id_usuario=@id_usuario) ";
            


            var resultado = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

            foreach (DataRow row in resultado)
            {
                listadoCurso.Add(ObjectMapping(row));
            }

            return listadoCurso;
        }



        private UsuarioCursoAvance ObjectMapping(DataRow row)
        {
            UsuarioCursoAvance oCursoUsuario = new UsuarioCursoAvance();

           

           
            oCursoUsuario.FechaInicio = Convert.ToDateTime(row["inicio"].ToString());
            oCursoUsuario.Fechafin = Convert.ToDateTime(row["inicio"].ToString());
            oCursoUsuario.Avance = Convert.ToInt32(row["porc_avance"].ToString());


            oCursoUsuario.Usuario = new Usuario();
            oCursoUsuario.Usuario.IdUsuario = Convert.ToInt32(row["id_usuario"].ToString());
            oCursoUsuario.Usuario.NombreUsuario = row["usuario"].ToString();
            
            
           


            oCursoUsuario.Curso = new Curso();
            oCursoUsuario.Curso.Nombre = row["nombre"].ToString();
            oCursoUsuario.Curso.IdCurso = Convert.ToInt32(row["id_curso"].ToString());





            return oCursoUsuario;
        }
        internal bool Create(UsuarioCursoAvance oCurso)
        {
            string str_sql = " INSERT into UsuariosCurso  ( id_usuario,id_curso) " +
                             " values (@id_usuario , @id_curso)";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_usuario", oCurso.Usuario.IdUsuario);
            parametros.Add("id_curso", oCurso.Curso.IdCurso);
            DataManager.GetInstance().EjecutarSQL(str_sql, parametros);



           string str_sql2 = " Insert into  UsuariosCursoAvance   (id_usuario,id_curso,inicio,fin,porc_avance) " +
                             "  Values (@id_usuario,@id_curso,@inicio,@fin,1) ";
            var parametros2 = new Dictionary<string, object>();
            parametros2.Add("id_usuario", oCurso.Usuario.IdUsuario);
            parametros2.Add("id_curso", oCurso.Curso.IdCurso);
            parametros2.Add("inicio", oCurso.FechaInicio);
            parametros2.Add("fin", oCurso.Fechafin);
           
            return (DataManager.GetInstance().EjecutarSQL(str_sql2, parametros2) == 1);
        }


    }
}
