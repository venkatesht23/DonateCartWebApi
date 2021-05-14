using DonateCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateCartWebApi.Services
{
    public interface ICampaignService
    {
        Task<IList<Campaign>> GetCampaigns();
        Task<IList<Campaign>> GetActiveCampaigns();
        Task<IList<Campaign>> GetClosedCampaigns();
    }
}
