using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarframeAlertGrabberWPF.Domain.Store_Classes.DTOs
{
    public abstract class WarframeItemDTO
    {
        public string guid { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string pubDate { get; set; }

        //public WarframeItemDTO(string guid, string title, string author, string pubdate)
        //{
        //    this.guid = guid;
        //    this.title = title;
        //    this.author = author;
        //    this.pubDate = pubdate;
        //}

        public abstract string GetFormattedString();

        public abstract override string ToString();
    }
}
