namespace PROYECTO_PAV.GUILayer.Reportes
{
    partial class frmObjetivoPorCursos
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
            this.dtpFechaVigencia = new System.Windows.Forms.DateTimePicker();
            this.btnFechaVigencia = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.reporte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // dtpFechaVigencia
            // 
            this.dtpFechaVigencia.Location = new System.Drawing.Point(12, 12);
            this.dtpFechaVigencia.Name = "dtpFechaVigencia";
            this.dtpFechaVigencia.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaVigencia.TabIndex = 1;
            this.dtpFechaVigencia.ValueChanged += new System.EventHandler(this.dtpFechaVigencia_ValueChanged);
            // 
            // btnFechaVigencia
            // 
            this.btnFechaVigencia.Location = new System.Drawing.Point(247, 12);
            this.btnFechaVigencia.Name = "btnFechaVigencia";
            this.btnFechaVigencia.Size = new System.Drawing.Size(75, 23);
            this.btnFechaVigencia.TabIndex = 2;
            this.btnFechaVigencia.Text = "Generar";
            this.btnFechaVigencia.UseVisualStyleBackColor = true;
            this.btnFechaVigencia.Click += new System.EventHandler(this.btnFechaVigencia_Click);
            // 
            // reporte
            // 
            this.reporte.LocalReport.ReportEmbeddedResource = "PROYECTO_PAV.GUILayer.Reportes.ReporteObjetivoCurso.rdlc";
            this.reporte.Location = new System.Drawing.Point(1, 38);
            this.reporte.Name = "reporte";
            this.reporte.ServerReport.BearerToken = null;
            this.reporte.Size = new System.Drawing.Size(800, 419);
            this.reporte.TabIndex = 3;
            this.reporte.Load += new System.EventHandler(this.reporte_Load);
            // 
            // frmObjetivoPorCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reporte);
            this.Controls.Add(this.btnFechaVigencia);
            this.Controls.Add(this.dtpFechaVigencia);
            this.Name = "frmObjetivoPorCursos";
            this.Text = "frmObjetivoPorCursos";
            this.Load += new System.EventHandler(this.frmObjetivoPorCursos_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFechaVigencia;
        private System.Windows.Forms.Button btnFechaVigencia;
        private Microsoft.Reporting.WinForms.ReportViewer ReporteObjetivoCurso;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private Microsoft.Reporting.WinForms.ReportViewer reporte;
    }
}