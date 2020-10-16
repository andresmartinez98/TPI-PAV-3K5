using PROYECTO_PAV.BusinessLayer;
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
    public partial class FormGestionObjetivos : Form
    {
        private readonly ObjetivoService ObjetivoService ;
        
        public FormGestionObjetivos()
        {
            InitializeComponent();
            InitializeDataGridView();
            ObjetivoService = new ObjetivoService();


        }
        private void InitializeDataGridView()
        {
            dgvObjetivos.ColumnCount = 3;
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
            dgvObjetivos.Columns[2].Name = "Estado";
            dgvObjetivos.Columns[2].DataPropertyName = "borrado";

            dgvObjetivos.Columns[2].Width = 0;


            dgvObjetivos.AutoResizeColumnHeadersHeight();
            dgvObjetivos.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

        }


        private void FormGestionObjetivos_Load(object sender, EventArgs e)
        {

            LlenarCombo(cmbNombreLargo, ObjetivoService.ObtenerTodos(), "Nombre", "NombreLargo");
            LlenarCombo(cmbNombreCorto, ObjetivoService.ObtenerTodos(), "Nombre", "NombreCorto");
            cmbNombreLargo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbNombreLargo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbNombreCorto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbNombreCorto.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private void LlenarCombo(ComboBox cbo, object source, string display, String value)
        {
            cbo.DataSource = source;

            cbo.DisplayMember = display;

            cbo.ValueMember = value;

            cbo.SelectedIndex = -1;
        }

        private void cmbNombreLargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            Dictionary<string, object> parametros = new Dictionary<string, object>();
           
            
            if (!string.IsNullOrEmpty(cmbNombreLargo.Text))
            {
                var nombreLargo = cmbNombreLargo.SelectedValue.ToString();
                parametros.Add("nombre_largo", nombreLargo);
            }
            if (!string.IsNullOrEmpty(cmbNombreCorto.Text))
            {
                var nombreCorto = cmbNombreCorto.SelectedValue.ToString();
                parametros.Add("nombre_corto", nombreCorto);
            }
            if (!chkBorrado.Checked)
            {
                parametros.Add("borrado", 0);
            }
            IList<Objetivo> listObjetivos = ObjetivoService.ObjetivoConFiltros(parametros);

            dgvObjetivos.DataSource = listObjetivos;


            if (dgvObjetivos.Rows.Count == 0)
            {



                MessageBox.Show("No se encontraron coincidencias para el/los filtros ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblObjetivo.Text = "Objetivos Recuperados: " + Convert.ToString(dgvObjetivos.Rows.Count);

            }




        }

        private void dgvObjetivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;
            btnQuitar.Enabled = true;

            try
            {
                if (Convert.ToBoolean(this.dgvObjetivos.Rows[e.RowIndex].Cells["Estado"].Value.ToString()) == true)
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
            frmABMObjetivos form = new frmABMObjetivos();
            form.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            frmABMObjetivos formulario = new frmABMObjetivos();
            var Obj = (Objetivo)dgvObjetivos.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmABMObjetivos.FormMode.eliminar, Obj);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMObjetivos formulario = new frmABMObjetivos();
            var Obj = (Objetivo)dgvObjetivos.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmABMObjetivos.FormMode.actualizar, Obj);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkBorrado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvObjetivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvObjetivos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvObjetivos.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    e.CellStyle.BackColor = Color.DarkGray;
                    dgvObjetivos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                }

            }
        }
    }
}
