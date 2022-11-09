using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class Constructor
    {
        public string Id { get; set; }

        public List<Client> Followers { get; set; }

        public decimal MinimumSalary { get; set; }

        public List<Site> CurrentSites { get; set; }

        public List<Site> FutureSites { get; set; }
    }
}
