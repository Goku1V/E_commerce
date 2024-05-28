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
    public partial class View_bill : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {
                string sel = "select t1.*,t2.* from Product_Table t1 join Order_Table t2 on t1.P_Id=t2.Product_Id where Order_status='notpaid' and Us_Id="+Session["id"]+" ";
                DataSet ds = ob.fn_dataset(sel);
                GridView1.DataSource = ds;
                GridView1.DataBind();

                string st = "select * from Bill_Tab where Us_Id=" + Session["id"] + " and Bill_Status='unpayed'";
                SqlDataReader dr = ob.fn_reader(st);
                while (dr.Read())
                {
                    Label2.Text = dr["Bill_Id"].ToString();
                    Label3.Text = dr["Bill_Date"].ToString();
                    Label6.Text = dr["Grand_Total"].ToString();
                }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string st = "select Grand_Total from Bill_Tab where Us_Id=" + Session["id"] + "";
            string t = ob.fn_scalar(st);
            int gt = Convert.ToInt32(t);

            Check_Bal.ServiceClient obj = new Check_Bal.ServiceClient();
            string bal = obj.balancecheck(TextBox1.Text);
            int ba = Convert.ToInt32(bal);


            if (ba > gt)
            {


                string a = "select max(Order_Id) from Order_Table where Us_Id='" + Session["id"] + "'";
                string b = ob.fn_scalar(a);
                int count = Convert.ToInt32(b);
                if(count != 0)
                {
                    int pro_id = 0;
                    for(int ab=1; ab <= count; ab++)
                    {
                        int pro_qty = 0, cart_qty = 0, qty = 0;
                        string stup = "select t1.*,t2.* from Product_Table t1 join Order_Table t2 on t1.P_Id= t2.Product_Id where Us_Id='" + Session["id"] + "'";
                        SqlDataReader dr = ob.fn_reader(stup);
                        while (dr.Read())
                        {
                            pro_qty = Convert.ToInt32(dr["P_Stock"]);
                            cart_qty = Convert.ToInt32(dr["Cart_Quantity"]);
                            pro_id = Convert.ToInt32(dr["Product_Id"]);
                            break;
                        }
                        qty = pro_qty - cart_qty;
                        string sup="update Product_Table set P_Stock = "+qty+" where P_id="+pro_id+"";
                        int up = ob.fn_nonquert(sup);

                    }
                }

                string cup = "update Order_Table set Cart_Status='unavilable' , Order_Status='payed' where Us_Id=" + Session["id"] + "";
                int i = ob.fn_nonquert(cup);

                string bup = "update Bill_Tab set Bill_Status='payed' where  Us_Id=" + Session["id"] + " ";
                int j = ob.fn_nonquert(bup);

                string uac = "update Account_Tab set Balance_Amount=" + (ba - gt) + " where Us_Id="+Session["id"]+"";
                int k = ob.fn_nonquert(uac);

                Label7.Text = "payed";

            }
        }
    }
}