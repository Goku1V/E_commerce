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
    public partial class View_Cart : System.Web.UI.Page
    {
        Concls ob = new Concls();

        int cid;
        int cqu;
        int cto;
        string cst;
        int pid;
        int uid;
        int gt=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid_view();
            }
           
        }

        public void grid_view()
        {
            string y = "select t1.*, t2.* from Product_Table t1 join Cart_Tab t2 on t2.Product_Id = t1.P_Id where Us_Id=" + Session["id"] + "";
            DataSet ds = ob.fn_dataset(y);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Panel1.Visible = true;
            Session["cartid"] = Convert.ToInt32(e.CommandArgument);
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string t = "select t2.P_Price from Product_Table t2 join Cart_Tab t1 on t1.Product_Id = t2.P_Id where t1.Cart_Id='" + Session["cartid"] + "'";
            string f = ob.fn_scalar(t);
            int q = Convert.ToInt32(TextBox1.Text);
            int p = Convert.ToInt32(f);
            int t_price = q * p;
            string m = "update Cart_tab set Cart_Quantity='" + TextBox1.Text + "',Cart_Total='" + t_price + "'where Cart_Id='" + Session["cartid"] + "' ";
            int i = ob.fn_nonquert(m);
            if (i == 1)
            {
                grid_view();
                Label2.Visible = true;
                Label2.Text = "success";
            }


        }

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string del = "delete from Cart_Tab where Cart_ID="+id+"";
            int i = ob.fn_nonquert(del);
            if (i == 1)
            {
                grid_view();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string mx = "select Max(Cart_Id) from Cart_Tab ";
            string m = ob.fn_scalar(mx);
            int max = Convert.ToInt32(m);

            for (int i = 1; i <= max; i++)
            {
                string uids = "select Us_Id from cart_Tab where cart_Id=" + i + " ";
                string st = ob.fn_scalar(uids);
                int q = Convert.ToInt32(st);
                int ids = Convert.ToInt32(Session["id"]);
                if (q == ids)
                {
                    string cat = "select * from cart_Tab where cart_Id=" + i + "";
                    SqlDataReader dr = ob.fn_reader(cat);

                    while (dr.Read())
                    {
                        cid = Convert.ToInt32(dr["Cart_Id"].ToString());
                        cqu = Convert.ToInt32(dr["Cart_Quantity"].ToString());
                        cto = Convert.ToInt32(dr["Cart_Total"].ToString());
                        cst = dr["Cart_Status"].ToString();
                        pid = Convert.ToInt32(dr["Product_Id"].ToString());
                        uid = Convert.ToInt32(dr["Us_Id"].ToString());
                    }

                    gt = gt + cto;
                    string ins = "insert Into Order_Table values ('notpaid'," + cid + "," + cqu + "," + cto + ",'" + cst + "'," + uid + "," + pid + ")";
                    int j = ob.fn_nonquert(ins);

                }

                
            }
                string bin = "insert into Bill_Tab values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','unpayed'," + uid + "," + gt + ")";
                int k = ob.fn_nonquert(bin);


            //if (k != 0)
            //{
            //    string del = "truncate table Cart_Tab";
            //    int l = ob.fn_nonquert(del);
            //}



            Response.Redirect("View_bill.aspx");


            
               



            

        }
    }
}