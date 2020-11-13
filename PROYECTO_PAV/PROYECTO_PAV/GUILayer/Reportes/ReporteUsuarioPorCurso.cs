using Microsoft.Reporting.WinForms;
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
    public partial class ReporteUsuarioPorCurso : Form
    {
        public ReporteUsuarioPorCurso()
        {
            InitializeComponent();
        }

        private void ReporteUsuarioPorCurso_Load(object sender, EventArgs e)
        {

            
        }

        private void btnFechaVigencia_Click(object sender, EventArgs e)
        {
            string strSQL = "select c.nombre as nombre ,count(uc.id_curso) as Alumnos "+
                           " from Cursos c join UsuariosCurso uc on (c.id_curso = uc.id_curso) "+
                           " where c.fecha_vigencia<@fechaVigencia " +
                            "group by c.nombre ";

            Dictionary<string, object> parametros = new Dictionary<string, object>();

            DateTime FechaVigencia;



            if (DateTime.TryParse(dtpFechaVigencia.Text, out FechaVigencia))
            {

                parametros.Add("fechaVigencia", FechaVigencia);
                

                //DATASOURCE
                ReporteObjetivoCurso.LocalReport.DataSources.Clear();
                ReporteObjetivoCurso.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataManager.GetInstance().ConsultaSQL(strSQL, parametros)));
                ReporteObjetivoCurso.RefreshReport();

            }
        }

        private void ReporteObjetivoCurso_Load(object sender, EventArgs e)
        {

        }
    }
}
