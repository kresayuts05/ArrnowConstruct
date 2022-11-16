using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.PostCommentConstants;


namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class PostComment
    {
        public PostComment()
        {
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FullUserNameMaxLength)]
        public string FullUserName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(EmailMaxLength)]
        public string  Email { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public Post Post { get; set; }

        //[ForeignKey(nameof(PostComment))]
        //public int ParentCommentId { get; set; }

        //public PostComment ParentComment { get; set; }
    }
}
