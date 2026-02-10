using ProjectPemrog_MN.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPemrog_MN.Views
{
    public partial class FormProfilKaryawan : Form
    {
        AuthManager auth = new AuthManager();
        private string userLogin;
        private string idKaryawan;

        public FormProfilKaryawan(string username, string idKaryawan)
        {
            InitializeComponent();
            this.userLogin = username;
            this.idKaryawan = idKaryawan;
            LoadProfil();
            LoadDefaultFoto();
        }

        private void LoadProfil()
        {
            DataTable dt = auth.GetProfilKaryawan(userLogin);

            if (dt.Rows.Count > 0)
            {
                txtNama.Text = dt.Rows[0]["nama_lengkap"].ToString();
                txtJabatan.Text = dt.Rows[0]["nama_jabatan"].ToString();
                txtGaji.Text = Convert.ToDecimal(dt.Rows[0]["gaji_pokok"]).ToString("N0");
                
                // Load alamat, no_hp, email
                txtAlamat.Text = dt.Rows[0]["alamat"] == DBNull.Value ? "-" : dt.Rows[0]["alamat"].ToString();
                txtNoHP.Text = dt.Rows[0]["no_hp"] == DBNull.Value ? "-" : dt.Rows[0]["no_hp"].ToString();
                txtEmail.Text = dt.Rows[0]["email"] == DBNull.Value ? "-" : dt.Rows[0]["email"].ToString();

                // FOTO dari database (jika ada)
                if (dt.Columns.Contains("foto") && dt.Rows[0]["foto"] != DBNull.Value)
                {
                    string fotoPath = dt.Rows[0]["foto"].ToString();
                    if (!string.IsNullOrEmpty(fotoPath) && File.Exists(fotoPath))
                    {
                        try
                        {
                            picFoto.Image = Image.FromFile(fotoPath);
                        }
                        catch
                        {
                            LoadDefaultFoto();
                        }
                    }
                    else
                    {
                        LoadDefaultFoto();
                    }
                }
                else
                {
                    LoadDefaultFoto();
                }
            }
            else
            {
                MessageBox.Show("Data profil tidak ditemukan.");
            }
        }

        private void LoadDefaultFoto()
        {
            if (picFoto.Image == null)
            {
                try
                {
                    picFoto.Image = Properties.Resources.default_user;
                }
                catch
                {
                    // Jika resource tidak ada, gunakan placeholder
                    picFoto.BackColor = Color.LightGray;
                }
            }
        }

        private void FormProfilKaryawan_Load(object sender, EventArgs e)
        {
        }

        // ================= UPLOAD FOTO =================
        private void btnUploadFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Pilih Foto Profil";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Validasi ukuran file (max 5MB)
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Length > 5 * 1024 * 1024)
                    {
                        MessageBox.Show("Ukuran file terlalu besar! Maksimal 5MB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        // Buat folder foto jika belum ada
                        string photoFolder = Path.Combine(Application.StartupPath, "Photos");
                        if (!Directory.Exists(photoFolder))
                        {
                            Directory.CreateDirectory(photoFolder);
                        }

                        // Copy file ke folder aplikasi
                        string fileName = $"{idKaryawan}_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
                        string destinationPath = Path.Combine(photoFolder, fileName);

                        // Resize dan compress image
                        using (Image img = Image.FromFile(filePath))
                        {
                            using (Bitmap bmp = new Bitmap(img, new Size(300, 300)))
                            {
                                bmp.Save(destinationPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                        }

                        // Update database dengan path foto
                        KaryawanController kc = new KaryawanController();
                        bool sukses = kc.UpdateFotoKaryawan(idKaryawan, destinationPath);

                        if (sukses)
                        {
                            // Load foto baru
                            picFoto.Image = Image.FromFile(destinationPath);
                            MessageBox.Show("Foto berhasil diupload!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Gagal menyimpan foto ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error upload foto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ================= EDIT PROFIL =================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormEditProfilKaryawan editForm = new FormEditProfilKaryawan(this.idKaryawan);
            editForm.ShowDialog();
            
            // Reload data setelah form edit ditutup
            LoadProfil();
        }

        // ================= CETAK GAJI =================
        private void btnCetakGaji_Click(object sender, EventArgs e)
        {
            // Buka dialog input jam lembur
            FormInputLembur inputLembur = new FormInputLembur();
            if (inputLembur.ShowDialog() == DialogResult.OK)
            {
                // Reload data terbaru sebelum print
                LoadProfil();
                
                // Panggil method print dari controller dengan jam lembur
                KaryawanController kc = new KaryawanController();
                kc.PrintSlipGajiDetail(this.idKaryawan, inputLembur.JamLembur);
            }
        }

        // ================= LOGOUT =================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Apakah Anda yakin ingin logout?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                this.Close();
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            Font labelFont = new Font("Segoe UI", 11, FontStyle.Bold);
            Font valueFont = new Font("Segoe UI", 11);
            Brush blackBrush = Brushes.Black;

            float yPosition = 50;
            float leftMargin = 50;
            float lineHeight = 30;

            // Judul
            e.Graphics.DrawString("SLIP GAJI KARYAWAN", titleFont, blackBrush, leftMargin, yPosition);
            yPosition += lineHeight + 10;

            // Garis pemisah
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPosition, 750, yPosition);
            yPosition += lineHeight;

            // Tanggal pencetakan
            e.Graphics.DrawString($"Tanggal: {DateTime.Now:dd MMMM yyyy}", valueFont, blackBrush, leftMargin, yPosition);
            yPosition += lineHeight + 20;

            // Data Karyawan
            e.Graphics.DrawString("Data Karyawan:", labelFont, blackBrush, leftMargin, yPosition);
            yPosition += lineHeight;

            e.Graphics.DrawString("Nama Lengkap:", labelFont, blackBrush, leftMargin, yPosition);
            e.Graphics.DrawString(txtNama.Text, valueFont, blackBrush, leftMargin + 200, yPosition);
            yPosition += lineHeight;

            e.Graphics.DrawString("Jabatan:", labelFont, blackBrush, leftMargin, yPosition);
            e.Graphics.DrawString(txtJabatan.Text, valueFont, blackBrush, leftMargin + 200, yPosition);
            yPosition += lineHeight;

            e.Graphics.DrawString("Gaji Pokok:", labelFont, blackBrush, leftMargin, yPosition);
            e.Graphics.DrawString($"Rp {txtGaji.Text}", valueFont, blackBrush, leftMargin + 200, yPosition);
            yPosition += lineHeight;

            // Tambahkan info kontak
            e.Graphics.DrawString("No. HP:", labelFont, blackBrush, leftMargin, yPosition);
            e.Graphics.DrawString(txtNoHP.Text, valueFont, blackBrush, leftMargin + 200, yPosition);
            yPosition += lineHeight;

            e.Graphics.DrawString("Email:", labelFont, blackBrush, leftMargin, yPosition);
            e.Graphics.DrawString(txtEmail.Text, valueFont, blackBrush, leftMargin + 200, yPosition);
            yPosition += lineHeight + 20;

            // Garis pemisah akhir
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPosition, 750, yPosition);

            e.HasMorePages = false;
        }
    }
}