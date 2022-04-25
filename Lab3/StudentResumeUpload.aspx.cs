// File: StudentResumeUpload.aspx.cs
// Author: Madisonsoft
// Date: 3/5/2022
// Purpose: Allow the student to upload their resume to be used later
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class StudentResumeUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            {//dont allow anyone that isn't signed in to view the page
                if (Session["Username"] != null)
                {//make sure the person is a student
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

            }

            {//get the studentID to use when uploading the filename into sql
                String sqlQuery = "Select StudentID From Student WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                sqlConnect.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Session["Student"] = reader["StudentID"].ToString();
                }
                sqlConnect.Close();

            }
        }

        protected void bttnUpload_Click(object sender, EventArgs e)
        {
            if (fileUploadText.HasFile)
                // Call a helper method routine to save the file.
                SaveFile(fileUploadText.PostedFile);
            else
                // Notify the user that a file was not uploaded.
                txtDisplay.Text = "You did not specify a file to upload.";
            //put the file into sql
            SqlConnection sqlConnect = new
            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            String sqlQuery = "Update Student Set Files = '" + fileUploadText.FileName + "'"+" Where StudentID="+ Session["Student"];
            
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnect);
            try
            {

                sqlConnect.Open();
                command.ExecuteNonQuery();


            }
            catch (SqlException)
            {
                txtDisplay.Text = "Something went wrong";
            }
            finally
            {
                sqlConnect.Close();

            }

            void SaveFile(HttpPostedFile file)
            {

                


                //save the file into the folder created
                String fpath = Request.PhysicalApplicationPath + "TextFile\\" + fileUploadText.FileName;
                fileUploadText.PostedFile.SaveAs(fpath);
                
                txtDisplay.Text = "Success!";

            }
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}