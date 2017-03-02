using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using WarframeAlertGrabberWPF.Domain.Store_Classes;
using WarframeAlertGrabberWPF.Domain.Store_Classes.DTOs;

namespace WarframeAlertGrabberWPF.Domain.Functional
{
    public class WarframeData
    {
        private List<WarframeItemDTO> MyItems = new List<WarframeItemDTO>();

        //public List<WarframeItemDTO> ReadXML()
        //{
        //    WebRequest request = WebRequest.Create("http://content.warframe.com/dynamic/rss.php");
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    Stream dataStream = response.GetResponseStream();
        //    StreamReader reader = new StreamReader(dataStream);

        //    //((HttpWebResponse)response).StatusCode;

        //    if(response.StatusCode.ToString().Equals("OK"))
        //    {
        //        string ResponseFromServer = reader.ReadLine();
        //        ResponseFromServer = reader.ReadLine();
        //        ResponseFromServer = reader.ReadLine();
        //        ResponseFromServer = reader.ReadLine();
        //        ResponseFromServer = reader.ReadLine();
        //        ResponseFromServer = reader.ReadLine();
        //        ResponseFromServer = reader.ReadLine();
        //        ResponseFromServer = reader.ReadLine();
        //        ResponseFromServer = reader.ReadLine();
        //        ResponseFromServer = reader.ReadLine();
        //        MyItems.Clear();

        //        string Guid = "";
        //        string Title = "";
        //        string Author = "";
        //        string PubDate = "";
        //        string Desc = "";
        //        string Pubdate = "";
        //        string Faction = "";
        //        string Expiry = "";

        //        while (String.IsNullOrEmpty(ResponseFromServer) == false)
        //        {
        //            //if (Display)
        //            //{
        //            //Temp += ResponseFromServer;
        //            //tester.Text += "\n";

        //            ResponseFromServer = reader.ReadLine();
        //            if (ResponseFromServer.Contains("<guid>"))
        //            {
        //                Guid = ResponseFromServer;
        //                ResponseFromServer = reader.ReadLine();
        //                if (ResponseFromServer.Contains("<author>"))
        //                {
        //                    Author = ResponseFromServer;

        //                    ResponseFromServer = reader.ReadLine();
        //                    if (ResponseFromServer.Contains("<title>"))
        //                    {
        //                        Title = ResponseFromServer;
        //                    }

        //                    ResponseFromServer = reader.ReadLine();
        //                    if (ResponseFromServer.Contains("<pubDate>"))
        //                    {
        //                        PubDate = ResponseFromServer;
        //                    }

        //                    WarframeNonAlertItem t = new WarframeNonAlertItem(Guid, Title, Author, PubDate);
        //                    MyItems.Add(t);
        //                    ResponseFromServer = reader.ReadLine();
        //                }
        //                else
        //                {
        //                    if (ResponseFromServer.Contains("<title>"))
        //                    {
        //                        Title = ResponseFromServer;
        //                    }

        //                    ResponseFromServer = reader.ReadLine();
        //                    if (ResponseFromServer.Contains("<author>"))
        //                    {
        //                        Author = ResponseFromServer;
        //                    }

        //                    ResponseFromServer = reader.ReadLine();
        //                    if (ResponseFromServer.Contains("<description>"))
        //                    {
        //                        Desc = ResponseFromServer;
        //                    }

        //                    ResponseFromServer = reader.ReadLine();
        //                    if (ResponseFromServer.Contains("<pubDate>"))
        //                    {
        //                        Pubdate = ResponseFromServer;
        //                    }

        //                    ResponseFromServer = reader.ReadLine();
        //                    if (ResponseFromServer.Contains("<wf:faction>"))
        //                    {
        //                        Faction = ResponseFromServer;
        //                    }

        //                    ResponseFromServer = reader.ReadLine();
        //                    if (ResponseFromServer.Contains("<wf:expiry>"))
        //                    {
        //                        Expiry = ResponseFromServer;
        //                    }

