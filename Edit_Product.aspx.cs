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
    public partial class Edit_Product : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid_bind();
            }

        }
        public void grid_bind()
        {
            string s = "select * from Product_Table";
            DataSet ds= ob.fn_dataset(s);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Session["id"] = Convert.ToInt32(e.CommandArgument);
            Panel1.Visible = true;
            string sel = "select * from Product_Table where P_Id=" + Session["id"] + "";
            SqlDataReader dr = ob.fn_reader(sel);

            while (dr.Read())
            {
                Label2.Text = dr["P_Name"].ToString();
                TextBox1.Text = dr["P_Details"].ToString();
                TextBox2.Text = dr["P_Price"].ToString();
                TextBox3.Text = dr["P_Stock"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/Photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string up = "update Product_Table set P_Photo ='" + p + "',P_Details='" + TextBox1.Text + "',P_Price=" + TextBox2.Text + ",P_Stock=" + TextBox3.Text + " where P_Id=" + Session["id"] + " ";
            int i = ob.fn_nonquert(up);
            if (i == 1)
            {
                Label7.Visible = true; 
                Label7.Text = "edited";
                grid_bind();
            }
        }
        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        { 
            int id = Convert.ToInt32(e.CommandArgument);
            string sel = "select P_Status from Product_Table where P_Id= " + id + "";
            string se = ob.fn_scalar(sel);
            if (se == "Available")
            {
                string s = "update Product_Table set P_Status='unavailable' where P_id=" + id + "";
                int j = ob.fn_nonquert(s);
                grid_bind();
            }
            else if (se == "unavailable")
            {
                string s = "update Product_Table set P_Status='available' where P_id=" + id + "";
                int j = ob.fn_nonquert(s);
                grid_bind();

            }
        }
    }
}