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
        private AuthManager auth = new AuthManager();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) 
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // ===== VALIDASI INPUT =====
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan Password wajib diisi!",
                                "Peringatan",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // ===== CEK LOGIN =====
            DataTable result = auth.CekLogin(username, password);

            if (result.Rows.Count > 0)
            {
                string role = result.Rows[0]["role"].ToString();
                string usernameDb = result.Rows[0]["username"].ToString();
                string idKaryawan = result.Rows[0]["id_karyawan"] == DBNull.Value
                    ? null
                    : result.Rows[0]["id_karyawan"].ToString();

                FormParent parent = new FormParent(
                    usernameDb,
                    role,
                    idKaryawan
                );

                parent.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "Username atau Password salah!",
                    "Login Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
