namespace ProjectPemrog_MN.Views
{
    partial class FormEditProfilKaryawan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label lblJabatan;
        private System.Windows.Forms.Label lblGaji;
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.Label lblNoHP;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtJabatan;
        private System.Windows.Forms.TextBox txtGaji;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtNoHP;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Panel panelForm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelForm = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.lblJabatan = new System.Windows.Forms.Label();
            this.lblGaji = new System.Windows.Forms.Label();
            this.lblAlamat = new System.Windows.Forms.Label();
            this.lblNoHP = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtJabatan = new System.Windows.Forms.TextBox();
            this.txtGaji = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtNoHP = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.lblTitle);
            this.panelForm.Controls.Add(this.lblNama);
            this.panelForm.Controls.Add(this.lblJabatan);
            this.panelForm.Controls.Add(this.lblGaji);
            this.panelForm.Controls.Add(this.lblAlamat);
            this.panelForm.Controls.Add(this.lblNoHP);
            this.panelForm.Controls.Add(this.lblEmail);
            this.panelForm.Controls.Add(this.txtNama);
            this.panelForm.Controls.Add(this.txtJabatan);
            this.panelForm.Controls.Add(this.txtGaji);
            this.panelForm.Controls.Add(this.txtAlamat);
            this.panelForm.Controls.Add(this.txtNoHP);
            this.panelForm.Controls.Add(this.txtEmail);
            this.panelForm.Controls.Add(this.btnSimpan);
            this.panelForm.Controls.Add(this.btnBatal);
            this.panelForm.Location = new System.Drawing.Point(50, 40);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(600, 600);
            this.panelForm.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Edit Profil Karyawan";
            // 
            // lblNama
            // 
            this.lblNama.Location = new System.Drawing.Point(30, 70);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(100, 20);
            this.lblNama.TabIndex = 1;
            this.lblNama.Text = "Nama Lengkap";
            // 
            // lblJabatan
            // 
            this.lblJabatan.Location = new System.Drawing.Point(30, 120);
            this.lblJabatan.Name = "lblJabatan";
            this.lblJabatan.Size = new System.Drawing.Size(100, 20);
            this.lblJabatan.TabIndex = 2;
            this.lblJabatan.Text = "Jabatan";
            // 
            // lblGaji
            // 
            this.lblGaji.Location = new System.Drawing.Point(30, 170);
            this.lblGaji.Name = "lblGaji";
            this.lblGaji.Size = new System.Drawing.Size(100, 20);
            this.lblGaji.TabIndex = 3;
            this.lblGaji.Text = "Gaji Pokok";
            // 
            // lblAlamat
            // 
            this.lblAlamat.Location = new System.Drawing.Point(30, 220);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(100, 20);
            this.lblAlamat.TabIndex = 4;
            this.lblAlamat.Text = "Alamat";
            // 
            // lblNoHP
            // 
            this.lblNoHP.Location = new System.Drawing.Point(30, 300);
            this.lblNoHP.Name = "lblNoHP";
            this.lblNoHP.Size = new System.Drawing.Size(100, 20);
            this.lblNoHP.TabIndex = 5;
            this.lblNoHP.Text = "No. HP";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(30, 350);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 20);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(150, 65);
            this.txtNama.Name = "txtNama";
            this.txtNama.ReadOnly = true;
            this.txtNama.Size = new System.Drawing.Size(400, 20);
            this.txtNama.TabIndex = 9;
            // 
            // txtJabatan
            // 
            this.txtJabatan.Location = new System.Drawing.Point(150, 115);
            this.txtJabatan.Name = "txtJabatan";
            this.txtJabatan.ReadOnly = true;
            this.txtJabatan.Size = new System.Drawing.Size(400, 20);
            this.txtJabatan.TabIndex = 10;
            // 
            // txtGaji
            // 
            this.txtGaji.Location = new System.Drawing.Point(150, 165);
            this.txtGaji.Name = "txtGaji";
            this.txtGaji.ReadOnly = true;
            this.txtGaji.Size = new System.Drawing.Size(400, 20);
            this.txtGaji.TabIndex = 11;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(150, 215);
            this.txtAlamat.Multiline = true;
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(400, 70);
            this.txtAlamat.TabIndex = 12;
            // 
            // txtNoHP
            // 
            this.txtNoHP.Location = new System.Drawing.Point(150, 295);
            this.txtNoHP.Name = "txtNoHP";
            this.txtNoHP.Size = new System.Drawing.Size(400, 20);
            this.txtNoHP.TabIndex = 13;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(150, 345);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(400, 20);
            this.txtEmail.TabIndex = 14;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(260, 530);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(100, 35);
            this.btnSimpan.TabIndex = 17;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.BackColor = System.Drawing.Color.DarkGray;
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.Location = new System.Drawing.Point(370, 530);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(100, 35);
            this.btnBatal.TabIndex = 18;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // FormEditProfilKaryawan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(700, 700);
            this.Controls.Add(this.panelForm);
            this.Name = "FormEditProfilKaryawan";
            this.Text = "Edit Profil Karyawan";
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}