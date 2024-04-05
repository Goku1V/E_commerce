using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace New_Project
{
   
        public class Concls
        {
            SqlConnection con;
            SqlCommand cmd;

            public Concls()
            {
                con = new SqlConnection(@"server=MSI\SQLEXPRESS01;database=Project;Integrated security = true");
            }

            public int fn_nonquert(string q)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                cmd = new SqlCommand(q, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }

            public string fn_scalar(string q)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd = new SqlCommand(q, con);
                con.Open();
                string s = cmd.ExecuteScalar().ToString();
                con.Close();
                return s;
            }

            public SqlDataReader fn_reader(string q)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd = new SqlCommand(q, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }

            public DataSet fn_dataset(string q)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

       }
 }
