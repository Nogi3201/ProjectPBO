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
    public partial class FormSplash : Form
    {
        public FormSplash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 2; // Kecepatan loading
            if (progressBar1.Value >= 100)
            {
                timer1.Stop();
                // Berpindah ke Form Login setelah loading selesai
                FormLogin login = new FormLogin();
                login.Show();
                this.Hide();
            }
        }
    }
}
