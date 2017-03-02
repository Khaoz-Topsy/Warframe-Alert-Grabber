using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WarframeAlertGrabberWPF.Domain.Functional
{
    public class WarframeDashData
    {
        public string readData()
        {
            //var json = new WebClient().DownloadString("http://content.warframe.com/dynamic/worldState.php");
            
            //return json;

            return new WebClient().DownloadString("http://content.warframe.com/dynamic/worldState.php");
        }

        private string RemoveBackSlashes(string corrupted)
        {
            string Result = "";

            return Result;
        }
    }
}