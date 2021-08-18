using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStore.WebUI.Controllers
{
    public class FileDownloadController : Controller
    {
        // GET: FileDownload
        public FileResult Download(string filePath)
        {
            string file = Server.MapPath(filePath);
            if (System.IO.File.Exists(file))
            {
                var fileBytes = System.IO.File.ReadAllBytes(file);
                var fileName = System.IO.Path.GetFileName(filePath);
                return File(fileBytes
                    , System.Net.Mime.MediaTypeNames.Application.Octet
                    , fileName);
            }
            return null;   
        }

        //todo: Session-7.6 Back file Download Fix (Backup.cshml)
        public FileResult DownloadBackupFile(string filePath)
        {
            var validFileName = filePath
                .Replace("/", "")
                .Replace(@"\", "")
                .Replace("//", "")
                .Replace(@"\\", "")
                .Replace("..", "");
            var backupFolder = "~/App_Data/bk";
            string file = Path.Combine(Server.MapPath(backupFolder)
                , validFileName);
            if (System.IO.File.Exists(file))
            {
                var fileBytes = System.IO.File.ReadAllBytes(file);
                return File(fileBytes
                    , System.Net.Mime.MediaTypeNames.Application.Octet
                    , validFileName);
            }
            return null;
        }
    }
}