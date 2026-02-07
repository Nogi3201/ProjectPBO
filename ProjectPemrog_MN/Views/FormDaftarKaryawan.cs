using ProjectPemrog_MN.Controllers;
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
    public partial class FormDaftarKaryawan : Form
    {
        KaryawanController kc = new KaryawanController();

        public FormDaftarKaryawan()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = kc.GetAllKaryawan();
            dgvKaryawan.DataSource = dt;

            dgvKaryawan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Judul kolom supaya rapi
            dgvKaryawan.Columns[0].HeaderText = "ID Karyawan";
            dgvKaryawan.Columns[1].HeaderText = "Nama Lengkap";
            dgvKaryawan.Columns[2].HeaderText = "Jabatan";
            dgvKaryawan.Columns[3].HeaderText = "Gaji Pokok";

            // Format rupiah
            dgvKaryawan.Columns[3].DefaultCellStyle.Format = "N0";
        }
    }
}