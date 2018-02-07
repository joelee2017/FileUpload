using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Uploads"));
            
            var query =(
                from file in di.EnumerateFiles("*.*")
                select file).Select((file, Index)=> new DownloadFile
                {
                    ID = Index + 1,
                    FileName =file.Name,
                    Length =file.Length,
                    LastWriteTime = file.LastWriteTime
                    
                });

            return View(query);
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


        public FileResult Download(string FileName)
        {
            string DownloadFilename = Path.Combine(Server.MapPath("~/Uploads"), FileName);
            ContentDisposition cd = new ContentDisposition
            {
                FileName = FileName, //設定下載檔案名稱
                Inline = false,      //禁止直接顯示檔案內容,針對過舊版本Browser
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(DownloadFilename, MediaTypeNames.Application.Octet);
        }
    }
}