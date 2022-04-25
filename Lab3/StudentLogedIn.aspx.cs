// File: StudentLogedIn.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: allow students to edit their own data and give them the ability to go to other pages
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class StudentLogedIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {//only allow people that are logged in to use the page
            if (Session["Username"] != null)
            {//only allow students to use the page
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



            {
                String sqlQuery = "Select Files From Student WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                sqlConnect.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Session["Resume"] = reader["Files"].ToString();
                }
                sqlConnect.Close();

            }
            { 
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            //search in the database for a first or last name with the letter(s) inputted
            SqlCommand cmd = new SqlCommand("SELECT Files FROM Student WHERE Username = '" +Session["Username"].ToString()+"'");
            cmd.Connection = con;
            DataTable dtForGridView = new DataTable();
            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
            sqlAdapter.Fill(dtForGridView);
            StudentsView.DataSource = dtForGridView;
            StudentsView.DataBind();
        }
            {
                String sqlQuery = "Select StudentID From Student WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
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

            {
                try
                {
                    String sqlQuery = "SELECT Mem.FirstName+' '+Mem.LastName AS Mentor_Name FROM Member MEM, Mentor Men, Student Stu WHERE MEM.MemberID=MEN.MemberID AND Stu.StudentID=Men.StudentID AND stu.StudentID=";
                    sqlQuery += Session["Student"];
                    {
                        SqlConnection sqlConnect = new
                        SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                        DataTable dtForGridView = new DataTable();
                        sqlAdapter.Fill(dtForGridView);

                        MentorGrid.DataSource = dtForGridView;
                        MentorGrid.DataBind();
                    }
                }
                catch
                {

                }
            }
        }

        protected void ApplyIntern_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApplyIntern.aspx");
        }

        protected void ApplyJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApplyJob.aspx");
        }

        protected void ApplyScholar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApplyScholar.aspx");
        }

        protected void UploadResume_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentResumeUpload.aspx");
        }

        protected void EditInfo_Click(object sender, EventArgs e)
        {
            

            {
                String sqlFirst = "Select FirstName,LastName,Email,PhoneNumber,UniversityYear,Major,GradYear From Student WHERE UserName='" + Session["Username"].ToString() + "'";
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
                    Session["Univ"] = reader["UniversityYear"].ToString();
                    Session["Maj"] = reader["Major"].ToString();
                    Session["Grad"] = reader["GradYear"].ToString();

                }
                sqlConnected.Close();
                Response.Redirect("UserStudentEdit.aspx");
            }



        }
    }
}