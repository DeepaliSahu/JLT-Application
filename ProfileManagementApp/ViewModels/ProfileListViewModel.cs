using Repository.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfileManagementApp.ViewModels
{
    public class ProfileListViewModel
    {
        public ProfileListViewModel()
        {
            this.Profiles = new List<ProfileViewModel>();
        }

        public ProfileListViewModel(IEnumerable<Profile> profiles)
        {
            this.Profiles = new List<ProfileViewModel>();

            foreach (var p in profiles)
            {
                this.Profiles.Add(new ProfileViewModel(p));
            }
        }

        public List<ProfileViewModel> Profiles { get; set; }
    }
}