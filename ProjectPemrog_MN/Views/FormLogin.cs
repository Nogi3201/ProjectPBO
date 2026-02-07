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
    public partial class FormLogin : Form
    {
        AuthManager auth = new AuthManager();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            DataTable result = auth.CekLogin(user, pass);

            if (result.Rows.Count > 0)
            {
                string role = result.Rows[0]["role"].ToString();
                string usernameFromDb = result.Rows[0]["username"].ToString();

                MessageBox.Show("Login Berhasil! Anda masuk sebagai " + role);

                // LOGIKA PEMISAHAN FORM BERDASARKAN ROLE
                if (role == "Admin")
                {
                    // Jika Admin, buka menu utama (Parent)
                    FormParent parent = new FormParent(role, usernameFromDb);
                    parent.Show();
                }
                else if (role == "Karyawan")
                {
                    // Jika Karyawan, langsung buka Form Profil
                    // Pastikan FormProfilKaryawan Anda sudah bisa menerima parameter username
                    FormProfilKaryawan profil = new FormProfilKaryawan(usernameFromDb);
                    profil.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau Password Salah!");
            }
        }

        private void btnRegistrasi_Click(object sender, EventArgs e)
        {
            FormRegistrasi reg = new FormRegistrasi();
            reg.Show();

            this.Hide();
        }
    }
}
