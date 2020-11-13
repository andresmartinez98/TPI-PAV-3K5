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
    public partial class frmInscripcionCursoUsuario : Form

    {
        private BindingList<UsuarioCursoAvance> ListaCursos;
        private Usuario oUsr;
        private BindingList<UsuarioCursoAvance> ListaCursosAgregar;
        private  UsuarioCursoAvanceService UsuarioCursoAvanceService;
        private UsuarioCursoService UsuarioCursoService;

        private CursoService oCursoService;
        public frmInscripcionCursoUsuario()
        {
            InitializeComponent();
            UsuarioCursoAvanceService = new UsuarioCursoAvanceService();
            ListaCursos = new BindingList<UsuarioCursoAvance>();
            oCursoService = new CursoService();
            ListaCursosAgregar = new BindingList<UsuarioCursoAvance>();
            UsuarioCursoService = new UsuarioCursoService();
        }

        private void frmInscripcionCursoUsuario_Load(object sender, EventArgs e)
        {
            LlenarCombo(cmbCurso, oCursoService.ObtenerNombreCurso(), "Nombre", "nombre");
            InitializeDataGridView();
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            parametros.Add("id_usuario", oUsr.IdUsuario.ToString());
            
            IList<UsuarioCursoAvance> ListaCursoss = UsuarioCursoAvanceService.ConsultarCursoConFiltros(parametros);
            
            foreach (var objs in ListaCursoss)
            {
                var obj = new UsuarioCursoAvance();


                obj.Curso = objs.Curso;
                obj.Fechafin = objs.Fechafin;
                obj.FechaInicio = objs.FechaInicio;

                ListaCursos.Add(obj);

            }



            dgvObjetivos.DataSource = ListaCursos;
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
            dgvObjetivos.ColumnCount = 3;
            dgvObjetivos.ColumnHeadersVisible = true;
            dgvObjetivos.AutoGenerateColumns = false;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);

            dgvObjetivos.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

        
            dgvObjetivos.Columns[0].Name = "Curso";
            dgvObjetivos.Columns[0].DataPropertyName = "curso";
            dgvObjetivos.Columns[1].Name = "Fecha Inicio";
            dgvObjetivos.Columns[1].DataPropertyName = "FechaInicio";

            dgvObjetivos.Columns[2].Name = "Fecha Fin";
            dgvObjetivos.Columns[2].DataPropertyName = "FechaFin";


       

            dgvObjetivos.AutoResizeColumnHeadersHeight();
            dgvObjetivos.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            foreach (var obj in ListaCursosAgregar)
            {
                var UsuarioCurso = new UsuarioCursoAvance();
                UsuarioCurso.Avance = 1;
                UsuarioCurso.Curso = obj.Curso;
                UsuarioCurso.Usuario = oUsr;

                UsuarioCurso.Fechafin = obj.Fechafin;
                UsuarioCurso.FechaInicio = obj.FechaInicio;
                UsuarioCursoAvanceService.CrearCursoUsuario(UsuarioCurso);
            }
            ListaCursosAgregar.Clear();

            
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void InicializarFormulario(Usuario oUsrs)
        {

            oUsr = oUsrs;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DateTime fechafin, fechainicio;
            DateTime.TryParse(txtFechaInicio.Text, out fechainicio);
            DateTime.TryParse(txtFechaFin.Text, out fechafin);

            var obj = (Curso)cmbCurso.SelectedItem;

            UsuarioCursoAvance usuarioCurso = new UsuarioCursoAvance();
            usuarioCurso.Curso = obj;
            usuarioCurso.Fechafin = fechafin;
            usuarioCurso.FechaInicio = fechainicio;

            ListaCursos.Add(usuarioCurso);
            ListaCursosAgregar.Add(usuarioCurso);


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
 }

