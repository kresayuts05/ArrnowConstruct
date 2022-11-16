using ArrnowConstruct.Infrastructure.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.RequestConstants;


namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class Request
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(typeof(int), RoomMinCount, RoomMaxCount)]
        public int RoomsCount { get; set; }

        [Required]
        public Month RequiredMonth { get; set; }

        [Required]
        [Range(typeof(decimal), BudgetMinValue, BudgetMaxValue)]
        public decimal Budget { get; set; }

        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        [Required]
        [ForeignKey(nameof(Constructor))]
        public int ConstructorId { get; set; }

        public Constructor Constructor { get; set; }
    }
}
