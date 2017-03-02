using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeAlertGrabberWPF.Data.Repositories.Interfaces;
using WarframeAlertGrabberWPF.Domain.Functional;
using WarframeAlertGrabberWPF.Domain.Store_Classes.DTOs;

namespace WarframeAlertGrabberWPF.Data.Repositories
{
    public class WarframeRepository : IWarframeRepository
    {
        public List<WarframeItemDTO> getAllAlerts()
        {
            WarframeData data = new WarframeData();
            return data.ReadXMLAlerts();
        }

        //public List<WarframeItemDTO> getNonAllerts()
        //{
        //    WarframeData data = new WarframeData();
        //    return data.ReadXMLOnlyNonAlerts();
        //}
    }
}
