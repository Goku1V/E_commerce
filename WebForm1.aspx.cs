using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace New_Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string y = "select t1.*, t2.* from Product_Table t1 join Cart_Tab t2 on t2.Product_Id = t1.P_Id where Us_Id='" + Session["id"] + "'";
            DataSet ds = ob.fn_dataset(y);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}