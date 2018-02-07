using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult Upload(IEnumerable<HttpPostedFileBase> files)
        {
            if(files.First() != null)
            {
                foreach(HttpPostedFileBase file in files)
                {
                    string SourceFilename = Path.GetFileName(file.FileName);//取得file的名稱

                    string TargetFilename = Path.Combine(Server.MapPath("~/Uploads"), SourceFilename);
                    //宣告存放位置

                    file.SaveAs(TargetFilename);
                }
            }
            return RedirectToAction("Index");
        }
    }
}