using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using PROYECTO_PAV.BusinessLayer;
using PROYECTO_PAV.GUILayer;

namespace PROYECTO_PAV
{

    public partial class frmLogin : Form
    {
        private readonly UsuarioService usuarioService;

        public string UsuarioLogueado { get; internal set; }



        public frmLogin()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if ((txtUsuario.Text == ""))
            {
                MessageBox.Show("Se debe ingresar un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if ((txtPassword.Text == ""))
            {
                MessageBox.Show("Se debe ingresar una contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var usr = usuarioService.ValidarUsuario(txtUsuario.Text, txtPassword.Text);
           
            if (usr != null)
            {
                UsuarioLogueado = usr.NombreUsuario;
               


                //por si despues queremos poner el alta de usr pero hy que refinr la cosa
                if (usr.NombreUsuario == "administrador")
                {
                    frmPrincipal principal = new frmPrincipal();
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    frmCliente formulario = new frmCliente();

                    formulario.InicializarFormulario(usr);
                    formulario.Show();
                  
                    this.Hide();



                }
            }
            else
            {
               
                txtPassword.Text = "";
                
                txtPassword.Focus();
                
                MessageBox.Show("Debe ingresar usuario y/o contraseña válidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
