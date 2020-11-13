using Microsoft.Reporting.WinForms;
using PROYECTO_PAV.BusinessLayer;
using PROYECTO_PAV.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_PAV.GUILayer.Reportes
{
    public partial class frmCursosxUsuarios : Form
    {

        private readonly UsuarioService UsuarioService ;
        private readonly UsuarioCursoAvanceService UsuarioCursoAvanceService;
        public IList<UsuarioCurso> listadoCurso;
        public frmCursosxUsuarios()
        {
            InitializeComponent();
            UsuarioService = new UsuarioService();
            LlenarCombo(cmbNombre, UsuarioService.ObtenerUsuariosxCurso(), "Nombre", "nombre");
            UsuarioCursoAvanceService = new UsuarioCursoAvanceService();
        }
        private void LlenarCombo(ComboBox cbo, object source, string display, String value)
        {
            cbo.DataSource = source;

            cbo.DisplayMember = display;

       

            cbo.SelectedIndex = -1;
        }

        private void frmCursosxUsuarios_Load(object sender, EventArgs e)
        {

            this.reportUsuarioxCurso.RefreshReport();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(cmbNombre.Text))
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                var nombre = cmbNombre.SelectedValue.ToString();
                parametros.Add("nombre", nombre);





                string strSQL = " select Distinct u.usuario as Nombre ,uca.porc_avance as Porcetaje  ,c.nombre as Curso" +
                                " from Usuarios u left join UsuariosCurso uc on(u.id_usuario = uc.id_usuario) " +
                                 " join UsuariosCursoAvance uca on(uca.id_usuario= uc.id_usuario) " +
                                 " join Cursos c on(uca.id_curso= c.id_curso) " +
                               " where u.usuario= @nombre ";





                reportUsuarioxCurso.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("nombre",
                    cmbNombre.Text)});

            //DATASOURCE
            reportUsuarioxCurso.LocalReport.DataSources.Clear();
                reportUsuarioxCurso.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataManager.GetInstance().ConsultaSQL(strSQL, parametros)));
                reportUsuarioxCurso.RefreshReport();

            }
            else
            {

                MessageBox.Show("Ingrese por favor un curso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
