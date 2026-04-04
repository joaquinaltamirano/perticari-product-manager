using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            parrotFlatProgressBar1.Value++;
            if (parrotFlatProgressBar1.Value == 100)
            {
                timer1.Stop();
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            }
        }
    }
}
