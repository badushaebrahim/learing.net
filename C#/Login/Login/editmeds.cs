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
    public partial class editmeds : Form
    {
        String nameofmeds2;
        int UID2, paramsid2, priceperunit2;
        public editmeds(String nameofmeds,int paramsid,int priceperunit,int UID)
        {
            InitializeComponent();
            nameofmeds2 = nameofmeds;
            UID2 = UID;
            priceperunit2 = priceperunit;
            paramsid2 = paramsid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            dash ne = new dash();
            ne.Show();
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            String nameofmeds = textBox2.Text;
            Regex regex = new Regex(@"^-?[0-9][0-9,\.]+$");

            if (regex.IsMatch(textBox4.Text) && textBox2.Text != "")
            {
                String Utemp= textBox1.Text, ptemp= textBox4.Text;
                int UIDs = int.Parse(Utemp);
                int price = int.Parse(ptemp);


                // MessageBox.Show(qr);
                String constring = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=badusha;Integrated Security=True";

                SqlConnection con = new SqlConnection(constring);
                //String qr = "UPDATE [dbo].[medsdetails]  SET[Nameofmed] = @nameofmed ,[Parmasisid] = @paramsid  ,[priceperunit] = @price WHERE UID =@uid ";
                String  qr = "EXEC dbo.MEDDETAIL_TABLE_CRUD @ACTIONTYPE ='updatemeds' ,@nameofmed = @nameofmed2,@paramsid=@paramsid2,@price=@price2,  @UID = @uid;";
                SqlCommand cmd = new SqlCommand(qr, con);
                cmd.Parameters.AddWithValue("@nameofmed2", textBox2.Text);
                cmd.Parameters.AddWithValue("@paramsid2", paramsid2);
                cmd.Parameters.AddWithValue("@price2", price);

                cmd.Parameters.AddWithValue("@uid", UIDs);
                
                                try
                                {
                                    con.Open();
                                    int i = cmd.ExecuteNonQuery();

                                    con.Close();

                                    if (i != 0)
                                    {
                                        MessageBox.Show("Updated ");
                                        //Login n = new Login();
                                        this.Close();
                        dash ne = new dash();
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
            }//end 
            else
            {
                MessageBox.Show("invalid value in form");
            }
        }

        private void setdatainform(object sender, EventArgs e)
        {
            textBox1.Text = UID2.ToString();
            textBox2.Text = nameofmeds2;
            textBox4.Text = priceperunit2.ToString();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
