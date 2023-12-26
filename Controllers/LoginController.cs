using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        User_service userservice;
        public LoginController()
        {
            String connString = "Server=" + "127.0.0.1" + ";Database=" + "Project" + ";port=" + "3306" + ";User=" + "root" + ";password=" + "0000";
            userservice = new User_service(connString);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Mypage()
        {
            var id = HttpContext.Session.GetString("id");
            var user = userservice.Select(id);
            return View(user);
        }

        public IActionResult Delete()
        {
            var id = HttpContext.Session.GetString("id");
            int result = userservice.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Update()
        {
            var id = HttpContext.Session.GetString("id");
            var user = userservice.Select(id);
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

            int result = userservice.Update(Id, password, Name, Phone, Email, Addr, gender);
            TempData["result"] = result;
            return View();
        }

    }
}
