using ArrnowConstruct.Core.ApplicationAttributes.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Models.Request
{
    public class RequestConfirmViewModel
    {
        [Required]
        public string FromDate { get; set; }

        [Required]
        public string ToDate { get; set; }

        public RequestViewModel RequestInformation { get; set; }
    }
}
