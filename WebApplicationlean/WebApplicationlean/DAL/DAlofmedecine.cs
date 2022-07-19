using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using WebApplicationlean.Models;

namespace WebApplicationlean.DAL
{
    public class DAlofmedecine
    {
        String constring = ConfigurationManager.ConnectionStrings["adoConnectionString"].ToString();
        //String constring = "Data Source=.\\SQLEXPRESS;Initial Catalog=badusha;Integrated Security=True";
        //get all medecines
        public List<modelofmedecine> GetMedecines()
        {
            List<modelofmedecine> medecineslist = new List<modelofmedecine>();

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "dbo.getmed";
                //cmd.CommandText = "SELECT * FROM dbo.medsdetails";
               cmd.CommandText = "dbo.MEDDETAIL_TABLE_CRUD";
               cmd.Parameters.AddWithValue("@ACTIONTYPE",  "getallmeds");
                //cmd.Parameters.AddWithValue("@ACTIONTYPE", "getallmeds");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable td = new DataTable();
                
                
                sda.Fill(td);
                con.Close();
                foreach(DataRow dr  in td.Rows)
                {
                    medecineslist.Add(new modelofmedecine
                    {
                        Nameofmed = dr["Nameofmed"].ToString(),
                        Parmasisid = Convert.ToInt32(  dr["Parmasisid"]),
                        dateandtime =dr["dateandtime"].ToString(),
                        priceperunit = Convert.ToInt32(dr["priceperunit"]),
                        UID = Convert.ToInt32(dr["UID"])


                    });
                }
            }

            return medecineslist;
        }
        //insert meds
        public  bool Insertmeds(modelofmedecine  medmodel)
        {
            int id = 0;
            using(SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.MEDDETAIL_TABLE_CRUD",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTIONTYPE", "addnewmeds");
                cmd.Parameters.AddWithValue("@nameofmed", medmodel.Nameofmed);
                cmd.Parameters.AddWithValue("@paramsid", medmodel.Parmasisid);
                cmd.Parameters.AddWithValue("@price",medmodel.priceperunit);
                id = cmd.ExecuteNonQuery();
                con.Close();
                if (id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            
        }
        //GET BY ID
        public List<modelofmedecine> GetMedecinesbyID(int Id)
        {
            List<modelofmedecine> medecineslist = new List<modelofmedecine>();

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "dbo.getmed";
                //cmd.CommandText = "SELECT * FROM dbo.medsdetails";
                cmd.CommandText = "dbo.MEDDETAIL_TABLE_CRUD";
                cmd.Parameters.AddWithValue("@ACTIONTYPE", "medbyid");
                cmd.Parameters.AddWithValue("@UID", Id);
                //cmd.Parameters.AddWithValue("@ACTIONTYPE", "getallmeds");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable td = new DataTable();


                sda.Fill(td);
                con.Close();
                foreach (DataRow dr in td.Rows)
                {
                    medecineslist.Add(new modelofmedecine
                    {
                        Nameofmed = dr["Nameofmed"].ToString(),
                        Parmasisid = Convert.ToInt32(dr["Parmasisid"]),
                        dateandtime = dr["dateandtime"].ToString(),
                        priceperunit = Convert.ToInt32(dr["priceperunit"]),
                        UID = Convert.ToInt32(dr["UID"])


                    });
                }
            }

            return medecineslist;
        }

        //update med 
       // public 
    }
}