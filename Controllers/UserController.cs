using _28FebbraioEs.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _28FebbraioEs.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM [User] WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userType = reader["UserType"].ToString();
                                HttpCookie userTypeCookie = new HttpCookie("userType", userType);
                                Response.Cookies.Add(userTypeCookie);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewBag.Error = "Username o password errati";
                            }
                        }
                    }
                }   
            }
                return View();
        }
    }
}