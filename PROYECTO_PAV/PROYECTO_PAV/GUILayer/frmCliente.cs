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

namespace PROYECTO_PAV.GUILayer
{
    public partial class frmCliente : Form
    {

        private Usuario oUsr;
        public frmCliente()
        {
            InitializeComponent();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = oUsr.NombreUsuario;
            this.WindowState = FormWindowState.Maximized;

        }
        public void InicializarFormulario(Usuario oUsrs)
        {

            oUsr = oUsrs;
        }

        private void inscribirseACursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInscripcionCursoUsuario formulario = new frmInscripcionCursoUsuario();

            formulario.InicializarFormulario(oUsr);

            formulario.ShowDialog();

        }
    }
}
