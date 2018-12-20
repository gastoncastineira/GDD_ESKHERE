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
            this.grado = new System.Windows.Forms.ComboBox();
            this.direccion = new System.Windows.Forms.TextBox();
            this.estado = new System.Windows.Forms.ComboBox();
            this.rubro = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnUbicacion = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Filas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Asientos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Precio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLimpiarUbicaciones = new System.Windows.Forms.Button();
            this.ubicacionFilas = new System.Windows.Forms.TextBox();
            this.ubicacionAsientos = new System.Windows.Forms.TextBox();
            this.ubicacionPrecio = new System.Windows.Forms.TextBox();
            this.ubicacionTipo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnFuncion = new System.Windows.Forms.Button();
            this.btnLimpiarFunciones = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grado
            // 
            this.grado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.grado.FormattingEnabled = true;
            this.grado.Location = new System.Drawing.Point(177, 170);
            this.grado.Name = "grado";
            this.grado.Size = new System.Drawing.Size(176, 21);
            this.grado.TabIndex = 41;
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(177, 142);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(176, 20);
            this.direccion.TabIndex = 39;
            // 
            // estado
            // 
            this.estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estado.FormattingEnabled = true;
            this.estado.Location = new System.Drawing.Point(177, 114);
            this.estado.Name = "estado";
            this.estado.Size = new System.Drawing.Size(176, 21);
            this.estado.TabIndex = 38;
            // 
            // rubro
            // 
            this.rubro.Location = new System.Drawing.Point(177, 86);
            this.rubro.Name = "rubro";
            this.rubro.Size = new System.Drawing.Size(176, 20);
            this.rubro.TabIndex = 37;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(287, 506);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(130, 23);
            this.btnGenerar.TabIndex = 35;
            this.btnGenerar.Text = "Generar publicación";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(117, 506);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 34;
            this.button5.Text = "Regresar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Descripción";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(177, 58);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(176, 20);
            this.descripcion.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Direccion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Rubro";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Grado";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Cantidad de filas";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Precio (en $)";
            // 
            // btnUbicacion
            // 
            this.btnUbicacion.Location = new System.Drawing.Point(99, 136);
            this.btnUbicacion.Name = "btnUbicacion";
            this.btnUbicacion.Size = new System.Drawing.Size(121, 23);
            this.btnUbicacion.TabIndex = 4;
            this.btnUbicacion.Text = "Agregar ubicación";
            this.btnUbicacion.UseVisualStyleBackColor = true;
            this.btnUbicacion.Click += new System.EventHandler(this.btnUbicacion_Click);
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
            this.listView2.Size = new System.Drawing.Size(255, 116);
            this.listView2.TabIndex = 5;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // Tipo
            // 
            this.Tipo.Text = "Tipo";
            this.Tipo.Width = 66;
            // 
            // Filas
            // 
            this.Filas.Text = "Filas";
            this.Filas.Width = 49;
            // 
            // Asientos
            // 
            this.Asientos.Text = "Asientos";
            this.Asientos.Width = 58;
            // 
            // Precio
            // 
            this.Precio.Text = "Precio (en $)";
            this.Precio.Width = 72;
            // 
            // btnLimpiarUbicaciones
            // 
            this.btnLimpiarUbicaciones.Location = new System.Drawing.Point(438, 136);
            this.btnLimpiarUbicaciones.Name = "btnLimpiarUbicaciones";
            this.btnLimpiarUbicaciones.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarUbicaciones.TabIndex = 6;
            this.btnLimpiarUbicaciones.Text = "Limpiar";
            this.btnLimpiarUbicaciones.UseVisualStyleBackColor = true;
            this.btnLimpiarUbicaciones.Click += new System.EventHandler(this.btnLimpiarUbicaciones_Click);
            // 
            // ubicacionFilas
            // 
            this.ubicacionFilas.Location = new System.Drawing.Point(120, 48);
            this.ubicacionFilas.Name = "ubicacionFilas";
            this.ubicacionFilas.Size = new System.Drawing.Size(100, 20);
            this.ubicacionFilas.TabIndex = 8;
            this.ubicacionFilas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ubicacionFilas_KeyPress);
            // 
            // ubicacionAsientos
            // 
            this.ubicacionAsientos.Location = new System.Drawing.Point(120, 75);
            this.ubicacionAsientos.Name = "ubicacionAsientos";
            this.ubicacionAsientos.Size = new System.Drawing.Size(100, 20);
            this.ubicacionAsientos.TabIndex = 9;
            this.ubicacionAsientos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ubicacionFilas_KeyPress);
            // 
            // ubicacionPrecio
            // 
            this.ubicacionPrecio.Location = new System.Drawing.Point(120, 102);
            this.ubicacionPrecio.Name = "ubicacionPrecio";
            this.ubicacionPrecio.Size = new System.Drawing.Size(100, 20);
            this.ubicacionPrecio.TabIndex = 10;
            this.ubicacionPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ubicacionPrecio_KeyPress);
            // 
            // ubicacionTipo
            // 
            this.ubicacionTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ubicacionTipo.FormattingEnabled = true;
            this.ubicacionTipo.Location = new System.Drawing.Point(120, 20);
            this.ubicacionTipo.Name = "ubicacionTipo";
            this.ubicacionTipo.Size = new System.Drawing.Size(100, 21);
            this.ubicacionTipo.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ubicacionTipo);
            this.groupBox2.Controls.Add(this.ubicacionPrecio);
            this.groupBox2.Controls.Add(this.ubicacionAsientos);
            this.groupBox2.Controls.Add(this.ubicacionFilas);
            this.groupBox2.Controls.Add(this.btnLimpiarUbicaciones);
            this.groupBox2.Controls.Add(this.listView2);
            this.groupBox2.Controls.Add(this.btnUbicacion);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(18, 333);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(519, 165);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ubicaciones";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dddd, dd/MM/yyyy HH:mm tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // btnFuncion
            // 
            this.btnFuncion.Location = new System.Drawing.Point(99, 85);
            this.btnFuncion.Name = "btnFuncion";
            this.btnFuncion.Size = new System.Drawing.Size(107, 23);
            this.btnFuncion.TabIndex = 1;
            this.btnFuncion.Text = "Agregar función";
            this.btnFuncion.UseVisualStyleBackColor = true;
            this.btnFuncion.Click += new System.EventHandler(this.btnFuncion_Click);
            // 
            // btnLimpiarFunciones
            // 
            this.btnLimpiarFunciones.Location = new System.Drawing.Point(438, 94);
            this.btnLimpiarFunciones.Name = "btnLimpiarFunciones";
            this.btnLimpiarFunciones.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarFunciones.TabIndex = 3;
            this.btnLimpiarFunciones.Text = "Limpiar";
            this.btnLimpiarFunciones.UseVisualStyleBackColor = true;
            this.btnLimpiarFunciones.Click += new System.EventHandler(this.btnLimpiarFunciones_Click);
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
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Fecha,
            this.Hora});
            this.listView1.Location = new System.Drawing.Point(258, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(255, 69);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Fecha
            // 
            this.Fecha.Text = "Fecha";
            this.Fecha.Width = 124;
            // 
            // Hora
            // 
            this.Hora.Text = "Hora";
            this.Hora.Width = 122;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnLimpiarFunciones);
            this.groupBox1.Controls.Add(this.btnFuncion);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(18, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 124);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funciones";
            // 
            // GenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 550);
            this.Controls.Add(this.grado);
            this.Controls.Add(this.direccion);
            this.Controls.Add(this.estado);
            this.Controls.Add(this.rubro);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Name = "GenerarPublicacion";
            this.Text = "Generar publicacion";
            this.Load += new System.EventHandler(this.GenerarPublicacion_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox grado;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.ComboBox estado;
        private System.Windows.Forms.TextBox rubro;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnUbicacion;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader Tipo;
        private System.Windows.Forms.ColumnHeader Filas;
        private System.Windows.Forms.ColumnHeader Asientos;
        private System.Windows.Forms.ColumnHeader Precio;
        private System.Windows.Forms.Button btnLimpiarUbicaciones;
        private System.Windows.Forms.TextBox ubicacionFilas;
        private System.Windows.Forms.TextBox ubicacionAsientos;
        private System.Windows.Forms.TextBox ubicacionPrecio;
        private System.Windows.Forms.ComboBox ubicacionTipo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnFuncion;
        private System.Windows.Forms.Button btnLimpiarFunciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Fecha;
        private System.Windows.Forms.ColumnHeader Hora;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}