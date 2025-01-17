﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Models.User
{
    public class UserModel
    {
        public string  Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string  ProfilePictureUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
