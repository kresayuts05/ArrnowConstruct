using ArrnowConstruct.Infrastructure.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.RoomConstants;


namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [Range(typeof(double), AreaMinValue, AreaMaxValue)]
        public double Area{ get; set; }
    }
}
