using PROYECTO_PAV.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PAV.DataAccesLayer
{
    class UsuarioCursoDao
    {
        public IList<UsuarioCurso> GetAll()
        {
            List<UsuarioCurso> CursoUsuario = new List<UsuarioCurso>();

            var strSql = "SELECT u.*, k.usuario ,k.id_perfil, c.nombre from UsuariosCurso u INNER JOIN Usuarios K on (u.id_usuario=k.id_usuario) INNER JOIN Cursos c on(c.id_curso=u.id_curso)   where k.borrado=0";

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultado.Rows)
            {
                CursoUsuario.Add(ObjectMapping(row));
            }

            return CursoUsuario;
        }

        private UsuarioCurso ObjectMapping(DataRow row)
        {
            UsuarioCurso oCursoUsuario = new UsuarioCurso();

            oCursoUsuario.IdUsuario = Convert.ToInt32(row["id_usuario"].ToString());
           
            oCursoUsuario.Observaciones = row["observaciones"].ToString();
            oCursoUsuario.FechaFin = Convert.ToDateTime(row["fin"].ToString());
            oCursoUsuario.FechaInicio = Convert.ToDateTime(row["inicio"].ToString());
            oCursoUsuario.Avance = Convert.ToInt32(row["porc_avance"].ToString());


            oCursoUsuario.Usuario = new Usuario();
            oCursoUsuario.Usuario.IdUsuario = Convert.ToInt32(row["id_usuario"].ToString());
            oCursoUsuario.Usuario.NombreUsuario = row["usuario"].ToString();

         

            oCursoUsuario.Curso = new Curso();
            oCursoUsuario.Curso.Nombre = row["nombre"].ToString();
            oCursoUsuario.Curso.IdCurso = Convert.ToInt32(row["id_curso"].ToString());

            



            return oCursoUsuario;
        }


        public void ActualizarAvanceUsuario(UsuarioCurso oCurso, int Avance)

        {
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();


                string str_sql = "Update  UsuariosCursoAvance set porc_avance=@avance " +
                              "where id_curso =@id_curso and id_usuario = @id_usuario";

                var parametros = new Dictionary<string, object>();
                parametros.Add("id_curso", oCurso.Curso.IdCurso);
                parametros.Add("id_usuario", oCurso.IdUsuario);
                parametros.Add("avance", Avance);

                DataManager.GetInstance().ConsultaSQL(str_sql, parametros);


            }
            catch (Exception ex)
            {
                dm.Rollback();
                throw ex;
              
            }
            finally
            {
         
                dm.Close();
            }
        }

        public IList<UsuarioCurso> GetCursoByFiltersGestion(Dictionary<string, object> parametros)
        {
            List<UsuarioCurso> listadoCurso = new List<UsuarioCurso>();
            var strSql = "select Distinct u.usuario,uca.inicio,uca.fin,uca.porc_avance,cu.nombre , uc.id_usuario,uc.puntuacion,uc.observaciones , cu.id_curso " +
            "from Usuarios u  join UsuariosCurso uc on(u.id_usuario = uc.id_usuario) " +
                            " join UsuariosCursoAvance uca on(uc.id_usuario = uca.id_usuario) " +
                            " join Cursos cu on(cu.id_curso = uc.id_curso) " +
                            "where cu.borrado = 0 and uca.id_curso=uc.id_curso";

       

            if (parametros.ContainsKey("nombreCurso"))
                strSql += " AND (cu.nombre=@nombreCurso) ";






            var resultado = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

            foreach (DataRow row in resultado)
            {
                listadoCurso.Add(ObjectMapping(row));
            }

            return listadoCurso;
        }





    }
}
