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
            frmLogin login = new frmLogin();
            login.ShowDialog();
           

        }

        private void consultarCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionCurso frmDetalle = new frmGestionCurso();
            frmDetalle.ShowDialog();
        }
    }
}
