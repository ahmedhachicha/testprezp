using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testprezp.Models
{
    public class Request
    {
        [Key]
        public int rId { get; set; }
        public ApplicationUserModel sender { get; set; }
        public ApplicationUserModel receiver { get; set; }
        public Boolean status { get; set; }
    }
}
