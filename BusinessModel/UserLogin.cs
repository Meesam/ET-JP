using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.BusinessModel
{
    public class UserLogin
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LoginDate { get; set; }
        public bool Status { get; set; }
    }
}