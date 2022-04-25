// File: StudentLogIn.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Allow students to log in
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

namespace Lab3
{
    public partial class StudentLogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {//make sure the person is signed int
            if (Session["Username"] != null)
            {//if the student is already signed in, take them to the logged in page
                if (Session["Typed"].ToString() == "Student")
                {
                    Response.Redirect("StudentLogedIn.aspx");
                }
                else if (Session["Typed"].ToString() == "Member") {
                    Response.Redirect("MemberLogedIn.aspx");
                }
                else if (Session["Typed"].ToString() == "Admin")
                {
                    Response.Redirect("AdminOverview.aspx");
                }
                else if (Session["Typed"].ToString() == "Leader")
                {
                    Response.Redirect("LeaderLogedIn.aspx");
                }
                else
                {
                    Response.Redirect("homepage.aspx");
                }
            }
            else
            {
               
            }
          }
        
            protected void btnStudentLogin_Click(object sender, EventArgs e)
            {// test the entered values to see if they exist
            //try
            {
                System.Data.SqlClient.SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
                SqlCommand loginCommand = new SqlCommand();
                loginCommand.Connection = sc;
                loginCommand.CommandType = CommandType.StoredProcedure;
                loginCommand.CommandText = "Userlogin";
                loginCommand.Parameters.AddWithValue("@UserName", txtUsername.Text.ToString());
                loginCommand.Parameters.AddWithValue("@PassWord", txtPassword.Text.ToString());
                sc.Open();
               
                SqlDataReader reader = loginCommand.ExecuteReader(); // create a reader

                if (reader.HasRows) // if the username exists, it will continue
                {
                    while (reader.Read()) // this will read the single record that matches the entered username
                    {
                        string storedHash = reader["Passwords"].ToString(); // store the database password into this variable

                        if (PasswordHash.ValidatePassword(txtPassword.Text, storedHash)) // if the entered password matches what is stored, it will show success
                        {


                            sc.Close();
                            Session["Username"] = txtUsername.Text;



                            {
                                String sqlQuerys = "Select Type From Member WHERE UserName=" + "'" + txtUsername.Text.ToString() + "'";
                                SqlConnection sqlConnects = new
                                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                                SqlCommand sqlCommands = new SqlCommand(sqlQuerys, sqlConnects);
                                sqlConnects.Open();
                                SqlDataReader readers = sqlCommands.ExecuteReader();
                                while (readers.Read())
                                {
                                    Session["Typed"] = readers["Type"].ToString();
                                }
                                sqlConnects.Close();

                                if (Session["Typed"] == null)
                                {
                                    Session["Typed"] = "Student";
                                    Response.Redirect("StudentLogedIn.aspx");
                                }
                                else if (Session["Typed"].ToString() == "Admin")
                                {
                                    Response.Redirect("AdminOverview.aspx");
                                }
                                else if (Session["Typed"].ToString() == "Member")
                                {
                                    Response.Redirect("MemberLogedIn.aspx");
                                }
                                else if (Session["Typed"].ToString() == "Leader")
                                {
                                    Response.Redirect("LeaderLogedIn.aspx");
                                }


                            }
                           
                        }
                        else
                            lblStatus.Text = "Username / Password is wrong";
                    }
                }
                else // if the username doesn't exist, it will show failure
                    lblStatus.Text = "Login failed.";

               
            }
            //catch
            {
                //lblStatus.Text = "Database Error.";
            }

        }

        protected void buttnCreateStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateStudentAccount.aspx");
        }

        protected void buttnCreateMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateMemberAccount.aspx");
        }
    }
    }
