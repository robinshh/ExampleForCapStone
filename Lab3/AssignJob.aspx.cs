// File: AssignJob.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Show students that have applied for a job and award them with the job
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
    public partial class AssignJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//only allow people that are logged in to view the page
                if (Session["Username"] != null)
                {//only allow members to use the page
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

        protected void AwardJob_Click(object sender, EventArgs e)
        {
            {//insert new entries if the job has not already been given out or the student doesn;t have a job
                SqlConnection sqlConnectss = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQueryss = "INSERT INTO StudentJob VALUES (" + StudentNamedList.SelectedValue + "," + JobNameList.SelectedValue + ")";

                SqlCommand commandss = new SqlCommand(sqlQueryss, sqlConnectss);
                try
                {
                    sqlConnectss.Open();
                    commandss.ExecuteNonQuery();
                    JobResult.Text = "Success";
                }
                catch (SqlException)
                {
                    JobResult.Text = "Record Already Exists ";
                }
                finally
                {
                    sqlConnectss.Close();
                }


               
            }

           
           
        }

        protected void ChangeJob_Click(object sender, EventArgs e)
        {//if a student or job has already been assigned, change the student 
            SqlConnection sqlConnect = new
               SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            String sqlQuery = "UPDATE StudentJob SET STUDENTID = ";
            sqlQuery += StudentNamedList.SelectedValue + " WHERE JobID =" + JobNameList.SelectedValue;

            SqlCommand command = new SqlCommand(sqlQuery, sqlConnect);
            try
            {
                sqlConnect.Open();
                command.ExecuteNonQuery();
                JobResult.Text = "Success";
            }
            catch (SqlException)
            {//make sure that someone doesn't try to give a student two jobs
                JobResult.Text = "Student can only have one Job ";
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