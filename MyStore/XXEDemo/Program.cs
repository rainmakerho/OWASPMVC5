using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlBomb
{
    class Program
    {
        public const long ONE_MB = 1000000;

        static void Main(string[] args)
        {
            //取得使用的記憶體
            var initMemory = $"Init Memory: {Process.GetCurrentProcess().WorkingSet64 / ONE_MB} MB";
            Stopwatch sw = Stopwatch.StartNew();
            XmlDocReadWin_INI_File();
            sw.Stop();
            Console.WriteLine(initMemory);
            Console.WriteLine($"Parse Time: {sw.ElapsedMilliseconds:#,##0} ms");
            //取得使用的記憶體
            Console.WriteLine($"End Memory: {Process.GetCurrentProcess().WorkingSet64 / ONE_MB} MB");
            Console.ReadKey();
        }

        static void XmlDocReadWin_INI_File()
        {
            var doc = new XmlDocument();
            //todo: Session-6.2 Fix XXE XXEDemo.EXE
            //doc.XmlResolver = null;
            doc.Load("XmlDemo.xml");
            Console.WriteLine("Read From XmlDemo.Xml");
            Console.WriteLine(doc.InnerText);
        }


        
    }
}
