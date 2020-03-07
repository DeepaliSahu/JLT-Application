using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfileManagementDB.Models
{
    public class ProfileDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NRIC { get; set; }

        public string DateCreated { get; set; }

        public string DateLastActivated { get; set; }

        public string DateLastDeactivated { get; set; }
        public string CurrentStatus { get; set; }
    }
}