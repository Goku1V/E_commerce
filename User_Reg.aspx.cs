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
    public partial class User_Reg : System.Web.UI.Page
    {

        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string st = "select * from State_Tab";
                DataSet ds = ob.fn_dataset(st);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "State_Name";
                DropDownList1.DataValueField = "State_Id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "--select--");
            }
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

            string ins = "insert into User_Reg values(" + regids + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "'," + TextBox4.Text + ",'" + TextBox5.Text + "','" + TextBox8.Text + "','" + DropDownList1.SelectedItem.Value + "','" + DropDownList2.SelectedItem.Value + "','" + TextBox9.Text + "','active')";
            int i = ob.fn_nonquert(ins);
            if (i == 1)
            {
                string inslog = "insert into Login_Tab values('" + TextBox6.Text + "','" + TextBox7.Text + "','user','active'," + regids + ")";
                int j = ob.fn_nonquert(inslog);
                if (j == 1)
                {
                    Label8.Visible = true;
                    Label8.Text = "Registered";
                }
            } 
        }
        protected void DropDownList1_TextChanged1(object sender, EventArgs e)
        {
            string dt = "select * from Dist_Tab where State_Id=" + DropDownList1.SelectedItem.Value + "";
            DataSet ds1 = ob.fn_dataset(dt);
            DropDownList2.DataSource = ds1;
            DropDownList2.DataTextField = "Dist_Name";
            DropDownList2.DataValueField = "Dist_Id";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "--select--");
        }
    }
}