using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Infrastructure.Data.Entities
{
    public class Client
    {
        public string Id { get; set; }

        public List<Constructor> Following { get; set; }

        public List<Request> RequestInProcess { get; set; }

        public List<Request> PreviousRequest { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
