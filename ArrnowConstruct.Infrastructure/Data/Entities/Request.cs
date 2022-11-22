using ArrnowConstruct.Infrastructure.Constants.Enums;
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
        [Range(typeof(int), AreaMinValue, AreaMaxValue)]
        public double Area { get; set; }

        [Required]
        public string RequiredDate { get; set; }

        [Required]
        [Range(typeof(decimal), BudgetMinValue, BudgetMaxValue)]
        public decimal Budget { get; set; }

        [Required]
        [EnumDataType(typeof(StatusEnum))]
        public string Status { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        [Required]
        [ForeignKey(nameof(Constructor))]
        public int ConstructorId { get; set; }

        public Constructor Constructor { get; set; }

        [Required]
        public ICollection<Category> RoomsTypes { get; set; } = new HashSet<Category>();
    }
}
