using ArrnowConstruct.Core.ApplicationAttributes.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrnowConstruct.Infrastructure.Data.Constants.ModelConstraints.SiteConstants;

namespace ArrnowConstruct.Core.Models.Request
{
    public class RequestConfirmViewModel
    {
    //    [Required]
    //    public int Id { get; set; }

        [Required]
        [DateLessThan("ToDate")]
        public string FromDate { get; set; }

        [Required]
        public string ToDate { get; set; }

        [Required]
        public string RequiredDate { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
