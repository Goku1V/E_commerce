using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New_Project
{
    public partial class Feedback : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ins = "insert into Feedback_Tab values(" + Session["Id"] + ",'"+TextBox1.Text+"','waiting','pending')";
            int i = ob.fn_nonquert(ins);
            if (i == 1)
            {
                Label2.Visible = true;
                Label2.Text = "Sucess";
            }
        }
    }
}