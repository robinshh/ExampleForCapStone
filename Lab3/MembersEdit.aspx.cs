// File: MembersEdit.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Allow members to change and add members
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
    public partial class MembersEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {// don't allow non users to view the page
                if (Session["Username"] != null)
                {//only allow members to view the page
                    if (Session["Typed"].ToString() == "Leader")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Admin")
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString()))
                {




                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sc;
                    cmd.CommandText = "UPDATE Member SET FirstName=@FName,LastName=@LName,Email=@EMAIL,PhoneNumber=@PhoneNum,Title=@Title,GradYear=@Grad WHERE MemberID ='" + MentorNameList.SelectedValue + "'";

                    cmd.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                    cmd.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtLastName.Text)));
                    cmd.Parameters.Add(new SqlParameter("@EMAIL", HttpUtility.HtmlEncode(txtEmail.Text)));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNum", HttpUtility.HtmlEncode(txtPhone.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Title", HttpUtility.HtmlEncode(txtTitle.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Grad", HttpUtility.HtmlEncode(txtGradYear.Text)));


                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();



                    
                    lblStatus.Text = "Successful";
                }
            }
            catch
            {
                lblStatus.Text = "Error Occured";
            }

        }

        protected void bttnShowInfo_Click(object sender, EventArgs e)
        {
            {
                String sqlFirst = "Select FirstName,LastName,Email,PhoneNumber,GradYear,Title From Member WHERE MemberID='" + MentorNameList.SelectedValue + "'";
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
            }
            {
                String firsted = Session["First"].ToString();
                txtFirstName.Text = firsted;
                String Lasted = Session["Lasts"].ToString();
                txtLastName.Text = Lasted;
                String Emailed = Session["email"].ToString();
                txtEmail.Text = Emailed;
                String Phoned = Session["Phone"].ToString();
                txtPhone.Text = Phoned;
                String Titled = Session["TITLE"].ToString();
                txtTitle.Text = Titled;
                String Graded = Session["Grad"].ToString();
                txtGradYear.Text = Graded;
            }
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}