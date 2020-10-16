namespace PROYECTO_PAV.GUILayer
{
    partial class FormGestionObjetivos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNombreCorto = new System.Windows.Forms.ComboBox();
            this.cmbNombreLargo = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvObjetivos = new System.Windows.Forms.DataGridView();
            this.chkBorrado = new System.Windows.Forms.CheckBox();
            this.lblObjetivo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjetivos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(28, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nombre Largo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(28, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nombre Corto:";
            // 
            // cmbNombreCorto
            // 
            this.cmbNombreCorto.FormattingEnabled = true;
            this.cmbNombreCorto.Location = new System.Drawing.Point(157, 20);
            this.cmbNombreCorto.Name = "cmbNombreCorto";
            this.cmbNombreCorto.Size = new System.Drawing.Size(181, 21);
            this.cmbNombreCorto.TabIndex = 21;
            // 
            // cmbNombreLargo
            // 
            this.cmbNombreLargo.FormattingEnabled = true;
            this.cmbNombreLargo.Location = new System.Drawing.Point(157, 54);
            this.cmbNombreLargo.Name = "cmbNombreLargo";
            this.cmbNombreLargo.Size = new System.Drawing.Size(181, 21);
            this.cmbNombreLargo.TabIndex = 22;
            this.cmbNombreLargo.SelectedIndexChanged += new System.EventHandler(this.cmbNombreLargo_SelectedIndexChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnConsultar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConsultar.Location = new System.Drawing.Point(392, 53);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(177, 24);
            this.btnConsultar.TabIndex = 23;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dgvObjetivos
            // 
            this.dgvObjetivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvObjetivos.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvObjetivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjetivos.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvObjetivos.Location = new System.Drawing.Point(19, 116);
            this.dgvObjetivos.Name = "dgvObjetivos";
            this.dgvObjetivos.RowHeadersWidth = 51;
            this.dgvObjetivos.Size = new System.Drawing.Size(563, 292);
            this.dgvObjetivos.TabIndex = 24;
            this.dgvObjetivos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObjetivos_CellClick);
            this.dgvObjetivos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObjetivos_CellContentClick);
            this.dgvObjetivos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvObjetivos_CellFormatting);
            // 
            // chkBorrado
            // 
            this.chkBorrado.AutoSize = true;
            this.chkBorrado.Font = new System.Drawing.Font("Verdana", 9F);
            this.chkBorrado.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.chkBorrado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkBorrado.Location = new System.Drawing.Point(157, 88);
            this.chkBorrado.Margin = new System.Windows.Forms.Padding(2);
            this.chkBorrado.Name = "chkBorrado";
            this.chkBorrado.Size = new System.Drawing.Size(189, 18);
            this.chkBorrado.TabIndex = 25;
            this.chkBorrado.Text = "Incluir Objetivos borrados";
            this.chkBorrado.UseVisualStyleBackColor = true;
            this.chkBorrado.CheckedChanged += new System.EventHandler(this.chkBorrado_CheckedChanged);
            // 
            // lblObjetivo
            // 
            this.lblObjetivo.AutoSize = true;
            this.lblObjetivo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObjetivo.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblObjetivo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblObjetivo.Location = new System.Drawing.Point(409, 412);
            this.lblObjetivo.Name = "lblObjetivo";
            this.lblObjetivo.Size = new System.Drawing.Size(0, 14);
            this.lblObjetivo.TabIndex = 35;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(506, 446);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(76, 33);
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnEditar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditar.Location = new System.Drawing.Point(203, 446);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(64, 33);
            this.btnEditar.TabIndex = 33;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnAgregar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAgregar.Location = new System.Drawing.Point(19, 446);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(69, 33);
            this.btnAgregar.TabIndex = 32;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnQuitar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnQuitar.Location = new System.Drawing.Point(111, 446);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(69, 33);
            this.btnQuitar.TabIndex = 31;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // FormGestionObjetivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(610, 500);
            this.Controls.Add(this.lblObjetivo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.chkBorrado);
            this.Controls.Add(this.dgvObjetivos);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.cmbNombreLargo);
            this.Controls.Add(this.cmbNombreCorto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(626, 539);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(626, 539);
            this.Name = "FormGestionObjetivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Objetivos";
            this.Load += new System.EventHandler(this.FormGestionObjetivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjetivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNombreCorto;
        private System.Windows.Forms.ComboBox cmbNombreLargo;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvObjetivos;
        private System.Windows.Forms.CheckBox chkBorrado;
        private System.Windows.Forms.Label lblObjetivo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
    }
}