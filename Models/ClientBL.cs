using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortal.BusinessModel;

namespace JobPortal.Models
{
    public class ClientBL : CoreModel<JobPortalContext, ClientMaster>
    {
        public List<ClientMaster> GetCleint()
        {
            var clientData = (from d in GetAll().Where(x=>x.Status==true)
                             select d).ToList();               
            return clientData;
        }

    }
}