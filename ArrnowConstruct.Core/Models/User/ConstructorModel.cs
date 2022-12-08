using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Models.User
{
    public class ConstructorModel
    {
        public UserModel User { get; set; }

        public int ConstructorId { get; set; }

        public decimal MinimumSalary { get; set; }

        public int PostsCount { get; set; }
    }
}
