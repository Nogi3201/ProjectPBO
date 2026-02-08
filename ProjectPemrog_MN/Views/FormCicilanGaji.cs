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
    public partial class FormCicilanGaji : Form
    {
        // Database connection helper
        private Config.Koneksi koneksi = new Config.Koneksi();

        public FormCicilanGaji()
        {
            InitializeComponent();
            LoadCicilan();
        }

        private void LoadCicilan()
        {
            using (MySqlConnection conn = koneksi.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM cicilan_gaji";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCicilan.DataSource = dt;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = koneksi.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO cicilan_gaji 
                              (id_karyawan, jumlah_cicilan, tanggal)
                              VALUES (@id, @jumlah, NOW())";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", txtIdKaryawan.Text);
                cmd.Parameters.AddWithValue("@jumlah", txtJumlah.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cicilan berhasil disimpan");
            LoadCicilan();
        }
    }
}
