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
        public dash()
        {
            InitializeComponent();
        }
       private void dashon_load(object sender , EventArgs e)
        {   //query to get details of medicine with Name of pharmasis how created it
            String qr = "select dbo.USERS.Name AS Name_of_pharamasist, dbo.medsdetails.* from dbo.medsdetails INNER JOIN dbo.USERS ON dbo.medsdetails.Parmasisid  =  dbo.USERS.ID";

            DatabaseAcces g = new DatabaseAcces(qr);
            DataTable dt = new DataTable();
            g.sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
             this.Hide();
            Login form = new Login();
            form.Show();
        }
    }
}
