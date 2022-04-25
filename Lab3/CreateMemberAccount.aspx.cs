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
    public partial class CreateMemberAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberLogIn.aspx", false);
        }

        protected void lnkAnother_Click(object sender, EventArgs e)
        {
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            txtEmail.Enabled = true;
            txtGradYear.Enabled = true;
            txtTitle.Enabled = true;
            txtPhone.Enabled = true;
            btnSubmit.Enabled = true;
            lnkAnother.Visible = false;
            txtEmail.Text = "";
            txtGradYear.Text = "";
            txtTitle.Text = "";
            txtPhone.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtPassword.Text != "" && txtUsername.Text != "" && txtEmail.Text != "" && txtPhone.Text != "" && txtGradYear.Text != "" && txtTitle.Text != "") // all fields must be filled out
            {
                // COMMIT VALUES
                try
                {
                    System.Data.SqlClient.SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

                    sc.Open();

                    System.Data.SqlClient.SqlCommand createUser = new System.Data.SqlClient.SqlCommand();
                    createUser.Connection = sc;
                    // INSERT USER RECORD
                    createUser.CommandText = "INSERT INTO MemberAccountApplication  (FirstName, LastName, Email,PhoneNumber,GradYear,Title, UserName,Password) " +
                        "VALUES (@FName, @LName,@Email,@PhoneNum,@Grad,@Title, @Username,@Password)";
                    createUser.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                    createUser.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtLastName.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Email", HttpUtility.HtmlEncode(txtEmail.Text)));
                    createUser.Parameters.Add(new SqlParameter("@PhoneNum", HttpUtility.HtmlEncode(txtPhone.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Grad", HttpUtility.HtmlEncode(txtGradYear.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Title", HttpUtility.HtmlEncode(txtTitle.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text))));

                    createUser.ExecuteNonQuery();
                    sc.Close();

                    lblStatus.Text = "User committed!";
                    txtFirstName.Enabled = false;
                    txtLastName.Enabled = false;
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;
                    txtEmail.Enabled = false;
                    txtGradYear.Enabled = false;
                    txtTitle.Enabled = false;
                    txtPhone.Enabled = false;
                    btnSubmit.Enabled = false;
                    lnkAnother.Visible = true;
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
