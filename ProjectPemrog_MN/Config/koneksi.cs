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
            var cs = ConfigurationManager.ConnectionStrings["pemrog2"];

            if (cs == null)
                throw new Exception(
                    "Connection string 'pemrog2' tidak ditemukan di App.config");

            connString = cs.ConnectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }

    }
}