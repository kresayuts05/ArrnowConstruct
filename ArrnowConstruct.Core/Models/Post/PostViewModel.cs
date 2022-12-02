using ArrnowConstruct.Core.Models.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Models.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string CreatedOn { get; set; }

        public string Description { get; set; }

        public string ShortContent { get; set; }

        public string Title { get; set; }

        public int Likes { get; set; }

        public List<string> Images { get; set; }

        public bool IsActive { get; set; }

        public SiteViewModel Site { get; set; }
    }
}
