using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateCartWebApi.Models.Dtos
{
    public class CampaignDto
    {
        public string Title { get; set; }
        public double? TotalAmount { get; set; }
        public double? BackersCount { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
