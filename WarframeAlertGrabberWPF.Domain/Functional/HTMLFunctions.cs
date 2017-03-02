using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace WarframeAlertGrabberWPF.Domain.Functional
{
    class HTMLFunctions
    {
        public static string RemoveHTML(string sentence)
        {
            int start, end = 0;
            start = sentence.IndexOf(">");
            string Temp = sentence.Substring(start + 1);
            end = Temp.IndexOf("<");
            return Temp.Substring(0, end);
        }
    }
}
