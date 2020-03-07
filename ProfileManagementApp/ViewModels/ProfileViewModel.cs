
using ProfileManagementApp.CustomAttribute;
using Repository.DataEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProfileManagementApp.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
        }

        public ProfileViewModel(Profile profile)
        {
            this.Id = profile.Id;
            this.FirstName = profile.FirstName;
            this.MiddleName = profile.MiddleName;
            this.LastName = profile.LastName;
            this.NRIC = profile.NRIC;
            this.CurrentStatus = profile.CurrentStatus;
            if (this.CurrentStatus == "New")
            {
                this.IsActive = null;
            }
            else
            {
                if (this.CurrentStatus == "Active")
                {
                    this.IsActive = true;
                }
                else
                {
                    this.IsActive = false;
                }
            }
            
        }




        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter First Name")]
        [StringLength(15)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Middle Name")]
        [StringLength(15)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(15)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter NRIC")]
        [StringLength(9)]
        [NRICValid]
        [Display(Name = "NRIC")]
        public string NRIC { get; set; }
      
        public string CurrentStatus { get; set; }

        public bool? IsActive { get; set; }
        public string DateCreated { get; set; }

        public string DateLastActivated { get; set; }

        public string DateLastDeactivated { get; set; }

        
    }
}