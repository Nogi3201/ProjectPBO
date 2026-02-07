namespace ProjectPemrog_MN.Views
{
    partial class FormDaftarKaryawan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvKaryawan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvKaryawan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKaryawan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKaryawan
            // 
            this.dgvKaryawan.AllowUserToAddRows = false;
            this.dgvKaryawan.AllowUserToDeleteRows = false;
            this.dgvKaryawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKaryawan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKaryawan.Location = new System.Drawing.Point(0, 0);
            this.dgvKaryawan.Name = "dgvKaryawan";
            this.dgvKaryawan.ReadOnly = true;
            this.dgvKaryawan.RowHeadersWidth = 51;
            this.dgvKaryawan.RowTemplate.Height = 24;
            this.dgvKaryawan.Size = new System.Drawing.Size(800, 450);
            this.dgvKaryawan.TabIndex = 0;
            // 
            // FormDaftarKaryawan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvKaryawan);
            this.Name = "FormDaftarKaryawan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daftar Karyawan";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKaryawan)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
