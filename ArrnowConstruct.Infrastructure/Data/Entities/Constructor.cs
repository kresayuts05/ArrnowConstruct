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
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Client> Followers { get; set; } = new HashSet<Client>();

        [Required]
        [Range(typeof(decimal), SalaryMinValue, SalaryMaxValue)]
        public decimal Salary { get; set; }

        public ICollection<Site> Sites { get; set; } = new HashSet<Site>();

        //public ICollection<Site> FutureSites { get; set; } = new HashSet<Site>();
    }
}
