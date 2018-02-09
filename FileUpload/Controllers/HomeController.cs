using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            int x = 10;
            int y = x / 0;

            return View();
        }

        [HandleError(ExceptionType = typeof(DivideByZeroException),View = "DivideByZeroException")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";


            int x = 10;
            int y = x / 0;

            return View();
        }

        [HandleError(ExceptionType = typeof(NullReferenceException), View = "NullReferenceException")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            Bitmap bmp = null;
            int w = bmp.Width;

            return View();
        }
    }
}