using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class Post
    {
        public Post()
        {
            this.Likes = 0;
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string ShortContent { get; set; }

        [Required]
        [MaxLength(20)]
        public string  Title { get; set; }

        public int Likes { get; set; }

        [Required]
        [ForeignKey(nameof(Site))]
        public int SiteId { get; set; }

        public Site Site { get; set; }

        public List<PostComments> PostComments { get; set; } = new List<PostComments>();

        public List<PostImage> PostImages { get; set; } = new List<PostImage>();

        public List<PostLikes> PostLikes { get; set; } 
    }
}
