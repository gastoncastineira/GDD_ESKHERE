namespace PalcoNet.Listado_Estadistico
{
    partial class ListadoEstadistico
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
            this.btnClientesPtsVnc = new System.Windows.Forms.Button();
            this.btnClientesCantCompra = new System.Windows.Forms.Button();
            this.btnEmpresasLocNoVendidas = new System.Windows.Forms.Button();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trimestre";
            // 
            // btnClientesPtsVnc
            // 
            this.btnClientesPtsVnc.Location = new System.Drawing.Point(17, 125);
            this.btnClientesPtsVnc.Name = "btnClientesPtsVnc";
            this.btnClientesPtsVnc.Size = new System.Drawing.Size(94, 53);
            this.btnClientesPtsVnc.TabIndex = 4;
            this.btnClientesPtsVnc.Text = "Clientes con mayores puntos vencidos";
            this.btnClientesPtsVnc.UseVisualStyleBackColor = true;
            this.btnClientesPtsVnc.Click += new System.EventHandler(this.btnClientesPtsVnc_Click);
            // 
            // btnClientesCantCompra
            // 
            this.btnClientesCantCompra.Location = new System.Drawing.Point(151, 125);
            this.btnClientesCantCompra.Name = "btnClientesCantCompra";
            this.btnClientesCantCompra.Size = new System.Drawing.Size(92, 53);
            this.btnClientesCantCompra.TabIndex = 5;
            this.btnClientesCantCompra.Text = "Clientes con mayor cantidad de compras";
            this.btnClientesCantCompra.UseVisualStyleBackColor = true;
            this.btnClientesCantCompra.Click += new System.EventHandler(this.btnClientesCantCompra_Click);
            // 
            // btnEmpresasLocNoVendidas
            // 
            this.btnEmpresasLocNoVendidas.Location = new System.Drawing.Point(273, 125);
            this.btnEmpresasLocNoVendidas.Name = "btnEmpresasLocNoVendidas";
            this.btnEmpresasLocNoVendidas.Size = new System.Drawing.Size(143, 53);
            this.btnEmpresasLocNoVendidas.TabIndex = 6;
            this.btnEmpresasLocNoVendidas.Text = "Empresas con mayor cantidad de ubicaciones no vendidas";
            this.btnEmpresasLocNoVendidas.UseVisualStyleBackColor = true;
            this.btnEmpresasLocNoVendidas.Click += new System.EventHandler(this.btnEmpresasLocNoVendidas_Click);
            // 
            // cmbAño
            // 
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Location = new System.Drawing.Point(44, 38);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(86, 21);
            this.cmbAño.TabIndex = 7;
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.FormattingEnabled = true;
            this.cmbTrimestre.Location = new System.Drawing.Point(264, 38);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(121, 21);
            this.cmbTrimestre.TabIndex = 8;
            this.cmbTrimestre.Text = "1";
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 226);
            this.Controls.Add(this.cmbTrimestre);
            this.Controls.Add(this.cmbAño);
            this.Controls.Add(this.btnEmpresasLocNoVendidas);
            this.Controls.Add(this.btnClientesCantCompra);
            this.Controls.Add(this.btnClientesPtsVnc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ListadoEstadistico";
            this.Text = "Listados estadisticos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClientesPtsVnc;
        private System.Windows.Forms.Button btnClientesCantCompra;
        private System.Windows.Forms.Button btnEmpresasLocNoVendidas;
        private System.Windows.Forms.ComboBox cmbAño;
        private System.Windows.Forms.ComboBox cmbTrimestre;
    }
}