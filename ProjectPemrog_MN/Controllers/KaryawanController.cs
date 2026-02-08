using MySql.Data.MySqlClient;
using ProjectPemrog_MN.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ProjectPemrog_MN.Controllers
{
    internal class KaryawanController
    {
        private Koneksi db = new Koneksi();

        // ================= GET ALL KARYAWAN (JOIN) =================
        public DataTable GetAllKaryawan()
        {
            DataTable dt = new DataTable();

            try
            {
                string query = @"SELECT 
                                    k.id_karyawan,
                                    k.nama_lengkap,
                                    j.nama_jabatan,
                                    j.gaji_pokok
                                 FROM karyawan k
                                 JOIN jabatan j 
                                   ON k.id_jabatan = j.id_jabatan
                                 ORDER BY k.id_karyawan ASC";

                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal mengambil data karyawan: " + ex.Message);
            }

            return dt;
        }

        // ================= GET KARYAWAN BY ID =================
        public DataTable GetKaryawanById(string idKaryawan)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = @"SELECT 
                                    k.id_karyawan,
                                    k.nama_lengkap,
                                    j.nama_jabatan,
                                    j.gaji_pokok,
                                    k.alamat,
                                    k.no_hp,
                                    k.email
                                 FROM karyawan k
                                 JOIN jabatan j 
                                   ON k.id_jabatan = j.id_jabatan
                                 WHERE k.id_karyawan = @id";

                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idKaryawan);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal mengambil data karyawan: " + ex.Message);
            }

            return dt;
        }

        // ================= UPDATE KARYAWAN =================
        public bool UpdateKaryawan(string idKaryawan, string alamat, string noHp, string email)
        {
            try
            {
                string query = @"UPDATE karyawan 
                               SET alamat = @alamat, 
                                   no_hp = @nohp, 
                                   email = @email 
                               WHERE id_karyawan = @id";

                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@alamat", alamat ?? "");
                        cmd.Parameters.AddWithValue("@nohp", noHp ?? "");
                        cmd.Parameters.AddWithValue("@email", email ?? "");
                        cmd.Parameters.AddWithValue("@id", idKaryawan);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal mengupdate data karyawan: " + ex.Message);
            }
        }

        // ================= UPDATE FOTO KARYAWAN =================
        public bool UpdateFotoKaryawan(string idKaryawan, string fotoPath)
        {
            try
            {
                string query = @"UPDATE karyawan 
                               SET foto = @foto 
                               WHERE id_karyawan = @id";

                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@foto", fotoPath ?? "");
                        cmd.Parameters.AddWithValue("@id", idKaryawan);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal mengupdate foto karyawan: " + ex.Message);
            }
        }

        // ================= PRINT SLIP GAJI DETAIL =================
        public void PrintSlipGajiDetail(string idKaryawan, int jamLembur)
        {
            try
            {
                DataTable dtKaryawan = GetKaryawanById(idKaryawan);

                if (dtKaryawan.Rows.Count > 0)
                {
                    string namaLengkap = dtKaryawan.Rows[0]["nama_lengkap"].ToString();
                    string jabatan = dtKaryawan.Rows[0]["nama_jabatan"].ToString();
                    decimal gajiPokok = Convert.ToDecimal(dtKaryawan.Rows[0]["gaji_pokok"]);

                    // Perhitungan gaji detail
                    decimal gajiPerHari = gajiPokok / 25; // Asumsi 25 hari kerja
                    decimal tarifLemburPerJam = gajiPerHari / 8; // Asumsi 8 jam kerja per hari
                    decimal totalLembur = jamLembur * tarifLemburPerJam;
                    decimal totalGaji = gajiPokok + totalLembur;

                    PrintDocument printDocument = new PrintDocument();
                    printDocument.PrintPage += (sender, e) =>
                    {
                        Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
                        Font labelFont = new Font("Segoe UI", 11, FontStyle.Bold);
                        Font valueFont = new Font("Segoe UI", 11);
                        Font smallFont = new Font("Segoe UI", 10);
                        Font tinyFont = new Font("Segoe UI", 9);
                        Brush blackBrush = Brushes.Black;

                        float yPosition = 50;
                        float leftMargin = 50;
                        float lineHeight = 30;

                        // Judul
                        e.Graphics.DrawString("SLIP GAJI KARYAWAN", titleFont, blackBrush, leftMargin, yPosition);
                        yPosition += lineHeight + 10;

                        // Garis pemisah
                        e.Graphics.DrawLine(Pens.Black, leftMargin, yPosition, 750, yPosition);
                        yPosition += lineHeight;

                        // Tanggal pencetakan
                        e.Graphics.DrawString($"Tanggal: {DateTime.Now:dd MMMM yyyy}", valueFont, blackBrush, leftMargin, yPosition);
                        yPosition += lineHeight + 20;

                        // Data Karyawan
                        e.Graphics.DrawString("Data Karyawan:", labelFont, blackBrush, leftMargin, yPosition);
                        yPosition += lineHeight;

                        e.Graphics.DrawString("Nama Lengkap:", labelFont, blackBrush, leftMargin, yPosition);
                        e.Graphics.DrawString(namaLengkap, valueFont, blackBrush, leftMargin + 200, yPosition);
                        yPosition += lineHeight;

                        e.Graphics.DrawString("Jabatan:", labelFont, blackBrush, leftMargin, yPosition);
                        e.Graphics.DrawString(jabatan, valueFont, blackBrush, leftMargin + 200, yPosition);
                        yPosition += lineHeight + 20;

                        // RINCIAN GAJI
                        e.Graphics.DrawString("RINCIAN GAJI:", new Font("Segoe UI", 12, FontStyle.Bold), blackBrush, leftMargin, yPosition);
                        yPosition += lineHeight + 10;

                        // Gaji Pokok
                        e.Graphics.DrawString("Gaji Pokok (25 hari):", labelFont, blackBrush, leftMargin, yPosition);
                        e.Graphics.DrawString($"Rp {gajiPokok:N0}", valueFont, blackBrush, leftMargin + 250, yPosition);
                        yPosition += lineHeight;

                        // Detail Perhitungan Lembur
                        e.Graphics.DrawString("Detail Lembur:", labelFont, blackBrush, leftMargin, yPosition);
                        yPosition += lineHeight;

                        e.Graphics.DrawString("  Jam Lembur:", smallFont, blackBrush, leftMargin + 20, yPosition);
                        e.Graphics.DrawString($"{jamLembur} jam", valueFont, blackBrush, leftMargin + 250, yPosition);
                        yPosition += lineHeight;

                        e.Graphics.DrawString("  Gaji Per Hari:", smallFont, blackBrush, leftMargin + 20, yPosition);
                        e.Graphics.DrawString($"Rp {gajiPerHari:N0} (Rp {gajiPokok:N0} ÷ 25)", tinyFont, blackBrush, leftMargin + 250, yPosition);
                        yPosition += lineHeight;

                        e.Graphics.DrawString("  Tarif/Jam:", smallFont, blackBrush, leftMargin + 20, yPosition);
                        e.Graphics.DrawString($"Rp {tarifLemburPerJam:N0} (Rp {gajiPerHari:N0} ÷ 8)", tinyFont, blackBrush, leftMargin + 250, yPosition);
                        yPosition += lineHeight;

                        e.Graphics.DrawString("  Total Lembur:", labelFont, blackBrush, leftMargin + 20, yPosition);
                        e.Graphics.DrawString($"Rp {totalLembur:N0}", valueFont, blackBrush, leftMargin + 250, yPosition);
                        yPosition += lineHeight + 10;

                        // Garis pemisah
                        e.Graphics.DrawLine(Pens.Black, leftMargin, yPosition, 750, yPosition);
                        yPosition += lineHeight;

                        // Total Gaji
                        e.Graphics.DrawString("TOTAL GAJI:", new Font("Segoe UI", 13, FontStyle.Bold), blackBrush, leftMargin, yPosition);
                        e.Graphics.DrawString($"Rp {totalGaji:N0}", new Font("Segoe UI", 13, FontStyle.Bold), blackBrush, leftMargin + 250, yPosition);
                        yPosition += lineHeight + 20;

                        // Garis pemisah akhir
                        e.Graphics.DrawLine(Pens.Black, leftMargin, yPosition, 750, yPosition);

                        e.HasMorePages = false;
                    };

                    PrintPreviewDialog printPreview = new PrintPreviewDialog();
                    printPreview.Document = printDocument;
                    printPreview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencetak slip gaji: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}