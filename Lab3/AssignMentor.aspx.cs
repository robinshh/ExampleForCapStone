using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;

namespace Lab3
{
    public partial class AssignMentor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//don't allow people that aren't logged in to view the page
                if (Session["Username"] != null)
                {//only allow members to view the page
                    if (Session["Typed"].ToString() == "Member")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Admin")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Leader")
                    {

                    }
                    else
                    {
                        Response.Redirect("homepage.aspx");
                    }
                }
                else
                {
                    Response.Redirect("homepage.aspx");
                }
            }
        }

        protected void AssignMentor_Click(object sender, EventArgs e)
        {
            {//assign members as mentors to students
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQuery = "INSERT INTO Mentor VALUES (";
                sqlQuery += MentorNameList.SelectedValue + "," + MentorNameList.SelectedValue + "," + StudentNameList.SelectedValue + ")";

                SqlCommand command = new SqlCommand(sqlQuery, sqlConnect);
                try
                {
                    sqlConnect.Open();
                    command.ExecuteNonQuery();
                    MentorResult.Text="Success";
                }
                catch (SqlException)
                {//Student can only have one mentor
                    MentorResult.Text="Student Already Assigned to Mentor";
                }
                finally
                {
                    sqlConnect.Close();
                }

            }
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}