using PROYECTO_PAV.BusinessLayer;
using PROYECTO_PAV.Entities;
using PROYECTO_PAV.GUILayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_PAV
{
    public partial class frmGestionCurso : Form
    {
        private readonly CursoService CursoService;
        private readonly CategoriaService CategoriaService;

        public frmGestionCurso()
        {
            InitializeComponent();
            InitializeDataGridView();
            CursoService = new CursoService();
            CategoriaService = new CategoriaService();
        }

        private void InitializeDataGridView()
        {
            dgvCurso.ColumnCount = 5;
            dgvCurso.ColumnHeadersVisible = true;
            dgvCurso.AutoGenerateColumns = false;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);

            dgvCurso.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            
            dgvCurso.Columns[0].Name = "Nombre";
            dgvCurso.Columns[0].DataPropertyName = "nombre";
            dgvCurso.Columns[1].Name = "Descripcion";
            dgvCurso.Columns[1].DataPropertyName = "descripcion";
            dgvCurso.Columns[2].Name = "Fecha Vigencia";
            dgvCurso.Columns[2].DataPropertyName = "FechaVigencia";
            dgvCurso.Columns[3].Name = "Categorias";
            dgvCurso.Columns[3].DataPropertyName = "categoria";
            dgvCurso.Columns[4].Name = "Estado";
            dgvCurso.Columns[4].DataPropertyName = "borrado";

            dgvCurso.Columns[4].Width = 0;

            dgvCurso.AutoResizeColumnHeadersHeight();
            dgvCurso.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            
        }

        private void GestionCurso_Load(object sender, EventArgs e)
        {
            LlenarDatos();
            
            cmbNombre.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbNombre.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbCategoria.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void LlenarDatos()
        {
            LlenarCombo(cmbNombre, CursoService.ObtenerTodos(), "Nombre", "Nombre");
            LlenarCombo(cmbCategoria, CategoriaService.ObtenerTodos(), "Nombre", "Nombre");
        }

        private void LlenarCombo(ComboBox cbo, object source, string display, String value)
        {
            cbo.DataSource = source;

            cbo.DisplayMember = display;

            cbo.ValueMember = value;

            cbo.SelectedIndex = -1;
        }

        private void cmbNombre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            DateTime fecha;
            

            if (DateTime.TryParse(txtFecha.Text, out fecha))
            {
                parametros.Add("fecha_vigencia", txtFecha.Text);

            }

            if (!string.IsNullOrEmpty(cmbNombre.Text))
            {
                var nombre = cmbNombre.SelectedValue.ToString();
                parametros.Add("nombre", nombre);
            }

            if (!string.IsNullOrEmpty(cmbCategoria.Text))
            {
                var categoria = cmbCategoria.SelectedValue.ToString();
                parametros.Add("categoria", categoria);
            }

            if (!chkBorrado.Checked)
            {
                parametros.Add("borrado", 0);
            }
            
            IList<Curso> listadoCurso = CursoService.ConsultarCursoConFiltros(parametros);

            dgvCurso.DataSource = listadoCurso;

            if (dgvCurso.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron coincidencias para el/los filtros ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                     
            else
            {
                lblCursos.Text = "Cursos Recuperados: " + Convert.ToString(dgvCurso.Rows.Count);

            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmAMBCCurso formulario = new frmAMBCCurso();
            var curso = (Curso)dgvCurso.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmAMBCCurso.FormMode.actualizar, curso);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void dgvCurso_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;
            btnQuitar.Enabled = true;

            try
            {
                if (Convert.ToBoolean(this.dgvCurso.Rows[e.RowIndex].Cells["Estado"].Value.ToString()) == true)
                    {                        
                        btnEditar.Enabled = false;
                        btnQuitar.Enabled = false;                        
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
            }            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAMBCCurso form = new frmAMBCCurso(); 
            form.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            frmAMBCCurso formulario = new frmAMBCCurso();
            var curso = (Curso)dgvCurso.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmAMBCCurso.FormMode.eliminar, curso);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCurso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvCurso_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvCurso.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    e.CellStyle.BackColor = Color.DarkGray;
                    dgvCurso.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;                    
                }                    
                    
            }
        }
    }
}
