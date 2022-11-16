using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.ReviewConstants;


namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class Review
    {
        public Review()
        {
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required]
        [Range(typeof(double), RatingMinValue, RatingMaxValue)]
        public double Rating { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<ReviewImage> Images { get; set; } = new HashSet<ReviewImage>();

        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public Post Post { get; set; }

        //[Required]
        //[ForeignKey(nameof(Client))]
        //public string ClientId { get; set; }

        //public Client Client { get; set; }

        //[Required]
        //[ForeignKey(nameof(Constructor))]
        //public string ConstructorId { get; set; }

        //public Constructor Constructor { get; set; }
    }
}
