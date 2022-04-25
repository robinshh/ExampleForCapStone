using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class CreateStudentAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx", false);
        }

        protected void lnkAnother_Click(object sender, EventArgs e)
        {
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            txtEmail.Enabled = true;
            txtGradYear.Enabled = true;
            txtMajor.Enabled = true;
            txtPhone.Enabled = true;
            txtUniversityYear.Enabled = true;
            btnSubmit.Enabled = true;
            lnkAnother.Visible = false;
            txtEmail.Text = "";
            txtGradYear.Text = "";
            txtUniversityYear.Text = "";
            txtMajor.Text = "";
            txtPhone.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtPassword.Text != "" && txtUsername.Text != "" && txtEmail.Text != "" && txtPhone.Text != "" && txtGradYear.Text != "" && txtMajor.Text != "" && txtUniversityYear.Text != "") // all fields must be filled out
            {
                // COMMIT VALUES
                try
                {
                    System.Data.SqlClient.SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

                    sc.Open();

                    System.Data.SqlClient.SqlCommand createUser = new System.Data.SqlClient.SqlCommand();
                    createUser.Connection = sc;
                    //INSERT USER RECORD
                    createUser.CommandText = "INSERT INTO StudentAccountApplication  (FirstName, LastName, Email,PhoneNumber,UniversityYear,Major,GradYear,UserName,Password) " +
                        "VALUES (@FName, @LName,@Email,@PhoneNum,@Univers,@maj,@Grad, @Username,@Password)";
                    createUser.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                    createUser.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtLastName.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Email", HttpUtility.HtmlEncode(txtEmail.Text)));
                    createUser.Parameters.Add(new SqlParameter("@PhoneNum", HttpUtility.HtmlEncode(txtPhone.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Univers", HttpUtility.HtmlEncode(txtUniversityYear.Text)));
                    createUser.Parameters.Add(new SqlParameter("@maj", HttpUtility.HtmlEncode(txtMajor.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Grad", HttpUtility.HtmlEncode(txtGradYear.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text))));
                    createUser.ExecuteNonQuery();
                    sc.Close();

                    lblStatus.Text = "User committed!";
                    txtFirstName.Enabled = true;
                    txtLastName.Enabled = true;
                    txtUsername.Enabled = true;
                    txtPassword.Enabled = true;
                    txtEmail.Enabled = true;
                    txtGradYear.Enabled = true;
                    txtMajor.Enabled = true;
                    txtUniversityYear.Enabled = true;
                    txtPhone.Enabled = true;
                    btnSubmit.Enabled = true;
                    lnkAnother.Visible = false;
                }
                catch
                {
                    lblStatus.Text = "Database Error - User not committed.";
                }
            }
            else
                lblStatus.Text = "Fill all fields.";
        }


    }
}