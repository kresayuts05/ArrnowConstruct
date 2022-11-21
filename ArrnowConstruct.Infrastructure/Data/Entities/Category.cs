using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.CategoryConstants;

namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public ICollection<Site> Sites { get; set; } = new HashSet<Site>();

        [Required]
        public ICollection<Request> Requests { get; set; } = new HashSet<Request>();
    }
}
