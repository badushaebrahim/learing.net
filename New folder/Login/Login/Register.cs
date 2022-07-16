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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            comboBox1.Items.Add("Pharmasist");
            comboBox1.Items.Add("Accontant");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox3.Text;
            string confirm = textBox4.Text;
           // MessageBox.Show(comboBox1.SelectedIndex.ToString());
            //number regex
            Regex pattern = new Regex(@"(?<!\d)\d{10}(?!\d)");
            // MessageBox.Show(p + c);
            if (textBox1.Text == "")
            {
                MessageBox.Show("Empty  field");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Empty  field");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Empty  field");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Empty  field");
            }
            //check for email pattern
            else if(!Regex.IsMatch(textBox2.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Email notr valid ");
            }
            else if (!pattern.IsMatch(textBox5.Text))
            {
                MessageBox.Show("phone number should be 10 degits long");

            }
            else if( password != confirm)
            {
                MessageBox.Show("password missmatch");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Empty  field");
            }
            else if(comboBox1.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("No roles selected");
            }
            else if(radioButton1.Checked!= true && radioButton2.Checked !=true && radioButton3.Checked != true)
            {
                MessageBox.Show("No gender selected");
            }
            else
            {
                dateTimePicker1.CustomFormat = "yyyy-MM-dd";
                String gender = null, Role=null;
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                if (radioButton1.Checked == true)
                {
                    gender = "Male";
                }
                if (radioButton2.Checked == true)
                {
                    gender = "Female";
                }
                if (radioButton3.Checked == true)
                {
                    gender = "Other";
                }

                if(comboBox1.SelectedIndex == 0)
                {
                    Role = "Pharmasist";
                }
                else if( comboBox1.SelectedIndex == 1)
                {
                    Role = "Accontant";
                }
                    String Name, Email, Password,  phonenumber;
                Name = textBox1.Text.Trim();
                Email = textBox2.Text.Trim();
                Password = textBox3.Text.Trim();
                phonenumber = textBox5.Text.Trim();

                String DOB = dateTimePicker1.Text.ToString();
                String qr = "EXEC dbo.USER_TABLE_CRUD @Type='addNewsuser',"+ "@Name ='"+ Name+"',@DOB ='"+DOB+"',@Email='" + Email + "',@Password='" + Password + "',"+ "@PhoneNumber='" +phonenumber+"',"+"@Gender='"+gender+"',"+ "@PhotoURL='nourl',"+ "@Role='"+Role + "';";


                MessageBox.Show(qr);
                String constring = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=badusha;Integrated Security=True";

                SqlConnection con = new SqlConnection(constring);
                
                SqlCommand cmd = new SqlCommand(qr, con);
               
                try
                {
                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    con.Close();

                    if (i != 0)
                    {
                        MessageBox.Show("User Created");
                        Login n = new Login();
                        this.Hide();
                        n.Show();
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
        }

        private void textBox5_TextChanged(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("ss");
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
