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
    public partial class frmCursoUsuario : Form
    {   

        private readonly UsuarioCursoService UsuarioService;
        private readonly CursoService Cursoservice;
        //lblFechas.Text = DateTime.Now.ToLongDateString();
        public IList<UsuarioCurso> listadoCurso;

 


        public frmCursoUsuario()
        {
            InitializeComponent();
            InitializeDataGridView();
            UsuarioService = new UsuarioCursoService();
            Cursoservice = new CursoService();
            

        }

        private void frmAltaUsuarioCurso_Load(object sender, EventArgs e)
        {

            LlenarCombo(cmbCursos, Cursoservice.ObtenerNombreCurso(), "Nombre", "nombre");
            

        }
        private void LlenarCombo(ComboBox cbo, object source, string display, String value)
        {
            cbo.DataSource = source;

            cbo.DisplayMember = display;

            cbo.ValueMember = value;

            cbo.SelectedIndex = -1;
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

            dgvCurso.Columns[0].Name = "ID";
            dgvCurso.Columns[0].DataPropertyName = "IdUsuario";
            dgvCurso.Columns[1].Name = "Nombre";
            dgvCurso.Columns[1].DataPropertyName = "usuario";
            dgvCurso.Columns[2].Name = "Fecha Inicio";
            dgvCurso.Columns[2].DataPropertyName = "FechaInicio";
            dgvCurso.Columns[3].Name = "Fecha Fin";
            dgvCurso.Columns[3].DataPropertyName = "FechaFin";
            dgvCurso.Columns[4].Name = "Porcentaje";
            dgvCurso.Columns[4].DataPropertyName = "Avance";
       




            dgvCurso.AutoResizeColumnHeadersHeight();
            dgvCurso.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);


        }


            private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtFecha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (listadoCurso != null)
            {
                listadoCurso.Clear();
            }
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(cmbCursos.Text))
            {
                var curso = cmbCursos.SelectedValue.ToString();
                parametros.Add("nombreCurso", curso);
                listadoCurso = UsuarioService.ConsultarCursoConFiltrosGestion(parametros);

                dgvCurso.DataSource = listadoCurso;
            }
            else {

                MessageBox.Show("Ingrese por favor un curso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void dgvCurso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbNombre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // VERIFICAR QUE EL DIA ACTUAL NO SEA MAYOR A LA FECHA MAXIMA
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;

            DateTime fechaInicio;
            DateTime fechaFin;
            TimeSpan fechaResultadoEntreFechas;
            TimeSpan fechaResultadoEntreActual;


            foreach (var i in listadoCurso)
            {
                fechaFin = i.FechaFin;
                fechaInicio = i.FechaInicio;

                fechaResultadoEntreFechas = fechaFin - fechaInicio;
                fechaResultadoEntreActual =fecha- fechaInicio ;


                int resultado = (fechaResultadoEntreActual.Days*100)/fechaResultadoEntreFechas.Days;

                if (fecha < fechaFin)
                {
                    UsuarioService.ActualizarAvance(i, resultado);
                }
                else {
                    UsuarioService.ActualizarAvance(i, 100);
                }

              
            }
            Dictionary<string, object> parametros = new Dictionary<string, object>();

         
           var curso = cmbCursos.SelectedValue.ToString();
           parametros.Add("nombreCurso", curso);
            

            listadoCurso = UsuarioService.ConsultarCursoConFiltrosGestion(parametros);

            dgvCurso.DataSource = listadoCurso;





        }

        private void lblCursos_Click(object sender, EventArgs e)
        {

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {


            
            
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            frmDetalleCursoUsuario formulario = new frmDetalleCursoUsuario();
            var Obj = (UsuarioCurso)dgvCurso.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(Obj);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void dgvCurso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDetalle.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
