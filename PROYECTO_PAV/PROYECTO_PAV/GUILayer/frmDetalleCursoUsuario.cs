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
    public partial class frmDetalleCursoUsuario : Form

    {

     
        private UsuarioCurso oCursoSelected;
        public frmDetalleCursoUsuario()
        {
            InitializeComponent();
        }

        private void frmDetalleCursoUsuario_Load(object sender, EventArgs e)
        {

            txtNombre.Enabled = false;
            txtPuntuacion.Enabled = false;
            txtObservacion.Enabled = false;
         

            txtNombre.Text = oCursoSelected.Usuario.NombreUsuario;
            txtPuntuacion.Text = oCursoSelected.Puntuacion.ToString(); 
            
            txtObservacion.Text = oCursoSelected.Observaciones;
          
        }
        public void InicializarFormulario( UsuarioCurso objetivoSelected)
        {
           
            oCursoSelected = objetivoSelected;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
