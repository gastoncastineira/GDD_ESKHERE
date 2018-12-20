namespace PalcoNet.Canje_Puntos
{
    partial class Canje_Puntos
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
            this.dgv_Premios_Elegibles = new System.Windows.Forms.DataGridView();
            this.lbl_Premios_Elegibles = new System.Windows.Forms.Label();
            this.lbl_Puntos_Cliente = new System.Windows.Forms.Label();
            this.dgv_PremiosPorCliente = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Canje = new System.Windows.Forms.Label();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.dgv_Ptos_Cliente = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIDsPremios = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Premios_Elegibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PremiosPorCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Ptos_Cliente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Puntos habilitados  del cliente";
            // 
            // dgv_Premios_Elegibles
            // 
            this.dgv_Premios_Elegibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Premios_Elegibles.Location = new System.Drawing.Point(12, 246);
            this.dgv_Premios_Elegibles.Name = "dgv_Premios_Elegibles";
            this.dgv_Premios_Elegibles.Size = new System.Drawing.Size(469, 90);
            this.dgv_Premios_Elegibles.TabIndex = 4;
            // 
            // lbl_Premios_Elegibles
            // 
            this.lbl_Premios_Elegibles.AutoSize = true;
            this.lbl_Premios_Elegibles.Location = new System.Drawing.Point(195, 218);
            this.lbl_Premios_Elegibles.Name = "lbl_Premios_Elegibles";
            this.lbl_Premios_Elegibles.Size = new System.Drawing.Size(89, 13);
            this.lbl_Premios_Elegibles.TabIndex = 5;
            this.lbl_Premios_Elegibles.Text = "Premios Elegibles";
            // 
            // lbl_Puntos_Cliente
            // 
            this.lbl_Puntos_Cliente.AutoSize = true;
            this.lbl_Puntos_Cliente.Location = new System.Drawing.Point(551, 32);
            this.lbl_Puntos_Cliente.Name = "lbl_Puntos_Cliente";
            this.lbl_Puntos_Cliente.Size = new System.Drawing.Size(0, 13);
            this.lbl_Puntos_Cliente.TabIndex = 6;
            // 
            // dgv_PremiosPorCliente
            // 
            this.dgv_PremiosPorCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PremiosPorCliente.Location = new System.Drawing.Point(16, 96);
            this.dgv_PremiosPorCliente.Name = "dgv_PremiosPorCliente";
            this.dgv_PremiosPorCliente.Size = new System.Drawing.Size(465, 101);
            this.dgv_PremiosPorCliente.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Premios actuales del cliente";
            // 
            // lbl_Canje
            // 
            this.lbl_Canje.AutoSize = true;
            this.lbl_Canje.Location = new System.Drawing.Point(50, 357);
            this.lbl_Canje.Name = "lbl_Canje";
            this.lbl_Canje.Size = new System.Drawing.Size(126, 13);
            this.lbl_Canje.TabIndex = 9;
            this.lbl_Canje.Text = "Ingresar premio a canjear";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(247, 397);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancelar.TabIndex = 11;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(143, 397);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_Aceptar.TabIndex = 12;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Canje_Premios);
            // 
            // dgv_Ptos_Cliente
            // 
            this.dgv_Ptos_Cliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Ptos_Cliente.Location = new System.Drawing.Point(513, 96);
            this.dgv_Ptos_Cliente.Name = "dgv_Ptos_Cliente";
            this.dgv_Ptos_Cliente.Size = new System.Drawing.Size(422, 240);
            this.dgv_Ptos_Cliente.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(662, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Puntos actuales del cliente";
            // 
            // cmbIDsPremios
            // 
            this.cmbIDsPremios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIDsPremios.FormattingEnabled = true;
            this.cmbIDsPremios.Location = new System.Drawing.Point(187, 354);
            this.cmbIDsPremios.Name = "cmbIDsPremios";
            this.cmbIDsPremios.Size = new System.Drawing.Size(121, 21);
            this.cmbIDsPremios.TabIndex = 15;
            // 
            // Canje_Puntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 432);
            this.Controls.Add(this.cmbIDsPremios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_Ptos_Cliente);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.lbl_Canje);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_PremiosPorCliente);
            this.Controls.Add(this.lbl_Puntos_Cliente);
            this.Controls.Add(this.lbl_Premios_Elegibles);
            this.Controls.Add(this.dgv_Premios_Elegibles);
            this.Controls.Add(this.label1);
            this.Name = "Canje_Puntos";
            this.Text = "Canje de puntos";
            this.Load += new System.EventHandler(this.cargarPtos_Premios);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Premios_Elegibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PremiosPorCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Ptos_Cliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Premios_Elegibles;
        private System.Windows.Forms.Label lbl_Premios_Elegibles;
        private System.Windows.Forms.Label lbl_Puntos_Cliente;
        private System.Windows.Forms.DataGridView dgv_PremiosPorCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Canje;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.DataGridView dgv_Ptos_Cliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbIDsPremios;
    }
}