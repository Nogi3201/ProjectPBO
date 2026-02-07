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
            userLogin = username;
            LoadProfil();
            LoadDefaultFoto();
        }


        private void LoadProfil()
        {
            DataTable dt = auth.GetProfilKaryawan(userLogin);

            if (dt.Rows.Count > 0)
            {
                txtNama.Text = dt.Rows[0]["nama_lengkap"].ToString();
                txtJabatan.Text = dt.Rows[0]["nama_jabatan"].ToString();
                txtGaji.Text = Convert.ToDecimal(dt.Rows[0]["gaji_pokok"]).ToString("N0");

                // FOTO dari database (jika ada)
                if (dt.Columns.Contains("foto"))
                {
                    string fotoPath = dt.Rows[0]["foto"].ToString();
                    if (!string.IsNullOrEmpty(fotoPath) && System.IO.File.Exists(fotoPath))
                    {
                        picFoto.Image = Image.FromFile(fotoPath);
                    }
                }
            }
            else
            {
                MessageBox.Show("Data profil tidak ditemukan.");
            }
        }

        private void LoadDefaultFoto()
        {
            if (picFoto.Image == null)
            {
                picFoto.Image = Properties.Resources.default_user;
            }
        }
    }
}