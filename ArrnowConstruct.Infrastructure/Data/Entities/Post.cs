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
            this.CreatedOn = DateTime.Now;
            IsActive = true;
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

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [ForeignKey(nameof(Site))]
        public int SiteId { get; set; }

        public Site Site { get; set; }

        public ICollection<Image> Image{ get; set; } = new HashSet<Image>();

    }
}