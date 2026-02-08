namespace ProjectPemrog_MN.Views
{
    partial class FormCetakData
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvCetak;
        private System.Windows.Forms.Button btnCetak;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new System.Windows.Forms.Label();
            dgvCetak = new System.Windows.Forms.DataGridView();
            btnCetak = new System.Windows.Forms.Button();

            // ===== Title =====
            lblTitle.Text = "Cetak Data Gaji";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Height = 48;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ===== DataGridView =====
            dgvCetak.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvCetak.ReadOnly = true;
            dgvCetak.AllowUserToAddRows = false;
            dgvCetak.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvCetak.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // ===== Button Cetak =====
            btnCetak.Text = "Cetak";
            btnCetak.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnCetak.Height = 40;
            btnCetak.Click += new System.EventHandler(this.btnCetak_Click);

            // ===== Form =====
            Controls.Add(dgvCetak);
            Controls.Add(btnCetak);
            Controls.Add(lblTitle);
            this.Width = 800;
            this.Height = 600;
            Dock = System.Windows.Forms.DockStyle.Fill;
        }
    }
}