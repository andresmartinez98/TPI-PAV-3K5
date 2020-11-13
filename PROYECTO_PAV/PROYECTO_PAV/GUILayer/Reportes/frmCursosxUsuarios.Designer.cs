namespace PROYECTO_PAV.GUILayer.Reportes
{
    partial class frmCursosxUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.cmbNombre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.reportUsuarioxCurso = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet1 = new PROYECTO_PAV.GUILayer.Reportes.DataSet1();
            this.CursosXusuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CursosXusuariosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbNombre
            // 
            this.cmbNombre.FormattingEnabled = true;
            this.cmbNombre.Location = new System.Drawing.Point(157, 22);
            this.cmbNombre.Name = "cmbNombre";
            this.cmbNombre.Size = new System.Drawing.Size(181, 21);
            this.cmbNombre.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nombre Usuario";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnConsultar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConsultar.Location = new System.Drawing.Point(361, 22);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(177, 24);
            this.btnConsultar.TabIndex = 24;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // reportUsuarioxCurso
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CursosXusuariosBindingSource;
            this.reportUsuarioxCurso.LocalReport.DataSources.Add(reportDataSource1);
            this.reportUsuarioxCurso.LocalReport.ReportEmbeddedResource = "PROYECTO_PAV.GUILayer.Reportes.ReporteCursosxUsuario.rdlc";
            this.reportUsuarioxCurso.Location = new System.Drawing.Point(15, 68);
            this.reportUsuarioxCurso.Name = "reportUsuarioxCurso";
            this.reportUsuarioxCurso.ServerReport.BearerToken = null;
            this.reportUsuarioxCurso.Size = new System.Drawing.Size(731, 492);
            this.reportUsuarioxCurso.TabIndex = 25;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CursosXusuariosBindingSource
            // 
            this.CursosXusuariosBindingSource.DataMember = "CursosXusuarios";
            this.CursosXusuariosBindingSource.DataSource = this.DataSet1;
            // 
            // frmCursosxUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 562);
            this.Controls.Add(this.reportUsuarioxCurso);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.cmbNombre);
            this.Controls.Add(this.label2);
            this.Name = "frmCursosxUsuarios";
            this.Text = "frmCursosxUsuarios";
            this.Load += new System.EventHandler(this.frmCursosxUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CursosXusuariosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConsultar;
        private Microsoft.Reporting.WinForms.ReportViewer reportUsuarioxCurso;
        private System.Windows.Forms.BindingSource CursosXusuariosBindingSource;
        private DataSet1 DataSet1;
    }
}