using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Models.Profile
{
    public class ProfileViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string ProfilePictureUrl { get; set; }

        public int PostsCount { get; set; }

        public int Followers { get; set; }

        public int Following { get; set; }

        public List<string> Images { get; set; } = new List<string>();

        public bool IsConstructor { get; set; }

    }
}
