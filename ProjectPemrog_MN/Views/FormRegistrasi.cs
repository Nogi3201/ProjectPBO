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
    public partial class FormRegistrasi : Form
    {
        AuthManager auth = new AuthManager();
        public FormRegistrasi()
        {
            InitializeComponent();
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            // Validasi input tidak boleh kosong
            if (txtNamaLengkap.Text == "" || txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Mohon lengkapi semua data!");
                return;
            }

            // Panggil fungsi simpan yang melakukan double insert
            bool sukses = auth.SimpanRegistrasiLengkap(txtNamaLengkap.Text, txtUsername.Text, txtPassword.Text);

            if (sukses)
            {
                MessageBox.Show("Akun berhasil dibuat! Silahkan login.");
                new FormLogin().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Registrasi Gagal! Username mungkin sudah digunakan.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            // Balik ke Login tanpa daftar
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }
    }
}
