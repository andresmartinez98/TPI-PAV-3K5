using PROYECTO_PAV.GUILayer;
using PROYECTO_PAV.GUILayer.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_PAV
{
    public partial class frmPrincipal : Form
    {  
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //frmLogin login = new frmLogin();
            //login.ShowDialog();

        }

        private void consultarCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionCurso frmDetalle = new frmGestionCurso();
            frmDetalle.ShowDialog();
        }

        private void consultarCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionCategoria frmCategoria = new frmGestionCategoria();
            frmCategoria.ShowDialog();
        }

        private void consultarObjetivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionObjetivos frmObjetivo = new FormGestionObjetivos();
            frmObjetivo.ShowDialog();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void actualizacionCursoUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCursoUsuario frmObjetivo = new frmCursoUsuario();
            frmObjetivo.ShowDialog();
        }

        private void usuariosPorCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteUsuarioPorCurso Reporte = new ReporteUsuarioPorCurso();
            Reporte.ShowDialog();
        }

        private void objetivosDeCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmObjetivoPorCursos Reporte = new frmObjetivoPorCursos();
            Reporte.ShowDialog();
        }

        private void cursosPorUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCursosxUsuarios Reporte = new frmCursosxUsuarios();
            Reporte.ShowDialog();
        }
    }
}
