using MySql.Data.MySqlClient;
using ProjectPemrog_MN.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }


        // ================= LOGIN =================
        public DataTable CekLogin(string username, string password)
        {
            DataTable dt = new DataTable();
            string hash = HashPassword(password);

            string query = @"SELECT * FROM users
                     WHERE username=@u AND password=@p";

            using (var conn = db.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", hash);
                new MySqlDataAdapter(cmd).Fill(dt);
            }

            return dt;
        }



        // ================= REGISTRASI =================
        public bool RegistrasiKaryawan(string nama, string username, string password)
        {
            string idKaryawan = BuatIDKaryawanOtomatis();
            string hash = HashPassword(password);

            MySqlTransaction tr = null;

            try
            {
                var conn = db.GetConnection();
                tr = conn.BeginTransaction();

                string q1 = @"INSERT INTO karyawan 
                             (id_karyawan, nama_lengkap, id_jabatan)
                             VALUES (@id, @nama, 2)";

                MySqlCommand c1 = new MySqlCommand(q1, conn, tr);
                c1.Parameters.AddWithValue("@id", idKaryawan);
                c1.Parameters.AddWithValue("@nama", nama);
                c1.ExecuteNonQuery();

                string q2 = @"INSERT INTO users 
                             (username, password, role, id_karyawan)
                             VALUES (@u, @p, 'Karyawan', @id)";

                MySqlCommand c2 = new MySqlCommand(q2, conn, tr);
                c2.Parameters.AddWithValue("@u", username);
                c2.Parameters.AddWithValue("@p", hash);
                c2.Parameters.AddWithValue("@id", idKaryawan);
                c2.ExecuteNonQuery();

                tr.Commit();
                return true;
            }
            catch
            {
                tr?.Rollback();
                return false;
            }
        }

        // ================= ID OTOMATIS =================
        private string BuatIDKaryawanOtomatis()
        {
            string id = "KRY001";

            string q = "SELECT id_karyawan FROM karyawan ORDER BY id_karyawan DESC LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(q, db.GetConnection());
            object r = cmd.ExecuteScalar();

            if (r != null)
            {
                int n = int.Parse(r.ToString().Substring(3)) + 1;
                id = "KRY" + n.ToString("D3");
            }

            return id;
        }

        public DataTable GetProfilKaryawan(string username)
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT k.nama_lengkap, j.nama_jabatan, j.gaji_pokok
        FROM users u
        JOIN karyawan k ON u.id_karyawan = k.id_karyawan
        JOIN jabatan j ON k.id_jabatan = j.id_jabatan
        WHERE u.username = @username
    ";

            using (var conn = db.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                new MySqlDataAdapter(cmd).Fill(dt);
            }

            return dt;
        }

        public bool SimpanRegistrasiLengkap(string nama, string username, string password)
        {
            string hash = HashPassword(password);

            using (var conn = db.GetConnection())
            {
                conn.Open();

                using (var trx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1️⃣ Insert ke tabel karyawan
                        string q1 = @"
                    INSERT INTO karyawan (id_karyawan, nama_lengkap)
                    VALUES (UUID(), @nama);
                ";

                        MySqlCommand cmd1 = new MySqlCommand(q1, conn, trx);
                        cmd1.Parameters.AddWithValue("@nama", nama);
                        cmd1.ExecuteNonQuery();

                        // 2️⃣ Ambil id_karyawan terakhir
                        string qGet = @"
                    SELECT id_karyawan 
                    FROM karyawan 
                    ORDER BY id_karyawan DESC 
                    LIMIT 1;
                ";

                        MySqlCommand cmdGet = new MySqlCommand(qGet, conn, trx);
                        string idKaryawan = cmdGet.ExecuteScalar().ToString();

                        // 3️⃣ Insert ke users
                        string q2 = @"
                    INSERT INTO users (username, password, role, id_karyawan)
                    VALUES (@username, @password, 'Karyawan', @id_karyawan);
                ";

                        MySqlCommand cmd2 = new MySqlCommand(q2, conn, trx);
                        cmd2.Parameters.AddWithValue("@username", username);
                        cmd2.Parameters.AddWithValue("@password", hash);
                        cmd2.Parameters.AddWithValue("@id_karyawan", idKaryawan);
                        cmd2.ExecuteNonQuery();

                        trx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trx.Rollback();
                        MessageBox.Show("Error registrasi: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool RegisterDanLogin(
            string nama,
            string username,
            string password,
            out string role,
            out string idKaryawan)
        {
            role = "Karyawan";
            idKaryawan = null;

            using (var conn = db.GetConnection())
            {
                conn.Open();
                using (var trx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1️⃣ Insert Karyawan
                        string q1 = @"
                    INSERT INTO karyawan (id_karyawan, nama_lengkap, id_jabatan)
                    VALUES (
                        CONCAT('KRY', LPAD(
                            (SELECT IFNULL(MAX(SUBSTRING(id_karyawan,4)),0)+1 FROM karyawan k),
                        3,'0')),
                        @nama,
                        1
                    )";

                        MySqlCommand cmd1 = new MySqlCommand(q1, conn, trx);
                        cmd1.Parameters.AddWithValue("@nama", nama);
                        cmd1.ExecuteNonQuery();

                        // 2️⃣ Ambil id_karyawan terakhir
                        string qId = "SELECT id_karyawan FROM karyawan ORDER BY id_karyawan DESC LIMIT 1";
                        MySqlCommand cmdId = new MySqlCommand(qId, conn, trx);
                        idKaryawan = cmdId.ExecuteScalar().ToString();

                        // 3️⃣ Insert Users
                        string hash = HashPassword(password);

                        string q2 = @"
                    INSERT INTO users (username, password, role, id_karyawan)
                    VALUES (@username, @password, 'Karyawan', @id_karyawan)";

                        MySqlCommand cmd2 = new MySqlCommand(q2, conn, trx);
                        cmd2.Parameters.AddWithValue("@username", username);
                        cmd2.Parameters.AddWithValue("@password", hash);
                        cmd2.Parameters.AddWithValue("@id_karyawan", idKaryawan);
                        cmd2.ExecuteNonQuery();

                        trx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    { 
                        trx.Rollback();
                        MessageBox.Show("Error registrasi: " + ex.Message);
                        return false;
                    }
                }
            }
        }


    }
}
