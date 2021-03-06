﻿namespace PalcoNet.Abm_Empresa_Espectaculo
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblRazon = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.lbl_FechaCreacion = new System.Windows.Forms.Label();
            this.lbl_Calle = new System.Windows.Forms.Label();
            this.txt_Calle = new System.Windows.Forms.TextBox();
            this.dtp_FechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // chbDepto
            // 
            this.chbDepto.AutoSize = true;
            this.chbDepto.Location = new System.Drawing.Point(416, 159);
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
            this.chbPiso.Location = new System.Drawing.Point(416, 112);
            this.chbPiso.Name = "chbPiso";
            this.chbPiso.Size = new System.Drawing.Size(46, 17);
            this.chbPiso.TabIndex = 47;
            this.chbPiso.Text = "Piso";
            this.chbPiso.UseVisualStyleBackColor = true;
            this.chbPiso.CheckedChanged += new System.EventHandler(this.chbPiso_CheckedChanged);
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.Location = new System.Drawing.Point(494, 239);
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.Size = new System.Drawing.Size(100, 20);
            this.txtCodPostal.TabIndex = 46;
            this.txtCodPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumerico);
            this.txtCodPostal.Leave += new System.EventHandler(this.txtCodPostal_Leave);
            // 
            // lblCodPostal
            // 
            this.lblCodPostal.AutoSize = true;
            this.lblCodPostal.Location = new System.Drawing.Point(413, 242);
            this.lblCodPostal.Name = "lblCodPostal";
            this.lblCodPostal.Size = new System.Drawing.Size(58, 13);
            this.lblCodPostal.TabIndex = 45;
            this.lblCodPostal.Text = "Cod Postal";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(494, 196);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 20);
            this.txtLocalidad.TabIndex = 44;
            this.txtLocalidad.Leave += new System.EventHandler(this.txtLocalidad_Leave);
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(413, 199);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(53, 13);
            this.lblLocalidad.TabIndex = 43;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lbl_Numero
            // 
            this.lbl_Numero.AutoSize = true;
            this.lbl_Numero.Location = new System.Drawing.Point(413, 70);
            this.lbl_Numero.Name = "lbl_Numero";
            this.lbl_Numero.Size = new System.Drawing.Size(44, 13);
            this.lbl_Numero.TabIndex = 42;
            this.lbl_Numero.Text = "Numero";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(9, 182);
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
            this.lblCiudad.Location = new System.Drawing.Point(9, 234);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(40, 13);
            this.lblCiudad.TabIndex = 39;
            this.lblCiudad.Text = "Ciudad";
            // 
            // txtPiso
            // 
            this.txtPiso.Enabled = false;
            this.txtPiso.Location = new System.Drawing.Point(494, 112);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(100, 20);
            this.txtPiso.TabIndex = 38;
            this.txtPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumerico);
            this.txtPiso.Leave += new System.EventHandler(this.txtPiso_Leave);
            // 
            // txtDepto
            // 
            this.txtDepto.Enabled = false;
            this.txtDepto.Location = new System.Drawing.Point(494, 159);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(100, 20);
            this.txtDepto.TabIndex = 37;
            this.txtDepto.Leave += new System.EventHandler(this.txtDepto_Leave);
            // 
            // txt_Numero
            // 
            this.txt_Numero.Location = new System.Drawing.Point(494, 67);
            this.txt_Numero.Name = "txt_Numero";
            this.txt_Numero.Size = new System.Drawing.Size(100, 20);
            this.txt_Numero.TabIndex = 36;
            this.txt_Numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumerico);
            this.txt_Numero.Leave += new System.EventHandler(this.txt_Numero_Leave);
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(93, 179);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 20);
            this.txtTel.TabIndex = 35;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumerico);
            this.txtTel.Leave += new System.EventHandler(this.txtTel_Leave);
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(93, 61);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(100, 20);
            this.txtCUIT.TabIndex = 34;
            //this.txtCUIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumerico);
            this.txtCUIT.Leave += new System.EventHandler(this.txtCUIT_Leave);
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(93, 231);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(100, 20);
            this.txtCiudad.TabIndex = 33;
            this.txtCiudad.Leave += new System.EventHandler(this.txtCiudad_Leave);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(355, 290);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 50;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(238, 290);
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
            this.lblRazon.Location = new System.Drawing.Point(4, 17);
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
            this.txtRazon.Location = new System.Drawing.Point(93, 14);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(100, 20);
            this.txtRazon.TabIndex = 51;
            this.txtRazon.Leave += new System.EventHandler(this.txtRazon_Leave);
            // 
            // lbl_FechaCreacion
            // 
            this.lbl_FechaCreacion.AutoSize = true;
            this.lbl_FechaCreacion.Location = new System.Drawing.Point(6, 108);
            this.lbl_FechaCreacion.Name = "lbl_FechaCreacion";
            this.lbl_FechaCreacion.Size = new System.Drawing.Size(85, 13);
            this.lbl_FechaCreacion.TabIndex = 56;
            this.lbl_FechaCreacion.Text = "Fecha_Creacion";
            // 
            // lbl_Calle
            // 
            this.lbl_Calle.AutoSize = true;
            this.lbl_Calle.Location = new System.Drawing.Point(416, 18);
            this.lbl_Calle.Name = "lbl_Calle";
            this.lbl_Calle.Size = new System.Drawing.Size(30, 13);
            this.lbl_Calle.TabIndex = 57;
            this.lbl_Calle.Text = "Calle";
            // 
            // txt_Calle
            // 
            this.txt_Calle.Location = new System.Drawing.Point(494, 18);
            this.txt_Calle.Name = "txt_Calle";
            this.txt_Calle.Size = new System.Drawing.Size(100, 20);
            this.txt_Calle.TabIndex = 58;
            this.txt_Calle.Leave += new System.EventHandler(this.txt_Calle_Leave);
            // 
            // dtp_FechaCreacion
            // 
            this.dtp_FechaCreacion.Location = new System.Drawing.Point(93, 108);
            this.dtp_FechaCreacion.Name = "dtp_FechaCreacion";
            this.dtp_FechaCreacion.Size = new System.Drawing.Size(200, 20);
            this.dtp_FechaCreacion.TabIndex = 59;
            this.dtp_FechaCreacion.Leave += new System.EventHandler(this.dtp_FechaCreacion_Leave);
            // 
            // AltaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 348);
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
            this.Name = "AltaEmpresa";
            this.Text = "Alta Empresa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AltaEmpresa_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AltaEmpresa_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblRazon;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.Label lbl_FechaCreacion;
        private System.Windows.Forms.Label lbl_Calle;
        private System.Windows.Forms.TextBox txt_Calle;
        private System.Windows.Forms.DateTimePicker dtp_FechaCreacion;
    }
}