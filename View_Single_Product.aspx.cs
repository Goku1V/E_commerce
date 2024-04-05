using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace New_Project
{
    public partial class View_Single_Product : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = "select * from Product_Table where P_id=" + Session["spid"] + "";
            SqlDataReader dr = ob.fn_reader(s);

            while (dr.Read())
            {
                Label1.Text = dr["P_Name"].ToString();
                Label2.Text = dr["P_Details"].ToString();
                Label3.Text = dr["P_Price"].ToString();
                Image1.ImageUrl = dr["P_Photo"].ToString();
            }

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select max(Cart_Id) from Cart_Tab ";
            string cartid = ob.fn_scalar(s);
            int Cart_Id = 0;
            if (cartid == "")
            {
                Cart_Id = 1;
            }
            else
            {
                int newcartid = Convert.ToInt32(cartid);
                Cart_Id = newcartid + 1;
            }


            string h = "select P_price from Product_Table where P_Id=" + Session["spid"] + "";
            string price = ob.fn_scalar(h);

            int q = Convert.ToInt32(TextBox1.Text);
            int p = Convert.ToInt32(price);
            int tp = q * p;

            string ins = "insert into Cart_Tab values("+Cart_Id+",'"+TextBox1.Text+"',"+tp+",'available',"+Session["id"] + ","+Session["spid"]+")";
            int i = ob.fn_nonquert(ins);
            if (i == 1)
            {
                Label4.Visible = true;
                Label4.Text = "added to cart";


            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("User_Index.aspx");
        }
    }
}