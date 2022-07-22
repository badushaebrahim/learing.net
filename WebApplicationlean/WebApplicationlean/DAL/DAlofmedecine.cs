using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

using WebApplicationlean.Models;

namespace WebApplicationlean.DAL
{
    public class DAlofmedecine
    {
        //hasing function
        public static string hashpwd(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            Byte[] originalBytes = encoder.GetBytes(password);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            password = BitConverter.ToString(encodedBytes).Replace("-", "");
            var result = password;
            return result;
        }

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
        /// <summary>
        /// get med supply
        public List<modelofsupplyer> Getsupply()
        {
            List<modelofsupplyer> medecineslist = new List<modelofsupplyer>();

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
              cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "dbo.getmed";
               // cmd.CommandText = "SELECT * FROM dbo.supplyerid";
                cmd.CommandText = "dbo.SUPPLYERID_TABLE_CRUD";
                cmd.Parameters.AddWithValue("@TYPE", "getsupplyerfull");
                //cmd.Parameters.AddWithValue("@ACTIONTYPE", "getallmeds");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable td = new DataTable();


                sda.Fill(td);
                con.Close();
                foreach (DataRow dr in td.Rows)
                {
                    medecineslist.Add(new modelofsupplyer
                    {
                        Supplyername = dr["Supplyername"].ToString(),
                        Companyname = dr["Companyname"].ToString(),
                        SupplyerAddress = dr["SupplyerAddress"].ToString(),
                        Email = dr["Email"].ToString(),
                        Phonenumber = dr["Phonenumber"].ToString(),

                        adddate = dr["adddate"].ToString(),
                        SID = Convert.ToInt32(dr["SID"])


                    });
                }
            }

            return medecineslist;
        }
        public List<modelofsupplyer> Getsupplybyid(int id)
        {
            List<modelofsupplyer> medecineslist = new List<modelofsupplyer>();

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "dbo.getmed";
                // cmd.CommandText = "SELECT * FROM dbo.supplyerid";
                cmd.CommandText = "dbo.SUPPLYERID_TABLE_CRUD";
                cmd.Parameters.AddWithValue("@TYPE", "getsupplyerbyid");
                cmd.Parameters.AddWithValue("@SID", id);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable td = new DataTable();


                sda.Fill(td);
                con.Close();
                foreach (DataRow dr in td.Rows)
                {
                    medecineslist.Add(new modelofsupplyer
                    {
                        Supplyername = dr["Supplyername"].ToString(),
                        Companyname = dr["Companyname"].ToString(),
                        SupplyerAddress = dr["SupplyerAddress"].ToString(),
                        Email = dr["Email"].ToString(),
                        Phonenumber = dr["Phonenumber"].ToString(),

                        adddate = dr["adddate"].ToString(),
                        SID = Convert.ToInt32(dr["SID"])


                    });
                }
            }

