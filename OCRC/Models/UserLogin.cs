using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OCRC.Models;


namespace OCRC.Models
{
    
    public class UserLogin
    {
        [Required]
        [Display(Name = "User name")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool rememberme { get; set; }

        /// Checks if user with given password exists in the database
        public bool IsValid(string _email, string _password)
        {
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|OCRC.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                string _sql = @"SELECT [email] FROM [dbo].[User] " +
                       @"WHERE [email] = @u AND [password] = @p ";
                 var cmd = new SqlCommand(_sql, cn);
                 cmd.Parameters
                     .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                     .Value = _email;
                cmd.Parameters
                     .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                     .Value = SHA1.Encode(_password);
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
    }
}