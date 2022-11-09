using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class Site
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [Required]
        public decimal StartingPrice { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();

       // public Request Request { get; set; }//HOW TO DO MANY TO MANY?
    }
}
