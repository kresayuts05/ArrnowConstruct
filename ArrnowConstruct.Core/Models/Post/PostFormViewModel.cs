using ArrnowConstruct.Core.Models.Site;
using ArrnowConstruct.Core.Models.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.PostConstants;

namespace ArrnowConstruct.Core.Models.Post
{
    public class PostFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(ShortContentMaxLength)]
        public string ShortContent { get; set; }

        [Required]
        [MaxLength(TiteMaxLength)]
        public string Title { get; set; }

        public ICollection<IFormFile> Images { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public int SiteId { get; set; }
    }
}
