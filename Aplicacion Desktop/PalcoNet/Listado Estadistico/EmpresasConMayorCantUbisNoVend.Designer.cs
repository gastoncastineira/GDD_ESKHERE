namespace PalcoNet.Listado_Estadistico
{
    partial class EmpresasConMayorCantUbisNoVendForm
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
            this.dgcECMUNV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgcECMUNV)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcECMUNV
            // 
            this.dgcECMUNV.AllowUserToAddRows = false;
            this.dgcECMUNV.AllowUserToDeleteRows = false;
            this.dgcECMUNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgcECMUNV.Location = new System.Drawing.Point(12, 12);
            this.dgcECMUNV.Name = "dgcECMUNV";
            this.dgcECMUNV.ReadOnly = true;
            this.dgcECMUNV.Size = new System.Drawing.Size(580, 257);
            this.dgcECMUNV.TabIndex = 0;
            // 
            // EmpresasConMayorCantUbisNoVendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 281);
            this.Controls.Add(this.dgcECMUNV);
            this.Name = "EmpresasConMayorCantUbisNoVendForm";
            this.Text = "Empresas con mayor cantidad de ubicaciones no vendidas";
            ((System.ComponentModel.ISupportInitialize)(this.dgcECMUNV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgcECMUNV;
    }
}