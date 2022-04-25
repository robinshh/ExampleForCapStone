// File: AssignScholarship.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Show students that have applied for an Scholarship and award them with the Scholarship
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
    public partial class AssignScholarship : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//don't allow people that aren't signed in to view the page
                if (Session["Username"] != null)
                {// only allow members to view the page
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

        protected void AwardScholar_Click(object sender, EventArgs e)
        {
            {//if the scholarship hasn't been given out yet, assign it to a student
                SqlConnection sqlConnectss = new
                               SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQueryss = "INSERT INTO StudentAward VALUES (";
                sqlQueryss += StudentNameList.SelectedValue + "," + ScholarshipNameList.SelectedValue + ")";

                SqlCommand commandss = new SqlCommand(sqlQueryss, sqlConnectss);
                try
                {//tell the user if the scholarship was assigned
                    sqlConnectss.Open();
                    commandss.ExecuteNonQuery();
                    ScholarResult.Text = "Success";
                }
                catch (SqlException)
                {//tell the user if the scholarship was already assigned
                    ScholarResult.Text = "Scholarship already assigned ";
                }
                finally
                {
                    sqlConnectss.Close();
                }

               
            }

          

        }

        protected void UpdateScholarship_Click(object sender, EventArgs e)
        {//If the scholarship is already assigned, change who it is assigned to
            SqlConnection sqlConnect = new
               SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            String sqlQuery = "UPDATE StudentAward SET STUDENTID = ";
            sqlQuery += StudentNameList.SelectedValue + " WHERE ScholarshipID =" + ScholarshipNameList.SelectedValue;

            SqlCommand command = new SqlCommand(sqlQuery, sqlConnect);
            try
            {
                sqlConnect.Open();
                command.ExecuteNonQuery();
                //tell the user that the records were updated
                ScholarResult.Text = "Success";
            }
            catch (SqlException)
            {// just in case of an error
                ScholarResult.Text = "Error Occured";
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