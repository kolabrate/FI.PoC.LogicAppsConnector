using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations;


namespace FI.PoC.CustomerPortal.Models
{
    [Table("Users")]
    public class User
    {
        [Required]
        public bool accountEnabled { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string department { get; set; }
        [Required]
        public string displayName { get; set; }
        public string givenName { get; set; }
        public string jobTitle { get; set; }

        [Required]
        public string mailNickname { get; set; }
        public string passwordPolicies { get; set; }

        [Required]
        public Passwordprofile passwordProfile { get; set; }
        public string mobilePhone { get; set; }
        public string usageLocation { get; set; }

        [Required]
        public string userPrincipalName { get; set; }
    }

    public class Passwordprofile
    {
        public string password { get; set; }
        public bool forceChangePasswordNextSignIn { get; set; }
    }
}

