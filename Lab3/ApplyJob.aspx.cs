// File: ApplyJob.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Allow students to apply jobs
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
    public partial class ApplyJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            {//dont allow anyone that isn't signed in to view the page
                if (Session["Username"] != null)
                {//make sure the person is a student
                    if (Session["Typed"].ToString() == "Student")
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

            //get the StudentID from the username of the person signed in
            { String sqlQuery = "Select StudentID From Student WHERE UserName="+"'" + Session["Username"].ToString()+"'";
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                sqlConnect.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Session["Student"] = reader["StudentID"].ToString();
                }
                sqlConnect.Close();
                
            }

            }
        protected void ApplyJobs_Click(object sender, EventArgs e)
        {
            {
                string Date = DateTime.Now.ToString("dd-MM-yyyy");
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQuery = "INSERT INTO JobApplication VALUES ('"+Date+"',@Desc,"+ Session["Student"].ToString() + "," + JobNameList.SelectedValue + ")";

                SqlCommand command = new SqlCommand(sqlQuery, sqlConnect);
                command.Parameters.AddWithValue("@Desc", HttpUtility.HtmlEncode(Description.Text.ToString()));
                try
                {
                    sqlConnect.Open();
                    command.ExecuteNonQuery();
                    Results.Text=("Success");
                }
                catch (SqlException)
                {
                    Results.Text=("Error Generated");
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