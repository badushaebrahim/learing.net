using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String constring = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=badusha;Integrated Security=True";

         SqlConnection con = new SqlConnection(constring);

          con.Open();

            String Email = textBox1.Text;
            String Password = textBox2.Text;

            String qr = "use badusha ;EXEC dbo.USER_TABLE_CRUD @Type='userLogin', @Email='" + Email + "',@Password='" + Password + "';";
     MessageBox.Show(qr);
            SqlDataAdapter sda = new SqlDataAdapter(qr, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("success");

            }
            else
            {
                MessageBox.Show("Please check your username and password");
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register rm = new Register();
            rm.Show();
        }
    }
}
