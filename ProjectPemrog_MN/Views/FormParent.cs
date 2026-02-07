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
        // Deklarasikan variabel untuk menampung data dari Login
        private string roleUser;
        private string usernameUser; // Ini yang sebelumnya menyebabkan error 'usernameString'

        // Update Constructor agar menerima role DAN username
        public FormParent(string role, string username)
        {
            InitializeComponent();
            this.roleUser = role;
            this.usernameUser = username; // Simpan username ke variabel class

            SetHakAkses();
        }

        private void SetHakAkses()
        {
            if (roleUser == "Karyawan")
            {
                masterToolStripMenuItem.Visible = false;
                laporanToolStripMenuItem.Visible = false;
            }
        }


        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cek apakah form sudah terbuka supaya tidak double
            if (Application.OpenForms["FormProfilKaryawan"] == null)
            {
                FormProfilKaryawan profil = new FormProfilKaryawan(usernameUser);
                profil.MdiParent = this; // Pastikan IsMdiContainer sudah True
                profil.WindowState = FormWindowState.Maximized;
                profil.Show();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
                new FormLogin().Show();
            }
        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDaftarKaryawan fk = new FormDaftarKaryawan();
            fk.Show();
        }
    }
}
