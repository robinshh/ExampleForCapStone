// File: ApplyScholar.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Allow students to apply for scholarships
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
    public partial class ApplyScholar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//Don't allow people that aren't signed in to view the page
                if (Session["Username"] != null)
                {//Only allow students to use the page
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

            
            //find the studentID with the username of the eprson logged in
            String sqlQuery = "Select StudentID From Student WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
            {
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

        protected void ApplyScholarship_Click(object sender, EventArgs e)
        {
            {
                string Date = DateTime.Now.ToString("dd-MM-yyyy");
                //get the textboxes and drop downs to insert values into the table for scholarship applications
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQuery = "INSERT INTO ScholarshipApplication VALUES ('"+ Date +"', @Desc," + Session["Student"].ToString() + "," + ScholarshipNameList.SelectedValue + ")";

                SqlCommand command = new SqlCommand(sqlQuery, sqlConnect);
                command.Parameters.AddWithValue("@Desc", HttpUtility.HtmlEncode(Description.Text.ToString()));

                try
                {//attempt to run the query
                    sqlConnect.Open();
                    command.ExecuteNonQuery();
                    //let the user know if it worked
                    Resulted.Text=("Success");
                }
                catch (SqlException)
                {//tell the user if an error occurs
                    Resulted.Text=("Error Generated");
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