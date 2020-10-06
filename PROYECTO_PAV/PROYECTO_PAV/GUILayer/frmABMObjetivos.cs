using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PROYECTO_PAV.BusinessLayer;
using PROYECTO_PAV.Entities;
namespace PROYECTO_PAV.GUILayer
{
    public partial class frmABMObjetivos : Form
    {
        private FormMode formMode = FormMode.nuevo;
        private readonly ObjetivoService oObjetivoService;
        private Objetivo oObjetivoSelected;
        public frmABMObjetivos()
        {
            InitializeComponent();
            oObjetivoService = new ObjetivoService();
        }
        public enum FormMode
        {
            nuevo,
            actualizar,
            eliminar = 99
        }

        public void InicializarFormulario(FormMode op, Objetivo objetivoSelected)
        {
            formMode = op;
            oObjetivoSelected = objetivoSelected;
        }

        private void frmABMObjetivos_Load(object sender, EventArgs e)
        {

            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                       
                        this.Text = "Nuevo Objetivo";

                        break;

                    }
             case FormMode.eliminar:
                    {
                        MostrarDatos();
                        this.Text = "Eliminar Objetivo";
                        txtNombreLargo.Enabled = false;
                        txtNombreCorto.Enabled = false;
                       

                        break;
                    }

                case FormMode.actualizar:
                    {
                        this.Text = "Actualizar Objetivo";

                        MostrarDatos();
                        txtNombreLargo.Enabled = true;
                        txtNombreCorto.Enabled = true;

                        break;
                    }
            }
        }
        private void MostrarDatos()
        {
            if (oObjetivoSelected != null)
            {
                txtNombreLargo.Text = oObjetivoSelected.NombreLargo;
                txtNombreCorto.Text = oObjetivoSelected.NombreCorto;                
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        
                        if (ExisteObjetivo() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oObjetivo= new Objetivo();
                                oObjetivo.NombreLargo = txtNombreLargo.Text;
                                oObjetivo.NombreCorto = txtNombreCorto.Text;
                          

                                if (oObjetivoService.CrearObjetivo(oObjetivo))
                                {
                                    MessageBox.Show("¡Objetivo insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Nombre del Objetivo encontrado. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }


                case FormMode.eliminar:
                    {
                        if (MessageBox.Show("¿Seguro que desea eliminar el Objetivo seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oObjetivoService.EliminarObjetivo(oObjetivoSelected))
                            {
                                MessageBox.Show("¡Objetivo eliminado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al eliminar el Objetivo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.actualizar:
                    {
                        if (ExisteObjetivo() == false)

                        {
                            if (ValidarCampos())
                            {
                                oObjetivoSelected.NombreLargo = txtNombreLargo.Text;
                                oObjetivoSelected.NombreCorto = txtNombreCorto.Text;

                                if (oObjetivoService.ActualizarObjetivo(oObjetivoSelected))
                                {
                                    MessageBox.Show("¡Objetivo actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Dispose();
                                }
                                else
                                    MessageBox.Show("Error al actualizar el Objetivo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            break;
                        }
                        else
                        {
                            MessageBox.Show("Nombre del Objetivo encontrado. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }

                    }          
                     
            }
        }
       private bool ExisteObjetivo()
        {
            if (oObjetivoService.ObtenerObjetivo(txtNombreLargo.Text) != null)
                return true;
            if (oObjetivoService.ObtenerObjetivo(txtNombreCorto.Text) != null)
                return true;                
                
            return false;            
        }

        private bool ValidarCampos()
        {
            txtNombreCorto.Focus();
            txtNombreLargo.BackColor = Color.White;
            txtNombreCorto.BackColor = Color.White;
            if (txtNombreLargo.Text == txtNombreCorto.Text)
            {
                MessageBox.Show("Los nombres no deben coincidir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;

            }
            if (txtNombreCorto.Text == string.Empty)
            {
                txtNombreCorto.BackColor = Color.Firebrick;
                txtNombreCorto.Focus();
                return false;
            }
            if (txtNombreLargo.Text == string.Empty)
            {
                txtNombreLargo.BackColor = Color.Firebrick;
                txtNombreLargo.Focus();
                return false;
            }

            return true;
        }

        private void txtNombreLargo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
