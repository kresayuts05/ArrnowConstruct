using ArrnowConstruct.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.RequestConstants;

namespace ArrnowConstruct.Core.Models.Request
{
    public class AddRequestViewModel
    {
        [Required]
        [Range(typeof(int), RoomMinCount, RoomMaxCount)]
        public int RoomsCount { get; set; }

        [Required]
        public string RequiredMonth { get; set; }

        [Required]
        [Range(typeof(decimal), BudgetMinValue, BudgetMaxValue)]
        public decimal Budget { get; set; }


        [Required]
        [Range(typeof(double), BudgetMinValue, BudgetMaxValue)]
        public double TotalArea { get; set; }

  

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int ConstructorId { get; set; }
    }
}
