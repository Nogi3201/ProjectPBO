using System.Windows.Forms;
using System.Drawing;

namespace ProjectPemrog_MN.Views
{
    partial class FormDataJabatan
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgvJabatan;
        private TextBox txtNamaJabatan;
        private TextBox txtGajiPokok;
        private Button btnTambah;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvJabatan = new System.Windows.Forms.DataGridView();
            this.btnTambah = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJabatan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1308, 40);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Data Jabatan";
            // 
            // dgvJabatan
            // 
            this.dgvJabatan.ColumnHeadersHeight = 34;
            // Reserve space for input fields below the grid
            this.dgvJabatan.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvJabatan.Height = 700;
            this.dgvJabatan.Location = new System.Drawing.Point(0, 40);
            this.dgvJabatan.Name = "dgvJabatan";
            this.dgvJabatan.RowHeadersWidth = 62;
            this.dgvJabatan.TabIndex = 0;
            // 
            // btnTambah
            // 
            this.btnTambah.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTambah.Location = new System.Drawing.Point(0, 844);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(1308, 40);
            this.btnTambah.TabIndex = 1;
            this.btnTambah.Text = "Tambah Jabatan";
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);

            // txtNamaJabatan
            this.txtNamaJabatan = new System.Windows.Forms.TextBox();
            this.txtNamaJabatan.SetBounds(20, 750, 400, 30);
            this.txtNamaJabatan.Name = "txtNamaJabatan";

            // txtGajiPokok
            this.txtGajiPokok = new System.Windows.Forms.TextBox();
            this.txtGajiPokok.SetBounds(440, 750, 200, 30);
            this.txtGajiPokok.Name = "txtGajiPokok";
            this.txtGajiPokok.Text = string.Empty;
            // 
            // FormDataJabatan
            // 
            this.ClientSize = new System.Drawing.Size(1308, 884);
            this.Controls.Add(this.txtNamaJabatan);
            this.Controls.Add(this.txtGajiPokok);
            this.Controls.Add(this.dgvJabatan);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormDataJabatan";
            ((System.ComponentModel.ISupportInitialize)(this.dgvJabatan)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
