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
    public partial class frmObjetivosPorCurso : Form
    {
        public frmObjetivosPorCurso()
        {
            InitializeComponent();
        }

        private void frmObjetivosPorCurso_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.Cursos' table. You can move, or remove it, as needed.
            this.CursosTableAdapter.Fill(this.DataSet1.Cursos);

            this.reportViewer1.RefreshReport();
        }
    }
}
