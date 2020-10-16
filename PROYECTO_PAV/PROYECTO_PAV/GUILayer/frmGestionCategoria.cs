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
using PROYECTO_PAV.GUILayer;

namespace PROYECTO_PAV.GUILayer
{
    public partial class frmGestionCategoria : Form
    {
        private readonly CategoriaService CategoriaService;

        public frmGestionCategoria()
        {
            InitializeComponent();
            CategoriaService = new CategoriaService();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
            {

            dgvCategoria.ColumnCount = 3;
            dgvCategoria.ColumnHeadersVisible = true;
            dgvCategoria.AutoGenerateColumns = false;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            
            dgvCategoria.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            
            dgvCategoria.Columns[0].Name = "Nombre";
            dgvCategoria.Columns[0].DataPropertyName = "nombre";
            dgvCategoria.Columns[1].Name = "Descripcion";
            dgvCategoria.Columns[1].DataPropertyName = "descripcion";
            dgvCategoria.Columns[2].Name = "Estado";
            dgvCategoria.Columns[2].DataPropertyName = "borrado";

            dgvCategoria.Columns[2].Width = 0;

            dgvCategoria.AutoResizeColumnHeadersHeight();
            dgvCategoria.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

        }

        private void frmGestionCategoria_Load(object sender, EventArgs e)
        {
            LlenarCombo(cmbNombreCat, CategoriaService.ObtenerTodos(), "Nombre", "Nombre");

            cmbNombreCat.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbNombreCat.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void LlenarCombo(ComboBox cbo, object source, string display, String value)
        {
            cbo.DataSource = source;

            cbo.DisplayMember = display;

            cbo.ValueMember = value;

            cbo.SelectedIndex = -1;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(cmbNombreCat.Text))
            {
                var nombre = cmbNombreCat.SelectedValue.ToString();
                parametros.Add("nombre", nombre);
            }
           
            if (!chkBorrado.Checked)
            {
                parametros.Add("borrado", 0);
            }

            IList<Categoria> listadoCategoria = CategoriaService.ConsultarCategoriaConFiltros(parametros);

            dgvCategoria.DataSource = listadoCategoria;

            if (dgvCategoria.Rows.Count == 0)
            {
               MessageBox.Show("No se encontraron coincidencias para el/los filtros ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);            }
            else
            {
                lblColumnas.Text = "Categorías Recuperadas: "+Convert.ToString(dgvCategoria.Rows.Count);               
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnQuitar.Enabled = true;

             try
                {
                    if (Convert.ToBoolean(this.dgvCategoria.Rows[e.RowIndex].Cells["Estado"].Value.ToString()) == true)
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
            frmABMCategorias form = new frmABMCategorias();

            form.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMCategorias formulario = new frmABMCategorias();
            var categoria = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmABMCategorias.FormMode.actualizar, categoria);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            frmABMCategorias formulario = new frmABMCategorias();
            var categoria = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmABMCategorias.FormMode.eliminar, categoria);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCategoria_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (this.dgvCategoria.Columns[e.ColumnIndex].Name == "Estado")
            {

                if (Convert.ToBoolean(e.Value) == true)
                {
                    e.CellStyle.BackColor = Color.DarkGray;
                    dgvCategoria.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                }

            }
            
        }
    }
}
