namespace PalcoNet.Comprar
{
    partial class Comprar
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
            this.chkLBCat = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fechaHasta = new System.Windows.Forms.DateTimePicker();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvPublicaciones = new System.Windows.Forms.DataGridView();
            this.btnElegir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAvanzaPag = new System.Windows.Forms.Button();
            this.btnRetrocede = new System.Windows.Forms.Button();
            this.btnPrimeraPag = new System.Windows.Forms.Button();
            this.btnUltimaPag = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Categorias:";
            // 
            // chkLBCat
            // 
            this.chkLBCat.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.chkLBCat.FormattingEnabled = true;
            this.chkLBCat.Location = new System.Drawing.Point(243, 29);
            this.chkLBCat.Name = "chkLBCat";
            this.chkLBCat.Size = new System.Drawing.Size(200, 64);
            this.chkLBCat.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripcion:";
            // 
            // descripcion
            // 
            this.descripcion.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.descripcion.Location = new System.Drawing.Point(243, 110);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(200, 20);
            this.descripcion.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Desde:";
            // 
            // fechaDesde
            // 
            this.fechaDesde.Location = new System.Drawing.Point(87, 23);
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(200, 20);
            this.fechaDesde.TabIndex = 6;
            this.fechaDesde.ValueChanged += new System.EventHandler(this.fechaDesde_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Hasta:";
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.groupBox1.Controls.Add(this.fechaHasta);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.fechaDesde);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(160, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 93);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha";
            // 
            // fechaHasta
            // 
            this.fechaHasta.Location = new System.Drawing.Point(87, 55);
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Size = new System.Drawing.Size(200, 20);
            this.fechaHasta.TabIndex = 8;
            this.fechaHasta.ValueChanged += new System.EventHandler(this.fechaHasta_ValueChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(204, 243);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(312, 243);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(117, 23);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar espectaculos";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvPublicaciones
            // 
            this.dgvPublicaciones.AllowUserToAddRows = false;
            this.dgvPublicaciones.AllowUserToDeleteRows = false;
            this.dgvPublicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublicaciones.Location = new System.Drawing.Point(12, 272);
            this.dgvPublicaciones.Name = "dgvPublicaciones";
            this.dgvPublicaciones.ReadOnly = true;
            this.dgvPublicaciones.Size = new System.Drawing.Size(579, 270);
            this.dgvPublicaciones.TabIndex = 12;
            this.dgvPublicaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPublicaciones_CellContentClick);
            this.dgvPublicaciones.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPublicaciones_RowEnter);
            // 
            // btnElegir
            // 
            this.btnElegir.Enabled = false;
            this.btnElegir.Location = new System.Drawing.Point(243, 589);
            this.btnElegir.Name = "btnElegir";
            this.btnElegir.Size = new System.Drawing.Size(112, 23);
            this.btnElegir.TabIndex = 13;
            this.btnElegir.Text = "Elegir ubicaciones";
            this.btnElegir.UseVisualStyleBackColor = true;
            this.btnElegir.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 14;
            // 
            // btnAvanzaPag
            // 
            this.btnAvanzaPag.Enabled = false;
            this.btnAvanzaPag.Location = new System.Drawing.Point(93, 548);
            this.btnAvanzaPag.Name = "btnAvanzaPag";
            this.btnAvanzaPag.Size = new System.Drawing.Size(75, 23);
            this.btnAvanzaPag.TabIndex = 18;
            this.btnAvanzaPag.Text = "Avanzar";
            this.btnAvanzaPag.UseVisualStyleBackColor = true;
            this.btnAvanzaPag.Click += new System.EventHandler(this.btnAvanzaPag_Click);
            // 
            // btnRetrocede
            // 
            this.btnRetrocede.Enabled = false;
            this.btnRetrocede.Location = new System.Drawing.Point(12, 548);
            this.btnRetrocede.Name = "btnRetrocede";
            this.btnRetrocede.Size = new System.Drawing.Size(75, 23);
            this.btnRetrocede.TabIndex = 19;
            this.btnRetrocede.Text = "Retroceder";
            this.btnRetrocede.UseVisualStyleBackColor = true;
            this.btnRetrocede.Click += new System.EventHandler(this.btnRetrocede_Click);
            // 
            // btnPrimeraPag
            // 
            this.btnPrimeraPag.Enabled = false;
            this.btnPrimeraPag.Location = new System.Drawing.Point(391, 548);
            this.btnPrimeraPag.Name = "btnPrimeraPag";
            this.btnPrimeraPag.Size = new System.Drawing.Size(100, 23);
            this.btnPrimeraPag.TabIndex = 20;
            this.btnPrimeraPag.Text = "Primera Página";
            this.btnPrimeraPag.UseVisualStyleBackColor = true;
            this.btnPrimeraPag.Click += new System.EventHandler(this.btnPrimeraPag_Click);
            // 
            // btnUltimaPag
            // 
            this.btnUltimaPag.Enabled = false;
            this.btnUltimaPag.Location = new System.Drawing.Point(497, 548);
            this.btnUltimaPag.Name = "btnUltimaPag";
            this.btnUltimaPag.Size = new System.Drawing.Size(94, 23);
            this.btnUltimaPag.TabIndex = 21;
            this.btnUltimaPag.Text = "Ultima página";
            this.btnUltimaPag.UseVisualStyleBackColor = true;
            this.btnUltimaPag.Click += new System.EventHandler(this.btnUltimaPag_Click);
            // 
            // Comprar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 624);
            this.Controls.Add(this.btnUltimaPag);
            this.Controls.Add(this.btnPrimeraPag);
            this.Controls.Add(this.btnRetrocede);
            this.Controls.Add(this.btnAvanzaPag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnElegir);
            this.Controls.Add(this.dgvPublicaciones);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkLBCat);
            this.Controls.Add(this.label1);
            this.Name = "Comprar";
            this.Text = "Comprar";
            this.Load += new System.EventHandler(this.Comprar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chkLBCat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fechaDesde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvPublicaciones;
        private System.Windows.Forms.Button btnElegir;
        private System.Windows.Forms.DateTimePicker fechaHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAvanzaPag;
        private System.Windows.Forms.Button btnRetrocede;
        private System.Windows.Forms.Button btnPrimeraPag;
        private System.Windows.Forms.Button btnUltimaPag;
    }
}