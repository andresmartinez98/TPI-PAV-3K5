namespace PROYECTO_PAV.GUILayer.Reportes
{
    partial class ReporteUsuarioPorCurso
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
            this.btnFechaVigencia = new System.Windows.Forms.Button();
            this.dtpFechaVigencia = new System.Windows.Forms.DateTimePicker();
            this.ReporteObjetivoCurso = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnFechaVigencia
            // 
            this.btnFechaVigencia.Location = new System.Drawing.Point(247, 12);
            this.btnFechaVigencia.Name = "btnFechaVigencia";
            this.btnFechaVigencia.Size = new System.Drawing.Size(75, 23);
            this.btnFechaVigencia.TabIndex = 4;
            this.btnFechaVigencia.Text = "Generar";
            this.btnFechaVigencia.UseVisualStyleBackColor = true;
            this.btnFechaVigencia.Click += new System.EventHandler(this.btnFechaVigencia_Click);
            // 
            // dtpFechaVigencia
            // 
            this.dtpFechaVigencia.Location = new System.Drawing.Point(12, 12);
            this.dtpFechaVigencia.Name = "dtpFechaVigencia";
            this.dtpFechaVigencia.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaVigencia.TabIndex = 3;
            // 
            // ReporteObjetivoCurso
            // 
            this.ReporteObjetivoCurso.LocalReport.ReportEmbeddedResource = "PROYECTO_PAV.GUILayer.Reportes.ReporteUsuariosxCurso.rdlc";
            this.ReporteObjetivoCurso.Location = new System.Drawing.Point(3, 38);
            this.ReporteObjetivoCurso.Name = "ReporteObjetivoCurso";
            this.ReporteObjetivoCurso.ServerReport.BearerToken = null;
            this.ReporteObjetivoCurso.Size = new System.Drawing.Size(776, 400);
            this.ReporteObjetivoCurso.TabIndex = 5;
            this.ReporteObjetivoCurso.Load += new System.EventHandler(this.ReporteObjetivoCurso_Load);
            // 
            // ReporteUsuarioPorCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReporteObjetivoCurso);
            this.Controls.Add(this.btnFechaVigencia);
            this.Controls.Add(this.dtpFechaVigencia);
            this.Name = "ReporteUsuarioPorCurso";
            this.Text = "ReporteUsuarioPorCurso";
            this.Load += new System.EventHandler(this.ReporteUsuarioPorCurso_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFechaVigencia;
        private System.Windows.Forms.DateTimePicker dtpFechaVigencia;
        private Microsoft.Reporting.WinForms.ReportViewer ReporteObjetivoCurso;
    }
}