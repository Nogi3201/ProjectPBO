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
    public partial class FormCetakData : Form
    {
        // Koneksi database helper
        private Config.Koneksi koneksi = new Config.Koneksi();

        public FormCetakData()
        {
            InitializeComponent();
            LoadDataGaji();
        }

        private void LoadDataGaji()
        {
            using (MySqlConnection conn = koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            g.id_gaji_detail,
                            k.nama_lengkap AS nama,
                            g.bulan,
                            g.tahun,
                            g.gaji_pokok,
                            g.total_lembur,
                            g.total_gaji,
                            g.tanggal_input
                        FROM gaji_detail g
                        JOIN karyawan k ON g.id_karyawan = k.id_karyawan
                        ORDER BY g.tanggal_input DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCetak.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message);
                }
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Fitur cetak dapat dikembangkan ke PDF atau Printer.\nSaat ini menampilkan data gaji.",
                "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
