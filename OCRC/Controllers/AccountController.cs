using OCRC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;


namespace OCRC.Controllers
{
    
    public class AccountController : Controller 
    {
        // GET: Account
        public ActionResult RegisterUser()
        {
            User user = new Models.User();
            user.role = new bool[4];
            return View(user);
        }
        //POST
        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                // set the access level 
                if (user.role[0])
                {
                    user.accesslvl = 1;
                }else if(user.role[1])
                { 
                    user.accesslvl = 2;
                }else if(user.role[2] || user.role[3])
                {
                    user.accesslvl = 3;
                }
                Repo.AddUser(user);
                return RedirectToAction("UserList", "Account");
            }

            return View(user);
        }

        public ActionResult EditUser(int? id)
        {
            ViewBag.Message = "EditUser";
            User user = Repo.findUserById(id);
            user.password = "";
            return View(user);
        }

        //POST
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (user.password == null)
            { 
                ModelState["password"].Errors.Clear();
            }
            if (ModelState.IsValid)
            {
                // reset the access level 
                if (user.role[0])
                {
                    user.accesslvl = 1;
                }
                else if (user.role[1])
                {
                    user.accesslvl = 2;
                }
                else if (user.role[2] || user.role[3])
                {
                    user.accesslvl = 3;
                }
                Repo.UpdateUser(user);
                return RedirectToAction("UserList", "Account");

            }

            return View(user);
        }

        //Get method for UserList in Admin Page
        [Authorize]
        [HttpGet]
        public ActionResult UserList()
        {
            ViewBag.Message = "UserList";

            List<User> vm = Repo.getAllUsers();

            return View(vm);
        }

        //Get method for ForgotPassword Page
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            ViewBag.Message = Session["FirstName"];
            return View();
        }

        //Post method for ForgotPassword Page
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordModel forgot)
        {
            if (ModelState.IsValid)
            {
                if (forgot.IsValid(forgot.email))
                {
                    // Generae password token that will be used in the email link to authenticate user
                    string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

                    // Generate the html link sent via email
                    string resetLink = "<a href='"
                       + Url.Action("ResetPassword", "Account", new { rt = token }, "http")
                       + "'>Reset Password Link</a>";

                    // Email stuff
                    User info = Repo.findUserByEmail(forgot.email);
                    String name = info.fname + " " + info.lname;
                    forgot.changetoken(forgot.email, token);
                    string subject = "Reset your password for " + name;
                    string body = "Please click this clink to reset your password: " + resetLink;
                    string from = "hoangcao@mail.weber.edu";

                    MailMessage message = new MailMessage(from, forgot.email);
                    message.Subject = subject;
                    message.Body = body;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        Credentials = new System.Net.NetworkCredential("hoangcao@mail.weber.edu", "password for email"),
                        DeliveryMethod = SmtpDeliveryMethod.Network
                    };

                    // Attempt to send the email
                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", "Issue sending email: " + e.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "No user found by that email.");
                }
            }

            return View(forgot);
        }

        //Get method for Login Page
        [HttpGet]
        public ActionResult Login()
        {
            UserLogin test = new UserLogin();
            return View(test);
        }

        //Post method for Login Page
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.UserLogin user)
        {

            if (ModelState.IsValid)
            {
                if (user.IsValid(user.email, user.password))
                {
                    ///SiteMapResolveEventHandler
                    FormsAuthentication.SetAuthCookie(user.email, user.rememberme);
                    User info = Repo.findUserByEmail(user.email);
                    Session["Username"] = info.fname + " " + info.lname;
                    Session["Access"] = info.accesslvl;
                    Session["Team"] = info.teamIdentifier;
                    Session["School"] = info.schoolIdentifier;
                    return RedirectToAction("Result", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }

        //Get method for Logout Page
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        //Get method for ResetPassword Page
        [AllowAnonymous]
        public ActionResult ResetPassword(string rt)
        {
            ResetPasswordModel model = new ResetPasswordModel();
            model.ReturnToken = rt;
            return View(model);
        }


        //Post method for ResetPassword Page
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                PasswordReset password = Repo.findTokenByEmail(model.email);
                if (model.changepassword(model.email, model.NewPassword) )
                    {
                        ViewBag.Message = "Successfully Changed";
                    }
               else
                    {
                        ModelState.AddModelError("", "Something went horribly wrong!");
                    }
                
            }        
               return View(model);
        }
    }
}