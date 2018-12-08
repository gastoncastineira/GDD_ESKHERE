namespace PalcoNet.Abm_Empresa_Espectaculo
{
    partial class AltaEmpresa
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
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblRazon = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chbDepto
            // 
            this.chbDepto.AutoSize = true;
            this.chbDepto.Location = new System.Drawing.Point(15, 311);
            this.chbDepto.Name = "chbDepto";
            this.chbDepto.Size = new System.Drawing.Size(55, 17);
            this.chbDepto.TabIndex = 48;
            this.chbDepto.Text = "Depto";
            this.chbDepto.UseVisualStyleBackColor = true;
            this.chbDepto.CheckedChanged += new System.EventHandler(this.chbDepto_CheckedChanged);
            // 
            // chbPiso
            // 
            this.chbPiso.AutoSize = true;
            this.chbPiso.Location = new System.Drawing.Point(15, 264);
            this.chbPiso.Name = "chbPiso";
            this.chbPiso.Size = new System.Drawing.Size(46, 17);
            this.chbPiso.TabIndex = 47;
            this.chbPiso.Text = "Piso";
            this.chbPiso.UseVisualStyleBackColor = true;
            this.chbPiso.CheckedChanged += new System.EventHandler(this.chbPiso_CheckedChanged);
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.Location = new System.Drawing.Point(93, 398);
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.Size = new System.Drawing.Size(100, 20);
            this.txtCodPostal.TabIndex = 46;
            this.txtCodPostal.Leave += new System.EventHandler(this.txtCodPostal_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Cod Postal";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(93, 355);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 20);
            this.txtLocalidad.TabIndex = 44;
            this.txtLocalidad.Leave += new System.EventHandler(this.txtLocalidad_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 358);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Localidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Dirección";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(9, 100);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(49, 13);
            this.lblTel.TabIndex = 41;
            this.lblTel.Text = "Teléfono";
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.Location = new System.Drawing.Point(9, 64);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(32, 13);
            this.lblCUIT.TabIndex = 40;
            this.lblCUIT.Text = "CUIT";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(9, 26);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(40, 13);
            this.lblCiudad.TabIndex = 39;
            this.lblCiudad.Text = "Ciudad";
            // 
            // txtPiso
            // 
            this.txtPiso.Enabled = false;
            this.txtPiso.Location = new System.Drawing.Point(93, 311);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(100, 20);
            this.txtPiso.TabIndex = 38;
            this.txtPiso.Leave += new System.EventHandler(this.txtPiso_Leave);
            // 
            // txtDepto
            // 
            this.txtDepto.Enabled = false;
            this.txtDepto.Location = new System.Drawing.Point(93, 261);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(100, 20);
            this.txtDepto.TabIndex = 37;
            this.txtDepto.Leave += new System.EventHandler(this.txtDepto_Leave);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(93, 219);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(100, 20);
            this.txtDir.TabIndex = 36;
            this.txtDir.Leave += new System.EventHandler(this.txtDir_Leave);
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(93, 97);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 20);
            this.txtTel.TabIndex = 35;
            this.txtTel.Leave += new System.EventHandler(this.txtTel_Leave);
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(93, 61);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(100, 20);
            this.txtCUIT.TabIndex = 34;
            this.txtCUIT.Leave += new System.EventHandler(this.txtCUIT_Leave);
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(93, 23);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(100, 20);
            this.txtCiudad.TabIndex = 33;
            this.txtCiudad.Leave += new System.EventHandler(this.txtCiudad_Leave);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(155, 438);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 50;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(20, 438);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 49;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(17, 144);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(26, 13);
            this.lblMail.TabIndex = 54;
            this.lblMail.Text = "Mail";
            // 
            // lblRazon
            // 
            this.lblRazon.AutoSize = true;
            this.lblRazon.Location = new System.Drawing.Point(4, 185);
            this.lblRazon.Name = "lblRazon";
            this.lblRazon.Size = new System.Drawing.Size(68, 13);
            this.lblRazon.TabIndex = 53;
            this.lblRazon.Text = "Razon social";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(93, 141);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(100, 20);
            this.txtMail.TabIndex = 52;
            this.txtMail.Leave += new System.EventHandler(this.txtMail_Leave);
            // 
            // txtRazon
            // 
            this.txtRazon.Location = new System.Drawing.Point(93, 182);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(100, 20);
            this.txtRazon.TabIndex = 51;
            this.txtRazon.Leave += new System.EventHandler(this.txtRazon_Leave);
            // 
            // AltaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 492);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblRazon);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtRazon);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.chbDepto);
            this.Controls.Add(this.chbPiso);
            this.Controls.Add(this.txtCodPostal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblCUIT);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.txtPiso);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.txtCiudad);
            this.Name = "AltaEmpresa";
            this.Text = "Alta Empresa";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AltaEmpresa_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbDepto;
        private System.Windows.Forms.CheckBox chbPiso;
        private System.Windows.Forms.TextBox txtCodPostal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtCUIT;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblRazon;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtRazon;
    }
}