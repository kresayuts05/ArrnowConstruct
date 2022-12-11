namespace ArrnowConstruct.Areas.Admin.Models
{
    public class UserDeleteViewModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }
    }
}
