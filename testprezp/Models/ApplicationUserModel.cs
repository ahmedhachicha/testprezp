using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testprezp.Models
{
     public class ApplicationUserModel
    {
        [Key]
        public string id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }
        [ForeignKey("sent")]
        public ICollection<Request> sent { get; set; }
        [ForeignKey("received ")]
        public ICollection<Request> received { get; set; }

    }
}
