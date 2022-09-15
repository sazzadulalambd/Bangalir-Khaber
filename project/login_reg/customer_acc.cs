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
    public partial class customer_acc : Form
    {
        double total;
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public customer_acc()
        {
            InitializeComponent();
            panel4.BringToFront();
            //panel5.BringToFront();
           // panel4.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("01301901407 \nwww.facebook.com/bangalirkhaber", "Help| Contact with us", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panel4.Show();
            panel4.BringToFront();

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
            
        }


        void GGridVView()
        {
            SqlConnection con = new SqlConnection(cs);

            con.Open();
            String query = "select id,ProductName,Price,payment,Updat from ORDERR where Cmail='" + Form1.loginId + "'";
            SqlDataAdapter com = new SqlDataAdapter(query, con);
            DataTable DT = new DataTable();
            com.Fill(DT);
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = DT;

            con.Close();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
            GGridVView();

        }

        private void customer_acc_FormClosing(object sender, FormClosingEventArgs e)
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

        private void customer_acc_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            String query = "select * from Customer_reg where mail='" + Form1.loginId + "'";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            adp.Fill(ds);
            label1.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
            label31.Text = ds.Tables[0].Rows[0]["mail"].ToString();

            con.Open();
            GetData();
        }

        private void GetData()
        {
            flowLayoutPanel1.Controls.Clear();
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "select PICTURE,NAME,PRICE,mail,id from Add_Product where NAME like'"+ guna2TextBox14.Text +"%' order by NAME";
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
                pic.Tag = dr["id"].ToString();


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
                pic.Cursor = Cursors.Hand;

                pic.Click += new EventHandler(OnClick);

            }
            dr.Close();
            con.Close();
        }

        public void OnClick(object sender, EventArgs e)
        {
            DialogResult di = MessageBox.Show("Add to cart?", "Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (di==DialogResult.Yes) 
            {
                SqlConnection con = new SqlConnection(cs);
                string tag = ((PictureBox)sender).Tag.ToString();
                con.Open();
                String query = "select * from Add_Product where id like'" + tag + "'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    total += double.Parse(dr["PRICE"].ToString());
                    dataGridView1.Rows.Add(dataGridView1.Rows.Count, dr["NAME"].ToString(), double.Parse(dr["PRICE"].ToString()).ToString("#,##0.00") + " TK",dr["mail"].ToString());
                    label14.Text = total.ToString(("#,##0.00") + " TK");
                }
                dr.Close();
                con.Close();
            }
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            String query = "update Customer_reg set NAME ='" + textBox1.Text + "', email = '" + textBox3.Text + "', District = '" + textBox2.Text + "', Phone = '" + textBox4.Text + "', Addres = '" + textBox5.Text + "', PASS = '" + textBox6.Text + "' where mail=mail";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            int a = com.ExecuteNonQuery();
            String message = "Information Updated Successfully";
            MessageBox.Show(message);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //string se = Form1.SetValueForText1;
            SqlConnection con = new SqlConnection(cs);
            String query = "select * from Customer_reg where mail='" + Form1.loginId + "'";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            

            adp.Fill(ds);
            textBox1.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
            textBox2.Text = ds.Tables[0].Rows[0]["District"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["mail"].ToString();
            textBox4.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            textBox5.Text = ds.Tables[0].Rows[0]["Addres"].ToString();
            textBox6.Text = ds.Tables[0].Rows[0]["PASS"].ToString();
            con.Open();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="bkash")
            {
                panel6.BringToFront();
                panel6.Show();
                panel7.Hide();
                panel8.Hide();
                panel9.Hide();

            }
            else if (comboBox1.Text == "Nagad")
            {
                panel8.BringToFront();
                panel8.Show();
                panel7.Hide();
                panel6.Hide();
                panel9.Hide();

            }
            else if (comboBox1.Text == "Rocket")
            {
                panel7.BringToFront();
                panel7.Show();
                panel6.Hide();
                panel8.Hide();
                panel9.Hide();
            }
            else if (comboBox1.Text == "Card")
            {
                panel9.BringToFront();
                panel9.Show();
                panel7.Hide();
                panel8.Hide();
                panel6.Hide();
            }
            else
            {
                panel9.Hide();
                panel7.Hide();
                panel8.Hide();
                panel6.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel4.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox14_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            panel4.Hide();
            panel2.BringToFront();
        }

        private void label16_Click(object sender, EventArgs e)
        {
          
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            //comboBox1.Text= "bkash";
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            panel9.Hide();
            //comboBox1.Text = "Card";
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            panel8.Hide();
            //comboBox1.Text = "Nagad";
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            panel7.Hide();
            //comboBox1.Text = "Rocket";
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            textBox21.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox22.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox23.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            String query = "select * from Customer_reg where mail='" + Form1.loginId + "'";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();


            adp.Fill(ds);
            textBox11.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
            textBox10.Text = ds.Tables[0].Rows[0]["mail"].ToString();
            textBox9.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            textBox8.Text = ds.Tables[0].Rows[0]["Addres"].ToString();
           
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);

            string query = "insert into ORDERR values (@FullName,@Cmail,@Phone,@Addres,@payment,@Price,@ProductName,@Smail,@Updat)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FullName", textBox11.Text);
            cmd.Parameters.AddWithValue("@Cmail", textBox10.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox9.Text);
            cmd.Parameters.AddWithValue("@Addres", textBox8.Text);
            cmd.Parameters.AddWithValue("@payment", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@Price", textBox22.Text);
            cmd.Parameters.AddWithValue("@ProductName", textBox21.Text);
            cmd.Parameters.AddWithValue("@Smail", textBox23.Text);
            cmd.Parameters.AddWithValue("@Updat", textBox24.Text);

            con.Open();

            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Order place Successfully!");
                

            }
            else
            {
                MessageBox.Show("Order doesnot place Successfully!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }
        void BindGridView()
        {
            
        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox25.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            panel10.BringToFront();
            panel10.Show();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            panel10.Hide();
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            String query = "DELETE from ORDERR where id=@id";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@id",textBox25.Text);
            con.Open();
            int a = com.ExecuteNonQuery();
            String message = "Order Cancel Successfully!";
            MessageBox.Show(message);
            panel10.Hide();
            GGridVView();

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
