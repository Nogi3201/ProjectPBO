using ClosedXML.Excel;
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
        private KaryawanController kc = new KaryawanController();

        public FormDaftarKaryawan()
        {
            InitializeComponent();
        }

        // ================= LOAD DATA =================
        private void FormDaftarKaryawan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // ================= EXPORT EXCEL =================

        private void ExportToExcel()
        {
            if (dgvKaryawan.Rows.Count == 0)
            {
                MessageBox.Show("Data kosong, tidak ada yang diexport.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.Title = "Simpan File Excel";
                sfd.FileName = "Data_Karyawan.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("Karyawan");

                        // Header
                        for (int i = 0; i < dgvKaryawan.Columns.Count; i++)
                        {
                            ws.Cell(1, i + 1).Value = dgvKaryawan.Columns[i].HeaderText;
                            ws.Cell(1, i + 1).Style.Font.Bold = true;
                        }

                        // Data
                        for (int r = 0; r < dgvKaryawan.Rows.Count; r++)
                        {
                            for (int c = 0; c < dgvKaryawan.Columns.Count; c++)
                            {
                                ws.Cell(r + 2, c + 1).Value =
                                    dgvKaryawan.Rows[r].Cells[c].Value?.ToString();
                            }
                        }

                        ws.Columns().AdjustToContents();
                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Export Excel berhasil 🎉");
                }
            }   
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            try
            {
                DataTable dt = kc.GetAllKaryawan();
                dgvKaryawan.DataSource = dt;

                dgvKaryawan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvKaryawan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvKaryawan.ReadOnly = true;
                dgvKaryawan.AllowUserToAddRows = false;

                if (dgvKaryawan.Columns.Count >= 4)
                {
                    dgvKaryawan.Columns[0].HeaderText = "ID Karyawan";
                    dgvKaryawan.Columns[1].HeaderText = "Nama Lengkap";
                    dgvKaryawan.Columns[2].HeaderText = "Jabatan";
                    dgvKaryawan.Columns[3].HeaderText = "Gaji Pokok";

                    dgvKaryawan.Columns[3].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat data karyawan: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

    }
}