using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarframeAlertGrabberWPF.Domain.Functional;
using WarframeAlertGrabberWPF.Domain.Store_Classes.DTOs;

namespace WarframeAlertGrabberWPF.Domain.Store_Classes
{
    public class WarframeNonAlertItem : WarframeItem
    {
        public WarframeNonAlertItem(string Guid, string Title, string Author, string PubDate)
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
    }
}