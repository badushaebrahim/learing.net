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
    public partial class dash : Form
    {
        int logineduserid;
        public dash(int usrid)
        {
            logineduserid = usrid;
            InitializeComponent();
        }
       private void dashon_load(object sender , EventArgs e)
        {   //query to get details of medicine with Name of pharmasis how created it
            String qr = "select dbo.USERS.Name AS Name_of_pharamasist, dbo.medsdetails.* from dbo.medsdetails INNER JOIN dbo.USERS ON dbo.medsdetails.Parmasisid  =  dbo.USERS.ID";
            //String qr = "EXEC USER_TABLE_CRUD @Type = 'getUserallDetails'";


            DatabaseAcces g = new DatabaseAcces(qr);
            DataTable dt = new DataTable();
            g.sda.Fill(dt);
            dataGridView1.DataSource = dt;
            //Global.useri
            //MessageBox.Show(Global.userid);

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex].HeaderText == "Update")
            {
                String nameofmeds;
                int UID, paramsid, priceperunit;
                nameofmeds = (string)dataGridView1.Rows[e.RowIndex].Cells["nameofmed"].Value;
                UID = (int)dataGridView1.Rows[e.RowIndex].Cells["UID"].Value;
                paramsid = (int)dataGridView1.Rows[e.RowIndex].Cells["Parmasisid"].Value;
                priceperunit = (int)dataGridView1.Rows[e.RowIndex].Cells["priceperunit"].Value;
                editmeds em = new editmeds(nameofmeds, paramsid, priceperunit, UID,logineduserid);
                em.ShowDialog();
                this.Close();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    int gridcontentid;
                    gridcontentid = (int)dataGridView1.Rows[e.RowIndex].Cells["UID"].Value;
                   // MessageBox.Show("id" + gridcontentid);
                    String constring = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=badusha;Integrated Security=True";
                    //String qr = "DELETE FROM dbo.medsdetails WHERE UID=@Uid";
                    String qr = "EXEC dbo.MEDDETAIL_TABLE_CRUD @ACTIONTYPE ='deletemeds' ,  @UID = @UId;";

                    SqlConnection con = new SqlConnection(constring);

                    SqlCommand cmd = new SqlCommand(qr, con);
                    cmd.Parameters.AddWithValue("@UId", gridcontentid);
                    MessageBox.Show(cmd.CommandText);
                    try
                    {
                        con.Open();
                        int i = cmd.ExecuteNonQuery();

                        con.Close();

                        if (i != 0)
                        {
                            MessageBox.Show("Data Deleted");
                            // String qr2 = "select dbo.USERS.Name AS Name_of_pharamasist, dbo.medsdetails.* from dbo.medsdetails INNER JOIN dbo.USERS ON dbo.medsdetails.Parmasisid  =  dbo.USERS.ID";
                            String qr2 = "EXEC dbo.MEDDETAIL_TABLE_CRUD @ACTIONTYPE ='joinedallmeds'";
                            //String qr = "EXEC USER_TABLE_CRUD @Type = 'getUserallDetails'";


                            DatabaseAcces g = new DatabaseAcces(qr2);
                            DataTable dt = new DataTable();
                            g.sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("delete faied");
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
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
             this.Hide();
            Login form = new Login();
            form.Show();
        }

        private void addMedecineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addmed em = new addmed( logineduserid);
            em.ShowDialog();
            this.Close();
        }
    }
}
