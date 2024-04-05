using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New_Project
{
    public partial class Login : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select Count(Reg_Id) from Login_Tab where Username ='" + TextBox1.Text + "' and Password = '" + TextBox2.Text + "' ";
            string cid = ob.fn_scalar(str);
            if (cid == "1")
            {
                string str1 = "select Reg_Id from Login_Tab where Username ='" + TextBox1.Text + "' and Password = '" + TextBox2.Text + "' ";
                string regid = ob.fn_scalar(str1);
                Session["id"] = regid;
                string str2 = "select User_type from Login_Tab where Username ='" + TextBox1.Text + "' and Password = '" + TextBox2.Text + "' ";
                string logtype = ob.fn_scalar(str2);
                if (logtype == "admin")
                {
                    Response.Redirect("Admin_Index.aspx");
                    Label3.Visible = true;
                    Label3.Text = "admin";
                }
                else if (logtype == "user")
                {
                    Response.Redirect("User_Index.aspx");
                    Label3.Visible = true;
                    Label3.Text = "user";
                }
            }
        }
    }
}