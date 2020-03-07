using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Repository.DataEntity
{
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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