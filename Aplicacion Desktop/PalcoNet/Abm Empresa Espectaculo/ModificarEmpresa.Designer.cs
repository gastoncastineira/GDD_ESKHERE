namespace PalcoNet.Abm_Empresa_Espectaculo
{
    partial class ModificarEmpresa
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
            this.dtp_FechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.txt_Calle = new System.Windows.Forms.TextBox();
            this.lbl_Calle = new System.Windows.Forms.Label();
            this.lbl_FechaCreacion = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblRazon = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.chbDepto = new System.Windows.Forms.CheckBox();
            this.chbPiso = new System.Windows.Forms.CheckBox();
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.lblCodPostal = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lbl_Numero = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txt_Numero = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtp_FechaCreacion
            // 
            this.dtp_FechaCreacion.Location = new System.Drawing.Point(101, 122);
            this.dtp_FechaCreacion.Name = "dtp_FechaCreacion";
            this.dtp_FechaCreacion.Size = new System.Drawing.Size(200, 20);
            this.dtp_FechaCreacion.TabIndex = 85;
            this.dtp_FechaCreacion.Leave += new System.EventHandler(this.dtp_FechaCreacion_Leave);
            // 
            // txt_Calle
            // 
            this.txt_Calle.Location = new System.Drawing.Point(502, 32);
            this.txt_Calle.Name = "txt_Calle";
            this.txt_Calle.Size = new System.Drawing.Size(100, 20);
            this.txt_Calle.TabIndex = 84;
            this.txt_Calle.Leave += new System.EventHandler(this.txt_Calle_Leave);
            // 
            // lbl_Calle
            // 
            this.lbl_Calle.AutoSize = true;
            this.lbl_Calle.Location = new System.Drawing.Point(424, 32);
            this.lbl_Calle.Name = "lbl_Calle";
            this.lbl_Calle.Size = new System.Drawing.Size(30, 13);
            this.lbl_Calle.TabIndex = 83;
            this.lbl_Calle.Text = "Calle";
            // 
            // lbl_FechaCreacion
            // 
            this.lbl_FechaCreacion.AutoSize = true;
            this.lbl_FechaCreacion.Location = new System.Drawing.Point(14, 122);
            this.lbl_FechaCreacion.Name = "lbl_FechaCreacion";
            this.lbl_FechaCreacion.Size = new System.Drawing.Size(85, 13);
            this.lbl_FechaCreacion.TabIndex = 82;
            this.lbl_FechaCreacion.Text = "Fecha_Creacion";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(25, 158);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(26, 13);
            this.lblMail.TabIndex = 81;
            this.lblMail.Text = "Mail";
            // 
            // lblRazon
            // 
            this.lblRazon.AutoSize = true;
            this.lblRazon.Location = new System.Drawing.Point(12, 31);
            this.lblRazon.Name = "lblRazon";
            this.lblRazon.Size = new System.Drawing.Size(68, 13);
            this.lblRazon.TabIndex = 80;
            this.lblRazon.Text = "Razon social";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(101, 155);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(100, 20);
            this.txtMail.TabIndex = 79;
            this.txtMail.Leave += new System.EventHandler(this.txtMail_Leave);
            // 
            // txtRazon
            // 
            this.txtRazon.Location = new System.Drawing.Point(101, 28);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(100, 20);
            this.txtRazon.TabIndex = 78;
            this.txtRazon.Leave += new System.EventHandler(this.txtRazon_Leave);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(363, 304);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 77;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(246, 304);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 76;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // chbDepto
            // 
            this.chbDepto.AutoSize = true;
            this.chbDepto.Location = new System.Drawing.Point(424, 173);
            this.chbDepto.Name = "chbDepto";
            this.chbDepto.Size = new System.Drawing.Size(55, 17);
            this.chbDepto.TabIndex = 75;
            this.chbDepto.Text = "Depto";
            this.chbDepto.UseVisualStyleBackColor = true;
            // 
            // chbPiso
            // 
            this.chbPiso.AutoSize = true;
            this.chbPiso.Location = new System.Drawing.Point(424, 126);
            this.chbPiso.Name = "chbPiso";
            this.chbPiso.Size = new System.Drawing.Size(46, 17);
            this.chbPiso.TabIndex = 74;
            this.chbPiso.Text = "Piso";
            this.chbPiso.UseVisualStyleBackColor = true;
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.Location = new System.Drawing.Point(502, 253);
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.Size = new System.Drawing.Size(100, 20);
            this.txtCodPostal.TabIndex = 73;
            this.txtCodPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumerico);
            this.txtCodPostal.Leave += new System.EventHandler(this.txtCodPostal_Leave);
            // 
            // lblCodPostal
            // 
            this.lblCodPostal.AutoSize = true;
            this.lblCodPostal.Location = new System.Drawing.Point(421, 256);
            this.lblCodPostal.Name = "lblCodPostal";
            this.lblCodPostal.Size = new System.Drawing.Size(58, 13);
            this.lblCodPostal.TabIndex = 72;
            this.lblCodPostal.Text = "Cod Postal";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(502, 210);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 20);
            this.txtLocalidad.TabIndex = 71;
            this.txtLocalidad.Leave += new System.EventHandler(this.txtLocalidad_Leave);
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(421, 213);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(53, 13);
            this.lblLocalidad.TabIndex = 70;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lbl_Numero
            // 
            this.lbl_Numero.AutoSize = true;
            this.lbl_Numero.Location = new System.Drawing.Point(421, 84);
            this.lbl_Numero.Name = "lbl_Numero";
            this.lbl_Numero.Size = new System.Drawing.Size(44, 13);
            this.lbl_Numero.TabIndex = 69;
            this.lbl_Numero.Text = "Numero";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(17, 196);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(49, 13);
            this.lblTel.TabIndex = 68;
            this.lblTel.Text = "Teléfono";
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.Location = new System.Drawing.Point(17, 78);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(32, 13);
            this.lblCUIT.TabIndex = 67;
            this.lblCUIT.Text = "CUIT";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(17, 248);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(40, 13);
            this.lblCiudad.TabIndex = 66;
            this.lblCiudad.Text = "Ciudad";
            // 
            // txtPiso
            // 
            this.txtPiso.Enabled = false;
            this.txtPiso.Location = new System.Drawing.Point(502, 126);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(100, 20);
            this.txtPiso.TabIndex = 65;
            this.txtPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumerico);
            this.txtPiso.Leave += new System.EventHandler(this.txtPiso_Leave);
            // 
            // txtDepto
            // 
            this.txtDepto.Enabled = false;
            this.txtDepto.Location = new System.Drawing.Point(502, 173);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(100, 20);
            this.txtDepto.TabIndex = 64;
            this.txtDepto.Leave += new System.EventHandler(this.txtDepto_Leave);
            // 
            // txt_Numero
            // 
            this.txt_Numero.Location = new System.Drawing.Point(502, 81);
            this.txt_Numero.Name = "txt_Numero";
            this.txt_Numero.Size = new System.Drawing.Size(100, 20);
            this.txt_Numero.TabIndex = 63;
            this.txt_Numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumerico);
            this.txt_Numero.Leave += new System.EventHandler(this.txt_Numero_Leave);
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(101, 193);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 20);
            this.txtTel.TabIndex = 62;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumerico);
            this.txtTel.Leave += new System.EventHandler(this.txtTel_Leave);
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(101, 75);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(100, 20);
            this.txtCUIT.TabIndex = 61;
            this.txtCUIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumerico);
            this.txtCUIT.Leave += new System.EventHandler(this.txtCUIT_Leave);
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(101, 245);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(100, 20);
            this.txtCiudad.TabIndex = 60;
            this.txtCiudad.Leave += new System.EventHandler(this.txtCiudad_Leave);
            // 
            // ModificarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 355);
            this.Controls.Add(this.dtp_FechaCreacion);
            this.Controls.Add(this.txt_Calle);
            this.Controls.Add(this.lbl_Calle);
            this.Controls.Add(this.lbl_FechaCreacion);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblRazon);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtRazon);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.chbDepto);
            this.Controls.Add(this.chbPiso);
            this.Controls.Add(this.txtCodPostal);
            this.Controls.Add(this.lblCodPostal);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.lbl_Numero);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblCUIT);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.txtPiso);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.txt_Numero);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.txtCiudad);
            this.Name = "ModificarEmpresa";
            this.Text = "ModificarEmpresa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_FechaCreacion;
        private System.Windows.Forms.TextBox txt_Calle;
        private System.Windows.Forms.Label lbl_Calle;
        private System.Windows.Forms.Label lbl_FechaCreacion;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblRazon;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.CheckBox chbDepto;
        private System.Windows.Forms.CheckBox chbPiso;
        private System.Windows.Forms.TextBox txtCodPostal;
        private System.Windows.Forms.Label lblCodPostal;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lbl_Numero;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.TextBox txt_Numero;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtCUIT;
        private System.Windows.Forms.TextBox txtCiudad;

    }
}