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
    class KaryawanController
    {
        koneksi db = new koneksi();

        public DataTable GetAllKaryawan()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT 
                            k.id_karyawan,
                            k.nama_lengkap,
                            j.nama_jabatan,
                            j.gaji_pokok
                        FROM karyawan k
                        JOIN jabatan j 
                        ON k.id_jabatan = j.id_jabatan";

            MySqlCommand cmd = new MySqlCommand(query, db.GetConn());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            db.CloseConn();

            return dt;
        }
    }
}