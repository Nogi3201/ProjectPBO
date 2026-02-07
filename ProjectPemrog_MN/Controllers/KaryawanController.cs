using MySql.Data.MySqlClient;
using ProjectPemrog_MN.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                   ON k.id_jabatan = j.id_jabatan";

                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal mengambil data karyawan: " + ex.Message);
            }

            return dt;
        }
    }
}