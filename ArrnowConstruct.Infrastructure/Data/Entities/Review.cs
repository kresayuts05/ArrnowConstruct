using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Range(typeof(double), "0", "5")]
        public double Rating { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public List<ReviewImage> Images { get; set; } = new List<ReviewImage>();

        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        [Required]
        [ForeignKey(nameof(Constructor))]
        public int ConstructorId { get; set; }

        public Constructor Constructor { get; set; }

        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
