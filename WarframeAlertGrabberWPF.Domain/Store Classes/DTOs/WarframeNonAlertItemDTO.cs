using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarframeAlertGrabberWPF.Domain.Functional;

namespace WarframeAlertGrabberWPF.Domain.Store_Classes.DTOs
{
    public class WarframeNonAlertItemDTO : WarframeItemDTO
    {
        public WarframeNonAlertItemDTO(string Guid, string Author, string Title, string PubDate)
        {
            this.guid = (Guid);
            this.title = (Title);
            this.author = (Author);
            this.pubDate = (PubDate);
        }

        public override string GetFormattedString()
        {
            return title + "-" + author + "-" + pubDate;
        }

        public override string ToString()
        {
            return
                "##### Invasion / Infestation ##### \n" +
                "Title: " + title + "\n" +
                "Author: " + author + "\n" +
                "PubDate: " + pubDate;
        }
    }
}