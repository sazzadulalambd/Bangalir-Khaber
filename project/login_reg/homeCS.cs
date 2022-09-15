using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login_reg
{
    public partial class homeCS : Form
    {
        public homeCS()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            seller_acc sa1 = new seller_acc();
            sa1.Show();
        }

        private void homeCS_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult di = MessageBox.Show("Do you want to close the Application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (di == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (di == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void homeCS_Load(object sender, EventArgs e)
        {

        }
    }
}
