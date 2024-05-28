using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

namespace New_Project
{
    public partial class View_FeedBack : System.Web.UI.Page
    {
        Concls ob = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid_bind();
            }
        }

        public void grid_bind()
        {
            string sel = "select * from Feedback_Tab where Status='pending'";
            DataSet ds = ob.fn_dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Panel1.Visible = true;
            int id = Convert.ToInt32(e.CommandArgument);
            Session["fid"] = id;
            string ab = "select t1.*,t2.* from Feedback_Tab t1 join User_Reg t2 on t1.User_Id = t2.Us_Id where F_Id=" + id + "";
            SqlDataReader dr = ob.fn_reader(ab);
            while (dr.Read())
            {
                Label2.Text = dr["Us_Name"].ToString();
                Label7.Text = dr["Us_Email"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SendEmail2("Gokul", "gokulv632@gmail.com", "gypx hxbs kfzb ylpe", "'" + Label2.Text + "'", "" + Label7.Text + "", "Feedback Replay", "'" + TextBox1.Text + "'");
            string str = "update Feedback_Tab set Replay='" + TextBox1.Text + "',Status='send' where F_Id=" + Session["fid"] + "";
            int i = ob.fn_nonquert(str);
            if (i == 1)
            {
                grid_bind();
                Panel1.Visible = false;
                
            }
        }

        public static void SendEmail2(string yourName, string yourGmailUserName, string yourGmailPassword, string toName, string toEmail, string subject, string body)
        {
            string to = toEmail; //To address    
            string from = yourGmailUserName; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = body;
            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(yourGmailUserName, yourGmailPassword);
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}