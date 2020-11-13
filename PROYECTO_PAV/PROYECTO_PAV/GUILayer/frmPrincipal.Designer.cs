namespace PROYECTO_PAV
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarCategoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarObjetivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizacionCursoUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosPorCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objetivosDeCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.cursosPorUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(124, 528);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarCursosToolStripMenuItem,
            this.consultarCategoriasToolStripMenuItem,
            this.consultarObjetivosToolStripMenuItem,
            this.actualizacionCursoUsuariosToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(115, 19);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // consultarCursosToolStripMenuItem
            // 
            this.consultarCursosToolStripMenuItem.Name = "consultarCursosToolStripMenuItem";
            this.consultarCursosToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.consultarCursosToolStripMenuItem.Text = "Consultar Cursos";
            this.consultarCursosToolStripMenuItem.Click += new System.EventHandler(this.consultarCursosToolStripMenuItem_Click);
            // 
            // consultarCategoriasToolStripMenuItem
            // 
            this.consultarCategoriasToolStripMenuItem.Name = "consultarCategoriasToolStripMenuItem";
            this.consultarCategoriasToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.consultarCategoriasToolStripMenuItem.Text = "Consultar Categorias";
            this.consultarCategoriasToolStripMenuItem.Click += new System.EventHandler(this.consultarCategoriasToolStripMenuItem_Click);
            // 
            // consultarObjetivosToolStripMenuItem
            // 
            this.consultarObjetivosToolStripMenuItem.Name = "consultarObjetivosToolStripMenuItem";
            this.consultarObjetivosToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.consultarObjetivosToolStripMenuItem.Text = "Consultar Objetivos";
            this.consultarObjetivosToolStripMenuItem.Click += new System.EventHandler(this.consultarObjetivosToolStripMenuItem_Click);
            // 
            // actualizacionCursoUsuariosToolStripMenuItem
            // 
            this.actualizacionCursoUsuariosToolStripMenuItem.Name = "actualizacionCursoUsuariosToolStripMenuItem";
            this.actualizacionCursoUsuariosToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.actualizacionCursoUsuariosToolStripMenuItem.Text = "Actualizacion Curso Usuarios";
            this.actualizacionCursoUsuariosToolStripMenuItem.Click += new System.EventHandler(this.actualizacionCursoUsuariosToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosPorCursoToolStripMenuItem,
            this.objetivosDeCursosToolStripMenuItem,
            this.cursosPorUsuariosToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(115, 19);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // usuariosPorCursoToolStripMenuItem
            // 
            this.usuariosPorCursoToolStripMenuItem.Name = "usuariosPorCursoToolStripMenuItem";
            this.usuariosPorCursoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosPorCursoToolStripMenuItem.Text = "Usuarios Por Curso";
            this.usuariosPorCursoToolStripMenuItem.Click += new System.EventHandler(this.usuariosPorCursoToolStripMenuItem_Click);
            // 
            // objetivosDeCursosToolStripMenuItem
            // 
            this.objetivosDeCursosToolStripMenuItem.Name = "objetivosDeCursosToolStripMenuItem";
            this.objetivosDeCursosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.objetivosDeCursosToolStripMenuItem.Text = "Objetivos de Cursos";
            this.objetivosDeCursosToolStripMenuItem.Click += new System.EventHandler(this.objetivosDeCursosToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(133, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 58);
            this.label1.TabIndex = 2;
            this.label1.Text = "PRINCIPAL";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(140, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(781, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // cursosPorUsuariosToolStripMenuItem
            // 
            this.cursosPorUsuariosToolStripMenuItem.Name = "cursosPorUsuariosToolStripMenuItem";
            this.cursosPorUsuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cursosPorUsuariosToolStripMenuItem.Text = "Cursos por Usuarios";
            this.cursosPorUsuariosToolStripMenuItem.Click += new System.EventHandler(this.cursosPorUsuariosToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(820, 528);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Menú";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarCursosToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem consultarCategoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarObjetivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizacionCursoUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosPorCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objetivosDeCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursosPorUsuariosToolStripMenuItem;
    }
}