using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoApplication.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ToDoApplication.Controllers
{
    public class HomeController : Controller
    {

              DbToDo db = new DbToDo();
        // GET: Home
        public ActionResult Index(ToDoMdl td)
        {
          
            if(Session["id"] != null )
            {
                int userid = Convert.ToInt32(Session["id"]);
                int id = Convert.ToInt32(Session["todoid"]);
                return View(db.GetToDo(userid));
            }
            else
            {
                RedirectToAction("login", "Login");
            }
            return View();
        }

        public JsonResult List()
        {
           

            int userid = Convert.ToInt32(Session["id"]);
            return Json(db.GetToDo(userid), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Add(ToDoMdl td)
        {
            td.Id = Convert.ToInt32(Session["id"]);
            return Json(db.AddToDo(td), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyId(int id)
        {
            int userid = Convert.ToInt32(Session["id"]);
            var ToDoMdl = db.GetToDo(userid).Find(x => x.Id.Equals(id));

            return Json(ToDoMdl, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(ToDoMdl td)
        {

            td.userid = Convert.ToInt32(Session["id"]);
           
            return Json(db.UpdateToDo(td), JsonRequestBehavior.AllowGet);

        }

        public JsonResult Delete(int Id)
        {
            
           return Json(db.DeleteToDo(Id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Checked(ToDoMdl td)
        {
            //td.id = Convert.ToInt32(Session["id"]);
            return Json(db.checkedtodo(td),JsonRequestBehavior.AllowGet);
        }
    }
}