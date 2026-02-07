using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPemrog_MN.Config
{
    internal class Koneksi
    {
        private readonly string connString;

        public Koneksi()
        {
            // Ambil dari App.config
            connString = ConfigurationManager.ConnectionStrings["db_pemrog2"].ConnectionString;
        }

        public MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal koneksi ke database: " + ex.Message);
            }
            return conn;
        }
    }
}