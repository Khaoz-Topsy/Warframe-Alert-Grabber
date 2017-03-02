using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarframeAlertGrabberWPF.Domain.Store_Classes
{
    public abstract class WarframeItem
    {
        public string guid { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string pubDate { get; set; }


        public abstract string GetFormattedString();

     
    }
}