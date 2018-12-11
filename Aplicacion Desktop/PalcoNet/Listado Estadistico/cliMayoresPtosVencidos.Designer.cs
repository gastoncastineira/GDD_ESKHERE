namespace PalcoNet.Listado_Estadistico
{
    partial class CliMayoresPtosvencidos
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
            this.dgvCMPV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCMPV)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCMPV
            // 
            this.dgvCMPV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCMPV.Location = new System.Drawing.Point(12, 35);
            this.dgvCMPV.Name = "dgvCMPV";
            this.dgvCMPV.Size = new System.Drawing.Size(520, 209);
            this.dgvCMPV.TabIndex = 1;
            // 
            // CliMayoresPtosvencidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 290);
            this.Controls.Add(this.dgvCMPV);
            this.Name = "CliMayoresPtosvencidos";
            this.Text = "Clientes con mayores puntos vencidos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCMPV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCMPV;
    }
}