using MyStore.Domain.Abstract;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MyStore.WebUI.Controllers
{
    //todo: Session-7.3 bypass admin access controll Fix
    //[Authorize(Roles ="Admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductRepository repository;

        

        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            var product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        //todo: Session-7.4.1 Upload Product Fix
        [HttpPost]
        public ActionResult Edit(Product product,
            HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                    var imageFilePath = Server.MapPath(@"~\Uploads\") + image.FileName;
                    image.SaveAs(imageFilePath);
                    product.ImagePath = image.FileName;
                }
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }


        //todo: Session-7.4.2 Upload Product Fix
        [HttpPost]
        public ActionResult EditFix(Product product,
            HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    //check file extensions
                    var imageFileExtensions = "png,jpg,jpeg,gif";
                    var allowedExtensions = imageFileExtensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var isValid = allowedExtensions.Any(y => image.FileName.EndsWith(y));
                    if (isValid)
                    {
                        product.ImageMimeType = image.ContentType;
                        product.ImageData = new byte[image.ContentLength];
                        image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                        var imageFilePath = Server.MapPath(@"~\Uploads\") + image.FileName;
                        image.SaveAs(imageFilePath);
                        product.ImagePath = image.FileName;
                    }
                    else
                    {
                        TempData["message"] = $"{image.FileName} 不允許，只允許上傳 {imageFileExtensions}檔案";
                        return View(product);
                    }
                }
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }


        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            var product = repository.DeleteProduct(productId);
            if(product!=null)
                TempData["message"] = $"{product.Name} was Deleted";
            return RedirectToAction("Index");
        }

        public ViewResult Backup()
        {
            
            return View();
        }

        //todo: Session-3.4 Command Injection Original Backup
        [HttpPost]
        public ActionResult Backup(string backupFileName)
        {
            ViewBag.BackupFileName = backupFileName;
            var output = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(backupFileName))
            {
                var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = @"c:\Windows\System32\cmd.exe",
                    Arguments = $"/C backup.bat {backupFileName}"
                };

                process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.OutputDataReceived += (sender, args) =>
                {
                    output.AppendLine(args.Data);
                    Debug.WriteLine(args.Data);
                };
                process.ErrorDataReceived += (sender, args) =>
                {
                    if (args.Data != null)
                    {
                        output.AppendLine($"{process.StartInfo.Arguments} Fail");
                        output.AppendLine(args.Data);
                        Debug.WriteLine(args.Data);
                    }
                };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();

            }
            else
            {
                TempData["message"] = $"備份檔案名稱不符合!!!";
            }
            ViewBag.ExecuteOutput = output.ToString();
            return View();
        }



        //todo: Session-3.4.1 Command Injection Fix by Regex
        [HttpPost]
        public ActionResult BackupFix(string backupFileName)
        {
            ViewBag.BackupFileName = backupFileName;
            var output = new StringBuilder();
            var rgx = new Regex(@"^[\w\-.\*]+$");
            if (!string.IsNullOrWhiteSpace(backupFileName) 
                && rgx.IsMatch(backupFileName))
            {
                var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = @"c:\Windows\System32\cmd.exe",
                    Arguments = $"/C backup.bat {backupFileName}"
                };

                process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.OutputDataReceived += (sender, args) =>
                {
                    output.AppendLine(args.Data);
                    Debug.WriteLine(args.Data);
                };
                process.ErrorDataReceived += (sender, args) =>
                {
                    if (args.Data != null)
                    {
                        output.AppendLine($"{process.StartInfo.Arguments} Fail");
                        output.AppendLine(args.Data);
                        Debug.WriteLine(args.Data);
                    }
                };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();

            }
            else
            {
                TempData["message"] = $"備份檔案名稱不符合!!!";
            }
            ViewBag.ExecuteOutput = output.ToString();
            return View();
        }
    }
}