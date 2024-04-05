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
    public partial class Add_Product : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sel = "select * from Category_Tab";
                DataSet ds = ob.fn_dataset(sel);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Cat_Name";
                DropDownList1.DataValueField = "Cat_Id";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/Photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string ins = "insert into Product_Table values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + p + "'," + TextBox3.Text + "," + TextBox4.Text + ",'Available'," + DropDownList1.SelectedItem.Value + ")";
            int i = ob.fn_nonquert(ins);
            if (i == 1)
            {
                Label7.Visible = true;
                Label7.Text = "Added";
            }
        }
    }
}