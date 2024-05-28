using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace New_Project
{
   
    public partial class View_Products : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sel = "select * from Product_table where Cat_id = " + Session["catid"] + "";
                DataSet ds = ob.fn_dataset(sel);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }

        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            Session["spid"] = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("View_Single_Product.aspx");
        }
    }
}