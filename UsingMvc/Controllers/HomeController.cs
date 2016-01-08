using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsingMvc.Models;
namespace UsingMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection formCollection)
        {
            var term = formCollection["Term"];
            if (term.Length <= 0) return View();
            term = term.ToLower();

            var f = FindData.FindList(term);
            ViewBag.list = f;
            return View();
        }
    }
}
