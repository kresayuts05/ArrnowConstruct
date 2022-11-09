using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
    //    [EnumDataType(typeof(PostStatus))]
        public string  Category { get; set; }

        [Required]
        [MaxLength(200)]
        public double Area{ get; set; }
    }
}
