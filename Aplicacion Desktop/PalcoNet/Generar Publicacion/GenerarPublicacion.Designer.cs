namespace PalcoNet.Generar_Publicacion
{
    partial class GenerarPublicacion
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ubicacionPrecio = new System.Windows.Forms.TextBox();
            this.ubicacionAsientos = new System.Windows.Forms.TextBox();
            this.ubicacionFilas = new System.Windows.Forms.TextBox();
            this.ubicacionTipo = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.rubro = new System.Windows.Forms.TextBox();
            this.estado = new System.Windows.Forms.ComboBox();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grado = new System.Windows.Forms.ComboBox();
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Filas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Asientos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Precio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rubro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Estado";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Direccion";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(12, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 124);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funciones";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(258, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(192, 69);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Seleccionar fecha y hora:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(375, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Agregar función";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ubicacionPrecio);
            this.groupBox2.Controls.Add(this.ubicacionAsientos);
            this.groupBox2.Controls.Add(this.ubicacionFilas);
            this.groupBox2.Controls.Add(this.ubicacionTipo);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.listView2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 289);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 165);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ubicaciones";
            // 
            // ubicacionPrecio
            // 
            this.ubicacionPrecio.Location = new System.Drawing.Point(120, 102);
            this.ubicacionPrecio.Name = "ubicacionPrecio";
            this.ubicacionPrecio.Size = new System.Drawing.Size(100, 20);
            this.ubicacionPrecio.TabIndex = 10;
            // 
            // ubicacionAsientos
            // 
            this.ubicacionAsientos.Location = new System.Drawing.Point(120, 75);
            this.ubicacionAsientos.Name = "ubicacionAsientos";
            this.ubicacionAsientos.Size = new System.Drawing.Size(100, 20);
            this.ubicacionAsientos.TabIndex = 9;
            // 
            // ubicacionFilas
            // 
            this.ubicacionFilas.Location = new System.Drawing.Point(120, 48);
            this.ubicacionFilas.Name = "ubicacionFilas";
            this.ubicacionFilas.Size = new System.Drawing.Size(100, 20);
            this.ubicacionFilas.TabIndex = 8;
            // 
            // ubicacionTipo
            // 
            this.ubicacionTipo.Location = new System.Drawing.Point(120, 20);
            this.ubicacionTipo.Name = "ubicacionTipo";
            this.ubicacionTipo.Size = new System.Drawing.Size(100, 20);
            this.ubicacionTipo.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(369, 136);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Limpiar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Tipo,
            this.Filas,
            this.Asientos,
            this.Precio});
            this.listView2.Location = new System.Drawing.Point(258, 14);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(186, 116);
            this.listView2.TabIndex = 5;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(99, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Agregar ubicación";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Precio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Asientos por fila";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Cantidad de filas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tipo";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(111, 462);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Regresar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(281, 462);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(130, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Generar publicación";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(171, 14);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(176, 20);
            this.descripcion.TabIndex = 8;
            // 
            // rubro
            // 
            this.rubro.Location = new System.Drawing.Point(171, 42);
            this.rubro.Name = "rubro";
            this.rubro.Size = new System.Drawing.Size(176, 20);
            this.rubro.TabIndex = 9;
            // 
            // estado
            // 
            this.estado.FormattingEnabled = true;
            this.estado.Location = new System.Drawing.Point(171, 70);
            this.estado.Name = "estado";
            this.estado.Size = new System.Drawing.Size(176, 21);
            this.estado.TabIndex = 10;
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(171, 98);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(176, 20);
            this.direccion.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Grado";
            // 
            // grado
            // 
            this.grado.FormattingEnabled = true;
            this.grado.Location = new System.Drawing.Point(171, 126);
            this.grado.Name = "grado";
            this.grado.Size = new System.Drawing.Size(176, 21);
            this.grado.TabIndex = 13;
            // 
            // Tipo
            // 
            this.Tipo.Text = "Tipo";
            // 
            // Filas
            // 
            this.Filas.Text = "Filas";
            // 
            // Asientos
            // 
            this.Asientos.Text = "Asientos";
            // 
            // Precio
            // 
            this.Precio.Text = "Precio";
            // 
            // GenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 497);
            this.Controls.Add(this.grado);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.direccion);
            this.Controls.Add(this.estado);
            this.Controls.Add(this.rubro);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GenerarPublicacion";
            this.Text = "Generar publicación";
            this.Load += new System.EventHandler(this.GenerarPublicacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.TextBox rubro;
        private System.Windows.Forms.ComboBox estado;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.TextBox ubicacionPrecio;
        private System.Windows.Forms.TextBox ubicacionAsientos;
        private System.Windows.Forms.TextBox ubicacionFilas;
        private System.Windows.Forms.TextBox ubicacionTipo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox grado;
        private System.Windows.Forms.ColumnHeader Tipo;
        private System.Windows.Forms.ColumnHeader Filas;
        private System.Windows.Forms.ColumnHeader Asientos;
        private System.Windows.Forms.ColumnHeader Precio;
    }
}