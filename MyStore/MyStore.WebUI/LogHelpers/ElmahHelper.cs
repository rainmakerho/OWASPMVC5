using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStore.WebUI.LogHelpers
{
    public class ElmahHelper
    {
        public static void Log(string message)
        {
            var ex = new Exception(message);
            Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
        }
    }
}