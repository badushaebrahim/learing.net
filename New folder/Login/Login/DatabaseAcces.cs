using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public  class DatabaseAcces
    {
       public  SqlDataAdapter sda;
        SqlConnection con;
        //constructror 
        public DatabaseAcces(String qr)
        {
            String constring = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=badusha;Integrated Security=True";

           con  = new SqlConnection(constring);

            con.Open();
           sda = new SqlDataAdapter(qr, con);

        }

        /*~DatabaseAcces() {
            con.Close();
        }*/
    }
}
