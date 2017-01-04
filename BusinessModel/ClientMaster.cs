using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.BusinessModel
{
    public class ClientMaster:BaseEntity
    {
        [Key]
        public int ClientID { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public string Notes { get; set; }
        public string CompanyGroup { get; set; }
        public string ClientLogo { get; set; }
        public int TotalEmployeeCount { get; set; }
        public int TurnoverCrore { get; set; }
    }
}