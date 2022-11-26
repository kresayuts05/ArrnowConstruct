using ArrnowConstruct.Core.Models.Category;
using ArrnowConstruct.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Models.Request
{
    public class RequestViewModel
    {
        public int Id { get; set; }

        public int RoomsCount { get; set; }

        public List<int> CategoryId { get; set; } = new List<int>();

        public IEnumerable<CategoryModel> RoomsTypes { get; set; } = new List<CategoryModel>();

        public double Area { get; set; }

        public string RequiredDate { get; set; }

        public decimal Budget { get; set; }

        public string Status { get; set; }

        public int ClientId { get; set; }

      //  public Client Client { get; set; }

        public string ClientAddress { get; set; }

        //public string ClientEmail { get; set; }

        public int ConstructorId { get; set; }

       // public Constructor Constructor { get; set; }

        public string ConstructorEmail { get; set; }

        public bool IsActive { get; set; }

    }
}
