using DonateCartWebApi.Models;
using DonateCartWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateCartWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet]
        [Route("getCampaigns")]
        public async Task<IEnumerable<Campaign>> GetCampaigns()
        {
            var campaigns = await _campaignService.GetCampaigns();

            return campaigns;
        }

        [HttpGet]
        [Route("activeCampaigns")]
        public async Task<IEnumerable<Campaign>> GetActiveCampaigns()
        {
            var campaigns = await _campaignService.GetActiveCampaigns();

            return campaigns;
        }

        [HttpGet]
        [Route("closedCampaigns")]
        public async Task<IEnumerable<Campaign>> GetClosedCampaigns()
        {
            var campaigns = await _campaignService.GetClosedCampaigns();

            return campaigns;
        }
    }
}
