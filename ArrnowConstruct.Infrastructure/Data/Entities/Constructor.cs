using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.ConstructorConstants;


namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class Constructor
    {
        public Constructor()
        {
            this.IsActive = true;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        [Range(typeof(decimal), SalaryMinValue, SalaryMaxValue)]
        public decimal Salary { get; set; }

        public ICollection<Site> Sites { get; set; } = new HashSet<Site>();

        public bool IsActive { get; set; }
    }
}
