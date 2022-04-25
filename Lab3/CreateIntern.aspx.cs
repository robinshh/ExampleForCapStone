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
    public partial class CreateIntern : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//don't allow non users to use the page
                if (Session["Username"] != null)
                {// don't allow non members to adjust jobs
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

        protected void CreateJobs_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    using (SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString()))
                    {




                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = sc;
                        cmd.CommandText = "INSERT INTO Internship VALUES (@Titlesss,@Intern,@Date,@ENDIN,'" + ContactList.SelectedValue + "')";

                        cmd.Parameters.Add(new SqlParameter("@Intern", HttpUtility.HtmlEncode(InternshipDescription.Text)));
                        cmd.Parameters.Add(new SqlParameter("@Date", HttpUtility.HtmlEncode(DateStart.Text)));
                        cmd.Parameters.Add(new SqlParameter("@Titlesss", HttpUtility.HtmlEncode(TitleIntern.Text)));
                        cmd.Parameters.Add(new SqlParameter("@ENDIN", HttpUtility.HtmlEncode(DateEnd.Text)));


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
        }

        protected void CreateJobs_Click1(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}