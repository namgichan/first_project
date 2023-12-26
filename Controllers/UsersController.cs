using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Project.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Net.Http;


namespace Project.Controllers
{
    public class UsersController : Controller
    {
        List<Users> list;
        User_service users;

        public UsersController()
        {
            String connString = "Server=" + "127.0.0.1" + ";Database=" + "Project" + ";port=" + "3306" + ";User=" + "root" + ";password=" + "0000";
            users = new User_service(connString);
        }

        public IActionResult Index()
        {
            list = users.GetUsers();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CreatePost(IFormCollection form)
        {
            var Id = form["userId"].ToString();
            var password = form["pwd"].ToString();
            var Name = form["userName"].ToString();
            var Phone = form["userPhone"].ToString();
            var Email = form["userEmail"].ToString();
            var Addr = form["userAddr"].ToString();
            var gender = form["gender"].ToString();

            int result = users.Create(Id, password, Name, Phone, Email, Addr, gender);
            TempData["result"] = result;
            return View();
        }

        public IActionResult Detail(string id)
        {
            var user = users.Select(id);
            return View(user);
        }

        public ActionResult Delete(string id)
        {
            int result = users.Delete(id);
            return RedirectToAction("Index");
        }

        //public ActionResult DeletePost(string id)
        //{
        //    int result = users.delete_proc(id);
        //    TempData["result"] = result;
        //    return View();
        //}


       public ActionResult Update(string id)
        {
            var user = users.Select(id);
            return View(user);
        }

        public ActionResult Updatepost(IFormCollection form)
        {
            var Id = form["userId"].ToString();
            var password = form["pwd"].ToString();
            var Name = form["userName"].ToString();
            var Phone = form["userPhone"].ToString();
            var Email = form["userEmail"].ToString();
            var Addr = form["userAddr"].ToString();
            var gender = form["gender"].ToString();

            int result = users.Update(Id, password, Name, Phone, Email, Addr, gender);
            TempData["result"] = result;
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Loginpost(IFormCollection form)
        {
            var id = form["userId"].ToString();
            var password = form["pwd"].ToString();

            int result = users.Login(id, password);
            //users.Mypage(id);

            TempData["result"] = result;

            base.HttpContext.Session.SetString("id", id);

            Console.WriteLine(result);
            return View();
        }
    }
}