// File: MemberLogedIn.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Allow the member to adjust their own info and get to other features
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
using System.Security.Cryptography;


namespace Lab3
{
    public partial class MemberLogedIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                        
            
            // don't allow people that aren't signed in to view the page
            
            if (Session["Username"] != null)
            {//only allow members to view the page
                if (Session["Typed"].ToString() == "Member")
                {

                }
                else if (Session["Typed"].ToString() == "Admin") {
                    Response.Redirect("AdminOverview.aspx");
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
            {
                String sqlQuery = "Select MemberID From Member WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
                //get the studentID by using the username of the Student that is logged in
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                sqlConnect.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Session["Member"] = reader["MemberID"].ToString();
                }
                sqlConnect.Close();

            }

            {
                try
                {
                    String sqlQuery = "SELECT Stu.FirstName+' '+Stu.LastName AS Student_Name FROM Member MEM, Mentor Men, Student Stu WHERE MEM.MemberID=MEN.MemberID AND Stu.StudentID=Men.StudentID AND MEM.MemberID=";
                    sqlQuery += Session["Member"];
                    {
                        SqlConnection sqlConnect = new
                        SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                        DataTable dtForGridView = new DataTable();
                        sqlAdapter.Fill(dtForGridView);

                        StudentGrid.DataSource = dtForGridView;
                        StudentGrid.DataBind();
                    }
                }
                catch
                {

                }
            }


        }

        protected void EditMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("MembersEdit.aspx");
        }

        protected void EditStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentEdit.aspx");
        }

        protected void EditScholarship_Click(object sender, EventArgs e)
        {
            Response.Redirect("Scholarship.aspx");
        }

        protected void EditJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("Job.aspx");
        }

        protected void EditInternship_Click(object sender, EventArgs e)
        {
            Response.Redirect("Internship.aspx");
        }

        protected void AssignMentor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssignMentor.aspx");
        }

        protected void AssignScholarship_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssignScholarship.aspx");
        }

        protected void AssignJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssignJob.aspx");
        }

        protected void AssignInternship_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssignIntern.aspx");
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSearch.aspx");
        }

        protected void MentorInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("MentorOverview.aspx");
        }

        protected void CompanyInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyOverview.aspx");
        }

        protected void MemberOverview_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberOverview.aspx");
        }

        protected void EditMemberUser_Click(object sender, EventArgs e)
        {
            {
                String sqlFirst = "Select FirstName,LastName,Email,PhoneNumber,GradYear,Title From Member WHERE UserName='" + Session["Username"].ToString() + "'";
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlFirst, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Session["First"] = reader["FirstName"].ToString();
                    Session["Lasts"] = reader["LastName"].ToString();
                    Session["email"] = reader["Email"].ToString();
                    Session["Phone"] = reader["PhoneNumber"].ToString();
                    Session["Grad"] = reader["GradYear"].ToString();
                    Session["TITLE"] = reader["Title"].ToString();

                }
                sqlConnected.Close();
                Response.Redirect("UserMemberEdit.aspx");
            }
        }
    }
}