        //                    MyItems.Add(new WarframeAlertItem(Guid, Title, Author, Desc, Pubdate, Faction, Expiry));
        //                    ResponseFromServer = reader.ReadLine();
        //                }
        //            }
        //            ResponseFromServer = reader.ReadLine();
        //        }

        //        reader.Close();
        //        response.Close();

        //        return MyItems;
        //    }
        //    else
        //    {
        //        MyItems.Clear();

        //        return MyItems;
        //    }
        //}

        public string ConvertDateString(string Date)
        {
            int start = 0;
            start = Date.IndexOf(" ");
            string Temp = Date.Substring(start);
            string Current = Temp;
            string Old = Temp;


            while (Temp.Contains(":") == true)
            {
                Old = Current;
                Current = Temp;
                Temp = Temp.Substring(start);
            }

            start = Old.Trim().IndexOf(" ");
            return CompareTimes(Old.Trim().Substring(0, start));
        }

        private string CompareTimes(string Time)
        {
            int start = 0;
            start = Time.IndexOf(":");
            int ExpiryHour = Convert.ToInt32(Time.Substring(0, start));
            ExpiryHour += 2;

            if(ExpiryHour > 23)
            {
                ExpiryHour = ExpiryHour - 24;
            }

            string Temp = Time.Substring(start+1);

            start = Temp.IndexOf(":");
            int ExpiryMinute = Convert.ToInt32(Temp.Substring(0, start));

            int ExpirySecond = Convert.ToInt32(Temp.Substring(start + 1));
            
            string Now = DateTime.Now.ToString("HH:mm:ss");
            int CurrentTimeHour = Convert.ToInt32(Now.Substring(0, 2)); //Adjusted for Timezone
            int CurrentTimeMinute = Convert.ToInt32(Now.Substring(3, 2));
            int CurrentTimeSecond = Convert.ToInt32(Now.Substring(6, 2));

            int TimeLeftHour;
            int TimeLeftMinute;
            int TimeLeftSecond;

            if (ExpirySecond >= CurrentTimeSecond) //Supposed to be
            {
                TimeLeftSecond = ExpirySecond - CurrentTimeSecond;
            }
            else
            {
                ExpirySecond = ExpirySecond + 60;
                TimeLeftSecond = ExpirySecond - CurrentTimeSecond;
                ExpiryMinute--;
            }

            if (ExpiryMinute >= CurrentTimeMinute) //Supposed to be
            {
                TimeLeftMinute = ExpiryMinute - CurrentTimeMinute;
            }
            else
            {
                ExpiryMinute = ExpiryMinute + 60;
                TimeLeftMinute = ExpiryMinute - CurrentTimeMinute;
                ExpiryHour--;
            }
            
            if (ExpiryHour >= CurrentTimeHour) //Supposed to be
            {
                TimeLeftHour = ExpiryHour - CurrentTimeHour;
            }
            else
            {
                //ExpiryHour = ExpiryHour + 24;
                //TimeLeftHour = ExpiryHour - CurrentTimeHour;
                return "Expired";
            }

            string Result = "";

            if (TimeLeftHour > 0) { Result = Result + " " + TimeLeftHour + "h"; }
            if (TimeLeftMinute > 0) { Result = Result + " " + TimeLeftMinute + "m"; }
            else { Result = "Expired"; }

            return Result;
        }

