using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New_Project
{
    public partial class Add_Category : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/Photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));

            string s = "insert into Category_Tab Values('" + TextBox1.Text + "','" + p + "','" + TextBox2.Text + "','available')";
            int i = ob.fn_nonquert(s);
            if (i == 1)
            {
                Label4.Visible = true;
                Label4.Text = "Added";
            }
        }
    }
}