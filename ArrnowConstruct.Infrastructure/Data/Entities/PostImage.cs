using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.PostImageConstants;


namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class PostImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
