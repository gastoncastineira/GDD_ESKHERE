namespace PalcoNet.Editar_Publicacion
{
    partial class EditarPublicacion
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
            this.gradoTxt = new System.Windows.Forms.ComboBox();
            this.direccionTxt = new System.Windows.Forms.TextBox();
            this.estadoTxt = new System.Windows.Forms.ComboBox();
            this.rubroTxt = new System.Windows.Forms.TextBox();
            this.descripcionTxt = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvFechasActuales = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvUbicacionesActuales = new System.Windows.Forms.DataGridView();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.btnLimpiarFunciones = new System.Windows.Forms.Button();
            this.btnFuncion = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ubicacionTipo = new System.Windows.Forms.ComboBox();
            this.ubicacionPrecio = new System.Windows.Forms.TextBox();
            this.ubicacionAsientos = new System.Windows.Forms.TextBox();
            this.ubicacionFilas = new System.Windows.Forms.TextBox();
            this.btnLimpiarUbicaciones = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Filas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Asientos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Precio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUbicacion = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechasActuales)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUbicacionesActuales)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradoTxt
            // 
            this.gradoTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradoTxt.FormattingEnabled = true;
            this.gradoTxt.Location = new System.Drawing.Point(386, 121);
            this.gradoTxt.Name = "gradoTxt";
            this.gradoTxt.Size = new System.Drawing.Size(176, 21);
            this.gradoTxt.TabIndex = 46;
            // 
            // direccionTxt
            // 
            this.direccionTxt.Location = new System.Drawing.Point(386, 93);
            this.direccionTxt.Name = "direccionTxt";
            this.direccionTxt.Size = new System.Drawing.Size(176, 20);
            this.direccionTxt.TabIndex = 45;
            // 
            // estadoTxt
            // 
            this.estadoTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estadoTxt.FormattingEnabled = true;
            this.estadoTxt.Location = new System.Drawing.Point(386, 65);
            this.estadoTxt.Name = "estadoTxt";
            this.estadoTxt.Size = new System.Drawing.Size(176, 21);
            this.estadoTxt.TabIndex = 44;
            // 
            // rubroTxt
            // 
            this.rubroTxt.Location = new System.Drawing.Point(386, 37);
            this.rubroTxt.Name = "rubroTxt";
            this.rubroTxt.Size = new System.Drawing.Size(176, 20);
            this.rubroTxt.TabIndex = 43;
            // 
            // descripcionTxt
            // 
            this.descripcionTxt.Location = new System.Drawing.Point(386, 9);
            this.descripcionTxt.Name = "descripcionTxt";
            this.descripcionTxt.Size = new System.Drawing.Size(176, 20);
            this.descripcionTxt.TabIndex = 42;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(222, 538);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 23);
            this.button5.TabIndex = 40;
            this.button5.Text = "Regresar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvFechasActuales);
            this.groupBox1.Location = new System.Drawing.Point(10, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 151);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funciones actuales";
            // 
            // dgvFechasActuales
            // 
            this.dgvFechasActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFechasActuales.Location = new System.Drawing.Point(9, 19);
            this.dgvFechasActuales.Name = "dgvFechasActuales";
            this.dgvFechasActuales.Size = new System.Drawing.Size(354, 121);
            this.dgvFechasActuales.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Direccion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Rubro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Descripción";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(250, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Grado";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvUbicacionesActuales);
            this.groupBox2.Location = new System.Drawing.Point(386, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 151);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ubicaciones actuales";
            // 
            // dgvUbicacionesActuales
            // 
            this.dgvUbicacionesActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUbicacionesActuales.Location = new System.Drawing.Point(14, 19);
            this.dgvUbicacionesActuales.Name = "dgvUbicacionesActuales";
            this.dgvUbicacionesActuales.Size = new System.Drawing.Size(455, 121);
            this.dgvUbicacionesActuales.TabIndex = 14;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(356, 538);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(95, 23);
            this.button7.TabIndex = 47;
            this.button7.Text = "Restaurar";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnLimpiarFunciones);
            this.groupBox3.Controls.Add(this.btnFuncion);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Location = new System.Drawing.Point(12, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(368, 181);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Funciones nuevas";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Fecha,
            this.Hora});
            this.listView1.Location = new System.Drawing.Point(9, 79);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(262, 96);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Fecha
            // 
            this.Fecha.Text = "Fecha";
            this.Fecha.Width = 120;
            // 
            // Hora
            // 
            this.Hora.Text = "Hora";
            this.Hora.Width = 122;
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
            // btnLimpiarFunciones
            // 
            this.btnLimpiarFunciones.Location = new System.Drawing.Point(290, 152);
            this.btnLimpiarFunciones.Name = "btnLimpiarFunciones";
            this.btnLimpiarFunciones.Size = new System.Drawing.Size(55, 23);
            this.btnLimpiarFunciones.TabIndex = 3;
            this.btnLimpiarFunciones.Text = "Limpiar";
            this.btnLimpiarFunciones.UseVisualStyleBackColor = true;
            this.btnLimpiarFunciones.Click += new System.EventHandler(this.btnLimpiarFunciones_Click_1);
            // 
            // btnFuncion
            // 
            this.btnFuncion.Location = new System.Drawing.Point(238, 45);
            this.btnFuncion.Name = "btnFuncion";
            this.btnFuncion.Size = new System.Drawing.Size(107, 23);
            this.btnFuncion.TabIndex = 1;
            this.btnFuncion.Text = "Agregar función";
            this.btnFuncion.UseVisualStyleBackColor = true;
            this.btnFuncion.Click += new System.EventHandler(this.btnFuncion_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dddd, dd/MM/yyyy HH:mm tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(9, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ubicacionTipo);
            this.groupBox4.Controls.Add(this.ubicacionPrecio);
            this.groupBox4.Controls.Add(this.ubicacionAsientos);
            this.groupBox4.Controls.Add(this.ubicacionFilas);
            this.groupBox4.Controls.Add(this.btnLimpiarUbicaciones);
            this.groupBox4.Controls.Add(this.listView2);
            this.groupBox4.Controls.Add(this.btnUbicacion);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(386, 329);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(476, 181);
            this.groupBox4.TabIndex = 49;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ubicaciones";
            // 
            // ubicacionTipo
            // 
            this.ubicacionTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ubicacionTipo.FormattingEnabled = true;
            this.ubicacionTipo.Location = new System.Drawing.Point(102, 21);
            this.ubicacionTipo.Name = "ubicacionTipo";
            this.ubicacionTipo.Size = new System.Drawing.Size(100, 21);
            this.ubicacionTipo.TabIndex = 11;
            // 
            // ubicacionPrecio
            // 
            this.ubicacionPrecio.Location = new System.Drawing.Point(102, 103);
            this.ubicacionPrecio.Name = "ubicacionPrecio";
            this.ubicacionPrecio.Size = new System.Drawing.Size(100, 20);
            this.ubicacionPrecio.TabIndex = 10;
            // 
            // ubicacionAsientos
            // 
            this.ubicacionAsientos.Location = new System.Drawing.Point(102, 76);
            this.ubicacionAsientos.Name = "ubicacionAsientos";
            this.ubicacionAsientos.Size = new System.Drawing.Size(100, 20);
            this.ubicacionAsientos.TabIndex = 9;
            // 
            // ubicacionFilas
            // 
            this.ubicacionFilas.Location = new System.Drawing.Point(102, 49);
            this.ubicacionFilas.Name = "ubicacionFilas";
            this.ubicacionFilas.Size = new System.Drawing.Size(100, 20);
            this.ubicacionFilas.TabIndex = 8;
            // 
            // btnLimpiarUbicaciones
            // 
            this.btnLimpiarUbicaciones.Location = new System.Drawing.Point(382, 152);
            this.btnLimpiarUbicaciones.Name = "btnLimpiarUbicaciones";
            this.btnLimpiarUbicaciones.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarUbicaciones.TabIndex = 6;
            this.btnLimpiarUbicaciones.Text = "Limpiar";
            this.btnLimpiarUbicaciones.UseVisualStyleBackColor = true;
            this.btnLimpiarUbicaciones.Click += new System.EventHandler(this.btnLimpiarUbicaciones_Click_1);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Tipo,
            this.Filas,
            this.Asientos,
            this.Precio});
            this.listView2.Location = new System.Drawing.Point(220, 22);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(237, 124);
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
            this.Filas.Width = 41;
            // 
            // Asientos
            // 
            this.Asientos.Text = "Asientos";
            this.Asientos.Width = 52;
            // 
            // Precio
            // 
            this.Precio.Text = "Precio (en $)";
            this.Precio.Width = 73;
            // 
            // btnUbicacion
            // 
            this.btnUbicacion.Location = new System.Drawing.Point(86, 136);
            this.btnUbicacion.Name = "btnUbicacion";
            this.btnUbicacion.Size = new System.Drawing.Size(121, 23);
            this.btnUbicacion.TabIndex = 4;
            this.btnUbicacion.Text = "Agregar ubicación";
            this.btnUbicacion.UseVisualStyleBackColor = true;
            this.btnUbicacion.Click += new System.EventHandler(this.btnUbicacion_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Precio (en $)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Asientos por fila";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Cantidad de filas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tipo";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(488, 538);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 50;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // EditarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 571);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.gradoTxt);
            this.Controls.Add(this.direccionTxt);
            this.Controls.Add(this.estadoTxt);
            this.Controls.Add(this.rubroTxt);
            this.Controls.Add(this.descripcionTxt);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Name = "EditarPublicacion";
            this.Text = "Editarpublicacion";
            this.Load += new System.EventHandler(this.EditarPublicacion_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechasActuales)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUbicacionesActuales)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox gradoTxt;
        private System.Windows.Forms.TextBox direccionTxt;
        private System.Windows.Forms.ComboBox estadoTxt;
        private System.Windows.Forms.TextBox rubroTxt;
        private System.Windows.Forms.TextBox descripcionTxt;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvFechasActuales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvUbicacionesActuales;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Fecha;
        private System.Windows.Forms.ColumnHeader Hora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLimpiarFunciones;
        private System.Windows.Forms.Button btnFuncion;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox ubicacionTipo;
        private System.Windows.Forms.TextBox ubicacionPrecio;
        private System.Windows.Forms.TextBox ubicacionAsientos;
        private System.Windows.Forms.TextBox ubicacionFilas;
        private System.Windows.Forms.Button btnLimpiarUbicaciones;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader Tipo;
        private System.Windows.Forms.ColumnHeader Filas;
        private System.Windows.Forms.ColumnHeader Asientos;
        private System.Windows.Forms.ColumnHeader Precio;
        private System.Windows.Forms.Button btnUbicacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnModificar;
    }
}