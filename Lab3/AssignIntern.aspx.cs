// File: AssignIntern.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Show students that have applied for an internship and award them with the internship
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class AssignIntern : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//only allow people who are signed in to view the page
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
        protected void AwardIntern_Click(object sender, EventArgs e)
        {
            {//insert new entries into the table
                SqlConnection sqlConnectss = new
                             SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQueryss = "INSERT INTO StudentIntern VALUES (";
                sqlQueryss += StudentNameList.SelectedValue + "," + InternNameList.SelectedValue + ")";

                SqlCommand commandss = new SqlCommand(sqlQueryss, sqlConnectss);
                try
                {
                    sqlConnectss.Open();
                    commandss.ExecuteNonQuery();
                    //tell the member if the create worked
                    AssignResult.Text = "Success";
                }
                catch (SqlException)
                {//if the intern or scholarship is already being used, tell the user
                    AssignResult.Text = "Intern or student already assigned ";
                }
                finally
                {
                    sqlConnectss.Close();
                }


               
            }
            
        }

        protected void changeInterns_Click(object sender, EventArgs e)
        {//allow the user to change the winner
            SqlConnection sqlConnect = new
               SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            String sqlQuery = "UPDATE StudentIntern SET STUDENTID = ";
            sqlQuery += StudentNameList.SelectedValue + " WHERE InternshipID =" + InternNameList.SelectedValue;

            SqlCommand command = new SqlCommand(sqlQuery, sqlConnect);
            try
            {
                sqlConnect.Open();
                command.ExecuteNonQuery();
                //tell the user that the winner was successfully updated
                AssignResult.Text = "Success";

            }
            catch (SqlException)
            {
                AssignResult.Text = "Cannot assign student to multiple internship";
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}