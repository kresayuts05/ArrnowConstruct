using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.PostConstants;


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
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(ShortContentMaxLength)]
        public string ShortContent { get; set; }

        [Required]
        [MaxLength(TiteMaxLength)]
        public string Title { get; set; }

        public int Likes { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [ForeignKey(nameof(Site))]
        public int SiteId { get; set; }

        public Site Site { get; set; }

        public ICollection<PostComment> PostComments { get; set; } = new HashSet<PostComment>();

        public ICollection<PostImage> PostImages { get; set; } = new HashSet<PostImage>();

        public ICollection<PostLikes> PostLikes { get; set; } = new HashSet<PostLikes>();



        //[Required]
        //[ForeignKey(nameof(Constructor))]
        //public string ConstructorId { get; set; }

        //public Constructor Constructor { get; set; }

        //[Required]
        //[ForeignKey(nameof(Client))]
        //public string ClientId { get; set; }

        //public Client Client { get; set; }
    }
}
