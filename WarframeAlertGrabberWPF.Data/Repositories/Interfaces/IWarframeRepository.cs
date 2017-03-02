using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeAlertGrabberWPF.Domain.Store_Classes.DTOs;

namespace WarframeAlertGrabberWPF.Data.Repositories.Interfaces
{
    public interface IWarframeRepository //: IBaseRepository<int>
    {
        List<WarframeItemDTO> getAllAlerts();
        //List<WarframeItemDTO> getNonAllerts();
    }
}
