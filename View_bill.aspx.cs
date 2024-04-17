using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace New_Project
{
    public partial class View_bill : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select t1.*,t2.* from Product_Table t1 join Order_Table t2 on t1.P_Id=t2.Product_Id";
            DataSet ds = ob.fn_dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();


            string st = "select * from Bill_Tab where Us_Id="+Session["id"]+"";
            SqlDataReader dr = ob.fn_reader(st);
            while (dr.Read())
            {
                Label2.Text = dr["Bill_Id"].ToString();
                Label3.Text = dr["Bill_Date"].ToString();
                Label6.Text = dr["Grand_Total"].ToString();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string st = "select * from Bill_Tab where Us_Id=" + Session["id"] + "";
            SqlDataReader dr = ob.fn_reader(st);
            Check_Bal.ServiceClient obj = new Check_Bal.ServiceClient();
            string bal = obj.balancecheck(TextBox1.Text);
            Label7.Text = bal;
        }
    }
}