using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FI.PoC.LogicAppsConnector.Models
{   
    public class Notify
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}