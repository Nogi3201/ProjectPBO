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
    public partial class FormLaporanGaji : Form
    {
        // Koneksi database helper
        private Config.Koneksi koneksi = new Config.Koneksi();

        public FormLaporanGaji()
        {
            InitializeComponent();
            LoadBulan();
            LoadTahun();
        }

        private void LoadBulan()
        {
            cbBulan.Items.Clear();
            cbBulan.Items.Add(new ComboItem("Januari", 1));
            cbBulan.Items.Add(new ComboItem("Februari", 2));
            cbBulan.Items.Add(new ComboItem("Maret", 3));
            cbBulan.Items.Add(new ComboItem("April", 4));
            cbBulan.Items.Add(new ComboItem("Mei", 5));
            cbBulan.Items.Add(new ComboItem("Juni", 6));
            cbBulan.Items.Add(new ComboItem("Juli", 7));
            cbBulan.Items.Add(new ComboItem("Agustus", 8));
            cbBulan.Items.Add(new ComboItem("September", 9));
            cbBulan.Items.Add(new ComboItem("Oktober", 10));
            cbBulan.Items.Add(new ComboItem("November", 11));
            cbBulan.Items.Add(new ComboItem("Desember", 12));

            cbBulan.SelectedIndex = 0;
        }

        private void LoadTahun()
        {
            int tahunSekarang = DateTime.Now.Year;
            for (int i = tahunSekarang - 5; i <= tahunSekarang + 1; i++)
            {
                cbTahun.Items.Add(i);
            }
            cbTahun.SelectedItem = tahunSekarang;
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            if (cbBulan.SelectedItem == null || cbTahun.SelectedItem == null)
            {
                MessageBox.Show("Pilih bulan dan tahun terlebih dahulu!");
                return;
            }

            int bulan = ((ComboItem)cbBulan.SelectedItem).Value;
            int tahun = Convert.ToInt32(cbTahun.SelectedItem);

            using (MySqlConnection conn = koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            k.nama_lengkap,
                            g.bulan,
                            g.tahun,
                            g.gaji_pokok,
                            g.total_lembur,
                            g.total_gaji,
                            g.tanggal_input
                        FROM gaji_detail g
                        JOIN karyawan k ON g.id_karyawan = k.id_karyawan
                        WHERE g.bulan = @bulan AND g.tahun = @tahun
                        ORDER BY k.nama_lengkap";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@bulan", bulan);
                    cmd.Parameters.AddWithValue("@tahun", tahun);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvLaporan.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("Data gaji tidak ditemukan untuk periode ini.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat laporan: " + ex.Message);
                }
            }
        }
    }

    // Helper class untuk ComboBox Bulan
    public class ComboItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}