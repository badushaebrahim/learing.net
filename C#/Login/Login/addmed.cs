using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class addmed : Form
    {
        int tuser;
        public addmed(int userid)
        {
            tuser = userid;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            dash ne = new dash(tuser);
            ne.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^-?[0-9,\.]+$");
            if (regex.IsMatch(textBox2.Text) && textBox2.Text != "")
            {
                String nameofmed = textBox1.Text, ptemp = textBox2.Text;

                int price = int.Parse(ptemp);
                String constring = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=badusha;Integrated Security=True";

                SqlConnection con = new SqlConnection(constring);
                //String qr = "UPDATE [dbo].[medsdetails]  SET[Nameofmed] = @nameofmed ,[Parmasisid] = @paramsid  ,[priceperunit] = @price WHERE UID =@uid ";
                String qr = "EXEC dbo.MEDDETAIL_TABLE_CRUD @ACTIONTYPE ='addnewmeds' ,@nameofmed = @nameofmed2,@paramsid=@paramsid2,@price=@price2;";
                SqlCommand cmd = new SqlCommand(qr, con);
                cmd.Parameters.AddWithValue("@nameofmed2", textBox1.Text);
                cmd.Parameters.AddWithValue("@paramsid2",tuser );
                cmd.Parameters.AddWithValue("@price2", price);

                try
                {
                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    con.Close();

                    if (i != 0)
                    {
                        MessageBox.Show("created new medecine ");
                        //Login n = new Login();
                        this.Close();
                        dash ne = new dash(tuser);
                        ne.Show();
                        //n.Show();
                    }
                }
                catch (SqlException e2)
                {
                    MessageBox.Show("Error Generated. Details: " + e2.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("invalid value in form");
            }
        }
    }
}
