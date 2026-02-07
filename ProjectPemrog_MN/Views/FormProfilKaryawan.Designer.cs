namespace ProjectPemrog_MN.Views
{
    partial class FormProfilKaryawan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label lblJabatan;
        private System.Windows.Forms.Label lblGaji;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtJabatan;
        private System.Windows.Forms.TextBox txtGaji;
        private System.Windows.Forms.Panel panelProfil;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelProfil = new System.Windows.Forms.Panel();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.lblJabatan = new System.Windows.Forms.Label();
            this.lblGaji = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtJabatan = new System.Windows.Forms.TextBox();
            this.txtGaji = new System.Windows.Forms.TextBox();

            this.panelProfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();

            // panelProfil
            this.panelProfil.BackColor = System.Drawing.Color.White;
            this.panelProfil.Controls.Add(this.picFoto);
            this.panelProfil.Controls.Add(this.lblTitle);
            this.panelProfil.Controls.Add(this.lblNama);
            this.panelProfil.Controls.Add(this.lblJabatan);
            this.panelProfil.Controls.Add(this.lblGaji);
            this.panelProfil.Controls.Add(this.txtNama);
            this.panelProfil.Controls.Add(this.txtJabatan);
            this.panelProfil.Controls.Add(this.txtGaji);
            this.panelProfil.Location = new System.Drawing.Point(50, 40);
            this.panelProfil.Size = new System.Drawing.Size(700, 350);

            // picFoto
            this.picFoto.Location = new System.Drawing.Point(30, 80);
            this.picFoto.Size = new System.Drawing.Size(150, 150);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblTitle
            this.lblTitle.Text = "Profil Karyawan";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);

            // Labels
            this.lblNama.Text = "Nama Lengkap";
            this.lblNama.Location = new System.Drawing.Point(220, 90);

            this.lblJabatan.Text = "Jabatan";
            this.lblJabatan.Location = new System.Drawing.Point(220, 150);

            this.lblGaji.Text = "Gaji Pokok";
            this.lblGaji.Location = new System.Drawing.Point(220, 210);

            // TextBox
            this.txtNama.Location = new System.Drawing.Point(350, 85);
            this.txtNama.ReadOnly = true;
            this.txtNama.Width = 250;

            this.txtJabatan.Location = new System.Drawing.Point(350, 145);
            this.txtJabatan.ReadOnly = true;
            this.txtJabatan.Width = 250;

            this.txtGaji.Location = new System.Drawing.Point(350, 205);
            this.txtGaji.ReadOnly = true;
            this.txtGaji.Width = 250;

            // Form
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.panelProfil);
            this.Text = "Profil Karyawan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.panelProfil.ResumeLayout(false);
            this.panelProfil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