        public List<WarframeItemDTO> ReadXMLAlerts()
        {
            List<WarframeItemDTO> MyAlertItems = new List<WarframeItemDTO>();

            WebRequest request = WebRequest.Create("http://content.warframe.com/dynamic/rss.php");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(dataStream);


            XmlSerializer serializer = new XmlSerializer(typeof(rss));
            rss WarframeData = (rss)serializer.Deserialize(new XmlTextReader(dataStream));

            if (response.StatusCode.ToString().Equals("OK"))
            {
                foreach (rssChannelItem AlertItem in WarframeData.channel.item)
                {
                    if (AlertItem.Items.Length == 7)
                    {
                        WarframeAlertItemDTO temp = new WarframeAlertItemDTO
                            (
                                AlertItem.Items[0],
                                AlertItem.Items[1],
                                AlertItem.Items[2],
                                AlertItem.Items[3],
                                AlertItem.Items[4],
                                AlertItem.Items[5],
                                AlertItem.Items[6],
                                "Expiry"
                            );
                        MyAlertItems.Add(temp);
                    }

                    if(AlertItem.Items.Length == 4)
                    {
                        WarframeNonAlertItemDTO temp = new WarframeNonAlertItemDTO
                            (
                                AlertItem.Items[0],
                                AlertItem.Items[1],
                                AlertItem.Items[2],
                                AlertItem.Items[3]
                            );
                        MyAlertItems.Add(temp);
                    }
                }
            }
            else
            {
                MyAlertItems.Clear();
            }

            return MyAlertItems;
        }

        public List<WarframeNonAlertItemDTO> ReadXMLOnlyNonAlerts()
        {
            List<WarframeNonAlertItemDTO> MyNonAlertItems = new List<WarframeNonAlertItemDTO>();
            WebRequest request = WebRequest.Create("http://content.warframe.com/dynamic/rss.php");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            //((HttpWebResponse)response).StatusCode;

            if (response.StatusCode.ToString().Equals("OK"))
            {
                string ResponseFromServer = reader.ReadLine();
                ResponseFromServer = reader.ReadLine();
                ResponseFromServer = reader.ReadLine();
                ResponseFromServer = reader.ReadLine();
                ResponseFromServer = reader.ReadLine();
                ResponseFromServer = reader.ReadLine();
                ResponseFromServer = reader.ReadLine();
                ResponseFromServer = reader.ReadLine();
                ResponseFromServer = reader.ReadLine();
                ResponseFromServer = reader.ReadLine();
                MyItems.Clear();

                string Guid = "";
                string Title = "";
                string Author = "";
                string PubDate = "";
                string Desc = "";
                string Pubdate = "";
                string Faction = "";
                string Expiry = "";

                while (String.IsNullOrEmpty(ResponseFromServer) == false)
                {
                    //if (Display)
                    //{
                    //Temp += ResponseFromServer;
                    //tester.Text += "\n";

                    ResponseFromServer = reader.ReadLine();
                    if (ResponseFromServer.Contains("<guid>"))
                    {
                        Guid = ResponseFromServer;
                        ResponseFromServer = reader.ReadLine();
                        if (ResponseFromServer.Contains("<author>"))
                        {
                            Author = ResponseFromServer;

                            ResponseFromServer = reader.ReadLine();
                            if (ResponseFromServer.Contains("<title>"))
                            {
                                Title = ResponseFromServer;
                            }

                            ResponseFromServer = reader.ReadLine();
                            if (ResponseFromServer.Contains("<pubDate>"))
                            {
                                PubDate = ResponseFromServer;
                            }

                            MyNonAlertItems.Add(new WarframeNonAlertItemDTO(Guid, Title, Author, PubDate));
                            ResponseFromServer = reader.ReadLine();
                        }
                        else
                        {
                            ResponseFromServer = reader.ReadLine();
                            ResponseFromServer = reader.ReadLine();
                            ResponseFromServer = reader.ReadLine();
                            ResponseFromServer = reader.ReadLine();
                            ResponseFromServer = reader.ReadLine();
                            ResponseFromServer = reader.ReadLine();
                        }
                    }
                    ResponseFromServer = reader.ReadLine();
                }

                reader.Close();
                response.Close();

                return MyNonAlertItems;
            }
            else
            {
                MyItems.Clear();

                return MyNonAlertItems;
            }
        }
    }
}