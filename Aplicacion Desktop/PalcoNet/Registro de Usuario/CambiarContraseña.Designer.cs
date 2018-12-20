namespace PalcoNet.Registro_de_Usuario
{
    partial class CambiarContraseña
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
            this.lblContra = new System.Windows.Forms.Label();
            this.lblContraRepe = new System.Windows.Forms.Label();
            this.txtContraRepe = new System.Windows.Forms.TextBox();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblContra
            // 
            this.lblContra.AutoSize = true;
            this.lblContra.Location = new System.Drawing.Point(12, 42);
            this.lblContra.Name = "lblContra";
            this.lblContra.Size = new System.Drawing.Size(96, 13);
            this.lblContra.TabIndex = 0;
            this.lblContra.Text = "Nueva Contraseña";
            // 
            // lblContraRepe
            // 
            this.lblContraRepe.AutoSize = true;
            this.lblContraRepe.Location = new System.Drawing.Point(12, 88);
            this.lblContraRepe.Name = "lblContraRepe";
            this.lblContraRepe.Size = new System.Drawing.Size(98, 13);
            this.lblContraRepe.TabIndex = 1;
            this.lblContraRepe.Text = "Repetir Contraseña";
            // 
            // txtContraRepe
            // 
            this.txtContraRepe.Location = new System.Drawing.Point(114, 85);
            this.txtContraRepe.Name = "txtContraRepe";
            this.txtContraRepe.PasswordChar = '*';
            this.txtContraRepe.Size = new System.Drawing.Size(100, 20);
            this.txtContraRepe.TabIndex = 2;
            // 
            // txtContra
            // 
            this.txtContra.Location = new System.Drawing.Point(114, 39);
            this.txtContra.Name = "txtContra";
            this.txtContra.PasswordChar = '*';
            this.txtContra.Size = new System.Drawing.Size(100, 20);
            this.txtContra.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(79, 153);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // CambiarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 188);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtContra);
            this.Controls.Add(this.txtContraRepe);
            this.Controls.Add(this.lblContraRepe);
            this.Controls.Add(this.lblContra);
            this.Name = "CambiarContraseña";
            this.Text = "CambiarContraseña";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CambiarContraseña_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContra;
        private System.Windows.Forms.Label lblContraRepe;
        private System.Windows.Forms.TextBox txtContraRepe;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.Button btnAceptar;
    }
}