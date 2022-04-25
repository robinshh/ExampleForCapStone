// File: Scholarship.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Allow members to add and change scholarships
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
    public partial class Scholarship : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//only allow people who are logged in to view the page
                if (Session["Username"] != null)
                {//only allow members to view and use the page
                    if (Session["Typed"].ToString() == "Leader")
                    {

                    }
                    if (Session["Typed"].ToString() == "Member")
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
                String sqlFirst = "Select ScholarshipName,ScholarshipYear, ScholarshipAmount from Scholarship WHERE ScholarshipID='" + ScholarList.SelectedValue + "'";
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlFirst, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Session["shipName"] = reader["ScholarshipName"].ToString();
                    Session["shipYear"] = reader["ScholarshipYear"].ToString();
                    Session["shipAmount"] = reader["ScholarshipAmount"].ToString();

                }
                sqlConnected.Close();
            }
            {
                String hipName = Session["shipName"].ToString();
                scholarnametxt.Text = hipName;
                String hipYear = Session["shipYear"].ToString();
                yeartxt.Text = hipYear;
                String hipAmount = Session["shipAmount"].ToString();
                amounttxt.Text = hipAmount;
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
                    cmd.CommandText = "UPDATE Scholarship SET ScholarshipName=@ipName,ScholarshipYear=@ipYear,ScholarshipAmount=@ipAmount WHERE ScholarshipID ='" + ScholarList.SelectedValue + "'";

                    cmd.Parameters.Add(new SqlParameter("@ipName", HttpUtility.HtmlEncode(scholarnametxt.Text)));
                    cmd.Parameters.Add(new SqlParameter("@ipYear", HttpUtility.HtmlEncode(yeartxt.Text)));
                    cmd.Parameters.Add(new SqlParameter("@ipAmount", HttpUtility.HtmlEncode(amounttxt.Text)));


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

        protected void CreateJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateScholarship.aspx");
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}