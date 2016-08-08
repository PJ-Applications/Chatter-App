using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatter.Models
{
    public class Chat
    {
        [Key]
        public int ChatID { get; set; }
        [MaxLength(150)]
        public string Post { get; set; }
        public DateTime TimeStamp { get; set; }
        


        public virtual ApplicationUser User { get; set; }
    }
}