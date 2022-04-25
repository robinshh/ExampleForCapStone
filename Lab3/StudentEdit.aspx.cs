// File: StudentEdit.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Allow members to view and edit students
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
    public partial class StudentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//only allow people that are logged in to view the page
                if (Session["Username"] != null)
                {//only allow members access
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

        protected void bttnShowInfo_Click(object sender, EventArgs e)
        {
            {
                String sqlFirst = "Select FirstName,LastName,Email,PhoneNumber,UniversityYear,Major,GradYear,UserName from Student Where StudentID=" + StudentList.SelectedValue;
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlFirst, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Session["FN"] = reader["FirstName"].ToString();
                    Session["LN"] = reader["LastName"].ToString();
                    Session["EM"] = reader["Email"].ToString();
                    Session["PN"] = reader["PhoneNumber"].ToString();
                    Session["UY"] = reader["UniversityYear"].ToString();
                    Session["M"] = reader["Major"].ToString();
                    Session["GY"] = reader["GradYear"].ToString();
                    Session["UN"] = reader["UserName"].ToString();

                }
                sqlConnected.Close();
            }
            {
                String FirstN = Session["FN"].ToString();
                txtFirst.Text = FirstN;
                String LastN = Session["LN"].ToString();
                txtLast.Text = LastN;
                String Mail = Session["EM"].ToString();
                txtEm.Text = Mail;
                String PNum = Session["PN"].ToString();
                txtPho.Text = PNum;
                String YearUn = Session["UY"].ToString();
                txtUni.Text = YearUn;
                String Majer = Session["M"].ToString();
                txtMaj.Text = Majer;
                String YearGr = Session["GY"].ToString();
                txtGrad.Text = YearGr;
                String Use = Session["UN"].ToString();
                labelUsername.Text = Use;
            }
        }

        protected void updateJob_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString()))
                {




                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sc;
                    cmd.CommandText = "UPDATE Student SET FirstName=@FNam,LastName=@LNam,Email=@eMail,PhoneNumber=@Numbers,UniversityYear=@UniYear,Major=@Majored,GradYear=@Grady WHERE StudentID ='" + StudentList.SelectedValue + "'";

                    cmd.Parameters.Add(new SqlParameter("@FNam", HttpUtility.HtmlEncode(txtFirst.Text)));
                    cmd.Parameters.Add(new SqlParameter("@LNam", HttpUtility.HtmlEncode(txtLast.Text)));
                    cmd.Parameters.Add(new SqlParameter("@eMail", HttpUtility.HtmlEncode(txtEm.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Numbers", HttpUtility.HtmlEncode(txtPho.Text)));
                    cmd.Parameters.Add(new SqlParameter("@UniYear", HttpUtility.HtmlEncode(txtUni.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Majored", HttpUtility.HtmlEncode(txtMaj.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Grady", HttpUtility.HtmlEncode(txtGrad.Text)));


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

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}