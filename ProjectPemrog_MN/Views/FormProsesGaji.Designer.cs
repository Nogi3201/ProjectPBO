namespace ProjectPemrog_MN.Views
{
    partial class FormProsesGaji
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbKaryawan;
        private System.Windows.Forms.NumericUpDown numBulan;
        private System.Windows.Forms.NumericUpDown numTahun;
        private System.Windows.Forms.TextBox txtGajiPokok;
        private System.Windows.Forms.TextBox txtJamLembur;
        private System.Windows.Forms.TextBox txtTarifLembur;
        private System.Windows.Forms.TextBox txtTotalLembur;
        private System.Windows.Forms.TextBox txtTotalGaji;
        private System.Windows.Forms.Button btnProses;

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
            cbKaryawan = new System.Windows.Forms.ComboBox();
            numBulan = new System.Windows.Forms.NumericUpDown();
            numTahun = new System.Windows.Forms.NumericUpDown();
            txtGajiPokok = new System.Windows.Forms.TextBox();
            txtJamLembur = new System.Windows.Forms.TextBox();
            txtTarifLembur = new System.Windows.Forms.TextBox();
            txtTotalLembur = new System.Windows.Forms.TextBox();
            txtTotalGaji = new System.Windows.Forms.TextBox();
            btnProses = new System.Windows.Forms.Button();

            // Title
            lblTitle.Text = "Proses Gaji Karyawan";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Height = 48;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ComboBox Karyawan
            cbKaryawan.Left = 20;
            cbKaryawan.Top = 60;
            cbKaryawan.Width = 360;
            cbKaryawan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbKaryawan.SelectedIndexChanged += new System.EventHandler(this.cbKaryawan_SelectedIndexChanged);

            // Bulan
            numBulan.Left = 20;
            numBulan.Top = 100;
            numBulan.Minimum = 1;
            numBulan.Maximum = 12;
            numBulan.Value = 1;

            // Tahun
            numTahun.Left = 140;
            numTahun.Top = 100;
            numTahun.Minimum = 2020;
            numTahun.Maximum = 2100;
            numTahun.Value = 2026;

            // Labels for inputs (added for clarity)
            var lblKaryawan = new System.Windows.Forms.Label() { Left = 20, Top = 40, Text = "Karyawan:" };
            var lblPeriode = new System.Windows.Forms.Label() { Left = 20, Top = 80, Text = "Periode (Bulan / Tahun):" };
            var lblGajiPokok = new System.Windows.Forms.Label() { Left = 20, Top = 120, Text = "Gaji Pokok:" };
            var lblJamLembur = new System.Windows.Forms.Label() { Left = 20, Top = 160, Text = "Jam Lembur:" };
            var lblTarifLembur = new System.Windows.Forms.Label() { Left = 20, Top = 200, Text = "Tarif Lembur/ jam:" };
            var lblTotalLembur = new System.Windows.Forms.Label() { Left = 20, Top = 240, Text = "Total Lembur:" };
            var lblTotalGaji = new System.Windows.Forms.Label() { Left = 20, Top = 280, Text = "Total Gaji:" };

            // TextBox
            txtGajiPokok.Left = 160; txtGajiPokok.Top = 120; txtGajiPokok.Width = 220; txtGajiPokok.ReadOnly = true;
            txtJamLembur.Left = 160; txtJamLembur.Top = 160; txtJamLembur.Width = 220;
            txtTarifLembur.Left = 160; txtTarifLembur.Top = 200; txtTarifLembur.Width = 220; txtTarifLembur.ReadOnly = true;
            txtTotalLembur.Left = 160; txtTotalLembur.Top = 240; txtTotalLembur.Width = 220; txtTotalLembur.ReadOnly = true;
            txtTotalGaji.Left = 160; txtTotalGaji.Top = 280; txtTotalGaji.Width = 220; txtTotalGaji.ReadOnly = true;

            // Button
            btnProses.Text = "Proses & Simpan";
            btnProses.Left = 160;
            btnProses.Top = 320;
            btnProses.Width = 120;
            btnProses.Click += new System.EventHandler(this.btnProses_Click);

            // Add controls
            Controls.Add(lblTitle);
            Controls.Add(lblKaryawan);
            Controls.Add(cbKaryawan);
            Controls.Add(lblPeriode);
            Controls.Add(numBulan);
            Controls.Add(numTahun);
            Controls.Add(lblGajiPokok);
            Controls.Add(txtGajiPokok);
            Controls.Add(lblJamLembur);
            Controls.Add(txtJamLembur);
            Controls.Add(lblTarifLembur);
            Controls.Add(txtTarifLembur);
            Controls.Add(lblTotalLembur);
            Controls.Add(txtTotalLembur);
            Controls.Add(lblTotalGaji);
            Controls.Add(txtTotalGaji);
            Controls.Add(btnProses);

            this.Width = 420;
            this.Height = 420;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            Dock = System.Windows.Forms.DockStyle.Fill;
        }
    }
}
