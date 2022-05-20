using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using XSS.Web.Models;

namespace XSS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HtmlEncoder _htmlEncoder;
        private JavaScriptEncoder _jsEncoder;
        private UrlEncoder _urlEncoder;



        public IActionResult CommentAdd()
        {

            if (System.IO.File.Exists("comment.txt")){
                ViewBag.comments = System.IO.File.ReadAllLines("comment.txt");
            }


            HttpContext.Response.Cookies.Append("email", "berkan@gmail.com");
            HttpContext.Response.Cookies.Append("password", "1234");
            return View();
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CommentAdd(string name, string comment)
        {
            _urlEncoder.Encode(name);

            System.IO.File.AppendAllText("comment.txt", $"{ name}-{ comment}\n");

            ViewBag.name = name;
            ViewBag.comment = comment;

            return RedirectToAction("CommentAdd");
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public HomeController(ILogger<HomeController> logger, HtmlEncoder htmlEncoder, JavaScriptEncoder jsEncoder, UrlEncoder urlEncoder) : this(logger)
        {
            _htmlEncoder = htmlEncoder;
            _jsEncoder = jsEncoder;
            _urlEncoder = urlEncoder;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
