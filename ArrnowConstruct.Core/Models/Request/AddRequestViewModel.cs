using ArrnowConstruct.Core.Models.Category;
using ArrnowConstruct.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.RequestConstants;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.UserConstants;

namespace ArrnowConstruct.Core.Models.Request
{
    public class AddRequestViewModel
    {
        [Required]
        [Range(typeof(int), RoomMinCount, RoomMaxCount)]
        public int RoomsCount { get; set; }

        public List<int> CategoryId { get; set; } = new List<int>();

        public IEnumerable<CategoryModel> RoomsTypes { get; set; } = new List<CategoryModel>();

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-M-d}")]
        public string RequiredDate { get; set; }

        [Required]
        [Range(typeof(decimal), BudgetMinValue, BudgetMaxValue)]
        public decimal Budget { get; set; }

        [Required]
        [Range(typeof(double), AreaMinValue, AreaMaxValue)]
        public double Area { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string ConstructorEmail { get; set; }
    }
}
