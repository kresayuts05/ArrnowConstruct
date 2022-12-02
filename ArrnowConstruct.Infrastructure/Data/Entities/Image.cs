using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UrlPath { get; set; }

        public User User { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public DateTime? DeletedOn { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public Post Post { get; set; }

        //Add key for reviws
    }
}