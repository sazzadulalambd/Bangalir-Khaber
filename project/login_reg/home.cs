using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace login_reg
{
    public partial class home : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        
        PictureBox[] pictureBoxs = new PictureBox[50];
        Label[] labelName = new Label[50];
        Label[] labelPrice = new Label[50];

        public home()
        {
            InitializeComponent();
            
        }
        private void home_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            flowLayoutPanel1.Controls.Clear();
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "select PICTURE,NAME,PRICE,mail from Add_Product where NAME like'" + guna2TextBox14.Text + "%' order by NAME";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                long len = dr.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                dr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                PictureBox pic = new PictureBox();
                pic.Width = 180;
                pic.Height = 120;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BorderStyle = BorderStyle.FixedSingle;


                Label price = new Label();
                price.Text = dr["PRICE"].ToString()+" TK";
                price.Width = 50;
                price.BackColor = Color.FromArgb(255, 0, 0);
                price.TextAlign = ContentAlignment.MiddleCenter;
                

                Label name = new Label();
                name.Text = dr["NAME"].ToString();
                name.BackColor = Color.FromArgb(0, 191, 255);
                name.TextAlign = ContentAlignment.MiddleCenter;
                name.Dock = DockStyle.Bottom;

                MemoryStream ms = new MemoryStream(array);
                Bitmap bitmap = new Bitmap(ms);
                pic.BackgroundImage = bitmap;

                pic.Controls.Add(price);
                pic.Controls.Add(name);
                flowLayoutPanel1.Controls.Add(pic);
                pic.Cursor = Cursors.Hand;
                pic.Click += new EventHandler(OnClick);

            }
            dr.Close();
            con.Close();
        }

        public void OnClick(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

 
       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult di = MessageBox.Show("Do you want to close the Application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (di == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (di == DialogResult.No)
            {

            }

            


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox14_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
