using ArrnowConstruct.Core.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Models.Home
{
    public class HomeViewModel
    {
        public List<string> Images{ get; set; }

        public List<PostViewModel> Posts { get; set; }
    }
}
