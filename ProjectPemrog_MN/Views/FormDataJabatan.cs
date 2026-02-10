using MySql.Data.MySqlClient;
using ProjectPemrog_MN.Config;
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
    public partial class FormDataJabatan : Form
    {
        // Database connection helper
        private Config.Koneksi koneksi = new Config.Koneksi();

        public FormDataJabatan()
        {
            InitializeComponent();
            LoadJabatan();
        }

        private void LoadJabatan()
        {
            using (MySqlConnection conn = koneksi.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM jabatan";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvJabatan.DataSource = dt;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (txtNamaJabatan.Text == "" || txtGajiPokok.Text == "")
            {
                MessageBox.Show("Lengkapi data jabatan");
                return;
            }

            using (MySqlConnection conn = koneksi.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO jabatan (nama_jabatan, gaji_pokok) VALUES (@nama, @gaji)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama", txtNamaJabatan.Text);
                cmd.Parameters.AddWithValue("@gaji", txtGajiPokok.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Jabatan berhasil ditambahkan");
            txtNamaJabatan.Clear();
            txtGajiPokok.Clear();
            LoadJabatan();
        }
    }
}