using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.ConstructorConstants;

namespace ArrnowConstruct.Core.Models.User
{
    public class ConstructorModel
    {
        public UserModel User { get; set; }

        public int ConstructorId { get; set; }

        [Required]
        [Range(typeof(decimal), SalaryMinValue, SalaryMaxValue)]
        public decimal MinimumSalary { get; set; }

        public int PostsCount { get; set; }
    }
}
