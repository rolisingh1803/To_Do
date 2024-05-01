using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ToDoApplication.Models;
using System.Configuration;

namespace ToDoApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //[Authorize]
        public ActionResult Index()
        {
           
            return View();
        }
       

        [HttpGet]
        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register(User us)
        {
           
            if (ModelState.IsValid)

            {
                
                if (!IsUserExist(us.Email))
                {
                   
                    {
                        DbToDo db = new DbToDo();
                        db.Register(us);
                        ModelState.Clear();
                        
                        ViewBag.SuccessMessage = "Registration Successfully";
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User with same email already exist!");
                }
                
            }

            return View();
        }

        [HttpGet]
        public ActionResult login()
        {
            //DbToDo db = new DbToDo();
            //string data = db.Register().Find(reg => reg.Id == id);             
          
            return View();
        }
        [ValidateAntiForgeryToken]

        public ActionResult login(User2 us)
        {
           // DbToDo db = new DbToDo();
            if (ModelState.IsValid)
            {
                if (IsValidUser(us.Email, us.Password))
                {
                  
                       //Session["firstname"] = user.FirstName.ToString();
                       //return RedirectToAction("UserDashBoard");
                    
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is wrong");
                }
            }
            return View();
        }

     
        public ActionResult logout()
        {
            //FormsAuthentication.SignOut();
            //FormsAuthentication.RedirectFromloginPage();
           // HttpContext.Current.Session.Clear();
            //Session.Abandon();
            return RedirectToAction("index", "Login");
        }


        private bool IsValidUser(string email,string password)
        {
            string constring = ConfigurationManager.ConnectionStrings["conn"].ToString();
            SqlConnection con = new SqlConnection(constring);
          
            bool IsValid = false;
            //string query = "select id from Registration where email=@email and password=@password and id=@id ";
            SqlCommand cmd = new SqlCommand("proc_login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
        
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
               
            con.Open();
           // int i = cmd.ExecuteNonQuery();
            con.Close();

            if (dt.Rows.Count > 0)
            {     
                Session["id"] = dt.Rows[0]["id"];
                IsValid =true;
            }
            return IsValid;
           
        }



        // check user is exist or not 

        private bool IsUserExist(string email)
        {
            string constring = ConfigurationManager.ConnectionStrings["conn"].ToString();
            SqlConnection con = new SqlConnection(constring);
            bool IsUserExist = false;
            string query = "select * from Registration where email=@email";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
               // int i = cmd.ExecuteNonQuery();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    IsUserExist = true;
                }
            }
            return IsUserExist;
        }


       

    }
}