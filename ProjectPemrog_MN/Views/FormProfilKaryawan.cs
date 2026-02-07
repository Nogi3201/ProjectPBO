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
    public partial class FormProfilKaryawan : Form
    {
        AuthManager auth = new AuthManager();
        private string userLogin;
        public FormProfilKaryawan(string username)
        {
            InitializeComponent();
            this.userLogin = username;
            TampilkanData();
        }
        private void TampilkanData()
        {
            DataTable dt = auth.GetProfilKaryawan(userLogin);
            if (dt.Rows.Count > 0)
            {
                // Mengambil kolom dari hasil JOIN di atas
                txtNama.Text = dt.Rows[0]["nama_lengkap"].ToString();
                txtJabatan.Text = dt.Rows[0]["nama_jabatan"].ToString();
                txtGaji.Text = dt.Rows[0]["gaji_pokok"].ToString();
            }
            else
            {
                MessageBox.Show("Data profil tidak ditemukan. Hubungkan id_karyawan di database!");
            }
        }
    }
}