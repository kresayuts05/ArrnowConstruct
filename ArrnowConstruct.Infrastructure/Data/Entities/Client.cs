using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Constructor> Following { get; set; } = new HashSet<Constructor>();

        public ICollection<Request> Requests { get; set; } = new HashSet<Request>();

        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

        //public ICollection<Request> PreviousRequests { get; set; } = new HashSet<Request>();
    }
}
