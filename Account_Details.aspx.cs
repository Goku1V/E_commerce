using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New_Project
{
    public partial class Account_Details : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ins = "insert into Account_Tab values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','"+ Session["id"] + "')";
            int i = ob.fn_nonquert(ins);
            if (i == 1)
            {
                Label4.Visible = true;
                Label4.Text = "Sucess";
            }
        }
    }
}