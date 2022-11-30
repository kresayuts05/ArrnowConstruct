using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.ReviewImageConstants;


namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class ReviewImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        [ForeignKey(nameof(Review))]
        public int ReviewId { get; set; }

        public Review Review { get; set; }
    }
}
