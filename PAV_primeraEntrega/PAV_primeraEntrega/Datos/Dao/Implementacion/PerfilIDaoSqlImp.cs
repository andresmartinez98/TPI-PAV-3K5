using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PAV_primeraEntrega.Negocio.Entidades;
using PAV_primeraEntrega.Datos.Dao.Interfaz;
using PAV_primeraEntrega.Datos.Helper;
using System.Data;

namespace PAV_primeraEntrega.Datos.Dao.Implementacion
{
    public class PerfillDaoSqlImp : IDao<Perfil>
    {

        //Vamos a reutilizar este método para crear cada objeto Per:
        public Perfil findById(int id)
        {
            string sql = "SELECT * FROM Perfiles p WHERE borrado = 'N' AND p.id_perfil = " + id.ToString();
            DataTable perfileDT = DBHelper.getDBHelper().ConsultaSQL(sql);
            DataTable opcionesMenuDT = null;

            if (perfileDT != null && perfileDT.Rows.Count > 0)
            {
                sql = "SELECT OM.* FROM Opciones_perfil OP, OpcionMenu OM WHERE OP.id_opcion_menu = OM.id_opcion_menu AND OP.id_perfil = " + id;
                opcionesMenuDT = DBHelper.getDBHelper().ConsultaSQL(sql);
                if (opcionesMenuDT.Rows.Count > 0)
                    return mapper(perfileDT.Rows[0], opcionesMenuDT);
            }
            return null;
        }

        public List<OpcionMenu> getOpcionesMenuAll()
        {
            List<OpcionMenu> lst = new List<OpcionMenu>();

            string query = "SELECT OM.* FROM  OpcionMenu OM";
            DataTable t = DBHelper.getDBHelper().ConsultaSQL(query);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_opcion_menu"].ToString());
                OpcionMenu op = new OpcionMenu(id, row["n_opcion"].ToString());
                lst.Add(op);
            }
            return lst;
        }

        public List<Perfil> FindByNombre(string filter)
        {
            string sql = "SELECT id_perfil FROM Perfiles WHERE borrado = 'N' AND n_perfil LIKE '%' + @param1 + '%'";
            DataTable data = DBHelper.getDBHelper().ConsultarSQLConParametros(sql, new Object[] { filter });
            List<Perfil> list = new List<Perfil>();
            foreach (DataRow row in data.Rows)
            {
                int id = Convert.ToInt32(row[0].ToString());
                list.Add(findById(id));
            }

            return list;
        }

        public List<OpcionMenu> getOpcionesByPerfil(int id)
        {
            return findById(id).OpcionesMenu;
        }



        public bool delete(int id)
        {
            //IMPORTANTE: en vez de hacer un delete, hacemos UPDATE porque es BORRADO LÓGICO 
            String sql = "UPDATE Perfiles SET borrado = 'S' WHERE id_perfil=" + id;
            return DBHelper.getDBHelper().ejecutarSQL(sql) != 0;

        }

        private Perfil mapper(DataRow perfilRow, DataTable opciones)
        {
            Perfil oPerfil = new Perfil();
            OpcionMenu oOpcionMenu = null;
            List<OpcionMenu> opcionesMenu = new List<OpcionMenu>();

            oPerfil.Id = Convert.ToInt32(perfilRow["id_perfil"].ToString());
            oPerfil.Nombre = perfilRow["n_perfil"].ToString();

            //agregamos este atributo tanto en la tabla como en la entidad
            //para trabajar solo con  registros activos, no borrados.
            oPerfil.Borrado = perfilRow["n_perfil"].ToString().Equals("S");
            foreach (DataRow opRow in opciones.Rows)
            {
                oOpcionMenu = new OpcionMenu();
                oOpcionMenu.Id = Convert.ToInt32(opRow["id_opcion_menu"].ToString());
                oOpcionMenu.Nombre = opRow["n_opcion"].ToString();
                opcionesMenu.Add(oOpcionMenu);
            }
            oPerfil.OpcionesMenu = opcionesMenu;

            return oPerfil;
        }

        public IList<Perfil> getAll()
        {
            //falta completar implemtación
            return null;
        }

        public bool add(Perfil obj)
        {
            string query = "DECLARE @idPerfil int;";
            query += "Insert INTO Perfiles (n_perfil, borrado) VALUES ('" + obj.Nombre + "', 'N');";
            query += "SELECT @idPerfil = @@IDENTITY;";
            foreach (OpcionMenu om in obj.OpcionesMenu)
            {
                query += "Insert INTO Opciones_perfil(id_opcion_menu, id_perfil) VALUES(" + om.Id.ToString() + ", @idPerfil);";
            }

            return DBHelper.getDBHelper().ejecutarSQL(query) > 0;
        }
    }
}
