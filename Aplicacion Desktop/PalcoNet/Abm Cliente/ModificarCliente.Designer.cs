namespace PalcoNet.Abm_Cliente
{
    partial class ModificarCliente
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
            this.chbDepto = new System.Windows.Forms.CheckBox();
            this.chbPiso = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cbbTipo = new System.Windows.Forms.ComboBox();
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNac = new System.Windows.Forms.DateTimePicker();
            this.lblNac = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.lblApel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblCUIL = new System.Windows.Forms.Label();
            this.lblDoc = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtCUIL = new System.Windows.Forms.TextBox();
            this.txtApel = new System.Windows.Forms.TextBox();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chbDepto
            // 
            this.chbDepto.AutoSize = true;
            this.chbDepto.Location = new System.Drawing.Point(335, 175);
            this.chbDepto.Name = "chbDepto";
            this.chbDepto.Size = new System.Drawing.Size(55, 17);
            this.chbDepto.TabIndex = 60;
            this.chbDepto.Text = "Depto";
            this.chbDepto.UseVisualStyleBackColor = true;
            this.chbDepto.CheckedChanged += new System.EventHandler(this.chbDepto_CheckedChanged);
            // 
            // chbPiso
            // 
            this.chbPiso.AutoSize = true;
            this.chbPiso.Location = new System.Drawing.Point(335, 128);
            this.chbPiso.Name = "chbPiso";
            this.chbPiso.Size = new System.Drawing.Size(46, 17);
            this.chbPiso.TabIndex = 59;
            this.chbPiso.Text = "Piso";
            this.chbPiso.UseVisualStyleBackColor = true;
            this.chbPiso.CheckedChanged += new System.EventHandler(this.chbPiso_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(296, 373);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 58;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(161, 373);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 57;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbbTipo
            // 
            this.cbbTipo.FormattingEnabled = true;
            this.cbbTipo.Items.AddRange(new object[] {
            "LE",
            "DNI"});
            this.cbbTipo.Location = new System.Drawing.Point(120, 262);
            this.cbbTipo.Name = "cbbTipo";
            this.cbbTipo.Size = new System.Drawing.Size(100, 21);
            this.cbbTipo.TabIndex = 56;
            this.cbbTipo.Leave += new System.EventHandler(this.cbbTipo_Leave);
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.Location = new System.Drawing.Point(397, 262);
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.Size = new System.Drawing.Size(100, 20);
            this.txtCodPostal.TabIndex = 55;
            this.txtCodPostal.Leave += new System.EventHandler(this.txtCodPostal_Leave);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(31, 262);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(48, 13);
            this.lblTipo.TabIndex = 54;
            this.lblTipo.Text = "TipoDoc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Cod Postal";
            // 
            // dtpNac
            // 
            this.dtpNac.Location = new System.Drawing.Point(211, 324);
            this.dtpNac.Name = "dtpNac";
            this.dtpNac.Size = new System.Drawing.Size(200, 20);
            this.dtpNac.TabIndex = 52;
            this.dtpNac.Value = new System.DateTime(2018, 11, 22, 16, 33, 36, 0);
            this.dtpNac.Leave += new System.EventHandler(this.dtpNac_Leave);
            // 
            // lblNac
            // 
            this.lblNac.AutoSize = true;
            this.lblNac.Location = new System.Drawing.Point(122, 330);
            this.lblNac.Name = "lblNac";
            this.lblNac.Size = new System.Drawing.Size(61, 13);
            this.lblNac.TabIndex = 51;
            this.lblNac.Text = "Fecha nac.";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(397, 219);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 20);
            this.txtLocalidad.TabIndex = 50;
            this.txtLocalidad.Leave += new System.EventHandler(this.txtLocalidad_Leave);
            // 
            // lblApel
            // 
            this.lblApel.AutoSize = true;
            this.lblApel.Location = new System.Drawing.Point(31, 77);
            this.lblApel.Name = "lblApel";
            this.lblApel.Size = new System.Drawing.Size(44, 13);
            this.lblApel.TabIndex = 49;
            this.lblApel.Text = "Apellido";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(332, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Localidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(332, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Dirección";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(31, 222);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(26, 13);
            this.lblMail.TabIndex = 46;
            this.lblMail.Text = "Mail";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(332, 27);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(49, 13);
            this.lblTel.TabIndex = 45;
            this.lblTel.Text = "Teléfono";
            // 
            // lblCUIL
            // 
            this.lblCUIL.AutoSize = true;
            this.lblCUIL.Location = new System.Drawing.Point(31, 179);
            this.lblCUIL.Name = "lblCUIL";
            this.lblCUIL.Size = new System.Drawing.Size(31, 13);
            this.lblCUIL.TabIndex = 44;
            this.lblCUIL.Text = "CUIL";
            // 
            // lblDoc
            // 
            this.lblDoc.AutoSize = true;
            this.lblDoc.Location = new System.Drawing.Point(31, 128);
            this.lblDoc.Name = "lblDoc";
            this.lblDoc.Size = new System.Drawing.Size(85, 13);
            this.lblDoc.TabIndex = 43;
            this.lblDoc.Text = "Nro. Documento";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(31, 27);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 42;
            this.lblNombre.Text = "Nombre";
            // 
            // txtPiso
            // 
            this.txtPiso.Enabled = false;
            this.txtPiso.Location = new System.Drawing.Point(397, 175);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(100, 20);
            this.txtPiso.TabIndex = 41;
            this.txtPiso.Leave += new System.EventHandler(this.txtPiso_Leave);
            // 
            // txtDepto
            // 
            this.txtDepto.Enabled = false;
            this.txtDepto.Location = new System.Drawing.Point(397, 125);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(100, 20);
            this.txtDepto.TabIndex = 40;
            this.txtDepto.Leave += new System.EventHandler(this.txtDepto_Leave);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(397, 74);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(100, 20);
            this.txtDir.TabIndex = 39;
            this.txtDir.Leave += new System.EventHandler(this.txtDir_Leave);
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(397, 24);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 20);
            this.txtTel.TabIndex = 38;
            this.txtTel.Leave += new System.EventHandler(this.txtTel_Leave);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(120, 219);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(100, 20);
            this.txtMail.TabIndex = 37;
            this.txtMail.Leave += new System.EventHandler(this.txtMail_Leave);
            // 
            // txtCUIL
            // 
            this.txtCUIL.Location = new System.Drawing.Point(120, 175);
            this.txtCUIL.Name = "txtCUIL";
            this.txtCUIL.Size = new System.Drawing.Size(100, 20);
            this.txtCUIL.TabIndex = 36;
            this.txtCUIL.Leave += new System.EventHandler(this.txtCUIL_Leave);
            // 
            // txtApel
            // 
            this.txtApel.Location = new System.Drawing.Point(120, 74);
            this.txtApel.Name = "txtApel";
            this.txtApel.Size = new System.Drawing.Size(100, 20);
            this.txtApel.TabIndex = 35;
            this.txtApel.Leave += new System.EventHandler(this.txtApel_Leave);
            // 
            // txtDoc
            // 
            this.txtDoc.Location = new System.Drawing.Point(120, 125);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(100, 20);
            this.txtDoc.TabIndex = 34;
            this.txtDoc.Leave += new System.EventHandler(this.txtDoc_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 24);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 33;
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // ModificarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 423);
            this.Controls.Add(this.chbDepto);
            this.Controls.Add(this.chbPiso);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbbTipo);
            this.Controls.Add(this.txtCodPostal);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpNac);
            this.Controls.Add(this.lblNac);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.lblApel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblCUIL);
            this.Controls.Add(this.lblDoc);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtPiso);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtCUIL);
            this.Controls.Add(this.txtApel);
            this.Controls.Add(this.txtDoc);
            this.Controls.Add(this.txtNombre);
            this.Name = "ModificarCliente";
            this.Text = "ModificarCliente";
            this.Load += new System.EventHandler(this.ModificarCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbDepto;
        private System.Windows.Forms.CheckBox chbPiso;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cbbTipo;
        private System.Windows.Forms.TextBox txtCodPostal;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNac;
        private System.Windows.Forms.Label lblNac;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label lblApel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblCUIL;
        private System.Windows.Forms.Label lblDoc;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtCUIL;
        private System.Windows.Forms.TextBox txtApel;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.TextBox txtNombre;
    }
}