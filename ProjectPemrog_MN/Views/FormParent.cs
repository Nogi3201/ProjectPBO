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
    public partial class FormParent : Form
    {
        // Menyimpan data user hasil login
        private string username;
        private string role;
        private string idKaryawan;

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tidak perlu isi apa-apa
        }


        public FormParent(string username, string role, string idKaryawan)
        {
            InitializeComponent();
            this.username = username;
            this.role = role;
            this.idKaryawan = idKaryawan;
            SetHakAkses();
        }

        // ================= HAK AKSES ROLE =================
        private void SetHakAkses()
        {
            if (this.role == "Karyawan")
            {
                masterToolStripMenuItem.Visible = false;
                laporanToolStripMenuItem.Visible = false;
            }

        }

        // ================= PROFIL =================
        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FormProfilKaryawan"] == null)
            {
                FormProfilKaryawan profil = new FormProfilKaryawan(this.username);
                profil.MdiParent = this;
                profil.WindowState = FormWindowState.Maximized;
                profil.Show();
            }
            else
            {
                Application.OpenForms["FormProfilKaryawan"].Activate();
            }
        }


        // ================= DATA KARYAWAN =================
        private void dataKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FormDaftarKaryawan"] == null)
            {
                FormDaftarKaryawan fk = new FormDaftarKaryawan();
                fk.MdiParent = this;
                fk.WindowState = FormWindowState.Maximized;
                fk.Show();
            }
            else
            {
                Application.OpenForms["FormDaftarKaryawan"].Activate();
            }
        }

        // ================= LOGOUT =================
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Apakah Anda yakin ingin logout?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                this.Close();
                new FormLogin().Show();
            }
        }

        private void akunToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
