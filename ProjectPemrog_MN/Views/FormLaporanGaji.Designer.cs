namespace ProjectPemrog_MN.Views
{
    partial class FormLaporanGaji
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbBulan;
        private System.Windows.Forms.ComboBox cbTahun;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.Panel panelTop;

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
            cbBulan = new System.Windows.Forms.ComboBox();
            cbTahun = new System.Windows.Forms.ComboBox();
            btnTampilkan = new System.Windows.Forms.Button();
            dgvLaporan = new System.Windows.Forms.DataGridView();
            panelTop = new System.Windows.Forms.Panel();

            // ===== Title =====
            lblTitle.Text = "Laporan Gaji Karyawan";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Height = 48;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ===== Panel Top =====
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Height = 60;

            cbBulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbBulan.Left = 10;
            cbBulan.Top = 18;
            cbBulan.Width = 180;

            cbTahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbTahun.Left = 200;
            cbTahun.Top = 18;
            cbTahun.Width = 100;

            btnTampilkan.Text = "Tampilkan";
            btnTampilkan.Left = 320;
            btnTampilkan.Top = 16;
            btnTampilkan.Width = 120;
            btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);

            panelTop.Controls.Add(cbBulan);
            panelTop.Controls.Add(cbTahun);
            panelTop.Controls.Add(btnTampilkan);

            // ===== DataGridView =====
            dgvLaporan.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvLaporan.ReadOnly = true;
            dgvLaporan.AllowUserToAddRows = false;
            dgvLaporan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvLaporan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // ===== Form =====
            Controls.Add(dgvLaporan);
            Controls.Add(panelTop);
            Controls.Add(lblTitle);
            this.Width = 900;
            this.Height = 600;
            Dock = System.Windows.Forms.DockStyle.Fill;
        }
    }
}