            return medecineslist;
        }

        /// </summary>

        //insert meds
        public bool Insertmeds(modelofmedecine  medmodel)
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
        //insert model
        public bool Insertsupplyer(modelofsupplyer supmodel)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.SUPPLYERID_TABLE_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TYPE", "addsupplyer");
                cmd.Parameters.AddWithValue("@Supplyername", supmodel.Supplyername);
                cmd.Parameters.AddWithValue("@Companyname", supmodel.Companyname);
                cmd.Parameters.AddWithValue("@SupplyerAddress", supmodel.SupplyerAddress);
                cmd.Parameters.AddWithValue("@Email", supmodel.Email);
                cmd.Parameters.AddWithValue("@Phonenumber", supmodel.Phonenumber);
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
        public bool Updatesupplyer(modelofsupplyer supmodel)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.SUPPLYERID_TABLE_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TYPE", "updatesupplyerbyid");
                cmd.Parameters.AddWithValue("@Supplyername", supmodel.Supplyername);
                cmd.Parameters.AddWithValue("@Companyname", supmodel.Companyname);
                cmd.Parameters.AddWithValue("@SupplyerAddress", supmodel.SupplyerAddress);
                cmd.Parameters.AddWithValue("@Email", supmodel.Email);
                cmd.Parameters.AddWithValue("@Phonenumber", supmodel.Phonenumber);
                cmd.Parameters.AddWithValue("@SID", supmodel.SID);
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
        public bool Deletesupplyer(int SID)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.SUPPLYERID_TABLE_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TYPE", "deletesupplyerbyid");
               // cmd.Parameters.AddWithValue("@Supplyername", supmodel.Supplyername);
               // cmd.Parameters.AddWithValue("@Companyname", supmodel.Companyname);
               // cmd.Parameters.AddWithValue("@SupplyerAddress", supmodel.SupplyerAddress);
               // cmd.Parameters.AddWithValue("@Email", supmodel.Email);
               // cmd.Parameters.AddWithValue("@Phonenumber", supmodel.Phonenumber);
               // cmd.Parameters.AddWithValue("@SID", supmodel.SID);
                cmd.Parameters.AddWithValue("@SID", SID);
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
        //get supply list






        //update med 
        public bool Updatemeds(modelofmedecine medmodel)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.MEDDETAIL_TABLE_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTIONTYPE", "updatemeds");
                cmd.Parameters.AddWithValue("@nameofmed", medmodel.Nameofmed);
                cmd.Parameters.AddWithValue("@paramsid", medmodel.Parmasisid);
                cmd.Parameters.AddWithValue("@price", medmodel.priceperunit);
                cmd.Parameters.AddWithValue("@UID", medmodel.UID);
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
        //delete med
        public bool Deletemeds(int uid)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.MEDDETAIL_TABLE_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTIONTYPE", "deletemeds");
               // cmd.Parameters.AddWithValue("@nameofmed", medmodel.Nameofmed);
               // cmd.Parameters.AddWithValue("@paramsid", medmodel.Parmasisid);
               // cmd.Parameters.AddWithValue("@price", medmodel.priceperunit);
                cmd.Parameters.AddWithValue("@UID", uid);
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

        //dal to register new pharmasist
        public bool Rgisternewuer(Userregmodel1 usrmodel)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.USER_TABLE_CRUD", con);
                String pass = hashpwd(usrmodel.Password);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TYPE", "addNewsuser");
                cmd.Parameters.AddWithValue("@Name", usrmodel.Name);
                cmd.Parameters.AddWithValue("@DOB", usrmodel.DOB);
                cmd.Parameters.AddWithValue("@Email", usrmodel.Email);
                cmd.Parameters.AddWithValue("@Password", pass);
                cmd.Parameters.AddWithValue("@PhoneNumber", usrmodel.PhoneNumber);
                cmd.Parameters.AddWithValue("@Gender", usrmodel.Gender);
                cmd.Parameters.AddWithValue("@Role", "Pharmasist");

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

        public String Userlogin(userloginmodel usrmodel)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.USER_TABLE_CRUD", con);
                String pass = hashpwd(usrmodel.Password);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TYPE", "userLogin");
                // cmd.Parameters.AddWithValue("@Name", usrmodel.Name);
                // cmd.Parameters.AddWithValue("@DOB", usrmodel.DOB);
                cmd.Parameters.AddWithValue("@Email", usrmodel.Email);
                cmd.Parameters.AddWithValue("@Password", pass);
                //cmd.Parameters.AddWithValue("@PhoneNumber", usrmodel.PhoneNumber);
                //  cmd.Parameters.AddWithValue("@Gender", usrmodel.Gender);
                // cmd.Parameters.AddWithValue("@Role", "Pharmasist");

                id = cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 0)
                {
                    return "F";
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        String val = dr["ID"].ToString();
                        return val;
                    }
                }

            }
            return "F";
        }

        //get supplyer id and name





    }
}