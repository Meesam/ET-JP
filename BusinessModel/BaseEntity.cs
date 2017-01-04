using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.BusinessModel
{
    public class BaseEntity
    {
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}