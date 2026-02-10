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
    public partial class FormProsesGaji : Form
    {
        // Koneksi database helper
        private Config.Koneksi koneksi = new Config.Koneksi();

        public FormProsesGaji()
        {
            InitializeComponent();
            LoadKaryawan();
        }

        private void LoadKaryawan()
        {
            using (MySqlConnection conn = koneksi.GetConnection())
            {
                conn.Open();
                string sql = "SELECT id_karyawan, nama_lengkap FROM karyawan";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbKaryawan.DataSource = dt;
                cbKaryawan.DisplayMember = "nama_lengkap";
                cbKaryawan.ValueMember = "id_karyawan";
                cbKaryawan.SelectedIndex = -1;
            }
        }

        private void cbKaryawan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKaryawan.SelectedValue == null) return;

            using (MySqlConnection conn = koneksi.GetConnection())
            {
                conn.Open();
                string sql = @"
                SELECT 
                    j.gaji_pokok,
                    k.jam_lembur,
                    k.tarif_lembur_perjam
                FROM karyawan k
                JOIN jabatan j ON k.id_jabatan = j.id_jabatan
                WHERE k.id_karyawan = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", cbKaryawan.SelectedValue.ToString());

                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtGajiPokok.Text = rd["gaji_pokok"].ToString();
                    txtJamLembur.Text = rd["jam_lembur"].ToString();
                    txtTarifLembur.Text = rd["tarif_lembur_perjam"].ToString();
                }
            }
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            if (cbKaryawan.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih karyawan terlebih dahulu");
                return;
            }

            int bulan = (int)numBulan.Value;
            int tahun = (int)numTahun.Value;

            decimal gajiPokok = decimal.Parse(txtGajiPokok.Text);
            int jamLembur = int.Parse(txtJamLembur.Text);
            decimal tarifLembur = decimal.Parse(txtTarifLembur.Text);

            decimal totalLembur = jamLembur * tarifLembur;
            decimal totalGaji = gajiPokok + totalLembur;

            txtTotalLembur.Text = totalLembur.ToString("N2");
            txtTotalGaji.Text = totalGaji.ToString("N2");

            using (MySqlConnection conn = koneksi.GetConnection())
            {
                conn.Open();
                string sql = @"
                INSERT INTO gaji_detail
                (id_karyawan, bulan, tahun, gaji_pokok, jam_lembur, tarif_lembur_perjam, total_lembur, total_gaji)
                VALUES
                (@id, @bulan, @tahun, @gaji, @jam, @tarif, @lembur, @total)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", cbKaryawan.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@bulan", bulan);
                cmd.Parameters.AddWithValue("@tahun", tahun);
                cmd.Parameters.AddWithValue("@gaji", gajiPokok);
                cmd.Parameters.AddWithValue("@jam", jamLembur);
                cmd.Parameters.AddWithValue("@tarif", tarifLembur);
                cmd.Parameters.AddWithValue("@lembur", totalLembur);
                cmd.Parameters.AddWithValue("@total", totalGaji);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Proses gaji berhasil disimpan");
        }
    }
}