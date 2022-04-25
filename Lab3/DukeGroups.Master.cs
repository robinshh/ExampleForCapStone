using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_1_
{
    public partial class DukeGroups : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                lblUserStatus.Text = "Hello " + Session["Username"].ToString();
                Logout.Visible = true;
                Login.Visible = false;
                bttnDash.Visible = true;
            }
            else
            {
                Logout.Visible = false;
                Login.Visible = true;
                bttnDash.Visible = false;
            }
        }


        protected void HomePage_Click(object sender, ImageClickEventArgs e)
        {//redirect to the homepage with the image
            Response.Redirect("homepage.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {// log out and get rid of all session variables 
            Session.Abandon();
            Response.Redirect("homepage.aspx");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }

        protected void bttnDash_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }

        protected void bttnContact_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }

        protected void bttnDonate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Donations.aspx");
        }

        protected void bttnWinner_Click(object sender, EventArgs e)
        {
            Response.Redirect("AwardWinners.aspx");
        }

        protected void bttnEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventsPage.aspx");
        }

        protected void bttnMission_Click(object sender, EventArgs e)
        {
            Response.Redirect("MissonPage.aspx");
        }

        protected void bttnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("homepage.aspx");
        }
    }
}