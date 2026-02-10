using ProjectPemrog_MN.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPemrog_MN.Views
{
    public partial class FormRegistrasi : Form
    {
        private AuthManager auth = new AuthManager();

        public FormRegistrasi()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // Setup input fields dengan border
            DrawBorderUnderInputField(txtNamaLengkap);
            DrawBorderUnderInputField(txtUsername);
            DrawBorderUnderInputField(txtPassword);
            
            // Setup form styling
            this.BackColor = Color.White;
        }

        private void DrawBorderUnderInputField(TextBox textBox)
        {
            textBox.Leave += (s, e) => textBox.Invalidate();
            textBox.Enter += (s, e) => textBox.Invalidate();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            // Gradient background - sama seperti FormLogin
            Color color1 = Color.FromArgb(240, 248, 255); // Alice Blue
            Color color2 = Color.FromArgb(230, 240, 250); // Light Blue
            
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.pnlMain.ClientRectangle,
                color1,
                color2,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.pnlMain.ClientRectangle);
            }
        }

        private void pnlRegisterContainer_Paint(object sender, PaintEventArgs e)
        {
            // Draw shadow effect
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            // Draw subtle border
            using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, 
                    pnlRegisterContainer.Width - 1, 
                    pnlRegisterContainer.Height - 1);
            }

            // Draw top accent line
            using (Pen penAccent = new Pen(Color.FromArgb(0, 102, 204), 3))
            {
                e.Graphics.DrawLine(penAccent, 0, 0, pnlRegisterContainer.Width, 0);
            }

            // Draw input field borders
            DrawInputFieldBorder(e, txtNamaLengkap);
            DrawInputFieldBorder(e, txtUsername);
            DrawInputFieldBorder(e, txtPassword);
        }

        private void DrawInputFieldBorder(PaintEventArgs e, TextBox textBox)
        {
            // Draw bottom border
            Color borderColor = textBox.Focused 
                ? Color.FromArgb(0, 102, 204) 
                : Color.FromArgb(200, 200, 200);
            
            int thickness = textBox.Focused ? 2 : 1;
            
            using (Pen pen = new Pen(borderColor, thickness))
            {
                int y = textBox.Location.Y + textBox.Height + 3;
                e.Graphics.DrawLine(pen, 
                    textBox.Location.X, y, 
                    textBox.Location.X + textBox.Width, y);
            }
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            string role;
            string idKaryawan;

            // ===== VALIDASI INPUT =====
            if (string.IsNullOrEmpty(txtNamaLengkap.Text.Trim()) || 
                string.IsNullOrEmpty(txtUsername.Text.Trim()) || 
                string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Semua field harus diisi!",
                                "Peringatan",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // ===== VALIDASI PANJANG PASSWORD =====
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password minimal harus 6 karakter!",
                                "Peringatan",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            bool sukses = auth.RegisterDanLogin(
                txtNamaLengkap.Text.Trim(),
                txtUsername.Text.Trim(),
                txtPassword.Text,
                out role,
                out idKaryawan
            );

            if (sukses)
            {
                MessageBox.Show("Registrasi berhasil! Selamat datang!",
                                "Sukses",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Kirim username dan idKaryawan ke FormProfilKaryawan
                FormProfilKaryawan profil = new FormProfilKaryawan(txtUsername.Text.Trim(), idKaryawan);
                profil.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Registrasi gagal. Username mungkin sudah digunakan atau ada kesalahan lain. Silakan coba lagi.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }

        private void lnkSudahPunya_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }

        private void btnDaftar_MouseEnter(object sender, EventArgs e)
        {
            btnDaftar.BackColor = Color.FromArgb(0, 85, 170);
        }

        private void btnDaftar_MouseLeave(object sender, EventArgs e)
        {
            btnDaftar.BackColor = Color.FromArgb(0, 102, 204);
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(230, 240, 250);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.White;
        }
    }
}
