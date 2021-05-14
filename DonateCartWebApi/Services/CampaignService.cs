using DonateCartWebApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DonateCartWebApi.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public readonly string _baseUrl = string.Empty;
        public CampaignService(HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = _configuration.GetValue<string>("WebUrls:CampaignUrl");
        }
        public async Task<IList<Campaign>> GetCampaigns()
        {
            List<Campaign> campaigns = new List<Campaign>();
            try
            {
                var response = await _httpClient.GetAsync(_baseUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("GetActiveCampaigns Failed");
                }

                var content = await response.Content.ReadAsStringAsync();
                campaigns = JsonConvert.DeserializeObject<List<Campaign>>(content);
                campaigns.OrderByDescending(x => x.TotalAmount);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return campaigns;
        }

        public async Task<IList<Campaign>> GetActiveCampaigns()
        {            
            var campaigns = await GetCampaigns();
            campaigns = campaigns.Where(x => x.EndDate >= DateTime.UtcNow)
                                .Where(x => x.Created <= DateTime.UtcNow && x.Created > DateTime.UtcNow.AddDays(-30))
                                .ToList();
            return campaigns;
        }

        public async Task<IList<Campaign>> GetClosedCampaigns()
        {
            var campaigns = await GetCampaigns();
            campaigns = campaigns.Where(x => x.EndDate <= DateTime.UtcNow || x.ProcuredAmount > x.TotalAmount)
                                .ToList();
            return campaigns;
        }
    }
}
