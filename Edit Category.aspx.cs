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
    public partial class Edit_Category : System.Web.UI.Page
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
            string sel = "select * from Category_Tab";
            DataSet ds = ob.fn_dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/Photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string update = "update Category_Tab set Cat_Photo='" + p + "',Cat_Desc='" + TextBox1.Text + "' where Cat_Id = " + Session["id"] + "";
            int i = ob.fn_nonquert(update);
            if (i == 1)
            {
                grid_bind();
                Label4.Text = "updated";
            }
        }
        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string sel = "select Cat_Status from Category_Tab where Cat_Id= " + id + "";
            string se = ob.fn_scalar(sel);
            if (se == "available")
            {
                string s = "update Category_Tab set Cat_Status='unavailable' where Cat_id=" + id + "";
                int j = ob.fn_nonquert(s);
                grid_bind();
            }
            else if (se == "unavailable")
            {
                string s = "update Category_Tab set Cat_Status='available' where Cat_id=" + id + "";
                int j = ob.fn_nonquert(s);
                grid_bind();
            }
        }
        protected void LinkButton3_Command(object sender, CommandEventArgs e)
        {
            Session["id"] = Convert.ToInt32(e.CommandArgument);
            Panel1.Visible = true;
            string p = "select * from Category_Tab where Cat_Id=" + Session["id"] + "";
            SqlDataReader dr = ob.fn_reader(p);
            while (dr.Read())
            {
                Label6.Text = dr["Cat_Name"].ToString();
                TextBox1.Text = dr["Cat_Desc"].ToString();
            }
        }
    }
}