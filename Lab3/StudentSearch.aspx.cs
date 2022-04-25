// File: StudentSearch.aspx.cs
// Author: Madisonsoft
// Date: 3/5/2022
// Purpose: Allow member to search for students and view their info and resume
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;


namespace Lab3
{
    public partial class StudentSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//only allow people that are logged in to view the page
                if (Session["Username"] != null)
                {//only allow members to use the page
                    if (Session["Typed"].ToString() == "Leader")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Admin")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Member")
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

        protected void Search4Student_Click(object sender, EventArgs e)
        {








            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            //search in the database for a first or last name with the letter(s) inputted
            SqlCommand cmd = new SqlCommand("SELECT StudentID, FirstName, LastName, Email, PhoneNumber, UniversityYear, Major, GradYear, UserName, Files FROM Student WHERE FirstName LIKE '%' + @Serch + '%' OR LastName LIKE '%' + @Serch + '%'");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Serch", HttpUtility.HtmlEncode(Searchtxt.Text.ToString()));
            DataTable dtForGridView = new DataTable();
            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
            
                sqlAdapter.Fill(dtForGridView);
                StudentsView.DataSource = dtForGridView;
                StudentsView.DataBind();
            
            



        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }

        }
    
