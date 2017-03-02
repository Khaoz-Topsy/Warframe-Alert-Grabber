using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarframeAlertGrabberWPF.Domain.Functional;
using WarframeAlertGrabberWPF.Domain.Store_Classes.DTOs;

namespace WarframeAlertGrabberWPF.Domain.Store_Classes
{
    public class WarframeAlertItem : WarframeItem
    {
        private string sDescription;
        private string sFaction;
        private string sExpiry;
        public WarframeAlertItem(string guid, string title, string author, string Description, string PubDate, string faction, string expiry)
        {
            this.guid = (guid);
            this.title = (title);
            this.author = (author);
            this.sDescription = (Description);
            this.pubDate = (PubDate);
            this.sFaction = (faction);
            this.sExpiry = (expiry);
        }

        public override string GetFormattedString()
        {
            return title + "-" + author + "-" + sDescription + "-" + pubDate + "-" + sFaction + "-" + sExpiry;
        }

        public string Description
        {
            get
            {
                return sDescription;
            }

            set
            {
                sDescription = value;
            }
        }

        public string Faction
        {
            get
            {
                return sFaction;
            }

            set
            {
                sFaction = value;
            }
        }

        public string Expiry
        {
            get
            {
                return sExpiry;
            }

            set
            {
                sExpiry = value;
            }
        }

        //public DateTime MoreAccurate
        //{
        //    get
        //    {
        //        return dtMoreAccurate;
        //    }

        //    set
        //    {
        //        dtMoreAccurate = value;
        //    }
        //}
    }
}