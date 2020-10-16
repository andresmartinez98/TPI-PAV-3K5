using PROYECTO_PAV.BusinessLayer;
using PROYECTO_PAV.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_PAV.GUILayer
{
    public partial class frmAMBCCurso : Form
    {  
        
        private FormMode formMode = FormMode.nuevo;
        private  CursoService oCursoService;
        private  CategoriaService oCategoriaService;
        private Curso oCursoSelected;
        private readonly ObjetivoService oObjetivoService;
        private  BindingList<Objetivo> listaObjetivos;


        public frmAMBCCurso()
        {
            InitializeComponent();
            oCursoService = new CursoService();
            oCategoriaService = new CategoriaService();
            oObjetivoService = new ObjetivoService();
            listaObjetivos = new BindingList<Objetivo>();

            InitializeDataGridView();
            
        }

        private void InitializeDataGridView()
        {
            dgvObjetivos.ColumnCount = 4;
            dgvObjetivos.ColumnHeadersVisible = true;
            dgvObjetivos.AutoGenerateColumns = false;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);

            dgvObjetivos.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dgvObjetivos.Columns[0].Name = "Nombre Corto";
            dgvObjetivos.Columns[0].DataPropertyName = "nombrecorto";
            dgvObjetivos.Columns[1].Name = "Nombre Largo";
            dgvObjetivos.Columns[1].DataPropertyName = "nombrelargo";
            dgvObjetivos.Columns[2].Name = "Puntos";
            dgvObjetivos.Columns[2].DataPropertyName = "puntos";
            
            dgvObjetivos.Columns[3].Name = "Estado";
            dgvObjetivos.Columns[3].DataPropertyName = "borrado";


            dgvObjetivos.Columns[3].Width = 0;

            dgvObjetivos.AutoResizeColumnHeadersHeight();
            dgvObjetivos.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        public enum FormMode
        {
            nuevo,
            actualizar,
            eliminar = 99
        }

        private void frmAMBCCurso_Load(System.Object sender, System.EventArgs e)
        {
            LlenarCombo(cmbCategoria, oCategoriaService.ObtenerTodos(), "Nombre", "IdCategoria");
            LlenarCombo(cmbObjetivo, oObjetivoService.ObtenerTodos(), "Nombre", "NombreLargo");

            cmbCategoria.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            
            cmbObjetivo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbObjetivo.AutoCompleteSource = AutoCompleteSource.ListItems;

            dgvObjetivos.DataSource = listaObjetivos;





            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nuevo Curso";
                        break;
                    }

                case FormMode.actualizar:
                    {
                        this.Text = "Actualizar Curso";
                        
                        MostrarDatos();
                        txtNombre.Enabled = true;
                        txtDescripcion.Enabled = true;
                        cmbCategoria.Enabled = true;
                        txtFecha.Enabled = true;

                        Dictionary<string, object> parametros = new Dictionary<string, object>();

                        parametros.Add("id_curso", oCursoSelected.IdCurso.ToString());

                        IList<Objetivo> listaObjetivos = oObjetivoService.ConsultarObjetivoConFiltros(parametros);



                        dgvObjetivos.DataSource = listaObjetivos;



                        break;
                    }

                case FormMode.eliminar:
                    {

                     
                        MostrarDatos();
                        this.Text = "Eliminar Curso";
                        txtNombre.Enabled = false;
                        txtDescripcion.Enabled = false;
                        cmbCategoria.Enabled = false;
                        txtFecha.Enabled = false;
                   
                        break;
                    }
            }
        }





        private void MostrarDatos()
        {
            if (oCursoSelected != null)
            {                  
                txtNombre.Text = oCursoSelected.Nombre;
                txtDescripcion.Text = oCursoSelected.Descripcion;
                txtFecha.Text = oCursoSelected.FechaVigencia.ToString("MM/dd/yyyy");
                cmbCategoria.Text = oCursoSelected.Categoria.Nombre;            

            }
        }
        public void InicializarFormulario(FormMode op, Curso cursoSelected)
        {
            formMode = op;
            oCursoSelected =  cursoSelected;
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void btnAceptar_Click(System.Object sender, System.EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        if (ExisteCurso() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oCurso = new Curso();
                                oCurso.Nombre = txtNombre.Text;
                                oCurso.Descripcion = txtDescripcion.Text;                               
                                oCurso.FechaVigencia = Convert.ToDateTime((txtFecha.Text));
                                
                                oCurso.Categoria = new Categoria();
                                oCurso.Categoria.IdCategoria = (int)cmbCategoria.SelectedValue;

                                oCurso.Objetivo = new List<Objetivo>();
                                oCurso.Objetivo = listaObjetivos;
                              
                                

                                if (oCursoService.CrearCurso(oCurso))
                                {
                                    MessageBox.Show("¡Curso insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Nombre de Curso encontrado. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                
                case FormMode.actualizar:

                    {
                       




                        if (ValidarCampos())
                        {                           
                            oCursoSelected.Nombre = txtNombre.Text;
                            oCursoSelected.Descripcion = txtDescripcion.Text;
                            oCursoSelected.FechaVigencia =Convert.ToDateTime(txtFecha.Text);
                            oCursoSelected.Categoria = new Categoria();
                            oCursoSelected.Categoria.IdCategoria = (int)cmbCategoria.SelectedValue;
                            oCursoSelected.Objetivo = new List<Objetivo>();
                            oCursoSelected.Objetivo = listaObjetivos;

                            if (oCursoService.ActualizarCurso(oCursoSelected))
                            {
                                MessageBox.Show("¡Curso actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar el Curso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                        break;
                    }
            
                case FormMode.eliminar:
                    {
                        if (MessageBox.Show("¿Seguro que desea eliminar el Curso seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oCursoService.EliminarCurso(oCursoSelected))
                            {
                                MessageBox.Show("¡Curso eliminado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al eliminar el curso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }              
            }
        }

        private bool ExisteCurso()
        {
            return oCursoService.ObtenerCurso(txtNombre.Text) != null;
        }

        private bool ValidarCampos()
        {
            cmbObjetivo.BackColor = Color.White;
            txtNombre.BackColor = Color.White;
            txtFecha.BackColor = Color.White;
            cmbCategoria.BackColor = Color.White;
            if (txtNombre.Text == string.Empty)
            {
                txtNombre.BackColor = Color.Firebrick;
                txtNombre.Focus();
                return false;
            }
                        

         
            if (!EsFecha(txtFecha.Text))
            {
                
                txtFecha.BackColor = Color.Firebrick;
                txtFecha.Focus();
                return false;
            }

            if (cmbCategoria.Text == string.Empty)
            {
                cmbCategoria.BackColor = Color.Firebrick;
                cmbCategoria.Focus();
                return false;
            }
            if (cmbObjetivo.Text == string.Empty)
            {
                cmbObjetivo.BackColor = Color.Firebrick;
                cmbObjetivo.Focus();
                return false;
            }

            return true;
        }

        public static Boolean EsFecha(String fecha)
        {
            try
            {
                DateTime.Parse(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void txtFecha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            //frmObjetivoCurso form = new frmObjetivoCurso();
            //var curso = (Curso)dgvCurso.CurrentRow.DataBoundItem;
            //form.InicializarFormulario(frmAMBCCurso.FormMode.actualizar, curso);
            //form.ShowDialog();
            //btnDetalle_Click(sender, e);

            //this.Width(450);
            //this.Height(265);

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;





        }

        private void dgvObjetivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                int cantidad = 0;
                int.TryParse(txtAgregar.Text, out cantidad);

                var obj = (Objetivo)cmbObjetivo.SelectedItem;
                listaObjetivos.Add(new Objetivo()
                {
                    NombreCorto = obj.NombreCorto,
                    NombreLargo = obj.NombreLargo,
                    Puntos = cantidad,
                    IdObjetivo = obj.IdObjetivo

                });
            }

    

            //InicializarDetalle();

        }

        private void cmbObjetivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            InicializarDetalle();
        }
        private void InicializarDetalle()
        {

       
            cmbCategoria.SelectedIndex = -1;
            txtAgregar.Text = "";
            cmbObjetivo.SelectedIndex = -1;
            txtDescripcion.Text = "";
            txtNombre.Text = "";
            txtFecha.Text = "";
        }
        private void _btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvObjetivos.CurrentRow != null)
            {
                var obj = (Objetivo)dgvObjetivos.CurrentRow.DataBoundItem;
                listaObjetivos.Remove(obj);
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarObj_Click(object sender, EventArgs e)
        {
            frmABMObjetivos form = new frmABMObjetivos();
            form.ShowDialog();
            
            LlenarCombo(cmbObjetivo, oObjetivoService.ObtenerTodos(), "Nombre", "NombreLargo");
        }

      
        
            
        
        private void gpbObjetivos_Enter(object sender, EventArgs e)
        {

        }

        private void txtAgregar_TextChanged(object sender, EventArgs e)
        {
           
                if (System.Text.RegularExpressions.Regex.IsMatch(txtAgregar.Text, "[^0-9]"))
                {
                    MessageBox.Show("Por favor, introduzca solo numeros.");
                txtAgregar.Text = txtAgregar.Text.Remove(txtAgregar.Text.Length - 1);
                }

            }
        
    }
}