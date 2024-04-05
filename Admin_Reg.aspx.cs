using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New_Project
{
    public partial class Admin_Reg : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Reg_Id) from Login_Tab";
            string regid = ob.fn_scalar(sel);
            int regids = 0;
            if (regid == "")
            {
                regids = 1;
            }

            else
            {
                int newid = Convert.ToInt32(regid);
                regids = newid + 1;
            }

            string ins = "insert into Admin_Reg values(" + regids + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "'," + TextBox4.Text + ",'" + TextBox5.Text + "')";
            int i = ob.fn_nonquert(ins);
            if (i == 1)
            {
                string inslog = "insert into Login_Tab values('" + TextBox6.Text + "','" + TextBox7.Text + "','admin','active'," + regids + ")";
                int j = ob.fn_nonquert(inslog);
                if (j == 1)
                {
                    Label8.Visible = true;
                    Label8.Text = "Registered";
                }

            }
        }

        
    }
}