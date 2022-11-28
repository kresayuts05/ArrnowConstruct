using ArrnowConstruct.Core.Models.User;
using ArrnowConstruct.Infrastructure.Data.Entities;

namespace ArrnowConstruct.Core.Models.Site
{
    public class SiteViewModel
    {
        public int Id { get; set; }

        public int RoomsCount { get; set; }

        public double Area { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public ClientModel Client { get; set; }

        public ConstructorModel Constructor { get; set; }

        public List<string> RoomsTypes { get; set; }
    }
}
