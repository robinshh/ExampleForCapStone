// File: ApplyIntern.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Allow students the ability to apply for internships
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
    public partial class ApplyIntern : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//Don't allow people who aren't logged in to access page
                if (Session["Username"] != null)
                {//Only allow students to apply 
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

            { String sqlQuery = "Select StudentID From Student WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
            //get the studentID by using the username of the Student that is logged in
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


        protected void ApplyIntern_Click(object sender, EventArgs e)
        {
            {
                string Date = DateTime.Now.ToString("dd-MM-yyyy");
                //use the texts boxes and dropdown menu to insert values in the application table 
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQuery = "INSERT INTO InternshipApplication VALUES ('"+ Date+"', @Desc," + Session["Student"].ToString() + "," + InternshipNameList.SelectedValue + ")";

                SqlCommand command = new SqlCommand(sqlQuery, sqlConnect);
                command.Parameters.AddWithValue("@Desc", HttpUtility.HtmlEncode(Description.Text.ToString()));
                try
                {
                    sqlConnect.Open();
                    command.ExecuteNonQuery();
                    ResultLabel.Text=("Success");
                }
                catch (SqlException)
                {
                    ResultLabel.Text=("Error Generated");
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