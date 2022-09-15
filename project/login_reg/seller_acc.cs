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
    public partial class seller_acc : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public seller_acc()
        {
            InitializeComponent();
            BindGridView();
            panel1.BringToFront();

        }



        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            homesc hcs = new homesc();
            hcs.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            
            string query = "insert into Add_Product values (@name,@PICTURE,@category,@quantity,@price,@descr,@mail)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox11.Text);
            cmd.Parameters.AddWithValue("@PICTURE", SavePhoto());
            cmd.Parameters.AddWithValue("@category", textBox10.Text);
            cmd.Parameters.AddWithValue("@quantity", textBox9.Text);
            cmd.Parameters.AddWithValue("@price", textBox8.Text);
            cmd.Parameters.AddWithValue("@descr", textBox7.Text);
            cmd.Parameters.AddWithValue("@mail", Form1.loginId);
            con.Open();

            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Add Product Post Successfully!");
                panel5.Hide();
                BindGridView();
                panel4.BringToFront();

            }
            else
            {
                MessageBox.Show("Post not Add Product Successfully");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All Files *.*|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All Files *.*|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                guna2CirclePictureBox1.Image = new Bitmap(ofd.FileName);
                
            }




        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel5.Hide();
            panel4.BringToFront();
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void seller_acc_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            String query = "select * from SSSSAAAA where mail='" + Form1.loginId + "'";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            adp.Fill(ds);
            label1.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
            label24.Text = ds.Tables[0].Rows[0]["mail"].ToString();

            con.Open();

            panel1.Show();
            GetData();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT*FROM Add_Product where mail='" + Form1.loginId + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            //Image Column 
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[1];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //Table Fit
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 40;

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            panel5.Show();
            textBox16.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox15.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox14.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox13.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox12.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox17.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            pictureBox2.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[1].Value);

        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
        private void label25_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All Files *.*|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(ofd.FileName);
            }
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update Add_Product set name=@name,category=@category,quantity=@quantity,price=@price,descr=@descr  where id=@id and  mail='" + Form1.loginId + "'" ;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox16.Text);
            //cmd.Parameters.AddWithValue("@PICTURE", SavePhoto());
            cmd.Parameters.AddWithValue("@category", textBox15.Text);
            cmd.Parameters.AddWithValue("@quantity", textBox14.Text);
            cmd.Parameters.AddWithValue("@price", textBox13.Text);
            cmd.Parameters.AddWithValue("@descr", textBox12.Text);
            cmd.Parameters.AddWithValue("@id", textBox17.Text);
            con.Open();

            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Product Edit Successfully! ","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel5.Hide();
                BindGridView();
                panel4.BringToFront();
            }
            else
            {
                MessageBox.Show("Product doesnot Edit Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            textBox16.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox15.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox14.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox13.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox12.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            pictureBox2.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[1].Value);
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from Add_Product where name=@name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox16.Text);

            con.Open();

            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Delete Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
                panel5.Hide();
            }
            else
            {
                MessageBox.Show("Not Delete Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel5.Hide();

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel5.Hide();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel4.BringToFront();
        }

        private void GGridVView()
        {
            SqlConnection con = new SqlConnection(cs);

            con.Open();
            String query = "select id,FullName,Price,payment,Updat from ORDERR where Smail='" + Form1.loginId + "'";
            SqlDataAdapter com = new SqlDataAdapter(query, con);
            DataTable DT = new DataTable();
            com.Fill(DT);
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = DT;

            con.Close();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
            GGridVView();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            home h1 = new home();
            h1.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("01301901407 \nwww.facebook.com/bangalirkhaber", "Help| Contact with us", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            DialogResult di = MessageBox.Show("Do you want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (di == DialogResult.Yes)
            {
                this.Hide();
                home h1 = new home();
                h1.Show();
            }
            else if (di == DialogResult.No)
            {

            }
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panel6.BringToFront();
        }

        private void seller_acc_FormClosing(object sender, FormClosingEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            String query = "select * from SSSSAAAA where mail='"+Form1.loginId+"'";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            adp.Fill(ds);
            textBox1.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
            textBox2.Text = ds.Tables[0].Rows[0]["District"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["mail"].ToString();
            textBox4.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            textBox5.Text = ds.Tables[0].Rows[0]["Addres"].ToString();
            textBox6.Text = ds.Tables[0].Rows[0]["PASS"].ToString();
            con.Open();
            
           
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            String query = "update SSSSAAAA set NAME ='" + textBox1.Text + "', email = '" + textBox3.Text + "', District = '" + textBox2.Text + "', Phone = '" + textBox4.Text + "', Addres = '" + textBox5.Text + "', PASS = '" + textBox6.Text + "' where mail=mail";
            SqlCommand com = new SqlCommand(query, con);

            con.Open();
            int a = com.ExecuteNonQuery();
            String message = "Information Updated Successfully";
            MessageBox.Show(message);
        }


        private void GetData() 
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "select PICTURE,NAME,PRICE from Add_Product where mail='" + Form1.loginId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                long len = dr.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                dr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                PictureBox pic = new PictureBox();
                pic.Width = 130;
                pic.Height = 80;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BorderStyle = BorderStyle.FixedSingle;


                Label price = new Label();
                price.Text = dr["PRICE"].ToString() + " TK";
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
                

            }
            dr.Close();
            con.Close();
        }
       
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into SSSSAAAA values (@PICTURE) where mail='" + Form1.loginId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PICTURE", SavePhoto());
            con.Open();
            con.Close();


        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox18.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            panel9.BringToFront();
            panel9.Show();
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            String query = "update ORDERR set Updat=@Updat where id=@id and Smail='" + Form1.loginId + "'" ;
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@Updat", comboBox1.Text);
            com.Parameters.AddWithValue("@id", textBox18.Text);
            con.Open();
            int a = com.ExecuteNonQuery();
            String message = "Status Updated Successfully";
            MessageBox.Show(message);
            panel9.Hide();
            GGridVView();
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}