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
    public partial class frmObjetivoPorCursos : Form
    {
        public frmObjetivoPorCursos()
        {
            InitializeComponent();
        }

        private void frmObjetivoPorCursos_Load(object sender, EventArgs e)
        {

       
            this.reporte.RefreshReport();
        }

        private void btnFechaVigencia_Click(object sender, EventArgs e)
        {
            string strSQL = "select c.nombre as Cursos  ,count(oc.id_curso) as  Objetivos " +
                            "from Cursos c join ObjetivosCursos oc on (c.id_curso = oc.id_curso) " +
                            "Where c.fecha_vigencia < @fechaVigencia " +
                            "group by c.nombre,oc.id_curso ";

            Dictionary<string, object> parametros = new Dictionary<string, object>();

            DateTime FechaVigencia;



            if (DateTime.TryParse(dtpFechaVigencia.Text, out FechaVigencia))
            {

                parametros.Add("fechaVigencia", FechaVigencia);
                


                //DATASOURCE
                reporte.LocalReport.DataSources.Clear();
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataManager.GetInstance().ConsultaSQL(strSQL, parametros)));
                reporte.RefreshReport();

            }
        }

        private void dtpFechaVigencia_ValueChanged(object sender, EventArgs e)
        {

        }

        private void reporte_Load(object sender, EventArgs e)
        {

        }
    }
}
