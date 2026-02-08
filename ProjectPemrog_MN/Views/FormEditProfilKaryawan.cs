using ProjectPemrog_MN.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPemrog_MN.Views
{
    public partial class FormEditProfilKaryawan : Form
    {
        private KaryawanController karyawanCtrl = new KaryawanController();
        private string idKaryawan;

        public FormEditProfilKaryawan(string idKaryawan)
        {
            InitializeComponent();
            this.idKaryawan = idKaryawan;
            LoadProfil();
        }

        private void LoadProfil()
        {
            try
            {
                DataTable dt = karyawanCtrl.GetKaryawanById(idKaryawan);

                if (dt.Rows.Count > 0)
                {
                    txtNama.Text = dt.Rows[0]["nama_lengkap"].ToString();
                    txtJabatan.Text = dt.Rows[0]["nama_jabatan"].ToString();
                    txtGaji.Text = Convert.ToDecimal(dt.Rows[0]["gaji_pokok"]).ToString("N0");
                    txtAlamat.Text = dt.Rows[0]["alamat"] == DBNull.Value ? "" : dt.Rows[0]["alamat"].ToString();
                    txtNoHP.Text = dt.Rows[0]["no_hp"] == DBNull.Value ? "" : dt.Rows[0]["no_hp"].ToString();
                    txtEmail.Text = dt.Rows[0]["email"] == DBNull.Value ? "" : dt.Rows[0]["email"].ToString();
                }
                else
                {
                    MessageBox.Show("Data karyawan tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error memuat profil: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string alamat = txtAlamat.Text;
            string noHp = txtNoHP.Text;
            string email = txtEmail.Text;

            // Validasi Email
            if (!string.IsNullOrEmpty(email))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                }
                catch
                {
                    MessageBox.Show("Format email tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Validasi No. HP (hanya angka)
            if (!string.IsNullOrEmpty(noHp) && !System.Text.RegularExpressions.Regex.IsMatch(noHp, @"^[0-9]+$"))
            {
                MessageBox.Show("No. HP hanya boleh berisi angka!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool sukses = karyawanCtrl.UpdateKaryawan(idKaryawan, alamat, noHp, email);

                if (sukses)
                {
                    MessageBox.Show("Data profil berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Gagal mengupdate data profil!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}