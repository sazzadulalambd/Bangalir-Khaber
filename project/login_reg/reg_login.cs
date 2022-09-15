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
using System.IO;

namespace login_reg
{
    public partial class reg_login : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public reg_login()
        {
            InitializeComponent();
        }

        private void reg_login_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(50, 0, 0, 0);
             panel2.BringToFront();

            guna2Button1.FillColor = Color.LimeGreen;
            guna2Button2.FillColor = Color.Gray;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();


            guna2Button1.FillColor = Color.Gray;
            guna2Button2.FillColor = Color.LimeGreen;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();


            guna2Button2.FillColor = Color.Gray;
            guna2Button1.FillColor = Color.LimeGreen;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            guna2TextBox7.UseSystemPasswordChar = false;
            pictureBox1.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            guna2TextBox7.UseSystemPasswordChar = true;
            pictureBox2.BringToFront();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            guna2TextBox2.UseSystemPasswordChar = false;
            pictureBox3.BringToFront();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            guna2TextBox2.UseSystemPasswordChar = true;
            pictureBox4.BringToFront();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            guna2TextBox8.UseSystemPasswordChar = false;
            pictureBox7.BringToFront();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            guna2TextBox8.UseSystemPasswordChar = true;
            pictureBox5.BringToFront();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            guna2TextBox9.UseSystemPasswordChar = false;
            pictureBox8.BringToFront();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            guna2TextBox9.UseSystemPasswordChar = true;
            pictureBox6.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if(guna2TextBox7.Text== guna2TextBox2.Text)
            {
                SqlConnection con1 = new SqlConnection(cs);
                string qurey1 = "INSERT into SSSSAAAA values (@Name,@mail,@Phone,@District,@Addres,@PASS)";
                SqlCommand cmd1 = new SqlCommand(qurey1, con1);
                cmd1.Parameters.AddWithValue("@Name", guna2TextBox1.Text);
                cmd1.Parameters.AddWithValue("@mail", guna2TextBox3.Text);
                cmd1.Parameters.AddWithValue("@Phone", guna2TextBox4.Text);
                cmd1.Parameters.AddWithValue("@District", guna2TextBox5.Text);
                cmd1.Parameters.AddWithValue("@Addres", guna2TextBox6.Text);
                cmd1.Parameters.AddWithValue("@PASS", guna2TextBox7.Text);
                con1.Open();
                
                int a = cmd1.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("    welcome!\nRegistation Successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 f1 = new Form1();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("Registation Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Registation Failed!\nEnter valid password or confirm password ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }





        
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2TextBox8.Text == guna2TextBox9.Text)
            {
                SqlConnection con2 = new SqlConnection(cs);
                string qurey2 = "INSERT into Customer_reg values (@Name,@mail,@Phone,@District,@Addres,@PASS)";
                SqlCommand cmd2 = new SqlCommand(qurey2, con2);
                cmd2.Parameters.AddWithValue("@Name", guna2TextBox14.Text);
                cmd2.Parameters.AddWithValue("@mail", guna2TextBox13.Text);
                cmd2.Parameters.AddWithValue("@Phone", guna2TextBox12.Text);
                cmd2.Parameters.AddWithValue("@District", guna2TextBox11.Text);
                cmd2.Parameters.AddWithValue("@Addres", guna2TextBox10.Text);
                cmd2.Parameters.AddWithValue("@PASS", guna2TextBox8.Text);
                con2.Open();
                int b = cmd2.ExecuteNonQuery();
                
                if (b > 0)
                {
                    MessageBox.Show("    welcome!\nRegistation Successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    home h = new home();
                    h.Show();
                }
                else
                {
                    MessageBox.Show("Registation Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Registation Failed!\nEnter valid password or confirm password ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
