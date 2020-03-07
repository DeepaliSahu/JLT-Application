using Repository.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfileManagementApp.ViewModels
{
    public class ProfileManageViewModel:ProfileViewModel
    {

        public ProfileManageViewModel()
            : base()
        {
        }
        public ProfileManageViewModel(Profile profile)
            : base(profile)
        {
        }

        public Profile ToDalEntity()
        {
            return ToDalEntity(new Profile());
        }

        public Profile ToDalEntity(Profile profile)
        {
            profile.FirstName = this.FirstName;
            profile.LastName = this.LastName;
            profile.MiddleName = this.MiddleName;
            profile.NRIC = this.NRIC;
            profile.CurrentStatus = this.CurrentStatus;
            profile.DateCreated = this.DateCreated;
            profile.DateLastActivated = this.DateLastActivated;
            profile.DateLastDeactivated = this.DateLastDeactivated;
            return profile;
        }
    }
}