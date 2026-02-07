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
            string role;
            string idKaryawan;

            bool sukses = auth.RegisterDanLogin(
                txtNamaLengkap.Text,
                txtUsername.Text,
                txtPassword.Text,
                out role,
                out idKaryawan
            );

            if (sukses)
            {
                MessageBox.Show("Registrasi berhasil. Selamat datang!");

                if (role == "Admin")
                {
                    FormParent parent = new FormParent(
                        txtUsername.Text,
                        role,
                        idKaryawan
                    );
                    parent.Show();
                }
                else if (role == "Karyawan")
                {
                    FormProfilKaryawan profil = new FormProfilKaryawan(txtUsername.Text);
                    profil.Show();
                }

                this.Hide();
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
