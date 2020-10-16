﻿namespace PROYECTO_PAV.GUILayer
{
    partial class frmAMBCCurso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAMBCCurso));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.MaskedTextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            this._btnQuitar = new System.Windows.Forms.Button();
            this._btnAgregar = new System.Windows.Forms.Button();
            this.txtPuntos = new System.Windows.Forms.TextBox();
            this.lblPuntos = new System.Windows.Forms.Label();
            this.dgvObjetivos = new System.Windows.Forms.DataGridView();
            this.cmbObjetivo = new System.Windows.Forms.ComboBox();
            this.lblObjetivo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjetivos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Name = "label4";
            // 
            // txtDescripcion
            // 
            resources.ApplyResources(this.txtDescripcion, "txtDescripcion");
            this.txtDescripcion.Name = "txtDescripcion";
            // 
            // txtNombre
            // 
            resources.ApplyResources(this.txtNombre, "txtNombre");
            this.txtNombre.Name = "txtNombre";
            // 
            // txtFecha
            // 
            resources.ApplyResources(this.txtFecha, "txtFecha");
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ValidatingType = typeof(System.DateTime);
            this.txtFecha.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtFecha_MaskInputRejected);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCategoria, "cmbCategoria");
            this.cmbCategoria.Name = "cmbCategoria";
            // 
            // btnAceptar
            // 
            resources.ApplyResources(this.btnAceptar, "btnAceptar");
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // _btnCancelar
            // 
            resources.ApplyResources(this._btnCancelar, "_btnCancelar");
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            // 
            // _btnQuitar
            // 
            resources.ApplyResources(this._btnQuitar, "_btnQuitar");
            this._btnQuitar.Name = "_btnQuitar";
            this._btnQuitar.UseVisualStyleBackColor = true;
            // 
            // _btnAgregar
            // 
            resources.ApplyResources(this._btnAgregar, "_btnAgregar");
            this._btnAgregar.Name = "_btnAgregar";
            this._btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtPuntos
            // 
            resources.ApplyResources(this.txtPuntos, "txtPuntos");
            this.txtPuntos.Name = "txtPuntos";
            // 
            // lblPuntos
            // 
            resources.ApplyResources(this.lblPuntos, "lblPuntos");
            this.lblPuntos.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblPuntos.Name = "lblPuntos";
            // 
            // dgvObjetivos
            // 
            this.dgvObjetivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvObjetivos.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvObjetivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjetivos.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.dgvObjetivos, "dgvObjetivos");
            this.dgvObjetivos.Name = "dgvObjetivos";
            // 
            // cmbObjetivo
            // 
            this.cmbObjetivo.FormattingEnabled = true;
            resources.ApplyResources(this.cmbObjetivo, "cmbObjetivo");
            this.cmbObjetivo.Name = "cmbObjetivo";
            // 
            // lblObjetivo
            // 
            resources.ApplyResources(this.lblObjetivo, "lblObjetivo");
            this.lblObjetivo.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblObjetivo.Name = "lblObjetivo";
            // 
            // frmAMBCCurso
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnQuitar);
            this.Controls.Add(this._btnAgregar);
            this.Controls.Add(this.txtPuntos);
            this.Controls.Add(this.lblPuntos);
            this.Controls.Add(this.dgvObjetivos);
            this.Controls.Add(this.cmbObjetivo);
            this.Controls.Add(this.lblObjetivo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAMBCCurso";
            this.Load += new System.EventHandler(this.frmAMBCCurso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjetivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        internal System.Windows.Forms.MaskedTextBox txtFecha;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button _btnCancelar;
        private System.Windows.Forms.Button _btnQuitar;
        private System.Windows.Forms.Button _btnAgregar;
        private System.Windows.Forms.TextBox txtPuntos;
        private System.Windows.Forms.Label lblPuntos;
        private System.Windows.Forms.DataGridView dgvObjetivos;
        private System.Windows.Forms.ComboBox cmbObjetivo;
        private System.Windows.Forms.Label lblObjetivo;
    }
}