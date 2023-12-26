using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;


namespace WebApplication1.Controllers//CRUD 요청
{
    public class NewsCRUDController : Controller
    {
        List<NewsTBL> list;
        news_services news;
        public NewsCRUDController()
        {
            String connString = "Server=" + "127.0.0.1" + ";Database=" +
                    "projectDB" + ";port=" + "3306" + ";User=" + "root" + ";password="
                    + "0000";
            news = new news_services(connString);

        }
        public IActionResult Index()//모든 데이터를 다 출력
        {
            list = news.GetNews();
            return View(list); //html 
        }
        public IActionResult Home()//모든 데이터를 다 출력
        {
            list = news.GetNews();
            return View(list); //html 
        }
        public IActionResult Create()
        {
            return View();
        }
        public ActionResult Createpost(IFormCollection form)
        {
            //var newsnum = Convert.ToInt32(form["NewsNum"].ToString());
            var newsarea = form["NewsArea"].ToString();
            var newstitle = form["NewsTitle"].ToString();
            var newscont = form["NewsCont"].ToString();
            //var newspredate = Convert.ToDateTime(form["NewsPreDate"].ToString());
            //var hits = Convert.ToInt32(form["Hits"].ToString());
            var userid = form["UserID"].ToString();

            int result = news.InsertNews(newsarea, newstitle, newscont, userid);
            TempData["result"] = result;
            return View();
        }
        public ActionResult Update(int id)
        {
            var pnews = news.SelectNews(id);
            return View(pnews);
        }
        [HttpPost]
        public ActionResult Updatepost(IFormCollection form)
        {
            var newsnum = Convert.ToInt32(form["NewsNum"].ToString());
            var newsarea = form["NewsArea"].ToString();
            var newstitle = form["NewsTitle"].ToString();
            var newscont = form["NewsCont"].ToString();
            //var newspredate = Convert.ToDateTime(form["NewsPreDate"].ToString());
            //var hits = Convert.ToInt32(form["Hits"].ToString());
            var userid = form["UserID"].ToString();

            int result = news.UpdateNews(newsnum, newsarea, newstitle, newscont, userid);
            TempData["result"] = result;
            return View();
        }
        public ActionResult Details(int id)
        {
            var pnews = news.SelectNews(id);
            return View(pnews);
        }
        public ActionResult Delete(int id)
        {
            var pnews = news.SelectNews(id);
            return View(pnews);
        }
        public ActionResult Deletepost(int id)
        {
            int result = news.DeleteNews(id);
            TempData["result"] = result;
            return View();
        }
        public IActionResult Search(string titleQuery, string areaQuery)
        {
            ViewBag.Title = "Index";
            ViewBag.SearchTitleQuery = titleQuery; // 제목 검색어를 ViewBag에 저장하여 뷰에서 사용
            ViewBag.SearchAreaQuery = areaQuery;   // 지역 검색어를 ViewBag에 저장하여 뷰에서 사용

            // 여기에 검색 로직을 구현합니다.
            // titleQuery 및 areaQuery를 사용하여 뉴스 항목을 검색하고 결과를 Model에 할당합니다.

            List<NewsTBL> searchResults = news.SearchNews(titleQuery, areaQuery);

            return View("Index", searchResults); // "Index" 뷰로 결과를 반환합니다.
        }

    }
}
