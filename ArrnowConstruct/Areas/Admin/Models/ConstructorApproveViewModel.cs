using System.ComponentModel.DataAnnotations;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.ConstructorConstants;

namespace ArrnowConstruct.Areas.Admin.Models
{
    public class ConstructorApproveViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        [Range(typeof(decimal), SalaryMinValue, SalaryMaxValue)]
        public decimal MinimumSalary { get; set; }
    }
}
