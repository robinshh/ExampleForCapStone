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
    public partial class UserStudentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //only allow people that are logged in to use the page
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


            if (!IsPostBack)
            {
                String firsted=Session["First"].ToString();
                txtFirstName.Text = firsted;
                String Lasted= Session["Lasts"].ToString();
                txtLastName.Text = Lasted;
                String Emailed= Session["email"].ToString();
                txtEmail.Text = Emailed;
                String Phoned= Session["Phone"].ToString();
                txtPhone.Text = Phoned;
                String UNivered= Session["Univ"].ToString();
                txtUniversityYear.Text = UNivered;
                String Majored= Session["Maj"].ToString();
                txtMajor.Text = Majored;
                String Graded= Session["Grad"].ToString();
                txtGradYear.Text = Graded;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            using (SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString()))
            {




                SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                cmd.Connection = sc;
                cmd.CommandText = "UPDATE Student SET FirstName=@FName,LastName=@LName,Email=@EMAIL,PhoneNumber=@PhoneNum,UniversityYear=@Univ,Major=@MAJ,GradYear=@Grad WHERE UserName ='"+Session["Username"].ToString()+"'";

                cmd.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                cmd.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtLastName.Text)));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", HttpUtility.HtmlEncode(txtEmail.Text)));
                cmd.Parameters.Add(new SqlParameter("@PhoneNum", HttpUtility.HtmlEncode(txtPhone.Text)));
                cmd.Parameters.Add(new SqlParameter("@Univ", HttpUtility.HtmlEncode(txtUniversityYear.Text)));
                cmd.Parameters.Add(new SqlParameter("@MAJ", HttpUtility.HtmlEncode(txtMajor.Text)));
                cmd.Parameters.Add(new SqlParameter("@Grad", HttpUtility.HtmlEncode(txtGradYear.Text)));
                

                sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();



                Response.Redirect("StudentLogedIn.aspx");
            }






        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
    }