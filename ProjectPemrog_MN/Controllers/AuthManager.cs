using MySql.Data.MySqlClient;
using ProjectPemrog_MN.Config;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ProjectPemrog_MN.Controllers
{
    internal class AuthManager
    {
        private Koneksi db = new Koneksi();

        // ================= HASH PASSWORD =================
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // ================= CEK LOGIN =================
        public DataTable CekLogin(string username, string password)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = @"SELECT id_user, username, role, id_karyawan
                                 FROM users
                                 WHERE username = @u AND password = @p";

                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", HashPassword(password));

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login gagal: " + ex.Message);
            }

            return dt;
        }

        // ================= REGISTRASI LENGKAP =================
        public bool RegistrasiKaryawan(string namaLengkap, string username, string password)
        {
            MySqlTransaction tr = null;

            try
            {
                MySqlConnection conn = db.GetConnection();
                tr = conn.BeginTransaction();

                // 1. Generate ID Karyawan
                string idKaryawan = BuatIDKaryawanOtomatis(conn, tr);

                // 2. Insert Karyawan
                string qKaryawan = @"INSERT INTO karyawan 
                                    (id_karyawan, nama_lengkap, id_jabatan)
                                    VALUES (@id, @nama, 2)";
                MySqlCommand cmdKry = new MySqlCommand(qKaryawan, conn, tr);
                cmdKry.Parameters.AddWithValue("@id", idKaryawan);
                cmdKry.Parameters.AddWithValue("@nama", namaLengkap);
                cmdKry.ExecuteNonQuery();

                // 3. Insert User
                string qUser = @"INSERT INTO users 
                                (username, password, role, id_karyawan)
                                VALUES (@u, @p, 'Karyawan', @id)";
                MySqlCommand cmdUser = new MySqlCommand(qUser, conn, tr);
                cmdUser.Parameters.AddWithValue("@u", username);
                cmdUser.Parameters.AddWithValue("@p", HashPassword(password));
                cmdUser.Parameters.AddWithValue("@id", idKaryawan);
                cmdUser.ExecuteNonQuery();

                tr.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (tr != null) tr.Rollback();
                MessageBox.Show("Registrasi gagal: " + ex.Message);
                return false;
            }
        }

        // ================= ID KARYAWAN OTOMATIS =================
        private string BuatIDKaryawanOtomatis(MySqlConnection conn, MySqlTransaction tr)
        {
            string idBaru = "KRY001";

            string query = "SELECT id_karyawan FROM karyawan ORDER BY id_karyawan DESC LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, conn, tr);
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                int angka = int.Parse(result.ToString().Substring(3));
                idBaru = "KRY" + (angka + 1).ToString("D3");
            }

            return idBaru;
        }
    }
}
