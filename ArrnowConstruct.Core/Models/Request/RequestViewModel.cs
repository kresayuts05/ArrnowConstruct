using ArrnowConstruct.Core.Models.Category;
using ArrnowConstruct.Core.Models.User;
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

        public ClientModel Client { get; set; }

        public ConstructorModel Constructor { get; set; }

        public bool IsActive { get; set; }

    }
}
