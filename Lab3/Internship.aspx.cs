// File: Internship.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Allow a member to add and adjust the internships
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
    public partial class Internship : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {// don't allow someone not signed in to use the page
                if (Session["Username"] != null)
                {//only allow members to use the page
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

        protected void CreateIntern_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateIntern.aspx");
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
                    cmd.CommandText = "UPDATE Internship SET InternshipTitle=@TITTLE,InternshipDescription=@Inte,DateStart=@Dat,DateEnd=@ending WHERE InternshipID ='" + Internlist.SelectedValue + "'";
                    cmd.Parameters.Add(new SqlParameter("@Inte", HttpUtility.HtmlEncode(InternshipDescription.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Dat", HttpUtility.HtmlEncode(DateStart.Text)));
                    cmd.Parameters.Add(new SqlParameter("@TITTLE", HttpUtility.HtmlEncode(TitleIntern.Text)));
                    cmd.Parameters.Add(new SqlParameter("@ending", HttpUtility.HtmlEncode(DateEnd.Text)));


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
                String sqlFirst = "Select InternshipTitle,InternshipDescription,DateStart,DateEnd from Internship WHERE InternshipID='" + Internlist.SelectedValue + "'";
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlFirst, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Session["Titel"] = reader["InternshipTitle"].ToString();
                    Session["Descr"] = reader["InternshipDescription"].ToString();
                    Session["Date"] = reader["DateStart"].ToString();
                    Session["End"] = reader["DateEnd"].ToString();

                }
                sqlConnected.Close();
            }
            {
                String Titless = Session["Titel"].ToString();
                TitleIntern.Text = Titless;
                String Descr = Session["Descr"].ToString();
                InternshipDescription.Text = Descr;
                String Date = Session["Date"].ToString();
                DateStart.Text = Date;
                String END = Session["End"].ToString();
                DateEnd.Text = END;
            }
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}