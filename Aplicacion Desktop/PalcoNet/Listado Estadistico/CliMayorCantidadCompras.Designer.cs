namespace PalcoNet.Listado_Estadistico
{
    partial class ClientesConMayorCantComprasForm
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
            this.dgvCMCC = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCMCC)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCMCC
            // 
            this.dgvCMCC.AllowUserToAddRows = false;
            this.dgvCMCC.AllowUserToDeleteRows = false;
            this.dgvCMCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCMCC.Location = new System.Drawing.Point(12, 12);
            this.dgvCMCC.Name = "dgvCMCC";
            this.dgvCMCC.ReadOnly = true;
            this.dgvCMCC.Size = new System.Drawing.Size(571, 271);
            this.dgvCMCC.TabIndex = 0;
            // 
            // ClientesConMayorCantComprasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 295);
            this.Controls.Add(this.dgvCMCC);
            this.Name = "ClientesConMayorCantComprasForm";
            this.Text = "Clientes con mayor cantidad de compras";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCMCC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCMCC;
    }
}