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
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.Label lblNoHP;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtJabatan;
        private System.Windows.Forms.TextBox txtGaji;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtNoHP;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel panelProfil;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnCetakGaji;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnUploadFoto;
        private System.Windows.Forms.Button btnLogout;
        private System.Drawing.Printing.PrintDocument printDocument1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }   

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelProfil = new System.Windows.Forms.Panel();
            this.btnUploadFoto = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCetakGaji = new System.Windows.Forms.Button();
            this.picFoto = new System.Windows.Forms.PictureBox();
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
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panelTop.SuspendLayout();
            this.panelProfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(70)))));
            this.panelTop.Controls.Add(this.btnLogout);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 50);
            this.panelTop.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(800, 10);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 30);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelProfil
            // 
            this.panelProfil.BackColor = System.Drawing.Color.White;
            this.panelProfil.Controls.Add(this.btnUploadFoto);
            this.panelProfil.Controls.Add(this.btnEdit);
            this.panelProfil.Controls.Add(this.btnCetakGaji);
            this.panelProfil.Controls.Add(this.picFoto);
            this.panelProfil.Controls.Add(this.lblTitle);
            this.panelProfil.Controls.Add(this.lblNama);
            this.panelProfil.Controls.Add(this.lblJabatan);
            this.panelProfil.Controls.Add(this.lblGaji);
            this.panelProfil.Controls.Add(this.lblAlamat);
            this.panelProfil.Controls.Add(this.lblNoHP);
            this.panelProfil.Controls.Add(this.lblEmail);
            this.panelProfil.Controls.Add(this.txtNama);
            this.panelProfil.Controls.Add(this.txtJabatan);
            this.panelProfil.Controls.Add(this.txtGaji);
            this.panelProfil.Controls.Add(this.txtAlamat);
            this.panelProfil.Controls.Add(this.txtNoHP);
            this.panelProfil.Controls.Add(this.txtEmail);
            this.panelProfil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProfil.Location = new System.Drawing.Point(0, 50);
            this.panelProfil.Name = "panelProfil";
            this.panelProfil.Size = new System.Drawing.Size(900, 550);
            this.panelProfil.TabIndex = 0;
            // 
            // btnUploadFoto
            // 
            this.btnUploadFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnUploadFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadFoto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUploadFoto.ForeColor = System.Drawing.Color.White;
            this.btnUploadFoto.Location = new System.Drawing.Point(30, 240);
            this.btnUploadFoto.Name = "btnUploadFoto";
            this.btnUploadFoto.Size = new System.Drawing.Size(150, 30);
            this.btnUploadFoto.TabIndex = 10;
            this.btnUploadFoto.Text = "Upload Foto";
            this.btnUploadFoto.UseVisualStyleBackColor = false;
            this.btnUploadFoto.Click += new System.EventHandler(this.btnUploadFoto_Click);
            // 
            // btnCetakGaji
            // 
            this.btnCetakGaji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnCetakGaji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCetakGaji.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCetakGaji.ForeColor = System.Drawing.Color.White;
            this.btnCetakGaji.Location = new System.Drawing.Point(350, 430);
            this.btnCetakGaji.Name = "btnCetakGaji";
            this.btnCetakGaji.Size = new System.Drawing.Size(120, 35);
            this.btnCetakGaji.TabIndex = 8;
            this.btnCetakGaji.Text = "Cetak Gaji";
            this.btnCetakGaji.UseVisualStyleBackColor = false;
            this.btnCetakGaji.Click += new System.EventHandler(this.btnCetakGaji_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(490, 430);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 35);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit Profil";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // picFoto
            // 
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Location = new System.Drawing.Point(30, 80);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(150, 150);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 23);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Profil Karyawan";
            // 
            // lblNama
            // 
            this.lblNama.Location = new System.Drawing.Point(220, 90);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(100, 23);
            this.lblNama.TabIndex = 2;
            this.lblNama.Text = "Nama Lengkap";
            // 
            // lblJabatan
            // 
            this.lblJabatan.Location = new System.Drawing.Point(220, 140);
            this.lblJabatan.Name = "lblJabatan";
            this.lblJabatan.Size = new System.Drawing.Size(100, 23);
            this.lblJabatan.TabIndex = 3;
            this.lblJabatan.Text = "Jabatan";
            // 
            // lblGaji
            // 
            this.lblGaji.Location = new System.Drawing.Point(220, 190);
            this.lblGaji.Name = "lblGaji";
            this.lblGaji.Size = new System.Drawing.Size(100, 23);
            this.lblGaji.TabIndex = 4;
            this.lblGaji.Text = "Gaji Pokok";
            // 
            // lblAlamat
            // 
            this.lblAlamat.Location = new System.Drawing.Point(220, 240);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(100, 23);
            this.lblAlamat.TabIndex = 5;
            this.lblAlamat.Text = "Alamat";
            // 
            // lblNoHP
            // 
            this.lblNoHP.Location = new System.Drawing.Point(220, 320);
            this.lblNoHP.Name = "lblNoHP";
            this.lblNoHP.Size = new System.Drawing.Size(100, 23);
            this.lblNoHP.TabIndex = 6;
            this.lblNoHP.Text = "No. HP";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(220, 370);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(350, 85);
            this.txtNama.Name = "txtNama";
            this.txtNama.ReadOnly = true;
            this.txtNama.Size = new System.Drawing.Size(300, 20);
            this.txtNama.TabIndex = 8;
            // 
            // txtJabatan
            // 
            this.txtJabatan.Location = new System.Drawing.Point(350, 135);
            this.txtJabatan.Name = "txtJabatan";
            this.txtJabatan.ReadOnly = true;
            this.txtJabatan.Size = new System.Drawing.Size(300, 20);
            this.txtJabatan.TabIndex = 9;
            // 
            // txtGaji
            // 
            this.txtGaji.Location = new System.Drawing.Point(350, 185);
            this.txtGaji.Name = "txtGaji";
            this.txtGaji.ReadOnly = true;
            this.txtGaji.Size = new System.Drawing.Size(300, 20);
            this.txtGaji.TabIndex = 10;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(350, 235);
            this.txtAlamat.Multiline = true;
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.ReadOnly = true;
            this.txtAlamat.Size = new System.Drawing.Size(300, 60);
            this.txtAlamat.TabIndex = 11;
            // 
            // txtNoHP
            // 
            this.txtNoHP.Location = new System.Drawing.Point(350, 315);
            this.txtNoHP.Name = "txtNoHP";
            this.txtNoHP.ReadOnly = true;
            this.txtNoHP.Size = new System.Drawing.Size(300, 20);
            this.txtNoHP.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(350, 365);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(300, 20);
            this.txtEmail.TabIndex = 13;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // FormProfilKaryawan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelProfil);
            this.Controls.Add(this.panelTop);
            this.Name = "FormProfilKaryawan";
            this.Text = "Profil Karyawan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormProfilKaryawan_Load);
            this.panelTop.ResumeLayout(false);
            this.panelProfil.ResumeLayout(false);
            this.panelProfil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

        }
    }
}