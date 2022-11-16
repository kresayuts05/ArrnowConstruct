using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.SiteConstants;


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
        [Range(typeof(double), StartingPriceMinValue, StartingPriceMaxValue)]
        public decimal StartingPrice { get; set; }

        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

        [Required]
        [ForeignKey(nameof(Constructor))]
        public string ConstructorId { get; set; }

        public Constructor Constructor { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public Client Client { get; set; }
    }
}
