// File: AccountApplications.aspx.cs
// Author: Madisonsoft
// Date: 3/5/2022
// Purpose: Allow the admin to accept application requests
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
    public partial class AccountApplications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["Username"] != null)
            {//only allow members to view the page
                if (Session["Typed"].ToString() == "Admin")
                {

                }
                else
                {
                    Response.Redirect("MemberLogedIn.aspx");
                }
            }
            else
            {
                Response.Redirect("homepage.aspx");
            }
        }

        protected void ViewMemberAcc_Click(object sender, EventArgs e)
        {//allow the member to see the account selected 
            String sqlQuery = "SELECT FirstName,LastName,Email,PhoneNumber,GradYear,Title,UserName from MemberAccountApplication Where MemberAccAppID=";
            sqlQuery += MemberListDrop.SelectedValue;
            {
                System.Data.SqlClient.SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                DataTable dtForGridView = new DataTable();
                sqlAdapter.Fill(dtForGridView);
                //fill the gridview with selected application info
                MemberAccGrid.DataSource = dtForGridView;
                MemberAccGrid.DataBind();
            }
        }

        protected void ViewStudentAcc_Click(object sender, EventArgs e)
        {//view the student application info
            String sqlQuery = "SELECT FirstName, LastName,Email,PhoneNumber,UniversityYear,Major,GradYear,UserName from StudentAccountApplication Where StudentAccAppID=";
            sqlQuery += StudentListDrop.SelectedValue;
            {
                System.Data.SqlClient.SqlConnection sqlConnects = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnects);
                //fill the application data into the gridview
                DataTable dtForGridView = new DataTable();
                sqlAdapter.Fill(dtForGridView);

                StudentAccGrid.DataSource = dtForGridView;
                StudentAccGrid.DataBind();
            }
        }

        protected void AcceptMemberAcc_Click(object sender, EventArgs e)
        {
            {//pass all of the data from the application into the correct table to be accepted
                string FirstNames = "Select FirstName from MemberAccountApplication WHERE MemberAccAppID=" + MemberListDrop.SelectedValue;
                string LastNames = "Select LastName from MemberAccountApplication WHERE MemberAccAppID=" + MemberListDrop.SelectedValue;
                string Emails = "Select Email from  MemberAccountApplication WHERE MemberAccAppID=" + MemberListDrop.SelectedValue;
                string PhoneNumbers = "Select PhoneNumber FROM MemberAccountApplication  WHERE MemberAccAppID=" + MemberListDrop.SelectedValue;
                string GradYears = "Select GradYear from MemberAccountApplication WHERE MemberAccAppID=" + MemberListDrop.SelectedValue;
                string Titles = "Select Title from  MemberAccountApplication WHERE MemberAccAppID=" + MemberListDrop.SelectedValue;
                string Usernames = "Select UserName from MemberAccountApplication WHERE MemberAccAppID=" + MemberListDrop.SelectedValue;
                string Passwords = "Select Password from MemberAccountApplication WHERE MemberAccAppID=" + MemberListDrop.SelectedValue;

                SqlConnection sqlconnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                //run commands for each individual piece to be inserted into the member table and login table
                SqlCommand FirstCommand = new SqlCommand(FirstNames, sqlconnect);
                SqlCommand LastCommand = new SqlCommand(LastNames, sqlconnect);
                SqlCommand EmailCommand = new SqlCommand(Emails, sqlconnect);
                SqlCommand PhoneCommand = new SqlCommand(PhoneNumbers, sqlconnect);
                SqlCommand GradCommand = new SqlCommand(GradYears, sqlconnect);
                SqlCommand TitleCommand = new SqlCommand(Titles, sqlconnect);
                SqlCommand UsernameCommand = new SqlCommand(Usernames, sqlconnect);
                SqlCommand PasswordCommand = new SqlCommand(Passwords, sqlconnect);

                sqlconnect.Open();
                //get all of the values from the application table
                try {
                    String FirstNameVar = (FirstCommand.ExecuteScalar().ToString());
                    Session["Firsts"] = FirstNameVar;
                    String LastNameVar = (LastCommand.ExecuteScalar().ToString());
                    Session["Lasts"] = LastNameVar;
                    String EmailVar = (EmailCommand.ExecuteScalar().ToString());
                    Session["Emailed"] = EmailVar;
                    String PhoneVar = (PhoneCommand.ExecuteScalar().ToString());
                    Session["Phon"] = PhoneVar;
                    String GradVar = (GradCommand.ExecuteScalar().ToString());
                    Session["Gradss"] = GradVar;
                    String TitleVar = (TitleCommand.ExecuteScalar().ToString());
                    Session["Tittle"] = TitleVar;
                    String UserVar = (UsernameCommand.ExecuteScalar().ToString());
                    Session["Use"] = UserVar;
                    String PassVar = (PasswordCommand.ExecuteScalar().ToString());
                    Session["Passed"] = PassVar;

                    sqlconnect.Close();


                    {//insert the variables into the member table (Member type is automatically just a member because priveledge escalation should be done manually in case of someone get unauthorized access) 
                        string Inserted = "Insert INTO MEMBER VALUES ('" + Session["Firsts"].ToString() + "','" + Session["Lasts"].ToString() + "','" + Session["Emailed"].ToString() + "','" + Session["Phon"].ToString() + "'," + Session["Gradss"].ToString() + ",'" + Session["Tittle"].ToString() + "','" + Session["Use"].ToString() + "','" + TypeList.Text + "','Null.jpg')";

                        SqlConnection sqlconnects = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                        SqlCommand InsertCommand = new SqlCommand(Inserted, sqlconnects);
                        sqlconnects.Open();
                        InsertCommand.ExecuteScalar();
                        sqlconnects.Close();
                    }
                    {//insert all of the values into the login table
                        string Inserting = "Insert INTO LOGINS VALUES ('" + Session["Use"].ToString() + "','" + Session["Passed"].ToString() + "')";
                        SqlConnection sqlconnected = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                        SqlCommand InsertCommand = new SqlCommand(Inserting, sqlconnected);
                        sqlconnected.Open();
                        InsertCommand.ExecuteScalar();
                        sqlconnected.Close();

                    }
                    
                    AcceptMemberResult.Text = "Member Successfully accepted";
                }
                catch
                {
                    AcceptMemberResult.Text = "Something went wrong";
                }
            }
        }

        protected void AcceptStudentAcc_Click(object sender, EventArgs e)
        {
            {//pass all of the data from the application into the correct table to be accepted
                string FirstNames = "Select FirstName from StudentAccountApplication  WHERE StudentAccAppID =" + StudentListDrop.SelectedValue;
                string LastNames = "Select LastName from StudentAccountApplication  WHERE StudentAccAppID =" + StudentListDrop.SelectedValue;
                string Emails = "Select Email from  StudentAccountApplication  WHERE StudentAccAppID =" + StudentListDrop.SelectedValue;
                string PhoneNumbers = "Select PhoneNumber FROM StudentAccountApplication   WHERE StudentAccAppID =" + StudentListDrop.SelectedValue;
                string Univ = "Select UniversityYear from  StudentAccountApplication  WHERE StudentAccAppID =" + StudentListDrop.SelectedValue;
                string Maj = "Select Major from  StudentAccountApplication  WHERE StudentAccAppID =" + StudentListDrop.SelectedValue;
                string GradYears = "Select GradYear from StudentAccountApplication  WHERE StudentAccAppID =" + StudentListDrop.SelectedValue;
                string Usernames = "Select UserName from StudentAccountApplication  WHERE StudentAccAppID =" + StudentListDrop.SelectedValue;
                string Passwords = "Select Password from StudentAccountApplication  WHERE StudentAccAppID =" + StudentListDrop.SelectedValue;

                SqlConnection sqlconnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                //run commands for each individual piece to be inserted into the member table and login table
                SqlCommand FirstCommand = new SqlCommand(FirstNames, sqlconnect);
                SqlCommand LastCommand = new SqlCommand(LastNames, sqlconnect);
                SqlCommand EmailCommand = new SqlCommand(Emails, sqlconnect);
                SqlCommand PhoneCommand = new SqlCommand(PhoneNumbers, sqlconnect);
                SqlCommand UnivCommand = new SqlCommand(Univ, sqlconnect);
                SqlCommand MajCommand = new SqlCommand(Maj, sqlconnect);
                SqlCommand GradCommand = new SqlCommand(GradYears, sqlconnect);
                SqlCommand UsernameCommand = new SqlCommand(Usernames, sqlconnect);
                SqlCommand PasswordCommand = new SqlCommand(Passwords, sqlconnect);

                sqlconnect.Open();

                try {
                    //get all of the values from the application table
                    String FirstNameVar = (FirstCommand.ExecuteScalar().ToString());
                    Session["Firsts"] = FirstNameVar;
                    String LastNameVar = (LastCommand.ExecuteScalar().ToString());
                    Session["Lasts"] = LastNameVar;
                    String EmailVar = (EmailCommand.ExecuteScalar().ToString());
                    Session["Emailed"] = EmailVar;
                    String PhoneVar = (PhoneCommand.ExecuteScalar().ToString());
                    Session["Phon"] = PhoneVar;
                    String UnivVar = (UnivCommand.ExecuteScalar().ToString());
                    Session["Univer"] = UnivVar;
                    String MajVar = (MajCommand.ExecuteScalar().ToString());
                    Session["Majs"] = MajVar;
                    String GradVar = (GradCommand.ExecuteScalar().ToString());
                    Session["Gradss"] = GradVar;
                    String UserVar = (UsernameCommand.ExecuteScalar().ToString());
                    Session["Use"] = UserVar;
                    String PassVar = (PasswordCommand.ExecuteScalar().ToString());
                    Session["Passed"] = PassVar;

                    sqlconnect.Close();


                    {//insert the variables into the member table
                        string Inserted = "Insert INTO Student VALUES ('" + Session["Firsts"].ToString() + "','" + Session["Lasts"].ToString() + "','" + Session["Emailed"].ToString() + "','" + Session["Phon"].ToString() + "','" + Session["Univer"].ToString() + "','" + Session["Majs"].ToString() + "'," + Session["Gradss"].ToString() + ",'" + Session["Use"].ToString() + "','Resume.pdf','Null.jpg')";

                        SqlConnection sqlconnects = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                        SqlCommand InsertCommand = new SqlCommand(Inserted, sqlconnects);
                        sqlconnects.Open();
                        InsertCommand.ExecuteScalar();
                        sqlconnects.Close();
                    }
                    {//insert all of the values into the login table
                        string Inserting = "Insert INTO LOGINS VALUES ('" + Session["Use"].ToString() + "','" + Session["Passed"].ToString() + "')";
                        SqlConnection sqlconnected = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                        SqlCommand InsertCommand = new SqlCommand(Inserting, sqlconnected);
                        sqlconnected.Open();
                        InsertCommand.ExecuteScalar();
                        sqlconnected.Close();

                    }
                    AcceptStudentResult.Text = "Student Accepted Successfully";

                }
                catch
                    {
                    AcceptStudentResult.Text = "Something went wrong";
                }

            }
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminOverview.aspx");
        }
    }
}