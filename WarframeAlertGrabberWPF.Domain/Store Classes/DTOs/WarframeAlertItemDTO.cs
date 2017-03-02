using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarframeAlertGrabberWPF.Domain.Functional;

namespace WarframeAlertGrabberWPF.Domain.Store_Classes.DTOs
{
    public class WarframeAlertItemDTO : WarframeItemDTO
    {
        public string Description;
        public string Faction;
        public string Expiry;
        public string TimeLeft;

        public WarframeAlertItemDTO(string guid, string title, string author, string Description, string PubDate, string faction, string expiry, string timeLeft)
        {
            //this.guid = HTMLFunctions.RemoveHTML(guid);
            //this.title = HTMLFunctions.RemoveHTML(title);
            //this.author = HTMLFunctions.RemoveHTML(author);
            //this.Description = HTMLFunctions.RemoveHTML(Description);
            //this.PubDate = HTMLFunctions.RemoveHTML(PubDate);
            //this.Faction = HTMLFunctions.RemoveHTML(faction);
            //this.Expiry = HTMLFunctions.RemoveHTML(expiry);
            //this.TimeLeft = timeLeft;


            this.guid = (guid);
            this.title = (title);
            this.author = (author);
            this.Description = (Description);
            this.pubDate = (PubDate);
            this.Faction = (faction);
            this.Expiry = (expiry);
            this.TimeLeft = timeLeft;
        }

        public override string GetFormattedString()
        {
            return title + "-" + author + "-" + Description + "-" + pubDate + "-" + Faction + "-" + Expiry + "-" + TimeLeft;
        }

        public override string ToString()
        {
            return
                "########## Alert ########## \n" +
                "Title: " + title + "\n" +
                "Author: " + author + "\n" +
                "Description: " + Description + "\n" +
                "PubDate: " + pubDate + "\n" +
                "Faction: " + Faction + "\n" +
                "Expiry: " + Expiry + "\n" +
                "TimeLeft: " + TimeLeft;
        }
    }
}