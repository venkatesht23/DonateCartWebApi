using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateCartWebApi.Models
{
    public class Campaign
    {
        public string Title { get; set; }
        public double? TotalAmount { get; set; }
        public double? ProcuredAmount { get; set; }
        public double? BackersCount { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Created { get; set; }
    }
}
