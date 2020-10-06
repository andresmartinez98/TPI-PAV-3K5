using System;
using PROYECTO_PAV.BusinessLayer;
using PROYECTO_PAV.Entities;
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
    public partial class frmABMCategorias : Form
    {

        private FormMode formMode = FormMode.nuevo;
        private readonly CategoriaService oCategoriaService;
        private  Categoria oCategoriaSelected;

        public frmABMCategorias()
        {
            InitializeComponent();
            oCategoriaService = new CategoriaService();
          
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
        public enum FormMode
        {
            nuevo,
            actualizar,
            eliminar = 99
        }

        public void InicializarFormulario(FormMode op, Categoria categoriaSelected)
        {
            formMode = op;
            oCategoriaSelected = categoriaSelected;
        }

        private void frmABMCategorias_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nueva Categoria";
                        break;
                    }

                case FormMode.actualizar:
                        {
                           this.Text = "Actualizar Categoria";

                        MostrarDatos();
                        txtNombre.Enabled = true;
                        txtDescripcion.Enabled = true;
                        

                        break;
                    }

                case FormMode.eliminar:
                    {
                        MostrarDatos();
                        this.Text = "Eliminar Categoria";
                        txtNombre.Enabled = false;
                        txtDescripcion.Enabled = false;
                       

                        break;
                    }
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        if (ExisteCategoria() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oCategoria = new Categoria();
                                oCategoria.Nombre = txtNombre.Text;
                                oCategoria.Descripcion = txtDescripcion.Text;
                               
                                if (oCategoriaService.CrearCategoria(oCategoria))
                                {
                                    MessageBox.Show("¡Categoria insertada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Nombre de Categoria encontrado. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case FormMode.actualizar:
                    {
                        if (ValidarCampos())
                        {
                            oCategoriaSelected.Nombre = txtNombre.Text;
                            oCategoriaSelected.Descripcion = txtDescripcion.Text;
                            

                            if (oCategoriaService.ActualizarCategoria(oCategoriaSelected))
                            {
                                MessageBox.Show("¡Categoria actualizada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar la categoria", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.eliminar:
                    {
                        if (MessageBox.Show("¿Seguro que desea eliminar la Categoria seleccionada?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oCategoriaService.EliminarCategoria(oCategoriaSelected))
                            {
                                MessageBox.Show("¡Categoria elimiada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al eliminar la Categoria", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }
        }

        private bool ExisteCategoria()
        {
            return oCategoriaService.ObtenerCategorias(txtNombre.Text) != null;
        }

        private bool ValidarCampos()
        {
            txtNombre.BackColor = Color.White;
            txtDescripcion.BackColor = Color.White;

            if (txtNombre.Text == string.Empty)
            {
                txtNombre.BackColor = Color.Firebrick;
                txtNombre.Focus();
                return false;
            }
            if (txtDescripcion.Text == string.Empty)
            {
                txtDescripcion.BackColor = Color.Firebrick;
                txtDescripcion.Focus();
                return false;
            }
            return true;

        }

        private void MostrarDatos()
        {
            if (oCategoriaSelected != null)
            {
                txtNombre.Text = oCategoriaSelected.Nombre;
                txtDescripcion.Text = oCategoriaSelected.Descripcion;             
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}