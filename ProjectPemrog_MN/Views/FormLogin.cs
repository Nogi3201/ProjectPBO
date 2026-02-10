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
    public partial class FormLogin : Form
    {
        private AuthManager auth = new AuthManager();

        public FormLogin()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // Setup input fields dengan border
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
            // Gradient background
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

        private void pnlLoginContainer_Paint(object sender, PaintEventArgs e)
        {
            // Draw shadow effect
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            // Draw subtle border
            using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, 
                    pnlLoginContainer.Width - 1, 
                    pnlLoginContainer.Height - 1);
            }

            // Draw top accent line
            using (Pen penAccent = new Pen(Color.FromArgb(0, 102, 204), 3))
            {
                e.Graphics.DrawLine(penAccent, 0, 0, pnlLoginContainer.Width, 0);
            }

            // Draw input field borders
            DrawInputFieldBorder(e, txtUsername);
            DrawInputFieldBorder(e, txtPassword);
        }

        private void DrawInputFieldBorder(PaintEventArgs e, TextBox textBox)
        {
            // Get textbox location relative to panel
            Point location = pnlLoginContainer.PointToClient(textBox.Parent.PointToClient(textBox.Location));
            
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

                // Arahkan sesuai role
                if (role == "Admin")
                {
                    FormParent parent = new FormParent(usernameDb, role, idKaryawan);
                    parent.Show();
                }
                else if (role == "Karyawan")
                {
                    FormProfilKaryawan profil = new FormProfilKaryawan(usernameDb, idKaryawan);
                    profil.Show();
                }

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
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnRegistrasi_Click(object sender, EventArgs e)
        {
            FormRegistrasi reg = new FormRegistrasi();
            reg.Show();
            this.Hide();
        }

        private void lnkBelumPunya_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegistrasi reg = new FormRegistrasi();
            reg.Show();
            this.Hide();
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(0, 85, 170);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(0, 102, 204);
        }

        private void btnRegistrasi_MouseEnter(object sender, EventArgs e)
        {
            btnRegistrasi.BackColor = Color.FromArgb(230, 240, 250);
        }

        private void btnRegistrasi_MouseLeave(object sender, EventArgs e)
        {
            btnRegistrasi.BackColor = Color.White;
        }
    }
}
