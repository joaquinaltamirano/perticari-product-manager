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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_verProductos_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
