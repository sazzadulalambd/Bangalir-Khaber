using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace login_reg
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public static string loginId ;
       
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(50, 0, 0, 0);

            panel2.BringToFront();

            guna2Button1.FillColor = Color.LimeGreen;
            guna2Button2.FillColor = Color.Gray;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            guna2TextBox2.UseSystemPasswordChar = true;
            pictureBox4.BringToFront();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            guna2TextBox2.UseSystemPasswordChar = true;
            pictureBox4.BringToFront();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            guna2TextBox2.UseSystemPasswordChar = false;
            pictureBox3.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();

            guna2Button1.FillColor = Color.LimeGreen;
            guna2Button2.FillColor = Color.Gray;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();

           
            guna2Button1.FillColor = Color.Gray;
            guna2Button2.FillColor = Color.LimeGreen;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            guna2TextBox3.UseSystemPasswordChar = true;
            pictureBox12.BringToFront();

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            guna2TextBox3.UseSystemPasswordChar = false;
            pictureBox14.BringToFront();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://facebook.com/");
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://google.com/");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://linkedin.com/");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://whatsapp.com/");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://facebook.com/");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://google.com/");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://linkedin.com/");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://whatsapp.com/");
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            reg_login rl = new reg_login();
            rl.Show();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            if (guna2TextBox4.Text != "" && guna2TextBox3.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from Customer_reg where mail='" + guna2TextBox4.Text + "' and PASS='" + guna2TextBox3.Text + "'";
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                
                if (ds.Tables[0].Rows.Count > 0)

                {


                    this.Hide();
                    loginId = ds.Tables[0].Rows[0]["mail"].ToString();
                    customer_acc ca = new customer_acc();
                    ca.Show();
                    MessageBox.Show("welcome to Bangalir Khaber!\n         Login Successfull", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Login Failed!\nEnter valid username and password  ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
            else if (guna2TextBox4.Text == "")
            {
                MessageBox.Show("Please enter username!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (guna2TextBox3.Text == "")
            {
                MessageBox.Show("Please enter password!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Please enter username & password!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)

        {
            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from SSSSAAAA where mail='"+ guna2TextBox1.Text+"' and PASS='"+ guna2TextBox2.Text+"'";
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                

                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.Hide();
                    loginId = ds.Tables[0].Rows[0]["mail"].ToString();
                    seller_acc sa = new seller_acc();
                    sa.Show();
                    
                    MessageBox.Show("welcome to Bangalir Khaber!\n         Login Successfull", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Login Failed!\nEnter valid username and password  ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
            else if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("Please enter username!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (guna2TextBox2.Text == "")
            {
                MessageBox.Show("Please enter password!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Please enter username & password!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            home h1 = new home();
            h1.Show();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            home h1 = new home();
            h1.Show();

        }
    }
}
