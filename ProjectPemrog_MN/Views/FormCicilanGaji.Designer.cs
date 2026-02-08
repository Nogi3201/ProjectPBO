namespace ProjectPemrog_MN.Views
{
    partial class FormCicilanGaji
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvCicilan;
        private System.Windows.Forms.TextBox txtIdKaryawan;
        private System.Windows.Forms.TextBox txtJumlah;
        private System.Windows.Forms.Button btnTambah;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvCicilan = new System.Windows.Forms.DataGridView();
            this.txtIdKaryawan = new System.Windows.Forms.TextBox();
            this.txtJumlah = new System.Windows.Forms.TextBox();
            this.btnTambah = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCicilan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 300);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1308, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cicilan Gaji";
            // 
            // dgvCicilan
            // 
            this.dgvCicilan.AllowUserToAddRows = false;
            this.dgvCicilan.ColumnHeadersHeight = 34;
            this.dgvCicilan.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCicilan.Location = new System.Drawing.Point(0, 0);
            this.dgvCicilan.Name = "dgvCicilan";
            this.dgvCicilan.ReadOnly = true;
            this.dgvCicilan.RowHeadersWidth = 62;
            this.dgvCicilan.Size = new System.Drawing.Size(1308, 300);
            this.dgvCicilan.TabIndex = 1;
            // 
            // txtIdKaryawan
            // 
            this.txtIdKaryawan.Location = new System.Drawing.Point(20, 350);
            this.txtIdKaryawan.Name = "txtIdKaryawan";
            this.txtIdKaryawan.Size = new System.Drawing.Size(200, 26);
            this.txtIdKaryawan.TabIndex = 2;
            // 
            // txtJumlah
            // 
            this.txtJumlah.Location = new System.Drawing.Point(240, 350);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(150, 26);
            this.txtJumlah.TabIndex = 3;
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(410, 350);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.TabIndex = 4;
            this.btnTambah.Text = "Simpan Cicilan";
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // FormCicilanGaji
            // 
            this.ClientSize = new System.Drawing.Size(1308, 843);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvCicilan);
            this.Controls.Add(this.txtIdKaryawan);
            this.Controls.Add(this.txtJumlah);
            this.Controls.Add(this.btnTambah);
            this.Name = "FormCicilanGaji";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCicilan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
