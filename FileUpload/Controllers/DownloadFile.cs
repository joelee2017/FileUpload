using System;
using System.ComponentModel.DataAnnotations;

namespace FileUpload.Controllers
{
    public class DownloadFile
    {
        [Display(Name ="編號")]
        public int ID { get; set; }

        [Display(Name = "檔名")]
        public string FileName { get; set; }

        [Display(Name = "檔案大小")]
        public long Length { get; set; }

        [Display(Name = "上傳日期")]
        public DateTime LastWriteTime { get; set; }
    }
}