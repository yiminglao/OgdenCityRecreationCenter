using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OCRC.Models
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "We need your email to send you a reset link!")]
        [Display(Name = "User name")]
        [EmailAddress(ErrorMessage = "We cannot find any user with that email")]
        public string email { get; set; }

        //Check if we have the same email in DB
        public bool IsValid(string _email)
        {
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|OCRC.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                string _sql = @"SELECT [email] FROM [dbo].[User] " +
                       @"WHERE [email] = @u";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = _email;               
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        }

        //Create a new token for that email
        public void changetoken(string _email, string _NewToken)
        {
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|OCRC.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                string _sql = @"UPDATE [dbo].[PasswordReset] " + @"SET [token] = @v " +
                       @"WHERE [email] = @u";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = _email;
                cmd.Parameters
                    .Add(new SqlParameter("@v", SqlDbType.NVarChar))
                    .Value = _NewToken;
                cn.Open();
                var reader = cmd.ExecuteReader();
            }
        }
    }
}